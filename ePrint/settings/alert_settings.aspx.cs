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

namespace ePrint.settings
{
    public partial class alert_settings : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        private Global gloobj = new Global();

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

        public alert_settings()
        {
        }

        public void BindAlertdetails()
        {
            DataSet dataSet = SettingsBasePage.settings_Select_Alert_Setting(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                this.objbase.SetDDLText(this.ddlTaskScreenMinute, row["ShowTaskAlertOnScreenTime"].ToString());
                this.objbase.SetDDLText(this.ddlCallScreenMinute, row["ShowCallAlertOnScreenTime"].ToString());
                this.objbase.SetDDLText(this.ddlTaskSendMinute, row["SendTaskAlertTime"].ToString());
                this.objbase.SetDDLText(this.ddlCallSendMinute, row["SendCallAlertTime"].ToString());
                if (row["isShowTaskAlertonScreen"].ToString().ToLower() != "false")
                {
                    this.chkTaskScreenMinute.Checked = true;
                }
                else
                {
                    this.chkTaskScreenMinute.Checked = false;
                }
                if (row["isShowCallAlertOnScreen"].ToString().ToLower() != "false")
                {
                    this.chkCallScreenMinute.Checked = true;
                }
                else
                {
                    this.chkCallScreenMinute.Checked = false;
                }
                if (row["isSendTaskAlert"].ToString().ToLower() != "false")
                {
                    this.chkTaskSendMinute.Checked = true;
                }
                else
                {
                    this.chkTaskSendMinute.Checked = false;
                }
                if (row["isSendCallAlert"].ToString().ToLower() != "false")
                {
                    this.chkCallSendMinute.Checked = true;
                }
                else
                {
                    this.chkCallSendMinute.Checked = false;
                }
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.DivAlertSettings.Style.Add("display", "none");
                this.chkswitchonAlertsetting.Checked = false;
                this.btnupdateSetting.Style.Add("display", "none");
                this.btnSaveSetting.Style.Add("display", "block");
            }
            else
            {
                SettingsBasePage.settings_Select_Alert_Setting(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID));
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (dataRow["isShowTaskAlertonScreen"].ToString().ToLower() == "true" || dataRow["isShowCallAlertOnScreen"].ToString().ToLower() == "true" || dataRow["isSendTaskAlert"].ToString().ToLower() == "true" || dataRow["isSendCallAlert"].ToString().ToLower() == "true")
                    {
                        this.DivAlertSettings.Style.Add("display", "block");
                        this.chkswitchonAlertsetting.Checked = true;
                        this.btnSaveSetting.Style.Add("display", "none");
                        this.btnupdateSetting.Style.Add("display", "block");
                    }
                    else
                    {
                        this.DivAlertSettings.Style.Add("display", "none");
                        this.chkswitchonAlertsetting.Checked = false;
                        this.btnupdateSetting.Style.Add("display", "none");
                        this.btnSaveSetting.Style.Add("display", "block");
                    }
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/UserEditProfile.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            if (this.chkTaskScreenMinute.Checked)
            {
                flag1 = true;
                num = Convert.ToInt32(this.ddlTaskScreenMinute.SelectedItem.Text);
            }
            if (this.chkCallScreenMinute.Checked)
            {
                flag2 = true;
                num1 = Convert.ToInt32(this.ddlCallScreenMinute.SelectedItem.Text);
            }
            if (this.chkTaskSendMinute.Checked)
            {
                flag3 = true;
                num2 = Convert.ToInt32(this.ddlTaskSendMinute.SelectedItem.Text);
            }
            if (this.chkCallSendMinute.Checked)
            {
                flag4 = true;
                num3 = Convert.ToInt32(this.ddlCallSendMinute.SelectedItem.Text);
            }
            DataSet dataSet = SettingsBasePage.settings_Select_Alert_Setting(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                flag = (row["UserID"].ToString() != Convert.ToInt64(this.UserID).ToString() ? false : true);
            }
            if (flag)
            {
                SettingsBasePage.Settings_Update_Alert_Setting(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID), flag1, num, flag2, num1, flag3, num2, flag4, num3, Convert.ToInt32(this.UserID));
            }
            else
            {
                SettingsBasePage.Settings_Insert_Alert_Setting(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID), flag1, num, flag2, num1, flag3, num2, flag4, num3, Convert.ToInt32(this.UserID));
            }
            this.objbase.Message_Display(this.objlang.GetLanguageConversion("Alert_settings_saved_successfully"), "msg-success", this.plhMessage);
            this.BindAlertdetails();
        }

        protected void btnupdateSetting_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            if (this.chkTaskScreenMinute.Checked)
            {
                flag = true;
                num = Convert.ToInt32(this.ddlTaskScreenMinute.SelectedItem.Text);
            }
            if (this.chkCallScreenMinute.Checked)
            {
                flag1 = true;
                num1 = Convert.ToInt32(this.ddlCallScreenMinute.SelectedItem.Text);
            }
            if (this.chkTaskSendMinute.Checked)
            {
                flag2 = true;
                num2 = Convert.ToInt32(this.ddlTaskSendMinute.SelectedItem.Text);
            }
            if (this.chkCallSendMinute.Checked)
            {
                flag3 = true;
                num3 = Convert.ToInt32(this.ddlCallSendMinute.SelectedItem.Text);
            }
            this.chkswitchonAlertsetting.Checked = false;
            this.DivAlertSettings.Style.Add("display", "none");
            SettingsBasePage.Settings_Update_Alert_Setting(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.UserID), flag, num, flag1, num1, flag2, num2, flag3, num3, Convert.ToInt32(this.UserID));
            this.objbase.Message_Display(this.objlang.GetLanguageConversion("Alert_settings_saved_successfully"), "msg-success", this.plhMessage);
            this.BindAlertdetails();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btncancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            this.ddltaskAlertOn.Items[0].Text = this.objlang.GetLanguageConversion("Screen");
            this.ddltaskAlertOn.Items[1].Text = this.objlang.GetLanguageConversion("Email");
            this.ddltaskAlertOn.Items[2].Text = this.objlang.GetLanguageConversion("Both");
            this.ddlEventAlerton.Items[0].Text = this.objlang.GetLanguageConversion("Screen");
            this.ddlEventAlerton.Items[1].Text = this.objlang.GetLanguageConversion("Email");
            this.ddlEventAlerton.Items[2].Text = this.objlang.GetLanguageConversion("Both");
            this.ddlCallalertOn.Items[0].Text = this.objlang.GetLanguageConversion("Screen");
            this.ddlCallalertOn.Items[1].Text = this.objlang.GetLanguageConversion("Email");
            this.ddlCallalertOn.Items[2].Text = this.objlang.GetLanguageConversion("Both");
            this.btnCancelSetting.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnSaveSetting.Text = this.objlang.GetLanguageConversion("Save");
            this.btnupdateSetting.Text = this.objlang.GetLanguageConversion("Update");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.convert(global.pageTitle(this.objlang.GetLanguageConversion("Alert_Settings"), this.CompanyID, this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/UserEditProfile.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("User_Setting"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Alert_Settings")));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Alert_Settings");
            if (!base.IsPostBack)
            {
                this.BindAlertdetails();
            }
        }
    }
}