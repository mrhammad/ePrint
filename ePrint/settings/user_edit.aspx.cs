using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.settings
{
    public partial class user_edit : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string type = string.Empty;

        private SettingsBasePage objset = new SettingsBasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int userid;

        public int CompanyID;

        private string email = string.Empty;

        public languageClass objlang = new languageClass();

        public int UserCount;

        public int NoOfUser;

        public int UserTypeId;

        public string strSitePath = global.sitePath();

        private string ImageToUpload = string.Empty;

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

        public user_edit()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/UserEditProfile.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            HttpCookie item = base.Request.Cookies["cke_uploadimageName"];
            if (item == null)
            {
                this.ImageToUpload = this.hid_UserImage.Value;
            }
            else if (this.hid_UserImage.Value == "")
            {
                this.ImageToUpload = this.hid_UserImage.Value;
            }
            else
            {
                this.ImageToUpload = item["uploadImgname"];
                item.Expires = DateTime.Now.AddDays(-1);
                base.Response.Cookies.Add(item);
            }
            SettingsBasePage.settings_user_profile_update(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid, base.SpecialEncode(this.txtname.Text), base.Server.HtmlEncode(base.SpecialEncode(this.txtDescription.Text)), base.SpecialEncode(this.txtPhone.Text), base.SpecialEncode(this.txtMobile.Text), base.SpecialEncode(this.txtFax.Text), this.ddlDefaultLanding.SelectedValue, this.ImageToUpload, base.SpecialEncode(this.txtJobTitle.Text));
            base.Response.Redirect("user_edit.aspx?Su=u");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Attributes.Add("onclick", "if(Page_ClientValidate()){javascript:loadingimg('btnsave','div_btnsaveprocess');}else{return false;}");
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_cancelprocess')");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("User_Image");
            this.CompanyID = Convert.ToInt32(Convert.ToInt32(this.Session["companyId"]));
            this.userid = Convert.ToInt32(this.Session["UserID"].ToString());
            DataTable dataTable = WebstoreBasePage.RestrictedUser((long)this.CompanyID);
            this.UserCount = Convert.ToInt16(dataTable.Rows[0]["UserCount"].ToString());
            this.NoOfUser = Convert.ToInt16(dataTable.Rows[0]["noofuser"].ToString());
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objlang.convert(global.pageTitle(this.objlang.GetLanguageConversion("User_Profile"), this.CompanyID, this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/UserEditProfile.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("User_Setting"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("User_Profile")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("User_Profile");
            if (!base.IsPostBack)
            {
                this.UserTypeId = SettingsBasePage.user_profile_userTypeId_Select(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid);
                DataTable dataTable1 = SettingsBasePage.setting_user_profile(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid);
                for (int i = 0; i <= dataTable1.Rows.Count - 1; i++)
                {
                    this.txtname.Text = base.SpecialDecode(dataTable1.Rows[i]["FirstName"].ToString());
                    this.txtDescription.Text = base.SpecialDecode(dataTable1.Rows[i]["Description"].ToString());
                    this.txtPhone.Text = dataTable1.Rows[i]["phone"].ToString();
                    this.txtMobile.Text = dataTable1.Rows[i]["Mobile"].ToString();
                    this.txtFax.Text = dataTable1.Rows[i]["Fax"].ToString();
                    this.txtJobTitle.Text = dataTable1.Rows[i]["jobTitle"].ToString();
                    if (dataTable1.Rows[i]["UserImage"].ToString() != "")
                    {
                        this.hid_UserImage.Value = dataTable1.Rows[i]["UserImage"].ToString();
                        this.ancUploadimage.Attributes.Add("style", "display:none");
                        this.lblUserImage.Attributes.Add("style", "display:block");
                        QueryString queryString = new QueryString()
					{
						{ "doctype", "imgcpuser" },
						{ "filename", dataTable1.Rows[i]["UserImage"].ToString() }
					};
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        Label label = this.lblUserImage;
                        string[] strArrays = new string[] { "<a class='mainheader' href='", this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", dataTable1.Rows[i]["UserImage"].ToString(), "</a>&nbsp;<div class='div_uploaduserimg'><img src='../images/erase.png' onclick=RemoveImage('image'); title='Remove' style='cursor: pointer'></div>" };
                        label.Text = string.Concat(strArrays);
                    }
                    DataTable dataTable2 = CompanyBasePage.crm_common_select_accessrightOfUserType(Convert.ToInt32(this.Session["companyId"].ToString()), this.UserTypeId);
                    this.ddlDefaultLanding.DataSource = dataTable2;
                    this.ddlDefaultLanding.DataTextField = "screenname";
                    this.ddlDefaultLanding.DataValueField = "headerName";
                    this.ddlDefaultLanding.DataBind();
                    this.ddlDefaultLanding.SelectedValue = dataTable1.Rows[i]["DefaultLanding"].ToString();
                }
            }
            try
            {
                if (base.Request.Params["Su"].ToLower() == "u")
                {
                    base.Message_Display("User Profile updated successfully", "msg-success", this.plhMessage);
                }
            }
            catch
            {
            }
        }
    }
}