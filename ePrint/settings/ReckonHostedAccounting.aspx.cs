using nmsConnectionClass;
using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ePrint.settings
{
    public partial class ReckonHostedAccounting : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        protected string strSitepath = global.sitePath();
        public int CompanyID;

        public int UserID;

        public int AccountID;

        private commonClass comm = new commonClass();

        public string DateFormat = string.Empty;

        public string ServerName = ConnectionClass.ServerName;

        public string DateTimeForFileName = string.Empty;
        private Global gloobj = new Global();


        protected void btn_InvoiceExport_Click(object sender, EventArgs e)
        {
            string exportFileName = "ReckonHostedExport.iif";
            string exportFilePath = "C:\\ExportDirectory\\" + exportFileName; // Update with your desired export directory

            string exportContent = GenerateExportContent();

            try
            {
                // Save the export content to a file
                //File.WriteAllText(exportFilePath, exportContent);
                // Set the response headers
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=ReckonHostedFile.iif");
                Response.AddHeader("Content-Length", exportContent.Length.ToString());

                // Write the content to the response stream
                Response.Write(exportContent.ToString());

                // End the response
                Response.End();
                Console.WriteLine("Export file created successfully at: " + exportFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting file: " + ex.Message);
            }
        }

        private string GenerateExportContent()
        {
            StringBuilder exportBuilder = new StringBuilder();
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
            DataTable invoiceeData = this.GetInvoiceTransactionData(flag, str, str1, Convert.ToInt64(0));

            // Add the header section
            exportBuilder.AppendLine("!TRNS\tTRNSID\tTRNSTYPE\tDATE\tACCNT\tNAME\tCLASS\tAMOUNT\tDOCNUM\tMEMO\tCLEAR\tTOPRINT\tNAMEISTAXABLE\tDUEDATE\tTERMS\tPAYMETH\tPONUM\tINVMEMO\tADDR1\tADDR2\tADDR3\tADDR4\tSADDR1\tSADDR2\tSADDR3\tSADDR4\tSADDR5\tTOSEND\tISAJE\tOTHER1");
            exportBuilder.AppendLine("!SPL\tSPLID\tTRNSTYPE\tTRANSDATE\tACCNT\tNAME\tCLASS\tAMOUNT\tDOCNUM\tMEMO\tCLEAR\tQNTY\tPRICE\tINVITEM\tTAXABLE\tTAXCODE\tTAXAMOUNT");
            exportBuilder.AppendLine("!ENDTRNS");

            //exportBuilder.AppendLine("!HDR TYPE=INVOICE");
            //exportBuilder.AppendLine("!HDR FIELD1=TRNSID");
            //exportBuilder.AppendLine("!HDR FIELD2=TIMESTAMP");
            //exportBuilder.AppendLine("!HDR FIELD3=TRNSTYPE");

            //exportBuilder.AppendLine("!HDR FIELD4=DATE");
            //exportBuilder.AppendLine("!HDR FIELD5=ACCNT");
            //exportBuilder.AppendLine("!HDR FIELD3=NAME");
            //exportBuilder.AppendLine("!HDR FIELD3=AMOUNT");
            //exportBuilder.AppendLine("!HDR FIELD3=DOCNUM");
            //exportBuilder.AppendLine("!HDR FIELD3=MEMO");
            //exportBuilder.AppendLine("!HDR FIELD3=CLEAR");
            //exportBuilder.AppendLine("!HDR FIELD3=TOPRINT");
            //exportBuilder.AppendLine("!HDR FIELD3=ADDR1");
            //exportBuilder.AppendLine("!HDR FIELD3=ADDR2");
            //exportBuilder.AppendLine("!HDR FIELD3=ADDR3");
            //exportBuilder.AppendLine("!HDR FIELD3=ADDR4");
            //exportBuilder.AppendLine("!HDR FIELD3=ADDR5");
            //exportBuilder.AppendLine("!HDR FIELD3=DUEDATE");
            //exportBuilder.AppendLine("!HDR FIELD3=TERMS");
            //exportBuilder.AppendLine("!HDR FIELD3=PAID");
            //exportBuilder.AppendLine("!HDR FIELD3=SHIPVIA");
            //exportBuilder.AppendLine("!HDR FIELD3=SHIPDATE");
            //exportBuilder.AppendLine("!HDR FIELD3=REP");
            //exportBuilder.AppendLine("!HDR FIELD3=FOB");

            //exportBuilder.AppendLine("!HDR FIELD3=PONUM");
            //exportBuilder.AppendLine("!HDR FIELD3=INVTITLE");
            //exportBuilder.AppendLine("!HDR FIELD3=INVMEMO");
            //exportBuilder.AppendLine("!HDR FIELD3=SADDR1");
            //exportBuilder.AppendLine("!HDR FIELD3=SADDR2");
            //exportBuilder.AppendLine("!HDR FIELD3=SADDR3");
            //exportBuilder.AppendLine("!HDR FIELD3=SADDR4");
            //exportBuilder.AppendLine("!HDR FIELD3=SADDR5");
            //exportBuilder.AppendLine("!HDR FIELD3=NAMEISTAXABLE");


            //exportBuilder.AppendLine("!HDR END");

            // Add transaction data
            foreach (DataRow transaction in invoiceeData.Rows)
            {
                decimal trans_amount = ConvertStringToDecimal(transaction["AMOUNT"].ToString());
                // Add the transaction header
                //exportBuilder.AppendLine("TRNS\t " + transaction["TRNSID"] + " \t" + transaction["TRNSTYPE"] + "\t" + transaction["DATE"] + "\t" + transaction["ACCNT"] + "\t" + transaction["NAME"] + "\t" + transaction["CLASS"] + "\t" + transaction["AMOUNT"] + "\t" + transaction["DOCNUM"] + "\t" + transaction["MEMO"] + "\t" + transaction["CLEAR"] + "\t" + transaction["TOPRINT"] + "\t" + transaction["NAMEISTAXABLE"] + "\t" + transaction["DUEDATE"] + "\t" + transaction["TERMS"] + "\t" + transaction["PAYMETH"] + "\t" + transaction["PONUM"] + "\t" + transaction["INVMEMO"] + "\t" + transaction["ADDR1"] + "\t" + transaction["ADDR2"] + "\t" + transaction["ADDR3"] + "\t" + transaction["ADDR4"] +  "\t" + transaction["SADDR1"] + "\t" + transaction["SADDR2"] + "\t" + transaction["SADDR3"] + "\t" + transaction["SADDR4"] + "\t" + transaction["SADDR5"] + "\t" + transaction["TOSEND"] + "\t" + transaction["ISAJE"] + "\t" + transaction["OTHER1"] + "");
                exportBuilder.AppendLine("TRNS\t  \t" + transaction["TRNSTYPE"] + "\t" + transaction["DATE"] + "\t" + transaction["ACCNT"] + "\t" + transaction["NAME"] + "\t" + transaction["CLASS"] + "\t" + trans_amount + "\t" + transaction["DOCNUM"] + "\t" + transaction["MEMO"] + "\t" + transaction["CLEAR"] + "\t" + transaction["TOPRINT"] + "\t" + transaction["NAMEISTAXABLE"] + "\t" + transaction["DUEDATE"] + "\t" + transaction["TERMS"] + "\t" + transaction["PAYMETH"] + "\t" + transaction["PONUM"] + "\t" + transaction["INVMEMO"] + "\t" + transaction["ADDR1"] + "\t" + transaction["ADDR2"] + "\t" + transaction["ADDR3"] + "\t" + transaction["ADDR4"] + "\t" + transaction["SADDR1"] + "\t" + transaction["SADDR2"] + "\t" + transaction["SADDR3"] + "\t" + transaction["SADDR4"] + "\t" + transaction["SADDR5"] + "\t" + transaction["TOSEND"] + "\t" + transaction["ISAJE"] + "\t" + transaction["OTHER1"] + "");

                //exportBuilder.AppendLine("!TRNS TRANSACTION HEADER");
                //exportBuilder.AppendLine($"TRNS TRNSID: {transaction["TRNSID"]}");
                //exportBuilder.AppendLine($"TRNS TIMESTAMP: {transaction["TIMESTAMP"]}");

                //exportBuilder.AppendLine($"TRNS TRNSTYPE: {transaction["TRNSTYPE"]}");
                //exportBuilder.AppendLine($"TRNS DATE: {transaction["DATE"]}");
                //exportBuilder.AppendLine($"TRNS ACCNT: {transaction["ACCNT"]}");
                //exportBuilder.AppendLine($"TRNS NAME: {transaction["NAME"]}");
                //exportBuilder.AppendLine($"TRNS AMOUNT: {transaction["AMOUNT"]}");
                //exportBuilder.AppendLine($"TRNS DOCNUM: {transaction["DOCNUM"]}");
                //exportBuilder.AppendLine($"TRNS MEMO: {transaction["MEMO"]}");
                //exportBuilder.AppendLine($"TRNS CLEAR: {transaction["CLEAR"]}");
                //exportBuilder.AppendLine($"TRNS TOPRINT: {transaction["TOPRINT"]}");
                //exportBuilder.AppendLine($"TRNS ADDR1: {transaction["ADDR1"]}");
                //exportBuilder.AppendLine($"TRNS ADDR2: {transaction["ADDR2"]}");
                //exportBuilder.AppendLine($"TRNS ADDR3: {transaction["ADDR3"]}");
                //exportBuilder.AppendLine($"TRNS ADDR4: {transaction["ADDR4"]}");
                //exportBuilder.AppendLine($"TRNS ADDR5: {transaction["ADDR5"]}");
                //exportBuilder.AppendLine($"TRNS DUEDATE: {transaction["DUEDATE"]}");
                //exportBuilder.AppendLine($"TRNS TERMS: {transaction["TERMS"]}");
                //exportBuilder.AppendLine($"TRNS PAID: {transaction["PAID"]}");
                //exportBuilder.AppendLine($"TRNS PAYMETH: {transaction["PAYMETH"]}");

                //exportBuilder.AppendLine($"TRNS SHIPVIA: {transaction["SHIPVIA"]}");
                //exportBuilder.AppendLine($"TRNS SHIPDATE: {transaction["SHIPDATE"]}");
                //exportBuilder.AppendLine($"TRNS REP: {transaction["REP"]}");
                //exportBuilder.AppendLine($"TRNS FOB: {transaction["FOB"]}");
                //exportBuilder.AppendLine($"TRNS PONUM: {transaction["PONUM"]}");
                //exportBuilder.AppendLine($"TRNS INVTITLE: {transaction["INVTITLE"]}");
                //exportBuilder.AppendLine($"TRNS INVMEMO: {transaction["INVMEMO"]}");
                //exportBuilder.AppendLine($"TRNS SADDR1: {transaction["SADDR1"]}");
                //exportBuilder.AppendLine($"TRNS SADDR2: {transaction["SADDR2"]}");
                //exportBuilder.AppendLine($"TRNS SADDR3: {transaction["SADDR3"]}");
                //exportBuilder.AppendLine($"TRNS SADDR4: {transaction["SADDR4"]}");
                //exportBuilder.AppendLine($"TRNS SADDR5: {transaction["SADDR5"]}");
                //exportBuilder.AppendLine($"TRNS NAMEISTAXABLE: {transaction["NAMEISTAXABLE"]}");

                DataTable invoiceeLineData = this.GetInvoiceLineItemData(flag, str, str1, Convert.ToInt64(0), int.Parse(transaction["InvoiceID"].ToString()));
                // Add line data for the transaction
                foreach (DataRow line in invoiceeLineData.Rows)
                {
                    decimal taxAmount = ConvertStringToDecimal(line["TAXAMOUNT"].ToString());
                    string taxCode = line["TAXCODE"].ToString();
                    decimal price = ConvertStringToDecimal(line["PRICE"].ToString());
                    string quantity = line["QNTY"].ToString();
                    decimal amount= ConvertStringToDecimal(line["AMOUNT"].ToString());

                    //if (line["SPLID"].ToString() == "0")
                    //{
                    //    taxAmount = "";
                    //    taxCode = "";
                    //    price = "";
                    //    quantity = "";
                    //}
                    //exportBuilder.AppendLine("SPL\t"+ line["SPLID"] + "\t" + line["TRNSTYPE"] + "\t" + line["TRANSDATE"] + "\t" + line["ACCNT"] + "\t" + line["NAME"] + "\t" + line["CLASS"] + "\t" + line["AMOUNT"] + "\t" + line["DOCNUM"] + "\t" + line["MEMO"] + "\t" + line["CLEAR"] + "\t" + quantity + "\t" + price + "\t" + line["INVITEM"] + "\t" + line["TAXABLE"] + "\t" + taxCode + "\t" + taxAmount + "");
                    if(taxAmount == 0.00m)
                    {
                        exportBuilder.AppendLine("SPL\t \t" + line["TRNSTYPE"] + "\t" + line["TRANSDATE"] + "\t" + line["ACCNT"] + "\t" + line["NAME"] + "\t" + line["CLASS"] + "\t" + amount + "\t" + line["DOCNUM"] + "\t" + line["MEMO"] + "\t" + line["CLEAR"] + "\t" + quantity + "\t" + price + "\t" + line["INVITEM"] + "\t" + line["TAXABLE"] + "\t" + taxCode + "");
                    }
                    else
                    {
                        exportBuilder.AppendLine("SPL\t \t" + line["TRNSTYPE"] + "\t" + line["TRANSDATE"] + "\t" + line["ACCNT"] + "\t" + line["NAME"] + "\t" + line["CLASS"] + "\t" + amount + "\t" + line["DOCNUM"] + "\t" + line["MEMO"] + "\t" + line["CLEAR"] + "\t" + quantity + "\t" + price + "\t" + line["INVITEM"] + "\t" + line["TAXABLE"] + "\t" + taxCode + "\t" + taxAmount + "");
                    }

                    //exportBuilder.AppendLine("!SPL LINE DATA");
                    //exportBuilder.AppendLine($"SPL SPLID: {line["SPLID"]}");
                    //exportBuilder.AppendLine($"SPL TRNSTYPE: {line["TRNSTYPE"]}");
                    //exportBuilder.AppendLine($"SPL DATE: {line["DATE"]}");
                    //exportBuilder.AppendLine($"SPL ACCNT: {line["ACCNT"]}");
                    //exportBuilder.AppendLine($"SPL NAME: {line["NAME"]}");
                    //exportBuilder.AppendLine($"SPL CLASS: {line["CLASS"]}");
                    //exportBuilder.AppendLine($"SPL AMOUNT: {line["AMOUNT"]}");
                    //exportBuilder.AppendLine($"SPL DOCNUM: {line["DOCNUM"]}");
                    //exportBuilder.AppendLine($"SPL MEMO: {line["MEMO"]}");
                    //exportBuilder.AppendLine($"SPL CLEAR: {line["CLEAR"]}");
                    //exportBuilder.AppendLine($"SPL PRICE: {line["PRICE"]}");
                    //exportBuilder.AppendLine($"SPL QNTY: {line["QNTY"]}");
                    //exportBuilder.AppendLine($"SPL INVITEM: {line["INVITEM"]}");
                    //exportBuilder.AppendLine($"SPL PAYMETH: {line["PAYMETH"]}");
                    //exportBuilder.AppendLine($"SPL TAXABLE: {line["TAXABLE"]}");
                    //exportBuilder.AppendLine($"SPL REIMBEXP: {line["REIMBEXP"]}");
                    //exportBuilder.AppendLine($"SPL EXTRA: {line["EXTRA"]}");
                    //exportBuilder.AppendLine($"SPL VALDAJ: {line["VALDAJ"]}");
                }

                // Close the transaction section
                exportBuilder.AppendLine("ENDTRNS");
            }

            // Close the header section
            //exportBuilder.AppendLine("!HDR END");
            //exportBuilder.AppendLine("!ENDHDR");
            return exportBuilder.ToString();
        }

        public DataTable GetInvoiceTransactionData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_Accounting_export_Invoice_Type_Reckon_Transaction", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.Session["CompanyID"].ToString());
            sqlCommand.Parameters.AddWithValue("@IsExported", IsExported);
            sqlCommand.Parameters.AddWithValue("@FRomDate", ValidFromDate);
            sqlCommand.Parameters.AddWithValue("@ToDate", ValidToDate);
            sqlCommand.Parameters.AddWithValue("@StatusID", StatusID);
            sqlCommand.CommandTimeout = Int32.MaxValue;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public DataTable GetInvoiceLineItemData(bool IsExported, string ValidFromDate, string ValidToDate, long StatusID,int InvoiceID)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_Accounting_export_Invoice_Type_Reckon_LineItem", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.Session["CompanyID"].ToString());
            sqlCommand.Parameters.AddWithValue("@IsExported", IsExported);
            sqlCommand.Parameters.AddWithValue("@FRomDate", ValidFromDate);
            sqlCommand.Parameters.AddWithValue("@ToDate", ValidToDate);
            sqlCommand.Parameters.AddWithValue("@StatusID", StatusID);
            sqlCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            sqlCommand.CommandTimeout = Int32.MaxValue;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        public decimal ConvertStringToDecimal(string inputString)
        {
            decimal roundedDecimal = 0.00m;
            // Convert the string to a decimal
            if (decimal.TryParse(inputString, out decimal inputDecimal))
            {
                roundedDecimal = Math.Round(inputDecimal, 2);
            }
            return roundedDecimal;
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
            base.Title = this.objLanguage.convert(global.pageTitle("Reckon Accounting", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateTimeForFileName = DateTime.Now.ToString("yyyy-MM-d--HH-mm-ss");
            this.header_mis.SettingName = ("Reckon Accounting");

            this.rdoInvoiceFrom.Text = this.objLanguage.GetLanguageConversion("All_Changes_Since_Last_Export");

            this.btn_InvoiceExport.Text = this.objLanguage.GetLanguageConversion("Export");

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

                this.txInvoiceFromDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txInvoiceToDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            }
        }
    }
}