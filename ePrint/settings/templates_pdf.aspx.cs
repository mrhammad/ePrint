using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Prefligt;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.settings
{
    public partial class templates_pdf : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        public int CompanyID;

        public int totalrec;

        private commonClass objJava = new commonClass();

        public languageClass objlang = new languageClass();

        public string ServerName = string.Empty;

        public Preflight_documents objPreFlight = new Preflight_documents();

        public string DateFormat = string.Empty;

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

        public templates_pdf()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            string reportFile = string.Empty;
            object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//TemplatePDF//" };
            empty = string.Concat(secureDocPath);
            if (this.txtFirstPageNo.Text != "")
            {
                num = Convert.ToInt32(this.txtFirstPageNo.Text);
            }
            if (this.txtLastPageNo.Text != "")
            {
                num1 = Convert.ToInt32(this.txtLastPageNo.Text);
            }
            if (this.hid_NewPDFName.Value != "")
            {
                string str = Guid.NewGuid().ToString();
                this.CompanyID = Convert.ToInt32(this.Session["companyID"].ToString());
                if (!this.fuPDF.HasFile)
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Please_select_one_pdf_to_upload"), "msg-fail", this.plhMessage);
                }
                else
                {
                    if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//")))
                    {
                        Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//"));
                    }
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//" };
                    if (!Directory.Exists(string.Concat(objArray)))
                    {
                        object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//" };
                        Directory.CreateDirectory(string.Concat(secureDocPath1));
                    }
                    object[] objArray1 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//TemplatePDF" };
                    if (!Directory.Exists(string.Concat(objArray1)))
                    {
                        object[] secureDocPath2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//TemplatePDF" };
                        Directory.CreateDirectory(string.Concat(secureDocPath2));
                    }
                    FileUpload fileUpload = this.fuPDF;
                    object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//TemplatePDF//", str, ".pdf" };
                    fileUpload.SaveAs(string.Concat(objArray2));
                    if (this.chkPreFlightFiles != null && this.chkPreFlightFiles.Checked)
                    {
                        PreflightParameters preflightParameter = this.objPreFlight.Preflight_file(string.Concat(str, ".pdf"), this.ddlPreFlightFiles.SelectedItem.Text, "", this.CompanyID.ToString(), empty);
                        if (preflightParameter.IsPreflighted)
                        {
                            str = preflightParameter.CorrectedFile;
                            reportFile = preflightParameter.ReportFile;
                        }
                    }
                    int num2 = SettingsBasePage.settings_templatespdf_insert(this.CompanyID, Convert.ToInt64(this.hid_PDFID.Value), base.SpecialEncode(this.txtTitle.Text), string.Concat(str, ".pdf"), str, reportFile);
                    SettingsBasePage.settings_templatespdf_pages_insert(num2, num, num1);
                    this.GridBind();
                    this.hidGridCount.Value = this.GridPDF.Items.Count.ToString();
                    if (num2 != -1)
                    {
                        this.txtTitle.Text = string.Empty;
                        base.Response.Redirect(string.Concat(this.strSitepath, "settings/templates_pdf.aspx?suc=in"));
                        return;
                    }
                }
            }
            else
            {
                if (this.chkPreFlightFiles != null && this.chkPreFlightFiles.Checked)
                {
                    PreflightParameters preflightParameter1 = this.objPreFlight.Preflight_file(this.hid_OldPDFName.Value, this.ddlPreFlightFiles.SelectedItem.Text, "", this.CompanyID.ToString(), empty);
                    if (preflightParameter1.IsPreflighted)
                    {
                        this.hid_OldPDFName.Value = preflightParameter1.CorrectedFile;
                        this.hid_OldReportFileName.Value = preflightParameter1.ReportFile;
                    }
                }
                int num3 = SettingsBasePage.settings_templatespdf_insert(this.CompanyID, Convert.ToInt64(this.hid_PDFID.Value), base.SpecialEncode(this.txtTitle.Text), this.hid_OldPDFName.Value, this.hid_OldPDFKey.Value, this.hid_OldReportFileName.Value);
                SettingsBasePage.settings_templatespdf_pages_insert(num3, num, num1);
                this.GridBind();
                this.hidGridCount.Value = this.GridPDF.Items.Count.ToString();
                if (num3 != -1)
                {
                    this.txtTitle.Text = string.Empty;
                    base.Response.Redirect(string.Concat(this.strSitepath, "settings/templates_pdf.aspx?suc=up"));
                    return;
                }
            }
        }

        public void GridBind()
        {
            this.odsPDF.TypeName = "Template";
            this.odsPDF.SelectMethod = "settings_template_pdf_select";
            this.odsPDF.SelectParameters.Clear();
            this.odsPDF.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.odsPDF.DataBind();
            DataTable table = ((DataView)this.odsPDF.Select()).Table;
            this.GridPDF.DataSource = table;
            this.GridPDF.DataBind();
            if (this.GridPDF.Items.Count != 0)
            {
                DataTable dataTable = ((DataView)this.odsPDF.Select()).Table;
                this.totalrec = dataTable.Rows.Count;
            }
            this.hidGridCount.Value = this.GridPDF.Items.Count.ToString();
        }

        protected void GridPDF_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Label label = (Label)e.Item.FindControl("lblIsReady");
                    label.Text = (label.Text == "0" ? "Processing" : "Ready");
                    //label.Text = (label.Text == "0" ? "Ready" : "Processing");
                }
            }
            catch (Exception exception)
            {
            }
            if (e.Item is GridDataItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnTitle");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnID");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnName");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdnKey");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdnReportFile");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdnImageName");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdnFirstPageNo");
                HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdnLastPageNo");
                HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("Title");
                HtmlAnchor htmlAnchor1 = (HtmlAnchor)e.Item.FindControl("Ready_For_Use");
                HtmlAnchor htmlAnchor2 = (HtmlAnchor)e.Item.FindControl("Date_Uploaded");
                HtmlAnchor htmlAnchor3 = (HtmlAnchor)e.Item.FindControl("Templates_No");
                AttributeCollection attributes = htmlAnchor.Attributes;
                string[] value = new string[] { "javascript:EditPDF('", hiddenField1.Value, "','", base.SpecialEncode(hiddenField.Value), "','", hiddenField2.Value, "','", hiddenField3.Value, "','", hiddenField5.Value, "','", hiddenField6.Value, "','", hiddenField7.Value, "','", hiddenField4.Value, "');" };
                attributes.Add("onclick", string.Concat(value));
                AttributeCollection attributeCollection = htmlAnchor1.Attributes;
                string[] strArrays = new string[] { "javascript:EditPDF('", hiddenField1.Value, "','", base.SpecialEncode(hiddenField.Value), "','", hiddenField2.Value, "','", hiddenField3.Value, "','", hiddenField5.Value, "','", hiddenField6.Value, "','", hiddenField7.Value, "','", hiddenField4.Value, "');" };
                attributeCollection.Add("onclick", string.Concat(strArrays));
                AttributeCollection attributeCollection2 = htmlAnchor2.Attributes;
                string[] strArrays2 = new string[] { "javascript:EditPDF('", hiddenField1.Value, "','", base.SpecialEncode(hiddenField.Value), "','", hiddenField2.Value, "','", hiddenField3.Value, "','", hiddenField5.Value, "','", hiddenField6.Value, "','", hiddenField7.Value, "','", hiddenField4.Value, "');" };
                attributeCollection.Add("onclick", string.Concat(strArrays2));
                AttributeCollection attributeCollection3 = htmlAnchor3.Attributes;
                string[] strArrays3 = new string[] { "javascript:EditPDF('", hiddenField1.Value, "','", base.SpecialEncode(hiddenField.Value), "','", hiddenField2.Value, "','", hiddenField3.Value, "','", hiddenField5.Value, "','", hiddenField6.Value, "','", hiddenField7.Value, "','", hiddenField4.Value, "');" };
                attributeCollection.Add("onclick", string.Concat(strArrays3));
                this.DateFormat = this.Session["DateFormat"].ToString();
                this.DateFormat = this.DateFormat.Replace("mm", "MM");
                object DateUploadedObj = DataBinder.Eval(e.Item.DataItem, "DateUploaded");
                if (DateUploadedObj != DBNull.Value && DateUploadedObj != null)
                {
                    DateTime dateUploaded = Convert.ToDateTime(DateUploadedObj);
                    htmlAnchor2.InnerText = dateUploaded.ToString(this.DateFormat); 
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridPDF.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridPDF.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridPDF_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridPDF.CurrentPageIndex = e.NewPageIndex;
            this.GridBind();
        }

        protected void GridPDF_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridBind();
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridPDF.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridPDF.Items[i].Cells[0].FindControl("Chkbx1");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_template_pdf_delete(this.CompanyID, (long)Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.GridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("PDF_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            this.GridPDF.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_display");
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_btnCancelprocess');");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["companyID"].ToString());
            this.txtTitle.Focus();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Templates_PDF")));
            base.Title = this.objLanguage.convert(global.pageTitle("Templates PDF", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Templates_PDF");
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.PreFlight_Options_Select("MIS", this.CompanyID);
                string str = "0";
                if (dataTable.Rows.Count != 0)
                {
                    DataTable dataTable1 = CompanyBasePage.PreflightProfile_Select();
                    this.ddlPreFlightFiles.DataSource = dataTable1;
                    this.ddlPreFlightFiles.DataTextField = "ProfileName";
                    this.ddlPreFlightFiles.DataValueField = "Id";
                    this.ddlPreFlightFiles.DataBind();
                    this.ddlPreFlightFiles.Items.Insert(0, new ListItem("---Select Profile---", "0"));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        str = row["ProfileId"].ToString();
                        if (Convert.ToInt32(row["IsEnabled"]) != 1)
                        {
                            this.hid_IsPreFlight.Value = "0";
                            this.chkPreFlightFiles.Visible = false;
                            this.ddlPreFlightFiles.Visible = false;
                        }
                        else
                        {
                            AttributeCollection attributes = this.chkPreFlightFiles.Attributes;
                            string[] clientID = new string[] { "javascript:EnablePreFlightDdl(", this.chkPreFlightFiles.ClientID, ",", this.ddlPreFlightFiles.ClientID, ");" };
                            attributes.Add("onclick", string.Concat(clientID));
                            this.hid_IsPreFlight.Value = "1";
                        }
                    }
                    this.ddlPreFlightFiles.SelectedIndex = this.ddlPreFlightFiles.Items.IndexOf(this.ddlPreFlightFiles.Items.FindByValue(str));
                    this.chkPreFlightFiles.Checked = false;
                    this.ddlPreFlightFiles.Enabled = false;
                }
                else
                {
                    this.hid_IsPreFlight.Value = "0";
                    this.chkPreFlightFiles.Visible = false;
                    this.ddlPreFlightFiles.Visible = false;
                }
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["suc"] != null)
                {
                    if (base.Request.Params["suc"].ToString().ToLower() == "in")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("PDF_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "up")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("PDF_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "de")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("PDF_Deleted_Successfully"), "msg-success", this.plhMessage);
                    }
                }
                this.GridBind();
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            this.btnSave.Attributes.Add("onclick", "javascript:var a=uploadCheck();if(a)loadingimage(this.id,'div_btnsaveprocessprocess');return a;");
        }

        private void paging_OnPageChange(int PageNumber)
        {
            this.GridPDF.DataBind();
        }
    }
}