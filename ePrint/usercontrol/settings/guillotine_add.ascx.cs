using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
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

namespace ePrint.usercontrol.settings
{
    public partial class guillotine_add : UserControl
    {
        //protected Label lblheader;

        //protected HtmlGenericControl colourPanel;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected HtmlGenericControl spnnote;

        //protected Panel pnlText;

        //protected Label Label7;

        //protected TextBox txtGuillotineName;

        //protected HtmlGenericControl spnGuillotineName;

        //protected HtmlGenericControl spnName;

        //protected Label Label10;

        //protected TextBox txtDescription;

        //protected Label Label8;

        //protected TextBox txtMinimumSheetHeight;

        //protected Label lblMinSheetHeight;

        //protected TextBox txtMinimumSheetWidth;

        //protected Label lblMinSheetWidth;

        //protected Label Label11;

        //protected TextBox txtMaximumSheetHeight;

        //protected Label lblMaxSheetHeight;

        //protected TextBox txtMaximumSheetWidth;

        //protected Label lblMaxSheetWidth;

        //protected Label Label12;

        //protected TextBox txtMaximumSheetWeight;

        //protected Label lblMaxSheetWeight;

        //protected TextBox txtSetupCharge;

        //protected TextBox txtCostperCut;

        //protected CheckBox chk_First_trim;

        //protected CheckBox chk_Second_trim;

        //protected Panel pnlTrim;

        //protected Label Label19;

        //protected TextBox txtMinRunningCharge;

        //protected TextBox txtMarkUp;

        //protected TextBox txtPaperWeight1;

        //protected TextBox txtPaperWeight2;

        //protected TextBox txtPaperWeight3;

        //protected TextBox txtMaxSheets1;

        //protected TextBox txtMaxSheets2;

        //protected TextBox txtMaxSheets3;

        //protected Panel pnlPlantCal;

        //protected DropDownList ddlItemCut;

        //protected Panel pnlItemCut;

        //protected Button btnGuillotineDelete;

        //protected Button btnDigitalPressCancel;

        //protected Button btnGuillotineAdd;

        //protected HtmlGenericControl Content;

        //protected Panel pnlGuillotineDisplay;

        //protected Panel pnlclosepopup;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string Action = string.Empty;

        public string ReqType = string.Empty;

        public long GuillotineID;

        public string paperType = string.Empty;

        public string PaperMeasure = string.Empty;

        public string Weight = string.Empty;

        public string Points = string.Empty;

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public commonClass comm = new commonClass();

        public string IsForLarge = string.Empty;

        public string ParaForLarge = string.Empty;

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

        public guillotine_add()
        {
        }

        private decimal MakeNullToDecimal(string values)
        {
            return (string.IsNullOrEmpty(values) ? new decimal(0) : Convert.ToDecimal(values));
        }

        private int MakeNullToInteger(string values)
        {
            return (string.IsNullOrEmpty(values) ? 0 : Convert.ToInt32(values));
        }

        protected void OnClick_btnDigitalPressCancel(object sender, EventArgs e)
        {
            this.Action = "cancel";
            if (base.Request.QueryString["type"] == null || !(base.Request.QueryString["type"] == "moreplant"))
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "settings/guillotine_view.aspx?", this.ParaForLarge));
                return;
            }
            if (base.Request.QueryString["islarge"] != null && base.Request.QueryString["islarge"] == "yes")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "common/common_popup.aspx?type=moreplant&pg=estimate&islarge=yes"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "common/common_popup.aspx?type=moreplant&pg=estimate"));
        }

        protected void OnClick_btnGuillotineAdd(object sender, EventArgs e)
        {
            decimal num = this.MakeNullToDecimal(this.objBase.SpecialEncode(this.txtSetupCharge.Text));
            decimal num1 = this.MakeNullToDecimal(this.objBase.SpecialEncode(this.txtCostperCut.Text));
            decimal num2 = this.MakeNullToDecimal(this.objBase.SpecialEncode(this.txtMinRunningCharge.Text));
            decimal num3 = this.MakeNullToDecimal(this.txtMarkUp.Text);
            decimal num4 = this.MakeNullToDecimal(this.txtPaperWeight1.Text);
            decimal num5 = this.MakeNullToDecimal(this.txtMaxSheets1.Text);
            decimal num6 = this.MakeNullToDecimal(this.txtPaperWeight2.Text);
            decimal num7 = this.MakeNullToDecimal(this.txtMaxSheets2.Text);
            decimal num8 = this.MakeNullToDecimal(this.txtPaperWeight3.Text);
            decimal num9 = this.MakeNullToDecimal(this.txtMaxSheets3.Text);

            //decimal num12 = this.MakeNullToDecimal(this.txtPaperCaliper1.Text);
            //decimal num13 = this.MakeNullToDecimal(this.txtPaperCaliper2.Text);
            //decimal num14 = this.MakeNullToDecimal(this.txtPaperCaliper3.Text);
            //decimal num15 = this.MakeNullToDecimal(this.txtMaxSheetsCaliper1.Text);
            //decimal num16 = this.MakeNullToDecimal(this.txtMaxSheetsCaliper2.Text);
            //decimal num17 = this.MakeNullToDecimal(this.txtMaxSheetsCaliper3.Text);
            string calculationType = this.ddlCalculationType.SelectedValue;

            bool flag = false;
            int num10 = 0;
            if (string.Compare(this.IsForLarge, "yes", true) == 0)
            {
                flag = true;
                num10 = Convert.ToInt32(this.ddlItemCut.SelectedItem.Text.ToString());
            }
            int num11 = SettingsBasePage.Settings_Guillotine_Insert(this.CompanyID, this.objBase.SpecialEncode(this.txtGuillotineName.Text), this.objBase.SpecialEncode(this.txtDescription.Text), Convert.ToDecimal(this.txtMinimumSheetHeight.Text), Convert.ToDecimal(this.txtMinimumSheetWidth.Text), Convert.ToDecimal(this.txtMaximumSheetHeight.Text), Convert.ToDecimal(this.txtMaximumSheetWidth.Text), Convert.ToDecimal(this.txtMaximumSheetWeight.Text), num, num1, num2, num3, num4, num5, num6, num7, num8, num9, this.GuillotineID, Convert.ToBoolean(this.chk_First_trim.Checked), Convert.ToBoolean(this.chk_Second_trim.Checked), flag, num10,ddlguillotinetype.SelectedValue,calculationType);
            this.GuillotineID = (long)num11;
            if (num11 == -1)
            {
                this.objBase.Message_Display("Guillotine already exists", "msg-fail", this.plhMessage);
                if (base.Request.Url.ToString().Contains("common/common_popup.aspx"))
                {
                    this.pnlGuillotineDisplay.Visible = true;
                }
                return;
            }
            if (base.Request.QueryString["type"] != null && base.Request.QueryString["type"] == "moreplant" && base.Request.QueryString["islarge"] != null && base.Request.QueryString["islarge"] == "yes")
            {
                this.pnlclosepopup.Visible = true;
                return;
            }
            if (base.Request.QueryString["type"] != null && base.Request.QueryString["type"] == "moreplant")
            {
                this.pnlclosepopup.Visible = true;
                return;
            }
            if (this.ReqType == "edit")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "Settings/guillotine_view.aspx?suc=up", this.ParaForLarge));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/guillotine_view.aspx?suc=ins", this.ParaForLarge));
        }

        protected void OnClick_btnGuillotineDelete(object sender, EventArgs e)
        {
            if (this.CompanyID != 0 && this.ReqType == "edit")
            {
                SettingsBasePage.Settings_Guillotine_Delete(this.CompanyID, this.GuillotineID);
                base.Response.Redirect(string.Concat(this.strSitepath, "settings/guillotine_view.aspx?suc=del", this.ParaForLarge));
            }
        }

        protected void OnClick_btnSave(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/guillotine_view.aspx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnDigitalPressCancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btnDigitalPressCancelprocess');");
            this.Label19.Text = string.Concat(this.objlang.GetLanguageConversion("Minimum_Running_Charge"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.Label7.Text = this.objlang.GetLanguageConversion("Name");
            this.Label10.Text = this.objlang.GetLanguageConversion("Description");
            this.Label8.Text = this.objlang.GetLanguageConversion("Minimum_Sheet_Size_For_The_Plant");
            this.Label11.Text = this.objlang.GetLanguageConversion("Maximum_Sheet_Size_For_The_Plant");
            this.Label12.Text = this.objlang.GetLanguageConversion("Maximum_Sheet_Weight");
            this.btnDigitalPressCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnGuillotineAdd.Text = this.objlang.GetLanguageConversion("Save");
            this.chk_First_trim.Text = this.objlang.GetLanguageConversion("First_Trim");
            this.chk_Second_trim.Text = this.objlang.GetLanguageConversion("Second_Trim");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["userID"].ToString());
            this.paperType = this.comm.settings_paperMeasurementType(this.CompanyID);
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.Weight = this.objpage.GetRegionalSettings(this.CompanyID, "Weight");
            this.Points = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMaterial");

            if (base.Request.Params["islarge"] == null)
            {
                this.spnGuillotineName.InnerText = this.objlang.GetLanguageConversion("Please_Enter_Guillotine_Name");
                this.spnName.InnerText = this.objlang.GetValueOnLang("Guillotine Name already exists");
                this.lblheader.Text = this.objlang.GetLanguageConversion("Settings_Guillotine_Press_Plant_Properties");
                this.spnnote.InnerText = this.objlang.GetValueOnLang("Use this type of guillotine where you are only able to cut one item at a time (Not suitable for sheet fed digital or offset printing)");
            }
            else
            {
                this.ParaForLarge = "&islarge=yes";
                this.IsForLarge = "yes";
                this.lblheader.Text = string.Concat(this.objlang.GetLanguageConversion("Settings"), " : ", this.objlang.GetLanguageConversion("Large_Format_Guillotine"));
                this.pnlPlantCal.Attributes.Add("style", "display:none");
                this.pnlTrim.Attributes.Add("style", "display:none");
                this.spnName.InnerText = this.objlang.GetLanguageConversion("Cutting_Table_Name_Already_Exists");
                this.spnGuillotineName.InnerText = this.objlang.GetLanguageConversion("Please_Enter_Cutting_Table_Name");
                this.spnnote.InnerText = this.objlang.GetLanguageConversion("Cutting_Table_Add_Header_Note");
                this.pnlText.Visible = true;
                this.pnlItemCut.Visible = true;
                for (int i = 1; i <= 10; i++)
                {
                    this.ddlItemCut.Items.Insert(i - 1, i.ToString());
                }
                if (!base.IsPostBack)
                {
                    this.chk_First_trim.Checked = false;
                    this.chk_Second_trim.Checked = true;
                    this.ddlItemCut.SelectedIndex = 3;
                }
            }
            if (base.Request.Params["id"] != null)
            {
                this.GuillotineID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (base.Request.Params["type"] != null)
            {
                this.ReqType = base.Request.Params["type"].ToString().ToLower();
                if (!base.IsPostBack)
                {
                    this.chk_First_trim.Checked = true;
                    this.chk_Second_trim.Checked = true;
                    if (this.ReqType == "edit" && base.Request.Params["id"] != null)
                    {
                        this.btnGuillotineDelete.Visible = true;
                        DataTable dataTable = new DataTable();
                        dataTable = SettingsBasePage.Settings_Guillotine_Select_By_ID(this.CompanyID, this.GuillotineID);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            this.txtGuillotineName.Text = this.objBase.SpecialDecode(row["GuillotineName"].ToString());
                            this.txtDescription.Text = this.objBase.SpecialDecode(row["Description"].ToString());
                            this.txtMinimumSheetHeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MinSheetHeight"].ToString()), 0, "", false, false, false);
                            this.txtMinimumSheetWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MinSheetWidth"].ToString()), 0, "", false, false, false);
                            this.txtMaximumSheetHeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetHeight"].ToString()), 0, "", false, false, false);
                            this.txtMaximumSheetWidth.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetWidth"].ToString()), 0, "", false, false, false);
                            this.txtMaximumSheetWeight.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetWeight"].ToString()), 0, "", false, false, false);
                            this.txtSetupCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SetUpCharge"].ToString()), 0, "", false, false, false);
                            this.txtCostperCut.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["CostPerCut"].ToString()), 0, "", false, false, false);
                            this.txtMinRunningCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MinCharge"].ToString()), 0, "", false, false, false);
                            this.txtMarkUp.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MarkUp"].ToString()), 0, "", false, false, false);
                            this.txtPaperWeight1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PaperWeight1"].ToString()), 0, "", false, false, false);
                            this.txtMaxSheets1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheets1"].ToString()), 0, "", false, false, false);
                            this.txtPaperWeight2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PaperWeight2"].ToString()), 0, "", false, false, false);
                            this.txtMaxSheets2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheets2"].ToString()), 0, "", false, false, false);
                            this.txtPaperWeight3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PaperWeight3"].ToString()), 0, "", false, false, false);
                            this.txtMaxSheets3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheets3"].ToString()), 0, "", false, false, false);
                            this.chk_First_trim.Checked = (Convert.ToBoolean(row["DefaultFirstTrim"]) ? true : false);
                            this.chk_Second_trim.Checked = (Convert.ToBoolean(row["DefaultSecondTrim"]) ? true : false);
                            this.ddlItemCut.SelectedIndex = Convert.ToInt32(row["JobCut"]) - 1;
                            this.ddlguillotinetype.SelectedValue = row["GuillotineType"].ToString();

                            //this.txtPaperCaliper1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PaperCaliper1"].ToString()), 4, "", false, false, false);
                            //this.txtPaperCaliper2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PaperCaliper2"].ToString()), 4, "", false, false, false);
                            //this.txtPaperCaliper3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["PaperCaliper3"].ToString()), 4, "", false, false, false);
                            //this.txtMaxSheetsCaliper1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetCaliper1"].ToString()), 0, "", false, false, false);
                            //this.txtMaxSheetsCaliper2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetCaliper2"].ToString()), 0, "", false, false, false);
                            //this.txtMaxSheetsCaliper3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MaxSheetCaliper3"].ToString()), 0, "", false, false, false);
                            this.ddlCalculationType.SelectedValue = row["PlantCalculationType"].ToString();
                            if(this.ddlCalculationType.SelectedValue == "Weight")
                            {
                                //this.CalculationType.Text = "Weight";
                                //this.pnlPlantCal.Style["display"] = "block";
                                //this.pnlPlantCal1.Style["display"] = "none";
                                //this.pnlPlantCal.Visible = true;
                                //this.pnlPlantCal1.Visible = false;
                                this.stock_weight.Style["display"] = "block";
                                this.stock_caliper.Style["display"] = "none";

                                this.max_throat_weight.Style["display"] = "block";
                                this.max_throat_caliper.Style["display"] = "none";

                            }
                            else
                            {
                                //this.CalculationType.Text = "Caliper";
                                //this.pnlPlantCal.Style["display"] = "none";
                                //this.pnlPlantCal1.Style["display"] = "block";
                                //this.pnlPlantCal.Visible = false;
                                //this.pnlPlantCal1.Visible = true;

                                this.stock_weight.Style["display"] = "none";
                                this.stock_caliper.Style["display"] = "block";

                                this.max_throat_weight.Style["display"] = "none";
                                this.max_throat_caliper.Style["display"] = "block";
                            }

                        }
                    }
                }
            }
        }
    }
}