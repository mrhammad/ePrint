using nmsCommon;
using ClosedXML.Excel;
using nmsConnection;
using nmsLanguage;
using System.IO;
using System.Text;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.WebStore
{
    public partial class estore_reports : BaseClass, IRequiresSessionState
    {

        public BaseClass objBc = new BaseClass();

        public BaseClass objBase = new BaseClass();

        public commonclass comm = new commonclass();

        public commonclass objCommon = new commonclass();

        public languageClass objlang = new languageClass();

        public languageClass objLanguage = new languageClass();

        public commonclass objJava = new commonclass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = string.Empty;

        public long StoreUserID;

        public int CompanyID;

        public string deptScreenName = string.Empty;

        public string Reports_type = string.Empty;

        public long reportid;

        public string strImagePath = string.Empty;

        public string DateFormat = string.Empty;

        public long AccountID;

        public int UserID;

        public bool IsDisplayLocation;

        public string CustomField1 = string.Empty;

        public string CustomField2 = string.Empty;

        public string CustomField3 = string.Empty;

        public string CustomField4 = string.Empty;

        public string CustomField5 = string.Empty;

        public string CustomField6 = string.Empty;

        public string Paper_Stock = string.Empty;

        public string Paper_Stock_Lenght = string.Empty;

        public string Weight_gsm = string.Empty;

        public bool AllowUnApprovedOrder;

        public string JobFromDate = string.Empty;

        public string JobToDate = string.Empty;

        public bool isstockitem;

        public bool isreplenshes;

        public string orderFromdate = string.Empty;

        public string orderTodate = string.Empty;

        public string FromDate = string.Empty;

        public string ToDate = string.Empty;

        public string jobreport_systemgenname = string.Empty;

        public string orderFROMdate_custreport = string.Empty;

        public string orderTOdate_custreport = string.Empty;

        public string jobFROMdate_custreport = string.Empty;

        public string jobTOdate_custreport = string.Empty;

        public string invoiceFROMdate_custreport = string.Empty;

        public string invoiceTOdate_custreport = string.Empty;

        public int PageNumber = 1;

        public int PageSize = 50;

        public bool flagdates;

        public bool flacosts;

        public bool flagcenter;

        public int cellvalue_subtotal;

        public int cellvalue_qty;

        public int cellvalue_OrderValue;

        public int cellvalue_costexmarkup;

        public int cellvalue_grossprofitpercentage;

        public int cellvalue_grossprofitprice;

        public int cellvalue_productwidth;

        public int cellvalue_productheight;

        public int cellvalue_productlength;

        public int cellvalue_productweight;

        public int cellvalue_productdimension;

        public int cellvalue_itemqty;

        public int cellvalue_approvalstatus;

        public int cellvalue_orderno;

        public int cellvalue_activitynotes;

        public int cellvalue_order_description;

        public int cellvalue_Companyname;

        public int cellvalue_itemtitle;

        public int cellvalue_ordererfor;

        public int cellvalue_totalprice;

        public int cellvalue_commissionamount;

        public int cellvalue_commissionpercentage;

        public int cellvalue_jobno;

        public int cellvalue_jobvalue;

        public int cellvalue_jobcostpriceinc;

        public int cellvalue_job_description;

        public int cellvalue_costpriceinc;

        public int cellvalue_invoiceamountpaid;

        public int cellvalue_invoiceamountOutstanding;

        public int cellvalue_invoiceno;

        public int cellvalue_invoice_description;

        public int cellvalue_fromquantity;

        public int cellvalue_toquantity;

        public int cellvalue_priceprod;

        public int cellvalue_MarkUpPercentage;

        public int cellvalue_MarkUpvalue;

        public int cellvalue_SellingPrice;

        public int cellvalue_qtyonhand;

        public int cellvalue_qty_inhand;

        public int cellvalue_AllocatedStockQuantity;

        public int cellvalue_AvailableStockQuantity;

        public int cellvalue_ReOrderQuantity;

        public int cellvalue_ReorderAlertLevel;

        public int cellvalue_QtySoldWeekToDate;

        public int cellvalue_QtySoldMonthToDate;

        public int cellvalue_QtySoldYearToDate;

        public int cellvalue_QtySoldTillDate;

        public int cellvalue_prod_Weight;

        public int cellvalue_prod_height;

        public int cellvalue_prod_Length;

        public int cellvalue_prod_width;

        public string ItemTitle_prodreport = "";

        public string Description_prod = "";

        public string Artwork_prod = "";

        public string Colour_prod = "";

        public string Size_prod = "";

        public string Material_prod = "";

        public string Delivery_prod = "";

        public string Finishing_prod = "";

        public string Proofs_prod = "";

        public string Packing_prod = "";

        public string Notes_prod = "";

        public string Instructions_prod = "";

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

        public estore_reports()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv, RadGrid grid)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (grid.MasterTableView.Columns.Count != dt.Columns.Count)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    grid.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                }
            }
        }

        protected void Back_Onclick(object sender, EventArgs e)
        {
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void Bind_ReportsData_byReportID(long reportid, string reporttype, RadGrid grid, DateTime fromdate_cust, DateTime todate_cust)
        {
            try
            {
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                int pageSize = grid.PageSize;
                int currentPageIndex = grid.CurrentPageIndex + 1;
                this.hdn_reportid_afterload.Value = reportid.ToString();
                DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(reportid, (long)this.CompanyID, this.StoreUserID, fromdate_cust, todate_cust, pageSize, currentPageIndex);
                this.hdnOrderFromdate_cust.Value = fromdate_cust.ToString();
                this.hdnOrderTodate_cust.Value = todate_cust.ToString();
                this.hdninvoiceFromdate_cust.Value = fromdate_cust.ToString();
                this.hdninvoicetodate_cust.Value = todate_cust.ToString();
                this.hdnjobtodate_cust.Value = todate_cust.ToString();
                this.hdnjobFromdate_cust.Value = fromdate_cust.ToString();
                DataTable item = dataSet.Tables[0];
                foreach (DataColumn column in item.Columns)
                {
                    column.ReadOnly = false;
                }
                if (item.Columns.Contains("ActivityNotes"))
                {
                    foreach (DataRow row in item.Rows)
                    {
                        if (row["ActivityNotes"] == null)
                        {
                            continue;
                        }
                        row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                        row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                    }
                }
                if (item.Columns.Contains("Orderid"))
                {
                    item.Columns.Remove("Orderid");
                }
                if (item.Columns.Contains("Estimateid"))
                {
                    item.Columns.Remove("Estimateid");
                }
                if (item.Columns.Contains("clientID"))
                {
                    item.Columns.Remove("clientID");
                }
                if (item.Columns.Contains("Invoiceid"))
                {
                    item.Columns.Remove("Invoiceid");
                }
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("IsStockItem"))
                {
                    item.Columns.Remove("IsStockItem");
                }
                if (item.Columns.Contains("ActivityRecords"))
                {
                    item.Columns.Remove("ActivityRecords");
                }
                if (item.Columns.Contains("TempProduct"))
                {
                    item.Columns.Remove("TempProduct");
                }
                if (item.Columns.Contains("TempAvailableQty"))
                {
                    item.Columns.Remove("TempAvailableQty");
                }
                if (item.Columns.Contains("pricecatalogueid"))
                {
                    item.Columns.Remove("pricecatalogueid");
                }
                if (item.Columns.Contains("RowNumber"))
                {
                    item.Columns.Remove("RowNumber");
                }
                foreach (DataRow dataRow in item.Rows)
                {
                    if (item.Columns.Contains("CreatedDate") && dataRow["createddate"].ToString() != "")
                    {
                        dataRow["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("OrderDate") && dataRow["OrderDate"].ToString() != "")
                    {
                        dataRow["OrderDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DueDate") && dataRow["DueDate"].ToString() != "")
                    {
                        dataRow["DueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("CompletionDate") && dataRow["CompletionDate"].ToString() != "")
                    {
                        dataRow["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DeliveryDate") && dataRow["DeliveryDate"].ToString() != "")
                    {
                        dataRow["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("actualdeliverydate") && dataRow["actualdeliverydate"].ToString() != "")
                    {
                        dataRow["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(dataRow["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("EstimatedDeliveryDate") && dataRow["EstimatedDeliveryDate"].ToString() != "")
                    {
                        dataRow["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ActualDeliveryDate") && dataRow["ActualDeliveryDate"].ToString() != "")
                    {
                        dataRow["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ProgressedDate") && dataRow["ProgressedDate"].ToString() != "")
                    {
                        dataRow["ProgressedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["ProgressedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("InvoiceDate") && dataRow["InvoiceDate"].ToString() != "")
                    {
                        dataRow["InvoiceDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["InvoiceDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("InvoiceDueDate") && dataRow["InvoiceDueDate"].ToString() != "")
                    {
                        dataRow["InvoiceDueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["InvoiceDueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ContactAddress") && dataRow["ContactAddress"].ToString() != "")
                    {
                        dataRow["ContactAddress"] = this.objBc.SpecialDecode(dataRow["ContactAddress"].ToString());
                    }
                    if (item.Columns.Contains("DeliveryAddress") && dataRow["DeliveryAddress"].ToString() != "")
                    {
                        dataRow["DeliveryAddress"] = this.objBc.SpecialDecode(dataRow["DeliveryAddress"].ToString());
                    }
                    if (item.Columns.Contains("InvoiceAddress") && dataRow["InvoiceAddress"].ToString() != "")
                    {
                        dataRow["InvoiceAddress"] = this.objBc.SpecialDecode(dataRow["InvoiceAddress"].ToString());
                    }
                    if (item.Columns.Contains("ItemTitle") && dataRow["ItemTitle"].ToString() != "")
                    {
                        dataRow["ItemTitle"] = this.objBc.SpecialDecode(dataRow["ItemTitle"].ToString());
                    }
                    if (item.Columns.Contains("Description") && dataRow["Description"].ToString() != "")
                    {
                        dataRow["Description"] = this.objBc.SpecialDecode(dataRow["Description"].ToString());
                    }
                    if (item.Columns.Contains("ActivityNotes") && dataRow["ActivityNotes"].ToString() != "")
                    {
                        dataRow["ActivityNotes"] = this.objBc.SpecialDecode(dataRow["ActivityNotes"].ToString());
                    }
                    if (item.Columns.Contains("ContactName") && dataRow["ContactName"].ToString() != "")
                    {
                        dataRow["ContactName"] = this.objBc.SpecialDecode(dataRow["ContactName"].ToString());
                    }
                    if (item.Columns.Contains("OrderTitle") && dataRow["OrderTitle"].ToString() != "")
                    {
                        dataRow["OrderTitle"] = this.objBc.SpecialDecode(dataRow["OrderTitle"].ToString());
                    }
                    if (item.Columns.Contains("Company") && dataRow["Company"].ToString() != "")
                    {
                        dataRow["Company"] = this.objBc.SpecialDecode(dataRow["Company"].ToString());
                    }
                    if (item.Columns.Contains("totaltaxprice") && dataRow["totaltaxprice"].ToString() != "")
                    {
                        dataRow["totaltaxprice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["totaltaxprice"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("TotalTaxPrice") && dataRow["TotalTaxPrice"].ToString() != "")
                    {
                        dataRow["TotalTaxPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalTaxPrice"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("OrderValue") && dataRow["OrderValue"].ToString() != "")
                    {
                        dataRow["OrderValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["OrderValue"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("SubTotal") && dataRow["SubTotal"].ToString() != "")
                    {
                        dataRow["SubTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["SubTotal"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("GrossProfitPrice") && dataRow["GrossProfitPrice"].ToString() != "")
                    {
                        dataRow["GrossProfitPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPrice"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("GrossProfitPercentage") && dataRow["GrossProfitPercentage"].ToString() != "")
                    {
                        dataRow["GrossProfitPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPercentage"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("CostExMarkup") && dataRow["CostExMarkup"].ToString() != "")
                    {
                        dataRow["CostExMarkup"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostExMarkup"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("ProductWidth") && dataRow["ProductWidth"].ToString() != "")
                    {
                        dataRow["ProductWidth"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWidth"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("Width") && dataRow["Width"].ToString() != "")
                    {
                        dataRow["Width"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Width"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("ProductHeight") && dataRow["ProductHeight"].ToString() != "")
                    {
                        dataRow["ProductHeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductHeight"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("Height") && dataRow["Height"].ToString() != "")
                    {
                        dataRow["Height"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Height"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("ProductLength") && dataRow["ProductLength"].ToString() != "")
                    {
                        dataRow["ProductLength"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductLength"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("Length") && dataRow["Length"].ToString() != "")
                    {
                        dataRow["Length"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Length"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("ProductWeight") && dataRow["ProductWeight"].ToString() != "")
                    {
                        dataRow["ProductWeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWeight"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("Weight") && dataRow["Weight"].ToString() != "")
                    {
                        dataRow["Weight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Weight"].ToString()), 2, "", false, false, true);
                    }
                    item.Columns.Contains("ProductDimension");
                    if (item.Columns.Contains("JobValue") && dataRow["JobValue"].ToString() != "")
                    {
                        dataRow["JobValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["JobValue"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("CostPrice") && dataRow["CostPrice"].ToString() != "")
                    {
                        dataRow["CostPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostPrice"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("CommissionAmount") && dataRow["CommissionAmount"].ToString() != "")
                    {
                        dataRow["CommissionAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionAmount"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("CommissionPercentage") && dataRow["CommissionPercentage"].ToString() != "")
                    {
                        dataRow["CommissionPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionPercentage"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("InvoiceValue") && dataRow["InvoiceValue"].ToString() != "")
                    {
                        dataRow["InvoiceValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceValue"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("InvoiceAmountPaid") && dataRow["InvoiceAmountPaid"].ToString() != "")
                    {
                        dataRow["InvoiceAmountPaid"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountPaid"].ToString()), 2, "", false, false, true);
                    }
                    if (!item.Columns.Contains("InvoiceAmountOutstanding") || !(dataRow["InvoiceAmountOutstanding"].ToString() != ""))
                    {
                        continue;
                    }
                    dataRow["InvoiceAmountOutstanding"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountOutstanding"].ToString()), 2, "", false, false, true);
                }
                if (this.Reports_type.ToLower() == "job" || reporttype.ToLower() == "job")
                {
                    if (item.Columns.Contains("jobid"))
                    {
                        item.Columns.Remove("jobid");
                    }
                    if (item.Columns.Contains("EstimateItemID"))
                    {
                        item.Columns.Remove("EstimateItemID");
                    }
                    if (item.Columns.Contains("Material"))
                    {
                        item.Columns["Material"].ColumnName = "Substrate";
                    }
                    if (item.Columns.Contains("Eventstartdate") && item.Columns.Contains("Eventenddate"))
                    {
                        DataColumn dataColumn = new DataColumn();
                        item.Columns.Add("Event Date", typeof(string));
                        if (item.Rows.Count == 0)
                        {
                            item.Columns.Remove("Eventstartdate");
                            item.Columns.Remove("Eventenddate");
                        }
                    }
                    foreach (DataRow row1 in item.Rows)
                    {
                        if (item.Columns.Contains("Eventstartdate") && item.Columns.Contains("Eventenddate"))
                        {
                            string str = this.comm.Eprint_return_Date_Before_View(row1["Eventstartdate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                            string str1 = this.comm.Eprint_return_Date_Before_View(row1["Eventenddate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                            if (str != "" && str1 != "")
                            {
                                row1["Event Date"] = string.Concat(str, "-", str1);
                            }
                            item.Columns.Remove("Eventstartdate");
                            item.Columns.Remove("Eventenddate");
                        }
                        if (row1.Table.Columns.Contains("CustomerName"))
                        {
                            row1["CustomerName"] = this.objBc.SpecialDecode(row1["CustomerName"].ToString());
                        }
                        if (row1.Table.Columns.Contains("ContactName"))
                        {
                            row1["ContactName"] = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Department"))
                        {
                            row1["Department"] = this.objBc.SpecialDecode(row1["Department"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeremail"))
                        {
                            row1["customeremail"] = this.objBc.SpecialDecode(row1["customeremail"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactemail"))
                        {
                            row1["contactemail"] = this.objBc.SpecialDecode(row1["contactemail"].ToString());
                        }
                        if (row1.Table.Columns.Contains("ContactJobTitle1"))
                        {
                            row1["ContactJobTitle1"] = this.objBc.SpecialDecode(row1["ContactJobTitle1"].ToString());
                        }
                        if (row1.Table.Columns.Contains("ContactJobTitle2"))
                        {
                            row1["ContactJobTitle2"] = this.objBc.SpecialDecode(row1["ContactJobTitle2"].ToString());
                        }
                        if (row1.Table.Columns.Contains("CustomerType"))
                        {
                            row1["CustomerType"] = this.objBc.SpecialDecode(row1["CustomerType"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactphone"))
                        {
                            row1["contactphone"] = this.objBc.SpecialDecode(row1["contactphone"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress1"))
                        {
                            row1["contactaddress1"] = this.objBc.SpecialDecode(row1["contactaddress1"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress2"))
                        {
                            row1["contactaddress2"] = this.objBc.SpecialDecode(row1["contactaddress2"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress3"))
                        {
                            row1["contactaddress3"] = this.objBc.SpecialDecode(row1["contactaddress3"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress4"))
                        {
                            row1["contactaddress4"] = this.objBc.SpecialDecode(row1["contactaddress4"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress5"))
                        {
                            row1["contactaddress5"] = this.objBc.SpecialDecode(row1["contactaddress5"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress6"))
                        {
                            row1["contactaddress6"] = this.objBc.SpecialDecode(row1["contactaddress6"].ToString());
                        }
                        if (row1.Table.Columns.Contains("contactaddress"))
                        {
                            row1["contactaddress"] = this.objBc.SpecialDecode(row1["contactaddress"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress1"))
                        {
                            row1["deliveryaddress1"] = this.objBc.SpecialDecode(row1["deliveryaddress1"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress2"))
                        {
                            row1["deliveryaddress2"] = this.objBc.SpecialDecode(row1["deliveryaddress2"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress3"))
                        {
                            row1["deliveryaddress3"] = this.objBc.SpecialDecode(row1["deliveryaddress3"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress4"))
                        {
                            row1["deliveryaddress4"] = this.objBc.SpecialDecode(row1["deliveryaddress4"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress5"))
                        {
                            row1["deliveryaddress5"] = this.objBc.SpecialDecode(row1["deliveryaddress5"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress6"))
                        {
                            row1["deliveryaddress6"] = this.objBc.SpecialDecode(row1["deliveryaddress6"].ToString());
                        }
                        if (row1.Table.Columns.Contains("deliveryaddress"))
                        {
                            row1["deliveryaddress"] = this.objBc.SpecialDecode(row1["deliveryaddress"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress1"))
                        {
                            row1["invoiceaddress1"] = this.objBc.SpecialDecode(row1["invoiceaddress1"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress2"))
                        {
                            row1["invoiceaddress2"] = this.objBc.SpecialDecode(row1["invoiceaddress2"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress3"))
                        {
                            row1["invoiceaddress3"] = this.objBc.SpecialDecode(row1["invoiceaddress3"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress4"))
                        {
                            row1["invoiceaddress4"] = this.objBc.SpecialDecode(row1["invoiceaddress4"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress5"))
                        {
                            row1["invoiceaddress5"] = this.objBc.SpecialDecode(row1["invoiceaddress5"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress6"))
                        {
                            row1["invoiceaddress6"] = this.objBc.SpecialDecode(row1["invoiceaddress6"].ToString());
                        }
                        if (row1.Table.Columns.Contains("invoiceaddress"))
                        {
                            row1["invoiceaddress"] = this.objBc.SpecialDecode(row1["invoiceaddress"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Estimator"))
                        {
                            row1["Estimator"] = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                        }
                        if (row1.Table.Columns.Contains("salesperson"))
                        {
                            row1["salesperson"] = this.objBc.SpecialDecode(row1["salesperson"].ToString());
                        }
                        if (row1.Table.Columns.Contains("jobtitle"))
                        {
                            row1["jobtitle"] = this.objBc.SpecialDecode(row1["jobtitle"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Status"))
                        {
                            row1["Status"] = this.objBc.SpecialDecode(row1["Status"].ToString());
                        }
                        if (row1.Table.Columns.Contains("ItemTitle"))
                        {
                            row1["ItemTitle"] = this.objBc.SpecialDecode(row1["ItemTitle"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Description"))
                        {
                            row1["DEscription"] = this.objBc.SpecialDecode(row1["DEscription"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Artwork"))
                        {
                            row1["Artwork"] = this.objBc.SpecialDecode(row1["Artwork"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Colour"))
                        {
                            row1["Colour"] = this.objBc.SpecialDecode(row1["Colour"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Size"))
                        {
                            row1["Size"] = this.objBc.SpecialDecode(row1["Size"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Material"))
                        {
                            row1["Material"] = this.objBc.SpecialDecode(row1["Material"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Delivery"))
                        {
                            row1["Delivery"] = this.objBc.SpecialDecode(row1["Delivery"].ToString());
                        }
                        if (row1.Table.Columns.Contains("finishing"))
                        {
                            row1["finishing"] = this.objBc.SpecialDecode(row1["finishing"].ToString());
                        }
                        if (row1.Table.Columns.Contains("notes"))
                        {
                            row1["notes"] = this.objBc.SpecialDecode(row1["notes"].ToString());
                        }
                        if (row1.Table.Columns.Contains("instructions"))
                        {
                            row1["instructions"] = this.objBc.SpecialDecode(row1["instructions"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Proofs"))
                        {
                            row1["Proofs"] = this.objBc.SpecialDecode(row1["Proofs"].ToString());
                        }
                        if (row1.Table.Columns.Contains("packing"))
                        {
                            row1["packing"] = this.objBc.SpecialDecode(row1["packing"].ToString());
                        }
                        if (row1.Table.Columns.Contains("ordernumber"))
                        {
                            row1["ordernumber"] = this.objBc.SpecialDecode(row1["ordernumber"].ToString());
                        }
                        if (row1.Table.Columns.Contains("Name"))
                        {
                            row1["Name"] = this.objBc.SpecialDecode(row1["Name"].ToString());
                        }
                        if (row1.Table.Columns.Contains("suppliername"))
                        {
                            row1["suppliername"] = this.objBc.SpecialDecode(row1["suppliername"].ToString());
                        }
                        if (row1.Table.Columns.Contains("producttitle"))
                        {
                            row1["producttitle"] = this.objBc.SpecialDecode(row1["producttitle"].ToString());
                        }
                        if (row1.Table.Columns.Contains("productcode"))
                        {
                            row1["productcode"] = this.objBc.SpecialDecode(row1["productcode"].ToString());
                        }
                        if (row1.Table.Columns.Contains("productcatagory"))
                        {
                            row1["productcatagory"] = this.objBc.SpecialDecode(row1["productcatagory"].ToString());
                        }
                        if (row1.Table.Columns.Contains("storename"))
                        {
                            row1["storename"] = this.objBc.SpecialDecode(row1["storename"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeraddress1"))
                        {
                            row1["customeraddress1"] = this.objBc.SpecialDecode(row1["customeraddress1"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeraddress2"))
                        {
                            row1["customeraddress2"] = this.objBc.SpecialDecode(row1["customeraddress2"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeraddress3"))
                        {
                            row1["customeraddress3"] = this.objBc.SpecialDecode(row1["customeraddress3"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeraddress4"))
                        {
                            row1["customeraddress4"] = this.objBc.SpecialDecode(row1["customeraddress4"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeraddress5"))
                        {
                            row1["customeraddress5"] = this.objBc.SpecialDecode(row1["customeraddress5"].ToString());
                        }
                        if (row1.Table.Columns.Contains("customeraddress6"))
                        {
                            row1["customeraddress6"] = this.objBc.SpecialDecode(row1["customeraddress6"].ToString());
                        }
                        if (!row1.Table.Columns.Contains("customeraddress"))
                        {
                            continue;
                        }
                        row1["customeraddress"] = this.objBc.SpecialDecode(row1["customeraddress"].ToString());
                    }
                }
                foreach (DataRow dataRow1 in item.Rows)
                {
                    if (dataRow1.Table.Columns.Contains("Company"))
                    {
                        dataRow1["Company"] = this.objBc.SpecialDecode(dataRow1["Company"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("ContactName"))
                    {
                        dataRow1["ContactName"] = this.objBc.SpecialDecode(dataRow1["ContactName"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Department"))
                    {
                        dataRow1["Department"] = this.objBc.SpecialDecode(dataRow1["Department"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeremail"))
                    {
                        dataRow1["customeremail"] = this.objBc.SpecialDecode(dataRow1["customeremail"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactemail"))
                    {
                        dataRow1["contactemail"] = this.objBc.SpecialDecode(dataRow1["contactemail"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("ContactJobTitle1"))
                    {
                        dataRow1["ContactJobTitle1"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle1"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("ContactJobTitle2"))
                    {
                        dataRow1["ContactJobTitle2"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle2"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("CustomerType"))
                    {
                        dataRow1["CustomerType"] = this.objBc.SpecialDecode(dataRow1["CustomerType"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactphone"))
                    {
                        dataRow1["contactphone"] = this.objBc.SpecialDecode(dataRow1["contactphone"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress1"))
                    {
                        dataRow1["contactaddress1"] = this.objBc.SpecialDecode(dataRow1["contactaddress1"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress2"))
                    {
                        dataRow1["contactaddress2"] = this.objBc.SpecialDecode(dataRow1["contactaddress2"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress3"))
                    {
                        dataRow1["contactaddress3"] = this.objBc.SpecialDecode(dataRow1["contactaddress3"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress4"))
                    {
                        dataRow1["contactaddress4"] = this.objBc.SpecialDecode(dataRow1["contactaddress4"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress5"))
                    {
                        dataRow1["contactaddress5"] = this.objBc.SpecialDecode(dataRow1["contactaddress5"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress6"))
                    {
                        dataRow1["contactaddress6"] = this.objBc.SpecialDecode(dataRow1["contactaddress6"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("contactaddress"))
                    {
                        dataRow1["contactaddress"] = this.objBc.SpecialDecode(dataRow1["contactaddress"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress1"))
                    {
                        dataRow1["deliveryaddress1"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress1"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress2"))
                    {
                        dataRow1["deliveryaddress2"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress2"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress3"))
                    {
                        dataRow1["deliveryaddress3"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress3"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress4"))
                    {
                        dataRow1["deliveryaddress4"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress4"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress5"))
                    {
                        dataRow1["deliveryaddress5"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress5"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress6"))
                    {
                        dataRow1["deliveryaddress6"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress6"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("deliveryaddress"))
                    {
                        dataRow1["deliveryaddress"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress1"))
                    {
                        dataRow1["invoiceaddress1"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress1"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress2"))
                    {
                        dataRow1["invoiceaddress2"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress2"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress3"))
                    {
                        dataRow1["invoiceaddress3"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress3"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress4"))
                    {
                        dataRow1["invoiceaddress4"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress4"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress5"))
                    {
                        dataRow1["invoiceaddress5"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress5"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress6"))
                    {
                        dataRow1["invoiceaddress6"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress6"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("invoiceaddress"))
                    {
                        dataRow1["invoiceaddress"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("salesperson"))
                    {
                        dataRow1["salesperson"] = this.objBc.SpecialDecode(dataRow1["salesperson"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("InvoiceTitle"))
                    {
                        dataRow1["InvoiceTitle"] = this.objBc.SpecialDecode(dataRow1["InvoiceTitle"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Status"))
                    {
                        dataRow1["Status"] = this.objBc.SpecialDecode(dataRow1["Status"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("ItemTitle"))
                    {
                        dataRow1["ItemTitle"] = this.objBc.SpecialDecode(dataRow1["ItemTitle"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Description"))
                    {
                        dataRow1["DEscription"] = this.objBc.SpecialDecode(dataRow1["DEscription"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Artwork"))
                    {
                        dataRow1["Artwork"] = this.objBc.SpecialDecode(dataRow1["Artwork"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Colour"))
                    {
                        dataRow1["Colour"] = this.objBc.SpecialDecode(dataRow1["Colour"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Size"))
                    {
                        dataRow1["Size"] = this.objBc.SpecialDecode(dataRow1["Size"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Material"))
                    {
                        dataRow1["Material"] = this.objBc.SpecialDecode(dataRow1["Material"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Delivery"))
                    {
                        dataRow1["Delivery"] = this.objBc.SpecialDecode(dataRow1["Delivery"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("finishing"))
                    {
                        dataRow1["finishing"] = this.objBc.SpecialDecode(dataRow1["finishing"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("notes"))
                    {
                        dataRow1["notes"] = this.objBc.SpecialDecode(dataRow1["notes"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("instructions"))
                    {
                        dataRow1["instructions"] = this.objBc.SpecialDecode(dataRow1["instructions"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Proofs"))
                    {
                        dataRow1["Proofs"] = this.objBc.SpecialDecode(dataRow1["Proofs"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("packing"))
                    {
                        dataRow1["packing"] = this.objBc.SpecialDecode(dataRow1["packing"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("ordernumber"))
                    {
                        dataRow1["ordernumber"] = this.objBc.SpecialDecode(dataRow1["ordernumber"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Name"))
                    {
                        dataRow1["Name"] = this.objBc.SpecialDecode(dataRow1["Name"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("suppliername"))
                    {
                        dataRow1["suppliername"] = this.objBc.SpecialDecode(dataRow1["suppliername"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("producttitle"))
                    {
                        dataRow1["producttitle"] = this.objBc.SpecialDecode(dataRow1["producttitle"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("productcode"))
                    {
                        dataRow1["productcode"] = this.objBc.SpecialDecode(dataRow1["productcode"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("storename"))
                    {
                        dataRow1["storename"] = this.objBc.SpecialDecode(dataRow1["storename"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeraddress1"))
                    {
                        dataRow1["customeraddress1"] = this.objBc.SpecialDecode(dataRow1["customeraddress1"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeraddress2"))
                    {
                        dataRow1["customeraddress2"] = this.objBc.SpecialDecode(dataRow1["customeraddress2"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeraddress3"))
                    {
                        dataRow1["customeraddress3"] = this.objBc.SpecialDecode(dataRow1["customeraddress3"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeraddress4"))
                    {
                        dataRow1["customeraddress4"] = this.objBc.SpecialDecode(dataRow1["customeraddress4"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeraddress5"))
                    {
                        dataRow1["customeraddress5"] = this.objBc.SpecialDecode(dataRow1["customeraddress5"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("customeraddress6"))
                    {
                        dataRow1["customeraddress6"] = this.objBc.SpecialDecode(dataRow1["customeraddress6"].ToString());
                    }
                    if (!dataRow1.Table.Columns.Contains("customeraddress"))
                    {
                        continue;
                    }
                    dataRow1["customeraddress"] = this.objBc.SpecialDecode(dataRow1["customeraddress"].ToString());
                }
                foreach (DataRow row2 in dataSet.Tables[0].Rows)
                {
                    if (row2.Table.Columns.Contains("ItemTitle"))
                    {
                        row2["ItemTitle"] = this.objBc.SpecialDecode(row2["ItemTitle"].ToString());
                    }
                    if (row2.Table.Columns.Contains("CategoryName"))
                    {
                        row2["CategoryName"] = this.objBc.SpecialDecode(row2["CategoryName"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemCode"))
                    {
                        row2["ItemCode"] = this.objBc.SpecialDecode(row2["ItemCode"].ToString());
                    }
                    if (row2.Table.Columns.Contains("CustomerCode"))
                    {
                        row2["CustomerCode"] = this.objBc.SpecialDecode(row2["CustomerCode"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemDescription"))
                    {
                        row2["ItemDescription"] = this.objBc.SpecialDecode(row2["ItemDescription"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemArtWork"))
                    {
                        row2["ItemArtWork"] = this.objBc.SpecialDecode(row2["ItemArtWork"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemColour"))
                    {
                        row2["ItemColour"] = this.objBc.SpecialDecode(row2["ItemColour"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemSize"))
                    {
                        row2["ItemSize"] = this.objBc.SpecialDecode(row2["ItemSize"].ToString());
                    }
                    if (row2.Table.Columns.Contains("Material"))
                    {
                        row2["Material"] = this.objBc.SpecialDecode(row2["Material"].ToString());
                    }
                    if (row2.Table.Columns.Contains("Delivery"))
                    {
                        row2["Delivery"] = this.objBc.SpecialDecode(row2["Delivery"].ToString());
                    }
                    if (row2.Table.Columns.Contains("Finishing"))
                    {
                        row2["Finishing"] = this.objBc.SpecialDecode(row2["Finishing"].ToString());
                    }
                    if (row2.Table.Columns.Contains("Proofs"))
                    {
                        row2["Proofs"] = this.objBc.SpecialDecode(row2["Proofs"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemPacking"))
                    {
                        row2["ItemPacking"] = this.objBc.SpecialDecode(row2["ItemPacking"].ToString());
                    }
                    if (row2.Table.Columns.Contains("ItemNotes"))
                    {
                        row2["ItemNotes"] = this.objBc.SpecialDecode(row2["ItemNotes"].ToString());
                    }
                    if (row2.Table.Columns.Contains("Terms/Instructions"))
                    {
                        row2["Terms/Instructions"] = this.objBc.SpecialDecode(row2["Terms/Instructions"].ToString());
                    }
                    if (item.Columns.Contains("price") && row2["price"].ToString() != "")
                    {
                        row2["price"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["price"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("MarkUpPercentage") && row2["MarkUpPercentage"].ToString() != "")
                    {
                        row2["MarkUpPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpPercentage"].ToString()), 2, "", false, false, true);
                    }
                    if (item.Columns.Contains("MarkUpValue") && row2["MarkUpValue"].ToString() != "")
                    {
                        row2["MarkUpValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpValue"].ToString()), 2, "", false, false, true);
                    }
                    if (!item.Columns.Contains("SellingPrice") || !(row2["SellingPrice"].ToString() != ""))
                    {
                        continue;
                    }
                    row2["SellingPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["SellingPrice"].ToString()), 2, "", false, false, true);
                }
                if (dataSet.Tables.Count > 1)
                {
                    grid.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]);
                }
                grid.DataSource = item;
                if (this.Reports_type.ToLower().Contains("order"))
                {
                    this.Session["reportdatatable_order"] = item;
                }
                else if (this.Reports_type.ToLower().Contains("job"))
                {
                    this.Session["reportdatatable_order_job"] = item;
                }
                else if (this.Reports_type.ToLower().Contains("invoice"))
                {
                    this.Session["reportdatatable_order_invoice"] = item;
                }
                else if (this.Reports_type.ToLower() == "stock")
                {
                    this.Session["reportdatatable_order_product"] = item;
                }
                this.AddBoundColumns(item, grid, grid);
                grid.DataBind();
            }
            catch (Exception ex)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Reports");
                grid.DataSource = dataTable;
                grid.MasterTableView.NoMasterRecordsText = "No Records Found";
                grid.DataBind();
            }
        }

        protected void btn_exportexcel_invoice(object sender, EventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime dateTime = Convert.ToDateTime(this.hdninvoiceFromdate_cust.Value);
            DateTime dateTime1 = Convert.ToDateTime(this.hdninvoicetodate_cust.Value);
            this.reportid = Convert.ToInt64(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime, dateTime1, 0, 0);
            DataTable item = dataSet.Tables[0];
            this.div_reportgrid.Attributes.Add("style", "display:block;");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (item.Columns.Contains("CreatedDate") && row["createddate"].ToString() != "")
                    {
                        row["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("OrderDate") && row["OrderDate"].ToString() != "")
                    {
                        row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DueDate") && row["DueDate"].ToString() != "")
                    {
                        row["DueDate"] = this.comm.Eprint_return_Date_Before_View(row["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("CompletionDate") && row["CompletionDate"].ToString() != "")
                    {
                        row["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DeliveryDate") && row["DeliveryDate"].ToString() != "")
                    {
                        row["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("actualdeliverydate") && row["actualdeliverydate"].ToString() != "")
                    {
                        row["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(row["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("EstimatedDeliveryDate") && row["EstimatedDeliveryDate"].ToString() != "")
                    {
                        row["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ActualDeliveryDate") && row["ActualDeliveryDate"].ToString() != "")
                    {
                        row["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ProgressedDate") && row["ProgressedDate"].ToString() != "")
                    {
                        row["ProgressedDate"] = this.comm.Eprint_return_Date_Before_View(row["ProgressedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("InvoiceDate") && row["InvoiceDate"].ToString() != "")
                    {
                        row["InvoiceDate"] = this.comm.Eprint_return_Date_Before_View(row["InvoiceDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("InvoiceDueDate") && row["InvoiceDueDate"].ToString() != "")
                    {
                        row["InvoiceDueDate"] = this.comm.Eprint_return_Date_Before_View(row["InvoiceDueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (!item.Columns.Contains("ActivityNotes") || row["ActivityNotes"] == null)
                    {
                        continue;
                    }
                    row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                    row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                }
                if (item.Columns.Contains("Orderid"))
                {
                    item.Columns.Remove("Orderid");
                }
                if (item.Columns.Contains("Estimateid"))
                {
                    item.Columns.Remove("Estimateid");
                }
                if (item.Columns.Contains("clientID"))
                {
                    item.Columns.Remove("clientID");
                }
                if (item.Columns.Contains("Invoiceid"))
                {
                    item.Columns.Remove("Invoiceid");
                }
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("IsStockItem"))
                {
                    item.Columns.Remove("IsStockItem");
                }
                if (item.Columns.Contains("ActivityRecords"))
                {
                    item.Columns.Remove("ActivityRecords");
                }
                if (item.Columns.Contains("TempProduct"))
                {
                    item.Columns.Remove("TempProduct");
                }
                if (item.Columns.Contains("TempAvailableQty"))
                {
                    item.Columns.Remove("TempAvailableQty");
                }
                if (item.Columns.Contains("pricecatalogueid"))
                {
                    item.Columns.Remove("pricecatalogueid");
                }
                if (item.Columns.Contains("RowNumber"))
                {
                    item.Columns.Remove("RowNumber");
                }
                foreach (DataColumn column in item.Columns)
                {
                    if (item.Columns.Contains("InvoiceNumber"))
                    {
                        item.Columns["InvoiceNumber"].ColumnName = "Invoice No.";
                    }
                    if (item.Columns.Contains("JobContactName"))
                    {
                        item.Columns["JobContactName"].ColumnName = "Job Contact Name";
                    }
                    if (item.Columns.Contains("ActivityNotes"))
                    {
                        item.Columns["ActivityNotes"].ColumnName = "Activity Notes";
                    }
                    if (item.Columns.Contains("ProgressedDate"))
                    {
                        item.Columns["ProgressedDate"].ColumnName = "Progress On";
                    }
                    if (item.Columns.Contains("InvoicePaid"))
                    {
                        item.Columns["InvoicePaid"].ColumnName = "Invoice Paid";
                    }
                    if (item.Columns.Contains("JobContactName"))
                    {
                        item.Columns["JobContactName"].ColumnName = "Job Contact Name";
                    }
                    if (item.Columns.Contains("CustomerAddress"))
                    {
                        item.Columns["CustomerAddress"].ColumnName = "Customer Address";
                    }
                    if (item.Columns.Contains("JobNumber"))
                    {
                        item.Columns["JobNumber"].ColumnName = "Job Number";
                    }
                    if (item.Columns.Contains("InvoiceTitle"))
                    {
                        item.Columns["InvoiceTitle"].ColumnName = "Invoice Title";
                    }
                    if (item.Columns.Contains("clientname"))
                    {
                        item.Columns["clientname"].ColumnName = "Company";
                    }
                    if (item.Columns.Contains("ProgressedBy"))
                    {
                        item.Columns["ProgressedBy"].ColumnName = "Progressed By";
                    }
                    if (item.Columns.Contains("ContactName"))
                    {
                        item.Columns["ContactName"].ColumnName = "Invoice Contact Name";
                    }
                    if (item.Columns.Contains("CustomerName"))
                    {
                        item.Columns["CustomerName"].ColumnName = "Company";
                    }
                    if (item.Columns.Contains("customeremail"))
                    {
                        item.Columns["customeremail"].ColumnName = "Customer Email";
                    }
                    if (item.Columns.Contains("ContactEmail"))
                    {
                        item.Columns["ContactEmail"].ColumnName = "Contact Email";
                    }
                    if (item.Columns.Contains("ContactPhone"))
                    {
                        item.Columns["ContactPhone"].ColumnName = "Contact Phone";
                    }
                    if (item.Columns.Contains("ContactAddress"))
                    {
                        item.Columns["ContactAddress"].ColumnName = "Contact Address";
                    }
                    if (item.Columns.Contains("DeliveryAddress"))
                    {
                        item.Columns["DeliveryAddress"].ColumnName = "Delivery Address";
                    }
                    if (item.Columns.Contains("InvoiceAddress"))
                    {
                        item.Columns["InvoiceAddress"].ColumnName = "Invoice Address";
                    }
                    if (item.Columns.Contains("SalesPerson"))
                    {
                        item.Columns["SalesPerson"].ColumnName = "Invoice SalesPerson";
                    }
                    if (item.Columns.Contains("CompletionDate"))
                    {
                        item.Columns["CompletionDate"].ColumnName = "Completed On";
                    }
                    if (item.Columns.Contains("CreatedDate"))
                    {
                        item.Columns["CreatedDate"].ColumnName = "Created On";
                    }
                    if (item.Columns.Contains("DeliveryDate"))
                    {
                        item.Columns["DeliveryDate"].ColumnName = "Delivery Date";
                    }
                    if (item.Columns.Contains("JobValue"))
                    {
                        item.Columns["JobValue"].ColumnName = string.Concat("Job Value Inc.Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("ItemTitle"))
                    {
                        item.Columns["ItemTitle"].ColumnName = "Item Title";
                    }
                    if (item.Columns.Contains("ItemStatusTitle"))
                    {
                        item.Columns["ItemStatusTitle"].ColumnName = "Item Status";
                    }
                    if (item.Columns.Contains("Material"))
                    {
                        item.Columns["Material"].ColumnName = "Paper/Stock";
                    }
                    if (item.Columns.Contains("OrderNumber"))
                    {
                        item.Columns["OrderNumber"].ColumnName = "Order No";
                    }
                    if (item.Columns.Contains("name"))
                    {
                        item.Columns["name"].ColumnName = "Referred By";
                    }
                    if (item.Columns.Contains("SubTotal"))
                    {
                        item.Columns["SubTotal"].ColumnName = string.Concat("Sub Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("GrossProfitPrice"))
                    {
                        item.Columns["GrossProfitPrice"].ColumnName = string.Concat("Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("GrossProfitPercentage"))
                    {
                        item.Columns["GrossProfitPercentage"].ColumnName = "Gross Profit (%)";
                    }
                    if (item.Columns.Contains("CostExMarkup"))
                    {
                        item.Columns["CostExMarkup"].ColumnName = string.Concat("Cost Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("AccountingCode"))
                    {
                        item.Columns["AccountingCode"].ColumnName = "Accounting Code";
                    }
                    if (item.Columns.Contains("CostCentre"))
                    {
                        item.Columns["CostCentre"].ColumnName = "Cost Centre";
                    }
                    if (item.Columns.Contains("ItemQuantity"))
                    {
                        item.Columns["ItemQuantity"].ColumnName = "Quantity";
                    }
                    if (item.Columns.Contains("EstimatedJobTime"))
                    {
                        item.Columns["EstimatedJobTime"].ColumnName = "Estimated Job Time";
                    }
                    if (item.Columns.Contains("ActaulJobTime"))
                    {
                        item.Columns["ActaulJobTime"].ColumnName = "Actaul Job Time";
                    }
                    if (item.Columns.Contains("EstimatedDeliveryDate"))
                    {
                        item.Columns["EstimatedDeliveryDate"].ColumnName = "Estimated Delivery Date";
                    }
                    if (item.Columns.Contains("ActualDeliveryDate"))
                    {
                        item.Columns["ActualDeliveryDate"].ColumnName = "Actual Delivery Date";
                    }
                    if (item.Columns.Contains("CustomerCode"))
                    {
                        item.Columns["CustomerCode"].ColumnName = "Customer Code";
                    }
                    if (item.Columns.Contains("PackUnit"))
                    {
                        item.Columns["PackUnit"].ColumnName = "Pack Unit";
                    }
                    if (item.Columns.Contains("CostPrice"))
                    {
                        item.Columns["CostPrice"].ColumnName = string.Concat("Cost Price (Inc. Markup) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("SupplierName"))
                    {
                        item.Columns["SupplierName"].ColumnName = "Supplier Name";
                    }
                    if (item.Columns.Contains("ProductTitle"))
                    {
                        item.Columns["ProductTitle"].ColumnName = "Product Title";
                    }
                    if (item.Columns.Contains("ProductCode"))
                    {
                        item.Columns["ProductCode"].ColumnName = "Product Code";
                    }
                    if (item.Columns.Contains("ProductCatagory"))
                    {
                        item.Columns["ProductCatagory"].ColumnName = "Product Category";
                    }
                    if (item.Columns.Contains("StoreName"))
                    {
                        item.Columns["StoreName"].ColumnName = "Store Name";
                    }
                    if (item.Columns.Contains("ProductWidth"))
                    {
                        item.Columns["ProductWidth"].ColumnName = string.Concat("Product Width (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("ProductHeight"))
                    {
                        item.Columns["ProductHeight"].ColumnName = string.Concat("Product Height (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("ProductLength"))
                    {
                        item.Columns["ProductLength"].ColumnName = string.Concat("Product Length (", this.Paper_Stock_Lenght, ")");
                    }
                    if (item.Columns.Contains("ProductWeight"))
                    {
                        item.Columns["ProductWeight"].ColumnName = string.Concat("Product Weight (", this.Weight_gsm, ")");
                    }
                    if (item.Columns.Contains("ProductDimension"))
                    {
                        item.Columns["ProductDimension"].ColumnName = "Product Dimension";
                    }
                    if (item.Columns.Contains("EventName"))
                    {
                        item.Columns["EventName"].ColumnName = "Event Name";
                    }
                    if (item.Columns.Contains("EventCodeNumber"))
                    {
                        item.Columns["EventCodeNumber"].ColumnName = "Event Code";
                    }
                    if (item.Columns.Contains("CampaignSignNumber"))
                    {
                        item.Columns["CampaignSignNumber"].ColumnName = "Sign No.";
                    }
                    if (item.Columns.Contains("EventVenue"))
                    {
                        item.Columns["EventVenue"].ColumnName = "Venue";
                    }
                    if (item.Columns.Contains("QTYDescription1"))
                    {
                        item.Columns["QTYDescription1"].ColumnName = "Quantity Description";
                    }
                    if (item.Columns.Contains("JobName"))
                    {
                        item.Columns["JobName"].ColumnName = "Job Name";
                    }
                    if (item.Columns.Contains("ContactJobTitle1"))
                    {
                        item.Columns["ContactJobTitle1"].ColumnName = "Contact Job Title 1";
                    }
                    if (item.Columns.Contains("ContactJobTitle2"))
                    {
                        item.Columns["ContactJobTitle2"].ColumnName = "Contact Job Title 2";
                    }
                    if (item.Columns.Contains("CustomerSalesperson"))
                    {
                        item.Columns["CustomerSalesperson"].ColumnName = "Customer Salesperson";
                    }
                    if (item.Columns.Contains("OrderedFor"))
                    {
                        item.Columns["OrderedFor"].ColumnName = "Ordered For";
                    }
                    if (item.Columns.Contains("CustomerType"))
                    {
                        item.Columns["CustomerType"].ColumnName = "Type";
                    }
                    if (item.Columns.Contains("CommissionAmount"))
                    {
                        item.Columns["CommissionAmount"].ColumnName = string.Concat("Commission (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("InvoiceValue"))
                    {
                        item.Columns["InvoiceValue"].ColumnName = string.Concat("Invoice Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("CommissionPercentage"))
                    {
                        item.Columns["CommissionPercentage"].ColumnName = "Commission (%)";
                    }
                    if (item.Columns.Contains("InvoiceDate"))
                    {
                        item.Columns["InvoiceDate"].ColumnName = "Invoice Date";
                    }
                    if (item.Columns.Contains("InvoiceDueDate"))
                    {
                        item.Columns["InvoiceDueDate"].ColumnName = "Invoice Due Date";
                    }
                    if (item.Columns.Contains("InvoiceAmountPaid"))
                    {
                        item.Columns["InvoiceAmountPaid"].ColumnName = string.Concat("Amount Paid (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("InvoiceAmountOutstanding"))
                    {
                        item.Columns["InvoiceAmountOutstanding"].ColumnName = string.Concat("Amount Outstanding (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("totaltaxprice"))
                    {
                        item.Columns["totaltaxprice"].ColumnName = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("TotalTaxPrice"))
                    {
                        item.Columns["TotalTaxPrice"].ColumnName = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("CustomField1"))
                    {
                        item.Columns["CustomField1"].ColumnName = this.CustomField1;
                    }
                    if (item.Columns.Contains("CustomField2"))
                    {
                        item.Columns["CustomField2"].ColumnName = this.CustomField2;
                    }
                    if (item.Columns.Contains("CustomField3"))
                    {
                        item.Columns["CustomField3"].ColumnName = this.CustomField3;
                    }
                    if (item.Columns.Contains("CustomField4"))
                    {
                        item.Columns["CustomField4"].ColumnName = this.CustomField4;
                    }
                    if (item.Columns.Contains("CustomField5"))
                    {
                        item.Columns["CustomField5"].ColumnName = this.CustomField5;
                    }
                    if (!item.Columns.Contains("CustomField6"))
                    {
                        continue;
                    }
                    item.Columns["CustomField6"].ColumnName = this.CustomField6;
                }
                StringBuilder stringBuilder = new StringBuilder();
                HttpContext current = HttpContext.Current;
                current.Response.Clear();
                stringBuilder.Append("<html><body><table border='1'>");
                stringBuilder.Append("<tr>");
                foreach (DataColumn dataColumn in item.Columns)
                {
                    stringBuilder.Append("<th align='center'>");
                    stringBuilder.Append(dataColumn.ColumnName);
                    stringBuilder.Append("</th>");
                }
                stringBuilder.Append("</tr>");
                string empty = string.Empty;
                string str = string.Empty;
                stringBuilder.Append(Environment.NewLine);
                foreach (DataRow dataRow in item.Rows)
                {
                    stringBuilder.Append("<tr>");
                    for (int i = 0; i < item.Columns.Count; i++)
                    {
                        stringBuilder.Append("<td>");
                        string str1 = dataRow.ItemArray[i].ToString();
                        str1 = Regex.Replace(str1, "'", "ˈ");
                        stringBuilder.Append(str1);
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append(Environment.NewLine);
                }
                stringBuilder.Append("</table></body></html>");
                string str2 = "Invoicereport_Excel.xls";
                current.Response.ContentType = "application/vnd.ms-excel";
                current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=\"", str2, "\""));
                current.Response.ContentEncoding = Encoding.Unicode;
                base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
                current.Response.Write(stringBuilder);
                current.Response.End();
                current.Response.Close();
                current.Response.Flush();
            }
        }

        protected void btn_exportexcel_jobs(object sender, EventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime dateTime = Convert.ToDateTime(this.hdnjobFromdate_cust.Value);
            DateTime dateTime1 = Convert.ToDateTime(this.hdnjobtodate_cust.Value);
            this.reportid = Convert.ToInt64(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime, dateTime1, 0, 0);
            DataTable item = dataSet.Tables[0];
            if (item != null)
            {
                if (item.Rows.Count == 0 && item.Columns.Contains("Eventstartdate") && item.Columns.Contains("Eventenddate"))
                {
                    item.Columns.Remove("Eventstartdate");
                    item.Columns.Remove("Eventenddate");
                    DataColumn dataColumn = new DataColumn();
                    item.Columns.Add("Event Date", typeof(string));
                }
                foreach (DataRow row in item.Rows)
                {
                    if (item.Columns.Contains("CreatedDate") && row["createddate"].ToString() != "")
                    {
                        row["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("OrderDate") && row["OrderDate"].ToString() != "")
                    {
                        row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DueDate") && row["DueDate"].ToString() != "")
                    {
                        row["DueDate"] = this.comm.Eprint_return_Date_Before_View(row["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("CompletionDate") && row["CompletionDate"].ToString() != "")
                    {
                        row["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DeliveryDate") && row["DeliveryDate"].ToString() != "")
                    {
                        row["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("actualdeliverydate") && row["actualdeliverydate"].ToString() != "")
                    {
                        row["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(row["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("EstimatedDeliveryDate") && row["EstimatedDeliveryDate"].ToString() != "")
                    {
                        row["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ActualDeliveryDate") && row["ActualDeliveryDate"].ToString() != "")
                    {
                        row["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("ActivityNotes") && row["ActivityNotes"] != null)
                    {
                        row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                        row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                    }
                    if (!row.Table.Columns.Contains("Eventstartdate") || !row.Table.Columns.Contains("Eventenddate"))
                    {
                        continue;
                    }
                    DataColumn dataColumn1 = new DataColumn();
                    item.Columns.Add("Event Date", typeof(string));
                    string str = this.comm.Eprint_return_Date_Before_View(row["Eventstartdate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    string str1 = this.comm.Eprint_return_Date_Before_View(row["Eventenddate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    if (str != "" && str1 != "")
                    {
                        row["Event Date"] = string.Concat(str, "-", str1);
                    }
                    item.Columns.Remove("Eventstartdate");
                    item.Columns.Remove("Eventenddate");
                }
                if (item.Columns.Contains("Orderid"))
                {
                    item.Columns.Remove("Orderid");
                }
                if (item.Columns.Contains("Estimateid"))
                {
                    item.Columns.Remove("Estimateid");
                }
                if (item.Columns.Contains("clientID"))
                {
                    item.Columns.Remove("clientID");
                }
                if (item.Columns.Contains("Invoiceid"))
                {
                    item.Columns.Remove("Invoiceid");
                }
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("IsStockItem"))
                {
                    item.Columns.Remove("IsStockItem");
                }
                if (item.Columns.Contains("ActivityRecords"))
                {
                    item.Columns.Remove("ActivityRecords");
                }
                if (item.Columns.Contains("TempProduct"))
                {
                    item.Columns.Remove("TempProduct");
                }
                if (item.Columns.Contains("TempAvailableQty"))
                {
                    item.Columns.Remove("TempAvailableQty");
                }
                if (item.Columns.Contains("pricecatalogueid"))
                {
                    item.Columns.Remove("pricecatalogueid");
                }
                if (item.Columns.Contains("RowNumber"))
                {
                    item.Columns.Remove("RowNumber");
                }
                foreach (DataColumn column in item.Columns)
                {
                    if (item.Columns.Contains("JobNumber"))
                    {
                        item.Columns["JobNumber"].ColumnName = "Job No.";
                    }
                    if (item.Columns.Contains("JobTitle"))
                    {
                        item.Columns["JobTitle"].ColumnName = "Job Title";
                    }
                    if (item.Columns.Contains("CustomerName"))
                    {
                        item.Columns["CustomerName"].ColumnName = "Company";
                    }
                    if (item.Columns.Contains("ContactName"))
                    {
                        item.Columns["ContactName"].ColumnName = "Contact";
                    }
                    if (item.Columns.Contains("customeremail"))
                    {
                        item.Columns["customeremail"].ColumnName = "Customer Email";
                    }
                    if (item.Columns.Contains("ContactEmail"))
                    {
                        item.Columns["ContactEmail"].ColumnName = "Contact Email";
                    }
                    if (item.Columns.Contains("ContactPhone"))
                    {
                        item.Columns["ContactPhone"].ColumnName = "Contact Phone";
                    }
                    if (item.Columns.Contains("ContactAddress"))
                    {
                        item.Columns["ContactAddress"].ColumnName = "Contact Address";
                    }
                    if (item.Columns.Contains("DeliveryAddress"))
                    {
                        item.Columns["DeliveryAddress"].ColumnName = "Delivery Address";
                    }
                    if (item.Columns.Contains("InvoiceAddress"))
                    {
                        item.Columns["InvoiceAddress"].ColumnName = "Invoice Address";
                    }
                    if (item.Columns.Contains("SalesPerson"))
                    {
                        item.Columns["SalesPerson"].ColumnName = "Job SalesPerson";
                    }
                    if (item.Columns.Contains("CompletionDate"))
                    {
                        item.Columns["CompletionDate"].ColumnName = "Completed On";
                    }
                    if (item.Columns.Contains("CreatedDate"))
                    {
                        item.Columns["CreatedDate"].ColumnName = "Created On";
                    }
                    if (item.Columns.Contains("DeliveryDate"))
                    {
                        item.Columns["DeliveryDate"].ColumnName = "Delivery Date";
                    }
                    if (item.Columns.Contains("ActualDeliverydate"))
                    {
                        item.Columns["ActualDeliverydate"].ColumnName = "Actual Delivery Date";
                    }
                    if (item.Columns.Contains("JobValue"))
                    {
                        item.Columns["JobValue"].ColumnName = string.Concat("Job Value Inc.Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("ItemTitle"))
                    {
                        item.Columns["ItemTitle"].ColumnName = "Item Title";
                    }
                    if (item.Columns.Contains("ItemStatusTitle"))
                    {
                        item.Columns["ItemStatusTitle"].ColumnName = "Item Status";
                    }
                    if (item.Columns.Contains("Material"))
                    {
                        item.Columns["Material"].ColumnName = "Paper/Stock";
                    }
                    if (item.Columns.Contains("OrderNumber"))
                    {
                        item.Columns["OrderNumber"].ColumnName = "Order No";
                    }
                    if (item.Columns.Contains("name"))
                    {
                        item.Columns["name"].ColumnName = "Referred By";
                    }
                    if (item.Columns.Contains("SubTotal"))
                    {
                        item.Columns["SubTotal"].ColumnName = string.Concat("Sub Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("GrossProfitPrice"))
                    {
                        item.Columns["GrossProfitPrice"].ColumnName = string.Concat("Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("GrossProfitPercentage"))
                    {
                        item.Columns["GrossProfitPercentage"].ColumnName = "Gross Profit (%)";
                    }
                    if (item.Columns.Contains("CostExMarkup"))
                    {
                        item.Columns["CostExMarkup"].ColumnName = string.Concat("Cost Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("AccountingCode"))
                    {
                        item.Columns["AccountingCode"].ColumnName = "Accounting Code";
                    }
                    if (item.Columns.Contains("CostCentre"))
                    {
                        item.Columns["CostCentre"].ColumnName = "Cost Centre";
                    }
                    if (item.Columns.Contains("ItemQuantity"))
                    {
                        item.Columns["ItemQuantity"].ColumnName = "Quantity";
                    }
                    if (item.Columns.Contains("EstimatedJobTime"))
                    {
                        item.Columns["EstimatedJobTime"].ColumnName = "Estimated Job Time";
                    }
                    if (item.Columns.Contains("ActaulJobTime"))
                    {
                        item.Columns["ActaulJobTime"].ColumnName = "Actaul Job Time";
                    }
                    if (item.Columns.Contains("EstimatedDeliveryDate"))
                    {
                        item.Columns["EstimatedDeliveryDate"].ColumnName = "Estimated Delivery Date";
                    }
                    if (item.Columns.Contains("ActualDeliveryDate"))
                    {
                        item.Columns["ActualDeliveryDate"].ColumnName = "Actual Delivery Date";
                    }
                    if (item.Columns.Contains("CustomerCode"))
                    {
                        item.Columns["CustomerCode"].ColumnName = "Customer Code";
                    }
                    if (item.Columns.Contains("PackUnit"))
                    {
                        item.Columns["PackUnit"].ColumnName = "Pack Unit";
                    }
                    if (item.Columns.Contains("CostPrice"))
                    {
                        item.Columns["CostPrice"].ColumnName = string.Concat("Cost Price (Inc. Markup) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("SupplierName"))
                    {
                        item.Columns["SupplierName"].ColumnName = "Supplier Name";
                    }
                    if (item.Columns.Contains("ProductTitle"))
                    {
                        item.Columns["ProductTitle"].ColumnName = "Product Title";
                    }
                    if (item.Columns.Contains("ProductCode"))
                    {
                        item.Columns["ProductCode"].ColumnName = "Product Code";
                    }
                    if (item.Columns.Contains("ProductCatagory"))
                    {
                        item.Columns["ProductCatagory"].ColumnName = "Product Category";
                    }
                    if (item.Columns.Contains("StoreName"))
                    {
                        item.Columns["StoreName"].ColumnName = "Store Name";
                    }
                    if (item.Columns.Contains("ProductWidth"))
                    {
                        item.Columns["ProductWidth"].ColumnName = string.Concat("Product Width (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("ProductHeight"))
                    {
                        item.Columns["ProductHeight"].ColumnName = string.Concat("Product Height (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("ProductLength"))
                    {
                        item.Columns["ProductLength"].ColumnName = string.Concat("Product Length (", this.Paper_Stock_Lenght, ")");
                    }
                    if (item.Columns.Contains("ProductWeight"))
                    {
                        item.Columns["ProductWeight"].ColumnName = string.Concat("Product Weight (", this.Weight_gsm, ")");
                    }
                    if (item.Columns.Contains("ProductDimension"))
                    {
                        item.Columns["ProductDimension"].ColumnName = "Product Dimension";
                    }
                    if (item.Columns.Contains("EventName"))
                    {
                        item.Columns["EventName"].ColumnName = "Event Name";
                    }
                    if (item.Columns.Contains("EventCodeNumber"))
                    {
                        item.Columns["EventCodeNumber"].ColumnName = "Event Code";
                    }
                    if (item.Columns.Contains("CampaignSignNumber"))
                    {
                        item.Columns["CampaignSignNumber"].ColumnName = "Sign No.";
                    }
                    if (item.Columns.Contains("EventVenue"))
                    {
                        item.Columns["EventVenue"].ColumnName = "Venue";
                    }
                    if (item.Columns.Contains("QTYDescription1"))
                    {
                        item.Columns["QTYDescription1"].ColumnName = "Quantity Description";
                    }
                    if (item.Columns.Contains("JobName"))
                    {
                        item.Columns["JobName"].ColumnName = "Job Name";
                    }
                    if (item.Columns.Contains("ContactJobTitle1"))
                    {
                        item.Columns["ContactJobTitle1"].ColumnName = "Contact Job Title 1";
                    }
                    if (item.Columns.Contains("ContactJobTitle2"))
                    {
                        item.Columns["ContactJobTitle2"].ColumnName = "Contact Job Title 2";
                    }
                    if (item.Columns.Contains("CustomerSalesperson"))
                    {
                        item.Columns["CustomerSalesperson"].ColumnName = "Customer Salesperson";
                    }
                    if (item.Columns.Contains("OrderedFor"))
                    {
                        item.Columns["OrderedFor"].ColumnName = "Ordered For";
                    }
                    if (item.Columns.Contains("CustomerType"))
                    {
                        item.Columns["CustomerType"].ColumnName = "Type";
                    }
                    if (item.Columns.Contains("CustomerAddress"))
                    {
                        item.Columns["CustomerAddress"].ColumnName = "Customer Address";
                    }
                    if (item.Columns.Contains("commissionamount"))
                    {
                        item.Columns["commissionamount"].ColumnName = string.Concat("Commission (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("CommissionPercentage"))
                    {
                        item.Columns["CommissionPercentage"].ColumnName = "Commission (%)";
                    }
                    if (item.Columns.Contains("totaltaxprice"))
                    {
                        item.Columns["totaltaxprice"].ColumnName = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("TotalTaxPrice"))
                    {
                        item.Columns["TotalTaxPrice"].ColumnName = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("CustomField1"))
                    {
                        item.Columns["CustomField1"].ColumnName = this.CustomField1;
                    }
                    if (item.Columns.Contains("CustomField2"))
                    {
                        item.Columns["CustomField2"].ColumnName = this.CustomField2;
                    }
                    if (item.Columns.Contains("CustomField3"))
                    {
                        item.Columns["CustomField3"].ColumnName = this.CustomField3;
                    }
                    if (item.Columns.Contains("CustomField4"))
                    {
                        item.Columns["CustomField4"].ColumnName = this.CustomField4;
                    }
                    if (item.Columns.Contains("CustomField5"))
                    {
                        item.Columns["CustomField5"].ColumnName = this.CustomField5;
                    }
                    if (!item.Columns.Contains("CustomField6"))
                    {
                        continue;
                    }
                    item.Columns["CustomField6"].ColumnName = this.CustomField6;
                }
                this.div_reportgrid.Attributes.Add("style", "display:block;");
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                StringBuilder stringBuilder = new StringBuilder();
                HttpContext current = HttpContext.Current;
                current.Response.Clear();
                stringBuilder.Append("<html><body><table border='1'>");
                stringBuilder.Append("<tr>");
                foreach (DataColumn column1 in item.Columns)
                {
                    stringBuilder.Append("<th align='center'>");
                    stringBuilder.Append(column1.ColumnName);
                    stringBuilder.Append("</th>");
                }
                stringBuilder.Append("</tr>");
                string empty = string.Empty;
                string empty1 = string.Empty;
                stringBuilder.Append(Environment.NewLine);
                foreach (DataRow dataRow in item.Rows)
                {
                    stringBuilder.Append("<tr>");
                    for (int i = 0; i < item.Columns.Count; i++)
                    {
                        stringBuilder.Append("<td>");
                        string str2 = dataRow.ItemArray[i].ToString();
                        str2 = Regex.Replace(str2, "'", "ˈ");
                        stringBuilder.Append(str2);
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append(Environment.NewLine);
                }
                stringBuilder.Append("</table></body></html>");
                string str3 = "Jobreport_Excel.xls";
                current.Response.ContentType = "application/vnd.ms-excel";
                current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=\"", str3, "\""));
                current.Response.ContentEncoding = Encoding.Unicode;
                base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
                current.Response.Write(stringBuilder);
                current.Response.End();
                current.Response.Close();
                current.Response.Flush();
            }
        }

        protected void btnback_reports_invoice(object sender, EventArgs e)
        {
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void btnback_reports_jobs(object sender, EventArgs e)
        {
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void btnback_reports_order(object sender, EventArgs e)
        {
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void btnback_reports_product(object sender, EventArgs e)
        {
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void btnexport_excel_product(object sender, EventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            this.div_reportgrid.Attributes.Add("style", "display:block;");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[2];
            int num = 1000000;
            int currentPageIndex = this.grid_reports_byreportid_product.CurrentPageIndex;
            dateTime[0] = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            this.reportid = (long)Convert.ToInt32(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime[0], dateTime[1], num, 1);
            DataTable item = dataSet.Tables[0];
            this.getColumnNameFromSettings();
            if (item.Columns.Contains("ActivityNotes"))
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row["ActivityNotes"] == null)
                    {
                        continue;
                    }
                    row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                    row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                }
            }
            if (item.Columns.Contains("IsStockItem"))
            {
                item.Columns.Remove("IsStockItem");
            }
            if (item.Columns.Contains("ActivityRecords"))
            {
                item.Columns.Remove("ActivityRecords");
            }
            if (item.Columns.Contains("TempProduct"))
            {
                item.Columns.Remove("TempProduct");
            }
            if (item.Columns.Contains("TempAvailableQty"))
            {
                item.Columns.Remove("TempAvailableQty");
            }
            if (item.Columns.Contains("pricecatalogueid"))
            {
                item.Columns.Remove("pricecatalogueid");
            }
            if (item.Columns.Contains("RowNumber"))
            {
                item.Columns.Remove("RowNumber");
            }
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                if (dataRow.Table.Columns.Contains("ItemTitle"))
                {
                    dataRow["ItemTitle"] = this.objBc.SpecialDecode(dataRow["ItemTitle"].ToString());
                }
                if (dataRow.Table.Columns.Contains("CategoryName"))
                {
                    dataRow["CategoryName"] = this.objBc.SpecialDecode(dataRow["CategoryName"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemCode"))
                {
                    dataRow["ItemCode"] = this.objBc.SpecialDecode(dataRow["ItemCode"].ToString());
                }
                if (dataRow.Table.Columns.Contains("CustomerCode"))
                {
                    dataRow["CustomerCode"] = this.objBc.SpecialDecode(dataRow["CustomerCode"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemDescription"))
                {
                    dataRow["ItemDescription"] = this.objBc.SpecialDecode(dataRow["ItemDescription"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemArtWork"))
                {
                    dataRow["ItemArtWork"] = this.objBc.SpecialDecode(dataRow["ItemArtWork"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemColour"))
                {
                    dataRow["ItemColour"] = this.objBc.SpecialDecode(dataRow["ItemColour"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemSize"))
                {
                    dataRow["ItemSize"] = this.objBc.SpecialDecode(dataRow["ItemSize"].ToString());
                }
                if (dataRow.Table.Columns.Contains("Material"))
                {
                    dataRow["Material"] = this.objBc.SpecialDecode(dataRow["Material"].ToString());
                }
                if (dataRow.Table.Columns.Contains("Delivery"))
                {
                    dataRow["Delivery"] = this.objBc.SpecialDecode(dataRow["Delivery"].ToString());
                }
                if (dataRow.Table.Columns.Contains("Finishing"))
                {
                    dataRow["Finishing"] = this.objBc.SpecialDecode(dataRow["Finishing"].ToString());
                }
                if (dataRow.Table.Columns.Contains("Proofs"))
                {
                    dataRow["Proofs"] = this.objBc.SpecialDecode(dataRow["Proofs"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemPacking"))
                {
                    dataRow["ItemPacking"] = this.objBc.SpecialDecode(dataRow["ItemPacking"].ToString());
                }
                if (dataRow.Table.Columns.Contains("ItemNotes"))
                {
                    dataRow["ItemNotes"] = this.objBc.SpecialDecode(dataRow["ItemNotes"].ToString());
                }
                if (dataRow.Table.Columns.Contains("Terms/Instructions"))
                {
                    dataRow["Terms/Instructions"] = this.objBc.SpecialDecode(dataRow["Terms/Instructions"].ToString());
                }
                if (item.Columns.Contains("price") && dataRow["price"].ToString() != "")
                {
                    dataRow["price"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["price"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpPercentage") && dataRow["MarkUpPercentage"].ToString() != "")
                {
                    dataRow["MarkUpPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["MarkUpPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpValue") && dataRow["MarkUpValue"].ToString() != "")
                {
                    dataRow["MarkUpValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["MarkUpValue"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("SellingPrice") || !(dataRow["SellingPrice"].ToString() != ""))
                {
                    continue;
                }
                dataRow["SellingPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["SellingPrice"].ToString()), 2, "", false, false, true);
            }
            if (item != null)
            {
                foreach (DataColumn column in item.Columns)
                {
                    if (item.Columns.Contains("ItemTitle"))
                    {
                        item.Columns["ItemTitle"].ColumnName = this.ItemTitle_prodreport;
                    }
                    if (item.Columns.Contains("CategoryName"))
                    {
                        item.Columns["CategoryName"].ColumnName = "Category Name";
                    }
                    if (item.Columns.Contains("ItemCode"))
                    {
                        item.Columns["ItemCode"].ColumnName = "Item Code";
                    }
                    if (item.Columns.Contains("CustomerCode"))
                    {
                        item.Columns["CustomerCode"].ColumnName = "Customer Code";
                    }
                    if (item.Columns.Contains("IsEditableProduct"))
                    {
                        item.Columns["IsEditableProduct"].ColumnName = "Product Type";
                    }
                    if (item.Columns.Contains("Weight"))
                    {
                        item.Columns["Weight"].ColumnName = string.Concat("Weight (", this.Weight_gsm, ")");
                    }
                    if (item.Columns.Contains("Width"))
                    {
                        item.Columns["Width"].ColumnName = string.Concat("Width (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("Height"))
                    {
                        item.Columns["Height"].ColumnName = string.Concat("Height (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("Length"))
                    {
                        item.Columns["Length"].ColumnName = string.Concat("Length (", this.Paper_Stock_Lenght, ")");
                    }
                    if (item.Columns.Contains("PublicAccount"))
                    {
                        item.Columns["PublicAccount"].ColumnName = "Public Accounts";
                    }
                    if (item.Columns.Contains("ItemDescription"))
                    {
                        item.Columns["ItemDescription"].ColumnName = "Product Description";
                    }
                    if (item.Columns.Contains("ItemArtwork"))
                    {
                        item.Columns["ItemArtwork"].ColumnName = "Product artwork";
                    }
                    if (item.Columns.Contains("ItemColour"))
                    {
                        item.Columns["ItemColour"].ColumnName = this.Colour_prod;
                    }
                    if (item.Columns.Contains("ItemSize"))
                    {
                        item.Columns["ItemSize"].ColumnName = this.Size_prod;
                    }
                    if (item.Columns.Contains("Material"))
                    {
                        item.Columns["Material"].ColumnName = this.Material_prod;
                    }
                    if (item.Columns.Contains("Delivery"))
                    {
                        item.Columns["Delivery"].ColumnName = this.Delivery_prod;
                    }
                    if (item.Columns.Contains("Finishing"))
                    {
                        item.Columns["Finishing"].ColumnName = this.Finishing_prod;
                    }
                    if (item.Columns.Contains("ItemSize"))
                    {
                        item.Columns["ItemSize"].ColumnName = this.Size_prod;
                    }
                    if (item.Columns.Contains("Proofs"))
                    {
                        item.Columns["Proofs"].ColumnName = this.Proofs_prod;
                    }
                    if (item.Columns.Contains("ItemPacking"))
                    {
                        item.Columns["ItemPacking"].ColumnName = this.Packing_prod;
                    }
                    if (item.Columns.Contains("ItemNotes"))
                    {
                        item.Columns["ItemNotes"].ColumnName = this.Notes_prod;
                    }
                    if (item.Columns.Contains("Terms/Instructions"))
                    {
                        item.Columns["Terms/Instructions"].ColumnName = this.Instructions_prod;
                    }
                    if (item.Columns.Contains("MatrixType"))
                    {
                        item.Columns["MatrixType"].ColumnName = "Pricing Type";
                    }
                    if (item.Columns.Contains("fromquantity"))
                    {
                        item.Columns["fromquantity"].ColumnName = "Start Qty";
                    }
                    if (item.Columns.Contains("toquantity"))
                    {
                        item.Columns["toquantity"].ColumnName = "End Qty";
                    }
                    if (item.Columns.Contains("price"))
                    {
                        item.Columns["price"].ColumnName = "Cost";
                    }
                    if (item.Columns.Contains("MarkUpPercentage"))
                    {
                        item.Columns["MarkUpPercentage"].ColumnName = "Mark (%)";
                    }
                    if (item.Columns.Contains("MarkUpValue"))
                    {
                        item.Columns["MarkUpValue"].ColumnName = "Mark Value";
                    }
                    if (item.Columns.Contains("QtyInHand"))
                    {
                        item.Columns["QtyInHand"].ColumnName = "Qty On Hand";
                    }
                    if (item.Columns.Contains("AllocatedQty"))
                    {
                        item.Columns["AllocatedQty"].ColumnName = "Allocated Qty";
                    }
                    if (item.Columns.Contains("AvailableQty"))
                    {
                        item.Columns["AvailableQty"].ColumnName = "Available Qty";
                    }
                    if (item.Columns.Contains("SellingPrice"))
                    {
                        item.Columns["SellingPrice"].ColumnName = "Selling Price";
                    }
                    if (item.Columns.Contains("TotalStockQuantity"))
                    {
                        item.Columns["TotalStockQuantity"].ColumnName = "Qty On Hand";
                    }
                    if (item.Columns.Contains("AllocatedStockQuantity"))
                    {
                        item.Columns["AllocatedStockQuantity"].ColumnName = "Allocated Qty";
                    }
                    if (item.Columns.Contains("AvailableStockQuantity"))
                    {
                        item.Columns["AvailableStockQuantity"].ColumnName = "Available Qty";
                    }
                    if (item.Columns.Contains("ReOrderQuantity"))
                    {
                        item.Columns["ReOrderQuantity"].ColumnName = "Re-order Qty";
                    }
                    if (item.Columns.Contains("ReorderAlertLevel"))
                    {
                        item.Columns["ReorderAlertLevel"].ColumnName = "Re-Order Alert Level";
                    }
                    if (item.Columns.Contains("QtySoldWeekToDate"))
                    {
                        item.Columns["QtySoldWeekToDate"].ColumnName = "Qty WTD";
                    }
                    if (item.Columns.Contains("QtySoldMonthToDate"))
                    {
                        item.Columns["QtySoldMonthToDate"].ColumnName = "Qty MTD";
                    }
                    if (item.Columns.Contains("QtySoldYearToDate"))
                    {
                        item.Columns["QtySoldYearToDate"].ColumnName = "Qty C-YTD";
                    }
                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    if (item.Columns.Contains("QtySoldFinancialYearToDate"))
                    {
                        item.Columns["QtySoldFinancialYearToDate"].ColumnName = "Qty F-YTD";
                    }

                    if (item.Columns.Contains("QtySoldTillDate"))
                    {
                        item.Columns["QtySoldTillDate"].ColumnName = "Qty TD";
                    }

                    // Ticket #9108  in excel export renamed columns QtySoldQuarterToDate and DateLastReplenished 
                    if (item.Columns.Contains("QtySoldQuarterToDate"))
                    {
                        item.Columns["QtySoldQuarterToDate"].ColumnName = "Qty QTD";
                    }
                    if (item.Columns.Contains("DateLastReplenished"))
                    {
                        item.Columns["DateLastReplenished"].ColumnName = "Date Last Replenished";
                    }

                    if (item.Columns.Contains("DrawStockFrom"))
                    {
                        item.Columns["DrawStockFrom"].ColumnName = "Draw Stock From";
                    }
                    if (item.Columns.Contains("SalesTaxRate"))
                    {
                        item.Columns["SalesTaxRate"].ColumnName = "Sales Tax Rate";
                    }
                    if (item.Columns.Contains("CustomField1"))
                    {
                        item.Columns["CustomField1"].ColumnName = this.CustomField1;
                    }
                    if (item.Columns.Contains("CustomField2"))
                    {
                        item.Columns["CustomField2"].ColumnName = this.CustomField2;
                    }
                    if (item.Columns.Contains("CustomField3"))
                    {
                        item.Columns["CustomField3"].ColumnName = this.CustomField3;
                    }
                    if (item.Columns.Contains("CustomField4"))
                    {
                        item.Columns["CustomField4"].ColumnName = this.CustomField4;
                    }
                    if (item.Columns.Contains("CustomField5"))
                    {
                        item.Columns["CustomField5"].ColumnName = this.CustomField5;
                    }

                    if (!item.Columns.Contains("CustomField6"))
                    {
                        continue;
                    }
                    item.Columns["CustomField6"].ColumnName = this.CustomField6;
                }
                StringBuilder stringBuilder = new StringBuilder();
                HttpContext current = HttpContext.Current;
                current.Response.Clear();
                stringBuilder.Append("<html><body><table border='1'>");
                stringBuilder.Append("<tr>");
                foreach (DataColumn dataColumn in item.Columns)
                {
                    stringBuilder.Append("<th align='center'>");
                    stringBuilder.Append(dataColumn.ColumnName);
                    stringBuilder.Append("</th>");
                }
                stringBuilder.Append("</tr>");
                string empty = string.Empty;
                string str = string.Empty;
                stringBuilder.Append(Environment.NewLine);
                foreach (DataRow row1 in item.Rows)
                {
                    stringBuilder.Append("<tr>");
                    for (int i = 0; i < item.Columns.Count; i++)
                    {
                        stringBuilder.Append("<td>");
                        string str1 = row1.ItemArray[i].ToString();
                        str1 = Regex.Replace(str1, "'", "ˈ");
                        stringBuilder.Append(str1);
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append(Environment.NewLine);
                }
                stringBuilder.Append("</table></body></html>");
                string str2 = "Productcatalogue Report_Excel.xls";
                current.Response.ContentType = "application/vnd.ms-excel";
                current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=\"", str2, "\""));
                current.Response.ContentEncoding = Encoding.Unicode;
                base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
                current.Response.Write(stringBuilder);
                current.Response.End();
                current.Response.Close();
                current.Response.Flush();
            }
        }

        protected void btngo_customizereport_invoice_datefilter(object sender, EventArgs e)
        {
            try
            {
                this.div_reportgrid.Attributes.Add("style", "display:block;");
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                long num = Convert.ToInt64(this.hdn_reportid_afterload.Value);
                GridTableView masterTableView = this.grid_reports_byreportid_invoice.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtfrmdate_invoice");
                TextBox textBox1 = (TextBox)items.FindControl("txttodate_invoice");
                this.invoiceFROMdate_custreport = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.invoiceTOdate_custreport = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                if (this.invoiceFROMdate_custreport == "")
                {
                    this.invoiceFROMdate_custreport = dateTime[0].ToString();
                }
                if (this.invoiceTOdate_custreport == "")
                {
                    this.invoiceTOdate_custreport = dateTime[1].ToString();
                }
                this.hdninvoiceFromdate_cust.Value = this.invoiceFROMdate_custreport;
                this.hdninvoicetodate_cust.Value = this.invoiceTOdate_custreport;
                this.Bind_ReportsData_byReportID(num, "invoice", this.grid_reports_byreportid_invoice, Convert.ToDateTime(this.invoiceFROMdate_custreport), Convert.ToDateTime(this.invoiceTOdate_custreport));
                for (int i = 0; i < this.grid_reports_byreportid_invoice.MasterTableView.Columns.Count; i++)
                {
                    if (this.grid_reports_byreportid_invoice.MasterTableView.Columns[i].HeaderText.ToLower() == "jobnumber")
                    {
                        this.grid_reports_byreportid_invoice.MasterTableView.Columns[i].ItemStyle.Wrap = false;
                    }
                    if (this.grid_reports_byreportid_invoice.MasterTableView.Columns[i].HeaderText.ToLower() == "invoicenumber")
                    {
                        this.grid_reports_byreportid_invoice.MasterTableView.Columns[i].ItemStyle.Wrap = false;
                    }
                }
                this.grid_reports_byreportid_invoice.MasterTableView.CurrentPageIndex = 0;
                this.grid_reports_byreportid_invoice.Rebind();
            }
            catch
            {
            }
        }

        protected void btngo_customizereport_job_datefilter(object sender, EventArgs e)
        {
            try
            {
                this.div_reportgrid.Attributes.Add("style", "display:block;");
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                long num = Convert.ToInt64(this.hdn_reportid_afterload.Value);
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                GridTableView masterTableView = this.grid_reports_byreportid_jobs.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtfrmdate_job");
                TextBox textBox1 = (TextBox)items.FindControl("txttodate_job");
                this.jobFROMdate_custreport = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.jobTOdate_custreport = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                if (this.jobFROMdate_custreport == "")
                {
                    this.jobFROMdate_custreport = dateTime[0].ToString();
                }
                if (this.jobTOdate_custreport == "")
                {
                    this.jobTOdate_custreport = dateTime[1].ToString();
                }
                this.hdnjobFromdate_cust.Value = this.jobFROMdate_custreport;
                this.hdnjobtodate_cust.Value = this.jobTOdate_custreport;
                this.Bind_ReportsData_byReportID(num, "job", this.grid_reports_byreportid_jobs, Convert.ToDateTime(this.jobFROMdate_custreport), Convert.ToDateTime(this.jobTOdate_custreport));
                for (int i = 0; i < this.grid_reports_byreportid_jobs.MasterTableView.Columns.Count; i++)
                {
                    if (this.grid_reports_byreportid_jobs.MasterTableView.Columns[i].HeaderText.ToLower() == "jobnumber")
                    {
                        this.grid_reports_byreportid_jobs.MasterTableView.Columns[i].ItemStyle.Wrap = false;
                    }
                }
                this.grid_reports_byreportid_jobs.MasterTableView.CurrentPageIndex = 0;
                this.grid_reports_byreportid_jobs.Rebind();
            }
            catch
            {
            }
        }

        protected void btngo_order_customizereport_datefilter(object sender, EventArgs e)
        {
            try
            {
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                this.div_reportgrid.Attributes.Add("style", "display:block;");
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                long num = Convert.ToInt64(this.hdn_reportid_afterload.Value);
                GridTableView masterTableView = this.grid_reports_byreportid_order.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtfrmdate_order");
                TextBox textBox1 = (TextBox)items.FindControl("txttodate_order");
                this.orderFROMdate_custreport = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.orderTOdate_custreport = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                if (this.orderFROMdate_custreport == "")
                {
                    this.orderFROMdate_custreport = dateTime[0].ToString();
                }
                if (this.orderTOdate_custreport == "")
                {
                    this.orderTOdate_custreport = dateTime[1].ToString();
                }
                this.hdnOrderFromdate_cust.Value = this.orderFROMdate_custreport;
                this.hdnOrderTodate_cust.Value = this.orderTOdate_custreport;
                this.Bind_ReportsData_byReportID(num, "order", this.grid_reports_byreportid_order, Convert.ToDateTime(this.orderFROMdate_custreport), Convert.ToDateTime(this.orderTOdate_custreport));
                for (int i = 0; i < this.grid_reports_byreportid_order.MasterTableView.Columns.Count; i++)
                {
                    if (this.grid_reports_byreportid_order.MasterTableView.Columns[i].HeaderText.ToLower() == "orderno")
                    {
                        this.grid_reports_byreportid_order.MasterTableView.Columns[i].ItemStyle.Wrap = false;
                    }
                }
                this.grid_reports_byreportid_order.MasterTableView.CurrentPageIndex = 0;
                this.grid_reports_byreportid_order.Rebind();
            }
            catch
            {
            }
        }

        protected void btnJobGo_OnClick(object sender, EventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtJobFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtJobToDate");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            this.JobFromDate = textBox.Text;
            this.JobToDate = textBox1.Text;
            DataSet dataSet = OrderBasePage.JobReport_CustomizeCustomer((long)this.CompanyID, this.StoreUserID, Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                foreach (DataColumn column in dataSet.Tables[i].Columns)
                {
                    column.ReadOnly = false;
                }
            }
            Label label = (Label)items.FindControl("lblSumTotalQty");
            Label label1 = (Label)items.FindControl("lblSumTotalSubTotal");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row.Table.Columns.Contains("JobTitle"))
                {
                    row["JobTitle"] = this.objBase.SpecialDecode(row["JobTitle"].ToString());
                }
                if (row.Table.Columns.Contains("DepartmentName"))
                {
                    row["DepartmentName"] = this.objBase.SpecialDecode(row["DepartmentName"].ToString());
                }
                if (row.Table.Columns.Contains("DepartmentState"))
                {
                    row["DepartmentState"] = this.objBase.SpecialDecode(row["DepartmentState"].ToString());
                }
                if (row.Table.Columns.Contains("ParentCategorySubCategory"))
                {
                    row["ParentCategorySubCategory"] = this.objBase.SpecialDecode(row["ParentCategorySubCategory"].ToString());
                }
                if (row.Table.Columns.Contains("Itemcode"))
                {
                    row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                }
                if (row.Table.Columns.Contains("CustomerCode"))
                {
                    row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                }
                if (row.Table.Columns.Contains("ItemTitle"))
                {
                    row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                }
                if (!row.Table.Columns.Contains("ItemDescription"))
                {
                    continue;
                }
                row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
            }
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                if (dataRow["TotalQuantity"] != null)
                {
                    this.hdnTotalQty.Value = dataRow["TotalQuantity"].ToString();
                }
                if (dataRow["TotalSubTotal"] == null)
                {
                    continue;
                }
                this.hdnTotalSalesValue.Value = dataRow["TotalSubTotal"].ToString();
            }
            this.RadGrid_CustomerJobReport.DataSource = dataSet.Tables[0];
            this.RadGrid_CustomerJobReport.DataBind();
        }

        protected void btnOrderReportGo_onClick(object sender, EventArgs e)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none;");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                GridTableView masterTableView = this.RadGrid_Order_Report.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtOrderFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtOrderToDate");
                this.orderFromdate = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.orderTodate = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.hdnOrderFromdate.Value = this.orderFromdate;
                this.hdnOrderTodate.Value = this.orderTodate;
                this.hdnOrderFromdate.Value = textBox.Text;
                this.hdnOrderTodate.Value = textBox1.Text;
                if (Convert.ToBoolean(OrderBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["AllowUnApprovedOrder"]))
                {
                    this.AllowUnApprovedOrder = true;
                }
                this.hdnOrderFromdate.Value = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderFromdate.Value, this.CompanyID, this.UserID, false);
                this.hdnOrderTodate.Value = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderTodate.Value, this.CompanyID, this.UserID, false);
                DataTable dataTable = new DataTable();
                dataTable = OrderBasePage.Orderreport_systemgenerated(this.CompanyID, this.StoreUserID, Convert.ToDateTime(this.hdnOrderFromdate.Value), Convert.ToDateTime(this.hdnOrderTodate.Value), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("Item Code"))
                        {
                            row["Item Code"] = this.objBase.SpecialDecode(row["Item Code"].ToString());
                        }
                        if (row.Table.Columns.Contains("Item Title"))
                        {
                            row["Item Title"] = this.objBase.SpecialDecode(row["Item Title"].ToString());
                        }
                        if (row.Table.Columns.Contains("End user Cost Centre"))
                        {
                            row["End user Cost Centre"] = this.objBase.SpecialDecode(row["End user Cost Centre"].ToString());
                        }
                        if (row.Table.Columns.Contains("Contact"))
                        {
                            row["Contact"] = this.objBase.SpecialDecode(row["Contact"].ToString());
                        }
                        if (row.Table.Columns.Contains("Customer"))
                        {
                            row["Customer"] = this.objBase.SpecialDecode(row["Customer"].ToString());
                        }
                        if (row.Table.Columns.Contains("Department"))
                        {
                            row["Department"] = this.objBase.SpecialDecode(row["Department"].ToString());
                        }
                        if (row.Table.Columns.Contains("Customer Code"))
                        {
                            row["Customer Code"] = this.objBase.SpecialDecode(row["Customer Code"].ToString());
                        }
                        if (!row.Table.Columns.Contains("Unit Cost"))
                        {
                            continue;
                        }
                        row["Unit Cost"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Unit Cost"].ToString()), 2, "", false, false, true);
                    }
                }
                this.Session["Orderreport_systemgeb_Orderdetails"] = dataTable;
                this.RadGrid_Order_Report.DataSource = dataTable;
                this.RadGrid_Order_Report.DataBind();
            }
            catch
            {
            }
        }

        protected void btnProductGo_OnClick(object sender, EventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            GridTableView masterTableView = this.RadGridProductReport_Customer_stockadjustment.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
            textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            this.FromDate = textBox.Text;
            this.ToDate = textBox1.Text;
            DataTable dataTable = OrderBasePage.ProductReport_Stockrelease_adjustment((long)this.CompanyID, Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate), this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("ParentCategory/SubCategory"))
                    {
                        row["ParentCategory/SubCategory"] = this.objBase.SpecialDecode(row["ParentCategory/SubCategory"].ToString());
                    }
                    if (row.Table.Columns.Contains("Itemcode"))
                    {
                        row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerCode"))
                    {
                        row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (!row.Table.Columns.Contains("ItemDescription"))
                    {
                        continue;
                    }
                    row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                }
            }
            this.Session["prodreport_systemen_stockusage_byadjustment"] = dataTable;
            this.RadGridProductReport_Customer_stockadjustment.DataSource = dataTable;
            this.RadGridProductReport_Customer_stockadjustment.DataBind();
        }

        protected void btnProductGoNew_OnClick(object sender, EventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            GridTableView masterTableView = this.RadGrid_stockallocatedcsutomer_new.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
            textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            this.FromDate = textBox.Text;
            this.ToDate = textBox1.Text;
            DataTable dataTable = OrderBasePage.ProductReport_Stockrelease_adjustment((long)this.CompanyID, Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate), this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("ParentCategory/SubCategory"))
                    {
                        row["ParentCategory/SubCategory"] = this.objBase.SpecialDecode(row["ParentCategory/SubCategory"].ToString());
                    }
                    if (row.Table.Columns.Contains("Itemcode"))
                    {
                        row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerCode"))
                    {
                        row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (!row.Table.Columns.Contains("ItemDescription"))
                    {
                        continue;
                    }
                    row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                }
            }
            this.RadGrid_stockallocatedcsutomer_new.DataSource = dataTable;
            this.RadGrid_stockallocatedcsutomer_new.DataBind();
        }

        protected void btnreport_exptoexcel_order(object sender, EventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime dateTime = Convert.ToDateTime(this.hdnOrderFromdate_cust.Value);
            DateTime dateTime1 = Convert.ToDateTime(this.hdnOrderTodate_cust.Value);
            this.reportid = Convert.ToInt64(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime, dateTime1, 0, 0);
            DataTable item = dataSet.Tables[0];
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (item.Columns.Contains("ActivityNotes") && row["ActivityNotes"] != null)
                    {
                        row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                        row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                    }
                    if (item.Columns.Contains("CreatedDate") && row["createddate"].ToString() != "")
                    {
                        row["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("OrderDate") && row["OrderDate"].ToString() != "")
                    {
                        row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DueDate") && row["DueDate"].ToString() != "")
                    {
                        row["DueDate"] = this.comm.Eprint_return_Date_Before_View(row["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("CompletionDate") && row["CompletionDate"].ToString() != "")
                    {
                        row["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("DeliveryDate") && row["DeliveryDate"].ToString() != "")
                    {
                        row["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("actualdeliverydate") && row["actualdeliverydate"].ToString() != "")
                    {
                        row["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(row["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (item.Columns.Contains("EstimatedDeliveryDate") && row["EstimatedDeliveryDate"].ToString() != "")
                    {
                        row["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    if (!item.Columns.Contains("ActualDeliveryDate") || !(row["ActualDeliveryDate"].ToString() != ""))
                    {
                        continue;
                    }
                    row["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(row["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("Orderid"))
                {
                    item.Columns.Remove("Orderid");
                }
                if (item.Columns.Contains("Estimateid"))
                {
                    item.Columns.Remove("Estimateid");
                }
                if (item.Columns.Contains("clientID"))
                {
                    item.Columns.Remove("clientID");
                }
                if (item.Columns.Contains("Invoiceid"))
                {
                    item.Columns.Remove("Invoiceid");
                }
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("IsStockItem"))
                {
                    item.Columns.Remove("IsStockItem");
                }
                if (item.Columns.Contains("ActivityRecords"))
                {
                    item.Columns.Remove("ActivityRecords");
                }
                if (item.Columns.Contains("TempProduct"))
                {
                    item.Columns.Remove("TempProduct");
                }
                if (item.Columns.Contains("TempAvailableQty"))
                {
                    item.Columns.Remove("TempAvailableQty");
                }
                if (item.Columns.Contains("pricecatalogueid"))
                {
                    item.Columns.Remove("pricecatalogueid");
                }
                if (item.Columns.Contains("RowNumber"))
                {
                    item.Columns.Remove("RowNumber");
                }
                foreach (DataColumn column in item.Columns)
                {
                    if (item.Columns.Contains("OrderNo"))
                    {
                        item.Columns["OrderNo"].ColumnName = "Order No";
                    }
                    if (item.Columns.Contains("ContactName"))
                    {
                        item.Columns["ContactName"].ColumnName = "Contact Name";
                    }
                    if (item.Columns.Contains("CustomerEmail"))
                    {
                        item.Columns["CustomerEmail"].ColumnName = "Customer Email";
                    }
                    if (item.Columns.Contains("ContactEmail"))
                    {
                        item.Columns["ContactEmail"].ColumnName = "Contact Email";
                    }
                    if (item.Columns.Contains("ContactPhone"))
                    {
                        item.Columns["ContactPhone"].ColumnName = "Contact Phone";
                    }
                    if (item.Columns.Contains("ContactAddress"))
                    {
                        item.Columns["ContactAddress"].ColumnName = "Contact Address";
                    }
                    if (item.Columns.Contains("DeliveryAddress"))
                    {
                        item.Columns["DeliveryAddress"].ColumnName = "Delivery Address";
                    }
                    if (item.Columns.Contains("InvoiceAddress"))
                    {
                        item.Columns["InvoiceAddress"].ColumnName = "Invoice Address";
                    }
                    if (item.Columns.Contains("Salesperson"))
                    {
                        item.Columns["Salesperson"].ColumnName = "Order Salesperson";
                    }
                    if (item.Columns.Contains("OrderTitle"))
                    {
                        item.Columns["OrderTitle"].ColumnName = "Order Title";
                    }
                    if (item.Columns.Contains("CreatedDate"))
                    {
                        item.Columns["CreatedDate"].ColumnName = "Created On";
                    }
                    if (item.Columns.Contains("OrderDate"))
                    {
                        item.Columns["OrderDate"].ColumnName = "Order Date";
                    }
                    if (item.Columns.Contains("OrderValue"))
                    {
                        item.Columns["OrderValue"].ColumnName = string.Concat("Order Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("ItemTitle"))
                    {
                        item.Columns["ItemTitle"].ColumnName = "Item Title";
                    }
                    if (item.Columns.Contains("ItemStatusTitle"))
                    {
                        item.Columns["ItemStatusTitle"].ColumnName = "Item Status";
                    }
                    if (item.Columns.Contains("OrderNumber"))
                    {
                        item.Columns["OrderNumber"].ColumnName = "Customer Order No";
                    }
                    if (item.Columns.Contains("name"))
                    {
                        item.Columns["name"].ColumnName = "Referred By";
                    }
                    if (item.Columns.Contains("SubTotal"))
                    {
                        item.Columns["SubTotal"].ColumnName = string.Concat("Sub Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("GrossProfitPrice"))
                    {
                        item.Columns["GrossProfitPrice"].ColumnName = string.Concat("Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("totaltaxprice"))
                    {
                        item.Columns["totaltaxprice"].ColumnName = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("TotalTaxPrice"))
                    {
                        item.Columns["TotalTaxPrice"].ColumnName = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("GrossProfitPercentage"))
                    {
                        item.Columns["GrossProfitPercentage"].ColumnName = "Gross Profit (%)";
                    }
                    if (item.Columns.Contains("AccountingCode"))
                    {
                        item.Columns["AccountingCode"].ColumnName = "Accounting Code";
                    }
                    if (item.Columns.Contains("CostCentre"))
                    {
                        item.Columns["CostCentre"].ColumnName = "Cost Centre";
                    }
                    if (item.Columns.Contains("ActivityNotes"))
                    {
                        item.Columns["ActivityNotes"].ColumnName = "Activity Notes";
                    }
                    if (item.Columns.Contains("ItemQuantity"))
                    {
                        item.Columns["ItemQuantity"].ColumnName = "Item Quantity";
                    }
                    if (item.Columns.Contains("StoreName"))
                    {
                        item.Columns["StoreName"].ColumnName = "Store Name";
                    }
                    if (item.Columns.Contains("ProductWidth"))
                    {
                        item.Columns["ProductWidth"].ColumnName = string.Concat("Product Width (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("ProductHeight"))
                    {
                        item.Columns["ProductHeight"].ColumnName = string.Concat("Product Height (", this.Paper_Stock, ")");
                    }
                    if (item.Columns.Contains("ProductLength"))
                    {
                        item.Columns["ProductLength"].ColumnName = string.Concat("Product Length (", this.Paper_Stock_Lenght, ")");
                    }
                    if (item.Columns.Contains("ProductWeight"))
                    {
                        item.Columns["ProductWeight"].ColumnName = string.Concat("Product Weight (", this.Weight_gsm, ")");
                    }
                    if (item.Columns.Contains("ProductDimension"))
                    {
                        item.Columns["ProductDimension"].ColumnName = "Product Dimension";
                    }
                    if (item.Columns.Contains("EventName"))
                    {
                        item.Columns["EventName"].ColumnName = "Event Name";
                    }
                    if (item.Columns.Contains("EventCodeNumber"))
                    {
                        item.Columns["EventCodeNumber"].ColumnName = "Event Code";
                    }
                    if (item.Columns.Contains("CampaignSignNumber"))
                    {
                        item.Columns["CampaignSignNumber"].ColumnName = "Sign No.";
                    }
                    if (item.Columns.Contains("ItemStatus"))
                    {
                        item.Columns["ItemStatus"].ColumnName = "Approval Status";
                    }
                    if (item.Columns.Contains("EventVenue"))
                    {
                        item.Columns["EventVenue"].ColumnName = "Event Venue";
                    }
                    if (item.Columns.Contains("QTYDescription1"))
                    {
                        item.Columns["QTYDescription1"].ColumnName = "Quantity";
                    }
                    if (item.Columns.Contains("ContactJobTitle1"))
                    {
                        item.Columns["ContactJobTitle1"].ColumnName = "Contact Job Title 1\t";
                    }
                    if (item.Columns.Contains("ContactJobTitle2"))
                    {
                        item.Columns["ContactJobTitle2"].ColumnName = "Contact Job Title 2";
                    }
                    if (item.Columns.Contains("CustomerSalesperson"))
                    {
                        item.Columns["CustomerSalesperson"].ColumnName = "Customer Salesperson";
                    }
                    if (item.Columns.Contains("CustomerCode"))
                    {
                        item.Columns["CustomerCode"].ColumnName = "Customer Code";
                    }
                    if (item.Columns.Contains("ProductCode"))
                    {
                        item.Columns["ProductCode"].ColumnName = "Product Code";
                    }
                    if (item.Columns.Contains("CommentsField"))
                    {
                        item.Columns["CommentsField"].ColumnName = "Comments Field";
                    }
                    if (item.Columns.Contains("DueDate"))
                    {
                        item.Columns["DueDate"].ColumnName = "Due Date";
                    }
                    if (item.Columns.Contains("JobName"))
                    {
                        item.Columns["JobName"].ColumnName = "Job Name";
                    }
                    if (item.Columns.Contains("OrderedFor"))
                    {
                        item.Columns["OrderedFor"].ColumnName = "Ordered For";
                    }
                    if (item.Columns.Contains("CostExMarkup"))
                    {
                        item.Columns["CostExMarkup"].ColumnName = string.Concat("Cost Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns.Contains("Material"))
                    {
                        item.Columns["Material"].ColumnName = "Paper/Stock";
                    }
                    if (item.Columns.Contains("SalesPerson"))
                    {
                        item.Columns["SalesPerson"].ColumnName = "Order Salesperson";
                    }
                    if (item.Columns.Contains("IsApproved"))
                    {
                        item.Columns["IsApproved"].ColumnName = "Approval Status";
                    }
                    if (item.Columns.Contains("CustomField1"))
                    {
                        item.Columns["CustomField1"].ColumnName = this.CustomField1;
                    }
                    if (item.Columns.Contains("CustomField2"))
                    {
                        item.Columns["CustomField2"].ColumnName = this.CustomField2;
                    }
                    if (item.Columns.Contains("CustomField3"))
                    {
                        item.Columns["CustomField3"].ColumnName = this.CustomField3;
                    }
                    if (item.Columns.Contains("CustomField4"))
                    {
                        item.Columns["CustomField4"].ColumnName = this.CustomField4;
                    }
                    if (item.Columns.Contains("CustomField5"))
                    {
                        item.Columns["CustomField5"].ColumnName = this.CustomField5;
                    }
                    if (!item.Columns.Contains("CustomField6"))
                    {
                        continue;
                    }
                    item.Columns["CustomField6"].ColumnName = this.CustomField6;
                }
                this.div_reportgrid.Attributes.Add("style", "display:block;");
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                StringBuilder stringBuilder = new StringBuilder();
                HttpContext current = HttpContext.Current;
                current.Response.Clear();
                stringBuilder.Append("<html><body><table border='1'>");
                stringBuilder.Append("<tr>");
                foreach (DataColumn dataColumn in item.Columns)
                {
                    stringBuilder.Append("<th align='center'>");
                    stringBuilder.Append(dataColumn.ColumnName);
                    stringBuilder.Append("</th>");
                }
                stringBuilder.Append("</tr>");
                string empty = string.Empty;
                string str = string.Empty;
                stringBuilder.Append(Environment.NewLine);
                foreach (DataRow dataRow in item.Rows)
                {
                    stringBuilder.Append("<tr>");
                    for (int i = 0; i < item.Columns.Count; i++)
                    {
                        stringBuilder.Append("<td>");
                        string str1 = dataRow.ItemArray[i].ToString();
                        str1 = Regex.Replace(str1, "'", "ˈ");
                        stringBuilder.Append(str1);
                        stringBuilder.Append("</td>");
                    }
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append(Environment.NewLine);
                }
                stringBuilder.Append("</table></body></html>");

                this.exportToXlsx(item, "OrderReport_Excel");
                //DataSet ds = new DataSet();
                //DataTable dtCopy1 = item.Copy();
                //ds.Tables.Add(dtCopy1);
                //using (XLWorkbook wb = new XLWorkbook())
                //{
                //    foreach (DataTable _dt in ds.Tables)
                //    {
                //        wb.Worksheets.Add(_dt);
                //    }
                //    Response.Clear();
                //    Response.Buffer = true;
                //    Response.Charset = "";
                //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //    Response.AddHeader("content-disposition", "attachment;filename=Productcatalogue Report_Excel.xlsx");
                //    using (MemoryStream MyMemoryStream = new MemoryStream())
                //    {
                //        wb.SaveAs(MyMemoryStream);
                //        MyMemoryStream.WriteTo(Response.OutputStream);
                //        Response.Flush();
                //        Response.End();
                //    }
                //}




                //string str2 = "OrderReport_Excel.xls";
                //current.Response.ContentType = "application/vnd.ms-excel";
                //current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=\"", str2, "\""));
                //current.Response.ContentEncoding = Encoding.Unicode;
                //base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
                //current.Response.Write(stringBuilder);
                //current.Response.End();
                //current.Response.Close();
                //current.Response.Flush();
            }
        }

        protected void btnStockUsage_PacksReportGo_onClick(object sender, EventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
        }

        protected void btnUsageReportGo_OnClick(object sender, EventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Prod_report_stockusage_bymontandYear((long)this.CompanyID, this.StoreUserID, this.hdnDepartmentID.Value, this.hdnMonthCategory.Value);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Stock Code"))
                    {
                        row["Stock Code"] = this.objBase.SpecialDecode(row["Stock Code"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    row["Product Name"] = this.objBase.SpecialDecode(row["Product Name"].ToString());
                }
            }
            this.Session["prodreport_systemen_stockusage_bymonth"] = dataTable;
            this.RadGrid_StockUsageReport_bymonthandyear.DataSource = dataTable;
            this.RadGrid_StockUsageReport_bymonthandyear.DataBind();
        }

        private void getColumnNameFromSettings()
        {
            DataSet dataSet = OrderBasePage.itemdescription_selectall_fromSettings_foralltypes((long)this.CompanyID, "c");
            if (dataSet.Tables[0].Rows[0]["databaseFieldName"].ToString() == "ItemTitle")
            {
                this.ItemTitle_prodreport = dataSet.Tables[0].Rows[0]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[1]["databaseFieldName"].ToString() == "Description")
            {
                this.Description_prod = dataSet.Tables[0].Rows[1]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[2]["databaseFieldName"].ToString() == "Artwork")
            {
                this.Artwork_prod = dataSet.Tables[0].Rows[2]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[3]["databaseFieldName"].ToString() == "Colour")
            {
                this.Colour_prod = dataSet.Tables[0].Rows[3]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[4]["databaseFieldName"].ToString() == "Size")
            {
                this.Size_prod = dataSet.Tables[0].Rows[4]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[5]["databaseFieldName"].ToString() == "Material")
            {
                this.Material_prod = dataSet.Tables[0].Rows[5]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[6]["databaseFieldName"].ToString() == "Delivery")
            {
                this.Delivery_prod = dataSet.Tables[0].Rows[6]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[7]["databaseFieldName"].ToString() == "Finishing")
            {
                this.Finishing_prod = dataSet.Tables[0].Rows[7]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[8]["databaseFieldName"].ToString() == "Proofs")
            {
                this.Proofs_prod = dataSet.Tables[0].Rows[8]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[9]["databaseFieldName"].ToString() == "Packing")
            {
                this.Packing_prod = dataSet.Tables[0].Rows[9]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[10]["databaseFieldName"].ToString() == "Notes")
            {
                this.Notes_prod = dataSet.Tables[0].Rows[10]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[11]["databaseFieldName"].ToString() == "Instructions")
            {
                this.Instructions_prod = dataSet.Tables[0].Rows[11]["ScreenName"].ToString();
            }
        }

        protected void Grid_estorereports_datasource(object source, GridNeedDataSourceEventArgs e)
        {
            this.div_Reports_Names.Attributes.Add("style", "display:block");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (this.StoreUserID == (long)0)
            {
                this.Grid_Estore_reports.DataSource = null;
                this.Grid_Estore_reports.MasterTableView.NoDetailRecordsText = "No Reports Found";
                return;
            }
            DataTable dataTable = OrderBasePage.Select_Reports_forCustomer(this.StoreUserID, this.Reports_type);
            if (dataTable.Rows.Count == 0)
            {
                this.Grid_Estore_reports.MasterTableView.NoMasterRecordsText = "No Reports Found";
            }
            foreach (DataColumn column in dataTable.Columns)
            {
                column.ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["reportname"] = this.objBc.SpecialDecode(row["reportname"].ToString());
                row["description"] = this.objBc.SpecialDecode(row["description"].ToString());
                if (row["reportname"].ToString().ToLower().Contains("order details report"))
                {
                    row["description"] = "Order Report";
                }
                if (row["reportname"].ToString().ToLower().Contains("product sales report"))
                {
                    row["description"] = "Product Sales Report";
                }
                if (row["reportname"].ToString().ToLower().Contains("sales/order report"))
                {
                    row["description"] = "Sales/Order Report";
                }
                if (row["reportname"].ToString().ToLower().Contains("stock usage report"))
                {
                    row["description"] = "Stock Usage Report";
                }
                if (row["reportname"].ToString().ToLower().Contains("stock usage report by month and year"))
                {
                    row["description"] = "Stock Usage Report by Month and Year Report";
                }
                if (row["reportname"].ToString().ToLower().Contains("stock release and adjustment report"))
                {
                    row["description"] = "Stock Release and Adjustment Report";
                }
                if (!row["reportname"].ToString().ToLower().Contains("stock report with quarterly sales"))
                {
                    continue;
                }
                row["description"] = "Stock Report with Quarterly Sales Report";
            }
            this.Grid_Estore_reports.DataSource = dataTable;
        }

        protected void Grid_estorereports_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkReportName");
            }
        }

        protected void grid_reports_byreportid_order_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
        }

        protected void grid_reports_byreportid_product_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.PageNumber = e.NewPageIndex + 1;
        }

        protected void grid_reports_byreportid_product_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.PageSize = e.NewPageSize;
        }

        protected void grid_reports_invoice_itemdatabound(object sender, GridItemEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            TextBox textBox = (TextBox)e.Item.FindControl("txtfrmdate_invoice");
            if (textBox != null)
            {
                textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.hdninvoiceFromdate_cust.Value == "" || this.hdninvoiceFromdate_cust.Value == "0")
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                else
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdninvoiceFromdate_cust.Value, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
            }
            TextBox textBox1 = (TextBox)e.Item.FindControl("txttodate_invoice");
            if (textBox1 != null)
            {
                textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.hdninvoicetodate_cust.Value == "" || this.hdninvoicetodate_cust.Value == "0")
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                else
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdninvoicetodate_cust.Value, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    if (e.Item.Cells[i].Text == "InvoiceNumber")
                    {
                        e.Item.Cells[i].Text = "Invoice No.";
                        this.cellvalue_invoiceno = i;
                    }
                    if (e.Item.Cells[i].Text == "JobNumber")
                    {
                        e.Item.Cells[i].Text = "Job Number";
                        this.cellvalue_jobno = i;
                    }
                    if (e.Item.Cells[i].Text == "CustomerName")
                    {
                        e.Item.Cells[i].Text = "Company";
                        this.cellvalue_Companyname = i;
                    }
                    if (e.Item.Cells[i].Text == "clientname")
                    {
                        e.Item.Cells[i].Text = "Company";
                        this.cellvalue_Companyname = i;
                    }
                    if (e.Item.Cells[i].Text == "InvoiceTitle")
                    {
                        e.Item.Cells[i].Text = "Invoice Title";
                    }
                    if (e.Item.Cells[i].Text == "ProgressedBy")
                    {
                        e.Item.Cells[i].Text = "Progress By";
                    }
                    if (e.Item.Cells[i].Text == "ContactName")
                    {
                        e.Item.Cells[i].Text = "Invoice Contact Name";
                    }
                    if (e.Item.Cells[i].Text == "ActivityNotes")
                    {
                        e.Item.Cells[i].Text = "Activity Notes";
                        this.cellvalue_activitynotes = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customeremail")
                    {
                        e.Item.Cells[i].Text = "Customer Email";
                    }
                    if (e.Item.Cells[i].Text == "ContactEmail")
                    {
                        e.Item.Cells[i].Text = "Contact Email";
                    }
                    if (e.Item.Cells[i].Text == "ContactPhone")
                    {
                        e.Item.Cells[i].Text = "Contact Phone";
                    }
                    if (e.Item.Cells[i].Text == "ContactAddress")
                    {
                        e.Item.Cells[i].Text = "Contact Address";
                    }
                    if (e.Item.Cells[i].Text == "DeliveryAddress")
                    {
                        e.Item.Cells[i].Text = "Delivery Address";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceAddress")
                    {
                        e.Item.Cells[i].Text = "Invoice Address";
                    }
                    if (e.Item.Cells[i].Text == "SalesPerson")
                    {
                        e.Item.Cells[i].Text = "Invoice SalesPerson";
                    }
                    if (e.Item.Cells[i].Text == "CompletionDate")
                    {
                        e.Item.Cells[i].Text = "Completed On";
                    }
                    if (e.Item.Cells[i].Text == "CreatedDate")
                    {
                        e.Item.Cells[i].Text = "Created On";
                    }
                    if (e.Item.Cells[i].Text == "DeliveryDate")
                    {
                        e.Item.Cells[i].Text = "Delivery Date";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceValue")
                    {
                        this.flacosts = true;
                        this.cellvalue_OrderValue = i;
                        e.Item.Cells[i].Text = string.Concat("Invoice Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "description")
                    {
                        e.Item.Cells[i].Text = "Description";
                        this.cellvalue_invoice_description = i;
                    }
                    if (e.Item.Cells[i].Text == "ItemTitle")
                    {
                        e.Item.Cells[i].Text = "Item Title";
                        this.cellvalue_itemtitle = i;
                    }
                    if (e.Item.Cells[i].Text == "ItemStatusTitle")
                    {
                        e.Item.Cells[i].Text = "Item Status";
                    }
                    if (e.Item.Cells[i].Text == "Material")
                    {
                        e.Item.Cells[i].Text = "Paper/Stock";
                    }
                    if (e.Item.Cells[i].Text == "OrderNumber")
                    {
                        e.Item.Cells[i].Text = "Order No";
                    }
                    if (e.Item.Cells[i].Text == "name")
                    {
                        e.Item.Cells[i].Text = "Referred By";
                    }
                    if (e.Item.Cells[i].Text == "SubTotal")
                    {
                        this.flacosts = true;
                        this.cellvalue_subtotal = i;
                        e.Item.Cells[i].Text = string.Concat("Sub Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "GrossProfitPrice")
                    {
                        this.flacosts = true;
                        this.cellvalue_grossprofitprice = i;
                        e.Item.Cells[i].Text = string.Concat("Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "GrossProfitPercentage")
                    {
                        this.flacosts = true;
                        this.cellvalue_grossprofitpercentage = i;
                        e.Item.Cells[i].Text = "Gross Profit (%)";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "CostExMarkup")
                    {
                        this.flacosts = true;
                        this.cellvalue_costexmarkup = i;
                        e.Item.Cells[i].Text = string.Concat("Cost Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AccountingCode")
                    {
                        e.Item.Cells[i].Text = "Accounting Code";
                    }
                    if (e.Item.Cells[i].Text == "CostCentre")
                    {
                        e.Item.Cells[i].Text = "Cost Centre";
                    }
                    if (e.Item.Cells[i].Text == "ItemQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_itemqty = i;
                        e.Item.Cells[i].Text = "Quantity";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "EstimatedJobTime")
                    {
                        e.Item.Cells[i].Text = "Estimated Job Time";
                    }
                    if (e.Item.Cells[i].Text == "ActaulJobTime")
                    {
                        e.Item.Cells[i].Text = "Actaul Job Time";
                    }
                    if (e.Item.Cells[i].Text == "EstimatedDeliveryDate")
                    {
                        e.Item.Cells[i].Text = "Estimated Delivery Date";
                    }
                    if (e.Item.Cells[i].Text == "ActualDeliveryDate")
                    {
                        e.Item.Cells[i].Text = "Actual Delivery Date";
                    }
                    if (e.Item.Cells[i].Text == "CustomerCode")
                    {
                        e.Item.Cells[i].Text = "Customer Code";
                    }
                    if (e.Item.Cells[i].Text == "PackUnit")
                    {
                        e.Item.Cells[i].Text = "Pack Unit";
                    }
                    if (e.Item.Cells[i].Text == "CostPrice")
                    {
                        this.flacosts = true;
                        this.cellvalue_costpriceinc = i;
                        e.Item.Cells[i].Text = string.Concat("Cost Price (Inc. Markup) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "SupplierName")
                    {
                        e.Item.Cells[i].Text = "Supplier Name";
                    }
                    if (e.Item.Cells[i].Text == "ProductTitle")
                    {
                        e.Item.Cells[i].Text = "Product Title";
                    }
                    if (e.Item.Cells[i].Text == "ProductCode")
                    {
                        e.Item.Cells[i].Text = "Product Code";
                    }
                    if (e.Item.Cells[i].Text == "ProductCatagory")
                    {
                        e.Item.Cells[i].Text = "Product Category";
                    }
                    if (e.Item.Cells[i].Text == "StoreName")
                    {
                        e.Item.Cells[i].Text = "Store Name";
                    }
                    if (e.Item.Cells[i].Text == "ProductWidth")
                    {
                        this.flacosts = true;
                        this.cellvalue_productwidth = i;
                        e.Item.Cells[i].Text = string.Concat("Product Width (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductHeight")
                    {
                        this.flacosts = true;
                        this.cellvalue_productheight = i;
                        e.Item.Cells[i].Text = string.Concat("Product Height (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductLength")
                    {
                        this.flacosts = true;
                        this.cellvalue_productlength = i;
                        e.Item.Cells[i].Text = string.Concat("Product Length (", this.Paper_Stock_Lenght, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductWeight")
                    {
                        this.flacosts = true;
                        this.cellvalue_productweight = i;
                        e.Item.Cells[i].Text = string.Concat("Product Weight (", this.Weight_gsm, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductDimension")
                    {
                        this.flacosts = true;
                        this.cellvalue_productdimension = i;
                        e.Item.Cells[i].Text = string.Concat("Product Dimension (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "EventName")
                    {
                        e.Item.Cells[i].Text = "Event Name";
                    }
                    if (e.Item.Cells[i].Text == "EventCodeNumber")
                    {
                        e.Item.Cells[i].Text = "Event Code";
                    }
                    if (e.Item.Cells[i].Text == "CampaignSignNumber")
                    {
                        e.Item.Cells[i].Text = "Sign No.";
                    }
                    if (e.Item.Cells[i].Text == "EventVenue")
                    {
                        e.Item.Cells[i].Text = "Venue";
                    }
                    if (e.Item.Cells[i].Text == "QTYDescription1")
                    {
                        this.flacosts = true;
                        this.cellvalue_qty = i;
                        e.Item.Cells[i].Text = "Quantity Description";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "jobname")
                    {
                        e.Item.Cells[i].Text = "Job Name";
                    }
                    if (e.Item.Cells[i].Text == "ContactJobTitle1")
                    {
                        e.Item.Cells[i].Text = "Contact Job Title 1";
                    }
                    if (e.Item.Cells[i].Text == "ContactJobTitle2")
                    {
                        e.Item.Cells[i].Text = "Contact Job Title 2";
                    }
                    if (e.Item.Cells[i].Text == "CustomerSalesperson")
                    {
                        e.Item.Cells[i].Text = "Customer Salesperson";
                    }
                    if (e.Item.Cells[i].Text == "OrderedFor")
                    {
                        e.Item.Cells[i].Text = "Ordered For";
                        this.cellvalue_ordererfor = i;
                    }
                    if (e.Item.Cells[i].Text == "CustomerType")
                    {
                        e.Item.Cells[i].Text = "Type";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceDate")
                    {
                        e.Item.Cells[i].Text = "Invoice Date";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceDueDate")
                    {
                        e.Item.Cells[i].Text = "Invoice Due Date";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceAmountPaid")
                    {
                        this.flacosts = true;
                        this.cellvalue_invoiceamountpaid = i;
                        e.Item.Cells[i].Text = string.Concat("Amount Paid (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "InvoiceAmountOutstanding")
                    {
                        this.flacosts = true;
                        this.cellvalue_invoiceamountOutstanding = i;
                        e.Item.Cells[i].Text = string.Concat("Amount Outstanding (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "commissionamount")
                    {
                        this.flacosts = true;
                        this.cellvalue_commissionamount = i;
                        e.Item.Cells[i].Text = string.Concat("Commission (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "CommissionPercentage")
                    {
                        this.flacosts = true;
                        this.cellvalue_commissionpercentage = i;
                        e.Item.Cells[i].Text = "Commission (%)";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "JobContactName")
                    {
                        e.Item.Cells[i].Text = "Job Contact Name";
                    }
                    if (e.Item.Cells[i].Text == "ProgressedDate")
                    {
                        e.Item.Cells[i].Text = "Progress On";
                    }
                    if (e.Item.Cells[i].Text == "InvoicePaid")
                    {
                        e.Item.Cells[i].Text = "Invoice Paid";
                    }
                    if (e.Item.Cells[i].Text == "CustomerAddress")
                    {
                        e.Item.Cells[i].Text = "Customer Address";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "totaltaxprice")
                    {
                        this.flacosts = true;
                        this.cellvalue_totalprice = i;
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                        e.Item.Cells[i].Text = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (e.Item.Cells[i].Text == "CustomField1")
                    {
                        e.Item.Cells[i].Text = this.CustomField1;
                    }
                    if (e.Item.Cells[i].Text == "CustomField2")
                    {
                        e.Item.Cells[i].Text = this.CustomField2;
                    }
                    if (e.Item.Cells[i].Text == "CustomField3")
                    {
                        e.Item.Cells[i].Text = this.CustomField3;
                    }
                    if (e.Item.Cells[i].Text == "CustomField4")
                    {
                        e.Item.Cells[i].Text = this.CustomField4;
                    }
                    if (e.Item.Cells[i].Text == "CustomField5")
                    {
                        e.Item.Cells[i].Text = this.CustomField5;
                    }
                    if (e.Item.Cells[i].Text == "CustomField6")
                    {
                        e.Item.Cells[i].Text = this.CustomField6;
                    }
                }
            }
            if (e.Item is GridDataItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    if (this.flacosts)
                    {
                        e.Item.Cells[this.cellvalue_subtotal].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_OrderValue].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_grossprofitprice].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_grossprofitpercentage].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_costexmarkup].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_qty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_itemqty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productwidth].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productheight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productlength].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productweight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productdimension].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_commissionamount].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_commissionpercentage].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_invoiceamountpaid].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_invoiceamountOutstanding].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_costpriceinc].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_totalprice].Attributes.Add("align", "right");
                    }
                    e.Item.Cells[this.cellvalue_invoiceno].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_jobno].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_activitynotes].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_itemtitle].Attributes.Add("style", "min-width:175px;");
                    e.Item.Cells[this.cellvalue_Companyname].Attributes.Add("style", "min-width:175px;");
                    e.Item.Cells[this.cellvalue_ordererfor].Attributes.Add("style", "min-width:100px;");
                    if (e.Item.Cells[this.cellvalue_invoice_description].Text.Length <= 25)
                    {
                        e.Item.Cells[this.cellvalue_invoice_description].Attributes.Add("style", "min-width:150px;");
                    }
                    else
                    {
                        e.Item.Cells[this.cellvalue_invoice_description].Attributes.Add("style", "min-width:200px;");
                    }
                }
            }
        }

        protected void grid_reports_invoice_needdatasource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            this.div_reportgrid.Attributes.Add("style", "display:block;");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            DateTime dateTime = Convert.ToDateTime(this.hdninvoiceFromdate_cust.Value);
            DateTime dateTime1 = Convert.ToDateTime(this.hdninvoicetodate_cust.Value);
            this.reportid = Convert.ToInt64(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime, dateTime1, 0, 0);
            DataTable item = dataSet.Tables[0];
            this.grid_reports_byreportid_invoice.DataSource = item;
            if (item.Columns.Contains("ActivityNotes"))
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row["ActivityNotes"] == null)
                    {
                        continue;
                    }
                    row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                    row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                }
            }
            if (item.Columns.Contains("Orderid"))
            {
                item.Columns.Remove("Orderid");
            }
            if (item.Columns.Contains("Estimateid"))
            {
                item.Columns.Remove("Estimateid");
            }
            if (item.Columns.Contains("clientID"))
            {
                item.Columns.Remove("clientID");
            }
            if (item.Columns.Contains("Invoiceid"))
            {
                item.Columns.Remove("Invoiceid");
            }
            if (item.Columns.Contains("jobid"))
            {
                item.Columns.Remove("jobid");
            }
            if (item.Columns.Contains("IsStockItem"))
            {
                item.Columns.Remove("IsStockItem");
            }
            if (item.Columns.Contains("ActivityRecords"))
            {
                item.Columns.Remove("ActivityRecords");
            }
            if (item.Columns.Contains("TempProduct"))
            {
                item.Columns.Remove("TempProduct");
            }
            if (item.Columns.Contains("TempAvailableQty"))
            {
                item.Columns.Remove("TempAvailableQty");
            }
            if (item.Columns.Contains("pricecatalogueid"))
            {
                item.Columns.Remove("pricecatalogueid");
            }
            if (item.Columns.Contains("RowNumber"))
            {
                item.Columns.Remove("RowNumber");
            }
            foreach (DataRow dataRow in item.Rows)
            {
                if (item.Columns.Contains("CreatedDate") && dataRow["createddate"].ToString() != "")
                {
                    dataRow["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("OrderDate") && dataRow["OrderDate"].ToString() != "")
                {
                    dataRow["OrderDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DueDate") && dataRow["DueDate"].ToString() != "")
                {
                    dataRow["DueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("CompletionDate") && dataRow["CompletionDate"].ToString() != "")
                {
                    dataRow["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DeliveryDate") && dataRow["DeliveryDate"].ToString() != "")
                {
                    dataRow["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("actualdeliverydate") && dataRow["actualdeliverydate"].ToString() != "")
                {
                    dataRow["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(dataRow["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("EstimatedDeliveryDate") && dataRow["EstimatedDeliveryDate"].ToString() != "")
                {
                    dataRow["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ActualDeliveryDate") && dataRow["ActualDeliveryDate"].ToString() != "")
                {
                    dataRow["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ProgressedDate") && dataRow["ProgressedDate"].ToString() != "")
                {
                    dataRow["ProgressedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["ProgressedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("InvoiceDate") && dataRow["InvoiceDate"].ToString() != "")
                {
                    dataRow["InvoiceDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["InvoiceDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("InvoiceDueDate") && dataRow["InvoiceDueDate"].ToString() != "")
                {
                    dataRow["InvoiceDueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["InvoiceDueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ContactAddress") && dataRow["ContactAddress"].ToString() != "")
                {
                    dataRow["ContactAddress"] = this.objBc.SpecialDecode(dataRow["ContactAddress"].ToString());
                }
                if (item.Columns.Contains("DeliveryAddress") && dataRow["DeliveryAddress"].ToString() != "")
                {
                    dataRow["DeliveryAddress"] = this.objBc.SpecialDecode(dataRow["DeliveryAddress"].ToString());
                }
                if (item.Columns.Contains("InvoiceAddress") && dataRow["InvoiceAddress"].ToString() != "")
                {
                    dataRow["InvoiceAddress"] = this.objBc.SpecialDecode(dataRow["InvoiceAddress"].ToString());
                }
                if (item.Columns.Contains("ItemTitle") && dataRow["ItemTitle"].ToString() != "")
                {
                    dataRow["ItemTitle"] = this.objBc.SpecialDecode(dataRow["ItemTitle"].ToString());
                }
                if (item.Columns.Contains("Description") && dataRow["Description"].ToString() != "")
                {
                    dataRow["Description"] = this.objBc.SpecialDecode(dataRow["Description"].ToString());
                }
                if (item.Columns.Contains("ActivityNotes") && dataRow["ActivityNotes"].ToString() != "")
                {
                    dataRow["ActivityNotes"] = this.objBc.SpecialDecode(dataRow["ActivityNotes"].ToString());
                }
                if (item.Columns.Contains("ContactName") && dataRow["ContactName"].ToString() != "")
                {
                    dataRow["ContactName"] = this.objBc.SpecialDecode(dataRow["ContactName"].ToString());
                }
                if (item.Columns.Contains("OrderTitle") && dataRow["OrderTitle"].ToString() != "")
                {
                    dataRow["OrderTitle"] = this.objBc.SpecialDecode(dataRow["OrderTitle"].ToString());
                }
                if (item.Columns.Contains("Company") && dataRow["Company"].ToString() != "")
                {
                    dataRow["Company"] = this.objBc.SpecialDecode(dataRow["Company"].ToString());
                }
                if (item.Columns.Contains("totaltaxprice") && dataRow["totaltaxprice"].ToString() != "")
                {
                    dataRow["totaltaxprice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["totaltaxprice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("TotalTaxPrice") && dataRow["TotalTaxPrice"].ToString() != "")
                {
                    dataRow["TotalTaxPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalTaxPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("OrderValue") && dataRow["OrderValue"].ToString() != "")
                {
                    dataRow["OrderValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["OrderValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("SubTotal") && dataRow["SubTotal"].ToString() != "")
                {
                    dataRow["SubTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["SubTotal"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPrice") && dataRow["GrossProfitPrice"].ToString() != "")
                {
                    dataRow["GrossProfitPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPercentage") && dataRow["GrossProfitPercentage"].ToString() != "")
                {
                    dataRow["GrossProfitPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostExMarkup") && dataRow["CostExMarkup"].ToString() != "")
                {
                    dataRow["CostExMarkup"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostExMarkup"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWidth") && dataRow["ProductWidth"].ToString() != "")
                {
                    dataRow["ProductWidth"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWidth"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Width") && dataRow["Width"].ToString() != "")
                {
                    dataRow["Width"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Width"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductHeight") && dataRow["ProductHeight"].ToString() != "")
                {
                    dataRow["ProductHeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductHeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Height") && dataRow["Height"].ToString() != "")
                {
                    dataRow["Height"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Height"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductLength") && dataRow["ProductLength"].ToString() != "")
                {
                    dataRow["ProductLength"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductLength"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Length") && dataRow["Length"].ToString() != "")
                {
                    dataRow["Length"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Length"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWeight") && dataRow["ProductWeight"].ToString() != "")
                {
                    dataRow["ProductWeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Weight") && dataRow["Weight"].ToString() != "")
                {
                    dataRow["Weight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Weight"].ToString()), 2, "", false, false, true);
                }
                item.Columns.Contains("ProductDimension");
                if (item.Columns.Contains("JobValue") && dataRow["JobValue"].ToString() != "")
                {
                    dataRow["JobValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["JobValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostPrice") && dataRow["CostPrice"].ToString() != "")
                {
                    dataRow["CostPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionAmount") && dataRow["CommissionAmount"].ToString() != "")
                {
                    dataRow["CommissionAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionAmount"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionPercentage") && dataRow["CommissionPercentage"].ToString() != "")
                {
                    dataRow["CommissionPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceValue") && dataRow["InvoiceValue"].ToString() != "")
                {
                    dataRow["InvoiceValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceAmountPaid") && dataRow["InvoiceAmountPaid"].ToString() != "")
                {
                    dataRow["InvoiceAmountPaid"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountPaid"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("InvoiceAmountOutstanding") || !(dataRow["InvoiceAmountOutstanding"].ToString() != ""))
                {
                    continue;
                }
                dataRow["InvoiceAmountOutstanding"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountOutstanding"].ToString()), 2, "", false, false, true);
            }
            if (this.Reports_type.ToLower() == "job")
            {
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("EstimateItemID"))
                {
                    item.Columns.Remove("EstimateItemID");
                }
                foreach (DataRow row1 in item.Rows)
                {
                    if (row1.Table.Columns.Contains("CustomerName"))
                    {
                        row1["CustomerName"] = this.objBc.SpecialDecode(row1["CustomerName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactName"))
                    {
                        row1["ContactName"] = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Department"))
                    {
                        row1["Department"] = this.objBc.SpecialDecode(row1["Department"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeremail"))
                    {
                        row1["customeremail"] = this.objBc.SpecialDecode(row1["customeremail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactemail"))
                    {
                        row1["contactemail"] = this.objBc.SpecialDecode(row1["contactemail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle1"))
                    {
                        row1["ContactJobTitle1"] = this.objBc.SpecialDecode(row1["ContactJobTitle1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle2"))
                    {
                        row1["ContactJobTitle2"] = this.objBc.SpecialDecode(row1["ContactJobTitle2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("CustomerType"))
                    {
                        row1["CustomerType"] = this.objBc.SpecialDecode(row1["CustomerType"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactphone"))
                    {
                        row1["contactphone"] = this.objBc.SpecialDecode(row1["contactphone"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress1"))
                    {
                        row1["contactaddress1"] = this.objBc.SpecialDecode(row1["contactaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress2"))
                    {
                        row1["contactaddress2"] = this.objBc.SpecialDecode(row1["contactaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress3"))
                    {
                        row1["contactaddress3"] = this.objBc.SpecialDecode(row1["contactaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress4"))
                    {
                        row1["contactaddress4"] = this.objBc.SpecialDecode(row1["contactaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress5"))
                    {
                        row1["contactaddress5"] = this.objBc.SpecialDecode(row1["contactaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress6"))
                    {
                        row1["contactaddress6"] = this.objBc.SpecialDecode(row1["contactaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress"))
                    {
                        row1["contactaddress"] = this.objBc.SpecialDecode(row1["contactaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress1"))
                    {
                        row1["deliveryaddress1"] = this.objBc.SpecialDecode(row1["deliveryaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress2"))
                    {
                        row1["deliveryaddress2"] = this.objBc.SpecialDecode(row1["deliveryaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress3"))
                    {
                        row1["deliveryaddress3"] = this.objBc.SpecialDecode(row1["deliveryaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress4"))
                    {
                        row1["deliveryaddress4"] = this.objBc.SpecialDecode(row1["deliveryaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress5"))
                    {
                        row1["deliveryaddress5"] = this.objBc.SpecialDecode(row1["deliveryaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress6"))
                    {
                        row1["deliveryaddress6"] = this.objBc.SpecialDecode(row1["deliveryaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress"))
                    {
                        row1["deliveryaddress"] = this.objBc.SpecialDecode(row1["deliveryaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress1"))
                    {
                        row1["invoiceaddress1"] = this.objBc.SpecialDecode(row1["invoiceaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress2"))
                    {
                        row1["invoiceaddress2"] = this.objBc.SpecialDecode(row1["invoiceaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress3"))
                    {
                        row1["invoiceaddress3"] = this.objBc.SpecialDecode(row1["invoiceaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress4"))
                    {
                        row1["invoiceaddress4"] = this.objBc.SpecialDecode(row1["invoiceaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress5"))
                    {
                        row1["invoiceaddress5"] = this.objBc.SpecialDecode(row1["invoiceaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress6"))
                    {
                        row1["invoiceaddress6"] = this.objBc.SpecialDecode(row1["invoiceaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress"))
                    {
                        row1["invoiceaddress"] = this.objBc.SpecialDecode(row1["invoiceaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Estimator"))
                    {
                        row1["Estimator"] = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                    }
                    if (row1.Table.Columns.Contains("salesperson"))
                    {
                        row1["salesperson"] = this.objBc.SpecialDecode(row1["salesperson"].ToString());
                    }
                    if (row1.Table.Columns.Contains("jobtitle"))
                    {
                        row1["jobtitle"] = this.objBc.SpecialDecode(row1["jobtitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Status"))
                    {
                        row1["Status"] = this.objBc.SpecialDecode(row1["Status"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ItemTitle"))
                    {
                        row1["ItemTitle"] = this.objBc.SpecialDecode(row1["ItemTitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Description"))
                    {
                        row1["DEscription"] = this.objBc.SpecialDecode(row1["DEscription"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Artwork"))
                    {
                        row1["Artwork"] = this.objBc.SpecialDecode(row1["Artwork"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Colour"))
                    {
                        row1["Colour"] = this.objBc.SpecialDecode(row1["Colour"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Size"))
                    {
                        row1["Size"] = this.objBc.SpecialDecode(row1["Size"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Material"))
                    {
                        row1["Material"] = this.objBc.SpecialDecode(row1["Material"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Delivery"))
                    {
                        row1["Delivery"] = this.objBc.SpecialDecode(row1["Delivery"].ToString());
                    }
                    if (row1.Table.Columns.Contains("finishing"))
                    {
                        row1["finishing"] = this.objBc.SpecialDecode(row1["finishing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("notes"))
                    {
                        row1["notes"] = this.objBc.SpecialDecode(row1["notes"].ToString());
                    }
                    if (row1.Table.Columns.Contains("instructions"))
                    {
                        row1["instructions"] = this.objBc.SpecialDecode(row1["instructions"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Proofs"))
                    {
                        row1["Proofs"] = this.objBc.SpecialDecode(row1["Proofs"].ToString());
                    }
                    if (row1.Table.Columns.Contains("packing"))
                    {
                        row1["packing"] = this.objBc.SpecialDecode(row1["packing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ordernumber"))
                    {
                        row1["ordernumber"] = this.objBc.SpecialDecode(row1["ordernumber"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Name"))
                    {
                        row1["Name"] = this.objBc.SpecialDecode(row1["Name"].ToString());
                    }
                    if (row1.Table.Columns.Contains("suppliername"))
                    {
                        row1["suppliername"] = this.objBc.SpecialDecode(row1["suppliername"].ToString());
                    }
                    if (row1.Table.Columns.Contains("producttitle"))
                    {
                        row1["producttitle"] = this.objBc.SpecialDecode(row1["producttitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcode"))
                    {
                        row1["productcode"] = this.objBc.SpecialDecode(row1["productcode"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcatagory"))
                    {
                        row1["productcatagory"] = this.objBc.SpecialDecode(row1["productcatagory"].ToString());
                    }
                    if (row1.Table.Columns.Contains("storename"))
                    {
                        row1["storename"] = this.objBc.SpecialDecode(row1["storename"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress1"))
                    {
                        row1["customeraddress1"] = this.objBc.SpecialDecode(row1["customeraddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress2"))
                    {
                        row1["customeraddress2"] = this.objBc.SpecialDecode(row1["customeraddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress3"))
                    {
                        row1["customeraddress3"] = this.objBc.SpecialDecode(row1["customeraddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress4"))
                    {
                        row1["customeraddress4"] = this.objBc.SpecialDecode(row1["customeraddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress5"))
                    {
                        row1["customeraddress5"] = this.objBc.SpecialDecode(row1["customeraddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress6"))
                    {
                        row1["customeraddress6"] = this.objBc.SpecialDecode(row1["customeraddress6"].ToString());
                    }
                    if (!row1.Table.Columns.Contains("customeraddress"))
                    {
                        continue;
                    }
                    row1["customeraddress"] = this.objBc.SpecialDecode(row1["customeraddress"].ToString());
                }
            }
            foreach (DataRow dataRow1 in item.Rows)
            {
                if (dataRow1.Table.Columns.Contains("clientname"))
                {
                    dataRow1["clientname"] = this.objBc.SpecialDecode(dataRow1["clientname"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactName"))
                {
                    dataRow1["ContactName"] = this.objBc.SpecialDecode(dataRow1["ContactName"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Department"))
                {
                    dataRow1["Department"] = this.objBc.SpecialDecode(dataRow1["Department"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeremail"))
                {
                    dataRow1["customeremail"] = this.objBc.SpecialDecode(dataRow1["customeremail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactemail"))
                {
                    dataRow1["contactemail"] = this.objBc.SpecialDecode(dataRow1["contactemail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle1"))
                {
                    dataRow1["ContactJobTitle1"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle2"))
                {
                    dataRow1["ContactJobTitle2"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("CustomerType"))
                {
                    dataRow1["CustomerType"] = this.objBc.SpecialDecode(dataRow1["CustomerType"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactphone"))
                {
                    dataRow1["contactphone"] = this.objBc.SpecialDecode(dataRow1["contactphone"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress1"))
                {
                    dataRow1["contactaddress1"] = this.objBc.SpecialDecode(dataRow1["contactaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress2"))
                {
                    dataRow1["contactaddress2"] = this.objBc.SpecialDecode(dataRow1["contactaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress3"))
                {
                    dataRow1["contactaddress3"] = this.objBc.SpecialDecode(dataRow1["contactaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress4"))
                {
                    dataRow1["contactaddress4"] = this.objBc.SpecialDecode(dataRow1["contactaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress5"))
                {
                    dataRow1["contactaddress5"] = this.objBc.SpecialDecode(dataRow1["contactaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress6"))
                {
                    dataRow1["contactaddress6"] = this.objBc.SpecialDecode(dataRow1["contactaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress"))
                {
                    dataRow1["contactaddress"] = this.objBc.SpecialDecode(dataRow1["contactaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress1"))
                {
                    dataRow1["deliveryaddress1"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress2"))
                {
                    dataRow1["deliveryaddress2"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress3"))
                {
                    dataRow1["deliveryaddress3"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress4"))
                {
                    dataRow1["deliveryaddress4"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress5"))
                {
                    dataRow1["deliveryaddress5"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress6"))
                {
                    dataRow1["deliveryaddress6"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress"))
                {
                    dataRow1["deliveryaddress"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress1"))
                {
                    dataRow1["invoiceaddress1"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress2"))
                {
                    dataRow1["invoiceaddress2"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress3"))
                {
                    dataRow1["invoiceaddress3"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress4"))
                {
                    dataRow1["invoiceaddress4"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress5"))
                {
                    dataRow1["invoiceaddress5"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress6"))
                {
                    dataRow1["invoiceaddress6"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress"))
                {
                    dataRow1["invoiceaddress"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("salesperson"))
                {
                    dataRow1["salesperson"] = this.objBc.SpecialDecode(dataRow1["salesperson"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("InvoiceTitle"))
                {
                    dataRow1["InvoiceTitle"] = this.objBc.SpecialDecode(dataRow1["InvoiceTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Status"))
                {
                    dataRow1["Status"] = this.objBc.SpecialDecode(dataRow1["Status"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ItemTitle"))
                {
                    dataRow1["ItemTitle"] = this.objBc.SpecialDecode(dataRow1["ItemTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Description"))
                {
                    dataRow1["DEscription"] = this.objBc.SpecialDecode(dataRow1["DEscription"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Artwork"))
                {
                    dataRow1["Artwork"] = this.objBc.SpecialDecode(dataRow1["Artwork"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Colour"))
                {
                    dataRow1["Colour"] = this.objBc.SpecialDecode(dataRow1["Colour"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Size"))
                {
                    dataRow1["Size"] = this.objBc.SpecialDecode(dataRow1["Size"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Material"))
                {
                    dataRow1["Material"] = this.objBc.SpecialDecode(dataRow1["Material"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Delivery"))
                {
                    dataRow1["Delivery"] = this.objBc.SpecialDecode(dataRow1["Delivery"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("finishing"))
                {
                    dataRow1["finishing"] = this.objBc.SpecialDecode(dataRow1["finishing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("notes"))
                {
                    dataRow1["notes"] = this.objBc.SpecialDecode(dataRow1["notes"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("instructions"))
                {
                    dataRow1["instructions"] = this.objBc.SpecialDecode(dataRow1["instructions"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Proofs"))
                {
                    dataRow1["Proofs"] = this.objBc.SpecialDecode(dataRow1["Proofs"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("packing"))
                {
                    dataRow1["packing"] = this.objBc.SpecialDecode(dataRow1["packing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ordernumber"))
                {
                    dataRow1["ordernumber"] = this.objBc.SpecialDecode(dataRow1["ordernumber"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Name"))
                {
                    dataRow1["Name"] = this.objBc.SpecialDecode(dataRow1["Name"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("suppliername"))
                {
                    dataRow1["suppliername"] = this.objBc.SpecialDecode(dataRow1["suppliername"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("producttitle"))
                {
                    dataRow1["producttitle"] = this.objBc.SpecialDecode(dataRow1["producttitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("productcode"))
                {
                    dataRow1["productcode"] = this.objBc.SpecialDecode(dataRow1["productcode"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("storename"))
                {
                    dataRow1["storename"] = this.objBc.SpecialDecode(dataRow1["storename"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress1"))
                {
                    dataRow1["customeraddress1"] = this.objBc.SpecialDecode(dataRow1["customeraddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress2"))
                {
                    dataRow1["customeraddress2"] = this.objBc.SpecialDecode(dataRow1["customeraddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress3"))
                {
                    dataRow1["customeraddress3"] = this.objBc.SpecialDecode(dataRow1["customeraddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress4"))
                {
                    dataRow1["customeraddress4"] = this.objBc.SpecialDecode(dataRow1["customeraddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress5"))
                {
                    dataRow1["customeraddress5"] = this.objBc.SpecialDecode(dataRow1["customeraddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress6"))
                {
                    dataRow1["customeraddress6"] = this.objBc.SpecialDecode(dataRow1["customeraddress6"].ToString());
                }
                if (!dataRow1.Table.Columns.Contains("customeraddress"))
                {
                    continue;
                }
                dataRow1["customeraddress"] = this.objBc.SpecialDecode(dataRow1["customeraddress"].ToString());
            }
            foreach (DataRow row2 in dataSet.Tables[0].Rows)
            {
                if (row2.Table.Columns.Contains("ItemTitle"))
                {
                    row2["ItemTitle"] = this.objBc.SpecialDecode(row2["ItemTitle"].ToString());
                }
                if (row2.Table.Columns.Contains("CategoryName"))
                {
                    row2["CategoryName"] = this.objBc.SpecialDecode(row2["CategoryName"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemCode"))
                {
                    row2["ItemCode"] = this.objBc.SpecialDecode(row2["ItemCode"].ToString());
                }
                if (row2.Table.Columns.Contains("CustomerCode"))
                {
                    row2["CustomerCode"] = this.objBc.SpecialDecode(row2["CustomerCode"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemDescription"))
                {
                    row2["ItemDescription"] = this.objBc.SpecialDecode(row2["ItemDescription"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemArtWork"))
                {
                    row2["ItemArtWork"] = this.objBc.SpecialDecode(row2["ItemArtWork"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemColour"))
                {
                    row2["ItemColour"] = this.objBc.SpecialDecode(row2["ItemColour"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemSize"))
                {
                    row2["ItemSize"] = this.objBc.SpecialDecode(row2["ItemSize"].ToString());
                }
                if (row2.Table.Columns.Contains("Material"))
                {
                    row2["Material"] = this.objBc.SpecialDecode(row2["Material"].ToString());
                }
                if (row2.Table.Columns.Contains("Delivery"))
                {
                    row2["Delivery"] = this.objBc.SpecialDecode(row2["Delivery"].ToString());
                }
                if (row2.Table.Columns.Contains("Finishing"))
                {
                    row2["Finishing"] = this.objBc.SpecialDecode(row2["Finishing"].ToString());
                }
                if (row2.Table.Columns.Contains("Proofs"))
                {
                    row2["Proofs"] = this.objBc.SpecialDecode(row2["Proofs"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemPacking"))
                {
                    row2["ItemPacking"] = this.objBc.SpecialDecode(row2["ItemPacking"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemNotes"))
                {
                    row2["ItemNotes"] = this.objBc.SpecialDecode(row2["ItemNotes"].ToString());
                }
                if (row2.Table.Columns.Contains("Terms/Instructions"))
                {
                    row2["Terms/Instructions"] = this.objBc.SpecialDecode(row2["Terms/Instructions"].ToString());
                }
                if (item.Columns.Contains("price") && row2["price"].ToString() != "")
                {
                    row2["price"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["price"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpPercentage") && row2["MarkUpPercentage"].ToString() != "")
                {
                    row2["MarkUpPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpValue") && row2["MarkUpValue"].ToString() != "")
                {
                    row2["MarkUpValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpValue"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("SellingPrice") || !(row2["SellingPrice"].ToString() != ""))
                {
                    continue;
                }
                row2["SellingPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["SellingPrice"].ToString()), 2, "", false, false, true);
            }
        }

        protected void grid_reports_jobs_itemdatabound(object sender, GridItemEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            TextBox textBox = (TextBox)e.Item.FindControl("txtfrmdate_job");
            if (textBox != null)
            {
                textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.hdnjobFromdate_cust.Value == "" || this.hdnjobFromdate_cust.Value == "0")
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                else
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnjobFromdate_cust.Value, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
            }
            TextBox textBox1 = (TextBox)e.Item.FindControl("txttodate_job");
            if (textBox1 != null)
            {
                textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.hdnjobtodate_cust.Value == "" || this.hdnjobtodate_cust.Value == "0")
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                else
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnjobtodate_cust.Value, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    if (e.Item.Cells[i].Text == "Eventstartdate")
                    {
                        e.Item.Cells[i].Visible = false;
                    }
                    if (e.Item.Cells[i].Text == "Eventenddate")
                    {
                        e.Item.Cells[i].Visible = false;
                    }
                    if (e.Item.Cells[i].Text == "JobNumber")
                    {
                        e.Item.Cells[i].Text = "Job No.";
                        this.cellvalue_jobno = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "jobtitle")
                    {
                        e.Item.Cells[i].Text = "Job Title";
                    }
                    if (e.Item.Cells[i].Text == "CustomerName")
                    {
                        e.Item.Cells[i].Text = "Company";
                        this.cellvalue_Companyname = i;
                    }
                    if (e.Item.Cells[i].Text == "ContactName")
                    {
                        e.Item.Cells[i].Text = "Contact";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customeremail")
                    {
                        e.Item.Cells[i].Text = "Customer Email";
                    }
                    if (e.Item.Cells[i].Text == "ContactEmail")
                    {
                        e.Item.Cells[i].Text = "Contact Email";
                    }
                    if (e.Item.Cells[i].Text == "ContactPhone")
                    {
                        e.Item.Cells[i].Text = "Contact Phone";
                    }
                    if (e.Item.Cells[i].Text == "ContactAddress")
                    {
                        e.Item.Cells[i].Text = "Contact Address";
                    }
                    if (e.Item.Cells[i].Text == "DeliveryAddress")
                    {
                        e.Item.Cells[i].Text = "Delivery Address";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceAddress")
                    {
                        e.Item.Cells[i].Text = "Invoice Address";
                    }
                    if (e.Item.Cells[i].Text == "SalesPerson")
                    {
                        e.Item.Cells[i].Text = "Job SalesPerson";
                    }
                    if (e.Item.Cells[i].Text == "CompletionDate")
                    {
                        e.Item.Cells[i].Text = "Completed On";
                    }
                    if (e.Item.Cells[i].Text == "CreatedDate")
                    {
                        e.Item.Cells[i].Text = "Created On";
                    }
                    if (e.Item.Cells[i].Text == "DeliveryDate")
                    {
                        e.Item.Cells[i].Text = "Delivery Date";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "actualdeliverydate")
                    {
                        e.Item.Cells[i].Text = "Actual Delivery Date";
                    }
                    if (e.Item.Cells[i].Text == "JobValue")
                    {
                        this.flacosts = true;
                        this.cellvalue_jobvalue = i;
                        e.Item.Cells[i].Text = string.Concat("Job Value Inc.Tax (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "description")
                    {
                        e.Item.Cells[i].Text = "Description";
                        this.cellvalue_job_description = i;
                    }
                    if (e.Item.Cells[i].Text == "ItemTitle")
                    {
                        e.Item.Cells[i].Text = "Item Title";
                        this.cellvalue_itemtitle = i;
                    }
                    if (e.Item.Cells[i].Text == "ItemStatusTitle")
                    {
                        e.Item.Cells[i].Text = "Item Status";
                    }
                    if (e.Item.Cells[i].Text == "Material")
                    {
                        e.Item.Cells[i].Text = "Paper/Stock";
                    }
                    if (e.Item.Cells[i].Text == "OrderNumber")
                    {
                        e.Item.Cells[i].Text = "Order No";
                    }
                    if (e.Item.Cells[i].Text == "name")
                    {
                        e.Item.Cells[i].Text = "Referred By";
                    }
                    if (e.Item.Cells[i].Text == "SubTotal")
                    {
                        this.flacosts = true;
                        this.cellvalue_subtotal = i;
                        e.Item.Cells[i].Text = string.Concat("Sub Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "GrossProfitPrice")
                    {
                        this.flacosts = true;
                        this.cellvalue_grossprofitprice = i;
                        e.Item.Cells[i].Text = string.Concat("Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "GrossProfitPercentage")
                    {
                        this.flacosts = true;
                        this.cellvalue_grossprofitpercentage = i;
                        e.Item.Cells[i].Text = "Gross Profit (%)";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "CostExMarkup")
                    {
                        this.flacosts = true;
                        this.cellvalue_costexmarkup = i;
                        e.Item.Cells[i].Text = string.Concat("Cost Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AccountingCode")
                    {
                        e.Item.Cells[i].Text = "Accounting Code";
                    }
                    if (e.Item.Cells[i].Text == "CostCentre")
                    {
                        e.Item.Cells[i].Text = "Cost Centre";
                    }
                    if (e.Item.Cells[i].Text == "ItemQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_itemqty = i;
                        e.Item.Cells[i].Text = "Quantity";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "EstimatedJobTime")
                    {
                        e.Item.Cells[i].Text = "Estimated Job Time";
                    }
                    if (e.Item.Cells[i].Text == "ActaulJobTime")
                    {
                        e.Item.Cells[i].Text = "Actaul Job Time";
                    }
                    if (e.Item.Cells[i].Text == "EstimatedDeliveryDate")
                    {
                        e.Item.Cells[i].Text = "Estimated Delivery Date";
                    }
                    if (e.Item.Cells[i].Text == "ActualDeliveryDate")
                    {
                        e.Item.Cells[i].Text = "Actual Delivery Date";
                    }
                    if (e.Item.Cells[i].Text == "CustomerCode")
                    {
                        e.Item.Cells[i].Text = "Customer Code";
                    }
                    if (e.Item.Cells[i].Text == "PackUnit")
                    {
                        e.Item.Cells[i].Text = "Pack Unit";
                    }
                    if (e.Item.Cells[i].Text == "CostPrice")
                    {
                        this.flacosts = true;
                        this.cellvalue_costpriceinc = i;
                        e.Item.Cells[i].Text = string.Concat("Cost Price (Inc. Markup) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "SupplierName")
                    {
                        e.Item.Cells[i].Text = "Supplier Name";
                    }
                    if (e.Item.Cells[i].Text == "ProductTitle")
                    {
                        e.Item.Cells[i].Text = "Product Title";
                    }
                    if (e.Item.Cells[i].Text == "ProductCode")
                    {
                        e.Item.Cells[i].Text = "Product Code";
                    }
                    if (e.Item.Cells[i].Text == "ProductCatagory")
                    {
                        e.Item.Cells[i].Text = "Product Category";
                    }
                    if (e.Item.Cells[i].Text == "StoreName")
                    {
                        e.Item.Cells[i].Text = "Store Name";
                    }
                    if (e.Item.Cells[i].Text == "ProductWidth")
                    {
                        this.flacosts = true;
                        this.cellvalue_productwidth = i;
                        e.Item.Cells[i].Text = string.Concat("Product Width (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductHeight")
                    {
                        this.flacosts = true;
                        this.cellvalue_productheight = i;
                        e.Item.Cells[i].Text = string.Concat("Product Height (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductLength")
                    {
                        this.flacosts = true;
                        this.cellvalue_productlength = i;
                        e.Item.Cells[i].Text = string.Concat("Product Length (", this.Paper_Stock_Lenght, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductWeight")
                    {
                        this.flacosts = true;
                        this.cellvalue_productweight = i;
                        e.Item.Cells[i].Text = string.Concat("Product Weight (", this.Weight_gsm, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductDimension")
                    {
                        this.flacosts = true;
                        this.cellvalue_productdimension = i;
                        e.Item.Cells[i].Text = string.Concat("Product Dimension (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "EventName")
                    {
                        e.Item.Cells[i].Text = "Event Name";
                    }
                    if (e.Item.Cells[i].Text == "EventCodeNumber")
                    {
                        e.Item.Cells[i].Text = "Event Code";
                    }
                    if (e.Item.Cells[i].Text == "CampaignSignNumber")
                    {
                        e.Item.Cells[i].Text = "Sign No.";
                    }
                    if (e.Item.Cells[i].Text == "EventVenue")
                    {
                        e.Item.Cells[i].Text = "Venue";
                    }
                    if (e.Item.Cells[i].Text == "QTYDescription1")
                    {
                        this.flacosts = true;
                        this.cellvalue_qty = i;
                        e.Item.Cells[i].Text = "Quantity Description";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "jobname")
                    {
                        e.Item.Cells[i].Text = "Job Name";
                    }
                    if (e.Item.Cells[i].Text == "ContactJobTitle1")
                    {
                        e.Item.Cells[i].Text = "Contact Job Title 1";
                    }
                    if (e.Item.Cells[i].Text == "ContactJobTitle2")
                    {
                        e.Item.Cells[i].Text = "Contact Job Title 2";
                    }
                    if (e.Item.Cells[i].Text == "CustomerSalesperson")
                    {
                        e.Item.Cells[i].Text = "Customer Salesperson";
                    }
                    if (e.Item.Cells[i].Text == "OrderedFor")
                    {
                        e.Item.Cells[i].Text = "Ordered For";
                        this.cellvalue_ordererfor = i;
                    }
                    if (e.Item.Cells[i].Text == "CustomerType")
                    {
                        e.Item.Cells[i].Text = "Type";
                    }
                    if (e.Item.Cells[i].Text == "CustomerAddress")
                    {
                        e.Item.Cells[i].Text = "Customer Address";
                    }
                    if (e.Item.Cells[i].Text == "ActivityNotes")
                    {
                        e.Item.Cells[i].Text = "Activity Notes";
                        this.cellvalue_activitynotes = i;
                    }
                    if (e.Item.Cells[i].Text == "commissionamount")
                    {
                        this.flacosts = true;
                        this.cellvalue_commissionamount = i;
                        e.Item.Cells[i].Text = string.Concat("Commission (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "CommissionPercentage")
                    {
                        this.flacosts = true;
                        this.cellvalue_commissionpercentage = i;
                        e.Item.Cells[i].Text = "Commission (%)";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "totaltaxprice")
                    {
                        this.flacosts = true;
                        this.cellvalue_totalprice = i;
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                        e.Item.Cells[i].Text = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (e.Item.Cells[i].Text == "CustomField1")
                    {
                        e.Item.Cells[i].Text = this.CustomField1;
                    }
                    if (e.Item.Cells[i].Text == "CustomField2")
                    {
                        e.Item.Cells[i].Text = this.CustomField2;
                    }
                    if (e.Item.Cells[i].Text == "CustomField3")
                    {
                        e.Item.Cells[i].Text = this.CustomField3;
                    }
                    if (e.Item.Cells[i].Text == "CustomField4")
                    {
                        e.Item.Cells[i].Text = this.CustomField4;
                    }
                    if (e.Item.Cells[i].Text == "CustomField5")
                    {
                        e.Item.Cells[i].Text = this.CustomField5;
                    }
                    if (e.Item.Cells[i].Text == "CustomField6")
                    {
                        e.Item.Cells[i].Text = this.CustomField6;
                    }
                }
            }
            if (e.Item is GridDataItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    if (this.flacosts)
                    {
                        e.Item.Cells[this.cellvalue_subtotal].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_OrderValue].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_grossprofitprice].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_grossprofitpercentage].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_costexmarkup].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_qty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_itemqty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productwidth].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productheight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productlength].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productweight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productdimension].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_commissionamount].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_commissionpercentage].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_costpriceinc].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_jobvalue].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_totalprice].Attributes.Add("align", "right");
                    }
                    e.Item.Cells[this.cellvalue_jobno].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_activitynotes].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_itemtitle].Attributes.Add("style", "min-width:175px;");
                    e.Item.Cells[this.cellvalue_Companyname].Attributes.Add("style", "min-width:175px;");
                    e.Item.Cells[this.cellvalue_Companyname].Attributes.Add("style", "min-width:100px;");
                    if (e.Item.Cells[this.cellvalue_job_description].Text.Length <= 25)
                    {
                        e.Item.Cells[this.cellvalue_job_description].Attributes.Add("style", "min-width:150px;");
                    }
                    else
                    {
                        e.Item.Cells[this.cellvalue_job_description].Attributes.Add("style", "min-width:200px;");
                    }
                }
            }
        }

        protected void grid_reports_jobs_needdatasource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            this.div_reportgrid.Attributes.Add("style", "display:block;");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            DateTime dateTime = Convert.ToDateTime(this.hdnjobFromdate_cust.Value);
            DateTime dateTime1 = Convert.ToDateTime(this.hdnjobtodate_cust.Value);
            this.reportid = Convert.ToInt64(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime, dateTime1, 0, 0);
            DataTable item = dataSet.Tables[0];
            this.grid_reports_byreportid_jobs.DataSource = item;
            if (item.Columns.Contains("Eventstartdate") && item.Columns.Contains("Eventenddate"))
            {
                DataColumn dataColumn = new DataColumn();
                item.Columns.Add("Event Date", typeof(string));
                if (item.Rows.Count == 0)
                {
                    item.Columns.Remove("Eventstartdate");
                    item.Columns.Remove("Eventenddate");
                }
            }
            foreach (DataRow row in item.Rows)
            {
                if (item.Columns.Contains("ActivityNotes") && row["ActivityNotes"] != null)
                {
                    row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                    row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                }
                if (!row.Table.Columns.Contains("Eventstartdate") || !row.Table.Columns.Contains("Eventenddate"))
                {
                    continue;
                }
                string str = this.comm.Eprint_return_Date_Before_View(row["Eventstartdate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                string str1 = this.comm.Eprint_return_Date_Before_View(row["Eventenddate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                if (str != "" && str1 != "")
                {
                    row["Event Date"] = string.Concat(str, "-", str1);
                }
                item.Columns.Remove("Eventstartdate");
                item.Columns.Remove("Eventenddate");
            }
            if (item.Columns.Contains("Orderid"))
            {
                item.Columns.Remove("Orderid");
            }
            if (item.Columns.Contains("Estimateid"))
            {
                item.Columns.Remove("Estimateid");
            }
            if (item.Columns.Contains("clientID"))
            {
                item.Columns.Remove("clientID");
            }
            if (item.Columns.Contains("Invoiceid"))
            {
                item.Columns.Remove("Invoiceid");
            }
            if (item.Columns.Contains("jobid"))
            {
                item.Columns.Remove("jobid");
            }
            if (item.Columns.Contains("IsStockItem"))
            {
                item.Columns.Remove("IsStockItem");
            }
            if (item.Columns.Contains("ActivityRecords"))
            {
                item.Columns.Remove("ActivityRecords");
            }
            if (item.Columns.Contains("TempProduct"))
            {
                item.Columns.Remove("TempProduct");
            }
            if (item.Columns.Contains("TempAvailableQty"))
            {
                item.Columns.Remove("TempAvailableQty");
            }
            if (item.Columns.Contains("pricecatalogueid"))
            {
                item.Columns.Remove("pricecatalogueid");
            }
            if (item.Columns.Contains("RowNumber"))
            {
                item.Columns.Remove("RowNumber");
            }
            foreach (DataRow dataRow in item.Rows)
            {
                if (item.Columns.Contains("CreatedDate") && dataRow["createddate"].ToString() != "")
                {
                    dataRow["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("OrderDate") && dataRow["OrderDate"].ToString() != "")
                {
                    dataRow["OrderDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DueDate") && dataRow["DueDate"].ToString() != "")
                {
                    dataRow["DueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("CompletionDate") && dataRow["CompletionDate"].ToString() != "")
                {
                    dataRow["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DeliveryDate") && dataRow["DeliveryDate"].ToString() != "")
                {
                    dataRow["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("actualdeliverydate") && dataRow["actualdeliverydate"].ToString() != "")
                {
                    dataRow["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(dataRow["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("EstimatedDeliveryDate") && dataRow["EstimatedDeliveryDate"].ToString() != "")
                {
                    dataRow["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ActualDeliveryDate") && dataRow["ActualDeliveryDate"].ToString() != "")
                {
                    dataRow["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ContactAddress") && dataRow["ContactAddress"].ToString() != "")
                {
                    dataRow["ContactAddress"] = this.objBc.SpecialDecode(dataRow["ContactAddress"].ToString());
                }
                if (item.Columns.Contains("DeliveryAddress") && dataRow["DeliveryAddress"].ToString() != "")
                {
                    dataRow["DeliveryAddress"] = this.objBc.SpecialDecode(dataRow["DeliveryAddress"].ToString());
                }
                if (item.Columns.Contains("InvoiceAddress") && dataRow["InvoiceAddress"].ToString() != "")
                {
                    dataRow["InvoiceAddress"] = this.objBc.SpecialDecode(dataRow["InvoiceAddress"].ToString());
                }
                if (item.Columns.Contains("ItemTitle") && dataRow["ItemTitle"].ToString() != "")
                {
                    dataRow["ItemTitle"] = this.objBc.SpecialDecode(dataRow["ItemTitle"].ToString());
                }
                if (item.Columns.Contains("Description") && dataRow["Description"].ToString() != "")
                {
                    dataRow["Description"] = this.objBc.SpecialDecode(dataRow["Description"].ToString());
                }
                if (item.Columns.Contains("ActivityNotes") && dataRow["ActivityNotes"].ToString() != "")
                {
                    dataRow["ActivityNotes"] = this.objBc.SpecialDecode(dataRow["ActivityNotes"].ToString());
                }
                if (item.Columns.Contains("ContactName") && dataRow["ContactName"].ToString() != "")
                {
                    dataRow["ContactName"] = this.objBc.SpecialDecode(dataRow["ContactName"].ToString());
                }
                if (item.Columns.Contains("OrderTitle") && dataRow["OrderTitle"].ToString() != "")
                {
                    dataRow["OrderTitle"] = this.objBc.SpecialDecode(dataRow["OrderTitle"].ToString());
                }
                if (item.Columns.Contains("Company") && dataRow["Company"].ToString() != "")
                {
                    dataRow["Company"] = this.objBc.SpecialDecode(dataRow["Company"].ToString());
                }
                if (item.Columns.Contains("totaltaxprice") && dataRow["totaltaxprice"].ToString() != "")
                {
                    dataRow["totaltaxprice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["totaltaxprice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("TotalTaxPrice") && dataRow["TotalTaxPrice"].ToString() != "")
                {
                    dataRow["TotalTaxPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalTaxPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("OrderValue") && dataRow["OrderValue"].ToString() != "")
                {
                    dataRow["OrderValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["OrderValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("SubTotal") && dataRow["SubTotal"].ToString() != "")
                {
                    dataRow["SubTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["SubTotal"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPrice") && dataRow["GrossProfitPrice"].ToString() != "")
                {
                    dataRow["GrossProfitPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPercentage") && dataRow["GrossProfitPercentage"].ToString() != "")
                {
                    dataRow["GrossProfitPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostExMarkup") && dataRow["CostExMarkup"].ToString() != "")
                {
                    dataRow["CostExMarkup"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostExMarkup"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWidth") && dataRow["ProductWidth"].ToString() != "")
                {
                    dataRow["ProductWidth"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWidth"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Width") && dataRow["Width"].ToString() != "")
                {
                    dataRow["Width"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Width"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductHeight") && dataRow["ProductHeight"].ToString() != "")
                {
                    dataRow["ProductHeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductHeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Height") && dataRow["Height"].ToString() != "")
                {
                    dataRow["Height"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Height"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductLength") && dataRow["ProductLength"].ToString() != "")
                {
                    dataRow["ProductLength"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductLength"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Length") && dataRow["Length"].ToString() != "")
                {
                    dataRow["Length"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Length"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWeight") && dataRow["ProductWeight"].ToString() != "")
                {
                    dataRow["ProductWeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Weight") && dataRow["Weight"].ToString() != "")
                {
                    dataRow["Weight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Weight"].ToString()), 2, "", false, false, true);
                }
                item.Columns.Contains("ProductDimension");
                if (item.Columns.Contains("JobValue") && dataRow["JobValue"].ToString() != "")
                {
                    dataRow["JobValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["JobValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostPrice") && dataRow["CostPrice"].ToString() != "")
                {
                    dataRow["CostPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionAmount") && dataRow["CommissionAmount"].ToString() != "")
                {
                    dataRow["CommissionAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionAmount"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionPercentage") && dataRow["CommissionPercentage"].ToString() != "")
                {
                    dataRow["CommissionPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceValue") && dataRow["InvoiceValue"].ToString() != "")
                {
                    dataRow["InvoiceValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceAmountPaid") && dataRow["InvoiceAmountPaid"].ToString() != "")
                {
                    dataRow["InvoiceAmountPaid"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountPaid"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("InvoiceAmountOutstanding") || !(dataRow["InvoiceAmountOutstanding"].ToString() != ""))
                {
                    continue;
                }
                dataRow["InvoiceAmountOutstanding"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountOutstanding"].ToString()), 2, "", false, false, true);
            }
            if (this.Reports_type.ToLower() == "job")
            {
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("EstimateItemID"))
                {
                    item.Columns.Remove("EstimateItemID");
                }
                DataColumn dataColumn1 = new DataColumn();
                item.Columns.Add("EventDate", typeof(string));
                foreach (DataRow row1 in item.Rows)
                {
                    if (!row1.Table.Columns.Contains("Eventstartdate") || !row1.Table.Columns.Contains("Eventenddate"))
                    {
                        item.Columns.Remove("EventDate");
                    }
                    else
                    {
                        string str2 = this.comm.Eprint_return_Date_Before_View(row1["Eventstartdate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                        string str3 = this.comm.Eprint_return_Date_Before_View(row1["Eventenddate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                        if (str2 != "" && str3 != "")
                        {
                            row1["EventDate"] = string.Concat(str2, "-", str3);
                        }
                        item.Columns.Remove("Eventstartdate");
                        item.Columns.Remove("Eventenddate");
                    }
                    if (row1.Table.Columns.Contains("CustomerName"))
                    {
                        row1["CustomerName"] = this.objBc.SpecialDecode(row1["CustomerName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactName"))
                    {
                        row1["ContactName"] = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Department"))
                    {
                        row1["Department"] = this.objBc.SpecialDecode(row1["Department"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeremail"))
                    {
                        row1["customeremail"] = this.objBc.SpecialDecode(row1["customeremail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactemail"))
                    {
                        row1["contactemail"] = this.objBc.SpecialDecode(row1["contactemail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle1"))
                    {
                        row1["ContactJobTitle1"] = this.objBc.SpecialDecode(row1["ContactJobTitle1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle2"))
                    {
                        row1["ContactJobTitle2"] = this.objBc.SpecialDecode(row1["ContactJobTitle2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("CustomerType"))
                    {
                        row1["CustomerType"] = this.objBc.SpecialDecode(row1["CustomerType"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactphone"))
                    {
                        row1["contactphone"] = this.objBc.SpecialDecode(row1["contactphone"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress1"))
                    {
                        row1["contactaddress1"] = this.objBc.SpecialDecode(row1["contactaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress2"))
                    {
                        row1["contactaddress2"] = this.objBc.SpecialDecode(row1["contactaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress3"))
                    {
                        row1["contactaddress3"] = this.objBc.SpecialDecode(row1["contactaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress4"))
                    {
                        row1["contactaddress4"] = this.objBc.SpecialDecode(row1["contactaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress5"))
                    {
                        row1["contactaddress5"] = this.objBc.SpecialDecode(row1["contactaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress6"))
                    {
                        row1["contactaddress6"] = this.objBc.SpecialDecode(row1["contactaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress"))
                    {
                        row1["contactaddress"] = this.objBc.SpecialDecode(row1["contactaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress1"))
                    {
                        row1["deliveryaddress1"] = this.objBc.SpecialDecode(row1["deliveryaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress2"))
                    {
                        row1["deliveryaddress2"] = this.objBc.SpecialDecode(row1["deliveryaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress3"))
                    {
                        row1["deliveryaddress3"] = this.objBc.SpecialDecode(row1["deliveryaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress4"))
                    {
                        row1["deliveryaddress4"] = this.objBc.SpecialDecode(row1["deliveryaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress5"))
                    {
                        row1["deliveryaddress5"] = this.objBc.SpecialDecode(row1["deliveryaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress6"))
                    {
                        row1["deliveryaddress6"] = this.objBc.SpecialDecode(row1["deliveryaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress"))
                    {
                        row1["deliveryaddress"] = this.objBc.SpecialDecode(row1["deliveryaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress1"))
                    {
                        row1["invoiceaddress1"] = this.objBc.SpecialDecode(row1["invoiceaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress2"))
                    {
                        row1["invoiceaddress2"] = this.objBc.SpecialDecode(row1["invoiceaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress3"))
                    {
                        row1["invoiceaddress3"] = this.objBc.SpecialDecode(row1["invoiceaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress4"))
                    {
                        row1["invoiceaddress4"] = this.objBc.SpecialDecode(row1["invoiceaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress5"))
                    {
                        row1["invoiceaddress5"] = this.objBc.SpecialDecode(row1["invoiceaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress6"))
                    {
                        row1["invoiceaddress6"] = this.objBc.SpecialDecode(row1["invoiceaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress"))
                    {
                        row1["invoiceaddress"] = this.objBc.SpecialDecode(row1["invoiceaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Estimator"))
                    {
                        row1["Estimator"] = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                    }
                    if (row1.Table.Columns.Contains("salesperson"))
                    {
                        row1["salesperson"] = this.objBc.SpecialDecode(row1["salesperson"].ToString());
                    }
                    if (row1.Table.Columns.Contains("jobtitle"))
                    {
                        row1["jobtitle"] = this.objBc.SpecialDecode(row1["jobtitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Status"))
                    {
                        row1["Status"] = this.objBc.SpecialDecode(row1["Status"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ItemTitle"))
                    {
                        row1["ItemTitle"] = this.objBc.SpecialDecode(row1["ItemTitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Description"))
                    {
                        row1["DEscription"] = this.objBc.SpecialDecode(row1["DEscription"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Artwork"))
                    {
                        row1["Artwork"] = this.objBc.SpecialDecode(row1["Artwork"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Colour"))
                    {
                        row1["Colour"] = this.objBc.SpecialDecode(row1["Colour"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Size"))
                    {
                        row1["Size"] = this.objBc.SpecialDecode(row1["Size"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Material"))
                    {
                        row1["Material"] = this.objBc.SpecialDecode(row1["Material"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Delivery"))
                    {
                        row1["Delivery"] = this.objBc.SpecialDecode(row1["Delivery"].ToString());
                    }
                    if (row1.Table.Columns.Contains("finishing"))
                    {
                        row1["finishing"] = this.objBc.SpecialDecode(row1["finishing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("notes"))
                    {
                        row1["notes"] = this.objBc.SpecialDecode(row1["notes"].ToString());
                    }
                    if (row1.Table.Columns.Contains("instructions"))
                    {
                        row1["instructions"] = this.objBc.SpecialDecode(row1["instructions"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Proofs"))
                    {
                        row1["Proofs"] = this.objBc.SpecialDecode(row1["Proofs"].ToString());
                    }
                    if (row1.Table.Columns.Contains("packing"))
                    {
                        row1["packing"] = this.objBc.SpecialDecode(row1["packing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ordernumber"))
                    {
                        row1["ordernumber"] = this.objBc.SpecialDecode(row1["ordernumber"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Name"))
                    {
                        row1["Name"] = this.objBc.SpecialDecode(row1["Name"].ToString());
                    }
                    if (row1.Table.Columns.Contains("suppliername"))
                    {
                        row1["suppliername"] = this.objBc.SpecialDecode(row1["suppliername"].ToString());
                    }
                    if (row1.Table.Columns.Contains("producttitle"))
                    {
                        row1["producttitle"] = this.objBc.SpecialDecode(row1["producttitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcode"))
                    {
                        row1["productcode"] = this.objBc.SpecialDecode(row1["productcode"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcatagory"))
                    {
                        row1["productcatagory"] = this.objBc.SpecialDecode(row1["productcatagory"].ToString());
                    }
                    if (row1.Table.Columns.Contains("storename"))
                    {
                        row1["storename"] = this.objBc.SpecialDecode(row1["storename"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress1"))
                    {
                        row1["customeraddress1"] = this.objBc.SpecialDecode(row1["customeraddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress2"))
                    {
                        row1["customeraddress2"] = this.objBc.SpecialDecode(row1["customeraddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress3"))
                    {
                        row1["customeraddress3"] = this.objBc.SpecialDecode(row1["customeraddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress4"))
                    {
                        row1["customeraddress4"] = this.objBc.SpecialDecode(row1["customeraddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress5"))
                    {
                        row1["customeraddress5"] = this.objBc.SpecialDecode(row1["customeraddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress6"))
                    {
                        row1["customeraddress6"] = this.objBc.SpecialDecode(row1["customeraddress6"].ToString());
                    }
                    if (!row1.Table.Columns.Contains("customeraddress"))
                    {
                        continue;
                    }
                    row1["customeraddress"] = this.objBc.SpecialDecode(row1["customeraddress"].ToString());
                }
            }
            foreach (DataRow dataRow1 in item.Rows)
            {
                if (dataRow1.Table.Columns.Contains("Company"))
                {
                    dataRow1["Company"] = this.objBc.SpecialDecode(dataRow1["Company"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactName"))
                {
                    dataRow1["ContactName"] = this.objBc.SpecialDecode(dataRow1["ContactName"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Department"))
                {
                    dataRow1["Department"] = this.objBc.SpecialDecode(dataRow1["Department"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeremail"))
                {
                    dataRow1["customeremail"] = this.objBc.SpecialDecode(dataRow1["customeremail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactemail"))
                {
                    dataRow1["contactemail"] = this.objBc.SpecialDecode(dataRow1["contactemail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle1"))
                {
                    dataRow1["ContactJobTitle1"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle2"))
                {
                    dataRow1["ContactJobTitle2"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("CustomerType"))
                {
                    dataRow1["CustomerType"] = this.objBc.SpecialDecode(dataRow1["CustomerType"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactphone"))
                {
                    dataRow1["contactphone"] = this.objBc.SpecialDecode(dataRow1["contactphone"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress1"))
                {
                    dataRow1["contactaddress1"] = this.objBc.SpecialDecode(dataRow1["contactaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress2"))
                {
                    dataRow1["contactaddress2"] = this.objBc.SpecialDecode(dataRow1["contactaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress3"))
                {
                    dataRow1["contactaddress3"] = this.objBc.SpecialDecode(dataRow1["contactaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress4"))
                {
                    dataRow1["contactaddress4"] = this.objBc.SpecialDecode(dataRow1["contactaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress5"))
                {
                    dataRow1["contactaddress5"] = this.objBc.SpecialDecode(dataRow1["contactaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress6"))
                {
                    dataRow1["contactaddress6"] = this.objBc.SpecialDecode(dataRow1["contactaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress"))
                {
                    dataRow1["contactaddress"] = this.objBc.SpecialDecode(dataRow1["contactaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress1"))
                {
                    dataRow1["deliveryaddress1"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress2"))
                {
                    dataRow1["deliveryaddress2"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress3"))
                {
                    dataRow1["deliveryaddress3"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress4"))
                {
                    dataRow1["deliveryaddress4"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress5"))
                {
                    dataRow1["deliveryaddress5"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress6"))
                {
                    dataRow1["deliveryaddress6"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress"))
                {
                    dataRow1["deliveryaddress"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress1"))
                {
                    dataRow1["invoiceaddress1"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress2"))
                {
                    dataRow1["invoiceaddress2"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress3"))
                {
                    dataRow1["invoiceaddress3"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress4"))
                {
                    dataRow1["invoiceaddress4"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress5"))
                {
                    dataRow1["invoiceaddress5"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress6"))
                {
                    dataRow1["invoiceaddress6"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress"))
                {
                    dataRow1["invoiceaddress"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("salesperson"))
                {
                    dataRow1["salesperson"] = this.objBc.SpecialDecode(dataRow1["salesperson"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("InvoiceTitle"))
                {
                    dataRow1["InvoiceTitle"] = this.objBc.SpecialDecode(dataRow1["InvoiceTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Status"))
                {
                    dataRow1["Status"] = this.objBc.SpecialDecode(dataRow1["Status"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ItemTitle"))
                {
                    dataRow1["ItemTitle"] = this.objBc.SpecialDecode(dataRow1["ItemTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Description"))
                {
                    dataRow1["DEscription"] = this.objBc.SpecialDecode(dataRow1["DEscription"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Artwork"))
                {
                    dataRow1["Artwork"] = this.objBc.SpecialDecode(dataRow1["Artwork"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Colour"))
                {
                    dataRow1["Colour"] = this.objBc.SpecialDecode(dataRow1["Colour"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Size"))
                {
                    dataRow1["Size"] = this.objBc.SpecialDecode(dataRow1["Size"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Material"))
                {
                    dataRow1["Material"] = this.objBc.SpecialDecode(dataRow1["Material"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Delivery"))
                {
                    dataRow1["Delivery"] = this.objBc.SpecialDecode(dataRow1["Delivery"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("finishing"))
                {
                    dataRow1["finishing"] = this.objBc.SpecialDecode(dataRow1["finishing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("notes"))
                {
                    dataRow1["notes"] = this.objBc.SpecialDecode(dataRow1["notes"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("instructions"))
                {
                    dataRow1["instructions"] = this.objBc.SpecialDecode(dataRow1["instructions"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Proofs"))
                {
                    dataRow1["Proofs"] = this.objBc.SpecialDecode(dataRow1["Proofs"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("packing"))
                {
                    dataRow1["packing"] = this.objBc.SpecialDecode(dataRow1["packing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ordernumber"))
                {
                    dataRow1["ordernumber"] = this.objBc.SpecialDecode(dataRow1["ordernumber"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Name"))
                {
                    dataRow1["Name"] = this.objBc.SpecialDecode(dataRow1["Name"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("suppliername"))
                {
                    dataRow1["suppliername"] = this.objBc.SpecialDecode(dataRow1["suppliername"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("producttitle"))
                {
                    dataRow1["producttitle"] = this.objBc.SpecialDecode(dataRow1["producttitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("productcode"))
                {
                    dataRow1["productcode"] = this.objBc.SpecialDecode(dataRow1["productcode"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("storename"))
                {
                    dataRow1["storename"] = this.objBc.SpecialDecode(dataRow1["storename"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress1"))
                {
                    dataRow1["customeraddress1"] = this.objBc.SpecialDecode(dataRow1["customeraddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress2"))
                {
                    dataRow1["customeraddress2"] = this.objBc.SpecialDecode(dataRow1["customeraddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress3"))
                {
                    dataRow1["customeraddress3"] = this.objBc.SpecialDecode(dataRow1["customeraddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress4"))
                {
                    dataRow1["customeraddress4"] = this.objBc.SpecialDecode(dataRow1["customeraddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress5"))
                {
                    dataRow1["customeraddress5"] = this.objBc.SpecialDecode(dataRow1["customeraddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress6"))
                {
                    dataRow1["customeraddress6"] = this.objBc.SpecialDecode(dataRow1["customeraddress6"].ToString());
                }
                if (!dataRow1.Table.Columns.Contains("customeraddress"))
                {
                    continue;
                }
                dataRow1["customeraddress"] = this.objBc.SpecialDecode(dataRow1["customeraddress"].ToString());
            }
            foreach (DataRow row2 in dataSet.Tables[0].Rows)
            {
                if (row2.Table.Columns.Contains("ItemTitle"))
                {
                    row2["ItemTitle"] = this.objBc.SpecialDecode(row2["ItemTitle"].ToString());
                }
                if (row2.Table.Columns.Contains("CategoryName"))
                {
                    row2["CategoryName"] = this.objBc.SpecialDecode(row2["CategoryName"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemCode"))
                {
                    row2["ItemCode"] = this.objBc.SpecialDecode(row2["ItemCode"].ToString());
                }
                if (row2.Table.Columns.Contains("CustomerCode"))
                {
                    row2["CustomerCode"] = this.objBc.SpecialDecode(row2["CustomerCode"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemDescription"))
                {
                    row2["ItemDescription"] = this.objBc.SpecialDecode(row2["ItemDescription"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemArtWork"))
                {
                    row2["ItemArtWork"] = this.objBc.SpecialDecode(row2["ItemArtWork"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemColour"))
                {
                    row2["ItemColour"] = this.objBc.SpecialDecode(row2["ItemColour"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemSize"))
                {
                    row2["ItemSize"] = this.objBc.SpecialDecode(row2["ItemSize"].ToString());
                }
                if (row2.Table.Columns.Contains("Material"))
                {
                    row2["Material"] = this.objBc.SpecialDecode(row2["Material"].ToString());
                }
                if (row2.Table.Columns.Contains("Delivery"))
                {
                    row2["Delivery"] = this.objBc.SpecialDecode(row2["Delivery"].ToString());
                }
                if (row2.Table.Columns.Contains("Finishing"))
                {
                    row2["Finishing"] = this.objBc.SpecialDecode(row2["Finishing"].ToString());
                }
                if (row2.Table.Columns.Contains("Proofs"))
                {
                    row2["Proofs"] = this.objBc.SpecialDecode(row2["Proofs"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemPacking"))
                {
                    row2["ItemPacking"] = this.objBc.SpecialDecode(row2["ItemPacking"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemNotes"))
                {
                    row2["ItemNotes"] = this.objBc.SpecialDecode(row2["ItemNotes"].ToString());
                }
                if (row2.Table.Columns.Contains("Terms/Instructions"))
                {
                    row2["Terms/Instructions"] = this.objBc.SpecialDecode(row2["Terms/Instructions"].ToString());
                }
                if (item.Columns.Contains("price") && row2["price"].ToString() != "")
                {
                    row2["price"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["price"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpPercentage") && row2["MarkUpPercentage"].ToString() != "")
                {
                    row2["MarkUpPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpValue") && row2["MarkUpValue"].ToString() != "")
                {
                    row2["MarkUpValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpValue"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("SellingPrice") || !(row2["SellingPrice"].ToString() != ""))
                {
                    continue;
                }
                row2["SellingPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["SellingPrice"].ToString()), 2, "", false, false, true);
            }
        }

        protected void grid_reports_order_itemdatabound(object sender, GridItemEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            TextBox textBox = (TextBox)e.Item.FindControl("txtfrmdate_order");
            if (textBox != null)
            {
                textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.hdnOrderFromdate_cust.Value == "" || this.hdnOrderFromdate_cust.Value == "0")
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                else
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderFromdate_cust.Value, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
            }
            TextBox textBox1 = (TextBox)e.Item.FindControl("txttodate_order");
            if (textBox1 != null)
            {
                textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (this.hdnOrderTodate_cust.Value == "" || this.hdnOrderTodate_cust.Value == "0")
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                else
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderTodate_cust.Value, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    if (e.Item.Cells[i].Text.ToLower() == "orderno")
                    {
                        e.Item.Cells[i].Text = "Order No";
                        this.cellvalue_orderno = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "contactname")
                    {
                        e.Item.Cells[i].Text = "Contact Name";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "company")
                    {
                        this.cellvalue_Companyname = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customeremail")
                    {
                        e.Item.Cells[i].Text = "Customer Email";
                    }
                    if (e.Item.Cells[i].Text == "ContactEmail")
                    {
                        e.Item.Cells[i].Text = "Contact Email";
                    }
                    if (e.Item.Cells[i].Text == "ContactPhone")
                    {
                        e.Item.Cells[i].Text = "Contact Phone";
                    }
                    if (e.Item.Cells[i].Text == "ContactAddress")
                    {
                        e.Item.Cells[i].Text = "Contact Address";
                    }
                    if (e.Item.Cells[i].Text == "DeliveryAddress")
                    {
                        e.Item.Cells[i].Text = "Delivery Address";
                    }
                    if (e.Item.Cells[i].Text == "InvoiceAddress")
                    {
                        e.Item.Cells[i].Text = "Invoice Address";
                    }
                    if (e.Item.Cells[i].Text == "SalesPerson")
                    {
                        e.Item.Cells[i].Text = "Order Salesperson";
                    }
                    if (e.Item.Cells[i].Text == "IsApproved")
                    {
                        this.flagcenter = true;
                        this.cellvalue_approvalstatus = i;
                        e.Item.Cells[i].Text = "Approval Status";
                    }
                    if (e.Item.Cells[i].Text == "ActivityNotes")
                    {
                        e.Item.Cells[i].Text = "Activity Notes";
                        this.cellvalue_activitynotes = i;
                    }
                    if (e.Item.Cells[i].Text == "OrderTitle")
                    {
                        e.Item.Cells[i].Text = "Order Title";
                    }
                    if (e.Item.Cells[i].Text == "CreatedDate")
                    {
                        e.Item.Cells[i].Text = "Created On";
                    }
                    if (e.Item.Cells[i].Text == "OrderDate")
                    {
                        e.Item.Cells[i].Text = "Order Date";
                    }
                    if (e.Item.Cells[i].Text == "OrderValue")
                    {
                        this.flacosts = true;
                        this.cellvalue_OrderValue = i;
                        e.Item.Cells[i].Text = string.Concat("Order Value (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ItemTitle")
                    {
                        e.Item.Cells[i].Text = "Item Title";
                        this.cellvalue_itemtitle = i;
                    }
                    if (e.Item.Cells[i].Text == "ItemStatusTitle")
                    {
                        e.Item.Cells[i].Text = "Item Status";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "description")
                    {
                        e.Item.Cells[i].Text = "Description";
                        this.cellvalue_order_description = i;
                    }
                    if (e.Item.Cells[i].Text == "OrderNumber")
                    {
                        e.Item.Cells[i].Text = "Customer Order No";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "name")
                    {
                        e.Item.Cells[i].Text = "Referred By";
                    }
                    if (e.Item.Cells[i].Text == "SubTotal")
                    {
                        this.flacosts = true;
                        this.cellvalue_subtotal = i;
                        e.Item.Cells[i].Text = string.Concat("Sub Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "GrossProfitPrice")
                    {
                        this.flacosts = true;
                        this.cellvalue_grossprofitprice = i;
                        e.Item.Cells[i].Text = string.Concat("Gross Profit (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "GrossProfitPercentage")
                    {
                        this.flacosts = true;
                        this.cellvalue_grossprofitpercentage = i;
                        e.Item.Cells[i].Text = "Gross Profit (%)";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "CostExMarkup")
                    {
                        this.flacosts = true;
                        this.cellvalue_costexmarkup = i;
                        e.Item.Cells[i].Text = string.Concat("Cost Ex. Markup (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AccountingCode")
                    {
                        e.Item.Cells[i].Text = "Accounting Code";
                    }
                    if (e.Item.Cells[i].Text == "CostCentre")
                    {
                        e.Item.Cells[i].Text = "Cost Centre";
                    }
                    if (e.Item.Cells[i].Text == "ActivityNotes")
                    {
                        e.Item.Cells[i].Text = "Activity Notes";
                    }
                    if (e.Item.Cells[i].Text == "ItemQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_itemqty = i;
                        e.Item.Cells[i].Text = "Item Quantity";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "StoreName")
                    {
                        e.Item.Cells[i].Text = "Store Name";
                    }
                    if (e.Item.Cells[i].Text == "ProductWidth")
                    {
                        this.flacosts = true;
                        this.cellvalue_productwidth = i;
                        e.Item.Cells[i].Text = string.Concat("Product Width (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductHeight")
                    {
                        this.flacosts = true;
                        this.cellvalue_productheight = i;
                        e.Item.Cells[i].Text = string.Concat("Product Height (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductLength")
                    {
                        this.flacosts = true;
                        this.cellvalue_productlength = i;
                        e.Item.Cells[i].Text = string.Concat("Product Length (", this.Paper_Stock_Lenght, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductWeight")
                    {
                        this.flacosts = true;
                        this.cellvalue_productweight = i;
                        e.Item.Cells[i].Text = string.Concat("Product Weight (", this.Weight_gsm, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ProductDimension")
                    {
                        this.flacosts = true;
                        this.cellvalue_productdimension = i;
                        e.Item.Cells[i].Text = string.Concat("Product Dimension (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "EventName")
                    {
                        e.Item.Cells[i].Text = "Event Name";
                    }
                    if (e.Item.Cells[i].Text == "EventCodeNumber")
                    {
                        e.Item.Cells[i].Text = "Event Code";
                    }
                    if (e.Item.Cells[i].Text == "CampaignSignNumber")
                    {
                        e.Item.Cells[i].Text = "Sign No.";
                    }
                    if (e.Item.Cells[i].Text == "ItemStatus")
                    {
                        e.Item.Cells[i].Text = "Item Status";
                    }
                    if (e.Item.Cells[i].Text == "EventVenue")
                    {
                        e.Item.Cells[i].Text = "Event Venue";
                    }
                    if (e.Item.Cells[i].Text == "QTYDescription1")
                    {
                        this.flacosts = true;
                        this.cellvalue_qty = i;
                        e.Item.Cells[i].Text = "Quantity";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ContactJobTitle1")
                    {
                        e.Item.Cells[i].Text = "Contact Job Title 1";
                    }
                    if (e.Item.Cells[i].Text == "ContactJobTitle2")
                    {
                        e.Item.Cells[i].Text = "Contact Job Title 2";
                    }
                    if (e.Item.Cells[i].Text == "CustomerSalesperson")
                    {
                        e.Item.Cells[i].Text = "Customer Salesperson";
                    }
                    if (e.Item.Cells[i].Text == "CustomerCode")
                    {
                        e.Item.Cells[i].Text = "Customer Code";
                    }
                    if (e.Item.Cells[i].Text == "ProductCode")
                    {
                        e.Item.Cells[i].Text = "Product Code";
                    }
                    if (e.Item.Cells[i].Text == "CommentsField")
                    {
                        e.Item.Cells[i].Text = "Comments Field";
                    }
                    if (e.Item.Cells[i].Text == "DueDate")
                    {
                        this.flagdates = true;
                        e.Item.Cells[i].Text = "Due Date";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "jobname")
                    {
                        e.Item.Cells[i].Text = "Job Name";
                    }
                    if (e.Item.Cells[i].Text == "OrderedFor")
                    {
                        e.Item.Cells[i].Text = "Ordered For";
                        this.cellvalue_ordererfor = i;
                    }
                    if (e.Item.Cells[i].Text == "Material")
                    {
                        e.Item.Cells[i].Text = "Paper/Stock";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "totaltaxprice")
                    {
                        this.flacosts = true;
                        this.cellvalue_totalprice = i;
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                        e.Item.Cells[i].Text = string.Concat("Total Tax Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (e.Item.Cells[i].Text == "CustomField1")
                    {
                        e.Item.Cells[i].Text = this.CustomField1;
                    }
                    if (e.Item.Cells[i].Text == "CustomField2")
                    {
                        e.Item.Cells[i].Text = this.CustomField2;
                    }
                    if (e.Item.Cells[i].Text == "CustomField3")
                    {
                        e.Item.Cells[i].Text = this.CustomField3;
                    }
                    if (e.Item.Cells[i].Text == "CustomField4")
                    {
                        e.Item.Cells[i].Text = this.CustomField4;
                    }
                    if (e.Item.Cells[i].Text == "CustomField5")
                    {
                        e.Item.Cells[i].Text = this.CustomField5;
                    }
                    if (e.Item.Cells[i].Text == "CustomField6")
                    {
                        e.Item.Cells[i].Text = this.CustomField6;
                    }
                }
            }
            if (e.Item is GridDataItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    if (this.flacosts)
                    {
                        e.Item.Cells[this.cellvalue_subtotal].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_OrderValue].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_grossprofitprice].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_grossprofitpercentage].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_costexmarkup].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_qty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_itemqty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productwidth].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productheight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productlength].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productweight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productdimension].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_totalprice].Attributes.Add("align", "right");
                    }
                    if (this.flagcenter)
                    {
                        e.Item.Cells[this.cellvalue_approvalstatus].Attributes.Add("align", "center");
                    }
                    e.Item.Cells[this.cellvalue_orderno].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_activitynotes].Attributes.Add("style", "white-space:nowrap;");
                    e.Item.Cells[this.cellvalue_Companyname].Attributes.Add("style", "min-width:175px;");
                    e.Item.Cells[this.cellvalue_itemtitle].Attributes.Add("style", "min-width:175px;");
                    e.Item.Cells[this.cellvalue_ordererfor].Attributes.Add("style", "min-width:100px;");
                    if (e.Item.Cells[this.cellvalue_order_description].Text.Length <= 25)
                    {
                        e.Item.Cells[this.cellvalue_order_description].Attributes.Add("style", "min-width:150px;");
                    }
                    else
                    {
                        e.Item.Cells[this.cellvalue_order_description].Attributes.Add("style", "min-width:200px;");
                    }
                }
            }
        }

        protected void grid_reports_order_needdatasource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            this.div_reportgrid.Attributes.Add("style", "display:block;");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            DateTime dateTime = Convert.ToDateTime(this.hdnOrderFromdate_cust.Value);
            DateTime dateTime1 = Convert.ToDateTime(this.hdnOrderTodate_cust.Value);
            this.reportid = Convert.ToInt64(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime, dateTime1, 0, 0);
            DataTable item = dataSet.Tables[0];
            this.grid_reports_byreportid_order.DataSource = item;
            if (item.Columns.Contains("ActivityNotes"))
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row["ActivityNotes"] == null)
                    {
                        continue;
                    }
                    row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                    row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                }
            }
            if (item.Columns.Contains("Orderid"))
            {
                item.Columns.Remove("Orderid");
            }
            if (item.Columns.Contains("Estimateid"))
            {
                item.Columns.Remove("Estimateid");
            }
            if (item.Columns.Contains("clientID"))
            {
                item.Columns.Remove("clientID");
            }
            if (item.Columns.Contains("Invoiceid"))
            {
                item.Columns.Remove("Invoiceid");
            }
            if (item.Columns.Contains("jobid"))
            {
                item.Columns.Remove("jobid");
            }
            if (item.Columns.Contains("IsStockItem"))
            {
                item.Columns.Remove("IsStockItem");
            }
            if (item.Columns.Contains("ActivityRecords"))
            {
                item.Columns.Remove("ActivityRecords");
            }
            if (item.Columns.Contains("TempProduct"))
            {
                item.Columns.Remove("TempProduct");
            }
            if (item.Columns.Contains("TempAvailableQty"))
            {
                item.Columns.Remove("TempAvailableQty");
            }
            if (item.Columns.Contains("pricecatalogueid"))
            {
                item.Columns.Remove("pricecatalogueid");
            }
            if (item.Columns.Contains("RowNumber"))
            {
                item.Columns.Remove("RowNumber");
            }
            foreach (DataRow dataRow in item.Rows)
            {
                if (item.Columns.Contains("CreatedDate") && dataRow["createddate"].ToString() != "")
                {
                    dataRow["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("OrderDate") && dataRow["OrderDate"].ToString() != "")
                {
                    dataRow["OrderDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DueDate") && dataRow["DueDate"].ToString() != "")
                {
                    dataRow["DueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("CompletionDate") && dataRow["CompletionDate"].ToString() != "")
                {
                    dataRow["CompletionDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CompletionDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DeliveryDate") && dataRow["DeliveryDate"].ToString() != "")
                {
                    dataRow["DeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("actualdeliverydate") && dataRow["actualdeliverydate"].ToString() != "")
                {
                    dataRow["actualdeliverydate"] = this.comm.Eprint_return_Date_Before_View(dataRow["actualdeliverydate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("EstimatedDeliveryDate") && dataRow["EstimatedDeliveryDate"].ToString() != "")
                {
                    dataRow["EstimatedDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["EstimatedDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ActualDeliveryDate") && dataRow["ActualDeliveryDate"].ToString() != "")
                {
                    dataRow["ActualDeliveryDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["ActualDeliveryDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ContactAddress") && dataRow["ContactAddress"].ToString() != "")
                {
                    dataRow["ContactAddress"] = this.objBc.SpecialDecode(dataRow["ContactAddress"].ToString());
                }
                if (item.Columns.Contains("DeliveryAddress") && dataRow["DeliveryAddress"].ToString() != "")
                {
                    dataRow["DeliveryAddress"] = this.objBc.SpecialDecode(dataRow["DeliveryAddress"].ToString());
                }
                if (item.Columns.Contains("InvoiceAddress") && dataRow["InvoiceAddress"].ToString() != "")
                {
                    dataRow["InvoiceAddress"] = this.objBc.SpecialDecode(dataRow["InvoiceAddress"].ToString());
                }
                if (item.Columns.Contains("ItemTitle") && dataRow["ItemTitle"].ToString() != "")
                {
                    dataRow["ItemTitle"] = this.objBc.SpecialDecode(dataRow["ItemTitle"].ToString());
                }
                if (item.Columns.Contains("Description") && dataRow["Description"].ToString() != "")
                {
                    dataRow["Description"] = this.objBc.SpecialDecode(dataRow["Description"].ToString());
                }
                if (item.Columns.Contains("ActivityNotes") && dataRow["ActivityNotes"].ToString() != "")
                {
                    dataRow["ActivityNotes"] = this.objBc.SpecialDecode(dataRow["ActivityNotes"].ToString());
                }
                if (item.Columns.Contains("ContactName") && dataRow["ContactName"].ToString() != "")
                {
                    dataRow["ContactName"] = this.objBc.SpecialDecode(dataRow["ContactName"].ToString());
                }
                if (item.Columns.Contains("OrderTitle") && dataRow["OrderTitle"].ToString() != "")
                {
                    dataRow["OrderTitle"] = this.objBc.SpecialDecode(dataRow["OrderTitle"].ToString());
                }
                if (item.Columns.Contains("Company") && dataRow["Company"].ToString() != "")
                {
                    dataRow["Company"] = this.objBc.SpecialDecode(dataRow["Company"].ToString());
                }
                if (item.Columns.Contains("totaltaxprice") && dataRow["totaltaxprice"].ToString() != "")
                {
                    dataRow["totaltaxprice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["totaltaxprice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("TotalTaxPrice") && dataRow["TotalTaxPrice"].ToString() != "")
                {
                    dataRow["TotalTaxPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalTaxPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("OrderValue") && dataRow["OrderValue"].ToString() != "")
                {
                    dataRow["OrderValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["OrderValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("SubTotal") && dataRow["SubTotal"].ToString() != "")
                {
                    dataRow["SubTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["SubTotal"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPrice") && dataRow["GrossProfitPrice"].ToString() != "")
                {
                    dataRow["GrossProfitPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPercentage") && dataRow["GrossProfitPercentage"].ToString() != "")
                {
                    dataRow["GrossProfitPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostExMarkup") && dataRow["CostExMarkup"].ToString() != "")
                {
                    dataRow["CostExMarkup"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostExMarkup"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWidth") && dataRow["ProductWidth"].ToString() != "")
                {
                    dataRow["ProductWidth"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWidth"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Width") && dataRow["Width"].ToString() != "")
                {
                    dataRow["Width"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Width"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductHeight") && dataRow["ProductHeight"].ToString() != "")
                {
                    dataRow["ProductHeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductHeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Height") && dataRow["Height"].ToString() != "")
                {
                    dataRow["Height"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Height"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductLength") && dataRow["ProductLength"].ToString() != "")
                {
                    dataRow["ProductLength"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductLength"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Length") && dataRow["Length"].ToString() != "")
                {
                    dataRow["Length"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Length"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWeight") && dataRow["ProductWeight"].ToString() != "")
                {
                    dataRow["ProductWeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Weight") && dataRow["Weight"].ToString() != "")
                {
                    dataRow["Weight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Weight"].ToString()), 2, "", false, false, true);
                }
                item.Columns.Contains("ProductDimension");
                if (item.Columns.Contains("JobValue") && dataRow["JobValue"].ToString() != "")
                {
                    dataRow["JobValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["JobValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostPrice") && dataRow["CostPrice"].ToString() != "")
                {
                    dataRow["CostPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionAmount") && dataRow["CommissionAmount"].ToString() != "")
                {
                    dataRow["CommissionAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionAmount"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionPercentage") && dataRow["CommissionPercentage"].ToString() != "")
                {
                    dataRow["CommissionPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceValue") && dataRow["InvoiceValue"].ToString() != "")
                {
                    dataRow["InvoiceValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceAmountPaid") && dataRow["InvoiceAmountPaid"].ToString() != "")
                {
                    dataRow["InvoiceAmountPaid"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountPaid"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("InvoiceAmountOutstanding") || !(dataRow["InvoiceAmountOutstanding"].ToString() != ""))
                {
                    continue;
                }
                dataRow["InvoiceAmountOutstanding"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountOutstanding"].ToString()), 2, "", false, false, true);
            }
            if (this.Reports_type.ToLower() == "job")
            {
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("EstimateItemID"))
                {
                    item.Columns.Remove("EstimateItemID");
                }
                foreach (DataRow row1 in item.Rows)
                {
                    if (row1.Table.Columns.Contains("CustomerName"))
                    {
                        row1["CustomerName"] = this.objBc.SpecialDecode(row1["CustomerName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactName"))
                    {
                        row1["ContactName"] = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Department"))
                    {
                        row1["Department"] = this.objBc.SpecialDecode(row1["Department"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeremail"))
                    {
                        row1["customeremail"] = this.objBc.SpecialDecode(row1["customeremail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactemail"))
                    {
                        row1["contactemail"] = this.objBc.SpecialDecode(row1["contactemail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle1"))
                    {
                        row1["ContactJobTitle1"] = this.objBc.SpecialDecode(row1["ContactJobTitle1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle2"))
                    {
                        row1["ContactJobTitle2"] = this.objBc.SpecialDecode(row1["ContactJobTitle2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("CustomerType"))
                    {
                        row1["CustomerType"] = this.objBc.SpecialDecode(row1["CustomerType"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactphone"))
                    {
                        row1["contactphone"] = this.objBc.SpecialDecode(row1["contactphone"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress1"))
                    {
                        row1["contactaddress1"] = this.objBc.SpecialDecode(row1["contactaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress2"))
                    {
                        row1["contactaddress2"] = this.objBc.SpecialDecode(row1["contactaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress3"))
                    {
                        row1["contactaddress3"] = this.objBc.SpecialDecode(row1["contactaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress4"))
                    {
                        row1["contactaddress4"] = this.objBc.SpecialDecode(row1["contactaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress5"))
                    {
                        row1["contactaddress5"] = this.objBc.SpecialDecode(row1["contactaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress6"))
                    {
                        row1["contactaddress6"] = this.objBc.SpecialDecode(row1["contactaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress"))
                    {
                        row1["contactaddress"] = this.objBc.SpecialDecode(row1["contactaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress1"))
                    {
                        row1["deliveryaddress1"] = this.objBc.SpecialDecode(row1["deliveryaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress2"))
                    {
                        row1["deliveryaddress2"] = this.objBc.SpecialDecode(row1["deliveryaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress3"))
                    {
                        row1["deliveryaddress3"] = this.objBc.SpecialDecode(row1["deliveryaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress4"))
                    {
                        row1["deliveryaddress4"] = this.objBc.SpecialDecode(row1["deliveryaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress5"))
                    {
                        row1["deliveryaddress5"] = this.objBc.SpecialDecode(row1["deliveryaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress6"))
                    {
                        row1["deliveryaddress6"] = this.objBc.SpecialDecode(row1["deliveryaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress"))
                    {
                        row1["deliveryaddress"] = this.objBc.SpecialDecode(row1["deliveryaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress1"))
                    {
                        row1["invoiceaddress1"] = this.objBc.SpecialDecode(row1["invoiceaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress2"))
                    {
                        row1["invoiceaddress2"] = this.objBc.SpecialDecode(row1["invoiceaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress3"))
                    {
                        row1["invoiceaddress3"] = this.objBc.SpecialDecode(row1["invoiceaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress4"))
                    {
                        row1["invoiceaddress4"] = this.objBc.SpecialDecode(row1["invoiceaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress5"))
                    {
                        row1["invoiceaddress5"] = this.objBc.SpecialDecode(row1["invoiceaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress6"))
                    {
                        row1["invoiceaddress6"] = this.objBc.SpecialDecode(row1["invoiceaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress"))
                    {
                        row1["invoiceaddress"] = this.objBc.SpecialDecode(row1["invoiceaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Estimator"))
                    {
                        row1["Estimator"] = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                    }
                    if (row1.Table.Columns.Contains("salesperson"))
                    {
                        row1["salesperson"] = this.objBc.SpecialDecode(row1["salesperson"].ToString());
                    }
                    if (row1.Table.Columns.Contains("jobtitle"))
                    {
                        row1["jobtitle"] = this.objBc.SpecialDecode(row1["jobtitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Status"))
                    {
                        row1["Status"] = this.objBc.SpecialDecode(row1["Status"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ItemTitle"))
                    {
                        row1["ItemTitle"] = this.objBc.SpecialDecode(row1["ItemTitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Description"))
                    {
                        row1["DEscription"] = this.objBc.SpecialDecode(row1["DEscription"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Artwork"))
                    {
                        row1["Artwork"] = this.objBc.SpecialDecode(row1["Artwork"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Colour"))
                    {
                        row1["Colour"] = this.objBc.SpecialDecode(row1["Colour"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Size"))
                    {
                        row1["Size"] = this.objBc.SpecialDecode(row1["Size"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Material"))
                    {
                        row1["Material"] = this.objBc.SpecialDecode(row1["Material"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Delivery"))
                    {
                        row1["Delivery"] = this.objBc.SpecialDecode(row1["Delivery"].ToString());
                    }
                    if (row1.Table.Columns.Contains("finishing"))
                    {
                        row1["finishing"] = this.objBc.SpecialDecode(row1["finishing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("notes"))
                    {
                        row1["notes"] = this.objBc.SpecialDecode(row1["notes"].ToString());
                    }
                    if (row1.Table.Columns.Contains("instructions"))
                    {
                        row1["instructions"] = this.objBc.SpecialDecode(row1["instructions"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Proofs"))
                    {
                        row1["Proofs"] = this.objBc.SpecialDecode(row1["Proofs"].ToString());
                    }
                    if (row1.Table.Columns.Contains("packing"))
                    {
                        row1["packing"] = this.objBc.SpecialDecode(row1["packing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ordernumber"))
                    {
                        row1["ordernumber"] = this.objBc.SpecialDecode(row1["ordernumber"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Name"))
                    {
                        row1["Name"] = this.objBc.SpecialDecode(row1["Name"].ToString());
                    }
                    if (row1.Table.Columns.Contains("suppliername"))
                    {
                        row1["suppliername"] = this.objBc.SpecialDecode(row1["suppliername"].ToString());
                    }
                    if (row1.Table.Columns.Contains("producttitle"))
                    {
                        row1["producttitle"] = this.objBc.SpecialDecode(row1["producttitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcode"))
                    {
                        row1["productcode"] = this.objBc.SpecialDecode(row1["productcode"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcatagory"))
                    {
                        row1["productcatagory"] = this.objBc.SpecialDecode(row1["productcatagory"].ToString());
                    }
                    if (row1.Table.Columns.Contains("storename"))
                    {
                        row1["storename"] = this.objBc.SpecialDecode(row1["storename"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress1"))
                    {
                        row1["customeraddress1"] = this.objBc.SpecialDecode(row1["customeraddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress2"))
                    {
                        row1["customeraddress2"] = this.objBc.SpecialDecode(row1["customeraddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress3"))
                    {
                        row1["customeraddress3"] = this.objBc.SpecialDecode(row1["customeraddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress4"))
                    {
                        row1["customeraddress4"] = this.objBc.SpecialDecode(row1["customeraddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress5"))
                    {
                        row1["customeraddress5"] = this.objBc.SpecialDecode(row1["customeraddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress6"))
                    {
                        row1["customeraddress6"] = this.objBc.SpecialDecode(row1["customeraddress6"].ToString());
                    }
                    if (!row1.Table.Columns.Contains("customeraddress"))
                    {
                        continue;
                    }
                    row1["customeraddress"] = this.objBc.SpecialDecode(row1["customeraddress"].ToString());
                }
            }
            foreach (DataRow dataRow1 in item.Rows)
            {
                if (dataRow1.Table.Columns.Contains("Company"))
                {
                    dataRow1["Company"] = this.objBc.SpecialDecode(dataRow1["Company"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactName"))
                {
                    dataRow1["ContactName"] = this.objBc.SpecialDecode(dataRow1["ContactName"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Department"))
                {
                    dataRow1["Department"] = this.objBc.SpecialDecode(dataRow1["Department"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeremail"))
                {
                    dataRow1["customeremail"] = this.objBc.SpecialDecode(dataRow1["customeremail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactemail"))
                {
                    dataRow1["contactemail"] = this.objBc.SpecialDecode(dataRow1["contactemail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle1"))
                {
                    dataRow1["ContactJobTitle1"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle2"))
                {
                    dataRow1["ContactJobTitle2"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("CustomerType"))
                {
                    dataRow1["CustomerType"] = this.objBc.SpecialDecode(dataRow1["CustomerType"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactphone"))
                {
                    dataRow1["contactphone"] = this.objBc.SpecialDecode(dataRow1["contactphone"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress1"))
                {
                    dataRow1["contactaddress1"] = this.objBc.SpecialDecode(dataRow1["contactaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress2"))
                {
                    dataRow1["contactaddress2"] = this.objBc.SpecialDecode(dataRow1["contactaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress3"))
                {
                    dataRow1["contactaddress3"] = this.objBc.SpecialDecode(dataRow1["contactaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress4"))
                {
                    dataRow1["contactaddress4"] = this.objBc.SpecialDecode(dataRow1["contactaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress5"))
                {
                    dataRow1["contactaddress5"] = this.objBc.SpecialDecode(dataRow1["contactaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress6"))
                {
                    dataRow1["contactaddress6"] = this.objBc.SpecialDecode(dataRow1["contactaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress"))
                {
                    dataRow1["contactaddress"] = this.objBc.SpecialDecode(dataRow1["contactaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress1"))
                {
                    dataRow1["deliveryaddress1"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress2"))
                {
                    dataRow1["deliveryaddress2"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress3"))
                {
                    dataRow1["deliveryaddress3"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress4"))
                {
                    dataRow1["deliveryaddress4"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress5"))
                {
                    dataRow1["deliveryaddress5"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress6"))
                {
                    dataRow1["deliveryaddress6"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress"))
                {
                    dataRow1["deliveryaddress"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress1"))
                {
                    dataRow1["invoiceaddress1"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress2"))
                {
                    dataRow1["invoiceaddress2"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress3"))
                {
                    dataRow1["invoiceaddress3"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress4"))
                {
                    dataRow1["invoiceaddress4"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress5"))
                {
                    dataRow1["invoiceaddress5"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress6"))
                {
                    dataRow1["invoiceaddress6"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress"))
                {
                    dataRow1["invoiceaddress"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("salesperson"))
                {
                    dataRow1["salesperson"] = this.objBc.SpecialDecode(dataRow1["salesperson"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("InvoiceTitle"))
                {
                    dataRow1["InvoiceTitle"] = this.objBc.SpecialDecode(dataRow1["InvoiceTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Status"))
                {
                    dataRow1["Status"] = this.objBc.SpecialDecode(dataRow1["Status"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ItemTitle"))
                {
                    dataRow1["ItemTitle"] = this.objBc.SpecialDecode(dataRow1["ItemTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Description"))
                {
                    dataRow1["DEscription"] = this.objBc.SpecialDecode(dataRow1["DEscription"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Artwork"))
                {
                    dataRow1["Artwork"] = this.objBc.SpecialDecode(dataRow1["Artwork"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Colour"))
                {
                    dataRow1["Colour"] = this.objBc.SpecialDecode(dataRow1["Colour"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Size"))
                {
                    dataRow1["Size"] = this.objBc.SpecialDecode(dataRow1["Size"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Material"))
                {
                    dataRow1["Material"] = this.objBc.SpecialDecode(dataRow1["Material"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Delivery"))
                {
                    dataRow1["Delivery"] = this.objBc.SpecialDecode(dataRow1["Delivery"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("finishing"))
                {
                    dataRow1["finishing"] = this.objBc.SpecialDecode(dataRow1["finishing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("notes"))
                {
                    dataRow1["notes"] = this.objBc.SpecialDecode(dataRow1["notes"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("instructions"))
                {
                    dataRow1["instructions"] = this.objBc.SpecialDecode(dataRow1["instructions"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Proofs"))
                {
                    dataRow1["Proofs"] = this.objBc.SpecialDecode(dataRow1["Proofs"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("packing"))
                {
                    dataRow1["packing"] = this.objBc.SpecialDecode(dataRow1["packing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ordernumber"))
                {
                    dataRow1["ordernumber"] = this.objBc.SpecialDecode(dataRow1["ordernumber"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Name"))
                {
                    dataRow1["Name"] = this.objBc.SpecialDecode(dataRow1["Name"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("suppliername"))
                {
                    dataRow1["suppliername"] = this.objBc.SpecialDecode(dataRow1["suppliername"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("producttitle"))
                {
                    dataRow1["producttitle"] = this.objBc.SpecialDecode(dataRow1["producttitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("productcode"))
                {
                    dataRow1["productcode"] = this.objBc.SpecialDecode(dataRow1["productcode"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("storename"))
                {
                    dataRow1["storename"] = this.objBc.SpecialDecode(dataRow1["storename"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress1"))
                {
                    dataRow1["customeraddress1"] = this.objBc.SpecialDecode(dataRow1["customeraddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress2"))
                {
                    dataRow1["customeraddress2"] = this.objBc.SpecialDecode(dataRow1["customeraddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress3"))
                {
                    dataRow1["customeraddress3"] = this.objBc.SpecialDecode(dataRow1["customeraddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress4"))
                {
                    dataRow1["customeraddress4"] = this.objBc.SpecialDecode(dataRow1["customeraddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress5"))
                {
                    dataRow1["customeraddress5"] = this.objBc.SpecialDecode(dataRow1["customeraddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress6"))
                {
                    dataRow1["customeraddress6"] = this.objBc.SpecialDecode(dataRow1["customeraddress6"].ToString());
                }
                if (!dataRow1.Table.Columns.Contains("customeraddress"))
                {
                    continue;
                }
                dataRow1["customeraddress"] = this.objBc.SpecialDecode(dataRow1["customeraddress"].ToString());
            }
            foreach (DataRow row2 in dataSet.Tables[0].Rows)
            {
                if (row2.Table.Columns.Contains("ItemTitle"))
                {
                    row2["ItemTitle"] = this.objBc.SpecialDecode(row2["ItemTitle"].ToString());
                }
                if (row2.Table.Columns.Contains("CategoryName"))
                {
                    row2["CategoryName"] = this.objBc.SpecialDecode(row2["CategoryName"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemCode"))
                {
                    row2["ItemCode"] = this.objBc.SpecialDecode(row2["ItemCode"].ToString());
                }
                if (row2.Table.Columns.Contains("CustomerCode"))
                {
                    row2["CustomerCode"] = this.objBc.SpecialDecode(row2["CustomerCode"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemDescription"))
                {
                    row2["ItemDescription"] = this.objBc.SpecialDecode(row2["ItemDescription"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemArtWork"))
                {
                    row2["ItemArtWork"] = this.objBc.SpecialDecode(row2["ItemArtWork"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemColour"))
                {
                    row2["ItemColour"] = this.objBc.SpecialDecode(row2["ItemColour"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemSize"))
                {
                    row2["ItemSize"] = this.objBc.SpecialDecode(row2["ItemSize"].ToString());
                }
                if (row2.Table.Columns.Contains("Material"))
                {
                    row2["Material"] = this.objBc.SpecialDecode(row2["Material"].ToString());
                }
                if (row2.Table.Columns.Contains("Delivery"))
                {
                    row2["Delivery"] = this.objBc.SpecialDecode(row2["Delivery"].ToString());
                }
                if (row2.Table.Columns.Contains("Finishing"))
                {
                    row2["Finishing"] = this.objBc.SpecialDecode(row2["Finishing"].ToString());
                }
                if (row2.Table.Columns.Contains("Proofs"))
                {
                    row2["Proofs"] = this.objBc.SpecialDecode(row2["Proofs"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemPacking"))
                {
                    row2["ItemPacking"] = this.objBc.SpecialDecode(row2["ItemPacking"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemNotes"))
                {
                    row2["ItemNotes"] = this.objBc.SpecialDecode(row2["ItemNotes"].ToString());
                }
                if (row2.Table.Columns.Contains("Terms/Instructions"))
                {
                    row2["Terms/Instructions"] = this.objBc.SpecialDecode(row2["Terms/Instructions"].ToString());
                }
                if (item.Columns.Contains("price") && row2["price"].ToString() != "")
                {
                    row2["price"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["price"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpPercentage") && row2["MarkUpPercentage"].ToString() != "")
                {
                    row2["MarkUpPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpValue") && row2["MarkUpValue"].ToString() != "")
                {
                    row2["MarkUpValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpValue"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("SellingPrice") || !(row2["SellingPrice"].ToString() != ""))
                {
                    continue;
                }
                row2["SellingPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["SellingPrice"].ToString()), 2, "", false, false, true);
            }
        }

        protected void grid_reports_Product_itemdatabound(object sender, GridItemEventArgs e)
        {
            this.getColumnNameFromSettings();
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    if (e.Item.Cells[i].Text == "ItemTitle")
                    {
                        e.Item.Cells[i].Text = this.ItemTitle_prodreport;
                    }
                    if (e.Item.Cells[i].Text == "CategoryName")
                    {
                        e.Item.Cells[i].Text = "Category Name";
                    }
                    if (e.Item.Cells[i].Text == "ItemCode")
                    {
                        e.Item.Cells[i].Text = "Item Code";
                    }
                    if (e.Item.Cells[i].Text == "CustomerCode")
                    {
                        e.Item.Cells[i].Text = "Customer Code";
                    }
                    if (e.Item.Cells[i].Text == "IsEditableProduct")
                    {
                        e.Item.Cells[i].Text = "Product Type";
                    }
                    if (e.Item.Cells[i].Text == "PublicAccount")
                    {
                        e.Item.Cells[i].Text = "Public Accounts";
                    }
                    if (e.Item.Cells[i].Text == "ItemDescription")
                    {
                        e.Item.Cells[i].Text = this.Description_prod;
                    }
                    if (e.Item.Cells[i].Text == "ItemArtwork")
                    {
                        e.Item.Cells[i].Text = this.Artwork_prod;
                    }
                    if (e.Item.Cells[i].Text == "ItemColour")
                    {
                        e.Item.Cells[i].Text = this.Colour_prod;
                    }
                    if (e.Item.Cells[i].Text == "ItemSize")
                    {
                        e.Item.Cells[i].Text = this.Size_prod;
                    }
                    if (e.Item.Cells[i].Text == "Material")
                    {
                        e.Item.Cells[i].Text = this.Material_prod;
                    }
                    if (e.Item.Cells[i].Text == "Delivery")
                    {
                        e.Item.Cells[i].Text = this.Delivery_prod;
                    }
                    if (e.Item.Cells[i].Text == "Finishing")
                    {
                        e.Item.Cells[i].Text = this.Finishing_prod;
                    }
                    if (e.Item.Cells[i].Text == "ItemSize")
                    {
                        e.Item.Cells[i].Text = this.Size_prod;
                    }
                    if (e.Item.Cells[i].Text == "Proofs")
                    {
                        e.Item.Cells[i].Text = this.Proofs_prod;
                    }
                    if (e.Item.Cells[i].Text == "ItemPacking")
                    {
                        e.Item.Cells[i].Text = this.Packing_prod;
                    }
                    if (e.Item.Cells[i].Text == "ItemNotes")
                    {
                        e.Item.Cells[i].Text = this.Notes_prod;
                    }
                    if (e.Item.Cells[i].Text == "Terms/Instructions")
                    {
                        e.Item.Cells[i].Text = this.Instructions_prod;
                    }
                    if (e.Item.Cells[i].Text == "MatrixType")
                    {
                        e.Item.Cells[i].Text = "Pricing Type";
                    }
                    if (e.Item.Cells[i].Text == "fromquantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_fromquantity = i;
                        e.Item.Cells[i].Text = "Start Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "toquantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_toquantity = i;
                        e.Item.Cells[i].Text = "End Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "price")
                    {
                        this.flacosts = true;
                        this.cellvalue_priceprod = i;
                        e.Item.Cells[i].Text = "Cost";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "MarkUpPercentage")
                    {
                        this.flacosts = true;
                        this.cellvalue_MarkUpPercentage = i;
                        e.Item.Cells[i].Text = "Mark (%)";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "MarkUpValue")
                    {
                        this.flacosts = true;
                        this.cellvalue_MarkUpvalue = i;
                        e.Item.Cells[i].Text = "Mark Value";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "SellingPrice")
                    {
                        this.flacosts = true;
                        this.cellvalue_SellingPrice = i;
                        e.Item.Cells[i].Text = "Selling Price";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "TotalStockQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_qtyonhand = i;
                        e.Item.Cells[i].Text = "Qty On Hand";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AllocatedStockQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_AllocatedStockQuantity = i;
                        e.Item.Cells[i].Text = "Allocated Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AvailableStockQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_AvailableStockQuantity = i;
                        e.Item.Cells[i].Text = "Available Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AllocatedQty")
                    {
                        this.flacosts = true;
                        this.cellvalue_AllocatedStockQuantity = i;
                        e.Item.Cells[i].Text = "Allocated Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "AvailableQty")
                    {
                        this.flacosts = true;
                        this.cellvalue_AvailableStockQuantity = i;
                        e.Item.Cells[i].Text = "Available Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ReOrderQuantity")
                    {
                        this.flacosts = true;
                        this.cellvalue_ReOrderQuantity = i;
                        e.Item.Cells[i].Text = "Re-order Qty";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "ReorderAlertLevel")
                    {
                        this.flacosts = true;
                        this.cellvalue_ReorderAlertLevel = i;
                        e.Item.Cells[i].Text = "Re-Order Alert Level";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "QtySoldWeekToDate")
                    {
                        this.flacosts = true;
                        this.cellvalue_QtySoldWeekToDate = i;
                        e.Item.Cells[i].Text = "Qty WTD";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "QtySoldMonthToDate")
                    {
                        this.flacosts = true;
                        this.cellvalue_QtySoldMonthToDate = i;
                        e.Item.Cells[i].Text = "Qty MTD";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "QtySoldYearToDate")
                    {
                        this.flacosts = true;
                        this.cellvalue_QtySoldYearToDate = i;
                        e.Item.Cells[i].Text = "Qty C-YTD";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    if (e.Item.Cells[i].Text == "QtySoldFinancialYearToDate")
                    {
                        this.flacosts = true;
                        this.cellvalue_QtySoldYearToDate = i;
                        e.Item.Cells[i].Text = "Qty F-YTD";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "QtySoldTillDate")
                    {
                        this.flacosts = true;
                        this.cellvalue_QtySoldTillDate = i;
                        e.Item.Cells[i].Text = "Qty TD";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "QtyInHand")
                    {
                        this.flacosts = true;
                        this.cellvalue_qty_inhand = i;
                        e.Item.Cells[i].Text = "Qty On Hand";
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "Length")
                    {
                        this.flacosts = true;
                        this.cellvalue_prod_Length = i;
                        e.Item.Cells[i].Text = string.Concat("Length (", this.Paper_Stock_Lenght, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "Height")
                    {
                        this.flacosts = true;
                        this.cellvalue_prod_height = i;
                        this.cellvalue_prod_height = i;
                        e.Item.Cells[i].Text = string.Concat("Height (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "Width")
                    {
                        this.flacosts = true;
                        this.cellvalue_prod_width = i;
                        e.Item.Cells[i].Text = string.Concat("Width (", this.Paper_Stock, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "Weight")
                    {
                        this.flacosts = true;
                        this.cellvalue_prod_Weight = i;
                        e.Item.Cells[i].Text = string.Concat("Weight (", this.Weight_gsm, ")");
                        e.Item.Cells[i].Attributes.Add("style", "text-align:right");
                    }
                    if (e.Item.Cells[i].Text == "DrawStockFrom")
                    {
                        e.Item.Cells[i].Text = "Draw Stock From";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "salestaxrate")
                    {
                        e.Item.Cells[i].Text = "Sales Tax Rate";
                    }
                    if (e.Item.Cells[i].Text == "CustomField1")
                    {
                        e.Item.Cells[i].Text = this.CustomField1;
                    }
                    if (e.Item.Cells[i].Text == "CustomField2")
                    {
                        e.Item.Cells[i].Text = this.CustomField2;
                    }
                    if (e.Item.Cells[i].Text == "CustomField3")
                    {
                        e.Item.Cells[i].Text = this.CustomField3;
                    }
                    if (e.Item.Cells[i].Text == "CustomField4")
                    {
                        e.Item.Cells[i].Text = this.CustomField4;
                    }
                    if (e.Item.Cells[i].Text == "CustomField5")
                    {
                        e.Item.Cells[i].Text = this.CustomField5;
                    }
                    if (e.Item.Cells[i].Text == "CustomField6")
                    {
                        e.Item.Cells[i].Text = this.CustomField6;
                    }

                    // Ticket #9108  "stock usage report with YTD" not show when accessed with the B2B
                    if (e.Item.Cells[i].Text == "QtySoldQuarterToDate")
                    {
                        e.Item.Cells[i].Text = "Qty QTD";
                    }
                    if (e.Item.Cells[i].Text == "DateLastReplenished")
                    {
                        e.Item.Cells[i].Text = "Date Last Replenished";
                    }
                }
            }
            if (e.Item is GridDataItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    if (this.flacosts)
                    {
                        e.Item.Cells[this.cellvalue_productwidth].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productheight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productlength].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productweight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_productdimension].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_QtySoldMonthToDate].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_QtySoldTillDate].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_QtySoldYearToDate].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_QtySoldWeekToDate].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_ReorderAlertLevel].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_ReOrderQuantity].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_SellingPrice].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_toquantity].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_qtyonhand].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_qty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_priceprod].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_MarkUpvalue].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_MarkUpPercentage].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_itemqty].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_fromquantity].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_AvailableStockQuantity].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_AllocatedStockQuantity].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_qty_inhand].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_prod_Weight].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_prod_Length].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_prod_height].Attributes.Add("align", "right");
                        e.Item.Cells[this.cellvalue_prod_width].Attributes.Add("align", "right");
                    }
                }
            }
        }

        protected void grid_reports_product_needdatasource(object source, GridNeedDataSourceEventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:block;");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[2];
            int pageSize = this.grid_reports_byreportid_product.PageSize;
            int currentPageIndex = this.grid_reports_byreportid_product.CurrentPageIndex + 1;
            dateTime[0] = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            this.reportid = (long)Convert.ToInt32(this.hdn_reportid_afterload.Value);
            DataSet dataSet = OrderBasePage.Select_Reports_databyreportid(this.reportid, (long)this.CompanyID, this.StoreUserID, dateTime[0], dateTime[1], pageSize, currentPageIndex);
            DataTable item = dataSet.Tables[0];
            foreach (DataColumn column in item.Columns)
            {
                column.ReadOnly = false;
            }
            this.div_reportgrid.Attributes.Add("style", "width:100%;");
            if (item.Columns.Contains("ActivityNotes"))
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row["ActivityNotes"] == null)
                    {
                        continue;
                    }
                    row["ActivityNotes"] = base.Server.HtmlDecode(row["ActivityNotes"].ToString());
                    row["ActivityNotes"] = row["ActivityNotes"].ToString().Replace("¶", "<br>");
                }
            }
            if (item.Columns.Contains("Orderid"))
            {
                item.Columns.Remove("Orderid");
            }
            if (item.Columns.Contains("Estimateid"))
            {
                item.Columns.Remove("Estimateid");
            }
            if (item.Columns.Contains("clientID"))
            {
                item.Columns.Remove("clientID");
            }
            if (item.Columns.Contains("Invoiceid"))
            {
                item.Columns.Remove("Invoiceid");
            }
            if (item.Columns.Contains("jobid"))
            {
                item.Columns.Remove("jobid");
            }
            if (item.Columns.Contains("IsStockItem"))
            {
                item.Columns.Remove("IsStockItem");
            }
            if (item.Columns.Contains("ActivityRecords"))
            {
                item.Columns.Remove("ActivityRecords");
            }
            if (item.Columns.Contains("TempProduct"))
            {
                item.Columns.Remove("TempProduct");
            }
            if (item.Columns.Contains("TempAvailableQty"))
            {
                item.Columns.Remove("TempAvailableQty");
            }
            if (item.Columns.Contains("pricecatalogueid"))
            {
                item.Columns.Remove("pricecatalogueid");
            }
            if (item.Columns.Contains("RowNumber"))
            {
                item.Columns.Remove("RowNumber");
            }
            foreach (DataRow dataRow in item.Rows)
            {
                if (item.Columns.Contains("CreatedDate") && dataRow["createddate"].ToString() != "")
                {
                    dataRow["CreatedDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["CreatedDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("OrderDate") && dataRow["OrderDate"].ToString() != "")
                {
                    dataRow["OrderDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("DueDate") && dataRow["DueDate"].ToString() != "")
                {
                    dataRow["DueDate"] = this.comm.Eprint_return_Date_Before_View(dataRow["DueDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                }
                if (item.Columns.Contains("ContactAddress") && dataRow["ContactAddress"].ToString() != "")
                {
                    dataRow["ContactAddress"] = this.objBc.SpecialDecode(dataRow["ContactAddress"].ToString());
                }
                if (item.Columns.Contains("DeliveryAddress") && dataRow["DeliveryAddress"].ToString() != "")
                {
                    dataRow["DeliveryAddress"] = this.objBc.SpecialDecode(dataRow["DeliveryAddress"].ToString());
                }
                if (item.Columns.Contains("InvoiceAddress") && dataRow["InvoiceAddress"].ToString() != "")
                {
                    dataRow["InvoiceAddress"] = this.objBc.SpecialDecode(dataRow["InvoiceAddress"].ToString());
                }
                if (item.Columns.Contains("ItemTitle") && dataRow["ItemTitle"].ToString() != "")
                {
                    dataRow["ItemTitle"] = this.objBc.SpecialDecode(dataRow["ItemTitle"].ToString());
                }
                if (item.Columns.Contains("Description") && dataRow["Description"].ToString() != "")
                {
                    dataRow["Description"] = this.objBc.SpecialDecode(dataRow["Description"].ToString());
                }
                if (item.Columns.Contains("ActivityNotes") && dataRow["ActivityNotes"].ToString() != "")
                {
                    dataRow["ActivityNotes"] = this.objBc.SpecialDecode(dataRow["ActivityNotes"].ToString());
                }
                if (item.Columns.Contains("ContactName") && dataRow["ContactName"].ToString() != "")
                {
                    dataRow["ContactName"] = this.objBc.SpecialDecode(dataRow["ContactName"].ToString());
                }
                if (item.Columns.Contains("OrderTitle") && dataRow["OrderTitle"].ToString() != "")
                {
                    dataRow["OrderTitle"] = this.objBc.SpecialDecode(dataRow["OrderTitle"].ToString());
                }
                if (item.Columns.Contains("Company") && dataRow["Company"].ToString() != "")
                {
                    dataRow["Company"] = this.objBc.SpecialDecode(dataRow["Company"].ToString());
                }
                if (item.Columns.Contains("OrderValue") && dataRow["OrderValue"].ToString() != "")
                {
                    dataRow["OrderValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["OrderValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("SubTotal") && dataRow["SubTotal"].ToString() != "")
                {
                    dataRow["SubTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["SubTotal"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPrice") && dataRow["GrossProfitPrice"].ToString() != "")
                {
                    dataRow["GrossProfitPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("GrossProfitPercentage") && dataRow["GrossProfitPercentage"].ToString() != "")
                {
                    dataRow["GrossProfitPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["GrossProfitPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostExMarkup") && dataRow["CostExMarkup"].ToString() != "")
                {
                    dataRow["CostExMarkup"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostExMarkup"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWidth") && dataRow["ProductWidth"].ToString() != "")
                {
                    dataRow["ProductWidth"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWidth"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Width") && dataRow["Width"].ToString() != "")
                {
                    dataRow["Width"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Width"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductHeight") && dataRow["ProductHeight"].ToString() != "")
                {
                    dataRow["ProductHeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductHeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Height") && dataRow["Height"].ToString() != "")
                {
                    dataRow["Height"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Height"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductLength") && dataRow["ProductLength"].ToString() != "")
                {
                    dataRow["ProductLength"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductLength"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Length") && dataRow["Length"].ToString() != "")
                {
                    dataRow["Length"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Length"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("ProductWeight") && dataRow["ProductWeight"].ToString() != "")
                {
                    dataRow["ProductWeight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["ProductWeight"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("Weight") && dataRow["Weight"].ToString() != "")
                {
                    dataRow["Weight"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["Weight"].ToString()), 2, "", false, false, true);
                }
                item.Columns.Contains("ProductDimension");
                if (item.Columns.Contains("JobValue") && dataRow["JobValue"].ToString() != "")
                {
                    dataRow["JobValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["JobValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CostPrice") && dataRow["CostPrice"].ToString() != "")
                {
                    dataRow["CostPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CostPrice"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionAmount") && dataRow["CommissionAmount"].ToString() != "")
                {
                    dataRow["CommissionAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionAmount"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("CommissionPercentage") && dataRow["CommissionPercentage"].ToString() != "")
                {
                    dataRow["CommissionPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CommissionPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceValue") && dataRow["InvoiceValue"].ToString() != "")
                {
                    dataRow["InvoiceValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceValue"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("InvoiceAmountPaid") && dataRow["InvoiceAmountPaid"].ToString() != "")
                {
                    dataRow["InvoiceAmountPaid"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountPaid"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("InvoiceAmountOutstanding") || !(dataRow["InvoiceAmountOutstanding"].ToString() != ""))
                {
                    continue;
                }
                dataRow["InvoiceAmountOutstanding"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["InvoiceAmountOutstanding"].ToString()), 2, "", false, false, true);
            }
            if (this.Reports_type.ToLower() == "job")
            {
                if (item.Columns.Contains("jobid"))
                {
                    item.Columns.Remove("jobid");
                }
                if (item.Columns.Contains("EstimateItemID"))
                {
                    item.Columns.Remove("EstimateItemID");
                }
                foreach (DataRow row1 in item.Rows)
                {
                    if (row1.Table.Columns.Contains("CustomerName"))
                    {
                        row1["CustomerName"] = this.objBc.SpecialDecode(row1["CustomerName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactName"))
                    {
                        row1["ContactName"] = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Department"))
                    {
                        row1["Department"] = this.objBc.SpecialDecode(row1["Department"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeremail"))
                    {
                        row1["customeremail"] = this.objBc.SpecialDecode(row1["customeremail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactemail"))
                    {
                        row1["contactemail"] = this.objBc.SpecialDecode(row1["contactemail"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle1"))
                    {
                        row1["ContactJobTitle1"] = this.objBc.SpecialDecode(row1["ContactJobTitle1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ContactJobTitle2"))
                    {
                        row1["ContactJobTitle2"] = this.objBc.SpecialDecode(row1["ContactJobTitle2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("CustomerType"))
                    {
                        row1["CustomerType"] = this.objBc.SpecialDecode(row1["CustomerType"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactphone"))
                    {
                        row1["contactphone"] = this.objBc.SpecialDecode(row1["contactphone"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress1"))
                    {
                        row1["contactaddress1"] = this.objBc.SpecialDecode(row1["contactaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress2"))
                    {
                        row1["contactaddress2"] = this.objBc.SpecialDecode(row1["contactaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress3"))
                    {
                        row1["contactaddress3"] = this.objBc.SpecialDecode(row1["contactaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress4"))
                    {
                        row1["contactaddress4"] = this.objBc.SpecialDecode(row1["contactaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress5"))
                    {
                        row1["contactaddress5"] = this.objBc.SpecialDecode(row1["contactaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress6"))
                    {
                        row1["contactaddress6"] = this.objBc.SpecialDecode(row1["contactaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("contactaddress"))
                    {
                        row1["contactaddress"] = this.objBc.SpecialDecode(row1["contactaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress1"))
                    {
                        row1["deliveryaddress1"] = this.objBc.SpecialDecode(row1["deliveryaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress2"))
                    {
                        row1["deliveryaddress2"] = this.objBc.SpecialDecode(row1["deliveryaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress3"))
                    {
                        row1["deliveryaddress3"] = this.objBc.SpecialDecode(row1["deliveryaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress4"))
                    {
                        row1["deliveryaddress4"] = this.objBc.SpecialDecode(row1["deliveryaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress5"))
                    {
                        row1["deliveryaddress5"] = this.objBc.SpecialDecode(row1["deliveryaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress6"))
                    {
                        row1["deliveryaddress6"] = this.objBc.SpecialDecode(row1["deliveryaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("deliveryaddress"))
                    {
                        row1["deliveryaddress"] = this.objBc.SpecialDecode(row1["deliveryaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress1"))
                    {
                        row1["invoiceaddress1"] = this.objBc.SpecialDecode(row1["invoiceaddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress2"))
                    {
                        row1["invoiceaddress2"] = this.objBc.SpecialDecode(row1["invoiceaddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress3"))
                    {
                        row1["invoiceaddress3"] = this.objBc.SpecialDecode(row1["invoiceaddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress4"))
                    {
                        row1["invoiceaddress4"] = this.objBc.SpecialDecode(row1["invoiceaddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress5"))
                    {
                        row1["invoiceaddress5"] = this.objBc.SpecialDecode(row1["invoiceaddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress6"))
                    {
                        row1["invoiceaddress6"] = this.objBc.SpecialDecode(row1["invoiceaddress6"].ToString());
                    }
                    if (row1.Table.Columns.Contains("invoiceaddress"))
                    {
                        row1["invoiceaddress"] = this.objBc.SpecialDecode(row1["invoiceaddress"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Estimator"))
                    {
                        row1["Estimator"] = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                    }
                    if (row1.Table.Columns.Contains("salesperson"))
                    {
                        row1["salesperson"] = this.objBc.SpecialDecode(row1["salesperson"].ToString());
                    }
                    if (row1.Table.Columns.Contains("jobtitle"))
                    {
                        row1["jobtitle"] = this.objBc.SpecialDecode(row1["jobtitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Status"))
                    {
                        row1["Status"] = this.objBc.SpecialDecode(row1["Status"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ItemTitle"))
                    {
                        row1["ItemTitle"] = this.objBc.SpecialDecode(row1["ItemTitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Description"))
                    {
                        row1["DEscription"] = this.objBc.SpecialDecode(row1["DEscription"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Artwork"))
                    {
                        row1["Artwork"] = this.objBc.SpecialDecode(row1["Artwork"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Colour"))
                    {
                        row1["Colour"] = this.objBc.SpecialDecode(row1["Colour"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Size"))
                    {
                        row1["Size"] = this.objBc.SpecialDecode(row1["Size"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Material"))
                    {
                        row1["Material"] = this.objBc.SpecialDecode(row1["Material"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Delivery"))
                    {
                        row1["Delivery"] = this.objBc.SpecialDecode(row1["Delivery"].ToString());
                    }
                    if (row1.Table.Columns.Contains("finishing"))
                    {
                        row1["finishing"] = this.objBc.SpecialDecode(row1["finishing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("notes"))
                    {
                        row1["notes"] = this.objBc.SpecialDecode(row1["notes"].ToString());
                    }
                    if (row1.Table.Columns.Contains("instructions"))
                    {
                        row1["instructions"] = this.objBc.SpecialDecode(row1["instructions"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Proofs"))
                    {
                        row1["Proofs"] = this.objBc.SpecialDecode(row1["Proofs"].ToString());
                    }
                    if (row1.Table.Columns.Contains("packing"))
                    {
                        row1["packing"] = this.objBc.SpecialDecode(row1["packing"].ToString());
                    }
                    if (row1.Table.Columns.Contains("ordernumber"))
                    {
                        row1["ordernumber"] = this.objBc.SpecialDecode(row1["ordernumber"].ToString());
                    }
                    if (row1.Table.Columns.Contains("Name"))
                    {
                        row1["Name"] = this.objBc.SpecialDecode(row1["Name"].ToString());
                    }
                    if (row1.Table.Columns.Contains("suppliername"))
                    {
                        row1["suppliername"] = this.objBc.SpecialDecode(row1["suppliername"].ToString());
                    }
                    if (row1.Table.Columns.Contains("producttitle"))
                    {
                        row1["producttitle"] = this.objBc.SpecialDecode(row1["producttitle"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcode"))
                    {
                        row1["productcode"] = this.objBc.SpecialDecode(row1["productcode"].ToString());
                    }
                    if (row1.Table.Columns.Contains("productcatagory"))
                    {
                        row1["productcatagory"] = this.objBc.SpecialDecode(row1["productcatagory"].ToString());
                    }
                    if (row1.Table.Columns.Contains("storename"))
                    {
                        row1["storename"] = this.objBc.SpecialDecode(row1["storename"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress1"))
                    {
                        row1["customeraddress1"] = this.objBc.SpecialDecode(row1["customeraddress1"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress2"))
                    {
                        row1["customeraddress2"] = this.objBc.SpecialDecode(row1["customeraddress2"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress3"))
                    {
                        row1["customeraddress3"] = this.objBc.SpecialDecode(row1["customeraddress3"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress4"))
                    {
                        row1["customeraddress4"] = this.objBc.SpecialDecode(row1["customeraddress4"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress5"))
                    {
                        row1["customeraddress5"] = this.objBc.SpecialDecode(row1["customeraddress5"].ToString());
                    }
                    if (row1.Table.Columns.Contains("customeraddress6"))
                    {
                        row1["customeraddress6"] = this.objBc.SpecialDecode(row1["customeraddress6"].ToString());
                    }
                    if (!row1.Table.Columns.Contains("customeraddress"))
                    {
                        continue;
                    }
                    row1["customeraddress"] = this.objBc.SpecialDecode(row1["customeraddress"].ToString());
                }
            }
            foreach (DataRow dataRow1 in item.Rows)
            {
                if (dataRow1.Table.Columns.Contains("Company"))
                {
                    dataRow1["Company"] = this.objBc.SpecialDecode(dataRow1["Company"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactName"))
                {
                    dataRow1["ContactName"] = this.objBc.SpecialDecode(dataRow1["ContactName"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Department"))
                {
                    dataRow1["Department"] = this.objBc.SpecialDecode(dataRow1["Department"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeremail"))
                {
                    dataRow1["customeremail"] = this.objBc.SpecialDecode(dataRow1["customeremail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactemail"))
                {
                    dataRow1["contactemail"] = this.objBc.SpecialDecode(dataRow1["contactemail"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle1"))
                {
                    dataRow1["ContactJobTitle1"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ContactJobTitle2"))
                {
                    dataRow1["ContactJobTitle2"] = this.objBc.SpecialDecode(dataRow1["ContactJobTitle2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("CustomerType"))
                {
                    dataRow1["CustomerType"] = this.objBc.SpecialDecode(dataRow1["CustomerType"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactphone"))
                {
                    dataRow1["contactphone"] = this.objBc.SpecialDecode(dataRow1["contactphone"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress1"))
                {
                    dataRow1["contactaddress1"] = this.objBc.SpecialDecode(dataRow1["contactaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress2"))
                {
                    dataRow1["contactaddress2"] = this.objBc.SpecialDecode(dataRow1["contactaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress3"))
                {
                    dataRow1["contactaddress3"] = this.objBc.SpecialDecode(dataRow1["contactaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress4"))
                {
                    dataRow1["contactaddress4"] = this.objBc.SpecialDecode(dataRow1["contactaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress5"))
                {
                    dataRow1["contactaddress5"] = this.objBc.SpecialDecode(dataRow1["contactaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress6"))
                {
                    dataRow1["contactaddress6"] = this.objBc.SpecialDecode(dataRow1["contactaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("contactaddress"))
                {
                    dataRow1["contactaddress"] = this.objBc.SpecialDecode(dataRow1["contactaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress1"))
                {
                    dataRow1["deliveryaddress1"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress2"))
                {
                    dataRow1["deliveryaddress2"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress3"))
                {
                    dataRow1["deliveryaddress3"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress4"))
                {
                    dataRow1["deliveryaddress4"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress5"))
                {
                    dataRow1["deliveryaddress5"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress6"))
                {
                    dataRow1["deliveryaddress6"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("deliveryaddress"))
                {
                    dataRow1["deliveryaddress"] = this.objBc.SpecialDecode(dataRow1["deliveryaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress1"))
                {
                    dataRow1["invoiceaddress1"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress2"))
                {
                    dataRow1["invoiceaddress2"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress3"))
                {
                    dataRow1["invoiceaddress3"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress4"))
                {
                    dataRow1["invoiceaddress4"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress5"))
                {
                    dataRow1["invoiceaddress5"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress6"))
                {
                    dataRow1["invoiceaddress6"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress6"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("invoiceaddress"))
                {
                    dataRow1["invoiceaddress"] = this.objBc.SpecialDecode(dataRow1["invoiceaddress"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("salesperson"))
                {
                    dataRow1["salesperson"] = this.objBc.SpecialDecode(dataRow1["salesperson"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("InvoiceTitle"))
                {
                    dataRow1["InvoiceTitle"] = this.objBc.SpecialDecode(dataRow1["InvoiceTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Status"))
                {
                    dataRow1["Status"] = this.objBc.SpecialDecode(dataRow1["Status"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ItemTitle"))
                {
                    dataRow1["ItemTitle"] = this.objBc.SpecialDecode(dataRow1["ItemTitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Description"))
                {
                    dataRow1["DEscription"] = this.objBc.SpecialDecode(dataRow1["DEscription"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Artwork"))
                {
                    dataRow1["Artwork"] = this.objBc.SpecialDecode(dataRow1["Artwork"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Colour"))
                {
                    dataRow1["Colour"] = this.objBc.SpecialDecode(dataRow1["Colour"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Size"))
                {
                    dataRow1["Size"] = this.objBc.SpecialDecode(dataRow1["Size"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Material"))
                {
                    dataRow1["Material"] = this.objBc.SpecialDecode(dataRow1["Material"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Delivery"))
                {
                    dataRow1["Delivery"] = this.objBc.SpecialDecode(dataRow1["Delivery"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("finishing"))
                {
                    dataRow1["finishing"] = this.objBc.SpecialDecode(dataRow1["finishing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("notes"))
                {
                    dataRow1["notes"] = this.objBc.SpecialDecode(dataRow1["notes"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("instructions"))
                {
                    dataRow1["instructions"] = this.objBc.SpecialDecode(dataRow1["instructions"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Proofs"))
                {
                    dataRow1["Proofs"] = this.objBc.SpecialDecode(dataRow1["Proofs"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("packing"))
                {
                    dataRow1["packing"] = this.objBc.SpecialDecode(dataRow1["packing"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("ordernumber"))
                {
                    dataRow1["ordernumber"] = this.objBc.SpecialDecode(dataRow1["ordernumber"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("Name"))
                {
                    dataRow1["Name"] = this.objBc.SpecialDecode(dataRow1["Name"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("suppliername"))
                {
                    dataRow1["suppliername"] = this.objBc.SpecialDecode(dataRow1["suppliername"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("producttitle"))
                {
                    dataRow1["producttitle"] = this.objBc.SpecialDecode(dataRow1["producttitle"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("productcode"))
                {
                    dataRow1["productcode"] = this.objBc.SpecialDecode(dataRow1["productcode"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("storename"))
                {
                    dataRow1["storename"] = this.objBc.SpecialDecode(dataRow1["storename"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress1"))
                {
                    dataRow1["customeraddress1"] = this.objBc.SpecialDecode(dataRow1["customeraddress1"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress2"))
                {
                    dataRow1["customeraddress2"] = this.objBc.SpecialDecode(dataRow1["customeraddress2"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress3"))
                {
                    dataRow1["customeraddress3"] = this.objBc.SpecialDecode(dataRow1["customeraddress3"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress4"))
                {
                    dataRow1["customeraddress4"] = this.objBc.SpecialDecode(dataRow1["customeraddress4"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress5"))
                {
                    dataRow1["customeraddress5"] = this.objBc.SpecialDecode(dataRow1["customeraddress5"].ToString());
                }
                if (dataRow1.Table.Columns.Contains("customeraddress6"))
                {
                    dataRow1["customeraddress6"] = this.objBc.SpecialDecode(dataRow1["customeraddress6"].ToString());
                }
                if (!dataRow1.Table.Columns.Contains("customeraddress"))
                {
                    continue;
                }
                dataRow1["customeraddress"] = this.objBc.SpecialDecode(dataRow1["customeraddress"].ToString());
            }
            foreach (DataRow row2 in dataSet.Tables[0].Rows)
            {
                if (row2.Table.Columns.Contains("ItemTitle"))
                {
                    row2["ItemTitle"] = this.objBc.SpecialDecode(row2["ItemTitle"].ToString());
                }
                if (row2.Table.Columns.Contains("CategoryName"))
                {
                    row2["CategoryName"] = this.objBc.SpecialDecode(row2["CategoryName"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemCode"))
                {
                    row2["ItemCode"] = this.objBc.SpecialDecode(row2["ItemCode"].ToString());
                }
                if (row2.Table.Columns.Contains("CustomerCode"))
                {
                    row2["CustomerCode"] = this.objBc.SpecialDecode(row2["CustomerCode"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemDescription"))
                {
                    row2["ItemDescription"] = this.objBc.SpecialDecode(row2["ItemDescription"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemArtWork"))
                {
                    row2["ItemArtWork"] = this.objBc.SpecialDecode(row2["ItemArtWork"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemColour"))
                {
                    row2["ItemColour"] = this.objBc.SpecialDecode(row2["ItemColour"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemSize"))
                {
                    row2["ItemSize"] = this.objBc.SpecialDecode(row2["ItemSize"].ToString());
                }
                if (row2.Table.Columns.Contains("Material"))
                {
                    row2["Material"] = this.objBc.SpecialDecode(row2["Material"].ToString());
                }
                if (row2.Table.Columns.Contains("Delivery"))
                {
                    row2["Delivery"] = this.objBc.SpecialDecode(row2["Delivery"].ToString());
                }
                if (row2.Table.Columns.Contains("Finishing"))
                {
                    row2["Finishing"] = this.objBc.SpecialDecode(row2["Finishing"].ToString());
                }
                if (row2.Table.Columns.Contains("Proofs"))
                {
                    row2["Proofs"] = this.objBc.SpecialDecode(row2["Proofs"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemPacking"))
                {
                    row2["ItemPacking"] = this.objBc.SpecialDecode(row2["ItemPacking"].ToString());
                }
                if (row2.Table.Columns.Contains("ItemNotes"))
                {
                    row2["ItemNotes"] = this.objBc.SpecialDecode(row2["ItemNotes"].ToString());
                }
                if (row2.Table.Columns.Contains("Terms/Instructions"))
                {
                    row2["Terms/Instructions"] = this.objBc.SpecialDecode(row2["Terms/Instructions"].ToString());
                }
                if (item.Columns.Contains("price") && row2["price"].ToString() != "")
                {
                    row2["price"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["price"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpPercentage") && row2["MarkUpPercentage"].ToString() != "")
                {
                    row2["MarkUpPercentage"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpPercentage"].ToString()), 2, "", false, false, true);
                }
                if (item.Columns.Contains("MarkUpValue") && row2["MarkUpValue"].ToString() != "")
                {
                    row2["MarkUpValue"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["MarkUpValue"].ToString()), 2, "", false, false, true);
                }
                if (!item.Columns.Contains("SellingPrice") || !(row2["SellingPrice"].ToString() != ""))
                {
                    continue;
                }
                row2["SellingPrice"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["SellingPrice"].ToString()), 2, "", false, false, true);
            }
            this.grid_reports_byreportid_product.DataSource = item;
        }

        protected void GridProductReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
        }

        protected void GridProductReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                DataTable item = this.Session["prodreport_systemen_stockusage_quarterlysales"] as DataTable;
                for (int i = 0; i < item.Columns.Count; i++)
                {
                    item.Columns[i].ReadOnly = false;
                }
                if (item != null)
                {
                    foreach (DataRow row in item.Rows)
                    {
                        if (row.Table.Columns.Contains("Category"))
                        {
                            row["Category"] = this.objBase.SpecialDecode(row["Category"].ToString());
                        }
                        if (row.Table.Columns.Contains("CustomerCode"))
                        {
                            row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                        }
                        if (row.Table.Columns.Contains("ItemTitle"))
                        {
                            row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                        }
                        if (row.Table.Columns.Contains("ProductDescription"))
                        {
                            row["ProductDescription"] = this.objBase.SpecialDecode(row["ProductDescription"].ToString());
                        }
                        if (!row.Table.Columns.Contains("Supplier"))
                        {
                            continue;
                        }
                        row["Supplier"] = this.objBase.SpecialDecode(row["Supplier"].ToString());
                    }
                }
                //this.GridProductReport_quarterlysales.DataSource = item;
                this.exportToXlsx(item, this.GridProductReport_quarterlysales.ExportSettings.FileName.ToString());

            }
            catch
            {
            }
        }
        protected void GridStockUsage_PacksReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                DataTable item = this.Session["system_stockusage_costprice"] as DataTable;
                for (int i = 0; i < item.Columns.Count; i++)
                {
                    item.Columns[i].ReadOnly = false;
                }
                this.exportToXlsx(item, this.RadStockUsage_Packs.ExportSettings.FileName.ToString());

            }
            catch(Exception ex)
            {
            }
        }

        protected void GridStockUsageHistoryReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                DataTable item = this.Session["system_StockUsageHistoryReport"] as DataTable;
                for (int i = 0; i < item.Columns.Count; i++)
                {
                    item.Columns[i].ReadOnly = false;
                }
                this.exportToXlsx(item, this.RadGrid_StockUsageHistoryReport.ExportSettings.FileName.ToString());

            }
            catch (Exception ex)
            {
            }
        }

        protected void lnkBtnClearFilter_Click(object sender, EventArgs e)
        {
            string d = ((LinkButton)sender).ID;
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            if (d == "LinkButton1_jobproductsales")
            {
                foreach (GridColumn column in this.RadGrid_CustomerJobReport.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression = string.Empty;
                this.RadGridJobCustomerReport(this.CompanyID);
                this.RadGrid_CustomerJobReport.MasterTableView.Rebind();
            }
            else if (d == "lnkBtnClearFilter_salesorder")
            {
                foreach (GridColumn empty in this.RadGridReports_salesorderreport.MasterTableView.Columns)
                {
                    empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty.CurrentFilterValue = string.Empty;
                }
                this.RadGridReports_salesorderreport.MasterTableView.FilterExpression = string.Empty;
                this.RadGridJobReport(this.CompanyID);
                this.RadGridReports_salesorderreport.MasterTableView.Rebind();
            }
            if (d == "LinkButton1_stockusage1")
            {
                this.RadStockUsage_Packs_stockusagereport.MasterTableView.FilterExpression = string.Empty;
                this.Session["checkfilter"] = "clear";
                foreach (GridColumn gridColumn in this.RadStockUsage_Packs_stockusagereport.MasterTableView.Columns)
                {
                    gridColumn.CurrentFilterValue = string.Empty;
                }
                this.RadGridstockUsageReportInPacks(this.CompanyID);
                this.RadStockUsage_Packs_stockusagereport.MasterTableView.Rebind();
                return;
            }
            if (d == "LinkButton1_bymonthyear")
            {
                this.Session["checkfilter"] = "clear";
                foreach (GridColumn column1 in this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.Columns)
                {
                    column1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column1.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.FilterExpression = string.Empty;
                this.RadGridstockUsageReport_bymonthandyear(this.CompanyID);
                this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.Rebind();
                return;
            }
            if (d == "LinkButton1filter_adjustment")
            {
                this.Session["checkfilter"] = "clear";
                foreach (GridColumn empty1 in this.RadGridProductReport_Customer_stockadjustment.MasterTableView.Columns)
                {
                    empty1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty1.CurrentFilterValue = string.Empty;
                }
                this.RadGridProductReport_Customer_stockadjustment.MasterTableView.FilterExpression = string.Empty;
                this.RadGridProductCustomerReport_stockreleaseandadjustment(this.CompanyID);
                this.RadGridProductReport_Customer_stockadjustment.MasterTableView.Rebind();
                return;
            }
            if (d == "lnkBtnClearFilter_quarterlysales")
            {
                this.Session["checkfilter"] = "clear";
                foreach (GridColumn gridColumn1 in this.GridProductReport_quarterlysales.MasterTableView.Columns)
                {
                    this.FromDate = this.hdnProductFormDate.Value;
                    this.ToDate = this.hdnProductToDate.Value;
                    gridColumn1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    gridColumn1.CurrentFilterValue = string.Empty;
                }
                this.GridProductReport_quarterlysales.MasterTableView.FilterExpression = string.Empty;
                this.RadGridProductReport_stockreportwithquarter_sales(this.CompanyID);
                this.GridProductReport_quarterlysales.MasterTableView.Rebind();
                return;
            }
            if (d == "LinkButton1filter_stockallocatedreport")
            {
                this.Session["checkfilter"] = "clear";
                foreach (GridColumn column2 in this.RadGrid_stockallocatedcsutomer_new.MasterTableView.Columns)
                {
                    column2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column2.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_stockallocatedcsutomer_new.MasterTableView.FilterExpression = string.Empty;
                this.RadGridProductCustomerReport_stock_allocatedcustomer(this.CompanyID);
                this.RadGrid_stockallocatedcsutomer_new.MasterTableView.Rebind();
                return;
            }
            if (d == "LinkButton1_order")
            {
                foreach (GridColumn empty2 in this.RadGrid_Order_Report.MasterTableView.Columns)
                {
                    this.hdnOrderFromdate.Value = dateTime[0].ToString();
                    this.hdnOrderTodate.Value = dateTime[1].ToString();
                    empty2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty2.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_Order_Report.MasterTableView.CurrentPageIndex = 0;
                this.RadGrid_Order_Report.MasterTableView.FilterExpression = string.Empty;
                this.hdnisstockItem.Value = "";
                this.hdnisreplinsh.Value = "";
                this.hdnOrderClientID.Value = "";
                this.RadGridoredrReport(this.CompanyID);
                this.RadGrid_Order_Report.Rebind();
            }
            if (d == "lnkBtnClearFilter_stockusagehistory")
            {
                foreach (GridColumn column in this.RadGrid_StockUsageHistoryReport.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_StockUsageHistoryReport.MasterTableView.FilterExpression = string.Empty;
                this.RadGridstockUsageHistoryReport(this.CompanyID);
                this.RadGrid_StockUsageHistoryReport.MasterTableView.Rebind();
            }

            if (d == "lnkBtnClearFilter_StockUsage_Packs")
            {
                foreach (GridColumn column in this.RadStockUsage_Packs.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.RadStockUsage_Packs.MasterTableView.FilterExpression = string.Empty;
                this.RadGridstockUsageReportInPacks_cost(this.CompanyID);
                this.RadStockUsage_Packs.MasterTableView.Rebind();
            }
        }

        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            GridItemType[] gridItemTypeArray;
            GridItem[] items;
            int i;
            string d = ((LinkButton)sender).ID;
            this.div_Reports_Names.Attributes.Add("style", "display:none;");
            if (d == "export_productsales")
            {
                GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
                gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                items = masterTableView.GetItems(gridItemTypeArray);
                for (i = 0; i < (int)items.Length; i++)
                {
                    ((GridFilteringItem)items[i]).Visible = false;
                }
                this.RadGrid_CustomerJobReport.ExportSettings.FileName = "Product Sales_Report";
                this.RadGrid_CustomerJobReport.ExportSettings.HideStructureColumns = false;
                this.RadGrid_CustomerJobReport.ExportSettings.IgnorePaging = true;
                this.RadGrid_CustomerJobReport.MasterTableView.GridLines = GridLines.Both;
                if (this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression == "")
                {
                    this.RadGrid_CustomerJobReport.MasterTableView.AllowFilteringByColumn = false;
                    this.RadGrid_CustomerJobReport.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadGrid_CustomerJobReport.ExportSettings.IgnorePaging = false;
                    this.RadGrid_CustomerJobReport.MasterTableView.AllowFilteringByColumn = true;
                }
                foreach (GridColumn column in this.RadGrid_CustomerJobReport.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_CustomerJobReport.ExportSettings.ExportOnlyData = true;
                this.RadGrid_CustomerJobReport.ExportSettings.HideStructureColumns = true;
                this.RadGrid_CustomerJobReport.MasterTableView.ExportToExcel();
            }
            else if (d == "export_salesorder")
            {
                GridItem[] gridItemArray = this.RadGridReports_salesorderreport.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int j = 0; j < (int)gridItemArray.Length; j++)
                {
                    ((GridFilteringItem)gridItemArray[j]).Visible = false;
                }
                this.RadGridReports_salesorderreport.ExportSettings.FileName = "Sales/order_Report";
                this.RadGridReports_salesorderreport.ExportSettings.IgnorePaging = true;
                this.RadGridReports_salesorderreport.MasterTableView.GridLines = GridLines.Both;
                if (this.RadGridReports_salesorderreport.MasterTableView.FilterExpression == "")
                {
                    this.RadGridReports_salesorderreport.MasterTableView.AllowFilteringByColumn = false;
                    this.RadGridReports_salesorderreport.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadGridReports_salesorderreport.ExportSettings.IgnorePaging = false;
                    this.RadGridReports_salesorderreport.MasterTableView.AllowFilteringByColumn = true;
                }
                this.RadGridReports_salesorderreport.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn empty in this.RadGridReports_salesorderreport.MasterTableView.Columns)
                {
                    empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty.CurrentFilterValue = string.Empty;
                }
                this.RadGridReports_salesorderreport.MasterTableView.ExportToExcel();
            }
            if (d == "export_stockusage")
            {
                GridItem[] items1 = this.RadStockUsage_Packs_stockusagereport.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int k = 0; k < (int)items1.Length; k++)
                {
                    ((GridFilteringItem)items1[k]).Visible = false;
                }
                this.RadStockUsage_Packs_stockusagereport.ExportSettings.FileName = "Stock Products_Report";
                if (this.RadStockUsage_Packs_stockusagereport.MasterTableView.FilterExpression == "")
                {
                    this.RadStockUsage_Packs_stockusagereport.MasterTableView.AllowFilteringByColumn = false;
                    this.RadStockUsage_Packs_stockusagereport.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadStockUsage_Packs_stockusagereport.ExportSettings.IgnorePaging = false;
                    this.RadStockUsage_Packs_stockusagereport.MasterTableView.AllowFilteringByColumn = true;
                }
                this.RadStockUsage_Packs_stockusagereport.MasterTableView.GridLines = GridLines.Both;
                this.RadStockUsage_Packs_stockusagereport.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn gridColumn in this.RadStockUsage_Packs_stockusagereport.MasterTableView.Columns)
                {
                    gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    gridColumn.CurrentFilterValue = string.Empty;
                }
                this.RadStockUsage_Packs_stockusagereport.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                this.RadStockUsage_Packs_stockusagereport.MasterTableView.ExportToExcel();
            }
            else if (d == "export_bymonthandyear")
            {
                GridItem[] gridItemArray1 = this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int l = 0; l < (int)gridItemArray1.Length; l++)
                {
                    ((GridFilteringItem)gridItemArray1[l]).Visible = false;
                }
                this.RadGrid_StockUsageReport_bymonthandyear.ExportSettings.FileName = "Stock_Usage_Report";
                if (this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.FilterExpression == "")
                {
                    this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.AllowFilteringByColumn = false;
                    this.RadGrid_StockUsageReport_bymonthandyear.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadGrid_StockUsageReport_bymonthandyear.ExportSettings.IgnorePaging = false;
                    this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.AllowFilteringByColumn = true;
                }
                this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.GridLines = GridLines.Both;
                this.RadGrid_StockUsageReport_bymonthandyear.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn column1 in this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.Columns)
                {
                    column1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column1.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_StockUsageReport_bymonthandyear.Rebind();
                this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                this.RadGrid_StockUsageReport_bymonthandyear.MasterTableView.ExportToExcel();
            }
            else if (d == "export_stock_adjustment")
            {
                GridItem[] items2 = this.RadGridProductReport_Customer_stockadjustment.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int m = 0; m < (int)items2.Length; m++)
                {
                    ((GridFilteringItem)items2[m]).Visible = false;
                }
                this.RadGridProductReport_Customer_stockadjustment.ExportSettings.FileName = "Stock_Usage_Report_InPacks";
                if (this.RadGridProductReport_Customer_stockadjustment.MasterTableView.FilterExpression == "")
                {
                    this.RadGridProductReport_Customer_stockadjustment.MasterTableView.AllowFilteringByColumn = false;
                    this.RadGridProductReport_Customer_stockadjustment.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadGridProductReport_Customer_stockadjustment.ExportSettings.IgnorePaging = false;
                    this.RadGridProductReport_Customer_stockadjustment.MasterTableView.AllowFilteringByColumn = true;
                }
                foreach (GridColumn empty1 in this.RadGridProductReport_Customer_stockadjustment.MasterTableView.Columns)
                {
                    empty1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty1.CurrentFilterValue = string.Empty;
                }
                this.RadGridProductReport_Customer_stockadjustment.MasterTableView.GridLines = GridLines.Both;
                this.RadGridProductReport_Customer_stockadjustment.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn gridColumn1 in this.RadGridProductReport_Customer_stockadjustment.MasterTableView.Columns)
                {
                    gridColumn1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    gridColumn1.CurrentFilterValue = string.Empty;
                }
                this.RadGridProductReport_Customer_stockadjustment.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                this.RadGridProductReport_Customer_stockadjustment.MasterTableView.ExportToExcel();
            }
            else if (d == "export_quarterlysales")
            {
                GridItem[] gridItemArray2 = this.GridProductReport_quarterlysales.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int n = 0; n < (int)gridItemArray2.Length; n++)
                {
                    ((GridFilteringItem)gridItemArray2[n]).Visible = false;
                }
                this.GridProductReport_quarterlysales.ExportSettings.FileName = "Product(Inventory)_Report";
                if (this.GridProductReport_quarterlysales.MasterTableView.FilterExpression == "")
                {
                    this.GridProductReport_quarterlysales.MasterTableView.AllowFilteringByColumn = false;
                    this.GridProductReport_quarterlysales.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.GridProductReport_quarterlysales.ExportSettings.IgnorePaging = false;
                    this.GridProductReport_quarterlysales.MasterTableView.AllowFilteringByColumn = true;
                }
                this.GridProductReport_quarterlysales.MasterTableView.GridLines = GridLines.Both;
                this.GridProductReport_quarterlysales.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn column2 in this.GridProductReport_quarterlysales.MasterTableView.Columns)
                {
                    column2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column2.CurrentFilterValue = string.Empty;
                }
                this.GridProductReport_quarterlysales.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                this.GridProductReport_quarterlysales.MasterTableView.ExportToExcel();
            }
            else if (d == "export_stock_allocatedreport")
            {
                items = this.RadGrid_stockallocatedcsutomer_new.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (i = 0; i < (int)items.Length; i++)
                {
                    ((GridFilteringItem)items[i]).Visible = false;
                }
                this.RadGrid_stockallocatedcsutomer_new.ExportSettings.FileName = "Stock_allocated_Report";
                if (this.RadGrid_stockallocatedcsutomer_new.MasterTableView.FilterExpression == "")
                {
                    this.RadGrid_stockallocatedcsutomer_new.MasterTableView.AllowFilteringByColumn = false;
                    this.RadGrid_stockallocatedcsutomer_new.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadGrid_stockallocatedcsutomer_new.ExportSettings.IgnorePaging = false;
                    this.RadGrid_stockallocatedcsutomer_new.MasterTableView.AllowFilteringByColumn = true;
                }
                foreach (GridColumn empty2 in this.RadGrid_stockallocatedcsutomer_new.MasterTableView.Columns)
                {
                    empty2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty2.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_stockallocatedcsutomer_new.MasterTableView.GridLines = GridLines.Both;
                this.RadGrid_stockallocatedcsutomer_new.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn gridColumn2 in this.RadGrid_stockallocatedcsutomer_new.MasterTableView.Columns)
                {
                    gridColumn2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    gridColumn2.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_stockallocatedcsutomer_new.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                this.RadGrid_stockallocatedcsutomer_new.MasterTableView.ExportToExcel();
            }
            if (d == "export_ordersystemgenerated")
            {
                GridTableView gridTableView = this.RadGrid_Order_Report.MasterTableView;
                gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                items = gridTableView.GetItems(gridItemTypeArray);
                for (i = 0; i < (int)items.Length; i++)
                {
                    ((GridFilteringItem)items[i]).Visible = false;
                }
                this.RadGrid_Order_Report.ExportSettings.FileName = "Order_Details";
                if (this.RadGrid_Order_Report.MasterTableView.FilterExpression == "")
                {
                    this.RadGrid_Order_Report.MasterTableView.AllowFilteringByColumn = false;
                    this.RadGrid_Order_Report.ExportSettings.IgnorePaging = true;
                }
                else
                {
                    this.RadGrid_Order_Report.ExportSettings.IgnorePaging = false;
                    this.RadGrid_Order_Report.MasterTableView.AllowFilteringByColumn = true;
                }
                this.RadGrid_Order_Report.MasterTableView.GridLines = GridLines.Both;
                this.RadGrid_Order_Report.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn column3 in this.RadGrid_Order_Report.MasterTableView.Columns)
                {
                    column3.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column3.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_Order_Report.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                this.RadGrid_Order_Report.MasterTableView.ExportToExcel();
            }

            if (d == "export_stockusagehistory")
            {
                GridItem[] items3 = this.RadGrid_StockUsageHistoryReport.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int k = 0; k < (int)items3.Length; k++)
                {
                    ((GridFilteringItem)items3[k]).Visible = false;
                }
                this.RadGrid_StockUsageHistoryReport.ExportSettings.FileName = "Stock Usage History Report";
                if (this.RadGrid_StockUsageHistoryReport.MasterTableView.FilterExpression == "")
                {
                    this.RadGrid_StockUsageHistoryReport.ExportSettings.IgnorePaging = true;
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.AllowFilteringByColumn = false;
                }
                else
                {
                    this.RadGrid_StockUsageHistoryReport.ExportSettings.IgnorePaging = false;
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.AllowFilteringByColumn = true;
                }
                this.RadGrid_StockUsageHistoryReport.MasterTableView.GridLines = GridLines.Both;
                this.RadGrid_StockUsageHistoryReport.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn gridColumn in this.RadGrid_StockUsageHistoryReport.MasterTableView.Columns)
                {
                    gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    //gridColumn.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_StockUsageHistoryReport.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                try
                {
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.ExportToExcel();

                }
                catch (Exception ex)
                {

                    throw ex;
                }            
            }

            if (d == "export_StockUsage_Packs")
            {
                GridItem[] items4 = this.RadStockUsage_Packs.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                for (int k = 0; k < (int)items4.Length; k++)
                {
                    ((GridFilteringItem)items4[k]).Visible = false;
                }
                this.RadStockUsage_Packs.ExportSettings.FileName = "Stock_Usage_Cost_Price_Report";
                if (this.RadStockUsage_Packs.MasterTableView.FilterExpression == "")
                {
                    this.RadStockUsage_Packs.ExportSettings.IgnorePaging = true;
                    this.RadStockUsage_Packs.MasterTableView.AllowFilteringByColumn = false;
                }
                else
                {
                    this.RadStockUsage_Packs.ExportSettings.IgnorePaging = false;
                    this.RadStockUsage_Packs.MasterTableView.AllowFilteringByColumn = true;
                }
                this.RadStockUsage_Packs.MasterTableView.GridLines = GridLines.Both;
                this.RadStockUsage_Packs.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn gridColumn in this.RadStockUsage_Packs.MasterTableView.Columns)
                {
                    gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    //gridColumn.CurrentFilterValue = string.Empty;
                }
                this.RadStockUsage_Packs.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                try
                {
                    this.RadStockUsage_Packs.MasterTableView.ExportToExcel();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }
        //protected void btnExportToExcel_Click(object sender, EventArgs e)
        //{
        //    // Hide any filtering items before export if needed
        //    GridItem[] items = RadGrid_StockUsageHistoryReport.MasterTableView.GetItems(GridItemType.FilteringItem);
        //    foreach (GridItem item in items)
        //    {
        //        item.Visible = false;
        //    }

        //    // Set export settings
        //    RadGrid_StockUsageHistoryReport.ExportSettings.FileName = "ExportedData";
        //    RadGrid_StockUsageHistoryReport.ExportSettings.IgnorePaging = true;

        //    // Export RadGrid data to Excel
        //    RadGrid_StockUsageHistoryReport.MasterTableView.ExportToExcel();

        //    // Show the filtering items again if they were hidden
        //    foreach (GridItem item in items)
        //    {
        //        item.Visible = true;
        //    }
        //}
        protected void lnkReportName_Click(object sender, EventArgs e)
        {
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            string[] strArrays = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            this.reportid = Convert.ToInt64(strArrays[0]);
            this.hdn_report_name_aftergen.Value = strArrays[1];
            string str = strArrays[1];
            this.Reports_type = strArrays[2];
            if (this.Reports_type == "" && this.reportid > (long)0)
            {
                this.Reports_type = "stock";
            }
            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "estore_reports.aspx'>Reports</a>&nbsp;>>&nbsp;&nbsp;", this.objBase.SpecialDecode(this.hdn_report_name_aftergen.Value));
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            this.hdn_reportid_afterload.Value = strArrays[0];
            if (this.Reports_type.ToLower().Contains("order"))
            {
                this.grid_reports_byreportid_invoice.Visible = false;
                this.grid_reports_byreportid_jobs.Visible = false;
                this.grid_reports_byreportid_order.Visible = true;
                this.grid_reports_byreportid_product.Visible = false;
                this.Grid_Estore_reports.Visible = false;
                if (this.reportid != (long)0)
                {
                    this.div_reportgrid.Attributes.Add("style", "display:block");
                    this.Bind_ReportsData_byReportID(this.reportid, "order", this.grid_reports_byreportid_order, dateTime[0], dateTime[1]);
                }
                else
                {
                    this.div_reportgrid.Attributes.Add("style", "display:none");
                    this.grid_reports_byreportid_order.Visible = false;
                    this.RadGrid_Order_Report.Visible = true;
                    this.div_Order_systemgen_reports.Attributes.Add("style", "display:block");
                    this.RadGridoredrReport(this.CompanyID);
                }
            }
            if (this.Reports_type.ToLower().Contains("job"))
            {
                this.grid_reports_byreportid_invoice.Visible = false;
                this.grid_reports_byreportid_jobs.Visible = true;
                this.grid_reports_byreportid_order.Visible = false;
                this.grid_reports_byreportid_product.Visible = false;
                this.Grid_Estore_reports.Visible = false;
                if (this.reportid != (long)0)
                {
                    this.div_reportgrid.Attributes.Add("style", "display:block");
                    this.Bind_ReportsData_byReportID(this.reportid, "job", this.grid_reports_byreportid_jobs, dateTime[0], dateTime[1]);
                }
                else
                {
                    this.div_reportgrid.Attributes.Add("style", "display:none");
                    this.div_job_systemgeneratedreports.Attributes.Add("style", "display:block");
                    this.grid_reports_byreportid_jobs.Visible = false;
                    if (str.ToLower().Contains("product sales report"))
                    {
                        this.jobreport_systemgenname = str;
                        this.RadGrid_CustomerJobReport.Visible = true;
                        this.RadGridJobCustomerReport(this.CompanyID);
                    }
                    else if (str.ToLower().Contains("sales/order report"))
                    {
                        this.jobreport_systemgenname = str;
                        this.RadGridReports_salesorderreport.Visible = true;
                        this.RadGridJobReport(this.CompanyID);
                    }
                }
            }
            if (this.Reports_type.ToLower().Contains("invoice"))
            {
                this.grid_reports_byreportid_invoice.Visible = true;
                this.grid_reports_byreportid_jobs.Visible = false;
                this.grid_reports_byreportid_order.Visible = false;
                this.grid_reports_byreportid_product.Visible = false;
                this.Grid_Estore_reports.Visible = false;
                this.div_reportgrid.Attributes.Add("style", "display:block");
                this.Bind_ReportsData_byReportID(this.reportid, "invoice", this.grid_reports_byreportid_invoice, dateTime[0], dateTime[1]);
            }
            if (this.Reports_type.ToLower().Contains("stock"))
            {
                this.grid_reports_byreportid_invoice.Visible = false;
                this.grid_reports_byreportid_jobs.Visible = false;
                this.grid_reports_byreportid_order.Visible = false;
                this.grid_reports_byreportid_product.Visible = true;
                this.Grid_Estore_reports.Visible = false;
                if (this.reportid != (long)0)
                {
                    this.div_reportgrid.Attributes.Add("style", "display:block");
                    this.Bind_ReportsData_byReportID(this.reportid, "product", this.grid_reports_byreportid_product, dateTime[0], dateTime[1]);
                }
                else
                {
                    this.div_reportgrid.Attributes.Add("style", "display:none");
                    this.grid_reports_byreportid_product.Visible = false;
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                    if (str.ToLower() == "stock usage report")
                    {
                        this.RadStockUsage_Packs_stockusagereport.Visible = true;
                        this.RadGridstockUsageReportInPacks(this.CompanyID);
                    }
                    if (str.ToLower().Contains("stock usage report by month and year"))
                    {
                        this.RadGrid_StockUsageReport_bymonthandyear.Visible = true;
                        this.RadGridstockUsageReport_bymonthandyear(this.CompanyID);
                    }
                    if (str.ToLower().Contains("stock release and adjustment report"))
                    {
                        this.RadGridProductReport_Customer_stockadjustment.Visible = true;
                        this.RadGridProductCustomerReport_stockreleaseandadjustment(this.CompanyID);
                    }
                    if (str.ToLower().Contains("stock report with quarterly sales"))
                    {
                        this.GridProductReport_quarterlysales.Visible = true;
                        this.RadGridProductReport_stockreportwithquarter_sales(this.CompanyID);
                    }
                }
            }
            if (this.Reports_type.ToLower() == "system" && this.reportid == (long)0)
            {
                this.div_reportgrid.Attributes.Add("style", "display:none");
                this.grid_reports_byreportid_order.Visible = false;
                this.grid_reports_byreportid_jobs.Visible = false;
                this.grid_reports_byreportid_invoice.Visible = false;
                this.grid_reports_byreportid_product.Visible = false;
                if (str == "Order Details Report")
                {
                    this.RadGrid_Order_Report.Visible = true;
                    this.div_Order_systemgen_reports.Attributes.Add("style", "display:block");
                    this.RadGridoredrReport(this.CompanyID);
                }
                if (str == "Product Sales Report")
                {
                    this.jobreport_systemgenname = str;
                    this.RadGrid_CustomerJobReport.Visible = true;
                    this.RadGridJobCustomerReport(this.CompanyID);
                    this.div_job_systemgeneratedreports.Attributes.Add("style", "display:block");
                }
                if (str == "Sales/Order Report")
                {
                    this.jobreport_systemgenname = str;
                    this.RadGridReports_salesorderreport.Visible = true;
                    this.RadGridJobReport(this.CompanyID);
                    this.div_job_systemgeneratedreports.Attributes.Add("style", "display:block");
                }
                if (str == "Stock Usage Report")
                {
                    this.RadStockUsage_Packs_stockusagereport.Visible = true;
                    this.RadGridstockUsageReportInPacks(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }
                if (str == "Stock Release and Adjustment Report")
                {
                    this.RadGridProductReport_Customer_stockadjustment.Visible = true;
                    this.RadGridProductCustomerReport_stockreleaseandadjustment(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }
                if (str == "Stock Usage Report by Month and Year")
                {
                    this.RadGrid_StockUsageReport_bymonthandyear.Visible = true;
                    this.RadGridstockUsageReport_bymonthandyear(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }
                if (str == "Stock Report with Quarterly Sales")
                {
                    this.GridProductReport_quarterlysales.Visible = true;
                    this.RadGridProductReport_stockreportwithquarter_sales(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }

                if (str == "Stock Usage Report - Cost Price")
                {
                    this.StockUsage_PacksReportFilters.Visible = true;
                    this.RadStockUsage_Packs.Visible = true;
                    this.RadGridstockUsageReportInPacks_cost(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }
                if (str == "Stock Usage Report(History)")
                {
                    this.StockUsageHistoryReportFilters.Visible = true;
                    this.RadGrid_StockUsageHistoryReport.Visible = true;
                    this.RadGridstockUsageHistoryReport(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }

                //if (str == "Stock Allocated Report")
                if (str == "Stock Allocation Report")
                {
                    this.RadGrid_stockallocatedcsutomer_new.Visible = true;
                    this.RadGridProductCustomerReport_stock_allocatedcustomer(this.CompanyID);
                    this.div_products_system_generatedreports.Attributes.Add("style", "display:block;");
                }
            }
        }
        public void RadGridstockUsageHistoryReport(int CompanyID)
        {
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }

            this.ddldepartment1.Items.Insert(0, new ListItem("-- Department Name --", ""));
            this.ddldepartment1.Items.Insert(1, new ListItem("All", "All"));
            DataTable productSelectDepartment = OrderBasePage.GetProduct_SelectDepartment(this.CompanyID, this.StoreUserID);
            for (int j = 0; j < productSelectDepartment.Columns.Count; j++)
            {
                productSelectDepartment.Columns[j].ReadOnly = false;
            }
            foreach (DataRow dataRow in productSelectDepartment.Rows)
            {
                dataRow["Deptname"] = this.objBase.SpecialDecode(dataRow["Deptname"].ToString());
            }
            this.ddldepartment1.DataSource = productSelectDepartment;
            this.ddldepartment1.DataTextField = "Deptname";
            this.ddldepartment1.DataValueField = "Deptid";
            this.ddldepartment1.DataBind();
            int num = productSelectDepartment.Rows.Count;
            this.ddldepartment1.Items.Insert(0, new ListItem("-- Department Name --", " "));
            this.ddldepartment1.Items.Insert(1, new ListItem("All", "All"));
            this.ddldepartment1.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
            this.ddldepartment1.Items.Insert(3, new ListItem("---------------------------------------", "Group"));
            //if (this.hdnDepartmentID.Value != "0" || this.hdnDepartmentID.Value != "")
            //{
            //    this.ddldepartment1.SelectedValue = this.hdnDepartmentID.Value;
            //}

            this.ddlMonthCategory1.Items.Insert(0, new ListItem("Show this Calendar Year", "CM"));
            this.ddlMonthCategory1.Items.Insert(1, new ListItem("Show by Last Financial Year", "LFM"));
            this.ddlMonthCategory1.Items.Insert(2, new ListItem("Show by Current Financial Year", "CFM"));
            this.ddlMonthCategory1.Items.Insert(3, new ListItem("Show for Last 12 Month", "LTM"));
            //this.ddlMonthCategory1.SelectedValue = this.hdnMonthCategory.Value;

            DataTable dataTable = OrderBasePage.ProductstockUsageHistoryReport((long)CompanyID, this.StoreUserID, "", "");
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Stock Code"))
                    {
                        row["Stock Code"] = this.objBase.SpecialDecode(row["Stock Code"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    row["Product Name"] = this.objBase.SpecialDecode(row["Product Name"].ToString());
                }
            }
            this.Session["system_StockUsageHistoryReport"] = dataTable;
            this.RadGrid_StockUsageHistoryReport.DataSource = dataTable;
            this.RadGrid_StockUsageHistoryReport.DataBind();
        }

        public void RadGridstockUsageReportInPacks_cost(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = OrderBasePage.GetStockUsage_InPacks_cost(this.CompanyID, this.StoreUserID, "");
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Table.Columns.Contains("ItemTitle"))
                {
                    row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                }
                if (!row.Table.Columns.Contains("ItemCode"))
                {
                    continue;
                }
                row["ItemCode"] = this.objBase.SpecialDecode(row["ItemCode"].ToString());
            }
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                if (!dataRow.Table.Columns.Contains("TotalExCCost") || dataRow["TotalExCCost"] == null)
                {
                    continue;
                }
                this.hdnTotalcost.Value = dataRow["TotalExCCost"].ToString();
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalExCCost"]), 0, "", false, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.Session["system_stockusage_costprice"] = dataTable;
            this.RadStockUsage_Packs.DataSource = dataTable;
            this.RadStockUsage_Packs.DataBind();
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            string deptID = this.ddldepartment1.SelectedValue;
            string monthCatagory = this.ddlMonthCategory1.SelectedValue;

            DataTable dataTable = OrderBasePage.ProductstockUsageHistoryReport((long)CompanyID, this.StoreUserID, deptID, monthCatagory);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Stock Code"))
                    {
                        row["Stock Code"] = this.objBase.SpecialDecode(row["Stock Code"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    row["Product Name"] = this.objBase.SpecialDecode(row["Product Name"].ToString());
                }
            }
            this.RadGrid_StockUsageHistoryReport.DataSource = dataTable;
            this.RadGrid_StockUsageHistoryReport.DataBind();
        }

        protected void RadGrid_StockUsageHistoryReport_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                string filterItemcode = string.Empty;
                string filterItemTitle = string.Empty;
                string filterMonthOnList = string.Empty;
                string filterQuantityonHand = string.Empty;
                string filterAllocatedStock = string.Empty;
                string filterAvailableStock = string.Empty;
                string filterStockOnBackOrder = string.Empty;
                string filterStockSalesValue = string.Empty;
                string filterUOI = string.Empty;
                string filterAvgMonthUsage = string.Empty;
                string filterMonthOver = string.Empty;
                string filterTotalSales = string.Empty;
                string filterJanuary = string.Empty;
                string filterFebruary = string.Empty;
                string filterMarch = string.Empty;
                string filterApril = string.Empty;
                string filterMay = string.Empty;
                string filterJune = string.Empty;
                string filterJuly = string.Empty;
                string filterAugust = string.Empty;
                string filterSeptember = string.Empty;
                string filterOctober = string.Empty;
                string filterNovember = string.Empty;
                string filterDecember = string.Empty;

                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem filterItem = (GridFilteringItem)e.Item;
                    TextBox ItemCode = (TextBox)filterItem["Item Code"].Controls[0];
                    filterItemcode = ItemCode.Text;

                    TextBox ItemTitle = (TextBox)filterItem["Item Title"].Controls[0];
                    filterItemTitle = ItemTitle.Text;

                    TextBox MonthOnList = (TextBox)filterItem["Month On List"].Controls[0];
                    filterMonthOnList = MonthOnList.Text;
                    TextBox QuantityonHand = (TextBox)filterItem["Quantity on Hand"].Controls[0];
                    filterQuantityonHand = QuantityonHand.Text;
                    TextBox AllocatedStock = (TextBox)filterItem["Allocated Stock"].Controls[0];
                    filterAllocatedStock = AllocatedStock.Text;
                    TextBox AvailableStock = (TextBox)filterItem["Available Stock"].Controls[0];
                    filterAvailableStock = AvailableStock.Text;
                    TextBox StockOnBackOrder = (TextBox)filterItem["StockOnBackOrder"].Controls[0];
                    filterStockOnBackOrder = StockOnBackOrder.Text;
                    TextBox StockSalesValue = (TextBox)filterItem["Stock Sales Value"].Controls[0];
                    filterStockSalesValue = StockSalesValue.Text;
                    TextBox UOI = (TextBox)filterItem["UOI"].Controls[0];
                    filterUOI = UOI.Text;
                    TextBox AvgMonthUsage = (TextBox)filterItem["Avg Month Usage"].Controls[0];
                    filterAvgMonthUsage = AvgMonthUsage.Text;
                    TextBox MonthOver = (TextBox)filterItem["Month Over"].Controls[0];
                    filterMonthOver = MonthOver.Text;
                    TextBox TotalSales = (TextBox)filterItem["Total Sales"].Controls[0];
                    filterTotalSales = TotalSales.Text;
                    TextBox January = (TextBox)filterItem["January"].Controls[0];
                    filterJanuary = January.Text;
                    TextBox February = (TextBox)filterItem["February"].Controls[0];
                    filterFebruary = February.Text;
                    TextBox March = (TextBox)filterItem["March"].Controls[0];
                    filterMarch = March.Text;
                    TextBox April = (TextBox)filterItem["April"].Controls[0];
                    filterApril = April.Text;
                    TextBox May = (TextBox)filterItem["May"].Controls[0];
                    filterMay = May.Text;
                    TextBox June = (TextBox)filterItem["June"].Controls[0];
                    filterJune = June.Text;
                    TextBox July = (TextBox)filterItem["July"].Controls[0];
                    filterJuly = July.Text;
                    TextBox August = (TextBox)filterItem["August"].Controls[0];
                    filterAugust = August.Text;
                    TextBox September = (TextBox)filterItem["September"].Controls[0];
                    filterSeptember = September.Text;
                    TextBox October = (TextBox)filterItem["October"].Controls[0];
                    filterOctober = October.Text;
                    TextBox November = (TextBox)filterItem["November"].Controls[0];
                    filterNovember = November.Text;
                  
                    TextBox December = (TextBox)filterItem["December"].Controls[0];
                    filterDecember = December.Text;
                }

                // Apply the filter to your data source
                // For example, if you have a DataTable as your data source
               

                string deptID = this.ddldepartment1.SelectedValue;
                string monthCatagory = this.ddlMonthCategory1.SelectedValue;

                DataTable dataTable = OrderBasePage.ProductstockUsageHistoryReport((long)CompanyID, this.StoreUserID, deptID, monthCatagory);
                //this.RadGrid_StockUsageHistoryReport.DataSource = dataTable;
                //this.RadGrid_StockUsageHistoryReport.DataBind();

                DataTable dt = dataTable;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    if(!string.IsNullOrEmpty(filterItemcode))
                    {
                        dv.RowFilter = string.Format("[Item Code] LIKE '%{0}%'",filterItemcode); 
                    }
                    if (!string.IsNullOrEmpty(filterItemTitle))
                    {
                        dv.RowFilter = string.Format("[Item Title] LIKE '%{0}%'", filterItemTitle);
                    }
                    if (!string.IsNullOrEmpty(filterMonthOnList))
                    {
                        dv.RowFilter = string.Format("[Month On List] = {0}", filterMonthOnList.ToString());
                    }
                    if (!string.IsNullOrEmpty(filterQuantityonHand))
                    {
                        dv.RowFilter = string.Format("[Quantity on Hand] = {0}", filterQuantityonHand);
                    }
                    if (!string.IsNullOrEmpty(filterAllocatedStock))
                    {
                        dv.RowFilter = string.Format("[Allocated Stock] = {0}", filterAllocatedStock);
                    }
                    if (!string.IsNullOrEmpty(filterAvailableStock))
                    {
                        dv.RowFilter = string.Format("[Available Stock] = {0}", filterAvailableStock);
                    }
                    if (!string.IsNullOrEmpty(filterStockOnBackOrder))
                    {
                        dv.RowFilter = string.Format("[StockOnBackOrder] = {0}", filterStockOnBackOrder);
                    }
                    if (!string.IsNullOrEmpty(filterStockSalesValue))
                    {
                        dv.RowFilter = string.Format("[Stock Sales Value] = {0}", filterStockSalesValue);
                    }
                    if (!string.IsNullOrEmpty(filterUOI))
                    {
                        dv.RowFilter = string.Format("[UOI] = {0}", filterUOI);
                    }
                    if (!string.IsNullOrEmpty(filterAvgMonthUsage))
                    {
                        dv.RowFilter = string.Format("[Avg Month Usage] = {0}", filterAvgMonthUsage);
                    }
                    if (!string.IsNullOrEmpty(filterMonthOver))
                    {
                        dv.RowFilter = string.Format("[Month Over] = {0}", filterMonthOver);
                    }
                    if (!string.IsNullOrEmpty(filterTotalSales))
                    {
                        dv.RowFilter = string.Format("[Total Sales] = {0}", filterTotalSales);
                    }
                    if (!string.IsNullOrEmpty(filterJanuary))
                    {
                        dv.RowFilter = string.Format("[January] = {0}", filterJanuary);
                    }
                    if (!string.IsNullOrEmpty(filterFebruary))
                    {
                        dv.RowFilter = string.Format("[February] = {0}", filterFebruary);
                    }
                    if (!string.IsNullOrEmpty(filterMarch))
                    {
                        dv.RowFilter = string.Format("[March] = {0}", filterMarch);
                    }
                    if (!string.IsNullOrEmpty(filterApril))
                    {
                        dv.RowFilter = string.Format("[April] = {0}", filterApril);
                    }
                    if (!string.IsNullOrEmpty(filterMay))
                    {
                        dv.RowFilter = string.Format("[May] = {0}", filterMay);
                    }
                    if (!string.IsNullOrEmpty(filterJune))
                    {
                        dv.RowFilter = string.Format("[June] = {0}", filterJune);
                    }
                    if (!string.IsNullOrEmpty(filterJuly))
                    {
                        dv.RowFilter = string.Format("[July] = {0}", filterJuly);
                    }
                    if (!string.IsNullOrEmpty(filterAugust))
                    {
                        dv.RowFilter = string.Format("[August] = {0}", filterAugust);
                    }
                    if (!string.IsNullOrEmpty(filterSeptember))
                    {
                        dv.RowFilter = string.Format("[September] = {0}", filterSeptember);
                    }
                    if (!string.IsNullOrEmpty(filterOctober))
                    {
                        dv.RowFilter = string.Format("[October] = {0}", filterOctober);
                    }
                    if (!string.IsNullOrEmpty(filterNovember))
                    {
                        dv.RowFilter = string.Format("[November] = {0}", filterNovember);
                    }
                    if (!string.IsNullOrEmpty(filterDecember))
                    {
                        dv.RowFilter = string.Format("[December] = {0}", filterDecember);
                    }

                    RadGrid_StockUsageHistoryReport.DataSource = dv;
                    RadGrid_StockUsageHistoryReport.DataBind();
                }
            }


        }

        protected void RadGrid_RadStockUsage_Packs_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                string filterItemcode = string.Empty;
                string filterItemTitle = string.Empty;
                string filterUOI = string.Empty;
                string filterQuantityonHand = string.Empty;
                string filterAllocatedStock = string.Empty;
                string filterAvailableStock = string.Empty;
                string filterStockOnBackOrder = string.Empty;
                string filterCostPerPack = string.Empty;
                string filterBackOrderValue = string.Empty;
                string filterCostValue = string.Empty;

                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem filterItem = (GridFilteringItem)e.Item;
                    TextBox ItemCode = (TextBox)filterItem["ItemCode"].Controls[0];
                    filterItemcode = ItemCode.Text;

                    TextBox ItemTitle = (TextBox)filterItem["ItemTitle"].Controls[0];
                    filterItemTitle = ItemTitle.Text;

                    TextBox QuantityonHand = (TextBox)filterItem["QuantityOnHand"].Controls[0];
                    filterQuantityonHand = QuantityonHand.Text;
                    TextBox AllocatedStock = (TextBox)filterItem["AllocatedStock"].Controls[0];
                    filterAllocatedStock = AllocatedStock.Text;
                    TextBox AvailableStock = (TextBox)filterItem["AvailableStock"].Controls[0];
                    filterAvailableStock = AvailableStock.Text;
                    TextBox StockOnBackOrder = (TextBox)filterItem["StockOnBackOrder"].Controls[0];
                    filterStockOnBackOrder = StockOnBackOrder.Text;
                    TextBox CostPerPack = (TextBox)filterItem["CostPerPack"].Controls[0];
                    filterCostPerPack = CostPerPack.Text;
                    TextBox UOI = (TextBox)filterItem["SoldInPacksOf"].Controls[0];
                    filterUOI = UOI.Text;
                    TextBox BackOrderValue = (TextBox)filterItem["BackOrderValue"].Controls[0];
                    filterBackOrderValue = BackOrderValue.Text;
                    TextBox CostValue = (TextBox)filterItem["CostQuantityOnBackOrder"].Controls[0];
                    filterCostValue = CostValue.Text;

                }

                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.productreport_stockusage((long)this.CompanyID, this.StoreUserID);
                DataTable dataTable = new DataTable();
                dataTable = dataSet.Tables[0];

                DataTable dt = dataTable;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    if (!string.IsNullOrEmpty(filterItemcode))
                    {
                        dv.RowFilter = string.Format("[ItemCode] LIKE '%{0}%'", filterItemcode);
                    }
                    if (!string.IsNullOrEmpty(filterItemTitle))
                    {
                        dv.RowFilter = string.Format("[ItemTitle] LIKE '%{0}%'", filterItemTitle);
                    }
                    if (!string.IsNullOrEmpty(filterQuantityonHand))
                    {
                        dv.RowFilter = string.Format("[QuantityOnHand] = {0}", filterQuantityonHand);
                    }
                    if (!string.IsNullOrEmpty(filterAllocatedStock))
                    {
                        dv.RowFilter = string.Format("[AllocatedStock] = {0}", filterAllocatedStock);
                    }
                    if (!string.IsNullOrEmpty(filterAvailableStock))
                    {
                        dv.RowFilter = string.Format("[AvailableStock] = {0}", filterAvailableStock);
                    }
                    if (!string.IsNullOrEmpty(filterStockOnBackOrder))
                    {
                        dv.RowFilter = string.Format("[StockOnBackOrder] = {0}", filterStockOnBackOrder);
                    }
                    if (!string.IsNullOrEmpty(filterUOI))
                    {
                        dv.RowFilter = string.Format("[SoldInPacksOf] = {0}", filterUOI);
                    }

                    if (!string.IsNullOrEmpty(filterCostPerPack))
                    {
                        dv.RowFilter = string.Format("[CostPerPack] = {0}", filterCostPerPack);
                    }
                    if (!string.IsNullOrEmpty(filterStockOnBackOrder))
                    {
                        dv.RowFilter = string.Format("[BackOrderValue] = {0}", filterBackOrderValue);
                    }
                    if (!string.IsNullOrEmpty(filterCostValue))
                    {
                        dv.RowFilter = string.Format("[CostQuantityOnBackOrder] = {0}", filterCostValue);
                    }

                    RadStockUsage_Packs.DataSource = dv;
                    RadStockUsage_Packs.DataBind();
                }
            }


        }

        protected void RadGrid_StockUsageHistoryReport_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem filterItem = (GridFilteringItem)e.Item;
                LinkButton filterButton = (LinkButton)filterItem.FindControl("FilterButton");
                if (filterButton != null)
                {
                    filterButton.Attributes.Add("style", "display:none");
                }
            }
        }
        //protected void RadGrid_StockUsageHistoryReport_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    try
        //    {
        //        this.RadGrid_StockUsageHistoryReport.Style.Add("width", "1980px");
        //        DataTable dataTable = OrderBasePage.settings_regionalsettings_select(this.CompanyID);
        //        DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
        //        DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
        //        DateTime.Now.AddMonths(-12);
        //        dateTime.AddYears(-1);
        //        dateTime1.AddYears(-1);
        //        DropDownList value = (DropDownList)e.Item.FindControl("ddlCustomerName");
        //        DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddldepartment1");
        //        DropDownList value1 = (DropDownList)e.Item.FindControl("ddlMonthCategory");
        //        Label label = (Label)e.Item.FindControl("lblMonthHeading");
        //        if (label != null)
        //        {
        //            if (this.hdnMonthCategory.Value.ToString() == "CM" || this.hdnMonthCategory.Value == "")
        //            {
        //                label.Text = " Calendar year sales (Allocations)";
        //            }
        //            else if (this.hdnMonthCategory.Value.ToString() == "LFM")
        //            {
        //                label.Text = " Last financial year sales (Allocations)";
        //            }
        //            else if (this.hdnMonthCategory.Value.ToString() == "CFM")
        //            {
        //                label.Text = " Current financial year sales (Allocations)";
        //            }
        //            else if (this.hdnMonthCategory.Value.ToString() == "LTM")
        //            {
        //                label.Text = "Last twelve month sales (Allocations)";
        //            }
        //        }
        //        if (dropDownList != null)
        //        {
        //            dropDownList.Items.Insert(0, new ListItem("-- Department Name --", ""));
        //            dropDownList.Items.Insert(1, new ListItem("All", "All"));
        //            DataTable productSelectDepartment = OrderBasePage.GetProduct_SelectDepartment(this.CompanyID, this.StoreUserID);
        //            for (int j = 0; j < productSelectDepartment.Columns.Count; j++)
        //            {
        //                productSelectDepartment.Columns[j].ReadOnly = false;
        //            }
        //            foreach (DataRow dataRow in productSelectDepartment.Rows)
        //            {
        //                dataRow["Deptname"] = this.objBase.SpecialDecode(dataRow["Deptname"].ToString());
        //            }
        //            dropDownList.DataSource = productSelectDepartment;
        //            dropDownList.DataTextField = "Deptname";
        //            dropDownList.DataValueField = "Deptid";
        //            dropDownList.DataBind();
        //            int num = productSelectDepartment.Rows.Count;
        //            dropDownList.Items.Insert(0, new ListItem("-- Department Name --", " "));
        //            dropDownList.Items.Insert(1, new ListItem("All", "All"));
        //            dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
        //            dropDownList.Items.Insert(3, new ListItem("---------------------------------------", "Group"));
        //            if (this.hdnDepartmentID.Value != "0" || this.hdnDepartmentID.Value != "")
        //            {
        //                dropDownList.SelectedValue = this.hdnDepartmentID.Value;
        //            }
        //        }
        //        if (value1 != null)
        //        {
        //            value1.Items.Insert(0, new ListItem("Show this Calendar Year", "CM"));
        //            value1.Items.Insert(1, new ListItem("Show by Last Financial Year", "LFM"));
        //            value1.Items.Insert(2, new ListItem("Show by Current Financial Year", "CFM"));
        //            value1.Items.Insert(3, new ListItem("Show for Last 12 Month", "LTM"));
        //            value1.SelectedValue = this.hdnMonthCategory.Value;
        //        }
        //        GridColumn[] renderColumns = e.Item.OwnerTableView.RenderColumns;
        //        for (int k = 0; k < (int)renderColumns.Length; k++)
        //        {
        //            GridColumn empty = renderColumns[k];
        //            empty.AutoPostBackOnFilter = true;
        //            if (empty.UniqueName == "January" || empty.UniqueName == "February" || empty.UniqueName == "March" || empty.UniqueName == "April" || empty.UniqueName == "May" || empty.UniqueName == "June" || empty.UniqueName == "July" || empty.UniqueName == "August" || empty.UniqueName == "September" || empty.UniqueName == "October" || empty.UniqueName == "November" || empty.UniqueName == "December" || empty.UniqueName == "UOI" || empty.UniqueName == "Total Sales")
        //            {
        //                empty.FilterControlWidth = Unit.Pixel(40);
        //            }
        //            else if (empty.UniqueName == "Item Title")
        //            {
        //                empty.HeaderStyle.Width = Unit.Pixel(500);
        //                empty.FilterControlWidth = Unit.Pixel(170);
        //            }
        //            else if (empty.UniqueName == "Stock Sales Value" || empty.UniqueName == "Avg Month Usage" || empty.UniqueName == "Month Over")
        //            {
        //                empty.HeaderStyle.Wrap = false;
        //                empty.HeaderStyle.Width = Unit.Pixel(300);
        //                empty.FilterControlWidth = Unit.Pixel(40);
        //            }
        //            else if (empty.UniqueName == "Month On List")
        //            {
        //                empty.FilterControlWidth = Unit.Pixel(40);
        //                empty.HeaderText = "Month on List";
        //            }
        //            else if (empty.UniqueName == "Quantity on Hand")
        //            {
        //                empty.FilterControlWidth = Unit.Pixel(40);
        //                empty.HeaderText = "Quantity on Hand";
        //            }
        //            else if (empty.UniqueName == "DeptID" || empty.UniqueName == "DeptName" || empty.UniqueName == "DeptId")
        //            {
        //                empty.Visible = false;
        //            }
        //            if (base.Session["checkfilter"] != null && base.Session["checkfilter"] == null)
        //            {
        //                empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
        //                empty.CurrentFilterValue = string.Empty;
        //            }
        //        }
        //        if (base.Session["checkfilter"] != null && base.Session["checkfilter"] == null)
        //        {
        //            base.Session["checkfilter"] = null;
        //        }
        //        if (e.Item is GridGroupHeaderItem)
        //        {
        //            GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
        //            DataRowView dataItem = (DataRowView)e.Item.DataItem;
        //            string[] strArrays = item.DataCell.Text.Split(new char[] { ':' });
        //            if (!strArrays[1].Contains("("))
        //            {
        //                item.DataCell.Text = strArrays[1].Trim();
        //            }
        //            else
        //            {
        //                item.DataCell.Text = strArrays[1].Replace("... group c", "C").Replace(". Group c", ". C").Trim();
        //            }
        //        }
        //        if (e.Item is GridHeaderItem)
        //        {
        //            GridHeaderItem gridHeaderItem = (GridHeaderItem)e.Item;
        //            gridHeaderItem["Month On List"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["Quantity on Hand"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["Stock Sales Value"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["UOI"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["Avg Month Usage"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["Month Over"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["Total Sales"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["January"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["February"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["March"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["April"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["May"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["June"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["July"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["August"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["September"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["October"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["November"].HorizontalAlign = HorizontalAlign.Right;
        //            gridHeaderItem["December"].HorizontalAlign = HorizontalAlign.Right;
        //        }
        //        if (e.Item is GridDataItem)
        //        {
        //            GridDataItem gridDataItem = (GridDataItem)e.Item;
        //            gridDataItem["Month On List"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["Quantity on Hand"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["Stock Sales Value"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["UOI"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["Avg Month Usage"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["Month Over"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["Total Sales"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["January"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["February"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["March"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["April"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["May"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["June"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["July"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["August"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["September"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["October"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["November"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["December"].HorizontalAlign = HorizontalAlign.Right;
        //            gridDataItem["Item Title"].Text = this.objBase.SpecialDecode(gridDataItem["Item Title"].Text);
        //            gridDataItem["Item Code"].Text = this.objBase.SpecialDecode(gridDataItem["Item Code"].Text);
        //        }
        //        if (e.Item is GridFilteringItem)
        //        {
        //            GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
        //            gridFilteringItem["Month On List"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["Quantity on Hand"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["Stock Sales Value"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["UOI"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["Avg Month Usage"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["Month Over"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["Total Sales"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["January"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["February"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["March"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["April"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["May"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["June"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["July"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["August"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["September"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["October"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["November"].HorizontalAlign = HorizontalAlign.Right;
        //            gridFilteringItem["December"].HorizontalAlign = HorizontalAlign.Right;
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        protected override void OnInit(EventArgs e)
        {
            GridFilterMenu filterMenu = this.RadGrid_Order_Report.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
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
            }
            GridFilterMenu languageConversion = this.RadGridProductReport_Customer_stockadjustment.FilterMenu;
            for (int j = languageConversion.Items.Count - 1; j >= 0; j--)
            {
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
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
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
            }
            GridFilterMenu gridFilterMenu = this.RadGrid_stockallocatedcsutomer_new.FilterMenu;
            for (int k = gridFilterMenu.Items.Count - 1; k >= 0; k--)
            {
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
                if (gridFilterMenu.Items[k].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "equalto")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu.Items[k].Visible = false;
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
            }
            GridFilterMenu filterMenu1 = this.RadGrid_CustomerJobReport.FilterMenu;
            for (int l = filterMenu1.Items.Count - 1; l >= 0; l--)
            {
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
                if (filterMenu1.Items[l].Text.ToLower() == "greaterthan")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "lessthan")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "equalto")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu1.Items[l].Visible = false;
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
            }
            GridFilterMenu languageConversion1 = this.RadGridReports_salesorderreport.FilterMenu;
            for (int m = languageConversion1.Items.Count - 1; m >= 0; m--)
            {
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
            }
            GridFilterMenu gridFilterMenu1 = this.RadStockUsage_Packs_stockusagereport.FilterMenu;
            for (int n = gridFilterMenu1.Items.Count - 1; n >= 0; n--)
            {
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
                if (gridFilterMenu1.Items[n].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu1.Items[n].Visible = false;
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
            }
            GridFilterMenu filterMenu2 = this.GridProductReport_quarterlysales.FilterMenu;
            for (int o = filterMenu2.Items.Count - 1; o >= 0; o--)
            {
                if (filterMenu2.Items[o].Text.ToLower() == "nofilter")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "contains")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "startswith")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "endswith")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "equalto")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "greaterthan")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "lessthan")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "isempty")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "notisempty")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "isnull")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "notisnull")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "between")
                {
                    filterMenu2.Items[o].Visible = false;
                }
                if (filterMenu2.Items[o].Text.ToLower() == "notbetween")
                {
                    filterMenu2.Items[o].Visible = false;
                }
            }
            GridFilterMenu languageConversion2 = this.RadGrid_StockUsageReport_bymonthandyear.FilterMenu;
            for (int p = languageConversion2.Items.Count - 1; p >= 0; p--)
            {
                if (languageConversion2.Items[p].Text.ToLower() == "nofilter")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "contains")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "startswith")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "endswith")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "equalto")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "greaterthan")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "lessthan")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "isempty")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "notisempty")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "isnull")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "notisnull")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "between")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "notbetween")
                {
                    languageConversion2.Items[p].Visible = false;
                }
            }

            GridFilterMenu languageConversion3 = this.RadGrid_StockUsageHistoryReport.FilterMenu;
            for (int q = languageConversion3.Items.Count - 1; q >= 0; q--)
            {
                if (languageConversion3.Items[q].Text.ToLower() == "nofilter")
                {
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "contains")
                {
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion3.Items[q].Visible = false;
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "startswith")
                {
                    languageConversion3.Items[q].Visible = false;
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "endswith")
                {
                    languageConversion3.Items[q].Visible = false;
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "equalto")
                {
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "notequalto")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "greaterthan")
                {
                    languageConversion3.Items[q].Visible = false;
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "lessthan")
                {
                    languageConversion3.Items[q].Visible = false;
                    languageConversion3.Items[q].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (languageConversion3.Items[q].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "isempty")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "notisempty")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "isnull")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "notisnull")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "between")
                {
                    languageConversion3.Items[q].Visible = false;
                }
                if (languageConversion3.Items[q].Text.ToLower() == "notbetween")
                {
                    languageConversion3.Items[q].Visible = false;
                }
            }

            GridFilterMenu languageConversion4 = this.RadStockUsage_Packs.FilterMenu;
            for (int t = languageConversion4.Items.Count - 1; t >= 0; t--)
            {
                if (languageConversion4.Items[t].Text.ToLower() == "nofilter")
                {
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "contains")
                {
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion4.Items[t].Visible = false;
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "startswith")
                {
                    languageConversion4.Items[t].Visible = false;
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "endswith")
                {
                    languageConversion4.Items[t].Visible = false;
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "equalto")
                {
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "notequalto")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "greaterthan")
                {
                    languageConversion4.Items[t].Visible = false;
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "lessthan")
                {
                    languageConversion4.Items[t].Visible = false;
                    languageConversion4.Items[t].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (languageConversion4.Items[t].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "isempty")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "notisempty")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "isnull")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "notisnull")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "between")
                {
                    languageConversion4.Items[t].Visible = false;
                }
                if (languageConversion4.Items[t].Text.ToLower() == "notbetween")
                {
                    languageConversion4.Items[t].Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "estore_reports.aspx'>Reports</a>");
            if (this.hdn_report_name_aftergen.Value != "")
            {
                ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "estore_reports.aspx'>Reports</a>&nbsp;>>&nbsp;&nbsp;", this.objBase.SpecialDecode(this.hdn_report_name_aftergen.Value));
            }
            this.div_Reports_Names.Attributes.Add("style", "display:block");
            this.div_reportgrid.Attributes.Add("style", "display:none;");
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (BaseClass.imagepath != "")
            {
                this.strImagePath = BaseClass.imagepath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            this.deptScreenName = this.objBc.Return_ApprovalRegistration_Settings("deptscreenname");
            if (!base.IsPostBack)
            {
                this.Session["reportdatatable_order"] = null;
                this.Session["reportdatatable_order_job"] = null;
                this.Session["reportdatatable_order_invoice"] = null;
                this.Session["reportdatatable_order_product"] = null;
                this.Session["Orderreport_systemgeb_Orderdetails"] = null;
                this.Session["prodreport_systemen_stockusage"] = null;
                this.Session["prodreport_systemen_stockusage_bymonth"] = null;
                this.Session["prodreport_systemen_stockusage_byadjustment"] = null;
                this.Session["prodreport_systemen_stockusage_quarterlysales"] = null;
                this.Session["system_stockusage_costprice"] = null;
                this.Session["system_StockUsageHistoryReport"] = null;
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
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }

            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, this.AccountID).Rows)
            {
                this.DateFormat = row["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());
            }
            base.Title = commonclass.pageTitle("Estore Reports", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            DataTable dataTable = OrderBasePage.settings_regionalsettings_select(this.CompanyID);
            this.Paper_Stock = dataTable.Rows[0]["PaperMeasure"].ToString();
            if (this.Paper_Stock == "mm")
            {
                this.Paper_Stock_Lenght = "Mtr";
            }
            else if (this.Paper_Stock == "In.")
            {
                this.Paper_Stock_Lenght = "Feet";
            }
            if (dataTable.Rows[0]["Weight"].ToString() != "")
            {
                this.Weight_gsm = dataTable.Rows[0]["GeneralWeight"].ToString();
            }
            foreach (DataRow dataRow in OrderBasePage.productcatalogue_warehousestock_select(this.CompanyID).Rows)
            {
                this.IsDisplayLocation = Convert.ToBoolean(dataRow["Isdisplay"]);
                if (dataRow["DatafieldName"].ToString().Trim() == "CustomField1" && this.IsDisplayLocation)
                {
                    this.CustomField1 = dataRow["ScreenName"].ToString().Trim();
                }
                if (dataRow["DatafieldName"].ToString().Trim() == "CustomField2" && this.IsDisplayLocation)
                {
                    this.CustomField2 = dataRow["ScreenName"].ToString().Trim();
                }
                if (dataRow["DatafieldName"].ToString().Trim() == "CustomField3" && this.IsDisplayLocation)
                {
                    this.CustomField3 = dataRow["ScreenName"].ToString().Trim();
                }
                if (dataRow["DatafieldName"].ToString().Trim() == "CustomField4" && this.IsDisplayLocation)
                {
                    this.CustomField4 = dataRow["ScreenName"].ToString().Trim();
                }
                if (dataRow["DatafieldName"].ToString().Trim() == "CustomField5" && this.IsDisplayLocation)
                {
                    this.CustomField5 = dataRow["ScreenName"].ToString().Trim();
                }
                if (!(dataRow["DatafieldName"].ToString().Trim() == "CustomField6") || !this.IsDisplayLocation)
                {
                    continue;
                }
                this.CustomField6 = dataRow["ScreenName"].ToString().Trim();
            }
            DataTable dataTable1 = OrderBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable1.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable1.Rows[0]["FisCalTo"]);
            this.hdnFromDate.Value = dateTime.ToString();
            this.hdnToDate.Value = dateTime1.ToString();
            this.RadGrid_Order_Report.Columns[0].HeaderText = "Customer";
            this.RadGrid_Order_Report.Columns[1].HeaderText = "Department";
            this.RadGrid_Order_Report.Columns[2].HeaderText = "Contact";
            this.RadGrid_Order_Report.Columns[3].HeaderText = "Cost Centre";
            this.RadGrid_Order_Report.Columns[4].HeaderText = "Order No";
            this.RadGrid_Order_Report.Columns[5].HeaderText = "Customer Order No";
            this.RadGrid_Order_Report.Columns[6].HeaderText = "Order Date";
            this.RadGrid_Order_Report.Columns[7].HeaderText = "Item Code";
            this.RadGrid_Order_Report.Columns[8].HeaderText = "Item Title";
            this.RadGrid_Order_Report.Columns[9].HeaderText = "Product Type";
            this.RadGrid_Order_Report.Columns[10].HeaderText = "Customer Code";
            this.RadGrid_Order_Report.Columns[11].HeaderText = "Order Qty";
            this.RadGrid_Order_Report.Columns[12].HeaderText = "Unit of Issue";
            this.RadGrid_Order_Report.Columns[13].HeaderText = "Unit Cost";
            this.RadGrid_Order_Report.Columns[14].HeaderText = "Total Cost (Ex. GST)";
            this.RadGridProductReport_Customer_stockadjustment.Columns[0].HeaderText = "Category";
            this.RadGridProductReport_Customer_stockadjustment.Columns[1].HeaderText = "Item code";
            this.RadGridProductReport_Customer_stockadjustment.Columns[2].HeaderText = "Customer code";
            this.RadGridProductReport_Customer_stockadjustment.Columns[3].HeaderText = "Item Title";
            this.RadGridProductReport_Customer_stockadjustment.Columns[4].HeaderText = "Item Description";
            this.RadGridProductReport_Customer_stockadjustment.Columns[5].HeaderText = "Opening Stock";
            this.RadGridProductReport_Customer_stockadjustment.Columns[6].HeaderText = "Total Releases";
            this.RadGridProductReport_Customer_stockadjustment.Columns[7].HeaderText = "Receipts";
            this.RadGridProductReport_Customer_stockadjustment.Columns[8].HeaderText = "Adjustments";
            this.RadGridProductReport_Customer_stockadjustment.Columns[9].HeaderText = "Closing Stock";
            this.RadGridProductReport_Customer_stockadjustment.Columns[10].HeaderText = "Stock Released to this Customer";
            this.RadGridProductReport_Customer_stockadjustment.Columns[11].HeaderText = "Weeks remaining";
            this.RadGrid_stockallocatedcsutomer_new.Columns[0].HeaderText = "Category";
            this.RadGrid_stockallocatedcsutomer_new.Columns[1].HeaderText = "Item code";
            this.RadGrid_stockallocatedcsutomer_new.Columns[2].HeaderText = "Customer code";
            this.RadGrid_stockallocatedcsutomer_new.Columns[3].HeaderText = "Item Title";
            this.RadGrid_stockallocatedcsutomer_new.Columns[4].HeaderText = "Item Description";
            this.RadGrid_stockallocatedcsutomer_new.Columns[5].HeaderText = "Opening Stock";
            this.RadGrid_stockallocatedcsutomer_new.Columns[6].HeaderText = "Allocated Quantity";
            this.RadGrid_stockallocatedcsutomer_new.Columns[7].HeaderText = "Total Releases";
            this.RadGrid_stockallocatedcsutomer_new.Columns[8].HeaderText = "Receipts";
            this.RadGrid_stockallocatedcsutomer_new.Columns[9].HeaderText = "Adjustments";
            this.RadGrid_stockallocatedcsutomer_new.Columns[10].HeaderText = "Closing Stock";
            this.RadGrid_stockallocatedcsutomer_new.Columns[11].HeaderText = "Stock Released to this Customer";
            this.RadGrid_stockallocatedcsutomer_new.Columns[12].HeaderText = "Weeks remaining";
            this.RadGrid_CustomerJobReport.Columns[10].HeaderText = string.Concat("Sales Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), ")");
            if (this.hdnDepartmentID.Value == "" || this.hdnDepartmentID.Value == "All")
            {
                this.RadGrid_StockUsageReport_bymonthandyear.GroupingEnabled = false;
                return;
            }
            if (this.hdnDepartmentID.Value == "Group")
            {
                this.RadGrid_StockUsageReport_bymonthandyear.GroupingEnabled = true;
                return;
            }
            this.RadGrid_StockUsageReport_bymonthandyear.GroupingEnabled = false;
        }

        protected void RadGrid_Order_Report_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!(e.CommandName == "Filter") || !(((Pair)e.CommandArgument).Second.ToString() == "OrderedDate"))
            {
                if (e.CommandName != "Sort" && e.CommandName != "Page")
                {
                    this.Session["filterPattern"] = null;
                }
                return;
            }
            string str = "";
            string str1 = "";
            e.Canceled = true;
            GridFilteringItem item = (GridFilteringItem)e.Item;
            string text = (item[((Pair)e.CommandArgument).Second.ToString()].Controls[0] as TextBox).Text;
            string str2 = (e.CommandArgument as Pair).First.ToString();
            GridTemplateColumn columnSafe = (GridTemplateColumn)e.Item.OwnerTableView.GetColumnSafe("OrderedDate");
            string str3 = str2;
            string str4 = str3;
            if (str3 != null)
            {
                switch (str4)
                {
                    case "EqualTo":
                        {
                            str = string.Concat("[OrderedDate] = '", str, "'");
                            columnSafe.CurrentFilterFunction = GridKnownFunction.EqualTo;
                            break;
                        }
                    case "NotEqualTo":
                        {
                            str = string.Concat("Not [OrderedDate] = '", str, "'");
                            columnSafe.CurrentFilterFunction = GridKnownFunction.NotEqualTo;
                            break;
                        }
                    case "GreaterThan":
                        {
                            str = string.Concat("[OrderedDate] > '", str, "'");
                            columnSafe.CurrentFilterFunction = GridKnownFunction.GreaterThan;
                            break;
                        }
                    case "LessThan":
                        {
                            str = string.Concat("[OrderedDate] < '", str, "'");
                            columnSafe.CurrentFilterFunction = GridKnownFunction.LessThan;
                            break;
                        }
                    case "GreaterThanOrEqualTo":
                        {
                            str = string.Concat("[OrderedDate] >= '", str, "'");
                            columnSafe.CurrentFilterFunction = GridKnownFunction.GreaterThanOrEqualTo;
                            break;
                        }
                    case "LessThanOrEqualTo":
                        {
                            str = string.Concat("[OrderedDate] <= '", str, "'");
                            columnSafe.CurrentFilterFunction = GridKnownFunction.LessThanOrEqualTo;
                            break;
                        }
                    case "Between":
                        {
                            string[] strArrays = new string[] { "'", str, "' <= [OrderedDate] AND [OrderedDate] <= '", str1, "'" };
                            str = string.Concat(strArrays);
                            columnSafe.CurrentFilterFunction = GridKnownFunction.Between;
                            break;
                        }
                    case "NotBetween":
                        {
                            string[] strArrays1 = new string[] { "[OrderedDate] <= '", str, "' OR [OrderedDate] >= '", str1, "'" };
                            str = string.Concat(strArrays1);
                            columnSafe.CurrentFilterFunction = GridKnownFunction.NotBetween;
                            break;
                        }
                }
            }
            foreach (GridColumn column in this.RadGrid_Order_Report.MasterTableView.Columns)
            {
                if (column.UniqueName == "OrderedDate")
                {
                    continue;
                }
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.Session["filterPattern"] = str;
            columnSafe.CurrentFilterValue = text;
            item.OwnerTableView.Rebind();
        }

        protected void RadGrid_Order_Report_ItemDataBound(object sender, GridItemEventArgs e)
        {
            TextBox value = (TextBox)e.Item.FindControl("txtOrderFromDate");
            TextBox textBox = (TextBox)e.Item.FindControl("txtOrderToDate");
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlStockItem");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkreplishment");
            Label label = (Label)e.Item.FindControl("lblOrderedDate");
            if (value != null && textBox != null)
            {
                if (value.Text != "")
                {
                    value.Text = this.objCommon.Eprint_return_Date_Before_View(value.Text, this.CompanyID, Convert.ToInt32(this.UserID), false);
                    this.orderFromdate = value.Text;
                }
                else
                {
                    value.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderFromdate.Value, this.CompanyID, this.UserID, false);
                }
                if (textBox.Text != "")
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.UserID), false);
                    this.orderTodate = textBox.Text;
                }
                else
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderTodate.Value, this.CompanyID, Convert.ToInt32(this.UserID), false);
                }
                value.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.hdnOrderFromdate.Value = this.objCommon.Eprint_return_Date_Before_View(value.Text, this.CompanyID, Convert.ToInt32(this.UserID), false);
                this.hdnOrderTodate.Value = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.UserID), false);
                if (this.hdnOrderFromdate.Value != "0" && value.Text == "")
                {
                    value.Text = this.hdnOrderFromdate.Value;
                }
                if (this.hdnOrderTodate.Value != "0" && textBox.Text == "")
                {
                    textBox.Text = this.hdnOrderTodate.Value;
                }
            }
            if (label != null)
            {
                label.Text = this.objCommon.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
            }
            if (dropDownList != null)
            {
                dropDownList.Items.Insert(0, new ListItem("-- Item Type --", ""));
                dropDownList.Items.Insert(1, new ListItem("All", "All"));
                dropDownList.Items.Insert(2, new ListItem("Stock", "1"));
                dropDownList.Items.Insert(3, new ListItem("Non Stock", "0"));
                dropDownList.Items.Insert(4, new ListItem("Editable", "3"));
                dropDownList.Items.Insert(5, new ListItem("Stock Editable", "2"));
                dropDownList.SelectedValue = this.hdnisstockItem.Value;
            }
            if (checkBox != null && this.hdnisreplinsh.Value != "")
            {
                checkBox.Checked = true;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["Total"].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void RadGrid_Order_Report_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            GridTableView masterTableView = this.RadGrid_Order_Report.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtOrderFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtOrderToDate");
            if (textBox != null)
            {
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.orderFromdate = textBox.Text;
                this.orderFromdate = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            }
            if (textBox1 != null)
            {
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.orderTodate = textBox1.Text;
                this.orderTodate = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
            }
            this.hdnOrderFromdate.Value = this.orderFromdate;
            this.hdnOrderTodate.Value = this.orderTodate;
            this.hdnOrderFromdate.Value = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderFromdate.Value, this.CompanyID, this.UserID, false);
            this.hdnOrderTodate.Value = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderTodate.Value, this.CompanyID, this.UserID, false);
            if (Convert.ToBoolean(OrderBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["AllowUnApprovedOrder"]))
            {
                this.AllowUnApprovedOrder = true;
            }
            DataTable dataTable = new DataTable();
            dataTable = OrderBasePage.Orderreport_systemgenerated(this.CompanyID, this.StoreUserID, Convert.ToDateTime(this.hdnOrderFromdate.Value), Convert.ToDateTime(this.hdnOrderTodate.Value), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Item Code"))
                    {
                        row["Item Code"] = this.objBase.SpecialDecode(row["Item Code"].ToString());
                    }
                    if (row.Table.Columns.Contains("Item Title"))
                    {
                        row["Item Title"] = this.objBase.SpecialDecode(row["Item Title"].ToString());
                    }
                    if (row.Table.Columns.Contains("End user Cost Centre"))
                    {
                        row["End user Cost Centre"] = this.objBase.SpecialDecode(row["End user Cost Centre"].ToString());
                    }
                    if (row.Table.Columns.Contains("Contact"))
                    {
                        row["Contact"] = this.objBase.SpecialDecode(row["Contact"].ToString());
                    }
                    if (row.Table.Columns.Contains("Customer"))
                    {
                        row["Customer"] = this.objBase.SpecialDecode(row["Customer"].ToString());
                    }
                    if (row.Table.Columns.Contains("Department"))
                    {
                        row["Department"] = this.objBase.SpecialDecode(row["Department"].ToString());
                    }
                    if (row.Table.Columns.Contains("Customer Code"))
                    {
                        row["Customer Code"] = this.objBase.SpecialDecode(row["Customer Code"].ToString());
                    }
                    row.Table.Columns.Contains("OrderedDate");
                    if (!row.Table.Columns.Contains("Unit Cost"))
                    {
                        continue;
                    }
                    row["Unit Cost"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row["Unit Cost"].ToString()), 2, "", false, false, true);
                }
            }
            //this.RadGrid_Order_Report.DataSource = dataTable;
            this.exportToXlsx(dataTable, this.RadGrid_Order_Report.ExportSettings.FileName.ToString());
            if (this.Session["filterPattern"] != null)
            {
                this.RadGrid_Order_Report.MasterTableView.FilterExpression = this.Session["filterPattern"].ToString();
            }
        }

        protected void RadGrid_stockallocatedcsutomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)e.Item.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtToDate");
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                if (textBox != null)
                {
                    if (this.FromDate != "")
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.FromDate, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    else
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                if (textBox1 != null)
                {
                    if (this.ToDate != "")
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.ToDate, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    else
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem item = (GridFilteringItem)e.Item;
                    item["Openingstock"].HorizontalAlign = HorizontalAlign.Right;
                    item["Releases"].HorizontalAlign = HorizontalAlign.Right;
                    item["Receipts"].HorizontalAlign = HorizontalAlign.Right;
                    item["Adjustments"].HorizontalAlign = HorizontalAlign.Right;
                    item["ClosingStock"].HorizontalAlign = HorizontalAlign.Right;
                    item["ReleasesOverLast13Weeks"].HorizontalAlign = HorizontalAlign.Right;
                    item["WeeksRemaining"].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch
            {
            }
        }

        protected void RadGrid_stockallocatedcsutomer_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                GridTableView masterTableView = this.RadGrid_stockallocatedcsutomer_new.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.FromDate = textBox.Text;
                this.ToDate = textBox1.Text;
                this.hdnProductFormDate.Value = textBox.Text;
                this.hdnProductToDate.Value = textBox1.Text;
                DataTable dataTable = new DataTable();
                dataTable = OrderBasePage.ProductReport_Stockrelease_adjustment((long)this.CompanyID, Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate), this.StoreUserID);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("ParentCategory/SubCategory"))
                        {
                            row["ParentCategory/SubCategory"] = this.objBase.SpecialDecode(row["ParentCategory/SubCategory"].ToString());
                        }
                        if (row.Table.Columns.Contains("Itemcode"))
                        {
                            row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                        }
                        if (row.Table.Columns.Contains("CustomerCode"))
                        {
                            row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                        }
                        if (row.Table.Columns.Contains("ItemTitle"))
                        {
                            row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                        }
                        if (!row.Table.Columns.Contains("ItemDescription"))
                        {
                            continue;
                        }
                        row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                    }
                }
                //this.RadGrid_stockallocatedcsutomer_new.DataSource = dataTable;
                this.exportToXlsx(dataTable, this.RadGrid_stockallocatedcsutomer_new.ExportSettings.FileName.ToString());
            }
            catch
            {
            }
        }

        protected void RadGrid_StockUsageReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                DataTable dataTable = OrderBasePage.settings_regionalsettings_select(this.CompanyID);
                DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
                DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
                DateTime.Now.AddMonths(-12);
                dateTime.AddYears(-1);
                dateTime1.AddYears(-1);
                DropDownList value = (DropDownList)e.Item.FindControl("ddldepartment");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlMonthCategory");
                Label label = (Label)e.Item.FindControl("lblMonthHeading");
                if (label != null)
                {
                    if (this.hdnMonthCategory.Value.ToString() == "CM" || this.hdnMonthCategory.Value == "")
                    {
                        label.Text = " Calendar year sales (Allocations)";
                    }
                    else if (this.hdnMonthCategory.Value.ToString() == "LFM")
                    {
                        label.Text = " Last financial year sales (Allocations)";
                    }
                    else if (this.hdnMonthCategory.Value.ToString() == "CFM")
                    {
                        label.Text = " Current financial year sales (Allocations)";
                    }
                    else if (this.hdnMonthCategory.Value.ToString() == "LTM")
                    {
                        label.Text = "Last twelve month sales (Allocations)";
                    }
                }
                if (value != null)
                {
                    DataSet dataSet = OrderBasePage.Select_BehalfUsersOrDept(this.AccountID, this.StoreUserID);
                    DataTable item = dataSet.Tables[2];
                    for (int i = 0; i < item.Columns.Count; i++)
                    {
                        item.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in item.Rows)
                    {
                        row["Deptname"] = this.objBase.SpecialDecode(row["Deptname"].ToString());
                    }
                    value.DataSource = item;
                    value.DataTextField = "Deptname";
                    value.DataValueField = "Deptid";
                    value.DataBind();
                    int count = item.Rows.Count;
                    value.Items.Insert(0, new ListItem("-- Department Name --", " "));
                    value.Items.Insert(1, new ListItem("All", "All"));
                    value.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                    value.Items.Insert(3, new ListItem("--------------------------------------------------------------", "Group"));
                    if (this.hdnDepartmentID.Value != "0" || this.hdnDepartmentID.Value != "")
                    {
                        value.SelectedValue = this.hdnDepartmentID.Value;
                    }
                }
                if (dropDownList != null)
                {
                    dropDownList.Items.Insert(0, new ListItem("Show this Calendar Year", "CM"));
                    dropDownList.Items.Insert(1, new ListItem("Show by Last Financial Year", "LFM"));
                    dropDownList.Items.Insert(2, new ListItem("Show by Current Financial Year", "CFM"));
                    dropDownList.Items.Insert(3, new ListItem("Show for Last 12 Month", "LTM"));
                    dropDownList.SelectedValue = this.hdnMonthCategory.Value;
                }
                GridColumn[] renderColumns = e.Item.OwnerTableView.RenderColumns;
                for (int j = 0; j < (int)renderColumns.Length; j++)
                {
                    GridColumn empty = renderColumns[j];
                    empty.AutoPostBackOnFilter = true;
                    if (empty.UniqueName == "January" || empty.UniqueName == "February" || empty.UniqueName == "March" || empty.UniqueName == "April" || empty.UniqueName == "May" || empty.UniqueName == "June" || empty.UniqueName == "July" || empty.UniqueName == "August" || empty.UniqueName == "September" || empty.UniqueName == "October" || empty.UniqueName == "November" || empty.UniqueName == "December" || empty.UniqueName == "UOI" || empty.UniqueName.Trim() == "TotalSales")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                    }
                    else if (empty.UniqueName.Trim() == "ItemTitle")
                    {
                        empty.HeaderStyle.Width = Unit.Pixel(500);
                        empty.FilterControlWidth = Unit.Pixel(170);
                    }
                    else if (empty.UniqueName.Trim() == "StockSalesValue" || empty.UniqueName.Trim() == "AvgMonthUsage" || empty.UniqueName.Trim() == "MonthOver")
                    {
                        empty.HeaderStyle.Wrap = false;
                        empty.HeaderStyle.Width = Unit.Pixel(300);
                        empty.FilterControlWidth = Unit.Pixel(40);
                    }
                    else if (empty.UniqueName.Trim() == "MonthOnList")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                        empty.HeaderText = "Month on List";
                    }
                    else if (empty.UniqueName.Trim() == "QuantityonHand")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                        empty.HeaderText = "Quantity on Hand";
                    }
                    else if (empty.UniqueName.Trim() == "DeptID" || empty.UniqueName.Trim() == "DeptName" || empty.UniqueName.Trim() == "DeptId")
                    {
                        empty.Visible = false;
                    }
                    if (this.Session["checkfilter"] != null && this.Session["checkfilter"] == null)
                    {
                        empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty.CurrentFilterValue = string.Empty;
                    }
                }
                if (this.Session["checkfilter"] != null && this.Session["checkfilter"] == null)
                {
                    this.Session["checkfilter"] = null;
                }
                if (e.Item is GridGroupHeaderItem)
                {
                    GridGroupHeaderItem gridGroupHeaderItem = (GridGroupHeaderItem)e.Item;
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    string[] strArrays = gridGroupHeaderItem.DataCell.Text.Split(new char[] { ':' });
                    if (!strArrays[1].Contains("("))
                    {
                        gridGroupHeaderItem.DataCell.Text = strArrays[1].Trim();
                    }
                    else
                    {
                        gridGroupHeaderItem.DataCell.Text = strArrays[1].Replace("... group c", "C").Replace(". Group c", ". C").Trim();
                    }
                }
                if (e.Item is GridHeaderItem)
                {
                    GridHeaderItem gridHeaderItem = (GridHeaderItem)e.Item;
                    gridHeaderItem["Month On List"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["Quantity on Hand"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["Stock Sales Value"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["UOI"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["Avg Month Usage"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["Month Over"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["Total Sales"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["January"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["February"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["March"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["April"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["May"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["June"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["July"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["August"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["September"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["October"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["November"].HorizontalAlign = HorizontalAlign.Right;
                    gridHeaderItem["December"].HorizontalAlign = HorizontalAlign.Right;
                }
                if (e.Item is GridDataItem)
                {
                    GridDataItem gridDataItem = (GridDataItem)e.Item;
                    gridDataItem["Month On List"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["Quantity on Hand"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["Stock Sales Value"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["UOI"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["Avg Month Usage"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["Month Over"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["Total Sales"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["January"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["February"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["March"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["April"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["May"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["June"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["July"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["August"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["September"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["October"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["November"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["December"].HorizontalAlign = HorizontalAlign.Right;
                    gridDataItem["Item Title"].Text = this.objBase.SpecialDecode(gridDataItem["Item Title"].Text);
                    gridDataItem["Item Code"].Text = this.objBase.SpecialDecode(gridDataItem["Item Code"].Text);
                }
                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                    gridFilteringItem["Month On List"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["Quantity on Hand"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["Stock Sales Value"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["UOI"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["Avg Month Usage"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["Month Over"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["Total Sales"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["January"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["February"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["March"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["April"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["May"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["June"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["July"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["August"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["September"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["October"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["November"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["December"].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch
            {
            }
        }

        protected void RadGrid_StockUsageReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Prod_report_stockusage_bymontandYear((long)this.CompanyID, this.StoreUserID, this.hdnDepartmentID.Value, this.hdnMonthCategory.Value);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Stock Code"))
                    {
                        row["Stock Code"] = this.objBase.SpecialDecode(row["Stock Code"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    row["Product Name"] = this.objBase.SpecialDecode(row["Product Name"].ToString());
                }
            }
            //this.RadGrid_StockUsageReport_bymonthandyear.DataSource = dataTable;
            this.exportToXlsx(dataTable, this.RadGrid_StockUsageReport_bymonthandyear.ExportSettings.FileName.ToString());
        }

        protected void RadGridCustomerJobReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                this.jobreport_systemgenname = "product sales report";
                TextBox textBox = (TextBox)e.Item.FindControl("txtJobFromDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtJobToDate");
                this.RadGrid_CustomerJobReport.GroupPanel.Text = "Drag a column header [Job Number/Department Name/Department State/Category/Customer Code] and drop it here to group by that column";
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem item = (GridFilteringItem)e.Item;
                    item["ItemQTy"].HorizontalAlign = HorizontalAlign.Right;
                    item["SalesValue"].HorizontalAlign = HorizontalAlign.Right;
                }
                if (textBox != null)
                {
                    if (this.JobFromDate != "")
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.JobFromDate, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    else
                    {
                        textBox.Text = this.comm.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                if (textBox1 != null)
                {
                    if (this.JobToDate != "")
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.JobToDate, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    else
                    {
                        textBox1.Text = this.comm.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                Label label = (Label)e.Item.FindControl("lblSalesValue");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnSubItemSalesValue");
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    GridDataItem gridDataItem = (GridDataItem)e.Item;
                    if (hiddenField.Value.ToLower() == "no")
                    {
                        label.Text = "n/a";
                    }
                }
                if (e.Item is GridFooterItem)
                {
                    GridFooterItem value = (GridFooterItem)e.Item;
                    if (value["ItemQTy"].FindControl("lblSumTotalQty") is Label)
                    {
                        (value["ItemQTy"].FindControl("lblSumTotalQty") as Label).Text = this.hdnTotalQty.Value;
                    }
                    if (value["SalesValue"].FindControl("lblSumTotalSubTotal") is Label)
                    {
                        (value["SalesValue"].FindControl("lblSumTotalSubTotal") as Label).Text = this.hdnTotalSalesValue.Value;
                    }
                }
                GridItem[] items = this.RadGrid_CustomerJobReport.MasterTableView.GetItems(new GridItemType[] { GridItemType.GroupFooter });
                for (int i = 0; i < (int)items.Length; i++)
                {
                    GridGroupFooterItem gridGroupFooterItem = (GridGroupFooterItem)items[i];
                    if (gridGroupFooterItem.Cells.Count == 14)
                    {
                        gridGroupFooterItem.Cells[11].Text = "<b>Sub Total:</b>".Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[12].Text = string.Concat("<b>", gridGroupFooterItem["ItemQTy"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[13].Text = string.Concat("<b>", gridGroupFooterItem["SalesValue"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                    }
                    if (gridGroupFooterItem.Cells.Count == 15)
                    {
                        gridGroupFooterItem.Cells[12].Text = "<b>Sub Total:</b>".Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[13].Text = string.Concat("<b>", gridGroupFooterItem["ItemQTy"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[14].Text = string.Concat("<b>", gridGroupFooterItem["SalesValue"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                    }
                    if (gridGroupFooterItem.Cells.Count == 16)
                    {
                        gridGroupFooterItem.Cells[13].Text = "<b>Sub Total:</b>".Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[14].Text = string.Concat("<b>", gridGroupFooterItem["ItemQTy"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[15].Text = string.Concat("<b>", gridGroupFooterItem["SalesValue"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                    }
                    if (gridGroupFooterItem.Cells.Count == 17)
                    {
                        gridGroupFooterItem.Cells[14].Text = "<b>Sub Total:</b>".Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[15].Text = string.Concat("<b>", gridGroupFooterItem["ItemQTy"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[16].Text = string.Concat("<b>", gridGroupFooterItem["SalesValue"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                    }
                    if (gridGroupFooterItem.Cells.Count == 18)
                    {
                        gridGroupFooterItem.Cells[15].Text = "<b>Sub Total:</b>".Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[16].Text = string.Concat("<b>", gridGroupFooterItem["ItemQTy"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                        gridGroupFooterItem.Cells[17].Text = string.Concat("<b>", gridGroupFooterItem["SalesValue"].Text, "</b>").Replace("<b><b>", "<b>").Replace("</b></b>", "</b>");
                    }
                }
                if (e.Item is GridPagerItem)
                {
                    Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem gridPagerItem = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.RadGrid_CustomerJobReport.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }
            }
            catch
            {
            }
        }

        protected void RadGridCustomerJobReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.div_reportgrid.Attributes.Add("style", "display:none");
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtJobFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtJobToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.JobFromDate = textBox.Text;
                this.JobToDate = textBox1.Text;
                this.hdnJobFormdate.Value = textBox.Text;
                this.hdnJobToDate.Value = textBox1.Text;
                DataSet dataSet = OrderBasePage.JobReport_CustomizeCustomer((long)this.CompanyID, this.StoreUserID, Convert.ToDateTime(this.JobFromDate), Convert.ToDateTime(this.JobToDate), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    foreach (DataColumn column in dataSet.Tables[i].Columns)
                    {
                        column.ReadOnly = false;
                    }
                }
                Label label = (Label)items.FindControl("lblSumTotalQty");
                Label label1 = (Label)items.FindControl("lblSumTotalSubTotal");
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row.Table.Columns.Contains("JobTitle"))
                    {
                        row["JobTitle"] = this.objBase.SpecialDecode(row["JobTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("DepartmentName"))
                    {
                        row["DepartmentName"] = this.objBase.SpecialDecode(row["DepartmentName"].ToString());
                    }
                    if (row.Table.Columns.Contains("DepartmentState"))
                    {
                        row["DepartmentState"] = this.objBase.SpecialDecode(row["DepartmentState"].ToString());
                    }
                    if (row.Table.Columns.Contains("ParentCategorySubCategory"))
                    {
                        row["ParentCategorySubCategory"] = this.objBase.SpecialDecode(row["ParentCategorySubCategory"].ToString());
                    }
                    if (row.Table.Columns.Contains("Itemcode"))
                    {
                        row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerCode"))
                    {
                        row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (!row.Table.Columns.Contains("ItemDescription"))
                    {
                        continue;
                    }
                    row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                }
                foreach (DataRow dataRow in dataSet.Tables[1].Rows)
                {
                    if (dataRow["TotalQuantity"] != null)
                    {
                        this.hdnTotalQty.Value = dataRow["TotalQuantity"].ToString();
                    }
                    if (dataRow["TotalSubTotal"] == null)
                    {
                        continue;
                    }
                    this.hdnTotalSalesValue.Value = dataRow["TotalSubTotal"].ToString();
                }
                this.RadGrid_CustomerJobReport.DataSource = dataSet.Tables[0];
                this.exportToXlsx(dataSet.Tables[0], this.RadGrid_CustomerJobReport.ExportSettings.FileName.ToString());
            }
            catch
            {
            }
        }

        public void RadGridJobCustomerReport(int CompanyID)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.JobReport_CustomizeCustomer((long)CompanyID, this.StoreUserID, dateTime[0], dateTime[1], this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
                foreach (DataColumn column in dataSet.Tables[0].Columns)
                {
                    column.ReadOnly = false;
                }
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row.Table.Columns.Contains("JobTitle"))
                    {
                        row["JobTitle"] = this.objBase.SpecialDecode(row["JobTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("DepartmentName"))
                    {
                        row["DepartmentName"] = this.objBase.SpecialDecode(row["DepartmentName"].ToString());
                    }
                    if (row.Table.Columns.Contains("DepartmentState"))
                    {
                        row["DepartmentState"] = this.objBase.SpecialDecode(row["DepartmentState"].ToString());
                    }
                    if (row.Table.Columns.Contains("ParentCategorySubCategory"))
                    {
                        row["ParentCategorySubCategory"] = this.objBase.SpecialDecode(row["ParentCategorySubCategory"].ToString());
                    }
                    if (row.Table.Columns.Contains("Itemcode"))
                    {
                        row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerCode"))
                    {
                        row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (!row.Table.Columns.Contains("ItemDescription"))
                    {
                        continue;
                    }
                    row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                }
                if (dataSet.Tables[1].Rows[0]["TotalQuantity"] != null)
                {
                    this.hdnTotalQty.Value = dataSet.Tables[1].Rows[0]["TotalQuantity"].ToString();
                }
                if (dataSet.Tables[1].Rows[0]["TotalSubTotal"] != null)
                {
                    this.hdnTotalSalesValue.Value = dataSet.Tables[1].Rows[0]["TotalSubTotal"].ToString();
                }
                if (this.hdnTotalQty.Value == "")
                {
                    this.hdnTotalQty.Value = "0";
                }
                if (this.hdnTotalSalesValue.Value == "")
                {
                    this.hdnTotalSalesValue.Value = "0";
                }
                this.RadGrid_CustomerJobReport.DataSource = dataSet.Tables[0];
                this.RadGrid_CustomerJobReport.DataBind();
            }
            catch
            {
            }
        }

        public void RadGridJobReport(int CompanyID)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.CustomizeJob_Report((long)CompanyID, this.StoreUserID, this.hdnFromDate.Value, this.hdnToDate.Value);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Category"))
                    {
                        row["Category"] = this.objBase.SpecialDecode(row["Category"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerCode"))
                    {
                        row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("ProductTitle"))
                    {
                        row["ProductTitle"] = this.objBase.SpecialDecode(row["ProductTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("ProductDescription"))
                    {
                        row["ProductDescription"] = this.objBase.SpecialDecode(row["ProductDescription"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerName"))
                    {
                        row["CustomerName"] = this.objBase.SpecialDecode(row["CustomerName"].ToString());
                    }
                    if (row.Table.Columns.Contains("State"))
                    {
                        row["State"] = this.objBase.SpecialDecode(row["State"].ToString());
                    }
                    if (row.Table.Columns.Contains("Department"))
                    {
                        row["Department"] = this.objBase.SpecialDecode(row["Department"].ToString());
                    }
                    if (!row.Table.Columns.Contains("ContactName"))
                    {
                        continue;
                    }
                    row["ContactName"] = this.objBase.SpecialDecode(row["ContactName"].ToString());
                }
            }
            this.RadGridReports_salesorderreport.DataSource = dataTable;
            this.RadGridReports_salesorderreport.DataBind();
        }

        protected void RadGridJobReports_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.CustomizeJob_Report((long)this.CompanyID, this.StoreUserID, this.hdnFromDate.Value, this.hdnToDate.Value);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Category"))
                    {
                        row["Category"] = this.objBase.SpecialDecode(row["Category"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerCode"))
                    {
                        row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("ProductDescription"))
                    {
                        row["ProductDescription"] = this.objBase.SpecialDecode(row["ProductDescription"].ToString());
                    }
                    if (row.Table.Columns.Contains("State"))
                    {
                        row["State"] = this.objBase.SpecialDecode(row["State"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerName"))
                    {
                        row["CustomerName"] = this.objBase.SpecialDecode(row["CustomerName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Department"))
                    {
                        row["Department"] = this.objBase.SpecialDecode(row["Department"].ToString());
                    }
                    if (!row.Table.Columns.Contains("ContactName"))
                    {
                        continue;
                    }
                    row["ContactName"] = this.objBase.SpecialDecode(row["ContactName"].ToString());
                }
            }
            //this.RadGridReports_salesorderreport.DataSource = dataTable;
            this.exportToXlsx(dataTable, this.RadGridReports_salesorderreport.ExportSettings.FileName.ToString());

        }

        public void RadGridoredrReport(int CompanyID)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = new DataTable();
            if (Convert.ToBoolean(OrderBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows[0]["AllowUnApprovedOrder"]))
            {
                this.AllowUnApprovedOrder = true;
            }
            DateTime now = DateTime.Now;
            DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTime[1] = dateTime2.AddDays(-1);
            this.orderFromdate = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), CompanyID, Convert.ToInt32(this.StoreUserID), false);
            this.orderTodate = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), CompanyID, Convert.ToInt32(this.StoreUserID), false);
            dataTable = OrderBasePage.Orderreport_systemgenerated(CompanyID, this.StoreUserID, dateTime[0], dateTime[1], this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
            this.hdnOrderFromdate.Value = dateTime[0].ToString();
            this.hdnOrderTodate.Value = dateTime[1].ToString();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Item Code"))
                    {
                        row["Item Code"] = this.objBc.SpecialDecode(row["Item Code"].ToString());
                    }
                    if (row.Table.Columns.Contains("Item Title"))
                    {
                        row["Item Title"] = this.objBase.SpecialDecode(row["Item Title"].ToString());
                    }
                    if (row.Table.Columns.Contains("End user Cost Centre"))
                    {
                        row["End user Cost Centre"] = this.objBase.SpecialDecode(row["End user Cost Centre"].ToString());
                    }
                    if (row.Table.Columns.Contains("Contact"))
                    {
                        row["Contact"] = this.objBase.SpecialDecode(row["Contact"].ToString());
                    }
                    if (row.Table.Columns.Contains("Customer"))
                    {
                        row["Customer"] = this.objBase.SpecialDecode(row["Customer"].ToString());
                    }
                    if (row.Table.Columns.Contains("Department"))
                    {
                        row["Department"] = this.objBase.SpecialDecode(row["Department"].ToString());
                    }
                    if (row.Table.Columns.Contains("Customer Code"))
                    {
                        row["Customer Code"] = this.objBase.SpecialDecode(row["Customer Code"].ToString());
                    }
                    row.Table.Columns.Contains("OrderedDate");
                    if (!row.Table.Columns.Contains("Unit Cost"))
                    {
                        continue;
                    }
                    row["Unit Cost"] = this.comm.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row["Unit Cost"].ToString()), 2, "", false, false, true);
                }
            }
            this.Session["Orderreport_systemgeb_Orderdetails"] = dataTable;
            this.RadGrid_Order_Report.DataSource = dataTable;
            this.RadGrid_Order_Report.DataBind();
        }

        public void RadGridProductCustomerReport_stock_allocatedcustomer(int CompanyID)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            try
            {
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataTable dataTable = new DataTable();
                dataTable = OrderBasePage.ProductReport_Stockrelease_adjustment((long)CompanyID, Convert.ToDateTime(dateTime[0]), Convert.ToDateTime(dateTime[1]), this.StoreUserID);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("ParentCategory/SubCategory"))
                        {
                            row["ParentCategory/SubCategory"] = this.objBase.SpecialDecode(row["ParentCategory/SubCategory"].ToString());
                        }
                        if (row.Table.Columns.Contains("Itemcode"))
                        {
                            row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                        }
                        if (row.Table.Columns.Contains("CustomerCode"))
                        {
                            row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                        }
                        if (row.Table.Columns.Contains("ItemTitle"))
                        {
                            row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                        }
                        if (!row.Table.Columns.Contains("ItemDescription"))
                        {
                            continue;
                        }
                        row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                    }
                }
                this.RadGrid_stockallocatedcsutomer_new.DataSource = dataTable;
                this.RadGrid_stockallocatedcsutomer_new.DataBind();
            }
            catch
            {
            }
        }

        public void RadGridProductCustomerReport_stockreleaseandadjustment(int CompanyID)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            try
            {
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataTable dataTable = new DataTable();
                dataTable = OrderBasePage.ProductReport_Stockrelease_adjustment((long)CompanyID, Convert.ToDateTime(dateTime[0]), Convert.ToDateTime(dateTime[1]), this.StoreUserID);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("ParentCategory/SubCategory"))
                        {
                            row["ParentCategory/SubCategory"] = this.objBase.SpecialDecode(row["ParentCategory/SubCategory"].ToString());
                        }
                        if (row.Table.Columns.Contains("Itemcode"))
                        {
                            row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                        }
                        if (row.Table.Columns.Contains("CustomerCode"))
                        {
                            row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                        }
                        if (row.Table.Columns.Contains("ItemTitle"))
                        {
                            row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                        }
                        if (!row.Table.Columns.Contains("ItemDescription"))
                        {
                            continue;
                        }
                        row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                    }
                }
                this.Session["prodreport_systemen_stockusage_byadjustment"] = dataTable;
                this.RadGridProductReport_Customer_stockadjustment.DataSource = dataTable;
                this.RadGridProductReport_Customer_stockadjustment.DataBind();
            }
            catch
            {
            }
        }

        public void RadGridProductReport_stockreportwithquarter_sales(int CompanyID)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            try
            {
                DataTable dataTable = OrderBasePage.Product_Report_quartersales((long)CompanyID, this.StoreUserID);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("Category"))
                        {
                            row["Category"] = this.objBase.SpecialDecode(row["Category"].ToString());
                        }
                        if (row.Table.Columns.Contains("CustomerCode"))
                        {
                            row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                        }
                        if (row.Table.Columns.Contains("ItemTitle"))
                        {
                            row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                        }
                        if (row.Table.Columns.Contains("ProductDescription"))
                        {
                            row["ProductDescription"] = this.objBase.SpecialDecode(row["ProductDescription"].ToString());
                        }
                        if (!row.Table.Columns.Contains("Supplier"))
                        {
                            continue;
                        }
                        row["Supplier"] = this.objBase.SpecialDecode(row["Supplier"].ToString());
                    }
                }
                this.Session["prodreport_systemen_stockusage_quarterlysales"] = dataTable;
                this.GridProductReport_quarterlysales.DataSource = dataTable;
                this.GridProductReport_quarterlysales.DataBind();
            }
            catch
            {
            }
        }

        protected void RadGridProductReportCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)e.Item.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtToDate");
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                if (textBox != null)
                {
                    if (this.FromDate != "")
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.FromDate, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    else
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                if (textBox1 != null)
                {
                    if (this.ToDate != "")
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.ToDate, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    else
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem item = (GridFilteringItem)e.Item;
                    item["Openingstock"].HorizontalAlign = HorizontalAlign.Right;
                    item["Releases"].HorizontalAlign = HorizontalAlign.Right;
                    item["Receipts"].HorizontalAlign = HorizontalAlign.Right;
                    item["Adjustments"].HorizontalAlign = HorizontalAlign.Right;
                    item["ClosingStock"].HorizontalAlign = HorizontalAlign.Right;
                    item["ReleasesOverLast13Weeks"].HorizontalAlign = HorizontalAlign.Right;
                    item["WeeksRemaining"].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch
            {
            }
        }

        protected void RadGridProductReportCustomer_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.div_Reports_Names.Attributes.Add("style", "display:none");
                this.div_reportgrid.Attributes.Add("style", "display:none");
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                GridTableView masterTableView = this.RadGridProductReport_Customer_stockadjustment.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                this.FromDate = textBox.Text;
                this.ToDate = textBox1.Text;
                this.hdnProductFormDate.Value = textBox.Text;
                this.hdnProductToDate.Value = textBox1.Text;
                DataTable dataTable = new DataTable();
                dataTable = OrderBasePage.ProductReport_Stockrelease_adjustment((long)this.CompanyID, Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate), this.StoreUserID);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.Table.Columns.Contains("ParentCategory/SubCategory"))
                        {
                            row["ParentCategory/SubCategory"] = this.objBase.SpecialDecode(row["ParentCategory/SubCategory"].ToString());
                        }
                        if (row.Table.Columns.Contains("Itemcode"))
                        {
                            row["Itemcode"] = this.objBase.SpecialDecode(row["Itemcode"].ToString());
                        }
                        if (row.Table.Columns.Contains("CustomerCode"))
                        {
                            row["CustomerCode"] = this.objBase.SpecialDecode(row["CustomerCode"].ToString());
                        }
                        if (row.Table.Columns.Contains("ItemTitle"))
                        {
                            row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                        }
                        if (!row.Table.Columns.Contains("ItemDescription"))
                        {
                            continue;
                        }
                        row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                    }
                }
                //this.RadGridProductReport_Customer_stockadjustment.DataSource = dataTable;
                this.exportToXlsx(dataTable, this.RadGridProductReport_Customer_stockadjustment.ExportSettings.FileName.ToString());
            }
            catch
            {
            }
        }

        protected void RadGridReports_ItemDataBound(object sender, GridItemEventArgs e)
        {
            this.jobreport_systemgenname = "sales/order report";
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGridReports_salesorderreport.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGridReports_salesorderreport.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void RadGridstockUsageReport_bymonthandyear(int CompanyID)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Prod_report_stockusage_bymontandYear((long)CompanyID, this.StoreUserID, "", "");
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Stock Code"))
                    {
                        row["Stock Code"] = this.objBase.SpecialDecode(row["Stock Code"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    row["Product Name"] = this.objBase.SpecialDecode(row["Product Name"].ToString());
                }
            }
            this.Session["prodreport_systemen_stockusage_bymonth"] = dataTable;
            this.RadGrid_StockUsageReport_bymonthandyear.DataSource = dataTable;
            this.RadGrid_StockUsageReport_bymonthandyear.DataBind();
        }

        public void RadGridstockUsageReportInPacks(int companyid)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataSet dataSet = new DataSet();
            dataSet = OrderBasePage.productreport_stockusage((long)this.CompanyID, this.StoreUserID);
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            this.Session["prodreport_systemen_stockusage"] = dataSet;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Table.Columns.Contains("ItemTitle"))
                {
                    row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                }
                if (!row.Table.Columns.Contains("Item Code"))
                {
                    continue;
                }
                row["ItemCode"] = this.objBase.SpecialDecode(row["ItemCode"].ToString());
            }
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                if (!dataRow.Table.Columns.Contains("TotalExCCost") || dataRow["TotalExCCost"] == null)
                {
                    continue;
                }
                this.hdnTotalcost.Value = dataRow["TotalExCCost"].ToString();
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalExCCost"].ToString()), 2, "", false, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs_stockusagereport.DataSource = dataTable;
            this.RadStockUsage_Packs_stockusagereport.DataBind();
        }

        protected void RadStockUsage_Packs_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem item = (GridFilteringItem)e.Item;
                item["SoldInPacksOf"].HorizontalAlign = HorizontalAlign.Right;
                item["QuantityOnHand"].HorizontalAlign = HorizontalAlign.Right;
                item["AllocatedStock"].HorizontalAlign = HorizontalAlign.Right;
                item["AvailableStock"].HorizontalAlign = HorizontalAlign.Right;
                item["StockOnBackOrder"].HorizontalAlign = HorizontalAlign.Right;
                item["CostPerPack"].HorizontalAlign = HorizontalAlign.Right;
                item["BackOrderValue"].HorizontalAlign = HorizontalAlign.Right;
                item["CostquantityOnBackOrder"].HorizontalAlign = HorizontalAlign.Right;
            }
            if (e.Item is GridFooterItem)
            {
                GridFooterItem str = (GridFooterItem)e.Item;
                if (str["CostquantityOnBackOrder"].FindControl("lblTotalCostQuantityvalue") is Label)
                {
                    (str["CostquantityOnBackOrder"].FindControl("lblTotalCostQuantityvalue") as Label).Text = this.hdnTotalcost.Value.ToString();
                }
            }
        }

        protected void RadStockUsage_Packs_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.div_reportgrid.Attributes.Add("style", "display:none");
            this.div_Reports_Names.Attributes.Add("style", "display:none");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataSet dataSet = OrderBasePage.productreport_stockusage((long)this.CompanyID, this.StoreUserID);
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                if (!row.Table.Columns.Contains("ItemTitle"))
                {
                    continue;
                }
                row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
            }
            foreach (DataRow dataRow in dataSet.Tables[1].Rows)
            {
                if (!dataRow.Table.Columns.Contains("TotalExCCost") || dataRow["TotalExCCost"] == null)
                {
                    continue;
                }
                this.hdnTotalcost.Value = dataRow["TotalExCCost"].ToString();
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["TotalExCCost"].ToString()), 2, "", false, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            //this.RadStockUsage_Packs_stockusagereport.DataSource = dataTable;
            this.exportToXlsx(dataTable, this.RadStockUsage_Packs_stockusagereport.ExportSettings.FileName.ToString());

        }


        protected void exportToXlsx(DataTable dt, string filename)
        {
            DataSet ds = new DataSet();
            DataTable dtCopy1 = dt.Copy();
            ds.Tables.Add(dtCopy1);
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable _dt in ds.Tables)
                {
                    wb.Worksheets.Add(_dt);
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", string.Concat("attachment; filename=\"", filename, "\".xlsx"));
                //  Response.AddHeader("content-disposition", "attachment;filename=Productcatalogue Report_Excel.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }

    }
}