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
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class Sage50Accounting : BaseClass, IRequiresSessionState
    {
        private HttpResponse response = HttpContext.Current.Response;
        private string appType = "Web";

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

        public Sage50Accounting()
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

        protected void btn_InvoiceExport_Click(object sender, EventArgs e)
        {
            newFunction();
        }

        protected void newFunction()
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
            DataSet invoiceeData = this.GetSage50InvoiceData(flag, str, str1, Convert.ToInt64(0));
            foreach (DataRow row in invoiceeData.Tables[0].Rows)
            {
                foreach (DataColumn column in invoiceeData.Tables[0].Columns)
                {
                    row[column.ColumnName] = base.SpecialDecode(row[column.ColumnName].ToString());

                    if (row["DecisionMaking"].ToString() == "True")
                    {
                        string myStringVariable = "There are changes in the CRM. Please run the customer export before importing your invoices.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                        return;
                    }

                }
            }
            DataTable dataTable = new DataTable();
            dataTable = (ConnectionClass.ServerName != "peterkin" ? this.AddBlankRow(invoiceeData.Tables[0], "Reference") : this.AddBlankRow(invoiceeData.Tables[0], "Invoice #"));
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50/Sage50_Invoice_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".xls" };
            string str2 = string.Concat(secureDocPath2);
            Export export = new Export();
            export.Save_ExportedDetails_InPath(invoiceeData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_CSV_Web(dataTable, "Invoice.xls");

            // start


            DataTable dataTable1 = new DataTable();

            dataTable1 = invoiceeData.Tables[0];

            dataTable1.Columns.Remove("DecisionMaking");

            String strDownloadFileName = "Invoice.csv";

            Byte[] myData = csvBytesWriter(ref dataTable1);

            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment; filename=" + strDownloadFileName);
            Response.BinaryWrite(myData);  // Binary data - see myData -  
            Response.End();
            

            // end
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SQL.ExecuteNonQuery((new commonClass()).strConnection, CommandType.Text, "update tb_client set isexported=0; update tb_invoice set isexported=0 ;update tb_purchase set isexported=0");
        }

        public DataSet GetInvoiceeData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate), new SqlParameter("@StatusID", (object)StatusID) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Accounting_export_Invoice_Type_myob", sqlParameter);
        }

        public DataSet GetSage50InvoiceData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate), new SqlParameter("@StatusID", (object)StatusID) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Accounting_export_Invoice_Type_Sage50", sqlParameter);
        }

        public DataSet GetPurchaseData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate), new SqlParameter("@StatusID", (object)StatusID) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_settings_Accounting_export_Purchase_Type_myob", sqlParameter);
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
            base.Title = this.objLanguage.convert(global.pageTitle("Sage50 Accounting", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateTimeForFileName = DateTime.Now.ToString("yyyy-MM-d--HH-mm-ss");
            //this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("SageOne_Accounting");
            this.header_mis.SettingName = ("Sage50 Accounting");
            
            this.rdoInvoiceFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");
          
            //this.rdoInvoiceAll.Text = this.objLanguage.GetLanguageConversion("All");
          
            //this.rdoInvoiceByDateRange.Text = this.objLanguage.GetLanguageConversion("By_Date_Range");
          
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
                //this.objSet.Bind_Status_new(this.ddlInvStatus, this.CompanyID, string.Concat("--", this.objLanguage.GetLanguageConversion("Select"), "--"), "invoice");
            }
            if (!base.IsPostBack)
            {

                

                commonClass _commonClass = this.comm;
                DateTime now = DateTime.Now;
                commonClass _commonClass1 = this.comm;
                DateTime dateTime = DateTime.Now;
                commonClass _commonClass2 = this.comm;
                DateTime now1 = DateTime.Now;
                commonClass _commonClass3 = this.comm;
                DateTime dateTime1 = DateTime.Now;
                commonClass _commonClass4 = this.comm;
                DateTime now2 = DateTime.Now;
                commonClass _commonClass5 = this.comm;
                DateTime dateTime2 = DateTime.Now;
                TextBox textBox6 = this.txInvoiceFromDate;
                commonClass _commonClass6 = this.comm;
                DateTime now3 = DateTime.Now;
                textBox6.Text = _commonClass6.Eprint_return_Date_Before_View(now3.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox7 = this.txInvoiceToDate;
                commonClass _commonClass7 = this.comm;
                DateTime dateTime3 = DateTime.Now;
                textBox7.Text = _commonClass7.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);


                TextBox textBox = this.txtCustomerFromDate;
                commonClass _commonClass9 = this.comm;
                DateTime now9 = DateTime.Now;
                textBox.Text = _commonClass9.Eprint_return_Date_Before_View(now9.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox1 = this.txtCustomerToDate;
                commonClass _commonClass10 = this.comm;
                DateTime dateTime9 = DateTime.Now;
                textBox1.Text = _commonClass10.Eprint_return_Date_Before_View(dateTime9.ToString(), this.CompanyID, this.UserID, false);


                this.txInvoiceFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txInvoiceToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomerFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtCustomerToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            }
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
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50" };
            if (!Directory.Exists(string.Concat(secureDocPath1)))
            {
                string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50" };
                Directory.CreateDirectory(string.Concat(strArrays1));
            }
            string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/AccountingExport/Sage50/Sage50_Customer_", this.DateTimeForFileName.ToString().Replace("/", "-"), ".xls" };
            string str2 = string.Concat(secureDocPath2);
            foreach (DataRow row in customerData.Tables[0].Rows)
            {
                row["Account Reference"] = base.SpecialDecode(row["Account Reference"].ToString());
                row["Account Name"] = base.SpecialDecode(row["Account Name"].ToString());
                row["Street 1"] = base.SpecialDecode(row["Street 1"].ToString());
                row["Street 2"] = base.SpecialDecode(row["Street 2"].ToString());
                row["Town"] = base.SpecialDecode(row["Town"].ToString());
                row["Country"] = base.SpecialDecode(row["Country"].ToString());
                row["Postcode"] = base.SpecialDecode(row["Postcode"].ToString());
                row["Contact Name"] = base.SpecialDecode(row["Contact Name"].ToString());
                row["Telephone Number"] = base.SpecialDecode(row["Telephone Number"].ToString());
                row["Fax Number"] = base.SpecialDecode(row["Fax Number"].ToString());
                row["Analysis 1"] = base.SpecialDecode(row["Analysis 1"].ToString());
                row["Analysis 2"] = base.SpecialDecode(row["Analysis 2"].ToString());
                row["Analysis 3"] = base.SpecialDecode(row["Analysis 3"].ToString());
                row["Department"] = base.SpecialDecode(row["Department"].ToString());
                row["VAT Reg No"] = base.SpecialDecode(row["VAT Reg No"].ToString());
                row["MTD Turnover"] = base.SpecialDecode(row["MTD Turnover"].ToString());
                row["YTD Turnover"] = base.SpecialDecode(row["YTD Turnover"].ToString());
                row["Last Year"] = base.SpecialDecode(row["Last Year"].ToString());
                row["Credit Limit"] = base.SpecialDecode(row["Credit Limit"].ToString());
                row["Terms Text"] = base.SpecialDecode(row["Terms Text"].ToString());
                row["Due Days"] = base.SpecialDecode(row["Due Days"].ToString());
                row["Settlement Discount"] = base.SpecialDecode(row["Settlement Discount"].ToString());
                row["Default Nominal"] = base.SpecialDecode(row["Default Nominal"].ToString());
                row["Tax Code"] = base.SpecialDecode(row["Tax Code"].ToString());
                row["Trade Contact"] = base.SpecialDecode(row["Trade Contact"].ToString());
                row["Telephone 2"] = base.SpecialDecode(row["Telephone 2"].ToString());
                row["eMAil"] = base.SpecialDecode(row["eMAil"].ToString());
                row["WWW"] = base.SpecialDecode(row["WWW"].ToString());
                row["Discount Rate"] = base.SpecialDecode(row["Discount Rate"].ToString());
                row["Payment Due Days"] = base.SpecialDecode(row["Payment Due Days"].ToString());
                row["Terms Agreed"] = base.SpecialDecode(row["Terms Agreed"].ToString());
                //row["Bank Name"] = base.SpecialDecode(row["Bank Name"].ToString());
                //row["Bank Address 1"] = base.SpecialDecode(row["Bank Address 1"].ToString());
                //row["Bank Address 2"] = base.SpecialDecode(row["Bank Address 2"].ToString());
                //row["Bank Address 3"] = base.SpecialDecode(row["Bank Address 3"].ToString());
                //row["Bank Address 4"] = base.SpecialDecode(row["Bank Address 4"].ToString());
                //row["Bank Address 5"] = base.SpecialDecode(row["Bank Address 5"].ToString());
                //row["Bank Account Name"] = base.SpecialDecode(row["Bank Account Name"].ToString());
                //row["Bank Sort Code"] = base.SpecialDecode(row["Bank Sort Code"].ToString());
                //row["Bank Account No"] = base.SpecialDecode(row["Bank Account No"].ToString());
                //row["Bank BACS Ref"] = base.SpecialDecode(row["Bank BACS Ref"].ToString());
                //row["Online Payments"] = base.SpecialDecode(row["Online Payments"].ToString());
                //row["Currency No"] = base.SpecialDecode(row["Currency No"].ToString());
                //row["Restrict Mailing"] = base.SpecialDecode(row["Restrict Mailing"].ToString());
                //row["Date Account Opened"] = base.SpecialDecode(row["Date Account Opened"].ToString());
                //row["Next Credit Review"] = base.SpecialDecode(row["Next Credit Review"].ToString());
                //row["Last Credit Review"] = base.SpecialDecode(row["Last Credit Review"].ToString());
                //row["Account Status"] = base.SpecialDecode(row["Account Status"].ToString());
                //row["Can Apply Charges"] = base.SpecialDecode(row["Can Apply Charges"].ToString());
                //row["Country Code"] = base.SpecialDecode(row["Country Code"].ToString());
                //row["Priority Trader"] = base.SpecialDecode(row["Priority Trader"].ToString());
                //row["Override Stock Tax"] = base.SpecialDecode(row["Override Stock Tax"].ToString());
                //row["Override Stock Nom"] = base.SpecialDecode(row["Override Stock Nom"].ToString());
                //row["Bank Additional 1"] = base.SpecialDecode(row["Bank Additional 1"].ToString());
                //row["Bank Additional 2"] = base.SpecialDecode(row["Bank Additional 2"].ToString());
                //row["Bank Additional 3"] = base.SpecialDecode(row["Bank Additional 3"].ToString());
                //row["Bank IBAN"] = base.SpecialDecode(row["Bank IBAN"].ToString());
                //row["Bank BIC Swift"] = base.SpecialDecode(row["Bank BIC Swift"].ToString());
                //row["Bank Roll Number"] = base.SpecialDecode(row["Bank Roll Number"].ToString());
                //row["Report Password"] = base.SpecialDecode(row["Report Password"].ToString());
                //row["DUNS Number"] = base.SpecialDecode(row["DUNS Number"].ToString());
                //row["Payment Method"] = base.SpecialDecode(row["Payment Method"].ToString());
                //row["Letters Via Email"] = base.SpecialDecode(row["Letters Via Email"].ToString());

            }
            Export export = new Export();
            export.Save_ExportedDetails_InPath(customerData.Tables[0], Export.ExportFormat.Excel, str2, ",");
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            //(new WebExport()).Export_with_XSLT_Web(customerData.Tables[0], "customer.xls");


            // start


            DataTable dataTable1 = new DataTable();

            dataTable1 = customerData.Tables[0];

            String strDownloadFileName = "customer.csv";

            Byte[] myData = csvBytesWriter(ref dataTable1);

            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment; filename=" + strDownloadFileName);
            Response.BinaryWrite(myData);  // Binary data - see myData -  
            Response.End();



            // end


        }

        public DataSet GetCustomerData(bool IsExported, string CompanyType, string ValidFromDate, string ValidToDate)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@companyid", this.Session["CompanyID"].ToString()), new SqlParameter("@IsExported", (object)IsExported), new SqlParameter("@CompanyType", CompanyType), new SqlParameter("@FRomDate", ValidFromDate), new SqlParameter("@ToDate", ValidToDate) };
            return SQL.ExecuteDataset((new commonClass()).strConnection, CommandType.StoredProcedure, "PC_Sage50_CustomerContact_Select", sqlParameter);
        }

        public byte[] csvBytesWriter(ref DataTable dTable)
        {

            //--------Columns Name---------------------------------------------------------------------------

            StringBuilder sb = new StringBuilder();
            int intClmn = dTable.Columns.Count;

            //int i = 0;
            //for (i = 0; i <= intClmn - 1; i += 1)
            //{
            //    sb.Append(@"""" + dTable.Columns[i].ColumnName.ToString() + @"""");
            //    if (i == intClmn - 1)
            //    {
            //        sb.Append(" ");
            //    }
            //    else
            //    {
            //        sb.Append(",");
            //    }
            //}
            //sb.Append(Environment.NewLine);

            //--------Data By  Columns---------------------------------------------------------------------------

            // declare this outside the loop!
            char[] csvTokens = new[] { '\"', ',', '\n', '\r' };

            // inside the loop
            

            foreach (DataRow row in dTable.Rows)
            {
                int ir = 0;
                for (ir = 0; ir <= intClmn - 1; ir += 1)
                {
                    if (row[ir].ToString().IndexOfAny(csvTokens) >= 0)
                    {
                        row[ir] = "\"" + row[ir].ToString().Replace("\"", "\"\"") + "\"";
                    } 

                    sb.Append(row[ir].ToString());
                    if (ir == intClmn - 1)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append(",");
                    }

                }
                sb.Append(Environment.NewLine);
            }

            return System.Text.Encoding.UTF8.GetBytes(sb.ToString());

        }
    }
}