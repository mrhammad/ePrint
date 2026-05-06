using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class ShipEngine_Sent_Settings : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private int CompanyID;

        private SettingsBasePage objSet = new SettingsBasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public int RegionalID;

        public int LanguageID;

        public string Colour = "Color";

        public string Organisation = "Organization";

        public string State = "State";

        public string Centre = "Center";

        public string ZipCode = "Zip Code";

        public string Metre = "Meter";

        public string Weight = "Weight";

        public string PaperMeasure = "PaperMeasure";

        public string License = "License";

        public string PageTitle = "PageTitle";

        public string CompanyTitle = "CompanyTitle";

        public string RegionalSettings = string.Empty;

        private BaseClass objBase = new BaseClass();

        public string DateFormat = string.Empty;

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

        public ShipEngine_Sent_Settings()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SettingsItem settingsItem = new SettingsItem()
            {
                CompanyID = this.CompanyID,
                Roundoff = Convert.ToInt32(this.ddlroundoff.SelectedValue)
            };
            this.Session["Roundoff"] = this.ddlroundoff.SelectedValue;
            string empty = string.Empty;
            empty = (this.ddlCompanyCountry.SelectedIndex != 0 ? this.ddlCompanyCountry.SelectedItem.Text : "");
            SettingsBasePage.shipengine_sent_settings_update(this.CompanyID, base.SpecialEncode(this.txtCompanyAddress1.Text), base.SpecialEncode(this.txtCompanyAddress2.Text), base.SpecialEncode(this.txtCity.Text), base.SpecialEncode(this.txtState.Text), base.SpecialEncode(this.txtCompanyPostalCode.Text), base.SpecialEncode(empty.ToString()), base.SpecialEncode(this.txtMaxWeight.Text), Convert.ToInt32(this.ddlCompanyCountry.SelectedValue), Convert.ToString(this.ddl_Currency.SelectedValue));
            this.Session["Roundoff"] = this.ddlroundoff.SelectedValue;
            base.Message_Display(this.objlang.GetLanguageConversion("Record_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSave.Attributes.Add("onclick", "javascript:var a=Validate();if(a)loadingimg('div_btnSave','div_btnsaveprocess');return a;");
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_btncancelprocess');");
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.txtFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.txtTo.Attributes.Add("onclick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("ShipEngine_Sent_Settings")));
            base.Title = this.objLanguage.convert(global.pageTitle("ShipEngine Sent Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("ShipEngine_Sent_Settings");
            if (!base.IsPostBack)
            {
                SqlCommand sqlCommand = new SqlCommand("crm_select_timezone", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                (new DataTable()).Load(sqlDataReader);
                this.objComp.company_country_select(this.ddlCompanyCountry);
                SqlCommand sqlCommand1 = new SqlCommand("[crm_select_currency_country2]", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader1);
                
                this.ddl_Currency.Items.Insert(0, "--Select--");
                this.ddl_Currency.Items[0].Value = "0";
                this.ddl_Currency.Items.Insert(1, new ListItem("kgs", "kgs"));
                this.ddl_Currency.Items.Insert(2, new ListItem("lbs", "lbs"));
                

                this.lblCompanyAddress1.Text = this.objlang.GetLanguageConversion("Company_Address1");
                this.lblCompanyAddress2.Text = this.objlang.GetLanguageConversion("Company_Address2");
                this.lblCompanyAddress4.Text = this.objlang.GetLanguageConversion("Postal_Code");
                this.lblCity.Text = this.objlang.GetLanguageConversion("City");
                this.lblState.Text = this.objlang.GetLanguageConversion("State");
                this.lblCompanyCountry.Text = this.objlang.GetLanguageConversion("Country");
                this.lblMaxWeight.Text = this.objlang.GetLanguageConversion("Maximum_Box_Weight");
                this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
                this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
                this.lblweight.Text = this.objlang.GetLanguageConversion("Weight");
            Label0:
                foreach (DataRow dataRow in SettingsBasePage.shipengine_sent_settings_select(this.CompanyID).Rows)
                {
                    this.txtCompanyAddress1.Text = dataRow["AddressLine1"].ToString();
                    this.txtCompanyAddress2.Text = dataRow["AddressLine2"].ToString();
                    this.txtCompanyPostalCode.Text = dataRow["PostalCode"].ToString();
                    this.txtCity.Text = dataRow["City"].ToString();
                    this.txtState.Text = dataRow["State"].ToString();
                    this.ddlCompanyCountry.SelectedValue = dataRow["CountryID"].ToString();
                    this.txtMaxWeight.Text = dataRow["MaxWeight"].ToString();
                    this.ddl_Currency.SelectedValue = Convert.ToString(dataRow["Weight"]);
                    
                    for (int i = 0; i < this.ddl_Currency.Items.Count; i++)
                    {
                        if (this.ddl_Currency.Items[i].Text.Trim() == Convert.ToString(dataRow["Weight"]).Trim())
                        {
                            this.ddl_Currency.SelectedValue = this.ddl_Currency.Items[i].Value;
                            break;
                        }
                    }
                }
            }
            this.lbl1.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address1");
            this.lbl2.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address2");
            this.lbl3.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address3");
            this.lbl4.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address4");
            this.lbl5.Text = this.objlang.GetLanguageConversion("Please_Enter_Address");
            this.lbl6.Text = this.objlang.GetLanguageConversion("Please_enter_Company_Country");
            this.lbl7.Text = this.objlang.GetLanguageConversion("Please_Enter_Quantity");
        }
    }
}