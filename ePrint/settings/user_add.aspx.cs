using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.settings
{
    public partial class user_add : BaseClass, IRequiresSessionState
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

        public user_add()
        {
        }

        protected void btndelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_user_delete(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid);
            base.Response.Redirect("user_manager.aspx?Su=d");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            checkEmail _checkEmail = new checkEmail();
            BaseClass baseClass = new BaseClass();
            string str = baseClass.Return_IsEnable_CRM(Convert.ToInt32(this.CompanyID));
            bool flag = false;
            if (str.Trim().ToLower() != "true")
            {
                flag = true;
            }
            else
            {
                flag = (!this.ChkActiveUserForSalesTarget.Checked ? false : true);
            }
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

            if (this.type != "edit")
            {
                if (_checkEmail.Email(base.SpecialEncode(this.txtemail.Text)))
                {
                    base.Response.Redirect("user_add.aspx?error=yes");
                    return;
                }
                if (SettingsBasePage.settings_usermailduplicacy_check(Convert.ToInt32(this.CompanyID), "user", this.txtemail.Text.ToString(), Convert.ToInt64(this.userid)) == -1)
                {
                    this.pnlCheck.Visible = true;
                    return;
                }
                SettingsBasePage.settings_user_insert(Convert.ToInt32(this.Session["companyId"].ToString()), base.SpecialEncode(this.txtemail.Text), base.SpecialEncode(this.txtname.Text), commonClass.Encrypt(base.SpecialEncode(this.txtpassword.Text)), Convert.ToInt32(this.ddlrole.SelectedItem.Value), base.Server.HtmlEncode(base.SpecialEncode(this.txtDescription.Text)), this.chkDisableAccount.Checked, Convert.ToString(DateTime.Now), base.SpecialEncode(this.txtPhone.Text), base.SpecialEncode(this.txtMobile.Text), base.SpecialEncode(this.txtFax.Text), this.ddlDefaultLanding.SelectedValue.ToString(), flag, this.ImageToUpload, base.SpecialEncode(this.txtJobTitle.Text), Convert.ToInt32(this.ddlLocation.SelectedItem == null ? "0" : this.ddlLocation.SelectedItem.Value));
                base.Response.Redirect("user_manager.aspx?Su=i");
                return;
            }
            if (this.email == base.SpecialEncode(this.txtemail.Text))
            {
                if (SettingsBasePage.settings_usermailduplicacy_check(Convert.ToInt32(this.CompanyID), "user", this.txtemail.Text.ToString(), Convert.ToInt64(this.userid)) == -1)
                {
                    this.pnlCheck.Visible = true;
                    return;
                }
                SettingsBasePage.settings_user_update(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid, base.SpecialEncode(this.txtemail.Text), base.SpecialEncode(this.txtname.Text), commonClass.Encrypt(base.SpecialEncode(this.txtpassword.Text)), Convert.ToInt32(this.ddlrole.SelectedItem.Value), base.Server.HtmlEncode(base.SpecialEncode(this.txtDescription.Text)), this.chkDisableAccount.Checked, base.SpecialEncode(this.txtPhone.Text), base.SpecialEncode(this.txtMobile.Text), base.SpecialEncode(this.txtFax.Text), this.ddlDefaultLanding.SelectedValue, flag, this.ImageToUpload, base.SpecialEncode(this.txtJobTitle.Text), Convert.ToInt32(this.ddlLocation.SelectedItem == null ? "0" : this.ddlLocation.SelectedItem.Value));
                base.Response.Redirect("user_manager.aspx?Su=u");
                return;
            }
            if (_checkEmail.Email(base.SpecialEncode(this.txtemail.Text)))
            {
                base.Response.Redirect(string.Concat("user_addnew.aspx?type=edit&userid=", this.userid, "&error=yes"));
                return;
            }
            if (SettingsBasePage.settings_usermailduplicacy_check(Convert.ToInt32(this.CompanyID), "user", base.SpecialEncode(this.txtemail.Text.ToString()), Convert.ToInt64(this.userid)) == -1)
            {
                this.pnlCheck.Visible = true;
                return;
            }
            SettingsBasePage.settings_user_update(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid, base.SpecialEncode(this.txtemail.Text), base.SpecialEncode(this.txtname.Text), commonClass.Encrypt(base.SpecialEncode(this.txtpassword.Text)), Convert.ToInt32(this.ddlrole.SelectedItem.Value), base.Server.HtmlEncode(base.SpecialEncode(this.txtDescription.Text)), this.chkDisableAccount.Checked, base.SpecialEncode(this.txtPhone.Text), base.SpecialEncode(this.txtMobile.Text), base.SpecialEncode(this.txtFax.Text), this.ddlDefaultLanding.SelectedValue.ToString(), flag, this.ImageToUpload, base.SpecialEncode(this.txtJobTitle.Text), Convert.ToInt32(this.ddlLocation.SelectedItem == null ? "0" : this.ddlLocation.SelectedItem.Value));
            base.Response.Redirect("user_manager.aspx");
        }

        protected void ddlrole_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static int Getmailduplicacy(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = baseClass.SpecialEncode(strArrays[1]);
            string str2 = baseClass.SpecialEncode(strArrays[2]);
            long num = Convert.ToInt64(strArrays[3]);
            int num1 = SettingsBasePage.settings_plantpressduplicacy_check(Convert.ToInt32(str), str2, str1, num);
            return num1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Attributes.Add("onclick", "if(Page_ClientValidate()){javascript:loadingimg('btnsave','div_btnsaveprocess');}else{return false;}");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btndelete.Text = this.objLanguage.GetLanguageConversion("Delete");
            this.RadWindow1.Title = this.objLanguage.GetLanguageConversion("User_Image");
            this.CompanyID = Convert.ToInt32(Convert.ToInt32(this.Session["companyId"]));
            DataTable dataTable = WebstoreBasePage.RestrictedUser((long)this.CompanyID);
            this.UserCount = Convert.ToInt16(dataTable.Rows[0]["UserCount"].ToString());
            this.NoOfUser = Convert.ToInt16(dataTable.Rows[0]["noofuser"].ToString());
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_cancelprocess');return cancelClick(path+'Settings/user_manager.aspx');");
            this.txtname.Focus();
            this.gloobj.setpagename("setting");

            if (base.Request.Params["type"] == null && this.NoOfUser < this.UserCount)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:RestrictedPopUp();", true);
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() != "edit")
                {
                    if (this.NoOfUser < this.UserCount)
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:RestrictedPopUp();", true);
                    }
                    this.div_delete.Style.Add("display", "none");
                    this.btndelete.Visible = false;
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/user_manager.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("User_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("User_Add")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Add User", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("User_Add");
                }
                else
                {
                    this.div_delete.Style.Add("display", "block");
                    this.btndelete.Visible = true;
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/user_manager.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("User_View"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("User_Edit")));
                    base.Title = this.objLanguage.convert(global.pageTitle("User Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("User_Edit");
                }
            }
            try
            {
                this.type = base.Request.Params["type"].ToString();
                this.userid = Convert.ToInt32(base.Request.Params["userid"]);
                if (this.type == "edit")
                {
                    this.lblheader.Text = "Settings:&nbsp;Edit User";
                }
            }
            catch
            {
            }
            try
            {
                if (base.Request.Params["error"].ToString() != "yes")
                {
                    this.lblerror.Visible = false;
                }
                else
                {
                    this.lblerror.Visible = true;
                }
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = SettingsBasePage.settings_userrole_select(Convert.ToInt32(this.Session["companyId"].ToString()), this.ddlrole);
                for (int i = 0; i <= dataTable1.Rows.Count - 1; i++)
                {
                    if (dataTable1.Rows[i]["usertype"].ToString() == "Administrator")
                    {
                        this.ddlrole.DataSource = dataTable1;
                        this.ddlrole.DataTextField = "usertype";
                        this.ddlrole.DataValueField = "usertypeid";
                        this.ddlrole.DataBind();
                        this.ddlrole.SelectedValue = dataTable1.Rows[i]["usertypeid"].ToString();
                    }
                }
                if (this.type == "edit")
                {
                    if (SettingsBasePage.settings_check_userid_exist(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid) != 1)
                    {
                        this.lblerror.Visible = true;
                        this.lblerror.Text = "You don't have permission to access";
                    }
                    else
                    {
                        this.btndelete.Visible = true;
                        DataTable dataTable2 = SettingsBasePage.setting_user_edit(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid, this.txtname, this.txtemail, this.txtpassword, this.txtconfirmpassword, this.ddlrole, this.txtDescription, this.chkDisableAccount, this.txtPhone, this.txtMobile, this.txtFax);
                        for (int j = 0; j <= dataTable2.Rows.Count - 1; j++)
                        {
                            this.txtname.Text = dataTable2.Rows[j]["FirstName"].ToString();
                            this.txtemail.Text = dataTable2.Rows[j]["Email"].ToString();

                            //Passwords dont need to be shown in the front end
                            //this.txtpassword.Text = commonClass.Decrypt(dataTable2.Rows[j]["Password"].ToString());
                            //this.txtpassword.Attributes.Add("value", commonClass.Decrypt(dataTable2.Rows[j]["Password"].ToString()));
                            //this.txtconfirmpassword.Attributes.Add("value", commonClass.Decrypt(dataTable2.Rows[j]["Password"].ToString()));
                            this.txtpassword.Enabled = false;
                            this.txtconfirmpassword.Enabled = false;
                            this.rvfpassword.Enabled = false;
                            this.RequiredFieldValidator3.Enabled = false;

                            this.txtDescription.Text = dataTable2.Rows[j]["Description"].ToString();
                            this.chkDisableAccount.Checked = Convert.ToBoolean(dataTable2.Rows[j]["DisableAccount"].ToString());
                            this.txtPhone.Text = dataTable2.Rows[j]["phone"].ToString();
                            this.txtMobile.Text = dataTable2.Rows[j]["Mobile"].ToString();
                            this.txtFax.Text = dataTable2.Rows[j]["Fax"].ToString();
                            this.txtJobTitle.Text = dataTable2.Rows[j]["jobTitle"].ToString();
                            if (dataTable2.Rows[j]["UserImage"].ToString() != "")
                            {
                                this.hid_UserImage.Value = dataTable2.Rows[j]["UserImage"].ToString();
                                this.ancUploadimage.Attributes.Add("style", "display:none");
                                this.lblUserImage.Attributes.Add("style", "display:block");
                                QueryString queryString = new QueryString()
                            {
                                { "doctype", "imgcpuser" },
                                { "filename", dataTable2.Rows[j]["UserImage"].ToString() }
                            };
                                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                                Label label = this.lblUserImage;
                                string[] strArrays1 = new string[] { "<a class='mainheader' href='", this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim(), "' target='_blank'>", dataTable2.Rows[j]["UserImage"].ToString(), "</a>&nbsp;<div class='div_uploaduserimg'><img src='../images/erase.png' onclick=RemoveImage('image'); title='Remove' style='cursor: pointer'></div>" };
                                label.Text = string.Concat(strArrays1);
                            }
                            if (dataTable2.Rows[j]["IsActivateUserForSalesTargets"].ToString().ToLower() != "true")
                            {
                                this.ChkActiveUserForSalesTarget.Checked = false;
                            }
                            else
                            {
                                this.ChkActiveUserForSalesTarget.Checked = true;
                            }
                            for (int k = 0; k < this.ddlrole.Items.Count; k++)
                            {
                                if (dataTable2.Rows[j]["usertypeid"].ToString() == this.ddlrole.Items[k].Value)
                                {
                                    this.ddlrole.SelectedIndex = k;
                                }
                            }
                            DataTable dataTable3 = CompanyBasePage.crm_common_select_accessrightOfUserType(Convert.ToInt32(this.Session["companyId"].ToString()), Convert.ToInt32(this.ddlrole.SelectedValue));
                            this.ddlDefaultLanding.DataSource = dataTable3;
                            this.ddlDefaultLanding.DataTextField = "screenname";
                            this.ddlDefaultLanding.DataValueField = "headerName";
                            this.ddlDefaultLanding.DataBind();
                            dataTable2.Rows[j]["DefaultLanding"].ToString();
                            this.ddlDefaultLanding.SelectedValue = dataTable2.Rows[j]["DefaultLanding"].ToString();
                            if (CheckXeroTracking())
                            {

                                DataTable dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
                                this.ddlLocation.DataSource = dataTableOptions;
                                this.ddlLocation.DataTextField = "TrackingOPtion";
                                this.ddlLocation.DataValueField = "Id";
                                this.ddlLocation.DataBind();
                                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByValue(dataTable2.Rows[j]["TrackingOptionId"].ToString()));

                            }

                            // this.ddlLocation.SelectedValue = dataTable2.Rows[j]["TrackingOptionId"].ToString();

                        }
                        DataTable dataTable4 = SettingsBasePage.Settings_user_check_isadmin(Convert.ToInt32(this.Session["companyId"].ToString()), this.userid);
                        string empty = string.Empty;
                        string str = string.Empty;
                        foreach (DataRow row in dataTable4.Rows)
                        {
                            empty = row["isAdmin"].ToString();
                            str = row["isCorporateRight"].ToString();
                        }
                        if (empty.ToLower().Trim() == "true" && str.ToLower().Trim() == "true")
                        {
                            this.ddlrole.Enabled = false;
                            this.btndelete.Visible = false;
                            this.div_delete.Visible = false;
                            this.chkDisableAccount.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.txtpassword.Enabled = true;
                    this.txtconfirmpassword.Enabled = true;
                    this.rvfpassword.Enabled = true;
                    this.RequiredFieldValidator3.Enabled = true;
                }
            }
            if (!base.IsPostBack && this.type != "edit" && this.ddlrole.SelectedItem.ToString() == "Administrator")
            {
                this.txtemail.Text = "";
                DataTable dataTable5 = CompanyBasePage.crm_common_select_accessrightOfUserType(Convert.ToInt32(this.Session["companyId"].ToString()), Convert.ToInt32(this.ddlrole.SelectedValue));
                this.ddlDefaultLanding.DataSource = dataTable5;
                this.ddlDefaultLanding.DataTextField = "screenname";
                this.ddlDefaultLanding.DataValueField = "headerName";
                this.ddlDefaultLanding.DataBind();
                if (CheckXeroTracking())
                {

                    DataTable dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
                    this.ddlLocation.DataSource = dataTableOptions;
                    this.ddlLocation.DataTextField = "TrackingOPtion";
                    this.ddlLocation.DataValueField = "Id";
                    this.ddlLocation.DataBind();
                }

            }
            this.email = this.txtemail.Text;
            this.btndelete.Attributes.Add("onclick", "javascript:var a=window.confirm('Are you sure,you want to delete this user?');if(a)loadingimg('div_btndelete','div_deleteprocess');return a;");
            if ((new BaseClass()).Return_IsEnable_CRM(Convert.ToInt32(this.CompanyID)).Trim().ToLower() != "true")
            {
                this.ChkActiveUserForSalesTarget.Enabled = false;
                this.lblIsadvanceCrmMsg.Visible = true;
            }
            else
            {
                this.ChkActiveUserForSalesTarget.Enabled = true;
                this.lblIsadvanceCrmMsg.Visible = false;
            }
            this.hdntype.Value = base.Request.Params["type"].ToString();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (this.ddlLocation.SelectedItem != null)
            {
                SettingsBasePage.DeleteTrackingOPtions(Convert.ToInt32(this.ddlLocation.SelectedItem.Value));
                var dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
                this.ddlLocation.DataSource = dataTableOptions;
                this.ddlLocation.DataTextField = "TrackingOPtion";
                this.ddlLocation.DataValueField = "Id";
                this.ddlLocation.DataBind();

            }

        }

        protected void btnSaveMarkup_Click(object sender, EventArgs e)
        {
            var empty = this.txtMarkupName.Text;
            if (this.ddlLocation.SelectedItem != null)
            {

                SettingsBasePage.SaveUpdateTrackingOPtions(Convert.ToInt32(this.ddlLocation.SelectedItem.Value), txtMarkupName.Text, "");
                SettingsBasePage.GetTrackingOPtions(0);
                var dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
                this.ddlLocation.DataSource = dataTableOptions;
                this.ddlLocation.DataTextField = "TrackingOPtion";
                this.ddlLocation.DataValueField = "Id";
                this.ddlLocation.DataBind();

                for (int i = 0; i < this.ddlLocation.Items.Count; i++)
                {
                    if (this.ddlLocation.Items[i].Text == empty)
                    {
                        this.ddlLocation.SelectedIndex = i;
                    }
                }

            }
        }




        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            var empty = this.txtMarkupName.Text;
            SettingsBasePage.SaveUpdateTrackingOPtions(0, txtMarkupName.Text, "");
            SettingsBasePage.GetTrackingOPtions(0);

            var dataTableOptions = SettingsBasePage.GetTrackingOPtions(0);
            this.ddlLocation.DataSource = dataTableOptions;
            this.ddlLocation.DataTextField = "TrackingOPtion";
            this.ddlLocation.DataValueField = "Id";
            this.ddlLocation.DataBind();

            for (int i = 0; i < this.ddlLocation.Items.Count; i++)
            {
                if (this.ddlLocation.Items[i].Text == empty)
                {
                    this.ddlLocation.SelectedIndex = i;
                }
            }
        }

        bool CheckXeroTracking()
        {
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_Xero_Tracking_Select")
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@System_Name", ConnectionClass.ServerName.ToString());
            object tmp = sqlCommand.ExecuteScalar();
            bool ab = Convert.ToBoolean(tmp);
            divLocation.Visible = ab;
            return ab;
        }
    }
}
