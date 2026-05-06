using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.StoreSettings
{
    public partial class TermsAndConditions : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public string ServerName = ConnectionClass.ServerName;

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

        public TermsAndConditions()
        {
        }

        public void btn_Save_Onclick(object sender, EventArgs e)
        {
            int num = 0;
            num = (!this.chk_isterms.Checked ? 0 : 1);
            WebstoreBasePage.TermsAndConditions_Insert(this.CompanyID, this.AccountID, num, this.Radeditor.Content);
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Terms_And_Conditions_Saved_Successfully"), "msg-success", this.plhMessageNew);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            string[] strArrays1 = strArrays;
            this.Radeditor.ImageManager.UploadPaths = strArrays1;
            this.Radeditor.ImageManager.ViewPaths = strArrays1;
            this.Radeditor.FlashManager.ViewPaths = strArrays1;
            this.Radeditor.FlashManager.UploadPaths = strArrays1;
            this.Radeditor.DocumentManager.ViewPaths = strArrays1;
            this.Radeditor.DocumentManager.UploadPaths = strArrays1;
            this.Radeditor.Height = Unit.Pixel(400);
            this.Radeditor.Width = Unit.Pixel(700);
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.Radeditor.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays2 = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays2[0]);
            }
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>eStore Settings View</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Terms_And_Conditions")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Terms And Conditions", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Terms_And_Conditions");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            if (!base.IsPostBack)
            {
                foreach (DataRow row in WebstoreBasePage.TermsAndConditions_Select(this.CompanyID, this.AccountID).Rows)
                {
                    if (!Convert.ToBoolean(row["IsTerms"]))
                    {
                        this.chk_isterms.Checked = false;
                    }
                    else
                    {
                        this.chk_isterms.Checked = true;
                    }
                    this.Radeditor.Content = row["TermsAndCondition"].ToString();
                }
            }
        }
    }
}