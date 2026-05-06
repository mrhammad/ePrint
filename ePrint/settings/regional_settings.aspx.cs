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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.settings
{
    public partial class regional_settings : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected Label lblcustomer;

        //protected DropDownList ddlLanguage;

        //protected HiddenField hid_LanguageID;

        //protected HiddenField hid_RegionalID;

        //protected Label lblDateFormate;

        //protected DropDownList ddlDateFormat;

        //protected HiddenField hid_Dateformat;

        //protected Label lblColour;

        //protected TextBox txtColour;

        //protected HiddenField hid_Colour;

        //protected Label lblOrganisation;

        //protected TextBox txtOrganisation;

        //protected HiddenField hid_Organisation;

        //protected Label lblState;

        //protected TextBox txtState;

        //protected HiddenField hid_State;

        //protected Label lblCentre;

        //protected TextBox txtCentre;

        //protected HiddenField hid_Centre;

        //protected Label lblZipCode;

        //protected TextBox txtPostcode;

        //protected HiddenField hid_ZipCode;

        //protected Label lblMetre;

        //protected TextBox txtMetre;

        //protected HiddenField hid_Metre;

        //protected Label lblWeight;

        //protected TextBox txtWeight;

        //protected HiddenField hid_Weight;

        //protected Label lblGeneralWeight;

        //protected TextBox txtGeneralWeight;

        //protected HiddenField hdngeneralweight;

        //protected Label lblPaperMeasure;

        //protected TextBox txtPaper;

        //protected DropDownList ddlPaperMeasure;

        //protected HiddenField hid_PaperMeasure;

        //protected HtmlGenericControl div_PaperMeasure;

        //protected Label lblOrganisation5;

        //protected TextBox txtPageTitle;

        //protected HiddenField hid_txtPageTitle;

        //protected Label lblColour0;

        //protected TextBox txtCompany;

        //protected HiddenField hid_CompanyTitle;

        //protected Label lblColour2;

        //protected DropDownList ddlTimeZone;

        //protected Label lblcostcentre;

        //protected CheckBox chkCostCentreDisplay;

        //protected HiddenField hdnFrom;

        //protected HiddenField hdnTo;

        //protected Label lblYear;

        //protected DropDownList ddlFromMonth;

        //protected DropDownList ddlToMonth;

        //protected RadButton btnCancel;

        //protected Button btnSave;

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private int CompanyID;

        private SettingsBasePage objSet = new SettingsBasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public commonClass commclass = new commonClass();

        private BaseClass objBase = new BaseClass();

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

        public int UserID;

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

        public regional_settings()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            if (this.chkCostCentreDisplay.Checked)
            {
                num = 1;
            }
            SettingsItem settingsItem = new SettingsItem()
            {
                RegionalID = Convert.ToInt32(this.hid_RegionalID.Value),
                CompanyID = this.CompanyID,
                LanguageID = Convert.ToInt32(this.ddlLanguage.SelectedValue),
                DateFormat = this.ddlDateFormat.SelectedValue,
                Colour = base.SpecialEncode(this.txtColour.Text),
                Organisation = base.SpecialEncode(this.txtOrganisation.Text),
                Centre = base.SpecialEncode(this.txtCentre.Text),
                State = base.SpecialEncode(this.txtState.Text),
                PostCode = base.SpecialEncode(this.txtPostcode.Text),
                Metre = base.SpecialEncode(this.txtMetre.Text),
                Weight = base.SpecialEncode(this.txtWeight.Text),
                GeneralWeight = base.SpecialEncode(this.txtGeneralWeight.Text),
                PaperMeasure = this.ddlPaperMeasure.SelectedValue,
                PageTitle = base.SpecialEncode(this.txtPageTitle.Text),
                CompanyTitle = base.SpecialEncode(this.txtCompany.Text),
                TimeZoneID = Convert.ToInt32(this.ddlTimeZone.SelectedValue),
                IsDisplayCostCentre = num,
                PaperMaterial = this.ddlPaperMaterial.SelectedValue,

            };
            int num1 = Convert.ToInt32(this.ddlFromMonth.SelectedValue);
            string empty = string.Empty;
            if (num1 != 1)
            {
                object obj = num1;
                DateTime dateTime = DateTime.Now.AddYears(-1);
                empty = string.Concat(obj, "/1/", dateTime.Year);
            }
            else
            {
                object obj1 = num1;
                DateTime now = DateTime.Now;
                empty = string.Concat(obj1, "/1/", now.Year);
            }
            settingsItem.fiscalfrom = Convert.ToDateTime(this.objBase.DateFormat_Return_As_MM_DD_YYYY("mm/dd/yyyy", empty));
            object num2 = Convert.ToInt32(this.ddlToMonth.SelectedValue);
            DateTime now1 = DateTime.Now;
            string str = string.Concat(num2, "/1/", now1.Year);
            settingsItem.fiscalto = Convert.ToDateTime(this.objBase.DateFormat_Return_As_MM_DD_YYYY("mm/dd/yyyy", str));
            int num3 = SettingsBasePage.settings_regionalsettings_insert(settingsItem);
            string empty1 = string.Empty;
            DateTime dateTime1 = new DateTime();
            DateTime dateTime2 = new DateTime();
            dateTime1 = settingsItem.fiscalfrom;
            dateTime2 = settingsItem.fiscalto;
            SettingsBasePage.settings_RegionalSettings_update(this.CompanyID, Convert.ToInt32(this.ddlLanguage.SelectedValue), base.SpecialEncode(this.ddlDateFormat.SelectedItem.Text), base.SpecialEncode(this.txtColour.Text), base.SpecialEncode(this.txtOrganisation.Text), base.SpecialEncode(this.txtState.Text), base.SpecialEncode(this.txtCentre.Text), base.SpecialEncode(this.txtPostcode.Text), base.SpecialEncode(this.txtMetre.Text), base.SpecialEncode(this.txtWeight.Text), base.SpecialEncode(this.txtGeneralWeight.Text), base.SpecialEncode(this.ddlPaperMeasure.Text), base.SpecialEncode(this.txtPageTitle.Text), base.SpecialEncode(this.txtCompany.Text), Convert.ToInt32(this.ddlTimeZone.SelectedValue), dateTime1, dateTime2, num, base.SpecialEncode(this.ddlPaperMaterial.Text));
            this.Session["DateFormat"] = this.objpage.GetRegionalSettings(this.CompanyID, "Dateformat");
            if (num3 > 0)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Regional_Settings_Updated_Successfully"), "msg-success", this.plhMessage);
            }
        }

        public string ChangeDateFormat(string DateFormat, string txtvalue)
        {
            string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
            if (Convert.ToInt32(strArrays[0].ToString()) > 12)
            {
                string[] str = new string[] { strArrays[2].ToString(), "/", strArrays[1].ToString(), "/", strArrays[0].ToString() };
                txtvalue = string.Concat(str);
            }
            else if (Convert.ToInt32(strArrays[1].ToString()) > 12)
            {
                string[] str1 = new string[] { strArrays[2].ToString(), "/", strArrays[0].ToString(), "/", strArrays[1].ToString() };
                txtvalue = string.Concat(str1);
            }
            else if (DateFormat == "dd/mm/yyyy")
            {
                string[] strArrays1 = new string[] { strArrays[2], "/", strArrays[1], "/", strArrays[0] };
                txtvalue = string.Concat(strArrays1);
            }
            else if (DateFormat == "mm/dd/yyyy")
            {
                string[] strArrays2 = new string[] { strArrays[2], "/", strArrays[1], "/", strArrays[0] };
                txtvalue = string.Concat(strArrays2);
            }
            return txtvalue;
        }

        protected void ddlDateFormat_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.div_PaperMeasure.Attributes.Add("style", "display:block");
            }
            else
            {
                this.div_PaperMeasure.Attributes.Add("style", "display:none");
            }
            if (!base.IsPostBack)
            {
                for (int i = 1; i <= 12; i++)
                {
                    ListItem listItem = new ListItem();
                    DateTime dateTime = new DateTime(1900, i, 1);
                    listItem.Text = dateTime.ToString("MMMM");
                    listItem.Value = i.ToString();
                    this.ddlFromMonth.Items.Add(listItem);
                }
                for (int j = 1; j <= 12; j++)
                {
                    ListItem str = new ListItem();
                    DateTime dateTime1 = new DateTime(1900, j, 1);
                    str.Text = dateTime1.ToString("MMMM");
                    str.Value = j.ToString();
                    this.ddlToMonth.Items.Add(str);
                }
            }
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();
            bool isPostBack = base.IsPostBack;
            this.btnSave.Attributes.Add("onclick", "javascript:var a=Validate();if(a)loadingimg('div_btnSave','div_btnsaveprocess');return a;");
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_btncancelprocess');");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.ddlLanguage.Focus();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Regional_Settings")));
            base.Title = this.objlang.convert(global.pageTitle("Regional Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Regional_Settings");
            if (!base.IsPostBack)
            {
                SqlCommand sqlCommand = new SqlCommand("crm_select_timezone", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                int num = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    this.ddlTimeZone.Items.Insert(num, row["timezone"].ToString());
                    this.ddlTimeZone.Items[num].Value = row["timezoneid"].ToString();
                    if (string.Compare(row["timezone"].ToString().Trim(), "GMT", true) == 0)
                    {
                        this.ddlTimeZone.SelectedIndex = num;
                    }
                    num++;
                }
                this.objSet.Bind_Language(this.ddlLanguage, this.CompanyID, "--- Select ---");
                this.lblcustomer.Text = this.objlang.GetLanguageConversion("Language");
                this.lblDateFormate.Text = this.objlang.GetLanguageConversion("Date_Format");
                this.lblColour.Text = this.objlang.GetLanguageConversion("Colour");
                this.lblOrganisation.Text = this.objlang.GetLanguageConversion("Organisation");
                this.lblState.Text = this.objlang.GetLanguageConversion("State");
                this.lblCentre.Text = this.objlang.GetLanguageConversion("Centre");
                this.lblZipCode.Text = this.objlang.GetLanguageConversion("Zip_Code");
                this.lblMetre.Text = this.objlang.GetLanguageConversion("Metre");
                this.lblWeight.Text = this.objlang.GetLanguageConversion("PaperWeight");
                this.lblGeneralWeight.Text = this.objlang.GetLanguageConversion("General_Weight");
                this.lblPaperMeasure.Text = this.objlang.GetLanguageConversion("Paper_Measure");
                this.lblOrganisation5.Text = this.objlang.GetLanguageConversion("Page_Title");
                this.lblColour0.Text = this.objlang.GetLanguageConversion("Company_Title");
                this.lblColour2.Text = this.objlang.GetLanguageConversion("Time_Zone");
                this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
                this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
                foreach (DataRow dataRow in SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows)
                {
                    if (!base.IsPostBack)
                    {
                        this.RegionalID = Convert.ToInt32(dataRow["RegionalID"].ToString());
                        this.hid_RegionalID.Value = dataRow["RegionalID"].ToString();
                        this.hid_LanguageID.Value = dataRow["LanguageID"].ToString();
                        this.hid_Dateformat.Value = dataRow["DateFormat"].ToString();
                        this.hid_Colour.Value = dataRow["Colour"].ToString();
                        this.hid_Organisation.Value = dataRow["Organisation"].ToString();
                        this.hid_State.Value = dataRow["State"].ToString();
                        this.hid_Centre.Value = dataRow["Centre"].ToString();
                        this.hid_ZipCode.Value = dataRow["PostCode"].ToString();
                        this.hid_Metre.Value = dataRow["Metre"].ToString();
                        this.hid_Weight.Value = dataRow["Weight"].ToString();
                        this.hdngeneralweight.Value = dataRow["GeneralWeight"].ToString();
                        this.hid_PaperMeasure.Value = dataRow["PaperMeasure"].ToString();
                        this.hid_txtPageTitle.Value = dataRow["PageTitle"].ToString();
                        this.hid_CompanyTitle.Value = dataRow["CompanyTitle"].ToString();
                        this.ddlLanguage.SelectedValue = dataRow["LanguageID"].ToString();
                        this.ddlDateFormat.SelectedValue = dataRow["DateFormat"].ToString();
                        this.txtColour.Text = base.SpecialDecode(dataRow["Colour"].ToString());
                        this.txtOrganisation.Text = base.SpecialDecode(dataRow["Organisation"].ToString());
                        this.txtState.Text = base.SpecialDecode(dataRow["State"].ToString());
                        this.txtCentre.Text = base.SpecialDecode(dataRow["Centre"].ToString());
                        this.txtPostcode.Text = base.SpecialDecode(dataRow["PostCode"].ToString());
                        this.txtMetre.Text = base.SpecialDecode(dataRow["Metre"].ToString());
                        this.txtWeight.Text = base.SpecialDecode(dataRow["Weight"].ToString());
                        this.txtGeneralWeight.Text = base.SpecialDecode(dataRow["GeneralWeight"].ToString());
                        this.ddlPaperMeasure.SelectedValue = dataRow["PaperMeasure"].ToString();
                        this.txtPageTitle.Text = base.SpecialDecode(dataRow["PageTitle"].ToString());
                        this.txtCompany.Text = base.SpecialDecode(dataRow["CompanyTitle"].ToString());
                        this.ddlTimeZone.SelectedValue = dataRow["TimeZoneID"].ToString();
                        this.hdnFrom.Value = this.commclass.Eprint_return_DateTime_Before_View(dataRow["FisCalFrom"].ToString(), this.CompanyID, this.UserID, true);
                        this.ddlPaperMaterial.SelectedValue = dataRow["PaperMaterial"].ToString();
                        this.hid_PaperMaterial.Value = dataRow["PaperMaterial"].ToString();

                        string str1 = dataRow["FisCalFrom"].ToString();
                        str1 = str1.Substring(0, 2);
                        str1 = str1.Replace("/", "");
                        str1 = str1.TrimStart(new Char[] { '0' });
                        this.hdnTo.Value = this.commclass.Eprint_return_DateTime_Before_View(dataRow["FisCalTo"].ToString(), this.CompanyID, this.UserID, true);
                        string str2 = dataRow["FisCalTo"].ToString();
                        str2 = str2.Substring(0, 2);
                        str2 = str2.Replace("/", "");
                        str2 = str2.TrimStart(new Char[] { '0' });
                        this.ddlFromMonth.SelectedValue = str1.ToString();
                        this.ddlToMonth.SelectedValue = str2.ToString();
                    }
                    if (!Convert.ToBoolean(dataRow["IsDisplayCostCentre"]))
                    {
                        this.chkCostCentreDisplay.Checked = false;
                    }
                    else
                    {
                        this.chkCostCentreDisplay.Checked = true;
                    }
                }
            }
        }
    }
}