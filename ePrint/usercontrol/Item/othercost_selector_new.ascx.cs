using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.usercontrol.Item
{
    public partial class othercost_selector_new : System.Web.UI.UserControl
    {
        public string strImagepath = global.strimagepath;

        public string strSitepath = global.sitePath();

        private InventoryBasePage objInv = new InventoryBasePage();

        public commonClass OBjJava = new commonClass();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public int CompanyID;

        public int UserID;

        public string CalType = string.Empty;

        public long OtherCostID;

        public long CostTimeBasedID;

        public string ItemType = string.Empty;

        public string Mode = string.Empty;

        public string otherinx = string.Empty;

        public string DefaultHourOrQtyType = string.Empty;

        public string FixedHourOrQty = string.Empty;

        public string VariableHourOrQty = string.Empty;

        public string TimeCostType = string.Empty;

        public string Key = string.Empty;

        public string FormulaTag = string.Empty;

        public long GuillotineID;

        public decimal CostPerCut;

        public long InventoryID;

        public decimal PaperWeight;

        public decimal PaperCaliper;

        public decimal GuillotineMaximumThroat;

        public string GuillotineSheets = string.Empty;

        public string SheetWithNoGutters = string.Empty;

        public string SheetWithGutters = string.Empty;

        private long PressID;

        public string DigiMethodType = string.Empty;

        public string DigiCalculationType = string.Empty;

        public decimal PressHourlyCharge;

        public decimal BlackChargeableRate;

        public decimal ColorChargeableRate;

        public decimal NoOfChargeableSheets;

        public decimal PressSetupCharge;

        public decimal PressMinimumRunningCharge;

        public decimal PressMarkUp;

        public decimal BlackGSM1;

        public decimal BlackPagesPerMinute1;

        public decimal BlackGSM2;

        public decimal BlackPagesPerMinute2;

        public decimal BlackGSM3;

        public decimal BlackPagesPerMinute3;

        public decimal ColorGSM1;

        public decimal ColorPagesPerMinute1;

        public decimal ColorGSM2;

        public decimal ColorPagesPerMinute2;

        public decimal ColorGSM3;

        public decimal ColorPagesPerMinute3;

        public decimal HourlyCharge;

        public string ZoneFrom = string.Empty;

        public string ZoneTo = string.Empty;

        public string ChargeableRate = string.Empty;

        public string ChargeableSheets = string.Empty;

        public string ZoneMarkup = string.Empty;

        public string ColoredZoneFrom = string.Empty;

        public string ColoredZoneTo = string.Empty;

        public string ColoredChargeableRate = string.Empty;

        public string ColoredChargeableSheets = string.Empty;

        public string SectionNo = "0";

        public decimal TotalFirstTrimCuts;

        public decimal InvPaperHeight;

        public decimal InvPaperWidth;

        public decimal PackedIn;

        public decimal PackedPrice;

        public decimal PaperUnitPrice;

        public decimal PaperMarkup;

        public long EstimateItemID;

        public static string EstimateType;

        public long BookletSectionID;

        public decimal Quantity;

        public string qty = string.Empty;

        public string HeightList = string.Empty;

        public string WidthList = string.Empty;

        public string WeightList = string.Empty;

        public string LengthList = string.Empty;

        public string MatrixType = string.Empty;

        private long EstQtyID;

        public decimal NoOfPagesInSection;

        public decimal SetupSpoilage;

        public decimal Partsperset;

        public decimal Setsperpad;

        public decimal RunningSpoilage;

        public decimal PortraitValue;

        public decimal LandscapeValue;

        public decimal ManualValue=0;

        public bool chkPortrait;

        public bool chkLandscape;

        public bool chkGutters;

        public decimal NoOfLeavesPerPad;

        public string ddlColors = string.Empty;

        public bool chkDoubleSided;

        public string SideColor = string.Empty;

        public bool chkFirstTrim;

        public decimal SheetHeight;

        public decimal SheetWidth;

        public string ProductType = string.Empty;

        public string ddlBookletFormat = string.Empty;

        public decimal NoOfSignatures;

        public decimal NoOfSections;

        public static string Qtycount;

        public string Qty1 = string.Empty;

        public string Qty2 = string.Empty;

        public string Qty3 = string.Empty;

        public string Qty4 = string.Empty;

        private string strQtyOutwork = string.Empty;

        private int countwarehouse;

        public string MatrixValue = string.Empty;

        public string pg = string.Empty;

        public int QtyNo;

        public string ModeinOrgionalCase = string.Empty;

        public string EstOtherCostID = string.Empty;

        public string OtherCostPressValues = string.Empty;

        public string OtherCostPressCostExMarkup = string.Empty;

        public string OtherCostPressValuesHourlyCharge = string.Empty;

        public string TotalPagesAllSections = string.Empty;

        public string PaperCostExMarkup = string.Empty;

        public string PaperMarkupPrice = string.Empty;

        public string PrintSheetsAllSections = string.Empty;

        public string PrintSheetsAllSections_ExcludeSpoilage = string.Empty;

        public string PrintSheetsSections1_ExcludeSpoilage = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strTotalLengthRequired = string.Empty;

        public string strTotalAreaRequired = string.Empty;

        public string strcalctype = string.Empty;

        public string strjobheight = string.Empty;

        public string strjobwidth = string.Empty;

        public string PaperMeasure = string.Empty;

        public static bool ForOtherCostFormula;

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

        static othercost_selector_new()
        {
            othercost_selector_new.EstimateType = string.Empty;
            othercost_selector_new.Qtycount = string.Empty;
            othercost_selector_new.ForOtherCostFormula = false;
        }

        public othercost_selector_new()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int num;
            char[] chrArray;
            decimal num1;
            string[] str;
            this.CompanyID = int.Parse(base.Session["companyid"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            othercost_selector_new.ForOtherCostFormula = Convert.ToBoolean(base.Session["ForOtherCostFormula"].ToString().ToLower());
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnRecalculate.Text = this.objLanguage.GetLanguageConversion("Re_Calculate");
            this.btnSaveMatrix.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnAdvanced.Text = string.Concat(this.objLanguage.GetLanguageConversion("Advanced"), " «");
            this.txtFormulaCost.Attributes.Add("style", "text-align:right");
            this.txtFormulaProfit.Attributes.Add("style", "text-align:right");
            this.txtFormulaSellingPrice.Attributes.Add("style", "text-align:right");
            this.txtQtyUnitRate.Attributes.Add("style", "text-align:right");
            this.txtQtyUnitRate1.Attributes.Add("style", "text-align:right");
            this.txtQtyUnitRate2.Attributes.Add("style", "text-align:right");
            this.txtQtyUnitRate3.Attributes.Add("style", "text-align:right");
            this.txtQtyQuantity.Attributes.Add("style", "text-align:right");
            this.txtQtyQuantity1.Attributes.Add("style", "text-align:right");
            this.txtQtyQuantity2.Attributes.Add("style", "text-align:right");
            this.txtQtyQuantity3.Attributes.Add("style", "text-align:right");
            this.txtQtyProfit.Attributes.Add("style", "text-align:right");
            this.txtQtyProfit1.Attributes.Add("style", "text-align:right");
            this.txtQtyProfit2.Attributes.Add("style", "text-align:right");
            this.txtQtyProfit3.Attributes.Add("style", "text-align:right");
            this.txtQtySellingPrice.Attributes.Add("style", "text-align:right");
            this.txtQtySellingPrice1.Attributes.Add("style", "text-align:right");
            this.txtQtySellingPrice2.Attributes.Add("style", "text-align:right");
            this.txtQtySellingPrice3.Attributes.Add("style", "text-align:right");
            this.txtQtySetUpTime.Attributes.Add("style", "text-align:right");
            this.txtQtyHourlyRate.Attributes.Add("style", "text-align:right");
            this.txtHourlyRate.Attributes.Add("style", "text-align:right");
            this.txtSetUpTime.Attributes.Add("style", "text-align:right");
            this.txtHours.Attributes.Add("style", "text-align:right");
            this.txtPasses.Attributes.Add("style", "text-align:right");
            this.txtProfit.Attributes.Add("style", "text-align:right");
            this.txtSellingPrice.Attributes.Add("style", "text-align:right");
            this.txtRunsRequired.Attributes.Add("style", "text-align:right");
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (base.Request.Params["caltype"] != null)
            {
                this.CalType = base.Request.Params["caltype"].ToString().ToLower();
                this.OtherCostID = Convert.ToInt64(base.Request.Params["costid"].ToString());
                this.CostTimeBasedID = Convert.ToInt64(base.Request.Params["costtypeid"].ToString());
                this.ItemType = base.Request.Params["itemtype"].ToString().ToLower();
                this.Mode = base.Request.Params["mode"].ToString().ToLower();
                this.ModeinOrgionalCase = base.Request.Params["mode"].ToString();
                this.otherinx = base.Request.Params["otherinx"].ToString();
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"].ToString());
                othercost_selector_new.EstimateType = base.Request.Params["mainestitemtype"].ToString();
                if (base.Request.Params["estcostid"] != null)
                {
                    this.EstOtherCostID = base.Request.Params["estcostid"].ToString();
                }
                if (othercost_selector_new.EstimateType != "")
                {
                    foreach (DataRow row in EstimatesBasePage.quantity_Select_forOtherCost(this.EstimateItemID, "", (long)0).Rows)
                    {
                        this.Qty1 = row["Qty1"].ToString();
                        this.Qty2 = row["Qty2"].ToString();
                        this.Qty3 = row["Qty3"].ToString();
                        this.Qty4 = row["Qty4"].ToString();
                    }
                    if (this.pg.ToLower() == "job" || this.pg.ToLower() == "invoice")
                    {
                        foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                        {
                            this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                        }
                    }
                    if (this.pg.ToLower() == "order")
                    {
                        this.QtyNo = 1;
                    }
                }
                if (this.ItemType == "m")
                {
                    this.div_btnRecalculate.Style.Add("display", "none");
                }
                if (this.ItemType != "m")
                {
                    this.GuillotineID = Convert.ToInt64(base.Request.Params["glid"].ToString());
                    this.InventoryID = Convert.ToInt64(base.Request.Params["invid"].ToString());
                    this.PressID = Convert.ToInt64(base.Request.Params["prid"].ToString());
                    if (othercost_selector_new.EstimateType == "S" || othercost_selector_new.EstimateType == "F")
                    {
                        this.ProductType = "singleitem";
                    }
                    else if (othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "D")
                    {
                        this.ProductType = "pads";
                    }
                    else if (othercost_selector_new.EstimateType == "N" || othercost_selector_new.EstimateType == "R")
                    {
                        this.ProductType = "ncr";
                        this.BookletSectionID = Convert.ToInt64(base.Request.Params["booksecid"]);
                    }
                    else if (othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "K")
                    {
                        this.ProductType = "booklet";
                        this.BookletSectionID = Convert.ToInt64(base.Request.Params["booksecid"]);
                    }
                    else if (othercost_selector_new.EstimateType == "L")
                    {
                        this.ProductType = "large";
                    }
                    if (othercost_selector_new.EstimateType == "S" || othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "L" || othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "C" || othercost_selector_new.EstimateType == "F" || othercost_selector_new.EstimateType == "D" || othercost_selector_new.EstimateType == "K" || othercost_selector_new.EstimateType == "N" || othercost_selector_new.EstimateType == "R" || othercost_selector_new.EstimateType == "O" || othercost_selector_new.EstimateType == "W" || othercost_selector_new.EstimateType == "U")
                    {
                        string empty = string.Empty;
                        DataTable dataTable = EstimatesBasePage.estimate_othercost_press_details_select((long)this.CompanyID, this.EstimateItemID, othercost_selector_new.EstimateType, this.BookletSectionID);
                        foreach (DataRow row1 in dataTable.Rows)
                        {
                            if (othercost_selector_new.EstimateType == "N")
                            {
                                this.Partsperset = Convert.ToDecimal(row1["NcrPartsPerSet"].ToString());
                                this.Setsperpad = Convert.ToDecimal(row1["NcrSetsPerPad"].ToString());
                            }
                            if (othercost_selector_new.EstimateType == "R")
                            {
                                this.Partsperset = Convert.ToDecimal(row1["NcrPartsPerSet"].ToString());
                                this.Setsperpad = Convert.ToDecimal(row1["NcrSetsPerPad"].ToString());
                                this.NoOfPagesInSection = Convert.ToDecimal(row1["NoOfPagesInSection"].ToString());
                                this.NoOfSections = Convert.ToDecimal(row1["NoOfSections"].ToString());
                                this.NoOfSignatures = Convert.ToDecimal(row1["NoOfSignatures"].ToString());
                                this.TotalPagesAllSections = row1["TotalPagesAllSections"].ToString();
                                this.ddlBookletFormat = (row1["PrintLayout"].ToString() == "P" ? "portrait" : "landscape");
                            }
                            if (othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "K")
                            {
                                this.NoOfPagesInSection = Convert.ToDecimal(row1["NoOfPagesInSection"].ToString());
                                this.NoOfSections = Convert.ToDecimal(row1["NoOfSections"].ToString());
                                this.NoOfSignatures = Convert.ToDecimal(row1["NoOfSignatures"].ToString());
                                this.TotalPagesAllSections = row1["TotalPagesAllSections"].ToString();
                                this.ddlBookletFormat = (row1["PrintLayout"].ToString() == "P" ? "portrait" : "landscape");
                            }
                            if (othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "D")
                            {
                                this.NoOfLeavesPerPad = Convert.ToDecimal(row1["LeavesPerPad"]);
                            }
                            if (othercost_selector_new.EstimateType == "L")
                            {
                                this.strcalctype = row1["CalcType"].ToString();
                                this.strTotalLengthRequired = row1["TotalLengthRequired"].ToString();
                                this.strTotalAreaRequired = row1["TotalAreaRequired"].ToString();
                                this.strjobheight = row1["jobheight"].ToString();
                                this.strjobwidth = row1["jobwidth"].ToString();
                            }
                            if (othercost_selector_new.EstimateType == "S" || othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "F" || othercost_selector_new.EstimateType == "D" || othercost_selector_new.EstimateType == "K" || othercost_selector_new.EstimateType == "N")
                            {
                                this.strjobheight = row1["jobheight"].ToString();
                                this.strjobwidth = row1["jobwidth"].ToString();
                            }
                            if (othercost_selector_new.EstimateType != "C" && othercost_selector_new.EstimateType != "O" && othercost_selector_new.EstimateType != "W" && othercost_selector_new.EstimateType != "U")
                            {
                                this.SetupSpoilage = Convert.ToDecimal(row1["SetupSpoilage"].ToString());
                                this.RunningSpoilage = Convert.ToDecimal(row1["RunningSpoilage"].ToString());
                                this.PortraitValue = Convert.ToDecimal(row1["PortraitValue"].ToString());
                                this.LandscapeValue = Convert.ToDecimal(row1["LandscapeValue"].ToString());                          
                                this.chkPortrait = (row1["PrintLayout"].ToString() == "P" ? true : false);
                                this.chkLandscape = (row1["PrintLayout"].ToString() == "L" ? true : false);
                                this.chkGutters = Convert.ToBoolean(row1["IsIncludeGutters"].ToString());
                                this.ddlColors = row1["Colour"].ToString();
                                this.chkDoubleSided = Convert.ToBoolean(row1["IsDoubleSided"].ToString());
                                this.SideColor = row1["SideColor"].ToString();
                                this.chkFirstTrim = Convert.ToBoolean(row1["IsFirstTrim"].ToString());
                                this.SheetHeight = Convert.ToDecimal(row1["SheetHeight"].ToString());
                                this.SheetWidth = Convert.ToDecimal(row1["SheetWidth"].ToString());
                            }
                            if (othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "S" ||  othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "F" || othercost_selector_new.EstimateType == "D" || othercost_selector_new.EstimateType == "N" || othercost_selector_new.EstimateType == "R" || othercost_selector_new.EstimateType == "K")
                            {
                                this.ManualValue = Convert.ToDecimal(row1["ManualValue"].ToString());
                            }
                            else
                            {
                                this.ManualValue = 0;
                            }
                            if (othercost_selector_new.EstimateType != "W")
                            {
                                empty = row1["Qty"].ToString();
                            }
                            else if (this.countwarehouse < 5)
                            {
                                othercost_selector_new usercontrolItemOthercostSelectorNew = this;
                                string str1 = usercontrolItemOthercostSelectorNew.strQtyOutwork;
                                num = Convert.ToInt32(row1["Quantity"]);
                                usercontrolItemOthercostSelectorNew.strQtyOutwork = string.Concat(str1, num.ToString(), "±");
                            }
                            if (othercost_selector_new.EstimateType == "O" || othercost_selector_new.EstimateType == "C")
                            {
                                othercost_selector_new usercontrolItemOthercostSelectorNew1 = this;
                                string str2 = usercontrolItemOthercostSelectorNew1.strQtyOutwork;
                                num = Convert.ToInt32(row1["Quantity"]);
                                usercontrolItemOthercostSelectorNew1.strQtyOutwork = string.Concat(str2, num.ToString(), "±");
                            }
                            if (othercost_selector_new.EstimateType == "C")
                            {
                                othercost_selector_new usercontrolItemOthercostSelectorNew2 = this;
                                usercontrolItemOthercostSelectorNew2.HeightList = string.Concat(usercontrolItemOthercostSelectorNew2.HeightList, row1["height"].ToString(), "§");
                                othercost_selector_new usercontrolItemOthercostSelectorNew3 = this;
                                usercontrolItemOthercostSelectorNew3.WidthList = string.Concat(usercontrolItemOthercostSelectorNew3.WidthList, row1["Width"].ToString(), "§");
                                othercost_selector_new usercontrolItemOthercostSelectorNew4 = this;
                                usercontrolItemOthercostSelectorNew4.WeightList = string.Concat(usercontrolItemOthercostSelectorNew4.WeightList, row1["weight"].ToString(), "§");
                                othercost_selector_new usercontrolItemOthercostSelectorNew5 = this;
                                usercontrolItemOthercostSelectorNew5.LengthList = string.Concat(usercontrolItemOthercostSelectorNew5.LengthList, row1["Length"].ToString(), "§");
                                this.MatrixType = row1["MatrixType"].ToString();
                            }
                            othercost_selector_new usercontrolItemOthercostSelectorNew6 = this;
                            usercontrolItemOthercostSelectorNew6.countwarehouse = usercontrolItemOthercostSelectorNew6.countwarehouse + 1;
                        }
                        if (othercost_selector_new.EstimateType == "S" || othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "L" || othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "F" || othercost_selector_new.EstimateType == "D" || othercost_selector_new.EstimateType == "N" || othercost_selector_new.EstimateType == "R" || othercost_selector_new.EstimateType == "K" || othercost_selector_new.EstimateType == "U")
                        {
                            chrArray = new char[] { '±' };
                            string[] strArrays = empty.Split(chrArray);
                            for (int i = 0; i < (int)strArrays.Length - 1; i++)
                            {
                                string str3 = strArrays[i];
                                chrArray = new char[] { '»' };
                                string[] strArrays1 = str3.Split(chrArray);
                                this.EstQtyID = Convert.ToInt64(strArrays1[0]);
                                if (i == 0)
                                {
                                    this.Quantity = Convert.ToDecimal(strArrays1[1]);
                                }
                                othercost_selector_new usercontrolItemOthercostSelectorNew7 = this;
                                usercontrolItemOthercostSelectorNew7.qty = string.Concat(usercontrolItemOthercostSelectorNew7.qty, strArrays1[1].ToString(), ",");
                            }
                        }
                        if (othercost_selector_new.EstimateType == "O" || othercost_selector_new.EstimateType == "C" || othercost_selector_new.EstimateType == "W")
                        {
                            string str4 = this.strQtyOutwork;
                            chrArray = new char[] { '±' };
                            string[] strArrays2 = str4.Split(chrArray);
                            for (int j = 0; j < (int)strArrays2.Length - 1; j++)
                            {
                                if (j != 0 || !(othercost_selector_new.EstimateType == "W"))
                                {
                                    this.Quantity = Convert.ToDecimal(strArrays2[j]);
                                }
                                else
                                {
                                    this.Quantity = Convert.ToDecimal(strArrays2[j]);
                                }
                                othercost_selector_new usercontrolItemOthercostSelectorNew8 = this;
                                usercontrolItemOthercostSelectorNew8.qty = string.Concat(usercontrolItemOthercostSelectorNew8.qty, this.Quantity, ",");
                            }
                        }
                    }
                }
                else if (this.pg.ToLower() == "estimate")
                {
                    if (base.Request.Params["EstQtyList"].ToString().Trim().Length > 0)
                    {
                        string str5 = base.Request.Params["EstQtyList"].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays3 = str5.Split(chrArray);
                        for (int k = 0; k < (int)strArrays3.Length - 1; k++)
                        {
                            if (k == 0)
                            {
                                this.Quantity = Convert.ToDecimal(strArrays3[k]);
                            }
                            othercost_selector_new usercontrolItemOthercostSelectorNew9 = this;
                            usercontrolItemOthercostSelectorNew9.qty = string.Concat(usercontrolItemOthercostSelectorNew9.qty, strArrays3[k], ",");
                        }
                        this.Qty1 = strArrays3[0].ToString();
                        this.Qty2 = strArrays3[1].ToString();
                        this.Qty3 = strArrays3[2].ToString();
                        this.Qty4 = strArrays3[3].ToString();
                    }
                }
                else if (this.pg.ToLower() == "job" || this.pg.ToLower() == "invoice")
                {
                    if (base.Request.Params["EstQtyList"].ToString().Trim().Length > 0)
                    {
                        string str6 = base.Request.Params["EstQtyList"].ToString();
                        chrArray = new char[] { '~' };
                        string[] strArrays4 = str6.Split(chrArray);
                        for (int k = 0; k < (int)strArrays4.Length - 1; k++)
                        {
                            if (k == 0)
                            {
                                this.Quantity = Convert.ToDecimal(strArrays4[k]);
                            }
                            othercost_selector_new usercontrolItemOthercostSelectorNew9 = this;
                            usercontrolItemOthercostSelectorNew9.qty = string.Concat(usercontrolItemOthercostSelectorNew9.qty, strArrays4[k], ",");
                        }
                        this.Qty1 = strArrays4[0].ToString();
                    }
                    if (this.EstimateItemID != (long)0)
                    {
                        foreach (DataRow dataRow1 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                        {
                            this.QtyNo = Convert.ToInt16(dataRow1["QtyNumber"].ToString());
                        }
                    }
                }
                if (!string.IsNullOrEmpty(this.otherinx))
                {
                    DataTable dataTable1 = EstimateBasePage.Estimate_OtherCost_View_By_EstOtherCostID(this.CompanyID, Convert.ToInt64(base.Request.Params["estcostid"].ToString()));
                    foreach (DataRow row2 in dataTable1.Rows)
                    {
                        this.lblCostName.Text = this.objBase.SpecialDecode(row2["OtherCostName"].ToString());
                        this.lblMinimumCharge.Text = this.OBjJava.GetCurrencyinRequiredFormate(this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["Minimum"].ToString()), 0, "", false, false, false), true);
                        HiddenField hdnMinimumCharge = this.hdn_MinimumCharge;
                        num1 = Convert.ToDecimal(row2["Minimum"].ToString());
                        hdnMinimumCharge.Value = num1.ToString();
                        this.txtProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["Markup"].ToString()), 0, "", false, false, false);
                        this.txtQtyProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["Markup"].ToString()), 0, "", false, false, false);
                        this.txtDescription.Text = row2["Notes"].ToString();
                        this.txtDescription.Style.Add("width", "81%");
                        this.SectionNo = row2["SectionNo"].ToString();
                    }
                }
                else
                {
                    DataTable dataTable2 = SettingsBasePage.settings_othercost_select(this.CompanyID, Convert.ToInt64(base.Request.Params["costid"].ToString()));
                    if (dataTable2 != null)
                    {
                        foreach (DataRow dataRow2 in dataTable2.Rows)
                        {
                            this.lblCostName.Text = this.objBase.SpecialDecode(dataRow2["OtherCostName"].ToString());
                            this.lblMinimumCharge.Text = this.OBjJava.GetCurrencyinRequiredFormate(this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Minimum"].ToString()), 0, "", false, false, false), true);
                            HiddenField hiddenField = this.hdn_MinimumCharge;
                            num1 = Convert.ToDecimal(dataRow2["Minimum"].ToString());
                            hiddenField.Value = num1.ToString();
                            this.txtProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtQtyProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtQtyProfit1.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtQtyProfit2.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtQtyProfit3.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit1.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit2.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit3.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["Profit"].ToString()), 0, "", false, false, false);
                            this.txtDescription.Text = this.objBase.SpecialDecode(dataRow2["Description"].ToString());
                            this.txtDescription.Style.Add("width", "81%");
                        }
                    }
                }
                if (base.Request.Params["caltype"].ToString().ToLower() == "t")
                {
                    DataTable dataTable3 = SettingsBasePage.settings_costtimebased_select(this.CompanyID, Convert.ToInt64(base.Request.Params["costtypeid"].ToString()));
                    foreach (DataRow row3 in dataTable3.Rows)
                    {
                        if (string.IsNullOrEmpty(this.otherinx))
                        {
                            this.txtHourlyRate.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["PerHourCost"].ToString()), 0, "", false, false, false);
                            this.txtSetUpTime.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["MakeReadyTime"].ToString()), 0, "", false, false, false);
                            this.txtHours.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["FixedHours"].ToString()), 0, "", false, false, false);
                            this.hid_HourlySpeed.Value = row3["HourlyRunSpeed"].ToString();
                        }
                        else if (this.ItemType != "m")
                        {
                            this.div_btnRecalculate.Style.Add("display", "block");
                        }
                        this.DefaultHourOrQtyType = row3["DefaultHourType"].ToString();
                        this.FixedHourOrQty = row3["FixedHours"].ToString();
                        this.VariableHourOrQty = row3["VariableHours"].ToString();
                        if(this.pg.ToLower() == "estimate" || this.pg.ToLower() == "job")
                        {
                            if (othercost_selector_new.EstimateType == "S" || othercost_selector_new.EstimateType == "L" || othercost_selector_new.EstimateType == "B" || othercost_selector_new.EstimateType == "P" || othercost_selector_new.EstimateType == "F" || othercost_selector_new.EstimateType == "D" || othercost_selector_new.EstimateType == "K")
                            {
                                if (!string.IsNullOrEmpty(this.VariableHourOrQty) && (this.VariableHourOrQty == "4" || this.VariableHourOrQty == "5"))
                                {
                                    decimal qty = new decimal(0);
                                    decimal qty2 = new decimal(0);
                                    decimal qty3 = new decimal(0);
                                    decimal qty4 = new decimal(0);

                                    decimal width = new decimal(0);
                                    decimal height = new decimal(0);
                                    decimal hourly = new decimal(0);
                                    decimal hourly2 = new decimal(0);
                                    decimal hourly3 = new decimal(0);
                                    decimal hourly4 = new decimal(0);

                                    qty = Convert.ToDecimal(this.Qty1);
                                    DataTable itemTable = new DataTable();
                                    if (othercost_selector_new.EstimateType == "S")
                                    {
                                        itemTable = EstimatesBasePage.single_item_select(this.CompanyID, this.EstimateItemID);
                                    }
                                    else if (othercost_selector_new.EstimateType == "B")
                                    {
                                        itemTable = EstimatesBasePage.estimate_booklet_item_select(this.CompanyID, this.EstimateItemID);

                                    }
                                    else if (othercost_selector_new.EstimateType == "P")
                                    {
                                        itemTable = EstimatesBasePage.estimate_pad_item_select(this.CompanyID, this.EstimateItemID);
                                    }
                                    else if (othercost_selector_new.EstimateType == "L")
                                    {
                                        itemTable = EstimatesBasePage.large_item_select(this.CompanyID, this.EstimateItemID);

                                    }
                                    else if (othercost_selector_new.EstimateType == "F")
                                    {
                                        itemTable = EstimatesBasePage.litho_estimate_select(this.CompanyID, this.EstimateItemID);
                                    }
                                    else if (othercost_selector_new.EstimateType == "D")
                                    {
                                        itemTable = EstimatesBasePage.estimate_litho_pad_item_select(this.CompanyID, this.EstimateItemID);
                                    }
                                    else if (othercost_selector_new.EstimateType == "K")
                                    {
                                        itemTable = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, this.EstimateItemID);
                                    }
                                    foreach (DataRow dr1 in itemTable.Rows)
                                    {
                                        width = Convert.ToDecimal(dr1["JobWidth"].ToString());
                                        height = Convert.ToDecimal(dr1["JobHeight"].ToString());
                                    }
                                    if (this.VariableHourOrQty == "4")
                                    {
                                        hourly = (width * qty) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                        if(!string.IsNullOrEmpty(this.Qty2) && this.Qty2 != "0")
                                        {
                                            qty2 = Convert.ToDecimal(this.Qty2);
                                            hourly2 = (width * qty2) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                            Session["HourlyQty2"] = hourly2;
                                        }
                                        if (!string.IsNullOrEmpty(this.Qty3) && this.Qty3 != "0")
                                        {
                                            qty3 = Convert.ToDecimal(this.Qty3);
                                            hourly3 = (width * qty3) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                            Session["HourlyQty3"] = hourly3;
                                        }
                                        if (!string.IsNullOrEmpty(this.Qty4) && this.Qty4 != "0")
                                        {
                                            qty4 = Convert.ToDecimal(this.Qty4);
                                            hourly4 = (width * qty4) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                            Session["HourlyQty4"] = hourly4;
                                        }


                                    }
                                    else
                                    {
                                        hourly = (height * qty) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                        if (!string.IsNullOrEmpty(this.Qty2) && this.Qty2 != "0")
                                        {
                                            qty2 = Convert.ToDecimal(this.Qty2);
                                            hourly2 = (height * qty2) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                            Session["HourlyQty2"] = hourly2;
                                        }
                                        if (!string.IsNullOrEmpty(this.Qty3) && this.Qty3 != "0")
                                        {
                                            qty3 = Convert.ToDecimal(this.Qty3);
                                            hourly3 = (height * qty3) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                            Session["HourlyQty3"] = hourly3;
                                        }
                                        if (!string.IsNullOrEmpty(this.Qty4) && this.Qty4 != "0")
                                        {
                                            qty4 = Convert.ToDecimal(this.Qty4);
                                            hourly4 = (height * qty4) / Convert.ToDecimal(row3["HourlyRunSpeed"].ToString());
                                            Session["HourlyQty4"] = hourly4;
                                        }
                                    }
                                    this.txtHours.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, hourly, 0, "", false, false, false);

                                }

                            }

                        }
                    }
                }
                else if (base.Request.Params["caltype"].ToString().ToLower() == "q")
                {
                    DataTable dataTable4 = SettingsBasePage.settings_costquantitybased_select(this.CompanyID, Convert.ToInt64(base.Request.Params["costtypeid"].ToString()));
                    foreach (DataRow dataRow3 in dataTable4.Rows)
                    {
                        if (string.IsNullOrEmpty(this.otherinx))
                        {
                            this.txtQtyUnitRate.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["DefaultUnitCost"].ToString()), 0, "", false, false, false);
                            this.txtQtyUnitRate1.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["DefaultUnitCost"].ToString()), 0, "", false, false, false);
                            this.txtQtyUnitRate2.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["DefaultUnitCost"].ToString()), 0, "", false, false, false);
                            this.txtQtyUnitRate3.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["DefaultUnitCost"].ToString()), 0, "", false, false, false);
                            this.txtQtySetUpTime.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["MakeReadyTime"].ToString()), 0, "", false, false, false);
                            this.txtQtyHourlyRate.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRate"].ToString()), 0, "", false, false, false);
                            if (dataRow3["defaultqtytype"].ToString() != "v")
                            {
                                this.txtQtyQuantity.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["FixedQty"].ToString()), 0, "", false, false, false);
                                this.txtQtyQuantity1.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["FixedQty"].ToString()), 0, "", false, false, false);
                                this.txtQtyQuantity2.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["FixedQty"].ToString()), 0, "", false, false, false);
                                this.txtQtyQuantity3.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["FixedQty"].ToString()), 0, "", false, false, false);
                            }
                            this.hid_TimePerUnit.Value = dataRow3["TimePerUnit"].ToString();
                        }
                        else if (this.ItemType != "m")
                        {
                            this.div_btnRecalculate.Style.Add("display", "block");
                        }
                        this.DefaultHourOrQtyType = dataRow3["DefaultQtyType"].ToString();
                        this.FixedHourOrQty = dataRow3["FixedQty"].ToString();
                        this.VariableHourOrQty = dataRow3["VariableQty"].ToString();
                    }
                }
                else if (base.Request.Params["caltype"].ToString().ToLower() == "f" || base.Request.Params["caltype"].ToString().ToLower() == "m")
                {
                    this.div_Description.Attributes.Remove("style");
                    this.div_Description.Attributes.Add("class", "box");
                    this.txtDescription.Style.Add("width", "450px");
                    if (!string.IsNullOrEmpty(this.otherinx))
                    {
                        DataTable dataTable5 = EstimateBasePage.Estimate_OtherCost_View_By_EstOtherCostID(this.CompanyID, Convert.ToInt64(base.Request.Params["estcostid"].ToString()));
                        foreach (DataRow row4 in dataTable5.Rows)
                        {
                            this.txtFormula.Text = this.objBase.SpecialDecode(row4["Formula"].ToString());
                            string str7 = row4["FormulaTag"].ToString();
                            chrArray = new char[] { '\u00B6' };
                            string[] strArrays5 = str7.Split(chrArray);
                            string str8 = row4["FormulaTag1"].ToString();
                            chrArray = new char[] { '\u00B6' };
                            string[] strArrays6 = str8.Split(chrArray);
                            string str9 = row4["FormulaTag2"].ToString();
                            chrArray = new char[] { '\u00B6' };
                            string[] strArrays7 = str9.Split(chrArray);
                            string str10 = row4["FormulaTag3"].ToString();
                            chrArray = new char[] { '\u00B6' };
                            string[] strArrays8 = str10.Split(chrArray);
                            this.txtWithActuals.Text = strArrays5[0].ToString();
                            this.txtWithActuals1.Text = strArrays6[0].ToString();
                            this.txtWithActuals2.Text = strArrays7[0].ToString();
                            this.txtWithActuals3.Text = strArrays8[0].ToString();
                            str = new string[] { strArrays5[0].ToString(), ",", strArrays6[0].ToString(), ",", strArrays7[0].ToString(), ",", strArrays8[0].ToString() };
                            this.MatrixValue = string.Concat(str);
                            this.FormulaTag = strArrays5[1].ToString();
                            this.SectionNo = row4["SectionNo"].ToString();
                            this.txtFormulaProfit.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["Markup"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit1.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["Markup1"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit2.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["Markup2"].ToString()), 0, "", false, false, false);
                            this.txtFormulaProfit3.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["Markup3"].ToString()), 0, "", false, false, false);
                            if (this.ItemType == "m")
                            {
                                continue;
                            }
                            this.div_btnRecalculate.Style.Add("display", "block");
                        }
                    }
                    else
                    {
                        DataTable dataTable6 = SettingsBasePage.settings_costformulabased_select(this.CompanyID, Convert.ToInt64(base.Request.Params["costtypeid"].ToString()));
                        foreach (DataRow dataRow4 in dataTable6.Rows)
                        {
                            this.txtFormula.Text = this.objBase.SpecialDecode(dataRow4["Formula"].ToString());
                            this.FormulaTag = dataRow4["FormulaTag"].ToString();
                        }
                        this.div_btnRecalculate.Style.Add("display", "none");
                    }
                    foreach (DataRow row5 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                    {
                        if (othercost_selector_new.EstimateType == "L")
                        {
                            if (this.PaperMeasure == "In.")
                            {
                                if (row5["Key"].ToString() == "Total Length Required (Meter)")
                                {
                                    row5["Key"] = "Total Length Required (Feet)";
                                }
                                else if (row5["Key"].ToString() == "Total Area Required (Sq.Meter)")
                                {
                                    row5["Key"] = "Total Area Required (Sq.Feet)";
                                }
                                else if (row5["Label"].ToString() == "Large Format Item Area (sq. meter)")
                                {
                                    row5["Key"] = "Large Format Item Area (sq. feet)";
                                }
                                else if (row5["Label"].ToString() == "Large Format Item Width (meter)")
                                {
                                    row5["Key"] = "Large Format Item Width (feet)";
                                }
                                else if (row5["Label"].ToString() == "Large Format Item Height (meter)")
                                {
                                    row5["Key"] = "Large Format Item Height (feet)";
                                }
                            }
                        }
                        else if (othercost_selector_new.EstimateType == "C" && this.PaperMeasure == "In.")
                        {
                            if (row5["Label"].ToString() == "Large Format Item Area (sq. meter)")
                            {
                                row5["Key"] = "Large Format Item Area (sq. feet)";
                            }
                            else if (row5["Label"].ToString() == "Large Format Item Width (meter)")
                            {
                                row5["Key"] = "Large Format Item Width (feet)";
                            }
                            else if (row5["Label"].ToString() == "Large Format Item Height (meter)")
                            {
                                row5["Key"] = "Large Format Item Height (feet)";
                            }
                        }
                        if(row5["Label"].ToString() == "Paper Caliper")
                        {
                            string paperMaterial = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMaterial");
                            row5["Key"] = string.Concat("Paper Caliper"," ","("+paperMaterial+")");
                        }
                        othercost_selector_new usercontrolItemOthercostSelectorNew10 = this;
                        usercontrolItemOthercostSelectorNew10.Key = string.Concat(usercontrolItemOthercostSelectorNew10.Key, row5["Key"].ToString(), "±");
                    }
                    if (base.Request.Params["caltype"].ToString().ToLower() == "m")
                    {
                        foreach (DataRow dataRow5 in SettingsBasePage.settings_othercost_matrix_select(this.CompanyID, this.OtherCostID).Rows)
                        {
                            this.txtCol1.Text = dataRow5["Column1"].ToString();
                            this.txtCol2.Text = dataRow5["Column2"].ToString();
                            this.txtCol3.Text = dataRow5["Column3"].ToString();
                            this.txtCol4.Text = dataRow5["Column4"].ToString();
                            this.txtCol5.Text = dataRow5["Column5"].ToString();
                            this.txtCol6.Text = dataRow5["Column6"].ToString();
                            this.txtCol7.Text = dataRow5["Column7"].ToString();
                            this.txtCol8.Text = dataRow5["Column8"].ToString();
                            this.txtCol9.Text = dataRow5["Column9"].ToString();
                            this.txtCol10.Text = dataRow5["Column10"].ToString();
                            this.txtprompt.Text = dataRow5["Prompt"].ToString();
                            this.hdnMatrixHeadingID.Value = dataRow5["MatrixHeadingID"].ToString();
                        }
                        DataTable dataTable7 = SettingsBasePage.settings_othercost_matrix_value_select(this.CompanyID, Convert.ToInt32(this.hdnMatrixHeadingID.Value));
                        int num2 = 1;
                        int num3 = -1;
                        int num4 = -1;
                        int num5 = -1;
                        int num6 = -1;
                        if (this.Qty1.Trim().Length == 0)
                        {
                            this.Qty1 = "0";
                        }
                        if (this.Qty2.Trim().Length == 0)
                        {
                            this.Qty2 = "0";
                        }
                        if (this.Qty3.Trim().Length == 0)
                        {
                            this.Qty3 = "0";
                        }
                        if (this.Qty4.Trim().Length == 0)
                        {
                            this.Qty4 = "0";
                        }
                        foreach (DataRow row6 in dataTable7.Rows)
                        {
                            TextBox textBox = (TextBox)this.div_table.FindControl(string.Concat("txtFrm", num2.ToString()));
                            textBox.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["RangeFrom"].ToString()), 0, "", true, false, false);
                            if (num2 != 20)
                            {
                                TextBox textBox1 = (TextBox)this.div_table.FindControl(string.Concat("txtTo", num2.ToString()));
                                textBox1.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["RangeTo"].ToString()), 0, "", true, false, false);
                            }
                            if (Convert.ToDecimal(this.Qty1) > new decimal(0) && Convert.ToDecimal(this.Qty1) >= Convert.ToDecimal(row6["RangeFrom"].ToString()) && Convert.ToDecimal(this.Qty1) <= Convert.ToDecimal(row6["RangeTo"].ToString()))
                            {
                                num3 = num2 - 1;
                            }
                            if (Convert.ToDecimal(this.Qty2) > new decimal(0) && Convert.ToDecimal(this.Qty2) >= Convert.ToDecimal(row6["RangeFrom"].ToString()) && Convert.ToDecimal(this.Qty2) <= Convert.ToDecimal(row6["RangeTo"].ToString()))
                            {
                                num4 = num2 - 1;
                            }
                            if (Convert.ToDecimal(this.Qty3) > new decimal(0) && Convert.ToDecimal(this.Qty3) >= Convert.ToDecimal(row6["RangeFrom"].ToString()) && Convert.ToDecimal(this.Qty3) <= Convert.ToDecimal(row6["RangeTo"].ToString()))
                            {
                                num5 = num2 - 1;
                            }
                            if (Convert.ToDecimal(this.Qty4) > new decimal(0) && Convert.ToDecimal(this.Qty4) >= Convert.ToDecimal(row6["RangeFrom"].ToString()) && Convert.ToDecimal(this.Qty4) <= Convert.ToDecimal(row6["RangeTo"].ToString()))
                            {
                                num6 = num2 - 1;
                            }
                            TextBox textBox2 = (TextBox)this.div_table.FindControl(string.Concat("txtA5", num2.ToString()));
                            textBox2.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column1"].ToString()), 3, "", false, false, false);
                            TextBox textBox3 = (TextBox)this.div_table.FindControl(string.Concat("txtA4", num2.ToString()));
                            textBox3.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column2"].ToString()), 3, "", false, false, false);
                            TextBox textBox4 = (TextBox)this.div_table.FindControl(string.Concat("txtA3", num2.ToString()));
                            textBox4.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column3"].ToString()), 3, "", false, false, false);
                            TextBox textBox5 = (TextBox)this.div_table.FindControl(string.Concat("txtA2", num2.ToString()));
                            textBox5.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column4"].ToString()), 3, "", false, false, false);
                            TextBox textBox6 = (TextBox)this.div_table.FindControl(string.Concat("txtA6", num2.ToString()));
                            textBox6.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column5"].ToString()), 3, "", false, false, false);
                            TextBox textBox7 = (TextBox)this.div_table.FindControl(string.Concat("txtA7", num2.ToString()));
                            textBox7.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column6"].ToString()), 3, "", false, false, false);
                            TextBox textBox8 = (TextBox)this.div_table.FindControl(string.Concat("txtA8", num2.ToString()));
                            textBox8.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column7"].ToString()), 3, "", false, false, false);
                            TextBox textBox9 = (TextBox)this.div_table.FindControl(string.Concat("txtA9", num2.ToString()));
                            textBox9.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column8"].ToString()), 3, "", false, false, false);
                            TextBox textBox10 = (TextBox)this.div_table.FindControl(string.Concat("txtA10", num2.ToString()));
                            textBox10.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column9"].ToString()), 3, "", false, false, false);
                            TextBox textBox11 = (TextBox)this.div_table.FindControl(string.Concat("txtA11", num2.ToString()));
                            textBox11.Text = this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row6["Column10"].ToString()), 3, "", false, false, false);
                            this.hdnMatrixValueID.Value = string.Concat(this.hdnMatrixValueID.Value, row6["MatrixValueID"].ToString(), "+");
                            if (Convert.ToDecimal(textBox2.Text) == new decimal(0) && Convert.ToDecimal(textBox3.Text) == new decimal(0) && Convert.ToDecimal(textBox4.Text) == new decimal(0) && Convert.ToDecimal(textBox5.Text) == new decimal(0) && Convert.ToDecimal(textBox6.Text) == new decimal(0) && Convert.ToDecimal(textBox7.Text) == new decimal(0) && Convert.ToDecimal(textBox8.Text) == new decimal(0) && Convert.ToDecimal(textBox9.Text) == new decimal(0) && Convert.ToDecimal(textBox10.Text) == new decimal(0) && Convert.ToDecimal(textBox11.Text) == new decimal(0))
                            {
                                if (num2 == 1)
                                {
                                    this.tr1.Visible = false;
                                }
                                else if (num2 == 2)
                                {
                                    this.tr2.Visible = false;
                                }
                                else if (num2 == 3)
                                {
                                    this.tr3.Visible = false;
                                }
                                else if (num2 == 4)
                                {
                                    this.tr4.Visible = false;
                                }
                                else if (num2 == 5)
                                {
                                    this.tr5.Visible = false;
                                }
                                else if (num2 == 6)
                                {
                                    this.tr6.Visible = false;
                                }
                                else if (num2 == 7)
                                {
                                    this.tr7.Visible = false;
                                }
                                else if (num2 == 8)
                                {
                                    this.tr8.Visible = false;
                                }
                                else if (num2 == 9)
                                {
                                    this.tr9.Visible = false;
                                }
                                else if (num2 == 10)
                                {
                                    this.tr10.Visible = false;
                                }
                                else if (num2 == 11)
                                {
                                    this.tr11.Visible = false;
                                }
                                else if (num2 == 12)
                                {
                                    this.tr12.Visible = false;
                                }
                                else if (num2 == 13)
                                {
                                    this.tr13.Visible = false;
                                }
                                else if (num2 == 14)
                                {
                                    this.tr14.Visible = false;
                                }
                                else if (num2 == 15)
                                {
                                    this.tr15.Visible = false;
                                }
                                else if (num2 == 16)
                                {
                                    this.tr16.Visible = false;
                                }
                                else if (num2 == 17)
                                {
                                    this.tr17.Visible = false;
                                }
                                else if (num2 == 18)
                                {
                                    this.tr18.Visible = false;
                                }
                                else if (num2 == 19)
                                {
                                    this.tr19.Visible = false;
                                }
                                else if (num2 == 20)
                                {
                                    this.tr20.Visible = false;
                                }
                            }
                            num2++;
                        }
                        for (int l = 1; l < 11; l++)
                        {
                            TextBox textBox12 = (TextBox)this.div_table.FindControl(string.Concat("txtcol", l.ToString()));
                            string str11 = string.Concat(string.Concat((num3.ToString() != "-1" ? this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[num3][string.Concat("Column", l)]), 3, "", false, false, false) : "0"), ","), (num4.ToString() != "-1" ? this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[num4][string.Concat("Column", l)]), 3, "", false, false, false) : "0"));
                            str11 = string.Concat(string.Concat(str11, ","), (num5.ToString() != "-1" ? this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[num5][string.Concat("Column", l)]), 3, "", false, false, false) : "0"));
                            str11 = string.Concat(string.Concat(str11, ","), (num6.ToString() != "-1" ? this.OBjJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable7.Rows[num6][string.Concat("Column", l)]), 3, "", false, false, false) : "0"));
                            textBox12.Attributes.Add("onclick", string.Concat("AssignMatrixValues('", str11, "')"));
                        }
                    }
                    long num7 = (long)0;
                    foreach (DataRow dataRow6 in SettingsBasePage.Settings_DigitalPress_Select_By_ID(this.CompanyID, this.PressID).Rows)
                    {
                        this.DigiMethodType = dataRow6["MethodName"].ToString().Trim().ToLower();
                        num7 = (long)Convert.ToInt32(dataRow6["MethodID"].ToString());
                        this.PressSetupCharge = Convert.ToDecimal(dataRow6["SetupCharge"]);
                        this.PressMinimumRunningCharge = Convert.ToDecimal(dataRow6["MinCharge"]);
                        this.PressMarkUp = Convert.ToDecimal(dataRow6["MarkUp"]);
                        this.DigiCalculationType = dataRow6["CalculationType"].ToString();
                    }
                    if (this.DigiMethodType == "clickchargelookup")
                    {
                        foreach (DataRow row7 in SettingsBasePage.Settings_ClickChargeLookup_Select_By_ID(this.CompanyID, num7).Rows)
                        {
                            this.BlackChargeableRate = Convert.ToDecimal(row7["BlackChargeableSheets"]);
                            this.ColorChargeableRate = Convert.ToDecimal(row7["ColorChargeableSheets"]);
                            this.NoOfChargeableSheets = Convert.ToDecimal(row7["ChargeableSheets"]);
                        }
                    }
                    else if (this.DigiMethodType == "speedweightlookup")
                    {
                        foreach (DataRow dataRow7 in SettingsBasePage.Settings_SpeedWeightLookup_Select_By_ID(this.CompanyID, num7).Rows)
                        {
                            decimal num8 = Convert.ToDecimal(dataRow7["HourlyCharge"]);
                            num1 = num8;
                            this.HourlyCharge = num8;
                            this.PressHourlyCharge = num1;
                            this.BlackGSM1 = Convert.ToDecimal(dataRow7["BlackGSM1"]);
                            this.BlackPagesPerMinute1 = Convert.ToDecimal(dataRow7["BlackPagesPerMinute1"]);
                            this.BlackGSM2 = Convert.ToDecimal(dataRow7["BlackGSM2"]);
                            this.BlackPagesPerMinute2 = Convert.ToDecimal(dataRow7["BlackPagesPerMinute2"]);
                            this.BlackGSM3 = Convert.ToDecimal(dataRow7["BlackGSM3"]);
                            this.BlackPagesPerMinute3 = Convert.ToDecimal(dataRow7["BlackPagesPerMinute3"]);
                            this.ColorGSM1 = Convert.ToDecimal(dataRow7["ColorGSM1"]);
                            this.ColorPagesPerMinute1 = Convert.ToDecimal(dataRow7["ColorPagesPerMinute1"]);
                            this.ColorGSM2 = Convert.ToDecimal(dataRow7["ColorGSM2"]);
                            this.ColorPagesPerMinute2 = Convert.ToDecimal(dataRow7["ColorPagesPerMinute2"]);
                            this.ColorGSM3 = Convert.ToDecimal(dataRow7["ColorGSM3"]);
                            this.ColorPagesPerMinute3 = Convert.ToDecimal(dataRow7["ColorPagesPerMinute3"]);
                        }
                    }
                    else if (this.DigiMethodType == "clickchargezonelookup")
                    {
                        foreach (DataRow row8 in SettingsBasePage.Settings_ClickChargeZoneLookup_Select_By_ID(this.CompanyID, this.PressID).Rows)
                        {
                            if (string.Compare(row8["ZoneType"].ToString(), "black", true) != 0)
                            {
                                if (string.Compare(row8["ZoneType"].ToString(), "color", true) != 0)
                                {
                                    continue;
                                }
                                othercost_selector_new usercontrolItemOthercostSelectorNew11 = this;
                                usercontrolItemOthercostSelectorNew11.ColoredZoneFrom = string.Concat(usercontrolItemOthercostSelectorNew11.ColoredZoneFrom, row8["ZoneFrom"].ToString(), "±");
                                othercost_selector_new usercontrolItemOthercostSelectorNew12 = this;
                                usercontrolItemOthercostSelectorNew12.ColoredZoneTo = string.Concat(usercontrolItemOthercostSelectorNew12.ColoredZoneTo, row8["ZoneTo"].ToString(), "±");
                                othercost_selector_new usercontrolItemOthercostSelectorNew13 = this;
                                usercontrolItemOthercostSelectorNew13.ColoredChargeableRate = string.Concat(usercontrolItemOthercostSelectorNew13.ColoredChargeableRate, row8["ChargeableRate"].ToString(), "±");
                                othercost_selector_new usercontrolItemOthercostSelectorNew14 = this;
                                usercontrolItemOthercostSelectorNew14.ColoredChargeableSheets = string.Concat(usercontrolItemOthercostSelectorNew14.ColoredChargeableSheets, row8["ChargeableSheets"].ToString(), "±");
                                double num9 = 0;
                                if (Convert.ToDouble(row8["Cost"]) > 0)
                                {
                                    num9 = Convert.ToDouble(row8["ChargeableRate"]) / Convert.ToDouble(row8["Cost"]) * 100;
                                }
                                othercost_selector_new usercontrolItemOthercostSelectorNew15 = this;
                                usercontrolItemOthercostSelectorNew15.ZoneMarkup = string.Concat(usercontrolItemOthercostSelectorNew15.ZoneMarkup, num9.ToString(), "±");
                            }
                            else
                            {
                                othercost_selector_new usercontrolItemOthercostSelectorNew16 = this;
                                usercontrolItemOthercostSelectorNew16.ZoneFrom = string.Concat(usercontrolItemOthercostSelectorNew16.ZoneFrom, row8["ZoneFrom"].ToString(), "±");
                                othercost_selector_new usercontrolItemOthercostSelectorNew17 = this;
                                usercontrolItemOthercostSelectorNew17.ZoneTo = string.Concat(usercontrolItemOthercostSelectorNew17.ZoneTo, row8["ZoneTo"].ToString(), "±");
                                othercost_selector_new usercontrolItemOthercostSelectorNew18 = this;
                                usercontrolItemOthercostSelectorNew18.ChargeableRate = string.Concat(usercontrolItemOthercostSelectorNew18.ChargeableRate, row8["ChargeableRate"].ToString(), "±");
                                othercost_selector_new usercontrolItemOthercostSelectorNew19 = this;
                                usercontrolItemOthercostSelectorNew19.ChargeableSheets = string.Concat(usercontrolItemOthercostSelectorNew19.ChargeableSheets, row8["ChargeableSheets"].ToString(), "±");
                                double num10 = 0;
                                if (Convert.ToDouble(row8["Cost"]) > 0)
                                {
                                    num10 = Convert.ToDouble(row8["ChargeableRate"]) / Convert.ToDouble(row8["Cost"]) * 100;
                                }
                                othercost_selector_new usercontrolItemOthercostSelectorNew20 = this;
                                usercontrolItemOthercostSelectorNew20.ZoneMarkup = string.Concat(usercontrolItemOthercostSelectorNew20.ZoneMarkup, num10.ToString(), "±");
                            }
                        }
                    }
                    foreach (DataRow dataRow8 in EstimateBasePage.estimate_guillotine_standard_table_selectall(this.CompanyID).Rows)
                    {
                        othercost_selector_new usercontrolItemOthercostSelectorNew21 = this;
                        usercontrolItemOthercostSelectorNew21.GuillotineSheets = string.Concat(usercontrolItemOthercostSelectorNew21.GuillotineSheets, Convert.ToDecimal(dataRow8["Sheet"].ToString()), "±");
                        othercost_selector_new usercontrolItemOthercostSelectorNew22 = this;
                        usercontrolItemOthercostSelectorNew22.SheetWithNoGutters = string.Concat(usercontrolItemOthercostSelectorNew22.SheetWithNoGutters, Convert.ToDecimal(dataRow8["NoGutters"].ToString()), "±");
                        othercost_selector_new usercontrolItemOthercostSelectorNew23 = this;
                        usercontrolItemOthercostSelectorNew23.SheetWithGutters = string.Concat(usercontrolItemOthercostSelectorNew23.SheetWithGutters, Convert.ToDecimal(dataRow8["WithGutters"].ToString()), "±");
                    }
                    DataTable dataTable8 = this.objInv.warehouse_inventoryproperties_select(this.CompanyID, this.InventoryID);
                    if (this.InventoryID > (long)0)
                    {
                        foreach (DataRow row9 in dataTable8.Rows)
                        {
                            this.PaperWeight = Convert.ToDecimal(row9["BasisWeight"]);
                            this.PaperCaliper = Convert.ToDecimal(row9["Caliper"]);
                            this.InvPaperHeight = Convert.ToDecimal(row9["Height"]);
                            this.InvPaperWidth = Convert.ToDecimal(row9["Width"]);
                            this.PackedIn = Convert.ToDecimal(row9["PackedIn"]);
                            this.PackedPrice = Convert.ToDecimal(row9["PackedPrice"]);
                            this.PaperUnitPrice = Convert.ToDecimal(row9["PaperUnitPrice"]);
                            this.PaperMarkup = Convert.ToDecimal(row9["PaperMarkup"]);
                        }
                    }
                    foreach (DataRow dataRow9 in SettingsBasePage.Settings_Guillotine_Select_By_ID(this.CompanyID, this.GuillotineID).Rows)
                    {
                        this.CostPerCut = Convert.ToDecimal(dataRow9["CostPerCut"].ToString());
                        decimal num11 = Convert.ToDecimal(dataRow9["PaperWeight1"].ToString());
                        decimal num12 = Convert.ToDecimal(dataRow9["PaperWeight2"].ToString());
                        decimal num13 = Convert.ToDecimal(dataRow9["PaperWeight3"].ToString());
                        decimal num14 = Convert.ToDecimal(dataRow9["MaxSheets1"].ToString());
                        decimal num15 = Convert.ToDecimal(dataRow9["MaxSheets2"].ToString());
                        decimal num16 = Convert.ToDecimal(dataRow9["MaxSheets3"].ToString());
                        if (this.PaperWeight <= num11)
                        {
                            this.GuillotineMaximumThroat = num14;
                        }
                        else if (this.PaperWeight > num12)
                        {
                            if (!(this.PaperWeight <= num13) && !(this.PaperWeight > num13))
                            {
                                continue;
                            }
                            this.GuillotineMaximumThroat = num16;
                        }
                        else
                        {
                            this.GuillotineMaximumThroat = num15;
                        }
                    }
                }
            }
            foreach (DataRow row10 in this.PCR_estimate_OtherCost_GetAllRequiredValue(this.EstimateItemID).Rows)
            {
                str = new string[] { row10["PressSellingPrice1"].ToString(), "~", row10["PressSellingPrice2"].ToString(), "~", row10["PressSellingPrice3"].ToString(), "~", row10["PressSellingPrice4"].ToString() };
                this.OtherCostPressValues = string.Concat(str);
                str = new string[] { row10["PressCostExMarkup1"].ToString(), "~", row10["PressCostExMarkup2"].ToString(), "~", row10["PressCostExMarkup3"].ToString(), "~", row10["PressCostExMarkup4"].ToString() };
                this.OtherCostPressCostExMarkup = string.Concat(str);
                str = new string[] { row10["HourlyCharge"].ToString(), "~", row10["HourlyCharge"].ToString(), "~", row10["HourlyCharge"].ToString(), "~", row10["HourlyCharge"].ToString() };
                this.OtherCostPressValuesHourlyCharge = string.Concat(str);
                str = new string[] { row10["PaperCostExMarkup1"].ToString(), "~", row10["PaperCostExMarkup2"].ToString(), "~", row10["PaperCostExMarkup3"].ToString(), "~", row10["PaperCostExMarkup4"].ToString() };
                this.PaperCostExMarkup = string.Concat(str);
                str = new string[] { row10["PaperMarkupPrice1"].ToString(), "~", row10["PaperMarkupPrice2"].ToString(), "~", row10["PaperMarkupPrice3"].ToString(), "~", row10["PaperMarkupPrice4"].ToString() };
                this.PaperMarkupPrice = string.Concat(str);
                str = new string[] { row10["PrintSheets1AllSections"].ToString(), "~", row10["PrintSheets2AllSections"].ToString(), "~", row10["PrintSheets3AllSections"].ToString(), "~", row10["PrintSheets4AllSections"].ToString() };
                this.PrintSheetsAllSections = string.Concat(str);
                str = new string[] { row10["PrintSheetQty_ExcludeSpoilage1"].ToString(), "~", row10["PrintSheetQty_ExcludeSpoilage2"].ToString(), "~", row10["PrintSheetQty_ExcludeSpoilage3"].ToString(), "~", row10["PrintSheetQty_ExcludeSpoilage4"].ToString() };
                this.PrintSheetsAllSections_ExcludeSpoilage = string.Concat(str);
            }
            ///////////////////////Code added by Amin/////////////////////////////
            foreach (DataRow row10 in this.PCR_estimate_OtherCost_GetAllRequiredValue_Section1(this.EstimateItemID).Rows)
            {
                //str = new string[] { row10["PressSellingPrice1"].ToString(), "~", row10["PressSellingPrice2"].ToString(), "~", row10["PressSellingPrice3"].ToString(), "~", row10["PressSellingPrice4"].ToString() };
                //this.OtherCostPressValues = string.Concat(str);
                //str = new string[] { row10["PressCostExMarkup1"].ToString(), "~", row10["PressCostExMarkup2"].ToString(), "~", row10["PressCostExMarkup3"].ToString(), "~", row10["PressCostExMarkup4"].ToString() };
                //this.OtherCostPressCostExMarkup = string.Concat(str);
                //str = new string[] { row10["HourlyCharge"].ToString(), "~", row10["HourlyCharge"].ToString(), "~", row10["HourlyCharge"].ToString(), "~", row10["HourlyCharge"].ToString() };
                //this.OtherCostPressValuesHourlyCharge = string.Concat(str);
                //str = new string[] { row10["PaperCostExMarkup1"].ToString(), "~", row10["PaperCostExMarkup2"].ToString(), "~", row10["PaperCostExMarkup3"].ToString(), "~", row10["PaperCostExMarkup4"].ToString() };
                //this.PaperCostExMarkup = string.Concat(str);
                //str = new string[] { row10["PaperMarkupPrice1"].ToString(), "~", row10["PaperMarkupPrice2"].ToString(), "~", row10["PaperMarkupPrice3"].ToString(), "~", row10["PaperMarkupPrice4"].ToString() };
                //this.PaperMarkupPrice = string.Concat(str);
                //str = new string[] { row10["PrintSheets1AllSections"].ToString(), "~", row10["PrintSheets2AllSections"].ToString(), "~", row10["PrintSheets3AllSections"].ToString(), "~", row10["PrintSheets4AllSections"].ToString() };
                //this.PrintSheetsAllSections = string.Concat(str);
                str = new string[] { row10["PrintSheets1"].ToString(), "~", row10["PrintSheets2"].ToString(), "~", row10["PrintSheets3"].ToString(), "~", row10["PrintSheets4"].ToString() };
                this.PrintSheetsSections1_ExcludeSpoilage = string.Concat(str);
            }
            //////////////////////End of code Added By Amin//////////////////////
            if (this.qty.Length == 0)
            {
                this.qty = "0,";
            }
        }

        public virtual DataTable PCR_estimate_OtherCost_GetAllRequiredValue(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_OtherCost_GetAllRequiredValue");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PCR_estimate_OtherCost_GetAllRequiredValue_Section1(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_OtherCost_GetAllRequiredValue_Section1");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}