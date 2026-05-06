using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class system_markup : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private commonClass objcom = new commonClass();

        public int CompanyID;

        public int UserID;

        public string MarkupName = string.Empty;

        public decimal MarkupRate;

        public int MarkupID;

        public string paperType = string.Empty;

        public string serverName = ConnectionClass.ServerName;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public system_markup()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_markup_delete(this.CompanyID, Convert.ToInt32(this.ddlMarkup.SelectedValue));
            Thread.Sleep(250);
            SettingsBasePage.Bind_Markup(this.ddlMarkup, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
            this.GetMarkupRate();
            this.hid_MarkType.Value = "add";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (this.hid_SysMarkupType.Value != "add")
            {
                SettingsBasePage.settings_system_markup_update(this.CompanyID, Convert.ToInt32(this.hid_SysMarkupID.Value), Convert.ToDecimal(this.txtPaper.Text), Convert.ToDecimal(this.txtPrintBroker.Text), Convert.ToDecimal(this.txtInks.Text), Convert.ToDecimal(this.txtInventoryItems.Text), Convert.ToDecimal(this.txtOtherCosts.Text), Convert.ToDecimal(this.txtDeliveryCost.Text), Convert.ToInt32(this.ddlMarkup.SelectedValue), Convert.ToInt32(this.ddlTax.SelectedValue), this.chkrounduptotals.Checked);
            }
            else
            {
                SettingsBasePage.settings_system_markup_insert(this.CompanyID, Convert.ToDecimal(this.txtPaper.Text), Convert.ToDecimal(this.txtPrintBroker.Text), Convert.ToDecimal(this.txtInks.Text), Convert.ToDecimal(this.txtInventoryItems.Text), Convert.ToDecimal(this.txtOtherCosts.Text), Convert.ToDecimal(this.txtDeliveryCost.Text), Convert.ToInt32(this.ddlMarkup.SelectedValue), Convert.ToInt32(this.ddlTax.SelectedValue), this.chkrounduptotals.Checked);
            }
            if (this.hid_SysMarkupType.Value == "add")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("System_Markups_saved_successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objlang.GetLanguageConversion("System_Markups_updated_successfully"), "msg-success", this.plhMessage);
        }

        protected void btnSaveMarkup_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.hid_MarkType.Value != "add")
            {
                empty = this.txtMarkupName.Text;
                SettingsBasePage.settings_markup_update(this.CompanyID, Convert.ToInt32(this.ddlMarkup.SelectedValue), base.SpecialEncode(this.txtMarkupName.Text), Convert.ToDecimal(base.SpecialEncode(this.txtMarkupRate.Text)));
                this.btnDelete.Style.Add("display", "block");
            }
            else
            {
                empty = this.txtMarkupName.Text;
                SettingsBasePage.settings_markup_insert(this.CompanyID, base.SpecialEncode(this.txtMarkupName.Text), Convert.ToDecimal(base.SpecialEncode(this.txtMarkupRate.Text.ToString())));
                this.txtMarkupName.Text = string.Empty;
                this.txtMarkupRate.Text = string.Empty;
            }
            SettingsBasePage.Bind_Markup(this.ddlMarkup, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
            for (int i = 0; i < this.ddlMarkup.Items.Count; i++)
            {
                if (this.ddlMarkup.Items[i].Text == empty)
                {
                    this.ddlMarkup.SelectedIndex = i;
                }
            }
            this.GetMarkupRate();
        }

        protected void ddlMarkup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetMarkupRate();
            if (Convert.ToInt32(this.ddlMarkup.SelectedIndex) == 0)
            {
                this.hid_MarkType.Value = "add";
                return;
            }
            this.hid_MarkType.Value = "edit";
        }

        protected void ddlTax_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetTaxRateByID();
        }

        public void GetMarkupRate()
        {
            DataTable dataTable = SettingsBasePage.settings_markup_select(this.CompanyID, Convert.ToInt32(this.ddlMarkup.SelectedValue));
            foreach (DataRow row in dataTable.Rows)
            {
                this.MarkupName = row["MarkupName"].ToString();
                this.MarkupRate = Convert.ToDecimal(row["MarkupRate"].ToString());
            }
            this.hid_MarkRate.Value = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.MarkupRate.ToString()), 0, "", false, false, true);
            this.lblmarkup.Text = string.Concat(this.hid_MarkRate.Value, "%");
        }

        protected void GetTaxRateByID()
        {
            decimal num = new decimal(0);
            DataTable dataTable = SettingsBasePage.settings_taxrate_selectbyID(this.CompanyID, Convert.ToInt32(this.ddlTax.SelectedValue));
            foreach (DataRow row in dataTable.Rows)
            {
                num = Convert.ToDecimal(row["TaxRate"].ToString());
            }
            this.hid_TaxRate.Value = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num.ToString()), 0, "", false, false, true);
            this.lbltaxcode.Text = string.Concat(this.hid_TaxRate.Value, "%");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_btncancelprocess');");
            this.RFVCode.Text = this.objlang.GetLanguageConversion("Please_Enter_Paper_Markup");
            this.REVPaper.Text = this.objlang.GetValueOnLang("Please enter numeric value");
            this.RequiredFieldValidator1.Text = this.objlang.GetValueOnLang("Please enter Outwork Markup ");
            this.REVPrintBroker.Text = this.objlang.GetValueOnLang("Please enter numeric value ");
            this.RequiredFieldValidator3.Text = this.objlang.GetValueOnLang("Please enter Inks Markup");
            this.REVInks.Text = this.objlang.GetValueOnLang("Please enter numeric value");
            this.RequiredFieldValidator4.Text = this.objlang.GetValueOnLang("Please enter Inv. Items Markup");
            this.REVInventoryItems.Text = this.objlang.GetValueOnLang("Please enter numeric value");
            this.RequiredFieldValidator6.Text = this.objlang.GetValueOnLang("Please enter Other Costs Markup");
            this.REVOtherCosts.Text = this.objlang.GetValueOnLang("Please enter numeric value");
            this.RequiredFieldValidator7.Text = this.objlang.GetValueOnLang("Please enter Delivery Cost Markup");
            this.REVDeliveryCost.Text = this.objlang.GetValueOnLang("Please enter numeric value");
            this.RFVMarkup.Text = this.objlang.GetValueOnLang("Please select Markup");
            this.RFVTax.Text = this.objlang.GetValueOnLang("Please select Tax Code");
            this.btnSaveMarkup.Text = this.objlang.GetLanguageConversion("Update");
            this.btnMarkupRatesSave.Text = this.objlang.GetLanguageConversion("Save");
            this.btnMarkupRatesCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnDelete.Text = this.objlang.GetLanguageConversion("Delete");
            this.btnAdd.Text = this.objlang.GetLanguageConversion("Save_as_New");
            this.RFVMarkupName.Text = this.objlang.GetValueOnLang("Please enter Markup Name");
            this.RFVMarkupRate.Text = this.objlang.GetValueOnLang("Please_Enter_Markup_Rate");
            this.Label2.Text = this.objlang.GetLanguageConversion("Markup_Name");
            this.Label3.Text = this.objlang.GetValueOnLang("Rate");
            this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnsave.Text = this.objlang.GetLanguageConversion("Save");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (!base.IsPostBack)
            {
                this.txtPaper.Focus();
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("System_Markup")));
            base.Title = this.objLanguage.convert(global.pageTitle("System Markup", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = "Default Markup";//this.objLanguage.GetLanguageConversion("System_Markup");
            this.paperType = this.objcom.settings_paperMeasurementType(this.CompanyID);
            if (this.serverName.ToLower() == "maspro")
            {
                this.divPaper.Visible = false;
                this.divInks.Visible = false;
            }
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.divPaper.Attributes.Add("style", "display:block");
                this.divInks.Attributes.Add("style", "display:block");
            }
            else
            {
                this.divPaper.Attributes.Add("style", "display:None");
                this.divInks.Attributes.Add("style", "display:None");
            }
            if (!base.IsPostBack)
            {
                SettingsBasePage.Bind_Markup(this.ddlMarkup, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                SettingsBasePage.Bind_TaxRate(this.ddlTax, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                DataTable dataTable = SettingsBasePage.settings_system_markup_select(this.CompanyID);
                if (dataTable.Rows.Count <= 0)
                {
                    this.hid_SysMarkupType.Value = "add";
                    this.txtPaper.Text = "0";
                    this.txtPrintBroker.Text = "0";
                    this.txtInks.Text = "0";
                    this.txtInventoryItems.Text = "0";
                    this.txtOtherCosts.Text = "0";
                    this.txtDeliveryCost.Text = "0";
                    this.ddlMarkup.SelectedValue = "0";
                    this.ddlTax.SelectedValue = "0";
                    this.chkrounduptotals.Checked = false;
                }
                else
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.hid_SysMarkupID.Value = row["SystemMarkupID"].ToString();
                        this.txtPaper.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Paper"].ToString()), 0, " ", false, false, false);
                        this.txtPrintBroker.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PrintBroker"].ToString()), 0, "", false, false, false);
                        this.txtInks.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Inks"].ToString()), 0, " ", false, false, false);
                        this.txtInventoryItems.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["InventoryItems"].ToString()), 0, " ", false, false, false);
                        this.txtOtherCosts.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["OtherCosts"].ToString()), 0, "", false, false, false);
                        this.txtDeliveryCost.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["DeliveryCost"].ToString()), 0, "", false, false, false);
                        this.ddlMarkup.SelectedValue = row["MarkupID"].ToString();
                        this.ddlTax.SelectedValue = row["TaxID"].ToString();
                        this.chkrounduptotals.Checked = Convert.ToBoolean(row["RoundUpTotals"].ToString());
                    }
                    if (this.ddlMarkup.SelectedValue != "0")
                    {
                        this.hid_MarkType.Value = "edit";
                    }
                    this.hid_SysMarkupType.Value = "edit";
                    this.GetMarkupRate();
                    this.GetTaxRateByID();
                    this.lbltaxcode.Text = string.Concat(this.hid_TaxRate.Value, "%");
                }
            }
            this.btnSaveMarkup.Attributes.Add("onclick", "javascript:hideDiv();");
            this.btnMarkupRatesSave.Attributes.Add("onclick", "javascript:return false;");
            this.btnMarkupRatesCancel.Attributes.Add("onclick", "javascript:closebar('div_markup');return false;");
        }
    }
}