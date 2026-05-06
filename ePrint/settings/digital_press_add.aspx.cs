using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
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
    public partial class digital_press_add : BaseClass, IRequiresSessionState
    {
        //protected RadCodeBlock RadCodeBlock1;

        //protected usercontrol_settings_Loading ucLoading;

        //protected Label lblheader;

        //protected HiddenField hdnBlack;

        //protected HiddenField hdnColor;

        //protected HiddenField hdn_ClickChargeZoneLookupBlack;

        //protected HiddenField hdn_ClickChargeZoneLookupColour;

        //protected HiddenField hdnTotalrowscount;

        //protected HiddenField hdnItemscount;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected TextBox txtDigitalPressName;

        //protected TextBox txtDescription;

        //protected CheckBox chkDefaultPress;

        //protected Label lblAccountCode;

        //protected DropDownList ddlAccountCode;

        //protected HtmlGenericControl div_AccountCode;

        //protected TextBox txtMaxImgHeight;

        //protected Label lblMaxImgHeight;

        //protected TextBox txtMaxImgWidth;

        //protected Label lblMaxImgWidth;

        //protected Label Label17;

        //protected TextBox txtMaxSheetWeight;

        //protected Label lblMaxSheetWeight;

        //protected TextBox txtGripDepth;

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

        //protected Label Label4;

        //protected DropDownList ddlPrintSheetSize;

        //protected Label Label5;

        //protected DropDownList ddlJobSize;

        //protected Label Label6;

        //protected DropDownList ddlGuillotine;

        //protected Label Label19;

        //protected TextBox txtSetupCharge;

        //protected Label Label20;

        //protected TextBox txtMinRunningCharge;

        //protected TextBox txtUnitOfMeasure;

        //protected HtmlGenericControl div_UnitOfMeasure;

        //protected Button btnDelete;

        //protected HtmlGenericControl divDelete;

        //protected Button Button1;

        //protected Button Button2;

        //protected HtmlGenericControl DIV_TAKE;

        //protected DropDownList ddlMethod;

        //protected HiddenField hid_ddlMethodSelected;

        //protected Label Label23;

        //protected TextBox txtBlackChargeableSheets;

        //protected Label Label2;

        //protected TextBox txtColourChargeableSheets;

        //protected Label Label22;

        //protected TextBox txtMarkUp;

        //protected Label Label3;

        //protected TextBox txtNoChargeableSheets;

        //protected TextBox txtHourlyCharge;

        //protected Label Label1;

        //protected TextBox txtspeedMarkup;

        //protected TextBox txtBlackGSM1;

        //protected TextBox txtBlackPagesPerMinute1;

        //protected TextBox txtBlackGSM2;

        //protected TextBox txtBlackPagesPerMinute2;

        //protected TextBox txtBlackGSM3;

        //protected TextBox txtBlackPagesPerMinute3;

        //protected Label Label30;

        //protected Label Label31;

        //protected TextBox txtColorGSM1;

        //protected TextBox txtColorPagesPerMinute1;

        //protected TextBox txtColorGSM2;

        //protected TextBox txtColorPagesPerMinute2;

        //protected TextBox txtColorGSM3;

        //protected TextBox txtColorPagesPerMinute3;

        //protected CheckBox chkCalculationType;

        //protected PlaceHolder plhBlackZone;

        //protected HtmlGenericControl spnGetID;

        //protected CheckBox chkBlackFlattenClick;

        //protected CheckBox chkBlackSumClick;

        //protected HtmlImage Img1;

        //protected PlaceHolder plhColorZone;

        //protected CheckBox chkColorFlattenClick;

        //protected CheckBox chkColorSumClick;

        //protected Button Button20;

        //protected RadButton Button22;

        //protected RadWindowManager RadWindowManager2;

        //protected Panel pnlddlMethod;

        //protected HiddenField hid_MethodID;

        //protected RadWindowManager RadWindowManager1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        public string stockUrl = string.Empty;

        private Global gloobj = new Global();

        private string ReqType = string.Empty;

        public BasePage objpage = new BasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public commonClass objcom = new commonClass();

        public long DigitalPressID;

        public int CompanyID;

        public int UserID;

        public string paperType = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public bool UnitOfMeasureKey;

        public int ItemsCounter;

        public decimal MatrixStartRange;

        public decimal MatrixEndRange;

        public decimal CostPrefill;

        public string paperWeight = string.Empty;

        public decimal BlackMatrixStartRange;

        public decimal BlackMatrixEndRange;

        public decimal BlackCostPrefill;

        public decimal ColourMatrixStartRange;

        public decimal ColourMatrixEndRange;

        public decimal ColourCostPrefill;

        public string Copied_Black_N_White_2_Color_Msg = string.Empty;

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

        public digital_press_add()
        {
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_digitalpress_delete(this.CompanyID, this.DigitalPressID);
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/digital_press_view.aspx?suc=de"));
        }

        public void btnDigitalAdd_OnClick(object sender, EventArgs e)
        {
            long num = Convert.ToInt64(this.hid_MethodID.Value);
            long num1 = (long)0;
            string value = this.hid_ddlMethodSelected.Value;
            string empty = string.Empty;
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            if (value == "ClickChargeLookup")
            {
                num = SettingsBasePage.Settings_ClickChargeLookup_Insert(this.CompanyID, this.objpage.MakeNullToDecimal(this.txtBlackChargeableSheets.Text), this.objpage.MakeNullToDecimal(this.txtColourChargeableSheets.Text), this.objpage.MakeNullToDecimal(this.txtNoChargeableSheets.Text), num);
                empty = this.txtMarkUp.Text;
            }
            else if (value == "SpeedWeightLookup")
            {
                num = SettingsBasePage.Settings_SpeedWeightLookup_Insert_Update(this.CompanyID, this.objpage.MakeNullToDecimal(this.txtHourlyCharge.Text), this.objpage.MakeNullToDecimal(this.txtBlackGSM1.Text), this.objpage.MakeNullToDecimal(this.txtBlackPagesPerMinute1.Text), this.objpage.MakeNullToDecimal(this.txtBlackGSM2.Text), this.objpage.MakeNullToDecimal(this.txtBlackPagesPerMinute2.Text), this.objpage.MakeNullToDecimal(this.txtBlackGSM3.Text), this.objpage.MakeNullToDecimal(this.txtBlackPagesPerMinute3.Text), this.objpage.MakeNullToDecimal(this.txtColorGSM1.Text), this.objpage.MakeNullToDecimal(this.txtColorPagesPerMinute1.Text), this.objpage.MakeNullToDecimal(this.txtColorGSM2.Text), this.objpage.MakeNullToDecimal(this.txtColorPagesPerMinute2.Text), this.objpage.MakeNullToDecimal(this.txtColorGSM3.Text), this.objpage.MakeNullToDecimal(this.txtColorPagesPerMinute3.Text), num);
                empty = this.txtspeedMarkup.Text;
            }
            else if (value == "ClickChargeZoneLookup")
            {
                num = (long)100;
                if (this.chkBlackFlattenClick.Checked)
                {
                    flag = true;
                }
                if (this.chkBlackSumClick.Checked)
                {
                    flag1 = true;
                }
                if (this.chkColorFlattenClick.Checked)
                {
                    flag2 = true;
                }
                if (this.chkColorSumClick.Checked)
                {
                    flag3 = true;
                }
            }
            if (num != (long)0)
            {
                num1 = SettingsBasePage.Settings_DigitalPress_Insert(this.CompanyID, base.SpecialEncode(this.txtDigitalPressName.Text), base.SpecialEncode(this.txtDescription.Text), this.objpage.MakeNullToDecimal(this.txtMaxImgHeight.Text), this.objpage.MakeNullToDecimal(this.txtMaxImgWidth.Text), this.objpage.MakeNullToDecimal(this.txtMaxSheetWeight.Text), this.objpage.MakeNullToDecimal(this.txtGutterDepthHeight.Text), this.objpage.MakeNullToDecimal(this.txtGutterDepthWidtht.Text), this.objpage.MakeNullToDecimal(this.txtGutterHorizontal.Text), this.objpage.MakeNullToDecimal(this.txtGutterVertical.Text), this.objpage.MakeNullToDecimal(this.txtSpoilageSheets.Text), this.objpage.MakeNullToDecimal(this.txtRunningSpoilage.Text), (long)this.objpage.MakeNullToInteger(this.hdnpaperID.Value), this.objpage.MakeNullToInteger(this.ddlPrintSheetSize.SelectedValue.ToString()), this.objpage.MakeNullToInteger(this.ddlJobSize.SelectedValue.ToString()), (long)this.objpage.MakeNullToInteger(this.ddlGuillotine.SelectedValue.ToString()), this.objpage.MakeNullToDecimal(this.txtSetupCharge.Text), this.objpage.MakeNullToDecimal(this.txtMinRunningCharge.Text), this.objpage.MakeNullToDecimal(empty), value, num, flag, flag1, flag2, flag3, this.DigitalPressID, this.chkDefaultPress.Checked, this.chkCalculationType.Checked, this.objpage.MakeNullToInteger(this.txtUnitOfMeasure.Text));
            }
            if (value == "ClickChargeZoneLookup")
            {
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringBuilder1 = new StringBuilder();
                string[] strArrays = this.hdn_ClickChargeZoneLookupBlack.Value.ToString().Split(new char[] { '$' });
                string[] strArrays1 = this.hdn_ClickChargeZoneLookupColour.Value.ToString().Split(new char[] { '$' });
                for (int i = 0; i < Convert.ToInt32((int)strArrays.Length); i++)
                {
                    string[] strArrays2 = strArrays[i].Split(new char[] { '~' });
                    string[] strArrays3 = strArrays1[i].Split(new char[] { '~' });
                    if (this.ReqType == "edit")
                    {
                        if (Convert.ToInt64(strArrays2[6]) != (long)0)
                        {
                            stringBuilder.Append(" Update  TABLE_NAME ");
                            stringBuilder.AppendFormat(" Set ZoneFrom={0}, ", this.objpage.MakeNullToDecimal(strArrays2[0]));
                            stringBuilder.AppendFormat(" ZoneTo={0}, ", this.objpage.MakeNullToDecimal(strArrays2[1]));
                            stringBuilder.AppendFormat(" ChargeableSheets={0}, ", this.objpage.MakeNullToDecimal(strArrays2[2]));
                            stringBuilder.AppendFormat(" Cost={0}, ", this.objpage.MakeNullToDecimal(strArrays2[3]));
                            stringBuilder.AppendFormat(" ChargeableRate={0}, ", this.objpage.MakeNullToDecimal(strArrays2[4]));
                            stringBuilder.AppendFormat(" Markup={0}, ", this.objpage.MakeNullToDecimal(strArrays2[5]));
                            stringBuilder.AppendFormat(" IsDeleted=0 ", new object[0]);
                            stringBuilder.AppendFormat(" Where DigitalPressID={0} ", num1);
                            stringBuilder.AppendFormat(" AND ClickChargeZoneLookupID={0}; ", Convert.ToInt64(strArrays2[6]));
                        }
                        else
                        {
                            stringBuilder.Append("Insert into  TABLE_NAME");
                            stringBuilder.Append(" (");
                            stringBuilder.Append("   DigitalPressID,ZoneFrom,ZoneTo,ChargeableSheets,Cost,ChargeableRate,ZoneType,Markup");
                            stringBuilder.Append(" )");
                            stringBuilder.Append("values ");
                            stringBuilder.Append("(");
                            object[] objArray = new object[] { num1, ",", this.objpage.MakeNullToDecimal(strArrays2[0]), ",", this.objpage.MakeNullToDecimal(strArrays2[1]), "," };
                            stringBuilder.Append(string.Concat(objArray));
                            object[] objArray1 = new object[] { " ", this.objpage.MakeNullToDecimal(strArrays2[2]), ",", this.objpage.MakeNullToDecimal(strArrays2[3]), "," };
                            stringBuilder.Append(string.Concat(objArray1));
                            stringBuilder.Append(string.Concat(this.objpage.MakeNullToDecimal(strArrays2[4]), ",'black',", this.objpage.MakeNullToDecimal(strArrays2[5])));
                            stringBuilder.Append(");");
                        }
                        if (Convert.ToInt64(strArrays3[6]) != (long)0)
                        {
                            stringBuilder1.Append(" Update  TABLE_NAME ");
                            stringBuilder1.AppendFormat(" Set ZoneFrom={0}, ", this.objpage.MakeNullToDecimal(strArrays3[0]));
                            stringBuilder1.AppendFormat(" ZoneTo={0}, ", this.objpage.MakeNullToDecimal(strArrays3[1]));
                            stringBuilder1.AppendFormat(" ChargeableSheets={0}, ", this.objpage.MakeNullToDecimal(strArrays3[2]));
                            stringBuilder1.AppendFormat(" Cost={0}, ", this.objpage.MakeNullToDecimal(strArrays3[3]));
                            stringBuilder1.AppendFormat(" ChargeableRate={0}, ", this.objpage.MakeNullToDecimal(strArrays3[4]));
                            stringBuilder1.AppendFormat(" Markup={0}, ", this.objpage.MakeNullToDecimal(strArrays3[5]));
                            stringBuilder1.AppendFormat(" IsDeleted=0 ", new object[0]);
                            stringBuilder1.AppendFormat(" Where DigitalPressID={0} ", num1);
                            stringBuilder1.AppendFormat(" AND ClickChargeZoneLookupID={0}; ", Convert.ToInt64(strArrays3[6]));
                        }
                        else
                        {
                            stringBuilder1.Append("Insert into TABLE_NAME");
                            stringBuilder1.Append(" (");
                            stringBuilder1.Append("   DigitalPressID,ZoneFrom,ZoneTo,ChargeableSheets,Cost,ChargeableRate,ZoneType,Markup");
                            stringBuilder1.Append(" )");
                            stringBuilder1.Append("values ");
                            stringBuilder1.Append("(");
                            object[] num2 = new object[] { num1, ",", this.objpage.MakeNullToDecimal(strArrays3[0]), ",", this.objpage.MakeNullToDecimal(strArrays3[1]), "," };
                            stringBuilder1.Append(string.Concat(num2));
                            object[] objArray2 = new object[] { " ", this.objpage.MakeNullToDecimal(strArrays3[2]), ",", this.objpage.MakeNullToDecimal(strArrays3[3]), "," };
                            stringBuilder1.Append(string.Concat(objArray2));
                            stringBuilder1.Append(string.Concat(this.objpage.MakeNullToDecimal(strArrays3[4]), ",'color',", this.objpage.MakeNullToDecimal(strArrays3[5])));
                            stringBuilder1.Append("); ");
                        }
                    }
                    else
                    {
                        stringBuilder.Append("Insert into  TABLE_NAME");
                        stringBuilder.Append(" (");
                        stringBuilder.Append("   DigitalPressID,ZoneFrom,ZoneTo,ChargeableSheets,Cost,ChargeableRate,ZoneType,Markup");
                        stringBuilder.Append(" )");
                        stringBuilder.Append("values ");
                        stringBuilder.Append("(");
                        object[] num3 = new object[] { num1, ",", this.objpage.MakeNullToDecimal(strArrays2[0]), ",", this.objpage.MakeNullToDecimal(strArrays2[1]), "," };
                        stringBuilder.Append(string.Concat(num3));
                        object[] objArray3 = new object[] { " ", this.objpage.MakeNullToDecimal(strArrays2[2]), ",", this.objpage.MakeNullToDecimal(strArrays2[3]), "," };
                        stringBuilder.Append(string.Concat(objArray3));
                        stringBuilder.Append(string.Concat(this.objpage.MakeNullToDecimal(strArrays2[4]), ",'black',", this.objpage.MakeNullToDecimal(strArrays2[5])));
                        stringBuilder.Append(");");
                        stringBuilder1.Append("Insert into TABLE_NAME");
                        stringBuilder1.Append(" (");
                        stringBuilder1.Append("   DigitalPressID,ZoneFrom,ZoneTo,ChargeableSheets,Cost,ChargeableRate,ZoneType,Markup");
                        stringBuilder1.Append(" )");
                        stringBuilder1.Append("values ");
                        stringBuilder1.Append("(");
                        object[] num4 = new object[] { num1, ",", this.objpage.MakeNullToDecimal(strArrays3[0]), ",", this.objpage.MakeNullToDecimal(strArrays3[1]), "," };
                        stringBuilder1.Append(string.Concat(num4));
                        object[] objArray4 = new object[] { " ", this.objpage.MakeNullToDecimal(strArrays3[2]), ",", this.objpage.MakeNullToDecimal(strArrays3[3]), "," };
                        stringBuilder1.Append(string.Concat(objArray4));
                        stringBuilder1.Append(string.Concat(this.objpage.MakeNullToDecimal(strArrays3[4]), ",'color',", this.objpage.MakeNullToDecimal(strArrays3[5])));
                        stringBuilder1.Append("); ");
                    }
                }
                StringBuilder stringBuilder2 = new StringBuilder();
                if (num1 != (long)-1)
                {
                    stringBuilder2.Append(" Update  TABLE_NAME ");
                    stringBuilder2.Append(" Set IsDeleted=1 ");
                    stringBuilder2.AppendFormat(" Where DigitalPressID={0} ", num1);
                    stringBuilder2.Append(stringBuilder1.ToString());
                    stringBuilder2.Append(stringBuilder.ToString());
                    SettingsBasePage.Settings_ClickChargeZoneLookup_Insert(0, (long)0, 0, 0, 0, new decimal(0), new decimal(0), stringBuilder2.ToString());
                }
            }
            if (num1 == (long)-1)
            {
                base.Response.Write("Already Exists");
                return;
            }
            if (this.AccountingCode == "d")
            {
                SettingsBasePage.DigitalPress_AccountingCode_Insert((long)this.CompanyID, num1, int.Parse(this.ddlAccountCode.SelectedValue));
            }
            if (this.ReqType == "edit")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "settings/digital_press_view.aspx?suc=up"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/digital_press_view.aspx?suc=in"));
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/digital_press_view.aspx"));
        }

        [WebMethod]
        public static int GetDigitalPress(string val)
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

        private void Load_Click_Charge_Zone()
        {
            DataTable dataTable = new DataTable();
            this.ddlMethod.SelectedIndex = 3;
            dataTable = SettingsBasePage.Settings_ClickChargeZoneLookup_Select_By_ID(this.CompanyID, this.DigitalPressID);
            int num = 1;
            int num1 = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["ZoneType"].ToString().ToLower() == "black")
                {
                    this.BlackMatrixStartRange = Convert.ToDecimal(row["ZoneFrom"].ToString());
                    this.BlackMatrixEndRange = Convert.ToDecimal(row["ZoneTo"].ToString());
                    this.BlackCostPrefill = Convert.ToDecimal(row["ChargeableRate"].ToString());
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_Black_", num, "' style='float: left; width: 100%;'>")));
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
                    object[] str = new object[] { "<input type='hidden' ID='hid_BlackClickChargeZoneLookupID_", num, "' value=", row["ClickChargeZoneLookupID"].ToString(), " Style='display:none' />" };
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
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                    ControlCollection controls2 = this.plhBlackZone.Controls;
                    object[] objArray2 = new object[] { "<input type='text' ID='txtBlackChargableSheets", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ChargeableSheets"].ToString()), 0, "", true, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", num, "'); />" };
                    controls2.Add(new LiteralControl(string.Concat(objArray2)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
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
                    object[] num4 = new object[] { "<input type='text' ID='txtBlackChargableRate", num, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ChargeableRate"].ToString()), 4, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", num, "');Calculate_BlackMarkup(this.value,", num, "); />" };
                    controlCollections3.Add(new LiteralControl(string.Concat(num4)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div>"));
                    ControlCollection controls4 = this.plhBlackZone.Controls;
                    object[] valueOnLang = new object[] { "<span id='spn_Black_", num, "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>", this.objlang.GetValueOnLang("Please enter numeric value"), "</span>" };
                    controls4.Add(new LiteralControl(string.Concat(valueOnLang)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    num++;
                }
                if (row["ZoneType"].ToString().ToLower() != "color")
                {
                    continue;
                }
                this.ColourMatrixStartRange = Convert.ToDecimal(row["ZoneFrom"].ToString());
                this.ColourMatrixEndRange = Convert.ToDecimal(row["ZoneTo"].ToString());
                this.ColourCostPrefill = Convert.ToDecimal(row["ChargeableRate"].ToString());
                this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_Color_", num1, "' style='float: left; width: 100%;'>")));
                if (num1 != 1)
                {
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%'><span>&nbsp;</span></div>"));
                }
                else
                {
                    this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div style='float: left; width: 10%;'><span>&nbsp;&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("From"), "</span></div>")));
                }
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%; text-align: right'>"));
                ControlCollection controlCollections4 = this.plhColorZone.Controls;
                object[] objArray4 = new object[] { "<span id='spnColorFrom", num1, "'>", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ZoneFrom"].ToString()), 0, "", true, false, false)), "</span>" };
                controlCollections4.Add(new LiteralControl(string.Concat(objArray4)));
                ControlCollection controls5 = this.plhColorZone.Controls;
                object[] num5 = new object[] { "<input type='text' ID='txtColorFrom", num1, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ZoneFrom"].ToString()), 0, "", true, false, false)), " Style='display: none'/>" };
                controls5.Add(new LiteralControl(string.Concat(num5)));
                ControlCollection controlCollections5 = this.plhColorZone.Controls;
                object[] str1 = new object[] { "<input type='hidden' ID='hid_ColorClickChargeZoneLookupID_", num1, "' value=", row["ClickChargeZoneLookupID"].ToString(), " Style='display:none' />" };
                controlCollections5.Add(new LiteralControl(string.Concat(str1)));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 3%; text-align: center'>"));
                this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<span id='spn_Colour_dash_", num1, "' >-</span>")));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                ControlCollection controls6 = this.plhColorZone.Controls;
                object[] objArray5 = new object[] { "<input type='text' ID='txtColorTo", num1, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ZoneTo"].ToString()), 0, "", true, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='8' onblur= AllowNumber(this,this.value);checkNextCharge(this.value,", num1, ",'color');CallonBlur(this.value,'spn_Color_", num1, "'); />" };
                controls6.Add(new LiteralControl(string.Concat(objArray5)));
                if (num1 == dataTable.Rows.Count / 2)
                {
                    this.plhColorZone.Controls.Add(new LiteralControl("&nbsp;"));
                }
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                ControlCollection controlCollections6 = this.plhColorZone.Controls;
                object[] num6 = new object[] { "<input type='text' ID='txtColorChargableSheets", num1, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ChargeableSheets"].ToString()), 0, "", true, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_", num1, "'); />" };
                controlCollections6.Add(new LiteralControl(string.Concat(num6)));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                ControlCollection controls7 = this.plhColorZone.Controls;
                object[] objArray6 = new object[] { "<input type='text' ID='txtColorCost", num1, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Cost"].ToString()), 4, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_", num1, "');Calculate_ColorChargeableRate(this.value,", num1, ",'cost'); />" };
                controls7.Add(new LiteralControl(string.Concat(objArray6)));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                ControlCollection controlCollections7 = this.plhColorZone.Controls;
                object[] num7 = new object[] { "<input type='text' ID='txtColorMarkup", num1, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 0, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_ColorChargeableRate(this.value,", num1, ",'markup'); />" };
                controlCollections7.Add(new LiteralControl(string.Concat(num7)));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 12%'>"));
                ControlCollection controls8 = this.plhColorZone.Controls;
                object[] objArray7 = new object[] { "<input type='text' ID='txtColorChargableRate", num1, "' value=", Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["ChargeableRate"].ToString()), 4, "", false, false, false)), " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_", num1, "');Calculate_ColorMarkup(this.value,", num1, "); />" };
                controls8.Add(new LiteralControl(string.Concat(objArray7)));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                if (num1 != dataTable.Rows.Count / 2)
                {
                    this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", num1, "' style='float: left;display:none'>")));
                    ControlCollection controlCollections8 = this.plhColorZone.Controls;
                    object[] objArray8 = new object[] { "<img id='imgDeleterow_", num1, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", num1, ");'/>" };
                    controlCollections8.Add(new LiteralControl(string.Concat(objArray8)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                }
                else
                {
                    this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", num1, "' style='float: left;'>")));
                    ControlCollection controls9 = this.plhColorZone.Controls;
                    object[] objArray9 = new object[] { "<img id='imgDeleterow_", num1, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", num1, ");'/>" };
                    controls9.Add(new LiteralControl(string.Concat(objArray9)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("<div>"));
                ControlCollection controlCollections9 = this.plhColorZone.Controls;
                object[] valueOnLang1 = new object[] { "<span id='spn_Color_", num1, "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>", this.objlang.GetValueOnLang("Please enter numeric value"), "</span>" };
                controlCollections9.Add(new LiteralControl(string.Concat(valueOnLang1)));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                num1++;
            }
            this.ItemsCounter = num - 1;
            this.hdnItemscount.Value = this.ItemsCounter.ToString();
            this.BlackMatrixStartRange = Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.BlackMatrixStartRange), 0, "", true, false, false));
            this.BlackMatrixEndRange = Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.BlackMatrixEndRange), 0, "", true, false, false));
            this.ColourMatrixStartRange = Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.ColourMatrixStartRange), 0, "", true, false, false));
            this.ColourMatrixEndRange = Convert.ToDecimal(this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.ColourMatrixEndRange), 0, "", true, false, false));
            this.hdnTotalrowscount.Value = this.ItemsCounter.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_Button1process');");
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            }
            this.Copied_Black_N_White_2_Color_Msg = this.objLanguage.GetLanguageConversion("Copied_Black_N_White_2_Color_Msg");
            this.Label19.Text = string.Concat(this.objLanguage.GetLanguageConversion("SetUp_Charge"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            this.Label20.Text = string.Concat(this.objLanguage.GetLanguageConversion("Minimum_Running_Charge"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnDelete.Text = this.objLanguage.GetLanguageConversion("Delete");
            this.Button2.Text = this.objLanguage.GetLanguageConversion("Next");
            this.Label23.Text = string.Concat(this.objLanguage.GetLanguageConversion("Rate_For_Black_And_White_Chargeable_Sheets"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            Label label2 = this.Label2;
            string[] languageConversion = new string[] { this.objLanguage.GetLanguageConversion("Rate"), " ", this.objLanguage.GetLanguageConversion("For"), " ", this.objpage.GetRegionalSettings(this.CompanyID, "Colour"), " ", this.objLanguage.GetLanguageConversion("Chargeable_Sheets"), " (", this.objcom.GetCurrencyinRequiredFormate("", true), ")" };
            label2.Text = string.Concat(languageConversion);
            this.Label3.Text = this.objLanguage.GetLanguageConversion("Number_Of_Chargeable_Sheets");
            this.Label1.Text = string.Concat(this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)");
            this.Label31.Text = this.objLanguage.GetLanguageConversion("Pages_Per_Minute");
            this.Button20.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.Button22.Text = this.objLanguage.GetLanguageConversion("Save");
            this.chkBlackFlattenClick.Text = this.objLanguage.GetLanguageConversion("Check_This_Box_To_Flatten_The_Click_Charge_Click_Zones");
            this.chkBlackSumClick.Text = this.objLanguage.GetLanguageConversion("Check_This_Box_To_Sum_The_Click_Charge_Rate_Click_Zones");
            this.Button22.Attributes.Add("onclick", "javascript:var a=FinalSave();if(a)loadingimg('div_btnsave','div_btnsaveprocess');return a;");
            this.divDelete.Visible = false;
            this.gloobj.setpagename("setting");
            this.txtDigitalPressName.Focus();
            if (this.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            }
            this.paperType = this.objcom.settings_paperMeasurementType(this.CompanyID);
            this.ItemsCounter = SettingsBasePage.DigitalPressMatrixCounter_Select((long)this.CompanyID);
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            this.paperWeight = base.SpecialDecode(dataTable.Rows[0]["Weight"].ToString());
            this.Label30.Text = base.SpecialDecode(this.paperWeight);
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
            this.lblMaxImgHeight.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblMaxImgWidth.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblMaxSheetWeight.Text = this.objpage.GetRegionalSettings(this.CompanyID, "Weight");
            this.lblPrintHeight.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblPrintWidth.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblGutterHor.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblGutterVer.Text = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            SettingsBasePage settingsBasePage = new SettingsBasePage();
            if (!base.IsPostBack)
            {
                settingsBasePage.Bind_PaperSize(this.ddlPrintSheetSize, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                settingsBasePage.Bind_PaperSize(this.ddlJobSize, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                SettingsBasePage.Guillotine_Bind(this.ddlGuillotine, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                this.ddlMethod.SelectedIndex = 1;
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = false;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"));
                }
                if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "add")
                {
                    DataTable dataTable1 = this.objInv.warehouse_inventory_selectall(this.CompanyID, "paper", "");
                    if (dataTable1.Rows.Count > 0)
                    {
                        string str = dataTable1.Rows[0].Table.Rows[0].ItemArray[3].ToString();
                        this.lblDefaultPaper.Text = str;
                        this.lblDefaultPaper.ToolTip = str;
                        string str1 = dataTable1.Rows[0].Table.Rows[0].ItemArray[0].ToString();
                        this.hdnpaperID.Value = str1;
                    }
                }
            }
            this.BlackMatrixStartRange = new decimal(1);
            this.BlackMatrixEndRange = new decimal(50);
            this.BlackCostPrefill = Convert.ToDecimal(0.22);
            this.ColourMatrixStartRange = new decimal(1);
            this.ColourMatrixEndRange = new decimal(50);
            this.ColourCostPrefill = Convert.ToDecimal(0.22);
            if (base.Request.Params["type"] != null)
            {
                this.ReqType = base.Request.Params["type"].ToString().ToLower();
            }
            if (this.ReqType != "edit")
            {
                for (int i = 1; i <= this.ItemsCounter; i++)
                {
                    this.plhBlackZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_Black_", i, "' style='float: left; width: 100%;'>")));
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
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%;'>"));
                    ControlCollection controls2 = this.plhBlackZone.Controls;
                    object[] objArray2 = new object[] { "<input type='text' ID='txtBlackChargableSheets", i, "' value=", 1, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", i, "'); />" };
                    controls2.Add(new LiteralControl(string.Concat(objArray2)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                    ControlCollection controlCollections2 = this.plhBlackZone.Controls;
                    object[] blackCostPrefill = new object[] { "<input type='text' ID='txtBlackCost", i, "' value=", this.BlackCostPrefill, "00 Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", i, "');Calculate_BlackChargeableRate(this.value,", i, ",'cost'); />" };
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
                    object[] blackCostPrefill1 = new object[] { "<input type='text' ID='txtBlackChargableRate", i, "' value=", this.BlackCostPrefill, "00 Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_", i, "');Calculate_BlackMarkup(this.value,", i, "); />" };
                    controlCollections3.Add(new LiteralControl(string.Concat(blackCostPrefill1)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("<div>"));
                    ControlCollection controls4 = this.plhBlackZone.Controls;
                    object[] valueOnLang = new object[] { "<span id='spn_Black_", i, "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>", this.objlang.GetValueOnLang("Please enter numeric value"), "</span>" };
                    controls4.Add(new LiteralControl(string.Concat(valueOnLang)));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhBlackZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_Color_", i, "' style='float: left; width: 100%;'>")));
                    if (i != 1)
                    {
                        this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%'><span>&nbsp;</span></div>"));
                    }
                    else
                    {
                        this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div style='float: left; width: 10%;'><span>&nbsp;&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("From"), "</span></div>")));
                    }
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 10%; text-align: right'>"));
                    ControlCollection controlCollections4 = this.plhColorZone.Controls;
                    object[] colourMatrixStartRange = new object[] { "<span id='spnColorFrom", i, "'>", this.ColourMatrixStartRange, "</span>" };
                    controlCollections4.Add(new LiteralControl(string.Concat(colourMatrixStartRange)));
                    ControlCollection controls5 = this.plhColorZone.Controls;
                    object[] colourMatrixStartRange1 = new object[] { "<input type='text' ID='txtColorFrom", i, "' value=", this.ColourMatrixStartRange, " Style='display: none'/>" };
                    controls5.Add(new LiteralControl(string.Concat(colourMatrixStartRange1)));
                    ControlCollection controlCollections5 = this.plhColorZone.Controls;
                    object[] objArray4 = new object[] { "<input type='hidden' ID='hid_ColorClickChargeZoneLookupID_", i, "' value=", 0, " Style='display:none' />" };
                    controlCollections5.Add(new LiteralControl(string.Concat(objArray4)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 3%; text-align: center'>"));
                    this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<span id='spn_Colour_dash_", i, "' >-</span>")));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                    ControlCollection controls6 = this.plhColorZone.Controls;
                    object[] colourMatrixEndRange = new object[] { "<input type='text' ID='txtColorTo", i, "' value=", this.ColourMatrixEndRange, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='8' onblur= AllowNumber(this,this.value);checkNextCharge(this.value,", i, ",'color');CallonBlur(this.value,'spn_Color_", i, "'); />" };
                    controls6.Add(new LiteralControl(string.Concat(colourMatrixEndRange)));
                    if (i == this.ItemsCounter)
                    {
                        this.plhColorZone.Controls.Add(new LiteralControl("&nbsp;"));
                    }
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                    ControlCollection controlCollections6 = this.plhColorZone.Controls;
                    object[] objArray5 = new object[] { "<input type='text' ID='txtColorChargableSheets", i, "' value=", 1, " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_", i, "'); />" };
                    controlCollections6.Add(new LiteralControl(string.Concat(objArray5)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                    ControlCollection controls7 = this.plhColorZone.Controls;
                    object[] colourCostPrefill = new object[] { "<input type='text' ID='txtColorCost", i, "' value=", this.ColourCostPrefill, "00 Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_", i, "');Calculate_ColorChargeableRate(this.value,", i, ",'cost'); />" };
                    controls7.Add(new LiteralControl(string.Concat(colourCostPrefill)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 15%'>"));
                    if (i != 1)
                    {
                        ControlCollection controlCollections7 = this.plhColorZone.Controls;
                        object[] objArray6 = new object[] { "<input type='text' ID='txtColorMarkup", i, "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_ColorChargeableRate(this.value,", i, ",'markup'); />" };
                        controlCollections7.Add(new LiteralControl(string.Concat(objArray6)));
                    }
                    else
                    {
                        this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<input type='text' ID='txtColorMarkup", i, "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);SetColorMarkupToAll(this); />")));
                    }
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='float: left; width: 12%'>"));
                    ControlCollection controls8 = this.plhColorZone.Controls;
                    object[] colourCostPrefill1 = new object[] { "<input type='text' ID='txtColorChargableRate", i, "' value=", this.ColourCostPrefill, "00 Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_", i, "');Calculate_ColorMarkup(this.value,", i, "); />" };
                    controls8.Add(new LiteralControl(string.Concat(colourCostPrefill1)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    if (i != this.ItemsCounter)
                    {
                        this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", i, "' style='float: left;display:none'>")));
                        ControlCollection controlCollections8 = this.plhColorZone.Controls;
                        object[] objArray7 = new object[] { "<img id='imgDeleterow_", i, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", i, ");'/>" };
                        controlCollections8.Add(new LiteralControl(string.Concat(objArray7)));
                        this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        this.plhColorZone.Controls.Add(new LiteralControl(string.Concat("<div id='div_imgDeleterow_", i, "' style='float: left;'>")));
                        ControlCollection controls9 = this.plhColorZone.Controls;
                        object[] objArray8 = new object[] { "<img id='imgDeleterow_", i, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(", i, ");'/>" };
                        controls9.Add(new LiteralControl(string.Concat(objArray8)));
                        this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='width: 10%; float: left;'>&nbsp;</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div style='width: 3%; float: left;'>&nbsp;</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("<div>"));
                    ControlCollection controlCollections9 = this.plhColorZone.Controls;
                    object[] valueOnLang1 = new object[] { "<span id='spn_Color_", i, "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>", this.objlang.GetValueOnLang("Please enter numeric value"), "</span>" };
                    controlCollections9.Add(new LiteralControl(string.Concat(valueOnLang1)));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    this.plhColorZone.Controls.Add(new LiteralControl("</div>"));
                    if (i >= 3)
                    {
                        this.BlackMatrixStartRange = this.BlackMatrixStartRange + new decimal(100);
                        this.ColourMatrixStartRange = this.ColourMatrixStartRange + new decimal(100);
                    }
                    else
                    {
                        this.BlackMatrixStartRange = this.BlackMatrixStartRange + new decimal(50);
                        this.ColourMatrixStartRange = this.ColourMatrixStartRange + new decimal(50);
                    }
                    if (i != 1)
                    {
                        this.BlackMatrixEndRange = this.BlackMatrixEndRange + new decimal(100);
                        this.ColourMatrixEndRange = this.ColourMatrixEndRange + new decimal(100);
                    }
                    else
                    {
                        this.BlackMatrixEndRange = this.BlackMatrixEndRange + new decimal(50);
                        this.ColourMatrixEndRange = this.ColourMatrixEndRange + new decimal(50);
                    }
                    if (i < 12)
                    {
                        this.BlackCostPrefill = this.BlackCostPrefill - Convert.ToDecimal(0.01);
                        this.ColourCostPrefill = this.ColourCostPrefill - Convert.ToDecimal(0.01);
                    }
                }
                this.BlackMatrixStartRange = this.BlackMatrixStartRange - new decimal(100);
                this.ColourMatrixStartRange = this.ColourMatrixStartRange - new decimal(100);
                this.BlackMatrixEndRange = this.BlackMatrixEndRange - new decimal(100);
                this.ColourMatrixEndRange = this.ColourMatrixEndRange - new decimal(100);
                this.hdnTotalrowscount.Value = this.ItemsCounter.ToString();
            }
            string empty = string.Empty;
            string empty1 = string.Empty;
            long num = (long)0;
            if (base.Request.Params["type"] == null)
            {
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/digital_press_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Digital_Press"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Digital_Press_Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Digital Press Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Digital_Press_Add");
            }
            else if (this.ReqType == "edit" && base.Request.Params["id"] != null)
            {
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/digital_press_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Plant_Presses_Digital_Press"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Digital_Press_Edit")));
                base.Title = this.objLanguage.convert(global.pageTitle("Digital Press Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Digital_Press_Edit");
                this.divDelete.Visible = true;
                this.DigitalPressID = Convert.ToInt64(base.Request.Params["id"].ToString());
                this.btnDelete.Visible = true;
                if (!base.IsPostBack)
                {
                    try
                    {
                        if (this.AccountingCode != "d")
                        {
                            this.div_AccountCode.Visible = false;
                        }
                        else
                        {
                            this.div_AccountCode.Visible = false;
                            this.DigitalPressID = (long)Convert.ToInt32(base.Request.Params["id"].ToString());
                            DropDownList dropDownList = this.ddlAccountCode;
                            int num1 = SettingsBasePage.DigitalPress_AccountingCode_Select((long)this.CompanyID, this.DigitalPressID);
                            dropDownList.SelectedValue = num1.ToString();
                        }
                    }
                    catch
                    {
                    }
                    DataTable dataTable2 = SettingsBasePage.Settings_DigitalPress_Select_By_ID(this.CompanyID, this.DigitalPressID);
                    foreach (DataRow row in dataTable2.Rows)
                    {
                        this.txtDigitalPressName.Text = base.SpecialDecode(row["DigitalPressName"].ToString());
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
                        this.ddlPrintSheetSize.SelectedValue = row["PrintSheetID"].ToString();
                        this.ddlJobSize.SelectedValue = row["JobSizeID"].ToString();
                        this.ddlGuillotine.SelectedValue = row["GuillotineID"].ToString();
                        this.txtSetupCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["SetupCharge"].ToString()), 0, "", false, false, false);
                        this.txtMinRunningCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MinCharge"].ToString()), 0, "", false, false, false);
                        empty = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["MarkUp"].ToString()), 0, "", false, false, false);
                        this.txtUnitOfMeasure.Text = row["UnitOfMeasure"].ToString();
                        if (!string.IsNullOrEmpty(row["InventoryName"].ToString()))
                        {
                            this.lblDefaultPaper.Text = base.SpecialDecode(row["InventoryName"].ToString());
                            this.lblDefaultPaper.ToolTip = base.SpecialDecode(row["InventoryName"].ToString());
                            this.hdnpaperID.Value = row["PaperID"].ToString();
                        }
                        this.chkCalculationType.Checked = Convert.ToBoolean(row["CalculationType"]);
                        empty1 = row["MethodName"].ToString();
                        this.hid_ddlMethodSelected.Value = empty1;
                        num = Convert.ToInt64(row["MethodID"].ToString());
                        this.hid_MethodID.Value = num.ToString();
                        this.pnlddlMethod.Visible = true;
                        if (Convert.ToBoolean(row["IsBlackFlatternClick"]))
                        {
                            this.chkBlackFlattenClick.Checked = true;
                        }
                        if (Convert.ToBoolean(row["IsBlackSumClick"]))
                        {
                            this.chkBlackSumClick.Checked = true;
                        }
                        if (Convert.ToBoolean(row["IsColorFlatternClick"]))
                        {
                            this.chkColorFlattenClick.Checked = true;
                        }
                        if (!Convert.ToBoolean(row["IsColorSumClick"]))
                        {
                            continue;
                        }
                        this.chkColorSumClick.Checked = true;
                    }
                    if (empty1.ToLower() == "clickchargelookup")
                    {
                        this.ddlMethod.SelectedIndex = 1;
                        dataTable2 = SettingsBasePage.Settings_ClickChargeLookup_Select_By_ID(this.CompanyID, num);
                        foreach (DataRow dataRow in dataTable2.Rows)
                        {
                            this.txtBlackChargeableSheets.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["BlackChargeableSheets"].ToString()), 3, "", false, false, true);
                            this.txtColourChargeableSheets.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["ColorChargeableSheets"].ToString()), 3, "", false, false, true);
                            this.txtNoChargeableSheets.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["ChargeableSheets"].ToString()), 0, "", true, false, false);
                        }
                        this.txtMarkUp.Text = empty;
                        return;
                    }
                    if (empty1.ToLower() == "speedweightlookup")
                    {
                        this.ddlMethod.SelectedIndex = 2;
                        dataTable2 = SettingsBasePage.Settings_SpeedWeightLookup_Select_By_ID(this.CompanyID, num);
                        foreach (DataRow row1 in dataTable2.Rows)
                        {
                            this.txtHourlyCharge.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["HourlyCharge"].ToString()), 0, "", false, false, false);
                            this.txtBlackGSM1.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BlackGSM1"].ToString()), 0, "", false, false, false);
                            this.txtBlackPagesPerMinute1.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BlackPagesPerMinute1"].ToString()), 0, "", false, false, false);
                            this.txtBlackGSM2.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BlackGSM2"].ToString()), 0, "", false, false, false);
                            this.txtBlackPagesPerMinute2.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BlackPagesPerMinute2"].ToString()), 0, "", false, false, false);
                            this.txtBlackGSM3.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BlackGSM3"].ToString()), 0, "", false, false, false);
                            this.txtBlackPagesPerMinute3.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["BlackPagesPerMinute3"].ToString()), 0, "", false, false, false);
                            this.txtColorGSM1.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ColorGSM1"].ToString()), 0, "", false, false, false);
                            this.txtColorPagesPerMinute1.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ColorPagesPerMinute1"].ToString()), 0, "", false, false, false);
                            this.txtColorGSM2.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ColorGSM2"].ToString()), 0, "", false, false, false);
                            this.txtColorPagesPerMinute2.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ColorPagesPerMinute2"].ToString()), 0, "", false, false, false);
                            this.txtColorGSM3.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ColorGSM3"].ToString()), 0, "", false, false, false);
                            this.txtColorPagesPerMinute3.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["ColorPagesPerMinute3"].ToString()), 0, "", false, false, false);
                        }
                        this.txtspeedMarkup.Text = empty;
                        return;
                    }
                    if (empty1.ToLower() == "clickchargezonelookup")
                    {
                        this.Load_Click_Charge_Zone();
                        return;
                    }
                }
            }
        }
    }
}