using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class forgotpassword : System.Web.UI.Page, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected HtmlGenericControl div_linkaccount;

        //protected HtmlGenericControl div_emailMsg;

        //protected HtmlImage imgSucess_Invalid;

        //protected Label lblSucess_Invalid;

        //protected HtmlGenericControl div_linkaccount_Invalid;

        //protected HtmlGenericControl div_emailMsg_Invalid;

        //protected Label lbl_forgotPassword;

        //protected Label Label1;

        //protected Label lbl_loginemail;

        //protected TextBox txt_loginemail;

        //protected RequiredFieldValidator reqemail;

        //protected RegularExpressionValidator RegularExpressionValidator1;

        //protected CustomValidator cvEmailID;

        //protected Button Button1;

        public string SesseionKey = string.Empty;

        public string AccountType = string.Empty;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        private EmailClass objemail = new EmailClass();

        private BaseClass objBase = new BaseClass();

        public languageClass objLanguage = new languageClass();

        public long StoreUserID;

        public static int companyID;

        public static long AccountID;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        static forgotpassword()
        {
        }

        public forgotpassword()
        {
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                this.lblSucess_Invalid.Text = "The email which you have entered doesnot exist in our system. Please retry or create a";
                this.div_emailMsg_Invalid.Style.Add("display", "block");
                this.div_emailMsg.Style.Add("display", "none");
            }
            else
            {
                DataTable dataTable = LoginBasePage.LoginTo_Store(this.objBase.SpecialEncode(this.txt_loginemail.Text.Trim()), "", forgotpassword.AccountID, ConnectionClass.AccountType);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.objemail.emailPassword(Convert.ToInt32(row["StoreUserID"].ToString()), Convert.ToInt32(row["CompanyID"]), Convert.ToInt32(row["AccountID"]), "Password Reminder Email");
                    this.lblSucess.Text = "The password has been send to your email.";
                    this.div_emailMsg.Style.Add("display", "block");
                    this.div_emailMsg_Invalid.Style.Add("display", "none");
                }
            }
        }

        protected void custEmailID_Duplicacy_ServerValidate(object source, ServerValidateEventArgs args)
        {
            loginclass _loginclass = new loginclass();
            if (LoginBasePage.CheckEmailID_Duplicacy((long)0, this.objBase.SpecialEncode(this.txt_loginemail.Text), forgotpassword.AccountID) == -1)
            {
                args.IsValid = true;
                return;
            }
            args.IsValid = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.reqemail.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Email_Address_Example_Note");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Submit");
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                forgotpassword.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                forgotpassword.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            HtmlImage htmlImage = this.imgSucess;
            object[] accountID = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=i_msg-success.gif&type=r&aid=", forgotpassword.AccountID, " &cid=", forgotpassword.companyID };
            htmlImage.Src = string.Concat(accountID);
            this.imgSucess.Alt = "";
            if (this.comm.GetDisplayValue("IsHome", forgotpassword.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(forgotpassword.companyID), Convert.ToInt32(forgotpassword.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            base.Title = commonclass.pageTitle("Forgot Password", Convert.ToInt32(forgotpassword.companyID), Convert.ToInt32(forgotpassword.AccountID));
            this.txt_loginemail.Focus();
        }
    }
}