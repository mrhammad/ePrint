using DocumentFormat.OpenXml.Drawing.Charts;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using DataTable = System.Data.DataTable;

namespace ePrint.usercontrol
{
    public partial class templates_view1 : System.Web.UI.UserControl
    {

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string strFilepath = global.filePath();

        private BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        private Template objTemplate = new Template();

        public languageClass objLangClass = new languageClass();

        public languageClass objLanguage = new languageClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private int CompanyID;

        public int UserID;

        public int TemplateID;

        public int EstimateID;
        public int ProofID;

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

        public string iframePathChooseTemp = string.Empty;

        public string iframePathpdf = string.Empty;

        public string iframePathForEditTemplate = string.Empty;

        public string iframeEmailPath = string.Empty;

        public int EmailCount;

        public string TempKey = string.Empty;

        public object objPrintBroker;

        public string OnlyOneTemp = string.Empty;

        public int PageSize = 25;

        public string ordid = string.Empty;

        public string maintype = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string Module = string.Empty;

        public string IS_INVOICEorJOB_from_Webstore = string.Empty;

        protected Random rGen;

        public string customType = string.Empty;

        protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

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

        public templates_view1()
        {
        }

        protected void GeneratePDF_WhenOnlyOne()
        {
            string empty = string.Empty;
            base.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())] = null;
            base.Session["TemplateHTML"] = null;
            base.Session["TemplateControlList"] = null;
            base.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] = null;
            base.Session["isSplit"] = null;
            base.Session["TemplateID"] = null;
            base.Session["TempNameLastCounter"] = null;
            base.Session["TemplateID"] = this.TemplateID.ToString();
            string str = this.GenPassWithCap(12);
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable = new DataTable();
            if (base.Request.Params["Page"].ToString().ToLower() == "estimate" || base.Request.Params["Page"].ToString().ToLower() == "printbroker" || base.Request.Params["Page"].ToString().ToLower() == "webstoreorder")
            {
                dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString());
            }
            else if (base.Request.Params["Page"].ToString().ToLower() == "job" || base.Request.Params["Page"].ToString().ToLower() == "jobcard")
            {
                dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.jobID, base.Request.Params["page"].ToString());
            }
            else
            {
                dataTable = (base.Request.Params["Page"].ToString().ToLower() != "invoice" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, (long)this.EstimateID, base.Request.Params["page"].ToString()) : SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.InvoiceID, base.Request.Params["page"].ToString()));
            }
            foreach (DataRow row in dataTable.Rows)
            {
                str1 = row["Number"].ToString();
                empty = row["TemNameLastCounter"].ToString();
            }
            if (base.Request.Params["Page"].ToString().ToLower() != "printbroker")
            {
                empty1 = string.Concat(str1, "-", empty, ".pdf");
                SettingsBasePage.settings_template_emailed_insert(empty1, str, (long)Convert.ToInt32(base.Session["CompanyID"]));
            }
            else if (base.Request.Params["Page"].ToString().ToLower() == "printbroker")
            {
                DataTable dataTable1 = new DataTable();
                dataTable1 = (base.Request.Params["isdirect"] == null ? this.objTemplate.estimate_itemid_select(this.CompanyID, Convert.ToInt64(this.EstimateID), (long)0) : this.objTemplate.estimate_itemid_select(this.CompanyID, Convert.ToInt64(this.EstimateID), (long)this.EstimateItemID));
                this.EmailCount = dataTable1.Rows.Count;
                for (int i = 1; i <= this.EmailCount; i++)
                {
                    string[] strArrays = new string[] { str1, "_", dataTable1.Rows[i - 1]["AttachmentTypeID"].ToString(), "_", dataTable1.Rows[i - 1]["SupplierID"].ToString(), "-", empty, ".pdf" };
                    empty1 = string.Concat(strArrays);
                    string[] strArrays1 = new string[] { dataTable1.Rows[i - 1]["AttachmentTypeID"].ToString(), "_", dataTable1.Rows[i - 1]["SupplierID"].ToString(), "_", str };
                    SettingsBasePage.settings_template_emailed_insert(empty1, string.Concat(strArrays1), (long)Convert.ToInt32(base.Session["CompanyID"]));
                }
            }
            base.Session["TempNameLastCounter"] = empty;
            if (str != "")
            {
                base.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())] = str;
                Session["NewTempKey0"] = str;
            }
        }

        public string GenPassWithCap(int i)
        {
            this.rGen = new Random();
            int num = 0;
            string str = "";
            for (int i1 = 0; i1 <= i; i1++)
            {
                num = this.rGen.Next(0, 60);
                str = string.Concat(str, this.strCharacters[num]);
            }
            return str;
        }

        protected void Insert_Activityhistory(string PdfKeyNew)
        {
            string empty = string.Empty;
            this.TemplateID = Convert.ToInt16(base.Session["TemplateID"]);
            DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(this.EstimateID), "template", (long)this.TemplateID);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["Name"].ToString();
            }
            if (base.Request.Params["page"].ToString().ToLower() == "estimate")
            {
                this.objnotes.Template_name = empty;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTemplateView);
                this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "job")
            {
                this.objnotes.Template_name = empty;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTemplateView);
                this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "webstoreorder")
            {
                this.objnotes.Template_name = empty;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderTemplateView);
                this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "purchase" && base.Request.Params["frompg"] != null)
            {
                if (base.Request.Params["frompg"].ToString().ToLower() == "job")
                {
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, Convert.ToInt64(this.EstimateID), "all", Convert.ToInt64(this.EstimateID));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        str = dataRow["ReferenceNO"].ToString();
                        empty1 = dataRow["PONO"].ToString();
                    }
                    this.objnotes.Template_name = empty;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_number = str;
                    this.objnotes.Po_number = empty1;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobPOViedInTemp);
                    this.objnotes.ModuleID = Convert.ToInt64(base.Request.Params["jobEstID"]);
                }
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "invoice")
            {
                this.objnotes.Template_name = empty;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTemplateView);
                this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "purchase")
            {
                this.objnotes.Template_name = empty;
                this.objnotes.ModuleName = "purchase";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.POViewTemp);
                this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "note")
            {
                this.objnotes.Template_name = empty;
                this.objnotes.ModuleName = "delivery";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.DelViewTemp);
                this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
            }
            else if (base.Request.Params["page"].ToString().ToLower() == "printbroker")
            {
                if (base.Request.Url.ToString().ToLower().Contains("/estimates"))
                {
                    this.objnotes.Template_name = empty;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstTemplateView);
                    this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                }
                else if (!base.Request.Url.ToString().ToLower().Contains("/jobs"))
                {
                    this.objnotes.Template_name = empty;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvTemplateView);
                    this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                }
                else
                {
                    this.objnotes.Template_name = empty;
                    this.objnotes.ModuleName = "jobs";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobTemplateView);
                    this.objnotes.ModuleID = Convert.ToInt64(this.EstimateID);
                }
            }
            this.objnotes.TempAttachment = string.Concat(this.strSitepath, "pdf.aspx?key=", PdfKeyNew);
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.cmnDate;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.EstimateID = Convert.ToInt32(base.Request.Params["EstID"].ToString());
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.PageType = base.Request.Params["page"].ToString();
            if (base.Request.Params["sectionid"].ToString() != "" && base.Request.Params["sectionid"].ToString() != null)
            {
                this.sectionid = Convert.ToInt32(base.Request.Params["sectionid"].ToString());
            }

            if (!String.IsNullOrEmpty(base.Request.Params["customtype"]))
            {
                this.customType = base.Request.Params["customtype"].ToString();
            }
            this.sectionname = base.Request.Params["sectionname"].ToString();
            this.CompanyType = base.Request.Params["type"].ToString();
            this.report_page = base.Request.Params["page"].ToString();
            base.Request.Url.ToString();
            this.ordid = (base.Request.Params["ordid"] != null ? base.Request.Params["ordid"].ToString() : "");
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (base.Request.QueryString["ProofID"] != null)
            {
                this.ProofID = Convert.ToInt32(base.Request.Params["ProofID"]);
            }
            
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            this.EstID = this.EstimateID;
            if ((base.Request.Params["Page"].ToString().ToLower() == "job" || base.Request.Params["Page"].ToString().ToLower() == "printbroker") && base.Request.Params["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt32(base.Request.Params["EstItemID"].ToString());
            }
            if (base.Request.Url.ToString().ToLower().Contains("estimates/templates_view1.aspx") || base.Request.Url.ToString().ToLower().Contains("orders/templates_view1.aspx"))
            {
                this.PDFIsFrom = "e";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/templates_view1.aspx"))
            {
                this.PDFIsFrom = "j";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/templates_view1.aspx"))
            {
                this.PDFIsFrom = "i";
            }
            if (this.ordid == "")
            {
                this.ordid = base.Request.Params["EstID"].ToString();
            }
            string empty = string.Empty;
            if (base.Request.Params["isdirect"] != null)
            {
                empty = "&isdirect=1";
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["Page"].ToString().ToLower() == "jobcard" || base.Request.Params["Page"].ToString().ToLower() == "printbroker")
                {
                    if (this.ordid == "")
                    {
                        object[] companyType = new object[] { this.strSitepath, "Estimates/estimate_Email_ChooseTemplate.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname, "&type=", this.CompanyType, "&page=", this.PageType, "&EstID=", this.EstID, "&EstItemID=", this.EstimateItemID, "&key=", this.TempKey, this.jID, this.InvID, empty };
                        this.iframePathChooseTemp = string.Concat(companyType);
                        object[] pageType = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, this.InvID, empty };
                        this.iframePathpdf = string.Concat(pageType);
                        object[] objArray = new object[] { this.strSitepath, "settings/template_output.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, this.InvID };
                        this.iframePathForEditTemplate = string.Concat(objArray);
                        object[] pageType1 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                        this.iframeEmailPath = string.Concat(pageType1);
                    }
                    else
                    {
                        object[] companyType1 = new object[] { this.strSitepath, "Estimates/estimate_Email_ChooseTemplate.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname, "&type=", this.CompanyType, "&page=", this.PageType, "&EstID=", this.EstID, "&ordid=", this.ordid, "&EstItemID=", this.EstimateItemID, "&key=", this.TempKey, this.jID, this.InvID, empty };
                        this.iframePathChooseTemp = string.Concat(companyType1);
                        object[] objArray1 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&ordid=", this.ordid, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, this.InvID, empty };
                        this.iframePathpdf = string.Concat(objArray1);
                        object[] pageType2 = new object[] { this.strSitepath, "settings/template_output.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, this.InvID };
                        this.iframePathForEditTemplate = string.Concat(pageType2);
                        object[] objArray2 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&ordid=", this.ordid, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                        this.iframeEmailPath = string.Concat(objArray2);
                    }
                }
                else if (base.Request.Params["Page"].ToString().ToLower() == "job" && this.EstimateItemID > 0)
                {
                    if (this.ordid == "")
                    {
                        object[] companyType2 = new object[] { this.strSitepath, "Estimates/estimate_Email_ChooseTemplate.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname, "&type=", this.CompanyType, "&page=", this.PageType, "&EstID=", this.EstID, "&key=", this.TempKey, "&EstItemID=", this.EstimateItemID, this.jID, empty };
                        this.iframePathChooseTemp = string.Concat(companyType2);
                        object[] pageType3 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, empty };
                        this.iframePathpdf = string.Concat(pageType3);
                        object[] objArray3 = new object[] { this.strSitepath, "settings/template_output.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID };
                        this.iframePathForEditTemplate = string.Concat(objArray3);
                        object[] pageType4 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&EstItemID=", this.EstimateItemID, this.jID, empty };
                        this.iframeEmailPath = string.Concat(pageType4);
                    }
                    else
                    {
                        object[] companyType3 = new object[] { this.strSitepath, "Estimates/estimate_Email_ChooseTemplate.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname, "&type=", this.CompanyType, "&page=", this.PageType, "&EstID=", this.EstID, "&ordid=", this.ordid, "&key=", this.TempKey, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                        this.iframePathChooseTemp = string.Concat(companyType3);
                        object[] objArray4 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&ordid=", this.ordid, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, this.InvID, empty };
                        this.iframePathpdf = string.Concat(objArray4);
                        object[] pageType5 = new object[] { this.strSitepath, "settings/template_output.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, this.jID, this.InvID };
                        this.iframePathForEditTemplate = string.Concat(pageType5);
                        object[] objArray5 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&ordid=", this.ordid, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                        this.iframeEmailPath = string.Concat(objArray5);
                    }
                }
                else if (this.ordid == "")
                {
                    object[] companyType4 = new object[] { this.strSitepath, "Estimates/estimate_Email_ChooseTemplate.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname, "&type=", this.CompanyType, "&page=", this.PageType, "&EstID=", this.EstID, "&key=", this.TempKey, this.jID, this.InvID, empty };
                    this.iframePathChooseTemp = string.Concat(companyType4);
                    object[] pageType6 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&key=", this.TempKey, this.jID, this.InvID, empty };
                    this.iframePathpdf = string.Concat(pageType6);
                    object[] objArray6 = new object[] { this.strSitepath, "settings/template_output.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&key=", this.TempKey, this.jID, this.InvID };
                    this.iframePathForEditTemplate = string.Concat(objArray6);
                    object[] pageType7 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                    this.iframeEmailPath = string.Concat(pageType7);
                }
                else
                {
                    object[] companyType5 = new object[] { this.strSitepath, "Estimates/estimate_Email_ChooseTemplate.aspx?sectionid=", this.sectionid, "&sectionname=", this.sectionname, "&type=", this.CompanyType, "&page=", this.PageType, "&EstID=", this.EstID, "&ordid=", this.ordid, "&key=", this.TempKey, this.jID, this.InvID, empty };
                    this.iframePathChooseTemp = string.Concat(companyType5);
                    object[] objArray7 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&ordid=", this.ordid, "&EstID=", this.EstimateID, "&key=", this.TempKey, this.jID, this.InvID, empty };
                    this.iframePathpdf = string.Concat(objArray7);
                    object[] pageType8 = new object[] { this.strSitepath, "settings/template_output.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&key=", this.TempKey, this.jID, this.InvID };
                    this.iframePathForEditTemplate = string.Concat(pageType8);
                    object[] objArray8 = new object[] { this.strSitepath, "Estimates/estimate_email.aspx?page=", this.PageType, "&EstID=", this.EstID, "&sectionid=", this.sectionid, "&type=", this.CompanyType, "&sectionname=", this.sectionname, "&ordid=", this.ordid, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, empty };
                    this.iframeEmailPath = string.Concat(objArray8);
                }
                if (base.Request.Url.ToString().ToLower().Contains("proofs/templates_view1.aspx"))
                {
                    this.iframePath = string.Concat(this.iframeEmailPath, "&ProofID=", ProofID);
                }
                else
                {

                    if (!String.IsNullOrEmpty(this.customType))
                    {
                        DataTable dataTable = Settings.Default_templates_select(this.CompanyID, this.PageType);
                        if (this.customType.Contains("preview") )
                        {
                            if (dataTable.Rows.Count != 1)
                            {
                              //  this.iframePath = this.iframePathChooseTemp;
                                this.iframePath = string.Concat(this.iframePathChooseTemp, "&customtype=", this.customType);
                            }
                            else
                            {
                                this.OnlyOneTemp = "yes";
                                this.TemplateID = Convert.ToInt32(dataTable.Rows[0]["TemplateID"].ToString());
                                this.GeneratePDF_WhenOnlyOne();
                                this.pnlOnlyOneTemp.Visible = true;
                                this.iframePath = string.Concat(this.iframePathpdf, "&templateid=", this.TemplateID);
                                this.TempKey = base.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())].ToString();
                            }
                        }
                        if (this.customType.Contains("choosetemp"))
                        {
                          //  this.iframePath = this.iframePathChooseTemp;
                            this.iframePath = string.Concat(this.iframePathChooseTemp, "&customtype=", this.customType);
                        }
                      
                        if (this.customType.Contains("download"))
                        {
                            if (dataTable.Rows.Count != 1)
                            {
                              //  this.iframePath = this.iframePathChooseTemp;
                                this.iframePath = string.Concat(this.iframePathChooseTemp,"&customtype=", this.customType);

                            }
                            else
                            {
                                this.OnlyOneTemp = "yes";
                                this.TemplateID = Convert.ToInt32(dataTable.Rows[0]["TemplateID"].ToString());
                                this.GeneratePDF_WhenOnlyOne();
                                this.pnlOnlyOneTemp.Visible = true;
                                this.iframePath = string.Concat(this.iframePathpdf, "&templateid=", this.TemplateID, "&customtype=", this.customType); 
                                this.TempKey = base.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())].ToString();
                            }
                        }

                    }
                    else
                    {


                        DataTable dataTable = Settings.Default_templates_select(this.CompanyID, this.PageType);
                        if (dataTable.Rows.Count != 1)
                        {
                            this.iframePath = this.iframePathChooseTemp;
                        }
                        else
                        {
                            this.OnlyOneTemp = "yes";
                            this.TemplateID = Convert.ToInt32(dataTable.Rows[0]["TemplateID"].ToString());
                            this.GeneratePDF_WhenOnlyOne();
                            this.pnlOnlyOneTemp.Visible = true;
                            this.iframePath = string.Concat(this.iframePathpdf, "&templateid=", this.TemplateID);
                            this.TempKey = base.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())].ToString();
                        }
                    }
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("/jobs"))
            {
                this.Module = "jobs";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("/invoice"))
            {
                this.Module = "invoice";
            }
            if (this.Module.ToLower() == "jobs")
            {
                this.IS_INVOICEorJOB_from_Webstore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.Module);
                return;
            }
            if (this.Module.ToLower() == "invoice")
            {
                this.IS_INVOICEorJOB_from_Webstore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.Module);
            }
        }
    }
}