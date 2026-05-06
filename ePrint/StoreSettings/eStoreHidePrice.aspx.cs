using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.StoreSettings
{
    public partial class eStoreHidePrice : BaseClass, IRequiresSessionState
    {
        

        private Global gloobj = new Global();

        public static int CompanyID;

        public static int UserID;

        public static long AccountID;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

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

        static eStoreHidePrice()
        {
        }

        public eStoreHidePrice()
        {
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Setting_UpdateHidePrice(eStoreHidePrice.AccountID, this.chkHidePrice.Checked);
            base.Response.Redirect("eStoreHidePrice.aspx?suc=up");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] != null)
            {
                eStoreHidePrice.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"] != null)
            {
                eStoreHidePrice.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            this.lblHidePrice.Text = this.objLanguage.GetLanguageConversion("Hide_Price");
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)eStoreHidePrice.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                eStoreHidePrice.AccountID = (long)Convert.ToInt32(strArrays[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Settings Saved Successfully", "msg-success", this.plhMessageNew);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Hide_Price")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("\tHide B2B eStore Prices", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Hide_Price");
            this.header.dtAccountList = this.objAcc.AccountsListforApprovalSystem(eStoreHidePrice.CompanyID);
            if (!base.IsPostBack)
            {
                foreach (DataRow row in SettingsBasePage.Setting_SpendLimit_Select(eStoreHidePrice.AccountID, (long)eStoreHidePrice.CompanyID).Rows)
                {
                    if (!Convert.ToBoolean(row["EnableHidePrice"]))
                    {
                        this.chkHidePrice.Checked = false;
                    }
                    else
                    {
                        this.chkHidePrice.Checked = true;
                    }
                }
            }
        }
    }
}