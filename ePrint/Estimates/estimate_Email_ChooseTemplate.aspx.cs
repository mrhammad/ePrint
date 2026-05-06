using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Estimates
{
    public partial class estimate_Email_ChooseTemplate : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string strFilepath = global.filePath();

        private BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        private Template objTemplate = new Template();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private Global gloobj = new Global();

        private int CompanyID;

        public int UserID;

        public int TemplateID;

        public long EstimateID;

        public long EstimateItemID;

        private int CustomerID;

        private int AttentionID;

        private string[] arryTag;

        private string TagNames = string.Empty;

        private int Items;

        private string RFQdescription = string.Empty;

        private string StrEsimateItemID = string.Empty;

        private string StrEstimateType = string.Empty;

        public long EstID;

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

        public string iframeEmailpPath = string.Empty;

        public int EmailCount;

        public string TempKey = string.Empty;

        public object objPrintBroker;

        public string OnlyOneTemp = string.Empty;

        public int PageSize = 200;

        public string ordid = string.Empty;

        public string maintype = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        protected Random rGen;

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

        public estimate_Email_ChooseTemplate()
        {
        }

        public new string GenPassWithCap(int i)
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

        public void GridBind(int PageNumber)
        {
            this.odsTemplate.TypeName = "Printcenter.UI.Setting.SettingsBasePage";
            this.odsTemplate.SelectMethod = "settings_templates_select";
            this.odsTemplate.SelectParameters.Clear();
            this.odsTemplate.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.odsTemplate.SelectParameters.Add("ModuleName", this.PageType);
            this.odsTemplate.DataBind();
            DataTable table = ((DataView)this.odsTemplate.Select()).Table;
            this.GridTemplate.DataSource = table;
            this.GridTemplate.DataBind();
            this.lblTotalRecords.Text = table.Rows.Count.ToString();
        }

        protected void GridTemplate_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string text = ((Label)e.Row.FindControl("lblID")).Text;
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Row.FindControl(text ?? "");
                Label label = (Label)e.Row.FindControl("lblIsDefault");
                Convert.ToBoolean(label.Text);
                e.Row.Attributes.Add("onclick", string.Concat("javascript:GeneratePDF('", text, "')"));
                e.Row.Attributes["onmouseover"] = string.Format("javascript:ItemOnMouseOver(this);", new object[0]);
                e.Row.Attributes["onmouseout"] = string.Format("javascript:ItemOnMouseOut(this);", new object[0]);
            }
        }

        protected void lnkTempName_OnClick(object sender, EventArgs e)
        {
            this.GridTemplate.Visible = false;
            LinkButton linkButton = (LinkButton)sender;
            this.hdnTemplateValue.Value = linkButton.CommandArgument.ToString();
            this.TemplateID = Convert.ToInt32(this.hdnTemplateValue.Value);
            this.Session["TemplateHTML"] = null;
            this.Session["TemplateControlList"] = null;
            this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] = null;
            this.Session["isSplit"] = null;
            this.Session["TemplateID"] = this.TemplateID.ToString();
            this.Session["TempNameLastCounter"] = null;
            string str = this.GenPassWithCap(12);
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable = new DataTable();
            if (base.Request.Params["Page"].ToString().ToLower() != "job")
            {
                dataTable = (base.Request.Params["Page"].ToString().ToLower() != "invoice" ? SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.EstimateID, base.Request.Params["page"]) : SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.InvoiceID, base.Request.Params["page"]));
            }
            else
            {
                dataTable = SettingsBasePage.settings_titlecode_fortemplate_select(this.CompanyID, this.jobID, base.Request.Params["page"]);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                empty1 = row["Number"].ToString();
                str1 = row["TemNameLastCounter"].ToString();
            }
            base.Request.Url.ToString();
            if (base.Request.Url.ToString().ToLower().Contains("estimates/estimate_email_choosetemplate.aspx"))
            {
                this.PDFIsFrom = "e";
            }
            if (base.Request.Params["Page"].ToString().ToLower() != "printbroker")
            {
                empty = string.Concat(empty1, "-", str1, ".pdf");
                SettingsBasePage.settings_template_emailed_insert(empty, str, (long)Convert.ToInt32(this.Session["CompanyID"]));
            }
            else if (base.Request.Params["Page"].ToString().ToLower() == "printbroker")
            {
                DataTable dataTable1 = new DataTable();
                if (base.Request.Params["isdirect"] == null)
                {
                    dataTable1 = this.objTemplate.estimate_itemid_select(this.CompanyID, Convert.ToInt64(this.EstimateID), (long)0);
                }
                else
                {
                    long num = (long)0;
                    if (base.Request.Params["EstItemID"] != null)
                    {
                        num = Convert.ToInt64(base.Request.Params["EstItemID"]);
                    }
                    dataTable1 = this.objTemplate.estimate_itemid_select(this.CompanyID, Convert.ToInt64(this.EstimateID), num);
                }
                this.EmailCount = dataTable1.Rows.Count;
                for (int i = 1; i <= this.EmailCount; i++)
                {
                    string[] strArrays = new string[] { empty1, "_", dataTable1.Rows[i - 1]["AttachmentTypeID"].ToString(), "_", dataTable1.Rows[i - 1]["SupplierID"].ToString(), "-", str1, ".pdf" };
                    empty = string.Concat(strArrays);
                    string[] strArrays1 = new string[] { dataTable1.Rows[i - 1]["AttachmentTypeID"].ToString(), "_", dataTable1.Rows[i - 1]["SupplierID"].ToString(), "_", str };
                    SettingsBasePage.settings_template_emailed_insert(empty, string.Concat(strArrays1), (long)Convert.ToInt32(this.Session["CompanyID"]));
                    this.Session["TempNameLastCounter"] = str1;
                }
            }
            if (str != "")
            {
                this.Session[string.Concat("NewTempKey", this.EstimateID.ToString().Trim())] = str;
            }
            string empty2 = string.Empty;
            if (base.Request.Params["isdirect"] != null)
            {
                empty2 = "&isdirect=1";
            }
            string empty3 = string.Empty;
            if (base.Request.Params["customtype"] != null)
            {
                empty3 = "&customtype="+ base.Request.Params["customtype"].ToString();
            }
            string str2 = string.Empty;
            if (base.Request.Params["Page"].ToString().ToLower() == "jobcard" || base.Request.Params["Page"].ToString().ToLower() == "printbroker")
            {
                if (this.ordid == "")
                {
                    object[] pageType = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, "&templateid=", this.TemplateID, this.jID, this.InvID, empty2, empty3 };
                    str2 = string.Concat(pageType);
                }
                else
                {
                    object[] objArray = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&ordid=", this.ordid, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, "&templateid=", this.TemplateID, this.jID, this.InvID, empty2, empty3 };
                    str2 = string.Concat(objArray);
                }
            }
            else if (base.Request.Params["Page"].ToString().ToLower() == "job" && this.EstimateItemID > (long)0)
            {
                if (this.ordid == "")
                {
                    object[] pageType1 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, "&templateid=", this.TemplateID, this.jID, this.InvID, empty2, empty3 };
                    str2 = string.Concat(pageType1);
                }
                else
                {
                    object[] objArray1 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&ordid=", this.ordid, "&EstID=", this.EstimateID, "&EstItemID=", this.EstimateItemID, "&From=", this.PDFIsFrom, "&key=", this.TempKey, "&templateid=", this.TemplateID, this.jID, this.InvID, empty2, empty3 };
                    str2 = string.Concat(objArray1);
                }
            }
            else if (this.ordid == "")
            {
                object[] pageType2 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&EstID=", this.EstimateID, "&key=", this.TempKey, "&templateid=", this.TemplateID, this.jID, this.InvID, empty2,empty3 };
                str2 = string.Concat(pageType2);
            }
            else
            {
                object[] objArray2 = new object[] { this.strSitepath, "pdf_generate1.aspx?page=", this.PageType, "&ordid=", this.ordid, "&EstID=", this.EstimateID, "&key=", this.TempKey, "&templateid=", this.TemplateID, this.jID, this.InvID, empty2, empty3 };
                str2 = string.Concat(objArray2);
            }
            Type type = base.GetType();
            object[] templateID = new object[] { "enablebtns('", str2, "','", this.TemplateID, "');" };
            System.Web.UI.ScriptManager.RegisterStartupScript(this, type, "Enable", string.Concat(templateID), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            this.EstimateID = Convert.ToInt64(base.Request.Params["EstID"]);
            this.EstID = this.EstimateID;
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            this.PageType = base.Request.Params["page"];
            this.sectionid = Convert.ToInt32(base.Request.Params["sectionid"]);
            this.sectionname = base.Request.Params["sectionname"];
            this.CompanyType = base.Request.Params["type"];
            if (!base.IsPostBack)
            {
                this.GridTemplate.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Template_Name");
                this.GridTemplate.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Description");
            }
            if (this.sectionname.ToLower() != "printbroker")
            {
                this.gloobj.setpagename(this.sectionname.ToLower());
            }
            else
            {
                this.gloobj.setpagename("estimate");
            }
            if (base.Request.Params["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            }
            if (base.Request.Params["ordid"] != null)
            {
                this.ordid = base.Request.Params["ordid"].ToString();
            }
            this.GridBind(1);
        }
    }
}