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
    public partial class eStoreSpendLimit : BaseClass, IRequiresSessionState
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

        static eStoreSpendLimit()
        {
        }

        public eStoreSpendLimit()
        {
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Setting_Insert_SpendLimitSettings(eStoreSpendLimit.AccountID, (long)eStoreSpendLimit.CompanyID, (long)eStoreSpendLimit.UserID, this.chkSpendLimit.Checked, this.rdoPerUser1.Checked, this.rdoPerdept.Checked);
            base.Response.Redirect("eStoreSpendLimit.aspx?suc=up");
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
            this.rdoPerdept.Text = this.objLanguage.GetLanguageConversion("Per_department");
            this.rdoPerUser1.Text = this.objLanguage.GetLanguageConversion("Per_user");
            this.lblspendlimit.Text = this.objLanguage.GetLanguageConversion("Apply_Spend_Limit");
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
                DataTable dataTable = SettingsBasePage.Setting_SpendLimit_Select(eStoreSpendLimit.AccountID, (long)eStoreSpendLimit.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!Convert.ToBoolean(row["IsSpendlimitEnabled"]))
                    {
                        this.chkSpendLimit.Checked = false;
                    }
                    else
                    {
                        this.chkSpendLimit.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsForUser"]))
                    {
                        this.rdoPerUser1.Checked = false;
                    }
                    else
                    {
                        this.rdoPerUser1.Checked = true;
                    }
                    if (!Convert.ToBoolean(row["IsForDepartment"]))
                    {
                        this.rdoPerdept.Checked = false;
                    }
                    else
                    {
                        this.rdoPerdept.Checked = true;
                    }
                }
                if (dataTable.Rows.Count == 0)
                {
                    this.chkSpendLimit.Checked = false;
                    this.rdoPerUser1.Checked = false;
                    this.rdoPerdept.Checked = false;
                }
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisable1();", true);
            }
        }
    }
}