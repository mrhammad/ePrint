using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.settings
{
    public partial class plantpresses_largeformat : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private InventoryBasePage objInv = new InventoryBasePage();

        public commonClass comm = new commonClass();

        public int CompanyID;

        public int UserID;

        public long PressID;

        public string Action = "add";

        private string paperlength = "";

        public string paperType = string.Empty;

        public string PaperMeasure = string.Empty;

        public string Weight = string.Empty;

        public bool Do_Guillotine_New_Cal;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public bool UnitOfMeasureKey;

        public string InkToPress_Validation = string.Empty;

        public string LargeFormatClaculation = string.Empty;

        public string White_Ink = string.Empty;

        public string WhiteInkToPress_Validation = string.Empty;

        public int ItemsCounter;

        public decimal BlackMatrixStartRange;

        public decimal BlackMatrixEndRange;

        public decimal BlackCostPrefill;

        public decimal MarkUp;

        public commonClass objcom = new commonClass();

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

        public plantpresses_largeformat()
        {
        }

        protected void btndelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.Settings_LargeFormate_Delete(this.CompanyID, this.PressID);
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/large_format_view.aspx?action=delete"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            decimal num = this.MakeNullToDecimal(this.txtSpoilage.Text);
            decimal num1 = this.MakeNullToDecimal(this.txtRunningSpoilage.Text);
            decimal num2 = this.MakeNullToDecimal(this.txtSetupCharge.Text);
            decimal num3 = this.MakeNullToDecimal(this.txtMinimumRunningCharge.Text);
            decimal num4 = this.MakeNullToDecimal(this.txtMarkup.Text);
            decimal num5 = this.MakeNullToDecimal(this.txtPressHourlyCharge.Text);
            decimal num6 = this.MakeNullToDecimal(this.txtInkCoverageSide1.Text);
            decimal num7 = this.MakeNullToDecimal(this.txtInkCoverageSide2.Text);
            decimal num8 = this.MakeNullToDecimal(this.txtMinimumWebWidth.Text);
            decimal num9 = this.MakeNullToDecimal(this.txtMaximumWebWidth.Text);
            decimal num10 = this.MakeNullToDecimal(this.txtMaximumSheetWeight.Text);
            decimal num11 = this.MakeNullToDecimal(this.txtGripDepth.Text);
            decimal num12 = this.MakeNullToDecimal(this.txtSideGutterDepth.Text);
            int num13 = Convert.ToInt32(this.hdnpaper1.Value);
            decimal num14 = this.MakeNullToDecimal(this.txtPrintPerHourLow.Text);
            decimal num15 = this.MakeNullToDecimal(this.txtPrintPerHourMedium.Text);
            decimal num16 = this.MakeNullToDecimal(this.txtPrintPerHourHigh.Text);
            decimal num17 = this.MakeNullToDecimal(this.txtPrintImageHeight.Text);
            decimal num18 = this.MakeNullToDecimal(this.txtPrintImageWidth.Text);
            decimal num19 = this.MakeNullToDecimal(this.txtGutterHorizontal.Text);
            decimal num20 = this.MakeNullToDecimal(this.txtGutterVertical.Text);
            decimal num21 = this.MakeNullToDecimal(this.txtWhiteInkCoverageSide1.Text);
            decimal num22 = this.MakeNullToDecimal(this.txtWhiteInkCoverageSide2.Text);
            decimal num25 = this.MakeNullToDecimal(this.txtSpoilage1.Text);

            if (string.Compare(this.Action, "add", true) == 0)
            {
                long num23 = SettingsBasePage.Settings_LargeFormate_Insert(this.CompanyID, base.SpecialEncode(this.txtLargeFormatName.Text), base.SpecialEncode(this.txtDescription.Text), num8, num9, num10, this.ddlGripSideOrientation.SelectedValue.ToString(), num11, num12, "sheet", num, "meters", num1, num13, Convert.ToInt32(this.ddlPrintSheetSize.SelectedValue.ToString()), Convert.ToInt32(this.ddlJobSize.SelectedValue.ToString()), Convert.ToInt32(this.ddlGuillotine.SelectedValue.ToString()), this.chkIsPerfecting.Checked, num2, num3, num4, num14, num15, num16, num5, num6, num7, this.chkDefaultPress.Checked, num17, num18, num19, num20, this.YieldMatrix_Value.Value, this.objpage.MakeNullToInteger(this.txtUnitOfMeasure.Text), Convert.ToInt64(this.hdnpaper2.Value), Convert.ToInt64(this.hdnpaper3.Value), Convert.ToInt64(this.hdnpaper4.Value), Convert.ToInt64(this.hdnpaper5.Value), num21, num22, this.chkTotalSheets.Checked,this.ddlMethod.SelectedValue,num25);
                if (num23 > 0)
                {
                    saveLargeFormatChargeZone(num23);
                }
                if (num23 == (long)-1)
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("PressName_Duplicate_Message"), "warningMsg", this.plhMessage);
                    return;
                }
                if (this.AccountingCode == "d")
                {
                    SettingsBasePage.LargeFormatPress_AccountingCode_Insert((long)this.CompanyID, num23, int.Parse(this.ddlAccountCode.SelectedValue));
                }
                this.hdnvalue.Value.Split(new char[] { '\u005E' });
                string[] strArrays = this.hdnid.Value.Split(new char[] { '\u005E' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    SettingsBasePage.Settings_LargeFormate_Insert_ink_insert(this.CompanyID, num23, Convert.ToInt32(strArrays[i].ToString()), false);
                }
                string[] strArrays1 = this.hdnidforwhiteink.Value.Split(new char[] { '\u005E' });
                for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                {
                    SettingsBasePage.Settings_LargeFormate_Insert_ink_insert(this.CompanyID, num23, Convert.ToInt32(strArrays1[j].ToString()), true);
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "settings/large_format_view.aspx?action=add"));
                return;
            }
            int num24 = SettingsBasePage.Settings_LargeFormate_Update(this.CompanyID, this.PressID, base.SpecialEncode(this.txtLargeFormatName.Text), base.SpecialEncode(this.txtDescription.Text), num8, num9, num10, this.ddlGripSideOrientation.SelectedValue.ToString(), num11, num12, "sheet", num, num1, num13, Convert.ToInt32(this.ddlPrintSheetSize.SelectedValue.ToString()), Convert.ToInt32(this.ddlJobSize.SelectedValue.ToString()), Convert.ToInt32(this.ddlGuillotine.SelectedValue.ToString()), this.chkIsPerfecting.Checked, num2, num3, num4, num14, num15, num16, num5, num6, num7, this.chkDefaultPress.Checked, num17, num18, num19, num20, this.YieldMatrix_Value.Value, this.objpage.MakeNullToInteger(this.txtUnitOfMeasure.Text), Convert.ToInt64(this.hdnpaper2.Value), Convert.ToInt64(this.hdnpaper3.Value), Convert.ToInt64(this.hdnpaper4.Value), Convert.ToInt64(this.hdnpaper5.Value), num21, num22, this.chkTotalSheets.Checked,num25);
            if (num24 > 0)
            {
                saveLargeFormatChargeZone(this.PressID);
            }
            if (this.AccountingCode == "d")
            {
                SettingsBasePage.LargeFormatPress_AccountingCode_Insert((long)this.CompanyID, this.PressID, int.Parse(this.ddlAccountCode.SelectedValue));
            }
            if (num24 == -1)
            {
                this.objBase.Message_Display(this.objlang.GetLanguageConversion("PressName_Already_Exists"), "warningMsg", this.plhMessage);
                return;
            }
            this.hdnvalue.Value.Split(new char[] { '\u005E' });
            string[] strArrays2 = this.hdnid.Value.Split(new char[] { '\u005E' });
            SettingsBasePage.Settings_LargeFormate_update_ink_Delete(this.CompanyID, this.PressID, 0);
            for (int k = 0; k < (int)strArrays2.Length - 1; k++)
            {
                SettingsBasePage.Settings_LargeFormate_update_ink_update(this.CompanyID, this.PressID, Convert.ToInt32(strArrays2[k].ToString()), false);
            }
            string[] strArrays3 = this.hdnidforwhiteink.Value.Split(new char[] { '\u005E' });
            for (int l = 0; l < (int)strArrays3.Length - 1; l++)
            {
                SettingsBasePage.Settings_LargeFormate_update_ink_update(this.CompanyID, this.PressID, Convert.ToInt32(strArrays3[l].ToString()), true);
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/large_format_view.aspx?action=edit"));
        }

        protected void Button4_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/large_format_view.aspx"));
        }

        [WebMethod]
        public static int GetLargeFormat(string val)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = baseClass.SpecialEncode(strArrays[1]);
            string str2 = baseClass.SpecialEncode(strArrays[2]);
            long num = Convert.ToInt64(strArrays[3]);
            int num1 = SettingsBasePage.settings_plantpressduplicacy_check(Convert.ToInt32(str), str2, str1, num);
            return num1;
        }

        private decimal MakeNullToDecimal(string values)
        {
            return (string.IsNullOrEmpty(values) ? new decimal(0) : Convert.ToDecimal(values));
        }

        private int MakeNullToInteger(string values)
        {
            int num = 0;
            try
            {
                num = (string.IsNullOrEmpty(values) ? 0 : Convert.ToInt32(values));
            }
            catch
            {
            }
            return num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["userID"].ToString());
            this.Button4.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_Button4process');");
            this.Label18.Text = this.objLanguage.GetLanguageConversion("Name");
            this.Label10.Text = this.objLanguage.GetLanguageConversion("Description");
            this.lblAccountCode.Text = this.objLanguage.GetLanguageConversion("Accounting_Code");
            this.Label5.Text = this.objLanguage.GetLanguageConversion("Maximum_Sheet_Width");
            this.Label6.Text = this.objLanguage.GetLanguageConversion("Maximum_Sheet_Weight");
            this.Label10.Text = this.objLanguage.GetLanguageConversion("Description");
            this.Label20.Text = this.objLanguage.GetLanguageConversion("Grip_Side_Orientation");
            this.ddlGripSideOrientation.Items[0].Text = this.objlang.GetLanguageConversion("None");
            this.ddlGripSideOrientation.Items[1].Text = this.objLanguage.GetLanguageConversion("Long_Side");
            this.ddlGripSideOrientation.Items[2].Text = this.objlang.GetLanguageConversion("Short_Side");
            this.Label21.Text = this.objLanguage.GetLanguageConversion("Grip_Depth");
            this.Label23.Text = this.objLanguage.GetLanguageConversion("Side_Gutter_Depth");
            this.btnMarkupRatesCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnMarkupRatesSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.Label13.Text = this.objLanguage.GetLanguageConversion("SetUp_Spoilage");
            this.Label16.Text = string.Concat(this.objLanguage.GetLanguageConversion("Running_Spoilage"), " (%)");
            this.Label25.Text = this.objLanguage.GetLanguageConversion("Default_Material1");
            this.Label4.Text = this.objLanguage.GetLanguageConversion("Default_Material2");
            this.Label8.Text = this.objLanguage.GetLanguageConversion("Default_Material3");
            this.Label11.Text = this.objLanguage.GetLanguageConversion("Default_Material4");
            this.Label14.Text = this.objLanguage.GetLanguageConversion("Default_Material5");
            this.Label46.Text = this.objLanguage.GetLanguageConversion("Default_Print_Sheet_Size");
            this.Label9.Text = this.objLanguage.GetLanguageConversion("Default_Job_Size");
            this.Label2.Text = this.objLanguage.GetLanguageConversion("Default_Cutting_Table");
            this.Label12.Text = this.objlang.GetValueOnLang("Can press do Perfecting?");
            this.Button4.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.Button5.Text = this.objLanguage.GetLanguageConversion("Next");
            this.Label3.Text = this.objlang.GetLanguageConversion("Print_Quality");
            this.lblInk.Text = this.objlang.GetLanguageConversion("Ink1");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btn_save.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btndelete.Text = this.objLanguage.GetLanguageConversion("Delete");
            this.Label27.Text = this.objlang.GetLanguageConversion("Default_Ink_Coverage_Side_1");
            this.Label7.Text = this.objlang.GetLanguageConversion("Default_Ink_Coverage_Side_2");
            this.Button10.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.InkToPress_Validation = this.objlang.GetLanguageConversion("Please_Select_Ink");
            this.WhiteInkToPress_Validation = this.objlang.GetLanguageConversion("Please_Select_WhiteInk");
            this.White_Ink = this.objlang.GetLanguageConversion("WhiteInk");
            this.Do_Guillotine_New_Cal = Convert.ToBoolean(EprintConfigurationManager.AppSettings["Guillotine_New_Cal"]);
            this.PaperMeasure = base.SpecialDecode(this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure"));
            this.Weight = base.SpecialDecode(this.objpage.GetRegionalSettings(this.CompanyID, "Weight"));
            this.paperType = this.comm.settings_paperMeasurementType(this.CompanyID);
            if (ConnectionClass.LargeFormatCalculation != null)
            {
                this.LargeFormatClaculation = ConnectionClass.LargeFormatCalculation;
            }
            if (this.PaperMeasure.ToLower() != "in.")
            {
                this.spnSpoilageType1.InnerText = "Sq.mtr";
                this.spnSpoilageType.InnerText = "mm";
                this.spnPrinting.InnerText = this.objLanguage.GetLanguageConversion("How_many_Square_Meter_can_you_print_per_hour");
            }
            else
            {
                this.spnPrinting.InnerText = this.objlang.GetLanguageConversion("How_many_metres_can_you_print_per_hour");
                this.spnSpoilageType1.InnerText = "Sq.Ft";
                this.spnSpoilageType.InnerText = "in";

            }
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            this.gloobj.setpagename("setting");
            bool unitOfMeasure = ConnectionClass.UnitOfMeasure;
            this.UnitOfMeasureKey = Convert.ToBoolean(ConnectionClass.UnitOfMeasure);
            if (!this.UnitOfMeasureKey)
            {
                this.div_UnitOfMeasure.Style.Add("display", "none");
            }
            else
            {
                this.div_UnitOfMeasure.Style.Add("display", "block");
            }
            this.btn_save.Attributes.Add("onclick", "javascript:var a=CheckSave();if(a!=false)loadingimage(this.id,'div_btnsaveprocess');return a;");
            this.txtLargeFormatName.Focus();
            this.txtGripDepth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtGripDepth.Text.ToString()), 0, "", false, false, true);
            this.txtSideGutterDepth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtSideGutterDepth.Text.ToString()), 0, "", false, false, true);
            this.txtRunningSpoilage.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtRunningSpoilage.Text.ToString()), 0, "", false, false, true);
            this.txtSetupCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtSetupCharge.Text.ToString()), 0, "", false, false, true);
            this.txtMinimumRunningCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMinimumRunningCharge.Text.ToString()), 0, "", false, false, true);
            this.txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMarkup.Text.ToString()), 0, "", false, false, true);
            this.txtPressHourlyCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtPressHourlyCharge.Text.ToString()), 0, "", false, false, true);
            if (!base.IsPostBack)
            {
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Style.Add("display", "none");
                }
                else
                {
                    this.div_AccountCode.Style.Add("display", "none");
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, "--- Select ---");
                }
            }
            try
            {
                this.PressID = Convert.ToInt64(base.Request.Params["pressid"].ToString());
                this.Action = base.Request.Params["action"].ToString();
                if (this.Action == "edit")
                {
                    this.btndelete.Visible = true;
                }
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                SettingsBasePage settingsBasePage = new SettingsBasePage();
                settingsBasePage.Bind_PaperSize(this.ddlPrintSheetSize, Convert.ToInt32(this.Session["companyId"].ToString()), string.Concat("---", this.objLanguage.GetLanguageConversion("select"), "---"));
                settingsBasePage.Bind_PaperSize(this.ddlJobSize, Convert.ToInt32(this.Session["companyId"].ToString()), string.Concat("---", this.objLanguage.GetLanguageConversion("select"), "---"));
                if (!this.Do_Guillotine_New_Cal)
                {
                    SettingsBasePage.Guillotine_Bind(this.ddlGuillotine, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("select"), "---"));
                }
                else
                {
                    SettingsBasePage.Guillotine_Bind_For_Large(this.ddlGuillotine, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("select"), "---"));
                }
                if (this.Action != "edit")
                {
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/large_format_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Large_Format"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Large_Format_Add")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Large Format Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Large_Format_Add");
                    DataSet dataSet = InventoryBasePage.warehouse_inventory_selectLargeFormat(this.CompanyID, "paper", "");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        string str2 = dataSet.Tables[0].Rows[0].Table.Rows[0].ItemArray[3].ToString();
                        this.spnpaper1.InnerHtml = str2;
                        this.spnpaper1.Attributes.Add("title", str2);
                        string str3 = dataSet.Tables[0].Rows[0].Table.Rows[0].ItemArray[0].ToString();
                        this.hdnpaper1.Value = str3;
                    }
                }
                else
                {
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/large_format_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Large_Format"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Large_Format_Edit")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Large Format Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Large_Format_Edit");
                    try
                    {
                        if (this.AccountingCode != "d")
                        {
                            this.div_AccountCode.Style.Add("display", "none");
                        }
                        else
                        {
                            this.div_AccountCode.Style.Add("display", "none");
                            DropDownList dropDownList = this.ddlAccountCode;
                            int num = SettingsBasePage.LargeFormatPress_AccountingCode_Select((long)this.CompanyID, this.PressID);
                            dropDownList.SelectedValue = num.ToString();
                            this.hdnAccountCode.Value = this.ddlAccountCode.SelectedValue;
                        }
                    }
                    catch
                    {
                    }
                    IDataReader dataReader = SettingsBasePage.Settings_LargeFormate_Select(this.CompanyID, this.PressID);
                    while (dataReader.Read())
                    {
                        this.txtLargeFormatName.Text = base.SpecialDecode(dataReader["PressName"].ToString());
                        this.txtDescription.Text = base.SpecialDecode(dataReader["Description"].ToString());
                        this.chkDefaultPress.Checked = Convert.ToBoolean(dataReader["IsDefaultPress"].ToString());
                        this.chkTotalSheets.Checked = Convert.ToBoolean(dataReader["isFullSheet"].ToString());
                        this.txtMinimumWebWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["MinWebWIdth"].ToString()), 0, "", false, false, false);
                        this.txtMaximumWebWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["MaxWebWidth"].ToString()), 0, "", false, false, false);
                        this.txtMaximumSheetWeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["MaxSheetWeight"].ToString()), 0, "", false, false, false);
                        this.txtGripDepth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["GripDepth"].ToString()), 0, "", false, false, false);
                        this.txtSideGutterDepth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["SideGutterDepth"].ToString()), 0, "", false, false, false);
                        this.txtSpoilage.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["SetUpSpoilage"].ToString()), 0, "", false, false, false);
                        this.txtSpoilage1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["SetUpSpoilage_Sqm"].ToString()), 0, "", false, false, false);
                        this.txtRunningSpoilage.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["RunningSpoilage"].ToString()), 0, "", false, false, false);
                        this.chkIsPerfecting.Checked = Convert.ToBoolean(dataReader["IsPerfecting"].ToString());
                        this.txtSetupCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["SetupCharge"].ToString()), 0, "", false, false, false);
                        this.txtMinimumRunningCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["MinRunningCharge"].ToString()), 0, "", false, false, false);
                        this.txtMarkup.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["MarkUp"].ToString()), 0, "", false, false, false);
                        this.txtPrintPerHourLow.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["PrintPerHourLow"].ToString()), 0, "", false, false, false);
                        this.txtPrintPerHourMedium.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["PrintPerHourMedium"].ToString()), 0, "", false, false, false);
                        this.txtPrintPerHourHigh.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["PrintPerHourHigh"].ToString()), 0, "", false, false, false);
                        this.txtPressHourlyCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["PerHourCharge"].ToString()), 0, "", false, false, false);
                        this.txtInkCoverageSide1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["CoverageSide1"].ToString()), 0, "", false, false, false);
                        this.txtInkCoverageSide2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["CoverageSide2"].ToString()), 0, "", false, false, false);
                        this.hdnpaper1.Value = dataReader["PaperSizeID"].ToString();
                        this.spnpaper1.InnerHtml = dataReader["Paper"].ToString();
                        this.spnpaper1.Attributes.Add("title", dataReader["Paper"].ToString());
                        this.txtWhiteInkCoverageSide1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["WhiteInkCoverageSide1"].ToString()), 0, "", false, false, false);
                        this.txtWhiteInkCoverageSide2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["WhiteInkCoverageSide2"].ToString()), 0, "", false, false, false);
                        this.hdnpaper2.Value = dataReader["Material2"].ToString();
                        if (dataReader["Paper2"].ToString() == "")
                        {
                            this.spnpaper2.InnerHtml = dataReader["Paper2"].ToString();
                        }
                        else
                        {
                            HtmlGenericControl htmlGenericControl = this.spnpaper2;
                            string[] strArrays1 = new string[] { dataReader["Paper2"].ToString(), "&nbsp;<img  id='img2' style='cursor:pointer' alt='Clear this ink' src='", this.strImagepath, "close.gif' onclick=\"javascript:clear_paper(this.id,'", dataReader["Paper2"].ToString(), "','2');\" />" };
                            htmlGenericControl.InnerHtml = string.Concat(strArrays1);
                        }
                        this.spnpaper2.Attributes.Add("title", dataReader["Paper2"].ToString());
                        this.hdnpaper3.Value = dataReader["Material3"].ToString();
                        if (dataReader["Paper3"].ToString() == "")
                        {
                            this.spnpaper3.InnerHtml = dataReader["Paper3"].ToString();
                        }
                        else
                        {
                            HtmlGenericControl htmlGenericControl1 = this.spnpaper3;
                            string[] strArrays2 = new string[] { dataReader["Paper3"].ToString(), "&nbsp;<img  id='img3' style='cursor:pointer' alt='Clear this ink' src='", this.strImagepath, "close.gif' onclick=\"javascript:clear_paper(this.id,'", dataReader["Paper3"].ToString(), "','3');\" />" };
                            htmlGenericControl1.InnerHtml = string.Concat(strArrays2);
                        }
                        this.spnpaper3.Attributes.Add("title", dataReader["Paper3"].ToString());
                        this.hdnpaper4.Value = dataReader["Material4"].ToString();
                        if (dataReader["Paper4"].ToString() == "")
                        {
                            this.spnpaper4.InnerHtml = dataReader["Paper4"].ToString();
                        }
                        else
                        {
                            HtmlGenericControl htmlGenericControl2 = this.spnpaper4;
                            string[] strArrays3 = new string[] { dataReader["Paper4"].ToString(), "&nbsp;<img  id='img4' style='cursor:pointer' alt='Clear this ink' src='", this.strImagepath, "close.gif' onclick=\"javascript:clear_paper(this.id,'", dataReader["Paper4"].ToString(), "','4');\" />" };
                            htmlGenericControl2.InnerHtml = string.Concat(strArrays3);
                        }
                        this.spnpaper4.Attributes.Add("title", dataReader["Paper4"].ToString());
                        this.hdnpaper5.Value = dataReader["Material5"].ToString();
                        if (dataReader["Paper5"].ToString() == "")
                        {
                            this.spnpaper5.InnerHtml = dataReader["Paper5"].ToString();
                        }
                        else
                        {
                            HtmlGenericControl htmlGenericControl3 = this.spnpaper5;
                            string[] str4 = new string[] { dataReader["Paper5"].ToString(), "&nbsp;<img  id='img5' style='cursor:pointer' alt='Clear this ink' src='", this.strImagepath, "close.gif' onclick=\"javascript:clear_paper(this.id,'", dataReader["Paper5"].ToString(), "','5');\" />" };
                            htmlGenericControl3.InnerHtml = string.Concat(str4);
                        }
                        this.spnpaper5.Attributes.Add("title", dataReader["Paper5"].ToString());
                        this.paperlength = dataReader["Paper"].ToString();
                        this.txtPrintImageHeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["PrintImageHeight"].ToString()), 0, "", false, false, false);
                        this.txtPrintImageWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["PrintImageWidth"].ToString()), 0, "", false, false, false);
                        this.txtGutterHorizontal.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["GutterHorizontal"].ToString()), 0, "", false, false, false);
                        this.txtGutterVertical.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataReader["GutterVertical"].ToString()), 0, "", false, false, false);
                        this.txtUnitOfMeasure.Text = dataReader["UnitOfMeasure"].ToString();
                        if (this.paperlength.Length >= 25)
                        {
                            this.paperlength = string.Concat(this.paperlength.Substring(0, 25), "...");
                        }
                        this.spnpaper1.InnerHtml = this.paperlength;
                        for (int i = 0; i < this.ddlGripSideOrientation.Items.Count; i++)
                        {
                            if (this.ddlGripSideOrientation.Items[i].Value == dataReader["GripSideOrientation"].ToString())
                            {
                                this.ddlGripSideOrientation.SelectedIndex = i;
                            }
                        }
                        for (int j = 0; j < this.ddlPrintSheetSize.Items.Count; j++)
                        {
                            if (this.ddlPrintSheetSize.Items[j].Value == dataReader["SheetSizeID"].ToString())
                            {
                                this.ddlPrintSheetSize.SelectedIndex = j;
                            }
                        }
                        for (int k = 0; k < this.ddlJobSize.Items.Count; k++)
                        {
                            if (this.ddlJobSize.Items[k].Value == dataReader["JobSizeID"].ToString())
                            {
                                this.ddlJobSize.SelectedIndex = k;
                            }
                        }
                        for (int l = 0; l < this.ddlGuillotine.Items.Count; l++)
                        {
                            if (this.ddlGuillotine.Items[l].Value == dataReader["GuillotineID"].ToString())
                            {
                                this.ddlGuillotine.SelectedIndex = l;
                            }
                        }

                        this.ddlMethod.Enabled = false;

                        if (dataReader["CalculationType"].ToString() == "timecosting")
                        {
                            ddlMethod.SelectedValue = dataReader["CalculationType"].ToString();
                            divNewMatrixCalculation.Style.Add("display", "block");
                            divHourlyChargeRate.Style.Add("display", "none");
                            div_Markup.Style.Add("display", "none");
                        }
                        else
                        {
                            ddlMethod.SelectedValue = dataReader["CalculationType"].ToString();
                            divNewMatrixCalculation.Style.Add("display", "none");
                            divHourlyChargeRate.Style.Add("display", "block");
                            div_Markup.Style.Add("display", "block");
                        }

                    }
                    dataReader.Dispose();
                    IDataReader dataReader1 = SettingsBasePage.Settings_LargeFormate_Insert_ink_update(this.CompanyID, this.PressID, false);
                    while (dataReader1.Read())
                    {
                        empty = string.Concat(empty, dataReader1["name"], "^");
                        str = string.Concat(str, dataReader1["InkID"], "^");
                    }
                    dataReader1.Dispose();
                    this.hdneditvalue.Value = empty;
                    this.hdneditid.Value = str;
                    IDataReader dataReader2 = SettingsBasePage.Settings_LargeFormate_Insert_ink_update(this.CompanyID, this.PressID, true);
                    while (dataReader2.Read())
                    {
                        empty1 = string.Concat(empty1, dataReader2["name"], "^");
                        str1 = string.Concat(str1, dataReader2["InkID"], "^");
                    }
                    dataReader2.Dispose();
                    this.hdneditvalueforwhiteink.Value = empty1;
                    this.hdneditidforwhiteink.Value = str1;
                }
            }
            this.btndelete.Attributes.Add("onclick", string.Concat("javascript:var a= window.confirm('Are you sure, you want to delete ", this.txtLargeFormatName.Text, " ?');if(a)loadingimage(this.id,'div_btndelprocess');return a;"));



            if (this.Action.ToLower() == "edit")
            {
                this.Load_Click_Charge_Zone();
            }
            else
            {

                this.ItemsCounter = 6;
                this.BlackMatrixStartRange = new decimal(1);
                this.BlackMatrixEndRange = new decimal(50);
                this.BlackCostPrefill = Convert.ToDecimal(100);
                this.MarkUp = Convert.ToDecimal(100);
                for (int i = 1; i <= this.ItemsCounter; i++)
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_Black_", i, "' style='float: left; width: 80%;'>")));
                    if (i != 1)
                    {
                        this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%;'><span>&nbsp;</span></div>"));
                    }
                    else
                    {
                        this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div style='float: left; width: 10%;'><span>&nbsp;", this.objLanguage.GetLanguageConversion("From"), "</span></div>")));
                    }
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%; text-align: right'>"));
                    ControlCollection controls = this.plhBlackZone.Controls;
                    object[] blackMatrixStartRange = new object[] { "<span id='spnBlackFrom", i, "'>", this.BlackMatrixStartRange, "</span>" };
                    controls.Add(new LiteralControl(string.Concat(blackMatrixStartRange)));
                    ControlCollection controlCollections = this.plhBlackZone.Controls;
                    object[] objArray = new object[] { "<input type='text' ID='txtBlackFrom", i, "' value=", this.BlackMatrixStartRange, " Style='display:none' />" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                    ControlCollection controls1 = this.plhBlackZone.Controls;
                    object[] objArray1 = new object[] { "<input type='hidden' ID='hid_BlackClickChargeZoneLookupID_", i, "' value=", 0, " Style='display:none' />" };
                    controls1.Add(new LiteralControl(string.Concat(objArray1)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 3%; text-align: center'>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<span id='spn_Black_dash_", i, "' >-</span>")));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                    ControlCollection controlCollections1 = this.plhBlackZone.Controls;
                    object[] blackMatrixEndRange = new object[] { "<input type='text' ID='txtBlackTo", i, "' value=", this.BlackMatrixEndRange, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='8' onblur=AllowNumber(this,this.value);checkNextCharge(this.value,", i, ",'black');CallonBlur(this.value,'spn_Black_", i, "'); />" };
                    controlCollections1.Add(new LiteralControl(string.Concat(blackMatrixEndRange)));
                    if (i == this.ItemsCounter)
                    {
                        this.plhBlackZone.Controls.Add(new LiteralControl("&nbsp;"));
                    }
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    //this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                    //ControlCollection controls2 = this.plhBlackZone.Controls;
                    //object[] objArray2 = new object[] { "<input type='text' ID='txtBlackChargableSheets", i, "' value=", 1, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", i, "'); />" };
                    //controls2.Add(new LiteralControl(string.Concat(objArray2)));
                    //this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                    ControlCollection controlCollections2 = this.plhBlackZone.Controls;
                    object[] blackCostPrefill = new object[] { "<input type='text' ID='txtBlackCost", i, "' value=", this.BlackCostPrefill, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px;'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", i, "');Calculate_BlackChargeableRate(this.value,", i, ",'cost'); />" };
                    controlCollections2.Add(new LiteralControl(string.Concat(blackCostPrefill)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                    if (i != 1)
                    {
                        ControlCollection controls3 = this.plhBlackZone.Controls;
                        object[] objArray3 = new object[] { "<input type='text' ID='txtBlackMarkup", i, "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_BlackChargeableRate(this.value,", i, ",'markup'); />" };
                        controls3.Add(new LiteralControl(string.Concat(objArray3)));
                    }
                    else
                    {
                        this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<input type='text' ID='txtBlackMarkup", i, "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);SetBlackMarkupToAll(this); />")));
                    }
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 12%;'>"));
                    ControlCollection controlCollections3 = this.plhBlackZone.Controls;
                    object[] blackCostPrefill1 = new object[] { "<input type='text' ID='txtBlackChargableRate", i, "' value=", this.BlackCostPrefill, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", i, "');Calculate_BlackMarkup(this.value,", i, "); />" };
                    controlCollections3.Add(new LiteralControl(string.Concat(blackCostPrefill1)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div>"));
                    ControlCollection controls4 = this.plhBlackZone.Controls;
                    object[] valueOnLang = new object[] { "<span id='spn_Black_", i, "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>", this.objlang.GetValueOnLang("Please enter numeric value"), "</span>" };
                    controls4.Add(new LiteralControl(string.Concat(valueOnLang)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    
                    if (i != this.ItemsCounter)
                    {
                        this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", i, "' style='float: left;display:none'>")));
                        ControlCollection controlCollections8 = this.plhBlackZone.Controls;
                        object[] objArray7 = new object[] { "<img id='imgDeleterow_", i, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", i, ");'/>" };
                        controlCollections8.Add(new LiteralControl(string.Concat(objArray7)));
                        this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", i, "' style='float: left;'>")));
                        ControlCollection controls9 = this.plhBlackZone.Controls;
                        object[] objArray8 = new object[] { "<img id='imgDeleterow_", i, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", i, ");'/>" };
                        controls9.Add(new LiteralControl(string.Concat(objArray8)));
                        this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                    //this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));

                    if (i >= 3)
                    {
                        this.BlackMatrixStartRange = this.BlackMatrixStartRange + new decimal(100);
                    }
                    else
                    {
                        this.BlackMatrixStartRange = this.BlackMatrixStartRange + new decimal(50);
                    }
                    if (i != 1)
                    {
                        this.BlackMatrixEndRange = this.BlackMatrixEndRange + new decimal(100);
                    }
                    else
                    {
                        this.BlackMatrixEndRange = this.BlackMatrixEndRange + new decimal(50);
                    }
                    //if (i < 12)
                    //{
                    //    this.BlackCostPrefill = this.BlackCostPrefill - Convert.ToDecimal(10);
                    //}

                }
                this.BlackMatrixStartRange = this.BlackMatrixStartRange - new decimal(100);
                //this.ColourMatrixStartRange = this.ColourMatrixStartRange - new decimal(100);
                this.BlackMatrixEndRange = this.BlackMatrixEndRange - new decimal(100);
                //this.ColourMatrixEndRange = this.ColourMatrixEndRange - new decimal(100);
                this.hdnTotalrowscount.Value = this.ItemsCounter.ToString();
            }

            

        }


        private void saveLargeFormatChargeZone(Int64 num1)
        {

            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = this.hdn_ClickChargeZoneLookupBlack.Value.ToString().Split(new char[] { '$' });
            for (int i = 0; i < Convert.ToInt32((int)strArrays.Length); i++)
            {
                string[] strArrays2 = strArrays[i].Split(new char[] { '~' });

                if (strArrays2.Length > 1)
                {

                    if (string.Compare(this.Action, "edit", true) == 0)
                    {
                        if (Convert.ToInt64(strArrays2[6]) != (long)0)
                        {
                            stringBuilder.Append(" Update  TABLE_NAME ");
                            stringBuilder.AppendFormat(" Set ZoneFrom={0}, ", this.objpage.MakeNullToDecimal(strArrays2[0]));
                            stringBuilder.AppendFormat(" ZoneTo={0}, ", this.objpage.MakeNullToDecimal(strArrays2[1]));
                            stringBuilder.AppendFormat(" HourlyCost={0}, ", this.objpage.MakeNullToDecimal(strArrays2[3]));
                            stringBuilder.AppendFormat(" HourlyChargeableRate={0}, ", this.objpage.MakeNullToDecimal(strArrays2[4]));
                            stringBuilder.AppendFormat(" Markup={0}, ", this.objpage.MakeNullToDecimal(strArrays2[5]));
                            stringBuilder.AppendFormat(" IsDeleted=0 ", new object[0]);
                            stringBuilder.AppendFormat(" Where LargeFormatPressID={0} ", num1);
                            stringBuilder.AppendFormat(" AND LargeFormatChargeZoneID={0}; ", Convert.ToInt64(strArrays2[6]));
                        }
                        else
                        {
                            stringBuilder.Append("Insert into  TABLE_NAME");
                            stringBuilder.Append(" (");
                            stringBuilder.Append("LargeFormatPressID,ZoneFrom,ZoneTo,HourlyCost,Markup,HourlyChargeableRate,IsDeleted,CreatedDate");
                            stringBuilder.Append(" )");
                            stringBuilder.Append("values ");
                            stringBuilder.Append("(");
                            object[] objArray = new object[] { num1, ",", this.objpage.MakeNullToDecimal(strArrays2[0]), ",", this.objpage.MakeNullToDecimal(strArrays2[1]), "," };
                            stringBuilder.Append(string.Concat(objArray));
                            object[] objArray1 = new object[] { " ", this.objpage.MakeNullToDecimal(strArrays2[3]), ",", this.objpage.MakeNullToDecimal(strArrays2[5]), "," };
                            stringBuilder.Append(string.Concat(objArray1));
                            stringBuilder.Append(string.Concat(this.objpage.MakeNullToDecimal(strArrays2[4]), ", 0", ",", DateTime.Now.ToShortDateString()));
                            stringBuilder.Append(");");
                        }

                    }
                    else
                    {
                        stringBuilder.Append("Insert into  TABLE_NAME");
                        stringBuilder.Append(" (");
                        stringBuilder.Append("LargeFormatPressID,ZoneFrom,ZoneTo,HourlyCost,Markup,HourlyChargeableRate,IsDeleted,CreatedDate");
                        stringBuilder.Append(" )");
                        stringBuilder.Append("values ");
                        stringBuilder.Append("(");
                        object[] num3 = new object[] { num1, ",", this.objpage.MakeNullToDecimal(strArrays2[0]), ",", this.objpage.MakeNullToDecimal(strArrays2[1]), "," };
                        stringBuilder.Append(string.Concat(num3));
                        object[] objArray3 = new object[] { " ", this.objpage.MakeNullToDecimal(strArrays2[3]), ",", this.objpage.MakeNullToDecimal(strArrays2[5]), "," };
                        stringBuilder.Append(string.Concat(objArray3));
                        stringBuilder.Append(string.Concat(this.objpage.MakeNullToDecimal(strArrays2[4]), ", 0", ",", DateTime.Now.ToShortDateString()));
                        stringBuilder.Append(");");

                    }
                }

            }
            StringBuilder stringBuilder2 = new StringBuilder();
            if (num1 != (long)-1)
            {
                stringBuilder2.Append(" Update  TABLE_NAME ");
                stringBuilder2.Append(" Set IsDeleted=1 ");
                stringBuilder2.AppendFormat(" Where LargeFormatPressID={0} ", num1);
                stringBuilder2.Append(stringBuilder.ToString());
                SettingsBasePage.Settings_LargeFormatChargeZone_Insert(stringBuilder2.ToString());
            }
        }

        private void Load_Click_Charge_Zone()
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Settings_LargeFormatChargeZone_Select_By_IDlong(this.PressID);
            int num = 1;
            int num1 = 1;
            foreach (DataRow row in dataTable.Rows)
            {

                this.BlackMatrixStartRange = Convert.ToDecimal(row["ZoneFrom"].ToString());
                this.BlackMatrixEndRange = Convert.ToDecimal(row["ZoneTo"].ToString());
                //this.BlackCostPrefill = Convert.ToDecimal(row["ChargeableRate"].ToString());
                this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_Black_", num, "' style='float: left; width: 80%;'>")));
                if (num != 1)
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%;'><span>&nbsp;</span></div>"));
                }
                else
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div style='float: left; width: 10%;'><span>&nbsp;", this.objLanguage.GetLanguageConversion("From"), "</span></div>")));
                }
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%; text-align: right'>"));
                ControlCollection controls = this.plhBlackZone.Controls;
                object[] objArray = new object[] { "<span id='spnBlackFrom", num, "'>", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ZoneFrom"].ToString()), 0, "", true, false, false)), "</span>" };
                controls.Add(new LiteralControl(string.Concat(objArray)));
                ControlCollection controlCollections = this.plhBlackZone.Controls;
                object[] objArray1 = new object[] { "<input type='text' ID='txtBlackFrom", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ZoneFrom"].ToString()), 0, "", true, false, false)), " Style='display:none' />" };
                controlCollections.Add(new LiteralControl(string.Concat(objArray1)));
                ControlCollection controls1 = this.plhBlackZone.Controls;
                object[] str = new object[] { "<input type='hidden' ID='hid_BlackClickChargeZoneLookupID_", num, "' value=", row["LargeFormatChargeZoneID"].ToString(), " Style='display:none' />" };
                controls1.Add(new LiteralControl(string.Concat(str)));
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 3%; text-align: center'>"));
                this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<span id='spn_Black_dash_", num, "' >-</span>")));
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                ControlCollection controlCollections1 = this.plhBlackZone.Controls;
                object[] num2 = new object[] { "<input type='text' ID='txtBlackTo", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ZoneTo"].ToString()), 0, "", true, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='8' onblur= AllowNumber(this,this.value);checkNextCharge(this.value,", num, ",'black');CallonBlur(this.value,'spn_Black_", num, "'); />" };
                controlCollections1.Add(new LiteralControl(string.Concat(num2)));
                if (num == dataTable.Rows.Count / 2)
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl("&nbsp;"));
                }
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                //this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                //ControlCollection controls2 = this.plhBlackZone.Controls;
                //object[] objArray2 = new object[] { "<input type='text' ID='txtBlackChargableSheets", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ChargeableSheets"].ToString()), 0, "", true, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", num, "'); />" };
                //controls2.Add(new LiteralControl(string.Concat(objArray2)));
                //this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                ControlCollection controlCollections2 = this.plhBlackZone.Controls;
                object[] num3 = new object[] { "<input type='text' ID='txtBlackCost", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Cost"].ToString()), 4, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", num, "');Calculate_BlackChargeableRate(this.value,", num, ",'cost'); />" };
                controlCollections2.Add(new LiteralControl(string.Concat(num3)));
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                ControlCollection controls3 = this.plhBlackZone.Controls;
                object[] objArray3 = new object[] { "<input type='text' ID='txtBlackMarkup", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 0, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_BlackChargeableRate(this.value,", num, ",'markup'); />" };
                controls3.Add(new LiteralControl(string.Concat(objArray3)));
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 12%;'>"));
                ControlCollection controlCollections3 = this.plhBlackZone.Controls;
                object[] num4 = new object[] { "<input type='text' ID='txtBlackChargableRate", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["HourlyChargeableRate"].ToString()), 4, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", num, "');Calculate_BlackMarkup(this.value,", num, "); />" };
                controlCollections3.Add(new LiteralControl(string.Concat(num4)));
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                this.plhBlackZone.Controls.Add(new LiteralControl("<div>"));
                ControlCollection controls4 = this.plhBlackZone.Controls;
                object[] valueOnLang = new object[] { "<span id='spn_Black_", num, "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>", this.objlang.GetValueOnLang("Please enter numeric value"), "</span>" };
                controls4.Add(new LiteralControl(string.Concat(valueOnLang)));
                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));

                if (num != dataTable.Rows.Count)
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", num, "' style='float: left;display:none'>")));
                    ControlCollection controlCollections8 = this.plhBlackZone.Controls;
                    object[] objArray8 = new object[] { "<img id='imgDeleterow_", num, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", num, ");'/>" };
                    controlCollections8.Add(new LiteralControl(string.Concat(objArray8)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", num, "' style='float: left;'>")));
                    ControlCollection controls9 = this.plhBlackZone.Controls;
                    object[] objArray9 = new object[] { "<img id='imgDeleterow_", num, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", num, ");'/>" };
                    controls9.Add(new LiteralControl(string.Concat(objArray9)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                }


                this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));

                

                num++;
            }
            this.ItemsCounter = num - 1;
            this.hdnItemscount.Value = this.ItemsCounter.ToString();
            this.BlackMatrixStartRange = Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.BlackMatrixStartRange), 0, "", true, false, false));
            this.BlackMatrixEndRange = Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.BlackMatrixEndRange), 0, "", true, false, false));
            this.hdnTotalrowscount.Value = this.ItemsCounter.ToString();
        }
    }
}