using ClosedXML.Excel;
using ePrint.ePrintUtilities;
using Microsoft.Ajax.Utilities;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Company;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RestSharp.Extensions;
using Stripe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol
{
    public partial class Reports : System.Web.UI.UserControl
    {

        public string DateFormat = "mm/dd/yyyy";

        private commonClass objCommon = new commonClass();

        public languageClass objLanguage = new languageClass();

        public int CompanyID;

        public int UserID;

        public int SystemReportCustCount;

        public string pagename = string.Empty;

        public int ManageStockPermission;

        public string FromDate = string.Empty;

        public string ToDate = string.Empty;

        public string JobFromDate = string.Empty;

        public string JobToDate = string.Empty;

        public bool isstockitem;

        public bool isreplenshes;

        public string orderFromdate = string.Empty;

        public string orderTodate = string.Empty;

        public BaseClass objBase = new BaseClass();

        public bool AllowUnApprovedOrder;

        public string strImagepath = global.imagePath();


        public int IsStoctUsageReport;

        public int IsStockUsageReportNew;

        public int IsStockReportMonth_Year;

        public int IsStockReportMonth_Year_History;

        public int IsStockReportMonth_YearReport;

        public int IsStockReportMonth_Year_HistoryReport;

        public int IsStockAdjustment;

        public int IsStockQuarterly;

        public int IsProductSalesReport;

        public int IsSalesOrderReport;

        public int IsStockAdjustmentNew;

        public int IsItemsWithReorderAlertsSet;

        public int ItemsRequiringReorder;

        public static string WhereCondition;

        private DataTable dtsearch = new DataTable();

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

        static Reports()
        {
            Reports.WhereCondition = string.Empty;
        }
        public string strSitepath = string.Empty;
        public Reports()
        {
            strSitepath = objBase.strSitepath;
        }

        protected void Back_Onclick(object sender, EventArgs e)
        {
            HideAllGridControls();
            this.GridReports.Visible = true;

            this.hdnParticluarClientID.Value = "";
            this.hdnCustomerTypeFilter.Value = "";
            this.hdnDurationFilter.Value = "";

            this.divReceipts.Style.Add("display", "none");
        }

        protected void btnJobGo_OnClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtJobFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtJobToDate");
            textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
            textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
            this.JobFromDate = textBox.Text;
            this.JobToDate = textBox1.Text;

            // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
            DataSet dataSet;
            if (hdnStockProdSalRelRep2.Value != "1")
            {
                dataSet = SettingsBasePage.JobReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
            }
            else
            {
                dataSet = SettingsBasePage.JobReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
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
                GridTableView masterTableView = this.RadGrid_Order_Report.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                RadComboBox radComboBox = (RadComboBox)items.FindControl("Customerlist");
                TextBox textBox = (TextBox)items.FindControl("txtOrderFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtOrderToDate");
                this.orderFromdate = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                this.orderTodate = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                this.hdnOrderFromdate.Value = this.orderFromdate;
                this.hdnOrderTodate.Value = this.orderTodate;
                if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["AllowUnApprovedOrder"]))
                {
                    this.AllowUnApprovedOrder = true;
                }
                if (this.hdnOrderClientID.Value != "")
                {
                    string str = this.hdnOrderClientID.Value.ToString();
                    str = str.Remove(str.Length - 1, 1);
                    this.hdnOrderClientID.Value = str;
                }
                DataTable dataTable = new DataTable();
                dataTable = SettingsBasePage.OrderDetailsReport((long)this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Convert.ToDateTime(this.hdnOrderFromdate.Value), Convert.ToDateTime(this.hdnOrderTodate.Value), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
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
                        if (!row.Table.Columns.Contains("Customer Code"))
                        {
                            continue;
                        }
                        row["Customer Code"] = this.objBase.SpecialDecode(row["Customer Code"].ToString());
                    }
                }
                this.RadGrid_Order_Report.DataSource = dataTable;
                this.RadGrid_Order_Report.DataBind();
            }
            catch (Exception exception)
            {
            }
        }

        protected void btnProductGo_OnClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGridProductReport_Customer.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
            textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
            textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
            this.FromDate = textBox.Text;
            this.ToDate = textBox1.Text;
            // added code for new report "Stock Release and Adjustment Report 2" by shehzad
            DataTable dataTable;
            if (hdnStockReleaseAdjRep2.Value != "1")
            {
                dataTable = SettingsBasePage.ProductReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
            }
            else
            {
                dataTable = SettingsBasePage.ProductReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
            }

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
            this.RadGridProductReport_Customer.DataSource = dataTable;
            this.RadGridProductReport_Customer.DataBind();
        }

        protected void btnProductGoNew_OnClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGridProductReport_CustomerNew.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
            textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
            textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
            this.FromDate = textBox.Text;
            this.ToDate = textBox1.Text;
            DataTable dataTable;
            if (hdnStockReleaseAdjRep2.Value != "1")
            {
                dataTable = SettingsBasePage.ProductReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
            }
            else
            {
                dataTable = SettingsBasePage.ProductReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
            }

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
            this.RadGridProductReport_CustomerNew.DataSource = dataTable;
            this.RadGridProductReport_CustomerNew.DataBind();
        }

        protected void btnStockUsage_PacksReportGo_MyProj_onClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadStockUsage_Packs_MyProj.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            RadComboBox radComboBox = (RadComboBox)items.FindControl("Customerlist");
            if (this.hdnOrderClientID.Value != "")
            {
                string str = this.hdnOrderClientID.Value.ToString();
                str = str.Remove(str.Length - 1, 1);
                this.hdnOrderClientID.Value = str;
            }
            try
            {
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                DataSet stockUsageInPacks = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Reports.WhereCondition);
                this.RadStockUsage_Packs_MyProj.DataSource = stockUsageInPacks.Tables[0];
                this.RadStockUsage_Packs_MyProj.DataBind();
            }
            catch
            {
            }
        }

        protected void btnStockUsage_PacksReportGo_onClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadStockUsage_Packs.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            RadComboBox radComboBox = (RadComboBox)items.FindControl("Customerlist");
            if (this.hdnOrderClientID.Value != "")
            {
                string str = this.hdnOrderClientID.Value.ToString();
                str = str.Remove(str.Length - 1, 1);
                this.hdnOrderClientID.Value = str;
            }
            try
            {
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                DataSet stockUsageInPacks = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Reports.WhereCondition);
                foreach (DataRow row in stockUsageInPacks.Tables[1].Rows)
                {
                    if (!row.Table.Columns.Contains("TotalExCCost") || row["TotalExCCost"] == null)
                    {
                        continue;
                    }
                    this.hdnTotalcost.Value = row["TotalExCCost"].ToString();
                    string str1 = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                    this.hdnTotalcost.Value = str1;
                }
                this.RadStockUsage_Packs.DataSource = stockUsageInPacks.Tables[0];
                this.RadStockUsage_Packs.DataBind();
            }
            catch
            {
            }
        }

        protected void btnUsageReportGo_OnClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGrid_StockUsageReport.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            DataTable dataTable = SettingsBasePage.ProductstockUsageReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
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
            this.RadGrid_StockUsageReport.DataSource = dataTable;
            this.RadGrid_StockUsageReport.DataBind();
        }
        protected void btnUsageHistoryReportGo_OnClick(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGrid_StockUsageHistoryReport.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            DataTable dataTable = SettingsBasePage.ProductstockUsageHistoryReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
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

        public void ddlCustomerName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.hdnClientID.Value == "")
                {
                    this.hdnClientID.Value = "0";
                }
                DataTable dataTable = SettingsBasePage.CustomizeProduct_Report(this.CompanyID, Convert.ToInt64(this.hdnClientID.Value));
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
                this.GridProductReport.DataSource = dataTable;
                this.GridProductReport.DataBind();
            }
            catch
            {
            }
        }

        public void ddlUsageCustomerName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGrid_StockUsageReport.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            DropDownList dropDownList = (DropDownList)items.FindControl("ddldepartment");
            DataTable productSelectDepartment = SettingsBasePage.GetProduct_SelectDepartment(this.CompanyID, this.hdnParticluarClientID.Value);
            for (int i = 0; i < productSelectDepartment.Columns.Count; i++)
            {
                productSelectDepartment.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in productSelectDepartment.Rows)
            {
                row["Deptname"] = this.objBase.SpecialDecode(row["Deptname"].ToString());
            }
            dropDownList.DataSource = productSelectDepartment;
            dropDownList.DataTextField = "Deptname";
            dropDownList.DataValueField = "Deptid";
            dropDownList.DataBind();
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }
            DataTable dataTable = SettingsBasePage.ProductstockUsageReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                dataTable.Columns[j].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow.Table.Columns.Contains("Stock Code"))
                    {
                        dataRow["Stock Code"] = this.objBase.SpecialDecode(dataRow["Stock Code"].ToString());
                    }
                    if (!dataRow.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    dataRow["Product Name"] = this.objBase.SpecialDecode(dataRow["Product Name"].ToString());
                }
            }
            this.RadGrid_StockUsageReport.DataSource = dataTable;
            this.RadGrid_StockUsageReport.DataBind();
        }

        public void ddlUsageHistoryCustomerName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridTableView masterTableView = this.RadGrid_StockUsageHistoryReport.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            DropDownList dropDownList = (DropDownList)items.FindControl("ddldepartment");
            DataTable productSelectDepartment = SettingsBasePage.GetProduct_SelectDepartment(this.CompanyID, this.hdnParticluarClientID.Value);
            for (int i = 0; i < productSelectDepartment.Columns.Count; i++)
            {
                productSelectDepartment.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in productSelectDepartment.Rows)
            {
                row["Deptname"] = this.objBase.SpecialDecode(row["Deptname"].ToString());
            }
            dropDownList.DataSource = productSelectDepartment;
            dropDownList.DataTextField = "Deptname";
            dropDownList.DataValueField = "Deptid";
            dropDownList.DataBind();
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }
            DataTable dataTable = SettingsBasePage.ProductstockUsageHistoryReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                dataTable.Columns[j].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow.Table.Columns.Contains("Stock Code"))
                    {
                        dataRow["Stock Code"] = this.objBase.SpecialDecode(dataRow["Stock Code"].ToString());
                    }
                    if (!dataRow.Table.Columns.Contains("Product Name"))
                    {
                        continue;
                    }
                    dataRow["Product Name"] = this.objBase.SpecialDecode(dataRow["Product Name"].ToString());
                }
            }
            this.RadGrid_StockUsageHistoryReport.DataSource = dataTable;
            this.RadGrid_StockUsageHistoryReport.DataBind();
        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                Convert.ToInt32(row["Roundoff"].ToString());
            }
            base.Session["SearchProd_History"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && Reports.WhereCondition != "")
                {
                    Reports.WhereCondition = string.Concat(Reports.WhereCondition, " and ");
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = Reports.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", dataRow["ColumnName"].ToString(), " like '", dataRow["FilterText"].ToString().Trim(), "%'" };
                            Reports.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = Reports.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string whereCondition2 = Reports.WhereCondition;
                            string[] str2 = new string[] { whereCondition2, " ", dataRow["ColumnName"].ToString(), " = '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(str2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition3 = Reports.WhereCondition;
                            string[] strArrays2 = new string[] { whereCondition3, " ", dataRow["ColumnName"].ToString(), " != '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 4:
                        {
                            string str3 = Reports.WhereCondition;
                            string[] strArrays3 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            Reports.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition4 = Reports.WhereCondition;
                            string[] str4 = new string[] { whereCondition4, " ", dataRow["ColumnName"].ToString(), " not like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            Reports.WhereCondition = string.Concat(str4);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition5 = Reports.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition5, " ", dataRow["ColumnName"].ToString(), " > '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 7:
                        {
                            string str5 = Reports.WhereCondition;
                            string[] strArrays5 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " < '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition6 = Reports.WhereCondition;
                            string[] str6 = new string[] { whereCondition6, " ", dataRow["ColumnName"].ToString(), " >= '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(str6);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition7 = Reports.WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition7, " ", dataRow["ColumnName"].ToString(), " <= '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 10:
                        {
                            Reports.WhereCondition = string.Concat(Reports.WhereCondition, " ", dataRow["ColumnName"].ToString(), " = ''");
                            continue;
                        }
                    case 11:
                        {
                            Reports.WhereCondition = string.Concat(Reports.WhereCondition, " ", dataRow["ColumnName"].ToString(), " != ''");
                            continue;
                        }
                    case 12:
                        {
                            Reports.WhereCondition = string.Concat(Reports.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is null");
                            continue;
                        }
                    case 13:
                        {
                            Reports.WhereCondition = string.Concat(Reports.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str7 = Reports.WhereCondition;
                            string[] strArrays7 = new string[] { str7, " ", dataRow["ColumnName"].ToString(), " between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition8 = Reports.WhereCondition;
                            string[] str8 = new string[] { whereCondition8, " ", dataRow["ColumnName"].ToString(), " not between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            Reports.WhereCondition = string.Concat(str8);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return Reports.WhereCondition;
        }

        public void GridBind(int CompanyID, string pagename)
        {
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_Reports_List", this.objCommon.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageName", pagename);
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            DataTable item = dataSet.Tables[0];
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("ReportID", typeof(int));
            dataTable2.Columns.Add("ReportName", typeof(string));
            dataTable2.Columns.Add("Description", typeof(string));
            dataTable2.Columns.Add("CreatedBy", typeof(string));
            dataTable2.Columns.Add("CreatedDate", typeof(DateTime));
            dataTable2.Columns.Add("AllocatedCustomers", typeof(int));
            if (pagename == "job")
            {
                DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(CompanyID);
                this.ManageStockPermission = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
                foreach (DataRow row in WebstoreBasePage.EstoreSystemReport_CustomerCount("job").Rows)
                {
                    //if (row["EstoreReportType"].ToString().Trim() != "Product Sales Report")
                    if (row["EstoreReportType"].ToString().Trim() != "Stock Product (Allocation) Report")
                    {
                        if (row["EstoreReportType"].ToString().Trim() != "Sales/Order Report")
                        {
                            continue;
                        }
                        this.IsSalesOrderReport = Convert.ToInt32(row["CustomerCount"].ToString());
                    }
                    else
                    {
                        this.IsProductSalesReport = Convert.ToInt32(row["CustomerCount"].ToString());
                    }
                }

                if (this.ManageStockPermission == 1)
                {
                    DataRowCollection rows = dataTable2.Rows;
                    //object[] now = new object[] { 0, "Product Sales Report", "", "System Report: Sales/Order", DateTime.Now, this.IsProductSalesReport };
                    object[] now = new object[] { 0, "Stock Product (Allocation) Report", "", "System Report: Sales/Order", DateTime.Now, this.IsProductSalesReport };
                    rows.Add(now);

                    // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
                    DataRowCollection rowCollection = dataTable2.Rows;
                    object[] newReport = new object[] { 0, "Stock Product Sales (Release) Report", "", "System Report: Sales/Order", DateTime.Now, this.IsProductSalesReport };
                    rowCollection.Add(newReport);
                }
                DataRowCollection dataRowCollection = dataTable2.Rows;
                object[] objArray = new object[] { 0, "Sales/Order Report", "", "System Report: Sales/Order", DateTime.Now, this.IsSalesOrderReport };
                dataRowCollection.Add(objArray);
                dataTable = dataTable2.Copy();
                dataTable.Merge(item, true);
            }
            else if (pagename == "")
            {
                DataTable dataTable3 = SettingsBasePage.settings_companyprofile_select(CompanyID);
                this.ManageStockPermission = Convert.ToInt32(dataTable3.Rows[0]["ProductStockManagement"]);
                DataTable dataTable4 = new DataTable();
                foreach (DataRow dataRow in WebstoreBasePage.EstoreSystemReport_CustomerCount("product").Rows)
                {
                    if (dataRow["EstoreReportType"].ToString().Trim() == "Stock Usage Report")
                    {
                        this.IsStoctUsageReport = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (dataRow["EstoreReportType"].ToString().Trim() == "Stock Usage Report New")
                    {
                        this.IsStockUsageReportNew = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (dataRow["EstoreReportType"].ToString().Trim().Contains("Stock Usage Report by Month and Year"))
                    {
                        this.IsStockReportMonth_Year = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (dataRow["EstoreReportType"].ToString().Trim().Contains("Stock Usage Report(History)"))
                    {
                        this.IsStockReportMonth_Year_History = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (dataRow["EstoreReportType"].ToString().Trim().Contains("Stock Release and Adjustment Report"))
                    {
                        this.IsStockAdjustment = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (dataRow["EstoreReportType"].ToString().Trim().Contains("Items with Reorder Alerts Set"))
                    {
                        this.IsItemsWithReorderAlertsSet = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (dataRow["EstoreReportType"].ToString().Trim().Contains("Items Requiring Reorder"))
                    {
                        this.ItemsRequiringReorder = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else if (!dataRow["EstoreReportType"].ToString().Trim().Contains("Stock Report with Quarterly Sales"))
                    {
                        if (!dataRow["EstoreReportType"].ToString().Trim().Contains("Stock Allocation Report"))
                        {
                            continue;
                        }
                        this.IsStockAdjustmentNew = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                    else
                    {
                        this.IsStockQuarterly = Convert.ToInt32(dataRow["CustomerCount"].ToString());
                    }
                }
                if (this.ManageStockPermission == 1)
                {
                    dataTable4.Columns.Add("ReportID", typeof(int));
                    dataTable4.Columns.Add("ReportName", typeof(string));
                    dataTable4.Columns.Add("Description", typeof(string));
                    dataTable4.Columns.Add("CreatedBy", typeof(string));
                    dataTable4.Columns.Add("CreatedDate", typeof(DateTime));
                    dataTable4.Columns.Add("AllocatedCustomers", typeof(int));
                    DataRowCollection rows1 = dataTable4.Rows;
                    object[] now1 = new object[] { 0, "Stock Usage Report", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStoctUsageReport };
                    rows1.Add(now1);
                    if (ConnectionClass.ServerName.ToLower() == "myprojexinventory" || ConnectionClass.ServerName.ToLower() == "anil_v4_0" || ConnectionClass.ServerName.ToLower() == "prelive_4")
                    {
                        DataRowCollection dataRowCollection1 = dataTable4.Rows;
                        object[] objArray1 = new object[] { 0, "Stock Usage Report New", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockUsageReportNew };
                        dataRowCollection1.Add(objArray1);
                    }
                    DataRowCollection rows2 = dataTable4.Rows;
                    object[] now2 = new object[] { 0, "Stock Usage Report by Month and Year", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockReportMonth_Year };
                    rows2.Add(now2);

                    DataRowCollection rowHistory = dataTable4.Rows;
                    object[] rowData = new object[] { 0, "Stock Usage Report(History)", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockReportMonth_Year_History };
                    rowHistory.Add(rowData);

                    DataRowCollection dataRowCollection2 = dataTable4.Rows;
                    object[] objArray2 = new object[] { 0, "Stock Usage Report - Cost Price", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStoctUsageReport };
                    dataRowCollection2.Add(objArray2);
                    //Below code commented by KR 29AUG2018
                    //Stock Release and Adjustment Report was removed
                    /*
                    DataRowCollection dataRowCollection2 = dataTable4.Rows;
                    object[] objArray2 = new object[] { 0, "Stock Release and Adjustment Report", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockAdjustment };
                    dataRowCollection2.Add(objArray2);
                    */

                    DataRowCollection dataRowCollection4 = dataTable4.Rows;
                    //object[] objArray4 = new object[] { 0, "Stock Release and Adjustment Report 2", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockAdjustmentNew };
                    //Rename the report (remove 2 at the end)
                    //KR comments 29AUG2018
                    object[] objArray4 = new object[] { 0, "Stock Release and Adjustment Report", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockAdjustmentNew };
                    dataRowCollection4.Add(objArray4);

                    DataRowCollection rows3 = dataTable4.Rows;
                    object[] now3 = new object[] { 0, "Stock Report with Quarterly Sales", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockQuarterly };
                    rows3.Add(now3);
                    DataRowCollection dataRowCollection3 = dataTable4.Rows;
                    object[] objArray3 = new object[] { 0, "Stock Allocation Report", "", "System Report: Products (Inventory)", DateTime.Now, this.IsStockAdjustmentNew };
                    dataRowCollection3.Add(objArray3);

                    DataRowCollection ItemsWithReorderAlertsSet = dataTable4.Rows;
                    object[] itemAlertSet3 = new object[] { 0, "Items with Reorder Alerts Set", "", "System Report: Products (Inventory)", DateTime.Now, this.IsItemsWithReorderAlertsSet };
                    ItemsWithReorderAlertsSet.Add(itemAlertSet3);

                    DataRowCollection ItemsRequiringReorder = dataTable4.Rows;
                    object[] itemRequiringOrder3 = new object[] { 0, "Items Requiring Reorder", "", "System Report: Products (Inventory)", DateTime.Now, this.ItemsRequiringReorder };
                    ItemsRequiringReorder.Add(itemRequiringOrder3);

                    dataTable = dataTable4.Copy();
                }
                dataTable.Merge(item, true);
            }
            else if (pagename == "activitycallreport")
            {
                this.GridReports.MasterTableView.GetColumn("AllocatedCustomers").Display = false;
                DataTable dataTable5 = new DataTable();
                dataTable5.Columns.Add("ReportID", typeof(int));
                dataTable5.Columns.Add("ReportName", typeof(string));
                dataTable5.Columns.Add("Description", typeof(string));
                dataTable5.Columns.Add("CreatedBy", typeof(string));
                dataTable5.Columns.Add("CreatedDate", typeof(DateTime));
                DataRowCollection rows4 = dataTable5.Rows;
                object[] now4 = new object[] { 0, "Call Report", "", "System Generated", DateTime.Now };
                rows4.Add(now4);
                dataTable = dataTable5.Copy();
                dataTable.Merge(item, true);
            }
            else if (pagename == "webstoreorder")
            {
                DataTable dataTable6 = SettingsBasePage.settings_companyprofile_select(CompanyID);
                this.ManageStockPermission = Convert.ToInt32(dataTable6.Rows[0]["ProductStockManagement"]);
                DataTable dataTable7 = new DataTable();
                foreach (DataRow row1 in WebstoreBasePage.EstoreSystemReport_CustomerCount("order").Rows)
                {
                    if (row1["EstoreReportType"].ToString().Trim() != "Order Details Report")
                    {
                        continue;
                    }
                    this.SystemReportCustCount = Convert.ToInt32(row1["CustomerCount"].ToString());
                }
                dataTable7.Columns.Add("ReportID", typeof(int));
                dataTable7.Columns.Add("ReportName", typeof(string));
                dataTable7.Columns.Add("Description", typeof(string));
                dataTable7.Columns.Add("CreatedBy", typeof(string));
                dataTable7.Columns.Add("CreatedDate", typeof(DateTime));
                dataTable7.Columns.Add("AllocatedCustomers", typeof(int));
                if (this.ManageStockPermission == 1)
                {
                    DataRowCollection dataRowCollection4 = dataTable7.Rows;
                    object[] objArray4 = new object[] { 0, "Order Details Report", "", "System Report: Order", DateTime.Now, this.SystemReportCustCount };
                    dataRowCollection4.Add(objArray4);
                }
                DataRowCollection dataRowCollectionAllOrders = dataTable7.Rows;
                object[] objArrayOrders = new object[] { 0, "All Orders by Customer", "", "System Report: Order", DateTime.Now, this.SystemReportCustCount };
                dataRowCollectionAllOrders.Add(objArrayOrders);

                dataTable = dataTable7.Copy();
                dataTable.Merge(item, true);
            }
            else if (pagename == "invoice")
            {
                DataTable dataTable5 = new DataTable();
                dataTable5.Columns.Add("ReportID", typeof(int));
                dataTable5.Columns.Add("ReportName", typeof(string));
                dataTable5.Columns.Add("Description", typeof(string));
                dataTable5.Columns.Add("CreatedBy", typeof(string));
                dataTable5.Columns.Add("CreatedDate", typeof(DateTime));
                dataTable5.Columns.Add("AllocatedCustomers", typeof(int));
                DataRowCollection rows1 = dataTable5.Rows;
                object[] now1 = new object[] { 0, "Customer Yearly Comparison Report", "", "System Report", DateTime.Now, this.IsStoctUsageReport };
                rows1.Add(now1);
                object[] now = new object[] { 0, "All Invoices by Customer", "", "System Report", DateTime.Now, true };
                rows1.Add(now);
                object[] allInvoicesByAccountingCode = new object[] { 0, "All Invoices by Accounting Code", "", "System Report", DateTime.Now, true };
                rows1.Add(allInvoicesByAccountingCode);

                dataTable = dataTable5.Copy();
                dataTable.Merge(item, true);

            }
            if (pagename == "estimate" || pagename == "job" || pagename == "client" || pagename == "warehouse" || pagename == "deliverynote" || pagename == "purchase" || pagename == "activitytaskeventreport" || pagename == "activitycallreport")
            {
                DataRowCollection rows = dataTable2.Rows;
                if (pagename == "estimate" || pagename == "job")
                {
                    if (pagename == "estimate")
                    {
                        object[] now = new object[] { 0, "All Estimates by Customer", "", "Support Team", DateTime.Now, true };
                        rows.Add(now);
                    }
                    else if (pagename == "job")
                    {
                        object[] now = new object[] { 0, "All Jobs by Customer", "", "Support Team", DateTime.Now, true };
                        rows.Add(now);
                    }

                    dataTable = dataTable2.Copy();
                    dataTable.Merge(item, true);
                }

                this.GridReports.MasterTableView.GetColumn("AllocatedCustomers").Display = false;
                ScriptManager.RegisterStartupScript(this, base.GetType(), "myFunction", "checkButtonChecked();", true);
            }
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            if (item != null)
            {
                foreach (DataRow dataRow1 in item.Rows)
                {
                    if (dataRow1.Table.Columns.Contains("ReportName"))
                    {
                        dataRow1["ReportName"] = this.objBase.SpecialDecode(dataRow1["ReportName"].ToString());
                    }
                    if (dataRow1.Table.Columns.Contains("Description"))
                    {
                        dataRow1["Description"] = this.objBase.SpecialDecode(dataRow1["Description"].ToString());
                    }
                    if (!dataRow1.Table.Columns.Contains("CreatedBy"))
                    {
                        continue;
                    }
                    dataRow1["CreatedBy"] = this.objBase.SpecialDecode(dataRow1["CreatedBy"].ToString());
                }
            }
            if (pagename == "estimate" || pagename == "job" || pagename == "" || pagename == "activitycallreport" || pagename == "webstoreorder" || pagename == "invoice")
            {
                foreach (DataRow row2 in dataTable.Rows)
                {
                    if (row2.Table.Columns.Contains("ReportName"))
                    {
                        row2["ReportName"] = this.objBase.SpecialDecode(row2["ReportName"].ToString());
                    }
                    if (row2.Table.Columns.Contains("Description"))
                    {
                        row2["Description"] = this.objBase.SpecialDecode(row2["Description"].ToString());
                    }
                    if (!row2.Table.Columns.Contains("CreatedBy"))
                    {
                        continue;
                    }
                    row2["CreatedBy"] = this.objBase.SpecialDecode(row2["CreatedBy"].ToString());
                }
                this.GridReports.DataSource = dataTable;
            }
            else
            {
                this.GridReports.DataSource = dataSet;
            }
            this.GridReports.DataBind();
            this.objCommon.closeConnection();
        }

        protected void GridClientReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.CustomizeClient_Report(this.CompanyID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Customer"))
                    {
                        row["Customer"] = this.objBase.SpecialDecode(row["Customer"].ToString());
                    }
                    if (row.Table.Columns.Contains("ContactName"))
                    {
                        row["ContactName"] = this.objBase.SpecialDecode(row["ContactName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Subject"))
                    {
                        row["Subject"] = this.objBase.SpecialDecode(row["Subject"].ToString());
                    }
                    if (row.Table.Columns.Contains("CallPurpose"))
                    {
                        row["CallPurpose"] = this.objBase.SpecialDecode(row["CallPurpose"].ToString());
                    }
                    if (row.Table.Columns.Contains("CallResult"))
                    {
                        row["CallResult"] = this.objBase.SpecialDecode(row["CallResult"].ToString());
                    }
                    if (row.Table.Columns.Contains("Description"))
                    {
                        row["Description"] = this.objBase.SpecialDecode(row["Description"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Status"))
                    {
                        continue;
                    }
                    row["Status"] = this.objBase.SpecialDecode(row["Status"].ToString());
                }
            }
            this.GridClientReport.DataSource = dataTable;
        }

        protected void GridProductReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DropDownList value = (DropDownList)e.Item.FindControl("ddlCustomerName");
                if (value != null)
                {
                    DataTable productCannedCustomer = SettingsBasePage.GetProductCanned_Customer(this.CompanyID);
                    for (int i = 0; i < productCannedCustomer.Columns.Count; i++)
                    {
                        productCannedCustomer.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productCannedCustomer.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                    }
                    value.DataSource = productCannedCustomer;
                    value.DataTextField = "clientname";
                    value.DataValueField = "clientID";
                    value.DataBind();
                    value.Items.Insert(0, new ListItem("-- Select --", "0"));
                    if (this.hdnClientID.Value != "0")
                    {
                        value.SelectedValue = this.hdnClientID.Value;
                    }
                }
                if (e.Item.ItemType == GridItemType.Header)
                {
                    if (this.hdnClientID.Value == "0")
                    {
                        e.Item.Cells[8].Text = base.Server.HtmlDecode("<div class='cannedreport_salesheader'>Sales</div><div class='cannedreport_salesheader'> (Inc Back Orders) </div>");
                    }
                    else
                    {
                        e.Item.Cells[8].Text = base.Server.HtmlDecode("<div class='cannedreport_salesheader'>Sales</div> <div class='cannedreport_salesheader'> (Inc Back Orders)</div> <div class='cannedreport_salesheader'>Per Customer</div>");
                    }
                }
            }
            catch
            {
            }
        }

        protected void GridProductReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (this.hdnClientID.Value == "")
                {
                    this.hdnClientID.Value = "0";
                }
                DataTable dataTable = SettingsBasePage.CustomizeProduct_Report(this.CompanyID, Convert.ToInt64(this.hdnClientID.Value));
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
                this.GridProductReport.DataSource = dataTable;
            }
            catch
            {
            }
        }

        protected void GridReports_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                ImageButton imageButton = (ImageButton)e.Item.FindControl("Imgedit");
                ImageButton imageButton1 = (ImageButton)e.Item.FindControl("ImgDelete");
                Label label = (Label)e.Item.FindControl("lblCreatedBy");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkReportName");
                linkButton.Click += new EventHandler(this.lnkReportName_Click);
                label.Text = this.objBase.SpecialDecode(label.Text);
                Label label1 = (Label)e.Item.FindControl("lblCreatedOn");
                Label label2 = (Label)e.Item.FindControl("lblAllocatedCustomers");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_ReportID");
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_AllocatedCustomers");
                label1.Text = this.objCommon.Eprint_return_Date_Before_View(label1.Text, this.CompanyID, this.UserID, true);
                string.Concat(this.strImagepath, "invoiced-paid.PNG");
                placeHolder.Controls.Clear();
                if (this.pagename == "webstoreorder")
                {
                    if (linkButton.Text == "Order Details Report")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    if (linkButton.Text == "All Orders by Customer")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    if (Convert.ToInt32(label2.Text) <= 0)
                    {
                        placeHolder.Controls.Add(new LiteralControl("<div>Not Allocated "));
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        Image image = new Image()
                        {
                            ID = string.Concat("img_", linkButton.Text),
                            ImageUrl = "~/images/invoiced-paid.PNG"
                        };
                        image.Style.Add("cursor", "pointer");
                        AttributeCollection attributes = image.Attributes;
                        string[] value = new string[] { "javascript:OpenCustomer_List('", hiddenField.Value, "','estorereports','", linkButton.Text, "','order');" };
                        attributes.Add("onclick", string.Concat(value));
                        placeHolder.Controls.Add(new LiteralControl("<div>Allocated "));
                        placeHolder.Controls.Add(image);
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                else if (this.pagename == "estimate")
                {
                    if (linkButton.Text == "All Estimates by Customer")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                }
                else if (this.pagename == "job")
                {
                    //if (linkButton.Text == "Product Sales Report")
                    if (linkButton.Text == "Stock Product (Allocation) Report")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    if (linkButton.Text == "All Jobs by Customer")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    else if (label.Text != "System Report: Sales/Order")
                    {
                        imageButton.Visible = true;
                        imageButton1.Visible = true;
                    }
                    else
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    if (Convert.ToInt32(label2.Text) <= 0)
                    {
                        placeHolder.Controls.Clear();
                        placeHolder.Controls.Add(new LiteralControl("<div>Not Allocated "));
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        Image image1 = new Image()
                        {
                            ID = string.Concat("img_", linkButton.Text),
                            ImageUrl = "~/images/invoiced-paid.PNG"
                        };
                        image1.Style.Add("cursor", "pointer");
                        AttributeCollection attributeCollection = image1.Attributes;
                        string[] strArrays = new string[] { "javascript:OpenCustomer_List('", hiddenField.Value, "','estorereports','", linkButton.Text, "','job');" };
                        attributeCollection.Add("onclick", string.Concat(strArrays));
                        placeHolder.Controls.Add(new LiteralControl("<div>Allocated "));
                        placeHolder.Controls.Add(image1);
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                else if (this.pagename == "invoice")
                {
                    if (label.Text != "System Report")
                    {
                        imageButton.Visible = true;
                        imageButton1.Visible = true;
                    }
                    else
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    if (Convert.ToInt32(label2.Text) <= 0)
                    {
                        placeHolder.Controls.Add(new LiteralControl("<div>Not Allocated "));
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        Image image2 = new Image()
                        {
                            ID = string.Concat("img_", linkButton.Text),
                            ImageUrl = "~/images/invoiced-paid.PNG"
                        };
                        image2.Style.Add("cursor", "pointer");
                        AttributeCollection attributes1 = image2.Attributes;
                        string[] value1 = new string[] { "javascript:OpenCustomer_List('", hiddenField.Value, "','estorereports','", linkButton.Text, "','invoice');" };
                        attributes1.Add("onclick", string.Concat(value1));
                        placeHolder.Controls.Add(new LiteralControl("<div>Allocated "));
                        placeHolder.Controls.Add(image2);
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                else if (this.pagename == "")
                {
                    if (linkButton.Text == "Stock Products Report")
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    else if (label.Text != "System Report: Products (Inventory)")
                    {
                        imageButton.Visible = true;
                        imageButton1.Visible = true;
                    }
                    else
                    {
                        imageButton.Visible = false;
                        imageButton1.Visible = false;
                    }
                    if (Convert.ToInt32(label2.Text) <= 0)
                    {
                        placeHolder.Controls.Add(new LiteralControl("<div>Not Allocated "));
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        Image image3 = new Image()
                        {
                            ID = string.Concat("img_", linkButton.Text),
                            ImageUrl = "~/images/invoiced-paid.PNG"
                        };
                        image3.Style.Add("cursor", "pointer");
                        AttributeCollection attributeCollection1 = image3.Attributes;
                        string[] strArrays1 = new string[] { "javascript:OpenCustomer_List('", hiddenField.Value, "','estorereports','", linkButton.Text, "','product');" };
                        attributeCollection1.Add("onclick", string.Concat(strArrays1));
                        placeHolder.Controls.Add(new LiteralControl("<div>Allocated "));
                        placeHolder.Controls.Add(image3);
                        placeHolder.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                else if (this.pagename != "activitycallreport")
                {
                    imageButton.Visible = true;
                    imageButton1.Visible = true;
                }
                else if (label.Text != "System Generated")
                {
                    imageButton.Visible = true;
                    imageButton1.Visible = true;
                }
                else
                {
                    imageButton.Visible = false;
                    imageButton1.Visible = false;
                }
                if (this.pagename == "client" || this.pagename == "warehouse" || this.pagename == "deliverynote" || this.pagename == "purchase" || this.pagename == "estimate" || this.pagename == "activitytaskeventreport" || this.pagename == "activitycallreport")
                {
                    ((HtmlInputCheckBox)e.Item.FindControl("Id")).Visible = false;
                }
            }
        }

        protected void GridReports_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.CompanyID = Convert.ToInt32(base.Session["companyid"].ToString());
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lnkReportName");
                linkButton.Click += new EventHandler(this.lnkReportName_Click);
                ImageButton imageButton = (ImageButton)e.Row.FindControl("Imgedit");
                Label label = (Label)e.Row.FindControl("lblCreatedOn");
                label.Text = this.objCommon.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
            }
        }

        protected void GridReports_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            this.OnPageIndexChanged();
        }

        protected void GridReports_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {
            this.OnPageSizeChanged();
        }

        private void GridStateSave()
        {
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGridReports);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.GridProductReport);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGrid_CustomerJobReport);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGridProductReport_Customer);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGrid_StockUsageReport);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGrid_StockUsageHistoryReport);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGrid_Order_Report);
            this.objCommon.GridStateSaveNew(this.pagename, string.Concat(this.UserID, this.pagename), this.RadGridProductReport_CustomerNew);
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                Reports.WhereCondition = "";
                if (base.Session["SearchProd_Stock"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["SearchProd_Stock"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["SearchProd_History"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] first = new object[] { str, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(first);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { str, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                base.Session["SearchProd_Stock"] = this.dtsearch;
                Reports.WhereCondition = this.FilterFunction(this.dtsearch);
            }
        }

        protected void ImgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            this.OnDeleteClick(Convert.ToInt32(imageButton.CommandArgument));
            this.CompanyID = Convert.ToInt32(base.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Url.ToString().ToLower().Contains("estimate_report"))
            {
                this.pagename = "estimate";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("job_report.aspx"))
            {
                this.pagename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("client_report.aspx"))
            {
                this.pagename = "client";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase_report.aspx"))
            {
                this.pagename = "purchase";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery_report.aspx"))
            {
                this.pagename = "deliverynote";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("inventory_report.aspx"))
            {
                this.pagename = "warehouse";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice_report.aspx"))
            {
                this.pagename = "invoice";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("/finishedgoods_report.aspx?type=store"))
            {
                this.pagename = "store";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("/finishedgoods_report.aspx?type=item"))
            {
                this.pagename = "item";
            }
            this.GridBind(this.CompanyID, this.pagename);
        }

        protected void Imgedit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            this.OnEditClick(Convert.ToInt32(imageButton.CommandArgument));
        }

        protected void lnkBtnClearFilter_Click(object sender, EventArgs e)
        {
            if (this.pagename == "estimate")
            {
                if (this.hdnParticularCustomer.Value == "AllEstimatesbyCustomer")
                {
                    ResetGridHeaderControls(sender);
                    this.BindRadGridAllEstimatesbyCustomer(this.CompanyID);
                }
            }
            if (this.pagename == "job")
            {
                if (this.hdnParticularCustomer.Value == "AllJobsbyCustomer")
                {
                    ResetGridHeaderControls(sender);
                    this.BindRadGridAllJobsbyCustomer(this.CompanyID);
                }
                else if (this.hdnParticularJobCustomer.Value != "yes")
                {
                    foreach (GridColumn column in this.RadGridReports.MasterTableView.Columns)
                    {
                        column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridReports.MasterTableView.FilterExpression = string.Empty;
                    this.RadGridJobReport(this.CompanyID);
                    this.RadGridReports.MasterTableView.Rebind();
                }
                else
                {
                    foreach (GridColumn empty in this.RadGrid_CustomerJobReport.MasterTableView.Columns)
                    {
                        this.JobFromDate = this.hdnJobFormdate.Value;
                        this.JobToDate = this.hdnJobToDate.Value;
                        empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty.CurrentFilterValue = string.Empty;
                    }
                    this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression = string.Empty;

                    // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
                    if (hdnStockProdSalRelRep2.Value != "1")
                    {
                        this.RadGridJobCustomerReport(this.CompanyID);
                    }
                    else
                    {
                        this.RadGridJobCustomerReport2(this.CompanyID);
                    }
                    this.RadGrid_CustomerJobReport.MasterTableView.Rebind();
                }
            }
            if (this.pagename == "")
            {
                Reports.WhereCondition = "";
                base.Session["SearchProd_Stock"] = null;
                if (this.hdnParticularCustomer.Value.ToLower() == "usage")
                {
                    this.RadGrid_StockUsageReport.MasterTableView.FilterExpression = string.Empty;
                    base.Session["checkfilter"] = "clear";
                    this.RadGridstockUsageReport(this.CompanyID);
                    this.RadGrid_StockUsageReport.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "usagehistory") // -- Safdar Aheer To be Corrected
                {
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.FilterExpression = string.Empty;
                    base.Session["checkfilter"] = "clear";
                    this.RadGridstockUsageHistoryReport(this.CompanyID);
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "packs")
                {
                    foreach (GridColumn gridColumn in this.RadStockUsage_Packs.MasterTableView.Columns)
                    {
                        gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn.CurrentFilterValue = string.Empty;
                    }
                    this.RadStockUsage_Packs.MasterTableView.FilterExpression = string.Empty;
                    this.RadGridstockUsageReportInPacks(this.CompanyID);
                    this.RadStockUsage_Packs.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "reorderalertsset")
                {
                    base.Session["checkfilter"] = "clear";
                    foreach (GridColumn gridColumn in this.RadGridItemswithReorderAlertsSet.MasterTableView.Columns)
                    {
                        gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridItemswithReorderAlertsSet.MasterTableView.FilterExpression = string.Empty;
                    this.BindRadGridItemsWithReorderAlertsSet(this.CompanyID);
                    this.RadGridItemswithReorderAlertsSet.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "itemsrequiringreorder")
                {
                    base.Session["checkfilter"] = "clear";
                    foreach (GridColumn gridColumn in this.RadGridItemsRequiringReorder.MasterTableView.Columns)
                    {
                        gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridItemsRequiringReorder.MasterTableView.FilterExpression = string.Empty;
                    this.BindRadGridItemsRequiringReorder(this.CompanyID);
                    this.RadGridItemsRequiringReorder.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "radgridallestimatesbycustomer")
                {
                    base.Session["checkfilter"] = "clear";
                    foreach (GridColumn gridColumn in this.RadGridAllEstimatesbyCustomer.MasterTableView.Columns)
                    {
                        gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridAllEstimatesbyCustomer.MasterTableView.FilterExpression = string.Empty;
                    this.BindRadGridAllEstimatesbyCustomer(this.CompanyID);
                    this.RadGridAllEstimatesbyCustomer.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "radgridalljobsbycustomer")
                {
                    base.Session["checkfilter"] = "clear";
                    foreach (GridColumn gridColumn in this.RadGridAllJobsbyCustomer.MasterTableView.Columns)
                    {
                        gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridAllJobsbyCustomer.MasterTableView.FilterExpression = string.Empty;
                    this.BindRadGridAllJobsbyCustomer(this.CompanyID);
                    this.RadGridAllJobsbyCustomer.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "packs_myproj")
                {
                    foreach (GridColumn column1 in this.RadStockUsage_Packs_MyProj.MasterTableView.Columns)
                    {
                        column1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column1.CurrentFilterValue = string.Empty;
                    }
                    this.RadStockUsage_Packs_MyProj.MasterTableView.FilterExpression = string.Empty;
                    this.RadGridstockUsageReportInPacks_MyProj(this.CompanyID);
                    this.RadStockUsage_Packs_MyProj.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value == "yes")
                {
                    foreach (GridColumn empty1 in this.RadGridProductReport_Customer.MasterTableView.Columns)
                    {
                        this.FromDate = this.hdnProductFormDate.Value;
                        this.ToDate = this.hdnProductToDate.Value;
                        empty1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty1.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridProductReport_Customer.MasterTableView.FilterExpression = string.Empty;
                    if (hdnStockReleaseAdjRep2.Value != "1")
                    {
                        this.RadGridProductCustomerReport(this.CompanyID);
                    }
                    else
                    {
                        this.RadGridProductCustomerReport2(this.CompanyID);
                    }

                    this.RadGridProductReport_Customer.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value == "")
                {
                    foreach (GridColumn gridColumn1 in this.GridProductReport.MasterTableView.Columns)
                    {
                        gridColumn1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn1.CurrentFilterValue = string.Empty;
                    }
                    this.GridProductReport.MasterTableView.FilterExpression = string.Empty;
                    this.RadGridProductReport(this.CompanyID);
                    this.GridProductReport.MasterTableView.Rebind();
                }
                else if (this.hdnParticularCustomer.Value == "new")
                {
                    foreach (GridColumn column2 in this.RadGridProductReport_CustomerNew.MasterTableView.Columns)
                    {
                        this.FromDate = this.hdnProductFormDate.Value;
                        this.ToDate = this.hdnProductToDate.Value;
                        column2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column2.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridProductReport_CustomerNew.MasterTableView.FilterExpression = string.Empty;
                    this.RadGridProductReportNew(this.CompanyID);
                    this.RadGridProductReport_CustomerNew.MasterTableView.Rebind();
                }
            }
            if (this.pagename == "activitycallreport")
            {
                foreach (GridColumn empty2 in this.GridClientReport.MasterTableView.Columns)
                {
                    empty2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty2.CurrentFilterValue = string.Empty;
                }
                this.GridClientReport.MasterTableView.FilterExpression = string.Empty;
                this.RadGridClientReport(this.CompanyID);
                this.GridClientReport.MasterTableView.Rebind();
            }
            if (this.pagename == "webstoreorder")
            {
                if (this.hdnParticularCustomer.Value == "AllOrdersbyCustomer")
                {
                    ResetGridHeaderControls(sender);
                    this.BindRadGridAllOrdersbyCustomer(this.CompanyID);
                }
                foreach (GridColumn gridColumn2 in this.RadGrid_Order_Report.MasterTableView.Columns)
                {
                    this.orderFromdate = this.hdnOrderFromdate.Value;
                    this.orderTodate = this.hdnOrderTodate.Value;
                    gridColumn2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    gridColumn2.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_Order_Report.MasterTableView.FilterExpression = string.Empty;
                this.hdnisstockItem.Value = "";
                this.hdnisreplinsh.Value = "";
                this.hdnOrderClientID.Value = "";
                this.RadGridoredrReport(this.CompanyID);
                this.RadGrid_Order_Report.MasterTableView.Rebind();
            }
            if (this.pagename == "invoice")
            {
                if (this.hdnParticularCustomer.Value == "AllInvoicesByCustomer")
                {
                    ResetGridHeaderControls(sender);
                    this.BindRadGridAllInvoicesbyCustomer(this.CompanyID);
                }
                else if (this.hdnParticularCustomer.Value == "AllInvoicesbyAccountingCode")
                {
                    ResetGridHeaderControls(sender);
                    this.BindRadGridAllInvoicesByItemCode(this.CompanyID);
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "Yearly Comparison")
                {
                    this.RadGridCustomerYearlyComparison.MasterTableView.FilterExpression = string.Empty;
                    base.Session["checkfilter"] = "clear";
                    this.RadGridCustomerYearlyComparisonReport(this.CompanyID);
                    this.RadGridCustomerYearlyComparison.MasterTableView.Rebind();
                }
            }
        }
        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            GridItemType[] gridItemTypeArray;
            GridItem[] items;
            int j;
            if (this.pagename == "estimate")
            {
                if (this.hdnParticularCustomer.Value.ToLower() == "allestimatesbycustomer")
                {
                    DataTable dt = new DataTable();
                    if (Session["AllEstimatesbyCustomer"] != null)
                    {
                        dt = (DataTable)Session["AllEstimatesbyCustomer"];
                    }
                    else
                    {
                        dt = GetAllEstimatesbyCustomerData(Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToInt64(this.hdnCustomerTypeFilter.Value), this.hdnDurationFilter.Value);
                    }
                    GridExportHelper.ExportGridToExcel(this.RadGridAllEstimatesbyCustomer, "AllEstimatesbyCustomer", dt, Response);
                }
            }
            else if (this.pagename == "job")
            {
                if (this.hdnParticularCustomer.Value.ToLower() == "alljobsbycustomer")
                {
                    DataTable dt = new DataTable();
                    if (Session["AllJobsbyCustomer"] != null)
                    {
                        dt = (DataTable)Session["AllJobsbyCustomer"];
                    }
                    else
                    {
                        dt = GetAllJobByCustomerData(Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToInt64(this.hdnCustomerTypeFilter.Value), this.hdnDurationFilter.Value);
                    }
                    GridExportHelper.ExportGridToExcel(this.RadGridAllJobsbyCustomer, "AllJobsbyCustomer", dt, Response);
                    return;
                }
                if (this.hdnParticularJobCustomer.Value != "yes")
                {
                    GridItem[] gridItemArray = this.RadGridReports.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (int i = 0; i < (int)gridItemArray.Length; i++)
                    {
                        ((GridFilteringItem)gridItemArray[i]).Visible = false;
                    }
                    //this.RadGridReports.ExportSettings.FileName = "Sales/order_Report.xls";
                    this.RadGridReports.ExportSettings.IgnorePaging = true;
                    this.RadGridReports.MasterTableView.GridLines = GridLines.Both;
                    if (this.RadGridReports.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridReports.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridReports.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridReports.ExportSettings.IgnorePaging = false;
                        this.RadGridReports.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridReports.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column in this.RadGridReports.MasterTableView.Columns)
                    {
                        column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column.CurrentFilterValue = string.Empty;
                    }
                    DataTable dataTable = SettingsBasePage.CustomizeJob_Report(CompanyID, this.hdnFromDate.Value, this.hdnToDate.Value);
                    DataSet _ds = new DataSet();
                    DataTable _dtCopy1 = dataTable.Copy();
                    _ds.Tables.Add(_dtCopy1);

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        foreach (DataTable _dt in _ds.Tables)
                        {
                            wb.Worksheets.Add(_dt);
                        }
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=Sales/order_Report.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    //this.RadGridReports.MasterTableView.ExportToExcel();
                    return;
                }
                GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
                gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                items = masterTableView.GetItems(gridItemTypeArray);
                for (j = 0; j < (int)items.Length; j++)
                {
                    ((GridFilteringItem)items[j]).Visible = false;
                }
                //this.RadGrid_CustomerJobReport.ExportSettings.FileName = "Product Sales_Report.xls";
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
                this.RadGrid_CustomerJobReport.ExportSettings.ExportOnlyData = true;
                foreach (GridColumn empty in this.RadGrid_CustomerJobReport.MasterTableView.Columns)
                {
                    empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty.CurrentFilterValue = string.Empty;
                }
                this.RadGrid_CustomerJobReport.ExportSettings.HideStructureColumns = true;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items1 = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray1)[0];

                TextBox textBox = (TextBox)items1.FindControl("txtJobFromDate");
                TextBox textBox1 = (TextBox)items1.FindControl("txtJobToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                this.JobFromDate = textBox.Text;
                this.JobToDate = textBox1.Text;
                DataSet dataSet;
                if (hdnStockProdSalRelRep2.Value != "1")
                {
                    dataSet = SettingsBasePage.JobReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
                }
                else
                {
                    dataSet = SettingsBasePage.JobReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
                }
                DataTable Table1 = dataSet.Tables[0];
                DataTable Table2 = dataSet.Tables[1];
                DataSet ds = new DataSet();
                DataTable dt2 = new DataTable();
                DataTable dtCopy1 = Table1.Copy();
                DataTable dtCopy2 = Table2.Copy();
                dtCopy1.Columns.RemoveAt(11);
                dtCopy1.Columns.RemoveAt(10);
                dtCopy1.Columns.RemoveAt(0);
                ds.Tables.Add(dtCopy1);
                ds.Tables.Add(dtCopy2);
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
                    Response.AddHeader("content-disposition", "attachment;filename=Product Sales_Report.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
                //this.RadGrid_CustomerJobReport.MasterTableView.ExportToExcel();
                return;
            }
            if (this.pagename != "")
            {
                if (this.pagename == "activitycallreport")
                {
                    GridTableView gridTableView = this.GridClientReport.MasterTableView;
                    gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                    items = gridTableView.GetItems(gridItemTypeArray);
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }
                    string str = "CustomerCall_Report.xls";
                    this.GridClientReport.ExportSettings.IgnorePaging = true;
                    this.GridClientReport.ExportSettings.ExportOnlyData = true;
                    this.GridClientReport.ExportSettings.FileName = str;
                    this.GridClientReport.MasterTableView.GridLines = GridLines.Both;
                    if (this.GridClientReport.MasterTableView.FilterExpression == "")
                    {
                        this.GridClientReport.MasterTableView.AllowFilteringByColumn = false;
                        this.GridClientReport.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.GridClientReport.ExportSettings.IgnorePaging = false;
                        this.GridClientReport.MasterTableView.AllowFilteringByColumn = true;
                    }
                    foreach (GridColumn gridColumn in this.GridClientReport.MasterTableView.Columns)
                    {
                        gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn.CurrentFilterValue = string.Empty;
                    }
                    this.GridClientReport.MasterTableView.ExportToExcel();
                    return;
                }
                if (this.pagename == "invoice")
                {
                    if (this.hdnParticularCustomer.Value.ToLower() == "yearly comparison")
                    {
                        GridItem[] gridItemArray1 = this.RadGridCustomerYearlyComparison.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                        for (int l = 0; l < (int)gridItemArray1.Length; l++)
                        {
                            ((GridFilteringItem)gridItemArray1[l]).Visible = false;
                        }
                        //this.RadGrid_StockUsageReport.ExportSettings.FileName = "Stock_Usage_Report.xls";
                        if (this.RadGridCustomerYearlyComparison.MasterTableView.FilterExpression == "")
                        {
                            this.RadGridCustomerYearlyComparison.MasterTableView.AllowFilteringByColumn = false;
                            this.RadGridCustomerYearlyComparison.ExportSettings.IgnorePaging = true;
                        }
                        else
                        {
                            this.RadGridCustomerYearlyComparison.ExportSettings.IgnorePaging = false;
                            this.RadGridCustomerYearlyComparison.MasterTableView.AllowFilteringByColumn = true;
                        }
                        this.RadGridCustomerYearlyComparison.MasterTableView.GridLines = GridLines.Both;
                        this.RadGridCustomerYearlyComparison.ExportSettings.ExportOnlyData = true;
                        foreach (GridColumn gridColumn1 in this.RadGridCustomerYearlyComparison.MasterTableView.Columns)
                        {
                            gridColumn1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                            gridColumn1.CurrentFilterValue = string.Empty;
                        }
                        this.RadGridCustomerYearlyComparison.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                        DataTable dt = SettingsBasePage.GetCustomerYearlyComparisonData(this.CompanyID, "");
                        DataSet ds = new DataSet();
                        DataTable dt2 = new DataTable();
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
                            Response.AddHeader("content-disposition", "attachment;filename=Customer_Yearly_Comparison_Report.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                    else if (this.hdnParticularCustomer.Value.ToLower() == "allinvoicesbycustomer")
                    {
                        DataTable dt = new DataTable();
                        if (Session["AllInvoicesbyCustomer"] != null)
                        {
                            dt = (DataTable)Session["AllInvoicesbyCustomer"];
                        }
                        else
                        {
                            dt = GetAllInvoicesbyCustomerData(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate, this.hdnDurationFilter.Value, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToInt64(this.hdnCustomerTypeFilter.Value));
                        }
                        GridExportHelper.ExportGridToExcel(this.RadGridAllInvoicesbyCustomer, "AllInvoicesbyCustomer", dt, Response);
                        return;
                    }
                    else if (this.hdnParticularCustomer.Value.ToLower() == "allinvoicesbyaccountingcode")
                    {
                        DataTable dt = new DataTable();
                        if (Session["AllInvoicesbyAccountingCode"] != null)
                        {
                            dt = (DataTable)Session["AllInvoicesbyAccountingCode"];
                        }
                        else
                        {
                            dt = GetAllInvoicesByItemCodeData(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate, this.hdnDurationFilter.Value, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToInt64(this.hdnCustomerTypeFilter.Value));
                        }
                        GridExportHelper.ExportGridToExcel(this.RadGridAllInvoicesbyAccountingCode, "AllInvoicesbyAccountingCode", dt, Response);
                        return;
                    }
                }
                if (this.pagename == "webstoreorder")
                {
                    if (this.hdnParticularCustomer.Value.ToLower() == "allordersbycustomer")
                    {
                        DataTable dt = new DataTable();
                        if (Session["AllOrdersbyCustomer"] != null)
                        {
                            dt = (DataTable)Session["AllOrdersbyCustomer"];
                        }
                        else
                        {
                            dt = GetAllOrdersbyCustomerData(long.Parse(this.hdnParticluarClientID.Value),long.Parse(this.hdnCustomerTypeFilter.Value), this.hdnDurationFilter.Value);
                        }
                        GridExportHelper.ExportGridToExcel(this.RadGridAllOrdersbyCustomer, "AllOrdersbyCustomer", dt, Response);
                        return;

                    }
                    else if (this.hdnParticularCustomer.Value == "Order")
                    {
                        GridTableView masterTableView1 = this.RadGrid_Order_Report.MasterTableView;

                        GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.CommandItem };
                        GridCommandItem items1 = (GridCommandItem)masterTableView1.GetItems(gridItemTypeArray1)[0];
                        TextBox textBox = (TextBox)items1.FindControl("txtOrderFromDate");
                        TextBox textBox1 = (TextBox)items1.FindControl("txtOrderToDate");
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);

                        gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                        items = masterTableView1.GetItems(gridItemTypeArray);
                        for (j = 0; j < (int)items.Length; j++)
                        {
                            ((GridFilteringItem)items[j]).Visible = false;
                        }

                        //this.RadGrid_Order_Report.ExportSettings.FileName = "Order_Details.xls";
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
                        foreach (GridColumn column1 in this.RadGrid_Order_Report.MasterTableView.Columns)
                        {
                            column1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                            column1.CurrentFilterValue = string.Empty;
                        }
                        this.RadGrid_Order_Report.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                        this.hdnOrderFromdate.Value = this.orderFromdate;
                        this.hdnOrderTodate.Value = this.orderTodate;
                        // DataTable dataTable = SettingsBasePage.OrderDetailsReport((long)this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Convert.ToDateTime(JobFromDate/*this.hdnOrderFromdate.Value*/), Convert.ToDateTime(JobToDate/*this.hdnOrderTodate.Value*/), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
                        DataTable dataTable = SettingsBasePage.OrderDetailsReport((long)this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);

                        DataSet ds = new DataSet();
                        DataTable dt2 = new DataTable();

                        dataTable.Columns["Customer"].SetOrdinal(0);
                        dataTable.Columns["Department"].SetOrdinal(1);
                        dataTable.Columns["Contact"].SetOrdinal(2);
                        dataTable.Columns["Cost Center"].SetOrdinal(3);
                        dataTable.Columns["Cost Center"].ColumnName = "Cost Centre";
                        dataTable.Columns["Order No"].SetOrdinal(4);
                        dataTable.Columns["Customer Order No"].SetOrdinal(5);
                        dataTable.Columns["OrderedDate"].SetOrdinal(6);//
                        dataTable.Columns["OrderedDate"].ColumnName = "Order Date";
                        dataTable.Columns["Item Code"].SetOrdinal(7);
                        dataTable.Columns["Item Title"].SetOrdinal(8);
                        dataTable.Columns["Product Type"].SetOrdinal(9);
                        dataTable.Columns["Customer Code"].SetOrdinal(10);
                        dataTable.Columns["Qty Ordered"].SetOrdinal(11);//
                        dataTable.Columns["Qty Ordered"].ColumnName = "Order Qty";
                        dataTable.Columns["Unit of Issue"].SetOrdinal(12);
                        dataTable.Columns["Unit Cost"].SetOrdinal(13);
                        dataTable.Columns["Total"].SetOrdinal(14);//
                        dataTable.Columns["Total"].ColumnName = "Total Cost(Ex. GST)";
                        dataTable.Columns.Remove("End user Cost Centre");
                        DataTable dtCopy1 = dataTable.Copy();
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
                            Response.AddHeader("content-disposition", "attachment;filename=Order_Details.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                        //this.RadGrid_Order_Report.MasterTableView.ExportToExcel();
                    }
                }
            }
            else
            {
                if (this.hdnParticularCustomer.Value == "yes")
                {
                    GridItem[] items1 = this.RadGridProductReport_Customer.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (int k = 0; k < (int)items1.Length; k++)
                    {
                        ((GridFilteringItem)items1[k]).Visible = false;
                    }
                    this.RadGridProductReport_Customer.ExportSettings.FileName = "Stock Products_Report.xls";
                    if (this.RadGridProductReport_Customer.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridProductReport_Customer.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridProductReport_Customer.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridProductReport_Customer.ExportSettings.IgnorePaging = false;
                        this.RadGridProductReport_Customer.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridProductReport_Customer.MasterTableView.GridLines = GridLines.Both;
                    this.RadGridProductReport_Customer.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn empty1 in this.RadGridProductReport_Customer.MasterTableView.Columns)
                    {
                        empty1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty1.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridProductReport_Customer.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadGridProductReport_Customer.MasterTableView.ExportToExcel();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "usage")
                {
                    GridItem[] gridItemArray1 = this.RadGrid_StockUsageReport.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (int l = 0; l < (int)gridItemArray1.Length; l++)
                    {
                        ((GridFilteringItem)gridItemArray1[l]).Visible = false;
                    }
                    //this.RadGrid_StockUsageReport.ExportSettings.FileName = "Stock_Usage_Report.xls";
                    if (this.RadGrid_StockUsageReport.MasterTableView.FilterExpression == "")
                    {
                        this.RadGrid_StockUsageReport.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGrid_StockUsageReport.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGrid_StockUsageReport.ExportSettings.IgnorePaging = false;
                        this.RadGrid_StockUsageReport.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGrid_StockUsageReport.MasterTableView.GridLines = GridLines.Both;
                    this.RadGrid_StockUsageReport.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn gridColumn1 in this.RadGrid_StockUsageReport.MasterTableView.Columns)
                    {
                        gridColumn1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn1.CurrentFilterValue = string.Empty;
                    }
                    this.RadGrid_StockUsageReport.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    DataTable stockUsage = SettingsBasePage.ProductstockUsageReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
                    DataSet ds = new DataSet();
                    DataTable dt2 = new DataTable();
                    DataTable dtCopy1 = stockUsage.Copy();
                    dtCopy1.Columns.RemoveAt(10);
                    dtCopy1.Columns.RemoveAt(9);
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
                        Response.AddHeader("content-disposition", "attachment;filename=Stock_Usage_Report.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }

                    //this.RadGrid_StockUsageReport.MasterTableView.ExportToExcel();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "usagehistory") // Safdar Aheer  
                {
                    GridItem[] gridItemArray1 = this.RadGrid_StockUsageHistoryReport.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (int l = 0; l < (int)gridItemArray1.Length; l++)
                    {
                        ((GridFilteringItem)gridItemArray1[l]).Visible = false;
                    }
                    //this.RadGrid_StockUsageHistoryReport.ExportSettings.FileName = "Stock_Usage_History_Report.xls";
                    if (this.RadGrid_StockUsageHistoryReport.MasterTableView.FilterExpression == "")
                    {
                        this.RadGrid_StockUsageHistoryReport.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGrid_StockUsageHistoryReport.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGrid_StockUsageHistoryReport.ExportSettings.IgnorePaging = false;
                        this.RadGrid_StockUsageHistoryReport.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.GridLines = GridLines.Both;
                    this.RadGrid_StockUsageHistoryReport.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn gridColumn1 in this.RadGrid_StockUsageHistoryReport.MasterTableView.Columns)
                    {
                        gridColumn1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn1.CurrentFilterValue = string.Empty;
                    }
                    this.RadGrid_StockUsageHistoryReport.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    DataTable dataTable = SettingsBasePage.ProductstockUsageHistoryReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
                    DataSet ds = new DataSet();
                    DataTable dt2 = new DataTable();
                    DataTable dtCopy1 = dataTable.Copy();
                    dtCopy1.Columns.RemoveAt(13);
                    dtCopy1.Columns.RemoveAt(12);
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
                        Response.AddHeader("content-disposition", "attachment;filename=Stock_Usage_History_Report.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    //this.RadGrid_StockUsageHistoryReport.MasterTableView.ExportToExcel();
                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "packs")
                {
                    GridItem[] items2 = this.RadStockUsage_Packs.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (int m = 0; m < (int)items2.Length; m++)
                    {
                        ((GridFilteringItem)items2[m]).Visible = false;
                    }
                    this.RadStockUsage_Packs.ExportSettings.FileName = "Stock_Usage_Report_InPacks";
                    if (this.RadStockUsage_Packs.MasterTableView.FilterExpression == "")
                    {
                        this.RadStockUsage_Packs.MasterTableView.AllowFilteringByColumn = false;
                        this.RadStockUsage_Packs.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadStockUsage_Packs.ExportSettings.IgnorePaging = false;
                        this.RadStockUsage_Packs.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadStockUsage_Packs.MasterTableView.GridLines = GridLines.Both;
                    this.RadStockUsage_Packs.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column2 in this.RadStockUsage_Packs.MasterTableView.Columns)
                    {
                        column2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column2.CurrentFilterValue = string.Empty;
                    }
                    this.RadStockUsage_Packs.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;

                    DataSet stockUsageInPacks = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Reports.WhereCondition);

                    DataSet ds = new DataSet();
                    DataTable dt2 = new DataTable();
                    DataTable dtCopy1 = stockUsageInPacks.Tables[0].Copy();
                    DataTable dtCopy2 = stockUsageInPacks.Tables[1].Copy();
                    dtCopy1.Columns.RemoveAt(11);
                    dtCopy1.Columns.RemoveAt(10);
                    var tbl2 = new DataTable();
                    tbl2.Columns.Add("c1");
                    tbl2.Columns.Add("c2");
                    tbl2.Columns.Add("c3");
                    tbl2.Columns.Add("c4");
                    tbl2.Columns.Add("c5");
                    tbl2.Columns.Add("c6");
                    tbl2.Columns.Add("c7");
                    tbl2.Columns.Add("c8");
                    tbl2.Columns.Add("c9");
                    tbl2.Columns.Add("c10");
                    foreach (DataRow row in dtCopy2.Rows)
                    {
                        tbl2.Rows.Add("", "", "", "", "", "", "", "", "Total Cost Value:", row["TotalExCCost"].ToString());
                    }
                    ds.Tables.Add(dtCopy1);
                    ds.Tables.Add(tbl2);
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
                        Response.AddHeader("content-disposition", "attachment;filename=Stock_Usage_Report_InPacks.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    //this.RadStockUsage_Packs.MasterTableView.ExportToExcel();


                }
                else if (this.hdnParticularCustomer.Value.ToLower() == "packs_myproj")
                {
                    GridItem[] gridItemArray2 = this.RadStockUsage_Packs_MyProj.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (int n = 0; n < (int)gridItemArray2.Length; n++)
                    {
                        ((GridFilteringItem)gridItemArray2[n]).Visible = false;
                    }
                    this.RadStockUsage_Packs_MyProj.ExportSettings.FileName = "Stock_Usage_Report_InPacks_New.xls";
                    if (this.RadStockUsage_Packs_MyProj.MasterTableView.FilterExpression == "")
                    {
                        this.RadStockUsage_Packs_MyProj.MasterTableView.AllowFilteringByColumn = false;
                        this.RadStockUsage_Packs_MyProj.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadStockUsage_Packs_MyProj.ExportSettings.IgnorePaging = false;
                        this.RadStockUsage_Packs_MyProj.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadStockUsage_Packs_MyProj.MasterTableView.GridLines = GridLines.Both;
                    this.RadStockUsage_Packs_MyProj.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn empty2 in this.RadStockUsage_Packs_MyProj.MasterTableView.Columns)
                    {
                        empty2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty2.CurrentFilterValue = string.Empty;
                    }
                    this.RadStockUsage_Packs_MyProj.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadStockUsage_Packs_MyProj.MasterTableView.ExportToExcel();
                }
                else if (this.hdnParticularCustomer.Value == "")
                {
                    items = this.GridProductReport.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }
                    //this.GridProductReport.ExportSettings.FileName = "Product(Inventory)_Report.xls";
                    if (this.GridProductReport.MasterTableView.FilterExpression == "")
                    {
                        this.GridProductReport.MasterTableView.AllowFilteringByColumn = false;
                        this.GridProductReport.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.GridProductReport.ExportSettings.IgnorePaging = false;
                        this.GridProductReport.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.GridProductReport.MasterTableView.GridLines = GridLines.Both;
                    this.GridProductReport.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn gridColumn2 in this.GridProductReport.MasterTableView.Columns)
                    {
                        gridColumn2.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        gridColumn2.CurrentFilterValue = string.Empty;
                    }
                    this.GridProductReport.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    DataTable dataTable = SettingsBasePage.CustomizeProduct_Report(this.CompanyID, Convert.ToInt64(this.hdnClientID.Value));
                    dataTable.Columns["category"].ColumnName = "Category";
                    dataTable.Columns["customercode"].ColumnName = "Customer Code";
                    dataTable.Columns["itemtitle"].ColumnName = "Item Title";
                    dataTable.Columns["productdescription"].ColumnName = "Product Description";
                    dataTable.Columns["openingstock"].ColumnName = "Stock on Hand";
                    dataTable.Columns["receipts"].ColumnName = "Receipts *";
                    dataTable.Columns["adj"].ColumnName = "Adjustment";
                    dataTable.Columns["availablestock"].ColumnName = "Available Stock";
                    dataTable.Columns["last_13_weekssales"].ColumnName = "Last 13 Weeks Sales";
                    dataTable.Columns["weeksremaining"].ColumnName = "Weeks Remaining";
                    dataTable.Columns["sales_incl_backorders"].ColumnName = "Sales (Inc Back Orders)";
                    dataTable.Columns["backorderunits"].ColumnName = "Back Order Quantity";
                    dataTable.Columns["supplier"].ColumnName = "Supplier";

                    DataSet ds = new DataSet();
                    DataTable dt2 = new DataTable();
                    DataTable dtCopy1 = dataTable.Copy();
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
                        Response.AddHeader("content-disposition", "attachment;filename=Product(Inventory)_Report.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                    //this.GridProductReport.MasterTableView.ExportToExcel();
                }
                if (this.hdnParticularCustomer.Value == "new")
                {
                    GridTableView gridTableView1 = this.RadGridProductReport_CustomerNew.MasterTableView;
                    gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                    items = gridTableView1.GetItems(gridItemTypeArray);
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }
                    this.RadGridProductReport_CustomerNew.ExportSettings.FileName = "Stock Products_Report_New.xls";
                    if (this.RadGridProductReport_CustomerNew.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridProductReport_CustomerNew.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridProductReport_CustomerNew.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridProductReport_CustomerNew.ExportSettings.IgnorePaging = false;
                        this.RadGridProductReport_CustomerNew.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridProductReport_CustomerNew.MasterTableView.GridLines = GridLines.Both;
                    this.RadGridProductReport_CustomerNew.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column3 in this.RadGridProductReport_CustomerNew.MasterTableView.Columns)
                    {
                        column3.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column3.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridProductReport_CustomerNew.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadGridProductReport_CustomerNew.MasterTableView.ExportToExcel();
                    return;
                }
                if (this.hdnParticularCustomer.Value == "ReorderAlertsSet")
                {
                    GridTableView gridTableView1 = this.RadGridItemswithReorderAlertsSet.MasterTableView;
                    gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                    items = gridTableView1.GetItems(gridItemTypeArray);
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }

                    GridColumn itemCodeColumn = this.RadGridItemswithReorderAlertsSet.MasterTableView.GetColumn("PriceCatalogueID");
                    if (itemCodeColumn != null)
                    {
                        itemCodeColumn.Display = false;
                    }

                    this.RadGridItemswithReorderAlertsSet.ExportSettings.FileName = "ItemswithReorderAlertsSet";
                    if (this.RadGridProductReport_CustomerNew.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridItemswithReorderAlertsSet.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridItemswithReorderAlertsSet.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridItemswithReorderAlertsSet.ExportSettings.IgnorePaging = false;
                        this.RadGridItemswithReorderAlertsSet.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridItemswithReorderAlertsSet.MasterTableView.GridLines = GridLines.Both;
                    this.RadGridItemswithReorderAlertsSet.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column3 in this.RadGridItemswithReorderAlertsSet.MasterTableView.Columns)
                    {
                        column3.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column3.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridItemswithReorderAlertsSet.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadGridItemswithReorderAlertsSet.MasterTableView.ExportToExcel();
                    return;
                }
                else if (this.hdnParticularCustomer.Value == "ItemsRequiringReorder")
                {
                    GridTableView gridTableView1 = this.RadGridItemsRequiringReorder.MasterTableView;

                    gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                    items = gridTableView1.GetItems(gridItemTypeArray);
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }

                    GridColumn itemCodeColumn = this.RadGridItemsRequiringReorder.MasterTableView.GetColumn("PriceCatalogueID");
                    if (itemCodeColumn != null)
                    {
                        itemCodeColumn.Display = false;
                    }

                    this.RadGridItemsRequiringReorder.ExportSettings.FileName = "ItemsRequiringReorder";
                    if (this.RadGridProductReport_CustomerNew.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridItemsRequiringReorder.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridItemsRequiringReorder.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridItemsRequiringReorder.ExportSettings.IgnorePaging = false;
                        this.RadGridItemsRequiringReorder.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridItemsRequiringReorder.MasterTableView.GridLines = GridLines.Both;
                    this.RadGridItemsRequiringReorder.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column3 in this.RadGridItemsRequiringReorder.MasterTableView.Columns)
                    {
                        column3.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column3.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridItemsRequiringReorder.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadGridItemsRequiringReorder.MasterTableView.ExportToExcel();
                    return;
                }
                else if (this.hdnParticularCustomer.Value == "radgridallestimatesbycustomer")
                {
                    GridTableView gridTableView1 = this.RadGridAllEstimatesbyCustomer.MasterTableView;

                    gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                    items = gridTableView1.GetItems(gridItemTypeArray);
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }

                    GridColumn itemCodeColumn = this.RadGridAllEstimatesbyCustomer.MasterTableView.GetColumn("PriceCatalogueID");
                    if (itemCodeColumn != null)
                    {
                        itemCodeColumn.Display = false;
                    }

                    this.RadGridAllEstimatesbyCustomer.ExportSettings.FileName = "allestimatesbycustomer";
                    if (this.RadGridProductReport_CustomerNew.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridAllEstimatesbyCustomer.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridAllEstimatesbyCustomer.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridAllEstimatesbyCustomer.ExportSettings.IgnorePaging = false;
                        this.RadGridAllEstimatesbyCustomer.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridAllEstimatesbyCustomer.MasterTableView.GridLines = GridLines.Both;
                    this.RadGridAllEstimatesbyCustomer.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column3 in this.RadGridAllEstimatesbyCustomer.MasterTableView.Columns)
                    {
                        column3.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column3.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridAllEstimatesbyCustomer.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadGridAllEstimatesbyCustomer.MasterTableView.ExportToExcel();
                    return;
                }
                else if (this.hdnParticularCustomer.Value == "radgridalljobsbycustomer")
                {
                    GridTableView gridTableView1 = this.RadGridAllJobsbyCustomer.MasterTableView;

                    gridItemTypeArray = new GridItemType[] { GridItemType.FilteringItem };
                    items = gridTableView1.GetItems(gridItemTypeArray);
                    for (j = 0; j < (int)items.Length; j++)
                    {
                        ((GridFilteringItem)items[j]).Visible = false;
                    }

                    GridColumn itemCodeColumn = this.RadGridAllJobsbyCustomer.MasterTableView.GetColumn("PriceCatalogueID");
                    if (itemCodeColumn != null)
                    {
                        itemCodeColumn.Display = false;
                    }

                    this.RadGridAllJobsbyCustomer.ExportSettings.FileName = "alljobsbycustomer";
                    if (this.RadGridProductReport_CustomerNew.MasterTableView.FilterExpression == "")
                    {
                        this.RadGridAllJobsbyCustomer.MasterTableView.AllowFilteringByColumn = false;
                        this.RadGridAllJobsbyCustomer.ExportSettings.IgnorePaging = true;
                    }
                    else
                    {
                        this.RadGridAllJobsbyCustomer.ExportSettings.IgnorePaging = false;
                        this.RadGridAllJobsbyCustomer.MasterTableView.AllowFilteringByColumn = true;
                    }
                    this.RadGridAllJobsbyCustomer.MasterTableView.GridLines = GridLines.Both;
                    this.RadGridAllJobsbyCustomer.ExportSettings.ExportOnlyData = true;
                    foreach (GridColumn column3 in this.RadGridAllJobsbyCustomer.MasterTableView.Columns)
                    {
                        column3.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        column3.CurrentFilterValue = string.Empty;
                    }
                    this.RadGridAllJobsbyCustomer.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;
                    this.RadGridAllJobsbyCustomer.MasterTableView.ExportToExcel();
                    return;
                }

            }
        }


        private void lnkReportName_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            if (string.IsNullOrEmpty(this.hdnParticularCustomer.Value))
            {
                this.hdnParticularCustomer.Value = "0";
            }
            this.hdnClearFilters.Value = "";
            SetReportsRelatedSessionNull();
            if (this.pagename == "estimate")
            {
                if (linkButton.Text == "All Estimates by Customer")
                {
                    SetDefaultFilterForSelectedReport();
                    this.BindRadGridAllEstimatesbyCustomer(this.CompanyID, 0, 0, this.hdnDurationFilter.Value);
                    this.HideAllGridControls();
                    this.RadGridAllEstimatesbyCustomer.Visible = true;
                    this.hdnParticularCustomer.Value = "AllEstimatesbyCustomer";
                }
            }
            else if (this.pagename == "job")
            {
                if (linkButton.Text == "All Jobs by Customer")
                {
                    SetDefaultFilterForSelectedReport();
                    this.BindRadGridAllJobsbyCustomer(this.CompanyID, 0, 0, this.hdnDurationFilter.Value);
                    this.HideAllGridControls();
                    this.RadGridAllJobsbyCustomer.Visible = true;
                    this.hdnParticularCustomer.Value = "AllJobsbyCustomer";
                }
                else if (linkButton.Text == "Sales/Order Report")
                {
                    this.RadGridJobReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGridReports.Visible = true;
                    this.hdnParticularJobCustomer.Value = "";
                }
                //if (linkButton.Text == "Product Sales Report")
                if (linkButton.Text == "Stock Product (Allocation) Report")
                {
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        this.hdnJobSelectedClientID.Value = productSelectClient.Rows[0]["clientID"].ToString();
                        if (ConnectionClass.ServerName.ToLower() != "dmc")
                        {
                            if (ConnectionClass.ServerName.ToLower() != "dmc2")
                            {
                                continue;
                            }
                            this.hdnJobSelectedClientID.Value = "16970";
                            break;
                        }
                        else
                        {
                            this.hdnJobSelectedClientID.Value = "16238";
                            break;
                        }
                    }
                    hdnStockProdAllocateReport.Value = "1";
                    this.RadGridJobCustomerReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGrid_CustomerJobReport.Visible = true;
                    this.hdnParticularJobCustomer.Value = "yes";
                }

                // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
                if (linkButton.Text == "Stock Product Sales (Release) Report")
                {
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        this.hdnJobSelectedClientID.Value = productSelectClient.Rows[0]["clientID"].ToString();
                        if (ConnectionClass.ServerName.ToLower() != "dmc")
                        {
                            if (ConnectionClass.ServerName.ToLower() != "dmc2")
                            {
                                continue;
                            }
                            this.hdnJobSelectedClientID.Value = "16970";
                            break;
                        }
                        else
                        {
                            this.hdnJobSelectedClientID.Value = "16238";
                            break;
                        }
                    }
                    hdnStockProdSalRelRep2.Value = "1";
                    this.RadGridJobCustomerReport2(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGrid_CustomerJobReport.Visible = true;
                    this.hdnParticularJobCustomer.Value = "yes";
                }
            }
            else if (this.pagename == "")
            {
                if (linkButton.Text == "Stock Report with Quarterly Sales")
                {
                    this.RadGridProductReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.GridProductReport.Visible = true;
                    this.hdnParticularCustomer.Value = "";
                }
                if (linkButton.Text == "Stock Release and Adjustment Report")
                {
                    //KR comments 29AUG2018
                    //Report "Stock Release and Adjustment Report 2" was renamed to "Stock Release and Adjustment Report"
                    DataTable dataTable = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        dataTable.Columns[j].ReadOnly = false;
                    }
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.hdnParticluarClientID.Value = dataTable.Rows[0]["clientID"].ToString();
                        if (ConnectionClass.ServerName.ToLower() != "dmc")
                        {
                            if (ConnectionClass.ServerName.ToLower() != "dmc2")
                            {
                                continue;
                            }
                            this.hdnParticluarClientID.Value = "16970";
                            break;
                        }
                        else
                        {
                            this.hdnParticluarClientID.Value = "16238";
                            break;
                        }
                    }
                    hdnStockReleaseAdjRep2.Value = "1";
                    this.RadGridProductCustomerReport2(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGridProductReport_Customer.Visible = true;
                    this.hdnParticularCustomer.Value = "yes";

                    /*
                    DataTable dataTable = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        dataTable.Columns[j].ReadOnly = false;
                    }
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.hdnParticluarClientID.Value = dataTable.Rows[0]["clientID"].ToString();
                        if (ConnectionClass.ServerName.ToLower() != "dmc")
                        {
                            if (ConnectionClass.ServerName.ToLower() != "dmc2")
                            {
                                continue;
                            }
                            this.hdnParticluarClientID.Value = "16970";
                            break;
                        }
                        else
                        {
                            this.hdnParticluarClientID.Value = "16238";
                            break;
                        }
                    }
                    this.RadGridProductCustomerReport(this.CompanyID);
                    this.RadGridReports.Visible = false;
                    this.GridProductReport.Visible = false;
                    this.GridReports.Visible = false;
                    this.GridClientReport.Visible = false;
                    this.RadGrid_CustomerJobReport.Visible = false;
                    this.RadGridProductReport_Customer.Visible = true;
                    this.RadGrid_Order_Report.Visible = false;
                    this.RadGrid_StockUsageReport.Visible = false;
                    this.RadGridProductReport_CustomerNew.Visible = false;
                    this.hdnParticularCustomer.Value = "yes";
                    */
                }

                // added code for new report "Stock Release and Adjustment Report 2" by shehzad
                if (linkButton.Text == "Stock Release and Adjustment Report 2")
                {
                    DataTable dataTable = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        dataTable.Columns[j].ReadOnly = false;
                    }
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.hdnParticluarClientID.Value = dataTable.Rows[0]["clientID"].ToString();
                        if (ConnectionClass.ServerName.ToLower() != "dmc")
                        {
                            if (ConnectionClass.ServerName.ToLower() != "dmc2")
                            {
                                continue;
                            }
                            this.hdnParticluarClientID.Value = "16970";
                            break;
                        }
                        else
                        {
                            this.hdnParticluarClientID.Value = "16238";
                            break;
                        }
                    }
                    hdnStockReleaseAdjRep2.Value = "1";
                    this.RadGridProductCustomerReport2(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGridProductReport_Customer.Visible = true;
                    this.hdnParticularCustomer.Value = "yes";
                }
                if (linkButton.Text == "Stock Usage Report by Month and Year")
                {
                    this.RadGridstockUsageReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGrid_StockUsageReport.Visible = true;
                    this.hdnParticularCustomer.Value = "Usage";
                    this.IsStockReportMonth_YearReport = 1;
                }
                if (linkButton.Text == "Stock Usage Report(History)")
                {
                    this.RadGridstockUsageHistoryReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGrid_StockUsageHistoryReport.Visible = true;
                    this.hdnParticularCustomer.Value = "UsageHistory";
                    this.IsStockReportMonth_Year_HistoryReport = 1;
                }
                if (linkButton.Text == "Stock Usage Report")
                {
                    this.RadGridstockUsageReportInPacks(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadStockUsage_Packs.Visible = true;
                    this.hdnParticularCustomer.Value = "packs";
                }
                if (linkButton.Text == "Stock Usage Report - Cost Price")
                {
                    this.RadGridstockUsageReportInPacks_cost(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadStockUsage_Packs.Visible = true;
                    this.hdnParticularCustomer.Value = "packs";
                }
                if ((ConnectionClass.ServerName.ToLower() == "myprojexinventory" || ConnectionClass.ServerName.ToLower() == "anil_v4_0" || ConnectionClass.ServerName.ToLower() == "prelive_4") && linkButton.Text == "Stock Usage Report New")
                {
                    this.RadGridstockUsageReportInPacks_MyProj(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadStockUsage_Packs_MyProj.Visible = true;
                    this.hdnParticularCustomer.Value = "packs_myproj";
                }
                if (linkButton.Text == "Stock Allocation Report")
                {
                    DataTable productSelectClient1 = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int k = 0; k < productSelectClient1.Columns.Count; k++)
                    {
                        productSelectClient1.Columns[k].ReadOnly = false;
                    }
                    foreach (DataRow row1 in productSelectClient1.Rows)
                    {
                        this.hdnParticluarClientID.Value = productSelectClient1.Rows[0]["clientID"].ToString();
                        if (ConnectionClass.ServerName.ToLower() != "dmc")
                        {
                            if (ConnectionClass.ServerName.ToLower() != "dmc2")
                            {
                                continue;
                            }
                            this.hdnParticluarClientID.Value = "16970";
                            break;
                        }
                        else
                        {
                            this.hdnParticluarClientID.Value = "16238";
                            break;
                        }
                    }
                    hdnStockReleaseAdjRep2.Value = "1";// Line added by Bilal sb from my machine. Ticket 9796
                    this.RadGridProductReportNew(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGridProductReport_CustomerNew.Visible = true;
                    this.hdnParticularCustomer.Value = "new";
                }
                if (linkButton.Text == "Items with Reorder Alerts Set")
                {
                    this.BindRadGridItemsWithReorderAlertsSet(this.CompanyID);
                    this.HideAllGridControls();
                    this.hdnParticularCustomer.Value = "ReorderAlertsSet";
                    this.RadGridItemswithReorderAlertsSet.Visible = true;
                }
                if (linkButton.Text == "Items Requiring Reorder")
                {
                    this.BindRadGridItemsRequiringReorder(this.CompanyID);
                    this.hdnParticularCustomer.Value = "ItemsRequiringReorder";

                    HideAllGridControls();
                    this.RadGridItemsRequiringReorder.Visible = true;
                }
            }
            else if (this.pagename == "invoice")
            {
                if (linkButton.Text == "All Invoices by Customer")
                {
                    SetDefaultFilterForSelectedReport();
                    this.BindRadGridAllInvoicesbyCustomer(this.CompanyID, 0, 0, this.hdnDurationFilter.Value);
                    HideAllGridControls();
                    this.RadGridAllInvoicesbyCustomer.Visible = true;
                    this.hdnParticularCustomer.Value = "AllInvoicesbyCustomer";
                }
                if (linkButton.Text == "All Invoices by Accounting Code")
                {
                    SetDefaultFilterForSelectedReport();
                    this.BindRadGridAllInvoicesByItemCode(this.CompanyID, 0, 0, this.hdnDurationFilter.Value);
                    HideAllGridControls();
                    this.RadGridAllInvoicesbyAccountingCode.Visible = true;
                    this.hdnParticularCustomer.Value = "AllInvoicesbyAccountingCode";
                }
                else
                if (linkButton.Text == "Customer Yearly Comparison Report")
                {
                    this.RadGridCustomerYearlyComparisonReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGridCustomerYearlyComparison.Visible = true;
                    this.hdnParticularCustomer.Value = "Yearly Comparison";
                }
            }
            else if (this.pagename == "activitycallreport")
            {
                if (linkButton.Text == "Call Report")
                {
                    this.RadGridClientReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.GridClientReport.Visible = true;
                }
            }
            else if (this.pagename == "webstoreorder")
            {
                if (linkButton.Text == "Order Details Report")
                {
                    this.RadGridoredrReport(this.CompanyID);
                    this.HideAllGridControls();
                    this.RadGrid_Order_Report.Visible = true;
                    this.hdnParticularCustomer.Value = "Order";
                }
                else if (linkButton.Text == "All Orders by Customer")
                {
                    SetDefaultFilterForSelectedReport();
                    this.BindRadGridAllOrdersbyCustomer(this.CompanyID, 0, 0, this.hdnDurationFilter.Value);
                    this.HideAllGridControls();
                    this.RadGridAllOrdersbyCustomer.Visible = true;
                    this.hdnParticularCustomer.Value = "AllOrdersbyCustomer";

                }

            }
            this.OnReportClick(Convert.ToInt32(linkButton.CommandArgument));
        }

        private void SetDefaultFilterForSelectedReport()
        {
            List<KeyValues> lstKeyValues = ePrintUtilities.Utilities.GetReportDurtionsList();
            var selectedItem = lstKeyValues.Where(k => k.isSelected == true).FirstOrDefault();
            if (selectedItem != null)
            {
                this.hdnDurationFilter.Value = selectedItem.value;
            }
        }

        private void SetReportsRelatedSessionNull() 
        {
            this.Session["AllEstimatesbyCustomer"] = null;
            this.Session["AllOrdersbyCustomer"] = null;
            this.Session["AllJobsbyCustomer"] = null;
            this.Session["AllInvoicesByCustomer"] = null;
            this.Session["AllInvoicesbyAccountingCode"] = null;
        }
        private void OnDeleteChange(int ReportID)
        {
            if (this.OnDeleteClick != null)
            {
                this.OnDeleteClick(ReportID);
            }
        }

        private void OnEditChange(int ReportID)
        {
            if (this.OnEditClick != null)
            {
                this.OnEditClick(ReportID);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.RadGridReports.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
            GridFilterMenu languageConversion = this.GridProductReport.FilterMenu;
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
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
            }
            GridFilterMenu gridFilterMenu = this.GridClientReport.FilterMenu;
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
                if (gridFilterMenu.Items[k].Text.ToLower() == "equalto")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
            }
            GridFilterMenu filterMenu1 = this.RadGridProductReport_Customer.FilterMenu;
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
            GridFilterMenu languageConversion1 = this.RadGridProductReport_CustomerNew.FilterMenu;
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
                if (languageConversion1.Items[m].Text.ToLower() == "greaterthan")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "lessthan")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "equalto")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("EqualTo");
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
            GridFilterMenu gridFilterMenu1 = this.RadGrid_StockUsageReport.FilterMenu;
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
                if (gridFilterMenu1.Items[n].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "equalto")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("EqualTo");
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

            GridFilterMenu gridFilterMenuHistory = this.RadGrid_StockUsageHistoryReport.FilterMenu;
            for (int n = gridFilterMenuHistory.Items.Count - 1; n >= 0; n--)
            {
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "nofilter")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "contains")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "doesnotcontain")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "startswith")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "endswith")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "lessthan")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "equalto")
                {
                    gridFilterMenuHistory.Items[n].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "isempty")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "notisempty")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "isnull")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "notisnull")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "between")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
                if (gridFilterMenuHistory.Items[n].Text.ToLower() == "notbetween")
                {
                    gridFilterMenuHistory.Items[n].Visible = false;
                }
            }

            GridFilterMenu filterMenu2 = this.RadGrid_CustomerJobReport.FilterMenu;
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
                if (filterMenu2.Items[o].Text.ToLower() == "greaterthan")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "lessthan")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (filterMenu2.Items[o].Text.ToLower() == "equalto")
                {
                    filterMenu2.Items[o].Text = this.objLanguage.GetLanguageConversion("EqualTo");
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
            GridFilterMenu languageConversion2 = this.RadGrid_Order_Report.FilterMenu;
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
                if (languageConversion2.Items[p].Text.ToLower() == "greaterthan")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "lessthan")
                {
                    languageConversion2.Items[p].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
                if (languageConversion2.Items[p].Text.ToLower() == "equalto")
                {
                    languageConversion2.Items[p].Visible = false;
                }
                if (languageConversion2.Items[p].Text.ToLower() == "notequalto")
                {
                    languageConversion2.Items[p].Visible = false;
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
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        private void OnReportChange(int ReportID)
        {
            if (this.OnReportClick != null)
            {
                this.OnReportClick(ReportID);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Url.ToString().ToLower().Contains("estimate_report"))
            {
                this.pagename = "estimate";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("job_report.aspx"))
            {
                this.pagename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("client_report.aspx"))
            {
                this.pagename = "client";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("purchase_report.aspx"))
            {
                this.pagename = "purchase";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("delivery_report.aspx"))
            {
                this.pagename = "deliverynote";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("inventory_report.aspx"))
            {
                this.pagename = "warehouse";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice_report.aspx"))
            {
                this.pagename = "invoice";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("/finishedgoods_report.aspx?type=store"))
            {
                this.pagename = "store";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("/finishedgoods_report.aspx?type=item"))
            {
                this.pagename = "item";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("order_report.aspx"))
            {
                this.pagename = "webstoreorder";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("productcatalogue_report.aspx"))
            {
                this.pagename = "";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("activity_taskeventreport.aspx"))
            {
                this.pagename = "activitytaskeventreport";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("activity_callreport.aspx"))
            {
                this.pagename = "activitycallreport";
            }
            if (!base.IsPostBack)
            {
                base.Session["SearchProd_Stock"] = null;
                Reports.WhereCondition = "";

                base.Session["ItemswithReorderAlertsSet"] = null;
                base.Session["ItemsRequiringReorder"] = null;



            }
            this.GridBind(this.CompanyID, this.pagename);
            this.DateFormat = base.Session["Dateformat"].ToString();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable1.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable1.Rows[0]["FisCalTo"]);
            this.hdnFromDate.Value = dateTime.ToString();
            this.hdnToDate.Value = dateTime1.ToString();
            this.RadGridProductReport_Customer.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Parent_Category_Sub_Category");
            this.RadGridProductReport_Customer.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Item_code");
            this.RadGridProductReport_Customer.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("p_Customer_code");
            this.RadGridProductReport_Customer.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGridProductReport_Customer.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description");
            this.RadGridProductReport_Customer.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Opening_Stock");
            this.RadGridProductReport_Customer.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Total_Releases");
            this.RadGridProductReport_Customer.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Receipts");
            this.RadGridProductReport_Customer.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Adjustments");
            this.RadGridProductReport_Customer.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Closing_Stock");
            this.RadGridProductReport_Customer.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Releases_Over_Last_13_Weeks");
            this.RadGridProductReport_Customer.Columns[11].HeaderText = this.objLanguage.GetLanguageConversion("Weeks_remaining");
            this.RadGridProductReport_CustomerNew.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Parent_Category_Sub_Category");
            this.RadGridProductReport_CustomerNew.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Item_code");
            this.RadGridProductReport_CustomerNew.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("p_Customer_code");
            this.RadGridProductReport_CustomerNew.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGridProductReport_CustomerNew.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description");
            this.RadGridProductReport_CustomerNew.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Opening_Stock");
            this.RadGridProductReport_CustomerNew.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Allocated_Quantity");
            this.RadGridProductReport_CustomerNew.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Total_Releases");
            this.RadGridProductReport_CustomerNew.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Receipts");
            this.RadGridProductReport_CustomerNew.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Adjustments");
            this.RadGridProductReport_CustomerNew.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Closing_Stock");
            this.RadGridProductReport_CustomerNew.Columns[11].HeaderText = this.objLanguage.GetLanguageConversion("Releases_Over_Last_13_Weeks");
            this.RadGridProductReport_CustomerNew.Columns[12].HeaderText = this.objLanguage.GetLanguageConversion("Weeks_remaining");
            this.RadGrid_CustomerJobReport.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Job_Number");
            this.RadGrid_CustomerJobReport.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Job_Title");
            this.RadGrid_CustomerJobReport.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Department_Name");
            this.RadGrid_CustomerJobReport.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Department_State");
            this.RadGrid_CustomerJobReport.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Parent_Category_Sub_Category");
            this.RadGrid_CustomerJobReport.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Item_Code");
            this.RadGrid_CustomerJobReport.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("p_Customer_code");
            this.RadGrid_CustomerJobReport.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGrid_CustomerJobReport.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description");
            this.RadGrid_CustomerJobReport.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Item_Qty");
            this.RadGrid_CustomerJobReport.Columns[10].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Sales_Value"), " (", this.objCommon.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGrid_Order_Report.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Customer");
            this.RadGrid_Order_Report.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Department");
            this.RadGrid_Order_Report.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Contact");
            this.RadGrid_Order_Report.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
            this.RadGrid_Order_Report.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Order_No");
            this.RadGrid_Order_Report.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_No");
            this.RadGrid_Order_Report.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Order_Date");
            this.RadGrid_Order_Report.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Item_Code");
            this.RadGrid_Order_Report.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGrid_Order_Report.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Product_Type");
            this.RadGrid_Order_Report.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("p_Customer_code");
            this.RadGrid_Order_Report.Columns[11].HeaderText = this.objLanguage.GetLanguageConversion("Order_Qty");
            this.RadGrid_Order_Report.Columns[12].HeaderText = this.objLanguage.GetLanguageConversion("Unit_of_Issue");
            this.RadGrid_Order_Report.Columns[13].HeaderText = this.objLanguage.GetLanguageConversion("Unit_Cost");
            this.RadGrid_Order_Report.Columns[14].HeaderText = this.objLanguage.GetLanguageConversion("Total_Cost_Exc_GST");


            this.RadGridItemswithReorderAlertsSet.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_Display");
            this.RadGridItemsRequiringReorder.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_Display");
            if (this.IsStockReportMonth_YearReport == 1) //--- Safdar Aheer 
            {
                if (this.hdnDepartmentID.Value == "" || this.hdnDepartmentID.Value == "All")
                {
                    this.RadGrid_StockUsageReport.GroupingEnabled = false;
                    return;
                }
                if (this.hdnDepartmentID.Value == "Group")
                {
                    this.RadGrid_StockUsageReport.GroupingEnabled = true;
                    return;
                }
                this.RadGrid_StockUsageReport.GroupingEnabled = false;
            }
            else if (this.IsStockReportMonth_Year_HistoryReport == 1) //--- Safdar Aheer
            {
                if (this.hdnDepartmentID.Value == "" || this.hdnDepartmentID.Value == "All")
                {
                    this.RadGrid_StockUsageHistoryReport.GroupingEnabled = false;
                    return;
                }
                if (this.hdnDepartmentID.Value == "Group")
                {
                    this.RadGrid_StockUsageHistoryReport.GroupingEnabled = true;
                    return;
                }
                this.RadGrid_StockUsageHistoryReport.GroupingEnabled = false;
            }

            RegisterClientScriptForStockManagementDialog();

        }

        private void RegisterClientScriptForStockManagementDialog()
        {
            string script = $@"
                            <script type='text/javascript'>
                                var path = '{strSitepath}';
                                function editstock(id) {{
                                    debugger;
                                    var Rad1Customer = window.radopen(path + 'common/common_popup.aspx?type=stockedit&action=edit&id=' + id, '1000', '500');
                                    SetRadWindow_Ver2('divrad', 'divBackGroundNew');
                                    Rad1Customer.setSize(1330, 520);
                                    Rad1Customer.center();
                                    Rad1Customer.id = 'Radwindowstock';
                                }}
                            </script>";

            if (!Page.ClientScript.IsStartupScriptRegistered("editStockScript"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "editStockScript", script);
            }
        }
        protected string FormatCustomerBadges(object customerStringObj)
        {
            string customerString = customerStringObj?.ToString() ?? "";
            var customers = customerString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(c => c.Trim());

            return string.Join(" ", customers.Select(c => $"<span class='badge badge-secondary'>{c}</span> <br>"));
        }


        protected void RadGrid_Order_Report_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!(e.CommandName == "Filter") || !(((Pair)e.CommandArgument).Second.ToString() == "OrderedDate"))
            {
                if (e.CommandName != "Sort" && e.CommandName != "Page")
                {
                    base.Session["filterPattern"] = null;
                }
                return;
            }
            string str = "";
            string str1 = "";
            e.Canceled = true;
            GridFilteringItem item = (GridFilteringItem)e.Item;
            string text = (item[((Pair)e.CommandArgument).Second.ToString()].Controls[0] as TextBox).Text;
            str = this.objCommon.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, text.ToString().Trim());
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
            base.Session["filterPattern"] = str;
            columnSafe.CurrentFilterValue = text;
            item.OwnerTableView.Rebind();
        }

        protected void RadGrid_Order_Report_ItemDataBound(object sender, GridItemEventArgs e)
        {
            RadComboBox radComboBox = (RadComboBox)e.Item.FindControl("Customerlist");
            TextBox textBox = (TextBox)e.Item.FindControl("txtOrderFromDate");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtOrderToDate");
            DropDownList value = (DropDownList)e.Item.FindControl("ddlStockItem");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkreplishment");
            Label label = (Label)e.Item.FindControl("lblOrderedDate");
            if (textBox != null && textBox1 != null)
            {
                if (textBox.Text != "")
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                    this.orderFromdate = textBox.Text;
                }
                else
                {
                    textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderFromdate.Value, this.CompanyID, this.UserID, false);
                }
                if (textBox1.Text != "")
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                    this.orderTodate = textBox1.Text;
                }
                else
                {
                    textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.hdnOrderTodate.Value, this.CompanyID, this.UserID, false);
                }
                textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.hdnOrderFromdate.Value = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                this.hdnOrderTodate.Value = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
            }
            if (label != null)
            {
                label.Text = this.objCommon.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, true);
            }
            if (radComboBox != null)
            {
                radComboBox.Items.Add(new RadComboBoxItem("-- Customer Name -- "));
                CheckBoxList checkBoxList = (CheckBoxList)radComboBox.Items[0].FindControl("chkclientname");
                CheckBoxList checkBoxList1 = new CheckBoxList();
                ListItem listItem = new ListItem();
                DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                for (int i = 0; i < productSelectClient.Columns.Count; i++)
                {
                    productSelectClient.Columns[i].ReadOnly = false;
                }
                int num = 0;
                foreach (DataRow row in productSelectClient.Rows)
                {
                    listItem = new ListItem(this.objBase.SpecialDecode(row["clientname"].ToString()), this.objBase.SpecialDecode(row["clientID"].ToString()));
                    AttributeCollection attributes = listItem.Attributes;
                    object[] objArray = new object[] { "javascript:getSelectedItem(this.id,", num, ",", this.objBase.SpecialDecode(row["clientID"].ToString()), ")" };
                    attributes.Add("onclick", string.Concat(objArray));
                    checkBoxList.Items.Add(listItem);
                    num++;
                }
                if (this.hdnOrderClientID.Value != "")
                {
                    int num1 = 0;
                    string str = this.hdnOrderClientID.Value.ToString();
                    string[] strArrays = str.Split(new char[] { ',' });
                    foreach (RadComboBoxItem item in radComboBox.Items)
                    {
                        foreach (ListItem item1 in ((CheckBoxList)item.FindControl("chkclientname")).Items)
                        {
                            for (int j = 0; j < (int)strArrays.Length; j++)
                            {
                                if (item1.Value == strArrays[j].ToString())
                                {
                                    item1.Selected = true;
                                    num1++;
                                }
                            }
                        }
                    }
                    radComboBox.EmptyMessage = string.Concat(num1, " Customer selected");
                }
            }
            if (value != null)
            {
                value.Items.Insert(0, new ListItem("-- Item Type --", ""));
                value.Items.Insert(1, new ListItem("All", "All"));
                value.Items.Insert(2, new ListItem("Stock", "1"));
                value.Items.Insert(3, new ListItem("Non Stock", "0"));
                value.Items.Insert(4, new ListItem("Editable", "3"));
                value.Items.Insert(5, new ListItem("Stock Editable", "2"));
                value.SelectedValue = this.hdnisstockItem.Value;
            }
            if (checkBox != null && this.hdnisreplinsh.Value != "")
            {
                checkBox.Checked = true;
            }
        }

        protected void RadGrid_Order_Report_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            GridTableView masterTableView = this.RadGrid_Order_Report.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            TextBox textBox = (TextBox)items.FindControl("txtOrderFromDate");
            TextBox textBox1 = (TextBox)items.FindControl("txtOrderToDate");
            this.orderFromdate = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
            this.orderTodate = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
            this.hdnOrderFromdate.Value = this.orderFromdate;
            this.hdnOrderTodate.Value = this.orderTodate;
            if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["AllowUnApprovedOrder"]))
            {
                this.AllowUnApprovedOrder = true;
            }
            if (this.hdnOrderClientID.Value != "")
            {
                string str = this.hdnOrderClientID.Value.ToString();
                str = str.Remove(str.Length - 1, 1);
                this.hdnOrderClientID.Value = str;
            }
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.OrderDetailsReport((long)this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Convert.ToDateTime(this.hdnOrderFromdate.Value), Convert.ToDateTime(this.hdnOrderTodate.Value), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
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
                    if (!row.Table.Columns.Contains("Customer Code"))
                    {
                        continue;
                    }
                    row["Customer Code"] = this.objBase.SpecialDecode(row["Customer Code"].ToString());
                }
            }
            this.RadGrid_Order_Report.DataSource = dataTable;
            if (base.Session["filterPattern"] != null)
            {
                this.RadGrid_Order_Report.MasterTableView.FilterExpression = base.Session["filterPattern"].ToString();
            }
        }

        protected void RadGrid_StockUsageReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                this.RadGrid_StockUsageReport.Style.Add("width", "1980px");
                DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
                DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
                DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
                DateTime.Now.AddMonths(-12);
                dateTime.AddYears(-1);
                dateTime1.AddYears(-1);
                DropDownList value = (DropDownList)e.Item.FindControl("ddlCustomerName");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddldepartment");
                DropDownList value1 = (DropDownList)e.Item.FindControl("ddlMonthCategory");
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
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                    }
                    value.DataSource = productSelectClient;
                    value.DataTextField = "clientname";
                    value.DataValueField = "clientID";
                    value.DataBind();
                    int count = productSelectClient.Rows.Count;
                    value.Items.Insert(0, new ListItem("-- Customer Name --", " "));
                    value.Items.Insert(1, new ListItem("All", "All"));
                    if (this.hdnParticluarClientID.Value != "0" || this.hdnParticluarClientID.Value != "")
                    {
                        value.SelectedValue = this.hdnParticluarClientID.Value;
                    }
                }
                if (dropDownList != null)
                {
                    if (this.hdnParticluarClientID.Value == "")
                    {
                        dropDownList.Items.Insert(0, new ListItem("-- Department Name --", ""));
                        dropDownList.Items.Insert(1, new ListItem("All", "All"));
                        dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                    }
                    else if (this.hdnParticluarClientID.Value != "All")
                    {
                        DataTable productSelectDepartment = SettingsBasePage.GetProduct_SelectDepartment(this.CompanyID, this.hdnParticluarClientID.Value);
                        for (int j = 0; j < productSelectDepartment.Columns.Count; j++)
                        {
                            productSelectDepartment.Columns[j].ReadOnly = false;
                        }
                        foreach (DataRow dataRow in productSelectDepartment.Rows)
                        {
                            dataRow["Deptname"] = this.objBase.SpecialDecode(dataRow["Deptname"].ToString());
                        }
                        dropDownList.DataSource = productSelectDepartment;
                        dropDownList.DataTextField = "Deptname";
                        dropDownList.DataValueField = "Deptid";
                        dropDownList.DataBind();
                        int num = productSelectDepartment.Rows.Count;
                        dropDownList.Items.Insert(0, new ListItem("-- Department Name --", " "));
                        dropDownList.Items.Insert(1, new ListItem("All", "All"));
                        dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                        dropDownList.Items.Insert(3, new ListItem("---------------------------------------", "Group"));
                    }
                    else
                    {
                        dropDownList.Items.Insert(0, new ListItem("-- Department Name --", ""));
                        dropDownList.Items.Insert(1, new ListItem("All", "All"));
                        dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                    }
                    if (this.hdnDepartmentID.Value != "0" || this.hdnDepartmentID.Value != "")
                    {
                        dropDownList.SelectedValue = this.hdnDepartmentID.Value;
                    }
                }
                if (value1 != null)
                {
                    value1.Items.Insert(0, new ListItem("Show this Calendar Year", "CM"));
                    value1.Items.Insert(1, new ListItem("Show by Last Financial Year", "LFM"));
                    value1.Items.Insert(2, new ListItem("Show by Current Financial Year", "CFM"));
                    value1.Items.Insert(3, new ListItem("Show for Last 12 Month", "LTM"));
                    value1.SelectedValue = this.hdnMonthCategory.Value;
                }
                GridColumn[] renderColumns = e.Item.OwnerTableView.RenderColumns;
                for (int k = 0; k < (int)renderColumns.Length; k++)
                {
                    GridColumn empty = renderColumns[k];
                    empty.AutoPostBackOnFilter = true;
                    if (empty.UniqueName == "January" || empty.UniqueName == "February" || empty.UniqueName == "March" || empty.UniqueName == "April" || empty.UniqueName == "May" || empty.UniqueName == "June" || empty.UniqueName == "July" || empty.UniqueName == "August" || empty.UniqueName == "September" || empty.UniqueName == "October" || empty.UniqueName == "November" || empty.UniqueName == "December" || empty.UniqueName == "UOI" || empty.UniqueName == "Total Sales")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                    }
                    else if (empty.UniqueName == "Item Title")
                    {
                        empty.HeaderStyle.Width = Unit.Pixel(500);
                        empty.FilterControlWidth = Unit.Pixel(170);
                    }
                    else if (empty.UniqueName == "Stock Sales Value" || empty.UniqueName == "Avg Month Usage" || empty.UniqueName == "Month Over")
                    {
                        empty.HeaderStyle.Wrap = false;
                        empty.HeaderStyle.Width = Unit.Pixel(300);
                        empty.FilterControlWidth = Unit.Pixel(40);
                    }
                    else if (empty.UniqueName == "Month On List")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                        empty.HeaderText = "Month on List";
                    }
                    else if (empty.UniqueName == "Quantity on Hand")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                        empty.HeaderText = "Quantity on Hand";
                    }
                    else if (empty.UniqueName == "DeptID" || empty.UniqueName == "DeptName" || empty.UniqueName == "DeptId")
                    {
                        empty.Visible = false;
                    }
                    if (base.Session["checkfilter"] != null && base.Session["checkfilter"] == null)
                    {
                        empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty.CurrentFilterValue = string.Empty;
                    }
                }
                if (base.Session["checkfilter"] != null && base.Session["checkfilter"] == null)
                {
                    base.Session["checkfilter"] = null;
                }
                if (e.Item is GridGroupHeaderItem)
                {
                    GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    string[] strArrays = item.DataCell.Text.Split(new char[] { ':' });
                    if (!strArrays[1].Contains("("))
                    {
                        item.DataCell.Text = strArrays[1].Trim();
                    }
                    else
                    {
                        item.DataCell.Text = strArrays[1].Replace("... group c", "C").Replace(". Group c", ". C").Trim();
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

        protected void RadGrid_StockUsageHistoryReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                this.RadGrid_StockUsageHistoryReport.Style.Add("width", "1980px");
                DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
                DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
                DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
                DateTime.Now.AddMonths(-12);
                dateTime.AddYears(-1);
                dateTime1.AddYears(-1);
                DropDownList value = (DropDownList)e.Item.FindControl("ddlCustomerName");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddldepartment");
                DropDownList value1 = (DropDownList)e.Item.FindControl("ddlMonthCategory");
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
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                    }
                    value.DataSource = productSelectClient;
                    value.DataTextField = "clientname";
                    value.DataValueField = "clientID";
                    value.DataBind();
                    int count = productSelectClient.Rows.Count;
                    value.Items.Insert(0, new ListItem("-- Customer Name --", " "));
                    value.Items.Insert(1, new ListItem("All", "All"));
                    if (this.hdnParticluarClientID.Value != "0" || this.hdnParticluarClientID.Value != "")
                    {
                        value.SelectedValue = this.hdnParticluarClientID.Value;
                    }
                }
                if (dropDownList != null)
                {
                    if (this.hdnParticluarClientID.Value == "")
                    {
                        dropDownList.Items.Insert(0, new ListItem("-- Department Name --", ""));
                        dropDownList.Items.Insert(1, new ListItem("All", "All"));
                        dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                    }
                    else if (this.hdnParticluarClientID.Value != "All")
                    {
                        DataTable productSelectDepartment = SettingsBasePage.GetProduct_SelectDepartment(this.CompanyID, this.hdnParticluarClientID.Value);
                        for (int j = 0; j < productSelectDepartment.Columns.Count; j++)
                        {
                            productSelectDepartment.Columns[j].ReadOnly = false;
                        }
                        foreach (DataRow dataRow in productSelectDepartment.Rows)
                        {
                            dataRow["Deptname"] = this.objBase.SpecialDecode(dataRow["Deptname"].ToString());
                        }
                        dropDownList.DataSource = productSelectDepartment;
                        dropDownList.DataTextField = "Deptname";
                        dropDownList.DataValueField = "Deptid";
                        dropDownList.DataBind();
                        int num = productSelectDepartment.Rows.Count;
                        dropDownList.Items.Insert(0, new ListItem("-- Department Name --", " "));
                        dropDownList.Items.Insert(1, new ListItem("All", "All"));
                        dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                        dropDownList.Items.Insert(3, new ListItem("---------------------------------------", "Group"));
                    }
                    else
                    {
                        dropDownList.Items.Insert(0, new ListItem("-- Department Name --", ""));
                        dropDownList.Items.Insert(1, new ListItem("All", "All"));
                        dropDownList.Items.Insert(2, new ListItem("All Summarised by Department", "Group"));
                    }
                    if (this.hdnDepartmentID.Value != "0" || this.hdnDepartmentID.Value != "")
                    {
                        dropDownList.SelectedValue = this.hdnDepartmentID.Value;
                    }
                }
                if (value1 != null)
                {
                    value1.Items.Insert(0, new ListItem("Show this Calendar Year", "CM"));
                    value1.Items.Insert(1, new ListItem("Show by Last Financial Year", "LFM"));
                    value1.Items.Insert(2, new ListItem("Show by Current Financial Year", "CFM"));
                    value1.Items.Insert(3, new ListItem("Show for Last 12 Month", "LTM"));
                    value1.SelectedValue = this.hdnMonthCategory.Value;
                }
                GridColumn[] renderColumns = e.Item.OwnerTableView.RenderColumns;
                for (int k = 0; k < (int)renderColumns.Length; k++)
                {
                    GridColumn empty = renderColumns[k];
                    empty.AutoPostBackOnFilter = true;
                    if (empty.UniqueName == "January" || empty.UniqueName == "February" || empty.UniqueName == "March" || empty.UniqueName == "April" || empty.UniqueName == "May" || empty.UniqueName == "June" || empty.UniqueName == "July" || empty.UniqueName == "August" || empty.UniqueName == "September" || empty.UniqueName == "October" || empty.UniqueName == "November" || empty.UniqueName == "December" || empty.UniqueName == "UOI" || empty.UniqueName == "Total Sales")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                    }
                    else if (empty.UniqueName == "Item Title")
                    {
                        empty.HeaderStyle.Width = Unit.Pixel(500);
                        empty.FilterControlWidth = Unit.Pixel(170);
                    }
                    else if (empty.UniqueName == "Stock Sales Value" || empty.UniqueName == "Avg Month Usage" || empty.UniqueName == "Month Over")
                    {
                        empty.HeaderStyle.Wrap = false;
                        empty.HeaderStyle.Width = Unit.Pixel(300);
                        empty.FilterControlWidth = Unit.Pixel(40);
                    }
                    else if (empty.UniqueName == "Month On List")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                        empty.HeaderText = "Month on List";
                    }
                    else if (empty.UniqueName == "Quantity on Hand")
                    {
                        empty.FilterControlWidth = Unit.Pixel(40);
                        empty.HeaderText = "Quantity on Hand";
                    }
                    else if (empty.UniqueName == "DeptID" || empty.UniqueName == "DeptName" || empty.UniqueName == "DeptId")
                    {
                        empty.Visible = false;
                    }
                    if (base.Session["checkfilter"] != null && base.Session["checkfilter"] == null)
                    {
                        empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        empty.CurrentFilterValue = string.Empty;
                    }
                }
                if (base.Session["checkfilter"] != null && base.Session["checkfilter"] == null)
                {
                    base.Session["checkfilter"] = null;
                }
                if (e.Item is GridGroupHeaderItem)
                {
                    GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    string[] strArrays = item.DataCell.Text.Split(new char[] { ':' });
                    if (!strArrays[1].Contains("("))
                    {
                        item.DataCell.Text = strArrays[1].Trim();
                    }
                    else
                    {
                        item.DataCell.Text = strArrays[1].Replace("... group c", "C").Replace(". Group c", ". C").Trim();
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
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }
            DataTable dataTable = SettingsBasePage.ProductstockUsageReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
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
            this.RadGrid_StockUsageReport.DataSource = dataTable;
        }

        protected void RadGrid_StockUsageHistoryReport_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }
            DataTable dataTable = SettingsBasePage.ProductstockUsageHistoryReport((long)this.CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
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
        }

        public void RadGridClientReport(int CompanyID)
        {
            DataTable dataTable = SettingsBasePage.CustomizeClient_Report(CompanyID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("Customer"))
                    {
                        row["Customer"] = this.objBase.SpecialDecode(row["Customer"].ToString());
                    }
                    if (row.Table.Columns.Contains("ContactName"))
                    {
                        row["ContactName"] = this.objBase.SpecialDecode(row["ContactName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Subject"))
                    {
                        row["Subject"] = this.objBase.SpecialDecode(row["Subject"].ToString());
                    }
                    if (row.Table.Columns.Contains("CallType"))
                    {
                        row["CallType"] = this.objBase.SpecialDecode(row["CallType"].ToString());
                    }
                    if (row.Table.Columns.Contains("CallPurpose"))
                    {
                        row["CallPurpose"] = this.objBase.SpecialDecode(row["CallPurpose"].ToString());
                    }
                    if (row.Table.Columns.Contains("CallResult"))
                    {
                        row["CallResult"] = this.objBase.SpecialDecode(row["CallResult"].ToString());
                    }
                    if (row.Table.Columns.Contains("Description"))
                    {
                        row["Description"] = this.objBase.SpecialDecode(row["Description"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Status"))
                    {
                        continue;
                    }
                    row["Status"] = this.objBase.SpecialDecode(row["Status"].ToString());
                }
            }
            this.GridClientReport.DataSource = dataTable;
            this.GridClientReport.DataBind();
        }

        protected void RadGridCustomerJobReport_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DropDownList value = (DropDownList)e.Item.FindControl("ddlJobParticularCustomerName");
                TextBox textBox = (TextBox)e.Item.FindControl("txtJobFromDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtJobToDate");
                if (value != null)
                {
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                    }
                    value.DataSource = productSelectClient;
                    value.DataTextField = "clientname";
                    value.DataValueField = "clientID";
                    value.DataBind();
                    int count = productSelectClient.Rows.Count;
                    if (this.hdnJobSelectedClientID.Value != "0")
                    {
                        value.SelectedValue = this.hdnJobSelectedClientID.Value;
                    }
                    this.RadGrid_CustomerJobReport.GroupPanel.Text = this.objLanguage.GetLanguageConversion("Drag_a_column_header_Department_Name_Department_State_Category_Customer_Code_and_drop_it_here_to_group_by_that_column");
                    DateTime now = DateTime.Now;
                    DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                    DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                    DateTime dateTime2 = dateTime1.AddMonths(1);
                    dateTime[1] = dateTime2.AddDays(-1);
                    if (this.JobFromDate != "")
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.JobFromDate, this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, this.UserID, false);
                    }
                    textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    if (this.JobToDate != "")
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.JobToDate, this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, this.UserID, false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
                Label label = (Label)e.Item.FindControl("lblSalesValue");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnSubItemSalesValue");
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    if (hiddenField.Value.ToLower() == "no")
                    {
                        label.Text = "n/a";
                    }
                }
                if (e.Item is GridFooterItem)
                {
                    GridFooterItem gridFooterItem = (GridFooterItem)e.Item;
                    (gridFooterItem["ItemQTy"].FindControl("lblSumTotalQty") as Label).Text = this.hdnTotalQty.Value;
                    (gridFooterItem["SalesValue"].FindControl("lblSumTotalSubTotal") as Label).Text = this.hdnTotalSalesValue.Value;
                }
                GridItem[] items = this.RadGrid_CustomerJobReport.MasterTableView.GetItems(new GridItemType[] { GridItemType.GroupFooter });
                for (int j = 0; j < (int)items.Length; j++)
                {
                    GridGroupFooterItem gridGroupFooterItem = (GridGroupFooterItem)items[j];
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
                if (e.Item is GridFilteringItem)
                {
                    GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                    gridFilteringItem["ItemQTy"].HorizontalAlign = HorizontalAlign.Right;
                    gridFilteringItem["SalesValue"].HorizontalAlign = HorizontalAlign.Right;
                }
                if (e.Item is GridPagerItem)
                {
                    Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem gridPagerItem = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.RadGrid_CustomerJobReport.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }

                //[Ticket #6174 ] Modified header column for both allocation and release report by shehzad                 
                if (e.Item is GridHeaderItem)
                {
                    GridHeaderItem item = e.Item as GridHeaderItem;
                    if (hdnStockProdAllocateReport.Value == "1")
                    {
                        item["ItemQty"].Text = "Item Qty Allocated";
                    }
                    else if (hdnStockProdSalRelRep2.Value == "1")
                    {
                        item["ItemQty"].Text = "Item Qty Released";
                    }

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
                if (this.hdnJobSelectedClientID.Value == "")
                {
                    this.hdnJobSelectedClientID.Value = "0";
                }
                GridTableView masterTableView = this.RadGrid_CustomerJobReport.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtJobFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtJobToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                this.JobFromDate = textBox.Text;
                this.JobToDate = textBox1.Text;
                this.hdnJobFormdate.Value = textBox.Text;
                this.hdnJobToDate.Value = textBox1.Text;

                // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
                DataSet dataSet;
                if (hdnStockProdSalRelRep2.Value != "1")
                {
                    dataSet = SettingsBasePage.JobReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
                }
                else
                {
                    dataSet = SettingsBasePage.JobReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression);
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
            }
            catch
            {
            }
        }

        public void RadGridJobCustomerReport(int CompanyID)
        {
            try
            {
                if (this.hdnJobSelectedClientID.Value == "")
                {
                    this.hdnJobSelectedClientID.Value = "0";
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataSet dataSet = new DataSet();
                dataSet = (this.JobFromDate == "" || this.JobToDate == "" ? SettingsBasePage.JobReport_CustomizeCustomer((long)CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), dateTime[0], dateTime[1], this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression) : SettingsBasePage.JobReport_CustomizeCustomer((long)CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(this.JobFromDate), Convert.ToDateTime(this.JobToDate), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression));
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

        // added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
        public void RadGridJobCustomerReport2(int CompanyID)
        {
            try
            {
                if (this.hdnJobSelectedClientID.Value == "")
                {
                    this.hdnJobSelectedClientID.Value = "0";
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataSet dataSet = new DataSet();
                dataSet = (this.JobFromDate == "" || this.JobToDate == "" ? SettingsBasePage.JobReport_CustomizeCustomer2((long)CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), dateTime[0], dateTime[1], this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression) : SettingsBasePage.JobReport_CustomizeCustomer2((long)CompanyID, Convert.ToInt64(this.hdnJobSelectedClientID.Value), Convert.ToDateTime(this.JobFromDate), Convert.ToDateTime(this.JobToDate), this.RadGrid_CustomerJobReport.MasterTableView.FilterExpression));
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
            DataTable dataTable = SettingsBasePage.CustomizeJob_Report(CompanyID, this.hdnFromDate.Value, this.hdnToDate.Value);
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
            this.RadGridReports.DataSource = dataTable;
            this.RadGridReports.DataBind();
        }

        protected void RadGridJobReports_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.CustomizeJob_Report(this.CompanyID, this.hdnFromDate.Value, this.hdnToDate.Value);
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
            this.RadGridReports.DataSource = dataTable;
        }

        public void RadGridoredrReport(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            if (this.hdnOrderClientID.Value != "")
            {
                string str = this.hdnOrderClientID.Value.ToString();
                str = str.Remove(str.Length - 1, 1);
                this.hdnOrderClientID.Value = str;
            }
            if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows[0]["AllowUnApprovedOrder"]))
            {
                this.AllowUnApprovedOrder = true;
            }
            if (!(this.hdnOrderTodate.Value == "0") || !(this.hdnOrderFromdate.Value == "0"))
            {
                DateTime now = DateTime.Now;
                if (this.orderFromdate == "")
                {
                    DateTime dateTime = new DateTime(now.Year, now.Month, 1);
                    this.orderFromdate = dateTime.ToString();
                }
                if (this.orderTodate == "")
                {
                    DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                    DateTime dateTime2 = dateTime1.AddMonths(1);
                    this.orderTodate = dateTime2.AddDays(-1).ToString();
                }
                dataTable = SettingsBasePage.OrderDetailsReport((long)CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Convert.ToDateTime(this.orderFromdate), Convert.ToDateTime(this.orderTodate), this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
            }
            else
            {
                DateTime now1 = DateTime.Now;
                DateTime[] dateTimeArray = new DateTime[] { new DateTime(now1.Year, now1.Month, 1), default(DateTime) };
                DateTime dateTime3 = new DateTime(now1.Year, now1.Month, 1);
                DateTime dateTime4 = dateTime3.AddMonths(1);
                dateTimeArray[1] = dateTime4.AddDays(-1);
                dataTable = SettingsBasePage.OrderDetailsReport((long)CompanyID, Convert.ToString(this.hdnOrderClientID.Value), dateTimeArray[0], dateTimeArray[1], this.hdnisstockItem.Value.ToString(), this.hdnisreplinsh.Value.ToString(), this.AllowUnApprovedOrder);
                this.hdnOrderFromdate.Value = dateTimeArray[0].ToString();
                this.hdnOrderTodate.Value = dateTimeArray[1].ToString();
            }
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
                    if (!row.Table.Columns.Contains("Customer Code"))
                    {
                        continue;
                    }
                    row["Customer Code"] = this.objBase.SpecialDecode(row["Customer Code"].ToString());
                }
            }
            this.RadGrid_Order_Report.DataSource = dataTable;
            this.RadGrid_Order_Report.DataBind();
        }

        public void RadGridProductCustomerReport(int CompanyID)
        {
            try
            {
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataTable dataTable = new DataTable();
                dataTable = (this.FromDate == "" || this.ToDate == "" ? SettingsBasePage.ProductReport_CustomizeCustomer((long)CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), dateTime[0], dateTime[1]) : SettingsBasePage.ProductReport_CustomizeCustomer((long)CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate)));
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
                this.RadGridProductReport_Customer.DataSource = dataTable;
                this.RadGridProductReport_Customer.DataBind();
            }
            catch
            {
            }
        }

        // added code for new report "Stock Release and Adjustment Report 2" by shehzad
        public void RadGridProductCustomerReport2(int CompanyID)
        {
            try
            {
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataTable dataTable = new DataTable();
                dataTable = (this.FromDate == "" || this.ToDate == "" ? SettingsBasePage.ProductReport_CustomizeCustomer2((long)CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), dateTime[0], dateTime[1]) : SettingsBasePage.ProductReport_CustomizeCustomer2((long)CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate)));
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
                this.RadGridProductReport_Customer.DataSource = dataTable;
                this.RadGridProductReport_Customer.DataBind();
            }
            catch
            {
            }
        }
        public void RadGridProductReport(int CompanyID)
        {
            try
            {
                if (this.hdnClientID.Value == "")
                {
                    this.hdnClientID.Value = "0";
                }
                DataTable dataTable = SettingsBasePage.CustomizeProduct_Report(CompanyID, Convert.ToInt64(this.hdnClientID.Value));
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
                this.GridProductReport.DataSource = dataTable;
                this.GridProductReport.DataBind();
                this.divReceipts.Style.Add("display", "block");
                this.lblReceiptsText.Text = this.objLanguage.GetLanguageConversion("Receipts_includes_both_stock_purchased_and_manually_added");
            }
            catch
            {
            }
        }

        protected void RadGridProductReport_CustomerNew_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DropDownList value = (DropDownList)e.Item.FindControl("ddlParticularCustomerName");
                TextBox textBox = (TextBox)e.Item.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtToDate");
                if (value != null)
                {
                    DateTime now = DateTime.Now;
                    DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                    DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                    DateTime dateTime2 = dateTime1.AddMonths(1);
                    dateTime[1] = dateTime2.AddDays(-1);
                    if (this.FromDate != "")
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.FromDate, this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, this.UserID, false);
                    }
                    textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    if (this.ToDate != "")
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.ToDate, this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, this.UserID, false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                    }
                    value.DataSource = productSelectClient;
                    value.DataTextField = "clientname";
                    value.DataValueField = "clientID";
                    value.DataBind();
                    int count = productSelectClient.Rows.Count;
                    if (this.hdnParticluarClientID.Value != "0")
                    {
                        value.SelectedValue = this.hdnParticluarClientID.Value;
                    }
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
                    item["AllocatedQty"].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            catch
            {
            }
        }

        protected void RadGridProductReport_CustomerNew_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                GridTableView masterTableView = this.RadGridProductReport_CustomerNew.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                this.FromDate = textBox.Text;
                this.ToDate = textBox1.Text;
                this.hdnProductFormDate.Value = textBox.Text;
                this.hdnProductToDate.Value = textBox1.Text;
                DataTable dataTable;
                if (hdnStockReleaseAdjRep2.Value != "1")
                {
                    dataTable = SettingsBasePage.ProductReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
                }
                else
                {
                    dataTable = SettingsBasePage.ProductReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
                }

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
                this.RadGridProductReport_CustomerNew.DataSource = dataTable;
            }
            catch
            {
            }
        }

        protected void RadGridItemswithReorderAlertsSet_GO_OnClick(object sender, EventArgs e)
        {
            long clientId = string.IsNullOrEmpty(this.hdnParticluarClientID.Value) ? 0 : Convert.ToInt64(this.hdnParticluarClientID.Value);
            BindRadGridItemsWithReorderAlertsSet(this.CompanyID, clientId);
        }

        protected void RadGridItemswithReorderAlertsSet_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);

                GridFilteringItem filterItem = (GridFilteringItem)e.Item;
                DataTable dt = (DataTable)Session["ItemswithReorderAlertsSet"];

                if (dt != null)
                {
                    // Clone structure for filtered result
                    DataTable filteredTable = dt.Clone();

                    foreach (DataRow row in dt.Rows)
                    {
                        bool match = true;

                        foreach (GridColumn col in RadGridItemswithReorderAlertsSet.MasterTableView.Columns)
                        {
                            string colName = col.UniqueName;
                            if (colName == "PriceCatalogueID")
                            {
                                continue;
                            }

                            Control ctrl = filterItem[colName].Controls[0];

                            if (ctrl is TextBox tb)
                            {
                                string filterText = tb.Text?.Trim();
                                string cellValue = row[colName].ToString();

                                if (!string.IsNullOrEmpty(filterText))
                                {
                                    if (row.Table.Columns[colName].DataType == typeof(DateTime))
                                    {
                                        DateTime dtValue = (DateTime)row[colName];
                                        cellValue = this.objCommon.Eprint_return_Date_Before_View(Convert.ToString(dtValue), this.CompanyID, this.UserID, true);
                                    }

                                    if (!cellValue.ToLower().Contains(filterText.ToLower()))
                                    {
                                        match = false;
                                        break; // one column didn’t match → skip row
                                    }
                                }
                            }
                        }

                        if (match)
                            filteredTable.ImportRow(row);
                    }

                    RadGridItemswithReorderAlertsSet.DataSource = filteredTable;
                    RadGridItemswithReorderAlertsSet.DataBind();
                    e.Canceled = true; // prevent default filtering 
                }
            }
        }

        protected void RadGridItemswithReorderAlertsSet_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                //GridTableView masterTableView = this.RadGridProductReport_CustomerNew.MasterTableView;
                //GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                //GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                if (Session["ItemswithReorderAlertsSet"] != null)
                {
                    BindRadGridItemsWithReorderAlertsSet(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), (DataTable)Session["ItemswithReorderAlertsSet"]);
                }

            }
            catch
            {
            }
        }
        protected void RadGridItemsRequiringReorder_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                //GridTableView masterTableView = this.RadGridProductReport_CustomerNew.MasterTableView;
                //GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                //GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                if (Session["ItemsRequiringReorder"] != null)
                {
                    BindRadGridItemsRequiringReorder(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), (DataTable)Session["ItemsRequiringReorder"]);
                }
            }
            catch
            {
            }
        }

        protected void RadGridItemsWithReorderAlertsSet_ItemDataBound(object sender, GridItemEventArgs e)
        {

            DropDownList value = (DropDownList)e.Item.FindControl("ddlParticularCustomerNameAlertsSet");
            if (value != null)
            {
                DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                for (int i = 0; i < productSelectClient.Columns.Count; i++)
                {
                    productSelectClient.Columns[i].ReadOnly = false;
                }
                foreach (DataRow row in productSelectClient.Rows)
                {
                    row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                }
                value.DataSource = productSelectClient;
                value.DataTextField = "clientname";
                value.DataValueField = "clientID";
                value.DataBind();
                value.Items.Insert(0, new ListItem("-- Customer Name -- ", ""));
                int count = productSelectClient.Rows.Count;
                if (this.hdnParticluarClientID.Value != "0")
                {
                    value.SelectedValue = this.hdnParticluarClientID.Value;
                }
            }
            Label lblEmailSentOn = (Label)e.Item.FindControl("lblEmailSentOn");
            if (lblEmailSentOn != null)
            {
                lblEmailSentOn.Text = this.objCommon.Eprint_return_Date_Before_View(lblEmailSentOn.Text, this.CompanyID, this.UserID, true);
            }
        }
        protected void RadGridItemsRequiringReorder_GO_OnClick(object sender, EventArgs e)
        {
            long clientId = string.IsNullOrEmpty(this.hdnParticluarClientID.Value) ? 0 : Convert.ToInt64(this.hdnParticluarClientID.Value);
            BindRadGridItemsRequiringReorder(this.CompanyID, clientId);
        }

        protected void RadGridItemsRequiringReorder_ItemDataBound(object sender, GridItemEventArgs e)
        {
            DropDownList value = (DropDownList)e.Item.FindControl("ddlParticularCustomerName");
            if (value != null)
            {
                DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                for (int i = 0; i < productSelectClient.Columns.Count; i++)
                {
                    productSelectClient.Columns[i].ReadOnly = false;
                }
                foreach (DataRow row in productSelectClient.Rows)
                {
                    row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                }
                value.DataSource = productSelectClient;
                value.DataTextField = "clientname";
                value.DataValueField = "clientID";
                value.DataBind();
                value.Items.Insert(0, new ListItem("-- Customer Name -- ", ""));
                int count = productSelectClient.Rows.Count;
                if (this.hdnParticluarClientID.Value != "0")
                {
                    value.SelectedValue = this.hdnParticluarClientID.Value;
                }
            }
            Label lblEmailSentOn = (Label)e.Item.FindControl("lblEmailSentOn");
            if (lblEmailSentOn != null)
            {
                lblEmailSentOn.Text = this.objCommon.Eprint_return_Date_Before_View(lblEmailSentOn.Text, this.CompanyID, this.UserID, true);
            }

        }

        protected void RadGridmsItemsRequiringReorder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);

                GridFilteringItem filterItem = (GridFilteringItem)e.Item;
                DataTable dt = (DataTable)Session["ItemsRequiringReorder"];
                if (dt != null)
                {
                    // Clone structure for filtered result
                    DataTable filteredTable = dt.Clone();

                    foreach (DataRow row in dt.Rows)
                    {
                        bool match = true;

                        foreach (GridColumn col in RadGridItemsRequiringReorder.MasterTableView.Columns)
                        {
                            string colName = col.UniqueName;
                            if (colName == "PriceCatalogueID")
                            {
                                continue;
                            }
                            Control ctrl = filterItem[colName].Controls[0];

                            if (ctrl is TextBox tb)
                            {
                                string filterText = tb.Text?.Trim();
                                string cellValue = row[colName].ToString();

                                if (!string.IsNullOrEmpty(filterText))
                                {
                                    if (row.Table.Columns[colName].DataType == typeof(DateTime))
                                    {
                                        DateTime dtValue = (DateTime)row[colName];
                                        cellValue = this.objCommon.Eprint_return_Date_Before_View(Convert.ToString(dtValue), this.CompanyID, this.UserID, true);
                                    }

                                    if (!cellValue.ToLower().Contains(filterText.ToLower()))
                                    {
                                        match = false;
                                        break; // one column didn’t match → skip row
                                    }
                                }
                            }
                        }

                        if (match)
                            filteredTable.ImportRow(row);
                    }

                    RadGridItemsRequiringReorder.DataSource = filteredTable;
                    RadGridItemsRequiringReorder.DataBind();
                    e.Canceled = true; // prevent default filtering 
                }
            }
        }

        protected void RadGridProductReportCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DropDownList value = (DropDownList)e.Item.FindControl("ddlParticularCustomerName");
                TextBox textBox = (TextBox)e.Item.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtToDate");
                if (value != null)
                {
                    DateTime now = DateTime.Now;
                    DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                    DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                    DateTime dateTime2 = dateTime1.AddMonths(1);
                    dateTime[1] = dateTime2.AddDays(-1);
                    if (this.FromDate != "")
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(this.FromDate, this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        textBox.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[0].ToString(), this.CompanyID, this.UserID, false);
                    }
                    textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    if (this.ToDate != "")
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(this.ToDate, this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(dateTime[1].ToString(), this.CompanyID, this.UserID, false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                    for (int i = 0; i < productSelectClient.Columns.Count; i++)
                    {
                        productSelectClient.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in productSelectClient.Rows)
                    {
                        row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                    }
                    value.DataSource = productSelectClient;
                    value.DataTextField = "clientname";
                    value.DataValueField = "clientID";
                    value.DataBind();
                    int count = productSelectClient.Rows.Count;
                    if (this.hdnParticluarClientID.Value != "0")
                    {
                        value.SelectedValue = this.hdnParticluarClientID.Value;
                    }
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
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                GridTableView masterTableView = this.RadGridProductReport_Customer.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                TextBox textBox = (TextBox)items.FindControl("txtFromDate");
                TextBox textBox1 = (TextBox)items.FindControl("txtToDate");
                textBox.Text = this.objCommon.Eprint_return_Date_Before_View(textBox.Text, this.CompanyID, this.UserID, false);
                textBox1.Text = this.objCommon.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                this.FromDate = textBox.Text;
                this.ToDate = textBox1.Text;
                this.hdnProductFormDate.Value = textBox.Text;
                this.hdnProductToDate.Value = textBox1.Text;
                DataTable dataTable;
                if (hdnStockReleaseAdjRep2.Value != "1")
                {
                    dataTable = SettingsBasePage.ProductReport_CustomizeCustomer((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
                }
                else
                {
                    dataTable = SettingsBasePage.ProductReport_CustomizeCustomer2((long)this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(textBox.Text), Convert.ToDateTime(textBox1.Text));
                }

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
                this.RadGridProductReport_Customer.DataSource = dataTable;
            }
            catch
            {
            }
        }

        public void RadGridProductReportNew(int CompanyID)
        {
            try
            {
                if (this.hdnParticluarClientID.Value == "")
                {
                    this.hdnParticluarClientID.Value = "0";
                }
                DateTime now = DateTime.Now;
                DateTime[] dateTime = new DateTime[] { new DateTime(now.Year, now.Month, 1), default(DateTime) };
                DateTime dateTime1 = new DateTime(now.Year, now.Month, 1);
                DateTime dateTime2 = dateTime1.AddMonths(1);
                dateTime[1] = dateTime2.AddDays(-1);
                DataTable dataTable = new DataTable();
                dataTable = (this.FromDate == "" || this.ToDate == "" ? SettingsBasePage.ProductReport_CustomizeCustomer((long)CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), dateTime[0], dateTime[1]) : SettingsBasePage.ProductReport_CustomizeCustomer((long)CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), Convert.ToDateTime(this.FromDate), Convert.ToDateTime(this.ToDate)));
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
                this.RadGridProductReport_CustomerNew.DataSource = dataTable;
                this.RadGridProductReport_CustomerNew.DataBind();
            }
            catch
            {
            }
        }

        protected void RadGridReports_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGridReports.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGridReports.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void RadGridCustomerYearlyComparisonReport(int companyid)
        {
            DataTable dt = new DataTable();
            dt = SettingsBasePage.GetCustomerYearlyComparisonData(this.CompanyID, Reports.WhereCondition);

            DataColumn formattedLastEstimateDateColumn = new DataColumn("FormattedLastEstimateDate", typeof(string));
            DataColumn formattedLastInvoiceDateColumn = new DataColumn("FormattedLastInvoiceDate", typeof(string));

            dt.Columns.Add(formattedLastEstimateDateColumn);
            dt.Columns.Add(formattedLastInvoiceDateColumn);

            foreach (DataRow row in dt.Rows)
            {
                row["FormattedLastEstimateDate"] = this.objCommon.Eprint_return_Date_Before_View(row["LastEstimateDate"].ToString(), this.CompanyID, this.UserID, false);
                row["FormattedLastInvoiceDate"] = this.objCommon.Eprint_return_Date_Before_View(row["LastInvoiceDate"].ToString(), this.CompanyID, this.UserID, false);

            }

            dt.Columns.Remove("LastEstimateDate");
            dt.Columns.Remove("LastInvoiceDate");

            formattedLastEstimateDateColumn.ColumnName = "LastEstimateDate";
            formattedLastInvoiceDateColumn.ColumnName = "LastInvoiceDate";


            this.RadGridCustomerYearlyComparison.DataSource = dt;
            this.RadGridCustomerYearlyComparison.DataBind();
        }

        protected void GridCustomerYearlyComparison_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                Reports.WhereCondition = "";
                if (base.Session["SearchProd_Stock"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["SearchProd_Stock"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["SearchProd_History"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] first = new object[] { str, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(first);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { str, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                base.Session["SearchProd_Stock"] = this.dtsearch;
                Reports.WhereCondition = this.FilterFunction(this.dtsearch);
            }
        }
        public void RadGridstockUsageReport(int CompanyID)
        {
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }
            DataTable dataTable = SettingsBasePage.ProductstockUsageReport((long)CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
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
            this.RadGrid_StockUsageReport.DataSource = dataTable;
            this.RadGrid_StockUsageReport.DataBind();
        }
        public void RadGridstockUsageHistoryReport(int CompanyID)
        {
            if (this.hdnParticluarClientID.Value == "0")
            {
                this.hdnParticluarClientID.Value = "";
            }
            DataTable dataTable = SettingsBasePage.ProductstockUsageHistoryReport((long)CompanyID, Convert.ToString(this.hdnParticluarClientID.Value), Convert.ToString(this.hdnDepartmentID.Value), Convert.ToString(this.hdnMonthCategory.Value));
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
        public void RadGridstockUsageReportInPacks(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, "0", Reports.WhereCondition);
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
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs.DataSource = dataTable;
            this.RadStockUsage_Packs.DataBind();
        }

        public void RadGridstockUsageHistoryReportInPacks(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, "0", Reports.WhereCondition);
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
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs.DataSource = dataTable;
            this.RadStockUsage_Packs.DataBind();
        }

        public void RadGridstockUsageReportInPacks_cost(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.GetStockUsage_InPacks_cost(this.CompanyID, "0", Reports.WhereCondition);
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
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs.DataSource = dataTable;
            this.RadStockUsage_Packs.DataBind();
        }

        public void BindRadGridItemsWithReorderAlertsSet(int companyid, long clientId = 0, DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataSet dataSet = new DataSet();
                dataSet = SettingsBasePage.GetItemsWithReorderAlertsSet(this.CompanyID, clientId);//, "0", Reports.WhereCondition);
                DataTable dataTable = new DataTable();
                dataTable = dataSet.Tables[0];

                //foreach (DataRow row in dataTable.Rows)
                //{
                //    row["EmailSentOn"] = this.objCommon.Eprint_return_Date_Before_View(Convert.ToString(row["EmailSentOn"]), this.CompanyID, this.UserID, true);
                //}
                Session["ItemswithReorderAlertsSet"] = dataTable;
                this.RadGridItemswithReorderAlertsSet.DataSource = dataTable;
                this.RadGridItemswithReorderAlertsSet.DataBind();
            }
            else
            {
                this.RadGridItemswithReorderAlertsSet.DataSource = dataSource;
                //this.RadGridItemswithReorderAlertsSet.DataBind();
            }

        }

        public void BindRadGridItemsRequiringReorder(int companyid, long clientId = 0, System.Data.DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataSet dataSet = new DataSet();
                dataSet = SettingsBasePage.GetItemsRequiringReorder(this.CompanyID, clientId);//, "0", Reports.WhereCondition);
                DataTable dataTable = new DataTable();
                dataTable = dataSet.Tables[0];
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    row["EmailSentOn"] = this.objCommon.Eprint_return_Date_Before_View(Convert.ToString(row["EmailSentOn"]), this.CompanyID, this.UserID, true);
                //}
                Session["ItemsRequiringReorder"] = dataTable;
                this.RadGridItemsRequiringReorder.DataSource = dataTable;
                this.RadGridItemsRequiringReorder.DataBind();
            }
            else
            {
                this.RadGridItemsRequiringReorder.DataSource = dataSource;
            }

        }


        public void RadGridstockUsageHistoryReportInPacks_costRadGridstockUsageHistoryReportInPacks_cost(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.GetStockUsage_InPacks_cost(this.CompanyID, "0", Reports.WhereCondition);
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
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs.DataSource = dataTable;
            this.RadStockUsage_Packs.DataBind();
        }

        public void RadGridstockUsageReportInPacks_MyProj(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, "0", Reports.WhereCondition);
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                if (!row.Table.Columns.Contains("TotalExCCost") || row["TotalExCCost"] == null)
                {
                    continue;
                }
                this.hdnTotalcost.Value = row["TotalExCCost"].ToString();
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs_MyProj.DataSource = dataTable;
            this.RadStockUsage_Packs_MyProj.DataBind();
        }

        public void RadGridstockUsageHistoryReportInPacks_MyProj(int companyid)
        {
            DataSet dataSet = new DataSet();
            dataSet = SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, "0", Reports.WhereCondition);
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                if (!row.Table.Columns.Contains("TotalExCCost") || row["TotalExCCost"] == null)
                {
                    continue;
                }
                this.hdnTotalcost.Value = row["TotalExCCost"].ToString();
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs_MyProj.DataSource = dataTable;
            this.RadStockUsage_Packs_MyProj.DataBind();
        }

        protected void RadStockUsage_Packs_MyProj_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            RadComboBox radComboBox = (RadComboBox)e.Item.FindControl("Customerlist");
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["QuantityOnHand"].HorizontalAlign = HorizontalAlign.Right;
            }
            if (radComboBox != null)
            {
                radComboBox.Items.Add(new RadComboBoxItem("-- Customer Name -- "));
                CheckBoxList checkBoxList = (CheckBoxList)radComboBox.Items[0].FindControl("chkclientname");
                CheckBoxList checkBoxList1 = new CheckBoxList();
                ListItem listItem = new ListItem();
                DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                for (int i = 0; i < productSelectClient.Columns.Count; i++)
                {
                    productSelectClient.Columns[i].ReadOnly = false;
                }
                int num = 0;
                foreach (DataRow row in productSelectClient.Rows)
                {
                    listItem = new ListItem(this.objBase.SpecialDecode(row["clientname"].ToString()), this.objBase.SpecialDecode(row["clientID"].ToString()));
                    AttributeCollection attributes = listItem.Attributes;
                    object[] objArray = new object[] { "javascript:getSelectedItem(this.id,", num, ",", this.objBase.SpecialDecode(row["clientID"].ToString()), ")" };
                    attributes.Add("onclick", string.Concat(objArray));
                    checkBoxList.Items.Add(listItem);
                    num++;
                }
                if (this.hdnOrderClientID.Value != "")
                {
                    int num1 = 0;
                    string str = this.hdnOrderClientID.Value.ToString();
                    string[] strArrays = str.Split(new char[] { ',' });
                    foreach (RadComboBoxItem item in radComboBox.Items)
                    {
                        foreach (ListItem item1 in ((CheckBoxList)item.FindControl("chkclientname")).Items)
                        {
                            for (int j = 0; j < (int)strArrays.Length; j++)
                            {
                                if (item1.Value == strArrays[j].ToString())
                                {
                                    item1.Selected = true;
                                    num1++;
                                }
                            }
                        }
                    }
                    radComboBox.EmptyMessage = string.Concat(num1, " Customer selected");
                }
            }
        }

        protected void RadStockUsage_Packs_MyProj_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = new DataSet();
            if (this.hdnOrderClientID.Value == "")
            {
                this.hdnOrderClientID.Value = "0";
            }
            dataSet = (this.hdnOrderClientID.Value != "0" ? SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Reports.WhereCondition) : SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, "0", Reports.WhereCondition));
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                if (!row.Table.Columns.Contains("TotalExCCost") || row["TotalExCCost"] == null)
                {
                    continue;
                }
                this.hdnTotalcost.Value = row["TotalExCCost"].ToString();
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs_MyProj.DataSource = dataTable;
        }

        protected void RadStockUsage_Packs_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            RadComboBox radComboBox = (RadComboBox)e.Item.FindControl("Customerlist");
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
            if (radComboBox != null)
            {
                radComboBox.Items.Add(new RadComboBoxItem("-- Customer Name -- "));
                CheckBoxList checkBoxList = (CheckBoxList)radComboBox.Items[0].FindControl("chkclientname");
                CheckBoxList checkBoxList1 = new CheckBoxList();
                ListItem listItem = new ListItem();
                DataTable productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                for (int i = 0; i < productSelectClient.Columns.Count; i++)
                {
                    productSelectClient.Columns[i].ReadOnly = false;
                }
                int num = 0;
                foreach (DataRow row in productSelectClient.Rows)
                {
                    listItem = new ListItem(this.objBase.SpecialDecode(row["clientname"].ToString()), this.objBase.SpecialDecode(row["clientID"].ToString()));
                    AttributeCollection attributes = listItem.Attributes;
                    object[] objArray = new object[] { "javascript:getSelectedItem(this.id,", num, ",", this.objBase.SpecialDecode(row["clientID"].ToString()), ")" };
                    attributes.Add("onclick", string.Concat(objArray));
                    checkBoxList.Items.Add(listItem);
                    num++;
                }
                if (this.hdnOrderClientID.Value != "")
                {
                    int num1 = 0;
                    string str1 = this.hdnOrderClientID.Value.ToString();
                    string[] strArrays = str1.Split(new char[] { ',' });
                    foreach (RadComboBoxItem radComboBoxItem in radComboBox.Items)
                    {
                        foreach (ListItem item1 in ((CheckBoxList)radComboBoxItem.FindControl("chkclientname")).Items)
                        {
                            for (int j = 0; j < (int)strArrays.Length; j++)
                            {
                                if (item1.Value == strArrays[j].ToString())
                                {
                                    item1.Selected = true;
                                    num1++;
                                }
                            }
                        }
                    }
                    radComboBox.EmptyMessage = string.Concat(num1, " Customer selected");
                }
            }
        }

        protected void RadStockUsage_Packs_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = new DataSet();
            if (this.hdnOrderClientID.Value == "")
            {
                this.hdnOrderClientID.Value = "0";
            }
            dataSet = (this.hdnOrderClientID.Value != "0" ? SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, Convert.ToString(this.hdnOrderClientID.Value), Reports.WhereCondition) : SettingsBasePage.GetStockUsage_InPacks(this.CompanyID, "0", Reports.WhereCondition));
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
                string str = Convert.ToString(this.objCommon.GetCurrencyinRequiredFormate(this.objCommon.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalExCCost"]), 0, "", false, false, true, false, true), true));
                this.hdnTotalcost.Value = str;
            }
            this.RadStockUsage_Packs.DataSource = dataTable;
        }
        protected void RadGridCustomerYearlyComparison_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (this.hdnOrderClientID.Value == "")
            {
                this.hdnOrderClientID.Value = "0";
            }
            dataTable = SettingsBasePage.GetCustomerYearlyComparisonData(this.CompanyID, Reports.WhereCondition);
            this.RadGridCustomerYearlyComparison.DataSource = dataTable;
        }

        public event DeleteReportEventHandler OnDeleteClick;

        public event EditReportEventHandler OnEditClick;

        public event LinkClientRunReportEventHandler onLinkClientreport;

        public event LinkProductRunReportEventHandler onLinkProductRunReport;

        public event LinkRunReportEventHandler onLinkRunClick;

        public event OnPageIndexChangedClick OnPageIndexChanged;

        public event OnPageSizeChangedClick OnPageSizeChanged;

        public event SavingReportEventHandler OnReportClick;

        protected void RadGrid_CustomerJobReport_PreRender(object sender, EventArgs e)
        {
            GridHeaderItem header = (GridHeaderItem)RadGrid_CustomerJobReport.MasterTableView.GetItems(GridItemType.Header)[0];
            header["ItemQty"].Wrap = false;
            header["ItemQty"].Width = Unit.Pixel(20);
        }

        #region AllEstimatesbyCustomer
        protected void RadGridAllEstimatesbyCustomer_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //try
            //{
            //    if (Session["AllEstimatesbyCustomer"] != null)
            //    {
            //        BindRadGridAllEstimatesbyCustomer(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), "", (DataTable)Session["AllEstimatesbyCustomer"]);
            //    }
            //}
            //catch
            //{
            //}
        }
        protected void RadGridAllEstimatesbyCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            BindDateCalendar(e);
            BindReportCustomerTypeDropDown(e);
            BindCustomersDropDown(e);
            BindReportPeriodDropDown(e, "AllEstimatesbyCustomer");
        }
        protected void RadGridAllEstimatesbyCustomer_ItemCommand(object sender, GridCommandEventArgs e)
        {
            e.Canceled = true;
        }
        protected void RadGridAllEstimatesbyCustomer_GO_OnClick(object sender, EventArgs e)
        {
            GridCommandItem commandItem = (GridCommandItem)RadGridAllEstimatesbyCustomer.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            string selectedPeriod;
            long clientId;
            long clientTypeId;
            SetClearFilterFlag();
            GoSearchButtonClick(commandItem, out selectedPeriod, "AllEstimatesbyCustomer", out clientId, out clientTypeId);
            BindRadGridAllEstimatesbyCustomer(this.CompanyID, clientId, clientTypeId, selectedPeriod);
        }
        public void BindRadGridAllEstimatesbyCustomer(int companyid, long clientId = 0, long clientTypeId = 0, string selectedDuration = "", System.Data.DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataTable dataTable = GetAllEstimatesbyCustomerData(clientId, clientTypeId, selectedDuration);

                Session["AllEstimatesbyCustomer"] = dataTable;

                this.RadGridAllEstimatesbyCustomer.DataSource = dataTable;
                this.RadGridAllEstimatesbyCustomer.DataBind();
            }
            else
            {
                this.RadGridAllEstimatesbyCustomer.DataSource = dataSource;
            }
        }

        private DataTable GetAllEstimatesbyCustomerData(long clientId, long clientTypeId, string selectedDuration)
        {
            ePrintReportQueries ePrintReportQueries = new ePrintReportQueries();

            StringBuilder stringBuilder1 = new StringBuilder();
            SqlCommand sqlCommandParam = new SqlCommand();

            DurationFilters durationFilters = new DurationFilters(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate);
            durationFilters.AppendDurationFiltersToQuery(selectedDuration, stringBuilder1, sqlCommandParam);
            if (clientId > 0)
            {
                ePrintReportQueries.AllEstimatesByCustomerWhere += " and a.CustomerID = " + clientId.ToString() + " ";//" and c.clientID=" + clientId.ToString() + " ";
            }
            if (clientTypeId > 0)
            {
                ePrintReportQueries.AllEstimatesByCustomerWhere += " and clnt.ClientTypeID like '%" + clientTypeId.ToString() + "%' ";
            }
            ePrintReportQueries.AllEstimatesByCustomerWhere += stringBuilder1.ToString();
            // Setup where condition
            System.Text.StringBuilder estimateQueryBuilder = ePrintReportQueries.GetAllEstimatesByCustomerSelectQuery();

            SqlConnection connection = new SqlConnection(this.objCommon.strConnection);
            sqlCommandParam.Connection = connection;
            sqlCommandParam.CommandType = System.Data.CommandType.Text;
            sqlCommandParam.CommandText = estimateQueryBuilder.ToString();
            sqlCommandParam.Parameters.AddWithValue("@companyid", this.CompanyID);
            sqlCommandParam.CommandTimeout = 1000;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommandParam);//SettingsBasePage.GetAllEstimateItemsByCustomers(estimateQueryBuilder.ToString(), this.CompanyID, clientId);//, "0", Reports.WhereCondition);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        #endregion

        #region AllOrdersbyCustomer
        protected void RadGridAllOrdersbyCustomer_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //try
            //{
            //    if (Session["AllOrdersbyCustomer"] != null)
            //    {
            //        BindRadGridAllOrdersbyCustomer(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), "", (DataTable)Session["AllEstimatesbyCustomer"]);
            //    }
            //}
            //catch
            //{
            //}
        }
        protected void RadGridAllOrdersbyCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            BindDateCalendar(e);
            BindReportCustomerTypeDropDown(e);
            BindCustomersDropDown(e);
            BindReportPeriodDropDown(e, "AllOrdersbyCustomer");
        }
        protected void RadGridAllOrdersbyCustomer_ItemCommand(object sender, GridCommandEventArgs e)
        {
            e.Canceled = true;
        }
        protected void RadGridAllOrdersbyCustomer_GO_OnClick(object sender, EventArgs e)
        {
            GridCommandItem commandItem = (GridCommandItem)RadGridAllOrdersbyCustomer.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            string selectedPeriod;
            long clientId;
            long clientTypeId;
            SetClearFilterFlag();
            GoSearchButtonClick(commandItem, out selectedPeriod, "AllOrdersbyCustomer", out clientId, out clientTypeId);
            BindRadGridAllOrdersbyCustomer(this.CompanyID, clientId, clientTypeId, selectedPeriod);
        }
        public void BindRadGridAllOrdersbyCustomer(int companyid, long clientId = 0, long clientTypeId = 0, string selectedDuration = "", System.Data.DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataTable dataTable = GetAllOrdersbyCustomerData(clientId, clientTypeId, selectedDuration);

                Session["AllOrdersbyCustomer"] = dataTable;

                this.RadGridAllOrdersbyCustomer.DataSource = dataTable;
                this.RadGridAllOrdersbyCustomer.DataBind();
            }
            else
            {
                this.RadGridAllOrdersbyCustomer.DataSource = dataSource;
            }
        }

        private DataTable GetAllOrdersbyCustomerData(long clientId, long clientTypeId, string selectedDuration)
        {
            ePrintReportQueries ePrintReportQueries = new ePrintReportQueries();

            StringBuilder stringBuilder1 = new StringBuilder();
            SqlCommand sqlCommandParam = new SqlCommand();

            DurationFilters durationFilters = new DurationFilters(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate);
            durationFilters.AppendDurationFiltersToQuery(selectedDuration, stringBuilder1, sqlCommandParam);
            if (clientId > 0)
            {
                ePrintReportQueries.AllOrdersByCustomerWhere += " and c.clientID=" + clientId.ToString() + " ";
            }
            if (clientTypeId > 0)
            {
                ePrintReportQueries.AllOrdersByCustomerWhere += " and c.ClientTypeID like '%" + clientTypeId.ToString() + "%' ";
            }
            ePrintReportQueries.AllOrdersByCustomerWhere += stringBuilder1.ToString();
            // Setup where condition
            System.Text.StringBuilder estimateQueryBuilder = ePrintReportQueries.GetAllOrdersByCustomerSelectQuery();

            SqlConnection connection = new SqlConnection(this.objCommon.strConnection);
            sqlCommandParam.Connection = connection;
            sqlCommandParam.CommandType = System.Data.CommandType.Text;
            sqlCommandParam.CommandText = estimateQueryBuilder.ToString();
            sqlCommandParam.Parameters.AddWithValue("@companyid", this.CompanyID);
            sqlCommandParam.CommandTimeout = 1000;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommandParam);//SettingsBasePage.GetAllEstimateItemsByCustomers(estimateQueryBuilder.ToString(), this.CompanyID, clientId);//, "0", Reports.WhereCondition);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        #endregion

        #region AllJobsbyCustomer
        protected void RadGridAllJobsbyCustomer_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //try
            //{
            //    if (Session["AllJobsbyCustomer"] != null)
            //    {
            //        BindRadGridAllJobsbyCustomer(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), "", (DataTable)Session["AllEstimatesbyCustomer"]);
            //    }
            //}
            //catch
            //{
            //}
        }
        protected void RadGridAllJobsbyCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            BindDateCalendar(e);
            BindReportCustomerTypeDropDown(e);
            BindCustomersDropDown(e);
            BindReportPeriodDropDown(e, "AllJobsbyCustomer");
        }
        protected void RadGridAllJobsbyCustomer_ItemCommand(object sender, GridCommandEventArgs e)
        {
            e.Canceled = true;
        }
        protected void RadGridAllJobsbyCustomer_GO_OnClick(object sender, EventArgs e)
        {
            GridCommandItem commandItem = (GridCommandItem)RadGridAllJobsbyCustomer.MasterTableView.GetItems(GridItemType.CommandItem)[0];

            string selectedPeriod;
            long clientId;
            long clientTypeId;
            SetClearFilterFlag();
            GoSearchButtonClick(commandItem, out selectedPeriod, "AllJobsbyCustomer", out clientId, out clientTypeId);
            BindRadGridAllJobsbyCustomer(this.CompanyID, clientId, clientTypeId, selectedPeriod);
        }
        public void BindRadGridAllJobsbyCustomer(int companyid, long clientId = 0, long clientTypeId = 0, string selectedDuration = "", System.Data.DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataTable dataTable = GetAllJobByCustomerData(clientId, clientTypeId, selectedDuration);

                Session["AllJobsbyCustomer"] = dataTable;

                this.RadGridAllJobsbyCustomer.DataSource = dataTable;
                this.RadGridAllJobsbyCustomer.DataBind();
            }
            else
            {
                this.RadGridAllJobsbyCustomer.DataSource = dataSource;
            }

        }

        private DataTable GetAllJobByCustomerData(long clientId, long clientTypeId, string selectedDuration)
        {
            ePrintReportQueries ePrintReportQueries = new ePrintReportQueries();

            StringBuilder stringBuilder1 = new StringBuilder();
            SqlCommand sqlCommandParam = new SqlCommand();

            DurationFilters durationFilters = new DurationFilters(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate);
            durationFilters.AppendDurationFiltersToQuery(selectedDuration, stringBuilder1, sqlCommandParam);
            if (clientId > 0)
            {
                ePrintReportQueries.AllJobsByCustomerWhere += " and d.clientID=" + clientId.ToString() + " ";
            }
            if (clientTypeId > 0)
            {
                ePrintReportQueries.AllJobsByCustomerWhere += " and d.ClientTypeID like '%" + clientTypeId.ToString() + "%' ";
            }

            ePrintReportQueries.AllJobsByCustomerWhere += stringBuilder1.ToString();
            // Setup where condition
            System.Text.StringBuilder estimateQueryBuilder = ePrintReportQueries.GetAllJobsByCustomerSelectQuery();

            SqlConnection connection = new SqlConnection(this.objCommon.strConnection);
            sqlCommandParam.Connection = connection;
            sqlCommandParam.CommandType = System.Data.CommandType.Text;
            sqlCommandParam.CommandText = estimateQueryBuilder.ToString();
            sqlCommandParam.Parameters.AddWithValue("@companyid", this.CompanyID);
            sqlCommandParam.CommandTimeout = 1000;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommandParam);//SettingsBasePage.GetAllEstimateItemsByCustomers(estimateQueryBuilder.ToString(), this.CompanyID, clientId);//, "0", Reports.WhereCondition);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        #endregion

        #region AllInvoicesByCustomer
        protected void RadGridAllInvoicesbyCustomer_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //try
            //{
            //    if (Session["AllInvoicesbyCustomer"] != null)
            //    {
            //        BindRadGridAllInvoicesbyCustomer(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), "", (DataTable)Session["AllEstimatesbyCustomer"]);
            //    }
            //}
            //catch
            //{
            //}
        }
        protected void RadGridAllInvoicesbyCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            BindDateCalendar(e);
            BindReportCustomerTypeDropDown(e);
            BindCustomersDropDown(e);
            BindReportPeriodDropDown(e, "AllInvoicesbyCustomer");
        }
        protected void RadGridAllInvoicesbyCustomer_ItemCommand(object sender, GridCommandEventArgs e)
        {
            e.Canceled = true;
        }
        protected void RadGridAllInvoicesbyCustomer_GO_OnClick(object sender, EventArgs e)
        {
            GridCommandItem commandItem = (GridCommandItem)RadGridAllInvoicesbyCustomer.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            string selectedPeriod;
            long clientId;
            long clientTypeId;
            SetClearFilterFlag();
            GoSearchButtonClick(commandItem, out selectedPeriod, "AllInvoicesbyCustomer", out clientId, out clientTypeId);
            BindRadGridAllInvoicesbyCustomer(this.CompanyID, clientId, clientTypeId, selectedPeriod);
        }
        public void BindRadGridAllInvoicesbyCustomer(int companyid, long clientId = 0, long clientTypeId = 0, string selectedDuration = "", System.Data.DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataTable dataTable = GetAllInvoicesbyCustomerData(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate, selectedDuration, clientId, clientTypeId);

                Session["AllInvoicesbyCustomer"] = dataTable;

                this.RadGridAllInvoicesbyCustomer.DataSource = dataTable;
                this.RadGridAllInvoicesbyCustomer.DataBind();
            }
            else
            {
                this.RadGridAllInvoicesbyCustomer.DataSource = dataSource;
            }

        }
        private DataTable GetAllInvoicesbyCustomerData(int companyId, int userId, string dateFormat, string fromDate, string toDate, string selectedDuration, long clientId, long clientTypeId)
        {
            ePrintReportQueries ePrintReportQueries = new ePrintReportQueries();
            StringBuilder queryBuilder = new StringBuilder();
            SqlCommand sqlCommandParam = new SqlCommand();

            // Apply duration filters
            DurationFilters durationFilters = new DurationFilters(companyId, userId, dateFormat, fromDate, toDate);
            durationFilters.AppendDurationFiltersToQuery(selectedDuration, queryBuilder, sqlCommandParam);

            // Add client condition if applicable
            if (clientId > 0)
            {
                ePrintReportQueries.AllInvoicesByCustomersWhere += " AND a.clientID = " + clientId.ToString() + " ";
            }
            if (clientTypeId > 0)
            {
                ePrintReportQueries.AllInvoicesByCustomersWhere += " AND clnt.ClientTypeID like '%" + clientTypeId.ToString() + "%' ";
            }

            // Append duration filters
            ePrintReportQueries.AllInvoicesByCustomersWhere += queryBuilder.ToString();

            // Build final query
            StringBuilder finalQuery = ePrintReportQueries.GetAllInvoicesByCustomersSelectQuery();

            // Prepare SQL command
            sqlCommandParam.CommandText = finalQuery.ToString();
            sqlCommandParam.CommandType = CommandType.Text;
            sqlCommandParam.Parameters.AddWithValue("@companyid", companyId);
            sqlCommandParam.CommandTimeout = 1000;

            // Execute and fill DataTable
            using (SqlConnection connection = new SqlConnection(this.objCommon.strConnection))
            {
                sqlCommandParam.Connection = connection;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandParam))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
            }
        }

        #endregion

        #region AllInvoicesbyAccountingCode
        protected void RadGridAllInvoicesbyAccountingCode_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //try
            //{
            //    if (Session["AllInvoicesbyAccountingCode"] != null)
            //    {
            //        BindRadGridAllOrdersbyCustomer(this.CompanyID, Convert.ToInt64(this.hdnParticluarClientID.Value), "", (DataTable)Session["AllEstimatesbyCustomer"]);
            //    }
            //}
            //catch
            //{
            //}
        }
        protected void RadGridAllInvoicesbyAccountingCode_ItemDataBound(object sender, GridItemEventArgs e)
        {
            BindDateCalendar(e);
            BindReportCustomerTypeDropDown(e);
            BindCustomersDropDown(e);
            BindReportPeriodDropDown(e, "AllInvoicesbyAccountingCode");
        }
        protected void RadGridAllInvoicesbyAccountingCode_ItemCommand(object sender, GridCommandEventArgs e)
        {
            e.Canceled = true;
        }
        protected void RadGridAllInvoicesbyAccountingCode_GO_OnClick(object sender, EventArgs e)
        {
            GridCommandItem commandItem = (GridCommandItem)RadGridAllInvoicesbyAccountingCode.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            string selectedPeriod;
            long clientId;
            long clientTypeId;
            SetClearFilterFlag();
            GoSearchButtonClick(commandItem, out selectedPeriod, "AllInvoicesbyAccountingCode", out clientId, out clientTypeId);
            BindRadGridAllInvoicesByItemCode(this.CompanyID, clientId, clientTypeId, selectedPeriod);
        }
        public void BindRadGridAllInvoicesByItemCode(int companyid, long clientId = 0, long clientTypeId = 0, string selectedDuration = "", System.Data.DataTable dataSource = null)
        {
            if (dataSource == null)
            {
                DataTable dataTable = GetAllInvoicesByItemCodeData(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate, selectedDuration, clientId, clientTypeId);

                Session["AllInvoicesbyAccountingCode"] = dataTable;

                this.RadGridAllInvoicesbyAccountingCode.DataSource = dataTable;
                this.RadGridAllInvoicesbyAccountingCode.DataBind();
            }
            else
            {
                this.RadGridAllInvoicesbyAccountingCode.DataSource = dataSource;
            }

        }

        private DataTable GetAllInvoicesByItemCodeData(int companyId, int userId, string dateFormat, string fromDate, string toDate, string selectedDuration, long clientId, long clientTypeId)
        {
            ePrintReportQueries ePrintReportQueries = new ePrintReportQueries();

            StringBuilder stringBuilder1 = new StringBuilder();
            SqlCommand sqlCommandParam = new SqlCommand();

            DurationFilters durationFilters = new DurationFilters(this.CompanyID, this.UserID, this.DateFormat, this.FromDate, this.ToDate);
            durationFilters.AppendDurationFiltersToQuery(selectedDuration, stringBuilder1, sqlCommandParam);
            if (clientId > 0)
            {
                ePrintReportQueries.AllInvoicesByAccountingCodeWhere += " and a.clientID=" + clientId.ToString() + " ";
            }
            if (clientTypeId > 0)
            {
                ePrintReportQueries.AllInvoicesByAccountingCodeWhere += " and clnt.ClientTypeID like '%" + clientTypeId.ToString() + "%' ";
            }

            ePrintReportQueries.AllInvoicesByAccountingCodeWhere += stringBuilder1.ToString();
            // Setup where condition
            System.Text.StringBuilder estimateQueryBuilder = ePrintReportQueries.GetAllInvoicesByAccountingCodeSelectQuery();

            SqlConnection connection = new SqlConnection(this.objCommon.strConnection);
            sqlCommandParam.Connection = connection;
            sqlCommandParam.CommandType = System.Data.CommandType.Text;
            sqlCommandParam.CommandText = estimateQueryBuilder.ToString();
            sqlCommandParam.Parameters.AddWithValue("@companyid", this.CompanyID);
            sqlCommandParam.CommandTimeout = 1000;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommandParam);//SettingsBasePage.GetAllEstimateItemsByCustomers(estimateQueryBuilder.ToString(), this.CompanyID, clientId);//, "0", Reports.WhereCondition);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        #endregion

        #region Common Methods For Grids
        private void GoSearchButtonClick(GridCommandItem commandItem, out string selectedPeriod, string prefix, out long clientId, out long clientTypeId)
        {

            // Find the dropdowns inside the CommandItemTemplate
            DropDownList ddlCustomer = (DropDownList)commandItem.FindControl("ddlParticularCustomerName");
            DropDownList ddlPeriod = (DropDownList)commandItem.FindControl("ddlReportPeriod");
            DropDownList ddlCustomerType = (DropDownList)commandItem.FindControl("ddlCustomerType");

            if (ddlCustomer != null)
            {
                string selectedCustomer = ddlCustomer.SelectedValue;
                if (!string.IsNullOrEmpty(selectedCustomer))
                {
                    this.hdnParticluarClientID.Value = selectedCustomer;
                }

            }
            selectedPeriod = "";
            if (ddlPeriod != null)
            {
                selectedPeriod = ddlPeriod.SelectedValue;
                this.hdnDurationFilter.Value = selectedPeriod;

                HtmlTable tblDateRanges = (HtmlTable)commandItem.FindControl("tbl_" + prefix + "_DateRanges");

                if (ddlPeriod.SelectedValue == "daterange")
                {
                    TextBox textBox = (TextBox)commandItem.FindControl("txtFromDate");
                    TextBox textBox1 = (TextBox)commandItem.FindControl("txtToDate");

                    this.FromDate = textBox.Text;
                    this.ToDate = textBox1.Text;
                    this.hdnFromDate.Value = textBox.Text;
                    this.hdnToDate.Value = textBox1.Text;
                    if (tblDateRanges != null)
                    {
                        tblDateRanges.Style["display"] = "block";
                    }
                }
                else
                {
                    if (tblDateRanges != null)
                    {
                        tblDateRanges.Style["display"] = "none";
                    }
                }
            }
            if (ddlCustomerType != null && !string.IsNullOrEmpty(ddlCustomerType.SelectedValue))
            {
                this.hdnCustomerTypeFilter.Value = ddlCustomerType.SelectedValue;
            }

            clientTypeId = string.IsNullOrEmpty(this.hdnCustomerTypeFilter.Value) ? 0 : Convert.ToInt64(this.hdnCustomerTypeFilter.Value);
            clientId = string.IsNullOrEmpty(this.hdnParticluarClientID.Value) ? 0 : Convert.ToInt64(this.hdnParticluarClientID.Value);
        }
        private void HideAllGridControls()
        {
            this.RadGridReports.Visible = false;
            this.GridReports.Visible = false;
            this.GridProductReport.Visible = false;
            this.GridClientReport.Visible = false;
            this.RadGridProductReport_Customer.Visible = false;
            this.RadGrid_CustomerJobReport.Visible = false;
            this.RadGrid_Order_Report.Visible = false;
            this.RadGrid_StockUsageReport.Visible = false;
            this.RadGrid_StockUsageHistoryReport.Visible = false;
            this.RadGridProductReport_CustomerNew.Visible = false;
            this.RadGridItemswithReorderAlertsSet.Visible = false;
            this.RadGridItemsRequiringReorder.Visible = false;
            this.RadGridCustomerYearlyComparison.Visible = false;
            this.RadStockUsage_Packs.Visible = false;
            this.RadStockUsage_Packs_MyProj.Visible = false;

            this.RadGridAllEstimatesbyCustomer.Visible = false;
            this.RadGridAllJobsbyCustomer.Visible = false;
            this.RadGridAllOrdersbyCustomer.Visible = false;
            this.RadGridAllInvoicesbyCustomer.Visible = false;
            this.RadGridAllInvoicesbyAccountingCode.Visible = false;

        }

        private void ResetGridHeaderControls(object sender)
        {
            LinkButton lnkButton = (LinkButton)sender;
            if (lnkButton != null)
            {
                GridCommandItem commandItem = lnkButton.NamingContainer as GridCommandItem;
                DropDownList ddlCustomer = (DropDownList)commandItem.FindControl("ddlParticularCustomerName");
                DropDownList ddlCustomerType = (DropDownList)commandItem.FindControl("ddlCustomerType");
                DropDownList ddlPeriods = (DropDownList)commandItem.FindControl("ddlReportPeriod");
                if (ddlCustomer != null)
                {
                    ddlCustomer.SelectedValue = "";
                }
                if (ddlCustomerType != null)
                {
                    ddlCustomerType.SelectedValue = "";
                }
                if (ddlPeriods != null)
                {
                    ddlPeriods.SelectedValue = "";
                }
            }

            //Reset hidden fields
            this.hdnParticluarClientID.Value = "0";
            this.hdnDurationFilter.Value = "0";
            this.hdnCustomerTypeFilter.Value = "0";
            this.hdnClearFilters.Value = "0";

        }
        #endregion

        #region Drop Down Filter Methods
        private void BindReportPeriodDropDown(GridItemEventArgs e, string gridPreFix)
        {
            DropDownList ddlPeriods = (DropDownList)e.Item.FindControl("ddlReportPeriod");
            if (ddlPeriods != null)
            {
                List<KeyValues> lstKeyValues = ePrintUtilities.Utilities.GetReportDurtionsList();

                ddlPeriods.DataSource = lstKeyValues;
                ddlPeriods.DataTextField = "text";
                ddlPeriods.DataValueField = "value";
                ddlPeriods.DataBind();
                ddlPeriods.Items.Insert(0, new ListItem(ePrintConstants.SelectDefaultOptionForDropDown, ""));
                if (this.hdnClearFilters.Value != "1")
                {
                    var selectedItem = lstKeyValues.Where(a => a.isSelected == true).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        ddlPeriods.SelectedValue = selectedItem.value;
                    }
                }
                //if (!string.IsNullOrEmpty(this.hdnDurationFilter.Value) && this.hdnDurationFilter.Value != "0")
                if (this.hdnDurationFilter.Value != "0")
                {
                    ddlPeriods.SelectedValue = this.hdnDurationFilter.Value;
                }

                if (ddlPeriods.SelectedValue == "daterange")
                {
                    HtmlTable tblDateRanges = (HtmlTable)e.Item.FindControl("tbl_" + gridPreFix + "_DateRanges");
                    if (tblDateRanges != null)
                    {
                        //Set date controls values
                        TextBox txtFromDate = (TextBox)e.Item.FindControl("txtFromDate");
                        if (txtFromDate != null)
                        {
                            if (!string.IsNullOrEmpty(this.hdnFromDate.Value) && this.hdnFromDate.Value != "0")
                            {
                                txtFromDate.Text = this.hdnFromDate.Value;
                            }
                        }
                        TextBox txtToDate = (TextBox)e.Item.FindControl("txtToDate");
                        if (txtToDate != null)
                        {
                            if (!string.IsNullOrEmpty(this.hdnToDate.Value) && this.hdnToDate.Value != "0")
                            {
                                txtToDate.Text = this.hdnToDate.Value;
                            }
                        }

                        tblDateRanges.Style["display"] = "block";
                    }
                    else
                    {
                        tblDateRanges.Style["display"] = "none";
                    }
                }

            }
        }
        private void BindReportCustomerTypeDropDown(GridItemEventArgs e)
        {
            DropDownList ddlCustomerType = (DropDownList)e.Item.FindControl("ddlCustomerType");
            if (ddlCustomerType != null)
            {
                DataTable dataTable = SettingsBasePage.settings_CompanyType_select(this.CompanyID);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //       dataRow["companytype"] = this.objBase.SpecialDecode(dataRow["companytype"].ToString());
                }
                ddlCustomerType.DataSource = dataTable;
                ddlCustomerType.DataTextField = "companytype";
                ddlCustomerType.DataValueField = "id";
                ddlCustomerType.DataBind();

                ddlCustomerType.Items.Insert(0, new ListItem(ePrintConstants.SelectDefaultOptionForDropDown, ""));

                if (!string.IsNullOrEmpty(this.hdnCustomerTypeFilter.Value) && this.hdnCustomerTypeFilter.Value != "0")
                {
                    ddlCustomerType.SelectedValue = this.hdnCustomerTypeFilter.Value;
                }
            }
        }
        private void BindCustomersDropDown(GridItemEventArgs e, object sender = null)
        {
            DropDownList ddlCustomerType = null;
            DropDownList ddlCustomer = null;
            if (sender != null)
            {
                ddlCustomerType = (DropDownList)sender;
                GridCommandItem commandItem = ddlCustomerType.NamingContainer as GridCommandItem;
                if (commandItem != null)
                {
                    ddlCustomer = (DropDownList)commandItem.FindControl("ddlParticularCustomerName");
                }
            }
            else
            {
                ddlCustomer = (DropDownList)e.Item.FindControl("ddlParticularCustomerName");
                ddlCustomerType = (DropDownList)e.Item.FindControl("ddlCustomerType");
            }
            if (ddlCustomer != null)
            {
                DataTable productSelectClient = new DataTable();

                if (ddlCustomerType != null && ddlCustomerType.SelectedValue != "")
                {
                    productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID, Convert.ToInt32(ddlCustomerType.SelectedValue));
                }
                else
                {
                    productSelectClient = SettingsBasePage.GetProduct_SelectClient(this.CompanyID);
                }

                for (int i = 0; i < productSelectClient.Columns.Count; i++)
                {
                    productSelectClient.Columns[i].ReadOnly = false;
                }
                foreach (DataRow row in productSelectClient.Rows)
                {
                    row["clientname"] = this.objBase.SpecialDecode(row["clientname"].ToString());
                }
                ddlCustomer.DataSource = productSelectClient;
                ddlCustomer.DataTextField = "clientname";
                ddlCustomer.DataValueField = "clientID";
                ddlCustomer.DataBind();
                ddlCustomer.Items.Insert(0, new ListItem(ePrintConstants.SelectDefaultOptionForDropDown, ""));
                int count = productSelectClient.Rows.Count;
                if (!string.IsNullOrEmpty(this.hdnParticluarClientID.Value) && this.hdnParticluarClientID.Value != "0")
                {
                    ddlCustomer.SelectedValue = this.hdnParticluarClientID.Value;
                }
                if (!string.IsNullOrEmpty(this.hdnCustomerTypeFilter.Value) && this.hdnCustomerTypeFilter.Value != "0")
                {
                    ddlCustomerType.SelectedValue = this.hdnCustomerTypeFilter.Value;
                }
            }
        }
        private void DisplayDateControls(GridItemEventArgs e, object sender = null)
        {
            DropDownList ddlDuration = null;
            if (sender != null)
            {
                ddlDuration = (DropDownList)sender;
                if (ddlDuration.SelectedValue == "daterange")
                {
                    GridCommandItem commandItem = ddlDuration.NamingContainer as GridCommandItem;
                    if (ddlDuration != null && ddlDuration.SelectedValue != "")
                    {
                        if (commandItem != null)
                        {
                            TextBox txtFromDate = (TextBox)commandItem.FindControl("txtFromDate");
                            if (txtFromDate != null)
                            {
                                txtFromDate.Visible = true;
                            }
                            TextBox txtToDate = (TextBox)commandItem.FindControl("txtToDate");
                            if (txtToDate != null)
                            {
                                txtToDate.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        private void BindDateCalendar(GridItemEventArgs e)
        {
            if (e.Item is GridCommandItem)
            {
                TextBox txtFromDate = (TextBox)e.Item.FindControl("txtFromDate");
                TextBox txtToDate = (TextBox)e.Item.FindControl("txtToDate");

                if (txtFromDate != null && txtToDate != null)
                {
                    txtFromDate.Text = this.objCommon.Eprint_return_Date_Before_View(txtFromDate.Text, this.CompanyID, this.UserID, false);
                    txtToDate.Text = this.objCommon.Eprint_return_Date_Before_View(txtToDate.Text, this.CompanyID, this.UserID, false);

                    txtFromDate.Attributes.Add(
                        "onclick",
                        $"javascript:event.cancelBubble=true;this.select();lcs(this,'{this.DateFormat}');"
                    );
                    txtToDate.Attributes.Add(
                        "onclick",
                        $"javascript:event.cancelBubble=true;this.select();lcs(this,'{this.DateFormat}');"
                    );
                }
            }
        }
        protected void ddlCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCustomersDropDown(null, sender);
        }
        protected void ddlReportPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDateControls(null, sender);
        }

        private void SetClearFilterFlag()
        {
            this.hdnClearFilters.Value = "1";
        }

        #endregion
    }
}