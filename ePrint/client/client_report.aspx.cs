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
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ClosedXML.Excel;

using nmsView;
using ePrint.ePrintUtilities;
namespace ePrint.client
{
    public partial class client_report : BaseClass, IRequiresSessionState
    {
        private BaseClass objBase = new BaseClass();

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public commonClass objJava = new commonClass();

        private CompanyBasePage objcomp = new CompanyBasePage();

        public string Tax2 = ConnectionClass.Tax2;

        public int UserID;

        public string ColumnNames = string.Empty;

        public string CompanyName = string.Empty;

        public string cs = string.Empty;

        public int CompanyID;

        public string DateFormat = string.Empty;

        public string flag = string.Empty;

        public string startdate_quart = string.Empty;

        public string enddate_quart = string.Empty;

        public string[] day;

        public string[] yestday;

        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] enquardate;

        public string[] stlastweek;

        public string[] enlastweek;
        public string[] stlastmonth;

        public string[] enlastmonth;

        public string[] stlastyear;

        public string[] enlastyear;

        public string[] stlastquardate;

        public string[] enlastquardate;

        public string[] from_halffiscalyear;

        public string[] to_halffiscalyear;

        public string year = string.Empty;

        public string[] startyear;

        public string[] endyear;

        public string[] past30days;

        public string[] past45days;

        public string[] past90days;

        public string[] past60days;

        public string[] past120days;

        public string[] past365days;

        public string[] laststdate;

        public string[] lastenddate;

        public int contactlstcount;

        public int Departmentlstcount;

        public int addresslstcount;

        public int estimatrangecheck;

        public string pagename = string.Empty;

        public int cellvalue_createdOn;

        public string flag_createdOn = string.Empty;

        public int cellvalue_estimateDate;

        public string flag_estimateDate = string.Empty;

        public int cellvalue_estTitle;

        public string flag_estTitle = string.Empty;

        public int cellvalue_itemtitle;

        public string flag_itemtitle = string.Empty;

        public int cellvalue_Description;

        public string flag_Description = string.Empty;

        public int cellvalue_Artwork;

        public string flag_Artwork = string.Empty;

        public int cellvalue_Colour;

        public string flag_Colour = string.Empty;

        public int cellvalue_Size;

        public string flag_Size = string.Empty;

        public int cellvalue_Material;

        public string flag_Material = string.Empty;

        public int cellvalue_Delivery;

        public string flag_Delivery = string.Empty;

        public int cellvalue_Finishing;

        public string flag_Finishing = string.Empty;

        public int cellvalue_Notes;

        public string flag_Notes = string.Empty;

        public int cellvalue_Instructions;

        public string flag_Instructions = string.Empty;

        public string flagid = string.Empty;

        public int cellvalue_flagid;

        public int cellvalue_AcOpenedDate;

        public string flag_AcOpenedDate = string.Empty;

        public int cellvalue_TotalEstimate;

        public string flag_TotalEstimate = string.Empty;

        public int cellvalue_EstimateValue;

        public string flag_EstimateValue = string.Empty;

        public int cellvalue_TotalJob;

        public string flag_TotalJob = string.Empty;

        public int cellvalue_JobValue;

        public string flag_JobValue = string.Empty;

        public string flag_ProfitMargin = string.Empty;

        public int cellvalue_ProfitMargin;

        public int cellvalue_TotalInvoice;

        public string flag_TotalInvoice = string.Empty;

        public int cellvalue_InvoiceValue;

        public int cellvalue_EstJobConversionCount;

        public int cellvalue_EstJobConversionValue;

        public string flag_InvoiceValue = string.Empty;

        public string flag_EstJobConversionCount = string.Empty;

        public string flag_EstJobConversionValue = string.Empty;

        public string flag_contactID = string.Empty;

        public int cellvalue_contactID;

        public string paperType = string.Empty;

        public int PageSize = 100;

        public int totalrec;

        private int PageNumber = 1;

        public string TotalEst = string.Empty;

        public string TotalEstValue = string.Empty;

        public string TotalJobs = string.Empty;

        public string TotalJobValue = string.Empty;

        public string TotalInv = string.Empty;

        public string TotalInvValue = string.Empty;

        public string TotalPurchase = string.Empty;

        public string TotalPurchaseValue = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string CurrencySymbol = string.Empty;

        public string stringcust1 = "";

        public string stringcust2 = "";

        public string stringcust3 = "";

        public string companytype = "";

        public string customertype = "";

        public string customertypeid = "";

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

        public client_report()
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
            base.Response.Redirect(string.Concat(this.strSitepath, "client/client_view.aspx"));
        }

        public void btnExport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            int num = 0;
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            int num1 = 0;
            while (num1 < this.chkColumns.Items.Count)
            {
                if (this.chkColumns.Items[1].Selected)
                {
                    flag = true;
                }
                if (this.chkColumns.Items[14].Selected)
                {
                    flag1 = true;
                }
                if (this.chkColumns.Items[20].Selected)
                {
                    flag2 = true;
                }
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
            if (this.ddlGrouprecords.SelectedValue != "0")
            {
                string value = this.hdnInnerHtml.Value;
                string str = "CRM_Report.xls";
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
            if (num != 1)
            {
                this.spnError.Visible = true;
                return;
            }
            DataTable item = this.GetEstimateData(0).Tables[0];
            foreach (DataRow row in item.Rows)
            {
                if (!row.Table.Columns.Contains("A/cOpened"))
                {
                    continue;
                }
                row["A/cOpened"] = this.objJava.Eprint_return_Date_Before_View(row["A/cOpened"].ToString(), this.CompanyID, this.UserID, true);
            }
            if (item.Columns.Contains("ClientID"))
            {
                item.Columns.Remove("ClientID");
            }
            if (item.Columns.Contains("contactID"))
            {
                item.Columns.Remove("contactID");
            }
            if (item.Columns.Contains("Name") && !flag2)
            {
                item.Columns.Remove("Name");
            }
            if (item.Columns.Contains("CompanyType") && !flag)
            {
                item.Columns.Remove("CompanyType");
            }
            if (item.Columns.Contains("CompanyNumber") && !flag1)
            {
                item.Columns.Remove("CompanyNumber");
            }
      
            foreach (DataColumn column in item.Columns)
            {
                for (int k = 0; k < item.Columns.Count; k++)
                {
                    if (item.Columns[k].ColumnName == "CompanyType")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Company_Type");
                    }
                    if (item.Columns[k].ColumnName == "AccountStatus")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Account_Status");
                    }
                    if (item.Columns[k].ColumnName == "AccountNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Account_Number");
                    }
                    if (item.Columns[k].ColumnName == "WebSite")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("URL");
                    }
                    if (item.Columns[k].ColumnName == "CreditLimit")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Credit_Limit");
                    }
                    if (item.Columns[k].ColumnName == "CreditRef")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Credit_Ref");
                    }
                    if (item.Columns[k].ColumnName == "Tax1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Tax1");
                    }
                    if (item.Columns[k].ColumnName == "Tax2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Tax2");
                    }
                    if (item.Columns[k].ColumnName == "Description")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Description");
                    }
                    if (item.Columns[k].ColumnName == "TaxRegNo")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Tax_reg_No");
                    }
                    if (item.Columns[k].ColumnName == "PaymentTerms")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Payment_Terms");
                    }
                    if (item.Columns[k].ColumnName == "CompanyNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Company_Number");
                    }
                    if (item.Columns[k].ColumnName == "ProfitMargin")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Profit_Margin");
                    }
                    if (item.Columns[k].ColumnName == "A/cOpened")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("A_C_Opened");
                    }
                    if (item.Columns[k].ColumnName == "BankCode")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Bank_Code");
                    }
                    if (item.Columns[k].ColumnName == "BankAccountNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Bank_Account_Number");
                    }
                    if (item.Columns[k].ColumnName == "AccountName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Account_Name");
                    }
                    if (item.Columns[k].ColumnName == "SalesPerson")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    if (item.Columns[k].ColumnName == "Name")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Referred_By");
                    }
                    if (item.Columns[k].ColumnName == "eStoreName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("eStore_Name");
                    }
                    // OpenTasksCalls
                    if (item.Columns[k].ColumnName == "OpenTasksCalls")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                    }
                    if (item.Columns[k].ColumnName == "RoyalityFree")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Royality_Free");
                    }
                    if (item.Columns[k].ColumnName == "ContactName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    if (item.Columns[k].ColumnName == "FirstName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("First_Name");
                    }
                    if (item.Columns[k].ColumnName == "MiddleName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Middle_Name");
                    }
                    if (item.Columns[k].ColumnName == "LastName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Last_Name");
                    }
                    if (item.Columns[k].ColumnName == "Title")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Title");
                    }
                    if (item.Columns[k].ColumnName == "jobtitle")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title1");
                    }
                    if (item.Columns[k].ColumnName == "jobtitle2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title2");
                    }
                    if (item.Columns[k].ColumnName == "ContactEmail")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Email");
                    }
                    if (item.Columns[k].ColumnName == "Mobile")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Mobile");
                    }
                    if (item.Columns[k].ColumnName == "Phone")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Phone");
                    }
                    if (item.Columns[k].ColumnName == "AlternateNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Alternate_Number");
                    }
                    if (item.Columns[k].ColumnName == "PersonalFax")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Personal_Fax");
                    }
                    if (item.Columns[k].ColumnName == "Department")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department");
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Address");
                    }
                    if (item.Columns[k].ColumnName == "DeliveryAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address");
                    }
                    if (item.Columns[k].ColumnName == "InvoiceAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address");
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress1")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[1].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress2")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[2].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress3")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[3].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress4")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[4].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress5")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[5].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactCountry")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Country");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address1");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address2");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address3");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address4");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address5");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelCountry")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_AddressCountry");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address1");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address2");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address3");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address4");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address5");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvCountry")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Country");
                    }
                    // contact additional information Custom Field 1 to 5
                    if (item.Columns[k].ColumnName == "ContactCustomField1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field1");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field2");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field3");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field4");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field5");
                    }

                    if (item.Columns[k].ColumnName == "DepartmentName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Name");
                    }
                    if (item.Columns[k].ColumnName == "DeptDeliveryAddres")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Dept_Delivery_Address");
                    }
                    if (item.Columns[k].ColumnName == "DeptInvoiceAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Dept_Invoice_Address");
                    }
                    if (item.Columns[k].ColumnName == "AddressLabel")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Address_Label");
                    }
                    if (item.Columns[k].ColumnName == "Address1")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[1].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address2")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[2].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address3")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[3].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address4")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[4].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address5")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[5].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Country")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Country");
                    }
                    if (item.Columns[k].ColumnName == "Fax")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Fax");
                    }
                    if (item.Columns[k].ColumnName == "IsPostBoxAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("IsPostBoxAddress");
                    }
                    if (item.Columns[k].ColumnName == "TotalEstimate")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Total_Estimate");
                    }
                    if (item.Columns[k].ColumnName == "EstValue")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "TotalJob")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Total_Job");
                    }
                    if (item.Columns[k].ColumnName == "JobValue")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "JobVal")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "TotalInvoice")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Total_Invoice");
                    }
                    if (item.Columns[k].ColumnName == "InvoiceValue")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Invoice_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "EstimateJobconversioncount")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_count");
                    }
                    if (item.Columns[k].ColumnName == "EstimateJobconversionvalue")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_value");
                    }
                    if (item.Columns[k].ColumnName == "salutation")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Title");
                    }
                    if (item.Columns[k].ColumnName == "MainApprover")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Main_Approver");
                    }
                    if (item.Columns[k].ColumnName == "SubscribeUser")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Subscribed_User");
                    }
                    if (item.Columns[k].ColumnName == "IsReceiveMailOut")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Receive_Mail_out");
                    }
                    if (item.Columns[k].ColumnName == "JobTitle1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title1");
                    }
                    if (item.Columns[k].ColumnName == "JobTitle2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title2");
                    }
                    if (item.Columns[k].ColumnName == "personalfax")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Personal_Fax");
                    }

                    // Department additional information Custom Field 1 to 5
                    if (item.Columns[k].ColumnName == "DepartmentCustomField1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field1");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field2");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field3");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field4");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field5");
                    }
                }
             
            }
            
            DataTable item1 = new DataTable();
            if (this.chkest.Checked || this.chkest1.Checked || this.chkjob.Checked || this.chkjob1.Checked || this.chkinv.Checked || this.chkinv1.Checked || this.chkpo.Checked || this.chkpo1.Checked)
            {
                
                item1.Columns.Add("Total");
                item1.Columns.Add("Value");
                if (this.TotalEst != "")
                {
                    item1.Rows.Add("Total Estimate", this.TotalEst); 
                }
                if (this.TotalEstValue != "")
                {
                    item1.Rows.Add("Total Estimate Value ", this.TotalEstValue);
                }
                if (this.TotalJobs != "")
                {
                    item1.Rows.Add("Total Jobs", this.TotalJobs);
                }
                if (this.TotalJobValue != "")
                {
                    item1.Rows.Add("Total Job Value ", this.TotalJobValue);
                }
                if (this.TotalInv != "")
                {
                    item1.Rows.Add("Total Invoice", this.TotalInv);
                }
                if (this.TotalInvValue != "")
                {
                    item1.Rows.Add("Total Invoice Value " , this.TotalInvValue);
                }
                if (this.TotalPurchase != "")
                {
                    item1.Rows.Add("Total Purchase", this.TotalPurchase);
                }
                if (this.TotalPurchaseValue != "")
                {
                    item1.Rows.Add("Total Purchase Value ", this.TotalPurchaseValue);
                }
            }
            DataSet ds = new DataSet();
            DataTable dtCopy = item.Copy();
            ds.Tables.Add(dtCopy);
            if (item1.Columns.Count > 0)
            {
                ds.Tables.Add(item1);
            }
            
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
                Response.AddHeader("content-disposition", "attachment;filename=CRM_Report.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }
        private DataTable SetClientReportColumns(DataSet clientData)
        {
            this.Session["DeleteMsg"] = null;
            int num = 0;
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            int num1 = 0;
            while (num1 < this.chkColumns.Items.Count)
            {
                if (this.chkColumns.Items[1].Selected)
                {
                    flag = true;
                }
                if (this.chkColumns.Items[14].Selected)
                {
                    flag1 = true;
                }
                if (this.chkColumns.Items[20].Selected)
                {
                    flag2 = true;
                }
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
            DataTable item = clientData.Tables[0];
            foreach (DataRow row in item.Rows)
            {
                if (!row.Table.Columns.Contains("A/cOpened"))
                {
                    continue;
                }
                row["A/cOpened"] = this.objJava.Eprint_return_Date_Before_View(row["A/cOpened"].ToString(), this.CompanyID, this.UserID, true);
            }
            if (item.Columns.Contains("ClientID"))
            {
                item.Columns.Remove("ClientID");
            }
            if (item.Columns.Contains("contactID"))
            {
                item.Columns.Remove("contactID");
            }
            if (item.Columns.Contains("Name") && !flag2)
            {
                item.Columns.Remove("Name");
            }
            if (item.Columns.Contains("CompanyType") && !flag)
            {
                item.Columns.Remove("CompanyType");
            }
            if (item.Columns.Contains("CompanyNumber") && !flag1)
            {
                item.Columns.Remove("CompanyNumber");
            }

            foreach (DataColumn column in item.Columns)
            {
                for (int k = 0; k < item.Columns.Count; k++)
                {
                    if (item.Columns[k].ColumnName == "CompanyType")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Company_Type");
                    }
                    if (item.Columns[k].ColumnName == "AccountStatus")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Account_Status");
                    }
                    if (item.Columns[k].ColumnName == "AccountNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Account_Number");
                    }
                    if (item.Columns[k].ColumnName == "WebSite")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("URL");
                    }
                    if (item.Columns[k].ColumnName == "CreditLimit")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Credit_Limit");
                    }
                    if (item.Columns[k].ColumnName == "CreditRef")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Credit_Ref");
                    }
                    if (item.Columns[k].ColumnName == "Tax1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Tax1");
                    }
                    if (item.Columns[k].ColumnName == "Tax2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Tax2");
                    }
                    if (item.Columns[k].ColumnName == "Description")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Description");
                    }
                    if (item.Columns[k].ColumnName == "TaxRegNo")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Tax_reg_No");
                    }
                    if (item.Columns[k].ColumnName == "PaymentTerms")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Payment_Terms");
                    }
                    if (item.Columns[k].ColumnName == "CompanyNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Company_Number");
                    }
                    if (item.Columns[k].ColumnName == "ProfitMargin")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Profit_Margin");
                    }
                    if (item.Columns[k].ColumnName == "A/cOpened")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("A_C_Opened");
                    }
                    if (item.Columns[k].ColumnName == "BankCode")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Bank_Code");
                    }
                    if (item.Columns[k].ColumnName == "BankAccountNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Bank_Account_Number");
                    }
                    if (item.Columns[k].ColumnName == "AccountName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Account_Name");
                    }
                    if (item.Columns[k].ColumnName == "SalesPerson")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    if (item.Columns[k].ColumnName == "Name")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Referred_By");
                    }
                    if (item.Columns[k].ColumnName == "eStoreName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("eStore_Name");
                    }
                    // OpenTasksCalls
                    if (item.Columns[k].ColumnName == "OpenTasksCalls")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                    }
                    if (item.Columns[k].ColumnName == "RoyalityFree")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Royality_Free");
                    }
                    if (item.Columns[k].ColumnName == "ContactName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    if (item.Columns[k].ColumnName == "FirstName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("First_Name");
                    }
                    if (item.Columns[k].ColumnName == "MiddleName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Middle_Name");
                    }
                    if (item.Columns[k].ColumnName == "LastName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Last_Name");
                    }
                    if (item.Columns[k].ColumnName == "Title")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Title");
                    }
                    if (item.Columns[k].ColumnName == "jobtitle")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title1");
                    }
                    if (item.Columns[k].ColumnName == "jobtitle2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title2");
                    }
                    if (item.Columns[k].ColumnName == "ContactEmail")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Email");
                    }
                    if (item.Columns[k].ColumnName == "Mobile")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Mobile");
                    }
                    if (item.Columns[k].ColumnName == "Phone")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Phone");
                    }
                    if (item.Columns[k].ColumnName == "AlternateNumber")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Alternate_Number");
                    }
                    if (item.Columns[k].ColumnName == "PersonalFax")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Personal_Fax");
                    }
                    if (item.Columns[k].ColumnName == "Department")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department");
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Address");
                    }
                    if (item.Columns[k].ColumnName == "DeliveryAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address");
                    }
                    if (item.Columns[k].ColumnName == "InvoiceAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address");
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress1")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[1].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress2")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[2].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress3")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[3].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress4")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[4].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactAddress5")
                    {
                        item.Columns[k].ColumnName = string.Concat("Contact ", this.Chk_addressList.Items[5].Text.ToString());
                    }
                    if (item.Columns[k].ColumnName == "ContactCountry")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Country");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address1");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address2");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address3");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address4");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelAddress5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address5");
                    }
                    if (item.Columns[k].ColumnName == "ContactDelCountry")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Delivery_AddressCountry");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address1");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address2");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address3");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address4");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvAddress5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address5");
                    }
                    if (item.Columns[k].ColumnName == "ContactInvCountry")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Invoice_Country");
                    }
                    // contact additional information Custom Field 1 to 5
                    if (item.Columns[k].ColumnName == "ContactCustomField1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field1");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field2");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field3");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field4");
                    }
                    if (item.Columns[k].ColumnName == "ContactCustomField5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Custom_Field5");
                    }

                    if (item.Columns[k].ColumnName == "DepartmentName")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Name");
                    }
                    if (item.Columns[k].ColumnName == "DeptDeliveryAddres")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Dept_Delivery_Address");
                    }
                    if (item.Columns[k].ColumnName == "DeptInvoiceAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Dept_Invoice_Address");
                    }
                    if (item.Columns[k].ColumnName == "AddressLabel")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Address_Label");
                    }
                    if (item.Columns[k].ColumnName == "Address1")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[1].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address2")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[2].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address3")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[3].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address4")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[4].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Address5")
                    {
                        item.Columns[k].ColumnName = this.Chk_addressList.Items[5].Text.ToString();
                    }
                    if (item.Columns[k].ColumnName == "Country")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Country");
                    }
                    if (item.Columns[k].ColumnName == "Fax")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Fax");
                    }
                    if (item.Columns[k].ColumnName == "IsPostBoxAddress")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("IsPostBoxAddress");
                    }
                    if (item.Columns[k].ColumnName == "TotalEstimate")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Total_Estimate");
                    }
                    if (item.Columns[k].ColumnName == "EstValue")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "TotalJob")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Total_Job");
                    }
                    if (item.Columns[k].ColumnName == "JobValue")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "JobVal")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "TotalInvoice")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Total_Invoice");
                    }
                    if (item.Columns[k].ColumnName == "InvoiceValue")
                    {
                        item.Columns[k].ColumnName = string.Concat(this.objLangClass.GetLanguageConversion("Invoice_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (item.Columns[k].ColumnName == "EstimateJobconversioncount")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_count");
                    }
                    if (item.Columns[k].ColumnName == "EstimateJobconversionvalue")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_value");
                    }
                    if (item.Columns[k].ColumnName == "salutation")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Title");
                    }
                    if (item.Columns[k].ColumnName == "MainApprover")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Main_Approver");
                    }
                    if (item.Columns[k].ColumnName == "SubscribeUser")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Subscribed_User");
                    }
                    if (item.Columns[k].ColumnName == "IsReceiveMailOut")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Receive_Mail_out");
                    }
                    if (item.Columns[k].ColumnName == "JobTitle1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title1");
                    }
                    if (item.Columns[k].ColumnName == "JobTitle2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Job_Title2");
                    }
                    if (item.Columns[k].ColumnName == "personalfax")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Personal_Fax");
                    }

                    // Department additional information Custom Field 1 to 5
                    if (item.Columns[k].ColumnName == "DepartmentCustomField1")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field1");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField2")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field2");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField3")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field3");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField4")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field4");
                    }
                    if (item.Columns[k].ColumnName == "DepartmentCustomField5")
                    {
                        item.Columns[k].ColumnName = this.objLangClass.GetLanguageConversion("Department_Custom_Field5");
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
            this.divtab.Visible = true;
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            this.divaggregate.Visible = false;
            this.divAggl.Visible = false;
            if (this.rdlDate.SelectedValue == "daterange")
            {
                this.txtFrom.Enabled = true;
                this.txtTo.Enabled = true;
            }
            if (this.ddlContactDateOption.SelectedValue == "daterange")
            {
                this.txtfromdate_converted.Enabled = true;
                this.txttodate_converted.Enabled = true;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetSelect();", true);
        }

        public void btngo_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            try
            {
                this.paging_OnPageChange(Convert.ToInt32(this.txt1.Text));
            }
            catch
            {
                this.paging_OnPageChange(Convert.ToInt32("1"));
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
                this.Panel1.Visible = false;
                int num = 0;
                this.div_showfilters.Style.Add("display", "none");
                this.divusrReportsave.Style.Add("display", "none");
                this.divtab.Visible = false;
                this.btnfilter.Visible = true;
                if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("crm", "exportreport").Trim().ToLower() != "false")
                {
                    this.btnExport.Visible = true;
                }
                else
                {
                    this.btnExport.Visible = false;
                }
                this.divtoolbar.Visible = true;
                this.txt1.Visible = true;
                this.btngo.Visible = true;
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
                    if (this.ddlGrouprecords.SelectedIndex != 0)
                    {
                        this.GridEstReport.Visible = false;
                        this.usrPaging.Visible = false;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.div_Total.Visible = true;
                    }
                    else
                    {
                        this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                        if (estimateData.Tables[0].Rows.Count == 0)
                        {
                            this.pnlEmptyRecords.Visible = true;
                            this.GridEstReport.Visible = false;
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
                            DataTable dt = SetClientReportColumns(estimateData);
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
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                            ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                            ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                            this.GridEstReport.Visible = true;
                            this.div_Total.Visible = false;
                            this.pnlEmptyRecords.Visible = false;
                            DataTable dt = SetClientReportColumns(estimateData);
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
            }
            catch
            {
            }
            this.pnlMask.Visible = false;
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
                sqlCommand.Parameters.AddWithValue("@Pagename", "client");
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
            string[] strArrays;
            string str;
            object[] companyID;
            DateTime now;
            object empty;
            DataSet dataSet = new DataSet();
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
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            string str11 = string.Empty;
            string empty12 = string.Empty;
            string str12 = this.txtFreetext.Text.ToString();
            char[] chrArray = new char[] { ',' };
            str12.Split(chrArray);
            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
            {
                str10 = base.SpecialEncode(this.txtFreetext.Text);
                if (str10.Contains(" "))
                {
                    strArrays = new string[] { " " };
                    string[] strArrays1 = str10.Split(strArrays, StringSplitOptions.None);
                    str10 = strArrays1[0].ToString();
                    empty11 = strArrays1[1].ToString();
                }
            }
            string empty13 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (!this.chkColumns.Items[i].Selected)
                {
                    if (this.chkColumns.Items[i].Value == "CompanyNumber")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "a.CompanyNumber";
                            strArrays = new string[] { " ltrim(a.CompanyNumber) like ltrim('%", str10, "%", empty11, "%') " };
                            empty10 = string.Concat(strArrays);
                            str = empty10;
                            strArrays = new string[] { str, " or ltrim(a.CompanyNumber) like ltrim('%", empty11, "%", str10, "%') " };
                            empty10 = string.Concat(strArrays);
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",a.CompanyNumber");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyNumber) like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyNumber) like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "CompanyType")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "Replace(Replace(a.CompanyType,'%27',''''),'%22','\"') as CompanyType";
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                strArrays = new string[] { "  ltrim(a.CompanyType) like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or  ltrim(a.CompanyType) like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(a.CompanyType,'%27',''''),'%22','\"') as CompanyType");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyType) like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyType) like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "name")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "'' as z.name";
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                strArrays = new string[] { "  z.Name like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or z.Name like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(z.name,'%27',''''),'%22','\"') as Name");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or z.Name like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or z.Name like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    // estorename
                    if (this.chkColumns.Items[i].Value == "eStoreName")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "Replace(Replace(ISNULL(ac.accountName,''),'%27',''''),'%22','\"') as eStoreName";
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                strArrays = new string[] { "  ac.accountName like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ac.accountName like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(ISNULL(ac.accountName,''),'%27',''''),'%22','\"') as eStoreName");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or ac.accountName like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ac.accountName like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                }
                else
                {
                    if (this.chkColumns.Items[i].Value == "CompanyName")
                    {
                        empty1 = "a.clientID,Replace(Replace(ltrim(a.clientName),'%27',''''),'%22','\"') as [Company Name]";
                        if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                        {
                            strArrays = new string[] { " ltrim(a.clientName) like ltrim('%", str10, "%", empty11, "%') " };
                            empty10 = string.Concat(strArrays);
                            str = empty10;
                            strArrays = new string[] { str, " or ltrim(a.clientName) like ltrim('%", str10, "%", empty11, "%') " };
                            empty10 = string.Concat(strArrays);
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "CompanyType")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "Replace(Replace(a.CompanyType,'%27',''''),'%22','\"') as CompanyType";
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                strArrays = new string[] { "  ltrim(a.CompanyType) like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or  ltrim(a.CompanyType) like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(a.CompanyType,'%27',''''),'%22','\"') as CompanyType");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyType) like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyType) like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Type")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.isNull(a.clienttype,''),'%27',''''),'%22','\"') as Type" : string.Concat(empty1, ",Replace(Replace(isNull(a.clienttype,''),'%27',''''),'%22','\"') as Type"));
                    }
                    if (this.chkColumns.Items[i].Value == "AccountStatus")
                    {
                        if (empty1 == "")
                        {
                            empty1 = string.Concat("Replace(Replace((Select tb_AccountStatus.StatusTitle from tb_AccountStatus where tb_AccountStatus.CompanyID=", this.CompanyID, " and tb_AccountStatus.StatusID=a.AccountStatus and tb_AccountStatus.IsDeleted=0),'%27',''''),'%22','\"') as AccountStatus");
                        }
                        else
                        {
                            companyID = new object[] { empty1, ",Replace(Replace((Select tb_AccountStatus.StatusTitle from tb_AccountStatus where tb_AccountStatus.CompanyID=", this.CompanyID, " and tb_AccountStatus.StatusID=a.AccountStatus and tb_AccountStatus.IsDeleted=0),'%27',''''),'%22','\"') as AccountStatus " };
                            empty1 = string.Concat(companyID);
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "AccountNo")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.AccountNumber,'%27',''''),'%22','\"') as AccountNumber" : string.Concat(empty1, ",Replace(Replace(a.AccountNumber,'%27',''''),'%22','\"') as AccountNumber"));
                    }
                    if (this.chkColumns.Items[i].Value == "Email")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.businessemail,'%27',''''),'%22','\"') as [Email]" : string.Concat(empty1, ",Replace(Replace(a.businessemail,'%27',''''),'%22','\"') as [Email]"));
                    }
                    if (this.chkColumns.Items[i].Value == "URL")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.WebSite,'%27',''''),'%22','\"') as [URL]" : string.Concat(empty1, ",Replace(Replace(a.WebSite,'%27',''''),'%22','\"') as [URL]"));
                    }
                    if (this.chkColumns.Items[i].Value == "CreditLimit")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.CreditLimit,'%27',''''),'%22','\"') as CreditLimit" : string.Concat(empty1, ",Replace(Replace(a.CreditLimit,'%27',''''),'%22','\"') as CreditLimit"));
                    }
                    if (this.chkColumns.Items[i].Value == "CreditRef")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.CreditRef,'%27',''''),'%22','\"') as CreditRef" : string.Concat(empty1, ",Replace(Replace(a.CreditRef,'%27',''''),'%22','\"') as CreditRef"));
                    }
                    if (this.Tax2.ToLower() != "no")
                    {
                        if (this.chkColumns.Items[i].Value == "Tax1")
                        {
                            if (empty1 == "")
                            {
                                empty1 = string.Concat("Replace(Replace((Select t.taxname from tb_TaxRates t  where t.CompanyID=", this.CompanyID, " and t.taxID=a.Tax1 and t.IsDeleted=0),'%27',''''),'%22','\"') as Tax1");
                            }
                            else
                            {
                                companyID = new object[] { empty1, ",Replace(Replace((Select t.taxname from tb_TaxRates t  where t.CompanyID=", this.CompanyID, " and t.taxID=a.Tax1 and t.IsDeleted=0),'%27',''''),'%22','\"') as Tax1" };
                                empty1 = string.Concat(companyID);
                            }
                        }
                        if (this.chkColumns.Items[i].Value == "Tax2")
                        {
                            if (empty1 == "")
                            {
                                empty1 = string.Concat("Replace(Replace((Select t.taxname from tb_TaxRates t  where t.CompanyID=", this.CompanyID, " and t.taxID=a.Tax2 and t.IsDeleted=0),'%27',''''),'%22','\"') as Tax2");
                            }
                            else
                            {
                                companyID = new object[] { empty1, ",Replace(Replace((Select t.taxname from tb_TaxRates t  where t.CompanyID=", this.CompanyID, " and t.taxID=a.Tax2 and t.IsDeleted=0),'%27',''''),'%22','\"') as Tax2" };
                                empty1 = string.Concat(companyID);
                            }
                        }
                    }
                    else if (this.chkColumns.Items[i].Value == "Tax1")
                    {
                        if (empty1 == "")
                        {
                            empty1 = string.Concat("Replace(Replace((Select t.taxname from tb_TaxRates t  where t.CompanyID=", this.CompanyID, " and t.taxID=a.Tax1 and t.IsDeleted=0),'%27',''''),'%22','\"') as Tax");
                        }
                        else
                        {
                            companyID = new object[] { empty1, ",Replace(Replace((Select t.taxname from tb_TaxRates t  where t.CompanyID=", this.CompanyID, " and t.taxID=a.Tax1 and t.IsDeleted=0),'%27',''''),'%22','\"') as Tax" };
                            empty1 = string.Concat(companyID);
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "Description")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.Description,'%27',''''),'%22','\"') as Description" : string.Concat(empty1, ",Replace(Replace(a.Description,'%27',''''),'%22','\"') as Description"));
                    }
                    if (this.chkColumns.Items[i].Value == "PaymentTerms")
                    {
                        if (empty1 == "")
                        {
                            empty1 = string.Concat("Replace(Replace(IsNull([dbo].[ReturnPaymentName](", this.CompanyID, ",a.PaymentTerms),''),'%27',''''),'%22','\"') as PaymentTerms");
                        }
                        else
                        {
                            companyID = new object[] { empty1, ",Replace(Replace(IsNull([dbo].[ReturnPaymentName](", this.CompanyID, ",a.PaymentTerms),''),'%27',''''),'%22','\"') as PaymentTerms" };
                            empty1 = string.Concat(companyID);
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ProfitMargin")
                    {
                        empty1 = (empty1 == "" ? "a.ProfitMargin" : string.Concat(empty1, ",a.ProfitMargin"));
                    }
                    if (this.chkColumns.Items[i].Value == "TaxRegNo")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.TaxRegNo,'%27',''''),'%22','\"') as TaxRegNo" : string.Concat(empty1, ",Replace(Replace(a.TaxRegNo,'%27',''''),'%22','\"') as TaxRegNo"));
                    }
                    if (this.chkColumns.Items[i].Value == "CompanyNumber")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "Replace(Replace(a.CompanyNumber,'%27',''''),'%22','\"') as CompanyNumber";
                            strArrays = new string[] { " ltrim(a.CompanyNumber) like ltrim('%", str10, "%", empty11, "%') " };
                            empty10 = string.Concat(strArrays);
                            str = empty10;
                            strArrays = new string[] { str, " or ltrim(a.CompanyNumber) like ltrim('%", empty11, "%", str10, "%') " };
                            empty10 = string.Concat(strArrays);
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(a.CompanyNumber,'%27',''''),'%22','\"') as CompanyNumber");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyNumber) like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ltrim(a.CompanyNumber) like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "ACOpened")
                    {
                        empty1 = (empty1 == "" ? "CONVERT(VARCHAR(100),a.[A/cOpened],101) as [A/cOpened]" : string.Concat(empty1, ",CONVERT(VARCHAR(100),a.[A/cOpened],101) as [A/cOpened]"));
                    }
                    if (this.chkColumns.Items[i].Value == "BankCode")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.BankCode,'%27',''''),'%22','\"') as BankCode" : string.Concat(empty1, ",Replace(Replace(a.BankCode,'%27',''''),'%22','\"') as BankCode"));
                    }
                    if (this.chkColumns.Items[i].Value == "BankAccountNumber")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.BankAccountNumber,'%27',''''),'%22','\"') as [Bank Account Number]" : string.Concat(empty1, ",Replace(Replace(a.BankAccountNumber,'%27',''''),'%22','\"') as [Bank Account Number]"));
                    }
                    if (this.chkColumns.Items[i].Value == "AccountName")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(a.AccountName,'%27',''''),'%22','\"') as AccountName" : string.Concat(empty1, ",Replace(Replace(a.AccountName,'%27',''''),'%22','\"') as AccountName"));
                    }
                    if (this.chkColumns.Items[i].Value == "SalesPerson")
                    {
                        if (empty1 == "")
                        {
                            empty1 = string.Concat("Replace(Replace((Select r.firstname from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userID=a.SalesPerson and r.IsDelete=0),'%27',''''),'%22','\"') as SalesPerson ");
                        }
                        else
                        {
                            companyID = new object[] { empty1, ",Replace(Replace((Select r.firstname from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=a.SalesPerson and r.IsDelete=0),'%27',''''),'%22','\"') as SalesPerson " };
                            empty1 = string.Concat(companyID);
                        }
                    }
                    if (this.chkColumns.Items[i].Value == "name")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "'' as z.name";
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                strArrays = new string[] { "  z.Name like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or z.Name like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(z.name,'%27',''''),'%22','\"') as Name");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or z.Name like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or z.Name like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    
                    // added eStoreNmae
                    if (this.chkColumns.Items[i].Value == "eStoreName")
                    {
                        if (empty1 == "")
                        {
                            empty1 = "Replace(Replace(ISNULL(ac.accountName,''),'%27',''''),'%22','\"') as eStoreName";
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                strArrays = new string[] { "  ac.accountName like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ac.accountName like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                        else
                        {
                            empty1 = string.Concat(empty1, ",Replace(Replace(ISNULL(ac.accountName,''),'%27',''''),'%22','\"') as eStoreName");
                            if (this.txtFreetext.Text != "" || this.txtFreetext.Text != null)
                            {
                                str = empty10;
                                strArrays = new string[] { str, " or ac.accountName like ltrim('%", str10, "%", empty11, "%') " };
                                empty10 = string.Concat(strArrays);
                                str = empty10;
                                strArrays = new string[] { str, " or ac.accountName like ltrim('%", empty11, "%", str10, "%') " };
                                empty10 = string.Concat(strArrays);
                            }
                        }
                    }
                    // OpenTasksCalls
                    if (this.chkColumns.Items[i].Value == "OpenTasksCalls")
                    {
                        empty1 = (empty1 == "" ? "isnull([dbo].[Get_Total_TaskCall_Count](a.clientID," + this.CompanyID + " , " + this.UserID + "), 0) as OpenTasksCalls" : string.Concat(empty1, ", isnull([dbo].[Get_Total_TaskCall_Count](a.clientID," + this.CompanyID + " , " + this.UserID + "), 0) as OpenTasksCalls"));
                    }
                    if (this.chkColumns.Items[i].Value == "RoyalityFree")
                    {
                        empty1 = (empty1 == "" ? "case when a.RoyalityFree=1 then 'Yes' else 'No' end as RoyalityFree" : string.Concat(empty1, ",case when a.RoyalityFree=1 then 'Yes' else 'No' end as RoyalityFree"));
                    }
                    
                    // eStoreName
                    //if (this.chkColumns.Items[i].Value == "eStoreName")
                    //{
                    //    if (empty1 == "")
                    //    {
                    //        empty1 = string.Concat("Replace(Replace((SELECT ISNULL(accountName, '') FROM tb_Accounts WHERE accountID = a.AccountID AND isDeleted = 0 AND CompanyID = ", this.CompanyID, " ),'%27',''''),'%22','\"') as eStoreName ");
                    //    }
                    //    else
                    //    {
                    //        companyID = new object[] { empty1, ",Replace(Replace((SELECT ISNULL(accountName, '') FROM tb_Accounts WHERE accountID = a.AccountID AND isDeleted = 0 AND CompanyID = ", this.CompanyID, " ),'%27',''''),'%22','\"') as eStoreName " };
                    //        empty1 = string.Concat(companyID);
                    //    }
                    //}
                }
            }
            for (int j = 0; j < this.chk_contactsList.Items.Count; j++)
            {
                if (this.chk_contactsList.Items[j].Selected)
                {
                    client_report clientClientReport = this;
                    clientClientReport.contactlstcount = clientClientReport.contactlstcount + 1;
                    if (this.chk_contactsList.Items[j].Value == "ContactName")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(Isnull(IsNull(b.firstname, '')+' '+IsNull(b.Middlename,'')+' '+IsNull(b.lastname,''),''),'%27',''''),'%22','\"') as ContactName" : string.Concat(empty1, ",Replace(Replace(Isnull(IsNull(b.firstname, '')+' '+IsNull(b.Middlename,'')+' '+IsNull(b.lastname,''),''),'%27',''''),'%22','\"') as ContactName"));                        
                    }
                    else if (this.chk_contactsList.Items[j].Value == "FirstName")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(IsNull(b.firstname, ''),'%27',''''),'%22','\"') as FirstName" : string.Concat(empty1, ",Replace(Replace(IsNull(b.firstname, ''),'%27',''''),'%22','\"') as FirstName"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "MiddleName")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(IsNull(b.Middlename,''),'%27',''''),'%22','\"') as MiddleName" : string.Concat(empty1, ",Replace(Replace(IsNull(b.Middlename,''),'%27',''''),'%22','\"') as MiddleName"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "LastName")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(IsNull(b.lastname,''),'%27',''''),'%22','\"') as LastName" : string.Concat(empty1, ",Replace(Replace(IsNull(b.lastname,''),'%27',''''),'%22','\"') as LastName"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "Title")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.salutation,'%27',''''),'%22','\"') as Title" : string.Concat(empty1, ",Replace(Replace(b.salutation,'%27',''''),'%22','\"') as Title"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "JobTitle1")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.jobtitle,'%27',''''),'%22','\"') as jobtitle" : string.Concat(empty1, ",Replace(Replace(b.jobtitle,'%27',''''),'%22','\"') as jobtitle"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "JobTitle2")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.jobtitle2,'%27',''''),'%22','\"') as jobtitle2" : string.Concat(empty1, ",Replace(Replace(b.jobtitle2,'%27',''''),'%22','\"') as jobtitle2"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "ContactEmail")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.Email,'%27',''''),'%22','\"') as ContactEmail" : string.Concat(empty1, ",Replace(Replace(b.Email,'%27',''''),'%22','\"') as ContactEmail"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "Mobile")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.Mobile,'%27',''''),'%22','\"') as Mobile" : string.Concat(empty1, ",Replace(Replace(b.Mobile,'%27',''''),'%22','\"') as Mobile"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "Phone")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.HomeTelephone,'%27',''''),'%22','\"') as Phone" : string.Concat(empty1, ",Replace(Replace(b.HomeTelephone,'%27',''''),'%22','\"') as Phone"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "AlternateNumber")
                    {
                        empty1 = (empty1 == "" ? "b.AlternateNumbers as AlternateNumber" : string.Concat(empty1, ",b.AlternateNumbers as AlternateNumber"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "PersonalFax")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.personalfax,'%27',''''),'%22','\"') as [Personal Fax]" : string.Concat(empty1, ",Replace(Replace(b.personalfax,'%27',''''),'%22','\"') as [Personal Fax]"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "Department")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace((select isnull(deptname,'') from tb_department where deptid=b.departmentid),'%27',''''),'%22','\"') as DepartmentName" : string.Concat(empty1, ",Replace(Replace((select isnull(deptname,'') from tb_department where deptid=b.departmentid),'%27',''''),'%22','\"') as DepartmentName"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "MainApprover")
                    {
                        empty1 = (empty1 == "" ? "case when b.MainApprover = 0 then 'No' else 'Yes' end as MainApprover" : string.Concat(empty1, ",case when b.MainApprover = 0 then 'No' else 'Yes' end as MainApprover"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "SubscribedUser")
                    {
                        empty1 = (empty1 == "" ? "case when b.Subscribe_NewsLetter = 0 then 'No' else 'Yes' end as SubscribeUser" : string.Concat(empty1, ",case when b.Subscribe_NewsLetter = 0 then 'No' else 'Yes' end as SubscribeUser"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "ReceiveMailout")
                    {
                        empty1 = (empty1 == "" ? "case when b.IsReceiveMailOut = 0 then 'No' else 'Yes' end as IsReceiveMailOut" : string.Concat(empty1, ",case when b.IsReceiveMailOut = 0 then 'No' else 'Yes' end as IsReceiveMailOut"));
                    }

                    // contact additional information Custom Field 1 to 5
                    else if (this.chk_contactsList.Items[j].Value == "ContactCustomField1")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.CustomField1,'%27',''''),'%22','\"') AS [ContactCustomField1]" : string.Concat(empty1, ",Replace(Replace(b.CustomField1,'%27',''''),'%22','\"') AS [ContactCustomField1]"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "ContactCustomField2")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.CustomField2,'%27',''''),'%22','\"') AS [ContactCustomField2]" : string.Concat(empty1, ",Replace(Replace(b.CustomField2,'%27',''''),'%22','\"') AS [ContactCustomField2]"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "ContactCustomField3")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.CustomField3,'%27',''''),'%22','\"') AS [ContactCustomField3]" : string.Concat(empty1, ",Replace(Replace(b.CustomField3,'%27',''''),'%22','\"') AS [ContactCustomField3]"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "ContactCustomField4")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.CustomField4,'%27',''''),'%22','\"') AS [ContactCustomField4]" : string.Concat(empty1, ",Replace(Replace(b.CustomField4,'%27',''''),'%22','\"') AS [ContactCustomField4]"));
                    }
                    else if (this.chk_contactsList.Items[j].Value == "ContactCustomField5")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(b.CustomField5,'%27',''''),'%22','\"') AS [ContactCustomField5]" : string.Concat(empty1, ",Replace(Replace(b.CustomField5,'%27',''''),'%22','\"') AS [ContactCustomField5]"));
                    }

                    else if (this.chk_contactsList.Items[j].Value == "ContactAddress")
                    {
                        if (this.ddlIndividual.SelectedValue == "IndividualColumn")
                        {
                            empty1 = (empty1 == "" ? "Replace(Replace(c1.Address,'%27',''''),'%22','\"') as ContactAddress1,Replace(Replace(c1.addressline2,'%27',''''),'%22','\"') as ContactAddress2,Replace(Replace(c1.city,'%27',''''),'%22','\"') as ContactAddress3,Replace(Replace(c1.state,'%27',''''),'%22','\"') as ContactAddress4,Replace(Replace(c1.zipcode,'%27',''''),'%22','\"') as ContactAddress5,Replace(Replace(c1.Country,'%27',''''),'%22','\"') as ContactCountry" : string.Concat(empty1, ",Replace(Replace(c1.Address,'%27',''''),'%22','\"') as ContactAddress1,Replace(Replace(c1.addressline2,'%27',''''),'%22','\"') as ContactAddress2,Replace(Replace(c1.city,'%27',''''),'%22','\"') as ContactAddress3,Replace(Replace(c1.state,'%27',''''),'%22','\"') as ContactAddress4,Replace(Replace(c1.zipcode,'%27',''''),'%22','\"') as ContactAddress5,Replace(Replace(c1.Country,'%27',''''),'%22','\"') as ContactCountry"));
                        }
                        else if (empty1 == "")
                        {
                            empty1 = string.Concat("Replace(Replace(dbo.[ReturnContactAddress_ContactID](", this.CompanyID, ",b.contactid,'c'),'%27',''''),'%22','\"') as ContactAddress");
                        }
                        else
                        {
                            companyID = new object[] { empty1, ",Replace(Replace(dbo.[ReturnContactAddress_ContactID](", this.CompanyID, ",b.contactid,'c'),'%27',''''),'%22','\"') as ContactAddress" };
                            empty1 = string.Concat(companyID);
                        }
                    }
                    else if (this.chk_contactsList.Items[j].Value != "DeliveryAddress")
                    {
                        if (this.chk_contactsList.Items[j].Value == "InvoiceAddress")
                        {
                            if (this.ddlIndividual.SelectedValue == "IndividualColumn")
                            {
                                empty1 = (empty1 == "" ? "Replace(Replace(c3.Address,'%27',''''),'%22','\"') as ContactInvAddress1,Replace(Replace(c3.addressline2,'%27',''''),'%22','\"') as ContactInvAddress2,Replace(Replace(c3.city,'%27',''''),'%22','\"') as ContactInvAddress3,Replace(Replace(c3.state,'%27',''''),'%22','\"') as ContactInvAddress4,Replace(Replace(c3.zipcode,'%27',''''),'%22','\"') as ContactInvAddress5,Replace(Replace(c3.Country,'%27',''''),'%22','\"') as ContactInvCountry" : string.Concat(empty1, ",Replace(Replace(c3.Address,'%27',''''),'%22','\"') as ContactInvAddress1,Replace(Replace(c3.addressline2,'%27',''''),'%22','\"') as ContactInvAddress2,Replace(Replace(c3.city,'%27',''''),'%22','\"') as ContactInvAddress3,Replace(Replace(c3.state,'%27',''''),'%22','\"') as ContactInvAddress4,Replace(Replace(c3.zipcode,'%27',''''),'%22','\"') as ContactInvAddress5,Replace(Replace(c3.Country,'%27',''''),'%22','\"') as ContactInvCountry"));
                            }
                            else if (empty1 == "")
                            {
                                empty1 = string.Concat("Replace(Replace(dbo.[ReturnContactAddress_ContactID](", this.CompanyID, ",b.contactid,'i'),'%27',''''),'%22','\"') as InvoiceAddress");
                            }
                            else
                            {
                                companyID = new object[] { empty1, ",Replace(Replace(dbo.[ReturnContactAddress_ContactID](", this.CompanyID, ",b.contactid,'i'),'%27',''''),'%22','\"') as InvoiceAddress" };
                                empty1 = string.Concat(companyID);
                            }
                        }
                    }
                    else if (this.ddlIndividual.SelectedValue == "IndividualColumn")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(c2.Address,'%27',''''),'%22','\"') as ContactDelAddress1,Replace(Replace(c2.addressline2,'%27',''''),'%22','\"') as ContactDelAddress2,Replace(Replace(c2.city,'%27',''''),'%22','\"') as ContactDelAddress3,Replace(Replace(c2.state,'%27',''''),'%22','\"') as ContactDelAddress4,Replace(Replace(c2.zipcode,'%27',''''),'%22','\"') as ContactDelAddress5,Replace(Replace(c2.Country,'%27',''''),'%22','\"') as ContactDelCountry" : string.Concat(empty1, ",Replace(Replace(c2.Address,'%27',''''),'%22','\"') as ContactDelAddress1,Replace(Replace(c2.addressline2,'%27',''''),'%22','\"') as ContactDelAddress2,Replace(Replace(c2.city,'%27',''''),'%22','\"') as ContactDelAddress3,Replace(Replace(c2.state,'%27',''''),'%22','\"') as ContactDelAddress4,Replace(Replace(c2.zipcode,'%27',''''),'%22','\"') as ContactDelAddress5,Replace(Replace(c2.Country,'%27',''''),'%22','\"') as ContactDelCountry"));
                    }
                    else if (empty1 == "")
                    {
                        empty1 = string.Concat("Replace(Replace(dbo.[ReturnContactAddress_ContactID](", this.CompanyID, ",b.contactid,'d'),'%27',''''),'%22','\"') as DeliveryAddress");
                    }
                    else
                    {
                        companyID = new object[] { empty1, ",Replace(Replace(dbo.[ReturnContactAddress_ContactID](", this.CompanyID, ",b.contactid,'d'),'%27',''''),'%22','\"') as DeliveryAddress" };
                        empty1 = string.Concat(companyID);
                    }
                }
            }
            for (int k = 0; k < this.Chk_DepartmentList.Items.Count; k++)
            {
                if (this.Chk_DepartmentList.Items[k].Selected)
                {
                    client_report departmentlstcount = this;
                    departmentlstcount.Departmentlstcount = departmentlstcount.Departmentlstcount + 1;
                    if (this.Chk_DepartmentList.Items[k].Value == "DepartmentName")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(d.deptname,''),'%27',''''),'%22','\"') as DepartmentName " : string.Concat(empty1, ",Replace(Replace(isnull(d.deptname,''),'%27',''''),'%22','\"') as DepartmentName "));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "DeliveryAddress1")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(isnull(a1.Address,'')+' '+isnull(a1.AddressLine2,'')+' '+isnull(a1.City,'')+' '+isnull(a1.State,'')+' '+  isnull(a1.ZipCode,'') +' '+isnull(a1.Country,''),''),'%27',''''),'%22','\"') as DeptDeliveryAddress" : string.Concat(empty1, ",Replace(Replace(isnull(isnull(a1.Address,'')+' '+isnull(a1.AddressLine2,'')+' '+isnull(a1.City,'')+' '+isnull(a1.State,'')+' '+  isnull(a1.ZipCode,'') +' '+isnull(a1.Country,''),'') ,'%27',''''),'%22','\"') as DeptDeliveryAddress"));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "InvoiceAddress1")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(isnull(ad.Address,'')+' '+isnull(ad.AddressLine2,'')+' '+isnull(ad.City,'')+' '+isnull(ad.State,'')+' '+ isnull(ad.ZipCode,'') +' '+isnull(ad.Country,''),''),'%27',''''),'%22','\"') as DeptInvoiceAddress" : string.Concat(empty1, ",Replace(Replace(isnull(isnull(ad.Address,'')+' '+isnull(ad.AddressLine2,'')+' '+isnull(ad.City,'')+' '+isnull(ad.State,'')+' '+ isnull(ad.ZipCode,'') +' '+isnull(ad.Country,''),''),'%27',''''),'%22','\"') as DeptInvoiceAddress"));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "Costcenter")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(CASE WHEN ISNULL(cct.CostCentreCode, '') = '' THEN ISNULL(cct.CostCentreName, '') WHEN ISNULL(cct.CostCentreName, '') = '' THEN ISNULL(cct.CostCentreCode, '') ELSE ISNULL((cct.CostCentreCode + ' - ' + cct.CostCentreName), '') END,'%27',''''),'%22','\"') AS CostCentre" : string.Concat(empty1, ",Replace(Replace(CASE WHEN ISNULL(cct.CostCentreCode, '') = '' THEN ISNULL(cct.CostCentreName, '') WHEN ISNULL(cct.CostCentreName, '') = '' THEN ISNULL(cct.CostCentreCode, '') ELSE ISNULL((cct.CostCentreCode + ' - ' + cct.CostCentreName), '') END,'%27',''''),'%22','\"') AS CostCentre"));
                    }
                    
                    // Department additional information Custom Field 1 to 5
                    else if (this.Chk_DepartmentList.Items[k].Value == "DepartmentCustomField1")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(d.CustomField1,''),'%27',''''),'%22','\"') as [DepartmentCustomField1] " : string.Concat(empty1, ",Replace(Replace(isnull(d.CustomField1,''),'%27',''''),'%22','\"') as [DepartmentCustomField1] "));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "DepartmentCustomField2")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(d.CustomField2,''),'%27',''''),'%22','\"') as [DepartmentCustomField2] " : string.Concat(empty1, ",Replace(Replace(isnull(d.CustomField2,''),'%27',''''),'%22','\"') as [DepartmentCustomField2] "));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "DepartmentCustomField3")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(d.CustomField3,''),'%27',''''),'%22','\"') as [DepartmentCustomField3] " : string.Concat(empty1, ",Replace(Replace(isnull(d.CustomField3,''),'%27',''''),'%22','\"') as [DepartmentCustomField3] "));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "DepartmentCustomField4")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(d.CustomField4,''),'%27',''''),'%22','\"') as [DepartmentCustomField4] " : string.Concat(empty1, ",Replace(Replace(isnull(d.CustomField4,''),'%27',''''),'%22','\"') as [DepartmentCustomField4] "));
                    }
                    else if (this.Chk_DepartmentList.Items[k].Value == "DepartmentCustomField5")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(isnull(d.CustomField5,''),'%27',''''),'%22','\"') as [DepartmentCustomField5] " : string.Concat(empty1, ",Replace(Replace(isnull(d.CustomField5,''),'%27',''''),'%22','\"') as [DepartmentCustomField5] "));
                    }
                }
            }
            for (int l = 0; l < this.Chk_addressList.Items.Count; l++)
            {
                if (this.Chk_addressList.Items[l].Selected)
                {
                    client_report addresstlstcount = this;
                    addresstlstcount.addresslstcount = addresstlstcount.addresslstcount + 1;
                    if (this.Chk_addressList.Items[l].Value == "AddressLabel")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.AddressLabel,'%27',''''),'%22','\"') as AddressLabel" : string.Concat(empty1, ",Replace(Replace(cmp.AddressLabel,'%27',''''),'%22','\"') as AddressLabel"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Address1")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.Address,'%27',''''),'%22','\"') as Address1" : string.Concat(empty1, ",Replace(Replace(cmp.Address,'%27',''''),'%22','\"') as Address1"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Address2")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.addressline2,'%27',''''),'%22','\"') as Address2" : string.Concat(empty1, ",Replace(Replace(cmp.addressline2,'%27',''''),'%22','\"') as Address2"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Address3")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.city,'%27',''''),'%22','\"') as Address3" : string.Concat(empty1, ",Replace(Replace(cmp.city,'%27',''''),'%22','\"') as Address3"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Address4")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.state,'%27',''''),'%22','\"') as Address4" : string.Concat(empty1, ",Replace(Replace(cmp.state,'%27',''''),'%22','\"') as Address4"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Address5")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.zipcode,'%27',''''),'%22','\"') as Address5" : string.Concat(empty1, ",Replace(Replace(cmp.zipcode,'%27',''''),'%22','\"') as Address5"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Country")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.Country,'%27',''''),'%22','\"') as Country" : string.Concat(empty1, ",Replace(Replace(cmp.Country,'%27',''''),'%22','\"') as Country"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Telephone")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.Telephone,'%27',''''),'%22','\"') as Telephone" : string.Concat(empty1, ",Replace(Replace(cmp.Telephone,'%27',''''),'%22','\"') as Telephone"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "Fax")
                    {
                        empty1 = (empty1 == "" ? "Replace(Replace(cmp.Fax,'%27',''''),'%22','\"') as Fax" : string.Concat(empty1, ",Replace(Replace(cmp.Fax,'%27',''''),'%22','\"') as Fax"));
                    }
                    else if (this.Chk_addressList.Items[l].Value == "IsPostBoxAddress")
                    {
                        empty1 = (empty1 == "" ? "case when cmp.isdefaultpostboxaddress=1 and cmp.isdelete=0 then 'Yes' else case when cmp.isdefaultpostboxaddress=0 and cmp.isdelete=0 then 'No' else '' end end as IsPostBoxAddress" : string.Concat(empty1, ",case when cmp.isdefaultpostboxaddress=1 and cmp.isdelete=0 then 'Yes' else case when cmp.isdefaultpostboxaddress=0 and cmp.isdelete=0 then 'No' else '' end end as IsPostBoxAddress"));
                    }
                }
            }
            for (int m = 0; m < this.chkAggCustomeritems.Items.Count; m++)
            {
                if (this.chkAggCustomeritems.Items[m].Selected)
                {
                    if (this.chkAggCustomeritems.Items[m].Value == "TotalEstimate")
                    {
                        string str13 = string.Empty;
                        string empty14 = string.Empty;
                        string str14 = string.Empty;
                        if (this.chkestimatevaluerange.Checked)
                        {
                            if (this.ddlestimatevaluedaterange.SelectedValue == "current month")
                            {
                                str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                                empty14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "last month")
                            {
                                str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                                empty14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "daterange")
                            {
                                str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueFromdate.Text));
                                empty14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueTodate.Text));
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "lastweek")
                            {
                                str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                                empty14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "lastyear")
                            {
                                str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                                empty14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                            }
                            strArrays = new string[] { "and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str13, "' and '", empty14, "'" };
                            str14 = string.Concat(strArrays);
                        }
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            empty1 = (empty1 == "" ? string.Concat("(select count(*) from tb_estimate e where customerid=a.clientid AND e.AttentionID = b.contactId and isdeleted=0 and IsForInvoice=0 AND EstimateNumber NOT IN ('DirectJob', 'Direct Job', '0', 'DirectInvoice', 'Direct Invoice', '') and ISNULL(IsCompleted,0)=1 and IsNull(IsDirectJob,0)=0 ", str14, ") as TotalEstimate") : string.Concat(empty1, ",(select count(*) from tb_estimate e where customerid=a.clientid AND e.AttentionID = b.contactId and isdeleted=0 and IsForInvoice=0 AND EstimateNumber NOT IN ('DirectJob', 'Direct Job', '0', 'DirectInvoice', 'Direct Invoice', '') and ISNULL(IsCompleted,0)=1 and IsNull(IsDirectJob,0)=0 ", str14, ") as TotalEstimate"));
                        }
                        else
                        {
                            empty1 = (empty1 == "" ? string.Concat("(select count(*) from tb_estimate e where customerid=a.clientid and isdeleted=0 and IsForInvoice=0 AND EstimateNumber NOT IN ('DirectJob', 'Direct Job', '0', 'DirectInvoice', 'Direct Invoice', '') and ISNULL(IsCompleted,0)=1 and IsNull(IsDirectJob,0)=0 ", str14, ") as TotalEstimate") : string.Concat(empty1, ",(select count(*) from tb_estimate e where customerid=a.clientid and isdeleted=0 and IsForInvoice=0 AND EstimateNumber NOT IN ('DirectJob', 'Direct Job', '0', 'DirectInvoice', 'Direct Invoice', '') and ISNULL(IsCompleted,0)=1 and IsNull(IsDirectJob,0)=0 ", str14, ") as TotalEstimate"));
                        }
                    }
                    else if (this.chkAggCustomeritems.Items[m].Value == "EstimateValue")
                    {
                        string empty15 = string.Empty;
                        string str15 = string.Empty;
                        string empty16 = string.Empty;
                        if (this.chkestimatevaluerange.Checked)
                        {
                            if (this.ddlestimatevaluedaterange.SelectedValue == "current month")
                            {
                                empty15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                                str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "last month")
                            {
                                empty15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                                str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "daterange")
                            {
                                empty15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueFromdate.Text));
                                str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueTodate.Text));
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "lastweek")
                            {
                                empty15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                                str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                            }
                            else if (this.ddlestimatevaluedaterange.SelectedValue == "lastyear")
                            {
                                empty15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                                str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                            }
                            strArrays = new string[] { "and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", empty15, "' and '", str15, "'" };
                            empty16 = string.Concat(strArrays);
                        }
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            empty1 = (empty1 == "" ? string.Concat("(SELECT CAST(ISNULL(SUM(TotalSubTotal1), 0) AS DECIMAL(28, 10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (select isnull(EstimateID,0) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  AND IsCompleted=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','')", empty16, ") and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end) as EstValue") : string.Concat(empty1, ",(SELECT CAST(ISNULL(SUM(TotalSubTotal1), 0) AS DECIMAL(28, 10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) where EstimateID IN (select isnull(EstimateID,0) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  AND IsCompleted=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','')", empty16, ") and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end) as EstValue"));
                        }
                        else
                        {
                            empty1 = (empty1 == "" ? string.Concat("(SELECT CAST(ISNULL(SUM(TotalSubTotal1), 0) AS DECIMAL(28, 10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (select isnull(EstimateID,0) from tb_estimate where customerid=a.clientid and isdeleted=0 and  AND IsCompleted=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','')", empty16, ") and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end) as EstValue") : string.Concat(empty1, ",(SELECT CAST(ISNULL(SUM(TotalSubTotal1), 0) AS DECIMAL(28, 10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (select isnull(EstimateID,0) from tb_estimate where customerid=a.clientid and isdeleted=0  AND IsCompleted=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','')", empty16, ") and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end) as EstValue"));
                        }
                    }
                    else if (this.chkAggCustomeritems.Items[m].Value == "TotalJob")
                    {
                        string str16 = string.Empty;
                        string empty17 = string.Empty;
                        string str17 = string.Empty;
                        if (this.chkjobvaluerange.Checked)
                        {
                            if (this.ddljobvaluedaterange.SelectedValue == "current month")
                            {
                                str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                                empty17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "last month")
                            {
                                str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                                empty17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "daterange")
                            {
                                str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueFromdate.Text));
                                empty17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueTodate.Text));
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "lastweek")
                            {
                                str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                                empty17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "lastyear")
                            {
                                str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                                empty17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                            }
                            strArrays = new string[] { " and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str16, "' and '", empty17, "'" };
                            str17 = string.Concat(strArrays);
                        }
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            empty1 = (empty1 == "" ? string.Concat("(select count(*) from tb_estimate e left join tb_job j on j.EstimateID=e.EstimateID where customerid=a.clientid and e.IsDeleted=0 AND e.AttentionID = b.contactId and j.IsDeleted=0 and j.IsReverted=0 and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 ", str17, ") as TotalJob") : string.Concat(empty1, ",(select count(*) from tb_estimate e left join tb_job j on j.EstimateID=e.EstimateID where customerid=a.clientid AND e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0 and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 ", str17, ") as TotalJob"));
                        }
                        else
                        {
                            empty1 = (empty1 == "" ? string.Concat("(select count(*) from tb_estimate e left join tb_job j on j.EstimateID=e.EstimateID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0 and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 ", str17, ") as TotalJob") : string.Concat(empty1, ",(select count(*) from tb_estimate e left join tb_job j on j.EstimateID=e.EstimateID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0 and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0", str17, ") as TotalJob"));
                        }
                    }
                    else if (this.chkAggCustomeritems.Items[m].Value == "JobValue")
                    {
                        string empty18 = string.Empty;
                        string str18 = string.Empty;
                        string empty19 = string.Empty;
                        if (this.chkjobvaluerange.Checked)
                        {
                            if (this.ddljobvaluedaterange.SelectedValue == "current month")
                            {
                                empty18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                                str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "last month")
                            {
                                empty18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                                str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "daterange")
                            {
                                empty18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueFromdate.Text));
                                str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueTodate.Text));
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "lastweek")
                            {
                                empty18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                                str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                            }
                            else if (this.ddljobvaluedaterange.SelectedValue == "lastyear")
                            {
                                empty18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                                str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                            }
                            strArrays = new string[] { " and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", empty18, "' and '", str18, "'" };
                            string.Concat(strArrays);
                        }
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            empty1 = (empty1 == "" ? " (SELECT ISNULL((SELECT CAST(SUM(jobvalue) + MAX(OrderItemShipping) AS decimal(28, 3)) FROM (SELECT CASE WHEN jc.qtynumber = 1 THEN ISNULL(TotalSubTotal1, 0) WHEN jc.qtynumber = 2 THEN ISNULL(TotalSubTotal2, 0) WHEN jc.qtynumber = 3 THEN ISNULL(TotalSubTotal3, 0) WHEN jc.qtynumber = 4 THEN ISNULL(TotalSubTotal4, 0) ELSE ISNULL(TotalSubTotal1, 0) END AS jobvalue,et.OrderItemShipping FROM tb_job j LEFT JOIN tb_Estimate g ON g.EstimateID = j.EstimateID AND a.clientID = g.CustomerID AND  e.AttentionID = b.contactId LEFT JOIN tb_esttotalpricedetails et WITH (NOLOCK) ON g.EstimateID = et.EstimateID LEFT JOIN tb_jobcard jc WITH (NOLOCK) ON jc.estimateitemid = et.estimateitemid WHERE et.SectionID = CASE WHEN et.estimatetype IN ('b', 'k', 'n') THEN -999 ELSE 0 END AND EXISTS (SELECT ei.estimateitemid FROM tb_estimateitem ei WITH (NOLOCK) WHERE ei.JOBID = j.JobID AND et.estimateitemid = ei.estimateitemid AND ei.IsDeleted = 0 AND j.IsDeleted=0 AND j.Isreverted = 0 AND ISNULL(g.iscompleted, 0) = 1 AND (j.JobNumber != 'Direct Invoice' OR j.JobNumber != 'DirectInvoice') AND j.JobNumber NOT IN ('Direct Invoice', 'DirectInvoice') AND g.isforinvoice != 1)) vw), 0)) AS JobVal " : string.Concat(empty1, ", (SELECT ISNULL((SELECT CAST(SUM(jobvalue) + MAX(OrderItemShipping) AS decimal(28, 3)) FROM (SELECT CASE WHEN jc.qtynumber = 1 THEN ISNULL(TotalSubTotal1, 0) WHEN jc.qtynumber = 2 THEN ISNULL(TotalSubTotal2, 0) WHEN jc.qtynumber = 3 THEN ISNULL(TotalSubTotal3, 0) WHEN jc.qtynumber = 4 THEN ISNULL(TotalSubTotal4, 0) ELSE ISNULL(TotalSubTotal1, 0) END AS jobvalue,et.OrderItemShipping FROM tb_job j LEFT JOIN tb_Estimate g ON g.EstimateID = j.EstimateID AND a.clientID = g.CustomerID AND  g.AttentionID = b.contactId  LEFT JOIN tb_esttotalpricedetails et WITH (NOLOCK) ON g.EstimateID = et.EstimateID LEFT JOIN tb_jobcard jc WITH (NOLOCK) ON jc.estimateitemid = et.estimateitemid WHERE et.SectionID = CASE WHEN et.estimatetype IN ('b', 'k', 'n') THEN -999 ELSE 0 END AND EXISTS (SELECT ei.estimateitemid FROM tb_estimateitem ei WITH (NOLOCK) WHERE ei.JOBID = j.JobID AND et.estimateitemid = ei.estimateitemid AND ei.IsDeleted = 0 AND j.IsDeleted=0 AND j.Isreverted = 0 AND ISNULL(g.iscompleted, 0) = 1 AND (j.JobNumber != 'Direct Invoice' OR j.JobNumber != 'DirectInvoice') AND j.JobNumber NOT IN ('Direct Invoice', 'DirectInvoice') AND g.isforinvoice != 1)) vw), 0)) AS JobVal "));
                        }
                        else
                        {
                            empty1 = (empty1 == "" ? " (SELECT ISNULL((SELECT CAST(SUM(jobvalue) + MAX(OrderItemShipping) AS decimal(28, 3)) FROM (SELECT CASE WHEN jc.qtynumber = 1 THEN ISNULL(TotalSubTotal1, 0) WHEN jc.qtynumber = 2 THEN ISNULL(TotalSubTotal2, 0) WHEN jc.qtynumber = 3 THEN ISNULL(TotalSubTotal3, 0) WHEN jc.qtynumber = 4 THEN ISNULL(TotalSubTotal4, 0) ELSE ISNULL(TotalSubTotal1, 0) END AS jobvalue,et.OrderItemShipping FROM tb_job j LEFT JOIN tb_Estimate g ON g.EstimateID = j.EstimateID AND a.clientID = g.CustomerID LEFT JOIN tb_esttotalpricedetails et WITH (NOLOCK) ON g.EstimateID = et.EstimateID LEFT JOIN tb_jobcard jc WITH (NOLOCK) ON jc.estimateitemid = et.estimateitemid WHERE et.SectionID = CASE WHEN et.estimatetype IN ('b', 'k', 'n') THEN -999 ELSE 0 END AND EXISTS (SELECT ei.estimateitemid FROM tb_estimateitem ei WITH (NOLOCK) WHERE ei.JOBID = j.JobID AND et.estimateitemid = ei.estimateitemid AND ei.IsDeleted = 0 AND j.IsDeleted=0 AND j.Isreverted = 0 AND ISNULL(g.iscompleted, 0) = 1 AND (j.JobNumber != 'Direct Invoice' OR j.JobNumber != 'DirectInvoice') AND j.JobNumber NOT IN ('Direct Invoice', 'DirectInvoice') AND g.isforinvoice != 1)) vw), 0)) AS JobVal " : string.Concat(empty1, ", (SELECT ISNULL((SELECT CAST(SUM(jobvalue) + MAX(OrderItemShipping) AS decimal(28, 3)) FROM (SELECT CASE WHEN jc.qtynumber = 1 THEN ISNULL(TotalSubTotal1, 0) WHEN jc.qtynumber = 2 THEN ISNULL(TotalSubTotal2, 0) WHEN jc.qtynumber = 3 THEN ISNULL(TotalSubTotal3, 0) WHEN jc.qtynumber = 4 THEN ISNULL(TotalSubTotal4, 0) ELSE ISNULL(TotalSubTotal1, 0) END AS jobvalue,et.OrderItemShipping FROM tb_job j LEFT JOIN tb_Estimate g ON g.EstimateID = j.EstimateID AND a.clientID = g.CustomerID LEFT JOIN tb_esttotalpricedetails et WITH (NOLOCK) ON g.EstimateID = et.EstimateID LEFT JOIN tb_jobcard jc WITH (NOLOCK) ON jc.estimateitemid = et.estimateitemid WHERE et.SectionID = CASE WHEN et.estimatetype IN ('b', 'k', 'n') THEN -999 ELSE 0 END AND EXISTS (SELECT ei.estimateitemid FROM tb_estimateitem ei WITH (NOLOCK) WHERE ei.JOBID = j.JobID AND et.estimateitemid = ei.estimateitemid AND ei.IsDeleted = 0 AND j.IsDeleted=0 AND j.Isreverted = 0 AND ISNULL(g.iscompleted, 0) = 1 AND (j.JobNumber != 'Direct Invoice' OR j.JobNumber != 'DirectInvoice') AND j.JobNumber NOT IN ('Direct Invoice', 'DirectInvoice') AND g.isforinvoice != 1)) vw), 0)) AS JobVal "));
                        }
                    }
                    else if (this.chkAggCustomeritems.Items[m].Value == "TotalInvoice")
                    {
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            empty1 = (empty1 == "" ? " (select COUNT( a.InvoiceID) FROM tb_invoice a with (NOLOCK) LEFT JOIN tb_Estimate e ON a.EstimateID = e.EstimateID AND b.contactId = e.AttentionID WHERE b.ClientID = a.ClientID AND   b.contactId = a.contactId AND a.IsDeleted = 0 and a.InvoiceNumber!='0' AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = a.invoiceid and i2.isdeleted=0))  as TotalInvoice" : string.Concat(empty1, ", (select COUNT( a.InvoiceID) FROM tb_invoice a with (NOLOCK) LEFT JOIN tb_Estimate e ON a.EstimateID = e.EstimateID AND b.contactId = e.AttentionID WHERE b.ClientID = a.ClientID AND   b.contactId = a.contactId AND a.IsDeleted = 0 and a.InvoiceNumber!='0' AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = a.invoiceid and i2.isdeleted=0))  as TotalInvoice"));
                        }
                        else
                        {
                            empty1 = (empty1 == "" ? "  (SELECT  COUNT(inv.InvoiceID) FROM tb_invoice inv WITH (NOLOCK) where a.ClientID = inv.ClientID and  inv.IsDeleted = 0 AND inv.InvoiceNumber != '0' AND EXISTS (SELECT i2.invoiceid FROM tb_estimateitem i2 WITH (NOLOCK) WHERE i2.invoiceid = inv.invoiceid AND i2.isdeleted = 0))   as TotalInvoice" : string.Concat(empty1, ", (SELECT  COUNT(inv.InvoiceID) FROM tb_invoice inv WITH (NOLOCK) where a.ClientID = inv.ClientID and inv.IsDeleted = 0 AND inv.InvoiceNumber != '0' AND EXISTS (SELECT i2.invoiceid FROM tb_estimateitem i2 WITH (NOLOCK) WHERE i2.invoiceid = inv.invoiceid AND i2.isdeleted = 0))   as TotalInvoice"));
                        }
                    }
                    else if (this.chkAggCustomeritems.Items[m].Value == "InvoiceValue")
                    {
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            empty1 = (empty1 == "" ? string.Concat(empty1, ",(SELECT  ISNULL(SUM(CASE when jc.qtynumber=1 then  isnull(TotalSubTotal1,0)+OrderItemShipping when jc.qtynumber=2 THEN isnull(TotalSubTotal2,0)+OrderItemShipping when jc.qtynumber=3 then isnull(TotalSubTotal3,0)+OrderItemShipping when jc.qtynumber=4 then isnull(TotalSubTotal4,0)+OrderItemShipping ELSE isnull(TotalSubTotal1,0)+ OrderItemShipping end),0) FROM tb_invoice inv with (NOLOCK) LEFT JOIN tb_EstimateItem i ON i.InvoiceID = inv.InvoiceID AND i.IsDeleted = 0 LEFT JOIN tb_contact c ON  c.contactID = inv.contactID LEFT JOIN tb_esttotalpricedetails et ON et.EstimateitemID = i.EstimateitemID LEFT JOIN tb_jobcard jc with (nolock) on jc.estimateitemid=et.estimateitemid where sectionid= case when et.estimatetype IN ('b','k','n') then -999 else 0 end AND EXISTS (select ei.estimateitemid from tb_estimateitem ei with (nolock) where ei.invoiceid=inv.invoiceid AND inv.clientID = a.clientID AND et.estimateitemid = ei.estimateitemid and inv.contactID = b.contactID and ei.IsDeleted=0) AND inv.IsDeleted = 0 and inv.InvoiceNumber!='0' AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = inv.invoiceid and i2.isdeleted=0)) AS InvoiceValue") : string.Concat(empty1, ",(SELECT  ISNULL(SUM(CASE when jc.qtynumber=1 then  isnull(TotalSubTotal1,0)+OrderItemShipping when jc.qtynumber=2 THEN isnull(TotalSubTotal2,0)+OrderItemShipping when jc.qtynumber=3 then isnull(TotalSubTotal3,0)+OrderItemShipping when jc.qtynumber=4 then isnull(TotalSubTotal4,0)+OrderItemShipping ELSE isnull(TotalSubTotal1,0)+ OrderItemShipping end),0) FROM tb_invoice inv with (NOLOCK) LEFT JOIN tb_EstimateItem i ON i.InvoiceID = inv.InvoiceID AND i.IsDeleted = 0 LEFT JOIN tb_contact c ON  c.contactID = inv.contactID LEFT JOIN tb_esttotalpricedetails et ON et.EstimateitemID = i.EstimateitemID LEFT JOIN tb_jobcard jc with (nolock) on jc.estimateitemid=et.estimateitemid where sectionid= case when et.estimatetype IN ('b','k','n') then -999 else 0 end AND EXISTS (select ei.estimateitemid from tb_estimateitem ei with (nolock) where ei.invoiceid=inv.invoiceid AND inv.clientID = a.clientID AND et.estimateitemid = ei.estimateitemid and inv.contactID = b.contactID and ei.IsDeleted=0) AND inv.IsDeleted = 0 and inv.InvoiceNumber!='0' AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = inv.invoiceid and i2.isdeleted=0)) AS InvoiceValue"));
                        }
                        else
                        {
                            empty1 = (empty1 == "" ? string.Concat(empty1, ",(SELECT  ISNULL(SUM(CASE when jc.qtynumber=1 then  isnull(TotalSubTotal1,0)+OrderItemShipping when jc.qtynumber=2 THEN isnull(TotalSubTotal2,0)+OrderItemShipping when jc.qtynumber=3 then isnull(TotalSubTotal3,0)+OrderItemShipping when jc.qtynumber=4 then isnull(TotalSubTotal4,0)+OrderItemShipping ELSE isnull(TotalSubTotal1,0)+ OrderItemShipping end),0) FROM tb_invoice inv with (NOLOCK) LEFT JOIN tb_EstimateItem i ON i.InvoiceID = inv.InvoiceID AND i.IsDeleted = 0 LEFT JOIN tb_contact c ON  c.contactID = inv.contactID LEFT JOIN tb_esttotalpricedetails et ON et.EstimateitemID = i.EstimateitemID LEFT JOIN tb_jobcard jc with (nolock) on jc.estimateitemid=et.estimateitemid where sectionid= case when et.estimatetype IN ('b','k','n') then -999 else 0 end AND EXISTS (select ei.estimateitemid from tb_estimateitem ei with (nolock) where ei.invoiceid=inv.invoiceid AND inv.clientID = a.clientID AND et.estimateitemid = ei.estimateitemid and ei.IsDeleted=0) AND inv.IsDeleted = 0 and inv.InvoiceNumber!='0' AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = inv.invoiceid and i2.isdeleted=0)) AS InvoiceValue") : string.Concat(empty1, ",(SELECT  ISNULL(SUM(CASE when jc.qtynumber=1 then  isnull(TotalSubTotal1,0)+OrderItemShipping when jc.qtynumber=2 THEN isnull(TotalSubTotal2,0)+OrderItemShipping when jc.qtynumber=3 then isnull(TotalSubTotal3,0)+OrderItemShipping when jc.qtynumber=4 then isnull(TotalSubTotal4,0)+OrderItemShipping ELSE isnull(TotalSubTotal1,0)+ OrderItemShipping end),0) FROM tb_invoice inv with (NOLOCK) LEFT JOIN tb_EstimateItem i ON i.InvoiceID = inv.InvoiceID AND i.IsDeleted = 0 LEFT JOIN tb_contact c ON  c.contactID = inv.contactID LEFT JOIN tb_esttotalpricedetails et ON et.EstimateitemID = i.EstimateitemID LEFT JOIN tb_jobcard jc with (nolock) on jc.estimateitemid=et.estimateitemid where sectionid= case when et.estimatetype IN ('b','k','n') then -999 else 0 end AND EXISTS (select ei.estimateitemid from tb_estimateitem ei with (nolock) where ei.invoiceid=inv.invoiceid AND inv.clientID = a.clientID AND et.estimateitemid = ei.estimateitemid and ei.IsDeleted=0) AND inv.IsDeleted = 0 and inv.InvoiceNumber!='0' AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = inv.invoiceid and i2.isdeleted=0)) AS InvoiceValue"));
                        }
                    }
                    else if (this.chkAggCustomeritems.Items[m].Value != "EstimateJobconversioncount")
                    {
                        if (this.chkAggCustomeritems.Items[m].Value == "EstimateJobconversionvalue")
                        {
                            if (this.contactlstcount <= 0 && this.Departmentlstcount <= 0)
                            {
                                if (empty1 == "")
                                {
                                    companyID = new object[] { " (SELECT (CAST(ISNULL(SUM(est.EstimateSubTotal),0) AS decimal(18, 2)) / ((SELECT ISNULL(NULLIF(sum(e.EstimateSubTotal), 0), 1) FROM tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID AND e.IsDeleted = 0 AND e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND e.CompanyID = ", this.CompanyID, ") )) * 100 AS EstimateJobconversionrate FROM tb_job jb LEFT JOIN tb_Estimate est ON jb.EstimateID = est.EstimateID WHERE est.IsDeleted = 0 AND est.CustomerID = a.clientID AND est.IsDeleted = 0 AND est.IsFromWebStore != 'yes' AND est.estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND est.CompanyID = ", this.CompanyID, ") as  EstimateJobconversionvalue " };
                                    empty1 = string.Concat(companyID);
                                }
                                else
                                {
                                    companyID = new object[] { empty1, ", (SELECT (CAST(ISNULL(SUM(est.EstimateSubTotal),0) AS decimal(18, 2)) / ((SELECT ISNULL(NULLIF(sum(e.EstimateSubTotal), 0), 1) FROM tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID AND e.IsDeleted = 0 AND e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND e.CompanyID = ", this.CompanyID, ") )) * 100 AS EstimateJobconversionrate FROM tb_job jb LEFT JOIN tb_Estimate est ON jb.EstimateID = est.EstimateID WHERE est.IsDeleted = 0 AND est.CustomerID = a.clientID AND est.IsDeleted = 0 AND est.IsFromWebStore != 'yes' AND est.estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND est.CompanyID = ", this.CompanyID, ") as  EstimateJobconversionvalue " };
                                    empty1 = string.Concat(companyID);
                                }
                            }
                            else if (empty1 == "")
                            {
                                companyID = new object[] { " (SELECT (CAST(ISNULL(SUM(est.EstimateSubTotal),0) AS decimal(18, 2)) / ((SELECT ISNULL(NULLIF(sum(e.EstimateSubTotal), 0), 1) FROM tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID AND e.attentionID = b.contactID AND e.IsDeleted = 0 AND e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND e.CompanyID = ", this.CompanyID, ") )) * 100 AS EstimateJobconversionrate FROM tb_job jb LEFT JOIN tb_Estimate est ON jb.EstimateID = est.EstimateID WHERE est.IsDeleted = 0 AND est.CustomerID = a.clientID AND est.attentionID = b.contactID AND est.IsDeleted = 0 AND est.IsFromWebStore != 'yes' AND est.estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND est.CompanyID = ", this.CompanyID, ") as  EstimateJobconversionvalue " };
                                empty1 = string.Concat(companyID);
                            }
                            else
                            {
                                companyID = new object[] { empty1, ", (SELECT (CAST(ISNULL(SUM(est.EstimateSubTotal),0) AS decimal(18, 2)) / ((SELECT ISNULL(NULLIF(sum(e.EstimateSubTotal), 0), 1) FROM tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID AND e.attentionID = b.contactID AND e.IsDeleted = 0 AND e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND e.CompanyID = ", this.CompanyID, ") )) * 100 AS EstimateJobconversionrate FROM tb_job jb LEFT JOIN tb_Estimate est ON jb.EstimateID = est.EstimateID WHERE est.IsDeleted = 0 AND est.CustomerID = a.clientID AND est.attentionID = b.contactID AND est.IsDeleted = 0 AND est.IsFromWebStore != 'yes' AND est.estimatenumber NOT IN ('Direct Invoice', 'DirectInvoice', 'Direct Job', 'DirectJob') AND est.CompanyID = ", this.CompanyID, ") as  EstimateJobconversionvalue " };
                                empty1 = string.Concat(companyID);
                            }
                        }
                    }
                    else if (this.contactlstcount <= 0 && this.Departmentlstcount <= 0)
                    {
                        if (empty1 == "")
                        {
                            companyID = new object[] { "(SELECT (CAST(COUNT(Jobid)AS DECIMAL(18,2))/ (( SELECT  ISNULL(NULLIF(COUNT(EstimateID),0),1) from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID  AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice' , 'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, " )))*100  AS ConvertCount from tb_job WHERE IsDeleted=0 and EstimateID IN ( SELECT EstimateID from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND e.estimatenumber NOT IN ('Direct Invoice' ,'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, ")) as  EstimateJobconversioncount " };
                            empty1 = string.Concat(companyID);
                        }
                        else
                        {
                            companyID = new object[] { empty1, ",(SELECT (CAST(COUNT(Jobid)AS DECIMAL(18,2))/ (( SELECT  ISNULL(NULLIF(COUNT(EstimateID),0),1) from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice' , 'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, " )))*100  AS ConvertCount from tb_job WHERE IsDeleted=0 and EstimateID IN ( SELECT EstimateID from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID  AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND e.estimatenumber NOT IN ('Direct Invoice' ,'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, ")) as  EstimateJobconversioncount " };
                            empty1 = string.Concat(companyID);
                        }
                    }
                    else if (empty1 == "")
                    {
                        companyID = new object[] { "(SELECT (CAST(COUNT(Jobid)AS DECIMAL(18,2))/ (( SELECT  ISNULL(NULLIF(COUNT(EstimateID),0),1) from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID  AND e.attentionID = b.contactID AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice' , 'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, " )))*100  AS ConvertCount from tb_job WHERE IsDeleted=0 and EstimateID IN ( SELECT EstimateID from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID  AND e.attentionID = b.contactID AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND e.estimatenumber NOT IN ('Direct Invoice' ,'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, ")) as  EstimateJobconversioncount " };
                        empty1 = string.Concat(companyID);
                    }
                    else
                    {
                        companyID = new object[] { empty1, ", (SELECT (CAST(COUNT(Jobid)AS DECIMAL(18,2))/ (( SELECT  ISNULL(NULLIF(COUNT(EstimateID),0),1) from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID  AND e.attentionID = b.contactID AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND Estimatenumber NOT IN ('Direct Invoice' , 'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, " )))*100  AS ConvertCount from tb_job WHERE IsDeleted=0 and EstimateID IN ( SELECT EstimateID from tb_Estimate e WITH (NOLOCK) WHERE e.CustomerID = a.clientID  AND e.attentionID = b.contactID AND e.IsDeleted=0 and e.IsFromWebStore != 'yes' AND e.estimatenumber NOT IN ('Direct Invoice' ,'DirectInvoice','Direct Job','DirectJob') AND e.CompanyID =", this.CompanyID, ")) as  EstimateJobconversioncount " };
                        empty1 = string.Concat(companyID);
                    }
                }
            }
            if (this.chk_contactsList.Items[0].Selected || this.chk_contactsList.Items[1].Selected || this.chk_contactsList.Items[2].Selected || this.chk_contactsList.Items[3].Selected || this.chk_contactsList.Items[4].Selected || this.chk_contactsList.Items[5].Selected || this.chk_contactsList.Items[6].Selected || this.chk_contactsList.Items[7].Selected || this.chk_contactsList.Items[8].Selected || this.chk_contactsList.Items[9].Selected || this.chk_contactsList.Items[10].Selected || this.chk_contactsList.Items[11].Selected || this.chk_contactsList.Items[12].Selected || this.chk_contactsList.Items[13].Selected || this.chk_contactsList.Items[14].Selected || this.chk_contactsList.Items[15].Selected || this.chk_contactsList.Items[16].Selected || this.chk_contactsList.Items[17].Selected)
            {
                empty1 = string.Concat(empty1, ",ISNULL(b.contactID, 0) AS contactID ");               
            }

            // filter report record
            viewClass _viewClass = new viewClass();
            if (this.pagename == "client")
            {
                string page = "client";
                str4 = _viewClass.showRecords_BaseOn_RolesAndPrivileges(page);
            }

            str1 = "from tb_Client a ";
            str1 = string.Concat(" ", str1, "left join tb_ClientReferencedBy z on z.ReferencedID = a.referencedBy ");
            str1 = string.Concat(" ", str1, " left join tb_user u on u.userID=a.SalesPerson and u.isdelete=0  ");
            // eStoreName added
            str1 = string.Concat(" ", str1, " LEFT JOIN tb_Accounts ac ON ac.accountID = a.AccountID AND ac.isDeleted = 0 AND ac.CompanyID = a.companyID  ");
            if (this.Chk_addressList.Items[0].Selected || this.Chk_addressList.Items[1].Selected || this.Chk_addressList.Items[2].Selected || this.Chk_addressList.Items[3].Selected || this.Chk_addressList.Items[4].Selected || this.Chk_addressList.Items[5].Selected || this.Chk_addressList.Items[6].Selected || this.Chk_addressList.Items[7].Selected || this.Chk_addressList.Items[8].Selected || this.Chk_addressList.Items[9].Selected)
            {
                str1 = string.Concat(" ", str1, "left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete=0 ");
            }
            if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
            {
                str1 = string.Concat(" ", str1, "left join tb_department d on d.Customerid=a.clientid and d.isdeleted=0  ");
               // str1 = string.Concat(" ", str1, "left join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0  ");
                
                // if show main contact checked --// added by shehzad
                if (chkShowMainContact.Checked)
                {
                    str1 = string.Concat(" ", str1, "inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and b.DefaultContact = 1 and isnull(b.contactID ,0) != 0  ");
                }
                else
                {
                    str1 = string.Concat(" ", str1, "inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0  ");
                }
                str1 = string.Concat(" ", str1, "left join tb_CostCenter cct on d.CostCentreID=cct.CostCentreID ");
                if (this.Chk_DepartmentList.Items[1].Selected || this.Chk_DepartmentList.Items[2].Selected)
                {
                    str1 = string.Concat(" ", str1, " left join tb_companyAddress ad on ad.Addressid=d.AddressID and ad.isdelete=0  ");
                    str1 = string.Concat(" ", str1, "left join tb_companyAddress a1 on a1.Addressid=d.DeliveryAddressID and a1.isdelete=0  ");
                }
            }
            else if (this.chkContactDateOption.Checked)
            {
                //str1 = string.Concat(" ", str1, "left join tb_contact b on b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0  ");

                // if show main contact checked --// added by shehzad
                if (chkShowMainContact.Checked)
                {
                    str1 = string.Concat(" ", str1, "left join tb_contact b on b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and b.DefaultContact = 1  ");
                }
                else
                {
                    str1 = string.Concat(" ", str1, "left join tb_contact b on b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0  ");
                }
                
            }
            if (this.ddlIndividual.SelectedValue == "IndividualColumn")
            {
                if (this.chk_contactsList.Items[13].Selected)
                {
                    str1 = string.Concat(" ", str1, "left join tb_companyaddress c1 on c1.addressid=b.contactaddressid and c1.isDelete=0 ");
                }
                if (this.chk_contactsList.Items[14].Selected)
                {
                    str1 = string.Concat(" ", str1, "left join tb_companyaddress c2 on c2.addressid=d.deliveryaddressid and c2.isDelete=0 ");
                }
                if (this.chk_contactsList.Items[15].Selected)
                {
                    str1 = string.Concat(" ", str1, "left join tb_companyaddress c3 on c3.addressid=d.addressid and c3.isDelete=0 ");
                }
            }
            //companyID = new object[] { " ", str1, " where a.companyid=", this.CompanyID, " and a.IsDelete=0 " };
            companyID = new object[] { " ", str1, " where " + str4 +  "a.companyid=", this.CompanyID, " and a.IsDelete=0 " };
            str1 = string.Concat(companyID);
            string str19 = string.Empty;
            string empty20 = string.Empty;
            string str20 = string.Empty;
            string empty21 = string.Empty;
            if (this.chkest.Checked || this.chkest1.Checked)
            {
                str19 = " from tb_Client a left join tb_Estimate e on e.CustomerID=a.ClientID  ";
                companyID = new object[] { " ", str19, " where a.companyid=", this.CompanyID, " and a.isDelete=0 and e.IsDeleted=0 and e.IsForInvoice=0 and e.IsForInvoice=0 and IsNull(e.IsCompleted,0)=1 and IsNull(e.IsDirectJob,0)=0 and e.IsFromWebStore!='yes' and estimatenumber not in ('Direct Invoice' , 'DirectInvoice','Direct Job','DirectJob') " };
                str19 = string.Concat(companyID);
            }
            if (this.chkjob.Checked || this.chkjob1.Checked)
            {
                empty20 = " from tb_Client a left join tb_Estimate e on e.CustomerID=a.ClientID  left join tb_job j on j.EstimateID=e.EstimateID ";
                empty20 = string.Concat(" ", empty20, "left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsParentItem=1 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateID =e.estimateid and tp.EstimateitemID = i.EstimateitemID and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end ");
                companyID = new object[] { " ", empty20, " where a.companyid=", this.CompanyID, " and a.isDelete=0 and j.IsDeleted=0 and e.IsDeleted=0 and j.IsReverted=0 and e.IsForInvoice=0 and IsNull(e.IsCompleted,0)=1 " };
                empty20 = string.Concat(companyID);
            }
            if (this.chkinv.Checked || this.chkinv1.Checked)
            {
                str20 = " from tb_Client a left join tb_Estimate e on e.CustomerID=a.ClientID left join tb_Invoice i on e.EstimateID=i.EstimateID ";
                str20 = string.Concat(" ", str20, "left join tb_EstimateItem ei on ei.InvoiceID=i.InvoiceID  and ei.IsParentItem=1 left join tb_jobcard jc on jc.EstimateItemID=ei.EstimateItemID  ");
                str20 = string.Concat(" ", str20, " left join tb_EstTotalPriceDetails tp  on tp.EstimateID =e.estimateid and tp.EstimateitemID = ei.EstimateitemID and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end  ");
                companyID = new object[] { " ", str20, " where a.companyid=", this.CompanyID, " and a.isDelete=0 and i.IsDeleted=0 and e.IsDeleted=0 and IsNull(e.IsCompleted,0)=1 AND EXISTS (select i2.invoiceid from tb_estimateitem i2 with (NOLOCK) where i2.invoiceid = i.invoiceid and i2.isdeleted=0)  " };
                str20 = string.Concat(companyID);
            }
            if (this.chkpo.Checked || this.chkpo1.Checked)
            {
                empty21 = "  from tb_purchaseitem pri left join  tb_purchase p on pri.purchaseid=p.purchaseid  left join tb_Client a on a.clientid=p.SupplierID  ";
                companyID = new object[] { " ", empty21, " where p.IsDeleted=0 and a.CompanyID=", this.CompanyID, " and a.isDelete=0 " };
                empty21 = string.Concat(companyID);
            }
            if (this.txtFreetext.Text != "")
            {
                str1 = string.Concat(str1, " and (", empty10, ")");
                base.SpecialEncode(this.txtFreetext.Text);
            }
            if (this.ddlCompanyType.SelectedValue == "Customer")
            {
                str1 = string.Concat(str1, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                empty21 = string.Concat(empty21, "and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                string selectedValue = this.ddlCompanyType.SelectedValue;
            }
            else if (this.ddlCompanyType.SelectedValue == "Supplier")
            {
                str1 = string.Concat(str1, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                str19 = string.Concat(str19, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                empty20 = string.Concat(empty20, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                str20 = string.Concat(str20, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                empty21 = string.Concat(empty21, "and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                string selectedValue1 = this.ddlCompanyType.SelectedValue;
            }
            else if (this.ddlCompanyType.SelectedValue != "Prospect")
            {
                str1 = string.Concat(str1, " ");
                str19 = string.Concat(str19, " ");
                empty20 = string.Concat(empty20, " ");
                str20 = string.Concat(str20, " ");
                empty21 = string.Concat(empty21, " ");
            }
            else
            {
                str1 = string.Concat(str1, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                str19 = string.Concat(str19, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                empty20 = string.Concat(empty20, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                str20 = string.Concat(str20, " and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                empty21 = string.Concat(empty21, "and a.Companytype='", base.ReplaceSingleQuote(this.ddlCompanyType.SelectedValue), "'");
                string selectedValue2 = this.ddlCompanyType.SelectedValue;
            }
            if (this.lstCustomerType.SelectedIndex != 0)
            {
                string str21 = string.Empty;
                string empty22 = string.Empty;
                int num = 0;
                for (int n = 0; n < this.lstCustomerType.Items.Count; n++)
                {
                    if (this.lstCustomerType.Items[n].Checked)
                    {
                        num++;
                        if (num != 1)
                        {
                            str21 = string.Concat(str21, ",", this.lstCustomerType.Items[n].Value);
                            empty22 = string.Concat(empty22, ",", this.lstCustomerType.Items[n].Text);
                        }
                        else
                        {
                            str21 = string.Concat(str21, this.lstCustomerType.Items[n].Value);
                            empty22 = string.Concat(empty22, this.lstCustomerType.Items[n].Text);
                        }
                    }
                }
                chrArray = new char[] { ',' };
                string[] strArrays2 = str21.Split(chrArray);
                if (num == 1)
                {
                    str1 = string.Concat(str1, "and a.ClientTypeID like '%", strArrays2[0], "%'");
                    empty22.ToString();
                }
                if (num > 1)
                {
                    str1 = string.Concat(str1, " And ( ");//kr 06-10-2017
                    for (int o = 0; o <= (int)strArrays2.Length - 1; o++)
                    {
                        str1 = string.Concat(str1, "  a.ClientTypeID like '%", strArrays2[o], "%'");
                        if (o != (int)strArrays2.Length - 1)
                        {
                            str1 = string.Concat(str1, " OR ");
                        }
                        empty22.ToString();
                    }
                    str1 = str1 + " ) ";//kr 06-10-2017
                }
            }
            if (this.chkDateOption.Checked)
            {
                if (this.rdlDate.SelectedValue == "daily")
                {
                    string str22 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    str1 = string.Concat(str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) = '", str22, "' ");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    string str23 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    str1 = string.Concat(str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) = '", str23, "' ");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    string str24 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str25 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str24, "' and '", str25, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    string str26 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str27 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str26, "' and '", str27, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    string startDate = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat.Replace("mm", "MM")));
                    string endDate = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm", "MM")));
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", startDate, "' and '", endDate, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    string str28 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str29 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str28, "' and '", str29, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    string str30 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.startyear[0].ToString());
                    string str31 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endyear[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str30, "' and '", str31, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    string str32 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                    string str33 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str32, "' and '", str33, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    string str32 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str33 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str32, "' and '", str33, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    string str32 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                    string str33 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str32, "' and '", str33, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    string str32 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str33 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,a.[A/cOpened])) between '", str32, "' and '", str33, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    commonClass _commonClass = this.objJava;
                    now = DateTime.Now;
                    string str34 = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    chrArray = new char[] { ' ' };
                    string[] strArrays3 = str34.Split(chrArray);
                    str1 = string.Concat(str1, " and (DateAdd(d,0,DateDiff(d,0,a.[A/cOpened])) <= '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays3[0].ToString()), "' ");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    string str35 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtFrom.Text));
                    string str36 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtTo.Text));
                    strArrays = new string[] { str1, " and (DateAdd(d,0,DateDiff(d,0,a.[A/cOpened])) BETWEEN '", str35, "' AND '", str36, "' " };
                    str1 = string.Concat(strArrays);
                }
            }
            if (this.chkContactDateOption.Checked)
            {
                if (this.ddlContactDateOption.SelectedValue == "daily")
                {
                    string str37 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    str1 = (!this.chkDateOption.Checked ? string.Concat(str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) = '", str37, "' ") : string.Concat(str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) = '", str37, "') "));
                }
                else if (this.ddlContactDateOption.SelectedValue == "yesterday")
                {
                    string str38 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    str1 = (!this.chkDateOption.Checked ? string.Concat(str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) = '", str38, "' ") : string.Concat(str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) = '", str38, "') "));
                }
                else if (this.ddlContactDateOption.SelectedValue == "thismonth")
                {
                    string str39 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str40 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str39, "' and '", str40, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str39, "' and '", str40, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlContactDateOption.SelectedValue == "thisquarter")
                {
                    string str41 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str42 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str41, "' and '", str42, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str41, "' and '", str42, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                // Current Year filter added
                else if (this.ddlContactDateOption.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    string startDate = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat));
                    string endDate = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm", "MM")));
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", startDate, "' and '", endDate, "' " };
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", startDate, "' and '", endDate, "' " };
                    }
                    str1 = string.Concat(strArrays);
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastquater")
                {
                    string str43 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str44 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str43, "' and '", str44, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str43, "' and '", str44, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlContactDateOption.SelectedValue == "thisyear")
                {
                    string str45 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.startyear[0].ToString());
                    string str46 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endyear[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str45, "' and '", str46, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str45, "' and '", str46, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlContactDateOption.SelectedValue == "halfyear")
                {
                    string str47 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                    string str48 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastweek")
                {
                    string str47 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str48 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastmonth")
                {
                    string str47 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                    string str48 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastyear")
                {
                    string str47 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str48 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateADD(d,0,DateDiff(d,0,b.CreateDate)) between '", str47, "' and '", str48, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }


                else if (this.ddlContactDateOption.SelectedValue == "tilldate")
                {
                    commonClass _commonClass1 = this.objJava;
                    now = DateTime.Now;
                    string str49 = _commonClass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    chrArray = new char[] { ' ' };
                    string[] strArrays4 = str49.Split(chrArray);
                    str1 = (!this.chkDateOption.Checked ? string.Concat(str1, " and (DateAdd(d,0,DateDiff(d,0,b.CreateDate)) <= '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays4[0].ToString()), "' ") : string.Concat(str1, " or DateAdd(d,0,DateDiff(d,0,b.CreateDate)) <= '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays4[0].ToString()), "') "));
                }
                else if (this.ddlContactDateOption.SelectedValue == "daterange")
                {
                    string str50 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtfromdate_converted.Text));
                    string str51 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txttodate_converted.Text));
                    if (!this.chkDateOption.Checked)
                    {
                        strArrays = new string[] { str1, " and (DateAdd(d,0,DateDiff(d,0,b.CreateDate)) BETWEEN '", str50, "' AND '", str51, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " or DateAdd(d,0,DateDiff(d,0,b.CreateDate)) BETWEEN '", str50, "' AND '", str51, "') " };
                        str1 = string.Concat(strArrays);
                    }
                }
            }
            if (this.chkDateOption.Checked && !this.chkContactDateOption.Checked || this.chkContactDateOption.Checked && !this.chkDateOption.Checked)
            {
                str1 = string.Concat(str1, ")");
            }
            if (this.chkNoActivityinPast.Checked)
            {
                if (this.ddl_NoActivityinPast.SelectedValue == "30")
                {
                    string str52 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.past30days[0].ToString());
                    string str53 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str52, "'and'", str53, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str53, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str52, "'and'", str53, "' ) AND a.createDate <='", str53, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str52, "'and'", str53, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str53, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str52, "'and'", str53, "' ) AND a.createDate <='", str53, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "60")
                {
                    string str54 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.past60days[0].ToString());
                    string str55 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str54, "'and'", str55, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str55, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str54, "'and'", str55, "' ) AND a.createDate <='", str55, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str54, "'and'", str55, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str55, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str54, "'and'", str55, "' ) AND a.createDate <='", str55, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "45")
                {
                    string str56 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.past45days[0].ToString());
                    string str57 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str56, "'and'", str57, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str57, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str56, "'and'", str57, "' ) AND a.createDate <='", str57, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str56, "'and'", str57, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str57, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str56, "'and'", str57, "' ) AND a.createDate <='", str57, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "90")
                {
                    string str58 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.past90days[0].ToString());
                    string str59 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str58, "'and'", str59, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str59, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str58, "'and'", str59, "' ) AND a.createDate <='", str59, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str58, "'and'", str59, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str59, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str58, "'and'", str59, "' ) AND a.createDate <='", str59, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "120")
                {
                    string str60 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.past120days[0].ToString());
                    string str61 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str60, "'and'", str61, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str61, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str60, "'and'", str61, "' ) AND a.createDate <='", str61, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str60, "'and'", str61, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str61, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str60, "'and'", str61, "' ) AND a.createDate <='", str61, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "365")
                {
                    string str62 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.past365days[0].ToString());
                    string str63 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str62, "'and'", str63, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str63, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str62, "'and'", str63, "' ) AND a.createDate <='", str63, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str62, "'and'", str63, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str63, "' " };
                        str1 = string.Concat(strArrays);
                    }
                    if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e INNER JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str62, "'and'", str63, "' ) AND a.createDate <='", str63, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "daterange")
                {
                    string str64 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtNoActivityinPastFromdate.Text));
                    string str65 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtNoActivityinPastTodate.Text));
                    if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str64, "'and'", str65, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str65, "' " };
                        str1 = string.Concat(strArrays);
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str64, "'and'", str65, "' ) AND a.createDate <='", str65, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    else if (this.chk_Estimate.Checked)
                    {
                        strArrays = new string[] { str1, "and a.clientID NOT IN (select e.CustomerID FROM tb_estimate e where DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str64, "'and'", str65, "' and e.CustomerID=a.ClientID AND e.IsCompleted=1 AND e.EstimateNumber not in ('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') AND e.IsFromWebStore='no') AND a.createDate <='", str65, "'" };
                        str1 = string.Concat(strArrays);
                    }
                    if (this.chk_Job.Checked)
                    {
                        strArrays = new string[] { str1, " and a.clientID NOT IN (SELECT e.CustomerID FROM tb_Estimate e LEFT JOIN tb_Job j ON j.EstimateID = e.EstimateID AND e.IsDeleted = 0 AND j.IsDeleted = 0 and e.EstimateNumber not in ('Direct Invoice','DirectInvoice' ) where  DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str64, "'and'", str65, "') AND a.createDate <='", str65, "'" };
                        str1 = string.Concat(strArrays);
                    }
                }
            }
            if (this.chkestimatevaluerange.Checked)
            {
                if (this.ddlestimatevaluedaterange.SelectedValue == "current month")
                {
                    string str66 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str67 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and e.AttentionID=b.ContactID  and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str66, "' and '", str67, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str66, "' and '", str67, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlestimatevaluedaterange.SelectedValue == "last month")
                {
                    string str68 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                    string str69 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and e.AttentionID=b.ContactID  and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str68, "' and '", str69, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str68, "' and '", str69, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlestimatevaluedaterange.SelectedValue == "daterange")
                {
                    string str70 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueFromdate.Text));
                    string str71 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueTodate.Text));
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and e.AttentionID=b.ContactID  and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str70, "' and '", str71, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str70, "' and '", str71, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlestimatevaluedaterange.SelectedValue == "lastweek")
                {
                    string str68 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str69 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and e.AttentionID=b.ContactID  and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str68, "' and '", str69, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str68, "' and '", str69, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddlestimatevaluedaterange.SelectedValue == "lastyear")
                {
                    string str68 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str69 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and e.AttentionID=b.ContactID  and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str68, "' and '", str69, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, "and round((select cast(isnull(sum(TotalSubTotal1),0) as decimal(28,10)) FROM tb_EstTotalPriceDetails WHERE EstimateItemID IN (SELECT EstimateItemID from tb_estimateitem with (NOLOCK) WHERE EstimateID IN (SELECT e.EstimateID from tb_estimate e where e.customerid=a.clientid and e.isdeleted=0 and ISNULL(e.IsCompleted,0)=1 and e.EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,e.CreatedDate)) between '", str68, "' and '", str69, "') and isdeleted=0  AND IsParentItem=1)and sectionid= case when estimatetype in ('B','K','N') then -999 else 0 end),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0))" };
                        str1 = string.Concat(strArrays);
                    }
                }
                if (this.ddlestimatevaluerange.SelectedValue == "greater than")
                {
                    str1 = string.Concat(str1, "> CAST('", this.txtestimatevaluerange.Text, "' AS DECIMAL(28,10))");
                }
                else if (this.ddlestimatevaluerange.SelectedValue == "less than")
                {
                    str1 = string.Concat(str1, "< CAST('", this.txtestimatevaluerange.Text, "' AS DECIMAL(28,10))");
                    if (this.ddlestimatevaluedaterange.SelectedValue == "current month")
                    {
                        string str72 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                        string str73 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0 )as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str72, "' and '", str73, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0 )as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str72, "' and '", str73, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddlestimatevaluedaterange.SelectedValue == "last month")
                    {
                        string str74 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                        string str75 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str74, "' and '", str75, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str74, "' and '", str75, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddlestimatevaluedaterange.SelectedValue == "daterange")
                    {
                        string str76 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueFromdate.Text));
                        string str77 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtestvalueTodate.Text));
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str76, "' and '", str77, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str76, "' and '", str77, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddlestimatevaluedaterange.SelectedValue == "lastweek")
                    {
                        string str74 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                        string str75 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str74, "' and '", str75, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str74, "' and '", str75, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddlestimatevaluedaterange.SelectedValue == "lastyear")
                    {
                        string str74 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                        string str75 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and AttentionID=b.ContactID  and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str74, "' and '", str75, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS (select cast(isnull(estimatevalue,0)as decimal(28,10)) from tb_estimate where customerid=a.clientid and isdeleted=0 and ISNULL(IsCompleted,0)=1 and EstimateNumber not in('DirectJob','Direct Job','0','DirectInvoice','Direct Invoice','') and DateADD(d,0,DateDiff(d,0,CreatedDate)) between '", str74, "' and '", str75, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                }
                else if (this.ddlestimatevaluerange.SelectedValue == "equals to")
                {
                    str1 = string.Concat(str1, "= CAST('", this.txtestimatevaluerange.Text, "' AS DECIMAL(28,10))");
                }
            }
            if (this.chkjobvaluerange.Checked)
            {
                if (this.ddljobvaluedaterange.SelectedValue == "current month")
                {
                    string str78 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str79 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str78, "' and '", str79, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str78, "' and '", str79, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddljobvaluedaterange.SelectedValue == "last month")
                {
                    string str80 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                    string str81 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str80, "' and '", str81, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str80, "' and '", str81, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddljobvaluedaterange.SelectedValue == "daterange")
                {
                    string str82 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueFromdate.Text));
                    string str83 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueTodate.Text));
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str82, "' and '", str83, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str82, "' and '", str83, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddljobvaluedaterange.SelectedValue == "lastweek")
                {
                    string str80 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str81 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str80, "' and '", str81, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str80, "' and '", str81, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                }
                else if (this.ddljobvaluedaterange.SelectedValue == "lastyear")
                {
                    string str80 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str81 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str80, "' and '", str81, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { str1, " and round((select isnull(sum(case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str80, "' and '", str81, "'),(select top 1 Roundoff from tb_Defaultsettings ds where companyid=a.companyid and ds.isdeleted=0)) " };
                        str1 = string.Concat(strArrays);
                    }
                }
                if (this.ddljobvaluerange.SelectedValue == "greater than")
                {
                    str1 = string.Concat(str1, "> CAST('", this.txtjobvaluerange.Text, "' AS DECIMAL(28,10))");
                }
                else if (this.ddljobvaluerange.SelectedValue == "less than")
                {
                    str1 = string.Concat(str1, "< CAST('", this.txtjobvaluerange.Text, "' AS DECIMAL(28,10))");
                    if (this.ddljobvaluedaterange.SelectedValue == "current month")
                    {
                        string str84 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                        string str85 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str84, "' and '", str85, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str84, "' and '", str85, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddljobvaluedaterange.SelectedValue == "last month")
                    {
                        string str86 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.laststdate[0].ToString());
                        string str87 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.lastenddate[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str86, "' and '", str87, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str86, "' and '", str87, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddljobvaluedaterange.SelectedValue == "lastweek")
                    {
                        string str86 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                        string str87 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str86, "' and '", str87, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str86, "' and '", str87, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddljobvaluedaterange.SelectedValue == "lastyear")
                    {
                        string str86 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                        string str87 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str86, "' and '", str87, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str86, "' and '", str87, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                    if (this.ddljobvaluedaterange.SelectedValue == "daterange")
                    {
                        string str88 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueFromdate.Text));
                        string str89 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtjobvalueTodate.Text));
                        if (this.contactlstcount > 0 || this.Departmentlstcount > 0)
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.AttentionID = b.contactId and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str88, "' and '", str89, "')" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str1, "AND EXISTS(select isnull((case when  isnull(jc.QTYNumber,0)=1 then ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=2 then ISNULL(tp.Totalsubtotal2, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=3 then ISNULL(tp.Totalsubtotal3, 0) + ISNULL(tp.OrderItemShipping, 0) when isnull(jc.QTYNumber,0)=4 then ISNULL(tp.Totalsubtotal4, 0) + ISNULL(tp.OrderItemShipping, 0) ELSE case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) ELSE ISNULL(tp.Totalsubtotal1, 0) + ISNULL(tp.OrderItemShipping, 0) END END),0)from tb_job j left join tb_Estimate e on e.EstimateID=j.EstimateID left join tb_EstimateItem i on i.JOBID=j.JobID and i.IsDeleted=0 left join tb_jobcard jc on jc.EstimateItemID=i.EstimateItemID left join tb_EstTotalPriceDetails tp  on tp.EstimateitemID = i.EstimateitemID  and tp.sectionid=case when tp.estimatetype in('B','N','K') then -999 else 0 end LEFT JOIN tb_EstPriceCatalogue ETP ON ETP.EstimateItemID=tp.ESTIMATEITEMID where customerid=a.clientid and e.IsDeleted=0 and j.IsDeleted=0 and j.IsReverted=0  and IsNull(e.IsCompleted,0)=1 and e.IsForInvoice=0 and  DateADD(d,0,DateDiff(d,0,j.CreatedDate)) between '", str88, "' and '", str89, "')" };
                            str1 = string.Concat(strArrays);
                        }
                    }
                }
                else if (this.ddljobvaluerange.SelectedValue == "equals to")
                {
                    str1 = string.Concat(str1, "= CAST('", this.txtjobvaluerange.Text, "' AS DECIMAL(28,10))");
                }
            }
            companyID = new object[] { " ", str1, "and a.companyid=", this.CompanyID, " and a.IsDelete=0" };
            str1 = string.Concat(companyID);
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            if (this.ddlGrouprecords.SelectedIndex == 0)
            {
                string empty23 = string.Empty;
                if (PageNumber != 0)
                {
                    if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                    {
                        if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companyname" || this.HdnSortBy.Value.ToLower().Trim().ToString() == "none")
                        {
                            empty2 = string.Concat(empty2, " order by [Company Name]");
                        }
                        if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companytype")
                        {
                            empty2 = string.Concat(empty2, " order by CompanyType");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "type")
                        {
                            empty2 = string.Concat(empty2, " order by Type");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountstatus")
                        {
                            empty2 = string.Concat(empty2, " order by AccountStatus");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountno")
                        {
                            empty2 = string.Concat(empty2, " order by AccountNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "email")
                        {
                            empty2 = string.Concat(empty2, " order by Email");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "url")
                        {
                            empty2 = string.Concat(empty2, " order by URL");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "creditlimit")
                        {
                            empty2 = string.Concat(empty2, " order by CreditLimit");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "creditref")
                        {
                            empty2 = string.Concat(empty2, " order by CreditRef");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "tax1")
                        {
                            empty2 = string.Concat(empty2, " order by Tax");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "description")
                        {
                            empty2 = string.Concat(empty2, " order by Description");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "paymentterms")
                        {
                            empty2 = string.Concat(empty2, " order by PaymentTerms");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "profitmargin")
                        {
                            empty2 = string.Concat(empty2, " order by ProfitMargin");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "taxregno")
                        {
                            empty2 = string.Concat(empty2, " order by TaxRegNo");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companynumber")
                        {
                            empty2 = string.Concat(empty2, " order by CompanyNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "acopened")
                        {
                            empty2 = string.Concat(empty2, " order by CONVERT(Date, a.[A/cOpened], 101)");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "bankcode")
                        {
                            empty2 = string.Concat(empty2, " order by BankCode");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "bankaccountnumber")
                        {
                            empty2 = string.Concat(empty2, " order by BankAccountNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountname")
                        {
                            empty2 = string.Concat(empty2, " order by AccountName");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "salesperson")
                        {
                            empty2 = string.Concat(empty2, " order by SalesPerson");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "name")
                        {
                            empty2 = string.Concat(empty2, " order by name");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "royalityfree")
                        {
                            empty2 = string.Concat(empty2, " order by RoyalityFree");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totalestimate")
                        {
                            empty2 = string.Concat(empty2, " order by TotalEstimate");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatevalue")
                        {
                            empty2 = string.Concat(empty2, " order by EstValue");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totaljob")
                        {
                            empty2 = string.Concat(empty2, " order by TotalJob");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "jobvalue")
                        {
                            empty2 = string.Concat(empty2, " order by JobVal");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totalinvoice")
                        {
                            empty2 = string.Concat(empty2, " order by TotalInvoice");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "invoicevalue")
                        {
                            empty2 = string.Concat(empty2, " order by InvoiceValue");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatejobconversioncount")
                        {
                            empty2 = string.Concat(empty2, " order by EstimateJobconversioncount");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatejobconversionvalue")
                        {
                            empty2 = string.Concat(empty2, " order by EstimateJobconversionvalue");
                        }
                    }
                    if (this.ddlDirection.SelectedValue != "ASC")
                    {
                        str = empty23;
                        if (this.contactlstcount > 0 && this.addresslstcount > 0)
                        {
                            var x = string.Concat("(", "select distinct ", empty1, str1, ")");

                            var x1 = x.Replace("left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete=0 ", "left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete!=0 ");

                            var x2 = x.Replace("inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0", "left join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete!=0 and isnull(b.contactID ,0) = 0");

                            var x3 = string.Concat("(", x1, "union", x2, ")");
                            strArrays = new string[] { str, x3, " ", empty2, " DESC " };
                            empty23 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str, "select distinct ", empty1, " ", str1, " ", empty2, " DESC " };
                            empty23 = string.Concat(strArrays);
                        }
                    }
                    else
                    {
                        str = empty23;
                        if (this.contactlstcount > 0 && this.addresslstcount > 0)
                        {
                            var x = string.Concat("(", "select distinct ", empty1, str1, ")");

                            var x1 = x.Replace("left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete=0 ", "left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete!=0 ");

                            var x2 = x.Replace("inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0", "left join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete!=0 and isnull(b.contactID ,0) = 0");

                            var x3 = string.Concat("(", x1, "union", x2, ")");
                            strArrays = new string[] { str, x3, " ", empty2, " ASC " };
                            empty23 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str, "select distinct ", empty1, " ", str1, " ", empty2, " ASC " };
                            empty23 = string.Concat(strArrays);
                        }
                        
                    }
                    //int pageNumber = PageNumber * 100 - 100;
                    //int num1 = 100;
                    empty = empty23;
                    //companyID = new object[] { empty, " offset ", pageNumber, " rows fetch next ", num1, " rows only;" };
                    //empty23 = string.Concat(companyID);
                    if (this.contactlstcount > 0 && this.addresslstcount > 0)
                        empty23 = string.Concat(empty23, "select ( ( select count(*) ", str1.Replace("left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete=0 ", "left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete!=0 "), " ) + ", "( select count(*) ", str1.Replace("inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0", "left join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete!=0 and isnull(b.contactID ,0) != 0"), " ) )");
                    else
                        empty23 = string.Concat(empty23, " select count(*) ", str1);
                }
                else
                {
                    if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                    {
                        if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companyname" || this.HdnSortBy.Value.ToLower().Trim().ToString() == "none")
                        {
                            empty2 = string.Concat(empty2, " order by [Company Name]");
                        }
                        if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companytype")
                        {
                            empty2 = string.Concat(empty2, " order by CompanyType");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "type")
                        {
                            empty2 = string.Concat(empty2, " order by Type");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountstatus")
                        {
                            empty2 = string.Concat(empty2, " order by AccountStatus");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountno")
                        {
                            empty2 = string.Concat(empty2, " order by AccountNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "email")
                        {
                            empty2 = string.Concat(empty2, " order by Email");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "url")
                        {
                            empty2 = string.Concat(empty2, " order by URL");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "creditlimit")
                        {
                            empty2 = string.Concat(empty2, " order by CreditLimit");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "creditref")
                        {
                            empty2 = string.Concat(empty2, " order by CreditRef");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "tax1")
                        {
                            empty2 = string.Concat(empty2, " order by Tax");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "description")
                        {
                            empty2 = string.Concat(empty2, " order by Description");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "paymentterms")
                        {
                            empty2 = string.Concat(empty2, " order by PaymentTerms");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "profitmargin")
                        {
                            empty2 = string.Concat(empty2, " order by ProfitMargin");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "taxregno")
                        {
                            empty2 = string.Concat(empty2, " order by TaxRegNo");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companynumber")
                        {
                            empty2 = string.Concat(empty2, " order by CompanyNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "acopened")
                        {
                            empty2 = string.Concat(empty2, " order by CONVERT(Date, a.[A/cOpened], 101)");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "bankcode")
                        {
                            empty2 = string.Concat(empty2, " order by BankCode");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "bankaccountnumber")
                        {
                            empty2 = string.Concat(empty2, " order by BankAccountNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountname")
                        {
                            empty2 = string.Concat(empty2, " order by AccountName");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "salesperson")
                        {
                            empty2 = string.Concat(empty2, " order by SalesPerson");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "name")
                        {
                            empty2 = string.Concat(empty2, " order by name");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "royalityfree")
                        {
                            empty2 = string.Concat(empty2, " order by RoyalityFree");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totalestimate")
                        {
                            empty2 = string.Concat(empty2, " order by TotalEstimate");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatevalue")
                        {
                            empty2 = string.Concat(empty2, " order by EstValue");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totaljob")
                        {
                            empty2 = string.Concat(empty2, " order by TotalJob");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "jobvalue")
                        {
                            empty2 = string.Concat(empty2, " order by JobVal");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totalinvoice")
                        {
                            empty2 = string.Concat(empty2, " order by TotalInvoice");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "invoicevalue")
                        {
                            empty2 = string.Concat(empty2, " order by InvoiceValue");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatejobconversioncount")
                        {
                            empty2 = string.Concat(empty2, " order by EstimateJobconversioncount");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatejobconversionvalue")
                        {
                            empty2 = string.Concat(empty2, " order by EstimateJobconversionvalue");
                        }
                    }
                    if (this.ddlDirection.SelectedValue != "ASC")
                    {
                        str = empty23;
                        if (this.contactlstcount > 0 && this.addresslstcount > 0)
                        {
                            var x = string.Concat("(", "select distinct ", empty1, str1, ")");

                            var x1 = x.Replace("left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete=0 ", "left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete!=0 ");

                            var x2 = x.Replace("inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0", "left join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete!=0 and isnull(b.contactID ,0) = 0");

                            var x3 = string.Concat("(", x1, "union", x2, ")");
                            strArrays = new string[] { str, x3, " ", empty2, " DESC " };
                            empty23 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str, "select distinct ", empty1, " ", str1, " ", empty2, " DESC " };
                            empty23 = string.Concat(strArrays);
                        }
                        //strArrays = new string[] { str, "select distinct ", empty1, " ", str1, " ", empty2, " DESC " };
                        //empty23 = string.Concat(strArrays);
                    }
                    else
                    {
                        str = empty23;
                        if (this.contactlstcount > 0 && this.addresslstcount > 0)
                        {
                            var x = string.Concat("(", "select distinct ", empty1, str1, ")");

                            var x1 = x.Replace("left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete=0 ", "left join tb_companyaddress cmp on cmp.ClientID=a.ClientID and cmp.Isdelete!=0 ");

                            var x2 = x.Replace("inner join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete=0 and isnull(b.contactID ,0) != 0", "left join tb_contact b on b.DepartmentID=d.deptid and b.companyid=a.companyid and b.clientID=a.clientID and b.isapproved=1 and b.isDelete!=0 and isnull(b.contactID ,0) = 0");

                            var x3 = string.Concat("(", x1, "union", x2, ")");
                            strArrays = new string[] { str, x3, " ", empty2, " ASC " };
                            empty23 = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { str, "select distinct ", empty1, " ", str1, " ", empty2, " ASC " };
                            empty23 = string.Concat(strArrays);
                        }
                        //strArrays = new string[] { str, "select distinct ", empty1, " ", str1, " ", empty2, " ASC " };
                        //empty23 = string.Concat(strArrays);
                    }
                }                
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty23, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                sqlDataAdapter.Fill(dataSet);
            }
            if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "1")
            {
                int num2 = 0;
                DataSet dataSet1 = new DataSet();
                string str90 = string.Concat("select distinct isnull(DATEADD(d, 0, DATEDIFF(d, 0, a.createDate)),'') as CreatedDate ", str1, " order by CreatedDate");
                (new SqlDataAdapter(str90, sqlConnection)).Fill(dataSet1);
                foreach (DataRow row in dataSet1.Tables[0].Rows)
                {
                    this.plhdetails.Controls.Add(new LiteralControl("<table boder=0  width=100% cellspacing=0 cellpadding=0>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold' ><b>"));
                    Label label = new Label();
                    commonClass _commonClass2 = this.objJava;
                    now = Convert.ToDateTime(row["CreatedDate"]);
                    label.Text = _commonClass2.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                    this.plhdetails.Controls.Add(label);
                    this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100% class='callreport_grpby' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                    if (this.chkColumns.Items[0].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>&nbsp;", this.objLangClass.GetLanguageConversion("Company_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[1].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Company_Type"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[2].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Type"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[3].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Status"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[4].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[5].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Email"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[6].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("url"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[7].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Credit_Limit"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[8].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Credit_Ref"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.Tax2.ToLower() != "no")
                    {
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax1"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax2"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Payment_Terms"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Profit_Margin"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='6%' valign='top' nowrap='nowrap' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax_Reg_No"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Company_Number"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("A_C_Opened"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='5%' nowrap='nowrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Code"), "</b>&nbsp;&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Account_Number"), "</b>&nbsp;</div></td>")));
                            this.flag_itemtitle = "true";
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Name"), "</b>&nbsp;</div></td>")));
                            this.flag_Description = "true";
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Sales_Person"), "</b>&nbsp;</div></td>")));
                            this.flag_Artwork = "true";
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Referred_By"), "</b>&nbsp;</div></td>")));
                            this.flag_Colour = "true";
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Royality_Free"), "</b>&nbsp;</div></td>")));
                            this.flag_Size = "true";
                        }
                    }
                    else
                    {
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Payment_Terms"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Profit_Margin"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='6%' valign='top' nowrap='nowrap' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax_Reg_No"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Company_Number"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("A_C_Opened"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='5%' nowrap='nowrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Code"), "</b>&nbsp;&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Account_Number"), "</b>&nbsp;</div></td>")));
                            this.flag_itemtitle = "true";
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Name"), "</b>&nbsp;</div></td>")));
                            this.flag_Description = "true";
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Sales_Person"), "</b>&nbsp;</div></td>")));
                            this.flag_Artwork = "true";
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Referred_By"), "</b>&nbsp;</div></td>")));
                            this.flag_Colour = "true";
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Royality_Free"), "</b>&nbsp;</div></td>")));
                            this.flag_Size = "true";
                        }
                    }
                    for (int p = 0; p < this.chk_contactsList.Items.Count; p++)
                    {
                        if (this.chk_contactsList.Items[p].Selected)
                        {
                            if (this.chk_contactsList.Items[p].Value == "ContactName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Name_First_Middle_Last"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "FirstName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("First_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "MiddleName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Middle_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "LastName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Last_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "Title")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Title"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "JobTitle1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Title1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "JobTitle2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Title2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ContactEmail")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Email"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "Mobile")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Mobile"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "Phone")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Phone"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "AlternateNumber")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Alternate_Number"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "PersonalFax")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Personal_Fax"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "Department")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ContactAddress")
                            {
                                if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Address"), "</b>&nbsp;</div></td>")));
                                }
                                else
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice Country</b>&nbsp;</div></td>"));
                                }
                            }
                            else if (this.chk_contactsList.Items[p].Value == "DeliveryAddress")
                            {
                                if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Delivery_Address"), "</b>&nbsp;</div></td>")));
                                }
                                else
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice Country</b>&nbsp;</div></td>"));
                                }
                            }
                            else if (this.chk_contactsList.Items[p].Value == "InvoiceAddress")
                            {
                                if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Invoice_Address"), "</b>&nbsp;</div></td>")));
                                }
                                else
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice Country</b>&nbsp;</div></td>"));
                                }
                            }
                            else if (this.chk_contactsList.Items[p].Value == "MainApprover")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("MAin_approver"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "SubscribedUser")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Subscribed_User"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ReceiveMailout")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Receive_Mail_out"), "</b>&nbsp;</div></td>")));
                            }
                            
                            // contact additional information Custom Field 1 to 5
                            else if (this.chk_contactsList.Items[p].Value == "ContactCustomField1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ContactCustomField2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ContactCustomField3")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field3"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ContactCustomField4")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field4"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[p].Value == "ContactCustomField5")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field5"), "</b>&nbsp;</div></td>")));
                            }

                        }
                    }
                    for (int q = 0; q < this.Chk_DepartmentList.Items.Count; q++)
                    {
                        if (this.Chk_DepartmentList.Items[q].Selected)
                        {
                            if (this.Chk_DepartmentList.Items[q].Value == "DepartmentName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "DeliveryAddress1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Dept_Delivery_Address"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "InvoiceAddress1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Dept_Invoice_Address"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "Costcenter")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Cost_Center"), "</b>&nbsp;</div></td>")));
                            }

                            // Department additional information Custom Field 1 to 5
                            else if (this.Chk_DepartmentList.Items[q].Value == "DepartmentCustomField1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "DepartmentCustomField2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "DepartmentCustomField3")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field3"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "DepartmentCustomField4")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field4"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[q].Value == "DepartmentCustomField5")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field5"), "</b>&nbsp;</div></td>")));
                            }

                        }
                    }
                    for (int r = 0; r < this.Chk_addressList.Items.Count; r++)
                    {
                        if (this.Chk_addressList.Items[r].Selected)
                        {
                            if (this.Chk_addressList.Items[r].Value == "AddressLabel")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address_Labels"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Address1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Address2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Address3")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address3"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Address4")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address4"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Address5")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address5"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Country")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Country"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Telephone")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Telephone"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "Fax")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Fax"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[r].Value == "IsPostBoxAddress")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Is_Post_Box_Address"), "</b>&nbsp;</div></td>")));
                            }
                        }
                    }
                    for (int s = 0; s < this.chkAggCustomeritems.Items.Count; s++)
                    {
                        if (this.chkAggCustomeritems.Items[s].Selected)
                        {
                            if (this.chkAggCustomeritems.Items[s].Value == "TotalEstimate")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Total_Estimate"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "EstimateValue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "TotalJob")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Total_Job"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "JobValue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "TotalInvoice")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Total_Invoice"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "InvoiceValue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Invoice_Value_Exc_Tax1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "EstimateJobconversioncount")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_count"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[s].Value == "EstimateJobconversionvalue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_value"), "</b>&nbsp;</div></td>")));
                            }
                        }
                    }
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    string empty24 = string.Empty;
                    commonClass _commonClass3 = this.objJava;
                    now = Convert.ToDateTime(row["CreatedDate"]);
                    string str91 = _commonClass3.Eprint_return_Date_Before_View(now.ToShortDateString(), this.CompanyID, this.UserID, false);
                    str = empty24;
                    strArrays = new string[] { str, "select distinct  ", empty1, " ", str1, " and isnull(DATEADD(d, 0, DATEDIFF(d, 0, a.createDate)),'') = '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, str91), "'" };
                    empty24 = string.Concat(strArrays);
                    if (this.HdnSortBy.Value != "" || this.HdnSortBy.Value != null)
                    {
                        if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companyname" || this.HdnSortBy.Value.ToLower().Trim().ToString() == "none")
                        {
                            empty24 = string.Concat(empty24, " order by [Company Name]");
                        }
                        if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companytype")
                        {
                            empty24 = string.Concat(empty24, " order by CompanyType");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "type")
                        {
                            empty24 = string.Concat(empty24, " order by Type");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountstatus")
                        {
                            empty24 = string.Concat(empty24, " order by AccountStatus");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountno")
                        {
                            empty24 = string.Concat(empty24, " order by AccountNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "email")
                        {
                            empty24 = string.Concat(empty24, " order by Email");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "url")
                        {
                            empty24 = string.Concat(empty24, " order by URL");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "creditlimit")
                        {
                            empty24 = string.Concat(empty24, " order by CreditLimit");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "creditref")
                        {
                            empty24 = string.Concat(empty24, " order by CreditRef");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "tax1")
                        {
                            empty24 = string.Concat(empty24, " order by Tax");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "description")
                        {
                            empty24 = string.Concat(empty24, " order by Description");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "paymentterms")
                        {
                            empty24 = string.Concat(empty24, " order by PaymentTerms");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "profitmargin")
                        {
                            empty24 = string.Concat(empty24, " order by ProfitMargin");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "taxregno")
                        {
                            empty24 = string.Concat(empty24, " order by TaxRegNo");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "companynumber")
                        {
                            empty24 = string.Concat(empty24, " order by CompanyNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "acopened")
                        {
                            empty24 = string.Concat(empty24, " order by CONVERT(Date, a.[A/cOpened], 101)");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "bankcode")
                        {
                            empty24 = string.Concat(empty24, " order by BankCode");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "bankaccountnumber")
                        {
                            empty24 = string.Concat(empty24, " order by BankAccountNumber");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "accountname")
                        {
                            empty24 = string.Concat(empty24, " order by AccountName");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "salesperson")
                        {
                            empty24 = string.Concat(empty24, " order by SalesPerson");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "name")
                        {
                            empty24 = string.Concat(empty24, " order by name");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "royalityfree")
                        {
                            empty24 = string.Concat(empty24, " order by RoyalityFree");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totalestimate")
                        {
                            empty24 = string.Concat(empty24, " order by TotalEstimate");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatevalue")
                        {
                            empty24 = string.Concat(empty24, " order by EstValue");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totaljob")
                        {
                            empty24 = string.Concat(empty24, " order by TotalJob");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "jobvalue")
                        {
                            empty24 = string.Concat(empty24, " order by JobVal");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "totalinvoice")
                        {
                            empty24 = string.Concat(empty24, " order by TotalInvoice");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "invoicevalue")
                        {
                            empty24 = string.Concat(empty24, " order by InvoiceValue");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatejobconversioncount")
                        {
                            empty24 = string.Concat(empty24, " order by EstimateJobconversioncount");
                        }
                        else if (this.HdnSortBy.Value.ToLower().Trim().ToString() == "estimatejobconversionvalue")
                        {
                            empty24 = string.Concat(empty24, " order by EstimateJobconversionvalue");
                        }
                    }
                    empty24 = (this.ddlDirection.SelectedValue != "ASC" ? string.Concat(empty24, " DESC ") : string.Concat(empty24, " ASC "));
                    SqlCommand sqlCommand = new SqlCommand(empty24, sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    int num3 = 0;
                    if (!sqlDataReader.HasRows)
                    {
                        this.plhdetails.Controls.Clear();
                    }
                    string empty25 = string.Empty;
                    string empty26 = string.Empty;
                    string empty27 = string.Empty;
                    string empty28 = string.Empty;
                    string empty29 = string.Empty;
                    string empty30 = string.Empty;
                    string empty31 = string.Empty;
                    string empty32 = string.Empty;
                    string empty33 = string.Empty;
                    string empty34 = string.Empty;
                    string empty35 = string.Empty;
                    string empty36 = string.Empty;
                    string empty37 = string.Empty;
                    string empty38 = string.Empty;
                    string empty39 = string.Empty;
                    string empty40 = string.Empty;
                    string empty41 = string.Empty;
                    while (sqlDataReader.Read())
                    {
                        num2++;
                        num3++;
                        if (num3 % 2 != 0)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        }
                        else
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport >"));
                        }
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Company Name"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CompanyType"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Type"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["AccountStatus"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["AccountNumber"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Email"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["URL"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CreditLimit"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CreditRef"].ToString(), "&nbsp;</div></td>")));
                        }
                        if (this.Tax2.ToLower() != "no")
                        {
                            if (this.chkColumns.Items[9].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Tax1"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Tax2"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Description"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["PaymentTerms"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["ProfitMargin"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["TaxRegNo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["CompanyNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader["A/cOpened"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["BankCode"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["Bank Account Number"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["AccountName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["SalesPerson"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["name"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["eStoreName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["OpenTasksCalls"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[24].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["RoyalityFree"].ToString(), "&nbsp;</div></td>")));
                            }
                            
                        }
                        else
                        {
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Description"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["PaymentTerms"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["ProfitMargin"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["TaxRegNo"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["CompanyNumber"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader["A/cOpened"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["BankCode"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["Bank Account Number"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["AccountName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["SalesPerson"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["name"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["eStoreName"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["OpenTasksCalls"].ToString(), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["RoyalityFree"].ToString(), "&nbsp;</div></td>")));
                            }
                            
                        }
                        for (int t = 0; t < this.chk_contactsList.Items.Count; t++)
                        {
                            if (this.chk_contactsList.Items[t].Selected)
                            {
                                if (this.chk_contactsList.Items[t].Value == "ContactName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "FirstName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["FirstName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "MiddleName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["MiddleName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "LastName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["LastName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "Title")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Title"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "JobTitle1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["jobtitle"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "JobTitle2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["jobtitle2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ContactEmail")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactEmail"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "Mobile")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["Mobile"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "Phone")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["Phone"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "AlternateNumber")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["AlternateNumber"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "PersonalFax")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["PersonalFax"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "Department")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ContactAddress")
                                {
                                    if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactAddress"].ToString(), "&nbsp;</div></td>")));
                                    }
                                    else
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactAddress1"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactAddress2"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactAddress3"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactAddress4"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactAddress5"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactCountry"].ToString(), "&nbsp;</div></td>")));
                                    }
                                }
                                else if (this.chk_contactsList.Items[t].Value == "DeliveryAddress")
                                {
                                    if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                                    }
                                    else
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactDelAddress1"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactDelAddress2"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactDelAddress3"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactDelAddress4"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactDelAddress5"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactDelCountry"].ToString(), "&nbsp;</div></td>")));
                                    }
                                }
                                else if (this.chk_contactsList.Items[t].Value == "InvoiceAddress")
                                {
                                    if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["InvoiceAddress"].ToString(), "&nbsp;</div></td>")));
                                    }
                                    else
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactInvAddress1"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactInvAddress2"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactInvAddress3"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactInvAddress4"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactInvAddress5"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["ContactInvCountry"].ToString(), "&nbsp;</div></td>")));
                                    }
                                }
                                else if (this.chk_contactsList.Items[t].Value == "MainApprover")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["MainApprover"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "SubscribedUser")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["SubscribeUser"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ReceiveMailout")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["IsReceiveMailOut"].ToString(), "&nbsp;</div></td>")));
                                }

                                // contact additional information Custom Field 1 to 5
                                else if (this.chk_contactsList.Items[t].Value == "ContactCustomField1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["ContactCustomField1"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ContactCustomField2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["ContactCustomField2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ContactCustomField3")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["ContactCustomField3"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ContactCustomField4")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["ContactCustomField4"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[t].Value == "ContactCustomField5")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["ContactCustomField5"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                        }
                        for (int u = 0; u < this.Chk_DepartmentList.Items.Count; u++)
                        {
                            if (this.Chk_DepartmentList.Items[u].Selected)
                            {
                                if (this.Chk_DepartmentList.Items[u].Value == "DepartmentName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "DeliveryAddress1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeptDeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "InvoiceAddress1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DeptInvoiceAddress"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "Costcenter")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["CostCentre"].ToString(), "&nbsp;</div></td>")));
                                }

                                // Department additional information Custom Field 1 to 5
                                else if (this.Chk_DepartmentList.Items[u].Value == "DepartmentCustomField1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentCustomField1"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "DepartmentCustomField2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentCustomField2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "DepartmentCustomField3")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentCustomField3"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "DepartmentCustomField4")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentCustomField4"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[u].Value == "DepartmentCustomField5")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["DepartmentCustomField5"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                        }
                        for (int v = 0; v < this.Chk_addressList.Items.Count; v++)
                        {
                            if (this.Chk_addressList.Items[v].Selected)
                            {
                                if (this.Chk_addressList.Items[v].Value == "AddressLabel")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["AddressLabel"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Address1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Address1"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Address2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Address2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Address3")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Address3"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Address4")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Address4"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Address5")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Address5"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Country")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader["Country"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Telephone")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["Telephone"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "Fax")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["Fax"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[v].Value == "IsPostBoxAddress")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader["IsPostBoxAddress"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                        }
                        for (int w = 0; w < this.chkAggCustomeritems.Items.Count; w++)
                        {
                            if (this.chkAggCustomeritems.Items[w].Selected)
                            {
                                if (this.chkAggCustomeritems.Items[w].Value == "TotalEstimate")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader["TotalEstimate"].ToString()), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "EstimateValue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["EstValue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "TotalJob")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader["TotalJob"].ToString()), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "JobValue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["JobVal"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "TotalInvoice")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader["TotalInvoice"].ToString()), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "InvoiceValue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["InvoiceValue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "EstimateJobconversioncount")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["EstimateJobconversioncount"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[w].Value == "EstimateJobconversionvalue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader["EstimateJobconversionvalue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                            }
                        }
                    }
                    sqlConnection.Close();
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                }
                this.lblTotalRecords.Text = num2.ToString();
            }
            else if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "2")
            {
                int num4 = 0;
                DataSet dataSet2 = new DataSet();
                string str92 = string.Concat("select distinct  ISNULL(u.firstname, '') AS SalesPerson ", str1, " ");
                (new SqlDataAdapter(str92, sqlConnection)).Fill(dataSet2);
                foreach (DataRow dataRow in dataSet2.Tables[0].Rows)
                {
                    this.plhdetails.Controls.Add(new LiteralControl("<table boder=0  width=100% cellspacing=0 cellpadding=0>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold' ><b>"));
                    Label label1 = new Label();
                    string str93 = base.SpecialDecode(dataRow["SalesPerson"].ToString());
                    dataRow["SalesPerson"] = base.SpecialEncode(dataRow["SalesPerson"].ToString());
                    if (str93 != "")
                    {
                        label1.Text = str93;
                    }
                    else
                    {
                        label1.Text = "Not Specified";
                    }
                    this.plhdetails.Controls.Add(label1);
                    this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<table width=100% class='callreport_grpby' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                    if (this.chkColumns.Items[0].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>&nbsp;", this.objLangClass.GetLanguageConversion("Company_Name"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[1].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Company_Type"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[2].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Type"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[3].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Status"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[4].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Number"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[5].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Email"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[6].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("url"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[7].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Credit_Limit"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.chkColumns.Items[8].Selected)
                    {
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Credit_Ref"), "</b>&nbsp;</div></td>")));
                    }
                    if (this.Tax2.ToLower() != "no")
                    {
                        if (this.chkColumns.Items[9].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax1"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax2"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Payment_Terms"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Profit_Margin"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='6%' valign='top' nowrap='nowrap' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax_Reg_No"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Company_Number"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("A_C_Opened"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='5%' nowrap='nowrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Code"), "</b>&nbsp;&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Account_Number"), "</b>&nbsp;</div></td>")));
                            this.flag_itemtitle = "true";
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Name"), "</b>&nbsp;</div></td>")));
                            this.flag_Description = "true";
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Sales_Person"), "</b>&nbsp;</div></td>")));
                            this.flag_Artwork = "true";
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Referred_By"), "</b>&nbsp;</div></td>")));
                            this.flag_Colour = "true";
                        }
                        if (this.chkColumns.Items[22].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Royality_Free"), "</b>&nbsp;</div></td>")));
                            this.flag_Size = "true";
                        }
                    }
                    else
                    {
                        if (this.chkColumns.Items[10].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[11].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Payment_Terms"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[12].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Profit_Margin"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[13].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='6%' valign='top' nowrap='nowrap' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Tax_Reg_No"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[14].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Company_Number"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[15].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("A_C_Opened"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[16].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=right width='5%' nowrap='nowrap' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Code"), "</b>&nbsp;&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[17].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Bank_Account_Number"), "</b>&nbsp;</div></td>")));
                            this.flag_itemtitle = "true";
                        }
                        if (this.chkColumns.Items[18].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Account_Name"), "</b>&nbsp;</div></td>")));
                            this.flag_Description = "true";
                        }
                        if (this.chkColumns.Items[19].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Sales_Person"), "</b>&nbsp;</div></td>")));
                            this.flag_Artwork = "true";
                        }
                        if (this.chkColumns.Items[20].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Referred_By"), "</b>&nbsp;</div></td>")));
                            this.flag_Colour = "true";
                        }
                        if (this.chkColumns.Items[21].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Royality_Free"), "</b>&nbsp;</div></td>")));
                            this.flag_Size = "true";
                        }
                    }
                    for (int x = 0; x < this.chk_contactsList.Items.Count; x++)
                    {
                        if (this.chk_contactsList.Items[x].Selected)
                        {
                            if (this.chk_contactsList.Items[x].Value == "ContactName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Name_First_Middle_Last"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "FirstName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("First_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "MiddleName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Middle_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "LastName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Last_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "Title")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Title"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "JobTitle1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Title1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "JobTitle2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Title2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ContactEmail")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Email"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "Mobile")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Mobile"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "Phone")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Phone"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "AlternateNumber")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Alternate_Number"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "PersonalFax")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Personal_Fax"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "Department")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ContactAddress")
                            {
                                if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Address"), "</b>&nbsp;</div></td>")));
                                }
                                else
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice Country</b>&nbsp;</div></td>"));
                                }
                            }
                            else if (this.chk_contactsList.Items[x].Value == "DeliveryAddress")
                            {
                                if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Delivery_Address"), "</b>&nbsp;</div></td>")));
                                }
                                else
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice Country</b>&nbsp;</div></td>"));
                                }
                            }
                            else if (this.chk_contactsList.Items[x].Value == "InvoiceAddress")
                            {
                                if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Invoice_Address"), "</b>&nbsp;</div></td>")));
                                }
                                else
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[1].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[2].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[3].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[4].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice ", this.Chk_addressList.Items[5].Text, "</b>&nbsp;</div></td>")));
                                    this.plhdetails.Controls.Add(new LiteralControl("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>Invoice Country</b>&nbsp;</div></td>"));
                                }
                            }
                            else if (this.chk_contactsList.Items[x].Value == "MainApprover")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("MAin_approver"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "SubscribedUser")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Subscribed_User"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ReceiveMailout")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Receive_Mail_out"), "</b>&nbsp;</div></td>")));
                            }
                            // contact additional information Custom Field 1 to 5
                            else if (this.chk_contactsList.Items[x].Value == "ContactCustomField1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ContactCustomField2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ContactCustomField3")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field3"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ContactCustomField4")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field4"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chk_contactsList.Items[x].Value == "ContactCustomField5")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Contact_Custom_Field5"), "</b>&nbsp;</div></td>")));
                            }
                        }
                    }
                    for (int y = 0; y < this.Chk_DepartmentList.Items.Count; y++)
                    {
                        if (this.Chk_DepartmentList.Items[y].Selected)
                        {
                            if (this.Chk_DepartmentList.Items[y].Value == "DepartmentName")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Name"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "DeliveryAddress1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Dept_Delivery_Address"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "InvoiceAddress1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Dept_Invoice_Address"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "Costcenter")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Cost_Center"), "</b>&nbsp;</div></td>")));
                            }

                            // Department additional information Custom Field 1 to 5
                            else if (this.Chk_DepartmentList.Items[y].Value == "DepartmentCustomField1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "DepartmentCustomField2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "DepartmentCustomField3")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field3"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "DepartmentCustomField4")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field4"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_DepartmentList.Items[y].Value == "DepartmentCustomField5")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Department_Custom_Field5"), "</b>&nbsp;</div></td>")));
                            }

                        }
                    }
                    for (int a = 0; a < this.Chk_addressList.Items.Count; a++)
                    {
                        if (this.Chk_addressList.Items[a].Selected)
                        {
                            if (this.Chk_addressList.Items[a].Value == "AddressLabel")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address_Labels"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Address1")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Address2")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address2"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Address3")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address3"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Address4")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address4"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Address5")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Address5"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Country")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Country"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Telephone")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Telephone"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "Fax")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Fax"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.Chk_addressList.Items[a].Value == "IsPostBoxAddress")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Is_Post_Box_Address"), "</b>&nbsp;</div></td>")));
                            }
                        }
                    }
                    for (int b = 0; b < this.chkAggCustomeritems.Items.Count; b++)
                    {
                        if (this.chkAggCustomeritems.Items[b].Selected)
                        {
                            if (this.chkAggCustomeritems.Items[b].Value == "TotalEstimate")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Total_Estimate"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "EstimateValue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "TotalJob")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Total_Job"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "JobValue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "TotalInvoice")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Total_Invoice"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "InvoiceValue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Invoice_Value_Exc_Tax1"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "EstimateJobconversioncount")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_count"), "</b>&nbsp;</div></td>")));
                            }
                            else if (this.chkAggCustomeritems.Items[b].Value == "EstimateJobconversionvalue")
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div class='headerreport_divwidth'><b>", this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_value"), "</b>&nbsp;</div></td>")));
                            }
                        }
                    }
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    empty = string.Empty;
                    companyID = new object[] { empty, "select distinct  ", empty1, " ", str1, " and isnull((Select r.firstname from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=a.SalesPerson and r.IsDelete=0),'') = '", dataRow["SalesPerson"].ToString().TrimStart(new char[0]).TrimEnd(new char[0]), "'" };
                    SqlCommand sqlCommand1 = new SqlCommand(string.Concat(companyID), sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                    int num5 = 0;
                    if (!sqlDataReader1.HasRows)
                    {
                        this.plhdetails.Controls.Clear();
                    }
                    string empty42 = string.Empty;
                    string empty43 = string.Empty;
                    string empty44 = string.Empty;
                    string empty45 = string.Empty;
                    string empty46 = string.Empty;
                    string empty47 = string.Empty;
                    string empty48 = string.Empty;
                    string empty49 = string.Empty;
                    string empty50 = string.Empty;
                    string empty51 = string.Empty;
                    string empty52 = string.Empty;
                    string empty53 = string.Empty;
                    string empty54 = string.Empty;
                    string empty55 = string.Empty;
                    string empty56 = string.Empty;
                    string empty57 = string.Empty;
                    string empty58 = string.Empty;
                    while (sqlDataReader1.Read())
                    {
                        num4++;
                        num5++;
                        if (num5 % 2 != 0)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        }
                        else
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport >"));
                        }
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Company Name"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["CompanyType"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Type"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["AccountStatus"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["AccountNumber"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Email"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["URL"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["CreditLimit"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["CreditRef"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.Tax2.ToLower() != "no")
                        {
                            if (this.chkColumns.Items[9].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Tax1"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Tax2"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Description"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["PaymentTerms"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["ProfitMargin"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["TaxRegNo"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["CompanyNumber"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader1["A/cOpened"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["BankCode"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Bank Account Number"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["AccountName"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["SalesPerson"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["name"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["eStoreName"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["OpenTasksCalls"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[24].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["RoyalityFree"].ToString()), "&nbsp;</div></td>")));
                            }
                            
                        }
                        else
                        {
                            if (this.chkColumns.Items[10].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Description"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[11].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["PaymentTerms"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[12].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["ProfitMargin"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[13].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["TaxRegNo"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[14].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["CompanyNumber"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[15].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_return_Date_Before_View(sqlDataReader1["A/cOpened"].ToString(), this.CompanyID, this.UserID, false), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[16].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["BankCode"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[17].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["Bank Account Number"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[18].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["AccountName"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[19].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["SalesPerson"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[20].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["name"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[21].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["eStoreName"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[22].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["OpenTasksCalls"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[23].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["RoyalityFree"].ToString()), "&nbsp;</div></td>")));
                            }
                            
                        }
                        for (int c = 0; c < this.chk_contactsList.Items.Count; c++)
                        {
                            if (this.chk_contactsList.Items[c].Selected)
                            {
                                if (this.chk_contactsList.Items[c].Value == "ContactName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "FirstName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["FirstName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "MiddleName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["MiddleName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "LastName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["LastName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "Title")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Title"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "JobTitle1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["jobtitle"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "JobTitle2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["jobtitle2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ContactEmail")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactEmail"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "Mobile")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["Mobile"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "Phone")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["Phone"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "AlternateNumber")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["AlternateNumber"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "PersonalFax")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["PersonalFax"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "Department")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ContactAddress")
                                {
                                    if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactAddress"].ToString(), "&nbsp;</div></td>")));
                                    }
                                    else
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactAddress1"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactAddress2"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactAddress3"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactAddress4"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactAddress5"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactCountry"].ToString(), "&nbsp;</div></td>")));
                                    }
                                }
                                else if (this.chk_contactsList.Items[c].Value == "DeliveryAddress")
                                {
                                    if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                                    }
                                    else
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactDelAddress1"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactDelAddress2"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactDelAddress3"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactDelAddress4"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactDelAddress5"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactDelCountry"].ToString(), "&nbsp;</div></td>")));
                                    }
                                }
                                else if (this.chk_contactsList.Items[c].Value == "InvoiceAddress")
                                {
                                    if (this.ddlIndividual.SelectedValue != "IndividualColumn")
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["InvoiceAddress"].ToString(), "&nbsp;</div></td>")));
                                    }
                                    else
                                    {
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactInvAddress1"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactInvAddress2"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactInvAddress3"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactInvAddress4"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactInvAddress5"].ToString(), "&nbsp;</div></td>")));
                                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["ContactInvCountry"].ToString(), "&nbsp;</div></td>")));
                                    }
                                }
                                else if (this.chk_contactsList.Items[c].Value == "MainApprover")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["MainApprover"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "SubscribedUser")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["SubscribeUser"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ReceiveMailout")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["IsReceiveMailOut"].ToString(), "&nbsp;</div></td>")));
                                }
                                // contact additional information Custom Field 1 to 5
                                else if (this.chk_contactsList.Items[c].Value == "ContactCustomField1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["ContactCustomField1"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ContactCustomField2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["ContactCustomField2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ContactCustomField3")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["ContactCustomField3"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ContactCustomField4")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["ContactCustomField4"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.chk_contactsList.Items[c].Value == "ContactCustomField5")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["ContactCustomField5"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                        }
                        for (int d = 0; d < this.Chk_DepartmentList.Items.Count; d++)
                        {
                            if (this.Chk_DepartmentList.Items[d].Selected)
                            {
                                if (this.Chk_DepartmentList.Items[d].Value == "DepartmentName")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentName"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "DeliveryAddress1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeptDeliveryAddress"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "InvoiceAddress1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DeptInvoiceAddress"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "Costcenter")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["CostCentre"].ToString(), "&nbsp;</div></td>")));
                                }

                                // Department additional information Custom Field 1 to 5
                                else if (this.Chk_DepartmentList.Items[d].Value == "DepartmentCustomField1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentCustomField1"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "DepartmentCustomField2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentCustomField2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "DepartmentCustomField3")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentCustomField3"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "DepartmentCustomField4")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentCustomField4"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_DepartmentList.Items[d].Value == "DepartmentCustomField5")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["DepartmentCustomField5"].ToString(), "&nbsp;</div></td>")));
                                }

                            }
                        }
                        for (int e = 0; e < this.Chk_addressList.Items.Count; e++)
                        {
                            if (this.Chk_addressList.Items[e].Selected)
                            {
                                if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "AddressLabel")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["AddressLabel"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Address1")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Address1"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Address2")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Address2"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Address3")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Address3"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Address4")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Address4"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Address5")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Address5"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Country")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;word-break:break-all;' class='divscroll'>", sqlDataReader1["Country"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Telephone")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["Telephone"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "Fax")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["Fax"].ToString(), "&nbsp;</div></td>")));
                                }
                                else if (this.Chk_addressList.Items[e].Selected && this.Chk_addressList.Items[e].Value == "IsPostBoxAddress")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", sqlDataReader1["IsPostBoxAddress"].ToString(), "&nbsp;</div></td>")));
                                }
                            }
                        }
                        for (int f = 0; f < this.chkAggCustomeritems.Items.Count; f++)
                        {
                            if (this.chkAggCustomeritems.Items[f].Selected)
                            {
                                if (this.chkAggCustomeritems.Items[f].Value == "TotalEstimate")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["TotalEstimate"].ToString()), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "EstimateValue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["EstValue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "TotalJob")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["TotalJob"].ToString()), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "JobValue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["JobVal"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "TotalInvoice")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", base.SpecialDecode(sqlDataReader1["TotalInvoice"].ToString()), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "InvoiceValue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["InvoiceValue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "EstimateJobconversioncount")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["EstimateJobconversioncount"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                                else if (this.chkAggCustomeritems.Items[f].Value == "EstimateJobconversionvalue")
                                {
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader1["EstimateJobconversionvalue"].ToString()), 0, "", false, false, true), "&nbsp;</div></td>")));
                                }
                            }
                        }
                    }
                    sqlConnection.Close();
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                }
                this.lblTotalRecords.Text = num4.ToString();
            }
            if (this.chkest.Checked || this.chkest1.Checked || this.chkjob.Checked || this.chkjob1.Checked || this.chkinv.Checked || this.chkinv1.Checked || this.chkpo.Checked || this.chkpo1.Checked)
            {
                this.divaggregate.Visible = true;
                this.divAggl.Visible = true;
            }
            string empty59 = string.Empty;
            string empty60 = string.Empty;
            string empty61 = string.Empty;
            string empty62 = string.Empty;
            if (!this.chkest.Checked)
            {
                this.divestCount.Visible = false;
            }
            else
            {
                this.divestCount.Visible = true;
                empty59 = (empty59 == "" ? string.Concat(empty59, "isnull(COUNT(distinct EstimateID), 0) as estimatecount") : string.Concat(empty59, empty59, ",isnull(COUNT(distinct EstimateID), 0) as estimatecount"));
            }
            if (!this.chkest1.Checked)
            {
                this.divestTotal.Visible = false;
            }
            else
            {
                this.divestTotal.Visible = true;
                empty59 = (empty59 == "" ? string.Concat(empty59, "isnull(sum(Estimatevalue),0) as estimatetotal") : string.Concat(empty59, ",isnull(sum(Estimatevalue),0) as estimatetotal"));
            }
            if (!this.chkjob.Checked)
            {
                this.divjobCount.Visible = false;
            }
            else
            {
                this.divjobCount.Visible = true;
                empty60 = (empty60 == "" ? string.Concat(empty60, "isnull(COUNT(distinct JOBID), 0) AS jobcount") : string.Concat(empty60, ",isnull(COUNT(distinct JOBID), 0) AS jobcount"));
            }
            if (!this.chkjob1.Checked)
            {
                this.divjobTotal.Visible = false;
            }
            else
            {
                this.divjobTotal.Visible = true;
                empty60 = (empty60 == "" ? string.Concat(empty60, "ISNULL(SUM(Estimatevalue), 0) as jobtotal") : string.Concat(empty60, ",isnull(SUM(Estimatevalue), 0) as jobtotal"));
            }
            if (!this.chkinv.Checked)
            {
                this.divinvCount.Visible = false;
            }
            else
            {
                this.divinvCount.Visible = true;
                empty61 = (empty61 == "" ? string.Concat(empty61, "isnull(COUNT(distinct InvoiceID), 0) as invcount") : string.Concat(empty61, ",isnull(COUNT(distinct InvoiceID), 0) as invcount"));
            }
            if (!this.chkinv1.Checked)
            {
                this.divinvTotal.Visible = false;
            }
            else
            {
                this.divinvTotal.Visible = true;
                empty61 = (empty61 == "" ? string.Concat(empty61, "isnull(SUM(InvoiceValue), 0) as invtotal") : string.Concat(empty61, ",isnull(SUM(InvoiceValue), 0) as invtotal"));
            }
            if (!this.chkpo.Checked)
            {
                this.divpurCount.Visible = false;
            }
            else
            {
                this.divpurCount.Visible = true;
                if (empty62 == "")
                {
                    empty62 = (this.ddlCompanyType.SelectedValue != "Supplier" ? string.Concat(empty62, "isnull(sum(PurchaseCount),0) as CountPurchaseValue") : string.Concat(empty62, "isnull(COUNT(distinct PurchaseID), 0) as CountPurchaseValue"));
                }
                else
                {
                    empty62 = (this.ddlCompanyType.SelectedValue != "Supplier" ? string.Concat(empty62, ",isnull(sum(PurchaseCount),0) as CountPurchaseValue") : string.Concat(empty62, ",isnull(COUNT(distinct PurchaseID), 0) as CountPurchaseValue"));
                }
            }
            if (!this.chkpo1.Checked)
            {
                this.divpurTotal.Visible = false;
            }
            else
            {
                this.divpurTotal.Visible = true;
                if (empty62 == "")
                {
                    empty62 = (this.ddlCompanyType.SelectedValue != "Supplier" ? string.Concat(empty62, "isnull(sum(PurchaseTotal),0) as TotalpurchaseValue") : string.Concat(empty62, "isnull(sum(POprice),0) as TotalpurchaseValue"));
                }
                else
                {
                    empty62 = (this.ddlCompanyType.SelectedValue != "Supplier" ? string.Concat(empty62, ",isnull(Sum(PurchaseTotal),0) as TotalpurchaseValue") : string.Concat(empty62, ",isnull(Sum(POprice),0) as TotalpurchaseValue"));
                }
            }
            string empty63 = string.Empty;
            string empty64 = string.Empty;
            string empty65 = string.Empty;
            string empty66 = string.Empty;
            if (empty59 != "" && (this.chkest.Checked || this.chkest1.Checked))
            {
                string empty67 = string.Empty;
                empty = "create table #tempEstCount(RowNumber int IDENTITY (1, 1) not null , EstimateCount int,EstimateTotal money,clientname nvarchar(250)) insert into #tempEstCount (EstimateCount,EstimateTotal,clientname) ";
                companyID = new object[] { empty, "  select distinct isnull(count(e.EstimateID),0) as EstimateCount,(SELECT sum(vw.estimatevalue) from VW_Estimate_View vw where companyid=", this.CompanyID, ")as estimatevalue,a.clientname " };
                empty63 = string.Concat(companyID);
                empty63 = string.Concat(empty63, " ", str19, " group by a.clientname");
                empty = empty67;
                companyID = new object[] { empty, empty63, " select ", empty59, " from VW_Estimate_View where CompanyID=", this.CompanyID };
                SqlCommand sqlCommand2 = new SqlCommand(string.Concat(companyID), sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                sqlConnection.Open();
                SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                while (sqlDataReader2.Read())
                {
                    if (this.chkest.Checked)
                    {
                        this.lblestCount.Text = sqlDataReader2["estimatecount"].ToString();
                        this.TotalEst = this.lblestCount.Text;
                    }
                    if (!this.chkest1.Checked)
                    {
                        continue;
                    }
                    this.lblestTotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader2["estimatetotal"].ToString()), 0, "", false, false, true);
                    this.TotalEstValue = this.lblestTotal.Text;
                }
                sqlConnection.Close();
            }
            if (empty60 != "" && (this.chkjob.Checked || this.chkjob1.Checked))
            {
                string empty68 = string.Empty;
                empty64 = string.Concat("create table #tempEstCount(RowNumber int IDENTITY (1, 1) not null , EstimateCount int,EstimateTotal money,clientname nvarchar(250)) insert into #tempEstCount (EstimateCount,EstimateTotal,clientname) ", "  select isnull(count(DISTINCT j.JobID),0) as EstimateCount,isnull(sum(case when e.IsFromWebStore='no' then case when  isnull(jc.QTYNumber,0)=1 then isnull(tp.TotalSellingPrice1,0) when isnull(jc.QTYNumber,0)=2 then isnull(tp.TotalSellingPrice2,0) when isnull(jc.QTYNumber,0)=3 then isnull(tp.TotalSellingPrice3,0) when isnull(jc.QTYNumber,0)=4 then isnull(tp.TotalSellingPrice4,0) end else case when i.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) else ISNULL((tp.TotalSellingPrice1),0) end end),0) as EstimateTotal,a.clientname");
                empty64 = string.Concat(empty64, " ", empty20, " group by a.clientname ");
                empty = empty68;
                companyID = new object[] { empty, empty64, " select ", empty60, " from VW_Job_View where CompanyID=", this.CompanyID };
                SqlCommand sqlCommand3 = new SqlCommand(string.Concat(companyID), sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                sqlConnection.Open();
                SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                while (sqlDataReader3.Read())
                {
                    if (this.chkjob.Checked)
                    {
                        this.lbljobCount.Text = sqlDataReader3["jobcount"].ToString();
                        this.TotalJobs = this.lbljobCount.Text;
                    }
                    if (!this.chkjob1.Checked)
                    {
                        continue;
                    }
                    this.lbljobTotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader3["jobtotal"].ToString()), 0, "", false, false, true);
                    this.TotalJobValue = this.lbljobTotal.Text;
                }
                sqlConnection.Close();
            }
            if (empty61 != "" && (this.chkinv.Checked || this.chkinv1.Checked))
            {
                string empty69 = string.Empty;
                empty65 = string.Concat("create table #tempEstCount(RowNumber int IDENTITY (1, 1) not null , EstimateCount int,EstimateTotal money,clientname nvarchar(250)) insert into #tempEstCount (EstimateCount,EstimateTotal,clientname) ", "  select isnull(count(DISTINCT i.InvoiceID),0) as EstimateCount,isnull(sum(case when e.IsFromWebStore='no' then case when  isnull(jc.QTYNumber,0)=1 then isnull(tp.TotalSellingPrice1,0) when isnull(jc.QTYNumber,0)=2 then isnull(tp.TotalSellingPrice2,0) when isnull(jc.QTYNumber,0)=3 then isnull(tp.TotalSellingPrice3,0) when isnull(jc.QTYNumber,0)=4 then isnull(tp.TotalSellingPrice4,0) end else case when ei.EstimateType='u' then  isnull(tp.TotalCostInMarkup1,0) else ISNULL((tp.TotalSellingPrice1),0) end end),0) as EstimateTotal,a.clientname");
                empty65 = string.Concat(empty65, " ", str20, " group by a.clientname ");
                empty = empty69;
                companyID = new object[] { empty, empty65, " select ", empty61, " from VW_Invoice_View where CompanyID=", this.CompanyID };
                SqlCommand sqlCommand4 = new SqlCommand(string.Concat(companyID), sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                sqlConnection.Open();
                SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
                while (sqlDataReader4.Read())
                {
                    if (this.chkinv.Checked)
                    {
                        this.lblinvCount.Text = sqlDataReader4["invcount"].ToString();
                        this.TotalInv = this.lblinvCount.Text;
                    }
                    if (!this.chkinv1.Checked)
                    {
                        continue;
                    }
                    this.lblinvTotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader4["invtotal"].ToString()), 0, "", false, false, true);
                    this.TotalInvValue = this.lblinvTotal.Text;
                }
                sqlConnection.Close();
            }
            if (empty62 != "" && (this.chkpo.Checked || this.chkpo1.Checked))
            {
                string empty70 = string.Empty;
                empty66 = "create table #tempPurCount(RowNumber int IDENTITY (1, 1) not null , PurchaseCount int,PurchaseTotal money,clientname nvarchar(250)) insert into #tempPurCount (PurchaseCount,PurchaseTotal,clientname) ";
                empty66 = string.Concat(empty66, "  select isnull(count(DISTINCT p.purchaseid),0) ,isnull(Sum(isnull(price,0)+isnull(TaxValue,0)),0),a.clientname");
                empty66 = string.Concat(empty66, " ", empty21, " group by a.clientname");
                if (this.ddlCompanyType.SelectedValue != "Supplier")
                {
                    str = empty70;
                    strArrays = new string[] { str, empty66, " select ", empty62, " from #tempPurCount" };
                    empty70 = string.Concat(strArrays);
                }
                else
                {
                    empty = empty70;
                    companyID = new object[] { empty, empty66, " select ", empty62, " from vw_purchase_view where CompanyID=", this.CompanyID };
                    empty70 = string.Concat(companyID);
                }
                SqlCommand sqlCommand5 = new SqlCommand(empty70, sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                sqlConnection.Open();
                SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
                while (sqlDataReader5.Read())
                {
                    if (this.chkpo.Checked)
                    {
                        this.lblpurCount.Text = sqlDataReader5["CountPurchaseValue"].ToString();
                        this.TotalPurchase = this.lblpurCount.Text;
                    }
                    if (!this.chkpo1.Checked)
                    {
                        continue;
                    }
                    this.lblpurTotal.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(sqlDataReader5["TotalpurchaseValue"].ToString()), 0, "", false, false, true);
                    this.TotalPurchaseValue = this.lblpurTotal.Text;
                }
                sqlConnection.Close();
            }
            if (this.ddlGrouprecords.SelectedIndex == 0)
            {
                foreach (DataRow row1 in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row1[0].ToString());
                }
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
            DataTable dt = SetClientReportColumns(estimateData);
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

        private void GridEstReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            this.GridEstReport.HeaderStyle.CssClass = "commonheaderstylereport11";
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                for (int i = 0; i < e.Row.Controls.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "CompanyType")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Company_Type");
                    }
                    if (e.Row.Cells[i].Text == "AccountStatus")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Account_Status");
                    }
                    else if (e.Row.Cells[i].Text == "AccountNumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Account_Number");
                    }
                    else if (e.Row.Cells[i].Text == "WebSite")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("URL");
                    }
                    else if (e.Row.Cells[i].Text == "CreditLimit")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Credit_Limit");
                    }
                    else if (e.Row.Cells[i].Text == "CreditRef")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Credit_Ref");
                    }
                    else if (e.Row.Cells[i].Text == "Tax1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Tax1");
                    }
                    else if (e.Row.Cells[i].Text == "Tax2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Tax2");
                    }
                    else if (e.Row.Cells[i].Text == "Description")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Description");
                    }
                    else if (e.Row.Cells[i].Text == "TaxRegNo")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Tax_reg_No");
                    }
                    else if (e.Row.Cells[i].Text == "PaymentTerms")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Payment_Terms");
                    }
                    else if (e.Row.Cells[i].Text == "CompanyNumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Company_Number");
                    }
                    else if (e.Row.Cells[i].Text == "ProfitMargin")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Profit_Margin");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_ProfitMargin = i;
                        this.flag_ProfitMargin = "true";
                    }
                    else if (e.Row.Cells[i].Text == "A/cOpened")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("A_C_Opened");
                        this.cellvalue_AcOpenedDate = i;
                        this.flag_AcOpenedDate = "true";
                    }
                    else if (e.Row.Cells[i].Text == "BankCode")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Bank_Code");
                    }
                    else if (e.Row.Cells[i].Text == "BankAccountNumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Bank_Account_Number");
                    }
                    else if (e.Row.Cells[i].Text == "AccountName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Account_Name");
                    }
                    else if (e.Row.Cells[i].Text == "SalesPerson")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    else if (e.Row.Cells[i].Text == "Name")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Referred_By");
                    }
                    else if (e.Row.Cells[i].Text == "eStoreName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("eStore_Name");
                    }
                    else if (e.Row.Cells[i].Text == "RoyalityFree")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Royality_Free");
                    }
                    else if (e.Row.Cells[i].Text == "OpenTasksCalls")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                    } 
                    else if (e.Row.Cells[i].Text == "ContactName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    else if (e.Row.Cells[i].Text == "FirstName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("First_Name");
                    }
                    else if (e.Row.Cells[i].Text == "MiddleName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Middle_Name");
                    }
                    else if (e.Row.Cells[i].Text == "LastName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Last_Name");
                    }
                    else if (e.Row.Cells[i].Text == "Title")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Title");
                    }
                    else if (e.Row.Cells[i].Text == "JobTitle1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Title1");
                    }
                    else if (e.Row.Cells[i].Text == "JobTitle2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Job_Title2");
                    }
                    else if (e.Row.Cells[i].Text == "ContactEmail")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Email");
                    }
                    else if (e.Row.Cells[i].Text == "Mobile")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Mobile");
                    }
                    else if (e.Row.Cells[i].Text == "Phone")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Phone");
                    }
                    else if (e.Row.Cells[i].Text == "AlternateNumber")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Alternate_Number");
                    }
                    else if (e.Row.Cells[i].Text == "PersonalFax")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Personal_Fax");
                    }
                    else if (e.Row.Cells[i].Text == "Department")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department");
                    }
                    else if (e.Row.Cells[i].Text == "ContactAddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Address");
                    }
                    else if (e.Row.Cells[i].Text == "DeliveryAddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address");
                    }
                    else if (e.Row.Cells[i].Text == "InvoiceAddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address");
                    }
                    else if (e.Row.Cells[i].Text == "ContactAddress1")
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[1].Text.ToString());
                    }
                    else if (e.Row.Cells[i].Text == "ContactAddress2")
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[2].Text.ToString());
                    }
                    else if (e.Row.Cells[i].Text == "ContactAddress3")
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[3].Text.ToString());
                    }
                    else if (e.Row.Cells[i].Text == "ContactAddress4")
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[4].Text.ToString());
                    }
                    else if (e.Row.Cells[i].Text == "ContactAddress5")
                    {
                        e.Row.Cells[i].Text = string.Concat("Contact ", this.Chk_addressList.Items[5].Text.ToString());
                    }
                    else if (e.Row.Cells[i].Text == "ContactCountry")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Country");
                    }
                    else if (e.Row.Cells[i].Text == "ContactDelAddress1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address1");
                    }
                    else if (e.Row.Cells[i].Text == "ContactDelAddress2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address2");
                    }
                    else if (e.Row.Cells[i].Text == "ContactDelAddress3")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address3");
                    }
                    else if (e.Row.Cells[i].Text == "ContactDelAddress4")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address4");
                    }
                    else if (e.Row.Cells[i].Text == "ContactDelAddress5")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_Address5");
                    }
                    else if (e.Row.Cells[i].Text == "ContactDelCountry")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Delivery_AddressCountry");
                    }
                    else if (e.Row.Cells[i].Text == "ContactInvAddress1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address1");
                    }
                    else if (e.Row.Cells[i].Text == "ContactInvAddress2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address2");
                    }
                    else if (e.Row.Cells[i].Text == "ContactInvAddress3")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address3");
                    }
                    else if (e.Row.Cells[i].Text == "ContactInvAddress4")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address4");
                    }
                    else if (e.Row.Cells[i].Text == "ContactInvAddress5")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Address5");
                    }
                    else if (e.Row.Cells[i].Text == "ContactInvCountry")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Invoice_Country");
                    }

                    // contact additional information Custom Field 1 to 5
                    else if (e.Row.Cells[i].Text == "ContactCustomField1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field1");
                    }
                    else if (e.Row.Cells[i].Text == "ContactCustomField2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field2");
                    }
                    else if (e.Row.Cells[i].Text == "ContactCustomField3")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field3");
                    }
                    else if (e.Row.Cells[i].Text == "ContactCustomField4")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field4");
                    }
                    else if (e.Row.Cells[i].Text == "ContactCustomField5")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field5");
                    }

                    else if (e.Row.Cells[i].Text == "DepartmentName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department_Name");
                    }
                    else if (e.Row.Cells[i].Text == "DeptDeliveryAddres")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Dept_Delivery_Address");
                    }
                    else if (e.Row.Cells[i].Text == "DeptInvoiceAddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Dept_Invoice_Address");
                    }
                    else if (e.Row.Cells[i].Text == "AddressLabel")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Address_Label");
                    }
                    else if (e.Row.Cells[i].Text == "Address1")
                    {
                        e.Row.Cells[i].Text = this.Chk_addressList.Items[1].Text.ToString();
                    }
                    else if (e.Row.Cells[i].Text == "Address2")
                    {
                        e.Row.Cells[i].Text = this.Chk_addressList.Items[2].Text.ToString();
                    }
                    else if (e.Row.Cells[i].Text == "Address3")
                    {
                        e.Row.Cells[i].Text = this.Chk_addressList.Items[3].Text.ToString();
                    }
                    else if (e.Row.Cells[i].Text == "Address4")
                    {
                        e.Row.Cells[i].Text = this.Chk_addressList.Items[4].Text.ToString();
                    }
                    else if (e.Row.Cells[i].Text == "Address5")
                    {
                        e.Row.Cells[i].Text = this.Chk_addressList.Items[5].Text.ToString();
                    }
                    else if (e.Row.Cells[i].Text == "Country")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Country");
                    }
                    else if (e.Row.Cells[i].Text == "Fax")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Fax");
                    }
                    else if (e.Row.Cells[i].Text == "IsPostBoxAddress")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("IsPostBoxAddress");
                    }
                    else if (e.Row.Cells[i].Text == "TotalEstimate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Total_Estimate");
                        this.cellvalue_TotalEstimate = i;
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.flag_TotalEstimate = "true";
                    }
                    else if (e.Row.Cells[i].Text == "EstValue")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_EstimateValue = i;
                        this.flag_EstimateValue = "true";
                    }
                    else if (e.Row.Cells[i].Text == "TotalJob")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Total_Job");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_TotalJob = i;
                        this.flag_TotalJob = "true";
                    }
                    else if (e.Row.Cells[i].Text == "JobValue")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_JobValue = i;
                        this.flag_JobValue = "true";
                    }
                    else if (e.Row.Cells[i].Text == "TotalInvoice")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Total_Invoice");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_TotalInvoice = i;
                        this.flag_TotalInvoice = "true";
                    }
                    else if (e.Row.Cells[i].Text == "InvoiceValue")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Invoice_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_InvoiceValue = i;
                        this.flag_InvoiceValue = "true";
                    }
                    else if (e.Row.Cells[i].Text == "EstimateJobconversioncount")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_count");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_EstJobConversionCount = i;
                        this.flag_EstJobConversionCount = "true";
                    }
                    else if (e.Row.Cells[i].Text == "EstimateJobconversionvalue")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_value");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cellvalue_EstJobConversionValue = i;
                        this.flag_EstJobConversionValue = "true";
                    }
                    else if (e.Row.Cells[i].Text == "salutation")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Title");
                    }
                    else if (e.Row.Cells[i].Text == "MainApprover")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Main_Approver");
                    }
                    else if (e.Row.Cells[i].Text == "SubscribeUser")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Subscribed_User");
                    }
                    else if (e.Row.Cells[i].Text == "IsReceiveMailOut")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Receive_Mail_out");
                    }
                    else if (e.Row.Cells[i].Text == "ContactID")
                    {
                        e.Row.Cells[i].Visible = false;
                        this.cellvalue_contactID = i;
                        this.flag_contactID = "true";
                    }

                    // Department additional information Custom Field 1 to 5
                    else if (e.Row.Cells[i].Text == "DepartmentCustomField1")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field1");
                    }
                    else if (e.Row.Cells[i].Text == "DepartmentCustomField2")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field2");
                    }
                    else if (e.Row.Cells[i].Text == "DepartmentCustomField3")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field3");
                    }
                    else if (e.Row.Cells[i].Text == "DepartmentCustomField4")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field4");
                    }
                    else if (e.Row.Cells[i].Text == "DepartmentCustomField5")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field5");
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                if (this.flag_AcOpenedDate == "true")
                {
                    e.Row.Cells[this.cellvalue_AcOpenedDate].Text = this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cellvalue_AcOpenedDate].Text, this.CompanyID, this.UserID, true);
                }
                if (this.flag_TotalEstimate == "true")
                {
                    e.Row.Cells[this.cellvalue_TotalEstimate].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_TotalEstimate].ID = "TotalEstimate";
                }
                if (this.flag_EstimateValue == "true")
                {
                    e.Row.Cells[this.cellvalue_EstimateValue].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_EstimateValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_EstimateValue].Text), 0, "", false, false, true);
                    e.Row.Cells[this.cellvalue_EstimateValue].ID = "EstValue";
                }
                if (this.flag_TotalJob == "true")
                {
                    e.Row.Cells[this.cellvalue_TotalJob].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_TotalJob].ID = "TotalJob";
                }
                if (this.flag_JobValue == "true")
                {
                    e.Row.Cells[this.cellvalue_JobValue].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_JobValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_JobValue].Text), 0, "", false, false, true);
                    e.Row.Cells[this.cellvalue_JobValue].ID = "JobValue";
                }
                if (this.flag_TotalInvoice == "true")
                {
                    e.Row.Cells[this.cellvalue_TotalInvoice].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_TotalInvoice].ID = "TotalInvoice";
                }
                if (this.flag_InvoiceValue == "true")
                {
                    e.Row.Cells[this.cellvalue_InvoiceValue].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_InvoiceValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_InvoiceValue].Text), 0, "", false, false, true);
                    e.Row.Cells[this.cellvalue_InvoiceValue].ID = "InvoiceValue";
                }
                if (this.flag_EstJobConversionCount == "true")
                {
                    e.Row.Cells[this.cellvalue_EstJobConversionCount].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_EstJobConversionCount].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_EstJobConversionCount].Text), 0, "", false, false, true);
                    e.Row.Cells[this.cellvalue_EstJobConversionCount].ID = "EstimateJobconversioncount";
                }
                if (this.flag_EstJobConversionValue == "true")
                {
                    e.Row.Cells[this.cellvalue_EstJobConversionValue].Attributes.Add("align", "right");
                    e.Row.Cells[this.cellvalue_EstJobConversionValue].Text = e.Row.Cells[this.cellvalue_EstJobConversionValue].Text.Replace("&nbsp;", "0");
                    e.Row.Cells[this.cellvalue_EstJobConversionValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_EstJobConversionValue].Text), 0, "", false, false, true);
                    e.Row.Cells[this.cellvalue_EstJobConversionValue].ID = "EstimateJobconversionvalue";
                }
                if (this.flag_contactID == "true")
                {
                    e.Row.Cells[this.cellvalue_contactID].Visible = false;
                }
                if (this.flag_ProfitMargin == "true")
                {
                    e.Row.Cells[this.cellvalue_ProfitMargin].Attributes.Add("align", "right");
                    if (e.Row.Cells[this.cellvalue_ProfitMargin].Text != "&nbsp;")
                    {
                        e.Row.Cells[this.cellvalue_ProfitMargin].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cellvalue_ProfitMargin].Text), 0, "", false, false, true);
                    }
                }
                for (int j = 0; j < e.Row.Cells.Count; j++)
                {
                    e.Row.Cells[j].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", e.Row.Cells[j].Text, "</div></div>");
                }
            }
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
                        int num35 = month12 - 2;
                        month12 = month12 - 4;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] languageConversion;
            this.CompanyID = Convert.ToInt32(this.Session["companyid"]);
            this.companytype = "Customer";
            this.objBase.ReturnRoles_Privileges_Reports("crm", "showreport", "");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            if (baseClass.ReturnRoles_Privileges_ReportStatus("crm", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.CurrencySymbol = this.objJava.GetCurrencyinRequiredFormate("", true);
            this.pnlMask.Visible = true;
            try
            {
                this.paperType = this.objJava.settings_paperMeasurementType(this.CompanyID);
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                if (base.Request.Params["pg"] == null)
                {
                    this.pagename = "client";
                }
                else if (base.Request.Params["pg"].ToString().Trim().ToLower() == "report")
                {
                    this.pagename = "Report";
                }
                global.pageName = this.pagename;
                global.pgName = "";
                this.gloobj.setpagename(this.pagename);
                languageClass _languageClass = new languageClass();
                base.Title = _languageClass.convert(global.pageTitle("CRM Report", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                if (this.pagename.ToString().ToLower().Trim() != "report")
                {
                    languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Client_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("CRM_Report")));
                }
                else
                {
                    base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../common/report.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Reports"), "</a>&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("CRM_Report")));
                }
                this.DateFormat = this.Session["Dateformat"].ToString();
                this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
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
                this.spn_daily_c.InnerText = string.Concat("(", this.day[0].ToString(), ")");
                commonClass _commonClass2 = this.objJava;
                string str1 = dateTime.AddDays(-1).ToString();
                char[] chrArray1 = new char[] { ' ' };
                string str2 = _commonClass2.Eprint_return_Date_Before_View(str1.Split(chrArray1)[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray2 = new char[] { ' ' };
                this.yestday = str2.Split(chrArray2);
                this.spn_yest.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
                this.spn_yest_c.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
                this.CurrentMonth().Split(new char[] { ',' });
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
                HtmlGenericControl spnMonthC = this.spn_month_c;
                string[] strArrays1 = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
                spnMonthC.InnerText = string.Concat(strArrays1);
                string[] strArrays2 = this.CurrentQuater().Split(new char[] { ',' });
                string str5 = strArrays2[0].ToString();
                char[] chrArray5 = new char[] { ' ' };
                this.stquardate = str5.Split(chrArray5);
                string str6 = strArrays2[1].ToString();
                char[] chrArray6 = new char[] { ' ' };
                this.enquardate = str6.Split(chrArray6);
                HtmlGenericControl spnQuarter = this.spn_quarter;
                string[] strArrays3 = new string[] { "(", this.objJava.Eprint_return_Date_Before_View(this.stquardate[0].ToString(), this.CompanyID, this.UserID, false), " to ", this.objJava.Eprint_return_Date_Before_View(this.enquardate[0].ToString(), this.CompanyID, this.UserID, false), ")" };
                spnQuarter.InnerText = string.Concat(strArrays3);
                HtmlGenericControl spnQuarterC = this.spn_quarter_c;
                string[] strArrays4 = new string[] { "(", this.objJava.Eprint_return_Date_Before_View(this.stquardate[0].ToString(), this.CompanyID, this.UserID, false), " to ", this.objJava.Eprint_return_Date_Before_View(this.enquardate[0].ToString(), this.CompanyID, this.UserID, false), ")" };
                spnQuarterC.InnerText = string.Concat(strArrays4);
                string[] strArrays5 = this.LastQuarter().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastquardate = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays5[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastquardate = str8.Split(chrArray8);
                HtmlGenericControl spnLastque = this.spn_lastque;
                string[] strArrays6 = new string[] { "(", this.stlastquardate[0].ToString(), " to ", this.enlastquardate[0].ToString(), ")" };
                spnLastque.InnerText = string.Concat(strArrays6);
                HtmlGenericControl spnLastqueC = this.spn_lastque_c;
                string[] strArrays7 = new string[] { "(", this.stlastquardate[0].ToString(), " to ", this.enlastquardate[0].ToString(), ")" };
                spnLastqueC.InnerText = string.Concat(strArrays7);
                string[] strArrays8 = this.HalfFiscalYear().Split(new char[] { ',' });
                string str9 = this.objJava.Eprint_return_Date_Before_View(strArrays8[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray9 = new char[] { ' ' };
                this.from_halffiscalyear = str9.Split(chrArray9);
                string str10 = this.objJava.Eprint_return_Date_Before_View(strArrays8[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray10 = new char[] { ' ' };
                this.to_halffiscalyear = str10.Split(chrArray10);
                HtmlGenericControl spnHalfyear = this.spn_halfyear;
                string[] strArrays9 = new string[] { "(", this.from_halffiscalyear[0].ToString(), " to ", this.to_halffiscalyear[0].ToString(), ")" };
                spnHalfyear.InnerText = string.Concat(strArrays9);
                HtmlGenericControl spn_halfyearC = this.spn__halfyear_c;
                string[] strArrays10 = new string[] { "(", this.from_halffiscalyear[0].ToString(), " to ", this.to_halffiscalyear[0].ToString(), ")" };
                spn_halfyearC.InnerText = string.Concat(strArrays10);
                string[] strArrays11 = this.CurrentFiscalYear().Split(new char[] { ',' });
                string str11 = this.objJava.Eprint_return_Date_Before_View(strArrays11[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray11 = new char[] { ' ' };
                this.startyear = str11.Split(chrArray11);
                string str12 = this.objJava.Eprint_return_Date_Before_View(strArrays11[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray12 = new char[] { ' ' };
                this.endyear = str12.Split(chrArray12);
                HtmlGenericControl spnYear = this.spn_year;
                string[] strArrays12 = new string[] { "(", this.startyear[0].ToString(), " to ", this.endyear[0].ToString(), ")" };
                spnYear.InnerText = string.Concat(strArrays12);
                HtmlGenericControl spnYearC = this.spn_year_c;
                string[] str13 = new string[] { "(", this.startyear[0].ToString(), " to ", this.endyear[0].ToString(), ")" };
                spnYearC.InnerText = string.Concat(str13);
                commonClass _commonClass3 = this.objJava;
                string str14 = dateTime.AddDays(-30).ToString();
                char[] chrArray13 = new char[] { ' ' };
                string str15 = _commonClass3.Eprint_return_Date_Before_View(str14.Split(chrArray13)[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray14 = new char[] { ' ' };
                this.past30days = str15.Split(chrArray14);
                HtmlGenericControl spnpast30days = this.Spnpast30days;
                string[] strArrays13 = new string[] { "(", this.past30days[0].ToString(), " to ", this.day[0].ToString(), ")" };
                spnpast30days.InnerText = string.Concat(strArrays13);
                commonClass _commonClass4 = this.objJava;
                string str16 = dateTime.AddDays(-45).ToString();
                chrArray = new char[] { ' ' };
                string str17 = _commonClass4.Eprint_return_Date_Before_View(str16.Split(chrArray)[0].ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.past45days = str17.Split(chrArray);
                HtmlGenericControl spanpast45days = this.Spanpast45days;
                languageConversion = new string[] { "(", this.past45days[0].ToString(), " to ", this.day[0].ToString(), ")" };
                spanpast45days.InnerText = string.Concat(languageConversion);
                commonClass _commonClass5 = this.objJava;
                now = dateTime.AddDays(-60);
                string str18 = now.ToString();
                chrArray = new char[] { ' ' };
                string str19 = _commonClass5.Eprint_return_Date_Before_View(str18.Split(chrArray)[0].ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.past60days = str19.Split(chrArray);
                HtmlGenericControl spnpast60days = this.Spnpast60days;
                languageConversion = new string[] { "(", this.past60days[0].ToString(), " to ", this.day[0].ToString(), ")" };
                spnpast60days.InnerText = string.Concat(languageConversion);
                commonClass _commonClass6 = this.objJava;
                now = dateTime.AddDays(-90);
                string str20 = now.ToString();
                chrArray = new char[] { ' ' };
                string str21 = _commonClass6.Eprint_return_Date_Before_View(str20.Split(chrArray)[0].ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.past90days = str21.Split(chrArray);
                HtmlGenericControl spnpast90days = this.Spnpast90days;
                languageConversion = new string[] { "(", this.past90days[0].ToString(), " to ", this.day[0].ToString(), ")" };
                spnpast90days.InnerText = string.Concat(languageConversion);
                commonClass _commonClass7 = this.objJava;
                now = dateTime.AddDays(-120);
                string str22 = now.ToString();
                chrArray = new char[] { ' ' };
                string str23 = _commonClass7.Eprint_return_Date_Before_View(str22.Split(chrArray)[0].ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.past120days = str23.Split(chrArray);
                HtmlGenericControl spnpast120days = this.Spnpast120days;
                languageConversion = new string[] { "(", this.past120days[0].ToString(), " to ", this.day[0].ToString(), ")" };
                spnpast120days.InnerText = string.Concat(languageConversion);
                commonClass _commonClass8 = this.objJava;
                now = dateTime.AddDays(-365);
                string str24 = now.ToString();
                chrArray = new char[] { ' ' };
                string str25 = _commonClass8.Eprint_return_Date_Before_View(str24.Split(chrArray)[0].ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.past365days = str25.Split(chrArray);
                HtmlGenericControl spnpast365days = this.Spnpast365days;
                languageConversion = new string[] { "(", this.past365days[0].ToString(), " to ", this.day[0].ToString(), ")" };
                spnpast365days.InnerText = string.Concat(languageConversion);
                HtmlGenericControl htmlGenericControl = this.spnestvaluecurrentmonth;
                languageConversion = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
                htmlGenericControl.InnerText = string.Concat(languageConversion);
                now = new DateTime(dateTime.Year, dateTime.Month, 1);
                DateTime dateTime4 = now.AddMonths(-1);
                now = new DateTime(dateTime.Year, dateTime.Month, 1);
                DateTime dateTime5 = now.AddDays(-1);
                string str26 = this.objJava.Eprint_return_Date_Before_View(dateTime4.ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.laststdate = str26.Split(chrArray);
                string str27 = this.objJava.Eprint_return_Date_Before_View(dateTime5.ToString(), this.CompanyID, this.UserID, false);
                chrArray = new char[] { ' ' };
                this.lastenddate = str27.Split(chrArray);
                HtmlGenericControl htmlGenericControl1 = this.spnestvaluelastmonth;
                languageConversion = new string[] { "(", this.laststdate[0].ToString(), " to ", this.lastenddate[0].ToString(), ")" };
                htmlGenericControl1.InnerText = string.Concat(languageConversion);
                HtmlGenericControl htmlGenericControl2 = this.spnjobvaluecurrentmonth;
                languageConversion = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
                htmlGenericControl2.InnerText = string.Concat(languageConversion);
                HtmlGenericControl htmlGenericControl3 = this.spnjobvaluelastmonth;
                languageConversion = new string[] { "(", this.laststdate[0].ToString(), " to ", this.lastenddate[0].ToString(), ")" };
                htmlGenericControl3.InnerText = string.Concat(languageConversion);
                try
                {
                    string[] strArrays31 = this.Lastweek().Split(new char[] { ',' });
                    string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays31[0].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray71 = new char[] { ' ' };
                    this.stlastweek = str71.Split(chrArray71);
                    string str81 = this.objJava.Eprint_return_Date_Before_View(strArrays31[1].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray81 = new char[] { ' ' };
                    this.enlastweek = str81.Split(chrArray81);
                    HtmlGenericControl spnLastweek = this.spn_lastweek;
                    string[] strArrays41 = new string[] { "(", this.stlastweek[0].ToString(), " to ", this.enlastweek[0].ToString(), ")" };
                    spnLastweek.InnerText = string.Concat(strArrays41);
                }
                catch
                {
                }
                try
                {
                    string[] strArrays31 = this.Lastmonth().Split(new char[] { ',' });
                    string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays31[0].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray71 = new char[] { ' ' };
                    this.stlastmonth = str71.Split(chrArray71);
                    string str81 = this.objJava.Eprint_return_Date_Before_View(strArrays31[1].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray81 = new char[] { ' ' };
                    this.enlastmonth = str81.Split(chrArray81);
                    HtmlGenericControl spnLastmonth = this.spn_lastmonth;
                    string[] strArrays41 = new string[] { "(", this.stlastmonth[0].ToString(), " to ", this.enlastmonth[0].ToString(), ")" };
                    spnLastmonth.InnerText = string.Concat(strArrays41);
                }
                catch
                {
                }
                try
                {
                    string[] strArrays31 = this.Lastyear().Split(new char[] { ',' });
                    string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays31[0].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray71 = new char[] { ' ' };
                    this.stlastyear = str71.Split(chrArray71);
                    string str81 = this.objJava.Eprint_return_Date_Before_View(strArrays31[1].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray81 = new char[] { ' ' };
                    this.enlastyear = str81.Split(chrArray81);
                    HtmlGenericControl spnLastyear = this.spn_lastyear;
                    string[] strArrays41 = new string[] { "(", this.stlastyear[0].ToString(), " to ", this.enlastyear[0].ToString(), ")" };
                    spnLastyear.InnerText = string.Concat(strArrays41);
                }
                catch
                {
                }
                HtmlGenericControl spn_ddlContactDateOption_annualYear1 = this.spn_ddlContactDateOption_annualYear;
                string[] strArrays333 = new string[] { "(",
                    this.objJava.Eprint_return_Date_Before_View(
                        ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                            ,
                                " to ",
                    this.objJava.Eprint_return_Date_Before_View(
                                ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                                , ")" };
                spn_ddlContactDateOption_annualYear1.InnerText = string.Concat(strArrays333);

                HtmlGenericControl spn_rdlDate_AnnualYear1 = this.spn_rdlDate_AnnualYear;
                string[] strArrays3331 = new string[] { "(",
                    this.objJava.Eprint_return_Date_Before_View(
                        ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                            ,
                                " to ",
                    this.objJava.Eprint_return_Date_Before_View(
                              ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                                , ")" };
                spn_rdlDate_AnnualYear1.InnerText = string.Concat(strArrays3331);

                int count = this.chkColumns.Items.Count;
                if (!base.IsPostBack)
                {
                    DataTable dataTable = SettingsBasePage.settings_CompanyType_select_ForClient(this.CompanyID, "Customer");
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        dataTable.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["companytype"] = row["companytype"].ToString();
                    }
                    this.lstCustomerType.DataSource = dataTable;
                    this.lstCustomerType.DataTextField = "companytype";
                    this.lstCustomerType.DataValueField = "id";
                    this.lstCustomerType.DataBind();
                    this.getAddressValue_FromSettings();
                    this.Panel1.Visible = true;
                    this.pnlDateOption_Disable.Visible = true;
                    this.txtFrom.Text = DateTime.Now.ToShortDateString();
                    this.txtFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox = this.txtFrom;
                    commonClass _commonClass9 = this.objJava;
                    now = DateTime.Now;
                    textBox.Text = _commonClass9.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtTo.Text = DateTime.Now.ToShortDateString();
                    this.txtTo.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox1 = this.txtTo;
                    commonClass _commonClass10 = this.objJava;
                    now = DateTime.Now;
                    textBox1.Text = _commonClass10.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtfromdate_converted.Text = DateTime.Now.ToShortDateString();
                    this.txtfromdate_converted.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox txtfromdateConverted = this.txtfromdate_converted;
                    commonClass _commonClass11 = this.objJava;
                    now = DateTime.Now;
                    txtfromdateConverted.Text = _commonClass11.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txttodate_converted.Text = DateTime.Now.ToShortDateString();
                    this.txttodate_converted.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox txttodateConverted = this.txttodate_converted;
                    commonClass _commonClass12 = this.objJava;
                    now = DateTime.Now;
                    txttodateConverted.Text = _commonClass12.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtNoActivityinPastFromdate.Text = DateTime.Now.ToShortDateString();
                    this.txtNoActivityinPastFromdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox2 = this.txtNoActivityinPastFromdate;
                    commonClass _commonClass13 = this.objJava;
                    now = DateTime.Now;
                    textBox2.Text = _commonClass13.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtNoActivityinPastTodate.Text = DateTime.Now.ToShortDateString();
                    this.txtNoActivityinPastTodate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox3 = this.txtNoActivityinPastTodate;
                    commonClass _commonClass14 = this.objJava;
                    now = DateTime.Now;
                    textBox3.Text = _commonClass14.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtestvalueFromdate.Text = DateTime.Now.ToShortDateString();
                    this.txtestvalueFromdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox4 = this.txtestvalueFromdate;
                    commonClass _commonClass15 = this.objJava;
                    now = DateTime.Now;
                    textBox4.Text = _commonClass15.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtestvalueTodate.Text = DateTime.Now.ToShortDateString();
                    this.txtestvalueTodate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox5 = this.txtestvalueTodate;
                    commonClass _commonClass16 = this.objJava;
                    now = DateTime.Now;
                    textBox5.Text = _commonClass16.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtjobvalueFromdate.Text = DateTime.Now.ToShortDateString();
                    this.txtjobvalueFromdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox6 = this.txtjobvalueFromdate;
                    commonClass _commonClass17 = this.objJava;
                    now = DateTime.Now;
                    textBox6.Text = _commonClass17.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.txtjobvalueTodate.Text = DateTime.Now.ToShortDateString();
                    this.txtjobvalueTodate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox7 = this.txtjobvalueTodate;
                    commonClass _commonClass18 = this.objJava;
                    now = DateTime.Now;
                    textBox7.Text = _commonClass18.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    if (ConnectionClass.Tax2 != null && !(ConnectionClass.Tax2.ToLower() == "yes"))
                    {
                        this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Tax");
                        this.chkColumns.Items.Remove(this.chkColumns.Items[10]);
                    }                    
                }
                if (base.IsPostBack)
                {
                    this.Panel1.Visible = false;
                }
                this.usrPaging.Visible = false;
                this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                if (!base.IsPostBack)
                {
                    this.Session["DeleteMsg"] = null;
                    this.Session["SaveAsNew"] = null;
                    this.pnlReports.Visible = true;
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Testing", "pageloadcheck();", true);
                }
                this.usrReportsave.OnReportClick += new SavingReportEventHandler(this.usrReportsave_OnReportClick);
                this.usrReportsave.OnEditClick += new EditReportEventHandler(this.usrReportsave_OnEditClick);
                this.usrReportsave.OnDeleteClick += new DeleteReportEventHandler(this.usrReportsave_OnDeleteClick);
                this.usrReportsave.OnPageIndexChanged += new OnPageIndexChangedClick(this.usrReportsave_OnPageIndexChanged);
                this.usrReportsave.OnPageSizeChanged += new OnPageSizeChangedClick(this.usrReportsave_OnPageSizeChanged);
            }
            catch
            {
            }
            if (ConnectionClass.ServerName.ToLower() != "coralcoast")
            {
                foreach (ListItem item in this.chkColumns.Items)
                {
                    if (item.Value != "RoyalityFree")
                    {
                        continue;
                    }
                    item.Attributes.Add("style", "display:none");
                    this.chkColumns.Items[23].Selected = false;
                }
            }
            else
            {
                foreach (ListItem listItem in this.chkColumns.Items)
                {
                    if (listItem.Value != "RoyalityFree")
                    {
                        continue;
                    }
                    listItem.Attributes.Add("style", "display:block");
                }
            }
            this.pnlMask.Visible = false;
            this.Chk_CompanyInfo.Text = this.objLangClass.GetLanguageConversion("Company_Information");
            this.Chk_contacts.Text = this.objLangClass.GetLanguageConversion("Contacts");
            this.Chk_Department.Text = this.objLangClass.GetLanguageConversion("Department");
            this.Chk_address.Text = this.objLangClass.GetLanguageConversion("Address");
            this.chkAggCustomer.Text = this.objLangClass.GetLanguageConversion("Show_Aggregate_Functions_To_Customer");
            this.chkDateOption.Text = this.objLangClass.GetLanguageConversion("Customer_Date_Option");
            this.chkContactDateOption.Text = this.objLangClass.GetLanguageConversion("Contact_Date_Option");
            this.chkNoActivityinPast.Text = this.objLangClass.GetLanguageConversion("No_Activity_in_past");
            this.chkestimatevaluerange.Text = this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1");
            this.chkjobvaluerange.Text = this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax");
            this.chk_Estimate.Text = this.objLangClass.GetLanguageConversion("Estimate");
            this.chk_Job.Text = this.objLangClass.GetLanguageConversion("Job");
            this.ddlCompanyType.Items[0].Text = string.Concat("---", this.objLangClass.GetLanguageConversion("Any"), "---");
            this.ddlCompanyType.Items[1].Text = this.objLangClass.GetLanguageConversion("Customer");
            this.ddlCompanyType.Items[2].Text = this.objLangClass.GetLanguageConversion("Supplier");
            this.ddlCompanyType.Items[3].Text = this.objLangClass.GetLanguageConversion("Prospect");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnSaveRun.Text = this.objLangClass.GetLanguageConversion("Save_And_Run");
            this.btnUpdateExisting.Text = this.objLangClass.GetLanguageConversion("Update_Report");
            this.btnRunReport.Text = this.objLangClass.GetLanguageConversion("Run_Report");
            this.btnfilter.ToolTip = this.objLangClass.GetLanguageConversion("Back_To_Search_Option");
            this.btnExport.ToolTip = this.objLangClass.GetLanguageConversion("Export");
            this.RadPanelBar1.Items[0].Text = this.objLangClass.GetLanguageConversion("Select_Columns_To_Run_Report");
            this.RadPanelBar1.Items[1].Text = this.objLangClass.GetLanguageConversion("Sort_The_Records");
            this.RadPanelBar1.Items[2].Text = this.objLangClass.GetLanguageConversion("Report_Filters");
            this.RadPanelBar1.Items[3].Text = this.objLangClass.GetLanguageConversion("Show_Aggregate_Functions_For_Search_Results");
            this.RadPanelBar1.Items[4].Text = this.objLangClass.GetLanguageConversion("Save_Report_Options");
            this.ddlIndividual.Items[0].Text = this.objLangClass.GetLanguageConversion("One_Column");
            this.ddlIndividual.Items[1].Text = this.objLangClass.GetLanguageConversion("Individual_Column");
            this.Chk_DepartmentList.Items[0].Text = this.objLangClass.GetLanguageConversion("Department_Name");
            this.Chk_DepartmentList.Items[1].Text = this.objLangClass.GetLanguageConversion("Dept_Delivery_Address");
            this.Chk_DepartmentList.Items[2].Text = this.objLangClass.GetLanguageConversion("Dept_Invoice_Address");
            this.Chk_DepartmentList.Items[3].Text = this.objLangClass.GetLanguageConversion("Cost_Center");
            
            // Department additional information Custom Field 1 to 5
            this.Chk_DepartmentList.Items[4].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field1");
            this.Chk_DepartmentList.Items[5].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field2");
            this.Chk_DepartmentList.Items[6].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field3");
            this.Chk_DepartmentList.Items[7].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field4");
            this.Chk_DepartmentList.Items[8].Text = this.objLangClass.GetLanguageConversion("Department_Custom_Field5");

            this.rdlDate.Items[0].Text = this.objLangClass.GetLanguageConversion("Today");
            this.rdlDate.Items[1].Text = this.objLangClass.GetLanguageConversion("Yesterday");
            this.rdlDate.Items[2].Text = this.objLangClass.GetLanguageConversion("Current_Month");
            this.rdlDate.Items[3].Text = this.objLangClass.GetLanguageConversion("Current_Quarter");
            this.rdlDate.Items[4].Text = ePrintConstants.CurrentYearText;
            this.rdlDate.Items[5].Text = this.objLangClass.GetLanguageConversion("Last_Quarter");
            this.rdlDate.Items[6].Text = this.objLangClass.GetLanguageConversion("Current_Year_Fiscal");
            this.rdlDate.Items[7].Text = this.objLangClass.GetLanguageConversion("Half_Fiscal_year");
            this.rdlDate.Items[8].Text = this.objLangClass.GetLanguageConversion("All_time");
            this.rdlDate.Items[9].Text = this.objLangClass.GetLanguageConversion("Select_Date");
            this.Chk_addressList.Items[0].Text = this.objLangClass.GetLanguageConversion("Address_Labels");
            this.Chk_addressList.Items[1].Text = this.objLangClass.GetLanguageConversion("Address1");
            this.Chk_addressList.Items[2].Text = this.objLangClass.GetLanguageConversion("Address2");
            this.Chk_addressList.Items[3].Text = this.objLangClass.GetLanguageConversion("Address3");
            this.Chk_addressList.Items[4].Text = this.objLangClass.GetLanguageConversion("Address4");
            this.Chk_addressList.Items[5].Text = this.objLangClass.GetLanguageConversion("Address5");
            this.Chk_addressList.Items[6].Text = this.objLangClass.GetLanguageConversion("Country");
            this.Chk_addressList.Items[7].Text = this.objLangClass.GetLanguageConversion("Telephone");
            this.Chk_addressList.Items[8].Text = this.objLangClass.GetLanguageConversion("Fax");
            this.Chk_addressList.Items[9].Text = this.objLangClass.GetLanguageConversion("Is_Post_Box_Address");
            this.chkAggCustomeritems.Items[0].Text = this.objLangClass.GetLanguageConversion("Total_Estimate");
            this.chkAggCustomeritems.Items[1].Text = this.objLangClass.GetLanguageConversion("Estimate_Value_Exc_Tax1");
            this.chkAggCustomeritems.Items[2].Text = this.objLangClass.GetLanguageConversion("Total_Job");
            this.chkAggCustomeritems.Items[3].Text = this.objLangClass.GetLanguageConversion("Job_Value_Exc_Tax");
            this.chkAggCustomeritems.Items[4].Text = this.objLangClass.GetLanguageConversion("Total_Invoice");
            this.chkAggCustomeritems.Items[5].Text = this.objLangClass.GetLanguageConversion("Invoice_Value_Exc_Tax1");
            this.chkAggCustomeritems.Items[6].Text = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_count");
            this.chkAggCustomeritems.Items[7].Text = this.objLangClass.GetLanguageConversion("Estimate_Job_conversion_value");
            this.chkColumns.Items[0].Text = this.objLangClass.GetLanguageConversion("Company_Name");
            this.chkColumns.Items[1].Text = this.objLangClass.GetLanguageConversion("Company_Type");
            this.chkColumns.Items[2].Text = this.objLangClass.GetLanguageConversion("Type");
            this.chkColumns.Items[3].Text = this.objLangClass.GetLanguageConversion("Account_Status");
            this.chkColumns.Items[4].Text = this.objLangClass.GetLanguageConversion("Account_Number");
            this.chkColumns.Items[5].Text = this.objLangClass.GetLanguageConversion("Email");
            this.chkColumns.Items[6].Text = this.objLangClass.GetLanguageConversion("url");
            this.chkColumns.Items[7].Text = this.objLangClass.GetLanguageConversion("Credit_Limit");
            this.chkColumns.Items[8].Text = this.objLangClass.GetLanguageConversion("Credit_Ref");
            if (this.Tax2.ToLower() != "no")
            {
                this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Tax1");
                this.chkColumns.Items[10].Text = this.objLangClass.GetLanguageConversion("Tax2");
                this.chkColumns.Items[11].Text = this.objLangClass.GetLanguageConversion("Description");
                this.chkColumns.Items[12].Text = this.objLangClass.GetLanguageConversion("Payment_Terms");
                this.chkColumns.Items[13].Text = this.objLangClass.GetLanguageConversion("Profit_Margin");
                this.chkColumns.Items[14].Text = this.objLangClass.GetLanguageConversion("Tax_Reg_No");
                this.chkColumns.Items[15].Text = this.objLangClass.GetLanguageConversion("Company_Number");
                this.chkColumns.Items[16].Text = this.objLangClass.GetLanguageConversion("A_C_Opened");
                this.chkColumns.Items[17].Text = this.objLangClass.GetLanguageConversion("Bank_Code");
                this.chkColumns.Items[18].Text = this.objLangClass.GetLanguageConversion("Bank_Account_Number");
                this.chkColumns.Items[19].Text = this.objLangClass.GetLanguageConversion("Account_Name");
                this.chkColumns.Items[20].Text = this.objLangClass.GetLanguageConversion("Sales_Person");
                this.chkColumns.Items[21].Text = this.objLangClass.GetLanguageConversion("Referred_By");
                this.chkColumns.Items[22].Text = this.objLangClass.GetLanguageConversion("eStore_Name");
                this.chkColumns.Items[23].Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls"); 
                this.chkColumns.Items[24].Text = this.objLangClass.GetLanguageConversion("Royality_Free");
                
            }
            else
            {
                this.chkColumns.Items[10].Text = this.objLangClass.GetLanguageConversion("Description");
                this.chkColumns.Items[11].Text = this.objLangClass.GetLanguageConversion("Payment_Terms");
                this.chkColumns.Items[12].Text = this.objLangClass.GetLanguageConversion("Profit_Margin");
                this.chkColumns.Items[13].Text = this.objLangClass.GetLanguageConversion("Tax_Reg_No");
                this.chkColumns.Items[14].Text = this.objLangClass.GetLanguageConversion("Company_Number");
                this.chkColumns.Items[15].Text = this.objLangClass.GetLanguageConversion("A_C_Opened");
                this.chkColumns.Items[16].Text = this.objLangClass.GetLanguageConversion("Bank_Code");
                this.chkColumns.Items[17].Text = this.objLangClass.GetLanguageConversion("Bank_Account_Number");
                this.chkColumns.Items[18].Text = this.objLangClass.GetLanguageConversion("Account_Name");
                this.chkColumns.Items[19].Text = this.objLangClass.GetLanguageConversion("Sales_Person");
                this.chkColumns.Items[20].Text = this.objLangClass.GetLanguageConversion("Referred_By");
                this.chkColumns.Items[21].Text = this.objLangClass.GetLanguageConversion("eStore_Name");
                this.chkColumns.Items[22].Text = this.objLangClass.GetLanguageConversion("Open_Tasks_Calls");
                this.chkColumns.Items[23].Text = this.objLangClass.GetLanguageConversion("Royality_Free");
                
            }
           
            this.chk_contactsList.Items[0].Text = this.objLangClass.GetLanguageConversion("Contact_Name_First_Middle_Last");
            this.chk_contactsList.Items[1].Text = this.objLangClass.GetLanguageConversion("First_Name");
            this.chk_contactsList.Items[2].Text = this.objLangClass.GetLanguageConversion("Middle_Name");
            this.chk_contactsList.Items[3].Text = this.objLangClass.GetLanguageConversion("Last_Name");
            this.chk_contactsList.Items[4].Text = this.objLangClass.GetLanguageConversion("Title");
            this.chk_contactsList.Items[5].Text = this.objLangClass.GetLanguageConversion("Job_Title1");
            this.chk_contactsList.Items[6].Text = this.objLangClass.GetLanguageConversion("Job_Title2");
            this.chk_contactsList.Items[7].Text = this.objLangClass.GetLanguageConversion("Email");
            this.chk_contactsList.Items[8].Text = this.objLangClass.GetLanguageConversion("Mobile");
            this.chk_contactsList.Items[9].Text = this.objLangClass.GetLanguageConversion("Phone");
            this.chk_contactsList.Items[10].Text = this.objLangClass.GetLanguageConversion("Alternate_Number");
            this.chk_contactsList.Items[11].Text = this.objLangClass.GetLanguageConversion("Personal_Fax");
            this.chk_contactsList.Items[12].Text = this.objLangClass.GetLanguageConversion("Department");
            this.chk_contactsList.Items[13].Text = this.objLangClass.GetLanguageConversion("Contact_Address");
            this.chk_contactsList.Items[14].Text = this.objLangClass.GetLanguageConversion("Dept_Delivery_Address");
            this.chk_contactsList.Items[15].Text = this.objLangClass.GetLanguageConversion("Dept_Invoice_Address");
            this.chk_contactsList.Items[16].Text = this.objLangClass.GetLanguageConversion("MAin_approver");
            this.chk_contactsList.Items[17].Text = this.objLangClass.GetLanguageConversion("Subscribed_User");
            this.chk_contactsList.Items[18].Text = this.objLangClass.GetLanguageConversion("Receive_Mail_out");

            // Contact additional information Custom Field 1 to 5
            this.chk_contactsList.Items[19].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field1");
            this.chk_contactsList.Items[20].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field2");
            this.chk_contactsList.Items[21].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field3");
            this.chk_contactsList.Items[22].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field4");
            this.chk_contactsList.Items[23].Text = this.objLangClass.GetLanguageConversion("Contact_Custom_Field5");

            this.chkest.Text = this.objLangClass.GetLanguageConversion("Total_Est");
            this.chkjob.Text = this.objLangClass.GetLanguageConversion("Total_Job");
            this.chkinv.Text = this.objLangClass.GetLanguageConversion("Total_Inv");
            this.chkest1.Text = this.objLangClass.GetLanguageConversion("Total_Est_Value");
            this.chkjob1.Text = this.objLangClass.GetLanguageConversion("Total_Job_Value");
            this.chkinv1.Text = this.objLangClass.GetLanguageConversion("Total_Inv_Value");
            this.ddlGrouprecords.Items[1].Text = this.objLangClass.GetLanguageConversion("Daily");
            this.ddlGrouprecords.Items[2].Text = this.objLangClass.GetLanguageConversion("Sales_Person");
            AttributeCollection attributes = this.chkColumns.Items[0].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[0].Text, "','", this.chkColumns.Items[0].Value, "','0')" };
            attributes.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection = this.chkColumns.Items[1].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[1].Text, "','", this.chkColumns.Items[1].Value, "','1')" };
            attributeCollection.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes1 = this.chkColumns.Items[2].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[2].Text, "','", this.chkColumns.Items[2].Value, "','2')" };
            attributes1.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection1 = this.chkColumns.Items[3].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[3].Text, "','", this.chkColumns.Items[3].Value, "','3')" };
            attributeCollection1.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes2 = this.chkColumns.Items[4].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[4].Text, "','", this.chkColumns.Items[4].Value, "','4')" };
            attributes2.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection2 = this.chkColumns.Items[5].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[5].Text, "','", this.chkColumns.Items[5].Value, "','5')" };
            attributeCollection2.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes3 = this.chkColumns.Items[6].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[6].Text, "','", this.chkColumns.Items[6].Value, "','6')" };
            attributes3.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection3 = this.chkColumns.Items[7].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[7].Text, "','", this.chkColumns.Items[7].Value, "','7')" };
            attributeCollection3.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes4 = this.chkColumns.Items[8].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[8].Text, "','", this.chkColumns.Items[8].Value, "','8')" };
            attributes4.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection4 = this.chkColumns.Items[9].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[9].Text, "','", this.chkColumns.Items[9].Value, "','9')" };
            attributeCollection4.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes5 = this.chkColumns.Items[10].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[10].Text, "','", this.chkColumns.Items[10].Value, "','10')" };
            attributes5.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection5 = this.chkColumns.Items[11].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[11].Text, "','", this.chkColumns.Items[11].Value, "','11')" };
            attributeCollection5.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes6 = this.chkColumns.Items[12].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[12].Text, "','", this.chkColumns.Items[12].Value, "','12')" };
            attributes6.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection6 = this.chkColumns.Items[13].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[13].Text, "','", this.chkColumns.Items[13].Value, "','13')" };
            attributeCollection6.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes7 = this.chkColumns.Items[14].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[14].Text, "','", this.chkColumns.Items[14].Value, "','14')" };
            attributes7.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection7 = this.chkColumns.Items[15].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[15].Text, "','", this.chkColumns.Items[15].Value, "','15')" };
            attributeCollection7.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes8 = this.chkColumns.Items[16].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[16].Text, "','", this.chkColumns.Items[16].Value, "','16')" };
            attributes8.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection8 = this.chkColumns.Items[17].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[17].Text, "','", this.chkColumns.Items[17].Value, "','17')" };
            attributeCollection8.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes9 = this.chkColumns.Items[18].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[18].Text, "','", this.chkColumns.Items[18].Value, "','18')" };
            attributes9.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection9 = this.chkColumns.Items[19].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[19].Text, "','", this.chkColumns.Items[19].Value, "','19')" };
            attributeCollection9.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes10 = this.chkColumns.Items[20].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[20].Text, "','", this.chkColumns.Items[20].Value, "','20')" };
            attributes10.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection10 = this.chkColumns.Items[21].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue('", this.chkColumns.Items[21].Text, "','", this.chkColumns.Items[21].Value, "','21')" };
            attributeCollection10.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes11 = this.chkAggCustomeritems.Items[0].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[0].Text, "','", this.chkAggCustomeritems.Items[0].Value, "','0')" };
            attributes11.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection11 = this.chkAggCustomeritems.Items[1].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[1].Text, "','", this.chkAggCustomeritems.Items[1].Value, "','1')" };
            attributeCollection11.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes12 = this.chkAggCustomeritems.Items[2].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[2].Text, "','", this.chkAggCustomeritems.Items[2].Value, "','2')" };
            attributes12.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection12 = this.chkAggCustomeritems.Items[3].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[3].Text, "','", this.chkAggCustomeritems.Items[3].Value, "','3')" };
            attributeCollection12.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes13 = this.chkAggCustomeritems.Items[4].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[4].Text, "','", this.chkAggCustomeritems.Items[4].Value, "','4')" };
            attributes13.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection13 = this.chkAggCustomeritems.Items[5].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[5].Text, "','", this.chkAggCustomeritems.Items[5].Value, "','5')" };
            attributeCollection13.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributes14 = this.chkAggCustomeritems.Items[6].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[6].Text, "','", this.chkAggCustomeritems.Items[6].Value, "','6')" };
            attributes14.Add("onclick", string.Concat(languageConversion));
            AttributeCollection attributeCollection14 = this.chkAggCustomeritems.Items[7].Attributes;
            languageConversion = new string[] { "javascript:AddDDLValue_Aggregate('", this.chkAggCustomeritems.Items[7].Text, "','", this.chkAggCustomeritems.Items[7].Value, "','7')" };
            attributeCollection14.Add("onclick", string.Concat(languageConversion));
            this.ddlSortBy.Attributes.Add("onchange", "javascript:ddlsortByOnchange();");
            if (!base.IsPostBack)
            {
                string empty1 = string.Empty;
                if (this.objBase.ReturnRoles_Privileges_Others("showsellingprice").ToLower() == "false")
                {
                    this.chkest1.Enabled = false;
                    this.chkest1.Checked = false;
                    this.chkjob1.Enabled = false;
                    this.chkjob1.Checked = false;
                    this.chkinv1.Enabled = false;
                    this.chkinv1.Checked = false;
                    this.chkpo1.Enabled = false;
                    this.chkpo1.Checked = false;
                    this.chkAggCustomeritems.Items[1].Enabled = false;
                    this.chkAggCustomeritems.Items[3].Enabled = false;
                    this.chkAggCustomeritems.Items[5].Enabled = false;
                    return;
                }
                this.chkest1.Enabled = true;
                this.chkjob1.Enabled = true;
                this.chkinv1.Enabled = true;
                this.chkpo1.Enabled = true;
                this.chkAggCustomeritems.Items[1].Enabled = true;
                this.chkAggCustomeritems.Items[3].Enabled = true;
                this.chkAggCustomeritems.Items[5].Enabled = true;
            }
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

        protected void rdllist_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = this.ddlCompanyType.SelectedValue;
            DataTable dataTable = SettingsBasePage.settings_CompanyType_select_ForClient(this.CompanyID, selectedValue);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["companytype"] = row["companytype"].ToString();
            }
            this.lstCustomerType.DataSource = dataTable;
            this.lstCustomerType.DataTextField = "companytype";
            this.lstCustomerType.DataValueField = "id";
            this.lstCustomerType.DataBind();
        }

        private void ReportDetails(int ReportID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            for (int i = 0; i < this.chkAggCustomeritems.Items.Count; i++)
            {
                this.chkAggCustomeritems.Items[i].Selected = false;
                this.chkAggCustomer.Checked = false;
            }
            for (int j = 0; j < this.chkColumns.Items.Count; j++)
            {
                this.chkColumns.Items[j].Selected = false;
                this.Chk_CompanyInfo.Checked = false;
            }
            for (int k = 0; k < this.chk_contactsList.Items.Count; k++)
            {
                this.chk_contactsList.Items[k].Selected = false;
                this.Chk_contacts.Checked = false;
            }
            for (int l = 0; l < this.Chk_DepartmentList.Items.Count; l++)
            {
                this.Chk_DepartmentList.Items[l].Selected = false;
                this.Chk_Department.Checked = false;
            }
            for (int m = 0; m < this.Chk_addressList.Items.Count; m++)
            {
                this.Chk_addressList.Items[m].Selected = false;
                this.Chk_address.Checked = false;
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
                row["Status"].ToString();
                empty1 = row["CustomerType"].ToString();
                str1 = row["SortValue"].ToString();
                empty2 = row["Direction"].ToString();
                string[] strArrays = empty.Split(new char[] { 'µ' });
                for (int n = 0; n < (int)strArrays.Length; n++)
                {
                    if (strArrays[n] == "Chk_CompanyInfo")
                    {
                        this.Chk_CompanyInfo.Checked = true;
                    }
                    if (strArrays[n] == "CompanyName")
                    {
                        this.chkColumns.Items[0].Selected = true;
                    }
                    else if (strArrays[n] == "CompanyType")
                    {
                        this.chkColumns.Items[1].Selected = true;
                    }
                    else if (strArrays[n] == "Type")
                    {
                        this.chkColumns.Items[2].Selected = true;
                    }
                    else if (strArrays[n] == "AccountStatus")
                    {
                        this.chkColumns.Items[3].Selected = true;
                    }
                    else if (strArrays[n] == "AccountNo")
                    {
                        this.chkColumns.Items[4].Selected = true;
                    }
                    else if (strArrays[n] == "Email")
                    {
                        this.chkColumns.Items[5].Selected = true;
                    }
                    else if (strArrays[n] == "URL")
                    {
                        this.chkColumns.Items[6].Selected = true;
                    }
                    else if (strArrays[n] == "CreditLimit")
                    {
                        this.chkColumns.Items[7].Selected = true;
                    }
                    else if (strArrays[n] == "CreditRef")
                    {
                        this.chkColumns.Items[8].Selected = true;
                    }
                    if (this.Tax2.ToLower() == "no")
                    {
                        if (strArrays[n] == "Chk_CompanyInfo")
                        {
                            this.Chk_CompanyInfo.Checked = true;
                        }
                        if (strArrays[n] == "Tax1")
                        {
                            this.chkColumns.Items[9].Selected = true;
                        }
                        else if (strArrays[n] == "Description")
                        {
                            this.chkColumns.Items[10].Selected = true;
                        }
                        else if (strArrays[n] == "PaymentTerms")
                        {
                            this.chkColumns.Items[11].Selected = true;
                        }
                        else if (strArrays[n] == "ProfitMargin")
                        {
                            this.chkColumns.Items[12].Selected = true;
                        }
                        else if (strArrays[n] == "TaxRegNo")
                        {
                            this.chkColumns.Items[13].Selected = true;
                        }
                        else if (strArrays[n] == "CompanyNumber")
                        {
                            this.chkColumns.Items[14].Selected = true;
                        }
                        else if (strArrays[n] == "ACOpened")
                        {
                            this.chkColumns.Items[15].Selected = true;
                        }
                        else if (strArrays[n] == "BankCode")
                        {
                            this.chkColumns.Items[16].Selected = true;
                        }
                        else if (strArrays[n] == "BankAccountNumber")
                        {
                            this.chkColumns.Items[17].Selected = true;
                        }
                        else if (strArrays[n] == "AccountName")
                        {
                            this.chkColumns.Items[18].Selected = true;
                        }
                        else if (strArrays[n] == "SalesPerson")
                        {
                            this.chkColumns.Items[19].Selected = true;
                        }
                        else if (strArrays[n] == "name")
                        {
                            this.chkColumns.Items[20].Selected = true;
                        }
                        else if (strArrays[n] == "eStoreName")
                        {
                            this.chkColumns.Items[21].Selected = true;
                        }
                        else if (strArrays[n] == "OpenTasksCalls")
                        {
                            this.chkColumns.Items[22].Selected = true;
                        }
                        else if (strArrays[n] == "RoyalityFree")
                        {
                            this.chkColumns.Items[23].Selected = true;
                        }
                        
                    }
                    else if (strArrays[n] == "Tax1")
                    {
                        this.chkColumns.Items[9].Selected = true;
                    }
                    else if (strArrays[n] == "Tax2")
                    {
                        this.chkColumns.Items[10].Selected = true;
                    }
                    else if (strArrays[n] == "Description")
                    {
                        this.chkColumns.Items[11].Selected = true;
                    }
                    else if (strArrays[n] == "PaymentTerms")
                    {
                        this.chkColumns.Items[12].Selected = true;
                    }
                    else if (strArrays[n] == "ProfitMargin")
                    {
                        this.chkColumns.Items[13].Selected = true;
                    }
                    else if (strArrays[n] == "TaxRegNo")
                    {
                        this.chkColumns.Items[14].Selected = true;
                    }
                    else if (strArrays[n] == "CompanyNumber")
                    {
                        this.chkColumns.Items[15].Selected = true;
                    }
                    else if (strArrays[n] == "ACOpened")
                    {
                        this.chkColumns.Items[16].Selected = true;
                    }
                    else if (strArrays[n] == "BankCode")
                    {
                        this.chkColumns.Items[17].Selected = true;
                    }
                    else if (strArrays[n] == "BankAccountNumber")
                    {
                        this.chkColumns.Items[18].Selected = true;
                    }
                    else if (strArrays[n] == "AccountName")
                    {
                        this.chkColumns.Items[19].Selected = true;
                    }
                    else if (strArrays[n] == "SalesPerson")
                    {
                        this.chkColumns.Items[20].Selected = true;
                    }
                    else if (strArrays[n] == "name")
                    {
                        this.chkColumns.Items[21].Selected = true;
                    }
                    else if (strArrays[n] == "eStoreName")
                    {
                        this.chkColumns.Items[22].Selected = true;
                    }
                    else if (strArrays[n] == "OpenTasksCalls")
                    {
                        this.chkColumns.Items[23].Selected = true;
                    }
                    else if (strArrays[n] == "RoyalityFree")
                    {
                        this.chkColumns.Items[24].Selected = true;
                    }
                   

                    if (strArrays[n] == "Chk_contacts")
                    {
                        this.Chk_contacts.Checked = true;
                    }
                    if (strArrays[n] == "ContactName")
                    {
                        this.chk_contactsList.Items[0].Selected = true;
                    }
                    else if (strArrays[n] == "FirstName")
                    {
                        this.chk_contactsList.Items[1].Selected = true;
                    }
                    else if (strArrays[n] == "MiddleName")
                    {
                        this.chk_contactsList.Items[2].Selected = true;
                    }
                    else if (strArrays[n] == "LastName")
                    {
                        this.chk_contactsList.Items[3].Selected = true;
                    }
                    else if (strArrays[n] == "Title")
                    {
                        this.chk_contactsList.Items[4].Selected = true;
                    }
                    else if (strArrays[n] == "JobTitle1")
                    {
                        this.chk_contactsList.Items[5].Selected = true;
                    }
                    else if (strArrays[n] == "JobTitle2")
                    {
                        this.chk_contactsList.Items[6].Selected = true;
                    }
                    else if (strArrays[n] == "ContactEmail")
                    {
                        this.chk_contactsList.Items[7].Selected = true;
                    }
                    else if (strArrays[n] == "Mobile")
                    {
                        this.chk_contactsList.Items[8].Selected = true;
                    }
                    else if (strArrays[n] == "Phone")
                    {
                        this.chk_contactsList.Items[9].Selected = true;
                    }
                    else if (strArrays[n] == "AlternateNumber")
                    {
                        this.chk_contactsList.Items[10].Selected = true;
                    }
                    else if (strArrays[n] == "PersonalFax")
                    {
                        this.chk_contactsList.Items[11].Selected = true;
                    }
                    else if (strArrays[n] == "Department")
                    {
                        this.chk_contactsList.Items[12].Selected = true;
                    }
                    else if (strArrays[n] == "ContactAddress")
                    {
                        this.chk_contactsList.Items[13].Selected = true;
                    }
                    else if (strArrays[n] == "DeliveryAddress")
                    {
                        this.chk_contactsList.Items[14].Selected = true;
                    }
                    else if (strArrays[n] == "InvoiceAddress")
                    {
                        this.chk_contactsList.Items[15].Selected = true;
                    }
                    else if (strArrays[n] == "MainApprover")
                    {
                        this.chk_contactsList.Items[16].Selected = true;
                    }
                    else if (strArrays[n] == "SubscribedUser")
                    {
                        this.chk_contactsList.Items[17].Selected = true;
                    }
                    else if (strArrays[n] == "ReceiveMailout")
                    {
                        this.chk_contactsList.Items[18].Selected = true;
                    }

                    // contact additional information Custom Field 1 to 5
                    else if (strArrays[n] == "ContactCustomField1")
                    {
                        this.chk_contactsList.Items[19].Selected = true;
                    }
                    else if (strArrays[n] == "ContactCustomField2")
                    {
                        this.chk_contactsList.Items[20].Selected = true;
                    }
                    else if (strArrays[n] == "ContactCustomField3")
                    {
                        this.chk_contactsList.Items[21].Selected = true;
                    }
                    else if (strArrays[n] == "ContactCustomField4")
                    {
                        this.chk_contactsList.Items[22].Selected = true;
                    }
                    else if (strArrays[n] == "ContactCustomField5")
                    {
                        this.chk_contactsList.Items[23].Selected = true;
                    }

                    else if (strArrays[n] == "Chk_Department")
                    {
                        this.Chk_Department.Checked = true;
                    }
                    else if (strArrays[n] == "DepartmentName")
                    {
                        this.Chk_DepartmentList.Items[0].Selected = true;
                    }
                    else if (strArrays[n] == "DeliveryAddress1")
                    {
                        this.Chk_DepartmentList.Items[1].Selected = true;
                    }
                    else if (strArrays[n] == "InvoiceAddress1")
                    {
                        this.Chk_DepartmentList.Items[2].Selected = true;
                    }
                    else if (strArrays[n] == "Costcenter")
                    {
                        this.Chk_DepartmentList.Items[3].Selected = true;
                    }

                    // Department additional information Custom Field 1 to 5
                    else if (strArrays[n] == "DepartmentCustomField1")
                    {
                        this.Chk_DepartmentList.Items[4].Selected = true;
                    }
                    else if (strArrays[n] == "DepartmentCustomField2")
                    {
                        this.Chk_DepartmentList.Items[5].Selected = true;
                    }
                    else if (strArrays[n] == "DepartmentCustomField3")
                    {
                        this.Chk_DepartmentList.Items[6].Selected = true;
                    }
                    else if (strArrays[n] == "DepartmentCustomField4")
                    {
                        this.Chk_DepartmentList.Items[7].Selected = true;
                    }
                    else if (strArrays[n] == "DepartmentCustomField5")
                    {
                        this.Chk_DepartmentList.Items[8].Selected = true;
                    }

                    else if (strArrays[n] == "Chk_address")
                    {
                        this.Chk_address.Checked = true;
                    }
                    else if (strArrays[n] == "AddressLabel")
                    {
                        this.Chk_addressList.Items[0].Selected = true;
                    }
                    else if (strArrays[n] == "Address1")
                    {
                        this.Chk_addressList.Items[1].Selected = true;
                    }
                    else if (strArrays[n] == "Address2")
                    {
                        this.Chk_addressList.Items[2].Selected = true;
                    }
                    else if (strArrays[n] == "Address3")
                    {
                        this.Chk_addressList.Items[3].Selected = true;
                    }
                    else if (strArrays[n] == "Address4")
                    {
                        this.Chk_addressList.Items[4].Selected = true;
                    }
                    else if (strArrays[n] == "Address5")
                    {
                        this.Chk_addressList.Items[5].Selected = true;
                    }
                    else if (strArrays[n] == "Country")
                    {
                        this.Chk_addressList.Items[6].Selected = true;
                    }
                    else if (strArrays[n] == "Telephone")
                    {
                        this.Chk_addressList.Items[7].Selected = true;
                    }
                    else if (strArrays[n] == "Fax")
                    {
                        this.Chk_addressList.Items[8].Selected = true;
                    }
                    else if (strArrays[n] == "IsPostBoxAddress")
                    {
                        this.Chk_addressList.Items[9].Selected = true;
                    }
                    else if (strArrays[n] == "chkAggCustomer")
                    {
                        this.chkAggCustomer.Checked = true;
                    }
                    if (strArrays[n] == "TotalEstimate")
                    {
                        this.chkAggCustomeritems.Items[0].Selected = true;
                    }
                    else if (strArrays[n] == "EstimateValue")
                    {
                        this.chkAggCustomeritems.Items[1].Selected = true;
                    }
                    else if (strArrays[n] == "TotalJob")
                    {
                        this.chkAggCustomeritems.Items[2].Selected = true;
                    }
                    else if (strArrays[n] == "JobValue")
                    {
                        this.chkAggCustomeritems.Items[3].Selected = true;
                    }
                    else if (strArrays[n] == "TotalInvoice")
                    {
                        this.chkAggCustomeritems.Items[4].Selected = true;
                    }
                    else if (strArrays[n] == "InvoiceValue")
                    {
                        this.chkAggCustomeritems.Items[5].Selected = true;
                    }
                    else if (strArrays[n] == "EstimateJobconversioncount")
                    {
                        this.chkAggCustomeritems.Items[6].Selected = true;
                    }
                    else if (strArrays[n] == "EstimateJobconversionvalue")
                    {
                        this.chkAggCustomeritems.Items[7].Selected = true;
                    }
                }
                if (Convert.ToInt32(row["GroupedBy"]) != 0)
                {
                    base.SetDDLValue(this.ddlGrouprecords, row["GroupedBy"].ToString());
                }
                if (Convert.ToInt32(row["EstCount"]) != 1)
                {
                    this.chkest.Checked = false;
                }
                else
                {
                    this.chkest.Checked = true;
                }
                if (Convert.ToInt32(row["EstTotal"]) != 1)
                {
                    this.chkest1.Checked = false;
                }
                else
                {
                    this.chkest1.Checked = true;
                }
                if (Convert.ToInt32(row["EstAverage"]) != 1)
                {
                    this.chkjob.Checked = false;
                }
                else
                {
                    this.chkjob.Checked = true;
                }
                if (Convert.ToInt32(row["EstMaximum"]) != 1)
                {
                    this.chkjob1.Checked = false;
                }
                else
                {
                    this.chkjob1.Checked = true;
                }
                if (Convert.ToInt32(row["NetTotal"]) != 1)
                {
                    this.chkinv.Checked = false;
                }
                else
                {
                    this.chkinv.Checked = true;
                }
                if (Convert.ToInt32(row["NetAverage"]) != 1)
                {
                    this.chkinv1.Checked = false;
                }
                else
                {
                    this.chkinv1.Checked = true;
                }
                if (Convert.ToInt32(row["NetMaximum"]) != 1)
                {
                    this.chkpo.Checked = false;
                }
                else
                {
                    this.chkpo.Checked = true;
                }
                if (Convert.ToInt32(row["NetMinimum"]) != 1)
                {
                    this.chkpo1.Checked = false;
                }
                else
                {
                    this.chkpo1.Checked = true;
                }
                if (!(row["IsShowContactAddressOneColumn"].ToString() == "True") || !(row["IsShowDeliveryAddressOneColumn"].ToString() == "True") || !(row["IsShowInvoiceAddressOneColumn"].ToString() == "True"))
                {
                    this.ddlIndividual.SelectedValue = "OneColumn";
                }
                else
                {
                    this.ddlIndividual.SelectedValue = "IndividualColumn";
                }
                if (row["SearchKeyword"].ToString() != "")
                {
                    this.txtFreetext.Text = row["SearchKeyword"].ToString();
                }
                if (row["CompanyName"].ToString() != "")
                {
                    this.ddlCompanyType.SelectedValue = row["CompanyName"].ToString();
                }
                if (row["ReportName"].ToString() != "")
                {
                    this.txtSaveReports.Text = row["ReportName"].ToString();
                }
                if (empty1 != "")
                {
                    string[] strArrays1 = empty1.Split(new char[] { 'µ' });
                    for (int o = 0; o < (int)strArrays1.Length; o++)
                    {
                        for (int p = 0; p < this.lstCustomerType.Items.Count; p++)
                        {
                            if (this.lstCustomerType.Items[p].Value == strArrays1[o])
                            {
                                this.lstCustomerType.Items[p].Checked = true;
                            }
                        }
                    }
                }
                this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
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
                    else if (row["CreatedDateType"].ToString().Trim() == "td")
                    {
                        this.rdlDate.SelectedValue = "tilldate";
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
                    else if (row["CreatedDateType"].ToString().Trim() == "dr")
                    {
                        this.rdlDate.SelectedValue = "daterange";
                        this.txtFrom.Enabled = true;
                        this.txtTo.Enabled = true;
                        this.txtFrom.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtTo.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                }
                if (Convert.ToInt32(row["IsContactCreatedDate"]) != 1)
                {
                    this.chkContactDateOption.Checked = false;
                }
                else
                {
                    this.chkContactDateOption.Checked = true;
                    if (row["ContactDateType"].ToString().Trim() == "t")
                    {
                        this.ddlContactDateOption.SelectedValue = "daily";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "y")
                    {
                        this.ddlContactDateOption.SelectedValue = "yesterday";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "cm")
                    {
                        this.ddlContactDateOption.SelectedValue = "thismonth";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "cq")
                    {
                        this.ddlContactDateOption.SelectedValue = "thisquarter";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "ay")
                    {
                        this.ddlContactDateOption.SelectedValue = ePrintConstants.ThisAnnualYear;
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "lq")
                    {
                        this.ddlContactDateOption.SelectedValue = "lastquater";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "cy")
                    {
                        this.ddlContactDateOption.SelectedValue = "thisyear";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "hy")
                    {
                        this.ddlContactDateOption.SelectedValue = "halfyear";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "td")
                    {
                        this.ddlContactDateOption.SelectedValue = "tilldate";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "lw")
                    {
                        this.ddlContactDateOption.SelectedValue = "lastweek";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "lm")
                    {
                        this.ddlContactDateOption.SelectedValue = "lastmonth";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "ly")
                    {
                        this.ddlContactDateOption.SelectedValue = "lastyear";
                    }
                    else if (row["ContactDateType"].ToString().Trim() == "dr")
                    {
                        this.ddlContactDateOption.SelectedValue = "daterange";
                        this.txtfromdate_converted.Enabled = true;
                        this.txttodate_converted.Enabled = true;
                        this.txtfromdate_converted.Text = this.objJava.Eprint_return_Date_Before_View(row["ContactDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txttodate_converted.Text = this.objJava.Eprint_return_Date_Before_View(row["ContactDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                }

                // if show main contact checked --// added by shehzad
                if (Convert.ToInt32(row["IsShowMainContact"]) != 1)
                {
                    this.chkShowMainContact.Checked = false;
                }
                else
                {
                    this.chkShowMainContact.Checked = true;
                }

                if (Convert.ToInt32(row["IsNoPastActivityCreated"]) != 1)
                {
                    this.chkNoActivityinPast.Checked = false;
                }
                else
                {
                    this.chkNoActivityinPast.Checked = true;
                    if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "td")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "30";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "fd")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "45";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "sd")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "60";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]).TrimEnd(new char[0]) == "nd")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "90";
                    }
                    else if (row["NoPastActivityDays"].ToString() == "otd")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "120";
                    }
                    else if (row["NoPastActivityDays"].ToString() == "tsd")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "365";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "dr")
                    {
                        this.ddl_NoActivityinPast.SelectedValue = "daterange";
                        this.txtNoActivityinPastFromdate.Enabled = true;
                        this.txtNoActivityinPastTodate.Enabled = true;
                        this.txtNoActivityinPastFromdate.Text = this.objJava.Eprint_return_Date_Before_View(row["NoPastActivityFromDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtNoActivityinPastTodate.Text = this.objJava.Eprint_return_Date_Before_View(row["NoPastActivityToDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    if (Convert.ToInt32(row["chkEstimate"]) == 1 && Convert.ToInt32(row["chkJob"]) == 1)
                    {
                        this.chk_Estimate.Checked = true;
                        this.chk_Job.Checked = true;
                    }
                    else if (Convert.ToInt32(row["chkEstimate"]) == 1)
                    {
                        this.chk_Estimate.Checked = true;
                    }
                    else if (Convert.ToInt32(row["chkJob"]) == 1)
                    {
                        this.chk_Job.Checked = true;
                    }
                }
                if (Convert.ToInt32(row["IsEstimateValuerangeCreated"]) != 1)
                {
                    this.chkestimatevaluerange.Checked = false;
                }
                else
                {
                    this.chkestimatevaluerange.Checked = true;
                    if (row["EstimateValueRange"].ToString().TrimEnd(new char[0]) == "gt")
                    {
                        this.ddlestimatevaluerange.SelectedValue = "greater than";
                    }
                    else if (row["EstimateValueRange"].ToString().TrimEnd(new char[0]) == "lt")
                    {
                        this.ddlestimatevaluerange.SelectedValue = "less than";
                    }
                    else if (row["EstimateValueRange"].ToString().TrimEnd(new char[0]) == "et")
                    {
                        this.ddlestimatevaluerange.SelectedValue = "equals to";
                    }
                    if (Convert.ToDecimal(row["Filtervalue"]).ToString() != "")
                    {
                        this.txtestimatevaluerange.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Filtervalue"].ToString()), 0, "", false, false, true).Replace(",", "");
                    }
                    if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "cm")
                    {
                        this.ddlestimatevaluedaterange.SelectedValue = "current month";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "lm")
                    {
                        this.ddlestimatevaluedaterange.SelectedValue = "last month";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "dr")
                    {
                        this.ddlestimatevaluedaterange.SelectedValue = "daterange";
                        this.txtestvalueFromdate.Enabled = true;
                        this.txtestvalueTodate.Enabled = true;
                        this.txtestvalueFromdate.Text = this.objJava.Eprint_return_Date_Before_View(row["NoPastActivityFromDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtestvalueTodate.Text = this.objJava.Eprint_return_Date_Before_View(row["NoPastActivityToDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                }
                if (Convert.ToInt32(row["IsJobValuerangeCreated"]) != 1)
                {
                    this.chkjobvaluerange.Checked = false;
                }
                else
                {
                    this.chkjobvaluerange.Checked = true;
                    if (row["EstimateValueRange"].ToString().TrimEnd(new char[0]) == "gt")
                    {
                        this.ddljobvaluerange.SelectedValue = "greater than";
                    }
                    else if (row["EstimateValueRange"].ToString().TrimEnd(new char[0]) == "lt")
                    {
                        this.ddljobvaluerange.SelectedValue = "less than";
                    }
                    else if (row["EstimateValueRange"].ToString().TrimEnd(new char[0]) == "et")
                    {
                        this.ddljobvaluerange.SelectedValue = "equals to";
                    }
                    if (Convert.ToDecimal(row["Filtervalue"]).ToString() != "")
                    {
                        this.txtjobvaluerange.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Filtervalue"].ToString()), 0, "", false, false, true).Replace(",", "");
                    }
                    if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) == "cm")
                    {
                        this.ddljobvaluedaterange.SelectedValue = "current month";
                    }
                    else if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) != "lm")
                    {
                        if (row["NoPastActivityDays"].ToString().TrimEnd(new char[0]) != "dr")
                        {
                            continue;
                        }
                        this.ddljobvaluedaterange.SelectedValue = "daterange";
                        this.txtjobvalueFromdate.Enabled = true;
                        this.txtjobvalueTodate.Enabled = true;
                        this.txtjobvalueFromdate.Text = this.objJava.Eprint_return_Date_Before_View(row["NoPastActivityFromDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtjobvalueTodate.Text = this.objJava.Eprint_return_Date_Before_View(row["NoPastActivityToDate"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.ddljobvaluedaterange.SelectedValue = "last month";
                    }
                }
            }
            if (!string.IsNullOrEmpty(str1))
            {
                this.HdnSortBy.Value = str1.ToString().Trim();
            }
            this.ddlDirection.SelectedValue = empty2.ToString().Trim();
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
                this.Panel1.Visible = false;
                this.div_showfilters.Style.Add("display", "none");
                this.divusrReportsave.Style.Add("display", "none");
                this.divtab.Visible = false;
                this.btnfilter.Visible = true;
                if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("crm", "exportreport").Trim().ToLower() != "false")
                {
                    this.btnExport.Visible = true;
                }
                else
                {
                    this.btnExport.Visible = false;
                }
                this.divtoolbar.Visible = true;
                this.txt1.Visible = true;
                this.btngo.Visible = true;
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
                    if (this.ddlGrouprecords.SelectedIndex != 0)
                    {
                        this.GridEstReport.Visible = false;
                        this.usrPaging.Visible = false;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        this.div_Total.Visible = true;
                    }
                    else
                    {
                        this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
                        if (estimateData.Tables[0].Rows.Count == 0)
                        {
                            this.pnlEmptyRecords.Visible = true;
                            this.GridEstReport.Visible = false;
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
                            DataTable dt = SetClientReportColumns(estimateData);
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
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                            ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                            ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                            this.GridEstReport.Visible = true;
                            this.div_Total.Visible = false;
                            this.pnlEmptyRecords.Visible = false;
                            DataTable dt = SetClientReportColumns(estimateData);
                            this.GridEstReport.DataSource = dt;
                            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                            this.GridEstReport.DataBind();
                            // Commented for ticket 71979


                            foreach (GridDataItem currentItem in this.GridEstReport.Items)
                            {
                                string text = currentItem.Cells[0].Text;

                                foreach (GridDataItem item in this.GridEstReport.Items)
                                {
                                    if (item != currentItem && string.Compare(text, item.Cells[0].Text, true) == 0)
                                    {
                                        for (int l = 0; l < currentItem.Cells.Count; l++)
                                        {
                                            // Accessing columns by index in Telerik RadGrid
                                            var column = this.GridEstReport.MasterTableView.Columns[l];

                                            if (string.Compare(currentItem.Cells[l].Text, item.Cells[l].Text, true) == 0 && item.Cells[l].ID == null)
                                            {
                                                // Check if the column is not in the "CostCentre" column
                                                if (!column.UniqueName.Contains("CostCentre"))
                                                    item.Cells[l].Text = string.Empty;
                                            }
                                        }
                                    }
                                }
                            }




                            //for (int j = 0; j < this.GridEstReport.Rows.Count; j++)
                            //{
                            //    string text = this.GridEstReport.Rows[j].Cells[0].Text;
                            //    for (int k = j + 1; k < this.GridEstReport.Rows.Count; k++)
                            //    {
                            //        if (string.Compare(text, this.GridEstReport.Rows[k].Cells[0].Text, true) == 0)
                            //        {
                            //            for (int l = 0; l < this.GridEstReport.Rows[k].Cells.Count; l++)
                            //            {
                            //                if (string.Compare(this.GridEstReport.Rows[j].Cells[l].Text, this.GridEstReport.Rows[k].Cells[l].Text, true) == 0 && this.GridEstReport.Rows[k].Cells[l].ID == null)
                            //                {
                            //                    if (!this.GridEstReport.HeaderRow.Cells[l].Text.Trim().Contains("CostCentre"))
                            //                        this.GridEstReport.Rows[k].Cells[l].Text = string.Empty;
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                            this.usrPaging.Visible = false;
                            pagingreport.intCurrentPage = this.PageNumber;
                            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                            this.usrPaging.CreatePaging();
                            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                            this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void SaveReports(string value)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (i != 0)
                    {
                        str1 = this.chkColumns.Items[i].Value;
                        client_report clientClientReport = this;
                        clientClientReport.ColumnNames = string.Concat(clientClientReport.ColumnNames, "µ", str1);
                    }
                    else
                    {
                        str1 = this.chkColumns.Items[i].Value;
                        this.ColumnNames = str1;
                    }
                }
            }
            for (int j = 0; j < this.chk_contactsList.Items.Count; j++)
            {
                if (this.chk_contactsList.Items[j].Selected)
                {
                    client_report clientClientReport1 = this;
                    clientClientReport1.contactlstcount = clientClientReport1.contactlstcount + 1;
                    str1 = this.chk_contactsList.Items[j].Value;
                    client_report clientClientReport2 = this;
                    clientClientReport2.ColumnNames = string.Concat(clientClientReport2.ColumnNames, "µ", str1);
                }
            }
            for (int k = 0; k < this.Chk_DepartmentList.Items.Count; k++)
            {
                if (this.Chk_DepartmentList.Items[k].Selected)
                {
                    str1 = this.Chk_DepartmentList.Items[k].Value;
                    client_report clientClientReport3 = this;
                    clientClientReport3.ColumnNames = string.Concat(clientClientReport3.ColumnNames, "µ", str1);
                }
            }
            for (int l = 0; l < this.Chk_addressList.Items.Count; l++)
            {
                if (this.Chk_addressList.Items[l].Selected)
                {
                    str1 = this.Chk_addressList.Items[l].Value;
                    client_report clientClientReport4 = this;
                    clientClientReport4.ColumnNames = string.Concat(clientClientReport4.ColumnNames, "µ", str1);
                }
            }
            for (int m = 0; m < this.chkAggCustomeritems.Items.Count; m++)
            {
                if (this.chkAggCustomeritems.Items[m].Selected)
                {
                    str1 = this.chkAggCustomeritems.Items[m].Value;
                    client_report clientClientReport5 = this;
                    clientClientReport5.ColumnNames = string.Concat(clientClientReport5.ColumnNames, "µ", str1);
                }
            }
            empty = " Columns";
            str = string.Concat("'", this.ColumnNames, "'");
            if (!this.chkest.Checked)
            {
                empty = string.Concat(empty, " ,EstCount");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,EstCount");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkest1.Checked)
            {
                empty = string.Concat(empty, " ,EstTotal");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,EstTotal");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkjob.Checked)
            {
                empty = string.Concat(empty, " ,EstAverage");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,EstAverage");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkjob1.Checked)
            {
                empty = string.Concat(empty, " ,EstMaximum");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,EstMaximum");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkinv.Checked)
            {
                empty = string.Concat(empty, " ,NetTotal");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,NetTotal");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkinv1.Checked)
            {
                empty = string.Concat(empty, " ,NetAverage");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,NetAverage");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkpo.Checked)
            {
                empty = string.Concat(empty, " ,NetMaximum");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,NetMaximum");
                str = string.Concat(str, " ,1");
            }
            if (!this.chkpo1.Checked)
            {
                empty = string.Concat(empty, " ,NetMinimum");
                str = string.Concat(str, " ,0");
            }
            else
            {
                empty = string.Concat(empty, " ,NetMinimum");
                str = string.Concat(str, " ,1");
            }
            if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "0")
            {
                empty = string.Concat(empty, " ,ReportType,GroupedBy");
                str = string.Concat(str, " ,'',0");
            }
            else
            {
                empty = string.Concat(empty, " ,ReportType,GroupedBy");
                str = string.Concat(str, " ,'',", this.ddlGrouprecords.SelectedValue);
            }
            if (this.txtFreetext.Text != "")
            {
                empty = string.Concat(empty, " ,SearchKeyword");
                str = string.Concat(str, " ,'", base.SpecialEncode(this.txtFreetext.Text), "'");
            }
            empty = string.Concat(empty, " ,CompanyName");
            str = string.Concat(str, " ,'", base.SpecialEncode(this.ddlCompanyType.SelectedValue), "'");
            empty = string.Concat(empty, " ,IsShowContactAddressOneColumn,IsShowDeliveryAddressOneColumn,IsShowInvoiceAddressOneColumn");
            str = (this.ddlIndividual.SelectedValue != "OneColumn" ? string.Concat(str, " ,1,1,1") : string.Concat(str, " ,0,0,0"));
            if (this.lstCustomerType.SelectedIndex != 0)
            {
                string empty2 = string.Empty;
                int num = 0;
                for (int n = 0; n < this.lstCustomerType.Items.Count; n++)
                {
                    if (this.lstCustomerType.Items[n].Checked)
                    {
                        num++;
                        empty2 = (num != 1 ? string.Concat(empty2, "µ", this.lstCustomerType.Items[n].Value) : this.lstCustomerType.Items[n].Value);
                    }
                }
                if (num > 0)
                {
                    empty = string.Concat(empty, " ,CustomerType");
                    str = string.Concat(str, " ,'", empty2, "'");
                }
            }
            if (!this.chkDateOption.Checked)
            {
                empty = string.Concat(empty, " ,IsCreatedDate,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                str = string.Concat(str, " ,0,'','',''");
            }
            else
            {
                empty = string.Concat(empty, " ,IsCreatedDate");
                str = string.Concat(str, " ,1");
                if (this.rdlDate.SelectedValue == "daily")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 't','',''");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'y','',''");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'cm','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'cq','',''");
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'ay','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'lq','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'cy','',''");
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'hy','',''");
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'td','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'lw','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'lm','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'ly','',''");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    string str2 = str;
                    string[] strArrays = new string[] { str2, ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFrom.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtTo.Text), "'" };
                    str = string.Concat(strArrays);
                }
            }
            if (!this.chkContactDateOption.Checked)
            {
                empty = string.Concat(empty, " ,IsContactCreatedDate,ContactDateType,ContactDateFrom,ContactDateTo");
                str = string.Concat(str, " ,0,'','',''");
            }
            else
            {
                empty = string.Concat(empty, " ,IsContactCreatedDate");
                str = string.Concat(str, " ,1");
                if (this.ddlContactDateOption.SelectedValue == "daily")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 't','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "yesterday")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'y','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "thismonth")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'cm','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "thisquarter")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'cq','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'ay','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastquater")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'lq','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "thisyear")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'cy','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "halfyear")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'hy','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "tilldate")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'td','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastweek")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'lw','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastmonth")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'lm','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "lastyear")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    str = string.Concat(str, ", 'ly','',''");
                }
                else if (this.ddlContactDateOption.SelectedValue == "daterange")
                {
                    empty = string.Concat(empty, " ,ContactDateType,ContactDateFrom,ContactDateTo");
                    string str3 = str;
                    string[] strArrays1 = new string[] { str3, ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtfromdate_converted.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txttodate_converted.Text), "'" };
                    str = string.Concat(strArrays1);
                }
            }
           
            // if show main contact checked --// added by shehzad
            if (this.chkShowMainContact.Checked)
            {
                empty = string.Concat(empty, " ,IsShowMainContact");
                str = string.Concat(str, " ,1");
            }
            else
            {
                empty = string.Concat(empty, " ,IsShowMainContact");
                str = string.Concat(str, " ,0");
            }
            if (this.chkNoActivityinPast.Checked)
            {
                empty = string.Concat(empty, " ,IsNoPastActivityCreated");
                str = string.Concat(str, " ,1");
                if (this.ddl_NoActivityinPast.SelectedValue == "30")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'td','',''");
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "45")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'fd','',''");
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "60")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'sd','',''");
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "90")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'nd','',''");
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "120")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'otd','',''");
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "365")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'tsd','',''");
                }
                else if (this.ddl_NoActivityinPast.SelectedValue == "daterange")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    string str4 = str;
                    string[] strArrays2 = new string[] { str4, ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtNoActivityinPastFromdate.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtNoActivityinPastTodate.Text), "'" };
                    str = string.Concat(strArrays2);
                }
                if (this.chk_Estimate.Checked && this.chk_Job.Checked)
                {
                    empty = string.Concat(empty, " ,chkEstimate,chkJob");
                    str = string.Concat(str, ", 1,1");
                }
                else if (this.chk_Estimate.Checked)
                {
                    empty = string.Concat(empty, " ,chkEstimate,chkJob");
                    str = string.Concat(str, ", 1,0");
                }
                else if (this.chk_Job.Checked)
                {
                    empty = string.Concat(empty, " ,chkEstimate,chkJob");
                    str = string.Concat(str, ", 0,1");
                }
            }
            else if (this.chkestimatevaluerange.Checked)
            {
                empty = string.Concat(empty, " ,IsEstimateValuerangeCreated");
                str = string.Concat(str, " ,1");
                if (this.ddlestimatevaluerange.SelectedValue == "greater than")
                {
                    empty = string.Concat(empty, " ,EstimateValueRange,Filtervalue");
                    str = string.Concat(str, ", 'gt',", this.txtestimatevaluerange.Text, " ");
                }
                else if (this.ddlestimatevaluerange.SelectedValue == "less than")
                {
                    empty = string.Concat(empty, " ,EstimateValueRange,Filtervalue");
                    str = string.Concat(str, ", 'lt',", this.txtestimatevaluerange.Text, " ");
                }
                else if (this.ddlestimatevaluerange.SelectedValue == "equals to")
                {
                    empty = string.Concat(empty, " ,EstimateValueRange,Filtervalue");
                    str = string.Concat(str, ", 'et',", this.txtestimatevaluerange.Text, " ");
                }
                if (this.ddlestimatevaluedaterange.SelectedValue == "current month")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'cm','',''");
                }
                else if (this.ddlestimatevaluedaterange.SelectedValue == "last month")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'lm','',''");
                }
                else if (this.ddlestimatevaluedaterange.SelectedValue == "daterange")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    string str5 = str;
                    string[] strArrays3 = new string[] { str5, ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtestvalueFromdate.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtestvalueTodate.Text), "'" };
                    str = string.Concat(strArrays3);
                }
                this.contactlstcount = 0;
            }
            else if (!this.chkjobvaluerange.Checked)
            {
                empty = string.Concat(empty, " ,IsNoPastActivityCreated,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate,chkEstimate,chkJob,IsEstimateValuerangeCreated,EstimateValueRange,Filtervalue,IsJobValuerangeCreated");
                str = string.Concat(str, " ,0,'','','',0,0,0,'',0,0");
            }
            else
            {
                empty = string.Concat(empty, " ,IsJobValuerangeCreated");
                str = string.Concat(str, " ,1");
                if (this.ddljobvaluerange.SelectedValue == "greater than")
                {
                    empty = string.Concat(empty, " ,EstimateValueRange,Filtervalue");
                    str = string.Concat(str, ", 'gt',", this.txtjobvaluerange.Text, " ");
                }
                else if (this.ddljobvaluerange.SelectedValue == "less than")
                {
                    empty = string.Concat(empty, " ,EstimateValueRange,Filtervalue");
                    str = string.Concat(str, ", 'lt',", this.txtjobvaluerange.Text, " ");
                }
                else if (this.ddljobvaluerange.SelectedValue == "equals to")
                {
                    empty = string.Concat(empty, " ,EstimateValueRange,Filtervalue");
                    str = string.Concat(str, ", 'et',", this.txtjobvaluerange.Text, " ");
                }
                if (this.ddljobvaluedaterange.SelectedValue == "current month")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'cm','',''");
                }
                else if (this.ddljobvaluedaterange.SelectedValue == "last month")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    str = string.Concat(str, ", 'lm','',''");
                }
                else if (this.ddljobvaluedaterange.SelectedValue == "daterange")
                {
                    empty = string.Concat(empty, " ,NoPastActivityDays,NoPastActivityFromDate,NoPastActivityToDate");
                    string str6 = str;
                    string[] strArrays4 = new string[] { str6, ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtjobvalueFromdate.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtjobvalueTodate.Text), "'" };
                    str = string.Concat(strArrays4);
                }
                this.contactlstcount = 0;
            }
            empty = string.Concat(empty, " ,EstConvertionDate,EstConvertionDateType,EstConvertionDateFrom,EstConvertionDateTo,ApplyDates");
            str = string.Concat(str, " ,0,'','','',0");
            if (this.txtSaveReports.Text != "")
            {
                empty = string.Concat(empty, " ,ReportName");
                str = string.Concat(str, ", '", base.SpecialEncode(this.txtSaveReports.Text), "'");
            }
            if (this.txtDescription.Text != "")
            {
                empty = string.Concat(empty, " ,Description");
                str = string.Concat(str, ", '", base.SpecialEncode(this.txtDescription.Text), "'");
            }
            empty = string.Concat(empty, " ,PageName,CompanyID,UserID,SortValue,Direction");
            object obj = str;
            object[] objArray = new object[] { obj, ", 'client',", Convert.ToInt32(this.Session["companyid"].ToString()), ",", Convert.ToInt32(this.Session["UserID"].ToString()), ", '", this.HdnSortBy.Value.ToString(), "' , '", this.ddlDirection.SelectedValue.ToString(), "'" };
            str = string.Concat(objArray);
            if (value == "Save")
            {
                string[] strArrays5 = new string[] { "Insert into tb_Reports_Save(", empty, ") Values (", str, ")" };
                empty1 = string.Concat(strArrays5);
            }
            else if (value == "Update")
            {
                if (this.hdn_reportID.Value == "")
                {
                    this.hdn_reportID.Value = "0";
                }
                empty1 = string.Concat("delete tb_reports_save where ReportID=", Convert.ToInt32(this.hdn_reportID.Value), ";");
                string[] strArrays6 = new string[] { " ", empty1, "Insert into tb_Reports_Save(", empty, ") Values (", str, ")" };
                empty1 = string.Concat(strArrays6);
                this.hdn_reportID.Value = "";
            }
            SqlCommand sqlCommand = new SqlCommand(empty1, this.objJava.openConnection())
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
            if (ReportID == 0)
            {
                this.Session["DeleteMsg"] = "SelectDeleteTab";
                return;
            }
            this.Session["DeleteMsg"] = null;
            this.ReportDetails(ReportID);
            this.RunReportOnClick();
            this.hdn_reportID.Value = ReportID.ToString();
        }

        protected void GridClient_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (base.IsPostBack)
            {
                DataSet ClientData = this.GetEstimateData(this.PageNumber);
                DataTable dt = SetClientReportColumns(ClientData);
                this.GridEstReport.DataSource = dt;
            }

        }
        protected void GridClient_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageNumber = e.NewPageIndex + 1;
        }

        protected void GridClient_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageSize = e.NewPageSize;
        }
    }
}