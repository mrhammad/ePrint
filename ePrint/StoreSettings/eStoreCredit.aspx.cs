using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using Printcenter.UI.Setting;
using System.Data;
using System.Web.SessionState;

namespace ePrint.StoreSettings
{
    public partial class eStoreCredit : BaseClass, IRequiresSessionState
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
        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Setting_Insert_StoreCreditsettings(eStoreSpendLimit.AccountID, (long)eStoreSpendLimit.CompanyID, (long)eStoreSpendLimit.UserID, this.chkSpendLimit.Checked,false);
            base.Response.Redirect("eStoreCredit.aspx?suc=up");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] != null)
            {
                eStoreSpendLimit.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"] != null)
            {
                eStoreSpendLimit.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            //this.rdoPerdept.Text = this.objLanguage.GetLanguageConversion("Per_department");
            //this.rdoPerUser1.Text = this.objLanguage.GetLanguageConversion("Per_user");
            this.lblspendlimit.Text = "Apply store credit";
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)eStoreSpendLimit.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                eStoreSpendLimit.AccountID = (long)Convert.ToInt32(strArrays[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Settings Saved Successfully", "msg-success", this.plhMessageNew);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Spend_Limit")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Spend Limit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Spend_Limit");
            this.header.dtAccountList = this.objAcc.AccountsListforApprovalSystem(eStoreSpendLimit.CompanyID);
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.Setting_StoreCredit_Select(eStoreSpendLimit.AccountID, (long)eStoreSpendLimit.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!Convert.ToBoolean(row["IsStoreCreditsEnabled"]))
                    {
                        this.chkSpendLimit.Checked = false;
                    }
                    else
                    {
                        this.chkSpendLimit.Checked = true;
                    }
                   
                }
                if (dataTable.Rows.Count == 0)
                {
                    this.chkSpendLimit.Checked = false;
                  
                }
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisable1();", true);
            }
        }
    }
}