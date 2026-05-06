using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using System.Web.Profile;
using System.Web.SessionState;
using Printcenter.UI.Setting;
using System.Data;
using Printcenter.UI.Company;

namespace ePrint.StoreSettings
{
    public class ShipEngineErrorData
    {
        public long CompanyID { get; set; }
        public long ClientID { get; set; }
        public bool IsTermsAndConditions { get; set; }
        public string ErrorMsg { get; set; }
    }
    public partial class ShipEngineError : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public long AccountID;

        public long ClientID;


        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        public CompanyBasePage companyBasePage = new CompanyBasePage();


        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        private BaseClass objBase = new BaseClass();

        public string AccList = string.Empty;

        public string SettingName = string.Empty;

        public DataTable dtAccountList = new DataTable();

        public string lblAccountName = string.Empty;

        public string Account_Name = string.Empty;

        public string Account_Type = string.Empty;

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
        public List<ShipEngineErrorData> clientList = new List<ShipEngineErrorData>();
        public void Save_OnClick(object sender, EventArgs e)
        {
            UPMessageNew.Visible = false;
            if (this.hdnAccountId.Value != "")
            {
                if (this.hdnAccountId.Value != "-1")
                {
                    string[] strArrays = this.hdnAccountId.Value.Split(new char[] { '~' });
                    SettingsBasePage.UpdateSelectedAccountID((long)this.UserID, Convert.ToInt64(strArrays[0].ToString()));
                    DataTable dt = companyBasePage.company_customer_select_by_clientID(this.CompanyID, Convert.ToInt64(strArrays[0].ToString()));
                    string clientName = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        clientName = dr["clientname"].ToString();
                    }
                    this.divdrpdn.Style["display"] = "none";
                    this.lbleStore.Text = clientName;
                    this.ClientID = Convert.ToInt64(strArrays[0].ToString());
                    DataTable dataTable = SettingsBasePage.Setting_ShipEngineError_Select(this.ClientID, this.CompanyID);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (!Convert.ToBoolean(row["IsTermsAndConditions"]))
                        {
                            this.chkTerms.Checked = false;
                        }
                        else
                        {
                            this.chkTerms.Checked = true;
                        }
                        if (!string.IsNullOrEmpty(row["ErrorMsg"].ToString()))
                        {
                            this.txtTermsDescription.InnerText = row["ErrorMsg"].ToString();
                        }

                    }
                    if (dataTable.Rows.Count == 0)
                    {
                        this.chkTerms.Checked = false;
                        this.txtTermsDescription.InnerText = "";

                    }
                }
                else
                {
                    this.divdrpdn.Style["display"] = "none";
                    this.lbleStore.Text = "All";
                    DataTable dataTable = SettingsBasePage.Setting_ShipEngineError_Select(0, this.CompanyID);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (!Convert.ToBoolean(row["IsTermsAndConditions"]))
                        {
                            this.chkTerms.Checked = false;
                        }
                        else
                        {
                            this.chkTerms.Checked = true;
                        }
                        if (!string.IsNullOrEmpty(row["ErrorMsg"].ToString()))
                        {
                            this.txtTermsDescription.InnerText = row["ErrorMsg"].ToString();
                        }

                    }
                    if (dataTable.Rows.Count == 0)
                    {
                        this.chkTerms.Checked = false;
                        this.txtTermsDescription.InnerText = "";

                    }
                }
                //base.Response.Redirect(string.Concat(this.strSitepath, "settings/ProofTermsAndConditions.aspx?id="+this.ClientID+""));
                //return;
            }
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            UPMessageNew.Visible = true;
            if (!string.IsNullOrEmpty(this.txtTermsDescription.InnerText))
            {
                this.terms_error.Style.Add("display", "none");
                if (this.hdnAccountId.Value != "-1")
                {
                    if (this.hdnAccountId.Value != "" || this.ClientID > 0)
                    {
                        if (this.hdnAccountId.Value == "")
                        {
                            this.hdnAccountId.Value = this.ClientID.ToString();
                        }
                        string[] strArrays = this.hdnAccountId.Value.Split(new char[] { '~' });
                        this.ClientID = Convert.ToInt64(strArrays[0].ToString());
                        SettingsBasePage.Setting_InsertUpdateShipEngineErrorMsg(this.CompanyID, this.ClientID, this.chkTerms.Checked, this.txtTermsDescription.InnerText);
                    }
                }
                else
                {
                    ShipEngineErrorData _ShipEngineErrorData = new ShipEngineErrorData();
                    _ShipEngineErrorData.CompanyID = this.CompanyID;
                    _ShipEngineErrorData.ClientID = 0;
                    _ShipEngineErrorData.IsTermsAndConditions = this.chkTerms.Checked;
                    _ShipEngineErrorData.ErrorMsg = this.txtTermsDescription.InnerText;
                    clientList.Add(_ShipEngineErrorData);
                    foreach (DataRow row in this.dtAccountList.Rows)
                    {
                        ShipEngineErrorData ShipEngineErrorData = new ShipEngineErrorData();
                        ShipEngineErrorData.CompanyID = this.CompanyID;
                        ShipEngineErrorData.ClientID = long.Parse(row["clientID"].ToString());
                        ShipEngineErrorData.IsTermsAndConditions = this.chkTerms.Checked;
                        ShipEngineErrorData.ErrorMsg = this.txtTermsDescription.InnerText;
                        clientList.Add(ShipEngineErrorData);
                    }
                    SettingsBasePage.Setting_AllInsertUpdateShipEngineErrorData(clientList);
                }
                base.Response.Redirect("ShipEngineError.aspx?suc=up&id=" + this.ClientID + "");
            }
            else
            {
                this.terms_error.Style.Add("display", "block");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.lblTerms.Text = "Display Error on Error State";
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Settings Saved Successfully", "msg-success", this.plhMessageNew);

            }
            if (base.Request.Params["id"] != null)
            {
                this.ClientID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/Settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Ship_Engine_Error")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            this.SettingName = this.objLanguage.GetLanguageConversion("ShipEngineError");
            base.Title = this.objLanguage.convert(global.pageTitle("ShipEngine Error", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            //this.dtAccountList = this.objAcc.AccountsListforApprovalSystem(this.CompanyID);
            this.lblSettingName.Text = this.SettingName;
            this.dtAccountList = companyBasePage.company_customer_select(this.CompanyID);
            this.plhAccountList.Controls.Add(new LiteralControl("<table>"));
            string str3 = "-1";

            // Add static item
            this.plhAccountList.Controls.Add(new LiteralControl("<tr>"));
            this.plhAccountList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
            this.plhAccountList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
            ControlCollection staticItemControls = this.plhAccountList.Controls;
            string[] staticItemHtml = new string[] { "<a style='color: Black' href =javascript:AccountSelect('", str3, "'); >All</a>" };
            staticItemControls.Add(new LiteralControl(string.Concat(staticItemHtml)));
            this.plhAccountList.Controls.Add(new LiteralControl("</div>"));
            this.plhAccountList.Controls.Add(new LiteralControl("</td>"));
            this.plhAccountList.Controls.Add(new LiteralControl("</tr>"));
            //int num = 0;
            //int num1 = 0;
            //string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);

            if (base.Request.Params["type"] == "edit" || base.Request.Params["type"] == "add" || base.Request.Params["mode"] == "edit")
            {
                this.spn_change.Visible = false;
            }
            foreach (DataRow row in this.dtAccountList.Rows)
            {
                string str1 = row["clientname"].ToString();
                string str2 = row["clientID"].ToString();
                this.plhAccountList.Controls.Add(new LiteralControl("<tr>"));
                this.plhAccountList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
                this.plhAccountList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
                ControlCollection controls = this.plhAccountList.Controls;
                string[] strArrays1 = new string[] { "<a style='color: Black' href =javascript:AccountSelect('", str2, "'); >", str1, "</a>" };
                controls.Add(new LiteralControl(string.Concat(strArrays1)));
                this.plhAccountList.Controls.Add(new LiteralControl("</div>"));
                this.plhAccountList.Controls.Add(new LiteralControl("</tr>"));
                this.plhAccountList.Controls.Add(new LiteralControl("</td>"));
                //this.Account_Name = str1;
                //this.Account_Type = row["accounttype"].ToString();
            }
            this.plhAccountList.Controls.Add(new LiteralControl("</table>"));
            if (this.ClientID > 0)
            {
                DataTable dt = companyBasePage.company_customer_select_by_clientID(this.CompanyID, this.ClientID);
                string clientName = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    clientName = dr["clientname"].ToString();
                }
                this.divdrpdn.Style["display"] = "none";
                this.lbleStore.Text = clientName;
            }
            if (this.ClientID == 0)
            {
                this.divdrpdn.Style["display"] = "none";
                this.lbleStore.Text = "All";
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = SettingsBasePage.Setting_GetShipEngineErrorSelectedCustomer(this.CompanyID);
                foreach (DataRow dr in dataTable1.Rows)
                {
                    this.ClientID = Convert.ToInt64(dr["ClientID"].ToString());
                    this.lbleStore.Text = dr["clientname"].ToString();

                }
                DataTable dataTable = SettingsBasePage.Setting_ShipEngineError_Select(this.ClientID, this.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!Convert.ToBoolean(row["IsTermsAndConditions"]))
                    {
                        this.chkTerms.Checked = false;
                    }
                    else
                    {
                        this.chkTerms.Checked = true;
                    }
                    if (!string.IsNullOrEmpty(row["ErrorMsg"].ToString()))
                    {
                        this.txtTermsDescription.InnerText = row["ErrorMsg"].ToString();
                    }

                }
                if (dataTable.Rows.Count == 0)
                {
                    this.chkTerms.Checked = false;
                    this.txtTermsDescription.InnerText = "";

                }
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisable1();", true);
            }
        }
    }
}