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

namespace ePrint.settings
{
    public partial class number_settings : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected Label lblerror;

        //protected RadioButton rbauto;

        //protected RadioButton RadioButton1;

        //protected RadioButton RadioButton2;

        //protected TextBox TextBox1;

        //protected RadioButton RadioButton3;

        //protected TextBox txtestimate;

        //protected TextBox txtjobs;

        //protected TextBox txtpurchases;

        //protected TextBox txtinvoices;

        //protected TextBox txtdelivery;

        //protected RadButton btn_cancel;

        //protected Button btn_save;

        //protected HiddenField hdnType;

        //protected HiddenField hidDbValue;

        //protected Panel pnlShowOnEdit;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        private Global gloobj = new Global();

        public char NumberType;

        public int CompanyID;

        public string IsLock = string.Empty;

        public string IpAddress = string.Empty;

        public string NumberingChangeHistory = string.Empty;

        public languageClass objlang = new languageClass();

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

        public number_settings()
        {
        }

        protected void btn_cancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btn_save_OnClick(object sender, EventArgs e)
        {
            this.IpAddress = number_settings.LocalIPAddress();
            DataTable dataTable = SettingsBasePage.settings_number_select1(Convert.ToInt32(this.Session["companyId"].ToString()));
            if (dataTable.Rows[0]["Type"].ToString().TrimEnd(new char[0]) == "a")
            {
                this.NumberingChangeHistory = "Numbering system has been changed from Auto";
            }
            else if (dataTable.Rows[0]["Type"].ToString().TrimEnd(new char[0]) != "i")
            {
                this.NumberingChangeHistory = string.Concat("Numbering system has been changed from Common with Value: ", dataTable.Rows[0]["Estimates"].ToString());
            }
            else
            {
                string[] str = new string[] { "Numbering system has been changed from Individual with Estimates Value: ", dataTable.Rows[0]["Estimates"].ToString(), " Jobs Value: ", dataTable.Rows[0]["Jobs"].ToString(), " Invoices Value: ", dataTable.Rows[0]["Invoices"].ToString(), " Purchases Value: ", dataTable.Rows[0]["Purchases"].ToString(), " Delivery Value: ", dataTable.Rows[0]["Delivery"].ToString() };
                this.NumberingChangeHistory = string.Concat(str);
            }
            if (!this.RadioButton1.Checked)
            {
                this.TextBox1.Text = "";
                this.txtestimate.Text = "";
                this.txtjobs.Text = "";
                this.txtpurchases.Text = "";
                this.txtinvoices.Text = "";
                this.txtdelivery.Text = "";
                this.txtAccountNumber.Text = "";
                this.NumberingChangeHistory = string.Concat(this.NumberingChangeHistory, " changed to Auto");
                if (this.hidDbValue.Value != "a")
                {
                    SettingsBasePage.settings_number_insert(this.CompanyID, 0, 0, 0, 0, 0, 'a', 0, "no", this.IpAddress, this.NumberingChangeHistory,0);
                }
            }
            else
            {
                if (!this.RadioButton2.Checked)
                {
                    string[] numberingChangeHistory = new string[] { this.NumberingChangeHistory, " to Individual with Estimate Value: ", this.txtestimate.Text, " Job Value: ", this.txtjobs.Text, " Purchase Value: ", this.txtpurchases.Text, " Delivery Value: ", this.txtdelivery.Text, " Account Value: ", this.txtAccountNumber.Text };
                    this.NumberingChangeHistory = string.Concat(numberingChangeHistory);
                    SettingsBasePage.settings_number_insert(this.CompanyID, Convert.ToInt32(this.txtestimate.Text), Convert.ToInt32(this.txtjobs.Text), Convert.ToInt32(this.txtinvoices.Text), Convert.ToInt32(this.txtpurchases.Text), Convert.ToInt32(this.txtdelivery.Text), 'i', 0, "no", this.IpAddress, this.NumberingChangeHistory, Convert.ToInt32(this.txtAccountNumber.Text));
                }
                else
                {
                    this.NumberingChangeHistory = string.Concat(this.NumberingChangeHistory, " to Common with Value: ", this.TextBox1.Text);
                    SettingsBasePage.settings_number_insert(this.CompanyID, Convert.ToInt32(this.TextBox1.Text), Convert.ToInt32(this.TextBox1.Text), Convert.ToInt32(this.TextBox1.Text), Convert.ToInt32(this.TextBox1.Text), Convert.ToInt32(this.TextBox1.Text), 'd', 0, "no", this.IpAddress, this.NumberingChangeHistory, Convert.ToInt32(this.TextBox1.Text));
                }
                base.Message_Display(this.objlang.GetLanguageConversion("Numbering_System_saved_successfully"), "msg-success", this.plhMessage);
                base.Response.Redirect(string.Concat(this.strSitepath, "Settings/number_settings.aspx?type=su"));
            }
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
            this.btn_cancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btncancelprocess');");
            this.rbauto.Text = this.objlang.GetLanguageConversion("Auto");
            this.btn_save.Text = this.objlang.GetLanguageConversion("Save_Lock");
            this.btn_cancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.RadioButton1.Text = this.objlang.GetLanguageConversion("Custom");
            this.RadioButton2.Text = this.objlang.GetLanguageConversion("Numbering_System_Note");
            this.RadioButton3.Text = this.objlang.GetLanguageConversion("Set_The_Starting_Value_For_Individuals");
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            this.rbauto.Focus();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Numbering_System")));
            base.Title = this.objLanguage.convert(global.pageTitle("Numbering System", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Numbering_System");
            if (this.Session["companyId"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["companyId"]);
            }
            try
            {
                if (base.Request["type"].ToLower() == "su")
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Numbering_System_saved_successfully"), "msg-success", this.plhMessage);
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
                    this.IsLock = dataReader["isLocked"].ToString().ToLower().Trim();
                    if (dataReader["isLocked"].ToString().ToLower() != "false")
                    {
                        this.btn_save.Attributes.Add("style", "cursor:not-allowed");
                        this.btn_save.Enabled = false;
                    }
                    else
                    {
                        this.btn_save.Enabled = true;
                    }
                    if (dataReader["Type"].ToString().TrimEnd(new char[0]) == "a")
                    {
                        this.NumberType = 'a';
                        this.rbauto.Checked = true;
                        if (base.IsPostBack)
                        {
                            this.RadioButton2.Checked = true;
                            this.RadioButton3.Checked = false;
                        }
                        this.hidDbValue.Value = "a";
                    }
                    else if (dataReader["Type"].ToString().TrimEnd(new char[0]) != "i")
                    {
                        this.NumberType = 'd';
                        this.RadioButton2.Checked = true;
                        this.RadioButton1.Checked = true;
                        this.TextBox1.Text = dataReader["Estimates"].ToString();
                        this.hidDbValue.Value = "d";
                    }
                    else
                    {
                        this.NumberType = 'i';
                        this.RadioButton3.Checked = true;
                        this.RadioButton1.Checked = true;
                        this.txtestimate.Text = dataReader["Estimates"].ToString();
                        this.txtinvoices.Text = dataReader["Invoices"].ToString();
                        this.txtjobs.Text = dataReader["Jobs"].ToString();
                        this.txtpurchases.Text = dataReader["Purchases"].ToString();
                        this.txtdelivery.Text = dataReader["Delivery"].ToString();
                        this.txtAccountNumber.Text = dataReader["Account"].ToString();
                        this.RadioButton2.Enabled = true;
                        this.RadioButton3.Enabled = true;
                        this.hidDbValue.Value = "i";
                    }
                }
                dataReader.Dispose();
            }
            this.rbauto.Attributes.Add("onclick", "javascript:enablegroup('a');");
            this.RadioButton1.Attributes.Add("onclick", "javascript:enablegroup('c');");
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