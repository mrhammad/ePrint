using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
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
    public partial class litho_press_add : BaseClass, IRequiresSessionState
    {
        //protected Label lblTypeHeader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected TextBox txtPressName;

        //protected TextBox txtDescription;

        //protected CheckBox chkDefaultPress;

        //protected RadioButton rdoPerfectYes;

        //protected RadioButton rdoPerfectNo;

        //protected Label lblAccountCode;

        //protected DropDownList ddlAccountCode;

        //protected HtmlGenericControl div_AccountCode;

        //protected TextBox txtMaxImgHeight;

        //protected Label lblMaxImgHeight;

        //protected TextBox txtMaxImgWidth;

        //protected Label lblMaxImgWidth;

        //protected TextBox txtMaxSheetWeight;

        //protected Label lblMaxSheetWeight;

        //protected TextBox txtGutterDepthHeight;

        //protected Label lblPrintHeight;

        //protected TextBox txtGutterDepthWidtht;

        //protected Label lblPrintWidth;

        //protected TextBox txtGutterHorizontal;

        //protected Label lblGutterHor;

        //protected TextBox txtGutterVertical;

        //protected Label lblGutterVer;

        //protected TextBox txtSpoilageSheets;

        //protected TextBox txtRunningSpoilage;

        //protected Label Label25;

        //protected ImageButton imgbtnDefaultPaper;

        //protected Label lblDefaultPaper;

        //protected HiddenField hdnpaperID;

        //protected Label Label7;

        //protected DropDownList ddlPrintSheetSize;

        //protected Label Label5;

        //protected DropDownList ddlJobSize;

        //protected Label Label1;

        //protected ImageButton ImageButton1;

        //protected Label lblDefaultPlates;

        //protected HiddenField hdnplateID;

        //protected Label Label6;

        //protected Label lblGuillotine;

        //protected Label Label19;

        //protected TextBox txtSetupCharge;

        //protected TextBox txtSetupChargeWork_n_Turn;

        //protected TextBox txtSetupChargeWork_n_Tumble;

        //protected Label Label2;

        //protected CheckBox chkMakeReady;

        //protected TextBox txtMakeReady;

        //protected TextBox txtMakeReadyWork_n_Turn;

        //protected TextBox txtMakeReadyWork_n_Tumble;

        //protected Label Label20;

        //protected TextBox txtMinRunningCharge;

        //protected Label Label4;

        //protected CheckBox chkWashUp;

        //protected TextBox txtWashUp;

        //protected Label Label22;

        //protected TextBox txtMarkUp;

        //protected TextBox txtUnitOfMeasure;

        //protected HtmlGenericControl div_UnitOfMeasure;

        //protected Button btnDelete;

        //protected Button btnCancel;

        //protected Button btnNext;

        //protected DropDownList ddlMethod;

        //protected HiddenField hid_ddlMethodSelected;

        //protected TextBox txtHourlyCharge;

        //protected TextBox txtBlackGSM1;

        //protected TextBox txtBlackPagesPerMinute1;

        //protected TextBox txtBlackGSM2;

        //protected TextBox txtBlackPagesPerMinute2;

        //protected TextBox txtBlackGSM3;

        //protected TextBox txtBlackPagesPerMinute3;

        //protected HtmlInputText txt_headersh1;

        //protected HtmlInputText txt_headersh2;

        //protected HtmlInputText txt_headersh3;

        //protected HtmlInputText txt_headersh4;

        //protected HtmlInputText txt_headersh5;

        //protected HtmlInputText txt_headergsm1;

        //protected HtmlInputText txt_val11;

        //protected HtmlInputText txt_val21;

        //protected HtmlInputText txt_val31;

        //protected HtmlInputText txt_val41;

        //protected HtmlInputText txt_val51;

        //protected HtmlInputText txt_headergsm2;

        //protected HtmlInputText txt_val12;

        //protected HtmlInputText txt_val22;

        //protected HtmlInputText txt_val32;

        //protected HtmlInputText txt_val42;

        //protected HtmlInputText txt_val52;

        //protected HtmlInputText txt_headergsm3;

        //protected HtmlInputText txt_val13;

        //protected HtmlInputText txt_val23;

        //protected HtmlInputText txt_val33;

        //protected HtmlInputText txt_val43;

        //protected HtmlInputText txt_val53;

        //protected HtmlGenericControl div_matrix;

        //protected RadioButton rdn_Yield;

        //protected RadioButton rdn_Matrix;

        //protected HiddenField YieldMatrix_Value;

        //protected Label lblInk;

        //protected TextBox txtInk;

        //protected HiddenField hdnlitholength;

        //protected HiddenField hdnlithovalue;

        //protected HiddenField hdnlithoid;

        //protected HiddenField hdnlithoeditvalue;

        //protected HiddenField hdnlithoeditid;

        //protected DropDownList ddlColourunit;

        //protected DropDownList ddlColourNo;

        //protected TextBox txtDefaultInk;

        //protected Button btnPrevious;

        //protected Button btnCancel1;

        //protected Button btnSave;

        //protected Button Button3;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField hdnlength;

        //protected HiddenField hdnvalue;

        //protected HiddenField hdnid;

        //protected HiddenField hdneditvalue;

        //protected HiddenField hdneditid;

        //protected HiddenField hid_GuillotineID;

        private Global gloobj = new Global();

        public int CompanyID;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public commonClass objcom = new commonClass();

        public int id;

        public string ReqType = "add";

        public long retid;

        public string paperType = string.Empty;

        public int UserID;

        public languageClass objlang = new languageClass();

        public bool UnitOfMeasureKey;

        public BasePage ObjPage = new BasePage();

        public string PaperMeasure = string.Empty;

        public string WeightMeasure = string.Empty;

        public string InkType = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

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

        public litho_press_add()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/litho_press_view.aspx"));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_lithopress_delete(this.CompanyID, (long)this.id);
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/litho_press_view.aspx?suc=de"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 1;
            this.rdn_Yield.Attributes.Add("onclick", "javascript:YieldMatrixValue('Y');");
            this.rdn_Matrix.Attributes.Add("onclick", "javascript:YieldMatrixValue('M');");
            bool flag = false;
            if (this.rdoPerfectYes.Checked)
            {
                flag = true;
            }
            Convert.ToDecimal(this.txtMakeReadyWork_n_Tumble.Text);
            this.retid = SettingsBasePage.Settings_LithoPress_Insert(this.CompanyID, base.SpecialEncode(this.txtPressName.Text), base.SpecialEncode(this.txtDescription.Text), Convert.ToDecimal(this.txtMaxImgHeight.Text), Convert.ToDecimal(this.txtMaxImgWidth.Text), Convert.ToDecimal(this.txtMaxSheetWeight.Text), Convert.ToDecimal(this.txtGutterDepthHeight.Text), Convert.ToDecimal(this.txtGutterDepthWidtht.Text), Convert.ToDecimal(this.txtGutterHorizontal.Text), Convert.ToDecimal(this.txtGutterVertical.Text), Convert.ToDecimal(this.txtSpoilageSheets.Text), Convert.ToDecimal(this.txtRunningSpoilage.Text), Convert.ToInt64(this.hdnpaperID.Value), Convert.ToInt32(this.ddlPrintSheetSize.SelectedValue.ToString()), Convert.ToInt32(this.ddlJobSize.SelectedValue.ToString()), Convert.ToInt64(this.hid_GuillotineID.Value), Convert.ToDecimal(this.txtSetupCharge.Text), Convert.ToDecimal(this.txtMinRunningCharge.Text), Convert.ToDecimal(this.txtMarkUp.Text), Convert.ToInt64(this.hdnplateID.Value), Convert.ToDecimal(this.txtMakeReady.Text), this.chkMakeReady.Checked, Convert.ToDecimal(this.txtWashUp.Text), this.chkWashUp.Checked, this.ddlMethod.SelectedItem.ToString(), Convert.ToDecimal(this.txtHourlyCharge.Text), this.ddlColourunit.SelectedValue.ToString(), this.ddlColourNo.SelectedValue.ToString(), Convert.ToDecimal(this.txtDefaultInk.Text), this.YieldMatrix_Value.Value, this.chkDefaultPress.Checked, (long)Convert.ToInt32(this.id), this.objpage.MakeNullToInteger(this.txtUnitOfMeasure.Text), Convert.ToDecimal(this.txtSetupChargeWork_n_Turn.Text), Convert.ToDecimal(this.txtSetupChargeWork_n_Tumble.Text), Convert.ToDecimal(this.txtMakeReadyWork_n_Turn.Text), Convert.ToDecimal(this.txtMakeReadyWork_n_Tumble.Text), flag);
            if (this.retid != (long)-1)
            {
                if (this.AccountingCode == "d")
                {
                    SettingsBasePage.Litho_press_AccountingCode_Insert((long)this.CompanyID, this.retid, int.Parse(this.ddlAccountCode.SelectedValue));
                }
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        HtmlInputText htmlInputText = (HtmlInputText)this.div_matrix.FindControl(string.Concat("txt_headergsm", i));
                        HtmlInputText htmlInputText1 = (HtmlInputText)this.div_matrix.FindControl(string.Concat("txt_headersh", j));
                        HtmlInputText htmlInputText2 = (HtmlInputText)this.div_matrix.FindControl(string.Concat("txt_val", j, i));
                        int.TryParse(htmlInputText.Value.ToString(), out num);
                        int.TryParse(htmlInputText1.Value.ToString(), out num);
                        int.TryParse(htmlInputText2.Value.ToString(), out num);
                        if (htmlInputText.Value == "")
                        {
                            htmlInputText.Value = "0";
                        }
                        if (htmlInputText1.Value == "")
                        {
                            htmlInputText1.Value = "0";
                        }
                        if (htmlInputText2.Value == "")
                        {
                            htmlInputText2.Value = "0";
                        }
                        if (this.ReqType.ToLower().Trim() != "edit")
                        {
                            SettingsBasePage.settings_Litho_press_matrix_insert(this.CompanyID, this.retid, Convert.ToDecimal(htmlInputText.Value), Convert.ToDecimal(htmlInputText1.Value), Convert.ToDecimal(htmlInputText2.Value));
                        }
                        else
                        {
                            if (num1 == 1)
                            {
                                SettingsBasePage.settings_Litho_press_matrix_update(this.CompanyID, this.retid);
                                num1++;
                            }
                            SettingsBasePage.settings_Litho_press_matrix_insert(this.CompanyID, this.retid, Convert.ToDecimal(htmlInputText.Value), Convert.ToDecimal(htmlInputText1.Value), Convert.ToDecimal(htmlInputText2.Value));
                        }
                    }
                }
                this.hdnvalue.Value.Split(new char[] { '\u005E' });
                string[] strArrays = this.hdnid.Value.Split(new char[] { '\u005E' });
                if (this.ReqType.ToLower().Trim() == "edit")
                {
                    SettingsBasePage.Settings_lithopress_update_ink_Delete(this.CompanyID, (long)this.id, 0);
                    for (int k = 0; k < (int)strArrays.Length - 1; k++)
                    {
                        SettingsBasePage.Settings_Litho_Insert_ink_insert(this.CompanyID, this.retid, Convert.ToInt32(strArrays[k].ToString()));
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "settings/litho_press_view.aspx?action=edit"));
                    return;
                }
                for (int l = 0; l < (int)strArrays.Length - 1; l++)
                {
                    SettingsBasePage.Settings_Litho_Insert_ink_insert(this.CompanyID, this.retid, Convert.ToInt32(strArrays[l].ToString()));
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "settings/litho_press_view.aspx?action=add"));
            }
        }

        [WebMethod]
        public static int GetLitho(string val)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.btnCancel1.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btncancel1process');");
            this.lblAccountCode.Text = this.objlang.GetValueOnLang("Accounting Code");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnDelete.Text = this.objLanguage.GetLanguageConversion("Delete");
            this.btnPrevious.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btnNext.Text = this.objLanguage.GetLanguageConversion("Next");
            this.btnCancel1.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.Label19.Text = string.Concat(this.objlang.GetValueOnLang("Set up Charge"), "  (", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            this.Label20.Text = string.Concat(this.objLanguage.GetLanguageConversion("Minimum_Running_Charge"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            this.Label2.Text = string.Concat(this.objLanguage.GetLanguageConversion("Make_Ready_Charge_Per_Plate_Euro"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            Label label4 = this.Label4;
            string[] languageConversion = new string[] { this.objLanguage.GetLanguageConversion("Wash_Up_Charge_Per"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")" };
            label4.Text = string.Concat(languageConversion);
            this.rdn_Yield.Text = this.objLanguage.GetLanguageConversion("Yield");
            this.rdn_Matrix.Text = this.objLanguage.GetLanguageConversion("Matrix");
            this.lblInk.Text = this.objlang.GetValueOnLang("Matrix");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            this.Button3.Text = this.objlang.GetLanguageConversion("Delete");
            string empty = string.Empty;
            string str = string.Empty;
            this.gloobj.setpagename("setting");
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.txtPressName.Focus();
            SettingsBasePage settingsBasePage = new SettingsBasePage();
            this.paperType = this.objcom.settings_paperMeasurementType(this.CompanyID);
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
            if (base.Request.Params["id"] != null)
            {
                this.id = Convert.ToInt32(base.Request.Params["id"].ToString());
            }
            this.txtSetupCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtSetupCharge.Text.ToString()), 0, "", false, false, true);
            this.txtMinRunningCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMinRunningCharge.Text.ToString()), 0, "", false, false, true);
            this.txtMakeReady.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMakeReady.Text.ToString()), 0, "", false, false, true);
            this.txtWashUp.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtWashUp.Text.ToString()), 0, "", false, false, true);
            this.txtMarkUp.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMarkUp.Text.ToString()), 0, "", false, false, true);
            this.txtSetupChargeWork_n_Turn.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtSetupChargeWork_n_Turn.Text.ToString()), 0, "", false, false, true);
            this.txtSetupChargeWork_n_Tumble.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtSetupChargeWork_n_Tumble.Text.ToString()), 0, "", false, false, true);
            this.txtMakeReadyWork_n_Turn.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMakeReadyWork_n_Turn.Text.ToString()), 0, "", false, false, true);
            this.txtMakeReadyWork_n_Tumble.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMakeReadyWork_n_Tumble.Text.ToString()), 0, "", false, false, true);
            if (!base.IsPostBack)
            {
                settingsBasePage.Bind_PaperSize(this.ddlPrintSheetSize, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                settingsBasePage.Bind_PaperSize(this.ddlJobSize, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = false;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                }
            }
            this.rdn_Yield.Attributes.Add("onclick", "javascript:return YieldMatrixValue('Y');");
            this.rdn_Matrix.Attributes.Add("onclick", "javascript:return YieldMatrixValue('M');");
            if (this.rdn_Yield.Checked)
            {
                this.YieldMatrix_Value.Value = "Y";
            }
            else if (this.rdn_Matrix.Checked)
            {
                this.YieldMatrix_Value.Value = "M";
            }
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.WeightMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "Weight");
            this.txtSpoilageSheets.Attributes.Add("style", "text-align:right");
            this.txtRunningSpoilage.Attributes.Add("style", "text-align:right");
            this.txtHourlyCharge.Attributes.Add("style", "text-align:right");
            this.txtHourlyCharge.Attributes.Add("style", "text-align:right");
            this.txtHourlyCharge.Attributes.Add("style", "text-align:right");
            this.txtHourlyCharge.Attributes.Add("style", "text-align:right");
            this.txtHourlyCharge.Attributes.Add("style", "text-align:right");
            this.txtHourlyCharge.Attributes.Add("style", "text-align:right");
            string empty1 = string.Empty;
            if (base.Request.Params["type"] == null)
            {
                string[] strArrays = new string[] { "<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/litho_press_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Sheet_Fed_offset_view"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Sheet_Fed_offset_Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Sheet Fed Offset", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Sheet_Fed_offset_Add");
            }
            else
            {
                this.ReqType = base.Request.Params["type"].ToString().ToLower();
                if (this.ReqType == "edit" && base.Request.Params["id"] != null)
                {
                    string[] languageConversion1 = new string[] { "<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/litho_press_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Sheet_Fed_Offset_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Sheet_Fed_Offset_Edit")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Sheet Fed Offset", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Sheet_Fed_Offset_Edit");
                    this.btnDelete.Visible = true;
                    if (!base.IsPostBack)
                    {
                        DataTable dataTable = SettingsBasePage.Settings_LithoPress_Select_By_ID(this.CompanyID, (long)this.id);
                        try
                        {
                            if (this.AccountingCode != "d")
                            {
                                this.div_AccountCode.Visible = false;
                            }
                            else
                            {
                                this.div_AccountCode.Visible = false;
                                this.id = Convert.ToInt32(base.Request.Params["id"].ToString());
                                DropDownList dropDownList = this.ddlAccountCode;
                                int num = SettingsBasePage.LithoPress_AccountingCode_Select((long)this.CompanyID, (long)this.id);
                                dropDownList.SelectedValue = num.ToString();
                            }
                        }
                        catch
                        {
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            this.txtPressName.Text = base.SpecialDecode(row["LithoPressName"].ToString());
                            this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
                            this.chkDefaultPress.Checked = Convert.ToBoolean(row["IsDefaultPress"].ToString());
                            this.txtMaxImgHeight.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxImgHeight"].ToString()), 0, "", false, false, false);
                            this.txtMaxImgWidth.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxImgWidth"].ToString()), 0, "", false, false, false);
                            this.txtMaxSheetWeight.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetWeight"].ToString()), 0, "", false, false, false);
                            this.txtGutterDepthHeight.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PrintImageHeight"].ToString()), 0, "", false, false, false);
                            this.txtGutterDepthWidtht.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PrintImageWidth"].ToString()), 0, "", false, false, false);
                            this.txtGutterHorizontal.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GutterHorizontal"].ToString()), 0, "", false, false, false);
                            this.txtGutterVertical.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["GutterVertical"].ToString()), 0, "", false, false, false);
                            this.txtSpoilageSheets.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SpoilageSheets"].ToString()), 0, "", false, false, false);
                            this.txtRunningSpoilage.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["RunningSpoilage"].ToString()), 0, "", false, false, false);
                            this.hdnpaperID.Value = row["PaperID"].ToString();
                            this.ddlPrintSheetSize.SelectedValue = row["PrintSheetID"].ToString();
                            this.ddlJobSize.SelectedValue = row["JobSizeID"].ToString();
                            this.hid_GuillotineID.Value = row["GuillotineID"].ToString();
                            this.lblGuillotine.Text = base.SpecialDecode(row["GuillotineName"].ToString());
                            this.lblDefaultPlates.Text = base.SpecialDecode(row["PlateName"].ToString());
                            this.lblDefaultPaper.Text = row["PaperName"].ToString();
                            this.txtSetupCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SetupCharge"].ToString()), 0, "", false, false, false);
                            this.txtSetupChargeWork_n_Turn.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SetupChargeWork_n_Turn"].ToString()), 0, "", false, false, true);
                            this.txtSetupChargeWork_n_Tumble.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SetupChargeWork_n_Tumble"].ToString()), 0, "", false, false, true);
                            this.txtMakeReadyWork_n_Turn.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MakeReadyWork_n_Turn"].ToString()), 0, "", false, false, true);
                            this.txtMakeReadyWork_n_Tumble.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MakeReadyWork_n_Tumble"].ToString()), 0, "", false, false, true);
                            if (!Convert.ToBoolean(row["isPressPerfect"]))
                            {
                                this.rdoPerfectYes.Checked = false;
                                this.rdoPerfectNo.Checked = true;
                            }
                            else
                            {
                                this.rdoPerfectYes.Checked = true;
                                this.rdoPerfectNo.Checked = false;
                            }
                            this.txtMinRunningCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MinCharge"].ToString()), 0, "", false, false, false);
                            this.txtMarkUp.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MarkUp"].ToString()), 0, "", false, false, false);
                            this.hdnplateID.Value = row["PlateID"].ToString();
                            this.txtMakeReady.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MakeReadyPerPlate"].ToString()), 0, "", false, false, false);
                            this.chkMakeReady.Checked = Convert.ToBoolean(row["MakeReadyPerPlateCheck"].ToString());
                            this.txtWashUp.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["WashupChargePerColour"].ToString()), 0, "", false, false, false);
                            this.chkWashUp.Checked = Convert.ToBoolean(row["WashupChargePerColourCheck"].ToString());
                            this.txtHourlyCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["HourlyChargeRate"].ToString()), 0, "", false, false, false);
                            this.ddlColourunit.SelectedValue = row["ColourUnits"].ToString();
                            this.ddlColourNo.SelectedValue = row["DefaultColour"].ToString();
                            this.txtDefaultInk.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["DefaultInkCoverageSide"].ToString()), 0, "", false, false, false);
                            this.txtUnitOfMeasure.Text = row["UnitOfMeasure"].ToString();
                            if (row["InkType"].ToString().ToLower() == "y")
                            {
                                this.rdn_Yield.Checked = true;
                                this.rdn_Matrix.Checked = false;
                            }
                            else if (row["InkType"].ToString().ToLower() == "m")
                            {
                                this.rdn_Matrix.Checked = true;
                                this.rdn_Yield.Checked = false;
                            }
                            for (int i = 0; i < this.ddlMethod.Items.Count; i++)
                            {
                                if (this.ddlMethod.Items[i].Text == row["MethodName"].ToString())
                                {
                                    this.ddlMethod.SelectedIndex = i;
                                }
                            }
                        }
                        DataTable dataTable1 = SettingsBasePage.Settings_LithoPressMatrix_Select_By_ID(this.CompanyID, (long)this.id);
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringBuilder1 = new StringBuilder();
                        StringBuilder stringBuilder2 = new StringBuilder();
                        if (dataTable1.Rows.Count > 0)
                        {
                            foreach (DataRow dataRow in dataTable1.Rows)
                            {
                                stringBuilder.Append(string.Concat(dataRow["GSM"].ToString(), ","));
                                stringBuilder1.Append(string.Concat(dataRow["sheets"].ToString(), ","));
                                stringBuilder2.Append(string.Concat(dataRow["sheetsperhour"].ToString(), ","));
                            }
                            string[] strArrays1 = new string[] { "," };
                            string[] strArrays2 = stringBuilder.ToString().Split(strArrays1, StringSplitOptions.RemoveEmptyEntries);
                            string[] strArrays3 = stringBuilder1.ToString().Split(strArrays1, StringSplitOptions.RemoveEmptyEntries);
                            string[] strArrays4 = stringBuilder2.ToString().Split(strArrays1, StringSplitOptions.RemoveEmptyEntries);
                            int num1 = 0;
                            for (int j = 1; j <= 3; j++)
                            {
                                for (int k = 1; k <= 5; k++)
                                {
                                    HtmlInputText htmlInputText = (HtmlInputText)this.div_matrix.FindControl(string.Concat("txt_headergsm", j));
                                    HtmlInputText htmlInputText1 = (HtmlInputText)this.div_matrix.FindControl(string.Concat("txt_headersh", k));
                                    HtmlInputText htmlInputText2 = (HtmlInputText)this.div_matrix.FindControl(string.Concat("txt_val", k, j));
                                    htmlInputText.Value = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(strArrays2[num1].ToString()), 0, "", true, false, false);
                                    htmlInputText1.Value = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(strArrays3[num1].ToString()), 0, "", true, false, false);
                                    htmlInputText2.Value = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(strArrays4[num1].ToString()), 0, "", true, false, false);
                                    num1++;
                                }
                            }
                        }
                        IDataReader dataReader = SettingsBasePage.settings_lithopress_select_ink(this.CompanyID, (long)this.id);
                        while (dataReader.Read())
                        {
                            empty = string.Concat(empty, dataReader["name"], "^");
                            str = string.Concat(str, dataReader["InkID"], "^");
                        }
                        dataReader.Dispose();
                        this.hdneditvalue.Value = empty;
                        this.hdneditid.Value = str;
                        return;
                    }
                }
            }
        }
    }
}