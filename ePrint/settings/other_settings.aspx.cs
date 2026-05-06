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
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.settings
{
    public partial class other_settings : System.Web.UI.Page, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private string section = string.Empty;

        private int CompanyID;

        public int totalrec;

        public string type = string.Empty;

        public string sectionvalue = string.Empty;

        public bool DefaultPhrase;

        public string EmailTemplateName = string.Empty;

        private commonClass objJava = new commonClass();

        public string strLo = string.Empty;

        private string label = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BasePage ObjPage = new BasePage();

        public languageClass objlang = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        private BaseClass objBase = new BaseClass();

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

        public other_settings()
        {
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_OtherSettings_insert_update(this.CompanyID, this.txtothersettings.Text, this.ddl_othersettings.SelectedValue);
            this.objBase.Message_Display(this.objlang.GetLanguageConversion("Other_Settings_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Attributes.Add("onclick", "javascript:var a=Validate();if(a)loadingimg('div_btnSave','div_btnsaveprocess');return a;");
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            base.Title = this.objlang.convert(global.pageTitle("Other Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Other_Settings");
            if (!base.IsPostBack)
            {
                this.objSet.Bind_ScreenName(this.ddl_othersettings, this.CompanyID, "--- Select ---");
            }
            foreach (DataRow row in SettingsBasePage.settings_othersettings_select(this.CompanyID).Rows)
            {
                if (base.IsPostBack)
                {
                    continue;
                }
                this.txtothersettings.Text = row["JobName"].ToString();
                this.ddl_othersettings.SelectedValue = row["DatabaseFieldName"].ToString();
            }
        }
    }
}