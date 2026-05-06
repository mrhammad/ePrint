using nmsCommon;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using System;
using System.Collections;
using System.Configuration;
using System.Data;

namespace Printcenter.Calculations
{
    public class Calculations
    {
        private commonClass commclass = new commonClass();

        public Calculations()
        {
        }

        private decimal Guillotine_Calculation(int CompanyID, decimal TotalSheets, decimal ThroatValue, decimal Printlayout, decimal GuillotineSetCharge, decimal GuillotineMinimumCharge, decimal GuillotineMarkUp, decimal CostPerCut, bool IsGutterSelected, int Quantity, ref decimal TotalNoOfCusts, ref decimal Bundles)
        {
            if (Printlayout == new decimal(0))
            {
                return 0;
            }
            Bundles = new decimal(0);
            if (ThroatValue != new decimal(0))
            {
                Bundles = Convert.ToInt32(Math.Ceiling(TotalSheets / Convert.ToDecimal(ThroatValue)));
            }
            if (Bundles == new decimal(0))
            {
                Bundles = new decimal(1);
            }
            TotalNoOfCusts = new decimal(0);
            decimal num = EstimateBasePage.Estimate_Summary_Guillotine_Standard_Table(CompanyID, Printlayout, (IsGutterSelected ? "yes" : "no"));
            TotalNoOfCusts = num * Bundles;
            return CostPerCut * TotalNoOfCusts;
        }

        public decimal GuillotineCalculation(int CompanyID, string EstimateType, int Quantity, decimal GuillotineMarkUp, DataRow drQty, decimal Totalpaper, ref decimal GuillotineCostExMarkup, ref decimal GuillotineMarkupPrice, ref decimal FirstTrimCuts, ref decimal FirstTrimNoOfBundles, ref decimal SecondTrimCuts, ref decimal SecondTrimNoOfBundles, decimal PaperLength_Required, ref decimal GuillotineMarkUp_Actual,string GuillotineType="Standard")
        {
            decimal num = Convert.ToDecimal(drQty["GuillotineSetupCharge"]);
            decimal num1 = Convert.ToDecimal(drQty["GuillotineMinimumRunningCharge"]);
            decimal num2 = Convert.ToDecimal(drQty["GuillotineCostPerCut"]);
            decimal num3 = Convert.ToDecimal(drQty["guillotineminimumrunningcharge"]);
            decimal num4 = Convert.ToDecimal(drQty["GuillotinePaperWeight1"]);
            decimal num5 = Convert.ToDecimal(drQty["GuillotineMaximumThroat1"]);
            decimal num6 = Convert.ToDecimal(drQty["GuillotinePaperWeight2"]);
            decimal num7 = Convert.ToDecimal(drQty["GuillotineMaximumThroat2"]);
            decimal num8 = Convert.ToDecimal(drQty["GuillotinePaperWeight3"]);
            decimal num9 = Convert.ToDecimal(drQty["GuillotineMaximumThroat3"]);
            decimal num10 = new decimal(0);
            if(GuillotineType == "Advanced")
            {
                num10 = Convert.ToDecimal(drQty["Caliper"]);
            }
            else
            {
                num10 = Convert.ToDecimal(drQty["PaperWeight"]);
            }
            string empty = string.Empty;
            decimal num11 = new decimal(0);
            if (EstimateType == "B" || EstimateType == "K")
            {
                empty = drQty["BookletFormat"].ToString();
                num11 = Convert.ToInt32(drQty["PagesPerSignature"]);
                if (drQty["BookletType"].ToString().ToLower() == "saddlestiched")
                {
                    num11 = num11 / new decimal(2);
                }
            }
            else
            {
                empty = drQty["PrintLayout"].ToString();
                decimal num12 = Convert.ToDecimal(drQty["PortraitValue"]);
                decimal num13 = Convert.ToDecimal(drQty["LandscapeValue"]);
                num11 = (empty == "L" ? num13 : num12);
            }
            decimal num14 = Convert.ToDecimal(drQty["Height"]);
            decimal num15 = Convert.ToDecimal(drQty["Width"]);
            decimal num16 = Convert.ToDecimal(drQty["SheetHeight"]);
            decimal num17 = Convert.ToDecimal(drQty["SheetWidth"]);
            decimal num18 = Convert.ToDecimal(drQty["BasisWeight"]);
            bool flag = Convert.ToBoolean(drQty["IsFirstTrim"]);
            bool flag1 = Convert.ToBoolean(drQty["IsSecondTrim"]);
            bool flag2 = Convert.ToBoolean(drQty["IsIncludeGutters"]);
            long num19 = Convert.ToInt64(drQty["GuillotineID"]);
            decimal num20 = new decimal(0);
            decimal num21 = new decimal(0);
            decimal num22 = new decimal(0);
            decimal num23 = new decimal(0);
            bool flag3 = Convert.ToBoolean(EprintConfigurationManager.AppSettings["Guillotine_New_Cal"]);
            if (num10 <= num4)
            {
                num20 = num5;
            }
            else if (num10 <= num6)
            {
                num20 = num7;
            }
            else if (num10 <= num8 || num10 > num8)
            {
                num20 = num9;
            }
            decimal num24 = new decimal(0);
            decimal num25 = new decimal(0);
            if (EstimateType != "L")
            {
                if (flag)
                {
                    decimal num26 = EstimateBasePage.Guillotine_First_Trim_Cut(num14, num15, num16, num17, num18, empty, Totalpaper, num4, num5, num6, num7, num8, num9, ref num24);
                    num21 = num2 * num26;
                    FirstTrimCuts = num26;
                    FirstTrimNoOfBundles = num24;
                }
                if (flag1)
                {
                    num22 = EstimatesBasePage.Guillotine_Calculation(CompanyID, Totalpaper, num20, num11, num, num1, GuillotineMarkUp, num2, flag2, Quantity, ref SecondTrimCuts, ref SecondTrimNoOfBundles,GuillotineType);
                }
            }
            else
            {
                drQty["InventoryPaperType"].ToString();
                if (flag1)
                {
                    if (!flag3)
                    {
                        decimal paperLengthRequired = PaperLength_Required * new decimal(1000);
                        decimal num27 = Math.Ceiling(paperLengthRequired / num16);
                        num22 = EstimatesBasePage.Guillotine_Calculation_Roll(CompanyID, num27, num20, num11, num, num1, GuillotineMarkUp, num2, Convert.ToBoolean(drQty["IsIncludeGutters"]), Quantity, ref SecondTrimCuts, ref SecondTrimNoOfBundles);
                    }
                    else
                    {
                        foreach (DataRow row in SummaryClass.guillotine_cost_for_large(CompanyID, num19, Quantity).Rows)
                        {
                            num22 = Convert.ToDecimal(row["Cost"]);
                            SecondTrimCuts = Convert.ToInt32(row["Cuts"]);
                        }
                    }
                }
            }
            if (flag1 || flag)
            {
                GuillotineCostExMarkup = num21 + num22;
                GuillotineMarkUp_Actual = GuillotineCostExMarkup + num;
                num23 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(GuillotineCostExMarkup, GuillotineMarkUp, num3, out num25, out GuillotineMarkUp, ref num);
                GuillotineMarkupPrice = (num25 * GuillotineMarkUp) / new decimal(100);
                if (num3 < num23)
                {
                    GuillotineCostExMarkup = num25 + num;
                }
                else
                {
                    GuillotineCostExMarkup = num3;
                }
            }
            else
            {
                GuillotineCostExMarkup = new decimal(0);
                GuillotineMarkupPrice = new decimal(0);
                num23 = new decimal(0);
                GuillotineMarkUp_Actual = new decimal(0);
            }
            return num23;
        }

        public decimal InkCalculation(int CompanyID, string EstimateType, int Quantity, decimal InkMarkup, DataRow drQty, long EstimateItemID, ref decimal InkCostExMarkup, ref decimal InkMarkupPrice, long EstimateBookletItemID, int partcount, string para, int QuantityNumber, string ProfitTaxKey)
        {
            long num = (long)0;
            decimal num1 = Convert.ToDecimal(drQty["JobHeight"]);
            decimal num2 = Convert.ToDecimal(drQty["JobWidth"]);
            decimal num3 = new decimal(0);
            decimal inkCostExMarkup = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
          
            string ppm = "In.";
            DataTable dtRegionalSettings_new = UI.Setting.SettingsBasePage.settings_regionalsettings_select(CompanyID);
            foreach (DataRow dataRow in dtRegionalSettings_new.Rows)
            {
                ppm = Convert.ToString(dataRow["PaperMeasure"]);
            }

            if (EstimateType != "L")
            {
                string empty = string.Empty;
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                DataTable dataTable = new DataTable();
                if (EstimateType == "F")
                {
                    dataTable = EstimatesBasePage.estimate_litho_ink_select_inkcost_popup(CompanyID, EstimateItemID, "Parts1", "");
                }
                else if (EstimateType == "D")
                {
                    dataTable = EstimatesBasePage.estimate_lithoPad_ink_select_inkcost_popup(CompanyID, EstimateItemID, "Parts1", "");
                }
                else if (EstimateType == "K")
                {
                    dataTable = EstimatesBasePage.estimate_lithobooklet_ink_select_inkcost_popup(CompanyID, EstimateItemID, EstimateBookletItemID, string.Concat("Parts", partcount), "");
                }
                else if (EstimateType == "N")
                {
                    dataTable = EstimatesBasePage.estimate_lithoNCR_ink_select_inkcost_popup(CompanyID, EstimateItemID, EstimateBookletItemID, string.Concat("Parts", partcount), "");
                }
                string paperMeasure = "In.";
                if (EstimateType == "K")
                {
                    //Retrieve the setting from Regional Settings
                    DataTable dtRegionalSettings = UI.Setting.SettingsBasePage.settings_regionalsettings_select(CompanyID);
                    foreach (DataRow dataRow in dtRegionalSettings.Rows)
                    {
                        paperMeasure = Convert.ToString(dataRow["PaperMeasure"]);
                    }
                }

                int num13 = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    row["sidesprinted"].ToString();
                    string isdoubleeSided = row["sidesprinted"].ToString();
                    long num14 = Convert.ToInt64(row["InkID"]);
                    DataTable dataTable1 = EstimatesBasePage.PCR_Estimate_InkMarkup_Select(CompanyID, EstimateItemID, Convert.ToInt64(row["InkID"]), EstimateBookletItemID, EstimateType, QuantityNumber);
                    try
                    {
                        if (partcount == 0)
                        {
                            partcount = 1;
                        }
                        DataRow[] dataRowArray = dataTable1.Select(string.Concat(" Sectionname='Parts", partcount, "' or Sectionname=''"));
                        if ((para == "updateqty" || para == "updatebookqty") && ProfitTaxKey.ToLower() == "database")
                        {
                            if (QuantityNumber == 1)
                            {
                                if (Convert.ToDecimal(dataRowArray[num13]["inkcostexmarkup1"]) > new decimal(0))
                                {
                                    InkMarkup = Convert.ToDecimal(dataRowArray[num13]["InkMarkup"]);
                                }
                            }
                            else if (QuantityNumber == 2)
                            {
                                if (Convert.ToDecimal(dataRowArray[num13]["inkcostexmarkup2"]) > new decimal(0))
                                {
                                    InkMarkup = Convert.ToDecimal(dataRowArray[num13]["InkMarkup"]);
                                }
                            }
                            else if (QuantityNumber == 3)
                            {
                                if (Convert.ToDecimal(dataRowArray[num13]["inkcostexmarkup3"]) > new decimal(0))
                                {
                                    InkMarkup = Convert.ToDecimal(dataRowArray[num13]["InkMarkup"]);
                                }
                            }
                            else if (QuantityNumber == 4 && Convert.ToDecimal(dataRowArray[num13]["inkcostexmarkup4"]) > new decimal(0))
                            {
                                InkMarkup = Convert.ToDecimal(dataRowArray[num13]["InkMarkup"]);
                            }
                        }
                        num = Convert.ToInt64(dataRowArray[num13]["EstimateInkCalcID"]);
                    }
                    catch
                    {
                    }
                    string str = Convert.ToString(row["InkType"]);
                    num8 = (row["InkMinimumCost"].ToString() == "" ? new decimal(0) : Convert.ToDecimal(row["InkMinimumCost"]));
                    decimal num15 = Convert.ToDecimal(row["DefaultInkCoverageSide"]);
                    decimal num16 = num15 / new decimal(100);
                    decimal num17 = new decimal(0);
                    if (str != "M")
                    {
                        num9 = Convert.ToDecimal(row["InkUnitPrice"]);
                        decimal num18 = new decimal(0);
                        decimal num19 = new decimal(0);
                        if (ppm == "In." && EstimateType == "K")
                        {
                            num18 = Convert.ToDecimal(drQty["JobWidth"]);                            
                        }
                        else if (ppm == "mm")
                        {
                            num18 = Convert.ToDecimal(drQty["JobWidth"]) / new decimal(10);
                        }
                        else
                        {
                            num18 = Convert.ToDecimal(drQty["JobWidth"]);  
                        }

                        if (ppm == "In." && EstimateType == "K")
                        {
                            num19 = Convert.ToDecimal(drQty["JobHeight"]);                           
                        }
                        else if (ppm == "mm")
                        {
                            num19 = Convert.ToDecimal(drQty["JobHeight"]) / new decimal(10);
                        }
                        else
                        {
                            num19 = Convert.ToDecimal(drQty["JobHeight"]);     
                        }
                        decimal num20 = num18 * num19;

                        if (num15 != new decimal(0))
                        {
                            decimal quantity = 0;
                            if (EstimateType == "D" || EstimateType == "N")
                            {
                                quantity = (num20 * Quantity) * Convert.ToInt32(row["LeavesPerPad"]);
                            }
                            else
                            {
                                //quantity = (EstimateType != "K" ? num20 * Quantity : (num20 * Quantity) * Convert.ToDecimal(row["NoOfSignatures"]));
                                //quantity = (EstimateType != "K" ? num20 * Quantity : (num20 * Quantity) * NoOfPagesInSection);
                              
                                // NoOfPagesInSection
                                int NoOfPagesInSection = -1;

                                if (drQty.Table.Columns.Contains("NoOfPagesInSection"))
                                {
                                    if (!drQty.IsNull("NoOfPagesInSection"))
                                    {
                                        NoOfPagesInSection = Convert.ToInt32(drQty["NoOfPagesInSection"]);
                                    }
                                }

                                if (NoOfPagesInSection != -1)
                                {
                                    quantity = (EstimateType == "K" ? (num20 * Quantity) * NoOfPagesInSection : num20 * Quantity);
                                }
                                else
                                {
                                    quantity = (EstimateType != "K" ? num20 * Quantity : (num20 * Quantity) * Convert.ToDecimal(row["NoOfSignatures"]));
                                }
                            }


                            if (paperMeasure == "mm" && EstimateType == "K") // Metric case (mm)
                            {
                                num17 = (quantity * num16) * num9;
                                num17 = num17 / 2;
                            }
                            else if (paperMeasure == "In." && EstimateType == "K")
                            {
                                //Imperial(Inches)
                                num17 = (quantity * num16) * num9;
                                num17 = num17 / 2;
                            }
                            else
                            {
                                num17 = (quantity * num16) * num9;
                            }

                        }
                    }
                    else
                    {
                        int quantity1 = 0;
                        if (EstimateType == "D" || EstimateType == "N")
                        {
                            quantity1 = Quantity * Convert.ToInt32(row["LeavesPerPad"]);
                        }
                        else
                        {
                            quantity1 = (EstimateType != "K" ? Quantity : Quantity * Convert.ToInt32(row["NoOfSignatures"]));
                        }
                        string empty1 = string.Empty;
                        try
                        {
                            empty1 = EstimatesBasePage.inkMatrixGetValues(Convert.ToInt32(quantity1), CompanyID, num14);
                        }
                        catch
                        {
                        }
                        foreach (DataRow dataRow in EstimatesBasePage.select_InventoryInkMatrixDetails_inkCal(CompanyID, num14, empty1).Rows)
                        {
                            num10 = Convert.ToDecimal(dataRow["ChargableSheets"]);
                            num11 = Convert.ToDecimal(dataRow["ChargableCost"]);
                            num12 = Convert.ToDecimal(dataRow["SetUpCost"]);
                        }
                        num17 = (num10 == new decimal(0) ? new decimal(0) : Convert.ToDecimal((num11 / num10) * quantity1));
                    }
                    decimal inkMarkup = num17 + ((num17 * InkMarkup) / new decimal(100));
                    decimal num21 = new decimal(0);
                    decimal num22 = new decimal(0);
                    if (str != "M")
                    {
                        decimal num23 = new decimal(0);
                        inkMarkup = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num17, InkMarkup, num8, out num22, out num7, ref num23);
                        EstimatesBasePage.PCR_Estimate_InkMarkup_Update(num22, InkMarkup, (num22 * num7) / new decimal(100), new decimal(0), num8, num17, QuantityNumber, num);
                    }
                    else
                    {
                        inkMarkup = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num17, InkMarkup, num8, out num22, out num7, ref num12);
                        EstimatesBasePage.PCR_Estimate_InkMarkup_Update(num22 + num12, InkMarkup, (num22 * num7) / new decimal(100), num12, num8, num17 + num12, QuantityNumber, num);
                    }
                    num21 = num21 + ((num22 * num7) / new decimal(100));
                    num22 = num22 + num12;
                    InkMarkupPrice = InkMarkupPrice + num21;
                    num6 = num6 + inkMarkup;
                    num13++;
                }
            }
            else
            {
                string str1 = drQty["OneSqCmInkCost"].ToString();
                if (!string.IsNullOrEmpty(str1.Trim()))
                {
                    decimal num24 = new decimal(0);
                    decimal num25 = new decimal(0);

                    if (ppm == "mm")
                    {
                        num24 = num2 / new decimal(10);
                        num25 = num24 * (num1 / new decimal(10));
                    }
                    else
                    {
                        num24 = num2;
                        num25 = num24 * (num1);
                    }

                    str1.Split(new char[] { '±' });
                    DataTable dataTable2 = EstimatesBasePage.LargeItem_ink_UnitPrice_MinimumCost_Select(CompanyID, EstimateItemID);
                    decimal num26 = new decimal(0);
                    int num27 = 0;
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        string str2 = drQty["Colour"].ToString();
                        decimal num28 = Convert.ToDecimal(drQty["InkCoverageSide1"]);
                        decimal num29 = Convert.ToDecimal(drQty["InkCoverageSide2"]);
                        num8 = (row1["InkMinimumCost"].ToString() == "" ? new decimal(0) : Convert.ToDecimal(row1["InkMinimumCost"]));
                        int num30 = Convert.ToInt16(dataTable2.Rows[0]["rownumber"].ToString());
                        DataTable dataTable3 = EstimatesBasePage.PCR_Estimate_InkMarkup_Select(CompanyID, EstimateItemID, Convert.ToInt64(row1["InventoryID"]), EstimateBookletItemID, EstimateType, QuantityNumber);
                        try
                        {
                            if (para == "updateqty" && ProfitTaxKey.ToLower() == "database")
                            {
                                InkMarkup = Convert.ToDecimal(dataTable3.Rows[num27]["InkMarkup"]);
                            }
                            num = Convert.ToInt64(dataTable3.Rows[num27]["EstimateInkCalcID"]);
                        }
                        catch
                        {
                        }
                        num27++;
                        if (!Convert.ToBoolean(drQty["IsDoubleSided"]) && num28 != new decimal(0))
                        {
                            if (string.Compare(str2, "black", true) != 0)
                            {
                                decimal quantity2 = num25 * Quantity;
                                decimal num31 = num28 / num30;
                                decimal num32 = quantity2 / num30;
                                decimal num33 = (num32 * num31) / new decimal(100);
                                decimal num34 = num33 * Convert.ToDecimal(row1["UnitPrice"]);
                                num3 = num3 + num34;
                                decimal inkMarkup1 = (num34 * InkMarkup) / new decimal(100);
                                num26 = num34;
                            }
                            else
                            {
                                decimal quantity3 = num25 * Quantity;
                                decimal num35 = num28 / num30;
                                decimal num36 = quantity3 / num30;
                                decimal num37 = (num36 * num35) / new decimal(100);
                                decimal num38 = num37 * Convert.ToDecimal(row1["UnitPrice"]);
                                num3 = num3 + num38;
                                decimal inkMarkup2 = (num38 * InkMarkup) / new decimal(100);
                                num26 = num38;
                            }
                            decimal num39 = new decimal(0);
                            num4 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num26, InkMarkup, num8, out InkCostExMarkup, out num7, ref num39);
                            num5 = num5 + num4;
                            inkCostExMarkup = inkCostExMarkup + ((InkCostExMarkup * num7) / new decimal(100));
                        }
                        else if (num29 != new decimal(0) && Convert.ToBoolean(drQty["IsDoubleSided"]))
                        {
                            if (string.Compare(str2, "black", true) != 0)
                            {
                                decimal num40 = num29 / num30;
                                decimal num41 = num25 / num30;
                                decimal num42 = (num41 * num40) / new decimal(100);
                                decimal num43 = num42 * Convert.ToDecimal(row1["UnitPrice"]);
                                num3 = num3 + num43;
                                decimal inkMarkup3 = (num43 * InkMarkup) / new decimal(100);
                                num26 = num43;
                            }
                            else
                            {
                                decimal num44 = num29 / num30;
                                decimal num45 = num25 / num30;
                                decimal num46 = (num45 * num44) / new decimal(100);
                                decimal num47 = num46 * Convert.ToDecimal(row1["UnitPrice"]);
                                num3 = num3 + num47;
                                decimal inkMarkup4 = (num47 * InkMarkup) / new decimal(100);
                                num26 = num47;
                            }
                            decimal num48 = new decimal(0);
                            num4 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num26, InkMarkup, num8, out InkCostExMarkup, out num7, ref num48);
                            num5 = num5 + num4;
                            inkCostExMarkup = inkCostExMarkup + ((InkCostExMarkup * num7) / new decimal(100));
                        }
                        EstimatesBasePage.PCR_Estimate_InkMarkup_Update(InkCostExMarkup, InkMarkup, (InkCostExMarkup * num7) / new decimal(100), new decimal(0), num8, num26, QuantityNumber, num);
                    }
                    num6 = num5;
                    InkMarkupPrice = inkCostExMarkup;
                }
            }
            InkCostExMarkup = num6 - InkMarkupPrice;
            return num6;
        }

        public decimal InkCalculationforLargeFormat(int CompanyID, string EstimateType, int Quantity, decimal InkMarkup, DataRow drQty, long EstimateItemID, ref decimal InkCostExMarkup, ref decimal InkMarkupPrice, long EstimateBookletItemID, int partcount, string para, int QuantityNumber, string ProfitTaxKey, string EstimateInkCalID)
        {
            long num = (long)0;
            decimal num1 = Convert.ToDecimal(drQty["JobHeight"]);
            decimal num2 = Convert.ToDecimal(drQty["JobWidth"]);
            // change formula as per ticket 10195
            //if (Convert.ToString(drQty["WidthType"]) == "In.")
            //{
            //    num1 = num1 / new decimal(39.37);
            //    num2 = num2 / new decimal(39.37);
            //}

            decimal num3 = new decimal(0);
            decimal inkCostExMarkup = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);

            string ppm = "In.";
            DataTable dtRegionalSettings_new = UI.Setting.SettingsBasePage.settings_regionalsettings_select(CompanyID);
            foreach (DataRow dataRow in dtRegionalSettings_new.Rows)
            {
                ppm = Convert.ToString(dataRow["PaperMeasure"]);
            }

            if (EstimateType == "L")
            {
                string str = drQty["OneSqCmInkCost"].ToString();
                string strInkMarkups = drQty["OneSqCmInkMarkup"].ToString();

                if (!string.IsNullOrEmpty(str.Trim()))
                {
                    decimal num9 = new decimal(0);
                    decimal num10 = new decimal(0);
                    if (ppm == "mm")
                    {
                        num9 = num2 / new decimal(10);
                        num10 = num9 * (num1 / new decimal(10));
                    }
                    else
                    {
                        num9 = num2;
                        num10 = num9 * (num1);
                    }
                    
                    str.Split(new char[] { '±' });
                    string [] inkMarkups=strInkMarkups.Split(new char[] { '±' });
                    Array.Reverse(inkMarkups);
                    DataTable dataTable = EstimatesBasePage.LargeItem_Ink_Details_Select(CompanyID, EstimateItemID, drQty["Colour"].ToString(), drQty["SideColor"].ToString(), Convert.ToBoolean(drQty["IsDoubleSided"]));
                    decimal num11 = new decimal(0);
                    decimal num12 = new decimal(0);
                    int num13 = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string str1 = "color";
                        string str2 = "color";
                        if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                        {
                            str2 = drQty["Colour"].ToString();
                            str1 = drQty["SideColor"].ToString();
                        }
                        else
                        {
                            str1 = drQty["Colour"].ToString();
                        }
                        decimal num14 = Convert.ToDecimal(drQty["InkCoverageSide1"]);
                        decimal num15 = Convert.ToDecimal(drQty["InkCoverageSide2"]);
                        decimal num16 = Convert.ToDecimal(drQty["WhiteInkCoverageSide1"]);
                        decimal num17 = Convert.ToDecimal(drQty["WhiteInkCoverageSide2"]);
                        num8 = (row["InkMinimumCost"].ToString() == "" ? new decimal(0) : Convert.ToDecimal(row["InkMinimumCost"]));
                        int num18 = Convert.ToInt16(row["ActualNOOfInks_in_FC"]);
                        int num19 = Convert.ToInt16(drQty["DPI"]);
                        DataTable dataTable1 = EstimatesBasePage.PCR_Estimate_InkMarkup_Select(CompanyID, EstimateItemID, Convert.ToInt64(row["InventoryID"]), EstimateBookletItemID, EstimateType, QuantityNumber);
                        try
                        {
                            if (para == "updateqty" && ProfitTaxKey.ToLower() == "database")
                            {
                                InkMarkup = Convert.ToDecimal(dataTable1.Rows[num13]["InkMarkup"]);
                            }
                            num = Convert.ToInt64(dataTable1.Rows[num13]["EstimateInkCalcID"]);
                        }
                        catch
                        {
                        }
                        if((inkMarkups.Length -1) >= num13)
                        {
                            if (inkMarkups[num13] == "0.0000000000" || inkMarkups[num13] == "-1.0000000000" || inkMarkups[num13] == "")
                            {
                                InkMarkup = Convert.ToDecimal(dataTable1.Rows[num13]["InkMarkup"]);
                            }
                            else
                            {
                                InkMarkup = Convert.ToDecimal(inkMarkups[num13]);
                            }
                        }
                        else
                        {
                            InkMarkup = Convert.ToDecimal(dataTable1.Rows[num13]["InkMarkup"]);
                        }
                        if (QuantityNumber == 1 && para != "updateqty")
                        {
                            //EstimatesBasePage.PC_EstimateLargeItem_InkMarkUp_Insert(Convert.ToInt64(dataTable1.Rows[num13]["EstimateInkCalcID"]), InkMarkup);
                            EstimatesBasePage.PC_EstimateLargeItem_InkMarkUp_Insert(Convert.ToInt64(dataTable1.Rows[num13]["EstimateInkCalcID"]), InkMarkup);
                        }
                        num13++;
                        if (!Convert.ToBoolean(drQty["IsDoubleSided"]))
                        {
                            if (string.Compare(str1, "color", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity = num10 * Quantity;
                                    decimal num20 = num14 / num18;
                                    //decimal num21 = quantity / num18;
                                    decimal num22 = (quantity * num20) / new decimal(100);
                                    decimal num23 = num22 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num23;
                                    decimal inkMarkup = (num23 * InkMarkup) / new decimal(100);
                                    num11 = (num19 != 1000 ? num23 : num23 * Convert.ToDecimal(1.66));
                                }
                            }
                            else if (string.Compare(str1, "swhite", true) == 0)
                            {
                                if (Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity1 = num10 * Quantity;
                                    decimal num24 = num16 / new decimal(1);
                                    decimal num25 = quantity1 / new decimal(1);
                                    decimal num26 = (num25 * num24) / new decimal(100);
                                    decimal num27 = num26 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num27;
                                    decimal inkMarkup1 = (num27 * InkMarkup) / new decimal(100);
                                    num11 = num27;
                                }
                            }
                            else if (string.Compare(str1, "dwhite", true) == 0)
                            {
                                if (Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity2 = num10 * Quantity;
                                    decimal num28 = num16 / new decimal(1);
                                    decimal num29 = quantity2 / new decimal(1);
                                    decimal num30 = (num29 * num28) / new decimal(100);
                                    decimal num31 = num30 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num31;
                                    decimal inkMarkup2 = (num31 * InkMarkup) / new decimal(100);
                                    num11 = num31 * new decimal(2);
                                }
                            }
                            else if (string.Compare(str1, "colourwithswhite", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity3 = num10 * Quantity;
                                    decimal num32 = num14 / num18;
                                    //decimal num33 = quantity3 / num18;
                                    decimal num34 = (quantity3 * num32) / new decimal(100);
                                    decimal num35 = num34 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num35;
                                    decimal inkMarkup3 = (num35 * InkMarkup) / new decimal(100);
                                    num11 = (num19 != 1000 ? num35 : num35 * Convert.ToDecimal(1.66));
                                }
                                else
                                {
                                    decimal quantity4 = num10 * Quantity;
                                    decimal num36 = num16 / new decimal(1);
                                    //decimal num37 = quantity4 / new decimal(1);
                                    decimal num38 = (quantity4 * num36) / new decimal(100);
                                    decimal num39 = num38 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num39;
                                    decimal inkMarkup4 = (num39 * InkMarkup) / new decimal(100);
                                    num11 = num39;
                                }
                            }
                            else if (string.Compare(str1, "colourwithdwhite", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity5 = num10 * Quantity;
                                    decimal num40 = num14 / num18;
                                    //decimal num41 = quantity5 / num18;
                                    decimal num42 = (quantity5 * num40) / new decimal(100);
                                    decimal num43 = num42 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num43;
                                    decimal inkMarkup5 = (num43 * InkMarkup) / new decimal(100);
                                    num11 = (num19 != 1000 ? num43 : num43 * Convert.ToDecimal(1.66));
                                }
                                else
                                {
                                    decimal quantity6 = num10 * Quantity;
                                    decimal num44 = num16 / new decimal(1);
                                    //decimal num45 = quantity6 / new decimal(1);
                                    decimal num46 = (quantity6 * num44) / new decimal(100);
                                    decimal num47 = num46 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num47;
                                    decimal inkMarkup6 = (num47 * InkMarkup) / new decimal(100);
                                    num11 = num47 * new decimal(2);
                                }
                            }
                            decimal num48 = new decimal(0);
                            num4 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num11, InkMarkup, num8, out InkCostExMarkup, out num7, ref num48);
                            num5 = num5 + num4;
                            inkCostExMarkup = inkCostExMarkup + ((InkCostExMarkup * num7) / new decimal(100));
                        }
                        else if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                        {
                            if (string.Compare(str2, "color", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity7 = num10 * Quantity;
                                    decimal num49 = num14 / num18;
                                    //decimal num50 = quantity7 / num18;
                                    decimal num51 = (quantity7 * num49) / new decimal(100);
                                    decimal num52 = num51 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num52;
                                    decimal inkMarkup7 = (num52 * InkMarkup) / new decimal(100);
                                    num11 = (num19 != 1000 ? num52 : num52 * Convert.ToDecimal(1.66));
                                }
                            }
                            else if (string.Compare(str2, "swhite", true) == 0)
                            {
                                if (Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity8 = num10 * Quantity;
                                    decimal num53 = num16 / new decimal(1);
                                    decimal num54 = quantity8 / new decimal(1);
                                    decimal num55 = (num54 * num53) / new decimal(100);
                                    decimal num56 = num55 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num56;
                                    decimal inkMarkup8 = (num56 * InkMarkup) / new decimal(100);
                                    num11 = num56;
                                }
                            }
                            else if (string.Compare(str2, "dwhite", true) == 0)
                            {
                                if (Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity9 = num10 * Quantity;
                                    decimal num57 = num16 / new decimal(1);
                                    decimal num58 = quantity9 / new decimal(1);
                                    decimal num59 = (num58 * num57) / new decimal(100);
                                    decimal num60 = num59 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num60;
                                    decimal inkMarkup9 = (num60 * InkMarkup) / new decimal(100);
                                    num11 = num60 * new decimal(2);
                                }
                            }
                            else if (string.Compare(str2, "colourwithswhite", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity10 = num10 * Quantity;
                                    decimal num61 = num14 / num18;
                                    //decimal num62 = quantity10 / num18;
                                    decimal num63 = (quantity10 * num61) / new decimal(100);
                                    decimal num64 = num63 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num64;
                                    decimal inkMarkup10 = (num64 * InkMarkup) / new decimal(100);
                                    num11 = (num19 != 1000 ? num64 : num64 * Convert.ToDecimal(1.66));
                                }
                                else
                                {
                                    decimal quantity11 = num10 * Quantity;
                                    decimal num65 = num16 / new decimal(1);
                                    //decimal num66 = quantity11 / new decimal(1);
                                    decimal num67 = (quantity11 * num65) / new decimal(100);
                                    decimal num68 = num67 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num68;
                                    decimal inkMarkup11 = (num68 * InkMarkup) / new decimal(100);
                                    num11 = num68;
                                }
                            }
                            else if (string.Compare(str2, "colourwithdwhite", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity12 = num10 * Quantity;
                                    decimal num69 = num14 / num18;
                                    //decimal num70 = quantity12 / num18;
                                    decimal num71 = (quantity12 * num69) / new decimal(100);
                                    decimal num72 = num71 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num72;
                                    decimal inkMarkup12 = (num72 * InkMarkup) / new decimal(100);
                                    num11 = (num19 != 1000 ? num72 : num72 * Convert.ToDecimal(1.66));
                                }
                                else
                                {
                                    decimal quantity13 = num10 * Quantity;
                                    decimal num73 = num16 / new decimal(1);
                                    //decimal num74 = quantity13 / new decimal(1);
                                    decimal num75 = (quantity13 * num73) / new decimal(100);
                                    decimal num76 = num75 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num76;
                                    decimal inkMarkup13 = (num76 * InkMarkup) / new decimal(100);
                                    num11 = num76 * new decimal(2);
                                }
                            }
                            if (string.Compare(str1, "color", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity14 = num10 * Quantity;
                                    decimal num77 = num15 / num18;
                                    //decimal num78 = quantity14 / num18;
                                    decimal num79 = (quantity14 * num77) / new decimal(100);
                                    decimal num80 = num79 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num80;
                                    decimal inkMarkup14 = (num80 * InkMarkup) / new decimal(100);
                                    num12 = (num19 != 1000 ? num80 : num80 * Convert.ToDecimal(1.66));
                                }
                            }
                            else if (string.Compare(str1, "swhite", true) == 0)
                            {
                                if (Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity15 = num10 * Quantity;
                                    decimal num81 = num17 / new decimal(1);
                                    decimal num82 = quantity15 / new decimal(1);
                                    decimal num83 = (num82 * num81) / new decimal(100);
                                    decimal num84 = num83 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num84;
                                    decimal inkMarkup15 = (num84 * InkMarkup) / new decimal(100);
                                    num12 = num84;
                                }
                            }
                            else if (string.Compare(str1, "dwhite", true) == 0)
                            {
                                if (Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity16 = num10 * Quantity;
                                    decimal num85 = num17 / new decimal(1);
                                    decimal num86 = quantity16 / new decimal(1);
                                    decimal num87 = (num86 * num85) / new decimal(100);
                                    decimal num88 = num87 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num88;
                                    decimal inkMarkup16 = (num88 * InkMarkup) / new decimal(100);
                                    num12 = num88 * new decimal(2);
                                }
                            }
                            else if (string.Compare(str1, "colourwithswhite", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity17 = num10 * Quantity;
                                    decimal num89 = num15 / num18;
                                    //decimal num90 = quantity17 / num18;
                                    decimal num91 = (quantity17 * num89) / new decimal(100);
                                    decimal num92 = num91 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num92;
                                    decimal inkMarkup17 = (num92 * InkMarkup) / new decimal(100);
                                    num12 = (num19 != 1000 ? num92 : num92 * Convert.ToDecimal(1.66));
                                }
                                else
                                {
                                    decimal quantity18 = num10 * Quantity;
                                    decimal num93 = num17 / new decimal(1);
                                    //decimal num94 = quantity18 / new decimal(1);
                                    decimal num95 = (quantity18 * num93) / new decimal(100);
                                    decimal num96 = num95 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num96;
                                    decimal inkMarkup18 = (num96 * InkMarkup) / new decimal(100);
                                    num12 = num96;
                                }
                            }
                            else if (string.Compare(str1, "colourwithdwhite", true) == 0)
                            {
                                if (!Convert.ToBoolean(row["IswhiteInk"]))
                                {
                                    decimal quantity19 = num10 * Quantity;
                                    decimal num97 = num15 / num18;
                                    //decimal num98 = quantity19 / num18;
                                    decimal num99 = (quantity19 * num97) / new decimal(100);
                                    decimal num100 = num99 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num100;
                                    decimal inkMarkup19 = (num100 * InkMarkup) / new decimal(100);
                                    num12 = (num19 != 1000 ? num100 : num100 * Convert.ToDecimal(1.66));
                                }
                                else
                                {
                                    decimal quantity20 = num10 * Quantity;
                                    decimal num101 = num17 / new decimal(1);
                                    //decimal num102 = quantity20 / new decimal(1);
                                    decimal num103 = (quantity20 * num101) / new decimal(100);
                                    decimal num104 = num103 * Convert.ToDecimal(row["UnitPrice"]);
                                    num3 = num3 + num104;
                                    decimal inkMarkup20 = (num104 * InkMarkup) / new decimal(100);
                                    num12 = num104 * new decimal(2);
                                }
                            }
                            decimal num105 = num11 + num12;
                            decimal num106 = new decimal(0);
                            num4 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num105, InkMarkup, num8, out InkCostExMarkup, out num7, ref num106);
                            num5 = num5 + num4;
                            inkCostExMarkup = inkCostExMarkup + ((InkCostExMarkup * num7) / new decimal(100));
                            num11 = num105;
                        }
                        EstimatesBasePage.PCR_Estimate_InkMarkup_Update(InkCostExMarkup, InkMarkup, (InkCostExMarkup * num7) / new decimal(100), new decimal(0), num8, num11, QuantityNumber, num);
                        num11 = new decimal(0);
                        num12 = new decimal(0);
                    }
                    num6 = num5;
                    InkMarkupPrice = inkCostExMarkup;
                }
            }
            InkCostExMarkup = num6 - InkMarkupPrice;
            return num6;
        }

        public decimal MakeReadyCalculation(int CompanyID, string EstimateType, int Quantity, decimal MakeReadyMarkup, DataRow drQty, ref decimal MakeReadyCostExMarkup, ref decimal MakeReadyMarkupPrice, int NCRCount)
        {
            decimal num = new decimal(0);
            decimal makeReadyCostExMarkup = new decimal(0);
            if (drQty["MakeReadyPerPlateCheck"].ToString().ToLower() == "true")
            {
                num = Convert.ToDecimal(drQty["MakeReadyUnitPrice"].ToString());
                if (Convert.ToBoolean(drQty["WorknTurn"]))
                {
                    num = Convert.ToDecimal(drQty["MakeReadyWork_n_Turn"]);
                }
                else if (Convert.ToBoolean(drQty["WorknTumble"]))
                {
                    num = Convert.ToDecimal(drQty["MakeReadyWork_n_Tumble"]);
                }
                long num1 = Convert.ToInt64(drQty["EstimateCalculationID"]);
                EstimatesBasePage.PCR_estimates_Update_SetupCharge_Or_MakeReady(num1, num, "makeready");
                decimal num2 = Convert.ToDecimal(drQty["NoofMakeReady"].ToString());
                MakeReadyCostExMarkup = num2 * num;
                MakeReadyMarkupPrice = (MakeReadyCostExMarkup * MakeReadyMarkup) / new decimal(100);
                makeReadyCostExMarkup = MakeReadyCostExMarkup + MakeReadyMarkupPrice;
                if (EstimateType == "N" && drQty["NcrImageType"].ToString().ToLower() == "common" && NCRCount != 0)
                {
                    MakeReadyCostExMarkup = new decimal(0);
                    makeReadyCostExMarkup = new decimal(0);
                    MakeReadyMarkupPrice = new decimal(0);
                }
            }
            return makeReadyCostExMarkup;
        }

        public decimal MaterrialCalculation(int CompanyID, string EstimateType, int Quantity, int MaterialNo, decimal MaterialMarkup, DataRow drQty, ref decimal MaterialCostExMarkup, ref decimal MaterialMarkupPrice, decimal NewTotalpaper, ref decimal Totalpaper, decimal MaterialLength_Required, ref bool IsRoll)
        {
            string empty = string.Empty;
            decimal num = new decimal(0);
            empty = drQty["PrintLayout"].ToString();
            decimal num1 = Convert.ToDecimal(drQty["PortraitValue"]);
            decimal num2 = Convert.ToDecimal(drQty["LandscapeValue"]);
            num = (empty == "L" ? num2 : num1);
            decimal num3 = Convert.ToDecimal(drQty["RunningSpoilage"].ToString());
            decimal num4 = Convert.ToDecimal(drQty["SetupSpoilage"].ToString());
            Convert.ToDecimal(drQty["Height"]);
            Convert.ToDecimal(drQty["Width"]);
            Convert.ToDecimal(drQty["SheetHeight"]);
            Convert.ToDecimal(drQty["SheetWidth"]);
            Convert.ToDecimal(drQty["JobHeight"]);
            Convert.ToDecimal(drQty["JobWidth"]);
            //decimal num5 = drQty["calctype"].ToString().ToLower() == "tilling" ? Convert.ToDecimal(drQty["PaperUnitPrice"]) : Convert.ToDecimal(drQty["MaterialUnitPrice"]);
            decimal num5 = Convert.ToDecimal(drQty["MaterialUnitPrice"]);
            decimal num6 = Convert.ToDecimal(drQty["PackedIn"]);
            decimal num7 = new decimal(0);
            bool flag = false;
            if (drQty["IsPaperUnitPriceLocked"].ToString().Trim().Length > 0)
            {
                flag = Convert.ToBoolean(drQty["IsPaperUnitPriceLocked"].ToString());
            }
            num7 = (!flag ? Convert.ToDecimal(drQty["PackedPrice"]) : num5 * num6);
            string str = string.Empty;
            if (EstimateType.ToLower() == "l")
            {
                drQty["calcType"].ToString();
            }
            bool flag1 = false;
            bool flag2 = false;
            if (MaterialNo == 1)
            {
                flag1 = Convert.ToBoolean(drQty["IsPricePerPack"]);
                flag2 = Convert.ToBoolean(drQty["IsPaperSupplied"]);
                IsRoll = false;
            }
            else if (MaterialNo == 2)
            {
                flag1 = Convert.ToBoolean(drQty["IsPricePerPack2"]);
                flag2 = Convert.ToBoolean(drQty["IsPaperSupplied2"]);
            }
            else if (MaterialNo == 3)
            {
                flag1 = Convert.ToBoolean(drQty["IsPricePerPack3"]);
                flag2 = Convert.ToBoolean(drQty["IsPaperSupplied3"]);
            }
            else if (MaterialNo == 4)
            {
                flag1 = Convert.ToBoolean(drQty["IsPricePerPack4"]);
                flag2 = Convert.ToBoolean(drQty["IsPaperSupplied4"]);
            }
            else if (MaterialNo == 5)
            {
                flag1 = Convert.ToBoolean(drQty["IsPricePerPack5"]);
                flag2 = Convert.ToBoolean(drQty["IsPaperSupplied5"]);
            }
            Convert.ToBoolean(drQty["IsIncludeGutters"]);
            Convert.ToDecimal(drQty["GutterHorizontal"]);
            Convert.ToDecimal(drQty["GutterVertical"]);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            string str1 = "singleitem";
            decimal num10 = new decimal(0);
            decimal materialCostExMarkup = new decimal(0);
            Totalpaper = EstimatesBasePage.GetPrintSheetCalulation(Quantity, num, num4, num3, num10, str1, new decimal(0), "", out num8);
            MaterialCostExMarkup = NewTotalpaper * num5;
            MaterialMarkupPrice = (MaterialCostExMarkup * MaterialMarkup) / new decimal(100);
            materialCostExMarkup = MaterialCostExMarkup + MaterialMarkupPrice;
            if (num6 > new decimal(0))
            {
                num9 = Math.Ceiling(NewTotalpaper / num6);
            }
            if (flag1)
            {
                NewTotalpaper = num9 * num6;
                decimal num11 = num9 * num7;
                MaterialMarkupPrice = (num11 * MaterialMarkup) / new decimal(100);
                MaterialCostExMarkup = num11;
                materialCostExMarkup = MaterialCostExMarkup + MaterialMarkupPrice;
            }
            else if (flag2)
            {
                MaterialCostExMarkup = new decimal(0);
                MaterialMarkupPrice = new decimal(0);
                materialCostExMarkup = new decimal(0);
            }
            if (EstimateType == "L")
            {
                string str2 = drQty["InventoryPaperType"].ToString();
                decimal num12 = Convert.ToDecimal(drQty["PaperLength"]);
                Convert.ToDecimal(drQty["Row"]);
                Convert.ToDecimal(drQty["Col"]);
                decimal num13 = Convert.ToDecimal(drQty["PackedRollCost"]);
                decimal num14 = Convert.ToDecimal(drQty["PerQuantity"]);
                decimal num15 = Convert.ToDecimal(drQty["PaperWidth"]);
                if (string.Compare(str2, "roll", true) == 0 || string.Compare(str2, "web printing", true) == 0 || string.Compare(str2, "sheet", true) == 0)
                {
                    if (MaterialNo == 1)
                    {
                        IsRoll = true;
                    }
                    MaterialCostExMarkup = MaterialLength_Required * num5;
                    decimal num16 = new decimal(0);
                    SummaryClass.One_Roll_Cost(CompanyID, num13, num14, num6, num7, num15, num12, MaterialLength_Required, ref num16);
                    if (flag1)
                    {
                        MaterialCostExMarkup = num16;
                    }
                    else if (flag2)
                    {
                        MaterialCostExMarkup = new decimal(0);
                        MaterialMarkupPrice = new decimal(0);
                        materialCostExMarkup = new decimal(0);
                    }
                    MaterialMarkupPrice = (MaterialCostExMarkup * MaterialMarkup) / new decimal(100);
                    materialCostExMarkup = MaterialCostExMarkup + MaterialMarkupPrice;
                }
            }
            return materialCostExMarkup;
        }

        public decimal PaperCalculation(int CompanyID, string EstimateType, int Quantity, decimal PaperMarkup, DataRow drQty, ref decimal PaperCostExMarkup, ref decimal PaperMarkupPrice, ref decimal NewTotalpaper, ref decimal Totalpaper, ref decimal PaperLength_Required, ref decimal FullSheetArea, bool isFullSheetUsage = false, decimal valToDivide = 0)
        {
            string empty = string.Empty;
            decimal num = new decimal(0);
            decimal numStock = new decimal(0);
            valToDivide = valToDivide == 0.0000000000M ? 1 : valToDivide;
            if (EstimateType != "K")
            {
                if (drQty.Table.Columns.Contains("ManualValue"))
                {
                    empty = drQty["PrintLayout"].ToString();
                    decimal num1 = Convert.ToDecimal(drQty["PortraitValue"]);
                    decimal num2 = Convert.ToDecimal(drQty["LandscapeValue"]);
                    decimal manual = Convert.ToDecimal(drQty["ManualValue"]);
                    num = (empty == "L" ? num2 : empty == "P" ? num1 : manual);
                }
                else
                {
                    empty = drQty["PrintLayout"].ToString();
                    decimal num1 = Convert.ToDecimal(drQty["PortraitValue"]);
                    decimal num2 = Convert.ToDecimal(drQty["LandscapeValue"]);
                    num = (empty == "L" ? num2 : num1);
                }



            }
            else
            {
                empty = drQty["BookletFormat"].ToString();
                num = Convert.ToInt32(drQty["NoOfSignatures"]);
            }
            decimal num3 = new decimal(0);
            bool flag = false;
            decimal num4 = Convert.ToDecimal(drQty["RunningSpoilage"].ToString());
            decimal num5 = Convert.ToDecimal(drQty["SetupSpoilage"].ToString());
            decimal num6 = Convert.ToDecimal(drQty["Height"]);
            decimal num7 = Convert.ToDecimal(drQty["Width"]);
            decimal num8 = Convert.ToDecimal(drQty["SheetHeight"]);
            decimal num9 = Convert.ToDecimal(drQty["SheetWidth"]);
            decimal num10 = Convert.ToDecimal(drQty["JobHeight"]);
            decimal num11 = Convert.ToDecimal(drQty["JobWidth"]);
            if (drQty["IsPaperUnitPriceLocked"].ToString().Trim().Length > 0)
            {
                flag = Convert.ToBoolean(drQty["IsPaperUnitPriceLocked"].ToString());
            }
            decimal num12 = Convert.ToDecimal(drQty["PaperUnitPrice"]);
            decimal num13 = Convert.ToDecimal(drQty["PackedIn"]);
            num3 = (!flag ? Convert.ToDecimal(drQty["PackedPrice"]) : num12 * num13);
            bool flag1 = Convert.ToBoolean(drQty["IsPricePerPack"]);
            bool flag2 = Convert.ToBoolean(drQty["IsPaperSupplied"]);
            bool flag3 = Convert.ToBoolean(drQty["IsIncludeGutters"]);
            decimal num14 = Convert.ToDecimal(drQty["GutterHorizontal"]);
            Convert.ToDecimal(drQty["GutterVertical"]);
            string str = string.Empty;
            if (EstimateType.ToLower() == "l")
            {
                str = drQty["calcType"].ToString();
            }
            decimal num15 = new decimal(0);
            decimal num16 = new decimal(0);
            decimal num17 = new decimal(0);
            decimal num18 = new decimal(0);
            string str1 = "singleitem";
            decimal num19 = new decimal(0);
            decimal paperCostExMarkup = new decimal(0);
            if (EstimateType == "P" || EstimateType == "D" || EstimateType == "N" || EstimateType == "R")
            {
                if (EstimateType != "N")
                {
                    if (EstimateType != "R")
                    {
                        num17 = (drQty["LeavesPerPad"] == null ? new decimal(0) : Convert.ToDecimal(drQty["LeavesPerPad"]));
                    }
                    else
                    {
                        num17 = Convert.ToDecimal(drQty["NcrSetsPerPad"].ToString());
                    }
                }
                else
                {
                    num17 = Convert.ToDecimal(drQty["NcrSetsPerPad"].ToString());
                }
                str1 = "pad";
                num19 = num17;
            }
            else if (EstimateType == "B" || EstimateType == "K")
            {
                num18 = (drQty["NoOfSignatures"] == null ? new decimal(0) : Convert.ToDecimal(drQty["NoOfSignatures"]));
                str1 = "booklet";
                num19 = num18;
            }
            Totalpaper = EstimatesBasePage.GetPrintSheetCalulation(Quantity, num, num5, num4, num19, str1, new decimal(0), "", out num15);
            NewTotalpaper = EstimateBasePage.NoOfSheetsReturnByFirstTrim(num6, num7, num8, num9, empty, Totalpaper);
            string regionalSettings = (new BasePage()).GetRegionalSettings(CompanyID, "PaperMeasure");
            //if (EstimateType == "L" && (str.ToString().ToLower() == "square" || str.ToString().ToLower() == "tilling"))
            if (EstimateType == "L" && (str.ToString().ToLower() != "linear"))
            {
                if (regionalSettings != "In.")
                {
                    FullSheetArea = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                    FullSheetArea = (FullSheetArea + (FullSheetArea * (num4 / new decimal(100)))) + num5;

                    if (isFullSheetUsage && str.ToString().ToLower() != "tilling")
                    {

                        NewTotalpaper = ((num9 / new decimal(1000)) * (num8 / new decimal(1000)));
                        NewTotalpaper = NewTotalpaper * Math.Ceiling((Quantity / valToDivide));
                        PaperLength_Required = ((num9 / new decimal(1000)) * (num8 / new decimal(1000)));
                        PaperLength_Required = PaperLength_Required * Math.Ceiling((Quantity / valToDivide));
                    }
                    else
                    {
                        NewTotalpaper = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                        NewTotalpaper = (NewTotalpaper + (NewTotalpaper * (num4 / new decimal(100)))) + num5;
                        PaperLength_Required = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                        PaperLength_Required = (PaperLength_Required + (PaperLength_Required * (num4 / new decimal(100)))) + num5;
                    }
                }
                else
                {
                    NewTotalpaper = ((num10 / new decimal(12)) * (num11 / new decimal(12))) * Quantity;
                    NewTotalpaper = (NewTotalpaper + (NewTotalpaper * (num4 / new decimal(100)))) + num5;
                    PaperLength_Required = ((num10 / new decimal(12)) * (num11 / new decimal(12))) * Quantity;
                    PaperLength_Required = (PaperLength_Required + (PaperLength_Required * (num4 / new decimal(100)))) + num5;
                }
            }
            PaperCostExMarkup = NewTotalpaper * num12;
            PaperMarkupPrice = (PaperCostExMarkup * PaperMarkup) / new decimal(100);
            paperCostExMarkup = PaperCostExMarkup + PaperMarkupPrice;
            if (num13 > new decimal(0))
            {
                num16 = Math.Ceiling(NewTotalpaper / num13);
            }
            if (flag1)
            {
                NewTotalpaper = num16 * num13;
                decimal num20 = num16 * num3;
                PaperMarkupPrice = (num20 * PaperMarkup) / new decimal(100);
                PaperCostExMarkup = num20;
                paperCostExMarkup = PaperCostExMarkup + PaperMarkupPrice;
            }
            else if (flag2)
            {
                PaperCostExMarkup = new decimal(0);
                PaperMarkupPrice = new decimal(0);
                paperCostExMarkup = new decimal(0);
            }
            if (EstimateType == "L")
            {
                string str2 = drQty["InventoryPaperType"].ToString();
                decimal num21 = Convert.ToDecimal(drQty["PaperLength"]);
                decimal num22 = Convert.ToDecimal(drQty["Row"]);
                decimal num23 = Convert.ToDecimal(drQty["Col"]);
                decimal num24 = Convert.ToDecimal(drQty["PackedRollCost"]);
                decimal num25 = Convert.ToDecimal(drQty["PerQuantity"]);
                decimal num26 = Convert.ToDecimal(drQty["PaperWidth"]);
                if (string.Compare(str2, "roll", true) == 0 || string.Compare(str2, "web printing", true) == 0 || string.Compare(str2, "sheet", true) == 0)
                {
                    if (str.ToString().ToLower() == "square")
                    {
                        numStock = EstimatesBasePage.required_length_calculation(Quantity, empty, num, num10, num11, num8, num9, flag3, num14, num5, num4, num22, num23, regionalSettings, str2);
                        EstimatesBasePage.Update_InvStock_calculation(Convert.ToInt64((drQty["EstimateitemID"])), numStock);
                    }
                    if (str.ToString().ToLower() == "linear")
                    {
                        PaperLength_Required = EstimatesBasePage.required_length_calculation(Quantity, empty, num, num10, num11, num8, num9, flag3, num14, num5, num4, num22, num23, regionalSettings, str2);
                    }
                    else if (regionalSettings != "In.")
                    {

                        FullSheetArea = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                        FullSheetArea = (FullSheetArea + (FullSheetArea * (num4 / new decimal(100)))) + num5;
                        if (isFullSheetUsage && str.ToString().ToLower() != "tilling")
                        {
                            //NewTotalpaper = ((num9 / new decimal(1000)) * (num8 / new decimal(1000))) * Quantity;
                            PaperLength_Required = ((num9 / new decimal(1000)) * (num8 / new decimal(1000)));
                            PaperLength_Required = PaperLength_Required * Math.Ceiling((Quantity / valToDivide));
                        }
                        else
                        {
                            PaperLength_Required = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                            PaperLength_Required = (PaperLength_Required + (PaperLength_Required * (num4 / new decimal(100)))) + num5;
                        }

                    }
                    else
                    {
                        PaperLength_Required = ((num10 / new decimal(12)) * (num11 / new decimal(12))) * Quantity;
                        PaperLength_Required = (PaperLength_Required + (PaperLength_Required * (num4 / new decimal(100)))) + num5;
                    }
                    PaperCostExMarkup = PaperLength_Required * num12;
                    decimal num27 = new decimal(0);
                    SummaryClass.One_Roll_Cost(CompanyID, num24, num25, num13, num3, num26, num21, PaperLength_Required, ref num27);
                    if (flag1)
                    {
                        PaperCostExMarkup = num27;
                    }
                    else if (flag2)
                    {
                        PaperCostExMarkup = new decimal(0);
                        PaperMarkupPrice = new decimal(0);
                        paperCostExMarkup = new decimal(0);
                    }
                    PaperMarkupPrice = (PaperCostExMarkup * PaperMarkup) / new decimal(100);
                    paperCostExMarkup = PaperCostExMarkup + PaperMarkupPrice;
                }
                else if (str.ToString().ToLower() == "square")
                {
                    if (regionalSettings != "In.")
                    {


                        FullSheetArea = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                        FullSheetArea = (FullSheetArea + (FullSheetArea * (num4 / new decimal(100)))) + num5;

                        if (isFullSheetUsage)
                        {
                            //NewTotalpaper = ((num9 / new decimal(1000)) * (num8 / new decimal(1000))) * Quantity;
                            PaperLength_Required = ((num9 / new decimal(1000)) * (num8 / new decimal(1000)));
                            PaperLength_Required = PaperLength_Required * Math.Ceiling((Quantity / valToDivide));
                        }
                        else
                        {
                            PaperLength_Required = ((num10 / new decimal(1000)) * (num11 / new decimal(1000))) * Quantity;
                            PaperLength_Required = (PaperLength_Required + (PaperLength_Required * (num4 / new decimal(100)))) + num5;
                        }

                    }
                    else
                    {
                        PaperLength_Required = ((num10 / new decimal(12)) * (num11 / new decimal(12))) * Quantity;
                        PaperLength_Required = (PaperLength_Required + (PaperLength_Required * (num4 / new decimal(100)))) + num5;
                    }
                }
            }
            return paperCostExMarkup;
        }

        public decimal PlateCalculation(int CompanyID, string EstimateType, int Quantity, decimal PlateMarkup, DataRow drQty, ref decimal PlateCostExMarkup, ref decimal PlateMarkupPrice, int NCRCount)
        {
            decimal num = new decimal(0);
            decimal num1 = Convert.ToDecimal(drQty["PlateUnitPrice"].ToString());
            decimal num2 = Convert.ToDecimal(drQty["Noofplates"]);
            PlateCostExMarkup = num2 * num1;
            PlateMarkupPrice = (PlateCostExMarkup * PlateMarkup) / new decimal(100);
            num = PlateCostExMarkup + PlateMarkupPrice;
            if (EstimateType == "N" && drQty["NcrImageType"].ToString().ToLower() == "common" && NCRCount != 0)
            {
                PlateCostExMarkup = new decimal(0);
                num = new decimal(0);
                PlateMarkupPrice = new decimal(0);
            }
            return num;
        }

        public decimal PressCalculation(int CompanyID, string EstimateType, int Quantity, decimal PressMarkUp, DataRow drQty, decimal Totalpaper, ref decimal PressCostExMarkup, ref decimal PressMarkupPrice, decimal PaperLength_Required, ref decimal PressJobTimeSide1, ref decimal PressJobTimeSide2, ref decimal Zone_Side1_PressMarkupPercentage, ref decimal Zone_Side2_PressMarkupPercentage, ref decimal Zone_Side1_PressMarkupPrice, ref decimal Zone_Side2_PressMarkupPrice, ref decimal Zone_Side1_CostExMarkup, ref decimal Zone_Side2_CostExMarkup, ref decimal Zone_Side1_ChargeableRate, ref decimal Zone_Side2_ChargeableRate, ref decimal PressCostExMarkup_Actual, int QuantityNumber, ref decimal Zone_Side1_Cost, ref decimal Zone_Side2_Cost)
        {
            Zone_Side1_PressMarkupPercentage = new decimal(0);
            Zone_Side2_PressMarkupPercentage = new decimal(0);
            Zone_Side1_PressMarkupPrice = new decimal(0);
            Zone_Side2_PressMarkupPrice = new decimal(0);
            Zone_Side1_CostExMarkup = new decimal(0);
            Zone_Side2_CostExMarkup = new decimal(0);
            Zone_Side1_ChargeableRate = new decimal(0);
            Zone_Side2_ChargeableRate = new decimal(0);
            Convert.ToInt64(drQty["PressID"]);
            long num = Convert.ToInt64(drQty["EstimateCalculationID"]);
            string str = drQty["PressType"].ToString();
            decimal num1 = Convert.ToDecimal(drQty["HourlyCharge"]);
            decimal num2 = Convert.ToDecimal(drQty["PressSetupCharge"]);
            decimal num3 = Convert.ToDecimal(drQty["PressMinimumRunningCharge"]);
            decimal num4 = Convert.ToDecimal(drQty["PaperWeight"]);
            decimal num5 = Convert.ToDecimal(drQty["PrintPerHourLow"]);
            decimal num6 = Convert.ToDecimal(drQty["PrintPerHourMedium"]);
            decimal num7 = Convert.ToDecimal(drQty["PrintPerHourHigh"]);
            string str1 = (str == "L" ? drQty["PrintQuality"].ToString() : string.Empty);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            if (EstimateType == "L")
            {
                string str2 = drQty["InventorypaperType"].ToString();
                string empty = string.Empty;
                empty = drQty["calcType"].ToString();
                decimal num11 = new decimal(0);
                num8 = EstimatesBasePage.Large_Press_Cost_Ex_SetupCharge(str1, num5, num6, num7, num1, PaperLength_Required, Totalpaper, str2, empty, out num11);
                PressJobTimeSide1 = num11;
                PressJobTimeSide2 = new decimal(0);
                if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                {
                    num8 = num8 * new decimal(2);
                    //PressJobTimeSide1 = num11;
                    PressJobTimeSide2 = num11;
                }
                PressMarkupPrice = (num8 * PressMarkUp) / new decimal(100);
                PressCostExMarkup_Actual = num8 + num2;
                num8 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num8, PressMarkUp, num3, out PressCostExMarkup, out num10, ref num2);
                PressMarkupPrice = (PressCostExMarkup * num10) / new decimal(100);
                PressCostExMarkup = PressCostExMarkup + num2;
            }
            else if (EstimateType != "F" && EstimateType != "D" && EstimateType != "K" && EstimateType != "N")
            {
                string str3 = drQty["Colour"].ToString();
                string str4 = drQty["SideColor"].ToString();
                decimal num12 = Convert.ToDecimal(drQty["BlackChargeableRate"]);
                decimal num13 = Convert.ToDecimal(drQty["ColorChargeableRate"]);
                decimal num14 = Convert.ToDecimal(drQty["NoOfChargeableSheets"]);
                if (str == "C")
                {
                    num8 = this.PressCostPerClick(Totalpaper, (str3 == "color" ? num13 : num12), num14);
                    if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                    {
                        decimal num15 = this.PressCostPerClick(Totalpaper, (str4.ToLower() == "color" ? num13 : num12), num14);
                        num8 = num8 + num15;
                    }
                    PressJobTimeSide1 = new decimal(0);
                    PressJobTimeSide2 = new decimal(0);
                }
                else if (str == "S")
                {
                    decimal num16 = new decimal(0);
                    num8 = EstimatesBasePage.SpeedWeightLookup_Cost(CompanyID, Totalpaper, num4, num1, num, str3, num2, num3, PressMarkUp, ref num16);
                    PressJobTimeSide1 = num16;
                    PressJobTimeSide2 = new decimal(0);
                    if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                    {
                        decimal num17 = EstimatesBasePage.SpeedWeightLookup_Cost(CompanyID, Totalpaper, num4, num1, num, str4, num2, num3, PressMarkUp, ref num16);
                        PressJobTimeSide2 = num16;
                        num8 = num8 + num17;
                    }
                }
                else if (str == "Z")
                {
                    decimal num18 = new decimal(0);
                    int num19 = Convert.ToInt32(Totalpaper);
                    int num20 = Convert.ToInt32(Totalpaper);
                    decimal num21 = new decimal(0);
                    Zone_Side1_PressMarkupPrice = new decimal(0);
                    decimal num22 = new decimal(0);
                    decimal num23 = new decimal(0);
                    Zone_Side2_PressMarkupPrice = new decimal(0);
                    decimal num24 = new decimal(0);
                    if (!Convert.ToBoolean(drQty["CalculationType"]) && Convert.ToBoolean(drQty["IsDoubleSided"]) && str3 == str4)
                    {
                        num20 = num20 * 2;
                    }
                    if (!Convert.ToBoolean(drQty["CalculationType"]))
                    {
                        foreach (DataRow row in EstimatesBasePage.estimate_click_charge_zone_2nd_calculation(CompanyID, num, num20, str3).Rows)
                        {
                            int num25 = Convert.ToInt32(row["ChargeableSheets"]);
                            decimal num26 = Convert.ToDecimal(row["Cost"]);
                            num9 = Convert.ToDecimal(row["Markup"]);
                            num18 = (num26 / num25) * num19;
                            Zone_Side1_ChargeableRate = num26;
                            num21 = num9;
                            Zone_Side1_CostExMarkup = num18;
                            Zone_Side1_Cost = Convert.ToDecimal(row["ChargeableRate"]);
                        }
                        Zone_Side1_PressMarkupPrice = (num18 * num21) / new decimal(100);
                        num22 = num18 + ((num18 * num21) / new decimal(100));
                        num8 = num22;
                        Zone_Side1_PressMarkupPercentage = num21;
                    }
                    else
                    {
                        num18 = EstimatesBasePage.Click_Charge_Zone_Cost(CompanyID, num, num19, str3, ref num9, false, Convert.ToInt32(drQty["PressID"]), Convert.ToInt32(drQty["EstimateItemID"]), QuantityNumber);
                        Zone_Side1_ChargeableRate = num18;
                        num21 = num9;
                        Zone_Side1_CostExMarkup = num18;
                        num22 = num18 + ((num18 * num21) / new decimal(100));
                        Zone_Side1_PressMarkupPrice = (num18 * num21) / new decimal(100);
                        num8 = num22;
                        Zone_Side1_PressMarkupPercentage = num21;
                    }
                    if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                    {
                        decimal num27 = new decimal(0);
                        if (!Convert.ToBoolean(drQty["CalculationType"]))
                        {
                            foreach (DataRow dataRow in EstimatesBasePage.estimate_click_charge_zone_2nd_calculation(CompanyID, num, num20, str4).Rows)
                            {
                                decimal num28 = Convert.ToDecimal(dataRow["ChargeableSheets"]);
                                decimal num29 = Convert.ToDecimal(dataRow["Cost"]);
                                num9 = Convert.ToDecimal(dataRow["Markup"]);
                                num27 = (num29 / num28) * num19;
                                Zone_Side2_ChargeableRate = num29;
                                num23 = num9;
                                Zone_Side2_CostExMarkup = num27;
                                Zone_Side2_Cost = Convert.ToDecimal(dataRow["ChargeableRate"]);
                            }
                            Zone_Side2_PressMarkupPrice = (num27 * num23) / new decimal(100);
                            num24 = num27 + ((num27 * num23) / new decimal(100));
                            num8 = num22 + num24;
                            Zone_Side2_PressMarkupPercentage = num23;
                        }
                        else
                        {
                            num27 = EstimatesBasePage.Click_Charge_Zone_Cost(CompanyID, num, num19, str4, ref num9, true, Convert.ToInt32(drQty["PressID"]), Convert.ToInt32(drQty["EstimateItemID"]), QuantityNumber);
                            Zone_Side2_ChargeableRate = num27;
                            num23 = num9;
                            Zone_Side2_CostExMarkup = num27;
                            num24 = num27 + ((num27 * num23) / new decimal(100));
                            Zone_Side2_PressMarkupPrice = (num27 * num23) / new decimal(100);
                            num8 = num22 + num24;
                            Zone_Side2_PressMarkupPercentage = num23;
                        }
                    }
                    PressJobTimeSide1 = new decimal(0);
                    PressJobTimeSide2 = new decimal(0);
                }
                else if (str == "L")
                {
                    decimal totalpaper = new decimal(0);
                    if (str1.ToLower() == "low")
                    {
                        totalpaper = Totalpaper / num5;
                    }
                    else if (str1.ToLower() == "medium")
                    {
                        totalpaper = Totalpaper / num6;
                    }
                    else if (str1.ToLower() == "high")
                    {
                        totalpaper = Totalpaper / num7;
                    }
                    num8 = totalpaper * num1;
                    PressJobTimeSide1 = totalpaper;
                    if (Convert.ToBoolean(drQty["IsDoubleSided"]))
                    {
                        num8 = num8 * new decimal(2);
                        PressJobTimeSide1 = totalpaper;
                    }
                    PressJobTimeSide2 = new decimal(0);
                }
                decimal num30 = new decimal(0);
                if (str != "Z")
                {
                    PressCostExMarkup_Actual = num8 + num2;
                    PressMarkupPrice = (num8 * PressMarkUp) / new decimal(100);
                    num8 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num8, PressMarkUp, num3, out num30, out num10, ref num2);
                    PressMarkupPrice = (num30 * num10) / new decimal(100);
                }
                else
                {
                    PressCostExMarkup_Actual = (num8 - (Zone_Side1_PressMarkupPrice + Zone_Side2_PressMarkupPrice)) + num2;
                    EstimatesBasePage.estimate_zone_markup_update(CompanyID, num, num9);
                    num8 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num8, new decimal(0), num3, out num30, out num10, ref num2);
                    if ((((num8 - num2) + (((num8 - num2) * num10) / new decimal(100))) + num2) > num3)
                    {
                        PressMarkupPrice = Zone_Side1_PressMarkupPrice + Zone_Side2_PressMarkupPrice;
                    }
                    else
                    {
                        PressMarkupPrice = new decimal(0);
                    }
                }
                PressCostExMarkup = num8 - PressMarkupPrice;
            }
            else if (str == "S")
            {
                decimal num31 = new decimal(0);
                int num32 = Convert.ToInt32(drQty["PressPasses"]);
                if (Convert.ToBoolean(drQty["WorknTurn"]))
                {
                    num2 = Convert.ToDecimal(drQty["SetupChargeWork_n_Turn"]);
                }
                else if (Convert.ToBoolean(drQty["WorknTumble"]))
                {
                    num2 = Convert.ToDecimal(drQty["SetupChargeWork_n_Tumble"]);
                }
                EstimatesBasePage.PCR_estimates_Update_SetupCharge_Or_MakeReady(num, num2, "PressSetupCharge");
                num8 = EstimatesBasePage.LithoSpeedWeightLookup_Cost(CompanyID, Convert.ToInt32(Totalpaper), num4, num1, num, num2, num3, PressMarkUp, ref num31);
                num31 = num31 * num32;
                PressJobTimeSide1 = num31;
                PressJobTimeSide2 = new decimal(0);
                num8 = num8 * num32;
                PressMarkupPrice = (num8 * PressMarkUp) / new decimal(100);
                PressCostExMarkup_Actual = num8 + num2;
                num8 = this.commclass.Eprint_GetminimumCost_ComparedtoCostwithMarkup(num8, PressMarkUp, num3, out PressCostExMarkup, out num10, ref num2);
               // PressMarkupPrice = (PressCostExMarkup * num10) / new decimal(100);
                PressCostExMarkup = PressCostExMarkup + num2;
            }
            return num8;
        }

        private decimal PressCostPerClick(decimal PrintSheets, decimal ChargeableRate, decimal ChargeableSheets)
        {
            decimal num = new decimal(0);
            if (ChargeableSheets > new decimal(0))
            {
                num = ChargeableRate / Convert.ToDecimal(ChargeableSheets);
            }
            return num * PrintSheets;
        }

        public decimal Return_PressPasses(string NoOfSide, decimal Side1Color, decimal Side2Color, decimal Colorunits, bool ischkdPerfect)
        {
            decimal num = new decimal(0);
            if (!ischkdPerfect)
            {
                num = (!(NoOfSide.ToLower() == "double") || !(Colorunits > new decimal(0)) ? Math.Ceiling(Side1Color / Colorunits) : Math.Ceiling(Side1Color / Colorunits) + Math.Ceiling(Side2Color / Colorunits));
            }
            else if (!(NoOfSide.ToLower() == "double") || !(Colorunits > new decimal(0)))
            {
                num = Math.Ceiling(Side1Color / Colorunits);
            }
            else if (Side1Color > Colorunits && Side2Color > Colorunits)
            {
                if (Side1Color >= Side2Color)
                {
                    num = Math.Ceiling(Side1Color / Colorunits);
                }
                else if (Side2Color >= Side1Color)
                {
                    num = Math.Ceiling(Side2Color / Colorunits);
                }
            }
            else if (Side1Color > Colorunits && Side2Color <= Colorunits)
            {
                num = Math.Ceiling(Side1Color / Colorunits);
            }
            else if (Side1Color <= Colorunits && Side2Color > Colorunits)
            {
                num = Math.Ceiling(Side2Color / Colorunits);
            }
            else if (Side1Color <= Colorunits && Side2Color <= Colorunits)
            {
                num = Math.Ceiling(Side1Color / Colorunits);
            }
            return num;
        }

        public decimal WashupCalculation(int CompanyID, string EstimateType, int Quantity, decimal WashUpMarkup, DataRow drQty, ref decimal WashupCostExMarkup, ref decimal WashupMarkupPrice, int NCRCount)
        {
            decimal num = new decimal(0);
            decimal washupCostExMarkup = new decimal(0);
            if (drQty["WashupChargePerColourCheck"].ToString().ToLower() == "true")
            {
                num = Convert.ToDecimal(drQty["WashupUnitPrice"].ToString());
                decimal num1 = Convert.ToDecimal(drQty["NoofWashup"].ToString());
                WashupCostExMarkup = num1 * num;
                WashupMarkupPrice = (WashupCostExMarkup * WashUpMarkup) / new decimal(100);
                washupCostExMarkup = WashupCostExMarkup + WashupMarkupPrice;
            }
            if (EstimateType == "N" && drQty["NcrImageType"].ToString().ToLower() == "common" && NCRCount != 0)
            {
                WashupCostExMarkup = new decimal(0);
                washupCostExMarkup = new decimal(0);
                WashupMarkupPrice = new decimal(0);
            }
            return washupCostExMarkup;
        }
    }
}