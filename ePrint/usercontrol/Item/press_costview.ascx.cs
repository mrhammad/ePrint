using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
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
using Telerik.Web.UI;
namespace ePrint.usercontrol.Item
{
    public partial class press_costview : UsercontrolBasePage
    {
        public long PressID;

        public long EstimateItemID;

        public long EstimateID;

        public long JobID;

        public long InvoiceID;

        public int CompanyID;

        public int UserID;

        public long TypeID;

        public string EstType = string.Empty;

        public string Module = string.Empty;

        public commonClass comm = new commonClass();

        public languageClass objLanguage = new languageClass();

        private BasePage ObjPage = new BasePage();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string ItemFrom = string.Empty;

        public string PressType = string.Empty;

        public string isJobTime = "no";

        public int sideno = 1;

        public string isZdoubleside = "no";

        public bool UnitOfMeasureKey;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private string PaperMeasure = string.Empty;

        public string IsFromeStore = string.Empty;

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

        public press_costview()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.EstType.ToLower() != "b")
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
            }
            else
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
            }
            if (base.Request.Params["From"] != null)
            {
                if (string.Compare(base.Request.Params["From"].ToString(), "li", true) == 0)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    string empty = string.Empty;
                    base.Request.Params["item"].ToString();
                }
                this.ItemFrom = base.Request.Params["From"].ToString();
            }
            long num = (long)0;
            string str = string.Empty;
            if (this.PressType.Trim().ToUpper() == "Z")
            {
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                decimal num16 = new decimal(0);
                decimal num17 = new decimal(0);
                decimal num18 = new decimal(0);
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                decimal num21 = new decimal(0);
                decimal num22 = new decimal(0);
                decimal num23 = new decimal(0);
                decimal num24 = new decimal(0);
                decimal num25 = new decimal(0);
                decimal num26 = new decimal(0);
                decimal num27 = new decimal(0);
                decimal num28 = new decimal(0);
                decimal num29 = new decimal(0);
                decimal num30 = new decimal(0);
                decimal num31 = new decimal(0);
                decimal num32 = new decimal(0);
                decimal num33 = new decimal(0);
                decimal num34 = new decimal(0);
                decimal num35 = new decimal(0);
                decimal num36 = new decimal(0);
                decimal num37 = new decimal(0);
                decimal num38 = new decimal(0);
                decimal num39 = new decimal(0);
                decimal num40 = new decimal(0);
                decimal num41 = new decimal(0);
                decimal num42 = new decimal(0);
                decimal num43 = new decimal(0);
                decimal num44 = new decimal(0);
                decimal num45 = new decimal(0);
                decimal num46 = new decimal(0);
                if (this.isZdoubleside.Trim().ToLower() != "yes")
                {
                    for (int i = 0; i < this.GridPressCostView.Items.Count; i++)
                    {
                        HiddenField hiddenField = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdn_MarkupPrice");
                        TextBox textBox = (TextBox)this.GridPressCostView.Items[i].FindControl("txt_Markup");
                        HiddenField hiddenField1 = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdn_EstimateCalculationID");
                        HiddenField hiddenField2 = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdn_CostExMarkup");
                        HiddenField hiddenField3 = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdn_CostExMarkup_Actual");
                        HiddenField hiddenField4 = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdnQtyNoOnlyForZone");
                        num = Convert.ToInt64(hiddenField1.Value);
                        HiddenField hiddenField5 = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdn_MinimumCharge");
                        num45 = Convert.ToDecimal(hiddenField5.Value);
                        HiddenField hiddenField6 = (HiddenField)this.GridPressCostView.Items[i].FindControl("hdn_SetUpCost");
                        num46 = Convert.ToDecimal(hiddenField6.Value);
                        int num47 = Convert.ToInt32(hiddenField4.Value);
                        if (num47 == 1)
                        {
                            num1 = Convert.ToDecimal(textBox.Text);
                            num5 = new decimal(0);
                            num9 = Convert.ToDecimal(hiddenField.Value);
                            num13 = new decimal(0);
                            num17 = num9 + num13;
                            num21 = Convert.ToDecimal(hiddenField2.Value);
                            num25 = new decimal(0);
                            if (((num21 + num9) + num46) <= num45)
                            {
                                num37 = num45;
                                num17 = new decimal(0);
                            }
                            else
                            {
                                num37 = num21 + num46;
                            }
                            num29 = Convert.ToDecimal(hiddenField3.Value);
                            num41 = num29 + new decimal(0);
                        }
                        else if (num47 == 2)
                        {
                            num2 = Convert.ToDecimal(textBox.Text);
                            num6 = new decimal(0);
                            num10 = Convert.ToDecimal(hiddenField.Value);
                            num14 = new decimal(0);
                            num18 = num10 + num14;
                            num22 = Convert.ToDecimal(hiddenField2.Value);
                            num26 = new decimal(0);
                            if (((num22 + num10) + num46) <= num45)
                            {
                                num38 = num45;
                                num18 = new decimal(0);
                            }
                            else
                            {
                                num38 = num22 + num46;
                            }
                            num30 = Convert.ToDecimal(hiddenField3.Value);
                            num42 = num30 + new decimal(0);
                        }
                        else if (num47 == 3)
                        {
                            num3 = Convert.ToDecimal(textBox.Text);
                            num7 = new decimal(0);
                            num11 = Convert.ToDecimal(hiddenField.Value);
                            num15 = new decimal(0);
                            num19 = num11 + num15;
                            num23 = Convert.ToDecimal(hiddenField2.Value);
                            num27 = new decimal(0);
                            if (((num23 + num11) + num46) <= num45)
                            {
                                num39 = num45;
                                num19 = new decimal(0);
                            }
                            else
                            {
                                num39 = num23 + num46;
                            }
                            num31 = Convert.ToDecimal(hiddenField3.Value);
                            num43 = num31 + new decimal(0);
                        }
                        else if (num47 == 4)
                        {
                            num4 = Convert.ToDecimal(textBox.Text);
                            num8 = new decimal(0);
                            num12 = Convert.ToDecimal(hiddenField.Value);
                            num16 = new decimal(0);
                            num20 = num12 + num16;
                            num24 = Convert.ToDecimal(hiddenField2.Value);
                            num28 = new decimal(0);
                            if (((num24 + num12) + num46) <= num45)
                            {
                                num40 = num45;
                                num20 = new decimal(0);
                            }
                            else
                            {
                                num40 = num24 + num46;
                            }
                            num32 = Convert.ToDecimal(hiddenField3.Value);
                            num44 = num32 + new decimal(0);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < this.GridPressCostView.Items.Count; j = j + 2)
                    {
                        HiddenField hiddenField7 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdn_CostExMarkup");
                        HiddenField hiddenField8 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdn_CostExMarkup_Actual");
                        HiddenField hiddenField9 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdn_MarkupPrice");
                        TextBox textBox1 = (TextBox)this.GridPressCostView.Items[j].FindControl("txt_Markup");
                        HiddenField hiddenField10 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdn_EstimateCalculationID");
                        HiddenField hiddenField11 = (HiddenField)this.GridPressCostView.Items[j + 1].FindControl("hdn_CostExMarkup");
                        HiddenField hiddenField12 = (HiddenField)this.GridPressCostView.Items[j + 1].FindControl("hdn_CostExMarkup_Actual");
                        HiddenField hiddenField13 = (HiddenField)this.GridPressCostView.Items[j + 1].FindControl("hdn_MarkupPrice");
                        TextBox textBox2 = (TextBox)this.GridPressCostView.Items[j + 1].FindControl("txt_Markup");
                        HiddenField hiddenField14 = (HiddenField)this.GridPressCostView.Items[j + 1].FindControl("hdn_EstimateCalculationID");
                        num = Convert.ToInt64(hiddenField10.Value);
                        HiddenField hiddenField15 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdnQtyNoOnlyForZone");
                        HiddenField hiddenField16 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdn_MinimumCharge");
                        HiddenField hiddenField17 = (HiddenField)this.GridPressCostView.Items[j].FindControl("hdn_SetUpCost");
                        num46 = Convert.ToDecimal(hiddenField17.Value);
                        num45 = Convert.ToDecimal(hiddenField16.Value);
                        int num48 = Convert.ToInt32(hiddenField15.Value);
                        if (num48 == 1)
                        {
                            num1 = Convert.ToDecimal(textBox1.Text);
                            num5 = Convert.ToDecimal(textBox2.Text);
                            num9 = Convert.ToDecimal(hiddenField9.Value);
                            num13 = Convert.ToDecimal(hiddenField13.Value);
                            num17 = num9 + num13;
                            num21 = Convert.ToDecimal(hiddenField7.Value);
                            num25 = Convert.ToDecimal(hiddenField11.Value);
                            if (((((num21 + num9) + num25) + num13) + num46) <= num45)
                            {
                                num37 = num45;
                                num17 = new decimal(0);
                            }
                            else
                            {
                                num37 = (num21 + num25) + num46;
                            }
                            num29 = Convert.ToDecimal(hiddenField8.Value);
                            num33 = Convert.ToDecimal(hiddenField12.Value);
                            num41 = num29 + num33;
                        }
                        else if (num48 == 2)
                        {
                            num2 = Convert.ToDecimal(textBox1.Text);
                            num6 = Convert.ToDecimal(textBox2.Text);
                            num10 = Convert.ToDecimal(hiddenField9.Value);
                            num14 = Convert.ToDecimal(hiddenField13.Value);
                            num18 = num10 + num14;
                            num22 = Convert.ToDecimal(hiddenField7.Value);
                            num26 = Convert.ToDecimal(hiddenField11.Value);
                            if (((((num22 + num10) + num26) + num14) + num46) <= num45)
                            {
                                num38 = num45;
                                num18 = new decimal(0);
                            }
                            else
                            {
                                num38 = (num22 + num26) + num46;
                            }
                            num30 = Convert.ToDecimal(hiddenField8.Value);
                            num34 = Convert.ToDecimal(hiddenField12.Value);
                            num42 = num30 + num34;
                        }
                        else if (num48 == 3)
                        {
                            num3 = Convert.ToDecimal(textBox1.Text);
                            num7 = Convert.ToDecimal(textBox2.Text);
                            num11 = Convert.ToDecimal(hiddenField9.Value);
                            num15 = Convert.ToDecimal(hiddenField13.Value);
                            num19 = num11 + num15;
                            num23 = Convert.ToDecimal(hiddenField7.Value);
                            num27 = Convert.ToDecimal(hiddenField11.Value);
                            if (((((num23 + num11) + num27) + num15) + num46) <= num45)
                            {
                                num39 = num45;
                                num19 = new decimal(0);
                            }
                            else
                            {
                                num39 = (num23 + num27) + num46;
                            }
                            num31 = Convert.ToDecimal(hiddenField8.Value);
                            num35 = Convert.ToDecimal(hiddenField12.Value);
                            num43 = num31 + num35;
                        }
                        else if (num48 == 4)
                        {
                            num4 = Convert.ToDecimal(textBox1.Text);
                            num8 = Convert.ToDecimal(textBox2.Text);
                            num12 = Convert.ToDecimal(hiddenField9.Value);
                            num16 = Convert.ToDecimal(hiddenField13.Value);
                            num20 = num12 + num16;
                            num24 = Convert.ToDecimal(hiddenField7.Value);
                            num28 = Convert.ToDecimal(hiddenField11.Value);
                            if (((((num24 + num12) + num28) + num16) + num46) <= num45)
                            {
                                num40 = num45;
                                num20 = new decimal(0);
                            }
                            else
                            {
                                num40 = (num24 + num28) + num46;
                            }
                            num32 = Convert.ToDecimal(hiddenField8.Value);
                            num36 = Convert.ToDecimal(hiddenField12.Value);
                            num44 = num32 + num36;
                        }
                    }
                }
                EstimatesBasePage.estimates_markup_calculation_update_ForPressZone(this.CompanyID, num, this.TypeID, this.EstType, num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, num13, num14, num15, num16, num17, num18, num19, num20, this.Module, num37, num38, num39, num40, num41, num42, num43, num44);
            }
            else
            {
                decimal[] numArray = new decimal[4];
                decimal[] numArray1 = new decimal[4];
                decimal[] numArray2 = new decimal[4];
                decimal[] numArray3 = new decimal[4];
                long[] numArray4 = new long[4];
                for (int k = 0; k < 4; k++)
                {
                    if (k < this.GridPressCostView.Items.Count)
                    {
                        HiddenField hiddenField18 = (HiddenField)this.GridPressCostView.Items[k].FindControl("hdn_MarkupPrice");
                        HiddenField hiddenField19 = (HiddenField)this.GridPressCostView.Items[k].FindControl("hdn_CostExMarkup");
                        HiddenField hiddenField20 = (HiddenField)this.GridPressCostView.Items[k].FindControl("hdn_CostExMarkup_Actual");
                        TextBox textBox3 = (TextBox)this.GridPressCostView.Items[k].FindControl("txt_Markup");
                        HiddenField hiddenField21 = (HiddenField)this.GridPressCostView.Items[k].FindControl("hdn_EstimateCalculationID");
                        HiddenField hiddenField22 = (HiddenField)this.GridPressCostView.Items[k].FindControl("hdnQtyNoOnlyForZone");
                        int num49 = Convert.ToInt32(hiddenField22.Value);
                        if (num49 == 1)
                        {
                            numArray[0] = Convert.ToDecimal(hiddenField18.Value);
                            numArray1[0] = Convert.ToDecimal(hiddenField19.Value);
                            numArray2[0] = Convert.ToDecimal(hiddenField20.Value);
                            numArray3[0] = Convert.ToDecimal(textBox3.Text);
                            numArray4[0] = Convert.ToInt64(hiddenField21.Value);
                        }
                        else if (num49 == 2)
                        {
                            numArray[1] = Convert.ToDecimal(hiddenField18.Value);
                            numArray1[1] = Convert.ToDecimal(hiddenField19.Value);
                            numArray2[1] = Convert.ToDecimal(hiddenField20.Value);
                            numArray3[1] = Convert.ToDecimal(textBox3.Text);
                            numArray4[1] = Convert.ToInt64(hiddenField21.Value);
                        }
                        else if (num49 == 3)
                        {
                            numArray[2] = Convert.ToDecimal(hiddenField18.Value);
                            numArray1[2] = Convert.ToDecimal(hiddenField19.Value);
                            numArray2[2] = Convert.ToDecimal(hiddenField20.Value);
                            numArray3[2] = Convert.ToDecimal(textBox3.Text);
                            numArray4[2] = Convert.ToInt64(hiddenField21.Value);
                        }
                        else if (num49 != 4)
                        {
                            numArray[k] = new decimal(0);
                            numArray1[k] = new decimal(0);
                            numArray2[k] = new decimal(0);
                            numArray3[k] = new decimal(0);
                            numArray4[k] = (long)0;
                        }
                        else
                        {
                            numArray[3] = Convert.ToDecimal(hiddenField18.Value);
                            numArray1[3] = Convert.ToDecimal(hiddenField19.Value);
                            numArray2[3] = Convert.ToDecimal(hiddenField20.Value);
                            numArray3[3] = Convert.ToDecimal(textBox3.Text);
                            numArray4[3] = Convert.ToInt64(hiddenField21.Value);
                        }
                    }
                }
                if ((int)numArray4.Length > 0)
                {
                    int num50 = 0;
                    while (num50 < (int)numArray4.Length)
                    {
                        if (numArray4[num50] <= (long)0)
                        {
                            num50++;
                        }
                        else
                        {
                            num = numArray4[num50];
                            break;
                        }
                    }
                }
                str = "Press";
                if (string.Compare(str, "press", true) == 0)
                {
                    EstimatesBasePage.estimates_markup_calculation_update(this.CompanyID, num, numArray3[0], str, this.TypeID, this.EstType, numArray3[1], numArray3[2], numArray3[3], numArray[0], numArray[1], numArray[2], numArray[3], numArray1[0], numArray1[1], numArray1[2], numArray1[3], this.Module, numArray2[0], numArray2[1], numArray2[2], numArray2[3]);
                }
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            this.pnlCallAfterUpdate.Visible = true;
        }

        protected void GridPressCostView_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["HourlyRate"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Hourly_Rate"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["SellingPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                item["PricePerUnitofMeasure"].Text = string.Concat(this.objLanguage.GetLanguageConversion("PPUM"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ") (inc markup)");
                //["MarkupPrice"].Text = string.Concat(this.objLanguage.GetLanguageConversion("Markup_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")"); By Amin
                if ((this.isJobTime.ToLower() == "yes") && (this.lblDoubleSided.Text.ToLower() == "yes"))
                {
                    item["JobTimeSide1"].Text = "Job Time(min) Side1";
                }
                else if (this.isJobTime.ToLower() == "yes")
                {
                    item["JobTimeSide1"].Text = "Job Time(min)";
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                int num = 0;
                Label label = (Label)e.Item.FindControl("lbl_qty");
                Label regionalSettings = (Label)e.Item.FindControl("lbl_Sidecolour");
                Label label1 = (Label)e.Item.FindControl("lbl_PrintSheets");
                Label label2 = (Label)e.Item.FindControl("lbl_PricePerUnitofMeasure");
                Label label3 = (Label)e.Item.FindControl("lbl_ChargableRate");
                Label label4 = (Label)e.Item.FindControl("lbl_PaperLength");
                Label label5 = (Label)e.Item.FindControl("lbl_ChargableSheets");
                Label label6 = (Label)e.Item.FindControl("lbl_ChargableRateSide1");
                Label label7 = (Label)e.Item.FindControl("lbl_ChargableRateSide2");
                Label label8 = (Label)e.Item.FindControl("lbl_JobTime");
                Label label9 = (Label)e.Item.FindControl("lbl_HourlyRate");
                Label label10 = (Label)e.Item.FindControl("lbl_JobTimeSide1");
                Label label11 = (Label)e.Item.FindControl("lbl_JobTimeSide2");
                Label label12 = (Label)e.Item.FindControl("lbl_ClickChargeCost");
                Label label13 = (Label)e.Item.FindControl("lbl_SetupCharge");
                Label label14 = (Label)e.Item.FindControl("lbl_SellingPrice");
                Label label15 = (Label)e.Item.FindControl("lbl_MarkupPrice");
                Label label16 = (Label)e.Item.FindControl("lbl_ZoneSide1Cost");
                Label label17 = (Label)e.Item.FindControl("lbl_TotalCLicks");
                HiddenField pressType = (HiddenField)e.Item.FindControl("hdnPressType");
                pressType.Value = this.PressType;
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", true, false, true);
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", true, false, true);
                label5.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label5.Text), 0, "", true, false, true);
                label3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label3.Text), 4, "", false, false, true);
                label4.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text), 0, "", false, false, true);
                label8.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label8.Text), 0, "", false, false, true);
                label9.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label9.Text), 0, "", false, false, true);
                label10.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label10.Text), 0, "", false, false, true);
                label11.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label11.Text), 0, "", false, false, true);
                label12.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label12.Text), 0, "", false, false, true);
                label13.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label13.Text), 0, "", false, false, true);
                label14.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label14.Text), 0, "", false, false, true);
                label15.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label15.Text), 0, "", false, false, true);
                label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);

                label16.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label16.Text), 4, "", false, false, true);
                label17.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label17.Text) , 0, "", false, false, true);

                if (this.PressType != "Z")
                {
                    label2.Text = string.Concat(label2.Text, " per ", label.Text);
                }
                else
                {
                    label2.Text = string.Concat(label2.Text, " per ", label1.Text);
                }
                if (this.EstType == "S" || this.EstType == "B" || this.EstType == "P" || this.EstType == "R")
                {
                    label6.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label6.Text), 3, "", false, false, true);
                    label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label7.Text), 3, "", false, false, true);
                }
                else
                {
                    label6.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label6.Text), 0, "", false, false, true);
                    label7.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label7.Text), 0, "", false, false, true);
                }
                if (regionalSettings.Text == "Color")
                {
                    regionalSettings.Text = this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour");
                }
                if (this.isZdoubleside == "yes")
                {
                    if (this.sideno % 2 != 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        num = 2;
                        label.Text = "";
                        label1.Text = "";
                        label13.Text = "";
                    }
                    object[] text = new object[] { "<strong>Side ", num, ": </strong>", regionalSettings.Text };
                    regionalSettings.Text = string.Concat(text);
                    object[] objArray = new object[] { "<strong>Side ", num, ": </strong>", label3.Text };
                    label3.Text = string.Concat(objArray);
                }
                TextBox textBox = (TextBox)e.Item.FindControl("txt_Markup");
                textBox.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox.Text), 0, "", false, false, false);
                if (this.PressType != "Z")
                {
                    textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Press(this);");
                }
                else
                {
                    textBox.Attributes.Add("onblur", "javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Press_ClickChargeZoneLookUp(this);");
                }
                textBox.Attributes.Add("onclick", "javascript:this.select();");
                if (this.lbl_ZonebuildupCalculationmethod.Text == "Yes")
                {
                    textBox.Attributes.Add("disabled", "disabled");
                    label16.Text = "N/A";
                }
                press_costview usercontrolItemPressCostview = this;
                usercontrolItemPressCostview.sideno = usercontrolItemPressCostview.sideno + 1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.PressID = Convert.ToInt64(base.Request.QueryString["PressID"].ToString());
            this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["EstimateItemID"].ToString());
            this.EstType = base.Request.QueryString["EstType"].ToString();
            if (!base.IsPostBack)
            {
                this.GridPressCostView.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
                this.GridPressCostView.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Print_Sheets");
                this.GridPressCostView.Columns[18].HeaderText = this.objLanguage.GetLanguageConversion("Set_Up_Charge");
                this.GridPressCostView.Columns[15].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Markup"), " (%)");
                this.GridPressCostView.Columns[19].HeaderText = this.objLanguage.GetLanguageConversion("Selling_Price");
                this.GridPressCostView.Columns[13].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Side"), " ", this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour"));
                this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            }
            bool unitOfMeasure = ConnectionClass.UnitOfMeasure;
            this.UnitOfMeasureKey = Convert.ToBoolean(ConnectionClass.UnitOfMeasure);
            if (this.EstType.ToLower() != "b")
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["TypeID"].ToString());
            }
            else
            {
                this.TypeID = Convert.ToInt64(base.Request.QueryString["EstimateBookletItemID"].ToString());
            }
            foreach (DataRow row in EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstimateItemID).Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"]);
                this.JobID = Convert.ToInt64(row["JOBID"]);
                this.InvoiceID = Convert.ToInt64(row["InvoiceID"]);
            }
            this.Module = base.Request.QueryString["Module"].ToString();
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            DataSet dataSet = EstimatesBasePage.PCR_Press_Cost_ViewOnPopUp(this.PressID, this.EstimateItemID, this.EstType, this.TypeID, this.Module);
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.GridPressCostView.MasterTableView.Columns[0].Visible = false;
                this.GridPressCostView.MasterTableView.Columns[1].Visible = false;
            }
            else
            {
                this.lblPressName.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[0]["pressname"].ToString());
                if (this.EstType.ToLower() != "l")
                {
                    this.Td1.Attributes.Add("style", "display:none;");
                    this.Td2.Attributes.Add("style", "display:none;");
                    this.Td3.Attributes.Add("style", "display:none;");
                }
                else
                {
                    string empty = string.Empty;
                    if (dataSet.Tables[0].Rows[0]["PrintQuality"].ToString().ToLower().Trim() == "low")
                    {
                        empty = this.objLanguage.GetLanguageConversion("low");
                    }
                    else if (dataSet.Tables[0].Rows[0]["PrintQuality"].ToString().ToLower().Trim() == "high")
                    {
                        empty = this.objLanguage.GetLanguageConversion("high");
                    }
                    else if (dataSet.Tables[0].Rows[0]["PrintQuality"].ToString().ToLower().Trim() == "medium")
                    {
                        empty = this.objLanguage.GetLanguageConversion("medium");
                    }
                    this.lblPrintQuality.Text = empty;
                }
                this.lblMinimumCharge.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataSet.Tables[0].Rows[0]["minimumcharge"].ToString()), 0, "", false, false, true);
                this.LblPrintQualityDPI.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PrintQualityDPI"].ToString()), 0, "", false, false, true);
                string str = string.Empty;
                if ((this.EstType == "F" || this.EstType == "N" || this.EstType == "K" || this.EstType == "D") && dataSet.Tables.Count > 2)
                {
                    str = dataSet.Tables[2].Rows[0]["Doublesided"].ToString().ToLower().Trim();
                }
                if (dataSet.Tables[0].Rows[0]["Doublesided"].ToString().ToLower().Trim() == "yes" || str == "yes")
                {
                    this.lblDoubleSided.Text = "Yes";
                }
                else
                {
                    this.lblDoubleSided.Text = "No";
                }
                if (this.EstType == "S" || this.EstType == "B" || this.EstType == "P" || this.EstType == "R")
                {
                    if (dataSet.Tables[0].Rows[0]["methodname"].ToString().Trim().ToLower() == "speedweightlookup")
                    {
                        if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "no")
                        {
                            this.GridPressCostView.MasterTableView.Columns[11].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[10].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                            if (this.UnitOfMeasureKey)
                            {
                                this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                            }
                            this.isJobTime = "yes";
                        }
                        else if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "yes")
                        {
                            this.GridPressCostView.MasterTableView.Columns[11].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[12].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[10].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                            if (this.UnitOfMeasureKey)
                            {
                                this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                            }
                        }
                    }
                    if (dataSet.Tables[0].Rows[0]["methodname"].ToString().Trim().ToLower() == "clickchargelookup")
                    {
                        if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "no")
                        {
                            this.GridPressCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                            if (this.UnitOfMeasureKey)
                            {
                                this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                            }
                        }
                        else if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "yes")
                        {
                            this.GridPressCostView.MasterTableView.Columns[7].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[8].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                            if (this.UnitOfMeasureKey)
                            {
                                this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                            }
                            if (this.EstType == "B")
                            {
                                this.GridPressCostView.MasterTableView.Columns[6].Visible = false;
                            }
                        }
                    }
                    if (dataSet.Tables[0].Rows[0]["methodname"].ToString().Trim().ToLower() == "clickchargezonelookup")
                    {
                        this.PressType = "Z";
                        this.trHeading3.Visible = true;
                        if (dataSet.Tables[0].Rows[0]["calculationtype"].ToString().Trim().ToLower() != "true")
                        {
                            this.lbl_ZonebuildupCalculationmethod.Text = "No";
                        }
                        else
                        {
                            this.lbl_ZonebuildupCalculationmethod.Text = "Yes";
                        }
                        if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "yes")
                        {
                            this.isZdoubleside = "yes";
                        }
                        if (this.EstType != "B")
                        {
                            this.GridPressCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[6].Visible = false;
                        }
                        else if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "no")
                        {
                            this.GridPressCostView.MasterTableView.Columns[5].Visible = true;
                        }
                        else if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "yes")
                        {
                            this.GridPressCostView.MasterTableView.Columns[5].Visible = true;
                            this.GridPressCostView.MasterTableView.Columns[6].Visible = false;
                        }
                        this.GridPressCostView.MasterTableView.Columns[13].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[16].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[2].Visible = true;
                        if (this.UnitOfMeasureKey)
                        {
                            this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                        }
                    }
                }
                else if (this.EstType == "F" || this.EstType == "K" || this.EstType == "N" || this.EstType == "D")
                {
                    this.GridPressCostView.MasterTableView.Columns[3].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[11].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[10].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                    if (this.UnitOfMeasureKey)
                    {
                        this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                    }
                    this.isJobTime = "yes";
                }
                else if (this.EstType.ToLower() == "l")
                {
                    if (string.Compare(dataSet.Tables[0].Rows[0]["papertype"].ToString().Trim().ToLower(), "roll", true) == 0 || string.Compare(dataSet.Tables[0].Rows[0]["papertype"].ToString().Trim().ToLower(), "web printing", true) == 0)
                    {
                        if (dataSet.Tables[0].Rows[0]["LargeCalcType"].ToString().Trim().ToLower() == "square")
                        {
                            if (this.PaperMeasure != "In.")
                            {
                                this.GridPressCostView.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Length_Sq_Meter");
                            }
                            else
                            {
                                this.GridPressCostView.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Length_Sq_feet");
                            }
                        }
                        if (dataSet.Tables[0].Rows[0]["LargeCalcType"].ToString().Trim().ToLower() == "tilling")
                        {
                            if (this.PaperMeasure != "In.")
                            {
                                this.GridPressCostView.MasterTableView.Columns[4].HeaderText = "Stock Area (sq m)";
                            }
                            else
                            {
                                this.GridPressCostView.MasterTableView.Columns[4].HeaderText = "Stock Area (sq ft)";
                            }
                        }
                        else if (this.PaperMeasure != "In.")
                        {
                            this.GridPressCostView.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Length_Meter");
                        }
                        else
                        {
                            this.GridPressCostView.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Length_feet");
                        }
                        this.GridPressCostView.MasterTableView.Columns[4].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[1].Visible = false;
                    }
                    else if (dataSet.Tables[0].Rows[0]["LargeCalcType"].ToString().Trim().ToLower() == "square")
                    {
                        this.GridPressCostView.MasterTableView.Columns[4].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[1].Visible = false;
                        if (this.PaperMeasure != "In.")
                        {
                            this.GridPressCostView.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Length_Sq_Meter");
                        }
                        else
                        {
                            this.GridPressCostView.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Length_Sq_feet");
                        }
                    }
                    else if (dataSet.Tables[0].Rows[0]["LargeCalcType"].ToString().Trim().ToLower() == "tilling")
                    {
                        this.GridPressCostView.MasterTableView.Columns[4].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[1].Visible = false;
                        if (this.PaperMeasure != "In.")
                        {
                            this.GridPressCostView.MasterTableView.Columns[4].HeaderText = "Stock Area (sq m)";
                        }
                        else
                        {
                            this.GridPressCostView.MasterTableView.Columns[4].HeaderText = "Stock Area (sq ft)";
                        }
                    }
                    this.GridPressCostView.MasterTableView.Columns[18].Visible = true;
                    //this.GridPressCostView.MasterTableView.Columns[11].Visible = true;

                    // job time calcuation
                    if(dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "no")
                    {
                        this.GridPressCostView.MasterTableView.Columns[11].Visible = true;                         
                    }
                    else if (dataSet.Tables[0].Rows[0]["DoubleSided"].ToString().Trim().ToLower() == "yes")
                    {
                        this.GridPressCostView.MasterTableView.Columns[11].Visible = true;
                        this.GridPressCostView.MasterTableView.Columns[12].Visible = true;
                    }

                    this.GridPressCostView.MasterTableView.Columns[10].Visible = true;
                    if (this.UnitOfMeasureKey)
                    {
                        this.GridPressCostView.MasterTableView.Columns[20].Visible = true;
                    }
                    this.GridPressCostView.MasterTableView.Columns[15].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[17].Visible = true;
                    this.GridPressCostView.MasterTableView.Columns[19].Visible = true;
                    this.isJobTime = "yes";
                }
            }
            this.GridPressCostView.DataSource = dataSet.Tables[0];
            this.GridPressCostView.DataBind();
            if (this.PressType == "Z")
            {
                DataTable item = dataSet.Tables[1];
                if (item.Rows.Count > 0)
                {
                    this.plhTotalSellingPrice.Controls.Add(new LiteralControl(string.Concat(" <table width='250px'><tr><td align='right'><strong>Quantity</strong></td><td align='right'><strong>Total Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></td></tr>")));
                    foreach (DataRow dataRow in item.Rows)
                    {
                        ControlCollection controls = this.plhTotalSellingPrice.Controls;
                        string[] strArrays = new string[] { "<tr><td align='right'>", dataRow["quantity"].ToString(), "</td><td align='right'><span id='td_PressCostView_Totalsellingprice'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["totalSellingPrice"].ToString()), 0, "", false, false, true), "</span></td></tr>" };
                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                    this.plhTotalSellingPrice.Controls.Add(new LiteralControl("</table>"));
                }
            }
            if (this.Module.ToLower() == "job")
            {
                this.IsFromeStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.JobID, "jobs");
            }
            if (this.Module.ToLower() == "invoice")
            {
                this.IsFromeStore = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, "invoice");
            }
        }
    }
}