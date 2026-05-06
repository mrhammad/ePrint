using MathFunctions;
using nmsCommon;
using nmsConnectionClass;
using Printcenter.UI.Estimates;
using Printcenter.UI.Jobs;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_costcenter_view : System.Web.UI.UserControl
    {
        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string para = string.Empty;

        public int CompanyID;

        public int UserID;

        public string EstCalType = string.Empty;

        public long EstCalculationID;

        public int PaperID;

        public string EstType = string.Empty;

        public long TypeID;

        public long EstimateItemID;

        public long EstBookletSectionID;

        public DataTable dtQty = new DataTable();

        public commonClass comm = new commonClass();

        public string MarkupIdList = string.Empty;

        public string ItemFrom = string.Empty;

        private string module = "estimate";

        private short QtyNo;

        private string _Type;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }

        public item_costcenter_view()
        {
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
        }

        protected void Generate_Price_Catalogue_Items()
        {
            this.lblCostViewTitle.Text = "Price Catalogue View";
            this.ItemFrom = "C";
            this.para = base.Request.Params["item"].ToString();
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
            DataTable dataTable = new DataTable();
            if (string.Compare(this.module, "estimate", true) == 0)
            {
                dataTable = EstimateBasePage.price_catalogue_select_by_estimateitem_id(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
            {
                foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.QtyNo = Convert.ToInt16(row["QtyNumber"].ToString());
                }
                dataTable = JobBasePage.price_catalogue_select_by_estimateitem_id_qtynumber(this.CompanyID, this.EstimateItemID, this.QtyNo);
            }
            int num = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (num == 0)
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Item Name</span></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow["CatalogueName"].ToString(), "</span></div>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:40%;text-align:center;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;text-align:right;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                }
                decimal num1 = Convert.ToDecimal(dataRow["Price"]);
                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;border:0px solid red'> "));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:35%;text-align:right;border:0px solid red'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Quantity"].ToString()), 0, "", true, false, true), "</span>")));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp;</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                ControlCollection controls = this.plhItemCostView.Controls;
                object[] objArray = new object[] { " <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num1.ToString()), 3, "", false, false, true), "</span><span id='spnPriceExMarkup_", num, "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Price"].ToString()), 3, "", false, false, true), "</span>" };
                controls.Add(new LiteralControl(string.Concat(objArray)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                long num2 = Convert.ToInt64(dataRow["EstPriceCatalogueID"]);
                decimal num3 = Convert.ToDecimal(dataRow["Markup"]);
                string str = string.Concat("onblur=javascript:CatalogueMarkupOnBlur(this,", num, ");");
                object[] objArray1 = new object[] { "<input id='txtMarkUp_", num, "' ", str, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3), 0, "", false, false, true), "' class='textboxnew' style='width:50px;'  maxlength='20' /> " };
                string str1 = string.Concat(objArray1);
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:40%;text-align:center;'> "));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" ", str1)));
                ControlCollection controlCollections = this.plhItemCostView.Controls;
                object[] objArray2 = new object[] { " <span id='spn_id_", num, "' style='display:none;'>", num2, "</span>" };
                controlCollections.Add(new LiteralControl(string.Concat(objArray2)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                decimal num4 = (num3 * num1) / new decimal(100);
                decimal num5 = num1 + num4;
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;text-align:right;width:15%;' > "));
                ControlCollection controls1 = this.plhItemCostView.Controls;
                object[] objArray3 = new object[] { "<span class='normaltext' id='spnSellingInMarkup_", num, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num5.ToString()), 0, "", false, false, true), "</span>" };
                controls1.Add(new LiteralControl(string.Concat(objArray3)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;text-align:right;width:3%;'> "));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                num++;
            }
        }

        private decimal Guillotine_Calculation(decimal TotalSheets, int ThroatValue, int Printlayout, decimal GuillotineSetCharge, decimal GuillotineMinimumCharge, decimal GuillotineMarkUp, decimal CostPerCut, bool IsGutterSelected, int Quantity, ref int TotalNoOfCusts, ref int Bundles)
        {
            if (Printlayout == 0)
            {
                return 0;
            }
            Bundles = 0;
            if (ThroatValue != 0)
            {
                Bundles = Convert.ToInt32(Math.Ceiling(TotalSheets / Convert.ToDecimal(ThroatValue)));
            }
            if (Bundles == 0)
            {
                Bundles = 1;
            }
            TotalNoOfCusts = 0;
            string str = (IsGutterSelected ? "yes" : "no");
            int num = Convert.ToInt32(EstimateBasePage.Estimate_Summary_Guillotine_Standard_Table(this.CompanyID, Printlayout, str));
            TotalNoOfCusts = num * Bundles;
            return CostPerCut * TotalNoOfCusts;
        }

        protected void InkCostGenerate()
        {
            DataTable dataTable;
            dataTable = (this.module != "job" ? EstimateBasePage.Estimate_Quantity_Select_By_ID(this.CompanyID, this.EstType, this.TypeID) : JobBasePage.Job_Quantity_Select_By_ID(this.CompanyID, this.EstType, this.TypeID, this.QtyNo));
            DataTable dataTable1 = EstimateBasePage.Ink_Information_By_LargeItem_ID(this.CompanyID, this.TypeID);
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = "align='center'";
            string str5 = "align='center'";
            if (dataTable.Rows.Count == 1)
            {
                str3 = "20%";
                empty4 = "20%";
                empty1 = "18%";
                empty3 = "18%";
                str2 = "5%";
                str4 = "";
                str5 = "align='right'";
            }
            else if (dataTable.Rows.Count == 2)
            {
                str3 = "10%";
                empty4 = "15%";
                empty1 = "12%";
                str2 = "5%";
                empty3 = "28%";
            }
            else if (dataTable.Rows.Count == 3)
            {
                str3 = "8%";
                empty4 = "10%";
                empty1 = "12%";
                str2 = "6%";
                empty3 = "30%";
            }
            else if (dataTable.Rows.Count == 4)
            {
                str3 = "10%";
                empty4 = "10%";
                empty1 = "10%";
                str2 = "5%";
                empty3 = "30%";
            }
            foreach (DataRow row in dataTable1.Rows)
            {
                this.EstCalculationID = Convert.ToInt64(row["EstCalculationID"]);
                str = row["InkIDList"].ToString();
                empty = row["QtyIDList"].ToString();
                if (num == 0)
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", str3, ";' > ")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'><br />Ink Name</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:5px;'>&nbsp;</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty4, "'> ")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'><br />Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty3, ";' > ")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <table border='0px' width='100%'><tr><td ", str4, "><span class='Headertext'>Sheets</span></td></tr></table>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <table border='0px'><tr>"));
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <td class='Headertext' width='", str2, ";' >")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(dataRow["Quantity"].ToString() ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </td>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("</tr></table>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:5px;'>&nbsp;</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty1, ";'> ")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'><br />Mark Up (%)</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty3, ";' align='right'>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <table border='0px' width='100%'><tr><td ", str5, "><span class='Headertext' >Selling Price</span></td></tr></table>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <table width='100%' border='0px'><tr>"));
                    foreach (DataRow row1 in dataTable.Rows)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <td class='Headertext' width='", str2, "' align='right'>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", row1["Quantity"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </td>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("</tr></table>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only5px'></div>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", str3, ";'> ")));
                string str6 = row["InkName"].ToString();
                int length = str6.Length;
                ControlCollection controls = this.plhItemCostView.Controls;
                string[] strArrays = new string[] { " <span class='normaltext' title='", row["InkName"].ToString(), "'>", str6, "</span>" };
                controls.Add(new LiteralControl(string.Concat(strArrays)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:5px;'>&nbsp;</div>"));
                string[] strArrays1 = row["OneSqCmInkCost"].ToString().Split(new char[] { '±' });
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty4, ";'> ")));
                try
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", strArrays1[num], "</span>")));
                }
                catch
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='normaltext'>0</span>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty3, ";' > ")));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <table border='0px'><tr>"));
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    int num1 = Convert.ToInt32(dataRow1["Quantity"]);
                    string str7 = row["PrintLayout"].ToString();
                    int num2 = Convert.ToInt32(row["PortraitValue"]);
                    int num3 = Convert.ToInt32(row["LandscapeValue"]);
                    int num4 = (str7 == "L" ? num3 : num2);
                    decimal num5 = Convert.ToDecimal(row["RunningSpoilage"]);
                    decimal num6 = Convert.ToDecimal(row["SetupSpoilage"]);
                    int num7 = 0;
                    if (num4 != 0)
                    {
                        num7 = Convert.ToInt32(num1 / num4);
                    }
                    decimal num8 = Convert.ToInt32((num1 * num5) / new decimal(100));
                    decimal num9 = Convert.ToInt32((num7 + num6) + num8);
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <td class='normaltext' width='", str2, ";' >")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" ", num9)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("</tr></table>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:5px;'>&nbsp;</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty1, ";'> ")));
                strArrays = new string[] { "onblur=javascript:InkMarkupOnBlur(this,this.value,\"", str, ",", empty, "\");" };
                string str8 = string.Concat(strArrays);
                strArrays = new string[] { "<input id='txtMarkUp_", row["InkID"].ToString(), "' ", str8, " value='", row["InkMarkup"].ToString(), "' class='textboxnew' style='width:50px;' tabindex='0'  maxlength='8' /> " };
                string str9 = string.Concat(strArrays);
                this.plhItemCostView.Controls.Add(new LiteralControl(str9));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty3, ";' align='right'> ")));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <table width='100%' border='0px'><tr>"));
                foreach (DataRow row2 in dataTable.Rows)
                {
                    int num10 = Convert.ToInt32(row2["Quantity"]);
                    string str10 = row["PrintLayout"].ToString();
                    int num11 = Convert.ToInt32(row["PortraitValue"]);
                    int num12 = Convert.ToInt32(row["LandscapeValue"]);
                    int num13 = (str10 == "L" ? num12 : num11);
                    decimal num14 = Convert.ToDecimal(row["RunningSpoilage"]);
                    decimal num15 = Convert.ToDecimal(row["SetupSpoilage"]);
                    int num16 = 0;
                    if (num13 != 0)
                    {
                        num16 = Convert.ToInt32(num10 / num13);
                    }
                    decimal num17 = (num16 * num14) / new decimal(100);
                    decimal num18 = (num16 + num15) + num17;
                    num18 = Math.Ceiling(num18);
                    decimal num19 = new decimal(0);
                    decimal num20 = Convert.ToInt32(row["JobWidth"]) / 10;
                    decimal num21 = Convert.ToInt32(row["JobHeight"]) / 10;
                    decimal num22 = num20 * num21;
                    decimal num23 = Convert.ToDecimal(row["InkCoverageSide1"]);
                    decimal num24 = Convert.ToDecimal(row["InkCoverageSide2"]);
                    if (num23 != new decimal(0))
                    {
                        decimal num25 = (num22 * num23) / new decimal(100);
                        decimal num26 = new decimal(0);
                        try
                        {
                            num26 = num25 * Convert.ToDecimal(strArrays1[num]);
                        }
                        catch
                        {
                        }
                        num19 = num19 + (num26 * num18);
                        num19 = this.ReturnExact2Decimal(num19);
                    }
                    if (num24 != new decimal(0) && Convert.ToBoolean(row["IsdecimalSided"]))
                    {
                        decimal num27 = (num22 * num24) / new decimal(100);
                        decimal num28 = new decimal(0);
                        try
                        {
                            num28 = num27 * Convert.ToDecimal(strArrays1[num]);
                        }
                        catch
                        {
                        }
                        num19 = num19 + (num28 * num18);
                        num19 = this.ReturnExact2Decimal(num19);
                    }
                    decimal num29 = Convert.ToDecimal(row["InkMarkup"]);
                    decimal num30 = num19 + ((num19 * num29) / new decimal(100));
                    num30 = this.ReturnExact2Decimal(num30);
                    string str11 = string.Concat(row["InkID"].ToString(), "_", row2["QuantityID"].ToString());
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <td class='normaltext' align='right'  width='", str2, "'>")));
                    ControlCollection controlCollections = this.plhItemCostView.Controls;
                    object[] objArray = new object[] { " <span style='display:none;' id='spnSellingExMarkup_", str11, "'>", num19, "</span>" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                    ControlCollection controls1 = this.plhItemCostView.Controls;
                    strArrays = new string[] { " <span class='normaltext' id='spnSellingPrice_", str11, "'>", num30.ToString("C"), "</span>" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("</tr></table>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only5px'></div>"));
                num++;
                this.hdn_Markup.Value = row["InkMarkup"].ToString();
            }
        }

        protected void lnkbtnSaveItemView_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.ItemFrom, "SPL", true) == 0 || string.Compare(this.ItemFrom, "B", true) == 0)
            {
                string[] strArrays = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                long num = Convert.ToInt64(strArrays[1].ToString());
                decimal num1 = Convert.ToDecimal(strArrays[2].ToString());
                string str = strArrays[3].ToString();
                if (string.Compare(str, "paper", true) == 0)
                {
                    EstimateBasePage.estimates_estcalculation_update(this.CompanyID, num, num1, str);
                }
                else if (string.Compare(str, "press", true) == 0)
                {
                    EstimateBasePage.estimates_estcalculation_update(this.CompanyID, num, num1, str);
                }
                else if (string.Compare(str, "guillotine", true) == 0)
                {
                    EstimateBasePage.estimates_estcalculation_update(this.CompanyID, num, num1, str);
                }
                else if (string.Compare(str, "ink", true) == 0)
                {
                    EstimateBasePage.estimates_estcalculation_update(this.CompanyID, num, num1, str);
                }
            }
            else if (string.Compare(this.ItemFrom, "IW", true) == 0)
            {
                string[] strArrays1 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    if (strArrays1[i] != "")
                    {
                        string[] strArrays2 = strArrays1[i].Split(new char[] { '±' });
                        long num2 = (long)0;
                        decimal num3 = new decimal(0);
                        for (int j = 0; j < (int)strArrays2.Length; j++)
                        {
                            string[] strArrays3 = strArrays2[j].Split(new char[] { '«' });
                            if (strArrays3[0] == "EstItemWarehouseID")
                            {
                                num2 = Convert.ToInt64(strArrays3[1]);
                            }
                            else if (strArrays3[0] == "MarkUp")
                            {
                                num3 = Convert.ToDecimal(strArrays3[1]);
                                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num2, num3, "IW", new decimal(0));
                            }
                        }
                    }
                }
            }
            else if (string.Compare(this.ItemFrom, "IU", true) == 0)
            {
                string[] strArrays4 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int k = 0; k < (int)strArrays4.Length; k++)
                {
                    if (strArrays4[k] != "")
                    {
                        string[] strArrays5 = strArrays4[k].Split(new char[] { '±' });
                        long num4 = (long)0;
                        decimal num5 = new decimal(0);
                        for (int l = 0; l < (int)strArrays5.Length; l++)
                        {
                            string[] strArrays6 = strArrays5[l].Split(new char[] { '«' });
                            if (strArrays6[0] == "EstOtherCostID")
                            {
                                num4 = Convert.ToInt64(strArrays6[1]);
                            }
                            else if (strArrays6[0] == "MarkUp")
                            {
                                num5 = Convert.ToDecimal(strArrays6[1]);
                                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num4, num5, "IU", new decimal(0));
                            }
                        }
                    }
                }
            }
            else if (string.Compare(this.ItemFrom, "IO", true) == 0)
            {
                string[] strArrays7 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int m = 0; m < (int)strArrays7.Length; m++)
                {
                    if (strArrays7[m] != "")
                    {
                        string[] strArrays8 = strArrays7[m].Split(new char[] { '±' });
                        long num6 = (long)0;
                        decimal num7 = new decimal(0);
                        decimal num8 = new decimal(0);
                        for (int n = 0; n < (int)strArrays8.Length; n++)
                        {
                            string[] strArrays9 = strArrays8[n].Split(new char[] { '«' });
                            if (strArrays9[0] == "EstItemOutworkSupplierID")
                            {
                                num6 = Convert.ToInt64(strArrays9[1]);
                            }
                            else if (strArrays9[0] == "MarkUp")
                            {
                                num7 = Convert.ToDecimal(strArrays9[1]);
                            }
                            else if (strArrays9[0] == "TotalPrice")
                            {
                                num8 = Convert.ToDecimal(strArrays9[1]);
                                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num6, num7, "IO", num8);
                            }
                        }
                    }
                }
            }
            else if (string.Compare(this.ItemFrom, "W", true) == 0)
            {
                string[] strArrays10 = this.hdn_SaveItemViewMarkup.Value.ToString().Split(new char[] { '»' });
                decimal num9 = Convert.ToDecimal(strArrays10[0]);
                long num10 = Convert.ToInt64(strArrays10[1]);
                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num10, num9, "W", new decimal(0));
            }
            else if (string.Compare(this.ItemFrom, "U", true) == 0)
            {
                string[] strArrays11 = this.hdn_SaveItemViewMarkup.Value.ToString().Split(new char[] { '»' });
                decimal num11 = Convert.ToDecimal(strArrays11[0]);
                long num12 = Convert.ToInt64(strArrays11[1]);
                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num12, num11, "U", new decimal(0));
            }
            else if (string.Compare(this.ItemFrom, "C", true) == 0)
            {
                string[] strArrays12 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int o = 0; o < (int)strArrays12.Length; o++)
                {
                    long num13 = (long)0;
                    decimal num14 = new decimal(0);
                    if (strArrays12[o] != "")
                    {
                        string[] strArrays13 = strArrays12[o].Split(new char[] { '±' });
                        for (int p = 0; p < (int)strArrays13.Length; p++)
                        {
                            string[] strArrays14 = strArrays13[p].Split(new char[] { '«' });
                            if (strArrays14[0] == "EstPriceCatalogueID")
                            {
                                num13 = Convert.ToInt64(strArrays14[1]);
                            }
                            else if (strArrays14[0] == "MarkUp")
                            {
                                num14 = Convert.ToDecimal(strArrays14[1]);
                                EstimateBasePage.price_catalogue_markup_update(this.CompanyID, num13, num14);
                            }
                        }
                    }
                }
            }
            this.plhItemCostView.Controls.Clear();
            this.pnlCallAfterUpdate.Visible = true;
        }

        protected void OtherCostSubItem()
        {
            char[] chrArray;
            object[] currencyinRequiredFormate;
            string[] str;
            this.para = base.Request.Params["item"].ToString();
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
            this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
            this.EstType = base.Request.Params["EstType"].ToString();
            long num = Convert.ToInt64(base.Request.Params["EstOtherCostID"]);
            DataTable dataTable = new DataTable();
            if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
            {
                foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.QtyNo = Convert.ToInt16(row["QtyNumber"].ToString());
                }
                dataTable = EstimateBasePage.item_othercost_by_qty_id_new_qtynumber(this.CompanyID, this.EstType, this.TypeID, num, this.QtyNo);
            }
            else
            {
                dataTable = EstimateBasePage.OtherCost_SubItem_Select_By_EstOtherCostID(this.CompanyID, this.EstType, this.TypeID, num);
            }
            int num1 = 1;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            int num4 = 0;
            string empty = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            ArrayList arrayLists2 = new ArrayList();
            DataTable dataTable1 = EstimateBasePage.Estimate_Information_By_ID(this.CompanyID, this.EstType, this.TypeID);
            if (this.EstType != "B")
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    num2 = Convert.ToDecimal(dataRow["SetupSpoilage"]);
                    num3 = Convert.ToDecimal(dataRow["RunningSpoilage"]);
                    num4 = Convert.ToInt32(dataRow["PrintlayoutValue"]);
                }
            }
            else
            {
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    num2 = Convert.ToDecimal(row1["SetupSpoilage"]);
                    num3 = Convert.ToDecimal(row1["RunningSpoilage"]);
                    empty = row1["NoOfSignatures"].ToString();
                    arrayLists.Add(row1["SetupSpoilage"].ToString());
                    arrayLists1.Add(row1["RunningSpoilage"].ToString());
                    arrayLists2.Add(row1["NoOfSignatures"].ToString());
                }
            }
            int num5 = 0;
            foreach (DataRow dataRow1 in dataTable.Rows)
            {
                int num6 = Convert.ToInt32(dataRow1["Quantity"]);
                string str1 = dataRow1["CalculationName"].ToString();
                string str2 = dataRow1["CalculationType"].ToString();
                string str3 = dataRow1["VariableDDLType"].ToString();
                string str4 = dataRow1["VariableHrsQty"].ToString();
                string str5 = dataRow1["MakeReadyTime"].ToString();
                Convert.ToDecimal(dataRow1["Cost"]);
                Convert.ToDecimal(dataRow1["Markup"]);
                Convert.ToDecimal(dataRow1["MinimumCost"]);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                int num9 = Convert.ToInt32(dataRow1["SetupTime"]);
                decimal num10 = Convert.ToDecimal(dataRow1["HourlyRate"]);
                decimal num11 = Convert.ToDecimal(dataRow1["UnitRate"]);
                decimal num12 = Convert.ToDecimal(dataRow1["HoursOrQty"]);
                decimal num13 = Convert.ToDecimal(dataRow1["Markup"]);
                decimal num14 = Convert.ToDecimal(dataRow1["MinimumCost"]);
                decimal num15 = Convert.ToDecimal(dataRow1["HourlyRunSpeed"]);
                decimal num16 = Convert.ToDecimal(dataRow1["Passes"]);
                decimal num17 = (num9 * num10) / new decimal(60);
                num17 = this.ReturnExact2Decimal(num17);
                num7 = Convert.ToDecimal(dataRow1["Cost"]);
                num7 = this.ReturnExact2Decimal(num7);
                if (num14 > num7)
                {
                    num7 = num14;
                    num7 = this.ReturnExact2Decimal(num7);
                }
                decimal num18 = (num7 * num13) / new decimal(100);
                num18 = this.ReturnExact2Decimal(num18);
                num8 = num7 + num18;
                num8 = this.ReturnExact2Decimal(num8);
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                if (this.EstType != "B")
                {
                    num20 = (num4 != 0 ? num6 / num4 : 0);
                }
                else if (!string.IsNullOrEmpty(empty))
                {
                    num20 = num6 * Convert.ToInt32(empty);
                }
                num19 = Math.Ceiling(num20);
                decimal num21 = new decimal(0);
                decimal num22 = new decimal(0);
                decimal num23 = new decimal(0);
                decimal num24 = new decimal(0);
                if (str3 == "1")
                {
                    num19 = Math.Ceiling(num20);
                    num24 = num19;
                }
                else if (str3 == "2")
                {
                    num21 = (num19 * num3) / new decimal(100);
                    if (this.EstType != "B")
                    {
                        decimal num25 = new decimal(0);
                        num19 = EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num6, num4, num2, num3, out num25);
                    }
                    else
                    {
                        num19 = (num19 + num2) + num21;
                    }
                    num19 = Math.Ceiling(num19);
                    num24 = num19;
                }
                else if (str3 == "3")
                {
                    num24 = num6;
                }
                else if (str3 == "4")
                {
                    num23 = Math.Ceiling((num6 * num3) / new decimal(100));
                    num22 = (num6 + num23) + num2;
                    num24 = Math.Ceiling(num22);
                }
                if (num1 == 1)
                {
                    stringBuilder.Append("<div align='left' style='border:1px solid silver;width:64%;padding:5px;border-style:dashed;'>");
                    if (string.Compare(str2, "f", true) != 0)
                    {
                        stringBuilder.Append("<span><u><b>Work Instruction:</b></u></span>");
                        stringBuilder.Append("<div class='only5px'></div>");
                    }
                    if (string.Compare(str1, "v", true) == 0)
                    {
                        stringBuilder.Append(string.Concat("<div> Print Layout Value: ", num4, "</div>    "));
                    }
                    if (string.Compare(str2, "f", true) != 0)
                    {
                        stringBuilder.Append(string.Concat("<div> Make Ready Time: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str5), 0, "", false, false, true), " min</div>    "));
                    }
                    if (num15 > new decimal(0) && string.Compare(str2, "t", true) == 0)
                    {
                        stringBuilder.Append(string.Concat("<div> Hourly Run Speed: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num15), 0, "", false, false, true), "</div>    "));
                        stringBuilder.Append(string.Concat("<div> Passes: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num16), 0, "", false, false, true), "</div>    "));
                    }
                    stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                    stringBuilder.Append("<div><span><u><b>Calculation:</b></u></span></div>    ");
                    stringBuilder.Append("<div class='only5px'></div>");
                    if (string.Compare(str2, "t", true) == 0)
                    {
                        if (str3 == "1")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (exl. Spoilage) / Hourly Run Speed)  x Hourly Rate + Make Ready Cost + Mark up</div>");
                        }
                        else if (str3 == "2")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (inc. Spoilage) / Hourly Run Speed)  x Hourly Rate + Make Ready Cost + Mark up</div>");
                        }
                        else if (str3 == "3")
                        {
                            stringBuilder.Append("<div> (Finished Item Qty (exl. Spoilage) / Hourly Run Speed) x Hourly Rate + Make Ready Cost + Mark up</div>");
                        }
                        else if (str3 != "4")
                        {
                            stringBuilder.Append("<div>(Hours x Hourly Rate) + Make Ready Cost + Mark up</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div> (Finished Item Qty (inc. Spoilage) / Hourly Run Speed)  x Hourly Rate + Make Ready Cost + Mark up</div>");
                        }
                    }
                    else if (string.Compare(str2, "q", true) != 0)
                    {
                        if (string.Compare(str2, "f", true) == 0 || string.Compare(str2, "m", true) == 0)
                        {
                            string str6 = dataRow1["FormulaTag"].ToString();
                            chrArray = new char[] { '\u00B6' };
                            string[] strArrays = str6.Split(chrArray);
                            string str7 = string.Concat(strArrays[1], " + Markup ");
                            stringBuilder.Append(string.Concat("<div align='left'> ", str7, " </div>"));
                            stringBuilder.Append("<div class='only10px'></div>");
                        }
                    }
                    else if (str3 == "1")
                    {
                        stringBuilder.Append("<div>(Print Sheet Qty (exl. Spoilage) x Unit Rate)  + Make Ready Cost + Mark up</div>");
                    }
                    else if (str3 == "2")
                    {
                        stringBuilder.Append("<div>(Print Sheet Qty (inc. Spoilage) x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    else if (str3 == "3")
                    {
                        stringBuilder.Append("<div>(Finished Item Qty (exl. Spoilage) x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    else if (str3 != "4")
                    {
                        stringBuilder.Append("<div>(Quantity x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    else
                    {
                        stringBuilder.Append("<div>(Finished Item Qty (inc. Spoilage) x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                    stringBuilder.Append("<div><span><u><b>Actuals:</b></u></span></div>");
                    stringBuilder.Append("<div class='only5px'></div>");
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Other Cost Name</span></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow1["OtherCostName"].ToString(), "</span></div>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div style='width:890px;'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' style='border:0px solid red'>"));
                    if (string.Compare(str2, "t", true) != 0)
                    {
                        if (string.Compare(str2, "q", true) == 0)
                        {
                            if (string.Compare(str1, "f", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Unit Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (string.Compare(str1, "v", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Print Sheets </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Unit Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                    }
                    else if (string.Compare(str1, "f", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hours </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(dataRow1["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (string.Compare(str1, "v", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Print Sheets </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hours </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(dataRow1["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:115px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Minimum Cost (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:150px;' nowrap='nowrap'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity 1 Selling Price</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                    if (string.Compare(str2, "t", true) != 0)
                    {
                        if (string.Compare(str2, "q", true) == 0)
                        {
                            if (string.Compare(str1, "f", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num12, "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", str5, "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), dataRow1["UnitRate"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), dataRow1["HourlyRate"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (string.Compare(str1, "v", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num6, "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", Convert.ToDecimal(str4), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", str5, "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), dataRow1["UnitRate"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), dataRow1["HourlyRate"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                    }
                    else if (string.Compare(str1, "f", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num12, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", str5, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), dataRow1["HourlyRate"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(dataRow1["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num15, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (string.Compare(str1, "v", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num6, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num24, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num12, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", str5, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        ControlCollection controls = this.plhItemCostView.Controls;
                        currencyinRequiredFormate = new object[] { "<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), num10, "</span>" };
                        controls.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(dataRow1["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num15, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:115px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num14.ToString("C"), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.hidItemList.Value = string.Concat(this.hidItemList.Value, dataRow1["EstOtherCostID"].ToString(), "±");
                    string str8 = string.Concat("onblur=javascript:ItemMarkupOnBlur(this.value,", dataRow1["EstOtherCostID"].ToString(), ");");
                    str = new string[] { "<input id='txtMarkUp_", dataRow1["EstOtherCostID"].ToString(), "' ", str8, "  value='", this.ReplaceDollorComma(num13), "' class='textboxnew' style='width:50px;'   maxlength='8' /> " };
                    string str9 = string.Concat(str);
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(str9 ?? ""));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;1idth:100px;'> "));
                    ControlCollection controlCollections = this.plhItemCostView.Controls;
                    currencyinRequiredFormate = new object[] { " <span  id='spnPriceExMarkup_", dataRow1["EstOtherCostID"].ToString(), "' style='display:none;'>", num7, "</span>" };
                    controlCollections.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    ControlCollection controls1 = this.plhItemCostView.Controls;
                    str = new string[] { " <span class='normaltext' id='spnSellingPrice_", dataRow1["EstOtherCostID"].ToString(), "'>", num8.ToString("C"), "</span>" };
                    controls1.Add(new LiteralControl(string.Concat(str)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    num1++;
                }
                stringBuilder.Append(string.Concat("<div><b>Quantity:</b> ", num6, "</div>"));
                if (string.Compare(str2, "t", true) != 0)
                {
                    if (string.Compare(str2, "q", true) == 0)
                    {
                        if (str3 == "1")
                        {
                            stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (exl. Spoilage): ", Convert.ToDecimal(str4), "</div>    "));
                        }
                        else if (str3 == "2")
                        {
                            stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (inc. Spoilage): ", Convert.ToDecimal(str4), "</div>    "));
                        }
                        else if (str3 == "3")
                        {
                            stringBuilder.Append(string.Concat("<div> Finished Item Qty (exl. Spoilage): ", Convert.ToDecimal(str4), "</div>    "));
                        }
                        else if (str3 == "4")
                        {
                            stringBuilder.Append(string.Concat("<div> Finished Item Qty (inc. Spoilage): ", Convert.ToDecimal(str4), "</div>    "));
                        }
                    }
                }
                else if (str3 == "1")
                {
                    stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (exl. Spoilage): ", num24, "</div>    "));
                }
                else if (str3 == "2")
                {
                    stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (inc. Spoilage): ", num24, "</div>    "));
                }
                else if (str3 == "3")
                {
                    stringBuilder.Append(string.Concat("<div> Finished Item Qty (exl. Spoilage): ", num24, "</div>    "));
                }
                else if (str3 == "4")
                {
                    stringBuilder.Append(string.Concat("<div> Finished Item Qty (inc. Spoilage): ", num24, "</div>    "));
                }
                if (string.Compare(str2, "t", true) == 0)
                {
                    currencyinRequiredFormate = new object[] { "<div>(", str4, " x ", num10, ") + ", num17, " + ", num18, " = ", this.comm.GetCurrencyinRequiredFormate("", true), num8.ToString("0.00"), "</div>    " };
                    stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                }
                else if (string.Compare(str2, "q", true) == 0)
                {
                    currencyinRequiredFormate = new object[] { "<div>(", Convert.ToDecimal(str4), " x ", num11, ") + ", num17, " + ", num18, "= ", this.comm.GetCurrencyinRequiredFormate("", true), num8.ToString("0.00"), "</div>    " };
                    stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                }
                else if (string.Compare(str2, "f", true) == 0 || string.Compare(str2, "m", true) == 0)
                {
                    string empty1 = string.Empty;
                    string str10 = dataRow1["FormulaWithActualValue"].ToString();
                    chrArray = new char[] { '±' };
                    string str11 = str10.Split(chrArray)[num5].ToString();
                    try
                    {
                        decimal num26 = (new MathParser()).Calculate(str11);
                        num26 = Convert.ToDecimal(num26.ToString());
                        empty1 = num26.ToString();
                        decimal num27 = this.ReturnExact2Decimal(Convert.ToDecimal(empty1)) + num18;
                        str11 = string.Concat(str11, " + ", num18.ToString());
                        str = new string[] { "<div align='left'> ", str11, " = ", num27.ToString("C"), " </div>" };
                        stringBuilder.Append(string.Concat(str));
                    }
                    catch
                    {
                        stringBuilder.Append(string.Concat("<div align='left'> ", str11, " </div>"));
                    }
                    stringBuilder.Append("<div class='only10px'></div>");
                }
                stringBuilder.Append("<div class='only10px'></div>");
                num5++;
            }
            stringBuilder.Append("</div>");
            stringBuilder.Append("<div class='only10px'></div>    ");
            this.plhItemCostView.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] markupIdList;
            string[] str;
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["module"] != null)
            {
                this.module = base.Request.Params["module"].ToString();
            }
            if (base.Request.Params["From"] != null)
            {
                if (string.Compare(base.Request.Params["From"].ToString(), "SPL", true) == 0)
                {
                    this.ItemFrom = "SPL";
                    if (base.Request.Params["EstimateItemID"] != null && base.Request.Params["TypeID"] != null && base.Request.Params["EstType"] != null && base.Request.Params["item"] != null)
                    {
                        this.para = base.Request.Params["item"].ToString();
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                        this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                        this.EstType = base.Request.Params["EstType"].ToString();
                        if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
                        {
                            foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                            {
                                this.QtyNo = Convert.ToInt16(row["QtyNumber"].ToString());
                            }
                        }
                        if (string.Compare(this.para, "ink", true) != 0)
                        {
                            this.SPLCostGenerate();
                        }
                        else
                        {
                            this.InkCostGenerate();
                        }
                    }
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "B", true) == 0)
                {
                    this.ItemFrom = "B";
                    if (base.Request.Params["EstType"] != null && base.Request.Params["item"] != null)
                    {
                        this.EstBookletSectionID = Convert.ToInt64(base.Request.Params["EstBookletSectionID"]);
                        this.para = base.Request.Params["item"].ToString();
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                        if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
                        {
                            foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                            {
                                this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                            }
                            this.dtQty = JobBasePage.Job_Summary_Item_Cost_View_Qtys_And_Cal_Book(this.CompanyID, this.EstBookletSectionID, "quantity", this.QtyNo);
                        }
                        else
                        {
                            this.dtQty = EstimateBasePage.Estimate_Summary_Item_Cost_View_Qtys_And_Cal_Book(this.CompanyID, this.EstBookletSectionID, "quantity");
                        }
                        DataTable dataTable = EstimateBasePage.Estimate_Summary_Item_Cost_View_Qtys_And_Cal_Book(this.CompanyID, this.EstBookletSectionID, "calculation");
                        int num = 0;
                        foreach (DataRow row1 in this.dtQty.Rows)
                        {
                            int num1 = Convert.ToInt32(row1["Quantity"]);
                            long num2 = Convert.ToInt64(row1["EstBookletQty"]);
                            if (!string.IsNullOrEmpty(this.MarkupIdList))
                            {
                                markupIdList = new object[] { this.MarkupIdList, "±", this.EstimateItemID, "_", num2 };
                                this.MarkupIdList = string.Concat(markupIdList);
                            }
                            else
                            {
                                this.MarkupIdList = string.Concat(this.EstimateItemID, "_", num2);
                            }
                            foreach (DataRow dataRow1 in dataTable.Rows)
                            {
                                this.EstCalculationID = Convert.ToInt64(dataRow1["EstCalculationID"]);
                                decimal num3 = Convert.ToDecimal(dataRow1["SetUpSpoilage"]);
                                decimal num4 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                                int num5 = Convert.ToInt32(dataRow1["NoOfSignatures"]);
                                string str1 = (dataRow1["NoOfSignatures"].ToString() == "" ? "0" : dataRow1["NoOfSignatures"].ToString());
                                decimal num6 = num1 * Convert.ToInt32(str1);
                                decimal num7 = (num6 * num4) / new decimal(100);
                                Convert.ToInt32(num6);
                                decimal num8 = new decimal(0);
                                int num9 = Convert.ToInt32(EstimateBasePage.Booklet_Print_Sheet_Calculation(num1, Convert.ToInt32(str1), num3, num4, out num8));
                                string str2 = "";
                                str2 = (string.Compare(dataRow1["BookletFormat"].ToString(), "Portrait", true) != 0 ? "L" : "P");
                                decimal num10 = Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                                decimal num11 = Convert.ToDecimal(dataRow1["PaperMarkup"]);
                                decimal num12 = Convert.ToDecimal(dataRow1["PaperWeight"]);
                                decimal num13 = num9 * num10;
                                num13 = this.ReturnExact2Decimal(num13);
                                decimal num14 = (num13 * num11) / new decimal(100);
                                num14 = this.ReturnExact2Decimal(num14);
                                num13 = num14 + num13;
                                num13 = this.ReturnExact2Decimal(num13);
                                string str3 = dataRow1["Press"].ToString();
                                string str4 = dataRow1["Colour"].ToString();
                                string str5 = dataRow1["SideColor"].ToString();
                                dataRow1["PaperName"].ToString();
                                if (string.Compare(this.para, "paper", true) == 0)
                                {
                                    this.lblCostViewTitle.Text = "Paper Cost View";
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    if (num == 0)
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Paper Name</span></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow1["PaperName"].ToString(), "</span></div>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        if (Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Paper Supplied</span></div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='box'><span class='Headertext'>Yes</span></div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        }
                                        else if (Convert.ToBoolean(dataRow1["IsPricePerPack"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Price for Whole Pack</span></div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='box'><span class='Headertext'>Yes</span></div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        }
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                        if (!Convert.ToBoolean(dataRow1["IsPricePerPack"]) && !Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        }
                                        else if (Convert.ToBoolean(dataRow1["IsPricePerPack"]) && !Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Packed In</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Pack Price</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        }
                                        else if (Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        }
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Selling Price </span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        num++;
                                    }
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    decimal num15 = num13 - num14;
                                    num15 = this.ReturnExact2Decimal(num15);
                                    decimal num16 = Convert.ToDecimal(dataRow1["PackedIn"]);
                                    decimal num17 = Convert.ToDecimal(dataRow1["PackedPrice"]);
                                    decimal num18 = Math.Ceiling(num9 / num16);
                                    if (Convert.ToBoolean(dataRow1["IsPricePerPack"]))
                                    {
                                        decimal num19 = num18 * num17;
                                        num19 = this.ReturnExact2Decimal(num19);
                                        num14 = (num19 * num11) / new decimal(100);
                                        num14 = this.ReturnExact2Decimal(num14);
                                        num15 = num19;
                                        num13 = num19 + num14;
                                        num13 = this.ReturnExact2Decimal(num13);
                                    }
                                    if (Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                    {
                                        num14 = new decimal(0);
                                        num15 = new decimal(0);
                                        num13 = new decimal(0);
                                    }
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    if (!Convert.ToBoolean(dataRow1["IsPricePerPack"]) && !Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num1, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num9, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    }
                                    else if (Convert.ToBoolean(dataRow1["IsPricePerPack"]) && !Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num1, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num9, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num16, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num17.ToString("C"), "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    }
                                    else if (Convert.ToBoolean(dataRow1["IsPaperSupplied"]))
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num1, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num9, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    }
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num10.ToString("C"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                    string str6 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                                    markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num2, "' ", str6, " value='", this.ReplaceDollorComma(num11), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                                    string str7 = string.Concat(markupIdList);
                                    this.plhItemCostView.Controls.Add(new LiteralControl(str7));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                    ControlCollection controls = this.plhItemCostView.Controls;
                                    markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num15, "</span>" };
                                    controls.Add(new LiteralControl(string.Concat(markupIdList)));
                                    ControlCollection controlCollections = this.plhItemCostView.Controls;
                                    markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num13.ToString("C"), "</span>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(markupIdList)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='onlyEmpty'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:right;padding-right:200px'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span id='spn_error' class='spanerrorMsg' style='width:125px;display:none;'>Please Enter Markup</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.hdn_Markup.Value = num11.ToString();
                                }
                                else if (string.Compare(this.para, "press", true) == 0)
                                {
                                    this.lblCostViewTitle.Text = "Press Cost View";
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    decimal num20 = Convert.ToDecimal(dataRow1["BlackChargeableRate"]);
                                    decimal num21 = Convert.ToDecimal(dataRow1["ColorChargeableRate"]);
                                    int num22 = Convert.ToInt32(dataRow1["NoOfChargeableSheets"]);
                                    decimal num23 = Convert.ToDecimal(dataRow1["PressMarkUp"]);
                                    decimal num24 = Convert.ToDecimal(dataRow1["PressSetupCharge"]);
                                    decimal num25 = Convert.ToDecimal(dataRow1["PressMinimumRunningCharge"]);
                                    decimal num26 = Convert.ToDecimal(dataRow1["HourlyCharge"]);
                                    long num27 = Convert.ToInt64(dataRow1["SpeedWeightTableID"]);
                                    string str8 = (str3 == "L" ? dataRow1["PrintQuality"].ToString() : string.Empty);
                                    int num28 = Convert.ToInt32(dataRow1["PrintPerHourLow"]);
                                    int num29 = Convert.ToInt32(dataRow1["PrintPerHourMedium"]);
                                    int num30 = Convert.ToInt32(dataRow1["PrintPerHourHigh"]);
                                    decimal num31 = new decimal(0);
                                    decimal num32 = new decimal(0);
                                    if (num == 0)
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Press Name&nbsp;</span></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow1["PressName"].ToString(), "</span></div>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span  class='normaltext' >Minimum Charge</span></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", num25.ToString("C"), "</span></div>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        if (Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span  class='normaltext' >decimal Sided</span></div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='box'><span class='Headertext'>Yes</span></div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        }
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                        if (string.Compare(str3, "C", true) == 0)
                                        {
                                            if (!Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                            {
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Rate</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Sheets</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            }
                                            else
                                            {
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Rate (Side 1)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Rate (Side 2)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Sheets</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price </span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            }
                                        }
                                        else if (string.Compare(str3, "Z", true) == 0)
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:22%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Click Charge Cost</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        }
                                        if (string.Compare(str3, "S", true) == 0)
                                        {
                                            if (!Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                            {
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Job Time(min)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Hourly Rate</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            }
                                            else
                                            {
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Job Time(min) Side 1</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Job Time(min) Side 2</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Hourly Rate</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            }
                                        }
                                        if (string.Compare(str3, "L", true) == 0)
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Hourly Charge</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>No. Of Hours</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        }
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        num++;
                                    }
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    decimal num33 = new decimal(0);
                                    decimal num34 = new decimal(0);
                                    decimal num35 = new decimal(0);
                                    decimal num36 = new decimal(0);
                                    decimal num37 = new decimal(0);
                                    if (string.Compare(str3, "C", true) == 0)
                                    {
                                        num33 = (str4 == "color" ? num21 : num20);
                                        num31 = this.PressCostPerClick(num9, num33, num22);
                                        num31 = this.ReturnExact2Decimal(num31);
                                        if (Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            num34 = (str5 == "color" ? num21 : num20);
                                            decimal num38 = this.PressCostPerClick(num9, num34, num22);
                                            num31 = num31 + this.ReturnExact2Decimal(num38);
                                            num31 = this.ReturnExact2Decimal(num31);
                                        }
                                    }
                                    else if (str3 == "S")
                                    {
                                        num31 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num9, num12, num26, num27, str4, num24, num25, num23, ref num35);
                                        if (Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            decimal num39 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num9, num12, num26, num27, str5, num24, num25, num23, ref num36);
                                            num31 = num31 + num39;
                                            num31 = this.ReturnExact2Decimal(num31);
                                        }
                                    }
                                    else if (str3 == "Z")
                                    {
                                        decimal num40 = new decimal(0);
                                        int num41 = Convert.ToInt32(num9);
                                        if (!Convert.ToBoolean(dataRow1["CalculationType"]))
                                        {
                                            DataTable dataTable1 = EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, this.EstCalculationID, num41, str4);
                                            foreach (DataRow row2 in dataTable1.Rows)
                                            {
                                                int num42 = Convert.ToInt32(row2["ChargeableSheets"]);
                                                num37 = Convert.ToDecimal(row2["Cost"]);
                                                num40 = (num37 / num42) * num41;
                                            }
                                        }
                                        else
                                        {
                                            num40 = EstimateBasePage.Click_Charge_Zone_Cost(this.CompanyID, this.EstCalculationID, num41, str4);
                                        }
                                        num31 = num40;
                                        num31 = this.ReturnExact2Decimal(num31);
                                        if (Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            decimal num43 = new decimal(0);
                                            if (!Convert.ToBoolean(dataRow1["CalculationType"]))
                                            {
                                                DataTable dataTable2 = EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, this.EstCalculationID, num41, str5);
                                                foreach (DataRow dataRow2 in dataTable2.Rows)
                                                {
                                                    int num44 = Convert.ToInt32(dataRow2["ChargeableSheets"]);
                                                    num37 = Convert.ToDecimal(dataRow2["Cost"]);
                                                    num43 = (num37 / num44) * num41;
                                                }
                                            }
                                            else
                                            {
                                                num43 = EstimateBasePage.Click_Charge_Zone_Cost(this.CompanyID, this.EstCalculationID, num41, str5);
                                            }
                                            num43 = this.ReturnExact2Decimal(num43);
                                            num31 = num31 + num43;
                                            num31 = this.ReturnExact2Decimal(num31);
                                        }
                                    }
                                    else if (str3 == "L")
                                    {
                                        decimal num45 = new decimal(0);
                                        if (string.Compare(str8, "low", true) == 0)
                                        {
                                            num45 = num9 / num28;
                                        }
                                        else if (string.Compare(str8, "medium", true) == 0)
                                        {
                                            num45 = num9 / num29;
                                        }
                                        else if (string.Compare(str8, "high", true) == 0)
                                        {
                                            num45 = num9 / num30;
                                        }
                                        num31 = num45 * num26;
                                        num31 = this.ReturnExact2Decimal(num31);
                                        if (Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            num31 = num31 * new decimal(2);
                                        }
                                    }
                                    num31 = num31 + num24;
                                    num31 = this.ReturnExact2Decimal(num31);
                                    if (num25 > num31)
                                    {
                                        num31 = num25;
                                        num31 = this.ReturnExact2Decimal(num31);
                                    }
                                    num32 = (num31 * num23) / new decimal(100);
                                    num32 = this.ReturnExact2Decimal(num32);
                                    num31 = num31 + num32;
                                    num31 = this.ReturnExact2Decimal(num31);
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    decimal num46 = num31 - num32;
                                    num46 = this.ReturnExact2Decimal(num46);
                                    string str9 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                                    markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num2, "' ", str9, " value='", this.ReplaceDollorComma(num23), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                                    string str10 = string.Concat(markupIdList);
                                    if (string.Compare(str3, "C", true) == 0)
                                    {
                                        if (!Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num1, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num9, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num33.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num22, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num24.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(str10));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                            ControlCollection controls1 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num46, "</span>" };
                                            controls1.Add(new LiteralControl(string.Concat(markupIdList)));
                                            ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num31.ToString("C"), "</span>" };
                                            controlCollections1.Add(new LiteralControl(string.Concat(markupIdList)));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        }
                                        else
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:8%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num1, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:8%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num9, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num33.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num34.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num22, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num24.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(str10));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                            ControlCollection controls2 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num46, "</span>" };
                                            controls2.Add(new LiteralControl(string.Concat(markupIdList)));
                                            ControlCollection controlCollections2 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num31.ToString("C"), "</span>" };
                                            controlCollections2.Add(new LiteralControl(string.Concat(markupIdList)));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        }
                                    }
                                    if (string.Compare(str3, "Z", true) == 0)
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num1, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num9, "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:22%;'> "));
                                        if (!Convert.ToBoolean(dataRow1["CalculationType"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num37.ToString("C"), "</span>")));
                                        }
                                        else
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='normaltext'>Click Chargeable Rate</span>"));
                                        }
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num24.ToString("C"), "</span>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:15%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(str10));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                        ControlCollection controls3 = this.plhItemCostView.Controls;
                                        markupIdList = new object[] { "  <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num46, "</span>" };
                                        controls3.Add(new LiteralControl(string.Concat(markupIdList)));
                                        ControlCollection controlCollections3 = this.plhItemCostView.Controls;
                                        markupIdList = new object[] { "  <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num31.ToString("C"), "</span>" };
                                        controlCollections3.Add(new LiteralControl(string.Concat(markupIdList)));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    }
                                    if (string.Compare(str3, "S", true) == 0)
                                    {
                                        if (!Convert.ToBoolean(dataRow1["IsdecimalSided"]))
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num1, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num9, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num35.ToString("0.00"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num26.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num24.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:15%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(str10));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                            ControlCollection controls4 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num46, "</span>" };
                                            controls4.Add(new LiteralControl(string.Concat(markupIdList)));
                                            ControlCollection controlCollections4 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num31.ToString("C"), "</span>" };
                                            controlCollections4.Add(new LiteralControl(string.Concat(markupIdList)));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        }
                                        else
                                        {
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num1, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:8%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("  <span class='normaltext'>", num9, "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num35.ToString("0.00"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num36.ToString("0.00"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num26.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num24.ToString("C"), "</span>")));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                                            this.plhItemCostView.Controls.Add(new LiteralControl(str10));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                            ControlCollection controls5 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num46, "</span>" };
                                            controls5.Add(new LiteralControl(string.Concat(markupIdList)));
                                            ControlCollection controlCollections5 = this.plhItemCostView.Controls;
                                            markupIdList = new object[] { "  <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num31.ToString("C"), "</span>" };
                                            controlCollections5.Add(new LiteralControl(string.Concat(markupIdList)));
                                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        }
                                    }
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.hdn_Markup.Value = num23.ToString();
                                }
                                else if (string.Compare(this.para, "guillotine", true) == 0)
                                {
                                    this.lblCostViewTitle.Text = "Guillotine Cost View";
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    decimal num47 = Convert.ToDecimal(dataRow1["GuillotineSetupCharge"]);
                                    decimal num48 = Convert.ToDecimal(dataRow1["GuillotineMinimumRunningCharge"]);
                                    decimal num49 = Convert.ToDecimal(dataRow1["GuillotineMarkUp"]);
                                    decimal num50 = Convert.ToDecimal(dataRow1["GuillotineCostPerCut"]);
                                    decimal num51 = Convert.ToDecimal(dataRow1["GuillotinePaperWeight1"]);
                                    int num52 = Convert.ToInt32(dataRow1["GuillotineMaximumThroat1"]);
                                    decimal num53 = Convert.ToDecimal(dataRow1["GuillotinePaperWeight2"]);
                                    int num54 = Convert.ToInt32(dataRow1["GuillotineMaximumThroat2"]);
                                    decimal num55 = Convert.ToDecimal(dataRow1["GuillotinePaperWeight3"]);
                                    int num56 = Convert.ToInt32(dataRow1["GuillotineMaximumThroat3"]);
                                    if (num == 0)
                                    {
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Guillotine Name&nbsp;</span></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow1["GuillotineName"].ToString(), "</span></div>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span  class='normaltext' >Minimum Charge</span></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", num48.ToString("C"), "</span></div>")));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:7%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Quantity</span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:7%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Sheets</span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:11%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>First Trim Cuts </span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>No Of Bundles </span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Second Trim Cuts </span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>No Of Bundles </span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:9%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Cost Per Cut</span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Setup Charge</span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <span class='Headertext'>Mark Up (%)</span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  <span class='Headertext'>Selling Price </span>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                        num++;
                                    }
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    int num57 = 0;
                                    if (num12 <= num51)
                                    {
                                        num57 = num52;
                                    }
                                    else if (num12 <= num53)
                                    {
                                        num57 = num54;
                                    }
                                    else if (num12 <= num55 || num12 > num55)
                                    {
                                        num57 = num56;
                                    }
                                    decimal num58 = new decimal(0);
                                    decimal num59 = new decimal(0);
                                    decimal num60 = new decimal(0);
                                    if (Convert.ToBoolean(dataRow1["IsFirstTrim"]))
                                    {
                                        decimal num61 = Convert.ToDecimal(dataRow1["Height"]);
                                        decimal num62 = Convert.ToDecimal(dataRow1["Width"]);
                                        decimal num63 = Convert.ToDecimal(dataRow1["SheetHeight"]);
                                        decimal num64 = Convert.ToDecimal(dataRow1["SheetWidth"]);
                                        decimal num65 = Convert.ToDecimal(dataRow1["BasisWeight"]);
                                        decimal num66 = EstimateBasePage.Guillotine_First_Trim_Cut(num61, num62, num63, num64, num65, str2, num9, num51, num52, num53, num54, num55, num56, ref num60);
                                        num59 = num66;
                                        num58 = num50 * num66;
                                        num58 = this.ReturnExact2Decimal(num58);
                                    }
                                    if (num59 == new decimal(0))
                                    {
                                        num60 = new decimal(0);
                                    }
                                    decimal num67 = new decimal(0);
                                    decimal num68 = new decimal(0);
                                    decimal num69 = new decimal(0);
                                    decimal num70 = new decimal(0);
                                    decimal num71 = new decimal(0);
                                    int num72 = 0;
                                    int num73 = 0;
                                    if (Convert.ToBoolean(dataRow1["IsSecondTrim"]))
                                    {
                                        num67 = this.Guillotine_Calculation(num9, num57, num5, num47, num48, num49, num50, Convert.ToBoolean(dataRow1["IsIncludeGutters"]), num1, ref num72, ref num73);
                                        num67 = this.ReturnExact2Decimal(num67);
                                    }
                                    if (num72 == 0)
                                    {
                                        num73 = 0;
                                    }
                                    if (Convert.ToBoolean(dataRow1["IsSecondTrim"]) || Convert.ToBoolean(dataRow1["IsFirstTrim"]))
                                    {
                                        decimal num74 = (num58 + num67) + num47;
                                        num74 = this.ReturnExact2Decimal(num74);
                                        num68 = (num48 <= num74 ? num74 : num48);
                                        num68 = this.ReturnExact2Decimal(num68);
                                    }
                                    num70 = num68;
                                    num69 = (num70 * num49) / new decimal(100);
                                    num69 = this.ReturnExact2Decimal(num69);
                                    num71 = this.ReturnExact2Decimal(num70 + num69);
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:7%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num1, "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:7%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num9, "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:11%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num59, "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num60, "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num72, "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num73, "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:9%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num50.ToString("C"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("    <span class='normaltext'>", num47.ToString("C"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                                    string str11 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                                    markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num2, "' ", str11, " value='", this.ReplaceDollorComma(num49), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                                    string str12 = string.Concat(markupIdList);
                                    this.plhItemCostView.Controls.Add(new LiteralControl(str12));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                                    ControlCollection controls6 = this.plhItemCostView.Controls;
                                    markupIdList = new object[] { "    <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num2, "' style='display:none;'>", num70, "</span>" };
                                    controls6.Add(new LiteralControl(string.Concat(markupIdList)));
                                    ControlCollection controlCollections6 = this.plhItemCostView.Controls;
                                    markupIdList = new object[] { "  <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num2, "'>", num71.ToString("C"), "</span>" };
                                    controlCollections6.Add(new LiteralControl(string.Concat(markupIdList)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.hdn_Markup.Value = num49.ToString();
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                    }
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "IW", true) == 0)
                {
                    this.lblCostViewTitle.Text = "Warehouse Item(s) View";
                    this.ItemFrom = "IW";
                    this.para = base.Request.Params["item"].ToString();
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    DataTable dataTable3 = EstimateBasePage.Estimate_Summary_Item_Warehouse_select(this.CompanyID, this.EstType, this.TypeID);
                    int num75 = 0;
                    foreach (DataRow row3 in dataTable3.Rows)
                    {
                        if (num75 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:30%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Warehouse Name</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Unit Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Selling Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num75++;
                        }
                        int num76 = Convert.ToInt32(row3["Quantity"]);
                        decimal num77 = Convert.ToDecimal(row3["UnitPrice"]);
                        decimal num78 = Convert.ToDecimal(row3["Markup"]);
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:30%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row3["WarehouseName"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row3["Quantity"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num77.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        decimal num79 = num76 * num77;
                        num79 = this.ReturnExact2Decimal(num79);
                        decimal num80 = (num79 * num78) / new decimal(100);
                        decimal num81 = num79 + this.ReturnExact2Decimal(num80);
                        num81 = this.ReturnExact2Decimal(num81);
                        string str13 = string.Concat("onblur=javascript:ItemMarkupOnBlur(this.value,", row3["EstItemWarehouseID"].ToString(), ");");
                        str = new string[] { "<input id='txtMarkUp_", row3["EstItemWarehouseID"].ToString(), "' ", str13, "  value='", this.ReplaceDollorComma(num78), "' class='textboxnew' style='width:50px;' maxlength='8' /> " };
                        string str14 = string.Concat(str);
                        this.plhItemCostView.Controls.Add(new LiteralControl(str14 ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        ControlCollection controls7 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", row3["EstItemWarehouseID"].ToString(), "' style='display:none;'>", num79, "</span>" };
                        controls7.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections7 = this.plhItemCostView.Controls;
                        str = new string[] { "<span class='normaltext' id='spnSellingPrice_", row3["EstItemWarehouseID"].ToString(), "'>", num81.ToString("C"), "</span>" };
                        controlCollections7.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hidItemList.Value = string.Concat(this.hidItemList.Value, row3["EstItemWarehouseID"].ToString(), "±");
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "IU", true) == 0)
                {
                    this.lblCostViewTitle.Text = "Other Cost Item(s) View";
                    this.ItemFrom = "IU";
                    this.OtherCostSubItem();
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "IO", true) == 0)
                {
                    this.lblCostViewTitle.Text = "Out Work Item(s) View";
                    this.ItemFrom = "IO";
                    this.para = base.Request.Params["item"].ToString();
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    DataTable dataTable4 = EstimateBasePage.Estimate_Summary_Item_Outwork_select(this.CompanyID, this.EstType, this.TypeID);
                    int num82 = 0;
                    long num83 = (long)0;
                    foreach (DataRow dataRow3 in dataTable4.Rows)
                    {
                        if (num82 == 0)
                        {
                            num83 = Convert.ToInt64(dataRow3["EstItemOutworkID"]);
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Outwork Title</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Cost</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Markup Type</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Selling Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num82++;
                        }
                        if (num83 != Convert.ToInt64(dataRow3["EstItemOutworkID"]))
                        {
                            num83 = Convert.ToInt64(dataRow3["EstItemOutworkID"]);
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div style='border-top:solid 1px silver'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                        }
                        string str15 = dataRow3["MarkupType"].ToString();
                        decimal num84 = Convert.ToDecimal(dataRow3["MarkupValue"]);
                        decimal num85 = new decimal(0);
                        decimal num86 = Convert.ToDecimal(dataRow3["TotalPrice"]);
                        num86 = this.ReturnExact2Decimal(num86);
                        decimal num87 = Convert.ToDecimal(dataRow3["Cost"]);
                        num87 = this.ReturnExact2Decimal(num87);
                        str15 = (string.Compare(str15, "F", true) != 0 ? "Percentage" : "Flat");
                        num85 = this.ReturnExact2Decimal(num84);
                        this.hidItemList.Value = string.Concat(this.hidItemList.Value, dataRow3["EstItemOutworkSupplierID"].ToString(), "±");
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", dataRow3["RFQTitle"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", dataRow3["Quantity"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num87.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", str15, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        str = new string[] { "onblur=javascript:ItemOutworkMarkupOnBlur(this.value,\"", dataRow3["EstItemOutworkSupplierID"].ToString(), ",", str15, "\");MakePrice2Decimal(this);" };
                        string str16 = string.Concat(str);
                        str = new string[] { "<input id='txtMarkUp_", dataRow3["EstItemOutworkSupplierID"].ToString(), "' ", str16, "  value='", this.ReplaceDollorComma(num85), "' class='textboxnew' style='width:50px;'   maxlength='8'/> " };
                        string str17 = string.Concat(str);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(str17 ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        ControlCollection controls8 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", dataRow3["EstItemOutworkSupplierID"].ToString(), "' style='display:none;'>", num87, "</span>" };
                        controls8.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections8 = this.plhItemCostView.Controls;
                        str = new string[] { "<span class='normaltext' id='spnSellingPrice_", dataRow3["EstItemOutworkSupplierID"].ToString(), "'>", num86.ToString("C"), "</span>" };
                        controlCollections8.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    }
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "U", true) == 0)
                {
                    this.lblCostViewTitle.Text = "Other Cost Item(s) View";
                    this.ItemFrom = "IU";
                    this.para = base.Request.Params["item"].ToString();
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    long num88 = Convert.ToInt64(base.Request.Params["TypeID"]);
                    DataTable dataTable5 = EstimateBasePage.Estimate_Summary_Item_OtherCost_select(this.CompanyID, "U", num88);
                    int num89 = 0;
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (DataRow row4 in dataTable5.Rows)
                    {
                        string str18 = row4["CalculationName"].ToString();
                        string str19 = row4["CalculationType"].ToString();
                        string str20 = row4["VariableDDLType"].ToString();
                        decimal num90 = Convert.ToDecimal(row4["HourlyRunSpeed"]);
                        string str21 = row4["FormulaTag"].ToString();
                        string[] strArrays = str21.Split(new char[] { '\u00B6' });
                        int num91 = Convert.ToInt32(row4["SetupTime"]);
                        decimal num92 = Convert.ToDecimal(row4["HourlyRate"]);
                        Convert.ToDecimal(row4["HoursOrQty"]);
                        decimal num93 = Convert.ToDecimal(row4["Markup"]);
                        decimal num94 = Convert.ToDecimal(row4["MinimumCost"]);
                        stringBuilder.Append("<div class='only10px'></div>");
                        stringBuilder.Append("<div align='left' style='width:60%;padding-left:10px'>");
                        stringBuilder.Append("<div align='left' style='border:1px solid silver;width:100%;padding:5px;border-style:dashed;'>");
                        if (string.Compare(str19, "t", true) == 0 || string.Compare(str19, "q", true) == 0)
                        {
                            stringBuilder.Append("<span><u><b>Work Instruction:</b></u></span>");
                            stringBuilder.Append("<div class='only5px'></div>");
                        }
                        if (string.Compare(str18, "v", true) == 0)
                        {
                            stringBuilder.Append("<div> Print Layout Value: 0</div>    ");
                        }
                        else if (string.Compare(str19, "f", true) != 0)
                        {
                            stringBuilder.Append(string.Concat("<div> Make Ready Time: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["MakeReadyTime"].ToString()), 0, "", false, false, true), " min</div>    "));
                        }
                        if (num90 > new decimal(0) && string.Compare(str19, "t", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div> Hourly Run Speed: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row4["HourlyRunSpeed"].ToString()), 0, "", false, false, true), "</div>    "));
                            stringBuilder.Append("<div> Passes: 0</div>    ");
                        }
                        stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                        stringBuilder.Append("<div><span><u><b>Calculation:</b></u></span></div>    ");
                        stringBuilder.Append("<div class='only5px'></div>");
                        if (string.Compare(str19, "t", true) != 0)
                        {
                            if (string.Compare(str19, "q", true) == 0)
                            {
                                if (str20 == "1")
                                {
                                    stringBuilder.Append("<div>(Print Sheet Qty (exl. Spoilage) x Unit Rate)  + Setup Cost</div>    ");
                                }
                                else if (str20 == "2")
                                {
                                    stringBuilder.Append("<div>(Print Sheet Qty (inc. Spoilage) x Unit Rate) + Setup Cost</div>    ");
                                }
                                else if (str20 == "3")
                                {
                                    stringBuilder.Append("<div>(Finished Item Qty (exl. Spoilage) x Unit Rate) + Setup Cost</div>    ");
                                }
                                else if (str20 != "4")
                                {
                                    stringBuilder.Append("<div>(Quantity x Unit Rate) + Setup Cost</div>");
                                }
                                else
                                {
                                    stringBuilder.Append("<div>(Finished Item Qty (inc. Spoilage) x Unit Rate) + Setup Cost</div>");
                                }
                            }
                        }
                        else if (str20 == "1")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (exl. Spoilage) / Hourly Run Speed)  x Hourly Rate    + Setup Cost</div>    ");
                        }
                        else if (str20 == "2")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (inc. Spoilage) / Hourly Run Speed)  x Hourly Rate + Setup Cost</div>    ");
                        }
                        else if (str20 == "3")
                        {
                            stringBuilder.Append("<div> (Finished Item Qty (exl. Spoilage) / Hourly Run Speed) x Hourly Rate + Setup Cost</div>    ");
                        }
                        else if (str20 != "4")
                        {
                            stringBuilder.Append("<div>(Hours x Hourly Rate) + Setup Cost</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div> (Finished Item Qty (inc. Spoilage) / Hourly Run Speed)  x Hourly Rate + Setup Cost</div>    ");
                        }
                        if (string.Compare(str19, "f", true) == 0 || string.Compare(str19, "m", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div>", strArrays[1], "+ Markup </div>"));
                        }
                        stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                        stringBuilder.Append("<div><span><u><b>Actuals:</b></u></span></div>");
                        stringBuilder.Append("<div class='only5px'></div>");
                        if (num89 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left' style='width:99%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;'><span class='normaltext'>Other Cost Name:&nbsp;</span></div><div style='float:left;'><span class='Headertext'>", row4["OtherCostName"].ToString(), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' style='border:0px solid red'>"));
                            if (string.Compare(str19, "t", true) != 0)
                            {
                                if (string.Compare(str19, "q", true) == 0 && (string.Compare(str18, "f", true) == 0 || string.Compare(str18, "v", true) == 0))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Qty</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Unit Rate</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Setup Time</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                            else if (string.Compare(str18, "f", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hours </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                if (Convert.ToDecimal(row4["HourlyRunSpeed"]) != new decimal(0))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Setup Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (string.Compare(str18, "v", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Print Sheets </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hours </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                if (Convert.ToDecimal(row4["HourlyRunSpeed"]) != new decimal(0))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Setup Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Minimum Charge (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Selling Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num89++;
                        }
                        decimal num95 = (num91 * num92) / new decimal(60);
                        num95 = this.ReturnExact2Decimal(num95);
                        decimal num96 = new decimal(0);
                        decimal num97 = new decimal(0);
                        if (!(row4["CalculationType"].ToString() == "t") && row4["CalculationType"].ToString() == "q")
                        {
                            Convert.ToDecimal(row4["UnitRate"]);
                        }
                        num96 = Convert.ToDecimal(row4["Cost"]);
                        num96 = this.ReturnExact2Decimal(num96);
                        if (string.Compare(str19, "t", true) != 0)
                        {
                            if (string.Compare(str19, "q", true) == 0 && (string.Compare(str18, "f", true) == 0 || string.Compare(str18, "v", true) == 0))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row4["HoursOrQty"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), row4["UnitRate"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), row4["HourlyRate"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row4["SetupTime"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else if (string.Compare(str18, "f", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row4["HoursOrQty"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row4["MakeReadyTime"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), row4["HourlyRate"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            if (Convert.ToDecimal(row4["HourlyRunSpeed"]) != new decimal(0))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row4["HourlyRunSpeed"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row4["SetupTime"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (string.Compare(str18, "v", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", row4["HoursOrQty"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normalText'>0</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", row4["HoursOrQty"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", row4["MakeReadyTime"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.comm.GetCurrencyinRequiredFormate("", true), row4["HourlyRate"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            if (Convert.ToDecimal(row4["HourlyRunSpeed"]) != new decimal(0))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", row4["HourlyRunSpeed"].ToString(), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", row4["SetupTime"].ToString(), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num94.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hidItemList.Value = string.Concat(this.hidItemList.Value, row4["EstOtherCostID"].ToString(), "±");
                        string str22 = string.Concat("onblur=javascript:ItemMarkupOnBlur(this.value,", row4["EstOtherCostID"].ToString(), ");MakePrice2Decimal(this);");
                        str = new string[] { "<input id='txtMarkUp_", row4["EstOtherCostID"].ToString(), "' ", str22, "  value='", this.ReplaceDollorComma(num93), "' class='textboxnew' style='width:50px;'   maxlength='8' /> " };
                        string str23 = string.Concat(str);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(str23 ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        if (num94 > num96)
                        {
                            num96 = num94;
                            num96 = this.ReturnExact2Decimal(num96);
                        }
                        decimal num98 = (num96 * num93) / new decimal(100);
                        num98 = this.ReturnExact2Decimal(num98);
                        num97 = num96 + num98;
                        num97 = this.ReturnExact2Decimal(num97);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;1idth:100px;'> "));
                        ControlCollection controls9 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", row4["EstOtherCostID"].ToString(), "' style='display:none;'>", num96, "</span>" };
                        controls9.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections9 = this.plhItemCostView.Controls;
                        str = new string[] { " <span class='normaltext' id='spnSellingPrice_", row4["EstOtherCostID"].ToString(), "'>", num97.ToString("C"), "</span>" };
                        controlCollections9.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        if (string.Compare(str19, "t", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div><b>Quantity:</b> ", row4["HoursOrQty"].ToString(), "</div>"));
                            markupIdList = new object[] { "<div>(", row4["HoursOrQty"].ToString(), " x ", num92, ") + ", num95, "= ", this.comm.GetCurrencyinRequiredFormate("", true), num97, "</div>    " };
                            stringBuilder.Append(string.Concat(markupIdList));
                        }
                        else if (string.Compare(str19, "q", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div><b>Quantity:</b> ", row4["HoursOrQty"].ToString(), "</div>"));
                            markupIdList = new object[] { "<div>(", Convert.ToDecimal(row4["HoursOrQty"].ToString()), " x ", row4["UnitRate"], ") + ", num95, "= ", this.comm.GetCurrencyinRequiredFormate("", true), num97, "</div>    " };
                            stringBuilder.Append(string.Concat(markupIdList));
                        }
                        if (string.Compare(str19, "f", true) == 0 || string.Compare(str19, "m", true) == 0)
                        {
                            strArrays[0] = (strArrays[0] == "" ? "0" : strArrays[0]);
                            string str24 = strArrays[0];
                            try
                            {
                                decimal num99 = (new MathParser()).Calculate(strArrays[0]);
                                num99 = Convert.ToDecimal(num99.ToString());
                                string str25 = num99.ToString();
                                decimal num100 = this.ReturnExact2Decimal(Convert.ToDecimal(str25)) + num98;
                                str24 = string.Concat(str24, " + ", num98.ToString());
                                str = new string[] { "<div align='left'> ", str24, " = ", num100.ToString("C"), " </div>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            catch
                            {
                                stringBuilder.Append(string.Concat("<div align='left'> ", str24, " </div>"));
                            }
                        }
                        stringBuilder.Append("<div class='only10px'></div>    ");
                    }
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div class='only10px'></div>    ");
                    stringBuilder.Append("</div>");
                    this.plhItemCostView.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "W", true) == 0)
                {
                    this.lblCostViewTitle.Text = "Warehouse Item(s) View";
                    this.ItemFrom = "W";
                    this.para = base.Request.Params["item"].ToString();
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    long num101 = Convert.ToInt64(base.Request.Params["TypeID"]);
                    DataTable dataTable6 = EstimateBasePage.Warehouse_Information_By_EstimateItemID(this.CompanyID, this.EstimateItemID, num101);
                    int num102 = 0;
                    foreach (DataRow dataRow4 in dataTable6.Rows)
                    {
                        if (num102 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Warehouse Item Name</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Unit Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Selling Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num102++;
                        }
                        int num103 = Convert.ToInt32(dataRow4["Quantity"]);
                        decimal num104 = Convert.ToDecimal(dataRow4["UnitPrice"]);
                        decimal num105 = Convert.ToDecimal((dataRow4["Markup"].ToString() == "" ? 0 : dataRow4["Markup"]));
                        decimal num106 = num104 * num103;
                        decimal num107 = num106 + ((num106 * num105) / new decimal(100));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", dataRow4["Name"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num103, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num104.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        string str26 = string.Concat("onblur=javascript:WarehouseMarkupOnBlur(this,this.value,'", num101, "');MakePrice2Decimal(this);");
                        str = new string[] { "<input id='txtMarkUp_", dataRow4["EstWarehouseItemID"].ToString(), "' ", str26, "  value='", this.ReplaceDollorComma(num105), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                        string str27 = string.Concat(str);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(str27));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        ControlCollection controls10 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnSellingExMarkup_", dataRow4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", num106, "</span>" };
                        controls10.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections10 = this.plhItemCostView.Controls;
                        str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", dataRow4["EstWarehouseItemID"].ToString(), "'>", num107.ToString("C"), "</span>" };
                        controlCollections10.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.hidItemList.Value = num101.ToString();
                    }
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "C", true) == 0)
                {
                    this.Generate_Price_Catalogue_Items();
                }
            }
            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float: right; width: 20%;'>  "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float: left;'> "));
            Button button = new Button()
            {
                Text = "Cancel",
                CssClass = "button",
                Width = Unit.Pixel(65)
            };
            button.Attributes.Add("onclick", "javascript:window.close();return false;");
            this.plhItemCostView.Controls.Add(button);
            this.plhItemCostView.Controls.Add(new LiteralControl(" </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float: left; width: 10px;'>&nbsp; </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float: left;'> "));
            Button button1 = new Button()
            {
                Text = "Save",
                CssClass = "button",
                Width = Unit.Pixel(65)
            };
            button1.Click += new EventHandler(this.lnkbtnSaveItemView_OnClick);
            button1.Attributes.Add("onclick", "javascript:return ItemMarkupSave();");
            this.plhItemCostView.Controls.Add(button1);
            this.plhItemCostView.Controls.Add(new LiteralControl(" </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
            this.Page.Title = this.lblCostViewTitle.Text;
            this.pnlCostView.Visible = true;
        }

        private decimal PressCostPerClick(decimal PrintSheets, decimal ChargeableRate, int ChargeableSheets)
        {
            decimal num = new decimal(0);
            num = ChargeableRate / Convert.ToDecimal(ChargeableSheets);
            return num * PrintSheets;
        }

        private string ReplaceDollorComma(decimal Markup)
        {
            string empty = string.Empty;
            if (Markup >= new decimal(0))
            {
                empty = Markup.ToString("C");
                empty = empty.Replace(",", "").Replace(this.comm.GetCurrencyinRequiredFormate("", true) ?? "", "");
            }
            else
            {
                empty = Markup.ToString();
            }
            return empty;
        }

        public decimal ReturnExact2Decimal(decimal Amount)
        {
            Amount = Amount * new decimal(100);
            string[] strArrays = Amount.ToString().Split(new char[] { '.' });
            decimal num = new decimal(0);
            num = Convert.ToDecimal(strArrays[0]);
            Amount = num / new decimal(100);
            return Amount;
        }

        protected void SPLCostGenerate()
        {
            object[] markupIdList;
            int num;
            if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
            {
                this.dtQty = JobBasePage.Job_Summary_Item_Cost_View_Qtys_And_Cal(this.CompanyID, this.EstimateItemID, this.TypeID, this.EstType, this.EstBookletSectionID, "quantity", this.QtyNo);
            }
            else
            {
                this.dtQty = EstimateBasePage.Estimate_Summary_Item_Cost_View_Qtys_And_Cal(this.CompanyID, this.EstimateItemID, this.TypeID, this.EstType, this.EstBookletSectionID, "quantity");
            }
            DataTable dataTable = EstimateBasePage.Estimate_Summary_Item_Cost_View_Qtys_And_Cal(this.CompanyID, this.EstimateItemID, this.TypeID, this.EstType, this.EstBookletSectionID, "calculation");
            int num1 = 0;
            foreach (DataRow row in this.dtQty.Rows)
            {
                int num2 = Convert.ToInt32(row["Quantity"]);
                long num3 = Convert.ToInt64(row["QuantityID"]);
                if (!string.IsNullOrEmpty(this.MarkupIdList))
                {
                    markupIdList = new object[] { this.MarkupIdList, "±", this.EstimateItemID, "_", num3 };
                    this.MarkupIdList = string.Concat(markupIdList);
                }
                else
                {
                    this.MarkupIdList = string.Concat(this.EstimateItemID, "_", num3);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.EstCalculationID = Convert.ToInt64(dataRow["EstCalculationID"]);
                    decimal num4 = Convert.ToDecimal(dataRow["SetUpSpoilage"]);
                    Convert.ToDecimal(dataRow["SetUpSpoilage"]);
                    decimal num5 = Convert.ToDecimal(dataRow["RunningSpoilage"]);
                    string str = dataRow["PrintLayout"].ToString();
                    int num6 = (str == "L" ? Convert.ToInt32(dataRow["LandScapeValue"]) : Convert.ToInt32(dataRow["PortraitValue"]));
                    decimal num7 = new decimal(0);
                    decimal num8 = EstimateBasePage.PrintSheets_Calculation_For_SingleItem(num2, num6, num4, num5, out num7);
                    decimal num9 = Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                    decimal num10 = Convert.ToDecimal(dataRow["PaperMarkup"]);
                    decimal num11 = Convert.ToDecimal(dataRow["PaperWeight"]);
                    string str1 = dataRow["Press"].ToString();
                    string str2 = dataRow["Colour"].ToString();
                    string str3 = dataRow["SideColor"].ToString();
                    dataRow["PaperName"].ToString();
                    string.Compare(this.EstType, "L", true);
                    if (string.Compare(this.para, "paper", true) == 0)
                    {
                        this.lblCostViewTitle.Text = "Paper Cost";
                        decimal num12 = num8 * num9;
                        num12 = this.ReturnExact2Decimal(num12);
                        decimal num13 = (num12 * num10) / new decimal(100);
                        num13 = this.ReturnExact2Decimal(num13);
                        num12 = num13 + num12;
                        num12 = this.ReturnExact2Decimal(num12);
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        if (num1 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Paper Name</span></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow["PaperName"].ToString(), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            if (Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Paper Supplied</span></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='box'><span class='Headertext'>Yes</span></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            else if (Convert.ToBoolean(dataRow["IsPricePerPack"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Price for Whole Pack</span></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='box'><span class='Headertext'>Yes</span></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            if (!Convert.ToBoolean(dataRow["IsPricePerPack"]) && !Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (Convert.ToBoolean(dataRow["IsPricePerPack"]) && !Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Packed In</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Pack Price</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Selling Price</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            num1++;
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        decimal num14 = num12 - num13;
                        num14 = this.ReturnExact2Decimal(num14);
                        decimal num15 = Convert.ToDecimal(dataRow["PackedIn"]);
                        decimal num16 = Convert.ToDecimal(dataRow["PackedPrice"]);
                        decimal num17 = Math.Ceiling(num8 / num15);
                        if (Convert.ToBoolean(dataRow["IsPricePerPack"]))
                        {
                            decimal num18 = num17 * num16;
                            num18 = this.ReturnExact2Decimal(num18);
                            num13 = (num18 * num10) / new decimal(100);
                            num13 = this.ReturnExact2Decimal(num13);
                            num14 = num18;
                            num12 = num18 + num13;
                            num12 = this.ReturnExact2Decimal(num12);
                        }
                        if (Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                        {
                            num13 = new decimal(0);
                            num14 = new decimal(0);
                            num12 = new decimal(0);
                        }
                        if (!Convert.ToBoolean(dataRow["IsPricePerPack"]) && !Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        else if (Convert.ToBoolean(dataRow["IsPricePerPack"]) && !Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num15, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num16.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (Convert.ToBoolean(dataRow["IsPaperSupplied"]))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num9.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        string str4 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                        markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num3, "' ", str4, " value='", this.ReplaceDollorComma(num10), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                        string str5 = string.Concat(markupIdList);
                        this.plhItemCostView.Controls.Add(new LiteralControl(str5));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        num14 = Convert.ToDecimal(Math.Round(num14, 2));
                        ControlCollection controls = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num14, "</span>" };
                        controls.Add(new LiteralControl(string.Concat(markupIdList)));
                        num12 = Convert.ToDecimal(Math.Round(num12, 2));
                        ControlCollection controlCollections = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num12.ToString("C"), "</span>" };
                        controlCollections.Add(new LiteralControl(string.Concat(markupIdList)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='onlyEmpty'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:right;padding-right:200px'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span id='spn_error' class='spanerrorMsg' style='width:125px;display:none;'>Please Enter Markup</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hdn_Markup.Value = num10.ToString();
                    }
                    else if (string.Compare(this.para, "press", true) == 0)
                    {
                        this.lblCostViewTitle.Text = "Press Cost View";
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' >"));
                        decimal num19 = Convert.ToDecimal(dataRow["BlackChargeableRate"]);
                        decimal num20 = Convert.ToDecimal(dataRow["ColorChargeableRate"]);
                        int num21 = Convert.ToInt32(dataRow["NoOfChargeableSheets"]);
                        decimal num22 = Convert.ToDecimal(dataRow["PressMarkUp"]);
                        decimal num23 = Convert.ToDecimal(dataRow["PressSetupCharge"]);
                        decimal num24 = Convert.ToDecimal(dataRow["PressMinimumRunningCharge"]);
                        decimal num25 = Convert.ToDecimal(dataRow["HourlyCharge"]);
                        long num26 = Convert.ToInt64(dataRow["SpeedWeightTableID"]);
                        string str6 = (str1 == "L" ? dataRow["PrintQuality"].ToString() : string.Empty);
                        int num27 = Convert.ToInt32(dataRow["PrintPerHourLow"]);
                        int num28 = Convert.ToInt32(dataRow["PrintPerHourMedium"]);
                        int num29 = Convert.ToInt32(dataRow["PrintPerHourHigh"]);
                        decimal num30 = new decimal(0);
                        decimal num31 = new decimal(0);
                        if (num1 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left' > "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Press Name&nbsp;</span></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow["PressName"].ToString(), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span  class='normaltext' >Minimum Charge</span></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", num24.ToString("C"), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            if (Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span  class='normaltext' >decimal Sided</span></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='box'><span class='Headertext'>Yes</span></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' >"));
                            if (string.Compare(str1, "C", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                if (!Convert.ToBoolean(dataRow["IsdecimalSided"]))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Rate</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                }
                                else
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Rate (Side 1)</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Rate (Side 2)</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Chargeable Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            else if (string.Compare(str1, "Z", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Click Charge Cost</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            if (string.Compare(str1, "S", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                if (!Convert.ToBoolean(dataRow["IsdecimalSided"]))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Job Time(min)</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                }
                                else
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Job Time(min) Side 1</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Job Time(min) Side 2</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Hourly Rate</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            if (string.Compare(str1, "L", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Quantity</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Sheets</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Hourly Charge</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>No. Of Hours</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Setup Charge</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext'>Mark Up (%)</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='Headertext' >Selling Price</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            num1++;
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        decimal num32 = new decimal(0);
                        decimal num33 = new decimal(0);
                        decimal num34 = new decimal(0);
                        decimal num35 = new decimal(0);
                        decimal num36 = new decimal(0);
                        decimal num37 = new decimal(0);
                        if (string.Compare(str1, "C", true) == 0)
                        {
                            num32 = (str2 == "color" ? num20 : num19);
                            num30 = this.PressCostPerClick(num8, num32, num21);
                            num30 = this.ReturnExact2Decimal(num30);
                            if (Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                num35 = (str3 == "color" ? num20 : num19);
                                decimal num38 = this.PressCostPerClick(num8, num35, num21);
                                num30 = num30 + this.ReturnExact2Decimal(num38);
                                num30 = this.ReturnExact2Decimal(num30);
                            }
                        }
                        else if (str1 == "S")
                        {
                            num30 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num8, num11, num25, num26, str2, num23, num24, num22, ref num33);
                            if (Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                decimal num39 = EstimateBasePage.SpeedWeightLookup_Cost(this.CompanyID, num8, num11, num25, num26, str3, num23, num24, num22, ref num36);
                                num30 = num30 + num39;
                                num30 = this.ReturnExact2Decimal(num30);
                            }
                        }
                        else if (str1 == "Z")
                        {
                            decimal num40 = new decimal(0);
                            int num41 = Convert.ToInt32(num8);
                            if (!Convert.ToBoolean(dataRow["CalculationType"]))
                            {
                                DataTable dataTable1 = EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, this.EstCalculationID, num41, str2);
                                foreach (DataRow row1 in dataTable1.Rows)
                                {
                                    int num42 = Convert.ToInt32(row1["ChargeableSheets"]);
                                    num37 = Convert.ToDecimal(row1["Cost"]);
                                    num40 = (num37 / num42) * num41;
                                }
                            }
                            else
                            {
                                num40 = EstimateBasePage.Click_Charge_Zone_Cost(this.CompanyID, this.EstCalculationID, num41, str2);
                            }
                            num30 = num40;
                            num30 = this.ReturnExact2Decimal(num30);
                            if (Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                decimal num43 = new decimal(0);
                                if (!Convert.ToBoolean(dataRow["CalculationType"]))
                                {
                                    DataTable dataTable2 = EstimateBasePage.estimate_zone_2nd_calculation(this.CompanyID, this.EstCalculationID, num41, str3);
                                    foreach (DataRow dataRow1 in dataTable2.Rows)
                                    {
                                        int num44 = Convert.ToInt32(dataRow1["ChargeableSheets"]);
                                        num37 = Convert.ToDecimal(dataRow1["Cost"]);
                                        num43 = (num37 / num44) * num41;
                                    }
                                }
                                else
                                {
                                    num43 = EstimateBasePage.Click_Charge_Zone_Cost(this.CompanyID, this.EstCalculationID, num41, str3);
                                }
                                num43 = this.ReturnExact2Decimal(num43);
                                num30 = num30 + num43;
                                num30 = this.ReturnExact2Decimal(num30);
                            }
                        }
                        else if (str1 == "L")
                        {
                            if (string.Compare(str6, "low", true) == 0)
                            {
                                num34 = num8 / num27;
                            }
                            else if (string.Compare(str6, "medium", true) == 0)
                            {
                                num34 = num8 / num28;
                            }
                            else if (string.Compare(str6, "high", true) == 0)
                            {
                                num34 = num8 / num29;
                            }
                            num34 = this.ReturnExact2Decimal(num34);
                            num30 = num34 * num25;
                            num30 = this.ReturnExact2Decimal(num30);
                            if (Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                num30 = num30 * new decimal(2);
                            }
                        }
                        num30 = num30 + num23;
                        num30 = this.ReturnExact2Decimal(num30);
                        if (num24 > num30)
                        {
                            num30 = num24;
                            num30 = this.ReturnExact2Decimal(num30);
                        }
                        num31 = (num30 * num22) / new decimal(100);
                        num31 = this.ReturnExact2Decimal(num31);
                        num30 = num30 + num31;
                        num30 = this.ReturnExact2Decimal(num30);
                        decimal num45 = num30 - num31;
                        num45 = this.ReturnExact2Decimal(num45);
                        string str7 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                        markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num3, "' ", str7, " value='", this.ReplaceDollorComma(num22), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                        string str8 = string.Concat(markupIdList);
                        if (string.Compare(str1, "C", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            if (!Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num32.ToString("C"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            else
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num32.ToString("C"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:18%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num35.ToString("C"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num21, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num23.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(str8));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            num45 = Convert.ToDecimal(Math.Round(num45, 2));
                            ControlCollection controls1 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num45, "</span>" };
                            controls1.Add(new LiteralControl(string.Concat(markupIdList)));
                            num30 = Convert.ToDecimal(Math.Round(num30, 2));
                            ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num30.ToString("C"), "</span>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(markupIdList)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        else if (string.Compare(str1, "Z", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            if (!Convert.ToBoolean(dataRow["CalculationType"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num37.ToString("C"), "</span>")));
                            }
                            else
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <span class='normaltext'>Click Chargeable Rate</span>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num23.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(str8));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            num45 = Convert.ToDecimal(Math.Round(num45, 2));
                            ControlCollection controls2 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num45, "</span>" };
                            controls2.Add(new LiteralControl(string.Concat(markupIdList)));
                            num30 = Convert.ToDecimal(Math.Round(num30, 2));
                            ControlCollection controlCollections2 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num30.ToString("C"), "</span>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(markupIdList)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        else if (string.Compare(str1, "S", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:8%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            if (!Convert.ToBoolean(dataRow["IsdecimalSided"]))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num33.ToString("0.00"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            else
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num33.ToString("0.00"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:16%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num36.ToString("0.00"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num25.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num23.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(str8));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            num45 = Convert.ToDecimal(Math.Round(num45, 2));
                            ControlCollection controls3 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num45, "</span>" };
                            controls3.Add(new LiteralControl(string.Concat(markupIdList)));
                            num30 = Convert.ToDecimal(Math.Round(num30, 2));
                            ControlCollection controlCollections3 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num30.ToString("C"), "</span>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(markupIdList)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        else if (string.Compare(str1, "L", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num25.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num34, "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num23.ToString("C"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(str8));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            num45 = Convert.ToDecimal(Math.Round(num45, 2));
                            ControlCollection controls4 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num45, "</span>" };
                            controls4.Add(new LiteralControl(string.Concat(markupIdList)));
                            num30 = Convert.ToDecimal(Math.Round(num30, 2));
                            ControlCollection controlCollections4 = this.plhItemCostView.Controls;
                            markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num30.ToString("C"), "</span>" };
                            controlCollections4.Add(new LiteralControl(string.Concat(markupIdList)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hdn_Markup.Value = num22.ToString();
                    }
                    else if (string.Compare(this.para, "guillotine", true) == 0)
                    {
                        this.lblCostViewTitle.Text = "Guillotine Cost View";
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        decimal num46 = Convert.ToDecimal(dataRow["GuillotineSetupCharge"]);
                        decimal num47 = Convert.ToDecimal(dataRow["GuillotineMinimumRunningCharge"]);
                        decimal num48 = Convert.ToDecimal(dataRow["GuillotineMarkUp"]);
                        decimal num49 = Convert.ToDecimal(dataRow["GuillotineCostPerCut"]);
                        decimal num50 = Convert.ToDecimal(dataRow["GuillotinePaperWeight1"]);
                        int num51 = Convert.ToInt32(dataRow["GuillotineMaximumThroat1"]);
                        decimal num52 = Convert.ToDecimal(dataRow["GuillotinePaperWeight2"]);
                        int num53 = Convert.ToInt32(dataRow["GuillotineMaximumThroat2"]);
                        decimal num54 = Convert.ToDecimal(dataRow["GuillotinePaperWeight3"]);
                        int num55 = Convert.ToInt32(dataRow["GuillotineMaximumThroat3"]);
                        int num56 = Convert.ToInt32(dataRow["PortraitValue"]);
                        int num57 = Convert.ToInt32(dataRow["LandscapeValue"]);
                        int num58 = 0;
                        num = (dataRow["PrintLayout"].ToString() == "L" ? num57 : num56);
                        num58 = num;
                        int num59 = num;
                        if (num59 != 0)
                        {
                            Convert.ToInt32(num2 / num59);
                        }
                        if (num1 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span class='normaltext' >Guillotine Name&nbsp;</span></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", dataRow["GuillotineName"].ToString(), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='bglabel' style='width:150px;'><span  class='normaltext' >Minimum Charge</span></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", num47.ToString("C"), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:7%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Quantity</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:7%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Sheets</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:11%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>First Trim Cuts </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>No Of Bundles </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:12%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Second Trim Cuts </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>No Of Bundles </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:9%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Cost Per Cut</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("    <span class='Headertext'>Setup Charge</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <div style='float:left;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  <span class='Headertext'>Selling Price </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("  </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            num1++;
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        int num60 = 0;
                        if (num11 <= num50)
                        {
                            num60 = num51;
                        }
                        else if (num11 <= num52)
                        {
                            num60 = num53;
                        }
                        else if (num11 <= num54 || num11 > num54)
                        {
                            num60 = num55;
                        }
                        decimal num61 = new decimal(0);
                        decimal num62 = new decimal(0);
                        decimal num63 = new decimal(0);
                        if (Convert.ToBoolean(dataRow["IsFirstTrim"]))
                        {
                            decimal num64 = Convert.ToDecimal(dataRow["Height"]);
                            decimal num65 = Convert.ToDecimal(dataRow["Width"]);
                            decimal num66 = Convert.ToDecimal(dataRow["SheetHeight"]);
                            decimal num67 = Convert.ToDecimal(dataRow["SheetWidth"]);
                            decimal num68 = Convert.ToDecimal(dataRow["BasisWeight"]);
                            decimal num69 = EstimateBasePage.Guillotine_First_Trim_Cut(num64, num65, num66, num67, num68, str, num8, num50, num51, num52, num53, num54, num55, ref num63);
                            num62 = num69;
                            num61 = num49 * num69;
                            num61 = this.ReturnExact2Decimal(num61);
                        }
                        if (num62 == new decimal(0))
                        {
                            num63 = new decimal(0);
                        }
                        decimal num70 = new decimal(0);
                        decimal num71 = new decimal(0);
                        decimal num72 = new decimal(0);
                        decimal num73 = new decimal(0);
                        decimal num74 = new decimal(0);
                        int num75 = 0;
                        int num76 = 0;
                        if (Convert.ToBoolean(dataRow["IsSecondTrim"]))
                        {
                            num70 = this.Guillotine_Calculation(num8, num60, num58, num46, num47, num48, num49, Convert.ToBoolean(dataRow["IsIncludeGutters"]), num2, ref num75, ref num76);
                            num70 = this.ReturnExact2Decimal(num70);
                        }
                        if (num75 == 0)
                        {
                            num76 = 0;
                        }
                        if (Convert.ToBoolean(dataRow["IsSecondTrim"]) || Convert.ToBoolean(dataRow["IsFirstTrim"]))
                        {
                            decimal num77 = (num61 + num70) + num46;
                            num77 = this.ReturnExact2Decimal(num77);
                            num71 = (num47 <= num77 ? num77 : num47);
                            num71 = this.ReturnExact2Decimal(num71);
                        }
                        num73 = num71;
                        num73 = this.ReturnExact2Decimal(num73);
                        num72 = (num73 * num48) / new decimal(100);
                        num72 = this.ReturnExact2Decimal(num72);
                        num74 = this.ReturnExact2Decimal(num73 + num72);
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:7%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:7%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:11%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num62, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num63, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num75, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num76, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:9%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num49.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num46.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        string str9 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                        markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num3, "' ", str9, " value='", this.ReplaceDollorComma(num48), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                        string str10 = string.Concat(markupIdList);
                        this.plhItemCostView.Controls.Add(new LiteralControl(str10));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        ControlCollection controls5 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num73, "</span>" };
                        controls5.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections5 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num74.ToString("C"), "</span>" };
                        controlCollections5.Add(new LiteralControl(string.Concat(markupIdList)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hdn_Markup.Value = num48.ToString();
                    }
                    else if (string.Compare(this.para, "ink", true) == 0)
                    {
                        this.lblCostViewTitle.Text = "Ink Cost View";
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        string str11 = dataRow["OneSqCmInkCost"].ToString();
                        decimal num78 = Convert.ToDecimal(dataRow["InkMarkup"]);
                        if (num1 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Sheets</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Selling Price </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num1++;
                        }
                        decimal num79 = new decimal(0);
                        decimal num80 = new decimal(0);
                        decimal num81 = new decimal(0);
                        if (!string.IsNullOrEmpty(str11.Trim()))
                        {
                            decimal num82 = Convert.ToInt32(dataRow["JobWidth"]) / 10;
                            decimal num83 = Convert.ToInt32(dataRow["JobHeight"]) / 10;
                            decimal num84 = num82 * num83;
                            decimal num85 = Convert.ToDecimal(dataRow["InkCoverageSide1"]);
                            decimal num86 = Convert.ToDecimal(dataRow["InkCoverageSide2"]);
                            string[] strArrays = str11.Split(new char[] { '±' });
                            for (int i = 0; i < (int)strArrays.Length; i++)
                            {
                                if (num85 != new decimal(0))
                                {
                                    decimal num87 = (num84 * num85) / new decimal(100);
                                    decimal num88 = num87 * Convert.ToDecimal(strArrays[i]);
                                    num80 = num80 + (num88 * num8);
                                }
                                if (num86 != new decimal(0) && Convert.ToBoolean(dataRow["IsdecimalSided"]))
                                {
                                    decimal num89 = (num84 * num86) / new decimal(100);
                                    decimal num90 = num89 * Convert.ToDecimal(strArrays[i]);
                                    num80 = num80 + (num90 * num8);
                                }
                            }
                            num79 = (num80 * num78) / new decimal(100);
                            num81 = num80 + this.ReturnExact2Decimal(num79);
                            num81 = this.ReturnExact2Decimal(num81);
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num2, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", num8, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;'> "));
                        string str12 = "onblur=javascript:MarkupOnBlur(this,this.value);";
                        markupIdList = new object[] { "<input id='txtMarkUp_", this.EstimateItemID, "_", num3, "' ", str12, " value='", num78.ToString(), "' class='textboxnew' style='width:50px;'  maxlength='8' /> " };
                        string str13 = string.Concat(markupIdList);
                        this.plhItemCostView.Controls.Add(new LiteralControl(str13));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        ControlCollection controls6 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", this.EstimateItemID, "_", num3, "' style='display:none;'>", num80, "</span>" };
                        controls6.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections6 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span class='normaltext' id='spnSellingPrice_", this.EstimateItemID, "_", num3, "'>", num81.ToString("C"), "</span>" };
                        controlCollections6.Add(new LiteralControl(string.Concat(markupIdList)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                        this.hdn_Markup.Value = num78.ToString();
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                }
            }
        }
    }
}