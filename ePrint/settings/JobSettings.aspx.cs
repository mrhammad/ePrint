using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class JobSettings : BaseClass, IRequiresSessionState
    {
        private commonClass objJava = new commonClass();

        public BasePage objPage = new BasePage();

        public int CompanyID;

        public languageClass objlang = new languageClass();

        private Global gloobj = new Global();
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.InsertUpdate_JobDefault_Settings(this.CompanyID, this.chkJobArtwork.Checked, this.chkJobProof.Checked, this.chkJobApproval.Checked, this.chkJobProduction.Checked,this.chkDisplayJobs.Checked);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = "Jobs Setting";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job_Settings")));
            base.Title = this.objLanguage.convert(global.pageTitle("Job Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Select_JobDefault_Settings(this.CompanyID).Rows)
                {
                    if (!Convert.ToBoolean(row["IsDefaultJobArtwork"]))
                    {
                        this.chkJobArtwork.Checked = false;
                    }
                    else
                    {
                        this.chkJobArtwork.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultJobProof"]))
                    {
                        this.chkJobProof.Checked = false;
                    }
                    else
                    {
                        this.chkJobProof.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultJobApproval"]))
                    {
                        this.chkJobApproval.Checked = false;
                    }
                    else
                    {
                        this.chkJobApproval.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsDefaultJobProduction"]))
                    {
                        this.chkJobProduction.Checked = false;
                    }
                    else
                    {
                        this.chkJobProduction.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["Display100JobsOnJobPage"]))
                    {
                        this.chkDisplayJobs.Checked = false;
                    }
                    else
                    {
                        this.chkDisplayJobs.Checked = true;
                    }
                }

            }
        }
    }
}