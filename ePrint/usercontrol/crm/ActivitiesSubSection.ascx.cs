using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.crm
{
    public partial class ActivitiesSubSection : System.Web.UI.UserControl
    {
        //protected Label lbl_Estimates;

        //protected LinkButton lnk_EstimatesTab;

        //protected HtmlGenericControl div_EstimatesTab;

        //protected UpdatePanel up_Estimates;

        //protected Label lbl_eStore;

        //protected LinkButton lnk_eStoreTab;

        //protected UpdatePanel up_eStore;

        //protected Label lbl_Jobs;

        //protected LinkButton lnk_JobsTab;

        //protected UpdatePanel up_Jobs;

        //protected Label lbl_Invoices;

        //protected LinkButton lnk_InvoicesTab;

        //protected UpdatePanel up_Invoice;

        //protected DropDownList ddlRecordTab;

        //protected PlaceHolder plh_EstimatesDetails;

        //protected UpdatePanel up_EstimatesDetails;

        //protected HtmlGenericControl div_EstimatesMain;

        //protected PlaceHolder plh_eStoreDetails;

        //protected UpdatePanel up_eStoreDetails;

        //protected HtmlGenericControl div_eStoreMain;

        //protected PlaceHolder plh_JobsDetails;

        //protected UpdatePanel up_JobsDetails;

        //protected HtmlGenericControl div_JobsMain;

        //protected PlaceHolder plh_InvoiceDetails;

        //protected UpdatePanel up_InvoiceDetails;

        //protected HtmlGenericControl div_InvoicesMain;

        //protected HtmlGenericControl div_History;

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string web_key = string.Empty;

        public string WebStorePath = string.Empty;

        public string FileExtension = string.Empty;

        public string QSsuc = string.Empty;

        public string strSuc = string.Empty;

        public string DateFormat = string.Empty;

        public string companytype = string.Empty;

        public string companyName = string.Empty;

        public string From = string.Empty;

        public string ImgPath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

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

        public ActivitiesSubSection()
        {
        }

        public void get_EstimateTab()
        {
            base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value = "activities";
            this.plh_EstimatesDetails.Controls.Clear();
            EstimateSubSection userControl = (EstimateSubSection)base.LoadControl("~/usercontrol/crm/EstimateSubSection.ascx");
            userControl.ID = "EstimateSubSection";
            this.plh_EstimatesDetails.Controls.Add(userControl);
            this.lbl_Estimates.Style.Add("color", "Red");
            this.lbl_eStore.Style.Add("color", "Black");
            this.lbl_Jobs.Style.Add("color", "Black");
            this.lbl_Invoices.Style.Add("color", "Black");
            this.div_EstimatesMain.Style.Add("display", "block");
            this.div_eStoreMain.Style.Add("display", "none");
            this.div_JobsMain.Style.Add("display", "none");
            this.div_InvoicesMain.Style.Add("display", "none");
            try
            {
                this.objBase.SetDDLValue(this.ddlRecordTab, "Estimate");
            }
            catch
            {
            }
        }

        public void get_eStoreTab()
        {
            base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value = "estore";
            this.plh_eStoreDetails.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/crm/eStoreSubSection.ascx");
            userControl.ID = "eStoreSubSection";
            this.plh_eStoreDetails.Controls.Add(userControl);
            this.lbl_Estimates.Style.Add("color", "Black");
            this.lbl_eStore.Style.Add("color", "Red");
            this.lbl_Jobs.Style.Add("color", "Black");
            this.lbl_Invoices.Style.Add("color", "Black");
            this.div_EstimatesMain.Style.Add("display", "none");
            this.div_eStoreMain.Style.Add("display", "block");
            this.div_JobsMain.Style.Add("display", "none");
            this.div_InvoicesMain.Style.Add("display", "none");
            try
            {
                this.objBase.SetDDLValue(this.ddlRecordTab, "eStoreorder");
            }
            catch
            {
            }
        }

        public void get_InvoicesTab()
        {
            base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value = "invoices";
            this.plh_InvoiceDetails.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/crm/InvoicesSubSection.ascx");
            userControl.ID = "InvoicesSubSection";
            this.plh_InvoiceDetails.Controls.Add(userControl);
            this.lbl_Estimates.Style.Add("color", "Black");
            this.lbl_eStore.Style.Add("color", "Black");
            this.lbl_Jobs.Style.Add("color", "Black");
            this.lbl_Invoices.Style.Add("color", "Red");
            this.div_EstimatesMain.Style.Add("display", "none");
            this.div_eStoreMain.Style.Add("display", "none");
            this.div_JobsMain.Style.Add("display", "none");
            this.div_InvoicesMain.Style.Add("display", "block");
            try
            {
                this.objBase.SetDDLValue(this.ddlRecordTab, "Invoices");
            }
            catch
            {
            }
        }

        public void get_JobsTab()
        {
            base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value = "jobs";
            this.plh_JobsDetails.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/crm/JobsSubSection.ascx");
            userControl.ID = "JobsSubSection";
            this.plh_JobsDetails.Controls.Add(userControl);
            this.lbl_Estimates.Style.Add("color", "Black");
            this.lbl_eStore.Style.Add("color", "Black");
            this.lbl_Jobs.Style.Add("color", "Red");
            this.lbl_Invoices.Style.Add("color", "Black");
            this.div_EstimatesMain.Style.Add("display", "none");
            this.div_eStoreMain.Style.Add("display", "none");
            this.div_JobsMain.Style.Add("display", "block");
            this.div_InvoicesMain.Style.Add("display", "none");
            try
            {
                this.objBase.SetDDLValue(this.ddlRecordTab, "Job");
            }
            catch
            {
            }
        }

        public void get_TabNameFromSettings(int CompanyID, int UserID)
        {
            DataTable dataTable = CompanyBasePage.crm_select_HeaderImage_new1(CompanyID, UserID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["headerName"].ToString().ToLower() == "estimates")
                    {
                        this.lbl_Estimates.Text = row["ScreenName"].ToString();
                    }
                    if (row["headerName"].ToString().ToLower() == "webstoreorder")
                    {
                        this.lbl_eStore.Text = row["ScreenName"].ToString();
                    }
                    if (row["headerName"].ToString().ToLower() == "jobs")
                    {
                        this.lbl_Jobs.Text = row["ScreenName"].ToString();
                    }
                    if (row["headerName"].ToString().ToLower() != "invoices")
                    {
                        continue;
                    }
                    this.lbl_Invoices.Text = row["ScreenName"].ToString();
                }
            }
        }

        protected void lnk_EstimatesTab_Click(object sender, EventArgs e)
        {
            this.get_EstimateTab();
        }

        protected void lnk_eStoreTab_Click(object sender, EventArgs e)
        {
            this.get_eStoreTab();
        }

        protected void lnk_InvoicesTab_Click(object sender, EventArgs e)
        {
            this.get_InvoicesTab();
        }

        protected void lnk_JobsTab_Click(object sender, EventArgs e)
        {
            this.get_JobsTab();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            try
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                this.ClientID = int.Parse(arrayLists[1].ToString());
                this.CompanyName = arrayLists[3].ToString();
                this.CompanyType = arrayLists[7].ToString();
            }
            catch
            {
            }
            string str1 = this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdisplay", "");
            string str2 = this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdisplay", "");
            string str3 = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdisplay", "");
            string str4 = this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdisplay", "");
            DataTable dataTable = new DataTable();
            if (this.CompanyType.ToLower().Trim() != "prospect")
            {
                dataTable.Columns.Add("Value", typeof(string));
                dataTable.Columns.Add("Text", typeof(string));
                if (str1 != "false")
                {
                    DataRowCollection rows = dataTable.Rows;
                    object[] languageConversion = new object[] { "Estimate", this.objLanguage.GetLanguageConversion("Estimate") };
                    rows.Add(languageConversion);
                }
                if (str2 != "false")
                {
                    DataRowCollection dataRowCollection = dataTable.Rows;
                    object[] objArray = new object[] { "eStoreorder", this.objLanguage.GetLanguageConversion("eStore_order") };
                    dataRowCollection.Add(objArray);
                }
                if (str3 != "false")
                {
                    DataRowCollection rows1 = dataTable.Rows;
                    object[] languageConversion1 = new object[] { "Job", this.objLanguage.GetLanguageConversion("Job") };
                    rows1.Add(languageConversion1);
                }
                if (str4 != "false")
                {
                    DataRowCollection dataRowCollection1 = dataTable.Rows;
                    object[] objArray1 = new object[] { "Invoices", this.objLanguage.GetLanguageConversion("Invoices") };
                    dataRowCollection1.Add(objArray1);
                }
                if (dataTable.Rows.Count <= 0)
                {
                    this.ddlRecordTab.Visible = false;
                }
                else
                {
                    this.ddlRecordTab.DataSource = dataTable;
                    this.ddlRecordTab.DataValueField = "Value";
                    this.ddlRecordTab.DataTextField = "Text";
                    this.ddlRecordTab.DataBind();
                }
            }
            else
            {
                this.up_eStore.Visible = false;
                dataTable.Columns.Add("Value", typeof(string));
                dataTable.Columns.Add("Text", typeof(string));
                if (str1 != "false")
                {
                    DataRowCollection rows2 = dataTable.Rows;
                    object[] languageConversion2 = new object[] { "Estimate", this.objLanguage.GetLanguageConversion("Estimate") };
                    rows2.Add(languageConversion2);
                }
                if (str3 != "false")
                {
                    DataRowCollection dataRowCollection2 = dataTable.Rows;
                    object[] objArray2 = new object[] { "Job", this.objLanguage.GetLanguageConversion("Job") };
                    dataRowCollection2.Add(objArray2);
                }
                if (str4 != "false")
                {
                    DataRowCollection rows3 = dataTable.Rows;
                    object[] languageConversion3 = new object[] { "Invoices", this.objLanguage.GetLanguageConversion("Invoices") };
                    rows3.Add(languageConversion3);
                }
                if (dataTable.Rows.Count <= 0)
                {
                    this.ddlRecordTab.Visible = false;
                }
                else
                {
                    this.ddlRecordTab.DataSource = dataTable;
                    this.ddlRecordTab.DataValueField = "Value";
                    this.ddlRecordTab.DataTextField = "Text";
                    this.ddlRecordTab.DataBind();
                }
            }
            this.get_TabNameFromSettings(this.CompanyID, this.UserID);
            if (dataTable.Rows.Count > 0)
            {
                base.Response.Cookies[string.Concat("CRMTabName", this.ClientID)].Value = this.ddlRecordTab.SelectedItem.Text.ToString();
            }
            if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)] != null)
            {
                if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "activities")
                {
                    this.plh_EstimatesDetails.Controls.Clear();
                    this.get_EstimateTab();
                    return;
                }
                if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "estore")
                {
                    this.get_eStoreTab();
                    return;
                }
                if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "jobs")
                {
                    this.get_JobsTab();
                    return;
                }
                if (base.Request.Cookies[string.Concat("CRMTabName", this.ClientID)].Value == "invoices")
                {
                    this.get_InvoicesTab();
                    return;
                }
                this.plh_EstimatesDetails.Controls.Clear();
                this.get_EstimateTab();
            }
        }
    }
}