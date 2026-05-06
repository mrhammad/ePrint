using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore.account
{
    public partial class accountedit : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected usercontrols_account_leftpanel account_panel1;

        //protected Label Label2;

        //protected TextBox txt_CompanyName;

        //protected Label lbl_firstName;

        //protected TextBox txt_firstName;

        //protected Label lbl_email;

        //protected TextBox txt_email;

        //protected CheckBox chk_changePwd;

        //protected Label lbl_currentPwd;

        //protected TextBox txt_currentPwd;

        //protected Label lbl_newPwd;

        //protected TextBox txt_newPwd;

        //protected Label lbl_lastName;

        //protected TextBox txt_lastName;

        //protected Label lbl_confirmPwd;

        //protected TextBox txt_confirmPwd;

        //protected Button btnSave;

        private commonclass comm = new commonclass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        public long StoreUserID;

        public long CompanyID;

        public long AccountID;

        public string RewriteModule;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string type = string.Empty;

        public string IsHomePageVisible = string.Empty;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public accountedit()
        {
        }

        protected void OnClick_btnSave(object sender, EventArgs e)
        {
            if (!this.chk_changePwd.Checked)
            {
                LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, base.SpecialEncode(this.txt_firstName.Text), base.SpecialEncode(this.txt_lastName.Text), base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text, this.CompanyID, this.AccountID, "", this.txt_CompanyName.Text, 0);
            }
            else
            {
                LoginBasePage.Create_StoreUser(this.StoreUserID, (long)0, base.SpecialEncode(this.txt_firstName.Text), base.SpecialEncode(this.txt_lastName.Text), base.SpecialEncode(this.txt_email.Text), this.txt_newPwd.Text.Trim(), this.CompanyID, this.AccountID, "yes", this.txt_CompanyName.Text, 0);
            }
            this.Session["FirstName"] = base.SpecialEncode(this.txt_firstName.Text.Trim());
            this.Session["LastName"] = base.SpecialEncode(this.txt_lastName.Text.Trim());
            base.Response.Redirect(string.Concat(this.strSitepath, "account/account.aspx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.chk_changePwd.Text = string.Concat(" ", this.objLanguage.GetLanguageConversion("Change_PAssword"));
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString();
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt64(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.RewriteModule = ConnectionClass.RewriteModule;
            }
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.comm.GetDisplayValue("IsHome", this.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            base.Title = commonclass.pageTitle("My Account", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            else if (this.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            else
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.txt_firstName.Text = base.SpecialDecode(row["FirstName"].ToString());
                    this.txt_lastName.Text = base.SpecialDecode(row["LastName"].ToString());
                    this.txt_email.Text = base.SpecialDecode(row["EmailID"].ToString());
                    this.txt_currentPwd.Attributes.Add("value", row["Password"].ToString());
                    this.txt_currentPwd.ReadOnly = true;
                    this.txt_CompanyName.Text = base.SpecialDecode(row["CompanyName"].ToString());
                    this.txt_CompanyName.ReadOnly = true;
                }
            }
            if (this.type == "p")
            {
                this.txt_newPwd.Focus();
                return;
            }
            this.txt_CompanyName.Focus();
        }
    }
}