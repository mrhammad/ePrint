using MathFunctions;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_cost_view : UsercontrolBasePage
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

        public string PaperMeasure = string.Empty;

        public string Metre = string.Empty;

        public long ParentEstimateItemID;

        private Global gloobj = new Global();

        public bool Do_Guillotine_New_Cal;

        public long EstimateLithoNcrItemID;

        private decimal Totalpaper_forpaper;

        private BasePage ObjPage = new BasePage();

        public string QType = "0";

        private decimal MinimumCostMarkup;

        private decimal CostexMarkup_forsummary;

        private decimal TempMarkUp;

        private int isidecount;

        private int id;

        private string sectionpartcount = string.Empty;

        public string ProfitTaxKey = string.Empty;

        public bool UnitOfMeasureKey;

        public bool ZonePressCalType;

        public decimal ProductBasePrice;

        public decimal ProductBasePrice1;

        public decimal ProductBasePrice2;

        public decimal ProductBasePrice3;

        public decimal ProductBasePrice4;

        public decimal ProdBasePriceIncMarkup;

        public decimal ProdBasePriceIncMarkup1;

        public decimal ProdBasePriceIncMarkup2;

        public decimal ProdBasePriceIncMarkup3;

        public decimal ProdBasePriceIncMarkup4;

        public string get_urlofparentpage = string.Empty;

        public languageClass objLanguage = new languageClass();

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

        public item_cost_view()
        {
        }

        protected void Generate_Price_Catalogue_Items()
        {
            string empty = string.Empty;
            empty = (new BasePage()).GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.lblCostViewTitle.Text = "Product Catalogue View";
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
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            int num4 = 0;
            int num5 = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (num4 == 0)
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='bglabel' style='width:150px'><span class='Headertext' >", this.objLanguage.GetLanguageConversion("Item_Name"), "</span></div>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box' style='padding-top:7px;><span class='normaltext'>", this.objBase.SpecialDecode(dataRow["ItemTitle"].ToString()), "</span></div>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left' style='height:auto;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <table cellpadding=0 cellspacing=0 width='100%' Border='0px' style='float:left'><tr>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <td style='width:151px;overflow: hidden;background-color: #EEE;padding: 5px;margin: 0px 0px 2px;font-size: 11px;'><div  style='width:150px'><span class='Headertext' >", this.objLanguage.GetLanguageConversion("Item_Description"), "</span></div></td>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <td width='90%'><div style='margin-left:2px;'><span class='normaltext'>", this.objBase.SpecialDecode(dataRow["Description"].ToString()), "</span></div></td>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </tr></table>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left' style='padding-top:2px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='bglabel' style='width:150px;margin-top: 2px;'><span class='Headertext' >", this.objLanguage.GetLanguageConversion("Item_Code"), "</span></div>")));
                    //this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box' style='padding-top:7px;'><span class='normaltext'>", this.objBase.SpecialDecode(dataRow["ItemCode"].ToString()), "</span></div>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<a href=",this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=",dataRow["PriceCatalogueID"], " target=_blank>","<div class='box' style='padding-top:7px;'><span class='normaltext'>", this.objBase.SpecialDecode(dataRow["ItemCode"].ToString()), "</span></div><a>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:11.3%;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    if (dataRow["MatrixType"].ToString().ToLower().Trim() == "g")
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        ControlCollection controls = this.plhItemCostView.Controls;
                        string[] languageConversion = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Width"), " (", empty, ")</span>" };
                        controls.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        ControlCollection controlCollections = this.plhItemCostView.Controls;
                        string[] strArrays = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Height"), " (", empty, ")</span>" };
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                    ControlCollection controls1 = this.plhItemCostView.Controls;
                    string[] languageConversion1 = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Cost_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion1)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;text-align:right;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    if (this.UnitOfMeasureKey)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:22%;text-align:right;border: 0px solid red'> "));
                        ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                        string[] strArrays1 = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Price_Per_Unit_Of_Measure"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" </br><span class='smallgraytext'>", this.objLanguage.GetLanguageConversion("incl_Markup"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:21%;text-align:right;'> "));
                    ControlCollection controls2 = this.plhItemCostView.Controls;
                    string[] languageConversion2 = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Cost_Price_Incl_Markup"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                    controls2.Add(new LiteralControl(string.Concat(languageConversion2)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                }
                decimal num6 = Convert.ToDecimal(dataRow["Price"]);
                if (num4 == 0)
                {
                    num = Convert.ToDecimal(dataRow["Quantity"].ToString());
                    this.ProductBasePrice1 = num6;
                    if (num != new decimal(0) || Convert.ToString(num) != "select" || Convert.ToString(num) != "")
                    {
                        num5 = 1;
                    }
                }
                if (num4 == 1)
                {
                    num1 = Convert.ToDecimal(dataRow["Quantity"].ToString());
                    this.ProductBasePrice2 = num6;
                    if (num1 != new decimal(0) || Convert.ToString(num1) != "select" || Convert.ToString(num1) != "")
                    {
                        num5 = 2;
                    }
                }
                if (num4 == 2)
                {
                    num2 = Convert.ToDecimal(dataRow["Quantity"].ToString());
                    this.ProductBasePrice3 = num6;
                    if (num2 != new decimal(0) || Convert.ToString(num2) != "select" || Convert.ToString(num2) != "")
                    {
                        num5 = 3;
                    }
                }
                if (num4 == 3)
                {
                    num3 = Convert.ToDecimal(dataRow["Quantity"].ToString());
                    this.ProductBasePrice4 = num6;
                    if (num3 != new decimal(0) || Convert.ToString(num3) != "select" || Convert.ToString(num3) != "")
                    {
                        num5 = 4;
                    }
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;border:0px solid red'> "));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50%;text-align:right;border:0px solid red'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Quantity"].ToString()), 0, "", true, false, true), "</span>")));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp;</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                if (dataRow["MatrixType"].ToString().ToLower().Trim() == "g")
                {
                    string str = "width:80%;";
                    string str1 = "width:82%;";
                    if (empty.ToLower().Trim() != "in.")
                    {
                        str = "width:90%;";
                        str1 = "width:95%;";
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;", str, "text-align:right;border:0px solid red'>")));
                    ControlCollection controlCollections2 = this.plhItemCostView.Controls;
                    object[] objArray = new object[] { " <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Width"]), 0, "", false, false, true), "</span><span id='spnWidth_", num4, "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Width"]), 3, "", false, false, true), "</span>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;", str1, "text-align:right;border:0px solid red'>")));
                    ControlCollection controls3 = this.plhItemCostView.Controls;
                    object[] objArray1 = new object[] { " <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Height"]), 0, "", false, false, true), "</span><span id='spnHeight_", num4, "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Height"]), 3, "", false, false, true), "</span>" };
                    controls3.Add(new LiteralControl(string.Concat(objArray1)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                ControlCollection controlCollections3 = this.plhItemCostView.Controls;
                decimal num8 = Convert.ToDecimal(dataRow["Markup"]);
                //object[] objArray2 = new object[] { " <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num6.ToString()), 0, "", false, false, true), "</span><span id='spnPriceExMarkup_", num4, "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Price"]), 3, "", false, false, true), "</span>" };
                string strPrice = string.Concat("onblur=javascript:CataloguePriceOnBlur(this,", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num8), 0, "", false, false, true),",", num4, ");");
                object[] objArray2 = new object[] { " <input id='txtCostPrice_",num4,"'",strPrice," value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num6.ToString()), 0, "", false, false, true), "' class='textboxnew' style='width:50px;text-align: right'  maxlength='20' /><span id='spnPriceExMarkup_", num4, "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Price"]), 3, "", false, false, true), "</span>" };
                controlCollections3.Add(new LiteralControl(string.Concat(objArray2)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                long num7 = Convert.ToInt64(dataRow["EstPriceCatalogueID"]);
                //decimal num8 = Convert.ToDecimal(dataRow["Markup"]);
                string str2 = string.Concat("onblur=javascript:CatalogueMarkupOnBlur(this,", num4, ");");
                object[] objArray3 = new object[] { "<input id='txtMarkUp_", num4, "' ", str2, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num8), 6, "", false, false, true), "' class='textboxnew' style='width:68px;text-align: right'  maxlength='20' /> " };
                string str3 = string.Concat(objArray3);
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;text-align:right;'> "));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" ", str3)));
                ControlCollection controls4 = this.plhItemCostView.Controls;
                object[] objArray4 = new object[] { " <span id='spn_id_", num4, "' style='display:none;'>", num7, "</span>" };
                controls4.Add(new LiteralControl(string.Concat(objArray4)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                decimal num9 = (num8 * num6) / new decimal(100);
                decimal num10 = num6 + num9;
                if (num4 == 0)
                {
                    this.ProdBasePriceIncMarkup1 = num10;
                }
                if (num4 == 1)
                {
                    this.ProdBasePriceIncMarkup2 = num10;
                }
                if (num4 == 2)
                {
                    this.ProdBasePriceIncMarkup3 = num10;
                }
                if (num4 == 3)
                {
                    this.ProdBasePriceIncMarkup4 = num10;
                }
                if (this.UnitOfMeasureKey)
                {
                    string str4 = SummaryClass.ReturnPricePerQty(this.CompanyID, this.UserID, Convert.ToInt32(dataRow["Quantity"]), Convert.ToDouble(num10), Convert.ToInt32(dataRow["UnitOfMeasure"]), false);
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:22%;text-align:right;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", str4, "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;text-align:right;width:21%;' > "));
                ControlCollection controlCollections4 = this.plhItemCostView.Controls;
                object[] objArray5 = new object[] { "<span class='normaltext' id='spnSellingInMarkup_", num4, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num10.ToString()), 0, "", false, false, true), "</span>" };
                controlCollections4.Add(new LiteralControl(string.Concat(objArray5)));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;text-align:right;width:3%;'> "));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                num4++;
            }
            for (int i = 1; i <= num5; i++)
            {
                DataTable dataTable1 = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(this.EstimateItemID);
                int num11 = 0;
                string empty1 = string.Empty;
                decimal num12 = new decimal(0);
                string empty2 = string.Empty;
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                decimal num16 = new decimal(0);
                decimal num17 = new decimal(0);
                if (dataTable1.Rows.Count >= 1)
                {
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        num11++;
                        empty1 = row1["EstimateOtherCostName"].ToString();
                        empty2 = row1["SelectedValue"].ToString();
                        if (i != 1 || this.QtyNo == 0)
                        {
                            num12 = Convert.ToDecimal(row1[string.Concat("SelectedPrice", i)]);
                            num13 = Convert.ToDecimal(row1[string.Concat("MarkupValue", i)]);
                            num14 = Convert.ToDecimal(row1[string.Concat("CostPriceInMarkup", i)]);
                            num15 = Convert.ToDecimal(row1[string.Concat("TotalPriceIncMarkup", i)]);
                            num16 = Convert.ToDecimal(row1[string.Concat("SelPriceTotalExMarkup", i)]);
                            num17 = Convert.ToDecimal(row1[string.Concat("TotalMarkupValue", i)]);
                        }
                        else
                        {
                            num12 = Convert.ToDecimal(row1[string.Concat("SelectedPrice", this.QtyNo)]);
                            num13 = Convert.ToDecimal(row1[string.Concat("MarkupValue", this.QtyNo)]);
                            num14 = Convert.ToDecimal(row1[string.Concat("CostPriceInMarkup", this.QtyNo)]);
                            num15 = Convert.ToDecimal(row1[string.Concat("TotalPriceIncMarkup", this.QtyNo)]);
                            num16 = Convert.ToDecimal(row1[string.Concat("SelPriceTotalExMarkup", this.QtyNo)]);
                            num17 = Convert.ToDecimal(row1[string.Concat("TotalMarkupValue", this.QtyNo)]);
                        }
                        if (!(num16 != new decimal(0)) || dataTable1.Rows.Count < 1)
                        {
                            continue;
                        }
                        if (num11 == 1 && i == 1)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div id='div_PCAdditionalOptions' runat='server' style='float:left;width:50%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='bglabel'><b>Additional Options</b></span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div style='border: 1px solid lightgray; padding-left: 10px; width:90%;'></div> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity </span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Option Name / Selected Value</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Cost Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Mark Up (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%; text-align:right;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Cost Price (incl. Markup) (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div style='border: 1px solid lightgray; padding-left: 10px; width:90%;'></div> "));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%; text-align:Center;'> "));
                        if (num11 != 1)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                        }
                        else
                        {
                            if (i == 1)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", num, "</span>")));
                            }
                            if (i == 2)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", num1, "</span>")));
                            }
                            if (i == 3)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", num2, "</span>")));
                            }
                            if (i == 4)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", num3, "</span>")));
                            }
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%; '> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.objBase.SpecialDecode(empty1), "</span>")));
                        if (empty2 == "")
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normaltext'><br />&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<br /><br /><span class='normaltext'><i>", empty2, "</i></span>")));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                        if (!(row1["ParentWebOtherCostID"].ToString() == "0") || !(row1["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num12), 0, "", false, false, true), "</span>")));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span style='display:none;' class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(0), 0, "", false, false, true), "</span>")));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                        if (!(row1["ParentWebOtherCostID"].ToString() == "0") || !(row1["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num13), 0, "", false, false, true), "</span>")));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span style='display:none;' class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(0), 0, "", false, false, true), "</span>")));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%; text-align:right;'> "));
                        if (!(row1["ParentWebOtherCostID"].ToString() == "0") || !(row1["WebOtherCostType"].ToString().ToLower().Trim() == "maingroup"))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num14), 0, "", false, false, true), "</span>")));
                        }
                        else
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span style='display:none;' class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(0), 0, "", false, false, true), "</span>")));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        if (num11 != dataTable1.Rows.Count)
                        {
                            continue;
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div style='border: 1px solid lightgray; padding-left: 10px; width:90%;'></div> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Option Total </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normaltext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num16), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num17), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%; text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num15), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        if (i == 1)
                        {
                            this.ProductBasePrice = this.ProductBasePrice1;
                            this.ProdBasePriceIncMarkup = this.ProdBasePriceIncMarkup1;
                        }
                        if (i == 2)
                        {
                            this.ProductBasePrice = this.ProductBasePrice2;
                            this.ProdBasePriceIncMarkup = this.ProdBasePriceIncMarkup2;
                        }
                        if (i == 3)
                        {
                            this.ProductBasePrice = this.ProductBasePrice3;
                            this.ProdBasePriceIncMarkup = this.ProdBasePriceIncMarkup3;
                        }
                        if (i == 4)
                        {
                            this.ProductBasePrice = this.ProductBasePrice4;
                            this.ProdBasePriceIncMarkup = this.ProdBasePriceIncMarkup4;
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:35%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Option Total + Product Total </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num16) + Convert.ToDecimal(this.ProductBasePrice), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%; text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normaltext'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%; text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num15) + Convert.ToDecimal(this.ProdBasePriceIncMarkup), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div style='border: 1px solid lightgray; padding-left: 10px; width:90%;'></div> "));
                    }
                }
            }
        }

        protected void Generate_Price_Catalogue_Sub_Items()
        {
            string[] strArrays;
            string empty = string.Empty;
            long num = (long)0;
            this.lblCostViewTitle.Text = "Product Catalogue View";
            this.ItemFrom = "IC";
            this.para = base.Request.Params["item"].ToString();
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
            this.EstType = base.Request.Params["EstType"].ToString();
            num = (base.Request.Params["TypeID"] != null ? Convert.ToInt64(base.Request.Params["TypeID"]) : (long)0);
            DataTable dataTable = new DataTable();
            dataTable = EstimatesBasePage.estimate_quantity_forcostview_select(this.CompanyID, this.EstimateItemID, this.EstType);
            int num1 = 0;
            DataTable dataTable1 = new DataTable();
            foreach (DataRow row in dataTable.Rows)
            {
                if (this.module == "job" || this.module.ToLower() == "invoice")
                {
                    foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    }
                    foreach (DataRow row1 in JobsBasePage.job_qty_select_by_qtynumber(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        empty = string.Concat(row1["QuantityID"].ToString(), "»", row1["Quantity"].ToString());
                    }
                    strArrays = empty.Split(new char[] { '±' });
                    dataTable1 = JobBasePage.price_catalogue_select_by_estimateitem_id_qtynumber(this.CompanyID, num, this.QtyNo);
                }
                else
                {
                    string str = row["Qty"].ToString();
                    str = str.Remove(str.Length - 1, 1);
                    strArrays = str.Split(new char[] { '±' });
                    dataTable1 = EstimatesBasePage.price_catalogue_select_by_estimateitem_id_new(this.CompanyID, num);
                }
                int num2 = 0;
                foreach (DataRow dataRow1 in dataTable1.Rows)
                {
                    if (num1 >= (int)strArrays.Length)
                    {
                        continue;
                    }
                    if (num2 == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='bglabel' style='width:150px;'><span class='Headertext' >", this.objLanguage.GetLanguageConversion("Item_Name"), "</span></div>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='normaltext'>", this.objBase.SpecialDecode(dataRow1["ItemTitle"].ToString()), "</span></div>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                        ControlCollection controls = this.plhItemCostView.Controls;
                        string[] languageConversion = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Cost_PRice"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                        controls.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;text-align:center;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_up"), " (%)</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        if (this.UnitOfMeasureKey)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:22%;text-align:right;border: 0px solid red'> "));
                            ControlCollection controlCollections = this.plhItemCostView.Controls;
                            string[] languageConversion1 = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Price_Per_Unit_Of_Measure"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                            controlCollections.Add(new LiteralControl(string.Concat(languageConversion1)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" </br><span class='smallgraytext'>", this.objLanguage.GetLanguageConversion("incl_Markup"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:23%;text-align:right;'> "));
                        ControlCollection controls1 = this.plhItemCostView.Controls;
                        string[] strArrays1 = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Cost_Price_incl_Markup"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                        controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                    }
                    decimal num3 = Convert.ToDecimal(dataRow1["Price"]);
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;border:0px solid red'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:35%;text-align:right;border:0px solid red'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Quantity"].ToString()), 0, "", true, false, true), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp;</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;text-align:right;'> "));
                    ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                    object[] objArray = new object[] { " <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num3.ToString()), 0, "", false, false, true), "</span><span id='spnPriceExMarkup_", num2, "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Price"].ToString()), 3, "", false, false, true), "</span>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(objArray)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    long num4 = Convert.ToInt64(dataRow1["EstPriceCatalogueID"]);
                    decimal num5 = Convert.ToDecimal(dataRow1["Markup"]);
                    object[] length = new object[] { "onblur=javascript:ItemCatalogueMarkupOnBlur(this,", num2, ",", (int)strArrays.Length, ");" };
                    string str1 = string.Concat(length);
                    //ticket 105304
                    object[] objArray1 = new object[] { "<input id='txtMarkUp_", num2, "' ", str1, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num5), 6, "", false, false, true), "' class='textboxnew' style='width:68px;text-align: right'  maxlength='20' /> " };
                    string str2 = string.Concat(objArray1);
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;text-align:center;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" ", str2)));
                    ControlCollection controls2 = this.plhItemCostView.Controls;
                    object[] objArray2 = new object[] { " <span id='spn_id_", num2, "' style='display:none;'>", num4, "</span>" };
                    controls2.Add(new LiteralControl(string.Concat(objArray2)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    decimal num6 = (num5 * num3) / new decimal(100);
                    decimal num7 = num3 + num6;
                    if (this.UnitOfMeasureKey)
                    {
                        string str3 = SummaryClass.ReturnPricePerQty(this.CompanyID, this.UserID, Convert.ToInt32(dataRow1["Quantity"]), Convert.ToDouble(num7), Convert.ToInt32(dataRow1["UnitOfMeasure"]), false);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;text-align:right;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", str3, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;text-align:right;width:23%;' > "));
                    ControlCollection controlCollections2 = this.plhItemCostView.Controls;
                    object[] objArray3 = new object[] { "<span class='normaltext' id='spnSellingInMarkup_", num2, "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num7.ToString()), 0, "", false, false, true), "</span>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(objArray3)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;text-align:right;width:3%;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                    num2++;
                    num1++;
                    this.hdn_PriceSubCnt.Value = num1.ToString();
                }
            }
        }

        public decimal getInkMatrixValuein_inkpopups(decimal InkID, string InkType, int Quantity, DataTable dtQty, decimal InkCoverageSide1, decimal InkCostExMarkup, out decimal InkSetupCost)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            long num3 = Convert.ToInt64(InkID);
            decimal inkCoverageSide1 = InkCoverageSide1 / new decimal(100);
            string empty = string.Empty;
            try
            {
                empty = EstimatesBasePage.inkMatrixGetValues(Convert.ToInt32(Quantity), this.CompanyID, num3);
            }
            catch
            {
            }
            foreach (DataRow row in EstimatesBasePage.select_InventoryInkMatrixDetails_inkCal(this.CompanyID, num3, empty).Rows)
            {
                num = Convert.ToDecimal(row["ChargableSheets"]);
                num1 = Convert.ToDecimal(row["ChargableCost"]);
                num2 = Convert.ToDecimal(row["SetUpCost"]);
            }
            if (num == new decimal(0))
            {
                InkCostExMarkup = new decimal(0);
            }
            else
            {
                InkCostExMarkup = Convert.ToDecimal((num1 / num) * Quantity);
            }
            InkSetupCost = num2;
            return InkCostExMarkup;
        }

        protected void LiPlateGenerate()
        {
            this.lblCostViewTitle.Text = "Plate Cost View";
            DataTable dataTable = new DataTable();
            DataColumn dataColumn = new DataColumn("Quantity", typeof(int));
            dataTable.Columns.Add(dataColumn);
            DataColumn dataColumn1 = new DataColumn("QuantityID", typeof(int));
            dataTable.Columns.Add(dataColumn1);
            string empty = string.Empty;
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            DataTable dataTable1 = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, (long)0);
            foreach (DataRow row in dataTable1.Rows)
            {
                num = Convert.ToInt32(row["Qty1"]);
                num1 = Convert.ToInt32(row["Qty2"]);
                num2 = Convert.ToInt32(row["Qty3"]);
                num3 = Convert.ToInt32(row["Qty4"]);
                if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
                {
                    foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                    {
                        this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    }
                    if (this.QtyNo == 1)
                    {
                        num1 = 0;
                        num2 = 0;
                        num3 = 0;
                    }
                    else if (this.QtyNo == 2)
                    {
                        num = 0;
                        num2 = 0;
                        num3 = 0;
                    }
                    else if (this.QtyNo == 3)
                    {
                        num = 0;
                        num1 = 0;
                        num3 = 0;
                    }
                    else if (this.QtyNo == 4)
                    {
                        num = 0;
                        num1 = 0;
                        num2 = 0;
                    }
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (num != 0)
                    {
                        DataRow str = null;
                        str = dataTable.NewRow();
                        str["Quantity"] = num.ToString();
                        str["QuantityID"] = row["QuantityID"].ToString();
                        dataTable.Rows.Add(str);
                    }
                    if (num1 != 0)
                    {
                        DataRow str1 = null;
                        str1 = dataTable.NewRow();
                        str1["Quantity"] = num1.ToString();
                        str1["QuantityID"] = row["QuantityID"].ToString();
                        dataTable.Rows.Add(str1);
                    }
                    if (num2 != 0)
                    {
                        DataRow dataRow1 = null;
                        dataRow1 = dataTable.NewRow();
                        dataRow1["Quantity"] = num2.ToString();
                        dataRow1["QuantityID"] = row["QuantityID"].ToString();
                        dataTable.Rows.Add(dataRow1);
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    DataRow str2 = null;
                    str2 = dataTable.NewRow();
                    str2["Quantity"] = num3.ToString();
                    str2["QuantityID"] = row["QuantityID"].ToString();
                    dataTable.Rows.Add(str2);
                }
                else
                {
                    if (num != 0)
                    {
                        DataRow dataRow2 = null;
                        dataRow2 = dataTable.NewRow();
                        dataRow2["Quantity"] = num.ToString();
                        dataRow2["QuantityID"] = row["QuantityID"].ToString();
                        dataTable.Rows.Add(dataRow2);
                    }
                    if (num1 != 0)
                    {
                        DataRow str3 = null;
                        str3 = dataTable.NewRow();
                        str3["Quantity"] = num1.ToString();
                        str3["QuantityID"] = row["QuantityID"].ToString();
                        dataTable.Rows.Add(str3);
                    }
                    if (num2 != 0)
                    {
                        DataRow dataRow3 = null;
                        dataRow3 = dataTable.NewRow();
                        dataRow3["Quantity"] = num2.ToString();
                        dataRow3["QuantityID"] = row["QuantityID"].ToString();
                        dataTable.Rows.Add(dataRow3);
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    DataRow str4 = null;
                    str4 = dataTable.NewRow();
                    str4["Quantity"] = num3.ToString();
                    str4["QuantityID"] = row["QuantityID"].ToString();
                    dataTable.Rows.Add(str4);
                }
            }
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            empty1 = "20%";
            empty2 = "20%";
            empty3 = "15%";
            empty4 = "5%";
            empty5 = "20%";
            str5 = "15%";
            string empty6 = string.Empty;
            string str6 = "align='center'";
            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty1, ";'> ")));
            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Plate Name</span>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty2, ";'> ")));
            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity</span>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            ControlCollection controls = this.plhItemCostView.Controls;
            string[] strArrays = new string[] { " <div ", str6, "style='float:left;text-align:right;width:", empty3, ";'> " };
            controls.Add(new LiteralControl(string.Concat(strArrays)));
            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Unit Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty4, ";'>&nbsp;</div>")));
            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty5, ";'> ")));
            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            ControlCollection controlCollections = this.plhItemCostView.Controls;
            string[] strArrays1 = new string[] { " <div ", str6, " style='float:left;text-align:right;;width:", str5, ";' nowrap='nowrap'> " };
            controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("<div style='float:left;width:5%;'>&nbsp;</div>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            DataTable dataTable2 = new DataTable();
            if (string.Compare(this.EstType, "f", true) == 0)
            {
                dataTable2 = EstimatesBasePage.estimate_litho_plate_select_popup(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.EstType, "D", true) == 0)
            {
                dataTable2 = EstimatesBasePage.estimate_lithoPad_plate_select_popup(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.EstType, "N", true) == 0)
            {
                dataTable2 = EstimatesBasePage.estimate_lithoNCR_select_popup(this.CompanyID, this.EstimateItemID, this.EstimateLithoNcrItemID);
            }
            else if (string.Compare(this.EstType, "R", true) == 0)
            {
                dataTable2 = EstimatesBasePage.estimate_lithoNCR_select_popup(this.CompanyID, this.EstimateItemID, this.EstimateLithoNcrItemID);
            }
            else if (string.Compare(this.EstType, "K", true) == 0)
            {
                dataTable2 = EstimatesBasePage.estimate_lithobooklet_plateswashupmakeready_popup(this.CompanyID, this.EstimateItemID, this.TypeID);
            }
            foreach (DataRow row1 in dataTable2.Rows)
            {
                decimal num4 = new decimal(0);
                if (this.ProfitTaxKey.ToLower() == "database")
                {
                    num4 = Convert.ToDecimal(row1["PlateMarkup"]);
                }
                empty = (row1["Noofplates"].ToString() == "" ? "0" : row1["Noofplates"].ToString());
                this.plhItemCostView.Controls.Add(new LiteralControl("<div style='clear:both'></div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;width:", empty1, ";'> ")));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", row1["PlateName"].ToString(), "</span>")));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;width:", empty2, ";'> ")));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                if (string.Compare(this.EstType, "N", true) != 0 || !(row1["NcrImageType"].ToString() == "common"))
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(empty), 0, "", true, false, true), "</span>")));
                }
                else
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normaltext'>--</span>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp;</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                ControlCollection controls1 = this.plhItemCostView.Controls;
                string[] strArrays2 = new string[] { "<div ", str6, " style='float:left;text-align:right;width:", empty3, ";'> " };
                controls1.Add(new LiteralControl(string.Concat(strArrays2)));
                if (string.Compare(this.EstType, "N", true) != 0 || !(row1["NcrImageType"].ToString() == "common"))
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["PlateUnitPrice"].ToString()), 0, "", false, false, true), "</span>")));
                }
                else
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normaltext'>--</span>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<div style='float:left;width:", empty4, ";'>&nbsp;</div>")));
                this.hdn_LithoMarkup.Value = Convert.ToString(num4);
                decimal num5 = new decimal(0);
                num5 = Convert.ToDecimal(empty) * Convert.ToDecimal(row1["PlateUnitPrice"]);
                decimal num6 = (num5 * num4) / new decimal(100);
                decimal num7 = num5 + num6;
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;width:", empty5, ";'> ")));
                string str7 = "onblur=AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_plates(this);";
                if (string.Compare(this.EstType, "N", true) != 0 || !(row1["NcrImageType"].ToString() == "common"))
                {
                    string[] strArrays3 = new string[] { "<input id='txtMarkUp_Plate' value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num4), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;' tabindex='0'  maxlength='15'  ", str7, "  > " };
                    string str8 = string.Concat(strArrays3);
                    this.plhItemCostView.Controls.Add(new LiteralControl(str8));
                }
                else
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='right' style='width:36%'>--</div>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span id='spn_Cost_Plate' style='display:none;'>", num5, "</span>")));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                string[] strArrays4 = new string[] { " <div ", str6, " style='float:left;text-align:right;width:", str5, ";' nowrap='nowrap'> " };
                controlCollections1.Add(new LiteralControl(string.Concat(strArrays4)));
                if (string.Compare(this.EstType, "N", true) != 0 || !(row1["NcrImageType"].ToString() == "common"))
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span id='spnSell_Plate' + class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num7.ToString()), 0, "", false, false, true), "</span>")));
                }
                else
                {
                    this.plhItemCostView.Controls.Add(new LiteralControl("<span id='spnSell_Plate' + class='normaltext'>--</span>"));
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("<div style='float:left;width:5%;'>&nbsp;</div>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            }
        }

        protected void lnkbtnSaveItemView_OnClick(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] estimateItemID;
            if (base.Request.Params["From"] != null && string.Compare(base.Request.Params["From"].ToString(), "li", true) == 0)
            {
                this.para = base.Request.Params["item"].ToString();
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                this.EstType = base.Request.Params["EstType"].ToString();
                string empty = string.Empty;
                empty = base.Request.Params["item"].ToString();
                EstimatesBasePage.estimates_litho_markup_calculation_update(this.CompanyID, this.EstimateItemID, Convert.ToDecimal(this.hdn_LithoMarkup.Value), empty, this.TypeID, this.EstType);
            }
            if (string.Compare(this.ItemFrom, "SPL", true) == 0)
            {
                string str = string.Empty;
                string empty1 = string.Empty;
                string value = this.hdn_SaveItemViewMarkup.Value;
                chrArray = new char[] { 'µ' };
                string[] strArrays = value.Split(chrArray);
                Convert.ToInt64(strArrays[1].ToString());
                Convert.ToDecimal(strArrays[2].ToString());
                strArrays[3].ToString();
                this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
            }
            else if (string.Compare(this.ItemFrom, "B", true) == 0)
            {
                string str1 = string.Empty;
                string[] strArrays1 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                Convert.ToInt64(strArrays1[1].ToString());
                Convert.ToDecimal(strArrays1[2].ToString());
                strArrays1[3].ToString();
            }
            else if (string.Compare(this.ItemFrom, "IW", true) == 0)
            {
                string[] strArrays2 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays2.Length; i++)
                {
                    if (strArrays2[i] != "")
                    {
                        string[] strArrays3 = strArrays2[i].Split(new char[] { '±' });
                        long num = (long)0;
                        decimal num1 = new decimal(0);
                        for (int j = 0; j < (int)strArrays3.Length; j++)
                        {
                            string[] strArrays4 = strArrays3[j].Split(new char[] { '«' });
                            if (strArrays4[0] == "EstItemWarehouseID")
                            {
                                num = Convert.ToInt64(strArrays4[1]);
                            }
                            else if (strArrays4[0] == "MarkUp")
                            {
                                num1 = Convert.ToDecimal(strArrays4[1]);
                                EstimatesBasePage.summary_sub_ware_markup_update(this.CompanyID, num, num1);
                            }
                        }
                    }
                }
            }
            else if (string.Compare(this.ItemFrom, "IU", true) == 0)
            {
                string[] strArrays5 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int k = 0; k < (int)strArrays5.Length; k++)
                {
                    if (strArrays5[k] != "")
                    {
                        string[] strArrays6 = strArrays5[k].Split(new char[] { '±' });
                        long num2 = (long)0;
                        decimal num3 = new decimal(0);
                        for (int l = 0; l < (int)strArrays6.Length; l++)
                        {
                            string[] strArrays7 = strArrays6[l].Split(new char[] { '«' });
                            if (strArrays7[0] == "EstOtherCostID")
                            {
                                num2 = Convert.ToInt64(strArrays7[1]);
                            }
                            else if (strArrays7[0] == "MarkUp")
                            {
                                num3 = Convert.ToDecimal(strArrays7[1]);
                                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num2, num3, "IU", new decimal(0));
                            }
                        }
                    }
                }
            }
            else if (string.Compare(this.ItemFrom, "IO", true) == 0)
            {
                string[] strArrays8 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int m = 0; m < (int)strArrays8.Length; m++)
                {
                    if (strArrays8[m] != "")
                    {
                        string[] strArrays9 = strArrays8[m].Split(new char[] { '±' });
                        long num4 = (long)0;
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        for (int n = 0; n < (int)strArrays9.Length; n++)
                        {
                            string[] strArrays10 = strArrays9[n].Split(new char[] { '«' });
                            if (strArrays10[0] == "EstItemOutworkSupplierID")
                            {
                                num4 = Convert.ToInt64(strArrays10[1]);
                            }
                            else if (strArrays10[0] == "MarkUp")
                            {
                                num5 = Convert.ToDecimal(strArrays10[1]);
                            }
                            else if (strArrays10[0] == "TotalPrice")
                            {
                                num6 = Convert.ToDecimal(strArrays10[1]);
                                EstimatesBasePage.sub_item_outwork_markup_update(this.CompanyID, num4, num5, num6);
                            }
                        }
                    }
                }
            }
            else if (string.Compare(this.ItemFrom, "W", true) == 0)
            {
                string[] strArrays11 = this.hdn_SaveItemViewMarkup.Value.ToString().Split(new char[] { '»' });
                decimal num7 = Convert.ToDecimal(strArrays11[0]);
                long num8 = Convert.ToInt64(strArrays11[1]);

                decimal QtyMarkup2 = Convert.ToDecimal(this.hdn_MarkupValue2.Value);
                decimal QtyMarkup3 = Convert.ToDecimal(this.hdn_MarkupValue3.Value);
                decimal QtyMarkup4 = Convert.ToDecimal(this.hdn_MarkupValue4.Value);

                if(num7 > 0)
                {
                    EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num8, num7, "W", new decimal(0));
                }
                EstimateBasePage.Estimate_Summary_Item_OtherQuantities_Markup_Update(num8,QtyMarkup2,QtyMarkup3,QtyMarkup4);
            }
            else if (string.Compare(this.ItemFrom, "U", true) == 0)
            {
                string[] strArrays12 = this.hdn_SaveItemViewMarkup.Value.ToString().Split(new char[] { '»' });
                decimal num9 = Convert.ToDecimal(strArrays12[0]);
                long num10 = Convert.ToInt64(strArrays12[1]);
                EstimateBasePage.Estimate_Summary_Item_Markup_Update(this.CompanyID, num10, num9, "U", new decimal(0));
            }
            else if (string.Compare(this.ItemFrom, "C", true) == 0 || string.Compare(this.ItemFrom, "IC", true) == 0)
            {
                string[] strArrays13 = this.hdn_SaveItemViewMarkup.Value.Split(new char[] { 'µ' });
                for (int o = 0; o < (int)strArrays13.Length; o++)
                {
                    long num11 = (long)0;
                    decimal num12 = new decimal(0);
                    if (strArrays13[o] != "")
                    {
                        string[] strArrays14 = strArrays13[o].Split(new char[] { '±' });
                        for (int p = 0; p < (int)strArrays14.Length; p++)
                        {
                            string str2 = strArrays14[p];
                            chrArray = new char[] { '«' };
                            string[] strArrays15 = str2.Split(chrArray);
                            if (strArrays15[0] == "EstPriceCatalogueID")
                            {
                                num11 = Convert.ToInt64(strArrays15[1]);
                            }
                            else if (strArrays15[0] == "MarkUp")
                            {
                                num12 = Convert.ToDecimal(strArrays15[1]);
                                EstimateBasePage.price_catalogue_markup_update(this.CompanyID, num11, num12);
                            }
                            else if (strArrays15[0] == "Price")
                            {
                                num12 = Convert.ToDecimal(strArrays15[1]);
                                EstimateBasePage.price_catalogue_price_update(this.CompanyID, num11, num12);
                            }
                        }
                    }
                }
            }
            EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            string str3 = this.module;
            string str4 = this.module;
            if (this.module.Contains("job"))
            {
                str3 = string.Concat(this.module, "s");
            }
            if (this.module.Contains("estimate"))
            {
                str3 = string.Concat(this.module, "s");
            }
            long num13 = (long)0;
            string str5 = "";
            string empty2 = string.Empty;
            long num14 = (long)0;
            long num15 = (long)0;
            if (base.Request.Url.ToString().Contains("InvID") && base.Request.QueryString["InvID"] != "")
            {
                empty2 = string.Concat("&InvID=", base.Request.QueryString["InvID"].ToString());
                num15 = Convert.ToInt64(base.Request.QueryString["InvID"].ToString());
            }
            if (base.Request.Url.ToString().Contains("jID") && base.Request.QueryString["jID"] != "")
            {
                str5 = string.Concat("&jID=", base.Request.QueryString["jID"].ToString());
                num14 = Convert.ToInt64(base.Request.QueryString["jID"].ToString());
            }
            if (base.Request.Url.ToString().Contains("EstimateID") && base.Request.QueryString["EstimateID"] != "")
            {
                num13 = Convert.ToInt64(base.Request.QueryString["EstimateID"].ToString());
            }
            string empty3 = string.Empty;
            if (str3 == "invoice")
            {
                empty3 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(num15, str3);
            }
            else if (str3 == "jobs")
            {
                empty3 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(num14, str3);
            }
            if (str3.Contains("order"))
            {
                str3 = "orders";
                if (this.ParentEstimateItemID == (long)0)
                {
                    estimateItemID = new object[] { this.strSitepath, str3, "/", str4, "_summary.aspx?ordid=", num13, "&estid=", num13, "&EstItemID=", this.EstimateItemID, str5, empty2 };
                    this.get_urlofparentpage = string.Concat(estimateItemID);
                }
                else
                {
                    estimateItemID = new object[] { this.strSitepath, str3, "/", str4, "_summary.aspx?ordid=", num13, "&estid=", num13, "&EstItemID=", this.ParentEstimateItemID, str5, empty2 };
                    this.get_urlofparentpage = string.Concat(estimateItemID);
                }
            }
            else if (this.ParentEstimateItemID != (long)0)
            {
                if (empty3.ToString().ToLower() != "yes")
                {
                    estimateItemID = new object[] { this.strSitepath, str3, "/", str4, "_summary_reeng.aspx?estid=", num13, "&EstItemID=", this.ParentEstimateItemID, str5, empty2 };
                    this.get_urlofparentpage = string.Concat(estimateItemID);
                }
                else
                {
                    estimateItemID = new object[] { this.strSitepath, str3, "/", str4, "_order_summary.aspx?estid=", num13, "&ordid=", num13, "&EstItemID=", this.ParentEstimateItemID, str5, empty2 };
                    this.get_urlofparentpage = string.Concat(estimateItemID);
                }
            }
            else if (empty3.ToString().ToLower() != "yes")
            {
                estimateItemID = new object[] { this.strSitepath, str3, "/", str4, "_summary_reeng.aspx?estid=", num13, "&EstItemID=", this.EstimateItemID, str5, empty2 };
                this.get_urlofparentpage = string.Concat(estimateItemID);
            }
            else
            {
                estimateItemID = new object[] { this.strSitepath, str3, "/", str4, "_order_summary.aspx?estid=", num13, "&ordid=", num13, "&EstItemID=", this.EstimateItemID, str5, empty2 };
                this.get_urlofparentpage = string.Concat(estimateItemID);
            }
            this.plhItemCostView.Controls.Clear();
            this.pnlCallAfterUpdate.Visible = true;
        }

        protected void OtherCostSubItem()
        {
            char[] chrArray;
            object[] str;
            string[] currencyinRequiredFormate;
            decimal num;
            this.para = base.Request.Params["item"].ToString();
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
            this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
            this.EstType = base.Request.Params["EstType"].ToString();
            long num1 = Convert.ToInt64(base.Request.Params["EstOtherCostID"]);
            DataTable dataTable = new DataTable();
            int num2 = 0;
            if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
            {
                foreach (DataRow row in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.QtyNo = Convert.ToInt16(row["QtyNumber"].ToString());
                }
                foreach (DataRow dataRow in JobsBasePage.job_qty_select_by_qtynumber(this.CompanyID, this.EstimateItemID).Rows)
                {
                    Convert.ToInt32(dataRow["Quantity"].ToString());
                }
                dataTable = EstimatesBasePage.job_othercost_subitem_select(this.CompanyID, this.EstType, this.TypeID, num1, this.QtyNo - 1);
                if (dataTable.Rows.Count > 0)
                {
                    num2 = Convert.ToInt32(dataTable.Rows[0]["Quantitynumber"].ToString());
                }
            }
            else
            {
                dataTable = EstimateBasePage.OtherCost_SubItem_Select_By_EstOtherCostID(this.CompanyID, this.EstType, this.TypeID, num1);
            }
            int num3 = 1;
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            int num6 = 0;
            string empty = string.Empty;
            int num7 = 0;
            int num8 = 0;
            StringBuilder stringBuilder = new StringBuilder();
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            ArrayList arrayLists2 = new ArrayList();
            DataTable dataTable1 = EstimateBasePage.Estimate_Information_By_ID(this.CompanyID, this.EstType, this.TypeID);
            if (this.EstType != "B")
            {
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    if (this.EstType == "P" || this.EstType == "D")
                    {
                        num7 = Convert.ToInt32(row1["LeavesPerPad"]);
                    }
                    else if (this.EstType == "N" || this.EstType == "R")
                    {
                        num8 = Convert.ToInt32(row1["NCRSetsPerPad"]);
                    }
                    num4 = Convert.ToDecimal(row1["SetupSpoilage"]);
                    num5 = Convert.ToDecimal(row1["RunningSpoilage"]);
                    num6 = Convert.ToInt32(row1["PrintlayoutValue"]);
                }
            }
            else
            {
                foreach (DataRow dataRow1 in dataTable1.Rows)
                {
                    num4 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                    num5 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                    empty = dataRow1["NoOfSignatures"].ToString();
                    arrayLists.Add(dataRow1["SetupSpoilage"].ToString());
                    arrayLists1.Add(dataRow1["RunningSpoilage"].ToString());
                    arrayLists2.Add(dataRow1["NoOfSignatures"].ToString());
                }
            }
            foreach (DataRow row2 in dataTable.Rows)
            {
                int num9 = Convert.ToInt32(row2["Quantity"]);
                string str1 = row2["CalculationName"].ToString();
                string str2 = row2["CalculationType"].ToString();
                string str3 = row2["VariableDDLType"].ToString();
                string str4 = row2["VariableHrsQty"].ToString();
                string str5 = row2["MakeReadyTime"].ToString();
                Convert.ToDecimal(row2["Cost"]);
                Convert.ToDecimal(row2["Markup"]);
                decimal num10 = Convert.ToDecimal(row2["MinimumCost"]);
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = Convert.ToDecimal(row2["SetupTime"]);
                decimal num14 = Convert.ToDecimal(row2["HourlyRate"]);
                decimal num15 = new decimal(0);
                decimal num16 = Convert.ToDecimal(row2["UnitRate"]);
                decimal num17 = Convert.ToDecimal(row2["UnitRate1"]);
                decimal num18 = Convert.ToDecimal(row2["UnitRate2"]);
                decimal num19 = Convert.ToDecimal(row2["UnitRate3"]);
                decimal num20 = Convert.ToDecimal(row2["HoursOrQty"]);
                decimal num21 = new decimal(0);
                decimal num22 = Convert.ToDecimal(row2["Markup"]);
                decimal num23 = Convert.ToDecimal(row2["Markup1"]);
                decimal num24 = Convert.ToDecimal(row2["Markup2"]);
                decimal num25 = Convert.ToDecimal(row2["Markup3"]);
                decimal num26 = Convert.ToDecimal(row2["MinimumCost"]);
                decimal num27 = Convert.ToDecimal(row2["HourlyRunSpeed"]);
                decimal num28 = Convert.ToDecimal(row2["Passes"]);
                if (num2 == 0)
                {
                    num15 = num16;
                    num21 = num22;
                }
                else if (num2 == 1)
                {
                    num15 = num17;
                    num21 = num23;
                }
                else if (num2 == 2)
                {
                    num15 = num18;
                    num21 = num24;
                }
                else if (num2 == 3)
                {
                    num15 = num19;
                    num21 = num25;
                }
                decimal num29 = new decimal(0);
                if (row2["CalculationType"].ToString().ToLower() != "f")
                {
                    num29 = (num13 * num14) / new decimal(60);
                }
                num11 = Convert.ToDecimal(row2["Cost"]);
                num11 = num11 - num29;
                decimal num30 = (num11 * num21) / new decimal(100);
                decimal num31 = num29;
                num12 = this.comm.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num11, num21, num26, out this.CostexMarkup_forsummary, out this.MinimumCostMarkup, ref num31);
                decimal num32 = new decimal(0);
                num32 = (num11 + num29) + num30;
                if (num26 != new decimal(0) && num32 <= num26)
                {
                    num12 = num26;
                }
                decimal num33 = new decimal(0);
                decimal num34 = new decimal(0);
                if (this.EstType == "B")
                {
                    if (!string.IsNullOrEmpty(empty))
                    {
                        num34 = num9 * Convert.ToDecimal(empty);
                    }
                }
                else if (this.EstType == "P" || this.EstType == "D")
                {
                    if (num7 > 0)
                    {
                        num34 = (num9 * Convert.ToDecimal(num7)) / Convert.ToDecimal(num6);
                    }
                }
                else if (this.EstType != "N" || this.EstType != "R")
                {
                    num34 = (num6 != 0 ? num9 / num6 : 0);
                }
                else if (num8 > 0 && num6 > 0)
                {
                    num34 = (num9 * Convert.ToDecimal(num8)) / Convert.ToDecimal(num6);
                }
                num33 = Math.Ceiling(num34);
                decimal num35 = new decimal(0);
                decimal num36 = new decimal(0);
                decimal num37 = new decimal(0);
                decimal num38 = new decimal(0);
                if (str3 == "1")
                {
                    num33 = Math.Ceiling(num34);
                    num38 = num33;
                }
                else if (str3 == "2")
                {
                    num35 = (num33 * num5) / new decimal(100);
                    decimal num39 = new decimal(0);
                    if (this.EstType == "B")
                    {
                        num33 = (num33 + num4) + num35;
                    }
                    else if (this.EstType == "P" || this.EstType == "D")
                    {
                        num33 = EstimatesBasePage.PrintSheets_Calculation_For_PadItem(num9, num7, Convert.ToDecimal(num6), Convert.ToDecimal(num4), Convert.ToDecimal(num5), out num39);
                    }
                    else
                    {
                        num33 = (this.EstType != "N" ? EstimatesBasePage.PrintSheets_Calculation_For_SingleItem(num9, num6, num4, num5, out num39) : EstimateBasePage.PrintSheets_Calculation_For_SingleItemForNCR_new(num9, Convert.ToDecimal(num8), Convert.ToDecimal(num4), Convert.ToDecimal(num5), Convert.ToDecimal(num6), out num39));
                    }
                    num33 = Math.Ceiling(num33);
                    num38 = num33;
                }
                else if (str3 == "3")
                {
                    num38 = num9;
                }
                else if (str3 == "4")
                {
                    num37 = Math.Ceiling((num9 * num5) / new decimal(100));
                    num36 = (num9 + num37) + num4;
                    num38 = Math.Ceiling(num36);
                }
                if (num3 == 1)
                {
                    stringBuilder.Append("<div align='left' style='border:1px solid silver;width:64%;padding:5px;border-style:dashed;'>");
                    if (string.Compare(str2, "f", true) != 0)
                    {
                        stringBuilder.Append("<span><u><b>Work Instruction:</b></u></span>");
                        stringBuilder.Append("<div class='only5px'></div>");
                    }
                    if (string.Compare(str1, "v", true) == 0)
                    {
                        stringBuilder.Append(string.Concat("<div> Print Layout Value: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num6), 0, "", true, false, true), "</div>    "));
                    }
                    if (string.Compare(str2, "f", true) != 0)
                    {
                        try
                        {
                            stringBuilder.Append(string.Concat("<div> Make Ready Time: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str5), 0, "", false, false, true), " min</div>    "));
                        }
                        catch
                        {
                        }
                    }
                    if (num27 > new decimal(0) && string.Compare(str2, "t", true) == 0)
                    {
                        stringBuilder.Append(string.Concat("<div> Hourly Run Speed: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num27), 0, "", false, false, true), "</div>    "));
                        stringBuilder.Append(string.Concat("<div> Passes: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num28), 0, "", false, false, true), "</div>    "));
                    }
                    stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                    stringBuilder.Append("<div><span><u><b>Calculation:</b></u></span></div>    ");
                    stringBuilder.Append("<div class='only5px'></div>");
                    if (string.Compare(str2, "t", true) == 0)
                    {
                        if (str3 == "1")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (exl. Spoilage) / Hourly Run Speed)  x Per Hour Cost + Make Ready Cost + Mark up</div>");
                        }
                        else if (str3 == "2")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (inc. Spoilage) / Hourly Run Speed)  x Per Hour Cost + Make Ready Cost + Mark up</div>");
                        }
                        else if (str3 == "3")
                        {
                            stringBuilder.Append("<div> (Finished Item Qty  / Hourly Run Speed) x Per Hour Cost + Make Ready Cost + Mark up</div>");
                        }
                        else if (str3 != "4")
                        {
                            stringBuilder.Append("<div>(Hours x Per Hour Cost) + Make Ready Cost + Mark up</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div> (Finished Item Qty / Hourly Run Speed)  x Per Hour Cost + Make Ready Cost + Mark up</div>");
                        }
                    }
                    else if (string.Compare(str2, "q", true) != 0)
                    {
                        if (string.Compare(str2, "f", true) == 0 || string.Compare(str2, "m", true) == 0)
                        {
                            string str6 = row2["FormulaTag"].ToString();
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
                        stringBuilder.Append("<div>(Finished Item Qty  x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    else if (str3 != "4")
                    {
                        stringBuilder.Append("<div>(Quantity x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    else
                    {
                        stringBuilder.Append("<div>(Finished Item Qty  x Unit Rate) + Make Ready Cost + Mark up</div>");
                    }
                    stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                    stringBuilder.Append("<div><span><u><b>Actuals:</b></u></span></div>");
                    stringBuilder.Append("<div class='only5px'></div>");
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='bglabel' style='width:150px;'><span class='normaltext' >", this.objLanguage.GetLanguageConversion("Other_Cost_Name"), "</span></div>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div class='box'><span class='Headertext'>", this.objBase.SpecialDecode(row2["OtherCostName"].ToString()), "</span></div>")));
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
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Hourly Rate(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
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
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Hourly Rate(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
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
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Hourly Rate(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(row2["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (string.Compare(str1, "v", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Quantity </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:85px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Print Sheets </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:70px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hours </span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:110px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:85px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Per Hour Cost(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(row2["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Minimum Cost (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:150px;' nowrap='nowrap'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Qty 1 Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
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
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:45px;border:solid 0px red;text-align:right;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num20), 0, "", true, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str5), 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:70%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:89%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["HourlyRate"].ToString()), 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (string.Compare(str1, "v", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num9), 0, "", true, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str5), 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:70%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["HourlyRate"].ToString()), 0, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                    }
                    else if (string.Compare(str1, "f", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.ReturnExact2Decimal(num20), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str5), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:66%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["HourlyRate"].ToString()), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(row2["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num27), 0, "", false, false, true), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    else if (string.Compare(str1, "v", true) == 0)
                    {
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num9), 0, "", true, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", true, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:70px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:70%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>&nbsp;", this.ReturnExact2Decimal(num20), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:110px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str5), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:85px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num14), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        if (Convert.ToDecimal(row2["HourlyRunSpeed"]) != new decimal(0))
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num27), 0, "", false, false, true), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                    }
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:115px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:85%;text-align:right;border:0px solid'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num26.ToString()), 0, "", false, false, true), "</span>")));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.hidItemList.Value = string.Concat(this.hidItemList.Value, row2["EstOtherCostID"].ToString(), "±");
                    str = new object[] { "onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);ItemMarkupOnBlur(this.value,", row2["EstOtherCostID"].ToString(), ",", num10, ",", num29, ");" };
                    string str8 = string.Concat(str);
                    currencyinRequiredFormate = new string[] { "<input id='txtMarkUp_", row2["EstOtherCostID"].ToString(), "' ", str8, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num21), 0, "", false, false, false), "' class='textboxnew' style='width:50px;text-align:right'   maxlength='15' /> " };
                    string str9 = string.Concat(currencyinRequiredFormate);
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("&nbsp;&nbsp;", str9)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;Width:145px;border:solid 0px red' align='right'> "));
                    ControlCollection controls = this.plhItemCostView.Controls;
                    str = new object[] { " <span  id='spnPriceExMarkup_", row2["EstOtherCostID"].ToString(), "' style='display:none;'>", num11, "</span>" };
                    controls.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controlCollections = this.plhItemCostView.Controls;
                    currencyinRequiredFormate = new string[] { " <span class='normaltext' id='spnSellingPrice_", row2["EstOtherCostID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num12.ToString()), 0, "", false, false, true), "</span>" };
                    controlCollections.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                    num3++;
                }
                stringBuilder.Append(string.Concat("<div><b>Quantity:</b> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num9), 0, "", true, false, true), "</div>"));
                if (string.Compare(str2, "t", true) != 0)
                {
                    if (string.Compare(str2, "q", true) == 0)
                    {
                        if (str3 == "1")
                        {
                            stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (exl. Spoilage): ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Convert.ToDecimal(num38)), 0, "", true, false, true), "</div>    "));
                        }
                        else if (str3 == "2")
                        {
                            stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (inc. Spoilage): ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Convert.ToDecimal(num38)), 0, "", true, false, true), "</div>    "));
                        }
                        else if (str3 == "3")
                        {
                            stringBuilder.Append(string.Concat("<div> Finished Item Qty : ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Convert.ToDecimal(num38)), 0, "", true, false, true), "</div>    "));
                        }
                        else if (str3 == "4")
                        {
                            stringBuilder.Append(string.Concat("<div> Finished Item Qty : ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(Convert.ToDecimal(num38)), 0, "", true, false, true), "</div>    "));
                        }
                    }
                }
                else if (str3 == "1")
                {
                    stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (exl. Spoilage): ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", true, false, true), "</div>    "));
                }
                else if (str3 == "2")
                {
                    stringBuilder.Append(string.Concat("<div> No. Of Print Sheets Required (inc. Spoilage): ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", true, false, true), "</div>    "));
                }
                else if (str3 == "3")
                {
                    stringBuilder.Append(string.Concat("<div> Finished Item Qty: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", true, false, true), "</div>    "));
                }
                else if (str3 == "4")
                {
                    stringBuilder.Append(string.Concat("<div> Finished Item Qty: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", false, false, true), "</div>    "));
                }
                if (string.Compare(str2, "t", true) == 0)
                {
                    if (string.Compare(str1, "f", true) != 0)
                    {
                        currencyinRequiredFormate = new string[] { "<div>((", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", true, false, true), " / ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num27), 0, "", true, false, true), ") x ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num14), 0, "", false, false, true), ") + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num29), 0, "", false, false, true), " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num30), 0, "", false, false, true), " =  ", this.comm.GetCurrencyinRequiredFormate(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num32.ToString()), 0, "", false, false, true), true), "</div>" };
                        stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else
                    {
                        str = new object[] { "<div>(", this.ReturnExact2Decimal(Convert.ToDecimal(str4)), " x ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num14), 0, "", false, false, true), ") + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num29), 0, "", false, false, true), " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num30), 0, "", false, false, true), "=  ", this.comm.GetCurrencyinRequiredFormate(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num32.ToString()), 0, "", false, false, true), true), "</div>" };
                        stringBuilder.Append(string.Concat(str));
                    }
                }
                else if (string.Compare(str2, "q", true) == 0)
                {
                    if (string.Compare(str1, "f", true) != 0)
                    {
                        currencyinRequiredFormate = new string[] { "<div>(", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38), 0, "", true, false, true), " x ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num15), 0, "", false, false, true), ") + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num29), 0, "", false, false, true), " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num30), 0, "", false, false, true), "=  ", this.comm.GetCurrencyinRequiredFormate(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num32.ToString()), 0, "", false, false, true), true), "</div>" };
                        stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else
                    {
                        currencyinRequiredFormate = new string[] { "<div>(", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str4), 0, "", true, false, true), " x ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num15), 0, "", false, false, true), ") + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num29), 0, "", false, false, true), " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num30), 0, "", false, false, true), "=  ", this.comm.GetCurrencyinRequiredFormate(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num32.ToString()), 0, "", false, false, true), true), "</div>" };
                        stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                    }
                }
                else if (string.Compare(str2, "f", true) == 0 || string.Compare(str2, "m", true) == 0)
                {
                    string str10 = "0";
                    string empty1 = string.Empty;
                    string str11 = row2["FormulaWithActualValue"].ToString();
                    chrArray = new char[] { '±' };
                    str11.Split(chrArray);
                    if (num2 == 0)
                    {
                        string str12 = row2["FormulaTag"].ToString();
                        chrArray = new char[] { '\u00B6' };
                        str10 = str12.Split(chrArray)[0].ToString();
                    }
                    if (num2 == 1)
                    {
                        string str13 = row2["FormulaTag1"].ToString();
                        chrArray = new char[] { '\u00B6' };
                        str10 = str13.Split(chrArray)[0].ToString();
                    }
                    if (num2 == 2)
                    {
                        string str14 = row2["FormulaTag2"].ToString();
                        chrArray = new char[] { '\u00B6' };
                        str10 = str14.Split(chrArray)[0].ToString();
                    }
                    if (num2 == 3)
                    {
                        string str15 = row2["FormulaTag3"].ToString();
                        chrArray = new char[] { '\u00B6' };
                        str10 = str15.Split(chrArray)[0].ToString();
                    }
                    try
                    {
                        MathParser mathParser = new MathParser();
                        if (!Convert.ToBoolean(base.Session["ForOtherCostFormula"].ToString()))
                        {
                            num = mathParser.Calculate(str10);
                            num = Convert.ToDecimal(num.ToString());
                            empty1 = num.ToString();
                        }
                        else
                        {
                            num = mathParser.Calculate_ForOtherCostFormulCalculation(str10);
                            num = Convert.ToDecimal(num.ToString());
                            empty1 = num.ToString();
                        }
                        decimal num40 = Convert.ToDecimal(empty1) + num30;
                        str10 = string.Concat(str10, " + (", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num30.ToString()), 0, "", false, false, true), ")");
                        currencyinRequiredFormate = new string[] { "<div align='left'> ", str10, " = ", this.comm.GetCurrencyinRequiredFormate(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num40.ToString()), 0, "", false, false, true), true), " </div>" };
                        stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                    }
                    catch
                    {
                        stringBuilder.Append(string.Concat("<div align='left'> ", str10, " </div>"));
                    }
                    stringBuilder.Append("<div class='only10px'></div>");
                }
                stringBuilder.Append("<div class='only10px'></div>");
                num2++;
            }
            stringBuilder.Append("</div>");
            stringBuilder.Append("<div class='only10px'></div>    ");
            this.plhItemCostView.Controls.Add(new LiteralControl(stringBuilder.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] chrArray;
            object[] markupIdList;
            decimal num;
            string[] str;
            string str1;
            if (ConnectionClass.ProfitTaxKey != null)
            {
                this.ProfitTaxKey = ConnectionClass.ProfitTaxKey;
            }
            bool unitOfMeasure = ConnectionClass.UnitOfMeasure;
            this.UnitOfMeasureKey = Convert.ToBoolean(ConnectionClass.UnitOfMeasure);
            base.Request.Params["item"].ToString();
            this.Do_Guillotine_New_Cal = Convert.ToBoolean(EprintConfigurationManager.AppSettings["Guillotine_New_Cal"]);
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["module"] != null)
            {
                this.module = base.Request.Params["module"].ToString();
            }
            if (base.Request.Params["Sectioncount"] != null)
            {
                this.sectionpartcount = base.Request.Params["Sectioncount"].ToString();
            }
            try
            {
                if (base.Request.Params["ParentEstimateItemID"] != null)
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["ParentEstimateItemID"]);
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            try
            {
                if (base.Request.Params["EstType"] != null)
                {
                    this.EstType = base.Request.Params["EstType"].ToString();
                }
            }
            catch
            {
            }
            if (base.Request.Params["From"] != null)
            {
                if (string.Compare(base.Request.Params["From"].ToString(), "li", true) == 0)
                {
                    this.para = base.Request.Params["item"].ToString();
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    this.EstimateLithoNcrItemID = Convert.ToInt64(base.Request.Params["TypeID"]);
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "SPL", true) == 0)
                {
                    this.ItemFrom = "SPL";
                    if (base.Request.Params["EstimateItemID"] != null && base.Request.Params["EstType"] != null && base.Request.Params["item"] != null)
                    {
                        this.para = base.Request.Params["item"].ToString();
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                        this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                        this.EstType = base.Request.Params["EstType"].ToString();
                        if (string.Compare(this.module, "job", true) != 0)
                        {
                            string.Compare(this.module, "invoice", true);
                        }
                        if (string.Compare(this.EstType, "f", true) == 0 || string.Compare(this.EstType, "d", true) == 0 || string.Compare(this.EstType, "n", true) == 0 || string.Compare(this.EstType, "k", true) == 0)
                        {
                            this.SPLLithoCostGenerate();
                        }
                        else
                        {
                            this.SPLCostGenerate();
                        }
                    }
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "B", true) == 0)
                {
                    this.ItemFrom = "B";
                    if (base.Request.Params["EstType"] != null && base.Request.Params["item"] != null)
                    {
                        long num1 = Convert.ToInt64(base.Request.Params["EstimateBookletItemID"]);
                        this.EstBookletSectionID = Convert.ToInt64(base.Request.Params["EstimateBookletItemID"]);
                        this.para = base.Request.Params["item"].ToString();
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                        DataTable dataTable = EstimatesBasePage.cost_view_for_booklet(this.CompanyID, this.EstimateItemID, this.EstBookletSectionID);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string[] strArrays = new string[0];
                            if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
                            {
                                foreach (DataRow dataRow in EstimatesBasePage.booklet_job_qty(this.CompanyID, this.EstimateItemID, num1).Rows)
                                {
                                    string str2 = dataRow["Qty"].ToString();
                                    chrArray = new char[] { '-' };
                                    strArrays = str2.Split(chrArray);
                                    this.QtyNo = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                                }
                            }
                            else
                            {
                                string str3 = row["Qty"].ToString();
                                chrArray = new char[] { '-' };
                                strArrays = str3.Split(chrArray);
                            }
                            if ((int)strArrays.Length <= 1)
                            {
                                continue;
                            }
                            this.dtQty = new DataTable();
                            DataColumn dataColumn = new DataColumn("Quantity", typeof(int));
                            this.dtQty.Columns.Add(dataColumn);
                            for (int i = 0; i < (int)strArrays.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(strArrays[i]))
                                {
                                    DataRow dataRow1 = null;
                                    dataRow1 = this.dtQty.NewRow();
                                    dataRow1["Quantity"] = strArrays[i];
                                    this.dtQty.Rows.Add(dataRow1);
                                }
                            }
                        }
                        int num2 = 1;
                        foreach (DataRow row1 in this.dtQty.Rows)
                        {
                            if (!string.IsNullOrEmpty(this.MarkupIdList))
                            {
                                markupIdList = new object[] { this.MarkupIdList, "±", this.EstimateItemID, "_", num2 };
                                this.MarkupIdList = string.Concat(markupIdList);
                            }
                            else
                            {
                                this.MarkupIdList = string.Concat(this.EstimateItemID, "_", num2);
                            }
                            foreach (DataRow row2 in dataTable.Rows)
                            {
                                int num3 = Convert.ToInt32(row1["Quantity"]);
                                this.EstCalculationID = Convert.ToInt64(row2["EstimateCalculationID"]);
                                this.ZonePressCalType = Convert.ToBoolean(row2["CalculationType"]);
                                decimal num4 = Convert.ToDecimal(row2["SetUpSpoilage"]);
                                decimal num5 = Convert.ToDecimal(row2["RunningSpoilage"]);
                                Convert.ToInt32(row2["NoOfSignatures"]);
                                if (row2["NoOfSignatures"].ToString() == "")
                                {
                                    str1 = "0";
                                }
                                else
                                {
                                    num = Math.Ceiling(Convert.ToDecimal(row2["NoOfSignatures"]));
                                    str1 = num.ToString();
                                }
                                string str4 = str1;
                                row2["InventoryCode"].ToString();
                                decimal num6 = num3 * Convert.ToDecimal(str4);
                                decimal num7 = (num6 * num5) / new decimal(100);
                                Convert.ToInt32(num6);
                                string.Compare(row2["BookletFormat"].ToString(), "Portrait", true);
                                decimal num8 = new decimal(0);
                                decimal printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num3, new decimal(0), num4, num5, Convert.ToDecimal(str4), "booklet", new decimal(0), "", out num8);
                                decimal num9 = new decimal(0);
                                decimal num10 = Convert.ToDecimal(row2["PaperUnitPrice"]);
                                Convert.ToDecimal(row2["PaperWeight"]);
                                Convert.ToInt64(row2["PressID"]);
                                Convert.ToInt64(row2["GuillotineID"]);
                                if (this.ProfitTaxKey.ToLower() == "database")
                                {
                                    if (num2 == 1)
                                    {
                                        num9 = Convert.ToDecimal(row2["PaperMarkup"]);
                                        Convert.ToDecimal(row2["PressMarkUp"]);
                                        Convert.ToDecimal(row2["GuillotineMarkUp"]);
                                    }
                                    if (num2 == 2)
                                    {
                                        num9 = Convert.ToDecimal(row2["PaperMarkup2"]);
                                        Convert.ToDecimal(row2["PressMarkUp2"]);
                                        Convert.ToDecimal(row2["GuillotineMarkUp2"]);
                                    }
                                    if (num2 == 3)
                                    {
                                        num9 = Convert.ToDecimal(row2["PaperMarkup3"]);
                                        Convert.ToDecimal(row2["PressMarkUp3"]);
                                        Convert.ToDecimal(row2["GuillotineMarkUp3"]);
                                    }
                                    if (num2 == 4)
                                    {
                                        num9 = Convert.ToDecimal(row2["PaperMarkup4"]);
                                        Convert.ToDecimal(row2["PressMarkUp4"]);
                                        Convert.ToDecimal(row2["GuillotineMarkUp4"]);
                                    }
                                }
                                decimal num11 = printSheetCalulation * num10;
                                decimal num12 = (num11 * num9) / new decimal(100);
                                num11 = num12 + num11;
                                string str5 = row2["PressType"].ToString();
                                string str6 = row2["Colour"].ToString();
                                string str7 = row2["SideColor"].ToString();
                                this.hdn_IsDoubleSided.Value = row2["IsDoubleSided"].ToString();
                                this.hdn_PressType.Value = str5;
                                this.hdn_ZoneSideColor1.Value = str6;
                                this.hdn_ZoneSideColor2.Value = str7;
                                row2["PaperName"].ToString();
                            }
                            num2++;
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl("</table>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
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
                    DataTable dataTable1 = new DataTable();
                    dataTable1 = (string.Compare(this.EstType, "B", true) == 0 || string.Compare(this.EstType, "N", true) == 0 || string.Compare(this.EstType, "K", true) == 0 ? EstimatesBasePage.sub_warehouse_in_summary((long)this.CompanyID, this.TypeID, this.EstType) : EstimatesBasePage.sub_warehouse_in_summary((long)this.CompanyID, this.ParentEstimateItemID, this.EstType));
                    int num13 = 0;
                    foreach (DataRow dataRow2 in dataTable1.Rows)
                    {
                        if (num13 == 0)
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
                            num13++;
                        }
                        decimal num14 = Convert.ToDecimal(dataRow2["Quantity"]);
                        decimal num15 = Convert.ToDecimal(dataRow2["UnitPrice"]);
                        decimal num16 = Convert.ToDecimal(dataRow2["Markup"]);
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:30%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.objBase.SpecialDecode(dataRow2["WarehouseName"].ToString()), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", dataRow2["Quantity"].ToString(), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:28%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", num15.ToString("C"), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        decimal num17 = Convert.ToDecimal(num14 * Convert.ToDecimal(num15));
                        decimal num18 = (num17 * num16) / new decimal(100);
                        decimal num19 = num17 + num18;
                        string str8 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);ItemMarkupOnBlur_ware(this.value,", dataRow2["EstWarehouseItemID"].ToString(), ");");
                        markupIdList = new object[] { "<input id='txtMarkUp_", dataRow2["EstWarehouseItemID"].ToString(), "' ", str8, "  value='", num16, "' class='textboxnew' style='width:75px;text-align:right;' maxlength='15' /> " };
                        string str9 = string.Concat(markupIdList);
                        this.plhItemCostView.Controls.Add(new LiteralControl(str9 ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50%;text-align:right;border:0px solid'>"));
                        ControlCollection controls = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", dataRow2["EstWarehouseItemID"].ToString(), "' style='display:none;'>", num17, "</span>" };
                        controls.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections = this.plhItemCostView.Controls;
                        str = new string[] { "<span class='normaltext' id='spnSellingPrice_", dataRow2["EstWarehouseItemID"].ToString(), "'>", num19.ToString("C"), "</span>" };
                        controlCollections.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hidItemList.Value = string.Concat(this.hidItemList.Value, dataRow2["EstWarehouseItemID"].ToString(), "±");
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
                else if (string.Compare(base.Request.Params["From"].ToString().Trim(), "IC", true) == 0)
                {
                    this.Generate_Price_Catalogue_Sub_Items();
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "IO", true) == 0)
                {
                    this.lblCostViewTitle.Text = this.objLanguage.GetLanguageConversion("Outwork_Item");
                    this.ItemFrom = "IO";
                    this.para = base.Request.Params["item"].ToString();
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    this.TypeID = Convert.ToInt64(base.Request.Params["TypeID"]);
                    this.EstType = base.Request.Params["EstType"].ToString();
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0 ? JobsBasePage.job_item_cost_view_sub_item_outwork(this.CompanyID, this.ParentEstimateItemID, this.EstimateItemID) : EstimatesBasePage.item_cost_view_sub_item_outwork(this.CompanyID, this.EstimateItemID));
                    int num20 = 0;
                    long num21 = (long)0;
                    foreach (DataRow row3 in dataTable2.Rows)
                    {
                        if (num20 == 0)
                        {
                            num21 = Convert.ToInt64(row3["EstOutworkID"]);
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' width='100%' style='border:0px solid' class='only10px'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;border:0px solid'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Supp_Quote"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;border:0px solid'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Supplier_Name"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Outwork_Title"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;' align='right'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75%;text-align:right;border:0px solid'>"));
                            ControlCollection controls1 = this.plhItemCostView.Controls;
                            str = new string[] { "<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Cost"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                            controls1.Add(new LiteralControl(string.Concat(str)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Markup_Type"), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Markup"), " </span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;border:0px solid'> "));
                            ControlCollection controlCollections1 = this.plhItemCostView.Controls;
                            str = new string[] { "<span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(str)));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num20++;
                        }
                        if (num21 != Convert.ToInt64(row3["EstOutworkID"]))
                        {
                            num21 = Convert.ToInt64(row3["EstOutworkID"]);
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div style='border-top:solid 1px silver'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                        }
                        string str10 = row3["MarkupType"].ToString();
                        decimal num22 = Convert.ToDecimal(row3["MarkupValue"]);
                        decimal num23 = new decimal(0);
                        decimal num24 = Convert.ToDecimal(row3["TotalPrice"]);
                        decimal num25 = Convert.ToDecimal(row3["Cost"]);
                        str10 = (string.Compare(str10, "F", true) != 0 ? "%" : this.comm.GetCurrencyinRequiredFormate("", true) ?? "");
                        num23 = num22;
                        this.hidItemList.Value = string.Concat(this.hidItemList.Value, row3["EstOutworkSupplierID"].ToString(), "±");
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' style='border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100%;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.objBase.SpecialDecode(row3["SupplierRefNo"].ToString()), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100%;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.objBase.SpecialDecode(row3["clientname"].ToString()), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.objBase.SpecialDecode(row3["RFQTitle"].ToString()), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align=right style='float:left;width:50px;border:solid 0px red'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["Quantity"].ToString()), 0, "", true, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:22%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align=right style='float:left;width:35%;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num25.ToString()), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='center' style='border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50%;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>&nbsp;", str10, "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        str = new string[] { "onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);ItemOutworkMarkupOnBlur(this.value,\"", row3["EstOutworkSupplierID"].ToString(), ",", str10, "\");" };
                        string str11 = string.Concat(str);
                        str = new string[] { "<input id='txtMarkUp_", row3["EstOutworkSupplierID"].ToString(), "' ", str11, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num23), 0, "", false, false, false), "' class='textboxnew' style='width:55px;text-align:right' maxlength='15'  /> " };
                        string str12 = string.Concat(str);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:10%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='center' style='float:left;width:60%;'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(str12 ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:12%;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:78%;text-align:right;border:0px solid'>"));
                        ControlCollection controls2 = this.plhItemCostView.Controls;
                        markupIdList = new object[] { " <span  id='spnPriceExMarkup_", row3["EstOutworkSupplierID"].ToString(), "' style='display:none;'>", num25, "</span>" };
                        controls2.Add(new LiteralControl(string.Concat(markupIdList)));
                        ControlCollection controlCollections2 = this.plhItemCostView.Controls;
                        str = new string[] { "<span class='normaltext' id='spnSellingPrice_", row3["EstOutworkSupplierID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num24.ToString()), 0, "", false, false, true), "</span>" };
                        controlCollections2.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
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
                    long num26 = (long)0;
                    long num27 = (long)0;
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstimateItemID"]);
                    if (this.EstType != "U")
                    {
                        num27 = Convert.ToInt64(base.Request.Params["TypeID"]);
                        num26 = Convert.ToInt64(base.Request.Params["EstOtherCostID"]);
                    }
                    else
                    {
                        num26 = Convert.ToInt64(base.Request.Params["TypeID"]);
                    }
                    DataTable dataTable3 = new DataTable();
                    if (this.EstType != "U")
                    {
                        dataTable3 = EstimatesBasePage.estimate_summary_items_othercost_select_new(this.CompanyID, this.EstType, num27, num26);
                    }
                    else
                    {
                        this.OtherCostSubItem();
                    }
                    int num28 = 0;
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (DataRow dataRow3 in dataTable3.Rows)
                    {
                        string str13 = dataRow3["CalculationName"].ToString();
                        string str14 = dataRow3["CalculationType"].ToString();
                        string str15 = dataRow3["VariableDDLType"].ToString();
                        decimal num29 = Convert.ToDecimal(dataRow3["HourlyRunSpeed"]);
                        string str16 = dataRow3["FormulaTag"].ToString();
                        chrArray = new char[] { '\u00B6' };
                        string[] strArrays1 = str16.Split(chrArray);
                        int num30 = Convert.ToInt32(dataRow3["SetupTime"]);
                        decimal num31 = Convert.ToDecimal(dataRow3["HourlyRate"]);
                        decimal num32 = Convert.ToDecimal(dataRow3["HoursOrQty"]);
                        decimal num33 = Convert.ToDecimal(dataRow3["Markup"]);
                        decimal num34 = Convert.ToDecimal(dataRow3["MinimumCost"]);
                        decimal num35 = Convert.ToDecimal(dataRow3["Passes"]);
                        stringBuilder.Append("<div class='only10px'></div>");
                        stringBuilder.Append("<div align='left' style='width:60%;padding-left:10px'>");
                        stringBuilder.Append("<div align='left' style='border:1px solid silver;width:100%;padding:5px;border-style:dashed;'>");
                        if (string.Compare(str14, "t", true) == 0 || string.Compare(str14, "q", true) == 0)
                        {
                            stringBuilder.Append("<span><u><b>Work Instruction:</b></u></span>");
                            stringBuilder.Append("<div class='only5px'></div>");
                        }
                        if (string.Compare(str13, "v", true) == 0)
                        {
                            stringBuilder.Append("<div> Print Layout Value: 0</div>    ");
                        }
                        else if (string.Compare(str14, "f", true) != 0 && dataRow3["MakeReadyTime"].ToString() != "")
                        {
                            stringBuilder.Append(string.Concat("<div> Make Ready Time: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["MakeReadyTime"]), 0, "", false, false, true), " min </div>    "));
                        }
                        if (num29 > new decimal(0) && string.Compare(str14, "t", true) == 0)
                        {
                            if (dataRow3["HourlyRunSpeed"] != null)
                            {
                                stringBuilder.Append(string.Concat("<div style='border:solid 0px red'> Hourly Run Speed: ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRunSpeed"].ToString()), 0, "", false, false, true), "</div>    "));
                            }
                            stringBuilder.Append(string.Concat("<div> Passes: ", num35, "</div>    "));
                        }
                        stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                        stringBuilder.Append("<div><span><u><b>Calculation:</b></u></span></div>    ");
                        stringBuilder.Append("<div class='only5px'></div>");
                        if (string.Compare(str14, "t", true) != 0)
                        {
                            if (string.Compare(str14, "q", true) == 0)
                            {
                                if (str15 == "1")
                                {
                                    stringBuilder.Append("<div>(Print Sheet Qty (exl. Spoilage) x Unit Rate)  + MakeReady Cost + Mark up</div>    ");
                                }
                                else if (str15 == "2")
                                {
                                    stringBuilder.Append("<div>(Print Sheet Qty (inc. Spoilage) x Unit Rate) + MakeReady Cost + Mark up</div>    ");
                                }
                                else if (str15 == "3")
                                {
                                    stringBuilder.Append("<div>(Finished Item Qty  x Unit Rate) + MakeReady Cost + Mark up</div>    ");
                                }
                                else if (str15 != "4")
                                {
                                    stringBuilder.Append("<div>(Quantity x Unit Rate) + MakeReady Cost+ Mark up</div>");
                                }
                                else
                                {
                                    stringBuilder.Append("<div>(Finished Item Qty  x Unit Rate) + MakeReady Cost + Mark up</div>");
                                }
                            }
                        }
                        else if (str15 == "1")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (exl. Spoilage) / Hourly Run Speed)  x Hourly Rate    + MakeReady Cost + Mark up</div>    ");
                        }
                        else if (str15 == "2")
                        {
                            stringBuilder.Append("<div> (Print Sheet Qty (inc. Spoilage) / Hourly Run Speed)  x Hourly Rate + MakeReady Cost + Mark up</div>    ");
                        }
                        else if (str15 == "3")
                        {
                            stringBuilder.Append("<div> (Finished Item Qty  / Hourly Run Speed) x Hourly Rate + MakeReady Cost + Mark up</div>    ");
                        }
                        else if (str15 != "4")
                        {
                            stringBuilder.Append("<div>(Hours x Per Hour Cost) + MakeReady Cost + Mark up</div>");
                        }
                        else
                        {
                            stringBuilder.Append("<div> (Finished Item Qty  / Hourly Run Speed)  x Hourly Rate + MakeReady Cost + Mark up</div>    ");
                        }
                        if (string.Compare(str14, "f", true) == 0 || string.Compare(str14, "m", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div>", this.objBase.SpecialDecode(strArrays1[1]), "+ Markup </div>"));
                        }
                        stringBuilder.Append("<div class='only5px'>&nbsp;</div>    ");
                        stringBuilder.Append("<div><span><u><b>Actuals:</b></u></span></div>");
                        stringBuilder.Append("<div class='only5px'></div>");
                        if (num28 == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div ></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div align='left' style='width:99%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <div style='float:left;'><span class='normaltext'>Other Cost Name:&nbsp;</span></div><div style='float:left;'><span class='Headertext'>", this.objBase.SpecialDecode(dataRow3["OtherCostName"].ToString()), "</span></div>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left' style='border:0px solid red'>"));
                            if (string.Compare(str14, "t", true) != 0)
                            {
                                if (string.Compare(str14, "q", true) == 0 && (string.Compare(str13, "f", true) == 0 || string.Compare(str13, "v", true) == 0))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;text-align:center'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Qty</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Unit Rate(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Hourly Rate(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                            else if (string.Compare(str13, "f", true) == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hours </span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Hourly Rate (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                if (Convert.ToDecimal(dataRow3["HourlyRunSpeed"]) != new decimal(0))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            else if (string.Compare(str13, "v", true) == 0)
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
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:110px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:85px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Hourly Rate(", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                if (Convert.ToDecimal(dataRow3["HourlyRunSpeed"]) != new decimal(0))
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Hourly Run Speed</span>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Make Ready Time</span>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;border:solid 0px red'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Minimum Charge (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='Headertext'>Mark Up (%)</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='Headertext'>Selling Price (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            num28++;
                        }
                        decimal num36 = (num30 * num31) / new decimal(60);
                        decimal num37 = new decimal(0);
                        decimal num38 = new decimal(0);
                        if (dataRow3["CalculationType"].ToString() == "q")
                        {
                            Convert.ToDecimal(dataRow3["UnitRate"]);
                        }
                        num37 = Convert.ToDecimal(dataRow3["Cost"]);
                        if (string.Compare(str14, "t", true) != 0)
                        {
                            if (string.Compare(str14, "q", true) == 0 && (string.Compare(str13, "f", true) == 0 || string.Compare(str13, "v", true) == 0))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                if (dataRow3["HoursOrQty"] != null)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HoursOrQty"].ToString()), 0, "", true, false, true), "</span>")));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div></div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90%;text-align:right;border:0px solid'>"));
                                if (dataRow3["UnitRate"] != null)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["UnitRate"].ToString()), 0, "", false, false, true), "</span>")));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:90%;text-align:right;border:0px solid'>"));
                                if (dataRow3["HourlyRate"] != null)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRate"].ToString()), 0, "", false, false, true), "</span>")));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:62%;text-align:right;border:0px solid'>"));
                                if (dataRow3["SetupTime"] != null)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["SetupTime"].ToString()), 0, "", false, false, true), "</span>")));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                        }
                        else if (string.Compare(str13, "f", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            if (dataRow3["HoursOrQty"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.ReturnExact2Decimal(num32), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:120px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                            if (dataRow3["MakeReadyTime"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["MakeReadyTime"].ToString()), 0, "", false, false, true), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:66%;text-align:right;border:0px solid'>"));
                            if (dataRow3["HourlyRate"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRate"].ToString()), 0, "", false, false, true), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            if (Convert.ToDecimal(dataRow3["HourlyRunSpeed"]) != new decimal(0))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75%;text-align:right;border:0px solid'>"));
                                if (dataRow3["HourlyRunSpeed"] != null)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRunSpeed"].ToString()), 0, "", false, false, true), "</span>")));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                            if (dataRow3["SetupTime"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["SetupTime"].ToString()), 0, "", false, false, true), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                        else if (string.Compare(str13, "v", true) == 0)
                        {
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            if (dataRow3["HoursOrQty"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.ReturnExact2Decimal(num32), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:75px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<span class='normalText'>0</span>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:50px;'> "));
                            if (dataRow3["HoursOrQty"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.ReturnExact2Decimal(num32), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:110px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                            if (dataRow3["MakeReadyTime"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["MakeReadyTime"].ToString()), 0, "", false, false, true), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:85px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:95%;text-align:right;border:0px solid'>"));
                            if (dataRow3["HourlyRate"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRate"].ToString()), 0, "", false, false, true), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            if (Convert.ToDecimal(dataRow3["HourlyRunSpeed"]) != new decimal(0))
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:125px;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                                if (dataRow3["HourlyRunSpeed"] != null)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRunSpeed"].ToString()), 0, "", false, false, true), "</span>")));
                                }
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80px;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                            if (dataRow3["SetupTime"] != null)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normalText'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["SetupTime"].ToString()), 0, "", false, false, true), "</span>")));
                            }
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:140px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:80%;text-align:right;border:0px solid'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat("<span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num34.ToString()), 0, "", false, false, true), "</span>")));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.hidItemList.Value = string.Concat(this.hidItemList.Value, dataRow3["EstOtherCostID"].ToString(), "±");
                        markupIdList = new object[] { "onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);ItemMarkupOnBlur(this.value,", dataRow3["EstOtherCostID"].ToString(), ",", num34, ",", num36, ");" };
                        string str17 = string.Concat(markupIdList);
                        str = new string[] { "<input id='txtMarkUp_", dataRow3["EstOtherCostID"].ToString(), "' ", str17, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num33), 0, "", false, false, false), "' class='textboxnew' style='width:60px;text-align:right'   maxlength='15' /> " };
                        string str18 = string.Concat(str);
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(str18 ?? ""));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        num37 = num37 - num36;
                        decimal num39 = (num37 * num33) / new decimal(100);
                        decimal num40 = num36;
                        num38 = this.comm.Eprint_GetminimumCost_ComparedtoCostwithMarkup_ForOtherCost(num37, num33, num34, out this.CostexMarkup_forsummary, out this.MinimumCostMarkup, ref num40);
                        decimal num41 = new decimal(0);
                        num41 = (num37 + num36) + num39;
                        if (num34 == new decimal(0))
                        {
                            num38 = num38;
                        }
                        else
                        {
                            num38 = (num41 < num34 ? num34 : num38);
                        }
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:100px;'> "));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:70%;text-align:right;border:0px solid'>"));
                        ControlCollection controls3 = this.plhItemCostView.Controls;
                        str = new string[] { " <span  id='spnPriceExMarkup_", dataRow3["EstOtherCostID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num37), 0, "", false, false, true), "</span>" };
                        controls3.Add(new LiteralControl(string.Concat(str)));
                        ControlCollection controlCollections3 = this.plhItemCostView.Controls;
                        str = new string[] { " <span class='normaltext' id='spnSellingPrice_", dataRow3["EstOtherCostID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num38.ToString()), 0, "", false, false, true), "</span>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(str)));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                        this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                        if (string.Compare(str14, "t", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div><b>Quantity:</b> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HoursOrQty"].ToString()), 0, "", true, false, true), "</div>"));
                            str = new string[] { "<div>(", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HoursOrQty"].ToString()), 0, "", true, false, true), " x ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num31), 0, "", false, false, true), ") + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num36), 0, "", false, false, true), " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num39), 0, "", false, false, true), " = ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num41), 0, "", false, false, true), "</div>    " };
                            stringBuilder.Append(string.Concat(str));
                        }
                        else if (string.Compare(str14, "q", true) == 0)
                        {
                            stringBuilder.Append(string.Concat("<div><b>Quantity:</b> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["quantityvar"].ToString()), 0, "", true, false, true), "</div>"));
                            str = new string[] { "<div>(", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HoursOrQty"].ToString()), 0, "", true, false, true), " x ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["UnitRate"]), 0, "", false, false, true), ") + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num36), 0, "", false, false, true), " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num39), 0, "", false, false, true), "= ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num41), 0, "", false, false, true), "</div>    " };
                            stringBuilder.Append(string.Concat(str));
                        }
                        if (string.Compare(str14, "f", true) == 0 || string.Compare(str14, "m", true) == 0)
                        {
                            strArrays1[0] = (strArrays1[0] == "" ? "0" : strArrays1[0]);
                            string str19 = strArrays1[0];
                            try
                            {
                                num = (new MathParser()).Calculate(strArrays1[0]);
                                num = Convert.ToDecimal(num.ToString());
                                string str20 = num.ToString();
                                decimal num42 = Convert.ToDecimal(str20) + num39;
                                str19 = string.Concat(str19, " + ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num39.ToString()), 0, "", false, false, true));
                                str = new string[] { "<div align='left'> ", str19, " = ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num42.ToString()), 0, "", false, false, true), " </div>" };
                                stringBuilder.Append(string.Concat(str));
                            }
                            catch
                            {
                                stringBuilder.Append(string.Concat("<div align='left'> ", str19, " </div>"));
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
                    long num43 = Convert.ToInt64(base.Request.Params["TypeID"]);
                    long QtyNumber = Convert.ToInt64(base.Request.Params["QtyNumber"]);

                    DataTable dataTable4 = EstimateBasePage.Warehouse_Information_By_EstimateItemID(this.CompanyID, this.EstimateItemID, num43);
                    int num44 = 0;
                    foreach (DataRow row4 in dataTable4.Rows)
                    {
                        if(this.module == "job" || this.module == "invoice")
                        {
                            if(QtyNumber == 1)
                            {
                                if (num44 == 0)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    ControlCollection controls4 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controls4.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                    ControlCollection controlCollections4 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controlCollections4.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    num44++;
                                }
                                int num45 = Convert.ToInt32(row4["Quantity"]);
                                decimal num46 = Convert.ToDecimal(row4["UnitPrice"]);
                                decimal num47 = new decimal(0);
                                num47 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                decimal num48 = Convert.ToDecimal(Convert.ToDecimal(num46) * num45);
                                decimal num49 = num48 + ((num48 * num47) / new decimal(100));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num45), 0, "", true, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num46.ToString()), 4, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                string str21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);WarehouseMarkupOnBlur(this,this.value,'", num43, "');");
                                str = new string[] { "<input id='txtMarkUp_", row4["EstWarehouseItemID"].ToString(), "' ", str21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num47), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                string str22 = string.Concat(str);
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(str22));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                ControlCollection controls5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num48), 0, "", false, false, true), "</span>" };
                                controls5.Add(new LiteralControl(string.Concat(str)));
                                ControlCollection controlCollections5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num49.ToString()), 0, "", false, false, true), "</span>" };
                                controlCollections5.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                this.hidItemList.Value = num43.ToString();
                            }
                           

                            ///////////////////////////////// For Quantity2
                            if(QtyNumber == 2)
                            {
                                int num50 = Convert.ToInt32(row4["Quantity2"]);
                                if (num50 > 0)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    ControlCollection controls_4 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controls_4.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                    ControlCollection controlCollections_4 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controlCollections_4.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    decimal num51 = Convert.ToDecimal(row4["UnitPrice"]);
                                    decimal num52 = new decimal(0);
                                    if (Convert.ToDecimal(row4["Markup2"].ToString()) > 0)
                                    {
                                        num52 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup2"].ToString() == "" ? 0 : row4["Markup2"])));
                                    }
                                    else
                                    {
                                        num52 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                    }
                                    decimal num53 = Convert.ToDecimal(Convert.ToDecimal(num50) * num51);
                                    decimal num54 = num53 + ((num53 * num52) / new decimal(100));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num50), 0, "", true, false, true), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num51.ToString()), 4, "", false, false, true), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    string str_21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);");
                                    str = new string[] { "<input id='txtMarkUp2_", row4["EstWarehouseItemID"].ToString(), "' ", str_21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num52), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                    string str_22 = string.Concat(str);
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(str_22));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                    ControlCollection controls_5 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num53), 0, "", false, false, true), "</span>" };
                                    controls_5.Add(new LiteralControl(string.Concat(str)));
                                    ControlCollection controlCollections_5 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num54.ToString()), 0, "", false, false, true), "</span>" };
                                    controlCollections_5.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    this.hidItemList.Value = num43.ToString();
                                }
                            }
                            

                            ////
                            /// For Quantity3//// 
                            if(QtyNumber == 3)
                            {
                                int num55 = Convert.ToInt32(row4["Quantity3"]);
                                if (num55 > 0)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    ControlCollection controlsQty3 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controlsQty3.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                    ControlCollection controlCollectionsQty3 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controlCollectionsQty3.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    decimal num56 = Convert.ToDecimal(row4["UnitPrice"]);
                                    decimal num57 = new decimal(0);
                                    if (Convert.ToDecimal(row4["Markup3"].ToString()) > 0)
                                    {
                                        num57 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup3"].ToString() == "" ? 0 : row4["Markup3"])));
                                    }
                                    else
                                    {
                                        num57 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                    }
                                    decimal num58 = Convert.ToDecimal(Convert.ToDecimal(num55) * num56);
                                    decimal num59 = num58 + ((num58 * num57) / new decimal(100));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num55), 0, "", true, false, true), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num56.ToString()), 4, "", false, false, true), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    string str_qty3_21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);");
                                    str = new string[] { "<input id='txtMarkUp3_", row4["EstWarehouseItemID"].ToString(), "' ", str_qty3_21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num57), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                    string str_qty3_22 = string.Concat(str);
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(str_qty3_22));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                    ControlCollection controls_qty3_5 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num58), 0, "", false, false, true), "</span>" };
                                    controls_qty3_5.Add(new LiteralControl(string.Concat(str)));
                                    ControlCollection controlCollections_qty3_5 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num59.ToString()), 0, "", false, false, true), "</span>" };
                                    controlCollections_qty3_5.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    this.hidItemList.Value = num43.ToString();
                                }
                            }
                           

                            /// For Quantity4 ////
                            if(QtyNumber == 4)
                            {
                                int num60 = Convert.ToInt32(row4["Quantity4"]);
                                if (num60 > 0)
                                {
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    ControlCollection controlsQty4 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controlsQty4.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                    ControlCollection controlCollectionsQty4 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                    controlCollectionsQty4.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    decimal num61 = Convert.ToDecimal(row4["UnitPrice"]);
                                    decimal num62 = new decimal(0);
                                    if (Convert.ToDecimal(row4["Markup4"].ToString()) > 0)
                                    {
                                        num62 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup4"].ToString() == "" ? 0 : row4["Markup4"])));
                                    }
                                    else
                                    {
                                        num62 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                    }
                                    decimal num63 = Convert.ToDecimal(Convert.ToDecimal(num60) * num61);
                                    decimal num64 = num63 + ((num63 * num62) / new decimal(100));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num60), 0, "", true, false, true), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num61.ToString()), 4, "", false, false, true), "</span>")));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    string str_qty4_21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);");
                                    str = new string[] { "<input id='txtMarkUp4_", row4["EstWarehouseItemID"].ToString(), "' ", str_qty4_21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num62), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                    string str_qty4_22 = string.Concat(str);
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(str_qty4_22));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                    ControlCollection controls_qty4_5 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num63), 0, "", false, false, true), "</span>" };
                                    controls_qty4_5.Add(new LiteralControl(string.Concat(str)));
                                    ControlCollection controlCollections_qty4_5 = this.plhItemCostView.Controls;
                                    str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num64.ToString()), 0, "", false, false, true), "</span>" };
                                    controlCollections_qty4_5.Add(new LiteralControl(string.Concat(str)));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                    this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                    this.hidItemList.Value = num43.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (num44 == 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                ControlCollection controls4 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controls4.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                ControlCollection controlCollections4 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controlCollections4.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                num44++;
                            }
                            int num45 = Convert.ToInt32(row4["Quantity"]);
                            decimal num46 = Convert.ToDecimal(row4["UnitPrice"]);
                            decimal num47 = new decimal(0);
                            num47 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                            decimal num48 = Convert.ToDecimal(Convert.ToDecimal(num46) * num45);
                            decimal num49 = num48 + ((num48 * num47) / new decimal(100));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num45), 0, "", true, false, true), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num46.ToString()), 4, "", false, false, true), "</span>")));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            string str21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);WarehouseMarkupOnBlur(this,this.value,'", num43, "');");
                            str = new string[] { "<input id='txtMarkUp_", row4["EstWarehouseItemID"].ToString(), "' ", str21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num47), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                            string str22 = string.Concat(str);
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(str22));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                            ControlCollection controls5 = this.plhItemCostView.Controls;
                            str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num48), 0, "", false, false, true), "</span>" };
                            controls5.Add(new LiteralControl(string.Concat(str)));
                            ControlCollection controlCollections5 = this.plhItemCostView.Controls;
                            str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num49.ToString()), 0, "", false, false, true), "</span>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(str)));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                            this.hidItemList.Value = num43.ToString();




                            ///////////////////////////////// For Quantity2
                            int num50 = Convert.ToInt32(row4["Quantity2"]);
                            if (num50 > 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                ControlCollection controls_4 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controls_4.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                ControlCollection controlCollections_4 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controlCollections_4.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                decimal num51 = Convert.ToDecimal(row4["UnitPrice"]);
                                decimal num52 = new decimal(0);
                                if (Convert.ToDecimal(row4["Markup2"].ToString()) > 0)
                                {
                                    num52 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup2"].ToString() == "" ? 0 : row4["Markup2"])));
                                }
                                else
                                {
                                    num52 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                }
                                decimal num53 = Convert.ToDecimal(Convert.ToDecimal(num50) * num51);
                                decimal num54 = num53 + ((num53 * num52) / new decimal(100));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num50), 0, "", true, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num51.ToString()), 4, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                string str_21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);");
                                str = new string[] { "<input id='txtMarkUp2_", row4["EstWarehouseItemID"].ToString(), "' ", str_21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num52), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                string str_22 = string.Concat(str);
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(str_22));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                ControlCollection controls_5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num53), 0, "", false, false, true), "</span>" };
                                controls_5.Add(new LiteralControl(string.Concat(str)));
                                ControlCollection controlCollections_5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num54.ToString()), 0, "", false, false, true), "</span>" };
                                controlCollections_5.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                this.hidItemList.Value = num43.ToString();
                            }

                            ////
                            /// For Quantity3////
                            int num55 = Convert.ToInt32(row4["Quantity3"]);
                            if (num55 > 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                ControlCollection controlsQty3 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controlsQty3.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                ControlCollection controlCollectionsQty3 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controlCollectionsQty3.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                decimal num56 = Convert.ToDecimal(row4["UnitPrice"]);
                                decimal num57 = new decimal(0);
                                if (Convert.ToDecimal(row4["Markup3"].ToString()) > 0)
                                {
                                    num57 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup3"].ToString() == "" ? 0 : row4["Markup3"])));
                                }
                                else
                                {
                                    num57 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                }
                                decimal num58 = Convert.ToDecimal(Convert.ToDecimal(num55) * num56);
                                decimal num59 = num58 + ((num58 * num57) / new decimal(100));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num55), 0, "", true, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num56.ToString()), 4, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                string str_qty3_21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);");
                                str = new string[] { "<input id='txtMarkUp3_", row4["EstWarehouseItemID"].ToString(), "' ", str_qty3_21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num57), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                string str_qty3_22 = string.Concat(str);
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(str_qty3_22));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                ControlCollection controls_qty3_5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num58), 0, "", false, false, true), "</span>" };
                                controls_qty3_5.Add(new LiteralControl(string.Concat(str)));
                                ControlCollection controlCollections_qty3_5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num59.ToString()), 0, "", false, false, true), "</span>" };
                                controlCollections_qty3_5.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                this.hidItemList.Value = num43.ToString();


                            }

                            /// For Quantity4 ////
                            int num60 = Convert.ToInt32(row4["Quantity4"]);
                            if (num60 > 0)
                            {
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Warehouse_Item_Name"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Quantity"), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                ControlCollection controlsQty4 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Unit_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controlsQty4.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Mark_Up"), " (%)</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;'> "));
                                ControlCollection controlCollectionsQty4 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='Headertext'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")</span>" };
                                controlCollectionsQty4.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                decimal num61 = Convert.ToDecimal(row4["UnitPrice"]);
                                decimal num62 = new decimal(0);
                                if (Convert.ToDecimal(row4["Markup4"].ToString()) > 0)
                                {
                                    num62 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup4"].ToString() == "" ? 0 : row4["Markup4"])));
                                }
                                else
                                {
                                    num62 = (this.ProfitTaxKey.ToLower() != "database" ? EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "InventoryItems", (long)0) : Convert.ToDecimal((row4["Markup"].ToString() == "" ? 0 : row4["Markup"])));
                                }
                                decimal num63 = Convert.ToDecimal(Convert.ToDecimal(num60) * num61);
                                decimal num64 = num63 + ((num63 * num62) / new decimal(100));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div align='left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.objBase.SpecialDecode(row4["Name"].ToString()), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:25%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num60), 0, "", true, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:38%;text-align:right;border:0px solid red'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(string.Concat(" <span class='normaltext'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num61.ToString()), 4, "", false, false, true), "</span>")));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                string str_qty4_21 = string.Concat("onblur=javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);");
                                str = new string[] { "<input id='txtMarkUp4_", row4["EstWarehouseItemID"].ToString(), "' ", str_qty4_21, "  value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num62), 0, "", false, false, false), "' class='textboxnew' style='width:75px;text-align:right;'  maxlength='15' /> " };
                                string str_qty4_22 = string.Concat(str);
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:20%;'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(str_qty4_22));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:15%'> "));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left;width:60%;text-align:right;border:0px solid'>"));
                                ControlCollection controls_qty4_5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span  id='spnSellingExMarkup_", row4["EstWarehouseItemID"].ToString(), "' style='display:none;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num63), 0, "", false, false, true), "</span>" };
                                controls_qty4_5.Add(new LiteralControl(string.Concat(str)));
                                ControlCollection controlCollections_qty4_5 = this.plhItemCostView.Controls;
                                str = new string[] { " <span class='normaltext' id='spnSellingInMarkup_", row4["EstWarehouseItemID"].ToString(), "'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num64.ToString()), 0, "", false, false, true), "</span>" };
                                controlCollections_qty4_5.Add(new LiteralControl(string.Concat(str)));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='float:left'>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" &nbsp; </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl(" </div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
                                this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
                                this.hidItemList.Value = num43.ToString();
                            }

                        }

                    }
                }
                else if (string.Compare(base.Request.Params["From"].ToString(), "C", true) == 0)
                {
                    this.Generate_Price_Catalogue_Items();
                }
            }
            string empty = string.Empty;
            if (string.Compare(this.EstType, "N", true) == 0 || string.Compare(this.EstType, "R", true) == 0)
            {
                DataTable dataTable5 = new DataTable();
                dataTable5 = EstimatesBasePage.estimate_lithoNCR_select_popup(this.CompanyID, Convert.ToInt64(base.Request.Params["EstimateItemID"]), Convert.ToInt64(base.Request.Params["TypeID"]));
                foreach (DataRow dataRow4 in dataTable5.Rows)
                {
                    empty = dataRow4["NcrImageType"].ToString();
                }
            }
            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            if (this.para.ToLower() != "paper")
            {
                this.plhItemCostView.Controls.Add(new LiteralControl("<table border='0' width='85%' cellspacing='1' cellpadding='1'>"));
            }
            this.plhItemCostView.Controls.Add(new LiteralControl("<tr><td align='left'>"));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div style='display:none;'> "));
            Button button = new Button()
            {
                Text = "Cancel",
                CssClass = "button",
                Width = Unit.Pixel(65)
            };
            button.Attributes.Add("onclick", "javascript:window.close();return false;");
            if (string.Compare(this.EstType, "N", true) == -1 && empty != "common" && (base.Request.Params["item"].ToString() != "plates" || base.Request.Params["item"].ToString() != "makeready" || base.Request.Params["item"].ToString() != "washup"))
            {
                this.plhItemCostView.Controls.Add(button);
            }
            this.plhItemCostView.Controls.Add(new LiteralControl(" </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" </td><td align='right'> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" <div> "));
            Button button1 = new Button()
            {
                Text = this.objLanguage.GetLanguageConversion("Save"),
                CssClass = "button",
                Width = Unit.Pixel(65)
            };
            button1.Click += new EventHandler(this.lnkbtnSaveItemView_OnClick);
            button1.Attributes.Add("onclick", "javascript:return ItemMarkupSave();");
            if ((string.Compare(this.EstType, "N", true) != 0 || !(empty == "common") || !(base.Request.Params["item"].ToString() == "plates") && !(base.Request.Params["item"].ToString() == "makeready") && !(base.Request.Params["item"].ToString() == "washup")) && this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "true")
            {
                this.plhItemCostView.Controls.Add(button1);
            }
            this.plhItemCostView.Controls.Add(new LiteralControl(" </div> "));
            this.plhItemCostView.Controls.Add(new LiteralControl(" </td></tr></table> "));
            this.plhItemCostView.Controls.Add(new LiteralControl("<div class='only5px'></div>"));
            this.Page.Title = this.lblCostViewTitle.Text;
            this.pnlCostView.Visible = true;
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

        public decimal ReturnExact9Decimal(decimal Amount)
        {
            Amount = Amount * new decimal(1000000000);
            string[] strArrays = Amount.ToString().Split(new char[] { '.' });
            decimal num = new decimal(0);
            num = Convert.ToDecimal(strArrays[0]);
            Amount = num / new decimal(1000000000);
            return Amount;
        }

        protected void SPLCostGenerate()
        {
            string empty = string.Empty;
            DataTable dataTable = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, this.EstBookletSectionID);
            foreach (DataRow row in dataTable.Rows)
            {
                int num = Convert.ToInt32(row["qty1"]);
                int num1 = Convert.ToInt32(row["qty2"]);
                int num2 = Convert.ToInt32(row["qty3"]);
                int num3 = Convert.ToInt32(row["qty4"]);
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (num != 0)
                    {
                        empty = string.Concat(empty, num.ToString(), "»");
                    }
                    if (num1 != 0)
                    {
                        empty = string.Concat(empty, num1.ToString(), "»");
                    }
                    if (num2 != 0)
                    {
                        empty = string.Concat(empty, num2.ToString(), "»");
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    empty = string.Concat(empty, num3.ToString(), "»");
                }
                else
                {
                    if (num != 0)
                    {
                        empty = string.Concat(empty, num.ToString(), "»");
                    }
                    if (num1 != 0)
                    {
                        empty = string.Concat(empty, num1.ToString(), "»");
                    }
                    if (num2 != 0)
                    {
                        empty = string.Concat(empty, num2.ToString(), "»");
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    empty = string.Concat(empty, num3.ToString(), "»");
                }
            }
            if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
            {
                foreach (DataRow dataRow in JobsBasePage.job_qty_select_by_qtynumber(this.CompanyID, this.EstimateItemID).Rows)
                {
                    empty = string.Concat(dataRow["Quantity"].ToString(), "»");
                }
            }
            empty = empty.Substring(0, empty.Length - 1);
            string[] strArrays = empty.Split(new char[] { '»' });
            this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            this.Metre = this.ObjPage.GetRegionalSettings(this.CompanyID, "Metre");
            DataTable dataTable1 = new DataTable();
            if (string.Compare(this.EstType, "S", true) == 0)
            {
                dataTable1 = EstimatesBasePage.single_item_select(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.EstType, "P", true) == 0)
            {
                dataTable1 = EstimatesBasePage.pad_item_select(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.EstType, "L", true) == 0)
            {
                dataTable1 = EstimatesBasePage.large_item_select(this.CompanyID, this.EstimateItemID);
            }
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                if (string.IsNullOrEmpty(strArrays[i]))
                {
                    return;
                }
                int num4 = Convert.ToInt32(strArrays[i]);
                long num5 = Convert.ToInt64(i);
                if (!string.IsNullOrEmpty(this.MarkupIdList))
                {
                    object[] markupIdList = new object[] { this.MarkupIdList, "±", this.EstimateItemID, "_", num5 };
                    this.MarkupIdList = string.Concat(markupIdList);
                }
                else
                {
                    this.MarkupIdList = string.Concat(this.EstimateItemID, "_", num5);
                }
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    this.EstCalculationID = Convert.ToInt64(row1["EstimateCalculationID"]);
                    decimal num6 = Convert.ToDecimal(row1["SetUpSpoilage"]);
                    Convert.ToDecimal(row1["SetUpSpoilage"]);
                    decimal num7 = Convert.ToDecimal(row1["RunningSpoilage"]);
                    string str = row1["PrintLayout"].ToString();
                    row1["InventoryCode"].ToString();
                    if (this.EstType != "L")
                    {
                        this.ZonePressCalType = Convert.ToBoolean(row1["CalculationType"]);
                    }
                    int num8 = (str == "L" ? Convert.ToInt32(row1["LandScapeValue"]) : Convert.ToInt32(row1["PortraitValue"]));
                    decimal num9 = new decimal(0);
                    if (string.Compare(this.EstType, "P", true) != 0)
                    {
                        EstimatesBasePage.GetPrintSheetCalulation(num4, num8, num6, num7, new decimal(0), "singleitem", new decimal(0), "", out num9);
                    }
                    else
                    {
                        int num10 = (row1["LeavesPerPad"] == null ? 0 : Convert.ToInt32(row1["LeavesPerPad"]));
                        EstimatesBasePage.GetPrintSheetCalulation(num4, num8, num6, num7, Convert.ToDecimal(num10), "pad", new decimal(0), "", out num9);
                    }
                    Convert.ToDecimal(row1["PaperUnitPrice"]);
                    Convert.ToDecimal(row1["PaperWeight"]);
                    long num11 = (long)0;
                    long num12 = (long)0;
                    num11 = Convert.ToInt64(row1["PressID"]);
                    num12 = Convert.ToInt64(row1["GuillotineID"]);
                    if (this.ProfitTaxKey.ToLower() == "database")
                    {
                        if (i == 0)
                        {
                            Convert.ToDecimal(row1["PaperMarkup"]);
                            Convert.ToDecimal(row1["PressMarkUp"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp"]);
                        }
                        if (i == 1)
                        {
                            Convert.ToDecimal(row1["PaperMarkup2"]);
                            Convert.ToDecimal(row1["PressMarkUp2"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp2"]);
                        }
                        if (i == 2)
                        {
                            Convert.ToDecimal(row1["PaperMarkup3"]);
                            Convert.ToDecimal(row1["PressMarkUp3"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp3"]);
                        }
                        if (i == 3)
                        {
                            Convert.ToDecimal(row1["PaperMarkup4"]);
                            Convert.ToDecimal(row1["PressMarkUp4"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp4"]);
                        }
                    }
                    else if (string.Compare(this.EstType, "L", true) == 0)
                    {
                        EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "largepress", num11);
                        EstimatesBasePage.MarkupfromSettings_forinventoryitems(this.CompanyID, "largeguillotine", num12);
                    }
                    string str1 = row1["PressType"].ToString();
                    this.hdn_PressType.Value = str1;
                    string str2 = row1["Colour"].ToString();
                    string str3 = row1["SideColor"].ToString();
                    row1["PaperName"].ToString();
                    this.hdn_ZoneSideColor1.Value = str2;
                    this.hdn_ZoneSideColor2.Value = str3;
                    if (string.Compare(this.EstType, "L", true) != 0)
                    {
                        continue;
                    }
                    Convert.ToDecimal(row1["JobHeight"]);
                    Convert.ToDecimal(row1["JobWidth"]);
                    Convert.ToDecimal(row1["SheetHeight"]);
                    Convert.ToDecimal(row1["SheetWidth"]);
                    Convert.ToDecimal(row1["GutterHorizontal"]);
                    Convert.ToDecimal(row1["GutterVertical"]);
                    Convert.ToInt32(row1["Row"]);
                    Convert.ToInt32(row1["Col"]);
                    num12 = Convert.ToInt64(row1["GuillotineID"]);
                }
                this.plhItemCostView.Controls.Add(new LiteralControl("</table>"));
                this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
            }
        }

        protected void SPLLithoCostGenerate()
        {
            string empty = string.Empty;
            if (string.Compare(this.EstType, "n", true) == 0 || string.Compare(this.EstType, "k", true) == 0)
            {
                this.EstBookletSectionID = this.TypeID;
            }
            DataTable dataTable = EstimatesBasePage.estimate_qty_select(this.CompanyID, this.EstimateItemID, this.EstBookletSectionID);
            foreach (DataRow row in dataTable.Rows)
            {
                int num = Convert.ToInt32(row["qty1"]);
                int num1 = Convert.ToInt32(row["qty2"]);
                int num2 = Convert.ToInt32(row["qty3"]);
                int num3 = Convert.ToInt32(row["qty4"]);
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (num != 0)
                    {
                        empty = string.Concat(empty, num.ToString(), "»");
                    }
                    if (num1 != 0)
                    {
                        empty = string.Concat(empty, num1.ToString(), "»");
                    }
                    if (num2 != 0)
                    {
                        empty = string.Concat(empty, num2.ToString(), "»");
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    empty = string.Concat(empty, num3.ToString(), "»");
                }
                else
                {
                    if (num != 0)
                    {
                        empty = string.Concat(empty, num.ToString(), "»");
                    }
                    if (num1 != 0)
                    {
                        empty = string.Concat(empty, num1.ToString(), "»");
                    }
                    if (num2 != 0)
                    {
                        empty = string.Concat(empty, num2.ToString(), "»");
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    empty = string.Concat(empty, num3.ToString(), "»");
                }
            }
            if (string.Compare(this.module, "job", true) == 0 || string.Compare(this.module, "invoice", true) == 0)
            {
                foreach (DataRow dataRow in JobsBasePage.job_qty_select_by_qtynumber(this.CompanyID, this.EstimateItemID).Rows)
                {
                    empty = string.Concat(dataRow["Quantity"].ToString(), "»");
                }
            }
            string[] strArrays = new string[] { "0" };
            if (empty.Length > 0)
            {
                empty = empty.Substring(0, empty.Length - 1);
                strArrays = empty.Split(new char[] { '»' });
            }
            DataTable dataTable1 = new DataTable();
            if (string.Compare(this.EstType, "F", true) == 0)
            {
                dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.EstType, "D", true) == 0)
            {
                dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, this.EstimateItemID);
            }
            else if (string.Compare(this.EstType, "N", true) == 0)
            {
                dataTable1 = EstimatesBasePage.lithoncr_item_select_popup_paperpressinkguillotine(this.CompanyID, this.EstimateItemID, this.TypeID);
            }
            else if (string.Compare(this.EstType, "R", true) == 0)
            {
                dataTable1 = EstimatesBasePage.lithoncr_item_select_popup_paperpressinkguillotine(this.CompanyID, this.EstimateItemID, this.TypeID);
            }
            else if (string.Compare(this.EstType, "K", true) == 0)
            {
                dataTable1 = EstimatesBasePage.lithobooklet_item_select_popup_paperpressinkguillotine(this.CompanyID, this.EstimateItemID, this.TypeID);
            }
            int num4 = 0;
            for (int i = 0; i < (int)strArrays.Length && !string.IsNullOrEmpty(strArrays[i]); i++)
            {
                int num5 = Convert.ToInt32(strArrays[i]);
                long num6 = Convert.ToInt64(i);
                if (!string.IsNullOrEmpty(this.MarkupIdList))
                {
                    object[] markupIdList = new object[] { this.MarkupIdList, "±", this.EstimateItemID, "_", num6 };
                    this.MarkupIdList = string.Concat(markupIdList);
                }
                else
                {
                    this.MarkupIdList = string.Concat(this.EstimateItemID, "_", num6);
                }
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    this.EstCalculationID = Convert.ToInt64(row1["EstimateCalculationID"]);
                    decimal num7 = Convert.ToDecimal(row1["SetUpSpoilage"]);
                    decimal num8 = Convert.ToDecimal(row1["SetUpSpoilage"]);
                    decimal num9 = Convert.ToDecimal(row1["RunningSpoilage"]);
                    Convert.ToInt32(row1["PortraitValue"]);
                    Convert.ToInt32(row1["LandscapeValue"]);
                    row1["InventoryCode"].ToString();
                    string str = "";
                    int num10 = 0;
                    if (string.Compare(this.EstType, "K", true) != 0)
                    {
                        num4 = (row1["PrintLayout"].ToString() == "L" ? Convert.ToInt32(row1["LandScapeValue"]) : Convert.ToInt32(row1["PortraitValue"]));
                        decimal num11 = new decimal(0);
                        if (string.Compare(this.EstType, "D", true) == 0)
                        {
                            num10 = (row1["LeavesPerPad"] == null ? 0 : Convert.ToInt32(row1["LeavesPerPad"]));
                            EstimatesBasePage.GetPrintSheetCalulation(num5, num4, num7, num9, Convert.ToDecimal(num10), "pad", new decimal(0), "", out num11);
                        }
                        else if (string.Compare(this.EstType, "N", true) != 0)
                        {
                            EstimatesBasePage.GetPrintSheetCalulation(num5, num4, num7, num9, new decimal(0), "singleitem", new decimal(0), "", out num11);
                        }
                        else
                        {
                            Convert.ToDecimal(row1["NcrPartsPerSet"].ToString());
                            decimal num12 = Convert.ToDecimal(row1["NcrSetsPerPad"].ToString());
                            decimal num13 = num12;
                            EstimatesBasePage.GetPrintSheetCalulation(num5, num4, num8, num9, Convert.ToDecimal(num13), "ncr", new decimal(0), "", out num8);
                        }
                    }
                    else
                    {
                        num4 = Convert.ToInt32(row1["NoOfSignatures"]);
                        string str1 = (row1["NoOfSignatures"].ToString() == "" ? "0" : row1["NoOfSignatures"].ToString());
                        decimal num14 = num5 * Convert.ToDecimal(str1);
                        decimal num15 = (num14 * num9) / new decimal(100);
                        Convert.ToInt32(num14);
                        str = (string.Compare(row1["BookletFormat"].ToString(), "P", true) != 0 ? "L" : "P");
                        decimal num16 = new decimal(0);
                        EstimatesBasePage.GetPrintSheetCalulation(num5, new decimal(0), num8, num9, Convert.ToDecimal(str1), "booklet", new decimal(0), "", out num16);
                    }
                    Convert.ToDecimal(row1["PaperUnitPrice"]);
                    Convert.ToDecimal(row1["PaperWeight"]);
                    Convert.ToInt64(row1["PressID"]);
                    Convert.ToInt64(row1["GuillotineID"]);
                    if (this.ProfitTaxKey.ToLower() == "database")
                    {
                        if (i == 0)
                        {
                            Convert.ToDecimal(row1["PaperMarkup"]);
                            Convert.ToDecimal(row1["PressMarkUp"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp"]);
                        }
                        if (i == 1)
                        {
                            Convert.ToDecimal(row1["PaperMarkup2"]);
                            Convert.ToDecimal(row1["PressMarkUp2"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp2"]);
                        }
                        if (i == 2)
                        {
                            Convert.ToDecimal(row1["PaperMarkup3"]);
                            Convert.ToDecimal(row1["PressMarkUp3"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp3"]);
                        }
                        if (i == 3)
                        {
                            Convert.ToDecimal(row1["PaperMarkup4"]);
                            Convert.ToDecimal(row1["PressMarkUp4"]);
                            Convert.ToDecimal(row1["GuillotineMarkUp4"]);
                        }
                    }
                    row1["PressType"].ToString();
                    row1["PaperName"].ToString();
                    if (string.Compare(this.EstType, "L", true) != 0)
                    {
                        continue;
                    }
                    Convert.ToDecimal(row1["JobHeight"]);
                    Convert.ToDecimal(row1["JobWidth"]);
                    Convert.ToDecimal(row1["SheetHeight"]);
                    Convert.ToDecimal(row1["SheetWidth"]);
                    Convert.ToDecimal(row1["GutterHorizontal"]);
                    Convert.ToDecimal(row1["GutterVertical"]);
                    Convert.ToInt32(row1["Row"]);
                    Convert.ToInt32(row1["Col"]);
                }
            }
            this.plhItemCostView.Controls.Add(new LiteralControl("</table>"));
            this.plhItemCostView.Controls.Add(new LiteralControl("</div>"));
        }
    }
}