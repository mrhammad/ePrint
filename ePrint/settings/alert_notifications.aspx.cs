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
    public partial class alert_notifications : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        private SettingsBasePage objset = new SettingsBasePage();

        private BaseClass objBass = new BaseClass();

        private Global gloobj = new Global();

        public languageClass objLangauge = new languageClass();

        private int CompanyID;

        private int UserID;

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

        public alert_notifications()
        {
        }

        public void BindNotification()
        {
            DataTable dataTable = SettingsBasePage.select_Alert_Notification_EmailBody(Convert.ToInt64(this.CompanyID));
            this.RadGridAlert.DataSource = dataTable;
            this.RadGridAlert.DataBind();
        }

        public void BindNotificationAlert()
        {
            DataTable dataTable = SettingsBasePage.select_Alert_Notification_EmailBody(Convert.ToInt64(this.CompanyID));
            if (dataTable.Rows.Count > 0)
            {
                this.txtAlertName.Text = base.SpecialDecode(dataTable.Rows[0]["TemplateName"].ToString());
                this.txtSubject.Text = base.SpecialDecode(dataTable.Rows[0]["Subject"].ToString());
                this.RadEditor1.Content = dataTable.Rows[0]["Body"].ToString();
                this.lblAlertID.Text = dataTable.Rows[0]["AlertID"].ToString();
                this.txtAlertName.Focus();
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Settings//system_pharsebook.aspx?Mtype=Eml");
        }

        protected void btnSave_Onclick(object sender, EventArgs e)
        {
            if (this.lblAlertID.Text != "")
            {
                SettingsBasePage.Settings_Update_Alert_Notification_settings(Convert.ToInt32(this.lblAlertID.Text), Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID), this.txtAlertName.Text, this.txtSubject.Text, this.RadEditor1.Content);
                base.Message_Display("Alert Setting Updated Successfully", "msg-success", this.plhMessage);
                this.BindNotificationAlert();
            }
        }

        protected void lnkTemplateName_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataSet dataSet = SettingsBasePage.Settings_Select_Alert_Email_Body(Convert.ToInt32(linkButton.CommandArgument.ToString()));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                this.txtAlertName.Text = base.SpecialDecode(row["TemplateName"].ToString());
                this.txtSubject.Text = base.SpecialDecode(row["Subject"].ToString());
                this.RadEditor1.Content = row["Body"].ToString();
                this.lblAlertID.Text = linkButton.CommandArgument.ToString();
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Editsettings();", true);
                this.txtAlertName.Focus();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
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
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangauge.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangauge.GetLanguageConversion("Alert_Notifications")));
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangauge.GetLanguageConversion("Alert_Notifications") ?? "", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.header_mis.SettingName = this.objLangauge.GetLanguageConversion("Alert_Notifications");
            if (!base.IsPostBack)
            {
                this.BindNotificationAlert();
            }
        }

        protected void RadGridAlert_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnDefaultValue");
                    Image image = (Image)e.Item.FindControl("imgdefault");
                    if (hiddenField.Value.ToLower() != "true")
                    {
                        image.ImageUrl = string.Concat(this.strImagepath, "1t.gif");
                    }
                    else
                    {
                        image.ImageUrl = string.Concat(this.strImagepath, "check.gif");
                    }
                }
            }
            catch
            {
            }
        }

        protected void RadGridAlert_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.select_Alert_Notification_EmailBody(Convert.ToInt64(this.CompanyID));
            this.RadGridAlert.DataSource = dataTable;
        }
    }
}