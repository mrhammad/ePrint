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

namespace ePrint.settings
{
    public partial class Company_profile : BaseClass, IRequiresSessionState
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

        public Company_profile()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
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
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            dateTime = (this.txtFrom.Text == "" ? Convert.ToDateTime("07/01/2012") : Convert.ToDateTime(this.objBase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtFrom.Text)));
            dateTime1 = (this.txtTo.Text == "" ? Convert.ToDateTime("06/30/2013") : Convert.ToDateTime(this.objBase.DateFormat_Return_As_MM_DD_YYYY(this.DateFormat, this.txtTo.Text)));
            SettingsBasePage.settings_companyprofile_update(this.CompanyID, base.SpecialEncode(this.txtCompanyName.Text), base.SpecialEncode(this.txtCompanyAddress1.Text), base.SpecialEncode(this.txtCompanyAddress2.Text), base.SpecialEncode(this.txtCompanyAddress3.Text), base.SpecialEncode(this.txtCompanyPostalCode.Text), base.SpecialEncode(empty.ToString()), base.SpecialEncode(this.txtCompanyPhone.Text), base.SpecialEncode(this.txtCompanyFax.Text), base.SpecialEncode(this.txtCompanyurl.Text), base.SpecialEncode(this.txtCompanyNumber.Text), base.SpecialEncode(this.txtTaxNumber.Text), Convert.ToInt32(this.ddlCompanyCountry.SelectedValue), base.SpecialEncode(this.txtCompanyEmail.Text), dateTime, dateTime1, Convert.ToString(this.ddl_Currency.SelectedValue));
            this.Session["Roundoff"] = this.ddlroundoff.SelectedValue;
            base.Message_Display(this.objlang.GetLanguageConversion("Company_Profile_updated_successfully"), "msg-success", this.plhMessage);
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
            this.txtCompanyName.Focus();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Company_Profile")));
            base.Title = this.objLanguage.convert(global.pageTitle("Company Profile", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Company_Profile");
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
                int str = 1;
                this.ddl_Currency.Items.Insert(0, "--Select--");
                this.ddl_Currency.Items[0].Value = "0";
                foreach (DataRow row in dataTable.Rows)
                {
                    this.ddl_Currency.Items.Insert(str, row["currencycode"].ToString());
                    this.ddl_Currency.Items[str].Value = row["countryID"].ToString();
                    str++;
                }
                this.lblCompanyName.Text = this.objlang.GetLanguageConversion("Company_Name");
                this.lblCompanyAddress1.Text = this.objlang.GetLanguageConversion("Company_Address1");
                this.lblCompanyAddress2.Text = this.objlang.GetLanguageConversion("Company_Address2");
                this.lblCompanyAddress3.Text = this.objlang.GetLanguageConversion("Company_Address3");
                this.lblCompanyAddress4.Text = this.objlang.GetLanguageConversion("Company_Address4");
                this.lblCompanyCountry.Text = this.objlang.GetLanguageConversion("Company_Country");
                this.lblCompanyPhone.Text = this.objlang.GetLanguageConversion("Company_Telephone");
                this.lblCompanyFax.Text = this.objlang.GetLanguageConversion("Company_Fax");
                this.lblCompanyEmail.Text = this.objlang.GetLanguageConversion("Company_Email");
                this.lblCompanyURL.Text = this.objlang.GetLanguageConversion("Company_URL");
                this.lblCompanyNumber.Text = this.objlang.GetLanguageConversion("Company_Number");
                this.lblTaxNumber.Text = this.objlang.GetLanguageConversion("Tax_Number");
                this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
                this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
                this.lblcurrency.Text = this.objlang.GetLanguageConversion("Currency");
            Label0:
                foreach (DataRow dataRow in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                {
                    
                    this.txtCompanyName.Text = dataRow["CompanyName"].ToString();
                    this.txtCompanyAddress1.Text = dataRow["AddressLine1"].ToString();
                    this.txtCompanyAddress2.Text = dataRow["AddressLine2"].ToString();
                    this.txtCompanyAddress3.Text = dataRow["AddressLine3"].ToString();
                    this.txtCompanyPostalCode.Text = dataRow["PostalCode"].ToString();
                    this.ddlCompanyCountry.SelectedValue = dataRow["CountryID"].ToString();
                    this.txtCompanyPhone.Text = dataRow["Telephone"].ToString();
                    this.txtCompanyFax.Text = dataRow["Fax"].ToString();
                    this.txtCompanyEmail.Text = dataRow["Email"].ToString();
                    this.txtCompanyurl.Text = dataRow["URL"].ToString();
                    this.txtCompanyNumber.Text = dataRow["CompanyNumber"].ToString();
                    this.txtTaxNumber.Text = dataRow["TaxNumber"].ToString();
                    TextBox textBox = this.txtFrom;
                    DateTime dateTime = Convert.ToDateTime(dataRow["FisCalFrom"].ToString());
                    textBox.Text = dateTime.ToString(this.DateFormat.Replace('m', 'M'));
                    TextBox str1 = this.txtTo;
                    DateTime dateTime1 = Convert.ToDateTime(dataRow["FisCalTo"].ToString());
                    str1.Text = dateTime1.ToString(this.DateFormat.Replace('m', 'M'));
                    this.ddl_Currency.SelectedValue = Convert.ToString(dataRow["currencycode"]);
                    //Below code commented by KR [01-06-2017]
                    /*int num = 0;
                    while (num < this.ddl_Currency.Items.Count)
                    {
                        //if (this.ddl_Currency.Items[num].Text != Convert.ToString(dataRow["currencycode"]))
                        if (this.ddl_Currency.Items[num].Text != Convert.ToString(dataRow["currencycode"]))
                        {
                            num++;
                        }
                        else
                        {
                            this.Session["CurrencySymbol"] = Convert.ToString(dataRow["CurrencySymbol"]);
                            this.ddl_Currency.SelectedIndex = num;
                            goto Label0;
                        }
                    }*/

                    //Code below by KR [01-06-2017]
                    for (int i = 0; i < this.ddl_Currency.Items.Count; i++)
                    {
                        if (this.ddl_Currency.Items[i].Text.Trim() == Convert.ToString(dataRow["currencycode"]).Trim())
                        {
                            this.ddl_Currency.SelectedValue = this.ddl_Currency.Items[i].Value;
                            this.Session["CurrencySymbol"] = Convert.ToString(dataRow["CurrencySymbol"]).Trim();
                            break;
                        }
                    }
                }
            }
            this.lbl1.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Name");
            this.lbl2.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address1");
            this.lbl3.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address2");
            this.lbl4.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address3");
            this.lbl5.Text = this.objlang.GetLanguageConversion("Please_Enter_Company_Address4");
            this.lbl6.Text = this.objlang.GetLanguageConversion("Please_enter_Company_Country");
            this.lbl7.Text = this.objlang.GetLanguageConversion("Please_enter_Company_Telephone");
            this.lbl8.Text = this.objlang.GetLanguageConversion("Please_enter_Company_Fax");
            this.lbl9.Text = this.objlang.GetLanguageConversion("Please_Enter_Valid_Email");
            this.lbl10.Text = this.objlang.GetLanguageConversion("Please_enter_Company_URL");
            this.lbl11.Text = this.objlang.GetLanguageConversion("Please_enter_Company_Number");
            this.lbl12.Text = this.objlang.GetLanguageConversion("Please_enter_Tax_Number");
        }
    }
}