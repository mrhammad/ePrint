using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.settings
{
    public partial class templates : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public int totalrec;

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        private Global gloobj = new Global();

        public string report_page = string.Empty;

        public languageClass objlang = new languageClass();

        private BaseClass objBase = new BaseClass();

        public string ModuleName = string.Empty;

        public string ImgPath = global.imagePath();

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

        public templates()
        {
        }

        protected void btn_Delete(object sender, EventArgs e)
        {
            SettingsBasePage.settings_template_Delete(this.companyid, Convert.ToInt32(this.hdnID.Value));
            this.GridBind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Template_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat("templates_add.aspx?page=", this.report_page, "&action=add"));
        }

        public void GridBind()
        {
            this.odsTemplate.TypeName = "Printcenter.UI.Setting.SettingsBasePage";
            this.odsTemplate.SelectMethod = "settings_templates_select";
            this.odsTemplate.SelectParameters.Clear();
            this.odsTemplate.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.odsTemplate.SelectParameters.Add("ModuleName", this.report_page);
            this.odsTemplate.DataBind();
            DataTable table = ((DataView)this.odsTemplate.Select()).Table;
            this.GridTemplate.DataSource = table;
            this.GridTemplate.DataBind();
            if (this.GridTemplate.Items.Count == 0)
            {
                return;
            }
            DataTable dataTable = ((DataView)this.odsTemplate.Select()).Table;
            this.totalrec = dataTable.Rows.Count;
        }

        protected void GridTemplate_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                LinkButton linkButton = (LinkButton)e.Item.Cells[0].FindControl("lnkName");
                LinkButton linkButton1 = (LinkButton)e.Item.Cells[0].FindControl("lnkDescription");
                LinkButton linkButton2 = (LinkButton)e.Item.Cells[0].FindControl("lnkModifiedDate");
                LinkButton linkButton3 = (LinkButton)e.Item.Cells[0].FindControl("lnkModifiedBy");
                LinkButton linkButton4 = (LinkButton)e.Item.Cells[0].FindControl("lnkLastUsed");
                ImageButton imageButton = (ImageButton)e.Item.Cells[0].FindControl("imgbtnCopy");
                int num = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TemplateID"));
                ImageButton imageButton1 = (ImageButton)e.Item.FindControl("img_DefaultTemplate");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_DefaultTemplate");
                Label label = (Label)e.Item.Cells[0].FindControl("lblIsDefault");
                HtmlImage htmlImage = (HtmlImage)e.Item.Cells[0].FindControl("imgCheck");
                ImageButton imageButton2 = (ImageButton)e.Item.FindControl("btnimgeditproperty");
                object[] reportPage = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num };
                imageButton2.PostBackUrl = string.Concat(reportPage);
                object[] objArray = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num };
                linkButton.PostBackUrl = string.Concat(objArray);
                object[] reportPage1 = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num };
                linkButton1.PostBackUrl = string.Concat(reportPage1);
                object[] reportPage2 = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num };
                linkButton2.PostBackUrl = string.Concat(reportPage2);
                object[] reportPage3 = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num };
                linkButton3.PostBackUrl = string.Concat(reportPage3);
                object[] reportPage4 = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num };
                linkButton4.PostBackUrl = string.Concat(reportPage4);
                object[] objArray1 = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", num, "&copy=yes" };
                imageButton.PostBackUrl = string.Concat(objArray1);
                object[] str = new object[] { "templates_editproperty.aspx?id=", num, "&page=", base.Request.Params["page"].ToString() };
                imageButton2.PostBackUrl = string.Concat(str);
                if (hiddenField.Value != "True")
                {
                    imageButton1.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_u.gif");
                }
                else
                {
                    imageButton1.ImageUrl = string.Concat(this.ImgPath, "ICON_checkboxNew.gif");
                }
                this.DateFormat = this.Session["DateFormat"].ToString();
                this.DateFormat = this.DateFormat.Replace("mm", "MM");
                object modifiedDateObj = DataBinder.Eval(e.Item.DataItem, "ModifiedDate");
                object modifiedByObj = DataBinder.Eval(e.Item.DataItem, "ModifiedBy");
                object lastUsedObj = DataBinder.Eval(e.Item.DataItem, "LastUsed");
                if (modifiedDateObj != DBNull.Value && modifiedDateObj != null)
                {
                    DateTime modifiedDate = Convert.ToDateTime(modifiedDateObj);
                    linkButton2.Text = modifiedDate.ToString(this.DateFormat); 
                }
                if (modifiedByObj != DBNull.Value && modifiedByObj != null)
                {
                    linkButton3.Text = modifiedByObj.ToString(); // just showing value
                }
                if (lastUsedObj != DBNull.Value && lastUsedObj != null)
                {
                    DateTime lastUsed = Convert.ToDateTime(lastUsedObj);
                    linkButton4.Text = lastUsed.ToString(this.DateFormat);
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridTemplate.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridTemplate.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridTemplate_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridTemplate.CurrentPageIndex = e.NewPageIndex;
            this.GridTemplate.Rebind();
        }

        protected void GridTemplate_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridTemplate.Rebind();
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (base.Request.Params["page"] != null)
            {
                if (base.Request.Params["page"].ToString().ToLower() != "webstoreorder")
                {
                    this.MasterPageFile = "~/Templates/settingpage.master";
                }
                else
                {
                    this.MasterPageFile = "~/Templates/SettingsEstore.master";
                }
            }
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridTemplate.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("DEfault");
            this.GridTemplate.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_display");
            this.gloobj.setpagename("setting");
            this.report_page = base.Request.Params["page"].ToString();
            if (this.report_page.ToLower().Trim() == "note")
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Delivery_Note"));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Delivery_Note"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle("Delivery Note: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Delivery_Note"), " ", this.objLanguage.GetLanguageConversion("Templates"));
            }
            else if (this.report_page.ToLower().Trim() == "printbroker")
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Supplier_RFQs"));
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Supplier_RFQs"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle("Supplier RFQs: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Supplier_RFQs"), " ", this.objLanguage.GetLanguageConversion("Templates"));
            }
            else if (this.report_page.ToLower().Trim() == "job")
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Job"));
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle("Job: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates"));
            }
            else if (this.report_page.ToLower().Trim() != "webstoreorder")
            {
                if (this.report_page.ToLower().Trim() == "invoice")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Invoice"));
                    string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Invoice"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                    this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Invoice"), " ", this.objLanguage.GetLanguageConversion("Templates"));
                }
                else if (this.report_page.ToLower().Trim() == "estimate")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Estimate"));
                    string[] languageConversion2 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion2), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Estimate"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                    this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Estimate"), " ", this.objLanguage.GetLanguageConversion("Templates"));
                }
                else if (this.report_page.ToLower().Trim() == "job")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("job"));
                    string[] strArrays2 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays2), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                    this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates"));
                }
                else if (this.report_page.ToLower().Trim() == "purchase")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Purchase"));
                    string[] languageConversion3 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion3), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Purchase"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                    this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Purchase"), " ", this.objLanguage.GetLanguageConversion("Templates"));
                }
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(this.report_page, " Templates"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Estore_Order"));
                string[] strArrays3 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Storesettings/Storesettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays3), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Estore_Order"), " ", this.objLanguage.GetLanguageConversion("Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle("eStore Order: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = string.Concat(this.objLanguage.GetLanguageConversion("Estore_Order"), " ", this.objLanguage.GetLanguageConversion("Templates"));
            }
            base.Title = "Settings: Templates";
            this.GridBind();
        }

        private void paging_OnPageChange(int PageNumber)
        {
            this.GridTemplate.DataBind();
            this.GridBind();
        }

        protected void setDefaulTemplate_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage settingsBasePage = new SettingsBasePage();
            SettingsBasePage.settings_default_template_update(Convert.ToInt32(this.Session["CompanyID"].ToString()), Convert.ToInt32(e.CommandArgument), this.report_page);
            this.objBase.Message_Display(this.objlang.GetLanguageConversion("Default_template_set_successfully"), "msg-success", this.plhMessage);
            this.GridBind();
            this.GridTemplate.Rebind();
        }
    }
}