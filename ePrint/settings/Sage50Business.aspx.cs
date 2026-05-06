using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using RKLib.ExportData;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

namespace ePrint.settings
{
    public partial class Sage50Business : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        private commonClass comm = new commonClass();

        public string DateFormat = string.Empty;

        public string ServerName = ConnectionClass.ServerName;

        public string DateTimeForFileName = string.Empty;
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

        public Sage50Business()
        {
        }

        public DataTable AddBlankRow(DataTable dtMain, string MatchingColumnName)
        {
            if (dtMain.Rows.Count <= 0)
            {
                return dtMain;
            }
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            object[] objArray = new object[dtMain.Columns.Count];
            for (int i = 0; i < dtMain.Columns.Count; i++)
            {
                dataTable.Columns.Add(dtMain.Columns[i].ToString(), typeof(string));
                objArray[i] = "";
            }
            string empty = string.Empty;
            int num = 0;
            foreach (DataRow row in dtMain.Rows)
            {
                if (empty != row[MatchingColumnName].ToString() && num > 0)
                {
                    dataTable.Rows.Add(objArray);
                }
                dataTable.ImportRow(row);
                num++;
                empty = row[MatchingColumnName].ToString();
            }
            return dataTable;
        }

        protected void Btn_CustomerExport_Click(object sender, EventArgs e)
        {
            string str = "01/01/1900";
            string str1 = "12/31/2100";
            if (this.rdoCustomerByDateRange.Checked)
            {
                if (this.txtCustomerFromDate.Text.Length > 0)
                {
                    str = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomerFromDate.Text);
                }
                if (this.txtCustomerToDate.Text.Length > 0)
                {
                    str1 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtCustomerToDate.Text);
                }
            }
            bool flag = false;
            if (this.rdoCustomerFrom.Checked)
            {
                flag = true;
            }
            DataSet customerData = this.GetCustomerData(flag, "customer", str, str1);
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business/Sage50Business_Customer_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".xls" };
            string str2 = string.Concat(secureDocPath2);
            foreach (DataRow row in customerData.Tables[0].Rows)
            {
                foreach (DataColumn column in customerData.Tables[0].Columns)
                {
                    row[column.ColumnName] = base.SpecialDecode(row[column.ColumnName].ToString());
                }
            }
            Export export = new Export();
            export.Save_ExportedDetails_InPath(customerData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_XSLT_Web(customerData.Tables[0], "customer.xls");
            DataSet ds = new DataSet();
            DataTable dtCopy1 = customerData.Tables[0].Copy();
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
                Response.AddHeader("content-disposition", "attachment;filename=Customer.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void btn_InvoiceExport_Click(object sender, EventArgs e)
        {
            string str = "01/01/1900";
            string str1 = "12/31/2100";
            if (this.rdoInvoiceByDateRange.Checked)
            {
                if (this.txInvoiceFromDate.Text.Length > 0)
                {
                    str = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txInvoiceFromDate.Text);
                }
                if (this.txInvoiceToDate.Text.Length > 0)
                {
                    str1 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txInvoiceToDate.Text);
                }
            }
            bool flag = false;
            if (this.rdoInvoiceFrom.Checked)
            {
                flag = true;
            }
            DataSet invoiceeData = this.GetInvoiceeData(flag, str, str1, Convert.ToInt64(this.ddlInvStatus.SelectedValue));
            foreach (DataRow row in invoiceeData.Tables[0].Rows)
            {
                foreach (DataColumn column in invoiceeData.Tables[0].Columns)
                {
                    row[column.ColumnName] = base.SpecialDecode(row[column.ColumnName].ToString());
                }
            }
            //DataTable dataTable = new DataTable();
            //if (Convert.ToString(Session["CompanyName"]).Contains("Clockwork") || Convert.ToString(Session["CompanyName"]).Contains("Handy Envelopes") || Convert.ToString(Session["CompanyName"]).Contains("Brightset") || Convert.ToString(Session["CompanyName"]).Contains("Spark") || Convert.ToString(Session["CompanyName"]).Contains("iPrint Digital")
            //    || Convert.ToString(Session["CompanyName"]).Contains("Creative Plastic Cards"))
            //{
            //    // Ticket #9629 MYOB export excel file hearder names updated
            //    dataTable = (ConnectionClass.ServerName != "peterkin" ? this.AddBlankRow(invoiceeData.Tables[0], "Invoice #") : this.AddBlankRow(invoiceeData.Tables[0], "Invoice #"));
            //}
            //else
            //{
            //    dataTable = (ConnectionClass.ServerName != "peterkin" ? this.AddBlankRow(invoiceeData.Tables[0], "InvoiceNumber") : this.AddBlankRow(invoiceeData.Tables[0], "Invoice #"));

            //}

            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business/Sage50Business_Invoice_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".xls" };
            string str2 = string.Concat(secureDocPath2);
            Export export = new Export();
            export.Save_ExportedDetails_InPath(invoiceeData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_XSLT_Web(invoiceeData.Tables[0], "Invoice.xls");
            DataSet ds = new DataSet();
            DataTable dtCopy1 = invoiceeData.Tables[0].Copy();
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
                Response.AddHeader("content-disposition", "attachment;filename=Invoice.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void Btn_PurchaseExport_Click(object sender, EventArgs e)
        {
            string str = "01/01/1900";
            string str1 = "12/31/2100";
            if (this.rdoPurchaseByDateRange.Checked)
            {
                if (this.txtPurchaseFromDate.Text.Length > 0)
                {
                    str = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtPurchaseFromDate.Text);
                }
                if (this.txtPurchaseToDate.Text.Length > 0)
                {
                    str1 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtPurchaseToDate.Text);
                }
            }
            bool flag = false;
            if (this.rdoPurchaseFrom.Checked)
            {
                flag = true;
            }
            DataSet purchaseData = this.GetPurchaseData(flag, str, str1, Convert.ToInt64(this.ddlPurchaseStatus.SelectedValue));
            foreach (DataRow row in purchaseData.Tables[0].Rows)
            {
                foreach (DataColumn column in purchaseData.Tables[0].Columns)
                {
                    row[column.ColumnName] = base.SpecialDecode(row[column.ColumnName].ToString());
                }
            }
            //    if (!string.IsNullOrEmpty(row["Amount"].ToString()))
            //    {
            //        row["Amount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Amount"]), 0, "", false, false, true);
            //    }
            //    if (Convert.ToString(Session["CompanyName"]).Contains("Clockwork") || Convert.ToString(Session["CompanyName"]).Contains("Handy Envelopes") || Convert.ToString(Session["CompanyName"]).Contains("Brightset") || Convert.ToString(Session["CompanyName"]).Contains("Spark") || Convert.ToString(Session["CompanyName"]).Contains("iPrint Digital")
            //        || Convert.ToString(Session["CompanyName"]).Contains("Creative Plastic Cards"))
            //    {
            //        if (ConnectionClass.ServerName != "peterkin")
            //        {
            //            if (!string.IsNullOrEmpty(row["Inc-Tax Amount"].ToString()))
            //            {
            //                row["Inc-Tax Amount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Inc-Tax Amount"]), 0, "", false, false, true);
            //            }
            //            if (string.IsNullOrEmpty(row["GST Amount"].ToString()))
            //            {
            //                continue;
            //            }
            //            row["GST Amount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GST Amount"]), 0, "", false, false, true);
            //        }
            //        else
            //        {
            //            if (!string.IsNullOrEmpty(row["Inc-Tax Amount"].ToString()))
            //            {
            //                row["Inc-Tax Amount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Inc-Tax Amount"]), 0, "", false, false, true);
            //            }
            //            if (string.IsNullOrEmpty(row["GST Amount"].ToString()))
            //            {
            //                continue;
            //            }
            //            row["GST Amount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GST Amount"]), 0, "", false, false, true);
            //        }
            //    }
            //    else
            //    {
            //        // for other than clockwork

            //        if (ConnectionClass.ServerName != "peterkin")
            //        {
            //            if (!string.IsNullOrEmpty(row["IncTaxAmount"].ToString()))
            //            {
            //                row["IncTaxAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["IncTaxAmount"]), 0, "", false, false, true);
            //            }
            //            if (string.IsNullOrEmpty(row["GSTAmount"].ToString()))
            //            {
            //                continue;
            //            }
            //            row["GSTAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GSTAmount"]), 0, "", false, false, true);
            //        }
            //        else
            //        {
            //            if (!string.IsNullOrEmpty(row["Inc-TaxAmount"].ToString()))
            //            {
            //                row["Inc-TaxAmount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Inc-TaxAmount"]), 0, "", false, false, true);
            //            }
            //            if (string.IsNullOrEmpty(row["GST Amount"].ToString()))
            //            {
            //                continue;
            //            }
            //            row["GST Amount"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GST Amount"]), 0, "", false, false, true);
            //        }
            //    }
            //}
            //DataTable dataTable = new DataTable();
            //if (Convert.ToString(Session["CompanyName"]).Contains("Clockwork") || Convert.ToString(Session["CompanyName"]).Contains("Handy Envelopes") || Convert.ToString(Session["CompanyName"]).Contains("Brightset") || Convert.ToString(Session["CompanyName"]).Contains("Spark") || Convert.ToString(Session["CompanyName"]).Contains("iPrint Digital")
            //    || Convert.ToString(Session["CompanyName"]).Contains("Creative Plastic Cards"))
            //{
            //    dataTable = (ConnectionClass.ServerName != "peterkin" ? this.AddBlankRow(purchaseData.Tables[0], "Purchase #") : this.AddBlankRow(purchaseData.Tables[0], "Purchase #"));
            //}
            //else
            //{
            //    dataTable = (ConnectionClass.ServerName != "peterkin" ? this.AddBlankRow(purchaseData.Tables[0], "PurchaseNumber") : this.AddBlankRow(purchaseData.Tables[0], "Purchase #"));
            //}
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business/Sage50Business_Purchase_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".xls" };
            string str2 = string.Concat(secureDocPath2);
            Export export = new Export();
            export.Save_ExportedDetails_InPath(purchaseData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_XSLT_Web(purchaseData.Tables[0], "Purchase.xls");
            DataSet ds = new DataSet();
            DataTable dtCopy1 = purchaseData.Tables[0].Copy();
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
                Response.AddHeader("content-disposition", "attachment;filename=Purchase.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void Btn_SupplierExport_Click(object sender, EventArgs e)
        {
            string str = "01/01/1900";
            string str1 = "12/31/2100";
            if (this.rdoSupplierByDateRange.Checked)
            {
                if (this.txtSupplierFromDate.Text.Length > 0)
                {
                    str = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtSupplierFromDate.Text);
                }
                if (this.txtSupplierToDate.Text.Length > 0)
                {
                    str1 = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtSupplierToDate.Text);
                }
            }
            bool flag = false;
            if (this.rdoSupplierFrom.Checked)
            {
                flag = true;
            }
            DataSet customerData = this.GetCustomerData(flag, "supplier", str, str1);
            foreach (DataRow row in customerData.Tables[0].Rows)
            {
                foreach (DataColumn column in customerData.Tables[0].Columns)
                {
                    row[column.ColumnName] = base.SpecialDecode(row[column.ColumnName].ToString());
                }
            }
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50Business/Sage50Business_Supplier_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".xls" };
            string str2 = string.Concat(secureDocPath2);
            Export export = new Export();
            export.Save_ExportedDetails_InPath(customerData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_XSLT_Web(customerData.Tables[0], "supplier.xls");
            DataSet ds = new DataSet();
            DataTable dtCopy1 = customerData.Tables[0].Copy();
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
                Response.AddHeader("content-disposition", "attachment;filename=Supplier.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SQL.ExecuteNonQuery((new commonClass()).strConnection, CommandType.Text, "update tb_client set isexported=0; update tb_invoice set isexported=0 ;update tb_purchase set isexported=0");
        }

        public DataSet GetCustomerData(bool IsExported, string CompanyType, string ValidFromDate, string ValidToDate)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@companyid", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@CompanyType", CompanyType), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Accounting_export_Contact_Type_Sage50Business", sqlParameter);
        }

        public DataSet GetInvoiceeData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate), new SqlParameter("@StatusID", (object)StatusID) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Accounting_export_Invoice_Type_Sage50Business", sqlParameter);
        }

        public DataSet GetPurchaseData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate), new SqlParameter("@StatusID", (object)StatusID) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Accounting_export_Purchase_Type_Sage50Business", sqlParameter);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["DateFormat"].ToString();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../Settings/Settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("MYOB_Accounting")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Sage50 Business", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateTimeForFileName = DateTime.Now.ToString("yyyy-MM-d--HH-mm-ss");
            this.header_mis.SettingName = ("Sage50 Business");
            this.rdoCustomerFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");
            this.rdoSupplierFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");
            this.rdoPurchaseFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");
            this.rdoInvoiceFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");
            this.rdoPurchaseAll.Text = this.objLanguage.GetLanguageConversion("All");
            this.rdoSupplierAll.Text = this.objLanguage.GetLanguageConversion("All");
            this.rdoCustomerAll.Text = this.objLanguage.GetLanguageConversion("All");
            this.rdoInvoiceAll.Text = this.objLanguage.GetLanguageConversion("All");
            this.rdoPurchaseByDateRange.Text = this.objLanguage.GetLanguageConversion("By_Date_Range");
            this.rdoSupplierByDateRange.Text = this.objLanguage.GetLanguageConversion("By_Date_Range");
            this.rdoCustomerByDateRange.Text = this.objLanguage.GetLanguageConversion("By_Date_Range");
            this.rdoInvoiceByDateRange.Text = this.objLanguage.GetLanguageConversion("By_Date_Range");
            this.Btn_CustomerExport.Text = this.objLanguage.GetLanguageConversion("Export");
            this.Btn_SupplierExport.Text = this.objLanguage.GetLanguageConversion("Export");
            this.Btn_PurchaseExport.Text = this.objLanguage.GetLanguageConversion("Export");
            this.btn_InvoiceExport.Text = this.objLanguage.GetLanguageConversion("Export");
            if (base.Request.QueryString["reset"] == null)
            {
                this.btnReset.Visible = false;
            }
            else
            {
                this.btnReset.Visible = true;
            }
            if (!base.IsPostBack)
            {
                this.objSet.Bind_Status_new(this.ddlPurchaseStatus, this.CompanyID, string.Concat("--", this.objLanguage.GetLanguageConversion("Select"), "--"), "purchase");
                this.objSet.Bind_Status_new(this.ddlInvStatus, this.CompanyID, string.Concat("--", this.objLanguage.GetLanguageConversion("Select"), "--"), "invoice");
            }
            if (!base.IsPostBack)
            {
                TextBox textBox = this.txtCustomerFromDate;
                commonClass _commonClass = this.comm;
                DateTime now = DateTime.Now;
                textBox.Text = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox1 = this.txtCustomerToDate;
                commonClass _commonClass1 = this.comm;
                DateTime dateTime = DateTime.Now;
                textBox1.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox2 = this.txtSupplierFromDate;
                commonClass _commonClass2 = this.comm;
                DateTime now1 = DateTime.Now;
                textBox2.Text = _commonClass2.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox3 = this.txtSupplierToDate;
                commonClass _commonClass3 = this.comm;
                DateTime dateTime1 = DateTime.Now;
                textBox3.Text = _commonClass3.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox4 = this.txtPurchaseFromDate;
                commonClass _commonClass4 = this.comm;
                DateTime now2 = DateTime.Now;
                textBox4.Text = _commonClass4.Eprint_return_Date_Before_View(now2.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox5 = this.txtPurchaseToDate;
                commonClass _commonClass5 = this.comm;
                DateTime dateTime2 = DateTime.Now;
                textBox5.Text = _commonClass5.Eprint_return_Date_Before_View(dateTime2.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox6 = this.txInvoiceFromDate;
                commonClass _commonClass6 = this.comm;
                DateTime now3 = DateTime.Now;
                textBox6.Text = _commonClass6.Eprint_return_Date_Before_View(now3.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox7 = this.txInvoiceToDate;
                commonClass _commonClass7 = this.comm;
                DateTime dateTime3 = DateTime.Now;
                textBox7.Text = _commonClass7.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);
                this.txtCustomerFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomerToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtSupplierFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtSupplierToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtPurchaseFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtPurchaseToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txInvoiceFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txInvoiceToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            }
        }
    }
}