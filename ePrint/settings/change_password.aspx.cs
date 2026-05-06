using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class change_password : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string type = string.Empty;

        private SettingsBasePage objset = new SettingsBasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private string email = string.Empty;

        public languageClass objlang = new languageClass();

        public int UserCount;

        public int NoOfUser;

        public string strSitePath = global.sitePath();

        private string ImageToUpload = string.Empty;

        public int userid;

        public int CompanyID;

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

        public change_password()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/UserEditProfile.aspx"));
        }

        protected void btsave_Click(object sender, EventArgs e)
        {
            SettingsBasePage.settings_user_password_update(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid, commonClass.Encrypt(base.SpecialEncode(this.txtpassword.Text)));
            base.Response.Redirect("change_password.aspx?Su=u");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Attributes.Add("onclick", "loadingimg('div_btnCancel','div_btncancelprocess')");
            this.CompanyID = Convert.ToInt32(Convert.ToInt32(this.Session["companyId"]));
            this.userid = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objlang.convert(global.pageTitle(this.objlang.GetLanguageConversion("Change_Password"), this.CompanyID, this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/UserEditProfile.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("User_Setting"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Change_Password")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Change_Password");
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.setting_user_profile(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid);
                for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
                {
                    this.txtOldPassword.Text = commonClass.Decrypt(dataTable.Rows[i]["Password"].ToString());
                    this.txtOldPassword.Attributes.Add("value", commonClass.Decrypt(dataTable.Rows[i]["Password"].ToString()));
                }
            }
            try
            {
                if (base.Request.Params["Su"].ToLower() == "u")
                {
                    base.Message_Display("Password changed successfully", "msg-success", this.plhMessage);
                }
            }
            catch
            {
            }
        }
    }
}