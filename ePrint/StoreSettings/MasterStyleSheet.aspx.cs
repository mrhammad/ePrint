using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.StoreSettings
{
    public partial class MasterStyleSheet : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

        public static string strSitepath;

        public string strImagepath = global.imagePath();

        public string Store_ThemePath = string.Empty;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public string StyleSheetPathMaster = string.Empty;

        private string AccountType = string.Empty;

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

        static MasterStyleSheet()
        {
            MasterStyleSheet.strSitepath = global.sitePath();
        }

        public MasterStyleSheet()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.QueryString["at"] != null && base.Request.QueryString["at"].ToString() != "")
            {
                this.AccountType = base.Request.QueryString["at"].ToString();
            }
            if (this.AccountType.ToString().ToLower() != "p")
            {
                this.StyleSheetPathMaster = base.Server.MapPath("../document/store/0/Themes/StyleSheet.css");
            }
            else
            {
                this.StyleSheetPathMaster = base.Server.MapPath("../document/store/0/Themes/StyleSheet_B2B.css");
            }
            FileInfo fileInfo = new FileInfo(this.StyleSheetPathMaster);
            if (File.Exists(this.StyleSheetPathMaster))
            {
                this.txt_editStyleSheet.Text = File.ReadAllText(this.StyleSheetPathMaster);
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Master StyleSheet", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}