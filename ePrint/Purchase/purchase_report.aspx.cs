using ePrint.usercontrol;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ClosedXML.Excel;
using ePrint.ePrintUtilities;

namespace ePrint.Purchase
{
    public partial class purchase_report : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string FreeTextColoumn = string.Empty;

        public commonClass objJava = new commonClass();

        public string ColumnNames = string.Empty;

        public string CompanyName = string.Empty;

        public string cs = string.Empty;

        public int CompanyID;

        public string DateFormat = string.Empty;

        public string startdate_quart = string.Empty;

        public string enddate_quart = string.Empty;

        public string[] day;

        public string[] yestday;

        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] enquardate;

        public string[] stlastquardate;

        public string[] enlastquardate;

        public string[] stlastweek;

        public string[] enlastweek;

        public string[] stlastmonth;

        public string[] enlastmonth;

        public string[] stlastyear;

        public string[] enlastyear;

        public string[] from_halffiscalyear;

        public string[] to_halffiscalyear;

        public string year = string.Empty;

        public string[] startyear;

        public string[] endyear;

        public string pagename = string.Empty;

        public string[] today1;

        public int cellvalue_ActivityNotes;

        public int cellvalue_ItemCode;

        public int cellvalue_PONO;

        public string flag_PONO = string.Empty;

        public int cellvalue_createdOn;

        public string flag_createdOn = string.Empty;

        public int cellvalue_company;

        public int cellvalue_contactAddress;

        public int cellvalue_deliveryaddress;

        public int cellvalue_commentdelivery;

        public int cellvalue_Description;

        public string flag_Description = string.Empty;

        public int cellvalue_estimateval;

        public string flag_company = string.Empty;

        public string flag_commentdelivery = string.Empty;

        public string flag_contactaddress = string.Empty;

        public string flag_deliveryaddress = string.Empty;

        public int cellvalue_raisedBy;

        public string flag_raisedBy = string.Empty;

        public int cellvalue_reqDate;

        public int cellvalue_taxval;

        public string flag_reqDate = string.Empty;

        public string flag_taxval = string.Empty;

        public int cellvalue_ExTaxvalue;

        public string flag_ExTaxvalue = string.Empty;

        public string flag_activitynotes = string.Empty;

        public int cellvalue_JobTitle;

        public int cellvalue_ItemQuantity;

        public int cellvalue_PackedIn;

        public string flag_PackedIn = string.Empty;

        public int cellvalue_Price;

        public int cellvalue_Tax;

        public string flag_Tax = string.Empty;

        public string flag_Price = string.Empty;

        public int cellvalue_Tax_Value;

        public string flag_Tax_Value = string.Empty;

        public string flag_JobTitle = string.Empty;

        public string flag_ItemQuantity = string.Empty;

        public string flag_ItemCode = string.Empty;

        public int cellvalue_supplierinvoicedate;

        public string flag_supplierinvoicedate = string.Empty;

        public int cellvalue_invoicedate;

        public string flag_invoicedate = string.Empty;

        public int cellvalue_deliverydate;

        public string flag_deliverydate = string.Empty;

        public int PageSize = 100;

        public int totalrec;

        private int PageNumber = 1;

        public int UserID;

        public string pg = string.Empty;

        public string PurchaseCount = string.Empty;

        public string TotalPurchaseValue = string.Empty;

        public string AveragePurchaseValue = string.Empty;

        public string MaxPurchaseValue = string.Empty;

        public string MinPurchaseValue = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;
        public int cellvalue_CustomDate1;

        public string flag_CustomDate1 = string.Empty;
        public int cellvalue_CustomDate2;

        public string flag_CustomDate2 = string.Empty;
        public int cellvalue_CustomDate3;

        public string flag_CustomDate3 = string.Empty;
        public int cellvalue_CustomDate4;

        public string flag_CustomDate4 = string.Empty;
        public int cellvalue_CustomDate5;

        public string flag_CustomDate5 = string.Empty;

        public string customDatetitle1 = String.Empty;
        public string customDatetitle2 = String.Empty;
        public string customDatetitle3 = String.Empty;
        public string customDatetitle4 = String.Empty;
        public string customDatetitle5 = String.Empty;

        public languageClass objLangClass = new languageClass();

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

        public purchase_report()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.pagename.ToString().ToLower().Trim() == "report")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "common/report.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_view.aspx"));
        }

        public void btnExport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.rdodetail.Checked || this.rdosummary.Checked)
            {
                string value = this.hdnInnerHtml.Value;
                string str = "Purchase_List.xls";
                base.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
                base.Response.Clear();
                base.Response.AppendHeader("content-disposition", string.Concat("attachment;filename=\"", str, "\""));
                base.Response.Charset = "";
                base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                base.Response.ContentType = "application/vnd.ms-excel";
                this.EnableViewState = false;
                base.Response.Write("\r\n");
                base.Response.Write(value);
                base.Response.End();
                return;
            }
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.spnError.Visible = true;
                return;
            }
            DataSet estimateData = this.GetEstimateData(0);
            foreach (DataRow row in estimateData.Tables[0].Rows)
            {
                if (row.Table.Columns.Contains("CreatedDate"))
                {
                    row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("RequestedDate"))
                {
                    row["RequestedDate"] = this.objJava.Eprint_return_Date_Before_View(row["RequestedDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("SupplierInvoiceDate"))
                {
                    row["SupplierInvoiceDate"] = this.objJava.Eprint_return_Date_Before_View(row["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("DeliveryDate"))
                {
                    row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("ActivityNotes"))
                {
                    string str1 = row["ActivityNotes"].ToString().Replace("¶", "<br />").Replace("&lt;br/&gt;", "<br />");
                    this.lblActivityNotes.Text = base.Server.HtmlDecode(str1);
                    row["ActivityNotes"] = this.lblActivityNotes.Text.ToString().Replace("<br />", " ").Replace("<br/>", " ").Replace("&lt;br/&gt;", " ").Replace("&lt;br /&gt;", " ");
                }
                if (!row.Table.Columns.Contains("Description"))
                {
                    continue;
                }
                string str2 = row["Description"].ToString().Replace("<br/>", "<br />");
                this.lblDescription.Text = base.Server.HtmlDecode(str2);
                row["Description"] = this.lblDescription.Text;
            }
            DataTable item = estimateData.Tables[0];
            if (item.Columns.Contains("Purchaseid"))
            {
                item.Columns.Remove("Purchaseid");
            }

            foreach (DataColumn column in item.Columns)
            {

                for (int j = 0; j < item.Columns.Count; j++)
                {
                    if (item.Columns[j].ColumnName == "PONo")
                    {
                        item.Columns[j].ColumnName = "PO No";
                    }
                    if (item.Columns[j].ColumnName == "Company")
                    {
                        item.Columns[j].ColumnName = "Supplier Name";
                    }
                    if (item.Columns[j].ColumnName == "CreatedDate")
                    {
                        item.Columns[j].ColumnName = "Created On";
                    }
                    if (item.Columns[j].ColumnName == "RaisedBy")
                    {
                        item.Columns[j].ColumnName = "Raised By";
                    }
                    if (item.Columns[j].ColumnName == "RequestedDate")
                    {
                        item.Columns[j].ColumnName = "Purchase Date";
                    }
                    if (item.Columns[j].ColumnName == "PurchaseTotalincludingtax")
                    {
                        item.Columns[j].ColumnName = string.Concat("Total(Inc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[j].ColumnName == "PurchaseTotalexcludingtax")
                    {
                        item.Columns[j].ColumnName = string.Concat("Total(Exc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[j].ColumnName == "OrderNumber")
                    {
                        item.Columns[j].ColumnName = "Customer Order No.";
                    }
                    if (item.Columns[j].ColumnName == "JobTitle")
                    {
                        item.Columns[j].ColumnName = "Job Title";
                    }
                    if (item.Columns[j].ColumnName == "ActivityNotes")
                    {
                        item.Columns[j].ColumnName = "Activity Notes";
                    }
                    if (item.Columns[j].ColumnName == "ContactName")
                    {
                        item.Columns[j].ColumnName = "Contact Name";
                    }
                    if (item.Columns[j].ColumnName == "ContactJobTitle1")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 1";
                    }
                    if (item.Columns[j].ColumnName == "ContactJobTitle2")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 2";
                    }
                    if (item.Columns[j].ColumnName == "PaymentTerms")
                    {
                        item.Columns[j].ColumnName = "Payment Terms";
                    }
                    if (item.Columns[j].ColumnName == "ItemTitle")
                    {
                        item.Columns[j].ColumnName = "Item Title";
                    }
                    if (item.Columns[j].ColumnName == "InvoiceNumber")
                    {
                        item.Columns[j].ColumnName = "Invoice Number";
                    }
                    //Invoice Date 
                    if (item.Columns[j].ColumnName == "InvoiceDate")
                    {
                        item.Columns[j].ColumnName = "Invoice Date";
                    }
                    if (item.Columns[j].ColumnName == "ContactAddress")
                    {
                        item.Columns[j].ColumnName = "Contact Address";
                    }
                    if (item.Columns[j].ColumnName == "DeliveryAddress")
                    {
                        item.Columns[j].ColumnName = "Delivery Address";
                    }
                    if (this.ddlContactAddress.SelectedValue == "1")
                    {
                        if (item.Columns[j].ColumnName == "ContactAddress1")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[1].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress2")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[2].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress3")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[3].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress4")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[4].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress5")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[5].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress6")
                        {
                            item.Columns[j].ColumnName = "Contact Country";
                        }
                    }
                    if (this.ddlDeliveryAddress.SelectedValue == "1")
                    {
                        if (item.Columns[j].ColumnName == "DeliveryAddress1")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[1].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress2")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[2].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress3")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[3].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress4")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[4].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress5")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[5].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress6")
                        {
                            item.Columns[j].ColumnName = "Delivery Country";
                        }
                    }
                    if (item.Columns[j].ColumnName == "CommentDeliveryInstructions")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Comment_Delivery_Instructions");
                    }
                    if (item.Columns[j].ColumnName == "Status")
                    {
                        item.Columns[j].ColumnName = "Status";
                    }
                    if (item.Columns[j].ColumnName == "ReferenceNumber")
                    {
                        item.Columns[j].ColumnName = "Reference Number";
                    }
                    if (item.Columns[j].ColumnName == "JobNumber")
                    {
                        item.Columns[j].ColumnName = "Job Number";
                    }
                    if (item.Columns[j].ColumnName == "CarrierInformation")
                    {
                        item.Columns[j].ColumnName = "Carrier Information";
                    }
                    if (item.Columns[j].ColumnName == "SupplierQuoteNO")
                    {
                        item.Columns[j].ColumnName = "Supplier Quote#";
                    }
                    if (item.Columns[j].ColumnName == "SupplierInvoiceNo")
                    {
                        item.Columns[j].ColumnName = "Supplier Invoice#";
                    }
                    if (item.Columns[j].ColumnName == "SupplierInvoiceDate")
                    {
                        item.Columns[j].ColumnName = "Supplier InvoiceDate";
                    }
                    if (item.Columns[j].ColumnName == "DeliveryDate")
                    {
                        item.Columns[j].ColumnName = "Delivery Date";
                    }
                    if (item.Columns[j].ColumnName == "InvoiceReceived")
                    {
                        item.Columns[j].ColumnName = "Invoice Received";
                    }
                    if (item.Columns[j].ColumnName == "AccountingCode")
                    {
                        item.Columns[j].ColumnName = "Accounting Code";
                    }
                    if (item.Columns[j].ColumnName == "ItemQuantity")
                    {
                        item.Columns[j].ColumnName = "Item Quantity";
                    }
                    if (item.Columns[j].ColumnName == "ItemCode")
                    {
                        item.Columns[j].ColumnName = "Item Code";
                    }
                    if (item.Columns[j].ColumnName == "Description")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Description");
                    }
                    if (item.Columns[j].ColumnName == "PackedIn")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Packed_In");
                    }
                    if (item.Columns[j].ColumnName == "Price")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Price");
                    }
                    if (item.Columns[j].ColumnName == "Tax")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Tax");
                    }
                    if (item.Columns[j].ColumnName == "TaxValue")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Tax_Value");
                    }
                    if (item.Columns[j].ColumnName == "Notes")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Notes");
                    }
                    if (item.Columns[j].ColumnName == "GoodsReceived")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Goods_Received");
                    }
                }
            }

            DataTable item2 = new DataTable();

            item2.Columns.Add("Count");
            item2.Columns.Add("Total(Inc.Tax)");
            item2.Columns.Add("Average(Inc.Tax)");
            item2.Columns.Add("Max(Inc.Tax)");
            item2.Columns.Add("Min(Inc.Tax)");
            item2.Rows.Add(this.PurchaseCount, this.TotalPurchaseValue, this.AveragePurchaseValue, this.MaxPurchaseValue, this.MinPurchaseValue);

            DataSet ds = new DataSet();
            DataTable dtCopy = item.Copy();
            ds.Tables.Add(dtCopy);
            ds.Tables.Add(item2);
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable dt in ds.Tables)
                {
                    wb.Worksheets.Add(dt);
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Purchasereport_Excel.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        private DataTable SetPurchaseReportColumns(DataSet purchaseData)
        {
            DataSet estimateData = purchaseData;
            foreach (DataRow row in estimateData.Tables[0].Rows)
            {
                if (row.Table.Columns.Contains("CreatedDate"))
                {
                    row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("RequestedDate"))
                {
                    row["RequestedDate"] = this.objJava.Eprint_return_Date_Before_View(row["RequestedDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("SupplierInvoiceDate"))
                {
                    row["SupplierInvoiceDate"] = this.objJava.Eprint_return_Date_Before_View(row["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("DeliveryDate"))
                {
                    row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("ActivityNotes"))
                {
                    string str1 = row["ActivityNotes"].ToString().Replace("¶", "<br />").Replace("&lt;br/&gt;", "<br />");
                    this.lblActivityNotes.Text = base.Server.HtmlDecode(str1);
                    row["ActivityNotes"] = this.lblActivityNotes.Text.ToString().Replace("<br />", " ").Replace("<br/>", " ").Replace("&lt;br/&gt;", " ").Replace("&lt;br /&gt;", " ");
                }
                if (!row.Table.Columns.Contains("Description"))
                {
                    continue;
                }
                string str2 = row["Description"].ToString().Replace("<br/>", "<br />");
                this.lblDescription.Text = base.Server.HtmlDecode(str2);
                row["Description"] = this.lblDescription.Text;
            }
            DataTable item = estimateData.Tables[0];
            if (item.Columns.Contains("Purchaseid"))
            {
                item.Columns.Remove("Purchaseid");
            }

            foreach (DataColumn column in item.Columns)
            {

                for (int j = 0; j < item.Columns.Count; j++)
                {
                    if (item.Columns[j].ColumnName == "PONo")
                    {
                        item.Columns[j].ColumnName = "PO No";
                    }
                    if (item.Columns[j].ColumnName == "Company")
                    {
                        item.Columns[j].ColumnName = "Supplier Name";
                    }
                    if (item.Columns[j].ColumnName == "CreatedDate")
                    {
                        item.Columns[j].ColumnName = "Created On";
                    }
                    if (item.Columns[j].ColumnName == "RaisedBy")
                    {
                        item.Columns[j].ColumnName = "Raised By";
                    }
                    if (item.Columns[j].ColumnName == "RequestedDate")
                    {
                        item.Columns[j].ColumnName = "Purchase Date";
                    }
                    if (item.Columns[j].ColumnName == "PurchaseTotalincludingtax")
                    {
                        item.Columns[j].ColumnName = string.Concat("Total(Inc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[j].ColumnName == "PurchaseTotalexcludingtax")
                    {
                        item.Columns[j].ColumnName = string.Concat("Total(Exc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[j].ColumnName == "OrderNumber")
                    {
                        item.Columns[j].ColumnName = "Customer Order No.";
                    }
                    if (item.Columns[j].ColumnName == "JobTitle")
                    {
                        item.Columns[j].ColumnName = "Job Title";
                    }
                    if (item.Columns[j].ColumnName == "ActivityNotes")
                    {
                        item.Columns[j].ColumnName = "Activity Notes";
                    }
                    if (item.Columns[j].ColumnName == "ContactName")
                    {
                        item.Columns[j].ColumnName = "Contact Name";
                    }
                    if (item.Columns[j].ColumnName == "ContactJobTitle1")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 1";
                    }
                    if (item.Columns[j].ColumnName == "ContactJobTitle2")
                    {
                        item.Columns[j].ColumnName = "Contact Job Title 2";
                    }
                    if (item.Columns[j].ColumnName == "PaymentTerms")
                    {
                        item.Columns[j].ColumnName = "Payment Terms";
                    }
                    if (item.Columns[j].ColumnName == "ItemTitle")
                    {
                        item.Columns[j].ColumnName = "Item Title";
                    }
                    if (item.Columns[j].ColumnName == "InvoiceNumber")
                    {
                        item.Columns[j].ColumnName = "Invoice Number";
                    }
                    //Invoice Date 
                    if (item.Columns[j].ColumnName == "InvoiceDate")
                    {
                        item.Columns[j].ColumnName = "Invoice Date";
                    }
                    if (item.Columns[j].ColumnName == "ContactAddress")
                    {
                        item.Columns[j].ColumnName = "Contact Address";
                    }
                    if (item.Columns[j].ColumnName == "DeliveryAddress")
                    {
                        item.Columns[j].ColumnName = "Delivery Address";
                    }
                    if (this.ddlContactAddress.SelectedValue == "1")
                    {
                        if (item.Columns[j].ColumnName == "ContactAddress1")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[1].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress2")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[2].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress3")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[3].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress4")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[4].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress5")
                        {
                            item.Columns[j].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[5].Text.ToString());
                        }
                        else if (item.Columns[j].ColumnName == "ContactAddress6")
                        {
                            item.Columns[j].ColumnName = "Contact Country";
                        }
                    }
                    if (this.ddlDeliveryAddress.SelectedValue == "1")
                    {
                        if (item.Columns[j].ColumnName == "DeliveryAddress1")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[1].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress2")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[2].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress3")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[3].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress4")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[4].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress5")
                        {
                            item.Columns[j].ColumnName = string.Concat("Delivery ", this.Chk_addressList.Items[5].Text);
                        }
                        else if (item.Columns[j].ColumnName == "DeliveryAddress6")
                        {
                            item.Columns[j].ColumnName = "Delivery Country";
                        }
                    }
                    if (item.Columns[j].ColumnName == "CommentDeliveryInstructions")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Comment_Delivery_Instructions");
                    }
                    if (item.Columns[j].ColumnName == "Status")
                    {
                        item.Columns[j].ColumnName = "Status";
                    }
                    if (item.Columns[j].ColumnName == "ReferenceNumber")
                    {
                        item.Columns[j].ColumnName = "Reference Number";
                    }
                    if (item.Columns[j].ColumnName == "JobNumber")
                    {
                        item.Columns[j].ColumnName = "Job Number";
                    }
                    if (item.Columns[j].ColumnName == "CarrierInformation")
                    {
                        item.Columns[j].ColumnName = "Carrier Information";
                    }
                    if (item.Columns[j].ColumnName == "SupplierQuoteNO")
                    {
                        item.Columns[j].ColumnName = "Supplier Quote#";
                    }
                    if (item.Columns[j].ColumnName == "SupplierInvoiceNo")
                    {
                        item.Columns[j].ColumnName = "Supplier Invoice#";
                    }
                    if (item.Columns[j].ColumnName == "SupplierInvoiceDate")
                    {
                        item.Columns[j].ColumnName = "Supplier InvoiceDate";
                    }
                    if (item.Columns[j].ColumnName == "DeliveryDate")
                    {
                        item.Columns[j].ColumnName = "Delivery Date";
                    }
                    if (item.Columns[j].ColumnName == "InvoiceReceived")
                    {
                        item.Columns[j].ColumnName = "Invoice Received";
                    }
                    if (item.Columns[j].ColumnName == "AccountingCode")
                    {
                        item.Columns[j].ColumnName = "Accounting Code";
                    }
                    if (item.Columns[j].ColumnName == "ItemQuantity")
                    {
                        item.Columns[j].ColumnName = "Item Quantity";
                    }
                    if (item.Columns[j].ColumnName == "ItemCode")
                    {
                        item.Columns[j].ColumnName = "Item Code";
                    }
                    if (item.Columns[j].ColumnName == "Description")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Description");
                    }
                    if (item.Columns[j].ColumnName == "PackedIn")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Packed_In");
                    }
                    if (item.Columns[j].ColumnName == "Price")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Price");
                    }
                    if (item.Columns[j].ColumnName == "Tax")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Tax");
                    }
                    if (item.Columns[j].ColumnName == "TaxValue")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Tax_Value");
                    }
                    if (item.Columns[j].ColumnName == "Notes")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Notes");
                    }
                    if (item.Columns[j].ColumnName == "GoodsReceived")
                    {
                        item.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Goods_Received");
                    }
                }
            }
            return item;
        }
        protected void btnfilter_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            if (this.Session["SaveAsNew"] != null)
            {
                this.btnSaveRun.Text = "Save and Run";
            }
            else
            {
                this.btnSaveRun.Text = "Save as New";
            }
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.divminimum.Visible = false;
            this.divMaximum.Visible = false;
            this.divAverage.Visible = false;
            this.divTotal.Visible = false;
            this.divCount.Visible = false;
            this.divaggregate.Visible = false;
            this.divAggl.Visible = false;
            this.usrPaging.Visible = false;
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetSelect();", true);
        }

        public void btngo_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.txt1.Text != "")
            {
                try
                {
                    this.paging_OnPageChange(Convert.ToInt32(this.txt1.Text));
                }
                catch
                {
                    this.paging_OnPageChange(Convert.ToInt32("1"));
                }
            }
        }

        public void btnRunReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.Session["DeleteMsg"] = null;
                this.btnUpdateExisting.Visible = false;
                this.btnRunReport.Visible = true;
                this.btnSaveRun.Text = "Save and Run";
                int num = 0;
                this.div_showfilters.Style.Add("display", "none");
                this.divusrReportsave.Style.Add("display", "none");
                this.divtab.Visible = false;
                this.btnfilter.Visible = true;
                if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("purchase", "exportreport").Trim().ToLower() != "false")
                {
                    this.btnExport.Visible = true;
                }
                else
                {
                    this.btnExport.Visible = false;
                }
                this.divtoolbar.Visible = true;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                int num1 = 0;
                while (num1 < this.chkColumns.Items.Count)
                {
                    if (!this.chkColumns.Items[num1].Selected)
                    {
                        num1++;
                    }
                    else
                    {
                        num = 1;
                        break;
                    }
                }
                if (num != 1)
                {
                    this.GridEstReport.Visible = false;
                    this.div_Total.Visible = false;
                    this.btnExport.Visible = false;
                    this.txt1.Visible = false;
                    this.btngo.Visible = false;
                    this.divtoolbar.Visible = true;
                }
                else
                {
                    DataSet estimateData = this.GetEstimateData(1);
                    if (this.rdodetail.Checked || this.rdosummary.Checked)
                    {
                        this.GridEstReport.Visible = false;
                        this.usrPaging.Visible = false;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.div_Total.Visible = true;
                    }
                    else if (estimateData.Tables.Count <= 0)
                    {
                        this.pnlEmptyRecords.Visible = true;
                        this.GridEstReport.Visible = false;
                        this.div_Total.Visible = true;
                        this.btnExport.Visible = false;
                        this.divtoolbar.Visible = true;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.divaggregate.Visible = false;
                        this.divAggl.Visible = false;
                        this.lblTotalRecords.Text = "0";
                    }
                    else if (estimateData.Tables[0].Rows.Count == 0)
                    {
                        this.pnlEmptyRecords.Visible = true;
                        this.GridEstReport.Visible = false;
                        this.div_Total.Visible = true;
                        this.btnExport.Visible = false;
                        this.divtoolbar.Visible = true;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.divaggregate.Visible = false;
                        this.divAggl.Visible = false;
                    }
                    else if (Convert.ToInt32(estimateData.Tables[1].Rows[0][0].ToString()) > 100)
                    {
                        if (!this.rdosummary.Checked)
                        {
                            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                        }
                        this.GridEstReport.Visible = true;
                        this.div_Total.Visible = false;
                        this.pnlEmptyRecords.Visible = false;
                        DataTable dt = SetPurchaseReportColumns(estimateData);
                        this.GridEstReport.DataSource = dt;
                        //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                        this.GridEstReport.DataBind();
                        this.usrPaging.Visible = false;
                        pagingreport.intCurrentPage = this.PageNumber;
                        pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                        this.usrPaging.CreatePaging();
                        //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                        this.CallPagingBtn_ScrollGrid(this.usrPaging);
                    }
                    else
                    {
                        if (!this.rdosummary.Checked)
                        {
                            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                        }
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                        ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                        this.GridEstReport.Visible = true;
                        this.div_Total.Visible = false;
                        this.pnlEmptyRecords.Visible = false;
                        DataTable dt = SetPurchaseReportColumns(estimateData);
                        this.GridEstReport.DataSource = dt;
                        //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                        this.GridEstReport.DataBind();
                        this.usrPaging.Visible = false;
                        pagingreport.intCurrentPage = this.PageNumber;
                        pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                        this.usrPaging.CreatePaging();
                        //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                        this.CallPagingBtn_ScrollGrid(this.usrPaging);
                    }
                }
            }
            catch
            {
            }
        }

        public void btnSaveRun_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.SaveReports("Save");
            this.RunReportOnClick();
        }

        public void btnUpdateExisting_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.Session["SaveAsNew"] = "SaveAsNew";
            if (this.hdn_reportID.Value == "")
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("PC_GetReportID", this.objJava.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
                sqlCommand.Parameters.AddWithValue("@Pagename", "purchase");
                (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
                this.objJava.closeConnection();
                foreach (DataRow row in dataTable.Rows)
                {
                    this.hdn_reportID.Value = row["ReportID"].ToString();
                }
            }
            this.SaveReports("Update");
            this.RunReportOnClick();
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            LinkButton linkButton = (LinkButton)usrPagingID.FindControl("lnkFirst");
            linkButton.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton1 = (LinkButton)usrPagingID.FindControl("lnkSecond");
            linkButton1.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton2 = (LinkButton)usrPagingID.FindControl("lnkThird");
            linkButton2.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton3 = (LinkButton)usrPagingID.FindControl("lnkFour");
            linkButton3.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton4 = (LinkButton)usrPagingID.FindControl("lnkFive");
            linkButton4.OnClientClick = "javascript:CheckGrid();";
            if (this.txt1.Text == linkButton.Text)
            {
                linkButton.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton1.Text)
            {
                linkButton1.Font.Bold = true;
                linkButton.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton2.Text)
            {
                linkButton2.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton3.Text)
            {
                linkButton3.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton4.Text)
            {
                linkButton4.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton.Font.Bold = false;
            }
            LinkButton linkButton5 = (LinkButton)usrPagingID.FindControl("lnkstart");
            LinkButton linkButton6 = (LinkButton)usrPagingID.FindControl("lnkPrev");
            LinkButton linkButton7 = (LinkButton)usrPagingID.FindControl("lnkNext");
            LinkButton linkButton8 = (LinkButton)usrPagingID.FindControl("lnkEnd");
            if (this.txt1.Text != "")
            {
                if (Convert.ToInt16(this.txt1.Text) >= 4)
                {
                    linkButton5.Enabled = true;
                    linkButton6.Enabled = true;
                }
                if (Convert.ToInt16(this.txt1.Text) >= 1)
                {
                    linkButton.Enabled = true;
                }
            }
            //if (this.GridEstReport.PageIndex == 1 || this.GridEstReport.PageIndex == 0)
            //{
            //    linkButton5.Enabled = false;
            //    linkButton6.Enabled = false;
            //}
            if (linkButton5.Enabled)
            {
                linkButton5.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton5.OnClientClick = "javascript:Disablelnk();";
            }
            if (linkButton6.Enabled)
            {
                linkButton6.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton6.OnClientClick = "javascript:Disablelnk();";
            }
            if (linkButton7.Enabled)
            {
                linkButton7.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton7.OnClientClick = "javascript:Disablelnk();";
            }
            if (!linkButton8.Enabled)
            {
                linkButton8.OnClientClick = "javascript:Disablelnk();";
                return;
            }
            linkButton8.OnClientClick = "javascript:showWaitMessage();";
        }

        public string CurrentFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            string str = string.Concat(dateTime.ToString(), ",", dateTime1.ToString());
            return str;
        }

        public string CurrentMonth()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime[] dateTimeArray = new DateTime[] { new DateTime(dateTime.Year, dateTime.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTimeArray[1] = dateTime2.AddDays(-1);
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string CurrentQuater()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            DateTime dateTime1 = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime1.Month;
            int num = dateTime.Month;
            DateTime dateTime2 = new DateTime();
            dateTime2 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int month1 = dateTime2.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (month1 == 1)
            {
                if (month == 1 || month == 2 || month == 3)
                {
                    int num1 = dateTime1.Month;
                    if (num1 == 1)
                    {
                        int num2 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num2, DateTime.DaysInMonth(dateTime1.Year, num2));
                    }
                    else if (num1 == 2)
                    {
                        num1--;
                        int num3 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num3, DateTime.DaysInMonth(dateTime1.Year, num3));
                    }
                    else if (num1 == 3)
                    {
                        num1 = num1 - 2;
                        int num4 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num4, DateTime.DaysInMonth(dateTime1.Year, num4));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month2 = dateTime1.Month;
                    if (month2 == 4)
                    {
                        int num5 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num5, DateTime.DaysInMonth(dateTime1.Year, num5));
                    }
                    else if (month2 == 5)
                    {
                        month2--;
                        int num6 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num6, DateTime.DaysInMonth(dateTime1.Year, num6));
                    }
                    else if (month2 == 6)
                    {
                        month2 = month2 - 2;
                        int num7 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num7, DateTime.DaysInMonth(dateTime1.Year, num7));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month3 = dateTime1.Month;
                    if (month3 == 7)
                    {
                        int num8 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num8, DateTime.DaysInMonth(dateTime1.Year, num8));
                    }
                    else if (month3 == 8)
                    {
                        month3--;
                        int num9 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num9, DateTime.DaysInMonth(dateTime1.Year, num9));
                    }
                    else if (month3 == 9)
                    {
                        month3 = month3 - 2;
                        int num10 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num10, DateTime.DaysInMonth(dateTime1.Year, num10));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month4 = dateTime1.Month;
                    if (month4 == 10)
                    {
                        int num11 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num11, DateTime.DaysInMonth(dateTime1.Year, num11));
                    }
                    if (month4 == 11)
                    {
                        month4--;
                        int num12 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num12, DateTime.DaysInMonth(dateTime1.Year, num12));
                    }
                    else if (month4 == 12)
                    {
                        month4 = month4 - 2;
                        int num13 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num13, DateTime.DaysInMonth(dateTime1.Year, num13));
                    }
                }
            }
            if (month1 == 2)
            {
                if (month == 2 || month == 3 || month == 4)
                {
                    int month5 = dateTime1.Month;
                    if (month5 == 2)
                    {
                        int num14 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num14, DateTime.DaysInMonth(dateTime1.Year, num14));
                    }
                    else if (month5 == 3)
                    {
                        month5--;
                        int num15 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num15, DateTime.DaysInMonth(dateTime1.Year, num15));
                    }
                    else if (month5 == 4)
                    {
                        month5 = month5 - 2;
                        int num16 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num16, DateTime.DaysInMonth(dateTime1.Year, num16));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month6 = dateTime1.Month;
                    if (month6 == 5)
                    {
                        int num17 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num17, DateTime.DaysInMonth(dateTime1.Year, num17));
                    }
                    else if (month6 == 6)
                    {
                        month6--;
                        int num18 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num18, DateTime.DaysInMonth(dateTime1.Year, num18));
                    }
                    else if (month6 == 7)
                    {
                        month6 = month6 - 2;
                        int num19 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num19, DateTime.DaysInMonth(dateTime1.Year, num19));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month7 = dateTime1.Month;
                    if (month7 == 8)
                    {
                        int num20 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num20, DateTime.DaysInMonth(dateTime1.Year, num20));
                    }
                    else if (month7 == 9)
                    {
                        month7--;
                        int num21 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num21, DateTime.DaysInMonth(dateTime1.Year, num21));
                    }
                    else if (month7 == 10)
                    {
                        month7 = month7 - 2;
                        int num22 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num22, DateTime.DaysInMonth(dateTime1.Year, num22));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month8 = dateTime1.Month;
                    if (month8 == 11)
                    {
                        int num23 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num23, DateTime.DaysInMonth(dateTime1.Year, num23));
                    }
                    if (month8 == 12)
                    {
                        month8--;
                        int num24 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num24, DateTime.DaysInMonth(dateTime1.Year, num24));
                    }
                    else if (month8 == 1)
                    {
                        month8 = month8 + 10;
                        int num25 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num25, DateTime.DaysInMonth(dateTime1.Year, num25));
                    }
                }
            }
            if (month1 == 3)
            {
                if (month == 3 || month == 4 || month == 5)
                {
                    int month9 = dateTime1.Month;
                    if (month9 == 3)
                    {
                        int num26 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num26, DateTime.DaysInMonth(dateTime1.Year, num26));
                    }
                    else if (month9 == 4)
                    {
                        month9--;
                        int num27 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num27, DateTime.DaysInMonth(dateTime1.Year, num27));
                    }
                    else if (month9 == 5)
                    {
                        month9 = month9 - 2;
                        int num28 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num28, DateTime.DaysInMonth(dateTime1.Year, num28));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month10 = dateTime1.Month;
                    if (month10 == 6)
                    {
                        int num29 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num29, DateTime.DaysInMonth(dateTime1.Year, num29));
                    }
                    else if (month10 == 7)
                    {
                        month10--;
                        int num30 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num30, DateTime.DaysInMonth(dateTime1.Year, num30));
                    }
                    else if (month10 == 8)
                    {
                        month10 = month10 - 2;
                        int num31 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num31, DateTime.DaysInMonth(dateTime1.Year, num31));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month11 = dateTime1.Month;
                    if (month11 == 9)
                    {
                        int num32 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num32, DateTime.DaysInMonth(dateTime1.Year, num32));
                    }
                    else if (month11 == 10)
                    {
                        month11--;
                        int num33 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num33, DateTime.DaysInMonth(dateTime1.Year, num33));
                    }
                    else if (month11 == 11)
                    {
                        month11 = month11 - 2;
                        int num34 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num34, DateTime.DaysInMonth(dateTime1.Year, num34));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month12 = dateTime1.Month;
                    if (month12 == 12)
                    {
                        int num35 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num35, DateTime.DaysInMonth(dateTime1.Year, num35));
                    }
                    if (month12 == 1)
                    {
                        month12 = month12 + 11;
                        int num36 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num36, DateTime.DaysInMonth(dateTime1.Year, num36));
                    }
                    else if (month12 == 2)
                    {
                        month12 = month12 + 10;
                        int num37 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num37, DateTime.DaysInMonth(dateTime1.Year, num37));
                    }
                }
            }
            if (month1 == 4)
            {
                if (month == 4 || month == 5 || month == 6)
                {
                    int month13 = dateTime1.Month;
                    if (month13 == 4)
                    {
                        int num38 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num38, DateTime.DaysInMonth(dateTime1.Year, num38));
                    }
                    else if (month13 == 5)
                    {
                        month13--;
                        int num39 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num39, DateTime.DaysInMonth(dateTime1.Year, num39));
                    }
                    else if (month13 == 6)
                    {
                        month13 = month13 - 2;
                        int num40 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num40, DateTime.DaysInMonth(dateTime1.Year, num40));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month14 = dateTime1.Month;
                    if (month14 == 7)
                    {
                        int num41 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num41, DateTime.DaysInMonth(dateTime1.Year, num41));
                    }
                    else if (month14 == 8)
                    {
                        month14--;
                        int num42 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num42, DateTime.DaysInMonth(dateTime1.Year, num42));
                    }
                    else if (month14 == 9)
                    {
                        month14 = month14 - 2;
                        int num43 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num43, DateTime.DaysInMonth(dateTime1.Year, num43));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month15 = dateTime1.Month;
                    if (month15 == 10)
                    {
                        int num44 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num44, DateTime.DaysInMonth(dateTime1.Year, num44));
                    }
                    else if (month15 == 11)
                    {
                        month15--;
                        int num45 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num45, DateTime.DaysInMonth(dateTime1.Year, num45));
                    }
                    else if (month15 == 12)
                    {
                        month15 = month15 - 2;
                        int num46 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num46, DateTime.DaysInMonth(dateTime1.Year, num46));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month16 = dateTime1.Month;
                    if (month16 == 1)
                    {
                        int num47 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num47, DateTime.DaysInMonth(dateTime1.Year, num47));
                    }
                    if (month16 == 2)
                    {
                        month16--;
                        int num48 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num48, DateTime.DaysInMonth(dateTime1.Year, num48));
                    }
                    else if (month16 == 3)
                    {
                        month16 = month16 - 2;
                        int num49 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num49, DateTime.DaysInMonth(dateTime1.Year, num49));
                    }
                }
            }
            if (month1 == 5)
            {
                if (month == 5 || month == 6 || month == 7)
                {
                    int month17 = dateTime1.Month;
                    if (month17 == 5)
                    {
                        int num50 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num50, DateTime.DaysInMonth(dateTime1.Year, num50));
                    }
                    else if (month17 == 6)
                    {
                        month17--;
                        int num51 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num51, DateTime.DaysInMonth(dateTime1.Year, num51));
                    }
                    else if (month17 == 7)
                    {
                        month17 = month17 - 2;
                        int num52 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num52, DateTime.DaysInMonth(dateTime1.Year, num52));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month18 = dateTime1.Month;
                    if (month18 == 8)
                    {
                        int num53 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num53, DateTime.DaysInMonth(dateTime1.Year, num53));
                    }
                    else if (month18 == 9)
                    {
                        month18--;
                        int num54 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num54, DateTime.DaysInMonth(dateTime1.Year, num54));
                    }
                    else if (month18 == 10)
                    {
                        month18 = month18 - 2;
                        int num55 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num55, DateTime.DaysInMonth(dateTime1.Year, num55));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month19 = dateTime1.Month;
                    if (month19 == 11)
                    {
                        int num56 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num56, DateTime.DaysInMonth(dateTime1.Year, num56));
                    }
                    else if (month19 == 12)
                    {
                        month19--;
                        int num57 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num57, DateTime.DaysInMonth(dateTime1.Year, num57));
                    }
                    else if (month19 == 1)
                    {
                        month19 = month19 + 10;
                        int num58 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num58, DateTime.DaysInMonth(dateTime1.Year, num58));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month20 = dateTime1.Month;
                    if (month20 == 2)
                    {
                        int num59 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num59, DateTime.DaysInMonth(dateTime1.Year, num59));
                    }
                    if (month20 == 3)
                    {
                        month20--;
                        int num60 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num60, DateTime.DaysInMonth(dateTime1.Year, num60));
                    }
                    else if (month20 == 4)
                    {
                        month20 = month20 - 2;
                        int num61 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num61, DateTime.DaysInMonth(dateTime1.Year, num61));
                    }
                }
            }
            if (month1 == 6)
            {
                if (month == 6 || month == 7 || month == 8)
                {
                    int month21 = dateTime1.Month;
                    if (month21 == 6)
                    {
                        int num62 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num62, DateTime.DaysInMonth(dateTime1.Year, num62));
                    }
                    else if (month21 == 7)
                    {
                        month21--;
                        int num63 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num63, DateTime.DaysInMonth(dateTime1.Year, num63));
                    }
                    else if (month21 == 8)
                    {
                        month21 = month21 - 2;
                        int num64 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num64, DateTime.DaysInMonth(dateTime1.Year, num64));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month22 = dateTime1.Month;
                    if (month22 == 9)
                    {
                        int num65 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num65, DateTime.DaysInMonth(dateTime1.Year, num65));
                    }
                    else if (month22 == 10)
                    {
                        month22--;
                        int num66 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num66, DateTime.DaysInMonth(dateTime1.Year, num66));
                    }
                    else if (month22 == 11)
                    {
                        month22 = month22 - 2;
                        int num67 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num67, DateTime.DaysInMonth(dateTime1.Year, num67));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month23 = dateTime1.Month;
                    if (month23 == 12)
                    {
                        int num68 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num68, DateTime.DaysInMonth(dateTime1.Year, num68));
                    }
                    else if (month23 == 1)
                    {
                        month23 = month23 + 11;
                        int num69 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num69, DateTime.DaysInMonth(dateTime1.Year, num69));
                    }
                    else if (month23 == 2)
                    {
                        month23 = month23 + 10;
                        int num70 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num70, DateTime.DaysInMonth(dateTime1.Year, num70));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month24 = dateTime1.Month;
                    if (month24 == 3)
                    {
                        int num71 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num71, DateTime.DaysInMonth(dateTime1.Year, num71));
                    }
                    if (month24 == 4)
                    {
                        month24--;
                        int num72 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num72, DateTime.DaysInMonth(dateTime1.Year, num72));
                    }
                    else if (month24 == 5)
                    {
                        month24 = month24 - 2;
                        int num73 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num73, DateTime.DaysInMonth(dateTime1.Year, num73));
                    }
                }
            }
            if (month1 == 7)
            {
                if (month == 7 || month == 8 || month == 9)
                {
                    int month25 = dateTime1.Month;
                    if (month25 == 7)
                    {
                        int num74 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num74, DateTime.DaysInMonth(dateTime1.Year, num74));
                    }
                    else if (month25 == 8)
                    {
                        month25--;
                        int num75 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num75, DateTime.DaysInMonth(dateTime1.Year, num75));
                    }
                    else if (month25 == 9)
                    {
                        month25 = month25 - 2;
                        int num76 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num76, DateTime.DaysInMonth(dateTime1.Year, num76));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month26 = dateTime1.Month;
                    if (month26 == 10)
                    {
                        int num77 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num77, DateTime.DaysInMonth(dateTime1.Year, num77));
                    }
                    else if (month26 == 11)
                    {
                        month26--;
                        int num78 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num78, DateTime.DaysInMonth(dateTime1.Year, num78));
                    }
                    else if (month26 == 12)
                    {
                        month26 = month26 - 2;
                        int num79 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num79, DateTime.DaysInMonth(dateTime1.Year, num79));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month27 = dateTime1.Month;
                    if (month27 == 1)
                    {
                        int num80 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num80, DateTime.DaysInMonth(dateTime1.Year, num80));
                    }
                    else if (month27 == 2)
                    {
                        month27--;
                        int num81 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num81, DateTime.DaysInMonth(dateTime1.Year, num81));
                    }
                    else if (month27 == 3)
                    {
                        month27 = month27 - 2;
                        int num82 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num82, DateTime.DaysInMonth(dateTime1.Year, num82));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month28 = dateTime1.Month;
                    if (month28 == 4)
                    {
                        int num83 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num83, DateTime.DaysInMonth(dateTime1.Year, num83));
                    }
                    if (month28 == 5)
                    {
                        month28--;
                        int num84 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num84, DateTime.DaysInMonth(dateTime1.Year, num84));
                    }
                    else if (month28 == 6)
                    {
                        month28 = month28 - 2;
                        int num85 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num85, DateTime.DaysInMonth(dateTime1.Year, num85));
                    }
                }
            }
            if (month1 == 8)
            {
                if (month == 8 || month == 9 || month == 10)
                {
                    int month29 = dateTime1.Month;
                    if (month29 == 8)
                    {
                        int num86 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num86, DateTime.DaysInMonth(dateTime1.Year, num86));
                    }
                    else if (month29 == 9)
                    {
                        month29--;
                        int num87 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num87, DateTime.DaysInMonth(dateTime1.Year, num87));
                    }
                    else if (month29 == 10)
                    {
                        month29 = month29 - 2;
                        int num88 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num88, DateTime.DaysInMonth(dateTime1.Year, num88));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month30 = dateTime1.Month;
                    if (month30 == 11)
                    {
                        int num89 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num89, DateTime.DaysInMonth(dateTime1.Year, num89));
                    }
                    else if (month30 == 12)
                    {
                        month30--;
                        int num90 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num90, DateTime.DaysInMonth(dateTime1.Year, num90));
                    }
                    else if (month30 == 1)
                    {
                        month30 = month30 + 10;
                        int num91 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num91, DateTime.DaysInMonth(dateTime1.Year, num91));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month31 = dateTime1.Month;
                    if (month31 == 2)
                    {
                        int num92 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num92, DateTime.DaysInMonth(dateTime1.Year, num92));
                    }
                    else if (month31 == 3)
                    {
                        month31--;
                        int num93 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num93, DateTime.DaysInMonth(dateTime1.Year, num93));
                    }
                    else if (month31 == 4)
                    {
                        month31 = month31 - 2;
                        int num94 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num94, DateTime.DaysInMonth(dateTime1.Year, num94));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month32 = dateTime1.Month;
                    if (month32 == 5)
                    {
                        int num95 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num95, DateTime.DaysInMonth(dateTime1.Year, num95));
                    }
                    if (month32 == 6)
                    {
                        month32--;
                        int num96 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num96, DateTime.DaysInMonth(dateTime1.Year, num96));
                    }
                    else if (month32 == 7)
                    {
                        month32 = month32 - 2;
                        int num97 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num97, DateTime.DaysInMonth(dateTime1.Year, num97));
                    }
                }
            }
            if (month1 == 9)
            {
                if (month == 9 || month == 10 || month == 11)
                {
                    int month33 = dateTime1.Month;
                    if (month33 == 9)
                    {
                        int num98 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num98, DateTime.DaysInMonth(dateTime1.Year, num98));
                    }
                    else if (month33 == 10)
                    {
                        month33--;
                        int num99 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num99, DateTime.DaysInMonth(dateTime1.Year, num99));
                    }
                    else if (month33 == 11)
                    {
                        month33 = month33 - 2;
                        int num100 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num100, DateTime.DaysInMonth(dateTime1.Year, num100));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month34 = dateTime1.Month;
                    if (month34 == 12)
                    {
                        int num101 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num101, DateTime.DaysInMonth(dateTime1.Year, num101));
                    }
                    else if (month34 == 1)
                    {
                        month34 = month34 + 11;
                        int num102 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num102, DateTime.DaysInMonth(dateTime1.Year, num102));
                    }
                    else if (month34 == 2)
                    {
                        month34 = month34 + 10;
                        int num103 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num103, DateTime.DaysInMonth(dateTime1.Year, num103));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month35 = dateTime1.Month;
                    if (month35 == 3)
                    {
                        int num104 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num104, DateTime.DaysInMonth(dateTime1.Year, num104));
                    }
                    else if (month35 == 4)
                    {
                        month35--;
                        int num105 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num105, DateTime.DaysInMonth(dateTime1.Year, num105));
                    }
                    else if (month35 == 5)
                    {
                        month35 = month35 - 2;
                        int num106 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num106, DateTime.DaysInMonth(dateTime1.Year, num106));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month36 = dateTime1.Month;
                    if (month36 == 6)
                    {
                        int num107 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num107, DateTime.DaysInMonth(dateTime1.Year, num107));
                    }
                    if (month36 == 7)
                    {
                        month36--;
                        int num108 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num108, DateTime.DaysInMonth(dateTime1.Year, num108));
                    }
                    else if (month36 == 8)
                    {
                        month36 = month36 - 2;
                        int num109 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num109, DateTime.DaysInMonth(dateTime1.Year, num109));
                    }
                }
            }
            if (month1 == 10)
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    int month37 = dateTime1.Month;
                    if (month37 == 10)
                    {
                        int num110 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num110, DateTime.DaysInMonth(dateTime1.Year, num110));
                    }
                    else if (month37 == 11)
                    {
                        month37--;
                        int num111 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num111, DateTime.DaysInMonth(dateTime1.Year, num111));
                    }
                    else if (month37 == 12)
                    {
                        month37 = month37 - 2;
                        int num112 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num112, DateTime.DaysInMonth(dateTime1.Year, num112));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month38 = dateTime1.Month;
                    if (month38 == 1)
                    {
                        int num113 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num113, DateTime.DaysInMonth(dateTime1.Year, num113));
                    }
                    else if (month38 == 2)
                    {
                        month38--;
                        int num114 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num114, DateTime.DaysInMonth(dateTime1.Year, num114));
                    }
                    else if (month38 == 3)
                    {
                        month38 = month38 - 2;
                        int num115 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num115, DateTime.DaysInMonth(dateTime1.Year, num115));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month39 = dateTime1.Month;
                    if (month39 == 4)
                    {
                        int num116 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num116, DateTime.DaysInMonth(dateTime1.Year, num116));
                    }
                    else if (month39 == 5)
                    {
                        month39--;
                        int num117 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num117, DateTime.DaysInMonth(dateTime1.Year, num117));
                    }
                    else if (month39 == 6)
                    {
                        month39 = month39 - 2;
                        int num118 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num118, DateTime.DaysInMonth(dateTime1.Year, num118));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month40 = dateTime1.Month;
                    if (month40 == 7)
                    {
                        int num119 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num119, DateTime.DaysInMonth(dateTime1.Year, num119));
                    }
                    if (month40 == 8)
                    {
                        month40--;
                        int num120 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num120, DateTime.DaysInMonth(dateTime1.Year, num120));
                    }
                    else if (month40 == 9)
                    {
                        month40 = month40 - 2;
                        int num121 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num121, DateTime.DaysInMonth(dateTime1.Year, num121));
                    }
                }
            }
            if (month1 == 11)
            {
                if (month == 11 || month == 12 || month == 1)
                {
                    int month41 = dateTime1.Month;
                    if (month41 == 11)
                    {
                        int num122 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num122, DateTime.DaysInMonth(dateTime1.Year, num122));
                    }
                    else if (month41 == 12)
                    {
                        month41--;
                        int num123 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num123, DateTime.DaysInMonth(dateTime1.Year, num123));
                    }
                    else if (month41 == 1)
                    {
                        month41 = month41 + 10;
                        int num124 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num124, DateTime.DaysInMonth(dateTime1.Year, num124));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month42 = dateTime1.Month;
                    if (month42 == 2)
                    {
                        int num125 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num125, DateTime.DaysInMonth(dateTime1.Year, num125));
                    }
                    else if (month42 == 3)
                    {
                        month42--;
                        int num126 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num126, DateTime.DaysInMonth(dateTime1.Year, num126));
                    }
                    else if (month42 == 4)
                    {
                        month42 = month42 - 2;
                        int num127 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num127, DateTime.DaysInMonth(dateTime1.Year, num127));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month43 = dateTime1.Month;
                    if (month43 == 5)
                    {
                        int num128 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num128, DateTime.DaysInMonth(dateTime1.Year, num128));
                    }
                    else if (month43 == 6)
                    {
                        month43--;
                        int num129 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num129, DateTime.DaysInMonth(dateTime1.Year, num129));
                    }
                    else if (month43 == 7)
                    {
                        month43 = month43 - 2;
                        int num130 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num130, DateTime.DaysInMonth(dateTime1.Year, num130));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month44 = dateTime1.Month;
                    if (month44 == 8)
                    {
                        int num131 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num131, DateTime.DaysInMonth(dateTime1.Year, num131));
                    }
                    if (month44 == 9)
                    {
                        month44--;
                        int num132 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num132, DateTime.DaysInMonth(dateTime1.Year, num132));
                    }
                    else if (month44 == 10)
                    {
                        month44 = month44 - 2;
                        int num133 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num133, DateTime.DaysInMonth(dateTime1.Year, num133));
                    }
                }
            }
            if (month1 == 12)
            {
                if (month == 12 || month == 1 || month == 2)
                {
                    int month45 = dateTime1.Month;
                    if (month45 == 12)
                    {
                        int num134 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num134, DateTime.DaysInMonth(dateTime1.Year, num134));
                    }
                    else if (month45 == 1)
                    {
                        month45 = month45 + 11;
                        int num135 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num135, DateTime.DaysInMonth(dateTime1.Year, num135));
                    }
                    else if (month45 == 2)
                    {
                        month45 = month45 + 10;
                        int num136 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num136, DateTime.DaysInMonth(dateTime1.Year, num136));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month46 = dateTime1.Month;
                    if (month46 == 3)
                    {
                        int num137 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num137, DateTime.DaysInMonth(dateTime1.Year, num137));
                    }
                    else if (month46 == 4)
                    {
                        month46--;
                        int num138 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num138, DateTime.DaysInMonth(dateTime1.Year, num138));
                    }
                    else if (month46 == 5)
                    {
                        month46 = month46 - 2;
                        int num139 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num139, DateTime.DaysInMonth(dateTime1.Year, num139));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month47 = dateTime1.Month;
                    if (month47 == 6)
                    {
                        int num140 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num140, DateTime.DaysInMonth(dateTime1.Year, num140));
                    }
                    else if (month47 == 7)
                    {
                        month47--;
                        int num141 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num141, DateTime.DaysInMonth(dateTime1.Year, num141));
                    }
                    else if (month47 == 8)
                    {
                        month47 = month47 - 2;
                        int num142 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num142, DateTime.DaysInMonth(dateTime1.Year, num142));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month48 = dateTime1.Month;
                    if (month48 == 9)
                    {
                        int num143 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num143, DateTime.DaysInMonth(dateTime1.Year, num143));
                    }
                    if (month48 == 10)
                    {
                        month48--;
                        int num144 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num144, DateTime.DaysInMonth(dateTime1.Year, num144));
                    }
                    else if (month48 == 11)
                    {
                        month48 = month48 - 2;
                        int num145 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num145, DateTime.DaysInMonth(dateTime1.Year, num145));
                    }
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        private void dgGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    e.Item.Cells[0].Visible = false;
                    e.Item.Cells[i].Style.Add("border-bottom", "1px solid #BE1333");
                    if (e.Item.Cells[i].Text.ToLower() == "pono")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Purchase_Number");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "createddate")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Created_On");
                        this.cellvalue_createdOn = i;
                        this.flag_createdOn = "true";
                        e.Item.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "requesteddate")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Purchase_Date");
                        this.cellvalue_reqDate = i;
                        this.flag_reqDate = "true";
                        e.Item.Cells[this.cellvalue_reqDate].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "raisedby")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Raised_By");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "supplierinvoicedate")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Supplier_Invoice_Date");
                        this.cellvalue_supplierinvoicedate = i;
                        this.flag_supplierinvoicedate = "true";
                        e.Item.Cells[this.cellvalue_supplierinvoicedate].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "deliverydate")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
                        this.cellvalue_deliverydate = i;
                        this.flag_deliverydate = "true";
                        e.Item.Cells[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "invoicedate")
                    {
                        e.Item.Cells[i].Text = this.objLangClass.GetLanguageConversion("Invoice_Date");
                        this.cellvalue_invoicedate = i;
                        this.flag_invoicedate = "true";
                        e.Item.Cells[this.cellvalue_invoicedate].Attributes.Add("align", "center");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate1")
                    {

                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate2")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate3")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate4")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "customdate5")
                    {
                        e.Item.Cells[i].Text = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        e.Item.Cells[i].Attributes.Add("align", "left");
                    }
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    e.Item.Cells[j].Width = Unit.Percentage(20);
                    e.Item.Cells[j].Attributes.Add("align", "left");
                    e.Item.Cells[j].Style.Add("border-bottom", "solid thin silver");
                    e.Item.Cells[j].Style.Add("color", "#000000");
                    e.Item.Cells[j].Style.Add("font", "10px Arial");
                    e.Item.Cells[j].Style.Add("height", "50px");
                    e.Item.Cells[0].Visible = false;
                    if (this.flag_reqDate == "true")
                    {
                        e.Item.Cells[this.cellvalue_reqDate].Attributes.Add("align", "center");
                    }
                    if (this.flag_createdOn == "true")
                    {
                        e.Item.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    }
                }
            }
        }

        public string Get2digit(string ddd)
        {
            string str;
            str = (ddd.Length != 1 ? ddd : string.Concat("0", ddd));
            return str;
        }

        private void getAddressValue_FromSettings()
        {
            foreach (DataRow row in CompanyBasePage.selectall_AddressValue_FromSetting(this.CompanyID).Tables[0].Rows)
            {
                if (row["AddressKey"].ToString().ToLower() == "address1")
                {
                    if (row["Value"].ToString() != "")
                    {
                        this.Chk_addressList.Items[1].Text = row["Value"].ToString();
                    }
                    else
                    {
                        this.Chk_addressList.Items[1].Text = "Address 1";
                    }
                }
                if (row["AddressKey"].ToString().ToLower() == "address2")
                {
                    if (row["Value"].ToString() != "")
                    {
                        this.Chk_addressList.Items[2].Text = row["Value"].ToString();
                    }
                    else
                    {
                        this.Chk_addressList.Items[2].Text = "Address 2";
                    }
                }
                if (row["AddressKey"].ToString().ToLower() == "address3")
                {
                    if (row["Value"].ToString() != "")
                    {
                        this.Chk_addressList.Items[3].Text = row["Value"].ToString();
                    }
                    else
                    {
                        this.Chk_addressList.Items[3].Text = "Address 3";
                    }
                }
                if (row["AddressKey"].ToString().ToLower() == "address4")
                {
                    if (row["Value"].ToString() != "")
                    {
                        this.Chk_addressList.Items[4].Text = row["Value"].ToString();
                    }
                    else
                    {
                        this.Chk_addressList.Items[4].Text = "Address 4";
                    }
                }
                if (row["AddressKey"].ToString().ToLower() != "address5")
                {
                    continue;
                }
                if (row["Value"].ToString() != "")
                {
                    this.Chk_addressList.Items[5].Text = row["Value"].ToString();
                }
                else
                {
                    this.Chk_addressList.Items[5].Text = "Address 5";
                }
            }
        }

        private DataSet GetEstimateData(int PageNumber)
        {
            object[] companyID;
            string[] str;
            DateTime now;
            char[] chrArray;
            int count;
            DataSet dataSet = new DataSet();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                string empty4 = string.Empty;
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                string str6 = string.Empty;
                string empty7 = string.Empty;
                for (int i = 0; i < this.chkColumns.Items.Count; i++)
                {
                    if (this.chkColumns.Items[i].Selected)
                    {
                        if (this.chkColumns.Items[i].Value == "PONO")
                        {
                            stringBuilder.Append("a.purchaseid,a.PONo");
                        }
                        else if (this.chkColumns.Items[i].Value == "CreatedDate")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate");
                            }
                            else
                            {
                                stringBuilder.Append(",CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Company")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(ltrim(b.ClientName),'%22','\"'),'%27%27',''''),'%27','''') as Company");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(ltrim(b.ClientName),'%22','\"'),'%27%27',''''),'%27','''') as Company");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ContactName")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(isnull(ct.FirstName +' '+ ct.LastName,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactName");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(isnull(ct.FirstName +' '+ ct.LastName,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactName");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ContactJobTitle1")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(ct.JobTitle,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle1");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(ct.JobTitle,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle1");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ContactJobTitle2")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(ct.JobTitle2,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle2");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(ct.JobTitle2,'%22','\"'),'%27%27',''''),'%27','''') as ContactJobTitle2");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "PaymentTerms")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(ISNULL((SELECT Name FROM tb_PaymentTerm WHERE PaymentTermID = b.PaymentTerms AND isDeleted = 0), ''),'%22','\"'),'%27%27',''''),'%27','''') as PaymentTerms");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(ISNULL((SELECT Name FROM tb_PaymentTerm WHERE PaymentTermID = b.PaymentTerms AND isDeleted = 0), ''),'%22','\"'),'%27%27',''''),'%27','''') as PaymentTerms");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ItemTitle")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(ISNULL((SELECT TOP 1 ItemTitle FROM tb_PriceCatalogue WHERE ItemCode = ISNULL(pi.ItemCode, '') AND IsDeleted = 0 AND companyID = a.CompanyID), ''),'%22','\"'),'%27%27',''''),'%27','''') as ItemTitle");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(ISNULL((SELECT TOP 1 ItemTitle FROM tb_PriceCatalogue WHERE ItemCode = ISNULL(pi.ItemCode, '') AND IsDeleted = 0 AND companyID = a.CompanyID), ''),'%22','\"'),'%27%27',''''),'%27','''') as ItemTitle");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "InvoiceNumber")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(isnull((SELECT STUFF((SELECT ',' + isnull(InvoiceNumber, '')FROM (SELECT isnull(InvoiceNumber, '') AS InvoiceNumber FROM tb_invoice WHERE CompanyID = a.CompanyID AND invoiceid = (select top 1 InvoiceID from tb_EstimateItem where EstimateItemID = pi.EstimateItemID) AND IsDeleted = 0) AS T\tFOR XML PATH('')), 1, 1, '')), ''),'%22','\"'),'%27%27',''''),'%27','''') AS [Invoice Number]");
                            }
                            else
                            {
                                stringBuilder.Append(", Replace(Replace(Replace(isnull((SELECT STUFF((SELECT ',' + isnull(InvoiceNumber, '')FROM (SELECT isnull(InvoiceNumber, '') AS InvoiceNumber FROM tb_invoice WHERE CompanyID = a.CompanyID AND invoiceid = (select top 1 InvoiceID from tb_EstimateItem where EstimateItemID = pi.EstimateItemID) AND IsDeleted = 0) AS T\tFOR XML PATH('')), 1, 1, '')), ''),'%22','\"'),'%27%27',''''),'%27','''') AS [Invoice Number]");
                            }
                        }
                        //InvoiceDate
                        else if (this.chkColumns.Items[i].Value == "InvoiceDate")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(" isnull((SELECT STUFF((SELECT ',' + isnull(InvoiceDate, '')FROM (SELECT isnull(CONVERT(varchar(10), CreatedDate, 101), '') AS InvoiceDate FROM tb_invoice WHERE CompanyID = a.CompanyID AND invoiceid = (select top 1 InvoiceID from tb_EstimateItem where EstimateItemID = pi.EstimateItemID) AND IsDeleted = 0) AS T\tFOR XML PATH('')), 1, 1, '')), '') AS [InvoiceDate]");
                            }
                            else
                            {
                                stringBuilder.Append(", isnull((SELECT STUFF((SELECT ',' + isnull(InvoiceDate, '')FROM (SELECT isnull(CONVERT(varchar(10), CreatedDate, 101), '') AS InvoiceDate FROM tb_invoice WHERE CompanyID = a.CompanyID AND invoiceid = (select top 1 InvoiceID from tb_EstimateItem where EstimateItemID = pi.EstimateItemID) AND IsDeleted = 0) AS T\tFOR XML PATH('')), 1, 1, '')), '') AS [InvoiceDate]");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ContactAddress")
                        {
                            if (this.ddlContactAddress.SelectedValue == "1")
                            {
                                if (stringBuilder.ToString() == "")
                                {
                                    stringBuilder.Append("Replace(Replace(Replace(IsNull(cnt.Address,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress1,Replace(Replace(Replace(IsNull(cnt.Addressline2,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress2,Replace(Replace(Replace(IsNull(cnt.City,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress3,Replace(Replace(Replace(IsNull(cnt.State,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress4,Replace(Replace(Replace(IsNull(cnt.ZipCode,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress5,Replace(Replace(Replace(IsNull(cnt.Country,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress6");
                                }
                                else
                                {
                                    stringBuilder.Append(",Replace(Replace(Replace(IsNull(cnt.Address,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress1,Replace(Replace(Replace(IsNull(cnt.Addressline2,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress2,Replace(Replace(Replace(IsNull(cnt.City,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress3,Replace(Replace(Replace(IsNull(cnt.State,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress4,Replace(Replace(Replace(IsNull(cnt.ZipCode,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress5,Replace(Replace(Replace(IsNull(cnt.Country,''),'%22','\"'),'%27%27',''''),'%27','''') as ContactAddress6");
                                }
                            }
                            else if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(IsNull(IsNull(cnt.Address,'')+' '+IsNull(cnt.Addressline2,'')+' '+IsNull(cnt.City,'')+' '+IsNull(cnt.State,'')+' '+IsNull(cnt.ZipCode,'')+' '+IsNull(cnt.Country,''),''),'%22','\"'),'%27%27',''''),'%27','''')  as ContactAddress");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(IsNull(IsNull(cnt.Address,'')+' '+IsNull(cnt.Addressline2,'')+' '+IsNull(cnt.City,'')+' '+IsNull(cnt.State,'')+' '+IsNull(cnt.ZipCode,'')+' '+IsNull(cnt.Country,''),''),'%22','\"'),'%27%27',''''),'%27','''')  as ContactAddress");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "DeliveryAddress")
                        {
                            if (this.ddlDeliveryAddress.SelectedValue == "1")
                            {
                                if (stringBuilder.ToString() == "")
                                {
                                    stringBuilder.Append("Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ISNULL(c.Address,'') else ISNULL(da.Address,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress1, Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then '' else  IsNull(da.AddressLine2,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress2, Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ISNULL(c.city,'') else ISNULL(da.city,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress3 , Replace(Replace(Replace(case  when (a.DeliveryAddressID)='0' then IsNull(c.AddressLine3,'') else IsNull(da.State,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress4,  Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ISNULL(c.city,'') else IsNull(da.ZipCode,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress5, Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then IsNull(c.Country,'') else IsNull(da.Country,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress6 ");
                                }
                                else
                                {
                                    stringBuilder.Append(",Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ISNULL(c.Address,'') else ISNULL(da.Address,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress1, Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then '' else  IsNull(da.AddressLine2,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress2, Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ISNULL(c.city,'') else ISNULL(da.city,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress3 , Replace(Replace(Replace(case  when (a.DeliveryAddressID)='0' then IsNull(c.AddressLine3,'') else IsNull(da.State,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress4,  Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ISNULL(c.city,'') else IsNull(da.ZipCode,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress5, Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then IsNull(c.Country,'') else IsNull(da.Country,'') end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress6 ");
                                }
                            }
                            else if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ((ISNULL(c.Address,'') + ' ' + IsNull(c.AddressLine3,'') + ' ' + ISNULL(c.city,'')  + ' ' + IsNull(c.zip,'') + ' ' + IsNull(c.Country,''))) else (ISNULL(da.Address,'') + ' ' + IsNull(da.AddressLine2,'') + ' ' + ISNULL(da.city,'') + ' ' + IsNull(da.State,'') + ' ' + IsNull(da.ZipCode,'') + ' ' + IsNull(da.Country,'')) end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress  ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(case when (a.DeliveryAddressID)='0' then ((ISNULL(c.Address,'') + ' ' + IsNull(c.AddressLine3,'') + ' ' + ISNULL(c.city,'')  + ' ' + IsNull(c.zip,'') + ' ' + IsNull(c.Country,''))) else (ISNULL(da.Address,'') + ' ' + IsNull(da.AddressLine2,'') + ' ' + ISNULL(da.city,'') + ' ' + IsNull(da.State,'') + ' ' + IsNull(da.ZipCode,'') + ' ' + IsNull(da.Country,'')) end,'%22','\"'),'%27%27',''''),'%27','''') as DeliveryAddress ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "CommentDeliveryInstructions")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(a.Comments,'%22','\"'),'%27%27',''''),'%27','''') as CommentDeliveryInstructions ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(a.Comments,'%22','\"'),'%27%27',''''),'%27','''') as CommentDeliveryInstructions ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Status")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(string.Concat("Replace(Replace(Replace((Select ISNULL(StatusTitle,'') from tb_EstimateStatus s where CompanyID=", this.CompanyID, " and s.StatusID=a.Status and s.IsDeleted=0),'%22','\"'),'%27%27',''''),'%27','''') as Status"));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat(",Replace(Replace(Replace((Select ISNULL(StatusTitle,'') from tb_EstimateStatus s where CompanyID=", this.CompanyID, " and s.StatusID=a.Status and s.IsDeleted=0),'%22','\"'),'%27%27',''''),'%27','''') as Status"));
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "RaisedBy")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(string.Concat("Replace(Replace(Replace((Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u where u.CompanyID=", this.CompanyID, " and u.UserID=a.RaisedByID),'%22','\"'),'%27%27',''''),'%27','''') as RaisedBy"));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat(",Replace(Replace(Replace((Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u  where u.CompanyID=", this.CompanyID, " and u.UserID=a.RaisedByID),'%22','\"'),'%27%27',''''),'%27','''') as RaisedBy"));
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "RequestedDate")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("CONVERT(VARCHAR(10),a.ReqDate,101) as RequestedDate ");
                            }
                            else
                            {
                                stringBuilder.Append(",CONVERT(VARCHAR(10),a.ReqDate,101) as RequestedDate");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "CarrierInformation")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(string.Concat("Replace(Replace(Replace((select isnull(clientName,'')  from tb_client where clientID=a.CourierID and companytype='supplier' and companyID='", this.CompanyID, "'),'%22','\"'),'%27%27',''''),'%27','''') as CarrierInformation"));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat(", Replace(Replace(Replace((select isnull(clientName,'')  from tb_client where clientID=a.CourierID and companytype='supplier' and companyID='", this.CompanyID, "'),'%22','\"'),'%27%27',''''),'%27','''') as CarrierInformation"));
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ReferenceNumber")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(ISNULL(a.ReferenceNo,''),'%22','\"'),'%27%27',''''),'%27','''') as ReferenceNumber");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(ISNULL(a.ReferenceNo,''),'%22','\"'),'%27%27',''''),'%27','''') as ReferenceNumber");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "JobNumber")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(isnull((SELECT STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) AS JobNumber FROM tb_job j inner JOIN tb_estimateitem ei on ei.jobid=j.JobID WHERE ei.EstimateitemID in ((select estimateitemid from tb_estothercost where estothercostid=pi.estimateitemid and IsDeleted=0 UNION  select estimateitemid from tb_EstimateBookletItem  where EstimateBookletItemID=pi.estimateitemid and IsDeleted=0 union select estimateitemid from tb_EstimateLithoBookletItem  where EstimateLithoBookletItemID=pi.estimateitemid and IsDeleted=0 union select estimateitemid from tb_EstimateLithoNCRItem  where EstimateLithoNcrItemID=pi.estimateitemid and IsDeleted=0 UNION(select estimateitemid from tb_PurchaseItem where EstimateItemID=pi.estimateitemid and IsDeleted=0)))) AS T FOR XML PATH('')), 1, 1, '')),''),'%22','\"'),'%27%27',''''),'%27','''') AS JobNumber");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(isnull((SELECT STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) AS JobNumber FROM tb_job j inner JOIN tb_estimateitem ei on ei.jobid=j.JobID WHERE ei.EstimateitemID in ((select estimateitemid from tb_estothercost where estothercostid=pi.estimateitemid and IsDeleted=0 UNION  select estimateitemid from tb_EstimateBookletItem  where EstimateBookletItemID=pi.estimateitemid and IsDeleted=0 union select estimateitemid from tb_EstimateLithoBookletItem  where EstimateLithoBookletItemID=pi.estimateitemid and IsDeleted=0 union select estimateitemid from tb_EstimateLithoNCRItem  where EstimateLithoNcrItemID=pi.estimateitemid and IsDeleted=0 UNION(select estimateitemid from tb_PurchaseItem where EstimateItemID=pi.estimateitemid and IsDeleted=0)))) AS T FOR XML PATH('')), 1, 1, '')),''),'%22','\"'),'%27%27',''''),'%27','''') AS JobNumber");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "SupplierQuoteNO")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(" Replace(Replace(Replace(a.SupplierQuoteNo,'%22','\"'),'%27%27',''''),'%27','''') as SupplierQuoteNO");
                            }
                            else
                            {
                                stringBuilder.Append(", Replace(Replace(Replace(a.SupplierQuoteNo,'%22','\"'),'%27%27',''''),'%27','''') as SupplierQuoteNO");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "SupplierInvoiceNo")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(" Replace(Replace(Replace(a.SupplierInvoiceNo,'%22','\"'),'%27%27',''''),'%27','''') as SupplierInvoiceNo");
                            }
                            else
                            {
                                stringBuilder.Append(", Replace(Replace(Replace(a.SupplierInvoiceNo,'%22','\"'),'%27%27',''''),'%27','''') as SupplierInvoiceNo");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "SupplierInvoiceDate")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(" CONVERT(VARCHAR(10),a.SupplierInvoiceDate,101) as SupplierInvoiceDate");
                            }
                            else
                            {
                                stringBuilder.Append(", CONVERT(VARCHAR(10),a.SupplierInvoiceDate,101) as SupplierInvoiceDate");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "DeliveryDate")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(" CONVERT(VARCHAR(10),a.ReqDate,101) as DeliveryDate");
                            }
                            else
                            {
                                stringBuilder.Append(", CONVERT(VARCHAR(10),a.ReqDate,101) as DeliveryDate");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "InvoiceReceived")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(" case when InvoiceReceived = 0 then 'no' else 'yes' end as InvoiceReceived");
                            }
                            else
                            {
                                stringBuilder.Append(", case when InvoiceReceived = 0 then 'no' else 'yes' end as InvoiceReceived");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Total(Incl.Tax)")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("isnull((isnull(price, 0) + isnull(TaxValue, 0)), 0) AS PurchaseTotalincludingtax");
                            }
                            else
                            {
                                stringBuilder.Append(",isnull((isnull(price, 0) + isnull(TaxValue, 0)), 0) AS PurchaseTotalincludingtax");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Total(Ex.Tax)")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("isnull((isnull(price, 0)), 0)  AS PurchaseTotalexcludingtax");
                            }
                            else
                            {
                                stringBuilder.Append(",isnull((isnull(price, 0)), 0)  AS PurchaseTotalexcludingtax");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "JobTitle")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace((select EstimateTitle from tb_Estimate e where e.EstimateID=a.EstimateID and e.IsDeleted=0),'%22','\"'),'%27%27',''''),'%27','''') as JobTitle ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace((select EstimateTitle from tb_Estimate e where e.EstimateID=a.EstimateID and e.IsDeleted=0),'%22','\"'),'%27%27',''''),'%27','''') as JobTitle ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ActivityNotes")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append(string.Concat("Replace(Replace(Replace(dbo.Fn_EncodingSingleDoubleQuote_Return(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.PurchaseID and IsDelete=0 and ModuleName='purchase') AS T FOR XML PATH('')),1,1,'') )),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                            }
                            else if (this.ddlNotesType.SelectedValue == "0")
                            {
                                stringBuilder.Append(string.Concat(",Replace(Replace(Replace(dbo.Fn_EncodingSingleDoubleQuote_Return(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.PurchaseID and IsDelete=0 and ModuleName='purchase') AS T FOR XML PATH('')),1,1,'') )),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                            }
                            else if (this.ddlNotesType.SelectedValue == "System")
                            {
                                stringBuilder.Append(string.Concat(",Replace(Replace(Replace(dbo.Fn_EncodingSingleDoubleQuote_Return(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.PurchaseID and IsDelete=0 and type='System' and ModuleName='purchase') AS T FOR XML PATH('')),1,1,'') )),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                            }
                            else if (this.ddlNotesType.SelectedValue == "General")
                            {
                                stringBuilder.Append(string.Concat(",Replace(Replace(Replace(dbo.Fn_EncodingSingleDoubleQuote_Return(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.PurchaseID and IsDelete=0 and type='General' and ModuleName='purchase') AS T FOR XML PATH('')),1,1,'') )),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                            }
                            else if (this.ddlNotesType.SelectedValue == "Error")
                            {
                                stringBuilder.Append(string.Concat(",Replace(Replace(Replace(dbo.Fn_EncodingSingleDoubleQuote_Return(( select  STUFF((SELECT '¶' + ActivityNotes FROM (SELECT rtrim(ltrim(Description)) as ActivityNotes from tb_notes  where CompanyID=", this.CompanyID, " and ModuleID=a.PurchaseID and IsDelete=0 and type='Error' and ModuleName='purchase') AS T FOR XML PATH('')),1,1,'') )),'%22','\"'),'%27%27',''''),'%27','''') as ActivityNotes "));
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "AccountingCode")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                companyID = new object[] { "Replace(Replace(Replace(case when isNull(ac.Code,'')='' Then (Select code from tb_accountingCode where IsDeleted=0 and isdefault=1 and CompanyID= ", this.CompanyID, ") else  isnull((Select code from tb_accountingCode ca where ca.AccountCodeID=pi.AccountCodeID and IsDeleted=0  and CompanyID=", this.CompanyID, "),'') end,'%22','\"'),'%27%27',''''),'%27','''')  as AccountingCode " };
                                stringBuilder.Append(string.Concat(companyID));
                            }
                            else
                            {
                                companyID = new object[] { ",Replace(Replace(Replace(case when isNull(ac.Code,'')='' Then (Select code from tb_accountingCode where IsDeleted=0 and isdefault=1 and CompanyID= ", this.CompanyID, ") else  isnull((Select code from tb_accountingCode ca where ca.AccountCodeID=pi.AccountCodeID and IsDeleted=0  and CompanyID=", this.CompanyID, "),'') end,'%22','\"'),'%27%27',''''),'%27','''')  as AccountingCode " };
                                stringBuilder.Append(string.Concat(companyID));
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ItemCode")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(isnull(pi.ItemCode,''),'%22','\"'),'%27%27',''''),'%27','''') as ItemCode ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(isnull(pi.ItemCode,''),'%22','\"'),'%27%27',''''),'%27','''') as ItemCode ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Description")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(isnull(pi.Description,''),'%22','\"'),'%27%27',''''),'%27','''') as Description ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(isnull(pi.Description,''),'%22','\"'),'%27%27',''''),'%27','''') as Description ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "ItemQuantity")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("ISNULL(cast(pi.Qty as decimal(18,2)), 0) AS ItemQuantity");
                            }
                            else
                            {
                                stringBuilder.Append(", ISNULL(cast(pi.Qty as decimal(18,2)), 0) AS ItemQuantity");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "PackedIn")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(isnull(pi.PackedIn,0),'%22','\"'),'%27%27',''''),'%27','''') as PackedIn ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(isnull(pi.PackedIn,0),'%22','\"'),'%27%27',''''),'%27','''') as PackedIn ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Price")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("isnull(pi.Price,0) as Price ");
                            }
                            else
                            {
                                stringBuilder.Append(",isnull(pi.Price,0) as Price ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Tax")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(t.TaxName,'%22','\"'),'%27%27',''''),'%27','''') as Tax ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(t.TaxName,'%22','\"'),'%27%27',''''),'%27','''') as Tax ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "TaxValue")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("isnull(pi.TaxValue,0) as TaxValue ");
                            }
                            else
                            {
                                stringBuilder.Append(",isnull(pi.TaxValue,0) as TaxValue ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "Notes")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("Replace(Replace(Replace(pi.Note,'%22','\"'),'%27%27',''''),'%27','''') as Notes ");
                            }
                            else
                            {
                                stringBuilder.Append(",Replace(Replace(Replace(pi.Note,'%22','\"'),'%27%27',''''),'%27','''') as Notes ");
                            }
                        }
                        else if (this.chkColumns.Items[i].Value == "GoodsReceived")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("case when pi.IsGoodsReceived='0' then 'No' else 'Yes' end as GoodsReceived ");
                            }
                            else
                            {
                                stringBuilder.Append(",case when pi.IsGoodsReceived='0' then 'No' else 'Yes' end as GoodsReceived ");
                            }
                        }

                        // CustomDate1
                        else if (this.chkColumns.Items[i].Value == "CustomDate1")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("(select CONVERT(VARCHAR(10), e.EstCustomDate1, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate1");
                            }
                            else
                            {
                                stringBuilder.Append(", (select CONVERT(VARCHAR(10), e.EstCustomDate1, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate1");
                            }
                        }

                        // CustomDate2
                        else if (this.chkColumns.Items[i].Value == "CustomDate2")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("(select CONVERT(VARCHAR(10), e.EstCustomDate2, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate2");
                            }
                            else
                            {
                                stringBuilder.Append(", (select CONVERT(VARCHAR(10), e.EstCustomDate2, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate2");
                            }
                        }

                        // CustomDate3
                        else if (this.chkColumns.Items[i].Value == "CustomDate3")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("(select CONVERT(VARCHAR(10), e.EstCustomDate3, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate3");
                            }
                            else
                            {
                                stringBuilder.Append(", (select CONVERT(VARCHAR(10), e.EstCustomDate3, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate3");
                            }
                        }

                        // CustomDate4
                        else if (this.chkColumns.Items[i].Value == "CustomDate4")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("(select CONVERT(VARCHAR(10), e.EstCustomDate4, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate4");
                            }
                            else
                            {
                                stringBuilder.Append(", (select CONVERT(VARCHAR(10), e.EstCustomDate4, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate4");
                            }
                        }

                        // CustomDate5
                        else if (this.chkColumns.Items[i].Value == "CustomDate5")
                        {
                            if (stringBuilder.ToString() == "")
                            {
                                stringBuilder.Append("(select CONVERT(VARCHAR(10), e.EstCustomDate5, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate5");
                            }
                            else
                            {
                                stringBuilder.Append(", (select CONVERT(VARCHAR(10), e.EstCustomDate5, 101) " +
                                                     "from tb_Estimate e " +
                                                     "where e.EstimateID=a.EstimateID and e.IsDeleted=0) as CustomDate5");
                            }
                        }


                    }
                }
                empty = "from tb_Purchase a left join tb_Client b on b.ClientID=a.SupplierID ";
                empty = string.Concat(" ", empty, "left join tb_Contact ct on a.ContactID=ct.ContactID  ");
                empty = string.Concat(" ", empty, "left join tb_CompanyAddress da on da.AddressId=a.DeliveryAddressID and da.IsDelete=0  ");
                empty = string.Concat(" ", empty, "left join tb_Company c on c.companyID=a.CompanyID  ");
                empty = string.Concat(" ", empty, "left join tb_PurchaseItem pi on pi.PurchaseID=a.PurchaseID and pi.IsDeleted=0  ");
                empty = string.Concat(" ", empty, "left join tb_TaxRates t on t.TaxID=pi.TaxID and t.IsDeleted=0  ");
                empty = string.Concat(" ", empty, "left join tb_accountingcode ac on ac.AccountCodeID=pi.AccountCodeID ");
                if (CheckXeroTracking())
                    empty = string.Concat(empty, " left join tb_user uu on uu.userID=a.CreatedBy left join TrackingOption tr on tr.Id=uu.TrackingOptionId ");
                companyID = new object[] { " ", empty, "left join tb_CompanyAddress cnt on cnt.AddressId=a.AddressId and cnt.IsDelete=0 where a.companyid=", this.CompanyID, " and a.IsDeleted=0 AND a.PONO!=''" };
                empty = string.Concat(companyID);
                if (this.txtFreetext.Text != "")
                {
                    int num = 0;
                    for (int j = 0; j < this.chkfreetext.Items.Count; j++)
                    {
                        if (this.chkfreetext.Items[j].Selected)
                        {
                            num++;
                        }
                    }
                    int num1 = 0;
                    for (int k = 0; k < this.chkfreetext.Items.Count; k++)
                    {
                        if (num > 1)
                        {
                            if (this.chkfreetext.Items[k].Selected)
                            {
                                if (this.chkfreetext.Items[k].Value == "SupplierName")
                                {
                                    empty = string.Concat(empty, " and ( (ltrim(b.ClientName) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                                }
                                if (this.chkfreetext.Items[k].Value == "PONO")
                                {
                                    empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                    empty = string.Concat(empty, "  (a.PONO like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                                }
                                if (this.chkfreetext.Items[k].Value == "JobNumber")
                                {
                                    empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                    companyID = new object[] { empty, "  ((select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID=", this.CompanyID, " and EstimateID=a.EstimateID) AS T FOR XML PATH('')),1,1,'') ) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')" };
                                    empty = string.Concat(companyID);
                                }
                                if (this.chkfreetext.Items[k].Value == "ContactName")
                                {
                                    empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                    empty = string.Concat(empty, "  (isnull(ct.FirstName +' '+ ct.LastName,'') like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                                }
                                if (this.chkfreetext.Items[k].Value == "ItemCode")
                                {
                                    empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                    empty = string.Concat(empty, "  (isnull(pi.ItemCode,'') like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                                }
                                if (this.chkfreetext.Items[k].Value == "AccountingCode")
                                {
                                    empty = (num1 != 0 ? string.Concat(empty, " or ") : string.Concat(empty, " and ( "));
                                    empty = string.Concat(empty, " (ISNULL(Ac.Code, '') like '%", base.SpecialEncode(this.txtFreetext.Text), "%') ");
                                }
                                num1++;
                            }
                        }
                        else if (num == 1 && this.chkfreetext.Items[k].Selected)
                        {
                            if (this.chkfreetext.Items[k].Value == "SupplierName")
                            {
                                empty = string.Concat(empty, " and ( (ltrim(b.ClientName) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "PONO")
                            {
                                empty = string.Concat(empty, " and ( (a.PONO like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "JobNumber")
                            {
                                companyID = new object[] { empty, " and ( ((select  STUFF((SELECT ',' + JobNumber FROM (SELECT rtrim(ltrim(JobNumber)) as JobNumber from tb_job where CompanyID=", this.CompanyID, " and EstimateID=a.EstimateID) AS T FOR XML PATH('')),1,1,'') ) like '%", base.SpecialEncode(this.txtFreetext.Text), "%')" };
                                empty = string.Concat(companyID);
                            }
                            if (this.chkfreetext.Items[k].Value == "ContactName")
                            {
                                empty = string.Concat(empty, " and ( (isnull(ct.FirstName +' '+ ct.LastName,'') like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "ItemCode")
                            {
                                empty = string.Concat(empty, " and ( (isnull(pi.ItemCode,'') like '%", base.SpecialEncode(this.txtFreetext.Text), "%')");
                            }
                            if (this.chkfreetext.Items[k].Value == "AccountingCode")
                            {
                                empty = string.Concat(empty, " and (  (ISNULL(Ac.Code, '') like '%", base.SpecialEncode(this.txtFreetext.Text), "%') ");
                            }
                        }
                    }
                    if (num != 0)
                    {
                        empty = string.Concat(empty, " ) ");
                    }
                    base.SpecialEncode(this.txtFreetext.Text);
                }

                if (chkItemCodeNotNull.Checked)
                {
                    empty += " and (ItemCode != '' and ItemCode is not null) ";
                }
                if (CheckXeroTracking())
                {
                    if (this.ddlLocation.SelectedIndex > 0)
                    {

                        empty = string.Concat(empty, " and tr.TrackingOption=", "'", ddlLocation.SelectedItem.Text, "' ");
                    }
                }

                // Estimator Drop down filter
                if (this.ddlEstimator.SelectedItem.Value != string.Empty)
                {
                    stringBuilder.Append(" and exists( ");

                    companyID = new object[] { " (Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u where u.CompanyID=", this.CompanyID,
                        " and u.UserID=a.EstimatorId and u.IsDelete=0  " +
                        " (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) and (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) like '%' +'",
                        base.SpecialEncode(this.ddlEstimator.SelectedItem.Text), "'+ '%') )" };
                    stringBuilder.Append(string.Concat(companyID));
                }

                // Sales Person Drop down filter
                if (this.ddlSalesPerson.SelectedItem.Value != string.Empty)
                {
                    stringBuilder.Append(" and exists( ");

                    companyID = new object[] { " (Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u where u.CompanyID=", this.CompanyID, 
                        " and u.UserID=a.SalesPerson and u.IsDelete=0  " +
                        " (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) and (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) like '%' +'", 
                        base.SpecialEncode(this.ddlSalesPerson.SelectedItem.Text), "'+ '%') )" };
                    stringBuilder.Append(string.Concat(companyID));
                }
                //Customer Sales Person filter
                if (this.ddlCustomerSalesPerson.SelectedItem.Value != string.Empty)
                {
                    stringBuilder.Append(" and exists( ");

                    companyID = new object[] { " (Select ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'') from tb_User u " +
                        " inner join tb_client clnt" +
                        " on clnt.SalesPerson = u.userID " +
                        "where u.CompanyID=", this.CompanyID, " and u.IsDelete=0 and (ISNULL(u.FirstName,'') + '' + ISNULL(u.LastName,'')) like '%' +'",
                        base.SpecialEncode(this.ddlCustomerSalesPerson.SelectedItem.Text), "'+ '%') )" };
                    stringBuilder.Append(string.Concat(companyID));
                }

                if (this.lstPurchaseSupplier.SelectedIndex != 0)
                {
                    string str7 = string.Empty;
                    string empty8 = string.Empty;
                    int num2 = 0;
                    for (int l = 0; l < this.lstPurchaseSupplier.Items.Count; l++)
                    {
                        if (this.lstPurchaseSupplier.Items[l].Checked)
                        {
                            num2++;
                            if (num2 != 1)
                            {
                                str7 = string.Concat(str7, ",", this.lstPurchaseSupplier.Items[l].Value);
                                empty8 = string.Concat(empty8, ",", this.lstPurchaseSupplier.Items[l].Text);
                            }
                            else
                            {
                                str7 = string.Concat(str7, this.lstPurchaseSupplier.Items[l].Value);
                                empty8 = string.Concat(empty8, this.lstPurchaseSupplier.Items[l].Text);
                            }
                        }
                    }
                    if (num2 > 0)
                    {
                        empty = string.Concat(empty, "and a.SupplierID in (", str7, ") ");
                        empty8.ToString();
                    }
                }
                if (this.PurchaseStatus.SelectedIndex != 0)
                {
                    string str8 = string.Empty;
                    string empty9 = string.Empty;
                    int num3 = 0;
                    for (int m = 0; m < this.PurchaseStatus.Items.Count; m++)
                    {
                        if (this.PurchaseStatus.Items[m].Checked)
                        {
                            num3++;
                            if (num3 != 1)
                            {
                                str8 = string.Concat(str8, ",", this.PurchaseStatus.Items[m].Value);
                                empty9 = string.Concat(empty9, ",", this.PurchaseStatus.Items[m].Text);
                            }
                            else
                            {
                                str8 = string.Concat(str8, this.PurchaseStatus.Items[m].Value);
                                empty9 = string.Concat(empty9, this.PurchaseStatus.Items[m].Text);
                            }
                        }
                    }
                    if (num3 > 0)
                    {
                        empty = string.Concat(empty, "and a.Status in (", str8, ") ");
                        empty9.ToString();
                    }
                }
                if (this.chkDateOption.Checked)
                {
                    if (this.rdlDate.SelectedValue == "daily")
                    {
                        string str9 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                        empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) = '", str9, "' ");
                    }
                    else if (this.rdlDate.SelectedValue == "yesterday")
                    {
                        string str10 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                        empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) = '", str10, "' ");
                    }
                    else if (this.rdlDate.SelectedValue == "thismonth")
                    {
                        string str11 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                        string str12 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str11, "' and '", str12, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "thisquarter")
                    {
                        string str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                        string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str13, "' and '", str14, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                    {
                        string str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat));
                        string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm", "MM")));
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str13, "' and '", str14, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "lastquater")
                    {
                        string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                        string str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                        str = new string[] { empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str15, "' and '", str16, "'" };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "thisyear")
                    {
                        string str17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.startyear[0].ToString());
                        string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endyear[0].ToString());
                        str = new string[] { empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str17, "' and '", str18, "'" };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "halfyear")
                    {
                        string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                        string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str19, "' and '", str20, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "lastweek")
                    {
                        string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                        string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str19, "' and '", str20, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "lastmonth")
                    {
                        string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                        string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str19, "' and '", str20, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "lastyear")
                    {
                        string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                        string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str19, "' and '", str20, "' " };
                        empty = string.Concat(str);
                    }
                    else if (this.rdlDate.SelectedValue == "tilldate")
                    {
                        commonClass _commonClass = this.objJava;
                        now = DateTime.Now;
                        string str21 = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        chrArray = new char[] { ' ' };
                        string[] strArrays = str21.Split(chrArray);
                        empty = string.Concat(empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) <= '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays[0].ToString()), "' ");
                    }
                    else if (this.rdlDate.SelectedValue == "daterange")
                    {
                        string str22 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtFrom.Text));
                        string str23 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtTo.Text));
                        str = new string[] { empty, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) BETWEEN '", str22, "' AND '", str23, "' " };
                        empty = string.Concat(str);
                    }
                }
                SqlConnection sqlConnection = new SqlConnection(this.cs);
                StringBuilder stringBuilder1 = new StringBuilder();
                if (!this.rdodetail.Checked && !this.rdosummary.Checked)
                {
                    if (PageNumber != 0)
                    {
                        //int pageNumber = PageNumber * 100 - 100;
                        //int num4 = 100;
                        companyID = new object[] { "select  ", stringBuilder, " ", empty };
                        stringBuilder1.Append(string.Concat(companyID));
                        if (this.HdnSortBy.Value.ToLower() == "none")
                        {
                            stringBuilder1.Append(" order by a.purchaseid ");
                        }
                        else if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                        {
                            if (this.HdnSortBy.Value.ToLower() == "purchasenumber")
                            {
                                stringBuilder1.Append("order by PONo");
                            }
                            else if (this.HdnSortBy.Value.ToLower() == "Company")
                            {
                                stringBuilder1.Append("order by clientname");
                            }
                            else if (this.HdnSortBy.Value != "Total(Incl.Tax)")
                            {
                                stringBuilder1.Append(string.Concat("order by ", this.HdnSortBy.Value));
                            }
                            else
                            {
                                stringBuilder1.Append("order by PurchaseTotalincludingtax");
                            }
                            if (this.ddldirection.SelectedValue == "ASC")
                            {
                                stringBuilder1.Append(" ASC ");
                            }
                            else if (this.ddldirection.SelectedValue == "DESC")
                            {
                                stringBuilder1.Append(" DESC ");
                            }
                        }
                        //companyID = new object[] { " offset ", pageNumber, " rows fetch next ", num4, " rows only;" };
                        //stringBuilder1.Append(string.Concat(companyID));
                        stringBuilder1.Append(string.Concat(" select count(*) ", empty.ToString()));
                    }
                    else
                    {
                        companyID = new object[] { "select  ", stringBuilder, " ", empty };
                        stringBuilder1.Append(string.Concat(companyID));
                        if (this.HdnSortBy.Value.ToLower() == "none")
                        {
                            stringBuilder1.Append(" ");
                        }
                        else if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                        {
                            if (this.HdnSortBy.Value.ToLower() == "purchasenumber")
                            {
                                stringBuilder1.Append("order by PONo");
                            }
                            else if (this.HdnSortBy.Value.ToLower() == "Company")
                            {
                                stringBuilder1.Append("order by clientname");
                            }
                            else if (this.HdnSortBy.Value != "Total(Incl.Tax)")
                            {
                                stringBuilder1.Append(string.Concat("order by ", this.HdnSortBy.Value));
                            }
                            else
                            {
                                stringBuilder1.Append("order by PurchaseTotalincludingtax");
                            }
                            if (this.ddldirection.SelectedValue == "ASC")
                            {
                                stringBuilder1.Append(" ASC ");
                            }
                            else if (this.ddldirection.SelectedValue == "DESC")
                            {
                                stringBuilder1.Append(" DESC ");
                            }
                        }
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringBuilder1.ToString(), sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                if (this.chkColumns1.Items[0].Selected || this.chkColumns1.Items[1].Selected || this.chkColumns1.Items[2].Selected || this.chkColumns1.Items[3].Selected || this.chkColumns1.Items[4].Selected)
                {
                    this.divaggregate.Visible = true;
                    this.divAggl.Visible = true;
                }
                try
                {
                    //if (!this.chkColumns.Items[18].Selected)
                    //{
                    //    this.divCount.Visible = false;
                    //    this.divminimum.Visible = false;
                    //    this.divAverage.Visible = false;
                    //    this.divTotal.Visible = false;
                    //    this.divaggregate1.Visible = false;
                    //}
                    //else
                    //{
                    StringBuilder stringBuilder2 = new StringBuilder();
                    if (this.chkColumns1.Items[0].Selected)
                    {
                        this.divaggregate1.Visible = true;
                        this.divCount.Visible = true;
                        if (stringBuilder2.ToString() == "")
                        {
                            stringBuilder2.Append("Count(x.PurchaseTotalincludingtax) as CountPurchaseValue");
                        }
                        else
                        {
                            stringBuilder2.Append(string.Concat(stringBuilder2, ",Count(x.PurchaseTotalincludingtax) as CountPurchaseValue"));
                        }
                    }
                    if (this.chkColumns1.Items[1].Selected)
                    {
                        this.divaggregate1.Visible = true;
                        this.divTotal.Visible = true;
                        if (stringBuilder2.ToString() == "")
                        {
                            stringBuilder2.Append("+isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue");
                        }
                        else
                        {
                            stringBuilder2.Append(",+isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue");
                        }
                    }
                    if (this.chkColumns1.Items[2].Selected)
                    {
                        this.divaggregate1.Visible = true;
                        this.divAverage.Visible = true;
                        if (stringBuilder2.ToString() == "")
                        {
                            stringBuilder2.Append("+isnull(avg(x.PurchaseTotalincludingtax),1) as AvgPurchaseValue");
                        }
                        else
                        {
                            stringBuilder2.Append(",+isnull(avg(x.PurchaseTotalincludingtax),0) as AvgPurchaseValue");
                        }
                    }
                    if (this.chkColumns1.Items[3].Selected)
                    {
                        this.divminimum.Visible = true;
                        this.divaggregate1.Visible = true;
                        if (stringBuilder2.ToString() == "")
                        {
                            stringBuilder2.Append("+isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue");
                        }
                        else
                        {
                            stringBuilder2.Append(",+isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue");
                        }
                    }
                    if (this.chkColumns1.Items[4].Selected)
                    {
                        this.divaggregate1.Visible = true;
                        this.divMaximum.Visible = true;
                        stringBuilder2.Append(",+isnull(Min(x.PurchaseTotalincludingtax),0) as MinPurchaseValue");
                    }
                    if (stringBuilder2.ToString() != "")
                    {
                        StringBuilder stringBuilder3 = new StringBuilder();
                        str = new string[] { "select ", stringBuilder2.ToString(), " from ( select isnull(isnull(pi.price,0)+isnull(pi.TaxValue,0),0) as PurchaseTotalincludingtax ", empty, " ) x" };
                        stringBuilder3.Append(string.Concat(str));
                        SqlCommand sqlCommand = new SqlCommand(stringBuilder3.ToString(), sqlConnection)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            if (this.chkColumns1.Items[3].Selected)
                            {
                                this.lblinvMaximum.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["MaxPurchaseValue"].ToString()), 0, " ", false, false, true);
                                this.MaxPurchaseValue = this.lblinvMaximum.Text;
                            }
                            if (this.chkColumns1.Items[4].Selected)
                            {
                                this.lblinvminimum.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["MinPurchaseValue"].ToString()), 0, " ", false, false, true);
                                this.MinPurchaseValue = this.lblinvminimum.Text;
                            }
                            if (this.chkColumns1.Items[2].Selected)
                            {
                                this.lblinvAverage.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["AvgPurchaseValue"].ToString()), 0, " ", false, false, true);
                                this.AveragePurchaseValue = this.lblinvAverage.Text;
                            }
                            if (this.chkColumns1.Items[0].Selected)
                            {
                                this.lblinvCount.Text = sqlDataReader["CountPurchaseValue"].ToString();
                                this.PurchaseCount = this.lblinvCount.Text;
                            }
                            if (!this.chkColumns1.Items[1].Selected)
                            {
                                continue;
                            }
                            this.lblinvTotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["TotalpurchaseValue"].ToString()), 0, " ", false, false, true);
                            this.TotalPurchaseValue = this.lblinvTotal.Text;
                        }
                        sqlConnection.Close();
                    }
                    //}
                }
                catch
                {
                }
                if (!this.rdodetail.Checked)
                {
                    if (this.rdosummary.Checked)
                    {
                        if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "1")
                        {
                            DataSet dataSet1 = new DataSet();
                            string str24 = string.Concat("select distinct DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) as EstimateDate ", empty);
                            (new SqlDataAdapter(str24, sqlConnection)).Fill(dataSet1);
                            Label label = this.lblTotalRecords;
                            count = dataSet1.Tables[0].Rows.Count;
                            label.Text = count.ToString();
                            foreach (DataRow row in dataSet1.Tables[0].Rows)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<table boder=0 width=100% cellspacing=2 cellpadding=2>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td align='left' class='table-rowrpt' style='font-weight:bold' >"));
                                Label label1 = new Label();
                                commonClass _commonClass1 = this.objJava;
                                now = Convert.ToDateTime(row["EstimateDate"]);
                                label1.Text = _commonClass1.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                                this.plhdetails.Controls.Add(label1);
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2><tr valign=top height=23>"));
                                if (this.chkColumns1.Items[3].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='10%'>Count</td>"));
                                }
                                if (this.chkColumns1.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[2].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Avg (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[0].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Max (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[1].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Min (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                commonClass _commonClass2 = this.objJava;
                                now = Convert.ToDateTime(row["EstimateDate"]);
                                string str25 = _commonClass2.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                                StringBuilder stringBuilder4 = new StringBuilder();
                                str = new string[] { "select isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue,isnull(Min(x.PurchaseTotalincludingtax),0) as MinPurchaseValue,isnull(avg(x.PurchaseTotalincludingtax),0) as AvgPurchaseValue,PurchaseID AS CountPurchaseValue,isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue FROM (select count(pi.purchaseID) as PurchaseID ,ISNULL( SUM(price + taxvalue),0.00) AS PurchaseTotalincludingtax ", empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate))='", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, str25), "')  as x GROUP by PurchaseID" };
                                stringBuilder4.Append(string.Concat(str));
                                SqlCommand sqlCommand1 = new SqlCommand(stringBuilder4.ToString(), sqlConnection)
                                {
                                    CommandType = CommandType.Text
                                };
                                sqlConnection.Open();
                                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                                while (sqlDataReader1.Read())
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100%><tr>"));
                                    if (this.chkColumns1.Items[3].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", sqlDataReader1["CountPurchaseValue"].ToString(), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[4].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["TotalpurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[2].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["AvgPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[0].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["MaxPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[1].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["MinPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                }
                                sqlConnection.Close();
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                            }
                        }
                        else if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "2")
                        {
                            DataSet dataSet2 = new DataSet();
                            string str26 = string.Concat("select distinct datepart(month,a.CreatedDate) as estmonth,datepart(year,a.CreatedDate) as estyear ", empty, " order by estyear,estmonth ");
                            (new SqlDataAdapter(str26, sqlConnection)).Fill(dataSet2);
                            Label label2 = this.lblTotalRecords;
                            count = dataSet2.Tables[0].Rows.Count;
                            label2.Text = count.ToString();
                            foreach (DataRow dataRow in dataSet2.Tables[0].Rows)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<table boder=2 width=100% cellspacing=2 cellpadding=2>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt'  style='font-weight:bold' >"));
                                Label label3 = new Label();
                                string str27 = string.Concat(this.Get2digit(dataRow["estmonth"].ToString()), "/01/", dataRow["estyear"].ToString());
                                DateTime dateTime = Convert.ToDateTime(str27);
                                DateTime dateTime1 = dateTime.Subtract(TimeSpan.FromDays((double)(dateTime.Day - 1)));
                                DateTime dateTime2 = dateTime1.AddMonths(1);
                                DateTime dateTime3 = dateTime2.Subtract(TimeSpan.FromDays(1));
                                str = new string[] { this.Get2digit(dataRow["estmonth"].ToString()), "/", null, null, null };
                                string str28 = dateTime3.ToString();
                                chrArray = new char[] { ' ' };
                                string str29 = str28.Split(chrArray)[0];
                                chrArray = new char[] { '/' };
                                str[2] = str29.Split(chrArray)[1];
                                str[3] = "/";
                                str[4] = dataRow["estyear"].ToString();
                                string str30 = string.Concat(str);
                                now = Convert.ToDateTime(str27);
                                label3.Text = string.Concat(now.ToString("MMMM"), "-", dataRow["estyear"].ToString());
                                this.plhdetails.Controls.Add(label3);
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2><tr valign=top height=23>"));
                                if (this.chkColumns1.Items[3].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='10%'>Count</td>"));
                                }
                                if (this.chkColumns1.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[2].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Avg (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[0].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Max (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[1].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Min (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                StringBuilder stringBuilder5 = new StringBuilder();
                                str = new string[] { "select isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue,isnull(Min(x.PurchaseTotalincludingtax),0) as MinPurchaseValue,isnull(avg(x.PurchaseTotalincludingtax),0) as AvgPurchaseValue,PurchaseID AS CountPurchaseValue,isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue FROM (select count(pi.purchaseID) as PurchaseID ,ISNULL( SUM(price + taxvalue),0.00) AS PurchaseTotalincludingtax ", empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str27, "' and '", str30, "')  as x GROUP by PurchaseID" };
                                stringBuilder5.Append(string.Concat(str));
                                SqlCommand sqlCommand2 = new SqlCommand(stringBuilder5.ToString(), sqlConnection)
                                {
                                    CommandType = CommandType.Text
                                };
                                sqlConnection.Open();
                                SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                                while (sqlDataReader2.Read())
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100%><tr>"));
                                    if (this.chkColumns1.Items[3].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", sqlDataReader2["CountPurchaseValue"].ToString(), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[4].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader2["TotalpurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[2].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader2["AvgPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[0].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader2["MaxPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[1].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader2["MinPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                }
                                sqlConnection.Close();
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                            }
                        }
                        else if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "3")
                        {
                            DataSet dataSet3 = new DataSet();
                            string str31 = string.Concat("select distinct datepart(year,a.CreatedDate) as estyear ", empty);
                            (new SqlDataAdapter(str31, sqlConnection)).Fill(dataSet3);
                            Label label4 = this.lblTotalRecords;
                            count = dataSet3.Tables[0].Rows.Count;
                            label4.Text = count.ToString();
                            foreach (DataRow row1 in dataSet3.Tables[0].Rows)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<table boder=0 width=100% cellspacing=2 cellpadding=2>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt'  style='font-weight:bold' >"));
                                Label label5 = new Label();
                                string str32 = string.Concat("01/01/", row1["estyear"].ToString());
                                string str33 = string.Concat("12/31/", row1["estyear"].ToString());
                                label5.Text = row1["estyear"].ToString();
                                this.plhdetails.Controls.Add(label5);
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2><tr valign=top height=23>"));
                                if (this.chkColumns1.Items[3].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='10%'>Count</td>"));
                                }
                                if (this.chkColumns1.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[2].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Avg (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[0].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Max (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[1].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Min (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                StringBuilder stringBuilder6 = new StringBuilder();
                                str = new string[] { "select isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue,isnull(Min(x.PurchaseTotalincludingtax),0) as MinPurchaseValue,isnull(avg(x.PurchaseTotalincludingtax),0) as AvgPurchaseValue,PurchaseID AS CountPurchaseValue,isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue FROM (select count(pi.purchaseID) as PurchaseID ,ISNULL( SUM(price + taxvalue),0.00) AS PurchaseTotalincludingtax ", empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str32, "' and '", str33, "')  as x GROUP by PurchaseID" };
                                stringBuilder6.Append(string.Concat(str));
                                SqlCommand sqlCommand3 = new SqlCommand(stringBuilder6.ToString(), sqlConnection)
                                {
                                    CommandType = CommandType.Text
                                };
                                sqlConnection.Open();
                                SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                                while (sqlDataReader3.Read())
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100%><tr>"));
                                    if (this.chkColumns1.Items[3].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", sqlDataReader3["CountPurchaseValue"].ToString(), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[4].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader3["TotalpurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[2].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader3["AvgPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[0].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader3["MaxPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[1].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader3["MinPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                }
                                sqlConnection.Close();
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                            }
                        }
                        if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "4")
                        {
                            DataSet dataSet4 = new DataSet();
                            string str34 = string.Concat("select distinct Replace(Replace(Replace(ltrim(isnull(b.ClientName,'')),'%22','\"'),'%27%27',''''),'%27','''') as Company ", empty, " order by Company Asc ");
                            (new SqlDataAdapter(str34, sqlConnection)).Fill(dataSet4);
                            Label label6 = this.lblTotalRecords;
                            count = dataSet4.Tables[0].Rows.Count;
                            label6.Text = count.ToString();
                            foreach (DataRow dataRow1 in dataSet4.Tables[0].Rows)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<table boder=0 width=100% cellspacing=0 cellpadding=2>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt'  style='font-weight:bold' >"));
                                Label label7 = new Label();
                                if (dataRow1["Company"].ToString().Trim() != "")
                                {
                                    label7.Text = dataRow1["Company"].ToString();
                                }
                                else
                                {
                                    label7.Text = "Not Specified";
                                }
                                this.plhdetails.Controls.Add(label7);
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("<table width=100% cellspacing=0 cellpadding=0 border=0 class=tablerowcolor2><tr valign=top height=23>"));
                                if (this.chkColumns1.Items[3].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='10%'>Count</td>"));
                                }
                                if (this.chkColumns1.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Total (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[2].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Avg (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[0].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Max (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                if (this.chkColumns1.Items[1].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='right' width='10%'>Min (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</td>")));
                                }
                                this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                StringBuilder stringBuilder7 = new StringBuilder();
                                if (dataRow1["Company"].ToString() != "")
                                {
                                    companyID = new object[] { "select isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue,isnull(Min(x.PurchaseTotalincludingtax),0) as MinPurchaseValue,isnull(avg(x.PurchaseTotalincludingtax),0) as AvgPurchaseValue,PurchaseID AS CountPurchaseValue,isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue FROM (select count(pi.purchaseID) as PurchaseID ,ISNULL( SUM(price + taxvalue),0.00) AS PurchaseTotalincludingtax ", empty, " and ltrim(b.ClientName)='", dataRow1["Company"], "')  as x GROUP by PurchaseID" };
                                    stringBuilder7.Append(string.Concat(companyID));
                                }
                                else
                                {
                                    stringBuilder7.Append(string.Concat("select isnull(max(x.PurchaseTotalincludingtax),0) as MaxPurchaseValue,isnull(Min(x.PurchaseTotalincludingtax),0) as MinPurchaseValue,isnull(avg(x.PurchaseTotalincludingtax),0) as AvgPurchaseValue,Count(x.PurchaseTotalincludingtax) as CountPurchaseValue,isnull(Sum(x.PurchaseTotalincludingtax),0) as TotalpurchaseValue from (select (select isnull(sum(isnull(price,0)+isnull(TaxValue,0)),0)  from tb_purchaseitem pri   " +
                                        "where pri.purchaseid=a.purchaseid) as PurchaseTotalincludingtax ", empty, " and ltrim(b.ClientName) is null ) x"));
                                }
                                SqlCommand sqlCommand4 = new SqlCommand(stringBuilder7.ToString(), sqlConnection)
                                {
                                    CommandType = CommandType.Text
                                };
                                sqlConnection.Open();
                                SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
                                while (sqlDataReader4.Read())
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100%><tr>"));
                                    if (this.chkColumns1.Items[3].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", sqlDataReader4["CountPurchaseValue"].ToString(), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[4].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader4["TotalpurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[2].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader4["AvgPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[0].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader4["MaxPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    if (this.chkColumns1.Items[1].Selected)
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='right' class='table-rowrpt' style='vertical-align:middle' width='10%'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader4["MinPurchaseValue"].ToString()), 0, "", false, false, true), "</td>")));
                                    }
                                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                                }
                                sqlConnection.Close();
                                this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                                this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                            }
                        }
                    }
                }
                else if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "1")
                {
                    int num5 = 0;
                    DataSet dataSet5 = new DataSet();
                    string str35 = string.Concat("select distinct DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) as EstimateDate ", empty);
                    (new SqlDataAdapter(str35, sqlConnection)).Fill(dataSet5);
                    foreach (DataRow row2 in dataSet5.Tables[0].Rows)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl("<table boder=0 width=100% cellspacing=0 cellpadding=0>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold' ><b>"));
                        Label label8 = new Label();
                        commonClass _commonClass3 = this.objJava;
                        now = Convert.ToDateTime(row2["EstimateDate"]);
                        label8.Text = _commonClass3.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                        this.plhdetails.Controls.Add(label8);
                        this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<table width=100% cellspacing=0 cellpadding=1 border=0 class='tablerowcolor2' ><tr class='headerstylereport1'  valign=top height=23>"));
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>&nbsp;Purchase Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Created On</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Name</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Name</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            if (this.ddlContactAddress.SelectedValue != "1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Address</b>&nbsp;</div></td>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Country</b>&nbsp;</div></td>"));
                            }
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            if (this.ddlDeliveryAddress.SelectedValue != "1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Address</b>&nbsp;</div></td>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Country</b>&nbsp;</div></td>"));
                            }
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Comment/Delivery Instructions</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Status</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Raised By</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Purchase Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b> ", this.objLanguage.GetLanguageConversion("Carrier_Information"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b> ", this.objLanguage.GetLanguageConversion("Reference_Number"), " </b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b> ", this.objLanguage.GetLanguageConversion("Job_Number"), " </b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>", this.objLanguage.GetLanguageConversion("Supp_Quote"), " </b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>", this.objLanguage.GetLanguageConversion("Supp_Inv"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>", this.objLanguage.GetLanguageConversion("Supplier_Invoice_Date"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Invoice Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Inc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Exc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Title</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Activity Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Accounting Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[23].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[24].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Description</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[25].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Quantity</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[26].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Packed In</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[27].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Price</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[28].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Tax</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[29].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Tax Value</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[30].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[31].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Goods Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[32].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 1</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[33].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 2</b>&nbsp;</div></td>"));
                        }
                        this.plhdetails.Controls.Add(new LiteralControl("<td width=1% align=right valign=top class='headerstylereport1'></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        commonClass _commonClass4 = this.objJava;
                        now = Convert.ToDateTime(row2["EstimateDate"]);
                        string str36 = _commonClass4.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                        StringBuilder stringBuilder8 = new StringBuilder();
                        companyID = new object[] { "select ", stringBuilder, " ", empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) = '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, str36), "' " };
                        stringBuilder8.Append(string.Concat(companyID));
                        stringBuilder8.Append(" order by a.PONO desc ");
                        SqlCommand sqlCommand5 = new SqlCommand(stringBuilder8.ToString(), sqlConnection)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
                        int num6 = 0;
                        if (!sqlDataReader5.HasRows)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr><td><table width=100% bordercolor=#DDDDDD cellspacing=0 cellpadding=0 border=0><tr><td colspan=10 class='normaltext' align='center'>No Records Found</td></tr>"));
                            this.plhdetails.Controls.Add(new LiteralControl("</table></td></tr>"));
                        }
                        while (sqlDataReader5.Read())
                        {
                            num5++;
                            num6++;
                            if (num6 % 2 != 0)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport>"));
                            }
                            if (this.chkColumns.Items[0].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["PONo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[1].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader5["CreatedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[2].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["Company"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[3].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlContactAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='10%' style='vertical-align:middle'><div id='division' style='overflow: auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactAddress"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlDeliveryAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[5].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='10%' style='vertical-align:middle'><div id='division' style='overflow: auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[6].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["CommentDeliveryInstructions"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[7].Selected)
                            {
                                ControlCollection controls = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;word-break:break-all;' class='divscroll' title='", sqlDataReader5["Status"].ToString(), "'>", base.SpecialDecode(sqlDataReader5["Status"].ToString()), "&nbsp;</div></td>" };
                                controls.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[8].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["RaisedBy"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[9].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader5["RequestedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["CarrierInformation"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["ReferenceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["JobNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["SupplierQuoteNO"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["SupplierInvoiceNo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader5["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader5["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["InvoiceReceived"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader5["PurchaseTotalincludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader5["PurchaseTotalexcludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["JobTitle"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                ControlCollection controlCollections = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;' class='divscroll' title='", base.Server.HtmlDecode(sqlDataReader5["ActivityNotes"].ToString().Replace("¶", "<br/>")), "'>", base.Server.HtmlDecode(sqlDataReader5["ActivityNotes"].ToString().Replace("¶", "<br/>")), "</div></td>" };
                                controlCollections.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["AccountingCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ItemCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[24].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["Description"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[25].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader5["ItemQuantity"].ToString()), "</div></td>")));
                            }
                            if (this.chkColumns.Items[26].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader5["PackedIn"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[27].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader5["Price"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[28].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader5["Tax"].ToString()), "</div></td>")));
                            }
                            if (this.chkColumns.Items[29].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader5["TaxValue"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[30].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["Notes"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[31].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader5["GoodsReceived"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[32].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactJobTitle1"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[33].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ContactJobTitle2"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[34].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["PaymentTerms"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[35].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["ItemTitle"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[36].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader5["InvoiceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[37].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader5["InvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            this.plhdetails.Controls.Add(new LiteralControl("<td width=1%></td></tr>"));
                        }
                        sqlConnection.Close();
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.lblTotalRecords.Text = num5.ToString();
                }
                else if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "2")
                {
                    int num7 = 0;
                    DataSet dataSet6 = new DataSet();
                    string str37 = string.Concat("select distinct datepart(month,a.CreatedDate) as estmonth,datepart(year,a.CreatedDate) as estyear ", empty, " order by estyear,estmonth ");
                    (new SqlDataAdapter(str37, sqlConnection)).Fill(dataSet6);
                    foreach (DataRow dataRow2 in dataSet6.Tables[0].Rows)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl("<table  boder=0 width=100% cellspacing=0 cellpadding=0>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='Left' style='font-weight:bold' >"));
                        Label label9 = new Label();
                        string str38 = string.Concat(this.Get2digit(dataRow2["estmonth"].ToString()), "/01/", dataRow2["estyear"].ToString());
                        DateTime dateTime4 = Convert.ToDateTime(str38);
                        DateTime dateTime5 = dateTime4.Subtract(TimeSpan.FromDays((double)(dateTime4.Day - 1)));
                        DateTime dateTime6 = dateTime5.AddMonths(1);
                        DateTime dateTime7 = dateTime6.Subtract(TimeSpan.FromDays(1));
                        str = new string[] { this.Get2digit(dataRow2["estmonth"].ToString()), "/", null, null, null };
                        string str39 = dateTime7.ToString();
                        chrArray = new char[] { ' ' };
                        string str40 = str39.Split(chrArray)[0];
                        chrArray = new char[] { '/' };
                        str[2] = str40.Split(chrArray)[1];
                        str[3] = "/";
                        str[4] = dataRow2["estyear"].ToString();
                        string str41 = string.Concat(str);
                        now = Convert.ToDateTime(str38);
                        label9.Text = string.Concat(now.ToString("MMMM"), "-", dataRow2["estyear"].ToString());
                        this.plhdetails.Controls.Add(label9);
                        this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<table width=100% style='padding:5px;' cellspacing=0 cellpadding=0 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>&nbsp;Purchase Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Created On</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Name</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Name</b>&nbsp;</div></td>"));
                        }
                        if (this.ddlContactAddress.SelectedValue == "1")
                        {
                            if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Country</b>&nbsp;</div></td>"));
                            }
                        }
                        else if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div style='min-width: 100px;'><div class='headerreport_divwidth200px'><b>Contact Address</b>&nbsp;</div></div></td>"));
                        }
                        if (this.ddlDeliveryAddress.SelectedValue == "1")
                        {
                            if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Country</b>&nbsp;</div></td>"));
                            }
                        }
                        else if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Address</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Comment/Delivery Instructions</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Status</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Raised By</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Purchase Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Carrier Information</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Reference Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Quote#</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Invoice#</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier InvoiceDate</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>DeliveryDate</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>InvoiceReceived</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Inc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Exc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Title</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Activity Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Accounting Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[23].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[24].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Description</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[25].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Quantity</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[26].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Packed In</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[27].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Price</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[28].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Tax</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[29].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Tax Value</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[30].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[31].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Goods Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[32].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 1</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[33].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 2</b>&nbsp;</div></td>"));
                        }
                        this.plhdetails.Controls.Add(new LiteralControl("<td width=1% align=right valign=top class='headerstylereport1'></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        StringBuilder stringBuilder9 = new StringBuilder();
                        companyID = new object[] { "select  ", stringBuilder, " ", empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str38, "' and '", str41, "'" };
                        stringBuilder9.Append(string.Concat(companyID));
                        stringBuilder9.Append(" order by a.PONO desc ");
                        SqlCommand sqlCommand6 = new SqlCommand(stringBuilder9.ToString(), sqlConnection)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
                        int num8 = 0;
                        if (!sqlDataReader6.HasRows)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr><td><table width=100% bordercolor=#DDDDDD cellspacing=0 cellpadding=0 border=0><tr><td colspan=10 class='normaltext' align='center'>No Records Found</td></tr>"));
                            this.plhdetails.Controls.Add(new LiteralControl("</table></td></tr>"));
                        }
                        while (sqlDataReader6.Read())
                        {
                            num7++;
                            num8++;
                            if (num8 % 2 != 0)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport>"));
                            }
                            if (this.chkColumns.Items[0].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["PONo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[1].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader6["CreatedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[2].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["Company"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[3].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlContactAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='10%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;' class='divscroll'><div style='min-width: 200px; max-height: 15px; height: 15px;'><div style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;'>", sqlDataReader6["ContactAddress"].ToString(), "&nbsp;</div></div></div></td>")));
                            }
                            if (this.ddlDeliveryAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[5].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["DeliveryAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["DeliveryAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["DeliveryAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["DeliveryAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["DeliveryAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["DeliveryAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='10%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;' class='divscroll'><div style='min-width: 200px; max-height: 15px; height: 15px;'><div style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;'>", sqlDataReader6["DeliveryAddress"].ToString(), "&nbsp;</div></div></div></td>")));
                            }
                            if (this.chkColumns.Items[6].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["CommentDeliveryInstructions"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[7].Selected)
                            {
                                ControlCollection controls1 = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;' class='divscroll' title='", sqlDataReader6["Status"].ToString(), "'>", sqlDataReader6["Status"].ToString(), "&nbsp;</div></td>" };
                                controls1.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[8].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["RaisedBy"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[9].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader6["RequestedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["CarrierInformation"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["ReferenceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["JobNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["SupplierQuoteNO"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["SupplierInvoiceNo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader6["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader6["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["InvoiceReceived"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader6["PurchaseTotalincludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader6["PurchaseTotalexcludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader6["JobTitle"].ToString()), "</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                ControlCollection controlCollections1 = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;' class='divscroll' title='", base.Server.HtmlDecode(sqlDataReader6["ActivityNotes"].ToString().Replace("¶", "<br/>")), "'>", base.Server.HtmlDecode(sqlDataReader6["ActivityNotes"].ToString().Replace("¶", "<br/>")), "</div></td>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["AccountingCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ItemCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[24].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["Description"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[25].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["ItemQuantity"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[26].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader6["PackedIn"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[27].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader6["Price"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[28].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["Tax"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[29].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader6["TaxValue"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[30].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["Notes"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[31].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader6["GoodsReceived"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[32].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactJobTitle1"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[33].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ContactJobTitle2"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[34].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["PaymentTerms"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[35].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["ItemTitle"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[36].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader6["InvoiceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[37].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader6["InvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            this.plhdetails.Controls.Add(new LiteralControl("<td width=1%></td></tr>"));
                        }
                        sqlConnection.Close();
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.lblTotalRecords.Text = num7.ToString();
                }
                else if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "3")
                {
                    int num9 = 0;
                    DataSet dataSet7 = new DataSet();
                    string str42 = string.Concat("select distinct datepart(year,a.CreatedDate) as estyear ", empty);
                    (new SqlDataAdapter(str42, sqlConnection)).Fill(dataSet7);
                    foreach (DataRow row3 in dataSet7.Tables[0].Rows)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl("<table boder=0 width=100% cellspacing=0 cellpadding=0>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' style='font-weight:bold' ><b>"));
                        Label label10 = new Label();
                        string str43 = string.Concat("01/01/", row3["estyear"].ToString());
                        string str44 = string.Concat("12/31/", row3["estyear"].ToString());
                        label10.Text = row3["estyear"].ToString();
                        this.plhdetails.Controls.Add(label10);
                        this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<table width=100% style='padding:5px;' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>&nbsp;Purchase Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Created On</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Name</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Name</b>&nbsp;</div></td>"));
                        }
                        if (this.ddlContactAddress.SelectedValue == "1")
                        {
                            if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Country</b>&nbsp;</div></td>"));
                            }
                        }
                        else if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Address</b>&nbsp;</div></td>"));
                        }
                        if (this.ddlDeliveryAddress.SelectedValue == "1")
                        {
                            if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Country</b>&nbsp;</div></td>"));
                            }
                        }
                        else if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Address</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Comment/Delivery Instructions</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Status</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Raised By</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Purchase Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Carrier Information</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Reference Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Quote#</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Invoice#</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier InvoiceDate</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Invoice Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Inc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Exc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Title</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Activity Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Accounting Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[23].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[24].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Description</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[25].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Quantity</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[26].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Packed In</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[27].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Price</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[28].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Tax</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[29].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>TaxValue</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[30].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[31].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Goods Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[32].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 1</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[33].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 2</b>&nbsp;</div></td>"));
                        }
                        this.plhdetails.Controls.Add(new LiteralControl("<td width=1% align=right valign=top class='headerstylereport1'></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        StringBuilder stringBuilder10 = new StringBuilder();
                        companyID = new object[] { "select ", stringBuilder, " ", empty, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str43, "' and '", str44, "'" };
                        stringBuilder10.Append(string.Concat(companyID));
                        stringBuilder10.Append(" order by a.PONO desc ");
                        SqlCommand sqlCommand7 = new SqlCommand(stringBuilder10.ToString(), sqlConnection)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
                        int num10 = 0;
                        if (!sqlDataReader7.HasRows)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr><td><table width=100% bordercolor=#DDDDDD cellspacing=0 cellpadding=0 border=0><tr><td colspan=10 class='normaltext' align='center'>No Records Found</td></tr>"));
                            this.plhdetails.Controls.Add(new LiteralControl("</table></td></tr>"));
                        }
                        while (sqlDataReader7.Read())
                        {
                            num9++;
                            num10++;
                            if (num10 % 2 != 0)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport>"));
                            }
                            if (this.chkColumns.Items[0].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["PONo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[1].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader7["CreatedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[2].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["Company"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[3].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlContactAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactAddress"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlDeliveryAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[5].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td align='left' width='5%' class='table-rowrpt' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 250px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[6].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["CommentDeliveryInstructions"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[7].Selected)
                            {
                                ControlCollection controls2 = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;' class='divscroll' title='", sqlDataReader7["Status"].ToString(), "'>", sqlDataReader7["Status"].ToString(), "&nbsp;</div></td>" };
                                controls2.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[8].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["RaisedBy"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[9].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader7["RequestedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["CarrierInformation"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["ReferenceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["JobNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["SupplierQuoteNO"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["SupplierInvoiceNo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader7["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader7["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["InvoiceReceived"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader7["PurchaseTotalincludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader7["PurchaseTotalexcludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["JobTitle"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                ControlCollection controlCollections2 = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;' class='divscroll' title='", base.Server.HtmlDecode(sqlDataReader7["ActivityNotes"].ToString().Replace("¶", "<br/>")), "'>", base.Server.HtmlDecode(sqlDataReader7["ActivityNotes"].ToString().Replace("¶", "<br/>")), "</div></td>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["AccountingCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["ItemCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[24].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["Description"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[25].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["ItemQuantity"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[26].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader7["PackedIn"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[27].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader7["Price"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[28].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["Tax"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[29].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader7["TaxValue"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[30].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["Notes"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[31].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader7["GoodsReceived"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[32].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactJobTitle1"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[33].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ContactJobTitle2"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[34].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["PaymentTerms"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[35].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["ItemTitle"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[36].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader7["InvoiceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[37].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader7["InvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            this.plhdetails.Controls.Add(new LiteralControl("<td width=1%></td></tr>"));
                        }
                        sqlConnection.Close();
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.lblTotalRecords.Text = num9.ToString();
                }
                else if (this.ddlsummarydetails.SelectedValue.ToString().Trim() == "4")
                {
                    int num11 = 0;
                    DataSet dataSet8 = new DataSet();
                    string str45 = string.Concat("select distinct Replace(Replace(Replace(ltrim(isnull(b.ClientName,'')),'%22','\"'),'%27%27',''''),'%27','''') as Company ", empty, " order by Company Asc  ");
                    (new SqlDataAdapter(str45, sqlConnection)).Fill(dataSet8);
                    foreach (DataRow dataRow3 in dataSet8.Tables[0].Rows)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl("<table boder=0 width=100% cellspacing=0 cellpadding=0>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' style='font-weight:bold' ><b>"));
                        Label label11 = new Label();
                        string empty10 = string.Empty;
                        empty10 = (dataRow3["Company"].ToString().Trim() != "" ? dataRow3["Company"].ToString() : "Not Specified");
                        label11.Text = base.SpecialDecode(empty10);
                        this.plhdetails.Controls.Add(label11);
                        this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("<table width=100% style='padding:5px;' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>&nbsp;Purchase Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Created On</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Name</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Name</b>&nbsp;</div></td>"));
                        }
                        if (this.ddlContactAddress.SelectedValue == "1")
                        {
                            if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Country</b>&nbsp;</div></td>"));
                            }
                        }
                        else if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Address</b>&nbsp;</div></td>"));
                        }
                        if (this.ddlDeliveryAddress.SelectedValue == "1")
                        {
                            if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Country</b>&nbsp;</div></td>"));
                            }
                        }
                        else if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='10%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Address</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Comment/Delivery Instructions</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Status</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Raised By</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Purchase Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Carrier Information</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Reference Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Number</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Quote#</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier Invoice#</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Supplier InvoiceDate</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Delivery Date</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Invoice Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Inc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Total(Exc.Tax) (", this.objJava.GetCurrencyinRequiredFormate("", true), ")</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Job Title</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Activity Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Accounting Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[23].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Code</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[24].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Description</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[25].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Item Quantity</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[26].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Packed In</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[27].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Price</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[28].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Tax</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[29].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='right' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>TaxValue</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[30].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Notes</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[31].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Goods Received</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[32].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 1</b>&nbsp;</div></td>"));
                        }
                        if (this.chkColumns.Items[33].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align=left width='15%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth200px'><b>Contact Job Title 2</b>&nbsp;</div></td>"));
                        }
                        this.plhdetails.Controls.Add(new LiteralControl("<td width=1% align=right valign=top class='headerstylereport1'></td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        StringBuilder stringBuilder11 = new StringBuilder();
                        if (dataRow3["Company"].ToString() != "")
                        {
                            companyID = new object[] { "select  ", stringBuilder, " ", empty, " and ltrim(b.ClientName)='", dataRow3["Company"], "'" };
                            stringBuilder11.Append(string.Concat(companyID));
                        }
                        else
                        {
                            companyID = new object[] { "select  ", stringBuilder, " ", empty, " and b.clientid is null" };
                            stringBuilder11.Append(string.Concat(companyID));
                        }
                        stringBuilder11.Append(" order by a.PONO desc ");
                        SqlCommand sqlCommand8 = new SqlCommand(stringBuilder11.ToString(), sqlConnection)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
                        int num12 = 0;
                        if (!sqlDataReader8.HasRows)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr><td><table width=100% bordercolor=#DDDDDD cellspacing=0 cellpadding=0 border=0><tr><td colspan=10 class='normaltext' align='center'>No Records Found</td></tr>"));
                            this.plhdetails.Controls.Add(new LiteralControl("</table></td></tr>"));
                        }
                        while (sqlDataReader8.Read())
                        {
                            num11++;
                            num12++;
                            if (num12 % 2 != 0)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr class='NewAlternativereport'>"));
                            }
                            if (this.chkColumns.Items[0].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["PONo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[1].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader8["CreatedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[2].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["Company"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[3].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlContactAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[4].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactAddress"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.ddlDeliveryAddress.SelectedValue == "1")
                            {
                                if (this.chkColumns.Items[5].Selected)
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress1"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress2"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress3"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress4"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress5"].ToString(), "&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress6"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                            else if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[6].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["CommentDeliveryInstructions"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[7].Selected)
                            {
                                ControlCollection controls3 = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 120px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll' title='", sqlDataReader8["Status"].ToString(), "'>", sqlDataReader8["Status"].ToString(), "&nbsp;</div></td>" };
                                controls3.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[8].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["RaisedBy"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[9].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader8["RequestedDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["CarrierInformation"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ReferenceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["JobNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["SupplierQuoteNO"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["SupplierInvoiceNo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader8["SupplierInvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader8["DeliveryDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["InvoiceReceived"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader8["PurchaseTotalincludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader8["PurchaseTotalexcludingtax"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["JobTitle"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                ControlCollection controlCollections3 = this.plhdetails.Controls;
                                str = new string[] { "<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px; word-break:break-all;' class='divscroll' title='", base.Server.HtmlDecode(sqlDataReader8["ActivityNotes"].ToString().Replace("¶", "<br/>")), "'>", base.Server.HtmlDecode(sqlDataReader8["ActivityNotes"].ToString().Replace("¶", "<br/>")), "</div></td>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(str)));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["AccountingCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["ItemCode"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[24].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["Description"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[25].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='right' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["ItemQuantity"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[26].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader8["PackedIn"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[27].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader8["Price"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[28].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["Tax"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[29].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=right width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader8["TaxValue"].ToString()), 0, "", false, false, true), "</div></td>")));
                            }
                            if (this.chkColumns.Items[30].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["Notes"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[31].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader8["GoodsReceived"].ToString(), "</div></td>")));
                            }
                            if (this.chkColumns.Items[32].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactJobTitle1"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[33].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ContactJobTitle2"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[34].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["PaymentTerms"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[35].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["ItemTitle"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[36].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader8["InvoiceNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[37].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align=left width='15%' style='vertical-align:middle' nowwrap='nowwrap'><div id='division' style='overflow:auto;height:15px;min-width: 100px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader8["InvoiceDate"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            this.plhdetails.Controls.Add(new LiteralControl("<td width=1%></td></tr>"));
                        }
                        sqlConnection.Close();
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.lblTotalRecords.Text = num11.ToString();
                }
                if (!this.rdosummary.Checked && !this.rdodetail.Checked)
                {
                    foreach (DataRow row4 in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine(row4[0].ToString());
                    }
                }
            }
            catch
            {
            }
            return dataSet;
        }

        public void GetPageBind(int PageNumber)
        {
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            DataSet estimateData = this.GetEstimateData(PageNumber);
            if (this.rdodetail.Checked || this.rdosummary.Checked)
            {
                this.GridEstReport.Visible = false;
                this.usrPaging.Visible = false;
                this.div_Total.Visible = true;
                return;
            }
            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
            if (estimateData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            DataTable dt = SetPurchaseReportColumns(estimateData);
            this.GridEstReport.DataSource = dt;
            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
            this.GridEstReport.DataBind();
            this.usrPaging.Visible = false;
            pagingreport.intCurrentPage = PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        [WebMethod]
        public static string GetSupplierName(string val)
        {
            string[] strArrays = val.Split(new char[] { '&' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            CompanyBasePage companyBasePage = new CompanyBasePage();
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = companyBasePage.company_autocomplete(Convert.ToInt32(str), "Supplier", baseClass.ReplaceSingleQuote(str1));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["ClientID"].ToString();
                empty1 = row["ClientName"].ToString();
                empty2 = row["Contacts"].ToString();
                str2 = row["CustomizedValue"].ToString();
                empty3 = companyBasePage.default_address_select(Convert.ToInt32(str), Convert.ToInt32(empty));
                string[] strArrays1 = new string[] { empty, "$", empty1, "$", empty2, "$", str2, "$", empty3, "µ" };
                empty4 = string.Concat(empty4, string.Concat(strArrays1));
            }
            return empty4;
        }

        private void GridEstReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                this.pnlGridview.Visible = true;
                for (int i = 0; i < e.Row.Controls.Count; i++)
                {
                    e.Row.Cells[0].Visible = false;
                    if (e.Row.Cells[i].Text.ToLower() == "pono")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Purchase_Number");
                        this.cellvalue_PONO = i;
                        this.flag_PONO = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "createddate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Created_On");
                        this.cellvalue_createdOn = i;
                        this.flag_createdOn = "true";
                        e.Row.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "company")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Supplier_Name");
                        this.cellvalue_company = i;
                        this.flag_company = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "contactname")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "contactjobtitle1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title1");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "contactjobtitle2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title2");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "paymentterms")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Payment_Terms");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "itemtitle")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Item_Title");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "invoicenumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Invoice_Number");
                    }
                    //if (e.Row.Cells[i].Text.ToLower() == "invoicedate")
                    //{
                    //    e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Invoice_Date");
                    //}
                    if (e.Row.Cells[i].Text.ToLower() == "contactaddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Address");
                        this.cellvalue_contactAddress = i;
                        this.flag_contactaddress = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "deliveryaddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Address");
                        this.cellvalue_deliveryaddress = i;
                        this.flag_deliveryaddress = "true";
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "ContactAddress1", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[1].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "ContactAddress2", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[2].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "ContactAddress3", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[3].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "ContactAddress4", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[4].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "ContactAddress5", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[5].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "ContactAddress6", true) == 0)
                    {
                        e.Row.Cells[i].Text = "Contact Country";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "DeliveryAddress1", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Delivery ", this.Chk_addressList.Items[1].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "DeliveryAddress2", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Delivery ", this.Chk_addressList.Items[2].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "DeliveryAddress3", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Delivery ", this.Chk_addressList.Items[3].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "DeliveryAddress4", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Delivery ", this.Chk_addressList.Items[4].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "DeliveryAddress5", true) == 0)
                    {
                        e.Row.Cells[i].Text = string.Concat("Delivery ", this.Chk_addressList.Items[5].Text.ToString());
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (string.Compare(e.Row.Cells[i].Text.ToLower(), "DeliveryAddress6", true) == 0)
                    {
                        e.Row.Cells[i].Text = "Delivery Country";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "commentdeliveryinstructions")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Comment_Delivery_Instructions");
                        this.cellvalue_commentdelivery = i;
                        this.flag_commentdelivery = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "status")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Status");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "raisedby")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Raised_By");
                        this.cellvalue_raisedBy = i;
                        this.flag_raisedBy = "true";
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "requesteddate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Purchase_Date");
                        this.cellvalue_reqDate = i;
                        this.flag_reqDate = "true";
                        e.Row.Cells[this.cellvalue_reqDate].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "carrierinformation")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Carrier_Information");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "referencenumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Reference_Number");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "jobnumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Number");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "supplierquoteno")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Supp_Quote");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "supplierinvoiceno")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Supp_Inv");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "supplierinvoicedate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Supplier_Invoice_Date");
                        this.cellvalue_supplierinvoicedate = i;
                        this.flag_supplierinvoicedate = "true";
                        e.Row.Cells[this.cellvalue_supplierinvoicedate].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "invoicedate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Invoice_Date");
                        this.cellvalue_invoicedate = i;
                        this.flag_invoicedate = "true";
                        e.Row.Cells[this.cellvalue_invoicedate].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "deliverydate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
                        this.cellvalue_deliverydate = i;
                        this.flag_deliverydate = "true";
                        e.Row.Cells[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "invoicereceived")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Invoice_Received");
                    }
                    if (e.Row.Cells[i].Text == "PurchaseTotalincludingtax")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Total_Incl_Tax"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.cellvalue_taxval = i;
                        this.flag_taxval = "true";
                        e.Row.Cells[this.cellvalue_taxval].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text == "PurchaseTotalexcludingtax")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Total_Ex_Tax"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.cellvalue_ExTaxvalue = i;
                        this.flag_ExTaxvalue = "true";
                        e.Row.Cells[this.cellvalue_ExTaxvalue].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text == "ActivityNotes")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Activity_Notes");
                        this.cellvalue_ActivityNotes = i;
                        this.flag_activitynotes = "true";
                        e.Row.Cells[this.cellvalue_ActivityNotes].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text == "JobTitle")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Title");
                        this.cellvalue_JobTitle = i;
                        this.flag_JobTitle = "true";
                    }
                    if (e.Row.Cells[i].Text == "AccountingCode")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Accounting_Code");
                    }
                    if (e.Row.Cells[i].Text == "ItemQuantity")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Item_Quantity");
                        this.cellvalue_ItemQuantity = i;
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.flag_ItemQuantity = "true";
                    }
                    if (e.Row.Cells[i].Text == "ItemCode")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Item_Code");
                        this.cellvalue_ItemCode = i;
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.flag_ItemCode = "true";
                        e.Row.Cells[this.cellvalue_ItemCode].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text == "Description")
                    {
                        this.flag_Description = "true";
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Description");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        this.cellvalue_Description = i;
                    }
                    if (e.Row.Cells[i].Text == "PackedIn")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Packed_In");
                        this.cellvalue_PackedIn = i;
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.flag_PackedIn = "true";
                        e.Row.Cells[this.cellvalue_PackedIn].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text == "Price")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Price");
                        this.cellvalue_Price = i;
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.flag_Price = "true";
                        e.Row.Cells[this.cellvalue_Price].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text == "Tax")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Tax");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        this.cellvalue_Tax = i;
                        this.flag_Tax = "true";
                    }
                    if (e.Row.Cells[i].Text == "TaxValue")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Tax_Value");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_Tax_Value = i;
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.flag_Tax_Value = "true";
                        e.Row.Cells[this.cellvalue_Tax_Value].Attributes.Add("align", "right");
                    }
                    if (e.Row.Cells[i].Text == "Notes")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Notes");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text == "GoodsReceived")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Goods_Received");
                        e.Row.Cells[i].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate1")
                    {
                        e.Row.Cells[i].Text = "CustomDate1";
                        this.cellvalue_CustomDate1 = i;
                        this.flag_CustomDate1 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate1].Attributes.Add("align", "left");
                    }

                    if (e.Row.Cells[i].Text.ToLower() == "customdate2")
                    {
                        e.Row.Cells[i].Text = "CustomDate2";
                        this.cellvalue_CustomDate2 = i;
                        this.flag_CustomDate2 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate2].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate3")
                    {
                        e.Row.Cells[i].Text = "CustomDate3";
                        this.cellvalue_CustomDate3 = i;
                        this.flag_CustomDate3 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate3].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate4")
                    {
                        e.Row.Cells[i].Text = "CustomDate4";
                        this.cellvalue_CustomDate4 = i;
                        this.flag_CustomDate4 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate4].Attributes.Add("align", "left");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "customdate5")
                    {
                        e.Row.Cells[i].Text = "CustomDate5";
                        this.cellvalue_CustomDate5 = i;
                        this.flag_CustomDate5 = "true";
                        e.Row.Cells[i].Attributes.Add("align", "left");
                        e.Row.Cells[this.cellvalue_CustomDate5].Attributes.Add("align", "left");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.pnlGridview.Visible = true;
                e.Row.Cells[0].Visible = false;
                if (this.flag_createdOn == "true")
                {
                    e.Row.Cells[this.cellvalue_createdOn].Attributes.Add("align", "center");
                    e.Row.Cells[this.cellvalue_createdOn].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_createdOn].Text, this.CompanyID, this.UserID, false), "</div>");
                }
                if (this.flag_supplierinvoicedate == "true")
                {
                    e.Row.Cells[this.cellvalue_supplierinvoicedate].Attributes.Add("align", "center");
                    e.Row.Cells[this.cellvalue_supplierinvoicedate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_supplierinvoicedate].Text, this.CompanyID, this.UserID, false), "</div>");
                }
                if (this.flag_invoicedate == "true")
                {
                    e.Row.Cells[this.cellvalue_invoicedate].Attributes.Add("align", "center");
                    e.Row.Cells[this.cellvalue_invoicedate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_invoicedate].Text, this.CompanyID, this.UserID, false), "</div>");
                }
                if (this.flag_deliverydate == "true")
                {
                    e.Row.Cells[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    e.Row.Cells[this.cellvalue_deliverydate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false), "</div>");
                }
                if (this.flag_reqDate == "true")
                {
                    e.Row.Cells[this.cellvalue_reqDate].Attributes.Add("align", "center");
                    e.Row.Cells[this.cellvalue_reqDate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_reqDate].Text, this.CompanyID, this.UserID, false), "</div>");
                }
                if (this.flag_taxval == "true")
                {
                    e.Row.Cells[this.cellvalue_taxval].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_taxval].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_taxval].Text), 0, "", false, false, true), "</div>");
                }
                if (this.flag_ExTaxvalue == "true")
                {
                    e.Row.Cells[this.cellvalue_ExTaxvalue].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_ExTaxvalue].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_ExTaxvalue].Text), 0, "", false, false, true), "</div>");
                }
                if (this.flag_company == "true")
                {
                    e.Row.Cells[this.cellvalue_company].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_company].Text), "</div>");
                }
                if (this.flag_contactaddress == "true")
                {
                    e.Row.Cells[this.cellvalue_contactAddress].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_contactAddress].Text), "</div>");
                }
                if (this.flag_deliveryaddress == "true")
                {
                    e.Row.Cells[this.cellvalue_deliveryaddress].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_deliveryaddress].Text), "</div>");
                }
                if (this.flag_commentdelivery == "true")
                {
                    e.Row.Cells[this.cellvalue_commentdelivery].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_commentdelivery].Text), "</div>");
                }
                if (this.flag_raisedBy == "true")
                {
                    e.Row.Cells[this.cellvalue_raisedBy].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_raisedBy].Text), "</div>");
                }
                if (this.flag_Description == "true")
                {
                    e.Row.Cells[this.cellvalue_Description].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_Description].Text), "</div>");
                }
                if (this.flag_JobTitle == "true")
                {
                    e.Row.Cells[this.cellvalue_JobTitle].Text = string.Concat("<div style='min-width: 100px ;width: 150px ;overflow:hidden;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_JobTitle].Text), "</div>");
                }
                if (this.flag_Tax == "true")
                {
                    e.Row.Cells[this.cellvalue_Tax].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cellvalue_Tax].Text), "</div>");
                }
                if (this.flag_ItemQuantity == "true")
                {
                    try
                    {
                        e.Row.Cells[this.cellvalue_ItemQuantity].Attributes.Add("align", "right");
                        e.Row.Cells[this.cellvalue_ItemQuantity].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.ToRemoveDecimalPlacesIfZero(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_ItemQuantity].Text), 0, "", false, false, true)), "</div>");
                    }
                    catch
                    {
                    }
                }
                if (this.flag_PackedIn == "true")
                {
                    e.Row.Cells[this.cellvalue_PackedIn].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_PackedIn].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_PackedIn].Text), 0, "", false, false, true), "</div>");
                }
                if (this.flag_Price == "true")
                {
                    e.Row.Cells[this.cellvalue_Price].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_Price].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_Price].Text), 0, "", false, false, true), "</div>");
                }
                if (this.flag_Tax_Value == "true")
                {
                    e.Row.Cells[this.cellvalue_Tax_Value].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_Tax_Value].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_Tax_Value].Text), 0, "", false, false, true), "</div>");
                }
                if (this.flag_ItemCode == "true")
                {
                    e.Row.Cells[this.cellvalue_ItemCode].Attributes.Add("align", "right");
                }
                for (int j = 0; j < e.Row.Cells.Count; j++)
                {
                    string str = e.Row.Cells[this.cellvalue_ActivityNotes].Text.Replace("¶", "<br/>");
                    this.lblActivityNotes.Text = base.Server.HtmlDecode(str);
                    e.Row.Cells[this.cellvalue_ActivityNotes].Text = this.lblActivityNotes.Text;
                    string str1 = e.Row.Cells[this.cellvalue_Description].Text.Replace("¶", "<br/>");
                    this.lblDescription.Text = base.Server.HtmlDecode(str1);
                    e.Row.Cells[this.cellvalue_Description].Text = this.lblDescription.Text;
                    if (e.Row.Cells.Count == 5)
                    {
                        e.Row.Cells[j].Text = string.Concat("<div style='min-width: 20%;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", e.Row.Cells[j].Text, "</div></div>");
                    }
                    if (e.Row.Cells.Count == 4)
                    {
                        e.Row.Cells[j].Text = string.Concat("<div style='min-width: 25%;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", e.Row.Cells[j].Text, "</div></div>");
                    }
                    if (e.Row.Cells.Count == 3)
                    {
                        e.Row.Cells[j].Text = string.Concat("<div style='min-width: 33.3% ;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", e.Row.Cells[j].Text, "</div></div>");
                    }
                    if (e.Row.Cells.Count == 2)
                    {
                        e.Row.Cells[j].Text = string.Concat("<div style='min-width: 50% ;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", e.Row.Cells[j].Text, "</div></div>");
                    }
                    if (e.Row.Cells.Count == 1)
                    {
                        e.Row.Cells[j].Text = string.Concat("<div style='min-width: 100% ;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", e.Row.Cells[j].Text, "</div></div>");
                    }
                }
            }
        }
        protected void GridPurchase_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (base.IsPostBack)
            {
                DataSet purchaseData = this.GetEstimateData(this.PageNumber);
                DataTable dt = SetPurchaseReportColumns(purchaseData);
                this.GridEstReport.DataSource = dt;
            }

        }
        protected void GridPurchase_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageNumber = e.NewPageIndex + 1;
        }

        protected void GridPurchase_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageSize = e.NewPageSize;
        }
        protected void GridPurchaseReport_OnDataBound(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected && (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21))
                {
                    num++;
                }
            }
            this.GridEstReport.HeaderStyle.CssClass = "commonheaderstylereport1";
        }


        public string Lastweek()
        {
            DateTime today = DateTime.Today;
            DayOfWeek currentDayOfWeek = today.DayOfWeek;

            // Calculate the start date of last week
            DateTime lastWeekStartDate = today.AddDays(-(int)currentDayOfWeek - 6);

            // Calculate the end date of last week
            DateTime lastWeekEndDate = lastWeekStartDate.AddDays(6);

            return lastWeekStartDate.ToString() + "," + lastWeekEndDate.ToString();
        }
        public string Lastmonth()
        {
            DateTime today = DateTime.Today;

            // Get the first day of the current month
            DateTime firstDayOfThisMonth = new DateTime(today.Year, today.Month, 1);

            // Get the last day of the previous month
            DateTime lastDayOfLastMonth = firstDayOfThisMonth.AddDays(-1);

            // Get the first day of the previous month
            DateTime firstDayOfLastMonth = new DateTime(lastDayOfLastMonth.Year, lastDayOfLastMonth.Month, 1);



            return firstDayOfLastMonth.ToString() + "," + lastDayOfLastMonth.ToString();
        }
        public string Lastyear()
        {
            DateTime currentDate = DateTime.Today;

            // Get start date of last year
            DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);

            // Get end date of last year
            DateTime lastYearEndDate = new DateTime(currentDate.Year - 1, 12, 31);


            return lastYearStartDate.ToString() + "," + lastYearEndDate.ToString();
        }

        public string HalfFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            int month = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.ToString());
            int num = dateTime.Month;
            DateTime dateTime3 = dateTime.AddMonths(5);
            int month1 = dateTime3.Month;
            int year = 0;
            int num1 = 0;
            int month2 = dateTime.Month;
            int num2 = dateTime2.Month;
            int month3 = dateTime3.Month;
            if (num <= 7)
            {
                num1 = DateTime.DaysInMonth(dateTime.Year, month1);
            }
            else
            {
                year = dateTime.AddYears(1).Year;
                num1 = DateTime.DaysInMonth(year, month1);
            }
            if (num2 <= month1 || dateTime2.Year != dateTime3.Year)
            {
                dateTimeArray[0] = new DateTime(dateTime.Year, num, 1);
                dateTimeArray[1] = new DateTime(dateTime3.Year, month1, num1);
            }
            else
            {
                dateTimeArray[0] = new DateTime(dateTime3.Year, month1 + 1, 1);
                dateTimeArray[1] = dateTime1;
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string LastQuarter()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime.Month;
            DateTime dateTime1 = new DateTime();
            dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int num = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (num == 1)
            {
                if (month == 1 || month == 2 || month == 3)
                {
                    int month1 = dateTime.Month;
                    if (month1 == 1)
                    {
                        int num1 = month1 + 11;
                        month1 = month1 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num1, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                    else if (month1 == 2)
                    {
                        int num2 = month1 + 10;
                        month1 = month1 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num2, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                    else if (month1 == 3)
                    {
                        int num3 = month1 + 9;
                        month1 = month1 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num3, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month2 = dateTime.Month;
                    if (month2 == 4)
                    {
                        month2 = month2 - 3;
                        int num4 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num4, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                    else if (month2 == 5)
                    {
                        month2 = month2 - 4;
                        int num5 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num5, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                    else if (month2 == 6)
                    {
                        month2 = month2 - 5;
                        int num6 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num6, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month3 = dateTime.Month;
                    if (month3 == 7)
                    {
                        month3 = month3 - 3;
                        int num7 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num7, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                    else if (month3 == 8)
                    {
                        month3 = month3 - 4;
                        int num8 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num8, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                    else if (month3 == 9)
                    {
                        month3 = month3 - 5;
                        int num9 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num9, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month4 = dateTime.Month;
                    if (month4 == 10)
                    {
                        month4 = month4 - 3;
                        int num10 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num10, DateTime.DaysInMonth(dateTime.Year, num10));
                    }
                    if (month4 == 11)
                    {
                        month4 = month4 - 4;
                        int num11 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num11, DateTime.DaysInMonth(dateTime.Year, num11));
                    }
                    else if (month4 == 12)
                    {
                        month4 = month4 - 5;
                        int num12 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num12, DateTime.DaysInMonth(dateTime.Year, num12));
                    }
                }
            }
            if (num == 2)
            {
                if (month == 2 || month == 3 || month == 4)
                {
                    int month5 = dateTime.Month;
                    if (month5 == 2)
                    {
                        int num13 = month5 - 1;
                        month5 = month5 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num13, DateTime.DaysInMonth(dateTime.Year, num13));
                    }
                    else if (month5 == 3)
                    {
                        int num14 = month5 - 2;
                        month5 = month5 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num14, DateTime.DaysInMonth(dateTime.Year, num14));
                    }
                    else if (month5 == 4)
                    {
                        int num15 = month5 - 3;
                        month5 = month5 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num15, DateTime.DaysInMonth(dateTime.Year, num15));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month6 = dateTime.Month;
                    if (month6 == 5)
                    {
                        int num16 = month6 - 1;
                        month6 = month6 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num16, DateTime.DaysInMonth(dateTime.Year, num16));
                    }
                    else if (month6 == 6)
                    {
                        int num17 = month6 - 2;
                        month6 = month6 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num17, DateTime.DaysInMonth(dateTime.Year, num17));
                    }
                    else if (month6 == 7)
                    {
                        int num18 = month6 - 3;
                        month6 = month6 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num18, DateTime.DaysInMonth(dateTime.Year, num18));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month7 = dateTime.Month;
                    if (month7 == 8)
                    {
                        int num19 = month7 - 1;
                        month7 = month7 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num19, DateTime.DaysInMonth(dateTime.Year, num19));
                    }
                    else if (month7 == 9)
                    {
                        int num20 = month7 - 2;
                        month7 = month7 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num20, DateTime.DaysInMonth(dateTime.Year, num20));
                    }
                    else if (month7 == 10)
                    {
                        int num21 = month7 - 3;
                        month7 = month7 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num21, DateTime.DaysInMonth(dateTime.Year, num21));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month8 = dateTime.Month;
                    if (month8 == 11)
                    {
                        int num22 = month8 - 1;
                        month8 = month8 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num22, DateTime.DaysInMonth(dateTime.Year, num22));
                    }
                    if (month8 == 12)
                    {
                        int num23 = month8 - 2;
                        month8 = month8 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num23, DateTime.DaysInMonth(dateTime.Year, num23));
                    }
                    else if (month8 == 1)
                    {
                        int num24 = month8 + 9;
                        month8 = month8 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num24, DateTime.DaysInMonth(dateTime.Year, num24));
                    }
                }
            }
            if (num == 3)
            {
                if (month == 3 || month == 4 || month == 5)
                {
                    int month9 = dateTime.Month;
                    if (month9 == 3)
                    {
                        int num25 = month9 - 1;
                        month9 = month9 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num25, DateTime.DaysInMonth(dateTime.Year, num25));
                    }
                    else if (month9 == 4)
                    {
                        int num26 = month9 - 2;
                        month9 = month9 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num26, DateTime.DaysInMonth(dateTime.Year, num26));
                    }
                    else if (month9 == 5)
                    {
                        int num27 = month9 - 3;
                        month9 = month9 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num27, DateTime.DaysInMonth(dateTime.Year, num27));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month10 = dateTime.Month;
                    if (month10 == 6)
                    {
                        int num28 = month10 - 1;
                        month10 = month10 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num28, DateTime.DaysInMonth(dateTime.Year, num28));
                    }
                    else if (month10 == 7)
                    {
                        int num29 = month10 - 2;
                        month10 = month10 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num29, DateTime.DaysInMonth(dateTime.Year, num29));
                    }
                    else if (month10 == 8)
                    {
                        int num30 = month10 - 3;
                        month10 = month10 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num30, DateTime.DaysInMonth(dateTime.Year, num30));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month11 = dateTime.Month;
                    if (month11 == 9)
                    {
                        int num31 = month11 - 1;
                        month11 = month11 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num31, DateTime.DaysInMonth(dateTime.Year, num31));
                    }
                    else if (month11 == 10)
                    {
                        int num32 = month11 - 2;
                        month11 = month11 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num32, DateTime.DaysInMonth(dateTime.Year, num32));
                    }
                    else if (month11 == 11)
                    {
                        int num33 = month11 - 3;
                        month11 = month11 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num33, DateTime.DaysInMonth(dateTime.Year, num33));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month12 = dateTime.Month;
                    if (month12 == 12)
                    {
                        int num34 = month12 - 1;
                        month12 = month12 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num34, DateTime.DaysInMonth(dateTime.Year, num34));
                    }
                    if (month12 == 1)
                    {
                        int num35 = month12 + 10;
                        month12 = month12 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num35, DateTime.DaysInMonth(dateTime.Year, num35));
                    }
                    else if (month12 == 2)
                    {
                        int num36 = month12 + 9;
                        month12 = month12 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num36, DateTime.DaysInMonth(dateTime.Year, num36));
                    }
                }
            }
            if (num == 4)
            {
                if (month == 4 || month == 5 || month == 6)
                {
                    int month13 = dateTime.Month;
                    if (month13 == 4)
                    {
                        int num37 = month13 - 1;
                        month13 = month13 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num37, DateTime.DaysInMonth(dateTime.Year, num37));
                    }
                    else if (month13 == 5)
                    {
                        int num38 = month13 - 2;
                        month13 = month13 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num38, DateTime.DaysInMonth(dateTime.Year, num38));
                    }
                    else if (month13 == 6)
                    {
                        int num39 = month13 - 3;
                        month13 = month13 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num39, DateTime.DaysInMonth(dateTime.Year, num39));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month14 = dateTime.Month;
                    if (month14 == 7)
                    {
                        int num40 = month14 - 1;
                        month14 = month14 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num40, DateTime.DaysInMonth(dateTime.Year, num40));
                    }
                    else if (month14 == 8)
                    {
                        int num41 = month14 - 2;
                        month14 = month14 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num41, DateTime.DaysInMonth(dateTime.Year, num41));
                    }
                    else if (month14 == 9)
                    {
                        int num42 = month14 - 3;
                        month14 = month14 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num42, DateTime.DaysInMonth(dateTime.Year, num42));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month15 = dateTime.Month;
                    if (month15 == 10)
                    {
                        int num43 = month15 - 1;
                        month15 = month15 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num43, DateTime.DaysInMonth(dateTime.Year, num43));
                    }
                    else if (month15 == 11)
                    {
                        int num44 = month15 - 2;
                        month15 = month15 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num44, DateTime.DaysInMonth(dateTime.Year, num44));
                    }
                    else if (month15 == 12)
                    {
                        int num45 = month15 - 3;
                        month15 = month15 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num45, DateTime.DaysInMonth(dateTime.Year, num45));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month16 = dateTime.Month;
                    if (month16 == 1)
                    {
                        int num46 = month16 + 11;
                        month16 = month16 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num46, DateTime.DaysInMonth(dateTime.Year, num46));
                    }
                    if (month16 == 2)
                    {
                        int num47 = month16 + 10;
                        month16 = month16 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num47, DateTime.DaysInMonth(dateTime.Year, num47));
                    }
                    else if (month16 == 3)
                    {
                        int num48 = month16 + 9;
                        month16 = month16 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num48, DateTime.DaysInMonth(dateTime.Year, num48));
                    }
                }
            }
            if (num == 5)
            {
                if (month == 5 || month == 6 || month == 7)
                {
                    int month17 = dateTime.Month;
                    if (month17 == 5)
                    {
                        int num49 = month17 - 1;
                        month17 = month17 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num49, DateTime.DaysInMonth(dateTime.Year, num49));
                    }
                    else if (month17 == 6)
                    {
                        int num50 = month17 - 2;
                        month17 = month17 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num50, DateTime.DaysInMonth(dateTime.Year, num50));
                    }
                    else if (month17 == 7)
                    {
                        int num51 = month17 - 3;
                        month17 = month17 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num51, DateTime.DaysInMonth(dateTime.Year, num51));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month18 = dateTime.Month;
                    if (month18 == 8)
                    {
                        int num52 = month18 - 1;
                        month18 = month18 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num52, DateTime.DaysInMonth(dateTime.Year, num52));
                    }
                    else if (month18 == 9)
                    {
                        int num53 = month18 - 2;
                        month18 = month18 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num53, DateTime.DaysInMonth(dateTime.Year, num53));
                    }
                    else if (month18 == 10)
                    {
                        int num54 = month18 - 3;
                        month18 = month18 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num54, DateTime.DaysInMonth(dateTime.Year, num54));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month19 = dateTime.Month;
                    if (month19 == 11)
                    {
                        int num55 = month19 - 1;
                        month19 = month19 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num55, DateTime.DaysInMonth(dateTime.Year, num55));
                    }
                    else if (month19 == 12)
                    {
                        int num56 = month19 - 2;
                        month19 = month19 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num56, DateTime.DaysInMonth(dateTime.Year, num56));
                    }
                    else if (month19 == 1)
                    {
                        int num57 = month19 + 7;
                        month19 = month19 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num57, DateTime.DaysInMonth(dateTime.Year, num57));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month20 = dateTime.Month;
                    if (month20 == 2)
                    {
                        int num58 = month20 - 1;
                        month20 = month20 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num58, DateTime.DaysInMonth(dateTime.Year, num58));
                    }
                    if (month20 == 3)
                    {
                        int num59 = month20 - 2;
                        month20 = month20 - 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num59, DateTime.DaysInMonth(dateTime.Year, num59));
                    }
                    else if (month20 == 4)
                    {
                        int num60 = month20 - 3;
                        month20 = month20 - 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num60, DateTime.DaysInMonth(dateTime.Year, num60));
                    }
                }
            }
            if (num == 6)
            {
                if (month == 6 || month == 7 || month == 8)
                {
                    int month21 = dateTime.Month;
                    if (month21 == 6)
                    {
                        int num61 = month21 - 1;
                        month21 = month21 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num61, DateTime.DaysInMonth(dateTime.Year, num61));
                    }
                    else if (month21 == 7)
                    {
                        int num62 = month21 - 2;
                        month21 = month21 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num62, DateTime.DaysInMonth(dateTime.Year, num62));
                    }
                    else if (month21 == 8)
                    {
                        int num63 = month21 - 3;
                        month21 = month21 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num63, DateTime.DaysInMonth(dateTime.Year, num63));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month22 = dateTime.Month;
                    if (month22 == 9)
                    {
                        int num64 = month22 - 1;
                        month22 = month22 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num64, DateTime.DaysInMonth(dateTime.Year, num64));
                    }
                    else if (month22 == 10)
                    {
                        int num65 = month22 - 2;
                        month22 = month22 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num65, DateTime.DaysInMonth(dateTime.Year, num65));
                    }
                    else if (month22 == 11)
                    {
                        int num66 = month22 - 3;
                        month22 = month22 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num66, DateTime.DaysInMonth(dateTime.Year, num66));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month23 = dateTime.Month;
                    if (month23 == 12)
                    {
                        int num67 = month23 - 1;
                        month23 = month23 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num67, DateTime.DaysInMonth(dateTime.Year, num67));
                    }
                    else if (month23 == 1)
                    {
                        int num68 = month23 + 10;
                        month23 = month23 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num68, DateTime.DaysInMonth(dateTime.Year, num68));
                    }
                    else if (month23 == 2)
                    {
                        int num69 = month23 + 9;
                        month23 = month23 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num69, DateTime.DaysInMonth(dateTime.Year, num69));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month24 = dateTime.Month;
                    if (month24 == 3)
                    {
                        int num70 = month24 - 1;
                        month24 = month24 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num70, DateTime.DaysInMonth(dateTime.Year, num70));
                    }
                    if (month24 == 4)
                    {
                        int num71 = month24 - 2;
                        month24 = month24 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num71, DateTime.DaysInMonth(dateTime.Year, num71));
                    }
                    else if (month24 == 5)
                    {
                        int num72 = month24 - 3;
                        month24 = month24 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num72, DateTime.DaysInMonth(dateTime.Year, num72));
                    }
                }
            }
            if (num == 7)
            {
                if (month == 7 || month == 8 || month == 9)
                {
                    int month25 = dateTime.Month;
                    if (month25 == 7)
                    {
                        int num73 = month25 - 1;
                        month25 = month25 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num73, DateTime.DaysInMonth(dateTime.Year, num73));
                    }
                    else if (month25 == 8)
                    {
                        int num74 = month25 - 2;
                        month25 = month25 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num74, DateTime.DaysInMonth(dateTime.Year, num74));
                    }
                    else if (month25 == 9)
                    {
                        int num75 = month25 - 3;
                        month25 = month25 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num75, DateTime.DaysInMonth(dateTime.Year, num75));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month26 = dateTime.Month;
                    if (month26 == 10)
                    {
                        int num76 = month26 - 1;
                        month26 = month26 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num76, DateTime.DaysInMonth(dateTime.Year, num76));
                    }
                    else if (month26 == 11)
                    {
                        int num77 = month26 - 2;
                        month26 = month26 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num77, DateTime.DaysInMonth(dateTime.Year, num77));
                    }
                    else if (month26 == 12)
                    {
                        int num78 = month26 - 3;
                        month26 = month26 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num78, DateTime.DaysInMonth(dateTime.Year, num78));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month27 = dateTime.Month;
                    if (month27 == 1)
                    {
                        int num79 = month27 + 11;
                        month27 = month27 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num79, DateTime.DaysInMonth(dateTime.Year, num79));
                    }
                    else if (month27 == 2)
                    {
                        int num80 = month27 + 10;
                        month27 = month27 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num80, DateTime.DaysInMonth(dateTime.Year, num80));
                    }
                    else if (month27 == 3)
                    {
                        int num81 = month27 + 9;
                        month27 = month27 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num81, DateTime.DaysInMonth(dateTime.Year, num81));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month28 = dateTime.Month;
                    if (month28 == 4)
                    {
                        int num82 = month28 - 1;
                        month28 = month28 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num82, DateTime.DaysInMonth(dateTime.Year, num82));
                    }
                    if (month28 == 5)
                    {
                        int num83 = month28 - 2;
                        month28 = month28 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num83, DateTime.DaysInMonth(dateTime.Year, num83));
                    }
                    else if (month28 == 6)
                    {
                        int num84 = month28 - 3;
                        month28 = month28 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num84, DateTime.DaysInMonth(dateTime.Year, num84));
                    }
                }
            }
            if (num == 8)
            {
                if (month == 8 || month == 9 || month == 10)
                {
                    int month29 = dateTime.Month;
                    if (month29 == 8)
                    {
                        int num85 = month29 - 1;
                        month29 = month29 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num85, DateTime.DaysInMonth(dateTime.Year, num85));
                    }
                    else if (month29 == 9)
                    {
                        int num86 = month29 - 2;
                        month29 = month29 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num86, DateTime.DaysInMonth(dateTime.Year, num86));
                    }
                    else if (month29 == 10)
                    {
                        int num87 = month29 - 3;
                        month29 = month29 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num87, DateTime.DaysInMonth(dateTime.Year, num87));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month30 = dateTime.Month;
                    if (month30 == 11)
                    {
                        int num88 = month30 - 1;
                        month30 = month30 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num88, DateTime.DaysInMonth(dateTime.Year, num88));
                    }
                    else if (month30 == 12)
                    {
                        int num89 = month30 - 2;
                        month30 = month30 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num89, DateTime.DaysInMonth(dateTime.Year, num89));
                    }
                    else if (month30 == 1)
                    {
                        int num90 = month30 + 9;
                        month30 = month30 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num90, DateTime.DaysInMonth(dateTime.Year, num90));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month31 = dateTime.Month;
                    if (month31 == 2)
                    {
                        int num91 = month31 - 1;
                        month31 = month31 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num91, DateTime.DaysInMonth(dateTime.Year, num91));
                    }
                    else if (month31 == 3)
                    {
                        int num92 = month31 - 2;
                        month31 = month31 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num92, DateTime.DaysInMonth(dateTime.Year, num92));
                    }
                    else if (month31 == 4)
                    {
                        int num93 = month31 - 3;
                        month31 = month31 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num93, DateTime.DaysInMonth(dateTime.Year, num93));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month32 = dateTime.Month;
                    if (month32 == 5)
                    {
                        int num94 = month32 - 1;
                        month32 = month32 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num94, DateTime.DaysInMonth(dateTime.Year, num94));
                    }
                    if (month32 == 6)
                    {
                        int num95 = month32 - 2;
                        month32 = month32 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num95, DateTime.DaysInMonth(dateTime.Year, num95));
                    }
                    else if (month32 == 7)
                    {
                        int num96 = month32 - 3;
                        month32 = month32 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num96, DateTime.DaysInMonth(dateTime.Year, num96));
                    }
                }
            }
            if (num == 9)
            {
                if (month == 9 || month == 10 || month == 11)
                {
                    int month33 = dateTime.Month;
                    if (month33 == 9)
                    {
                        int num97 = month33 - 1;
                        month33 = month33 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num97, DateTime.DaysInMonth(dateTime.Year, num97));
                    }
                    else if (month33 == 10)
                    {
                        int num98 = month33 - 2;
                        month33 = month33 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num98, DateTime.DaysInMonth(dateTime.Year, num98));
                    }
                    else if (month33 == 11)
                    {
                        int num99 = month33 - 3;
                        month33 = month33 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num99, DateTime.DaysInMonth(dateTime.Year, num99));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month34 = dateTime.Month;
                    if (month34 == 12)
                    {
                        int num100 = month34 - 1;
                        month34 = month34 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num100, DateTime.DaysInMonth(dateTime.Year, num100));
                    }
                    else if (month34 == 1)
                    {
                        int num101 = month34 + 10;
                        month34 = month34 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num101, DateTime.DaysInMonth(dateTime.Year, num101));
                    }
                    else if (month34 == 2)
                    {
                        int num102 = month34 + 9;
                        month34 = month34 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num102, DateTime.DaysInMonth(dateTime.Year, num102));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month35 = dateTime.Month;
                    if (month35 == 3)
                    {
                        int num103 = month35 - 1;
                        month35 = month35 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num103, DateTime.DaysInMonth(dateTime.Year, num103));
                    }
                    else if (month35 == 4)
                    {
                        int num104 = month35 - 2;
                        month35 = month35 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num104, DateTime.DaysInMonth(dateTime.Year, num104));
                    }
                    else if (month35 == 5)
                    {
                        int num105 = month35 - 3;
                        month35 = month35 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num105, DateTime.DaysInMonth(dateTime.Year, num105));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month36 = dateTime.Month;
                    if (month36 == 6)
                    {
                        int num106 = month36 - 1;
                        month36 = month36 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num106, DateTime.DaysInMonth(dateTime.Year, num106));
                    }
                    if (month36 == 7)
                    {
                        int num107 = month36 - 2;
                        month36 = month36 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num107, DateTime.DaysInMonth(dateTime.Year, num107));
                    }
                    else if (month36 == 8)
                    {
                        int num108 = month36 - 3;
                        month36 = month36 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num108, DateTime.DaysInMonth(dateTime.Year, num108));
                    }
                }
            }
            if (num == 10)
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    int month37 = dateTime.Month;
                    if (month37 == 10)
                    {
                        int num109 = month37 - 1;
                        month37 = month37 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num109, DateTime.DaysInMonth(dateTime.Year, num109));
                    }
                    else if (month37 == 11)
                    {
                        int num110 = month37 - 2;
                        month37 = month37 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num110, DateTime.DaysInMonth(dateTime.Year, num110));
                    }
                    else if (month37 == 12)
                    {
                        int num111 = month37 - 3;
                        month37 = month37 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num111, DateTime.DaysInMonth(dateTime.Year, num111));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month38 = dateTime.Month;
                    if (month38 == 1)
                    {
                        int num112 = month38 + 11;
                        month38 = month38 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num112, DateTime.DaysInMonth(dateTime.Year, num112));
                    }
                    else if (month38 == 2)
                    {
                        int num113 = month38 + 10;
                        month38 = month38 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num113, DateTime.DaysInMonth(dateTime.Year, num113));
                    }
                    else if (month38 == 3)
                    {
                        int num114 = month38 + 9;
                        month38 = month38 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num114, DateTime.DaysInMonth(dateTime.Year, num114));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month39 = dateTime.Month;
                    if (month39 == 4)
                    {
                        int num115 = month39 - 1;
                        month39 = month39 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num115, DateTime.DaysInMonth(dateTime.Year, num115));
                    }
                    else if (month39 == 5)
                    {
                        int num116 = month39 - 2;
                        month39 = month39 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num116, DateTime.DaysInMonth(dateTime.Year, num116));
                    }
                    else if (month39 == 6)
                    {
                        int num117 = month39 - 3;
                        month39 = month39 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num117, DateTime.DaysInMonth(dateTime.Year, num117));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month40 = dateTime.Month;
                    if (month40 == 7)
                    {
                        int num118 = month40 - 1;
                        month40 = month40 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num118, DateTime.DaysInMonth(dateTime.Year, num118));
                    }
                    if (month40 == 8)
                    {
                        int num119 = month40 - 2;
                        month40 = month40 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num119, DateTime.DaysInMonth(dateTime.Year, num119));
                    }
                    else if (month40 == 9)
                    {
                        int num120 = month40 - 3;
                        month40 = month40 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num120, DateTime.DaysInMonth(dateTime.Year, num120));
                    }
                }
            }
            if (num == 11)
            {
                if (month == 11 || month == 12 || month == 1)
                {
                    int month41 = dateTime.Month;
                    if (month41 == 11)
                    {
                        int num121 = month41 - 1;
                        month41 = month41 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num121, DateTime.DaysInMonth(dateTime.Year, num121));
                    }
                    else if (month41 == 12)
                    {
                        int num122 = month41 - 2;
                        month41 = month41 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num122, DateTime.DaysInMonth(dateTime.Year, num122));
                    }
                    else if (month41 == 1)
                    {
                        int num123 = month41 + 9;
                        month41 = month41 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num123, DateTime.DaysInMonth(dateTime.Year, num123));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month42 = dateTime.Month;
                    if (month42 == 2)
                    {
                        int num124 = month42 - 1;
                        month42 = month42 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num124, DateTime.DaysInMonth(dateTime.Year, num124));
                    }
                    else if (month42 == 3)
                    {
                        int num125 = month42 - 2;
                        month42 = month42 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num125, DateTime.DaysInMonth(dateTime.Year, num125));
                    }
                    else if (month42 == 4)
                    {
                        int num126 = month42 - 3;
                        month42 = month42 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num126, DateTime.DaysInMonth(dateTime.Year, num126));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month43 = dateTime.Month;
                    if (month43 == 5)
                    {
                        int num127 = month43 - 1;
                        month43 = month43 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num127, DateTime.DaysInMonth(dateTime.Year, num127));
                    }
                    else if (month43 == 6)
                    {
                        int num128 = month43 - 2;
                        month43 = month43 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num128, DateTime.DaysInMonth(dateTime.Year, num128));
                    }
                    else if (month43 == 7)
                    {
                        int num129 = month43 - 3;
                        month43 = month43 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num129, DateTime.DaysInMonth(dateTime.Year, num129));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month44 = dateTime.Month;
                    if (month44 == 8)
                    {
                        int num130 = month44 - 1;
                        month44 = month44 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num130, DateTime.DaysInMonth(dateTime.Year, num130));
                    }
                    if (month44 == 9)
                    {
                        int num131 = month44 - 2;
                        month44 = month44 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num131, DateTime.DaysInMonth(dateTime.Year, num131));
                    }
                    else if (month44 == 10)
                    {
                        int num132 = month44 - 3;
                        month44 = month44 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num132, DateTime.DaysInMonth(dateTime.Year, num132));
                    }
                }
            }
            if (num == 12)
            {
                if (month == 12 || month == 1 || month == 2)
                {
                    int month45 = dateTime.Month;
                    if (month45 == 12)
                    {
                        int num133 = month45 - 1;
                        month45 = month45 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num133, DateTime.DaysInMonth(dateTime.Year, num133));
                    }
                    else if (month45 == 1)
                    {
                        int num134 = month45 + 10;
                        month45 = month45 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num134, DateTime.DaysInMonth(dateTime.Year, num134));
                    }
                    else if (month45 == 2)
                    {
                        int num135 = month45 + 9;
                        month45 = month45 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num135, DateTime.DaysInMonth(dateTime.Year, num135));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month46 = dateTime.Month;
                    if (month46 == 3)
                    {
                        int num136 = month46 - 1;
                        month46 = month46 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num136, DateTime.DaysInMonth(dateTime.Year, num136));
                    }
                    else if (month46 == 4)
                    {
                        int num137 = month46 - 2;
                        month46 = month46 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num137, DateTime.DaysInMonth(dateTime.Year, num137));
                    }
                    else if (month46 == 5)
                    {
                        int num138 = month46 - 3;
                        month46 = month46 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num138, DateTime.DaysInMonth(dateTime.Year, num138));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month47 = dateTime.Month;
                    if (month47 == 6)
                    {
                        int num139 = month47 - 1;
                        month47 = month47 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num139, DateTime.DaysInMonth(dateTime.Year, num139));
                    }
                    else if (month47 == 7)
                    {
                        int num140 = month47 - 2;
                        month47 = month47 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num140, DateTime.DaysInMonth(dateTime.Year, num140));
                    }
                    else if (month47 == 8)
                    {
                        int num141 = month47 - 3;
                        month47 = month47 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num141, DateTime.DaysInMonth(dateTime.Year, num141));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month48 = dateTime.Month;
                    if (month48 == 9)
                    {
                        int num142 = month48 - 1;
                        month48 = month48 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num142, DateTime.DaysInMonth(dateTime.Year, num142));
                    }
                    if (month48 == 10)
                    {
                        int num143 = month48 - 2;
                        month48 = month48 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num143, DateTime.DaysInMonth(dateTime.Year, num143));
                    }
                    else if (month48 == 11)
                    {
                        int num144 = month48 - 3;
                        month48 = month48 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num144, DateTime.DaysInMonth(dateTime.Year, num144));
                    }
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] languageConversion;
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Reports("purchase", "showreport", "");
            BaseClass baseClass1 = new BaseClass();
            string empty = string.Empty;
            if (baseClass1.ReturnRoles_Privileges_ForGrid("purchase", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            if (baseClass1.ReturnRoles_Privileges_ReportStatus("purchase", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            if (this.rdosummary.Checked)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetSummaryDetails();", true);
            }
            else if (this.rdodetail.Checked)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetDetails();", true);
            }
            this.pg = "purchase";
            if (base.Request.Params["pg"] == null)
            {
                this.pagename = "purchase";
            }
            else if (base.Request.Params["pg"].ToString().Trim().ToLower() == "report")
            {
                this.pagename = "Report";
            }
            global.pageName = this.pagename;
            global.pgName = "";
            this.gloobj.setpagename(this.pagename);
            languageClass _languageClass = new languageClass();
            base.Title = _languageClass.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Purchase_Report") ?? "", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (this.pagename.ToString().ToLower().Trim() != "report")
            {
                languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../purchase/purchase_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Purchase_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Purchase_Report")));
            }
            else
            {
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../common/report.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Reports"), "</a>&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Purchase_Report")));
            }
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("select CompanyName from tb_Company where CompanyID=", this.CompanyID, " and isdelete=0"), sqlConnection);
            this.CompanyName = (string)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            DateTime dateTime = _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            commonClass _commonClass1 = this.objJava;
            DateTime now1 = DateTime.Now;
            string str = _commonClass1.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
            char[] chrArray = new char[] { ' ' };
            this.day = str.Split(chrArray);
            this.spn_daily.InnerText = string.Concat("(", this.day[0].ToString(), ")");
            commonClass _commonClass2 = this.objJava;
            string str1 = dateTime.AddDays(-1).ToString();
            char[] chrArray1 = new char[] { ' ' };
            string str2 = _commonClass2.Eprint_return_Date_Before_View(str1.Split(chrArray1)[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray2 = new char[] { ' ' };
            this.yestday = str2.Split(chrArray2);
            this.spn_yest.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
            DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime3 = dateTime2.AddMonths(1).AddDays(-1);
            string str3 = this.objJava.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray3 = new char[] { ' ' };
            this.stdate = str3.Split(chrArray3);
            string str4 = this.objJava.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray4 = new char[] { ' ' };
            this.endate = str4.Split(chrArray4);
            HtmlGenericControl spnMonth = this.spn_month;
            string[] strArrays = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
            spnMonth.InnerText = string.Concat(strArrays);
            try
            {
                string[] strArrays1 = this.CurrentQuater().Split(new char[] { ',' });
                string str5 = this.objJava.Eprint_return_Date_Before_View(strArrays1[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray5 = new char[] { ' ' };
                this.stquardate = str5.Split(chrArray5);
                string str6 = this.objJava.Eprint_return_Date_Before_View(strArrays1[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray6 = new char[] { ' ' };
                this.enquardate = str6.Split(chrArray6);
                HtmlGenericControl spnQuarter = this.spn_quarter;
                string[] strArrays2 = new string[] { "(", this.stquardate[0].ToString(), " to ", this.enquardate[0].ToString(), ")" };
                spnQuarter.InnerText = string.Concat(strArrays2);
            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.LastQuarter().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastquardate = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastquardate = str8.Split(chrArray8);
                HtmlGenericControl spnLastque = this.spn_lastque;
                string[] strArrays4 = new string[] { "(", this.stlastquardate[0].ToString(), " to ", this.enlastquardate[0].ToString(), ")" };
                spnLastque.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastweek().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastweek = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastweek = str8.Split(chrArray8);
                HtmlGenericControl spnLastweek = this.spn_lastweek;
                string[] strArrays4 = new string[] { "(", this.stlastweek[0].ToString(), " to ", this.enlastweek[0].ToString(), ")" };
                spnLastweek.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }

            HtmlGenericControl spn_rdlDate_annualYear1 = this.spn_rdlDate_annualYear;
            string[] strArrays444 = new string[] { "(",
                    this.objJava.Eprint_return_Date_Before_View(
                        ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat)
                        , this.CompanyID, this.UserID, false),
                                " to ",
                    this.objJava.Eprint_return_Date_Before_View(
                               ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                                , ")" };
            spn_rdlDate_annualYear1.InnerText = string.Concat(strArrays444);

            try
            {
                string[] strArrays3 = this.Lastmonth().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastmonth = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastmonth = str8.Split(chrArray8);
                HtmlGenericControl spnLastmonth = this.spn_lastmonth;
                string[] strArrays4 = new string[] { "(", this.stlastmonth[0].ToString(), " to ", this.enlastmonth[0].ToString(), ")" };
                spnLastmonth.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastyear().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastyear = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastyear = str8.Split(chrArray8);
                HtmlGenericControl spnLastyear = this.spn_lastyear;
                string[] strArrays4 = new string[] { "(", this.stlastyear[0].ToString(), " to ", this.enlastyear[0].ToString(), ")" };
                spnLastyear.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }
            string[] strArrays5 = this.HalfFiscalYear().Split(new char[] { ',' });
            string str9 = this.objJava.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray9 = new char[] { ' ' };
            this.from_halffiscalyear = str9.Split(chrArray9);
            string str10 = this.objJava.Eprint_return_Date_Before_View(strArrays5[1].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray10 = new char[] { ' ' };
            this.to_halffiscalyear = str10.Split(chrArray10);
            HtmlGenericControl spanHalfyear = this.span_halfyear;
            string[] strArrays6 = new string[] { "(", this.from_halffiscalyear[0].ToString(), " to ", this.to_halffiscalyear[0].ToString(), ")" };
            spanHalfyear.InnerText = string.Concat(strArrays6);
            string[] strArrays7 = this.CurrentFiscalYear().Split(new char[] { ',' });
            string str11 = this.objJava.Eprint_return_Date_Before_View(strArrays7[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray11 = new char[] { ' ' };
            this.startyear = str11.Split(chrArray11);
            string str12 = this.objJava.Eprint_return_Date_Before_View(strArrays7[1].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray12 = new char[] { ' ' };
            this.endyear = str12.Split(chrArray12);
            HtmlGenericControl spnYear = this.spn_year;
            string[] strArrays8 = new string[] { "(", this.startyear[0].ToString(), " to ", this.endyear[0].ToString(), ")" };
            spnYear.InnerText = string.Concat(strArrays8);
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "purchase");
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    row["StatusTitle"] = baseClass.SpecialDecode(row["StatusTitle"].ToString());
                }
                this.PurchaseStatus.DataSource = dataTable;
                this.PurchaseStatus.DataTextField = "StatusTitle";
                this.PurchaseStatus.DataValueField = "StatusID";
                this.PurchaseStatus.DataBind();
                CompanyBasePage companyBasePage = new CompanyBasePage();
                string str13 = "";
                DataTable dataTable1 = companyBasePage.company_autocomplete(Convert.ToInt32(this.CompanyID), "Supplier", baseClass.ReplaceSingleQuote(str13));
                for (int j = 0; j < dataTable1.Columns.Count; j++)
                {
                    dataTable1.Columns[j].ReadOnly = false;
                }
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    dataRow["ClientName"] = baseClass.SpecialDecode(dataRow["ClientName"].ToString());
                }
                this.lstPurchaseSupplier.DataSource = dataTable1;
                this.lstPurchaseSupplier.DataTextField = "ClientName";
                this.lstPurchaseSupplier.DataValueField = "ClientID";
                this.lstPurchaseSupplier.DataBind();
                this.pnlDateOption_Disable.Visible = true;
                this.txtFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox = this.txtFrom;
                commonClass _commonClass3 = this.objJava;
                DateTime now2 = DateTime.Now;
                textBox.Text = _commonClass3.Eprint_return_Date_Before_View(now2.ToString(), this.CompanyID, this.UserID, true);
                this.txtTo.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox1 = this.txtTo;
                commonClass _commonClass4 = this.objJava;
                DateTime now3 = DateTime.Now;
                textBox1.Text = _commonClass4.Eprint_return_Date_Before_View(now3.ToString(), this.CompanyID, this.UserID, true);
            }
            if (!base.IsPostBack)
            {
                this.usrPaging.Visible = false;
            }
            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            ListItem listItem = this.ddlsummarydetails.Items.FindByValue("0");
            listItem.Attributes.Add("style", "color:gray;");
            listItem.Attributes.Add("disabled", "true");
            if (!base.IsPostBack)
            {
                this.Session["DeleteMsg"] = null;
                this.Session["SaveAsNew"] = null;
                this.pnlReports.Visible = true;
            }
            this.usrReportsave.OnReportClick += new SavingReportEventHandler(this.usrReportsave_OnReportClick);
            this.usrReportsave.OnEditClick += new EditReportEventHandler(this.usrReportsave_OnEditClick);
            this.usrReportsave.OnDeleteClick += new DeleteReportEventHandler(this.usrReportsave_OnDeleteClick);
            this.usrReportsave.OnPageIndexChanged += new OnPageIndexChangedClick(this.usrReportsave_OnPageIndexChanged);
            this.usrReportsave.OnPageSizeChanged += new OnPageSizeChangedClick(this.usrReportsave_OnPageSizeChanged);
            this.getAddressValue_FromSettings();
            ListItem[] listItemArray = new ListItem[] { new ListItem("--- Any ---", "1"), new ListItem(string.Concat("Below ", this.objJava.GetCurrencyinRequiredFormate("", true), "500"), "2"), new ListItem(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), "501-", this.objJava.GetCurrencyinRequiredFormate("", true), "2500"), "3"), new ListItem(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), "2501-", this.objJava.GetCurrencyinRequiredFormate("", true), "5000"), "4") };
            this.ddlEstimateRange.Items.AddRange(listItemArray);
            this.ddlEstimateRange.DataBind();
            this.rdosummary.Text = this.objLangClass.GetLanguageConversion("Summary");
            this.rdodetail.Text = this.objLangClass.GetLanguageConversion("Detailed");
            this.chkDateOption.Text = this.objLangClass.GetLanguageConversion("Date_Options");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnSaveRun.Text = this.objLangClass.GetLanguageConversion("Save_And_Run");
            this.btnRunReport.Text = this.objLangClass.GetLanguageConversion("Run_Report");
            this.btnfilter.ToolTip = this.objLangClass.GetLanguageConversion("Back_To_Search_Option");
            this.btnExport.ToolTip = this.objLangClass.GetLanguageConversion("Export");
            this.btngo.ToolTip = this.objLangClass.GetLanguageConversion("GoTo");
            this.RadPanelBar1.Items[0].Text = this.objLangClass.GetLanguageConversion("Select_Columns_To_Run_Report");
            this.RadPanelBar1.Items[1].Text = this.objLangClass.GetLanguageConversion("Sort_The_Records");
            this.RadPanelBar1.Items[2].Text = this.objLangClass.GetLanguageConversion("Report_Filters");
            this.RadPanelBar1.Items[3].Text = this.objLangClass.GetLanguageConversion("Aggregate_Functions_By_Purchase_Value");
            this.RadPanelBar1.Items[4].Text = this.objLangClass.GetLanguageConversion("Save_Report_Options");
            this.ddldirection.Items[0].Text = this.objLangClass.GetLanguageConversion("Ascending");
            this.ddldirection.Items[1].Text = this.objLangClass.GetLanguageConversion("Descending");
            this.ddlsummarydetails.Items[0].Text = this.objLangClass.GetLanguageConversion("Date");
            this.ddlsummarydetails.Items[1].Text = this.objLangClass.GetLanguageConversion("Daily");
            this.ddlsummarydetails.Items[2].Text = this.objLangClass.GetLanguageConversion("Monthly");
            this.ddlsummarydetails.Items[3].Text = this.objLangClass.GetLanguageConversion("Yearly");
            this.ddlsummarydetails.Items[4].Text = this.objLangClass.GetLanguageConversion("Supplier");
            this.rdlDate.Items[0].Text = this.objLangClass.GetLanguageConversion("Today");
            this.rdlDate.Items[1].Text = this.objLangClass.GetLanguageConversion("Yesterday");
            this.rdlDate.Items[2].Text = this.objLangClass.GetLanguageConversion("Current_Month");
            this.rdlDate.Items[3].Text = this.objLangClass.GetLanguageConversion("Current_Quarter");
            this.rdlDate.Items[4].Text = ePrintConstants.CurrentYearText;
            this.rdlDate.Items[5].Text = this.objLangClass.GetLanguageConversion("Last_Quarter");
            this.rdlDate.Items[6].Text = this.objLangClass.GetLanguageConversion("Current_Year_Fiscal");
            this.rdlDate.Items[7].Text = this.objLangClass.GetLanguageConversion("Half_Fiscal_year");
            this.rdlDate.Items[8].Text = this.objLangClass.GetLanguageConversion("Till_Date");
            this.rdlDate.Items[9].Text = this.objLangClass.GetLanguageConversion("Select_Date");
            this.chkColumns.Items[0].Text = this.objLangClass.GetLanguageConversion("Purchase_Number");
            this.chkColumns.Items[1].Text = this.objLangClass.GetLanguageConversion("Created_Date");
            this.chkColumns.Items[2].Text = this.objLangClass.GetLanguageConversion("Supplier_Name");
            this.chkColumns.Items[3].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
            this.chkColumns.Items[4].Text = this.objLangClass.GetLanguageConversion("Contact_Address");
            this.chkColumns.Items[5].Text = this.objLangClass.GetLanguageConversion("Delivery_Address");
            this.chkColumns.Items[6].Text = this.objLangClass.GetLanguageConversion("Comment_Delivery_Instructions");
            this.chkColumns.Items[7].Text = this.objLangClass.GetLanguageConversion("Status");
            this.chkColumns.Items[8].Text = this.objLangClass.GetLanguageConversion("Raised_By");
            this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Purchase_Date");
            this.chkColumns.Items[10].Text = this.objLangClass.GetLanguageConversion("Carrier_Information");
            this.chkColumns.Items[11].Text = this.objLangClass.GetLanguageConversion("Reference_Number");
            this.chkColumns.Items[12].Text = this.objLangClass.GetLanguageConversion("Job_Number");
            this.chkColumns.Items[13].Text = this.objLangClass.GetLanguageConversion("Supp_Quote");
            this.chkColumns.Items[14].Text = this.objLangClass.GetLanguageConversion("Supp_Inv");
            this.chkColumns.Items[15].Text = this.objLangClass.GetLanguageConversion("Supplier_Invoice_Date");
            this.chkColumns.Items[16].Text = this.objLangClass.GetLanguageConversion("Delivery_Date");
            this.chkColumns.Items[17].Text = this.objLangClass.GetLanguageConversion("Invoice_Received");
            this.chkColumns.Items[18].Text = this.objLangClass.GetLanguageConversion("Total_Incl_Tax");
            this.chkColumns.Items[19].Text = this.objLangClass.GetLanguageConversion("Total_Ex_Tax");
            this.chkColumns.Items[20].Text = this.objLangClass.GetLanguageConversion("Job_Title");
            this.chkColumns.Items[21].Text = this.objLangClass.GetLanguageConversion("Activity_Notes");
            this.chkColumns.Items[22].Text = this.objLangClass.GetLanguageConversion("Accounting_Code");
            this.chkColumns.Items[23].Text = this.objLangClass.GetLanguageConversion("Item_Code");
            this.chkColumns.Items[24].Text = this.objLangClass.GetLanguageConversion("Description");
            this.chkColumns.Items[25].Text = this.objLangClass.GetLanguageConversion("Item_Quantity");
            this.chkColumns.Items[26].Text = this.objLangClass.GetLanguageConversion("Packed_In");
            this.chkColumns.Items[27].Text = this.objLangClass.GetLanguageConversion("Price");
            this.chkColumns.Items[28].Text = this.objLangClass.GetLanguageConversion("Tax");
            this.chkColumns.Items[29].Text = this.objLangClass.GetLanguageConversion("Tax_Value");
            this.chkColumns.Items[30].Text = this.objLangClass.GetLanguageConversion("Notes");
            this.chkColumns.Items[31].Text = this.objLangClass.GetLanguageConversion("Goods_Received");
            this.chkColumns.Items[32].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title1");
            this.chkColumns.Items[33].Text = this.objLangClass.GetLanguageConversion("Contact_Job_Title2");
            this.chkColumns.Items[34].Text = this.objLangClass.GetLanguageConversion("Payment_Terms");
            this.chkColumns.Items[35].Text = this.objLangClass.GetLanguageConversion("Item_Title");
            this.chkColumns.Items[37].Text = this.objLangClass.GetLanguageConversion("Invoice_Date");
            //foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            //{
            //    customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
            //    customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
            //    customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
            //    customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
            //    customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            //}
            //this.chkColumns.Items[38].Text = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
            //this.chkColumns.Items[39].Text = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
            //this.chkColumns.Items[40].Text = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
            //this.chkColumns.Items[41].Text = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
            //this.chkColumns.Items[42].Text = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;

            this.chkColumns1.Items[0].Text = this.objLangClass.GetLanguageConversion("Count");
            this.chkColumns1.Items[1].Text = this.objLangClass.GetLanguageConversion("Total");
            this.chkColumns1.Items[2].Text = this.objLangClass.GetLanguageConversion("Average");
            this.chkColumns1.Items[3].Text = this.objLangClass.GetLanguageConversion("Maximum");
            this.chkColumns1.Items[4].Text = this.objLangClass.GetLanguageConversion("Minimum");
            this.chkfreetext.Items[0].Text = _languageClass.GetLanguageConversion("Supplier_Name");
            this.chkfreetext.Items[1].Text = _languageClass.GetLanguageConversion("Purchase_Number");
            this.chkfreetext.Items[2].Text = _languageClass.GetLanguageConversion("Job_Number");
            this.chkfreetext.Items[3].Text = _languageClass.GetLanguageConversion("Contact_Name");
            this.chkfreetext.Items[4].Text = _languageClass.GetLanguageConversion("Item_Code");
            this.chkfreetext.Items[5].Text = _languageClass.GetLanguageConversion("Accounting_Code");
            AttributeCollection attributes = this.chkColumns.Items[0].Attributes;
            string[] text = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[0].Text, "','", this.chkColumns.Items[0].Value, "','0')" };
            attributes.Add("onclick", string.Concat(text));
            AttributeCollection attributeCollection = this.chkColumns.Items[1].Attributes;
            string[] text1 = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[1].Text, "','", this.chkColumns.Items[1].Value, "','1')" };
            attributeCollection.Add("onclick", string.Concat(text1));
            AttributeCollection attributes1 = this.chkColumns.Items[2].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[2].Text, "','", this.chkColumns.Items[2].Value, "','2')" };
            attributes1.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection1 = this.chkColumns.Items[8].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[8].Text, "','", this.chkColumns.Items[8].Value, "','8')" };
            attributeCollection1.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes2 = this.chkColumns.Items[9].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[9].Text, "','", this.chkColumns.Items[9].Value, "','9')" };
            attributes2.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection2 = this.chkColumns.Items[18].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[18].Text, "','", this.chkColumns.Items[18].Value, "','18')" };
            attributeCollection2.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes3 = this.chkColumns.Items[20].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[20].Text, "','", this.chkColumns.Items[20].Value, "','20')" };
            attributes3.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection3 = this.chkColumns.Items[23].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[23].Text, "','", this.chkColumns.Items[23].Value, "','23')" };
            attributeCollection3.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes4 = this.chkColumns.Items[25].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[25].Text, "','", this.chkColumns.Items[25].Value, "','25')" };
            attributes4.Add("onclick", string.Concat(languageConversion));
            this.ddlSortBy.Attributes.Add("onchange", "javascript:ddlsortByOnchange();");
            string empty1 = string.Empty;
            if (!base.IsPostBack)
            {

                if (CheckXeroTracking())
                {
                    divLocation.Visible = true;
                    DataTable dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
                    DataRow toInsert = dataTableOptions.NewRow();
                    toInsert[0] = 0;
                    toInsert[1] = "Select Location";
                    dataTableOptions.Rows.InsertAt(toInsert, 0);
                    this.ddlLocation.DataSource = dataTableOptions;
                    this.ddlLocation.DataTextField = "TrackingOPtion";
                    this.ddlLocation.DataValueField = "Id";
                    this.ddlLocation.DataBind();
                    //ddlLocation.Items.Insert(0, new ListItem("Select Location", "0"));
                }
                this.BindEstimatorDropDown();
                this.BindSalesPersonDropDown();
                this.BindCustomerSalesPersonDropDown();
            }
            if (baseClass.ReturnRoles_Privileges_Others("showsellingprice").ToLower() != "false")
            {
                this.chkColumns.Items[18].Enabled = true;
                return;
            }
            this.chkColumns.Items[18].Selected = false;
            this.chkColumns.Items[18].Enabled = false;


        }
        bool CheckXeroTracking()
        {
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_Xero_Tracking_Select")
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@System_Name", ConnectionClass.ServerName.ToString());
            return true;
            return (bool)sqlCommand.ExecuteScalar();
        }
        private void paging_OnPageChange(int PageNumber1)
        {
            //if (PageNumber1 <= 0)
            //{
            //    this.GridEstReport.PageIndex = PageNumber1;
            //}
            //else
            //{
            //    this.GridEstReport.PageIndex = PageNumber1 - 1;
            //}
            this.GetPageBind(PageNumber1);
            this.div_showfilters.Style.Add("display", "none");
            this.divusrReportsave.Style.Add("display", "none");
            this.GridEstReport.DataBind();
        }

        private void ReportDetails(int ReportID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                this.chkColumns.Items[i].Selected = false;
            }
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_GetReport_Details", this.objJava.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ReportID", ReportID);
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            this.objJava.closeConnection();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["Columns"].ToString();
                str = row["Status"].ToString();
                str1 = row["CompanyName"].ToString();
                string[] strArrays = empty.Split(new char[] { 'µ' });
                for (int j = 0; j < (int)strArrays.Length; j++)
                {
                    if (strArrays[j] == "PONO")
                    {
                        this.chkColumns.Items[0].Selected = true;
                    }
                    else if (strArrays[j] == "CreatedDate")
                    {
                        this.chkColumns.Items[1].Selected = true;
                    }
                    else if (strArrays[j] == "Company")
                    {
                        this.chkColumns.Items[2].Selected = true;
                    }
                    else if (strArrays[j] == "ContactName")
                    {
                        this.chkColumns.Items[3].Selected = true;
                    }
                    else if (strArrays[j] == "ContactAddress")
                    {
                        this.chkColumns.Items[4].Selected = true;
                    }
                    else if (strArrays[j] == "DeliveryAddress")
                    {
                        this.chkColumns.Items[5].Selected = true;
                    }
                    else if (strArrays[j] == "CommentDeliveryInstructions")
                    {
                        this.chkColumns.Items[6].Selected = true;
                    }
                    else if (strArrays[j] == "Status")
                    {
                        this.chkColumns.Items[7].Selected = true;
                    }
                    else if (strArrays[j] == "RaisedBy")
                    {
                        this.chkColumns.Items[8].Selected = true;
                    }
                    else if (strArrays[j] == "RequestedDate")
                    {
                        this.chkColumns.Items[9].Selected = true;
                    }
                    else if (strArrays[j] == "CarrierInformation")
                    {
                        this.chkColumns.Items[10].Selected = true;
                    }
                    else if (strArrays[j] == "ReferenceNumber")
                    {
                        this.chkColumns.Items[11].Selected = true;
                    }
                    else if (strArrays[j] == "JobNumber")
                    {
                        this.chkColumns.Items[12].Selected = true;
                    }
                    else if (strArrays[j] == "SupplierQuoteNO")
                    {
                        this.chkColumns.Items[13].Selected = true;
                    }
                    else if (strArrays[j] == "SupplierInvoiceNo")
                    {
                        this.chkColumns.Items[14].Selected = true;
                    }
                    else if (strArrays[j] == "SupplierInvoiceDate")
                    {
                        this.chkColumns.Items[15].Selected = true;
                    }
                    else if (strArrays[j] == "DeliveryDate")
                    {
                        this.chkColumns.Items[16].Selected = true;
                    }
                    else if (strArrays[j] == "InvoiceReceived")
                    {
                        this.chkColumns.Items[17].Selected = true;
                    }
                    else if (strArrays[j] == "Total(Incl.Tax)")
                    {
                        this.chkColumns.Items[18].Selected = true;
                    }
                    else if (strArrays[j] == "Total(Ex.Tax)")
                    {
                        this.chkColumns.Items[19].Selected = true;
                    }
                    else if (strArrays[j] == "JobTitle")
                    {
                        this.chkColumns.Items[20].Selected = true;
                    }
                    else if (strArrays[j] == "ActivityNotes")
                    {
                        this.chkColumns.Items[21].Selected = true;
                    }
                    else if (strArrays[j] == "AccountingCode")
                    {
                        this.chkColumns.Items[22].Selected = true;
                    }
                    else if (strArrays[j] == "ItemCode")
                    {
                        this.chkColumns.Items[23].Selected = true;
                    }
                    else if (strArrays[j] == "Description")
                    {
                        this.chkColumns.Items[24].Selected = true;
                    }
                    else if (strArrays[j] == "ItemQuantity")
                    {
                        this.chkColumns.Items[25].Selected = true;
                    }
                    else if (strArrays[j] == "PackedIn")
                    {
                        this.chkColumns.Items[26].Selected = true;
                    }
                    else if (strArrays[j] == "Price")
                    {
                        this.chkColumns.Items[27].Selected = true;
                    }
                    else if (strArrays[j] == "Tax")
                    {
                        this.chkColumns.Items[28].Selected = true;
                    }
                    else if (strArrays[j] == "TaxValue")
                    {
                        this.chkColumns.Items[29].Selected = true;
                    }
                    else if (strArrays[j] == "Notes")
                    {
                        this.chkColumns.Items[30].Selected = true;
                    }
                    else if (strArrays[j] == "GoodsReceived")
                    {
                        this.chkColumns.Items[31].Selected = true;
                    }
                    else if (strArrays[j] == "ContactJobTitle1")
                    {
                        this.chkColumns.Items[32].Selected = true;
                    }
                    else if (strArrays[j] == "ContactJobTitle2")
                    {
                        this.chkColumns.Items[33].Selected = true;
                    }
                    else if (strArrays[j] == "PaymentTerms")
                    {
                        this.chkColumns.Items[34].Selected = true;
                    }
                    else if (strArrays[j] == "ItemTitle")
                    {
                        this.chkColumns.Items[35].Selected = true;
                    }
                    else if (strArrays[j] == "InvoiceNumber")
                    {
                        this.chkColumns.Items[36].Selected = true;
                    }
                    else if (strArrays[j] == "InvoiceDate")
                    {
                        this.chkColumns.Items[37].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate1")
                    {
                        this.chkColumns.Items[38].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate2")
                    {
                        this.chkColumns.Items[39].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate3")
                    {
                        this.chkColumns.Items[40].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate14")
                    {
                        this.chkColumns.Items[41].Selected = true;
                    }
                    if (strArrays[j].ToLower() == "customdate5")
                    {
                        this.chkColumns.Items[42].Selected = true;
                    }
                    else if (strArrays[j] == "DESC")
                    {
                        this.ddldirection.SelectedValue = "DESC";
                        this.HdnSortBy.Value = strArrays[j - 1];
                    }
                    else if (strArrays[j] == "ASC")
                    {
                        this.ddldirection.SelectedValue = "ASC";
                        this.HdnSortBy.Value = strArrays[j - 1];
                    }
                }
                if (Convert.ToInt32(row["EstCount"]) != 1)
                {
                    this.chkColumns1.Items[0].Selected = false;
                }
                else
                {
                    this.chkColumns1.Items[0].Selected = true;
                }
                if (Convert.ToInt32(row["EstTotal"]) != 1)
                {
                    this.chkColumns1.Items[1].Selected = false;
                }
                else
                {
                    this.chkColumns1.Items[1].Selected = true;
                }
                if (Convert.ToInt32(row["EstAverage"]) != 1)
                {
                    this.chkColumns1.Items[2].Selected = false;
                }
                else
                {
                    this.chkColumns1.Items[2].Selected = true;
                }
                if (Convert.ToInt32(row["EstMaximum"]) != 1)
                {
                    this.chkColumns1.Items[3].Selected = false;
                }
                else
                {
                    this.chkColumns1.Items[3].Selected = true;
                }
                if (Convert.ToInt32(row["EstMinimum"]) != 1)
                {
                    this.chkColumns1.Items[4].Selected = false;
                }
                else
                {
                    this.chkColumns1.Items[4].Selected = true;
                }
                if (row["IsShowContactAddressOneColumn"].ToString() == "True")
                {
                    this.ddlContactAddress.SelectedValue = "1";
                }
                if (row["isItemCodeNotNull"].ToString() == "True")
                {
                    this.chkItemCodeNotNull.Checked = true;
                }
                else
                {
                    this.chkItemCodeNotNull.Checked = false;
                }
                if (row["IsShowDeliveryAddressOneColumn"].ToString() == "True")
                {
                    this.ddlDeliveryAddress.SelectedValue = "1";
                }
                if (row["ReportName"].ToString() != "")
                {
                    this.txtSaveReports.Text = base.SpecialDecode(row["ReportName"].ToString());
                }
                this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
                if (str1 != "")
                {
                    string[] strArrays1 = str1.Split(new char[] { 'µ' });
                    for (int k = 0; k < (int)strArrays1.Length; k++)
                    {
                        for (int l = 0; l < this.lstPurchaseSupplier.Items.Count; l++)
                        {
                            if (this.lstPurchaseSupplier.Items[l].Value == strArrays1[k])
                            {
                                this.lstPurchaseSupplier.Items[l].Checked = true;
                            }
                        }
                    }
                }
                if (row["customerID"].ToString() != "")
                {
                    this.hid_ClientID.Value = row["customerID"].ToString();
                }
                if (row["SearchKeyword"].ToString() != "")
                {
                    this.txtFreetext.Text = row["SearchKeyword"].ToString();
                }
                if (CheckXeroTracking() && row["TrackingLocation"].ToString() != "")
                {
                    this.ddlLocation.SelectedValue = ddlLocation.Items.FindByText(row["TrackingLocation"].ToString()).Value;
                }
                empty1 = row["SelectedSearchText"].ToString();
                string[] strArrays2 = empty1.Split(new char[] { 'µ' });
                this.chkfreetext.Items[0].Selected = false;
                this.chkfreetext.Items[1].Selected = false;
                for (int m = 0; m < (int)strArrays2.Length; m++)
                {
                    if (strArrays2[m] == "SupplierName")
                    {
                        this.chkfreetext.Items[0].Selected = true;
                    }
                    if (strArrays2[m] == "PONO")
                    {
                        this.chkfreetext.Items[1].Selected = true;
                    }
                    if (strArrays2[m] == "JobNumber")
                    {
                        this.chkfreetext.Items[2].Selected = true;
                    }
                    if (strArrays2[m] == "ContactName")
                    {
                        this.chkfreetext.Items[3].Selected = true;
                    }
                    if (strArrays2[m] == "ItemCode")
                    {
                        this.chkfreetext.Items[4].Selected = true;
                    }
                    if (strArrays2[m] == "AccountingCode")
                    {
                        this.chkfreetext.Items[5].Selected = true;
                    }
                }
                if (str != "")
                {
                    string[] strArrays3 = str.Split(new char[] { 'µ' });
                    for (int n = 0; n < (int)strArrays3.Length; n++)
                    {
                        for (int o = 0; o < this.PurchaseStatus.Items.Count; o++)
                        {
                            if (this.PurchaseStatus.Items[o].Value == strArrays3[n])
                            {
                                this.PurchaseStatus.Items[o].Checked = true;
                            }
                        }
                    }
                }
                if (Convert.ToInt32(row["PriceRange"]) != 0)
                {
                    this.ddlEstimateRange.SelectedValue = row["PriceRange"].ToString();
                }

                if (!string.IsNullOrEmpty(Convert.ToString(row["SalesPersonId"])) && row["SalesPersonId"].ToString().Trim() != "0")
                {
                    this.ddlSalesPerson.SelectedValue = row["SalesPersonId"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(row["EstimatorId"])) && row["EstimatorId"].ToString().Trim() != "0")
                {
                    this.ddlEstimator.SelectedValue = row["EstimatorId"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(row["CustomerSalesPersonId"])) && row["CustomerSalesPersonId"].ToString().Trim() != "0")
                {
                    this.ddlCustomerSalesPerson.SelectedValue = row["CustomerSalesPersonId"].ToString();
                }

                if (Convert.ToInt32(row["EstNoAssignedValue"]) != 1)
                {
                    this.chkEstimate.Checked = false;
                }
                else
                {
                    this.chkEstimate.Checked = true;
                }
                if (row["ReportType"].ToString() == "Summary")
                {
                    this.rdosummary.Checked = true;
                }
                else if (row["ReportType"].ToString() == "Detailed")
                {
                    this.rdodetail.Checked = true;
                }
                if ((row["ReportType"].ToString() == "Summary" || row["ReportType"].ToString() == "Detailed") && Convert.ToInt32(row["GroupedBy"]) != 0)
                {
                    this.ddlsummarydetails.SelectedValue = row["GroupedBy"].ToString();
                }
                if (row["NotesType"].ToString() != "0")
                {
                    base.SetDDLValue(this.ddlNotesType, row["NotesType"].ToString());
                }
                if (Convert.ToInt32(row["IsCreatedDate"]) != 1)
                {
                    this.chkDateOption.Checked = false;
                }
                else
                {
                    this.chkDateOption.Checked = true;
                    if (row["CreatedDateType"].ToString().Trim() == "t")
                    {
                        this.rdlDate.SelectedValue = "daily";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "y")
                    {
                        this.rdlDate.SelectedValue = "yesterday";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cm")
                    {
                        this.rdlDate.SelectedValue = "thismonth";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cq")
                    {
                        this.rdlDate.SelectedValue = "thisquarter";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "ay")
                    {
                        this.rdlDate.SelectedValue = ePrintConstants.ThisAnnualYear;
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lq")
                    {
                        this.rdlDate.SelectedValue = "lastquater";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cy")
                    {
                        this.rdlDate.SelectedValue = "thisyear";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "hy")
                    {
                        this.rdlDate.SelectedValue = "halfyear";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lw")
                    {
                        this.rdlDate.SelectedValue = "lastweek";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lm")
                    {
                        this.rdlDate.SelectedValue = "lastmonth";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "ly")
                    {
                        this.rdlDate.SelectedValue = "lastyear";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() != "td")
                    {
                        if (row["CreatedDateType"].ToString().Trim() != "dr")
                        {
                            continue;
                        }
                        this.rdlDate.SelectedValue = "daterange";
                        this.txtFrom.Enabled = true;
                        this.txtTo.Enabled = true;
                        this.txtFrom.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtTo.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.rdlDate.SelectedValue = "tilldate";
                    }
                }
            }
        }

        private void RunReportOnClick()
        {
            try
            {
                this.btnUpdateExisting.Visible = true;
                this.btnRunReport.Visible = true;
                this.Session["SaveAsNew"] = "SaveAsNew";
                this.btnSaveRun.Text = "Save as new";
                int num = 0;
                this.divtab.Visible = false;
                this.div_showfilters.Style.Add("display", "none");
                this.divusrReportsave.Style.Add("display", "none");
                this.btnfilter.Visible = true;
                if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("purchase", "exportreport").Trim().ToLower() != "false")
                {
                    this.btnExport.Visible = true;
                }
                else
                {
                    this.btnExport.Visible = false;
                }
                this.divtoolbar.Visible = true;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                for (int i = 0; i < this.chkColumns.Items.Count; i++)
                {
                    if (this.chkColumns.Items[i].Selected)
                    {
                        num = 1;
                    }
                }
                if (num != 1)
                {
                    this.GridEstReport.Visible = false;
                    this.div_Total.Visible = false;
                    this.btnExport.Visible = false;
                    this.txt1.Visible = false;
                    this.btngo.Visible = false;
                    this.divtoolbar.Visible = true;
                }
                else
                {
                    DataSet estimateData = this.GetEstimateData(1);
                    if (this.rdodetail.Checked || this.rdosummary.Checked)
                    {
                        this.GridEstReport.Visible = false;
                        this.usrPaging.Visible = false;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.div_Total.Visible = true;
                    }
                    else if (estimateData.Tables.Count <= 0)
                    {
                        this.pnlEmptyRecords.Visible = true;
                        this.GridEstReport.Visible = false;
                        this.div_Total.Visible = true;
                        this.btnExport.Visible = false;
                        this.divtoolbar.Visible = true;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.divaggregate.Visible = false;
                        this.divAggl.Visible = false;
                        this.lblTotalRecords.Text = "0";
                    }
                    else
                    {
                        if (estimateData.Tables[0].Rows.Count == 0)
                        {
                            this.pnlEmptyRecords.Visible = true;
                            this.GridEstReport.Visible = false;
                            this.div_Total.Visible = true;
                            this.btnExport.Visible = false;
                            this.divtoolbar.Visible = true;
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                            this.divaggregate.Visible = false;
                            this.divAggl.Visible = false;
                        }
                        else if (Convert.ToInt32(estimateData.Tables[1].Rows[0][0].ToString()) > 100)
                        {
                            this.GridEstReport.Visible = true;
                            this.div_Total.Visible = false;
                            this.pnlEmptyRecords.Visible = false;
                            DataTable dt = SetPurchaseReportColumns(estimateData);
                            this.GridEstReport.DataSource = dt;
                            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                            this.GridEstReport.DataBind();
                            //this.usrPaging.Visible = true;
                            this.usrPaging.Visible = false;
                            pagingreport.intCurrentPage = this.PageNumber;
                            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                            this.usrPaging.CreatePaging();
                            //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                            this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        }
                        else
                        {
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                            ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                            ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                            this.GridEstReport.Visible = true;
                            this.div_Total.Visible = false;
                            this.pnlEmptyRecords.Visible = false;
                            DataTable dt = SetPurchaseReportColumns(estimateData);
                            this.GridEstReport.DataSource = dt;
                            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                            this.GridEstReport.DataBind();
                            this.usrPaging.Visible = false;
                            pagingreport.intCurrentPage = this.PageNumber;
                            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                            this.usrPaging.CreatePaging();
                            //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                            this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        }
                        this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {
            }
        }

        private void SaveReports(string value)
        {
            string str = this.hid_ClientID.Value;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            string empty = string.Empty;
            string empty1 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (i != 0)
                    {
                        empty = this.chkColumns.Items[i].Value;
                        purchase_report purchasePurchaseReport = this;
                        purchasePurchaseReport.ColumnNames = string.Concat(purchasePurchaseReport.ColumnNames, "µ", empty);
                    }
                    else
                    {
                        empty = this.chkColumns.Items[i].Value;
                        this.ColumnNames = empty;
                    }
                }
            }
            if (this.HdnSortBy.Value.ToLower() == "none")
            {
                purchase_report purchasePurchaseReport1 = this;
                purchasePurchaseReport1.ColumnNames = string.Concat(purchasePurchaseReport1.ColumnNames, " ");
            }
            else
            {
                purchase_report purchasePurchaseReport2 = this;
                string columnNames = purchasePurchaseReport2.ColumnNames;
                string[] strArrays = new string[] { columnNames, "µ", this.HdnSortBy.Value, "µ", this.ddldirection.SelectedValue };
                purchasePurchaseReport2.ColumnNames = string.Concat(strArrays);
            }
            stringBuilder.Append(" Columns");
            stringBuilder1.Append(string.Concat(" '", this.ColumnNames, "'"));
            //if (this.chkColumns.Items[18].Selected)
            {
                if (!this.chkColumns1.Items[0].Selected)
                {
                    stringBuilder.Append(" ,EstCount");
                    stringBuilder1.Append(" ,0");
                }
                else
                {
                    stringBuilder.Append(" ,EstCount");
                    stringBuilder1.Append(" ,1");
                }
                if (!this.chkColumns1.Items[1].Selected)
                {
                    stringBuilder.Append(" ,EstTotal");
                    stringBuilder1.Append(" ,0");
                }
                else
                {
                    stringBuilder.Append(" ,EstTotal");
                    stringBuilder1.Append(" ,1");
                }
                if (!this.chkColumns1.Items[2].Selected)
                {
                    stringBuilder.Append(" ,EstAverage");
                    stringBuilder1.Append(" ,0");
                }
                else
                {
                    stringBuilder.Append(" ,EstAverage");
                    stringBuilder1.Append(" ,1");
                }
                if (!this.chkColumns1.Items[3].Selected)
                {
                    stringBuilder.Append(" ,EstMaximum");
                    stringBuilder1.Append(" ,0");
                }
                else
                {
                    stringBuilder.Append(" ,EstMaximum");
                    stringBuilder1.Append(" ,1");
                }
                if (!this.chkColumns1.Items[4].Selected)
                {
                    stringBuilder.Append(" ,EstMinimum");
                    stringBuilder1.Append(" ,0");
                }
                else
                {
                    stringBuilder.Append(" ,EstMinimum");
                    stringBuilder1.Append(" ,1");
                }
                stringBuilder.Append(" ,EstConvertedCount");
                stringBuilder1.Append(" ,0");
                stringBuilder.Append(" ,NetTotal");
                stringBuilder1.Append(" ,0");
                stringBuilder.Append(" ,NetAverage");
                stringBuilder1.Append(" ,0");
                stringBuilder.Append(" ,NetMaximum");
                stringBuilder1.Append(" ,0");
                stringBuilder.Append(" ,NetMinimum");
                stringBuilder1.Append(" ,0");
            }
            stringBuilder.Append(" ,IsShowContactAddressOneColumn");
            stringBuilder1.Append(string.Concat(" ,'", this.ddlContactAddress.SelectedValue, "'"));
            stringBuilder.Append(" ,IsShowDeliveryAddressOneColumn");
            stringBuilder1.Append(string.Concat(" ,'", this.ddlDeliveryAddress.SelectedValue, "'"));
            if (this.rdodetail.Checked)
            {
                stringBuilder.Append(" ,ReportType");
                stringBuilder1.Append(string.Concat(" ,'", this.rdodetail.Text, "'"));
            }
            else if (!this.rdosummary.Checked)
            {
                stringBuilder.Append(" ,ReportType,GroupedBy");
                stringBuilder1.Append(" ,'',0");
            }
            else
            {
                stringBuilder.Append(" ,ReportType");
                stringBuilder1.Append(string.Concat(" ,'", this.rdosummary.Text, "'"));
            }
            if ((this.rdodetail.Checked || this.rdosummary.Checked) && this.ddlsummarydetails.SelectedValue.ToString().Trim() != "0")
            {
                stringBuilder.Append(" ,GroupedBy");
                stringBuilder1.Append(string.Concat(" ,", this.ddlsummarydetails.SelectedValue));
            }
            if (this.txtFreetext.Text != "")
            {
                stringBuilder.Append(" ,SearchKeyword");
                stringBuilder1.Append(string.Concat(" ,'", base.ReplaceSingleQuote(this.txtFreetext.Text), "'"));
            }
            for (int j = 0; j < this.chkfreetext.Items.Count; j++)
            {
                if (this.chkfreetext.Items[j].Selected)
                {
                    if (j != 0)
                    {
                        this.FreeTextColoumn = this.chkfreetext.Items[j].Value;
                        empty1 = string.Concat(empty1, "µ", this.FreeTextColoumn);
                    }
                    else
                    {
                        this.FreeTextColoumn = this.chkfreetext.Items[j].Value;
                        empty1 = string.Concat(empty1, this.FreeTextColoumn);
                    }
                }
            }
            stringBuilder.Append(" ,SelectedSearchText");
            stringBuilder1.Append(string.Concat(" ,'", empty1, "'"));
            if (this.PurchaseStatus.SelectedIndex != 0)
            {
                string str1 = string.Empty;
                string empty2 = string.Empty;
                int num = 0;
                for (int k = 0; k < this.PurchaseStatus.Items.Count; k++)
                {
                    if (this.PurchaseStatus.Items[k].Checked)
                    {
                        num++;
                        str1 = (num != 1 ? string.Concat(str1, "µ", this.PurchaseStatus.Items[k].Value) : this.PurchaseStatus.Items[k].Value);
                    }
                }
                if (num > 0)
                {
                    stringBuilder.Append(" ,Status");
                    stringBuilder1.Append(string.Concat(" ,'", str1, "'"));
                }
            }
            if (this.lstPurchaseSupplier.SelectedIndex != 0)
            {
                string str2 = string.Empty;
                int num1 = 0;
                for (int l = 0; l < this.lstPurchaseSupplier.Items.Count; l++)
                {
                    if (this.lstPurchaseSupplier.Items[l].Checked)
                    {
                        num1++;
                        str2 = (num1 != 1 ? string.Concat(str2, "µ", this.lstPurchaseSupplier.Items[l].Value) : this.lstPurchaseSupplier.Items[l].Value);
                    }
                }
                if (num1 > 0)
                {
                    stringBuilder.Append(" ,CompanyName");
                    stringBuilder1.Append(string.Concat(" ,'", str2, "'"));
                }
            }
            stringBuilder.Append(" ,PriceRange");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstNoAssignedValue");
            stringBuilder1.Append(", 0");
            if (this.ddlNotesType.SelectedValue.ToString().Trim() != "0")
            {
                stringBuilder.Append(" ,NotesType");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlNotesType.SelectedValue, "'"));
            }

            if (this.chkItemCodeNotNull.Checked)
            {
                stringBuilder.Append(" ,isItemCodeNotNull");
                stringBuilder1.Append(string.Concat(" ,'", this.chkItemCodeNotNull.Checked, "'"));
            }

            if (!this.chkDateOption.Checked)
            {
                stringBuilder.Append(" ,IsCreatedDate,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                stringBuilder1.Append(" ,0,'','',''");
            }
            else
            {
                stringBuilder.Append(" ,IsCreatedDate");
                stringBuilder1.Append(" ,1");
                if (this.rdlDate.SelectedValue == "daily")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 't','',''");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'y','',''");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cm','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cq','',''");
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'ay','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lq','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cy','',''");
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'hy','',''");
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'td','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lw','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lm','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'ly','',''");
                }

                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    string[] strArrays1 = new string[] { ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFrom.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtTo.Text), "'" };
                    stringBuilder1.Append(string.Concat(strArrays1));
                }
            }
            if (CheckXeroTracking() && this.ddlLocation.SelectedIndex >= 0)
            {
                stringBuilder.Append(" ,TrackingLocation");
                stringBuilder1.Append(string.Concat(" ,'", ddlLocation.SelectedItem.Text, "'"));
            }

            if (this.ddlSalesPerson.SelectedValue != "")
            {
                stringBuilder.Append(" ,SalesPersonId");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlSalesPerson.SelectedValue, "'"));
            }
            if (this.ddlEstimator.SelectedValue != "")
            {
                stringBuilder.Append(" ,EstimatorId");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlEstimator.SelectedValue, "'"));
            }
            if (this.ddlCustomerSalesPerson.SelectedValue != "")
            {
                stringBuilder.Append(" ,CustomerSalesPersonId");
                stringBuilder1.Append(string.Concat(" ,'", this.ddlCustomerSalesPerson.SelectedValue, "'"));
            }

            stringBuilder.Append(" ,EstConvertionDate,EstConvertionDateType,EstConvertionDateFrom,EstConvertionDateTo,ApplyDates");
            stringBuilder1.Append(" ,0,'','','',0");
            if (this.txtSaveReports.Text != "")
            {
                stringBuilder.Append(" ,ReportName");
                stringBuilder1.Append(string.Concat(", '", base.SpecialEncode(this.txtSaveReports.Text), "'"));
            }
            if (this.txtDescription.Text != "")
            {
                stringBuilder.Append(" ,Description");
                stringBuilder1.Append(string.Concat(", '", base.SpecialEncode(this.txtDescription.Text), "'"));
            }
            stringBuilder.Append(" ,PageName,CompanyID,UserID");
            object[] objArray = new object[] { ", '", this.pg, "',", Convert.ToInt32(this.Session["companyid"].ToString()), ",", Convert.ToInt32(this.Session["UserID"].ToString()) };
            stringBuilder1.Append(string.Concat(objArray));
            if (value == "Save")
            {
                string[] strArrays2 = new string[] { "Insert into tb_Reports_Save(", stringBuilder.ToString(), ") Values (", stringBuilder1.ToString(), ")" };
                stringBuilder2.Append(string.Concat(strArrays2));
            }
            else if (value == "Update")
            {
                stringBuilder2.Append(string.Concat("delete tb_reports_save where ReportID=", Convert.ToInt32(this.hdn_reportID.Value)));
                string[] str3 = new string[] { " Insert into tb_Reports_Save(", stringBuilder.ToString(), ") Values (", stringBuilder1.ToString(), ")" };
                stringBuilder2.Append(string.Concat(str3));
                this.hdn_reportID.Value = "";
            }
            SqlCommand sqlCommand = new SqlCommand(stringBuilder2.ToString(), this.objJava.openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.ExecuteNonQuery();
            this.objJava.closeConnection();
        }

        private void usrReportsave_OnDeleteClick(int ReportID)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_Reports_Delete", this.objJava.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ReportID", ReportID);
            sqlCommand.ExecuteNonQuery();
            this.objJava.closeConnection();
            this.pnlSavedReports.Visible = true;
            this.Session["DeleteMsg"] = "SelectDeleteTab";
            this.Session["SaveAsNew"] = null;
        }

        private void usrReportsave_OnEditClick(int ReportID)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.pnlSavedReports.Visible = false;
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.divminimum.Visible = false;
            this.divMaximum.Visible = false;
            this.divAverage.Visible = false;
            this.divTotal.Visible = false;
            this.divCount.Visible = false;
            this.divaggregate1.Visible = false;
            this.usrPaging.Visible = false;
            this.divaggregate.Visible = false;
            this.divAggl.Visible = false;
            this.btnUpdateExisting.Visible = true;
            this.btnSaveRun.Visible = true;
            this.btnRunReport.Visible = false;
            this.btnSaveRun.Text = "Save as New";
            this.ReportDetails(ReportID);
            this.hdn_reportID.Value = ReportID.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "selected", "javascript:OnEditReport();", true);
        }

        private void usrReportsave_OnPageIndexChanged()
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnPageSizeChanged()
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnReportClick(int ReportID)
        {
            this.Session["DeleteMsg"] = null;
            this.ReportDetails(ReportID);
            this.RunReportOnClick();
            this.hdn_reportID.Value = ReportID.ToString();
        }

        private void BindEstimatorDropDown()
        {
            DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("LimitName"))
                    {
                        continue;
                    }
                    dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                    dataRow1["LimitName"] = SpecialDecode(dataRow1["LimitName"].ToString());
                }
            }
            this.ddlEstimator.DataSource = dataTable;
            this.ddlEstimator.DataTextField = "LimitName";
            this.ddlEstimator.DataValueField = "UserID";
            this.ddlEstimator.DataBind();

            this.ddlEstimator.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void BindSalesPersonDropDown()
        {
            DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("LimitName"))
                    {
                        continue;
                    }
                    dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                    dataRow1["LimitName"] = SpecialDecode(dataRow1["LimitName"].ToString());
                }
            }
            this.ddlSalesPerson.DataSource = dataTable;
            this.ddlSalesPerson.DataTextField = "LimitName";
            this.ddlSalesPerson.DataValueField = "UserID";
            this.ddlSalesPerson.DataBind();

            this.ddlSalesPerson.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void BindCustomerSalesPersonDropDown()
        {
            DataTable dataTable = SettingsBasePage.settings_user_select_forddl(this.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (!dataRow1.Table.Columns.Contains("LimitName"))
                    {
                        continue;
                    }
                    dataRow1.Table.Columns["LimitName"].ReadOnly = false;
                    dataRow1["LimitName"] = SpecialDecode(dataRow1["LimitName"].ToString());
                }
            }
            this.ddlCustomerSalesPerson.DataSource = dataTable;
            this.ddlCustomerSalesPerson.DataTextField = "LimitName";
            this.ddlCustomerSalesPerson.DataValueField = "UserID";
            this.ddlCustomerSalesPerson.DataBind();

            this.ddlCustomerSalesPerson.Items.Insert(0, new ListItem("-- Select --", ""));
        }
    }
}