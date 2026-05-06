using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Printcenter.UI.Setting;

namespace ePrint.settings
{
    public class FtpPrefixSettingsModel
    {
        public int ID { get; set; }
        public int PrefixSelectedMode { get; set; }
    }
    public partial class FTP_Prefix : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        public int CompanyID;

        public int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Prefix");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.GetLanguageConversion("Prefix");
            base.Session["pagename"] = "setting";
            if (!IsPostBack)
            {
                LoadSavedFtpPrefixSettings();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int selectedOption = 0;

            if (rbNone.Checked)
            {
                selectedOption = 0;
            }
            else if (rbPrefix.Checked)
            {
                selectedOption = 1;
            }
            else if (rbOverwrite.Checked)
            {
                selectedOption = 2;
            }
            SettingsBasePage.InsertUpdateFTPPrefix(this.CompanyID, selectedOption);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Prefix_Saved_Message"), "msg-success", this.plhMessage);
        }
        private void LoadSavedFtpPrefixSettings()
        {
            var settings = SettingsBasePage.GetFtpPrefixSettings(this.CompanyID);

            if (settings != null)
            {
                if(settings.PrefixSelectedMode == 1)
                {
                    rbPrefix.Checked = true;
                }
                else if(settings.PrefixSelectedMode == 2)
                {
                    rbOverwrite.Checked = true;
                }
                else
                {
                    rbNone.Checked = true;
                }
            }
        }
    }
}