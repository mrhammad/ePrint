using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class changepassword : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath;

        public int userID;

        public languageClass objLanguage = new languageClass();

        private commonClass objCommonClass = new commonClass();

        public string tabcolor = "";

        public int companyid;

        public BasePage objpage = new BasePage();

        private Global Globl = new Global();

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

        public changepassword()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.pnlmessagecomfirm.Visible = false;
            base.Response.Redirect(string.Concat(global.sitePath(), "welcome.aspx"));
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int num = 0;
            SqlCommand sqlCommand = new SqlCommand("crm_update_change_password_New", this.objCommonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@userID", this.userID);
            sqlCommand.Parameters.AddWithValue("@password", commonClass.Encrypt(base.ReplaceSingleQuote(this.txtnewpwd.Text)));
            sqlCommand.Parameters.AddWithValue("@oldpassword", commonClass.Encrypt(base.ReplaceSingleQuote(this.txtoldpwd.Text)));
            sqlCommand.Parameters.AddWithValue("@companyID", this.Session["companyID"].ToString());
            sqlCommand.Parameters.Add("@totalpassword", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            num = int.Parse(sqlCommand.Parameters["@totalpassword"].Value.ToString());
            this.objCommonClass.closeConnection();
            if (num == -1)
            {
                this.pnlMessage.Visible = true;
                this.pnlmessagecomfirm.Visible = false;
                this.lblmessage.Text = this.objLanguage.convert("Invalid old password. Please try again");
                return;
            }
            if (num == -2)
            {
                this.pnlMessage.Visible = true;
                this.pnlmessagecomfirm.Visible = false;
                this.lblmessage.Text = this.objLanguage.convert("New password exists in your last three password");
                return;
            }
            this.pnlmessagecomfirm.Visible = true;
            this.pnlMessage.Visible = false;
            this.pnlBody.Visible = false;
            this.btnsubmit.Visible = false;
            this.btncancel.Visible = false;
            this.lnkBack.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "welcome";
            this.Globl.setpagename("welcome");
            this.companyid = int.Parse(this.Session["companyid"].ToString());
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            this.tabcolor = this.objpage.colorCode(this.companyid, "home");
            base.Title = this.objLanguage.convert(global.pageTitle("Change Password", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path("<a href=welcome.aspx style=text-decoration:underline>Home</a>", "&nbsp;>&nbsp;Change Password");
            this.txtoldpwd.Focus();
            this.strImagepath = global.imagePath();
            this.userID = int.Parse(this.Session["userID"].ToString());
            if (!base.IsPostBack)
            {
                this.btnsubmit.Text = this.objLanguage.convert(this.btnsubmit.Text);
                this.btncancel.Text = this.objLanguage.convert(this.btncancel.Text);
                this.RequiredFieldValidator1.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator1.ErrorMessage);
                this.RequiredFieldValidator2.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator2.ErrorMessage);
                this.RequiredFieldValidator3.ErrorMessage = this.objLanguage.convert(this.RequiredFieldValidator3.ErrorMessage);
                this.CompareValidator1.ErrorMessage = this.objLanguage.convert(this.CompareValidator1.ErrorMessage);
                this.lnkBack.Text = this.objLanguage.convert(this.lnkBack.Text);
                this.lnkBack.PostBackUrl = base.Request.UrlReferrer.ToString();
                this.lblmessageconfirm.Text = this.objLanguage.convert("Password has been changed successfully");
            }
        }
    }
}