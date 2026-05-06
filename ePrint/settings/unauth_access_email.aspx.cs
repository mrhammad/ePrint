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
    public partial class unauth_access_email : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private SettingsBasePage objset = new SettingsBasePage();

        private BaseClass objBass = new BaseClass();

        private Global gloobj = new Global();

        public languageClass objLangauge = new languageClass();

        private int CompanyID;

        private int UserID;

        public static int ddlSelectedValue;

        public string serverName = ConnectionClass.ServerName;

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

        static unauth_access_email()
        {
        }

        public unauth_access_email()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings/unauth_access_email.aspx");
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
                SettingsBasePage.Unauth_Access_EmailBody_insert(this.CompanyID, this.UserID, this.txtName.Text, this.txtSubject.Text, this.RadEditor1.Content.ToString(), Convert.ToInt32(this.ddlFooterSignature.SelectedValue), Convert.ToBoolean(num), (long)0);
                base.Message_Display(this.objLangauge.GetLanguageConversion("Data_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                SettingsBasePage.Unauth_Access_EmailBody_insert(this.CompanyID, this.UserID, this.txtName.Text, this.txtSubject.Text, this.RadEditor1.Content.ToString(), Convert.ToInt32(this.ddlFooterSignature.SelectedValue), Convert.ToBoolean(num), (long)Convert.ToInt32(this.lblemail.Text));
                base.Message_Display(this.objLangauge.GetLanguageConversion("Data_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.Getemaildetails();
        }

        public void ddlEmailSignature()
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Select_EmailSignature(this.CompanyID);
            this.ddlFooterSignature.DataSource = dataTable;
            this.ddlFooterSignature.DataTextField = "FooterTitle";
            this.ddlFooterSignature.DataValueField = "EmailFooterID";
            this.ddlFooterSignature.DataBind();
            this.ddlFooterSignature.Items.Insert(0, "--- Select ---");
            this.ddlFooterSignature.Items[0].Text = "--- Select ---";
            this.ddlFooterSignature.Items[0].Value = "0";
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Isdefault"].ToString().ToLower() != "true")
                {
                    unauth_access_email.ddlSelectedValue = 0;
                }
                else
                {
                    this.objBass.SetDDLValue(this.ddlFooterSignature, row["EmailFooterID"].ToString());
                    unauth_access_email.ddlSelectedValue = Convert.ToInt16(row["EmailFooterID"]);
                    break;
                }
            }
            this.txtName.Text = string.Empty;
            this.RadEditor1.Content = string.Empty;
            this.chkDefaultEmailBody.Checked = false;
        }

        public void Getemaildetails()
        {
            DataTable dataTable = SettingsBasePage.Unauth_Access_EmailBody_Select(this.CompanyID);
            this.grdUnthorisedaccess.DataSource = dataTable;
            this.grdUnthorisedaccess.DataBind();
        }

        public void grdUnthorisedaccess_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaultValue");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkTemplateName");
                LinkButton linkButton1 = (LinkButton)e.Item.FindControl("lnkTemplateSubject");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonErase");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("chkSelectGrid");
                Image image = (Image)e.Item.FindControl("imgdefault");
                if (hiddenField.Value.ToLower() == "true")
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    imageButton.Visible = false;
                    htmlInputCheckBox.Disabled = true;
                    return;
                }
                image.ImageUrl = string.Concat(this.strImagepath, "1t.gif");
            }
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.Unauth_Access_EmailBody_delete((long)Convert.ToInt32(e.CommandArgument));
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
                    SettingsBasePage.Unauth_Access_EmailBody_delete((long)Convert.ToInt32(strArrays[i]));
                }
            }
            this.Getemaildetails();
            base.Message_Display(this.objLangauge.GetLanguageConversion("Email_Body_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnktemplate_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataTable dataTable = SettingsBasePage.Unauth_Access_EmailBody_selectedrow((long)Convert.ToInt32(linkButton.CommandArgument.ToString()));
            this.txtName.Text = dataTable.Rows[0]["TemplateName"].ToString();
            this.txtSubject.Text = dataTable.Rows[0]["Subject"].ToString();
            this.objBass.SetDDLValue(this.ddlFooterSignature, dataTable.Rows[0]["FooterID"].ToString());
            this.RadEditor1.Content = dataTable.Rows[0]["Body"].ToString();
            this.chkDefaultEmailBody.Checked = Convert.ToBoolean(dataTable.Rows[0]["Isdefault"].ToString());
            this.hiddenEmailID.Value = linkButton.CommandArgument.ToString();
            this.lblemail.Text = linkButton.CommandArgument.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:addnew('edit');", true);
            this.txtName.Focus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.serverName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.RadEditor1.ImageManager.UploadPaths = strArrays1;
            this.RadEditor1.ImageManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.ViewPaths = strArrays1;
            this.RadEditor1.FlashManager.UploadPaths = strArrays1;
            this.RadEditor1.DocumentManager.ViewPaths = strArrays1;
            this.RadEditor1.DocumentManager.UploadPaths = strArrays1;
            this.grdUnthorisedaccess.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Template_Name");
            this.grdUnthorisedaccess.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Subject");
            this.grdUnthorisedaccess.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.grdUnthorisedaccess.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.grdUnthorisedaccess.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_display");
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            if (this.Session["CustomAccessRight"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            else if (this.Session["CustomAccessRight"].ToString().Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            this.btnCancel.Text = this.objLangauge.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLangauge.GetLanguageConversion("Save");
            this.UserID = Convert.ToInt32(this.Session["userid"]);
            this.CompanyID = Convert.ToInt32(this.Session["companyid"]);
            this.Getemaildetails();
            if (!base.IsPostBack)
            {
                this.ddlEmailSignature();
            }
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email")));
            base.Title = this.objLanguage.convert(global.pageTitle("Unauthorised Access", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Email");
        }
    }
}