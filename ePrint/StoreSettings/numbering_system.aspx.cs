using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Data;
using System.Net;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class numbering_system : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        private Global gloobj = new Global();

        public char NumberType;

        public int CompanyID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string IpAddress = string.Empty;

        public string NumberingChangeHistory = string.Empty;

        public languageClass objlang = new languageClass();

        public string IsLock = string.Empty;

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

        public numbering_system()
        {
        }

        protected void btn_cancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"));
        }

        protected void btn_save_OnClick(object sender, EventArgs e)
        {
            this.IpAddress = numbering_system.LocalIPAddress();
            DataTable dataTable = SettingsBasePage.settings_number_select1(Convert.ToInt32(this.Session["companyId"].ToString()));
            if (dataTable.Rows[0]["OrderType"].ToString().TrimEnd(new char[0]) != "a")
            {
                this.NumberingChangeHistory = string.Concat("Numbering system has been changed from Common with Value: ", dataTable.Rows[0]["Order"].ToString());
            }
            else
            {
                this.NumberingChangeHistory = "Numbering system has been changed from Auto";
            }
            if (!this.RadioButton1.Checked)
            {
                this.TextBox1.Text = "";
                if (this.hidDbValue.Value == "a")
                {
                    this.NumberingChangeHistory = string.Concat(this.NumberingChangeHistory, " changed to Auto");
                    SettingsBasePage.settings_number_insert(this.CompanyID, 0, 0, 0, 0, 0, 'a', 0, "yes", this.IpAddress, this.NumberingChangeHistory,0);
                }
            }
            else if (this.RadioButton2.Checked)
            {
                this.NumberingChangeHistory = string.Concat(this.NumberingChangeHistory, " to Common with Value: ", this.TextBox1.Text);
                SettingsBasePage.settings_number_insert(this.CompanyID, 0, 0, 0, 0, 0, 'i', Convert.ToInt32(this.TextBox1.Text), "yes", this.IpAddress, this.NumberingChangeHistory,0);
            }
            base.Message_Display("Numbering System saved successfully", "msg-success", this.plhMessage);
            base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/numbering_system.aspx?type=su"));
            this.pnlShowOnEdit.Visible = true;
        }

        public static string LocalIPAddress()
        {
            string str = "";
            System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < (int)addressList.Length; i++)
            {
                str = addressList[i].ToString();
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_cancel.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel','div_btn_cancelprocess');");
            this.rbauto.Text = this.objlang.GetLanguageConversion("Auto");
            this.btn_save.Text = this.objlang.GetLanguageConversion("Save_Lock");
            this.btn_cancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.RadioButton1.Text = this.objlang.GetLanguageConversion("Custom");
            this.RadioButton2.Text = string.Concat(this.objlang.GetLanguageConversion("eStore_Orders_Starting_Value"), " : ");
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            this.rbauto.Focus();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Numbering_System")));
            base.Title = this.objLanguage.convert(global.pageTitle("Numbering System", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objlang.GetLanguageConversion("Numbering_System");
            if (this.Session["companyId"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["companyId"]);
            }
            try
            {
                if (base.Request["type"].ToLower() == "su")
                {
                    base.Message_Display("Numbering System saved successfully", "msg-success", this.plhMessage);
                }
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                IDataReader dataReader = SettingsBasePage.settings_number_select(Convert.ToInt32(this.Session["companyId"].ToString()));
                while (dataReader.Read())
                {
                    this.IsLock = dataReader["IsOrderLocked"].ToString().ToLower().Trim();
                    if (dataReader["IsOrderLocked"].ToString().ToLower() != "false")
                    {
                        this.btn_save.Attributes.Add("style", "cursor:not-allowed");
                        this.btn_save.Enabled = false;
                    }
                    else
                    {
                        this.btn_save.Enabled = true;
                    }
                    if (dataReader["OrderType"].ToString().TrimEnd(new char[0]) != "a")
                    {
                        if (dataReader["OrderType"].ToString().TrimEnd(new char[0]) != "i")
                        {
                            continue;
                        }
                        this.NumberType = 'i';
                        this.RadioButton1.Checked = true;
                        this.RadioButton2.Enabled = true;
                        this.TextBox1.Text = dataReader["Order"].ToString();
                        this.hidDbValue.Value = "i";
                    }
                    else
                    {
                        this.NumberType = 'a';
                        this.rbauto.Checked = true;
                        if (base.IsPostBack)
                        {
                            this.RadioButton2.Checked = true;
                        }
                        this.hidDbValue.Value = "a";
                    }
                }
                dataReader.Dispose();
            }
            this.rbauto.Attributes.Add("onclick", "javascript:enablegroup('a');");
            this.RadioButton1.Attributes.Add("onclick", "javascript:enablegroup('i');");
            this.btn_save.Attributes.Add("onclick", "javascript:return checkvalidation();");
            this.btn_save.Attributes.Add("onclick", "javascript:return Validation();");
            this.btn_save.Attributes.Add("onclick", "javascript:return btnSave_Confirmation();");
            this.pnlShowOnEdit.Visible = true;
        }

        protected void rbauto_OnCheckedChanged(object sender, EventArgs e)
        {
        }
    }
}