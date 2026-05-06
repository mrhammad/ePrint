using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.settings
{
    public partial class system_productlowstock_email : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public static int CompanyID;

        public static int UserID;

        private Global gloobj = new Global();

        public languageClass objLangauge = new languageClass();

        public string ServerName = ConnectionClass.ServerName;

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

        static system_productlowstock_email()
        {
        }

        public system_productlowstock_email()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings/system_productlowstock_email.aspx");
        }

        protected void btnSave_Onclick(object sender, EventArgs e)
        {
            int num = 0;
            if (this.chkDefaultEmailBody.Checked)
            {
                num = 1;
            }
            if (this.lblemail.Text == "")
            {
                SettingsBasePage.productcatalogue_StockReminderEmailBody_insert(system_productlowstock_email.CompanyID, system_productlowstock_email.UserID, base.SpecialEncode(this.txtemailtempname.Text), this.RadEditor1.Content.ToString(), num, base.SpecialEncode(this.txtSubject.Text));
            }
            else
            {
                SettingsBasePage.productcatalogue_StockReminderEmailBody_update(Convert.ToInt32(this.lblemail.Text), base.SpecialEncode(this.txtemailtempname.Text), this.RadEditor1.Content.ToString(), num, base.SpecialEncode(this.txtSubject.Text));
            }
            this.Getemaildetails();
        }

        public void Getemaildetails()
        {
            DataTable dataTable = SettingsBasePage.productcatalogue_StockReminderEmail_select(system_productlowstock_email.CompanyID);
            this.grdLowStockEmail.DataSource = dataTable;
            this.grdLowStockEmail.DataBind();
        }

        public void grdLowStockEmail_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaultVal");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkTemplateName");
                LinkButton linkButton1 = (LinkButton)e.Item.FindControl("lnkSubject");
                Image image = (Image)e.Item.FindControl("imgdefault");
                if (hiddenField.Value.ToLower() != "true")
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "1t.gif");
                }
                else
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                }
                linkButton.Text = base.SpecialDecode(linkButton.Text);
                linkButton1.Text = base.SpecialDecode(linkButton1.Text);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdLowStockEmail.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdLowStockEmail.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void lnkAddNew_OnClik(object sender, EventArgs e)
        {
            this.RadEditor1.Content = "";
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            foreach (GridDataItem item in this.grdLowStockEmail.MasterTableView.Items)
            {
                SettingsBasePage.productcatalogue_StockReminderEmail_delete(Convert.ToInt32(e.CommandArgument));
            }
            this.Getemaildetails();
            base.Message_Display(this.objLangauge.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkMultidelete_Onclick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEmailIdMultiple.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (strArrays[i] != "")
                {
                    SettingsBasePage.productcatalogue_StockReminderEmail_delete(Convert.ToInt32(strArrays[i]));
                }
            }
            this.Getemaildetails();
            base.Message_Display(this.objLangauge.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnktemplate_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataTable dataTable = SettingsBasePage.productcatalogue_StockReminderEmail_selectedrow(Convert.ToInt32(linkButton.CommandArgument.ToString()));
            this.txtemailtempname.Text = base.SpecialDecode(dataTable.Rows[0]["TemplateName"].ToString());
            this.txtSubject.Text = base.SpecialDecode(dataTable.Rows[0]["Subject"].ToString());
            this.RadEditor1.Content = dataTable.Rows[0]["Body"].ToString();
            this.chkDefaultEmailBody.Checked = Convert.ToBoolean(dataTable.Rows[0]["Isdefault"].ToString());
            this.hiddenEmailID.Value = linkButton.CommandArgument.ToString();
            this.lblemail.Text = linkButton.CommandArgument.ToString();
            this.txtemailtempname.Focus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.grdLowStockEmail.Columns[1].HeaderText = this.objLangauge.GetLanguageConversion("Template_Name");
            this.grdLowStockEmail.Columns[2].HeaderText = this.objLangauge.GetLanguageConversion("Subject");
            this.grdLowStockEmail.Columns[3].HeaderText = this.objLangauge.GetLanguageConversion("Default");
            this.grdLowStockEmail.Columns[4].HeaderText = this.objLangauge.GetLanguageConversion("Action");
            this.btnCancel.Text = this.objLangauge.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLangauge.GetLanguageConversion("Save");
            this.grdLowStockEmail.MasterTableView.NoMasterRecordsText = this.objLangauge.GetLanguageConversion("No_records_to_display");
            this.lnkDeleteStatus.Text = this.objLangauge.GetLanguageConversion("Detele_Selected");
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "hidetype();", true);
            system_productlowstock_email.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            system_productlowstock_email.UserID = Convert.ToInt32(this.Session["userid"].ToString());
            if (!base.IsPostBack)
            {
                this.Getemaildetails();
            }
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            system_productlowstock_email.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email"), "&nbsp;>>&nbsp;", this.objLangauge.GetLanguageConversion("Product_Stock_Reminder_Email")));
            base.Title = this.objLanguage.convert(global.pageTitle("System Stock Reminder Email", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLangauge.GetLanguageConversion("Product_Stock_Reminder_Email");
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadEditor1.ImageManager.UploadPaths = strArrays1;
            this.RadEditor1.ImageManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.UploadPaths = strArrays1;
            this.RadEditor1.DocumentManager.ViewPaths = strArrays1;
            this.RadEditor1.DocumentManager.UploadPaths = strArrays1;
        }
    }
}