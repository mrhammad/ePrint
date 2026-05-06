using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class Upload_PreFlightProfile : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessageNew;

        //protected Label lblUpload;

        //protected FileUpload fuPreFlightProfile;

        //protected Button btnUpload;

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public Global gloobj = new Global();

        public languageClass objlang = new languageClass();

        public string SystemName = ConnectionClass.ServerName;

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

        public Upload_PreFlightProfile()
        {
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.fuPreFlightProfile.HasFile)
            {
                if (!Directory.Exists(string.Concat(this.SecureDocPath, this.SystemName, "/store/0/PreflightProfile/")))
                {
                    Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.SystemName, "/store/0/PreflightProfile/"));
                }
                this.fuPreFlightProfile.SaveAs(string.Concat(this.SecureDocPath, this.SystemName, "/store/0/PreflightProfile/", this.fuPreFlightProfile.FileName));
                string str = this.fuPreFlightProfile.FileName.Replace(".ppp", "");
                SettingsBasePage.PreFlightProfile_Insert(str);
                base.Response.Redirect("../Settings/Upload_PreFlightProfile.aspx?suc=up");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Upload_PreFlight_Profile");
            this.gloobj.setpagename("setting");
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Upload_PreFlight_profile_success"), "msg-success", this.plhMessage);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Upload_PreFlight_Profile")));
            base.Title = this.objlang.convert(global.pageTitle("Upload PreFlight Profile", this.CompanyID, this.Session["companyName"].ToString()));
            if (!base.IsPostBack)
            {
                this.lblUpload.Text = this.objlang.GetLanguageConversion("Upload_PreFlight_Profile").ToString().Replace("Upload ", "");
            }
        }
    }
}