using ePrint.usercontrol;
using nmsCommon;
using nmsConnectionClass;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Estimates
{
    public partial class estimate_email : BaseClass, IRequiresSessionState
    {

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string strFilepath = global.filePath();

        private BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        private Template objTemplate = new Template();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public long AttachmentTypeID;

        public int UCcount;

        public string items = string.Empty;

        private int CompanyID;

        private static long Company_ID;

        public int UserID;

        private int TemplateID;

        public int EstimateID;

        public int EstimateItemID;

        private int CustomerID;

        private int AttentionID;

        private string[] arryTag;

        private string TagNames = string.Empty;

        private int Items;

        private string RFQdescription = string.Empty;

        private string StrEsimateItemID = string.Empty;

        private string StrEstimateType = string.Empty;

        public int EstID;

        public int totalrec;

        public int DefTemplateID;

        public string PageType = string.Empty;

        public int sectionid;

        public string sectionname = string.Empty;

        public string CompanyType = string.Empty;

        public string report_page = string.Empty;

        public string PDFIsFrom = string.Empty;

        private double Price;

        private double TaxValue;

        private double TotalIncTax;

        private string[] AryStrNoteQty;

        private string[] AryStrDescription;

        private string[] AryStrPurCode;

        private string[] AryStrPurQty;

        private string[] AryStrPurDesc;

        private string[] AryStrPurPrice;

        private string[] AryStrPurTotPriceIncTax;

        public string iframePath = string.Empty;

        public string iframePathForEditTemplate = string.Empty;

        public int EmailCount;

        public string TempKey = string.Empty;

        public object objPrintBroker;

        public string OnlyOneTemp = string.Empty;

        public int PageSize = 25;

        public string ordid = string.Empty;

        public string maintype = string.Empty;

        private Global gloobj = new Global();

        public string RedirectPath = string.Empty;

        public string EmailSettingType = string.Empty;

        public string DefaultEmailBody = string.Empty;

        public string EmailTo = string.Empty;

        public string EmailCC = string.Empty;

        public string EmailBCC = string.Empty;

        public string FinalOutlookData = string.Empty;

        public string SysName = ConnectionClass.ServerName;

        private StringBuilder strBuOutlook = new StringBuilder();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ServerName = string.Empty;

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

        static estimate_email()
        {
        }

        public estimate_email()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.sectionname.ToString() == "PrintBroker")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore((long)this.EstimateID, "estimate");
            }
            string str = string.Empty;
            if (this.sectionname == "lead")
            {
                QueryString queryString = new QueryString()
			{
				{ "leadid", this.sectionid.ToString() }
			};
                string str1 = "lead/lead_detail.aspx";
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str1 = string.Concat(str1, queryString1.ToString());
                str = string.Concat(global.sitePath(), str1);
            }
            else if (this.sectionname == "client")
            {
                str = string.Concat(global.sitePath(), "client/client_view.aspx");
            }
            else if (this.sectionname.ToLower() == "estimate")
            {
                str = string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "printbroker")
            {
                if (empty.ToString() != "yes")
                {
                    str = string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    string[] strArrays = new string[] { this.strSitepath, "orders/order_summary.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), "&ordid=", base.Request.Params["EstID"].ToString() };
                    str = string.Concat(strArrays);
                }
            }
            else if (this.sectionname.ToLower() == "job")
            {
                if (this.ordid == "")
                {
                    str = string.Concat(this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    string[] strArrays1 = new string[] { this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString() };
                    str = string.Concat(strArrays1);
                }
            }
            else if (this.sectionname.ToLower() == "invoice")
            {
                if (this.ordid == "")
                {
                    str = string.Concat(this.strSitepath, "invoice/Invoice_Summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    string[] str2 = new string[] { this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString() };
                    str = string.Concat(str2);
                }
            }
            else if (this.sectionname.ToLower() == "purchase")
            {
                str = string.Concat(this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "deliverynote")
            {
                str = string.Concat(this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "jobcard")
            {
                str = string.Concat(this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() != "webstoreorder")
            {
                QueryString queryString2 = new QueryString()
			{
				{ "contactid", this.sectionid.ToString() }
			};
                string str3 = "contact/contact_detail.aspx";
                QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                str3 = string.Concat(str3, queryString3.ToString());
                str = string.Concat(global.sitePath(), str3);
            }
            else
            {
                string[] strArrays2 = new string[] { this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString() };
                str = string.Concat(strArrays2);
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "page", string.Concat("forRedirect('", str, "');"), true);
        }

        protected void btnSendAllEmail_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.sectionname.ToString() == "PrintBroker")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore((long)this.EstimateID, "estimate");
            }
            DataTable dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString());
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                empty1 = row["Number"].ToString();
                str = row["TemNameLastCounter"].ToString();
            }
            SettingsBasePage.Update_settings_TemNameLastCounter(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString());
            long num = (long)0;
            num = Convert.ToInt64(base.Request.Params["TempID"]);
            for (int i = 1; i <= this.EmailCount; i++)
            {
                Control control = this.plhEmail.FindControl(string.Concat("uc", i.ToString()));
                email_printbroker usercontrolEmailPrintbroker = (email_printbroker)control;
                CheckBox checkBox = (CheckBox)usercontrolEmailPrintbroker.FindControl("chkEmail");
                HiddenField hiddenField = (HiddenField)usercontrolEmailPrintbroker.FindControl("hid_TemplateKey");
                HtmlTextArea htmlTextArea = (HtmlTextArea)usercontrolEmailPrintbroker.FindControl("txtfirstname");
                HtmlTextArea htmlTextArea1 = (HtmlTextArea)usercontrolEmailPrintbroker.FindControl("txtbcc");
                HtmlTextArea htmlTextArea2 = (HtmlTextArea)usercontrolEmailPrintbroker.FindControl("txtcc");
                string str1 = this.objBase.ReplaceSingleQuote(htmlTextArea.Value);
                string str2 = this.objBase.ReplaceSingleQuote(htmlTextArea2.Value);
                string str3 = this.objBase.ReplaceSingleQuote(htmlTextArea1.Value);
                if (checkBox.Checked)
                {
                    usercontrolEmailPrintbroker.sendemail();
                    string empty2 = string.Empty;
                    DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(this.EstimateID), "template", num);
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        empty2 = dataRow["Name"].ToString();
                    }
                    if (base.Request.Params["page"].ToLower() == "estimate")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass = this.objnotes;
                        string[] strArrays = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass.email_address = string.Concat(strArrays);
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTemplateSent);
                    }
                    else if (base.Request.Params["page"].ToLower() == "job")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass1 = this.objnotes;
                        string[] strArrays1 = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass1.email_address = string.Concat(strArrays1);
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTemplateSent);
                    }
                    else if (base.Request.Params["page"].ToLower() == "invoice")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass2 = this.objnotes;
                        string[] strArrays2 = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass2.email_address = string.Concat(strArrays2);
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTemplateSent);
                    }
                    else if (base.Request.Params["page"].ToLower() == "purchase")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass3 = this.objnotes;
                        string[] strArrays3 = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass3.email_address = string.Concat(strArrays3);
                        this.objnotes.ModuleName = "purchase";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POTempSend);
                    }
                    else if (base.Request.Params["page"].ToLower() == "note")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass4 = this.objnotes;
                        string[] strArrays4 = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass4.email_address = string.Concat(strArrays4);
                        this.objnotes.ModuleName = "delivery";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelTempSend);
                    }
                    else if (base.Request.Params["page"].ToLower() == "webstoreorder")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass5 = this.objnotes;
                        string[] strArrays5 = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass5.email_address = string.Concat(strArrays5);
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderTempSend);
                    }
                    else if (base.Request.Params["page"].ToLower() == "printbroker")
                    {
                        this.objnotes.Template_name = empty2;
                        notesclass _notesclass6 = this.objnotes;
                        string[] strArrays6 = new string[] { str1.Replace(",", ", "), ", ", str2.Replace(",", ", "), ", ", str3.Replace(",", ", ") };
                        _notesclass6.email_address = string.Concat(strArrays6);
                        this.objnotes.ModuleName = "printbroker";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.SupplierRFQTempSend);
                    }
                    if (this.PageType.ToLower() != "printbroker")
                    {
                        notesclass _notesclass7 = this.objnotes;
                        object[] value = new object[] { this.strSitepath, "pdf.aspx?key=", i, "_", hiddenField.Value };
                        _notesclass7.TempAttachment = string.Concat(value);
                    }
                    else
                    {
                        notesclass _notesclass8 = this.objnotes;
                        object[] attachmentTypeID = new object[] { this.strSitepath, "pdf.aspx?key=", usercontrolEmailPrintbroker.AttachmentTypeID, "_", usercontrolEmailPrintbroker.SupplierID, "_", hiddenField.Value };
                        _notesclass8.TempAttachment = string.Concat(attachmentTypeID);
                    }
                    this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass9 = this.objnotes;
                    commonClass _commonClass = this.cmnDate;
                    DateTime now = DateTime.Now;
                    _notesclass9.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                    string str4 = "";
                    if (this.PageType.ToLower() != "printbroker")
                    {
                        str4 = string.Concat(empty1, "-", str, ".pdf");
                    }
                    else
                    {
                        object[] objArray = new object[] { empty1, "_", usercontrolEmailPrintbroker.AttachmentTypeID, "_", usercontrolEmailPrintbroker.SupplierID, "-", str, ".pdf" };
                        str4 = string.Concat(objArray);
                    }
                    string str5 = "";
                    if (this.PageType.ToLower() != "printbroker")
                    {
                        str5 = SettingsBasePage.settings_template_emailed_select_GUID(string.Concat(i, "_", hiddenField.Value));
                    }
                    else
                    {
                        object[] attachmentTypeID1 = new object[] { usercontrolEmailPrintbroker.AttachmentTypeID, "_", usercontrolEmailPrintbroker.SupplierID, "_", hiddenField.Value };
                        str5 = SettingsBasePage.settings_template_emailed_select_GUID(string.Concat(attachmentTypeID1));
                    }
                    string str6 = string.Concat(this.strFilepath, "tempattachment\\", str5);
                    object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//" };
                    if (!Directory.Exists(string.Concat(secureDocPath)))
                    {
                        object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//" };
                        Directory.CreateDirectory(string.Concat(secureDocPath1));
                    }
                    if (File.Exists(str6))
                    {
                        object[] objArray1 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//", str4 };
                        File.Copy(str6, string.Concat(objArray1), true);
                    }
                }
            }
            if (this.sectionname == "lead")
            {
                QueryString queryString = new QueryString()
			{
				{ "leadid", this.sectionid.ToString() }
			};
                string str7 = "lead/lead_detail.aspx";
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                str7 = string.Concat(str7, queryString1.ToString());
                this.RedirectPath = string.Concat(global.sitePath(), str7);
            }
            else if (this.sectionname == "client")
            {
                QueryString queryString2 = new QueryString()
			{
				{ "clientid", this.sectionid.ToString() },
				{ "isnew", "2" },
				{ "bypass", "1" },
				{ "type", base.Request.Params["type"].ToString() }
			};
                string str8 = "client/client_detail.aspx";
                QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                str8 = string.Concat(str8, queryString3.ToString());
                this.RedirectPath = string.Concat(global.sitePath(), str8);
            }
            else if (this.sectionname.ToLower() == "estimate")
            {
                this.RedirectPath = string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "printbroker")
            {
                if (empty.ToString() != "yes")
                {
                    this.RedirectPath = string.Concat("../estimates/estimate_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    this.RedirectPath = string.Concat("../orders/order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString());
                }
            }
            else if (this.sectionname.ToLower() == "job")
            {
                if (this.ordid == "")
                {
                    this.RedirectPath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    this.RedirectPath = string.Concat("../jobs/job_order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString());
                }
            }
            else if (this.sectionname.ToLower() == "invoice")
            {
                if (this.ordid == "")
                {
                    this.RedirectPath = string.Concat("../invoice/invoice_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
                }
                else
                {
                    this.RedirectPath = string.Concat("../invoice/invoice_order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString());
                }
            }
            else if (this.sectionname.ToLower() == "purchase")
            {
                this.RedirectPath = string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "deliverynote")
            {
                this.RedirectPath = string.Concat("../delivery/delivery_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() == "jobcard")
            {
                this.RedirectPath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString());
            }
            else if (this.sectionname.ToLower() != "webstore")
            {
                QueryString queryString4 = new QueryString()
			{
				{ "contactid", this.sectionid.ToString() }
			};
                string str9 = "contact/contact_detail.aspx";
                QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                str9 = string.Concat(str9, queryString5.ToString());
                this.RedirectPath = string.Concat(global.sitePath(), str9);
            }
            else
            {
                this.RedirectPath = string.Concat("../orders/order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "page", string.Concat("forRedirect('", this.RedirectPath, "');"), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] emailTo;
            object[] secureDocPath;
            this.EstimateID = Convert.ToInt32(base.Request.Params["EstID"].ToString());
            this.EstID = this.EstimateID;
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            estimate_email.Company_ID = (long)Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.PageType = base.Request.Params["page"].ToString();
            this.sectionid = Convert.ToInt32(base.Request.Params["sectionid"].ToString());
            this.sectionname = base.Request.Params["sectionname"].ToString();
            this.CompanyType = base.Request.Params["type"].ToString();
            if (this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())] != null)
            {
                this.TempKey = this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())].ToString();
            }
            this.gloobj.setpagename(base.Request.Params["page"].ToString());
            this.ordid = (base.Request.Params["ordid"] != null ? base.Request.Params["ordid"].ToString() : "");
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (this.Session["SelectedItemForPrint"] != null)
            {
                this.items = this.Session["SelectedItemForPrint"].ToString();
            }
            foreach (DataRow row in SettingsBasePage.settings_emailsetting_select(this.CompanyID, this.UserID).Rows)
            {
                this.EmailSettingType = row["EmailSettingType"].ToString();
                if (Convert.ToBoolean(row["IsCheckedCC"]) && row["cc"].ToString().Length > 0)
                {
                    if (this.EmailCC.Length <= 0)
                    {
                        this.EmailCC = base.SpecialDecode(row["cc"].ToString());
                    }
                    else
                    {
                        estimate_email estimatesEstimateEmail = this;
                        estimatesEstimateEmail.EmailCC = string.Concat(estimatesEstimateEmail.EmailCC, ",", base.SpecialDecode(row["cc"].ToString()));
                    }
                }
                if (!Convert.ToBoolean(row["IsCheckedBCC"]) || row["bcc"].ToString().Length <= 0)
                {
                    continue;
                }
                if (this.EmailBCC.Length <= 0)
                {
                    this.EmailBCC = base.SpecialDecode(row["bcc"].ToString());
                }
                else
                {
                    estimate_email estimatesEstimateEmail1 = this;
                    estimatesEstimateEmail1.EmailBCC = string.Concat(estimatesEstimateEmail1.EmailBCC, ",", base.SpecialDecode(row["bcc"].ToString()));
                }
            }
            string lower = base.Request.Params["page"].ToString().ToLower();
            if (lower == "purchase")
            {
                lower = "Purchase Order";
            }
            else if (lower == "note")
            {
                lower = "Delivery Note";
            }
            else if (lower == "printbroker")
            {
                lower = "Supplier RFQ";
            }
            DataTable dataTable = this.objTemplate.Select_EmailTemplateName(this.UserID, this.CompanyID, lower);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.DefaultEmailBody = string.Concat(dataRow["Body"].ToString(), " ", dataRow["FooterText"].ToString());
            }
            if (base.Request.Params["Page"].ToString().ToLower() != "printbroker")
            {
                if (this.EmailSettingType.ToLower() != "o")
                {
                    this.plhEmail.Controls.Clear();
                    email_template tempKey = (email_template)base.LoadControl("~/usercontrol/email_template.ascx");
                    tempKey.ID = "uc1";
                    tempKey.TemplateKey = this.TempKey;
                    this.plhEmail.Controls.Add(tempKey);
                    HtmlGenericControl htmlGenericControl = (HtmlGenericControl)tempKey.FindControl("div_EmailFromEprint");
                    htmlGenericControl.Attributes.Add("style", "display:block");
                }
                else
                {
                    string empty = string.Empty;
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    DataTable dataTable1 = new DataTable();
                    if (base.Request.Params["page"].ToString().ToLower() == "estimate" || base.Request.Params["page"].ToString().ToLower() == "order" || base.Request.Params["page"].ToString().ToLower() == "webstoreorder")
                    {
                        dataTable1 = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString(), this.items);
                    }
                    else if (base.Request.Params["page"].ToString().ToLower() == "job" || base.Request.Params["page"].ToString().ToLower() == "jobcard")
                    {
                        dataTable1 = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, Convert.ToInt64(base.Request.Params["jID"]), base.Request.Params["page"].ToString(), this.items);
                    }
                    else
                    {
                        dataTable1 = (base.Request.Params["page"].ToString().ToLower() != "invoice" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, Convert.ToInt64(base.Request.Params["EstID"]), base.Request.Params["page"].ToString(), this.items) : SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, Convert.ToInt64(base.Request.Params["InvID"]), base.Request.Params["page"].ToString(), this.items));
                    }
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        empty = row1["Title"].ToString() ;
                        empty = empty.Replace("'", "\\'");
                        empty = empty.Replace("\n", " ");                                 
                        if (this.sectionname.ToLower() == "purchase" && empty.Length > 0)
                        {
                            emailTo = new string[] { "\r\n" };
                            string[] strArrays = emailTo;
                            empty = base.Server.HtmlDecode(empty.Split(strArrays, StringSplitOptions.None)[0].Replace("Item Title:", ""));
                        }
                        str = row1["Number"].ToString();
                        this.EmailTo = base.SpecialEncode(row1["email"].ToString());
                        empty1 = row1["TemNameLastCounter"].ToString();
                    }
                    this.DefaultEmailBody = this.objTemplate.ReplaceAllTags_Outlook(dataTable1, this.TempKey, base.Request.Params["page"].ToString(), this.DefaultEmailBody, "0");
                    string str1 = string.Concat(this.strSitepath, "pdf.aspx?key=", this.TempKey);
                    string defaultEmailBody = this.DefaultEmailBody;
                    emailTo = new string[] { "<a href=", str1, ">", str1, "</a>&nbsp;" };
                    defaultEmailBody.Replace("[$PDFPath$]", string.Concat(emailTo));
                    this.DefaultEmailBody = (this.DefaultEmailBody.Length > 1500 ? string.Concat(this.DefaultEmailBody.Substring(0, 1500).ToString(), "<\n>", str1) : this.DefaultEmailBody);
                    if (ConnectionClass.ServerName.ToLower() != "occy")
                    {
                        this.strBuOutlook.Append("<div id='div_EmailBody_PrintBroker' style='display: block;'>");
                    }
                    else
                    {
                        this.strBuOutlook.Append("<div id='div_EmailBody_PrintBroker' style='display: none;'>");
                    }
                    this.strBuOutlook.Append("<span class='smallgrayText'>(Note: Copy and paste the Email body displayed below to ");
                    this.strBuOutlook.Append("your local email client [Outlook, MacMail] )</span><a href='#' onclick=javascript:fnSelect('div_EmailBodyContent');>");
                    this.strBuOutlook.Append("Select All</a>");
                    this.strBuOutlook.Append("<br />");
                    this.strBuOutlook.Append("<div id='div_EmailBodyContent' class='normalText'>");
                    this.strBuOutlook.Append(this.DefaultEmailBody);
                    this.strBuOutlook.Append("</div>");
                    this.strBuOutlook.Append("</div>");
                    this.plhEmail.Controls.Add(new LiteralControl(this.strBuOutlook.ToString()));
                    emailTo = new string[] { "OpenOutlook('", this.EmailTo, "','", this.EmailCC, "','", this.EmailBCC, "','", empty, "','div_EmailBodyContent','", str1, "')" };
                    this.FinalOutlookData = string.Concat(emailTo);
                    string str2 = SettingsBasePage.settings_template_emailed_select(this.TempKey);
                    if (base.Request.Params["Page"].ToString().ToLower() != "printbroker")
                    {
                        str2 = string.Concat(str, "-", empty1, ".pdf");
                    }
                    EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
                    string str3 = SettingsBasePage.settings_template_emailed_select_GUID(this.TempKey);
                    string str4 = string.Concat(this.strFilepath, "tempattachment\\", this.objBase.SpecialEncode(str3));
                    secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//" };
                    if (!Directory.Exists(string.Concat(secureDocPath)))
                    {
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//" };
                        Directory.CreateDirectory(string.Concat(secureDocPath));
                    }
                    if (File.Exists(str4))
                    {
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//", this.objBase.SpecialEncode(str2) };
                        File.Copy(str4, string.Concat(secureDocPath), true);
                    }
                }
                this.div_btnSendEmail.Style.Add("display", "none");
                this.div_btnSendEmail1.Style.Add("display", "none");
            }
            else
            {
                int num = 1;
                DataTable dataTable2 = new DataTable();
                if (base.Request.Params["isdirect"] == null)
                {
                    dataTable2 = this.objTemplate.estimate_itemid_select(this.CompanyID, Convert.ToInt64(this.EstimateID), (long)0);
                }
                else
                {
                    long num1 = (long)0;
                    if (base.Request.Params["EstItemID"] != null)
                    {
                        num1 = Convert.ToInt64(base.Request.Params["EstItemID"]);
                    }
                    dataTable2 = this.objTemplate.estimate_itemid_select(this.CompanyID, Convert.ToInt64(this.EstimateID), num1);
                }
                this.EmailCount = dataTable2.Rows.Count;
                this.FinalOutlookData = "";
                foreach (DataRow dataRow1 in dataTable2.Rows)
                {
                    string defaultEmailBody1 = this.DefaultEmailBody;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    DataTable dataTable3 = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString());
                    foreach (DataRow row2 in dataTable3.Rows)
                    {
                        empty2 = row2["Number"].ToString();
                        empty3 = row2["TemNameLastCounter"].ToString();
                    }
                    string empty4 = string.Empty;
                    foreach (DataRow dataRow2 in SettingsBasePage.settings_phrasebook_select(this.CompanyID, "Email Body").Rows)
                    {
                        string str5 = empty4;
                        emailTo = new string[] { str5, dataRow2["PhraseBookID"].ToString(), "±", dataRow2["PhraseText"].ToString(), "µ" };
                        empty4 = string.Concat(emailTo);
                    }
                    if (this.EmailSettingType.ToLower() != "o")
                    {
                        email_printbroker count = (email_printbroker)base.LoadControl("~/usercontrol/email_printbroker.ascx");
                        count.ID = string.Concat("uc", num.ToString());
                        count.ContactEmail = base.SpecialDecode(dataRow1["ContactEmail"].ToString());
                        emailTo = new string[] { empty2, "_", dataRow1["AttachmentTypeID"].ToString(), "_", dataRow1["SupplierID"].ToString().ToString(), "-", empty3, ".pdf" };
                        count.PDFAttachment += string.Concat(emailTo);

                        //int _count = dataTable2.Rows.Count;
                        //int cnt = 0;
                        //foreach (DataRow dr in dataTable2.Rows)
                        //{
                        //    if(_count != (cnt +1))
                        //    {
                        //        emailTo = new string[] { empty2, "_", dr["AttachmentTypeID"].ToString(), "_", dr["SupplierID"].ToString().ToString(), "-", empty3, ".pdf", "," };
                        //    }
                        //    else
                        //    {
                        //        emailTo = new string[] { empty2, "_", dr["AttachmentTypeID"].ToString(), "_", dr["SupplierID"].ToString().ToString(), "-", empty3, ".pdf" };
                        //    }
                        //    cnt++;
                        //}
                        if (dataRow1["ArtWork"] != null)
                        {
                            string[] strArrays1 = dataRow1["ArtWork"].ToString().Split(new char[] { '«' });
                            for (int i = 0; i < (int)strArrays1.Length - 1; i++)
                            {
                                count.ArtWorkAttachment = string.Concat(count.ArtWorkAttachment, ",", strArrays1[i].ToString());
                            }
                        }
                        count.SupplierCount = dataTable2.Rows.Count;
                        count.SupplierName = dataRow1["SupplierName"].ToString();
                        count.SupplierID = dataRow1["SupplierID"].ToString();
                        count.AttachmentTypeID = Convert.ToInt64(dataRow1["AttachmentTypeID"].ToString());
                        count.SupplierContactID = Convert.ToInt32(dataRow1["SupplierContactID"]);
                        count.TemplateKey = this.TempKey;
                        count.EmailText = empty4;
                        emailTo = new string[] { this.strSitepath, "pdf.aspx?key=", dataRow1["AttachmentTypeID"].ToString(), "_", dataRow1["SupplierID"].ToString(), "_", this.TempKey };
                        count.Sup_PDFPath = string.Concat(emailTo);
                        //string pdfPath = string.Empty;
                        //foreach (DataRow dr in dataTable2.Rows)
                        //{
                        //    emailTo = new string[] { this.strSitepath, "pdf.aspx?key=", dr["AttachmentTypeID"].ToString(), "_", dr["SupplierID"].ToString(), "_", this.TempKey, "µ" };
                        //    pdfPath += string.Concat(emailTo);
                        //}
                        //count.Sup_PDFPath = pdfPath.Replace("µ",Environment.NewLine);
                        this.plhEmail.Controls.Add(count);
                        count.UCcount = this.EmailCount;
                        this.div_btnSendEmail.Style.Add("display", "block");
                        this.div_btnSendEmail1.Style.Add("display", "block");
                    }
                    else
                    {
                        this.plhEmail.Controls.Clear();
                        string empty5 = string.Empty;
                        string empty6 = string.Empty;
                        DataTable dataTable4 = this.objTemplate.settings_titlecode_fortemplate_select_for_printbrocker_New(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString(), Convert.ToInt32(dataRow1["SupplierID"]), Convert.ToInt32(dataRow1["SupplierContactID"]), Convert.ToInt64(dataRow1["AttachmentTypeID"].ToString()));
                        foreach (DataRow row3 in dataTable3.Rows)
                        {
                            empty5 = row3["Title"].ToString();
                            if (this.sectionname.ToLower() == "purchase" && empty5.Length > 0)
                            {
                                string[] strArrays2 = new string[] { "\r\n" };
                                empty5 = base.Server.HtmlDecode(empty5.Split(strArrays2, StringSplitOptions.None)[0].Replace("Item Title:", ""));
                            }
                            row3["Number"].ToString();
                        }
                        this.EmailTo = base.SpecialDecode(dataRow1["ContactEmail"].ToString());
                        defaultEmailBody1 = this.objTemplate.ReplaceAllTags_Outlook(dataTable4, this.TempKey, base.Request.Params["page"].ToString(), defaultEmailBody1, string.Concat(dataRow1["AttachmentTypeID"].ToString(), "_", dataRow1["SupplierID"].ToString()));
                        string[] strArrays3 = new string[] { this.strSitepath, "pdf.aspx?key=", dataRow1["AttachmentTypeID"].ToString(), "_", dataRow1["SupplierID"].ToString(), "_", this.TempKey };
                        string str6 = string.Concat(strArrays3);
                        defaultEmailBody1 = (defaultEmailBody1.Length > 1500 ? string.Concat(defaultEmailBody1.Substring(0, 1500).ToString(), "<\n>", str6) : defaultEmailBody1);
                        if (ConnectionClass.ServerName.ToLower() != "occy")
                        {
                            this.strBuOutlook.Append("<div id='div_EmailBody_PrintBroker' style='display: block;'>");
                        }
                        else
                        {
                            this.strBuOutlook.Append("<div id='div_EmailBody_PrintBroker' style='display: none;'>");
                        }
                        this.strBuOutlook.Append("<span class='smallgrayText'>(Note: Copy and paste the Email body displayed below to ");
                        this.strBuOutlook.Append(string.Concat("your local email client [Outlook, MacMail] )</span><a href='#' onclick=javascript:fnSelect('div_EmailBodyContent", num, "');>"));
                        this.strBuOutlook.Append("Select All</a>");
                        this.strBuOutlook.Append("<br />");
                        this.strBuOutlook.Append(string.Concat("<b>", dataRow1["SupplierName"].ToString(), "</b>"));
                        this.strBuOutlook.Append("<br />");
                        this.strBuOutlook.Append(string.Concat("<div id='div_EmailBodyContent", num, "' class='normalText'>"));
                        this.strBuOutlook.Append(defaultEmailBody1);
                        this.strBuOutlook.Append("</div>");
                        this.strBuOutlook.Append("</div>");
                        this.plhEmail.Controls.Add(new LiteralControl(this.strBuOutlook.ToString()));
                        estimate_email estimatesEstimateEmail2 = this;
                        object finalOutlookData = estimatesEstimateEmail2.FinalOutlookData;
                        secureDocPath = new object[] { finalOutlookData, "OpenOutlook('", this.EmailTo, "','", this.EmailCC, "','", this.EmailBCC, "','", empty5, "','div_EmailBodyContent", num, "','", str6, "');" };
                        estimatesEstimateEmail2.FinalOutlookData = string.Concat(secureDocPath);
                        emailTo = new string[] { dataRow1["AttachmentTypeID"].ToString(), "_", dataRow1["SupplierID"].ToString(), "_", this.TempKey };
                        string str7 = SettingsBasePage.settings_template_emailed_select(string.Concat(emailTo));
                        EprintConfigurationManager.AppSettings["ServerName"].Trim().ToString();
                        emailTo = new string[] { dataRow1["AttachmentTypeID"].ToString(), "_", dataRow1["SupplierID"].ToString(), "_", this.TempKey };
                        string str8 = SettingsBasePage.settings_template_emailed_select_GUID(string.Concat(emailTo));
                        string str9 = string.Concat(this.strFilepath, "tempattachment\\", this.objBase.SpecialEncode(str8));
                        secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//" };
                        if (!Directory.Exists(string.Concat(secureDocPath)))
                        {
                            secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//" };
                            Directory.CreateDirectory(string.Concat(secureDocPath));
                        }
                        if (File.Exists(str9))
                        {
                            secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//sentpdf//", this.objBase.SpecialEncode(str7) };
                            File.Copy(str9, string.Concat(secureDocPath), true);
                        }
                    }
                    num++;
                }
            }
        }

        [WebMethod]
        public static string SaveEmailedTemplate(string strattachment, string PDFKey)
        {
            SettingsBasePage.settings_template_emailed_insert(strattachment, PDFKey, estimate_email.Company_ID);
            return PDFKey;
        }

        [WebMethod]
        public static string SaveEmailedTemplate_Printbroker(int SupplierCount, string EstimateNumber, string PDFKey)
        {
            for (int i = 1; i <= SupplierCount; i++)
            {
                object[] estimateNumber = new object[] { EstimateNumber, "_", i, "-", HttpContext.Current.Session["TempNameLastCounter"], ".pdf" };
                string str = string.Concat(estimateNumber);
                SettingsBasePage.settings_template_emailed_insert(str, string.Concat(i, "_", PDFKey), estimate_email.Company_ID);
            }
            return PDFKey;
        }
    }
}
