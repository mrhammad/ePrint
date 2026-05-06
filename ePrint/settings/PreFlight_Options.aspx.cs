using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
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
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class PreFlight_Options : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessageNew;

        //protected CheckBox chkEnable;

        //protected Label lblDefaultProfile;

        //protected DropDownList ddlProfiles;

        //protected Button btnSave;

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public Global gloobj = new Global();

        public languageClass objlang = new languageClass();

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

        public PreFlight_Options()
        {
        }

        protected void btnSave_Click(object o, EventArgs e)
        {
            SettingsBasePage.Settings_PreFlightOptions_InsertUpdate(Convert.ToInt32(this.ddlProfiles.SelectedValue), "MIS", this.CompanyID, this.chkEnable.Checked);
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/PreFlight_Options.aspx?suc=up"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("PreFlight_Options");
            this.gloobj.setpagename("setting");
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("PreFlight_Options_saved_successfully"), "msg-success", this.plhMessage);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("PreFlight_Options")));
            base.Title = this.objlang.convert(global.pageTitle("PreFlight Options", this.CompanyID, this.Session["companyName"].ToString()));
            if (!base.IsPostBack)
            {
                DataTable dataTable = CompanyBasePage.PreflightProfile_Select();
                this.ddlProfiles.DataSource = dataTable;
                this.ddlProfiles.DataTextField = "ProfileName";
                this.ddlProfiles.DataValueField = "ID";
                this.ddlProfiles.DataBind();
                this.ddlProfiles.Items.Insert(0, new ListItem("---Select Profile---", "0"));
                DataTable dataTable1 = SettingsBasePage.PreFlight_Options_Select("MIS", this.CompanyID);
                string str = "0";
                foreach (DataRow row in dataTable1.Rows)
                {
                    str = row["ProfileId"].ToString();
                    if (Convert.ToInt32(row["IsEnabled"]) != 1)
                    {
                        this.chkEnable.Checked = false;
                    }
                    else
                    {
                        this.chkEnable.Checked = true;
                    }
                }
                this.ddlProfiles.SelectedIndex = this.ddlProfiles.Items.IndexOf(this.ddlProfiles.Items.FindByValue(str));
                this.chkEnable.Attributes.Add("onclick", "javascript:EnableDisableDdl();");
            }
            if (!this.chkEnable.Checked)
            {
                this.ddlProfiles.Enabled = false;
            }
        }
    }
}