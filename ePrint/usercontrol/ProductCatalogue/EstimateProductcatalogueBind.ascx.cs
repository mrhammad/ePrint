using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ePrint.settings;
using System.Linq;
using System.Configuration;

namespace ePrint.usercontrol.ProductCatalogue
{
    public partial class EstimateProductcatalogueBind : System.Web.UI.UserControl
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private BaseClass ObjClass = new BaseClass();

        public int CustID;

        public int CustomerID;

        public static int Customer_ID;

        public string ClearFilter = string.Empty;

        private commonClass commclass = new commonClass();

        public BaseClass objBase = new BaseClass();

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public long jobID;

        public long InvoiceID;

        public long EstimateItemID;

        public long EstSingleItemID;

        public long EstPadItemID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        private string CatalogueProfit = string.Empty;

        private string CatalogueTax = string.Empty;

        public long PressID;

        public int PageSize = 1000000;

        public int ClientID;

        public string companytype = string.Empty;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        private commonClass objJava = new commonClass();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public string modulename = "estimates";

        public string submodulename = "estimate";

        public string Pub_CustomerID = "0";

        public string Pub_CustomerName = "";

        public string EstTypeFromSP = string.Empty;

        private long ParentItemID;

        private string ParentItemType = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string subedit = string.Empty;

        public long EstimateBookletItemID;

        public decimal defaultvalue;

        public string frmcopyitem = string.Empty;

        public string MainType = string.Empty;

        public string SimpleMatBrowserHandy = "no";

        public bool Check_SpecialPrivilege;

        public static int IsBackOrder;

        private Label txt_lblItemtitle = new Label();

        private Label txt_lblDescription = new Label();

        private Label txt_lblArtwork = new Label();

        private Label txt_lblColour = new Label();

        private Label txt_lblSize = new Label();

        private Label txt_lblMaterial = new Label();

        private Label txt_lblDelivery = new Label();

        private Label txt_lblFinishing = new Label();

        private Label txt_lblProofs = new Label();

        private Label txt_lblPacking = new Label();

        private Label txt_lblNotes = new Label();

        private Label txt_lblInstructions = new Label();

        private Label lblCustomDiscription1 = new Label();

        private Label lblCustomDiscription2 = new Label();

        private Label lblCustomDiscription3 = new Label();

        private Label lblCustomDiscription4 = new Label();

        private Label lblCustomDiscription5 = new Label();

        private Label lblCustomDiscription6 = new Label();

        private Label lblCustomDiscription7 = new Label();

        private Label lblCustomDiscription8 = new Label();

        private Label lblCustomDiscription9 = new Label();

        private Label lblCustomDiscription10 = new Label();

        private Label lblCustomDiscription11 = new Label();

        private Label lblCustomDiscription12 = new Label();

        private Label lblCustomDiscription13 = new Label();

        private Label lblCustomDiscription14 = new Label();

        private Label lblCustomDiscription15 = new Label();

        private Label lblCustomDiscription16 = new Label();

        private Label lblCustomDiscription17 = new Label();

        private Label lblCustomDiscription18 = new Label();

        private Label lblCustomDiscription19 = new Label();

        private Label lblCustomDiscription20 = new Label();

        private Label lblCustomDiscription21 = new Label();

        private Label lblCustomDiscription22 = new Label();

        private Label lblCustomDiscription23 = new Label();

        private Label lblCustomDiscription24 = new Label();

        private Label lblCustomDiscription25 = new Label();

        public int IsDirectJob;

        private int IsForInvoice;

        public string Webstore = string.Empty;

        public string MainCalculationtype = string.Empty;

        public string OtherCostName = string.Empty;

        public long OrderID;

        public long OrderItemID;

        public int OrderAddItemsCount;

        public string inittotal = string.Empty;

        private string WareItemDesc = string.Empty;

        private string itemtitle = string.Empty;

        private string itemdesc = string.Empty;

        private string itemartwork = string.Empty;

        private string itemcolor = string.Empty;

        private string itemsize = string.Empty;

        private string itemmaterial = string.Empty;

        private string itemdelivery = string.Empty;

        private string itemfinishing = string.Empty;

        private string itemnotes = string.Empty;

        private string itemterms = string.Empty;

        private string itemproofs = string.Empty;

        private string itempacking = string.Empty;

        public long EstimateAdditionalItemID;

        public string CalculationType = string.Empty;

        public long SelectedID;

        public string SelectedValue = string.Empty;

        public decimal MarkupPercentage1;

        public decimal MarkupPercentage2;

        public decimal MarkupPercentage3;

        public decimal MarkupPercentage4;

        public decimal CostPrice1;

        public decimal CostPrice2;

        public decimal CostPrice3;

        public decimal CostPrice4;

        public decimal MarkupValue1;

        public decimal MarkupValue2;

        public decimal MarkupValue3;

        public decimal MarkupValue4;

        public int SortOrderNo;

        public decimal SelectedPrice1;

        public decimal SelectedPrice2;

        public decimal SelectedPrice3;

        public decimal SelectedPrice4;

        public string EstimateOtherCostName = string.Empty;

        public long OthercostID;

        public string Formula = string.Empty;

        public decimal MarkUp;

        public decimal TotalPrice;

        public decimal MarkUpValue;

        public decimal SelectedPrice;

        public decimal TotalPriceExMarkup1;

        public decimal TotalPriceExMarkup2;

        public decimal TotalPriceExMarkup3;

        public decimal TotalPriceExMarkup4;

        public decimal TotalPriceIncMarkup1;

        public decimal TotalPriceIncMarkup2;

        public decimal TotalPriceIncMarkup3;

        public decimal TotalPriceIncMarkup4;

        public long WebOtherCostID;

        public int MainItemQuantity;

        public string ProductName = string.Empty;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public languageClass objLanguage = new languageClass();

        public string Alert_Msg = string.Empty;

        public static long PriceCatalogueID;

        public string frm = string.Empty;

        public int RoundOff;

        public string Measurementvalue = string.Empty;

        public string Measurementvalue_Sq = string.Empty;

        public string CustomDiscription1 = "style='display:none'";

        public string CustomDiscription2 = "style='display:none'";

        public string CustomDiscription3 = "style='display:none'";

        public string CustomDiscription4 = "style='display:none'";

        public string CustomDiscription5 = "style='display:none'";

        public string CustomDiscription6 = "style='display:none'";

        public string CustomDiscription7 = "style='display:none'";

        public string CustomDiscription8 = "style='display:none'";

        public string CustomDiscription9 = "style='display:none'";

        public string CustomDiscription10 = "style='display:none'";

        public string CustomDiscription11 = "style='display:none'";

        public string CustomDiscription12 = "style='display:none'";

        public string CustomDiscription13 = "style='display:none'";

        public string CustomDiscription14 = "style='display:none'";

        public string CustomDiscription15 = "style='display:none'";

        public string CustomDiscription16 = "style='display:none'";

        public string CustomDiscription17 = "style='display:none'";

        public string CustomDiscription18 = "style='display:none'";

        public string CustomDiscription19 = "style='display:none'";

        public string CustomDiscription20 = "style='display:none'";

        public string CustomDiscription21 = "style='display:none'";

        public string CustomDiscription22 = "style='display:none'";

        public string CustomDiscription23 = "style='display:none'";

        public string CustomDiscription24 = "style='display:none'";

        public string CustomDiscription25 = "style='display:none'";

        public string Description = "style='display:none'";

        public string Artwork = "style='display:none'";

        public string Color = "style='display:none'";

        public string Size = "style='display:none'";

        public string Material = "style='display:none'";

        public string Delivery = "style='display:none'";

        public string Finishing = "style='display:none'";

        public string Proof = "style='display:none'";

        public string Pack = "style='display:none'";

        public string Note = "style='display:none'";

        public string Instruction = "style='display:none'";

        private string CustDisc1 = string.Empty;

        private string CustDisc2 = string.Empty;

        private string CustDisc3 = string.Empty;

        private string CustDisc4 = string.Empty;

        private string CustDisc5 = string.Empty;

        private string CustDisc6 = string.Empty;

        private string CustDisc7 = string.Empty;

        private string CustDisc8 = string.Empty;

        private string CustDisc9 = string.Empty;

        private string CustDisc10 = string.Empty;

        private string CustDisc11 = string.Empty;

        private string CustDisc12 = string.Empty;

        private string CustDisc13 = string.Empty;

        private string CustDisc14 = string.Empty;

        private string CustDisc15 = string.Empty;

        private string CustDisc16 = string.Empty;

        private string CustDisc17 = string.Empty;

        private string CustDisc18 = string.Empty;

        private string CustDisc19 = string.Empty;

        private string CustDisc20 = string.Empty;

        private string CustDisc21 = string.Empty;

        private string CustDisc22 = string.Empty;

        private string CustDisc23 = string.Empty;

        private string CustDisc24 = string.Empty;

        private string CustDisc25 = string.Empty;

        public string ProductCataDesc = string.Empty;

        public string Quantity1 = string.Empty;

        public string Quantity2 = string.Empty;

        public string Quantity3 = string.Empty;

        public string Quantity4 = string.Empty;

        public string QtyusedforCalculation1 = string.Empty;

        public string QtyusedforCalculation2 = string.Empty;

        public string QtyusedforCalculation3 = string.Empty;

        public string QtyusedforCalculation4 = string.Empty;

        public string Width1 = string.Empty;

        public string Width2 = string.Empty;

        public string Width3 = string.Empty;

        public string Width4 = string.Empty;

        public string Height1 = string.Empty;

        public string Height2 = string.Empty;

        public string Height3 = string.Empty;

        public string Height4 = string.Empty;

        public string MultipleOf = string.Empty;

        public int Noofi;

        public string MatrixType = string.Empty;

        public int IsStockItem;

        public int QtyNumber;

        private bool IsStockReplenishItem;

        private bool IsStockReplenished;

        private string firstQtydis = "display:none;";

        private string SecQtydis = "display:none;";

        private string ThirdQtydis = "display:none;";

        private string ForthQtydis = "display:none;";

        public string ModuleType = string.Empty;

        private string firstQtydis_ = "visibility: hidden;";

        private string SecQtydis_ = "visibility: hidden;";

        private string ThirdQtydis_ = "visibility: hidden;";

        private string ForthQtydis_ = "visibility: hidden;";

        public decimal MaxQuantity;

        private SummaryClass SummaryClassObj = new SummaryClass();

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

        public bool Decoration1_Mandadory;
        public bool Decoration2_Mandadory;
        public bool Decoration3_Mandadory;
        public bool Decoration4_Mandadory;
        public bool Decoration5_Mandadory;
        public bool Decoration6_Mandadory;

        public string name1;
        public string name2;
        public string name3;
        public string name4;
        public string name5;
        public string name6;

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

        static EstimateProductcatalogueBind()
        {
            EstimateProductcatalogueBind.Customer_ID = -1;
            EstimateProductcatalogueBind.IsBackOrder = 0;
            EstimateProductcatalogueBind.ManageStockPermission = 0;
            EstimateProductcatalogueBind.PriceCatalogueID = (long)0;
        }

        public EstimateProductcatalogueBind()
        {
        }

        public void BindOtherMultipleDropdownList(long PriceCatalogueID)
        {
            DataTable dataTable = EstimateBasePage.OtherMultiple_product_Select(this.CompanyID, PriceCatalogueID);
            this.ddlOtherMultiple.DataSource = dataTable;
            this.ddlOtherMultiple.DataTextField = "CatalogueName";
            this.ddlOtherMultiple.DataValueField = "PriceCatalogueID";
            this.ddlOtherMultiple.DataBind();
        }

        public void BindOtherMultipleDropdownList1(long PriceCatalogueID)
        {
            DataTable dataTable = EstimateBasePage.OtherMultiple_product_Select(this.CompanyID, PriceCatalogueID);
            this.ddlOtherMultiple1.DataSource = dataTable;
            this.ddlOtherMultiple1.DataTextField = "CatalogueName";
            this.ddlOtherMultiple1.DataValueField = "PriceCatalogueID";
            this.ddlOtherMultiple1.DataBind();
        }

        public void BindOtherMultipleDropdownList2(long PriceCatalogueID)
        {
            DataTable dataTable = EstimateBasePage.OtherMultiple_product_Select(this.CompanyID, PriceCatalogueID);
            this.ddlOtherMultiple2.DataSource = dataTable;
            this.ddlOtherMultiple2.DataTextField = "CatalogueName";
            this.ddlOtherMultiple2.DataValueField = "PriceCatalogueID";
            this.ddlOtherMultiple2.DataBind();
        }
        public void BindProductDetails(long PriceCatalogueID, char Drawstockfrom)
        {
            string[] languageConversion;
            object[] str;
            DataTable dataTable = SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID);
            this.plhquantity.Controls.Clear();
            this.plhCatalogueList.Controls.Clear();
            this.pnlCatalogue.Style.Add("display", "block");
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='center' style='width:100%;margin-top:-4px'>"));
            DataTable dataTable1 = EstimateBasePage.price_catalogue_select_by_id(this.CompanyID, PriceCatalogueID, Drawstockfrom);
            if (dataTable1.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Norowsalert();", true);
                return;
            }
            this.hdn_SoldInPacksof.Value = dataTable1.Rows[0]["SoldInPacksof"].ToString();
            this.hdn_IsCumulative.Value = dataTable1.Rows[0]["IsCumulativePricing"].ToString().ToLower();
            EstimateProductcatalogueBind.IsBackOrder = Convert.ToInt32(dataTable1.Rows[0]["IsBackOrder"]);
            this.hdn_isbackorder.Value = EstimateProductcatalogueBind.IsBackOrder.ToString();
            this.hdn_drawstockfrom.Value = dataTable1.Rows[0]["DrawStockFrom"].ToString();
            DataTable dataTable2 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            HiddenField hdnStockManagement = this.hdn_StockManagement;
            int num = Convert.ToInt32(dataTable2.Rows[0]["ProductStockManagement"]);
            hdnStockManagement.Value = num.ToString();
            HiddenField hdnKitavailibility = this.hdn_kitavailibility;
            num = this.objBase.Check_MaxKit_Availability(PriceCatalogueID, 0);
            hdnKitavailibility.Value = num.ToString();
            int num1 = 0;
            string empty = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            StringBuilder stringBuilder4 = new StringBuilder();
            stringBuilder.Append("<option value='select'>select</option>");
            stringBuilder1.Append("<option value='select'>select</option>");
            stringBuilder2.Append("<option value='select'>select</option>");
            stringBuilder3.Append("<option value='select'>select</option>");
            stringBuilder4.Append("<option value='select'>select</option>");
            string str1 = "block";
            str1 = (!this.Check_SpecialPrivilege ? "block" : "none");
            string empty1 = string.Empty;
            foreach (DataRow row in dataTable1.Rows)
            {
                this.hdnUnitOfMeasure.Value = row["UnitOfMeasure"].ToString();
                this.IsStockItem = Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]);
                if (!Convert.ToBoolean(row["IsSides"]))
                {
                    empty1 = "none";
                    this.hid_IsSides.Value = "0";
                }
                else
                {
                    empty1 = "block";
                    this.hid_IsSides.Value = "1";
                }
                empty = row["CatalogueName"].ToString();
                this.MatrixType = row["MatrixType"].ToString();
                string str2 = "#F2F2F2";
                if (num1 % 2 == 0)
                {
                    str2 = "#FFFFFF";
                }
                if (num1 == 0)
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='padding: 2px;width: 100%;' >"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float: left;width: 45%;overflow: hidden; overflow-y: scroll; height:450px;'>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblItemtitle.Text, "</div>")));
                        try
                        {
                            if (base.Request.Params["FromAddAnItem"] == null)
                            {
                                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><textarea id='txtcatalogue_item_title' rows='2' cols='15' class='textboxnew' onblur='Copy_ItemTitle_Price(this.value);' class='textboxnew'  style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["ItemTitle"].ToString()).Replace("\r\n", "<br/>"), "</textarea></div>")));
                            }
                            else
                            {
                                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><textarea id='txtcatalogue_item_title'  rows='2' cols='15' class='textboxnew' onblur='Copy_ItemTitle_Price(this.value);' class='textboxnew'  style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["ItemTitle"].ToString()).Replace("\r\n", "<br/>"), "</textarea></div>")));
                            }
                        }
                        catch
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><textarea id='txtcatalogue_item_title'  rows='2' cols='15' class='textboxnew' onblur='Copy_ItemTitle_Price(this.value);' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["ItemTitle"].ToString()).Replace("\r\n", "<br/>"), "</textarea></div>")));
                        }
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Description, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblDescription.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_design' rows='2' cols='15' class='textboxnew' onblur=Copy_Description_Price(this.value);  style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Description"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Artwork, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblArtwork.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_art' rows='2' cols='15' onblur=Copy_Artwork_Price(this.value); class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Artwork"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Color, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblColour.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_color' rows='2' cols='15' onblur=Copy_Color_Price(this.value); class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Color"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Size, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblSize.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_size' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Size"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Material, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblMaterial.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_material' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Material"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Delivery, " >")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblDelivery.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_delivery' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Delivery"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Finishing, " >")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblFinishing.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_finishing' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Finishing"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Proof, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblProofs.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_Proofs' rows='2' cols='15'  class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Proofs"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Pack, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblPacking.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_Packing' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Packing"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Note, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblNotes.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_notes' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Notes"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Instruction, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;overflow:hidden;'>", this.txt_lblInstructions.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_terms' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["Instructions"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription1, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription1.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription1' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription1"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription2, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription2.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription2' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription2"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription3, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription3.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription3' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription3"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription4, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription4.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription4' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription4"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription5, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription5.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription5' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription5"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription6, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription6.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription6' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription6"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription7, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription7.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription7' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription7"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription8, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription8.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription8' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription8"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription9, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription9.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription9' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription9"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription10, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription10.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription10' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription10"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription11, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription11.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription11' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription11"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription12, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription12.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription12' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription12"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription13, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription13.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription13' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription13"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription14, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription14.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription14' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription14"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription15, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription15.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription15' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription15"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription16, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription16.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription16' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription16"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription17, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription17.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription17' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription17"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription18, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription18.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription18' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription18"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription19, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription19.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription19' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription19"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription20, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription20.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription20' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription20"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription21, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription21.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription21' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription21"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription22, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription22.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription22' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription22"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription23, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription23.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription23' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription23"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription24, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription24.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription24' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription24"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription25, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription25.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription25' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(row["CustomDescription25"].ToString()), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        languageClass _languageClass = new languageClass();
                        commonClass _commonClass = new commonClass();
                        SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)this.CompanyID), new SqlParameter("@EstimateItemID", (object)this.EstimateItemID) };
                        DataSet dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_View", sqlParameter);
                        for (int i = 0; i < dataSet.Tables[2].Rows.Count; i++)
                        {
                            if (this.txt_lblItemtitle.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemtitle = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblDescription.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemdesc = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblArtwork.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemartwork = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblColour.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemcolor = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblSize.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemsize = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblMaterial.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemmaterial = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblDelivery.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemdelivery = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblFinishing.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemfinishing = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblProofs.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemnotes = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblPacking.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itempacking = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblNotes.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemproofs = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.txt_lblInstructions.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.itemterms = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription1.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc1 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription2.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc2 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription3.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc3 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription4.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc4 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription5.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc5 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription6.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc6 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription7.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc7 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription8.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc8 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription9.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc9 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription10.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc10 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription11.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc11 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription12.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc12 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription13.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc13 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription14.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc14 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription15.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc15 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription16.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc16 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription17.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc17 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription18.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc18 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription19.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc19 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription20.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc20 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription21.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc21 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription22.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc22 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription23.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc23 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription24.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc24 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                            if (this.lblCustomDiscription25.Text == dataSet.Tables[2].Rows[i]["ItemLabel"].ToString())
                            {
                                this.CustDisc25 = dataSet.Tables[2].Rows[i]["ItemValue"].ToString();
                            }
                        }
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='padding: 2px;width: 100%;' >"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float: left;width: 45%;overflow: hidden; overflow-y: scroll; height:450px;'>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblItemtitle.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><textarea id='txtcatalogue_item_title' rows='2' cols='15' onblur='Copy_ItemTitle_Price(this.value);'  class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemtitle).Replace("<br/>", "\n"), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Description, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblDescription.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_design' rows='2' cols='15' class='textboxnew' onblur=Copy_Description_Price(this.value);  style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemdesc), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Artwork, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblArtwork.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_art' rows='2' cols='15' onblur=Copy_Artwork_Price(this.value); class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemartwork), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Color, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblColour.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_color' rows='2' cols='15' onblur=Copy_Color_Price(this.value); class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemcolor), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Size, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblSize.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_size' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemsize), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Material, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblMaterial.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_material' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemmaterial), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Delivery, " >")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblDelivery.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_delivery' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemdelivery), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Finishing, " >")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblFinishing.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_finishing' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemfinishing), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Proof, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblProofs.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_Proofs' rows='2' cols='15'  class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemproofs), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Pack, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblPacking.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_Packing' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itempacking), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.Note, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.txt_lblNotes.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_notes' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemnotes), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.Instruction, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;overflow:hidden;'>", this.txt_lblInstructions.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_terms' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.itemterms), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription1, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription1.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription1' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc1), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription2, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription2.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription2' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc2), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription3, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription3.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription3' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc3), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' ", this.CustomDiscription4, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription4.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription4' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc4), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription5, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription5.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription5' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc5), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription6, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription6.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription6' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc6), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription7, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription7.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription7' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc7), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription8, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription8.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription8' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc8), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription9, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription9.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription9' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc9), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription10, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription10.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription10' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc10), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription11, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription11.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription11' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc11), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription12, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription12.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription12' rows='2' cols='15' class='textboxnew'style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc12), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription13, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription13.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription13' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc13), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription14, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription14.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription14' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc14), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription15, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription15.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription15' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc15), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription16, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription16.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription16' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc16), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription17, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription17.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription17' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc17), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription18, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription18.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription18' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc18), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription19, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription19.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription19' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc19), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription20, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription20.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription20' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc20), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription21, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription21.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription21' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc21), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription22, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription22.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription22' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc22), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription23, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription23.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription23' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc23), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription24, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 8%;width:27%;'>", this.lblCustomDiscription24.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription24' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc24), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left'", this.CustomDiscription25, ">")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 5%;width:27%;'>", this.lblCustomDiscription25.Text, "</div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtCustomDiscription25' rows='2' cols='15' class='textboxnew' style='width:98%;height: 7%;'>", this.objBase.SpecialDecode(this.CustDisc25), "</textarea></div>")));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;width:54%;'>"));
                    if (base.Session["productstockmanagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
                    {
                        string lower = row["DrawStockFrom"].ToString().ToLower();
                        if (lower == "s" || lower == "o" || lower == "a")
                        {
                            DataTable dataTable3 = WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, Convert.ToInt32(PriceCatalogueID));
                            if (dataTable3.Rows.Count > 0)
                            {
                                StringBuilder stringBuilder5 = new StringBuilder();
                                stringBuilder5.Append("<fieldset style='margin-left:-1px'>");
                                stringBuilder5.Append(string.Concat("<legend>", this.objLanguage.GetLanguageConversion("Current_Stock_Levels"), "</legend>"));
                                if (lower == "o")
                                {
                                    stringBuilder5.Append("<table style='width:30%;border-collapse: collapse; border: 1px solid #CCCCCC'>");
                                }
                                else
                                {
                                    stringBuilder5.Append("<table style='width:90%;border-collapse: collapse; border: 1px solid #CCCCCC'>");
                                }
                                stringBuilder5.Append("<tr style='background-color: #DDDDDD; height: 18px;'>");
                                if (lower != "o")
                                {
                                    stringBuilder5.Append("<td>");
                                    stringBuilder5.Append("Current Stock");
                                    stringBuilder5.Append("</td>");
                                    stringBuilder5.Append("<td>");
                                    stringBuilder5.Append("Allocated Stock");
                                    stringBuilder5.Append("</td>");
                                    stringBuilder5.Append("<td>");
                                    stringBuilder5.Append("Production Quantity");
                                    stringBuilder5.Append("</td>");
                                }
                                stringBuilder5.Append("<td>");
                                stringBuilder5.Append("Available Stock");
                                stringBuilder5.Append("</td>");
                                string empty2 = string.Empty;
                                string empty3 = string.Empty;
                                if (lower != "o")
                                {
                                    empty2 = dataTable3.Rows[0]["TotalQuantity"].ToString();
                                    empty3 = dataTable3.Rows[0]["AvailableQuantity"].ToString();
                                }
                                else
                                {
                                    int num2 = (new BaseClass()).Check_MaxKit_Availability(PriceCatalogueID, 0);
                                    empty3 = num2.ToString();
                                }
                                stringBuilder5.Append("</tr>");
                                stringBuilder5.Append("<tr style='background-color: #EFEFEF'>");
                                if (lower != "o")
                                {
                                    stringBuilder5.Append("<td>");
                                    stringBuilder5.Append(string.Concat("<input id='txtcurrentstock' type='text' disabled='disable' style='width:125px' value='", empty2, "' class='textboxnew'/>"));
                                    stringBuilder5.Append("</td>");
                                    stringBuilder5.Append("<td>");
                                    stringBuilder5.Append(string.Concat("<input id='txtallocatedstock' type='text'  disabled='disable' style='width:125px;' value='", dataTable3.Rows[0]["AllocatedQuantity"], "' class='textboxnew'/>"));
                                    stringBuilder5.Append("</td>");
                                    stringBuilder5.Append("<td>");
                                    num = Convert.ToInt32(dataTable3.Rows[0]["ProductionQuantity"]);
                                    stringBuilder5.Append(string.Concat("<input id='txtproductionquantity' type='text'  disabled='disable' style='width:125px' value='", num.ToString(), "' class='textboxnew />'"));
                                    stringBuilder5.Append("</td>");
                                }
                                stringBuilder5.Append("<td>");
                                stringBuilder5.Append(string.Concat("<input id='txtavailablestock' type='text'  disabled='disable' style='width:125px' value='", empty3, "' class='textboxnew' />"));
                                stringBuilder5.Append("</td>");
                                stringBuilder5.Append("</tr>");
                                stringBuilder5.Append("</table>");
                                stringBuilder5.Append("</fieldset>");
                                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                            }
                        }
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='border:solid 1px silver;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='height:24px;padding-top:6px;width:100%padding:2px;background-image: url(../images/bg-gradient.png); background-repeat: repeat;font-weight:bold; border-bottom:1px solid silver'>"));
                    if (this.MatrixType == "P")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:25%;float:left;text-align:center;'>Quantity</div>"));
                        ControlCollection controls = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Cost_For_1"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                        controls.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controlCollections = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Markup"), "(%)</div>" };
                        controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controls1 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:29%;float:left;text-align:right;'>", this.objLanguage.GetLanguageConversion("Selling_Price"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                        controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    else if (this.MatrixType == "G")
                    {
                        ControlCollection controlCollections1 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:31%;float:left;text-align:center;'>From (", this.Measurementvalue_Sq, ") -To (", this.Measurementvalue_Sq, ")</div>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controls2 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:25%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Cost_Price"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), "/", this.Measurementvalue_Sq, ")</div>" };
                        controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controlCollections2 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:15%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Markup"), " (%)</div>" };
                        controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controls3 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:28%;float:left;text-align:right;'>", this.objLanguage.GetLanguageConversion("Selling_Price"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), "/", this.Measurementvalue_Sq, ")</div>" };
                        controls3.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    else if (this.MatrixType == "S")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:25%;float:left;text-align:center;'>Quantity</div>"));
                        ControlCollection controlCollections3 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:20%;float:left;padding-left:4px;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Cost"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controls4 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Markup"), "(%)</div>" };
                        controls4.Add(new LiteralControl(string.Concat(languageConversion)));
                        ControlCollection controlCollections4 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:29%;float:left;text-align:right;'>", this.objLanguage.GetLanguageConversion("Selling_Price"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                        controlCollections4.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='height:218px;overflow-y:scroll;border:0px solid'><div>"));
                }
                if (row["ToQuantity"] == "")
                    row["ToQuantity"] = 0;
                if (row["FromQuantity"] == "")
                    row["FromQuantity"] = 0;
                string str3 = Convert.ToDecimal(row["ToQuantity"]).ToString("0.##");
                if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                {
                    str = new object[] { "<option value='", num1, "'>", str3, "</option>" };
                    stringBuilder.Append(string.Concat(str));
                }
                else
                {
                    if (this.Quantity1.ToString() != str3)
                    {
                        str = new object[] { "<option value='", num1, "'>", str3, "</option>" };
                        stringBuilder1.Append(string.Concat(str));
                    }
                    else
                    {
                        str = new object[] { "<option value='", num1, "'selected='selected'>", this.Quantity1.ToString(), "</option>" };
                        stringBuilder1.Append(string.Concat(str));
                    }
                    if (this.Quantity2.ToString() != str3)
                    {
                        str = new object[] { "<option value='", num1, "'>", str3, "</option>" };
                        stringBuilder2.Append(string.Concat(str));
                    }
                    else
                    {
                        str = new object[] { "<option value='", num1, "'selected='selected'>", this.Quantity2.ToString(), "</option>" };
                        stringBuilder2.Append(string.Concat(str));
                    }
                    if (this.Quantity3.ToString() != str3)
                    {
                        str = new object[] { "<option value='", num1, "'>", str3, "</option>" };
                        stringBuilder3.Append(string.Concat(str));
                    }
                    else
                    {
                        str = new object[] { "<option value='", num1, "'selected='selected'>", this.Quantity3.ToString(), "</option>" };
                        stringBuilder3.Append(string.Concat(str));
                    }
                    if (this.Quantity4.ToString() != str3)
                    {
                        str = new object[] { "<option value='", num1, "'>", str3, "</option>" };
                        stringBuilder4.Append(string.Concat(str));
                    }
                    else
                    {
                        str = new object[] { "<option value='", num1, "'selected='selected'>", this.Quantity4.ToString(), "</option>" };
                        stringBuilder4.Append(string.Concat(str));
                    }
                }
                string str4 = "17%";
                string str5 = "30%";
                string str6 = "20%";
                string str7 = "29%";
                if (this.MatrixType == "G")
                {
                    str4 = "35%";
                    str5 = "20%";
                    str6 = "15%";
                    str7 = "29%";
                }
                if (this.MatrixType == "P")
                {
                    str4 = "17%";
                    str5 = "29%";
                    str6 = "20%";
                    str7 = "29%";
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='center' style='height:20px;width:99%padding:2px;background-color:", str2, "' class='onlyEmpty'>")));
                if (this.MatrixType != "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div style='width:", str4, ";float:left;text-align:right;'>")));
                }
                else
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div style='width:", str4, ";float:left;'>")));
                }
                if (this.MatrixType == "P")
                {
                    ControlCollection controls5 = this.plhCatalogueList.Controls;
                    str = new object[] { "<span id='spn_FromQty_", num1, "'>", Convert.ToDecimal(row["FromQuantity"]).ToString("0.##"), "</span> - " };
                    controls5.Add(new LiteralControl(string.Concat(str)));
                }
                else if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:80px;float:left;text-align:right;'>"));
                    ControlCollection controlCollections5 = this.plhCatalogueList.Controls;
                    str = new object[] { "<span id='spn_FromQty_", num1, "'>", Convert.ToDecimal(row["FromQuantity"]).ToString("0.##"), "</span>" };
                    controlCollections5.Add(new LiteralControl(string.Concat(str)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:40px;float:left;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<span>-</span>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:50px;float:left;text-align:right;'>"));
                    ControlCollection controls6 = this.plhCatalogueList.Controls;
                    str = new object[] { "<span id='spn_ToQty_", num1, "'>", Convert.ToDecimal(row["ToQuantity"]).ToString("0.##"), "</span></div>" };
                    controls6.Add(new LiteralControl(string.Concat(str)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                if (this.MatrixType != "G")
                {
                    ControlCollection controlCollections6 = this.plhCatalogueList.Controls;
                    str = new object[] { "<span id='spn_FromQty_", num1, "' style='display:none;'>", Convert.ToDecimal(row["FromQuantity"]).ToString("0.##"), "</span>" };
                    controlCollections6.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controls7 = this.plhCatalogueList.Controls;
                    str = new object[] { "<span id='spn_ToQty_", num1, "'>", Convert.ToDecimal(row["ToQuantity"]).ToString("0.##"), "</span></div>" };
                    controls7.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controlCollections7 = this.plhCatalogueList.Controls;
                    str = new object[] { "<div style='width:", str5, ";float:left;text-align:right;display: ", str1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Price"].ToString()), 6, "", false, false, true), "<span id='spn_price_", num1, "' style='display:none;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Price"].ToString()), 6, "", false, false, true), "</span></div>" };
                    controlCollections7.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controls8 = this.plhCatalogueList.Controls;
                    str = new object[] { "<div style='width:", str6, ";float:left;padding-left:4px;text-align:right;display: ", str1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 6, "", false, false, true), "<span id='spn_markup_", num1, "' style='display:none;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 6, "", false, false, true), "</span></div>" };
                    controls8.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controlCollections8 = this.plhCatalogueList.Controls;
                    str = new object[] { "<div style='width:", str7, ";float:left;text-align:right;'><span id='spn_SellingPrice_", num1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["sellingPrice"].ToString()), 6, "", false, false, true), "</span></div>" };
                    controlCollections8.Add(new LiteralControl(string.Concat(str)));
                }
                else
                {
                    ControlCollection controls9 = this.plhCatalogueList.Controls;
                    str = new object[] { "<div style='width:", str5, ";float:left;text-align:right;display: ", str1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Price"].ToString()), 6, "", false, false, true), "<span id='spn_price_", num1, "' style='display:none;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Price"].ToString()), 6, "", false, false, true), "</span></div>" };
                    controls9.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controlCollections9 = this.plhCatalogueList.Controls;
                    str = new object[] { "<div style='width:", str6, ";float:left;text-align:right;display: ", str1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 6, "", false, false, true), "<span id='spn_markup_", num1, "' style='display:none;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 6, "", false, false, true), "</span></div>" };
                    controlCollections9.Add(new LiteralControl(string.Concat(str)));
                    ControlCollection controls10 = this.plhCatalogueList.Controls;
                    str = new object[] { "<div style='width:", str7, ";float:left;text-align:right;'><span id='spn_SellingPrice_", num1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["sellingPrice"].ToString()), 6, "", false, false, true), "</span></div>" };
                    controls10.Add(new LiteralControl(string.Concat(str)));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                num1++;
                this.MaxQuantity = Convert.ToDecimal(row["ToQuantity"].ToString());
                this.Noofi = num1;
            }
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='bgLabel' style='width:23%;'>Quantity</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;padding-bottom: 0px;'> "));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
            string str8 = ";";
            if (this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "job")
            {
                str8 = ";display:none;";
            }
            else if (this.modulename == "orders")
            {
                str8 = ";display:none;";
            }
            else if (this.modulename == "invoice" && this.IsForInvoice == 1 || this.modulename == "invoice" && this.IsDirectJob == 1)
            {
                str8 = ";display:none;";
            }
            DataTable dataTable4 = new DataTable();
            dataTable4 = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, (long)0, this.EstimateItemID, this.modulename);
            if (dataTable4.Rows.Count > 0)
            {
                this.IsStockReplenishItem = Convert.ToBoolean(dataTable4.Rows[0]["IsStockReplenishItem"]);
                this.IsStockReplenished = Convert.ToBoolean(dataTable4.Rows[0]["IsStockReplenished"]);
            }
            string str9 = "none";
            string str10 = "block";
            string str11 = "none";
            if (!ConnectionClass.IsHandy)
            {
                str9 = "none";
                str10 = "block";
                str11 = "block";
            }
            else
            {
                str9 = "block";
                str10 = "none";
                str11 = "none";
            }
            if (this.ParentEstimateItemID > (long)0 && (this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice"))
            {
                HttpBrowserCapabilities browser = base.Request.Browser;
                foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                {
                    this.QtyNumber = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    this.hdnQtyNumber.Value = this.QtyNumber.ToString();
                }
                this.firstQtydis = "display:none;";
                this.SecQtydis = "display:none;";
                this.ThirdQtydis = "display:none;";
                this.ForthQtydis = "display:none;";
                if (this.QtyNumber == 1)
                {
                    this.firstQtydis = "display:block;";
                    if (browser.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:block; width:100px;";
                        this.SecQtydis_ = "visibility: hidden; width:100px;";
                        this.ThirdQtydis_ = "visibility: hidden; width:100px;";
                        this.ForthQtydis_ = "visibility: hidden; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:block;";
                        this.SecQtydis_ = "display:none; width:10%;";
                        this.ThirdQtydis_ = "display:none; width:10%;";
                        this.ForthQtydis_ = "display:none; width:10%;";
                    }
                }
                if (this.QtyNumber == 2)
                {
                    this.SecQtydis = "display:block;";
                    if (browser.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:none; width:100px;";
                        this.SecQtydis_ = "display:block; width:100px;";
                        this.ThirdQtydis_ = "visibility: hidden; width:100px;";
                        this.ForthQtydis_ = "visibility: hidden; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:none; width:10%;";
                        this.SecQtydis_ = "display:block;";
                        this.ThirdQtydis_ = "display:none; width:10%;";
                        this.ForthQtydis_ = "display:none; width:10%;";
                    }
                }
                if (this.QtyNumber == 3)
                {
                    this.ThirdQtydis = "display:block;";
                    if (browser.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:none; width:100px;";
                        this.SecQtydis_ = "display:none; width:100px;";
                        this.ThirdQtydis_ = "display:block; width:100px;";
                        this.ForthQtydis_ = "visibility: hidden; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:none; width:10%;";
                        this.SecQtydis_ = "display:none; width:10%;";
                        this.ThirdQtydis_ = "display:block;";
                        this.ForthQtydis_ = "display:none; width:10%;";
                    }
                }
                if (this.QtyNumber == 4)
                {
                    this.ForthQtydis = "display:block;";
                    if (browser.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:none; width:100px;";
                        this.SecQtydis_ = "display:none; width:100px;";
                        this.ThirdQtydis_ = "display:none; width:100px;";
                        this.ForthQtydis_ = "display:block; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:none; width:10%;";
                        this.SecQtydis_ = "display:none; width:10%;";
                        this.ThirdQtydis_ = "display:none; width:10%;";
                        this.ForthQtydis_ = "display:block;";
                    }
                }
                this.Product_catalogueDetails_Edit();
                if (this.MatrixType == "S")
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections10 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str10, "'>", stringBuilder, " </select>  " };
                            controlCollections10.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls11 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_1'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controls11.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections11 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_1'  type='text'  style='margin-left: 2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections11.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.SecQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls12 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controls12.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections12 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_2'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controlCollections12.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls13 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='margin-left: 2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, ");  onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls13.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections13 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controlCollections13.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls14 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_3'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controls14.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections14 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='margin-left: 2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections14.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ForthQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls15 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controls15.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections15 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_4'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controlCollections15.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls16 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='margin-left: 2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls16.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections16 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='margin-left: 3px;width:75px;display:", str10, "'>", stringBuilder1, " </select>  " };
                            controlCollections16.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls17 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_1'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                            controls17.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections17 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_1'  type='text'  style='margin-left: 3px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">  " };
                        controlCollections17.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.SecQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls18 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='margin-left: 3px;width:75px;display:", str10, "'>", stringBuilder2, "</select>  " };
                            controls18.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections18 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_2'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                            controlCollections18.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls19 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, ");  onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">  " };
                        controls19.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections19 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='margin-left: 3px;width:75px;display:", str10, "'>", stringBuilder3, "</select>  " };
                            controlCollections19.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls20 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_3'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                            controls20.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections20 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">  " };
                        controlCollections20.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ForthQtydis, "' > ")));
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls21 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='margin-left: 3px;width:75px;display:", str10, "'>", stringBuilder4, "</select>  " };
                            controls21.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections21 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_4'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                            controlCollections21.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls22 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">  " };
                        controls22.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                }
                else if (this.MatrixType == "P")
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, " ' > ")));
                        ControlCollection controlCollections22 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections22.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                        ControlCollection controls23 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls23.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, " ' > ")));
                        ControlCollection controlCollections23 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections23.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                        ControlCollection controls24 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls24.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, " ' > ")));
                        ControlCollection controlCollections24 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                        controlCollections24.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                        ControlCollection controls25 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                        controls25.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, " ' > ")));
                        ControlCollection controlCollections25 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                        controlCollections25.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                        ControlCollection controls26 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                        controls26.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                }
                else if (this.MatrixType == "G")
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, " ' > ")));
                        ControlCollection controlCollections26 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections26.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                        ControlCollection controls27 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls27.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, " ' > ")));
                        ControlCollection controlCollections27 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections27.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                        ControlCollection controls28 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls28.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, " ' > ")));
                        ControlCollection controlCollections28 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                        controlCollections28.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                        ControlCollection controls29 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                        controls29.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, " ' > ")));
                        ControlCollection controlCollections29 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                        controlCollections29.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                        ControlCollection controls30 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='margin-left: 3px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                        controls30.Add(new LiteralControl(string.Concat(str)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    ControlCollection controlCollections30 = this.plhCatalogueList.Controls;
                    languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Width"), " (", this.Measurementvalue, ")</div>" };
                    controlCollections30.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls31 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls31.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections31 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width1, ">" };
                        controlCollections31.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls32 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls32.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections32 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width2, ">" };
                        controlCollections32.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls33 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls33.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections33 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width3, ">" };
                        controlCollections33.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls34 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls34.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections34 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width4, ">" };
                        controlCollections34.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%'>"));
                    ControlCollection controls35 = this.plhCatalogueList.Controls;
                    languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Height"), " (", this.Measurementvalue, ")</div>" };
                    controls35.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections35 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections35.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls36 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height1, ">" };
                        controls36.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections36 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections36.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls37 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height2, ">" };
                        controls37.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections37 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections37.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls38 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height3, ">" };
                        controls38.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections38 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections38.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls39 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height4, ">" };
                        controls39.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                if (!ConnectionClass.IsHandy)
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='display:none'>"));
                }
                else
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='bgLabel' style='width:23%;'>Qty used for Calculation</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px' style='margin-left:4px;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                if (this.MatrixType == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections39 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='margin-left: -2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections39.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls40 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">  " };
                        controls40.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.SecQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections40 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='margin-left: -2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections40.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls41 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">  " };
                        controls41.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections41 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='margin-left: -2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections41.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls42 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">  " };
                        controls42.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ForthQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections42 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='margin-left: -2px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections42.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls43 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">  " };
                        controls43.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, " ' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections43 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;", this.firstQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections43.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls44 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;", this.firstQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">" };
                        controls44.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections44 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.SecQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections44.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls45 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.SecQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">" };
                        controls45.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, " ' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections45 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ThirdQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections45.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls46 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ThirdQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">" };
                        controls46.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections46 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ForthQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections46.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls47 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ForthQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">" };
                        controls47.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, " ' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections47 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;", this.firstQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections47.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls48 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;", this.firstQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">" };
                        controls48.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections48 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.SecQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections48.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls49 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.SecQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">" };
                        controls49.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, " ' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections49 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ThirdQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections49.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls50 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ThirdQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">" };
                        controls50.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections50 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ForthQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections50.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls51 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;", this.ForthQtydis, "' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">" };
                        controls51.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>Selling Price(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.firstQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections51 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_1' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections51.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls52 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_2'  style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls52.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections52 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_3'  style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections52.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls53 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_4'  style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls53.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                string languageConversion1 = this.objLanguage.GetLanguageConversion("Create_Multiple_Of");
                languageConversion1 = (!ConnectionClass.IsHandy ? "Create Multiple Of " : "Sides");
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", languageConversion1, "</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;margin-left: 3px;margin-left: 3px;'> "));
                StringBuilder stringBuilder6 = new StringBuilder();
                if (ConnectionClass.ServerName != null && (ConnectionClass.ServerName.ToString().ToLower() == "mbe" || ConnectionClass.ServerName.ToString().ToLower() == "mbekentstreet" || ConnectionClass.ServerName.ToString().ToLower() == "mbeadelaidesouth" || ConnectionClass.ServerName.ToString().ToLower() == "mbeperthcbd"))
                {
                    if (!ConnectionClass.IsHandy)
                    {
                        for (int j = 1; j <= 10000; j++)
                        {
                            if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                            {
                                str = new object[] { "<option value='", j, "'>", j, "</option>" };
                                stringBuilder6.Append(string.Concat(str));
                            }
                            else if (this.MultipleOf.ToString() != j.ToString())
                            {
                                str = new object[] { "<option value='", j, "'>", j, "</option>" };
                                stringBuilder6.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<option value='", j, "'selected='selected'>", j, "</option>" };
                                stringBuilder6.Append(string.Concat(str));
                            }
                        }
                    }
                    else
                    {
                        for (int k = 1; k < 3; k++)
                        {
                            if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                            {
                                str = new object[] { "<option value='", k, "'>", k, "</option>" };
                                stringBuilder6.Append(string.Concat(str));
                            }
                            else if (this.MultipleOf.ToString() != k.ToString())
                            {
                                str = new object[] { "<option value='", k, "'>", k, "</option>" };
                                stringBuilder6.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<option value='", k, "'selected='selected'>", k, "</option>" };
                                stringBuilder6.Append(string.Concat(str));
                            }
                        }
                    }
                }
                else if (!ConnectionClass.IsHandy)
                {
                    for (int l = 1; l <= 300; l++)
                    {
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                        {
                            str = new object[] { "<option value='", l, "'>", l, "</option>" };
                            stringBuilder6.Append(string.Concat(str));
                        }
                        else if (this.MultipleOf.ToString() != l.ToString())
                        {
                            str = new object[] { "<option value='", l, "'>", l, "</option>" };
                            stringBuilder6.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<option value='", l, "'selected='selected'>", l, "</option>" };
                            stringBuilder6.Append(string.Concat(str));
                        }
                    }
                    str = new object[] { "<option value='", 500, "'>", 500, "</option>" };
                    stringBuilder6.Append(string.Concat(str));
                    str = new object[] { "<option value='", 750, "'>", 750, "</option>" };
                    stringBuilder6.Append(string.Concat(str));
                    str = new object[] { "<option value='", 1000, "'>", 1000, "</option>" };
                    stringBuilder6.Append(string.Concat(str));
                }
                else
                {
                    for (int m = 1; m < 3; m++)
                    {
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                        {
                            str = new object[] { "<option value='", m, "'>", m, "</option>" };
                            stringBuilder6.Append(string.Concat(str));
                        }
                        else if (this.MultipleOf.ToString() != m.ToString())
                        {
                            str = new object[] { "<option value='", m, "'>", m, "</option>" };
                            stringBuilder6.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<option value='", m, "'selected='selected'>", m, "</option>" };
                            stringBuilder6.Append(string.Concat(str));
                        }
                    }
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<select id='ddlMultiple' onchange='showTotalCostPrice();' class='textboxnew' style='width:75px;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</select>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%;display:", empty1, "'>")));
                ControlCollection controlCollections53 = this.plhCatalogueList.Controls;
                languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Total_Selling_Price"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                controlCollections53.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.firstQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls54 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_1' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls54.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.SecQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections54 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_2' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections54.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls55 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_3' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls55.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ForthQtydis, "' > ")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections55 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_4' style='float:right;padding-right:37px;'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections55.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                if (base.Request.Params["parentestitemid"] != null && base.Request.Params["parentestitemid"] != "0")
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (this.modulename.ToLower() == "jobs" && this.ParentEstimateItemID == (long)0 && this.IsDirectJob == 1 && this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && Convert.ToString(Drawstockfrom).ToLower() == "s")
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%; display:", empty1, "'>")));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%; display:none'>"));
                    }
                    if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["MandatoryReplenishments"]))
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Replenish_Order"), " <span style='color:red;'>*</span>", "</div>")));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Replenish_Order"), "</div>")));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width: 12%; margin-left: -1px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));

                    if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["MandatoryReplenishments"]))
                    {
                        // Create dropdown for mandatory selection
                        this.plhCatalogueList.Controls.Add(new LiteralControl(@"<select id='ddl_MandatoryReplenish' required style='width:100%;'><option value=''>-- Select --</option>
                        <option value='true'>True</option><option value='false'>False</option></select><span style='color:red;' id='val_MandatoryReplenish'></span>"));
                    }
                    else
                    {
                        // Original checkbox logic
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID || !this.IsStockReplenishItem)
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Replenish_Product' type='checkbox' />"));
                        }
                        else
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Replenish_Product' type='checkbox' checked disabled />"));
                        }
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                if (this.MainType.ToLower() == "edit")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'> <div id='spn_Update_Item_Descriptions' style='width:101%;'>", this.objLanguage.GetLanguageConversion("Update_Item_Descriptions"), "</div></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    if (dataTable.Rows.Count <= 0)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' />"));
                    }
                    else if (!Convert.ToBoolean(dataTable.Rows[0]["UpdateItemDescription"]))
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' />"));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' checked />"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            }
            else if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
            {
                HttpBrowserCapabilities httpBrowserCapability = base.Request.Browser;
                foreach (DataRow row1 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.EstimateItemID).Rows)
                {
                    this.QtyNumber = Convert.ToInt16(row1["QtyNumber"].ToString());
                    this.hdnQtyNumber.Value = this.QtyNumber.ToString();
                }
                this.firstQtydis = "display:none;";
                this.SecQtydis = "display:none;";
                this.ThirdQtydis = "display:none;";
                this.ForthQtydis = "display:none;";
                if (this.QtyNumber == 1)
                {
                    this.firstQtydis = "display:block;";
                    if (httpBrowserCapability.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:block; width:100px;";
                        this.SecQtydis_ = "visibility: hidden; width:100px;";
                        this.ThirdQtydis_ = "visibility: hidden; width:100px;";
                        this.ForthQtydis_ = "visibility: hidden; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:block;";
                        this.SecQtydis_ = "display:none; width:10%;";
                        this.ThirdQtydis_ = "display:none; width:10%;";
                        this.ForthQtydis_ = "display:none; width:10%;";
                    }
                }
                if (this.QtyNumber == 2)
                {
                    this.SecQtydis = "display:block;";
                    if (httpBrowserCapability.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:none; width:100px;";
                        this.SecQtydis_ = "display:block; width:100px;";
                        this.ThirdQtydis_ = "visibility: hidden; width:100px;";
                        this.ForthQtydis_ = "visibility: hidden; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:none; width:10%;";
                        this.SecQtydis_ = "display:block;";
                        this.ThirdQtydis_ = "display:none; width:10%;";
                        this.ForthQtydis_ = "display:none; width:10%;";
                    }
                }
                if (this.QtyNumber == 3)
                {
                    this.ThirdQtydis = "display:block;";
                    if (httpBrowserCapability.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:none; width:100px;";
                        this.SecQtydis_ = "display:none; width:100px;";
                        this.ThirdQtydis_ = "display:block; width:100px;";
                        this.ForthQtydis_ = "visibility: hidden; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:none; width:10%;";
                        this.SecQtydis_ = "display:none; width:10%;";
                        this.ThirdQtydis_ = "display:block;";
                        this.ForthQtydis_ = "display:none; width:10%;";
                    }
                }
                if (this.QtyNumber == 4)
                {
                    this.ForthQtydis = "display:block;";
                    if (httpBrowserCapability.Browser.ToLower() != "firefox")
                    {
                        this.firstQtydis_ = "display:none; width:100px;";
                        this.SecQtydis_ = "display:none; width:100px;";
                        this.ThirdQtydis_ = "display:none; width:100px;";
                        this.ForthQtydis_ = "display:block; width:100px;";
                    }
                    else
                    {
                        this.firstQtydis_ = "display:none; width:10%;";
                        this.SecQtydis_ = "display:none; width:10%;";
                        this.ThirdQtydis_ = "display:none; width:10%;";
                        this.ForthQtydis_ = "display:block;";
                    }
                }
                this.Product_catalogueDetails_Edit();
                if (this.MatrixType == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls56 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str10, "'>", stringBuilder, " </select>  " };
                            controls56.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections56 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_1'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controlCollections56.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls57 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_1'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls57.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections57 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onload=TakeSellPrice(this,'1'); onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str10, "'>", stringBuilder1, " </select>  " };
                            controlCollections57.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls58 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_1'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                            controls58.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections58 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_1'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">  " };
                        controlCollections58.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls59 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer;' title='Check Availability' ToolTip='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_1','s');  border='0' />" };
                        controls59.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.SecQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections59 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controlCollections59.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls60 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_2'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controls60.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections60 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections60.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls61 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str10, "'>", stringBuilder2, "</select>  " };
                            controls61.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections61 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_2'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                            controlCollections61.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls62 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">  " };
                        controls62.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections62 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_2','s');  border='0' />" };
                        controlCollections62.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls63 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controls63.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections63 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_3'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controlCollections63.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls64 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls64.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections64 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str10, "'>", stringBuilder3, "</select>  " };
                            controlCollections64.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls65 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_3'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                            controls65.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections65 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">  " };
                        controlCollections65.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls66 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_3','s');  border='0' />" };
                        controls66.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ForthQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections66 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controlCollections66.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls67 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_4'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controls67.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections67 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections67.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls68 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str10, "'>", stringBuilder4, "</select>  " };
                            controls68.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections68 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_4'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                            controlCollections68.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls69 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">  " };
                        controls69.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections69 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_4','s');  border='0' />" };
                        controlCollections69.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls70 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls70.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections70 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                        controlCollections70.Add(new LiteralControl(string.Concat(str)));
                    }
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls71 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_1','p');  border='0' />" };
                        controls71.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.SecQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections71 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections71.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls72 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                        controls72.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections72 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_2','p');  border='0' />" };
                        controlCollections72.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ThirdQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls73 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls73.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections73 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                        controlCollections73.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls74 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_3','p');  border='0' />" };
                        controls74.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", this.ForthQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections74 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections74.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls75 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style=';width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                        controls75.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections75 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability'  onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_4','p');  border='0' />" };
                        controlCollections75.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls76 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls76.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections76 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                        controlCollections76.Add(new LiteralControl(string.Concat(str)));
                    }
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls77 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_1','g');  border='0' />" };
                        controls77.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections77 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections77.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls78 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                        controls78.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections78 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_2','g');  border='0' />" };
                        controlCollections78.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls79 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls79.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections79 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                        controlCollections79.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls80 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_3','g');  border='0' />" };
                        controls80.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections80 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections80.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls81 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                        controls81.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections81 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability'  onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_4','g');  border='0' />" };
                        controlCollections81.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    ControlCollection controls82 = this.plhCatalogueList.Controls;
                    languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Width"), " (", this.Measurementvalue, ")</div>" };
                    controls82.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections82 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('width');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections82.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls83 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('width');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width1, ">" };
                        controls83.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections83 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections83.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls84 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width2, ">" };
                        controls84.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections84 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections84.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls85 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width3, ">" };
                        controls85.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections85 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections85.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls86 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width4, ">" };
                        controls86.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%'>"));
                    ControlCollection controlCollections86 = this.plhCatalogueList.Controls;
                    languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Height"), " (", this.Measurementvalue, ")</div>" };
                    controlCollections86.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls87 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('height');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls87.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections87 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('height');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height1, ">" };
                        controlCollections87.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls88 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls88.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections88 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height2, ">" };
                        controlCollections88.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls89 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls89.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections89 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height3, ">" };
                        controlCollections89.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls90 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls90.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections90 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height4, ">" };
                        controlCollections90.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                if (!ConnectionClass.IsHandy)
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='display:none'>"));
                }
                else
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='bgLabel' style='width:23%;'>Qty used for Calculation</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px' style='margin-left:4px;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                if (this.MatrixType == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls91 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls91.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections91 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">  " };
                        controlCollections91.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls92 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls92.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections92 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">  " };
                        controlCollections92.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls93 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls93.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections93 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">  " };
                        controlCollections93.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls94 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls94.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections94 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='margin-left: -1px;width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">  " };
                        controlCollections94.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls95 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls95.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections95 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">" };
                        controlCollections95.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls96 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls96.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections96 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">" };
                        controlCollections96.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls97 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls97.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections97 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">" };
                        controlCollections97.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls98 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls98.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections98 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">" };
                        controlCollections98.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls99 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls99.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections99 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='margin-left: -1px;width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">" };
                        controlCollections99.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls100 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls100.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections100 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">" };
                        controlCollections100.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls101 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls101.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections101 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">" };
                        controlCollections101.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls102 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls102.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections102 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='margin-left: -1px;width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">" };
                        controlCollections102.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>Selling Price(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls103 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_1' style='float:right;padding-right:37px;'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls103.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections103 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_2'  style='float:right;padding-right:37px;'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections103.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls104 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_3'  style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls104.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections104 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_4' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections104.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                string str12 = "Create Multiple Of ";
                str12 = (!ConnectionClass.IsHandy ? "Create Multiple Of " : "Sides");
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", str12, "</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;margin-left: 3px;'> "));
                StringBuilder stringBuilder7 = new StringBuilder();
                if (ConnectionClass.ServerName != null && (ConnectionClass.ServerName.ToString().ToLower() == "mbe" || ConnectionClass.ServerName.ToString().ToLower() == "mbekentstreet" || ConnectionClass.ServerName.ToString().ToLower() == "mbeadelaidesouth" || ConnectionClass.ServerName.ToString().ToLower() == "mbeperthcbd"))
                {
                    if (!ConnectionClass.IsHandy)
                    {
                        for (int n = 1; n <= 10000; n++)
                        {
                            if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                            {
                                str = new object[] { "<option value='", n, "'>", n, "</option>" };
                                stringBuilder7.Append(string.Concat(str));
                            }
                            else if (this.MultipleOf.ToString() != n.ToString())
                            {
                                str = new object[] { "<option value='", n, "'>", n, "</option>" };
                                stringBuilder7.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<option value='", n, "'selected='selected'>", n, "</option>" };
                                stringBuilder7.Append(string.Concat(str));
                            }
                        }
                    }
                    else
                    {
                        for (int o = 1; o < 3; o++)
                        {
                            if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                            {
                                str = new object[] { "<option value='", o, "'>", o, "</option>" };
                                stringBuilder7.Append(string.Concat(str));
                            }
                            else if (this.MultipleOf.ToString() != o.ToString())
                            {
                                str = new object[] { "<option value='", o, "'>", o, "</option>" };
                                stringBuilder7.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<option value='", o, "'selected='selected'>", o, "</option>" };
                                stringBuilder7.Append(string.Concat(str));
                            }
                        }
                    }
                }
                else if (!ConnectionClass.IsHandy)
                {
                    for (int p = 1; p <= 300; p++)
                    {
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                        {
                            str = new object[] { "<option value='", p, "'>", p, "</option>" };
                            stringBuilder7.Append(string.Concat(str));
                        }
                        else if (this.MultipleOf.ToString() != p.ToString())
                        {
                            str = new object[] { "<option value='", p, "'>", p, "</option>" };
                            stringBuilder7.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<option value='", p, "'selected='selected'>", p, "</option>" };
                            stringBuilder7.Append(string.Concat(str));
                        }
                    }
                    str = new object[] { "<option value='", 500, "'>", 500, "</option>" };
                    stringBuilder7.Append(string.Concat(str));
                    str = new object[] { "<option value='", 750, "'>", 750, "</option>" };
                    stringBuilder7.Append(string.Concat(str));
                    str = new object[] { "<option value='", 1000, "'>", 1000, "</option>" };
                    stringBuilder7.Append(string.Concat(str));
                }
                else
                {
                    for (int q = 1; q < 3; q++)
                    {
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                        {
                            str = new object[] { "<option value='", q, "'>", q, "</option>" };
                            stringBuilder7.Append(string.Concat(str));
                        }
                        else if (this.MultipleOf.ToString() != q.ToString())
                        {
                            str = new object[] { "<option value='", q, "'>", q, "</option>" };
                            stringBuilder7.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<option value='", q, "'selected='selected'>", q, "</option>" };
                            stringBuilder7.Append(string.Concat(str));
                        }
                    }
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<select id='ddlMultiple' onchange='showTotalCostPrice();' class='textboxnew' style='width:75px;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder7.ToString()));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</select>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%;display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>Total Selling Price(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.firstQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls105 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_1' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls105.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.SecQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections105 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_2' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections105.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ThirdQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controls106 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_3' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls106.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", this.ForthQtydis, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                ControlCollection controlCollections106 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_4' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections106.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                if (base.Request.Params["parentestitemid"] != null && base.Request.Params["parentestitemid"] != "0")
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (this.modulename.ToLower() == "jobs" && this.ParentEstimateItemID == (long)0 && this.IsDirectJob == 1 && this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && Convert.ToString(Drawstockfrom).ToLower() == "s")
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%; display:", empty1, "'>")));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%; display:none'>"));
                    }
                    if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["MandatoryReplenishments"]))
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Replenish_Order"), " <span style='color:red;'>*</span>", "</div>")));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Replenish_Order"), "</div>")));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width: 12%; margin-left: -1px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));


                    if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["MandatoryReplenishments"]))
                    {
                        // Create dropdown for mandatory selection
                        this.plhCatalogueList.Controls.Add(new LiteralControl(@"<select id='ddl_MandatoryReplenish' required style='width:100%;'><option value=''>-- Select --</option>
                        <option value='true'>True</option><option value='false'>False</option></select><span style='color:red;' id='val_MandatoryReplenish'></span>"));
                    }
                    else
                    {
                        // Original checkbox logic
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID || !this.IsStockReplenishItem)
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Replenish_Product' type='checkbox' />"));
                        }
                        else
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Replenish_Product' type='checkbox' checked disabled />"));
                        }
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'> <div id='spn_Update_Item_Descriptions' style='width:101%;'>", this.objLanguage.GetLanguageConversion("Update_Item_Descriptions"), "</div></div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                if (dataTable.Rows.Count <= 0)
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' />"));
                }
                else if (!Convert.ToBoolean(dataTable.Rows[0]["UpdateItemDescription"]))
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' />"));
                }
                else
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' checked />"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            }
            else
            {
                this.Product_catalogueDetails_Edit();

                if (this.MatrixType == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls107 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str10, "'>", stringBuilder, " </select>  " };
                            controls107.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections107 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_1'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controlCollections107.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls108 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_1'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls108.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections108 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onload=TakeSellPrice(this,'1'); onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str10, "'>", stringBuilder1, " </select>  " };
                            controlCollections108.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls109 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_1'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                            controls109.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections109 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_1'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">  " };
                        controlCollections109.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls110 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer;' title='Check Availability' ToolTip='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_1','s');  border='0' />" };
                        controls110.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections110 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controlCollections110.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls111 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_2'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controls111.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections111 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections111.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls112 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str10, "'>", stringBuilder2, "</select>  " };
                            controls112.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections112 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_2'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                            controlCollections112.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls113 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">  " };
                        controls113.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections113 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_2','s');  border='0' />" };
                        controlCollections113.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls114 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controls114.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections114 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_3'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controlCollections114.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls115 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls115.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections115 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str10, "'>", stringBuilder3, "</select>  " };
                            controlCollections115.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls116 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_3'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                            controls116.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections116 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">  " };
                        controlCollections116.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls117 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_3','s');  border='0' />" };
                        controls117.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controlCollections117 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str10, "'>", stringBuilder, "</select>  " };
                            controlCollections117.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controls118 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_4'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' value='' class='textboxnew' maxlength=7>" };
                            controls118.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controlCollections118 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controlCollections118.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        if (!Convert.ToBoolean(this.hdn_IsCumulative.Value))
                        {
                            ControlCollection controls119 = this.plhCatalogueList.Controls;
                            str = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str10, "'>", stringBuilder4, "</select>  " };
                            controls119.Add(new LiteralControl(string.Concat(str)));
                        }
                        else
                        {
                            ControlCollection controlCollections119 = this.plhCatalogueList.Controls;
                            str = new object[] { "<input id='txt_Cumulative_PriceQty_4'  type='text' style='width:75px;text-align:right;display:", str11, ";' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                            controlCollections119.Add(new LiteralControl(string.Concat(str)));
                        }
                        ControlCollection controls120 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:75px;text-align:right;display:", str9, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">  " };
                        controls120.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections120 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_4','s');  border='0' />" };
                        controlCollections120.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls121 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls121.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections121 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                        controlCollections121.Add(new LiteralControl(string.Concat(str)));
                    }
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls122 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_1','p');  border='0' />" };
                        controls122.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections122 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections122.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls123 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                        controls123.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections123 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_2','p');  border='0' />" };
                        controlCollections123.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls124 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls124.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections124 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                        controlCollections124.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls125 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_3','p');  border='0' />" };
                        controls125.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections125 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections125.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls126 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                        controls126.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections126 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability'  onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_4','p');  border='0' />" };
                        controlCollections126.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls127 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls127.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections127 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity1, ">" };
                        controlCollections127.Add(new LiteralControl(string.Concat(str)));
                    }
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls128 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_1','g');  border='0' />" };
                        controls128.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections128 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections128.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls129 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity2, ">" };
                        controls129.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections129 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_2','g');  border='0' />" };
                        controlCollections129.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls130 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls130.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections130 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity3, ">" };
                        controlCollections130.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls131 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_3','g');  border='0' />" };
                        controls131.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections131 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controlCollections131.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls132 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.Quantity4, ">" };
                        controls132.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && dataTable1.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections132 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability'  onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_4','g');  border='0' />" };
                        controlCollections132.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    ControlCollection controls133 = this.plhCatalogueList.Controls;
                    languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Width"), " (", this.Measurementvalue, ")</div>" };
                    controls133.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections133 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('width');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections133.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls134 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('width');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width1, ">" };
                        controls134.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections134 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections134.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls135 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width2, ">" };
                        controls135.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections135 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections135.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls136 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width3, ">" };
                        controls136.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controlCollections136 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controlCollections136.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controls137 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Width_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' value=", this.Width4, ">" };
                        controls137.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%'>"));
                    ControlCollection controlCollections137 = this.plhCatalogueList.Controls;
                    languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Height"), " (", this.Measurementvalue, ")</div>" };
                    controlCollections137.Add(new LiteralControl(string.Concat(languageConversion)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid;margin-top: -3px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls138 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('height');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls138.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections138 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_1'  type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");Dimension_Prefill('height');CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height1, ">" };
                        controlCollections138.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls139 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls139.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections139 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height2, ">" };
                        controlCollections139.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls140 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls140.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections140 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height3, ">" };
                        controlCollections140.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls141 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' >" };
                        controls141.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections141 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_Height_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=javascript:roundUp(this.id,this.value,", this.RoundOff, ");CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' value=", this.Height4, ">" };
                        controlCollections141.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                if (!ConnectionClass.IsHandy)
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='display:none'>"));
                }
                else
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='bgLabel' style='width:23%;'>Qty used for Calculation</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px' style='margin-left:4px;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                if (this.MatrixType == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls142 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls142.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections142 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">  " };
                        controlCollections142.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls143 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls143.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections143 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">  " };
                        controlCollections143.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls144 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls144.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections144 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">  " };
                        controlCollections144.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls145 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls145.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections145 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='width:75px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">  " };
                        controlCollections145.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID) 
                    {
                        ControlCollection controls146 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls146.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections146 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">" };
                        controlCollections146.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls147 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls147.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections147 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">" };
                        controlCollections147.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls148 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls148.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections148 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">" };
                        controlCollections148.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls149 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls149.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections149 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">" };
                        controlCollections149.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (this.MatrixType == "G")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls150 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls150.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections150 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='width:75px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num1, "); onblur=CalculateQtyPrice(this,this.value,'1',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation1, ">" };
                        controlCollections150.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls151 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls151.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections151 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num1, "); onblur=CalculateQtyPrice(this,this.value,'2',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation2, ">" };
                        controlCollections151.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls152 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls152.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections152 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num1, "); onblur=CalculateQtyPrice(this,this.value,'3',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation3, ">" };
                        controlCollections152.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str8, "' > ")));
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        ControlCollection controls153 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                        controls153.Add(new LiteralControl(string.Concat(str)));
                    }
                    else
                    {
                        ControlCollection controlCollections153 = this.plhCatalogueList.Controls;
                        str = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='width:75px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num1, "); onblur=CalculateQtyPrice(this,this.value,'4',", num1, "); autocomplete='off' class='textboxnew' maxlength=7 value=", this.QtyusedforCalculation4, ">" };
                        controlCollections153.Add(new LiteralControl(string.Concat(str)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>Selling Price(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controls154 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_1'   style='float:right;padding-right:37px;'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls154.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controlCollections154 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_2'  style='float:right;padding-right:37px;", str8, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections154.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controls155 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_3'  style='float:right;padding-right:37px;", str8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls155.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controlCollections155 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_QtyPrice_4' style='float:right;padding-right:37px;", str8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections155.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                string str13 = "Create Multiple Of ";
                str13 = (!ConnectionClass.IsHandy ? "Create Multiple Of " : "Sides");
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", str13, "</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;margin-left: 3px;'> "));
                StringBuilder stringBuilder8 = new StringBuilder();
                if (ConnectionClass.ServerName != null && (ConnectionClass.ServerName.ToString().ToLower() == "mbe" || ConnectionClass.ServerName.ToString().ToLower() == "mbekentstreet" || ConnectionClass.ServerName.ToString().ToLower() == "mbeadelaidesouth" || ConnectionClass.ServerName.ToString().ToLower() == "mbeperthcbd"))
                {
                    if (!ConnectionClass.IsHandy)
                    {
                        for (int r = 1; r <= 10000; r++)
                        {
                            if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                            {
                                str = new object[] { "<option value='", r, "'>", r, "</option>" };
                                stringBuilder8.Append(string.Concat(str));
                            }
                            else if (this.MultipleOf.ToString() != r.ToString())
                            {
                                str = new object[] { "<option value='", r, "'>", r, "</option>" };
                                stringBuilder8.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<option value='", r, "'selected='selected'>", r, "</option>" };
                                stringBuilder8.Append(string.Concat(str));
                            }
                        }
                    }
                    else
                    {
                        for (int s = 1; s < 3; s++)
                        {
                            if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                            {
                                str = new object[] { "<option value='", s, "'>", s, "</option>" };
                                stringBuilder8.Append(string.Concat(str));
                            }
                            else if (this.MultipleOf.ToString() != s.ToString())
                            {
                                str = new object[] { "<option value='", s, "'>", s, "</option>" };
                                stringBuilder8.Append(string.Concat(str));
                            }
                            else
                            {
                                str = new object[] { "<option value='", s, "'selected='selected'>", s, "</option>" };
                                stringBuilder8.Append(string.Concat(str));
                            }
                        }
                    }
                }
                else if (!ConnectionClass.IsHandy)
                {
                    int u = 0;
                    for (int t = 1; t <= 303; t++)
                    {
                        switch(t)
                        {
                            case 301:
                                u = 500;
                                break;
                            case 302:
                                u = 750;
                                break;
                            case 303:
                                u = 1000;
                                break;
                            default:
                                u = t;
                                break;
                        }
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                        {
                            str = new object[] { "<option value='", u, "'>", u, "</option>" };
                            stringBuilder8.Append(string.Concat(str));
                        }
                        else if (this.MultipleOf.ToString() != u.ToString())
                        {
                            str = new object[] { "<option value='", u, "'>", u, "</option>" };
                            stringBuilder8.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<option value='", u, "'selected='selected'>", u, "</option>" };
                            stringBuilder8.Append(string.Concat(str));
                        }
                    }
                }
                else
                {
                    for (int u = 1; u < 3; u++)
                    {
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                        {
                            str = new object[] { "<option value='", u, "'>", u, "</option>" };
                            stringBuilder8.Append(string.Concat(str));
                        }
                        else if (this.MultipleOf.ToString() != u.ToString())
                        {
                            str = new object[] { "<option value='", u, "'>", u, "</option>" };
                            stringBuilder8.Append(string.Concat(str));
                        }
                        else
                        {
                            str = new object[] { "<option value='", u, "'selected='selected'>", u, "</option>" };
                            stringBuilder8.Append(string.Concat(str));
                        }
                    }
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<select id='ddlMultiple' onchange='showTotalCostPrice();' class='textboxnew' style='width:75px;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder8.ToString()));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</select>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%;display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>Total Selling Price(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controls156 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_1' style='float:right;padding-right:37px;' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls156.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controlCollections156 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_2' style='float:right;padding-right:37px;", str8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections156.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controls157 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_3' style='float:right;padding-right:37px;", str8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls157.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controlCollections157 = this.plhCatalogueList.Controls;
                str = new object[] { "<span id='spn_Total_QtyPrice_4' style='float:right;padding-right:37px;", str8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections157.Add(new LiteralControl(string.Concat(str)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                if (base.Request.Params["parentestitemid"] != null && base.Request.Params["parentestitemid"] != "0")
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (this.modulename.ToLower() == "jobs" && this.ParentEstimateItemID == (long)0  && this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable1.Rows[0]["IsStockItem"]) == 1 && Convert.ToString(Drawstockfrom).ToLower() == "s")
                {
                    if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%; display:", empty1, "'>")));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%; display:none'>"));
                    }
                    if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["MandatoryReplenishments"]))
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Replenish_Order"), " <span style='color:red;'>*</span>", "</div>")));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Replenish_Order"), "</div>")));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width: 12%; margin-left: -1px;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                   
                    if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["MandatoryReplenishments"]))
                    {
                        // Create dropdown for mandatory selection
                        this.plhCatalogueList.Controls.Add(new LiteralControl(@"<select id='ddl_MandatoryReplenish' required style='width:100%;'><option value=''>-- Select --</option>
                        <option value='true'>True</option><option value='false'>False</option></select><span style='color:red;' id='val_MandatoryReplenish'></span>"));
                    }
                    else
                    {
                        // Original checkbox logic
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != PriceCatalogueID || !this.IsStockReplenishItem)
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Replenish_Product' type='checkbox' />"));
                        }
                        else
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Replenish_Product' type='checkbox' checked disabled />"));
                        }
                    }

                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                if (this.MainType.ToLower() == "edit")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'> <div id='spn_Update_Item_Descriptions' style='width:101%;'>", this.objLanguage.GetLanguageConversion("Update_Item_Descriptions"), "</div></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    if (dataTable.Rows.Count <= 0)
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' />"));
                    }
                    else if (!Convert.ToBoolean(dataTable.Rows[0]["UpdateItemDescription"]))
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' />"));
                    }
                    else
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<input id='chk_Update_Item_Descriptions' type='checkbox' checked />"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            }
            if (this.QueryType == "add" && this.ParentEstimateType.ToLower() == "c")
            {
                string empty4 = string.Empty;
                foreach (DataRow dataRow1 in EstimatesBasePage.Select_ProductCatalogueQty(this.ParentEstimateItemID, this.ParentEstimateType).Rows)
                {
                    str = new object[] { empty4, dataRow1["Quantity"], "~", dataRow1["QtyNumber"], "µ" };
                    empty4 = string.Concat(str);
                }
            }
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='float:left;width:100%;white-space: nowrap'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<table style='float:right; white-space: nowrap; margin-right: -5px;'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='white-space: nowrap;margin-left:53%;'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;display:none'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<input type='submit' value='Cancel' onclick='javascript:HidePanle();return false;' class='button' style='width:65px' />"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;'>"));
            Button button = new Button()
            {
                Text = "Cancel",
                CssClass = "button",
                Visible = false,
                Width = Unit.Pixel(65)
            };
            button.Attributes.Add("onclick", "javascript:HidePanle();return false;");
            this.plhCatalogueList.Controls.Add(button);
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div id='div_Cancel_and_select_different_product' style='float:left; margin-left: 5px;'>"));
            Button button1 = new Button()
            {
                Text = this.objLanguage.GetLanguageConversion("Cancel"),
                CssClass = "button"
            };
            button1.Style.Add("width", "65px");
            button1.Attributes.Add("onclick", "javascript:CancelandSelectDiffProduct();");
            this.plhCatalogueList.Controls.Add(button1);
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));




            if (OrderAddItemsCount == 0)
            {
                long CatalogueID = Convert.ToInt64(this.hidCatalogueID.Value);
                var decoration = OrderBasePage.productsDetails_Select(CatalogueID);

                foreach (DataRow row in decoration.Rows)
                {
                    name1 = row["Decoration1_Name"].ToString();
                    name2 = row["Decoration2_Name"].ToString();
                    name3 = row["Decoration3_Name"].ToString();
                    name4 = row["Decoration4_Name"].ToString();
                    name5 = row["Decoration5_Name"].ToString();
                    name6 = row["Decoration6_Name"].ToString();
                }
                if (name1 != "" || name2 != "" || name3 != "" || name4 != "" || name5 != "" || name6 != "")
                {
                    OrderAddItemsCount = 1;
                }
                
            }
            if (this.OrderAddItemsCount == 0)
            {
                string isAddOrContinue = "saveandgo";

                this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div id='divsave' style='float:left;'>"));
                Button button2 = new Button()
                {
                    Text = this.objLanguage.GetLanguageConversion("Save"),
                    CssClass = "button"
                };
                button2.Style.Add("width", "65px");
                AttributeCollection attributes = button2.Attributes;
                str = new object[] { "javascript:storeToArray(", PriceCatalogueID, ",'", empty, "','", this.MatrixType, "','", isAddOrContinue, "');return false;" };
                attributes.Add("onclick", string.Concat(str));
                this.plhCatalogueList.Controls.Add(button2);
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div id='div_btnsaveloading' class='button'  style='width:47px; height:14px; display: none; float:left;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='trans' alt='loading' border='0' />")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));



                //start 

                if (base.Request.QueryString["fromPageType"] == "job" || base.Request.QueryString["fromPageType"] == "invoice" || base.Request.QueryString["fromPageType"] == "estimate")
                {
                    isAddOrContinue = "addmore";
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div id='divsave_new' style='float:left;'>"));
                    Button button2_new = new Button()
                    {
                        Text = "Save & Add Another",
                        CssClass = "button"
                    };
                    button2_new.Style.Add("width", "130px");
                    AttributeCollection attributes_new = button2_new.Attributes;
                    str = new object[] { "javascript:storeToArray(", PriceCatalogueID, ",'", empty, "','", this.MatrixType, "','", isAddOrContinue, "');return false;" };
                    attributes_new.Add("onclick", string.Concat(str));
                    this.plhCatalogueList.Controls.Add(button2_new);
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div id='div_btnsaveloading_new' class='button'  style='width:47px; height:14px; display: none; float:left;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "radimg1.gif' class='trans' alt='loading' border='0' />")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));

                }

                //end

            }
            string empty5 = string.Empty;
            Button button3 = new Button()
            {
                ID = "btnidnext",
                Text = "Next",
                CssClass = "button"
            };
            button3.Style.Add("display", "block");
            button3.Style.Add("width", "65px");
            if (this.OrderAddItemsCount == 0)
            {
                empty5 = "display: none;";
                button3.Style.Add("display", "none");
            }
            this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='", empty5, "'>")));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:2px;'></div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div>"));
            AttributeCollection attributeCollection = button3.Attributes;
            str = new object[] { "javascript:funcBtnNextonclick('", PriceCatalogueID, "','", empty, "','", this.MatrixType, "');return false;" };
            attributeCollection.Add("onclick", string.Concat(str));
            this.plhCatalogueList.Controls.Add(button3);
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            HiddenField hidCatalogueItems = this.hid_catalogue_items;
            num = dataTable1.Rows.Count;
            hidCatalogueItems.Value = num.ToString();
        }

        protected void btnCatalogueFinish_OnClick(object sender, EventArgs e)
        {
            object[] str;
            decimal profitMargin;
            string[] strArrays;
            int taxID;
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string catalogueProfitAndTax = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            long num = (long)0;
            int num1 = 0;
            int num2 = 1;
            decimal num3 = new decimal(0);
            bool flag = false;
            int productIdByEstimatetItemId = 0;
            StringBuilder stringBuilder1 = new StringBuilder();
            long num4 = (long)0;
            DataTable dataTable = new DataTable();
            if (this.EstimateItemID != (long)0)
            {
                dataTable = EstimatesBasePage.OrderItemID_Select(this.EstimateID, this.EstimateItemID);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                num4 = Convert.ToInt64(row["ProductID"]);
            }
            long num5 = (long)0;
            bool TaxPrecedence = EstimatesBasePage.TaxPrecedence_Select(this.EstimateID);
            if (base.Request.Params["PriceCatalogueID"] != null)
            {
                num5 = Convert.ToInt64(base.Request.Params["PriceCatalogueID"]);
            }
            if (base.Request.Params["acntype"].ToString() == "edit" && this.frmcopyitem != "yes")
            {
                empty = ",ProfitMargin,SubTotal,Tax,TaxID";
                //if (Convert.ToInt64(num4) == Convert.ToInt64(num5) || num4 == (long)0 || num5 == (long)0)
                //{
                //    catalogueProfitAndTax = this.CatalogueProfitAndTax;
                //}
                //else
                //{
                int deID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);


                str = new object[] { ",", null, null, null, null, null };
                profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                str[1] = profitMargin.ToString();
                str[2] = ",0,";
                if (deID == 0)
                {
                    profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, num5);
                }
                else
                {
                    profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                }
                str[3] = profitMargin.ToString();
                str[4] = ",";
                if (deID == 0 || TaxPrecedence == false)
                {
                    Int32 TaxId = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, num5);

                    str[5] = TaxId != 0 ? TaxId : EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);

                }
                else
                {
                    str[5] = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                }
                catalogueProfitAndTax = string.Concat(str);
                profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                profitMargin.ToString();
                if (deID == 0)
                {
                    profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, num5);
                }
                else
                {
                    profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                }
                profitMargin.ToString();
                //}
                if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0 || string.Compare(this.ParentEstimateType, "R", true) == 0)
                {
                    this.ParentItemID = this.EstimateBookletItemID;
                }
                else
                {
                    this.ParentItemID = this.ParentEstimateItemID;
                }
                foreach (DataRow dataRow in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                {
                    this.EstTypeFromSP = dataRow["EstimateType"].ToString();
                    this.ParentItemType = dataRow["EstimateType"].ToString();
                }
            }
            else if (base.Request.Params["acntype"].ToString() == "add" || this.frmcopyitem == "yes")
            {
                empty = ",ProfitMargin,SubTotal,Tax,TaxID";
                long parentEstimateItemID = (long)0;
                bool flag1 = false;
                if (this.ParentEstimateItemID != (long)0)
                {
                    flag1 = false;
                    parentEstimateItemID = this.ParentEstimateItemID;
                }
                else
                {
                    flag1 = true;
                    parentEstimateItemID = (long)0;
                }
                if (flag1)
                {
                    int deID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);

                    str = new object[] { ",", null, null, null, null, null };
                    profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    str[1] = profitMargin.ToString();
                    str[2] = ",0,";
                    if (deID == 0)
                    {
                        profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, num5);
                    }
                    else
                    {
                        profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                    }
                    str[3] = profitMargin.ToString();
                    str[4] = ",";
                    if (deID == 0 || TaxPrecedence == false)
                    {
                        // str[5] = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, num5);
                        Int32 TaxId = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, num5);

                        str[5] = TaxId != 0 ? TaxId : EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    }
                    else
                    {
                        str[5] = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    }
                    catalogueProfitAndTax = string.Concat(str);
                }
                else if (this.ParentEstimateType != "C")
                {
                    strArrays = new string[] { ",", null, null, null, null, null };
                    profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    strArrays[1] = profitMargin.ToString();
                    strArrays[2] = ",0,";
                    profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                    strArrays[3] = profitMargin.ToString();
                    strArrays[4] = ",";
                    taxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    strArrays[5] = taxID.ToString();
                    catalogueProfitAndTax = string.Concat(strArrays);
                }
                else
                {
                    int deID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);

                    productIdByEstimatetItemId = EstimatesBasePage.GetProductId_ByEstimatetItemId(this.CompanyID, Convert.ToInt32(this.ParentEstimateItemID));
                    strArrays = new string[] { ",", null, null, null, null, null };
                    profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    strArrays[1] = profitMargin.ToString();
                    strArrays[2] = ",0,";
                    if (deID == 0)
                    {
                        profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, (long)productIdByEstimatetItemId);
                    }
                    else
                    {
                        profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                    }
                    strArrays[3] = profitMargin.ToString();
                    strArrays[4] = ",";
                    if (deID == 0 || TaxPrecedence == false)
                    {
                        taxID = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, (long)productIdByEstimatetItemId);

                    }
                    else
                    {
                        taxID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    }
                    strArrays[5] = taxID.ToString();
                    catalogueProfitAndTax = string.Concat(strArrays);
                }
                if (this.InvoiceID <= (long)0)
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "C", flag1, parentEstimateItemID, num5);
                }
                else
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "C", flag1, parentEstimateItemID, num5);
                }
                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                if (this.jobID > (long)0)
                {
                    long estimateItemID = this.EstimateItemID;
                    long num6 = this.jobID;
                    commonClass _commonClass = this.commclass;
                    DateTime now = DateTime.Now;
                    JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num6, false, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                }
                if (this.InvoiceID > (long)0)
                {
                    InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0 || string.Compare(this.ParentEstimateType, "R", true) == 0)
                    {
                        this.ParentItemID = this.EstimateBookletItemID;
                    }
                    else
                    {
                        this.ParentItemID = this.ParentEstimateItemID;
                    }
                    foreach (DataRow row1 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                    {
                        this.EstTypeFromSP = row1["EstimateType"].ToString();
                        this.ParentItemType = row1["EstimateType"].ToString();
                    }
                }
                else
                {
                    this.EstSingleItemID = (long)0;
                    this.EstTypeFromSP = "";
                }
            }
            int num7 = 0;
            bool flag2 = false;
            if (this.EstimateItemID != (long)0)
            {
                string value = this.hidCatalogueData.Value;
                char[] chrArray = new char[] { 'µ' };
                string[] array = value.Split(chrArray);
                List<string> strs = new List<string>(array);
                for (int i = 0; i < strs.Count; i++)
                {
                    if (strs[i].IndexOf("Cost»±") != -1)
                    {
                        strs.RemoveAt(i);
                        i = 0;
                    }
                }
                array = strs.ToArray();
                for (int j = 0; j < (int)array.Length; j++)
                {
                    string str2 = array[j];
                    chrArray = new char[] { '±' };
                    string[] strArrays1 = str2.Split(chrArray);
                    string str3 = "0";
                    string str4 = "";
                    string empty2 = string.Empty;
                    if (base.Request.Params["acntype"].ToString() == "add" || this.hid_GetItemDescription.Value != "")
                    {
                        base.Session["PricecatalogItemTitle"] = this.Objclss.SpecialEncode(this.hid_GetItemDescription.Value);
                    }
                    if (!string.IsNullOrEmpty(array[j]))
                    {
                        this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
                        empty2 = this.Objclss.SpecialEncode(this.WareItemDesc);
                        if (base.Request.Params["acntype"].ToString() == "edit" && this.frmcopyitem != "yes" && this.hid_GetItemDescription.Value.Trim().Length == 0)
                        {
                            foreach (DataRow dataRow1 in EstimatesBasePage.Pricecatalog_selecttiemdescription_byestimateitemid(this.CompanyID, this.EstimateItemID).Rows)
                            {
                                for (int k = 0; k <= 0; k++)
                                {
                                    empty2 = dataRow1["ItemDescription"].ToString();
                                }
                            }
                        }
                        stringBuilder.Append(string.Concat(" Insert into [TABLE_EstPriceCatalogue](EstimateItemID,PriceCatalogueID,Quantity,Price,MultipleOf,Markup,QtyNumber,ItemTitle,ItemDescription,ParentItemID,ParentItemType", empty, ", Height, Width,QtyusedforCalculation, IsSides, IsBackOrder,approvestatus)"));
                        stringBuilder.Append(string.Concat(" Values (", this.EstimateItemID, ","));
                        for (int l = 0; l < (int)strArrays1.Length; l++)
                        {
                            string str5 = strArrays1[l];
                            chrArray = new char[] { '»' };
                            string[] strArrays2 = str5.Split(chrArray);
                            if (strArrays1[l].Length > 0)
                            {
                                if (strArrays2[0].Trim() == "PriceCatalogueID")
                                {
                                    num = Convert.ToInt64(strArrays2[1].Trim());
                                    stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                }
                                else if (strArrays2[0].Trim() == "Quantity")
                                {
                                    num1 = Convert.ToInt32(Convert.ToDecimal(strArrays2[1].Trim()));
                                    stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                }
                                else if (strArrays2[0].Trim() == "Price")
                                {
                                    num3 = Convert.ToDecimal(strArrays2[1].Trim());
                                }
                                else if (strArrays2[0].Trim() == "Cost")
                                {
                                    if (strArrays2[1].Trim().Trim().Length != 0)
                                    {
                                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append("0,");
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "MultipleOf", true) == 0)
                                {
                                    str3 = strArrays2[1].Trim();
                                    if (str3 != "0" && str3 != "")
                                    {
                                        num2 = Convert.ToInt32(str3);
                                    }
                                    stringBuilder.Append(string.Concat(str3, ","));
                                }
                                else if (string.Compare(strArrays2[0], "CatalogueName", true) == 0)
                                {
                                    if (base.Request.Params["acntype"].ToString() == "add")
                                    {
                                        string str6 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str4 = str6.Split(chrArray)[0];
                                    }
                                    if (base.Request.Params["acntype"].ToString() == "edit")
                                    {
                                        string str7 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        if (str7.Split(chrArray)[0] == "")
                                        {
                                            goto Label1;
                                        }
                                        BaseClass baseClass = this.objBase;
                                        string str8 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str4 = baseClass.SpecialEncode(str8.Split(chrArray)[0]);
                                        goto Label0;
                                    }
                                    Label1:
                                    str4 = strArrays2[1].Trim();
                                    Label0:
                                    if (this.hdnDrawStockFrom.Value.ToLower() == "m")
                                    {
                                        if (base.Request.QueryString["cataloguename"] != null)
                                        {
                                            this.ProductName = base.Request.QueryString["cataloguename"].ToString().Replace("<br/>", " - ");
                                        }
                                        str4 = string.Concat(this.ProductName, "<br/>", str4);
                                    }
                                    str4 = str4.Replace("\r\n", "<br/>");
                                }
                                else if (strArrays2[0].Trim() == "Markup")
                                {
                                    stringBuilder.Append(((strArrays2[1].Trim() ?? "") == "" ? "0," : string.Concat(strArrays2[1].Trim().Replace(",", ""), ",")));
                                    if (!(this.MainType.ToLower() == "edit") || !(this.modulename.ToLower() == "jobs") && !(this.modulename.ToLower() == "invoice") && !(this.modulename.ToLower() == "orders") || (int)array.Length > 2)
                                    {
                                        flag2 = true;
                                        num7 = j + 1;
                                    }
                                    else if (this.ParentEstimateItemID <= (long)0)
                                    {
                                        num7 = 1;
                                    }
                                    else
                                    {
                                        foreach (DataRow row2 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                                        {
                                            num7 = Convert.ToInt16(row2["QtyNumber"].ToString());
                                        }
                                        if (num7 == 0)
                                        {
                                            num7 = 1;
                                        }
                                    }
                                    stringBuilder.Append(string.Concat(num7, ","));
                                    stringBuilder.Append(string.Concat("'", this.Objclss.SpecialEncode(str4), "',"));
                                    stringBuilder.Append(string.Concat("'", this.Objclss.SpecialEncode(empty2), "',"));
                                    str = new object[] { this.ParentItemID, ",'", this.EstTypeFromSP, "'" };
                                    stringBuilder.Append(string.Concat(str));
                                    stringBuilder.Append(string.Concat(catalogueProfitAndTax, ","));
                                }
                                else if (strArrays2[0].Trim() == "Height")
                                {
                                    if (strArrays2[1].Trim().Length == 0)
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                    else if (strArrays2[1].Trim().ToString().ToLower() != "undefined")
                                    {
                                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                }
                                else if (strArrays2[0].Trim() == "Width")
                                {
                                    if (strArrays2[1].Trim().Length == 0)
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                    else if (strArrays2[1].Trim().ToString().ToLower() != "undefined")
                                    {
                                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                }
                                else if (strArrays2[0].Trim() == "ReplenishProduct")
                                {
                                    flag = (strArrays2[1].Trim().ToString().ToLower() != "true" ? false : true);
                                }
                                else if (strArrays2[0].Trim() == "QtyusedforCalculation")
                                {
                                    Convert.ToInt32(strArrays2[1].Trim());
                                    stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                }
                            }
                        }
                        stringBuilder.Append(string.Concat(this.hid_IsSides.Value, ","));
                        bool flag3 = EstimateBasePage.EstPriceCatalogue_IsBackOrder_Check(num, num1 * num2, this.EstimateItemID);
                        if (flag)
                        {
                            flag3 = false;
                        }
                        stringBuilder.Append(string.Concat("'", flag3, "',1)"));
                    }
                }
                string empty3 = string.Empty;
                string str9 = string.Concat(" Delete from [TABLE_EstPriceCatalogue] where EstimateItemID=", this.EstimateItemID, "; ");
                stringBuilder.Append(string.Concat(" ; delete from tb_EstPriceCatAddOptionDetails where estimateitemid=", this.EstimateItemID, " "));
                if (flag)
                {
                    empty3 = string.Concat("; UPDATE tb_Estimateitem  SET IsStockReplenishitem = 1 WHERE EstimateItemID=", this.EstimateItemID);
                }
                if (this.MainType.ToLower() == "edit" && num4 != num)
                {
                    empty3 = string.Concat(empty3, "; UPDATE tb_Estimateitem  SET IsStockReplenishitem = 0 , IsStockReplenished = 0 WHERE EstimateItemID=", this.EstimateItemID);
                }
                int companyID = this.CompanyID;
                strArrays = new string[] { str9, " ", stringBuilder.ToString(), " ", empty3.ToString() };
                EstimateBasePage.price_catalogue_insert(companyID, string.Concat(strArrays), this.EstimateItemID);
                EstimatesBasePage.estimate_othercost_typeid_update(this.CompanyID, this.EstimateItemID, "C", (long)0);
            }
            if (base.Request.Params["parentestitemid"] == null || !(base.Request.Params["parentestitemid"] != "0"))
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (base.Request.Params["acntype"].ToString() == "add")
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0 || string.Compare(this.modulename, "orders", true) == 0)
                {
                    if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                    {
                        JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                        EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                    }
                    long num8 = (long)0;
                    foreach (DataRow dataRow2 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dataRow2["StatusID"])))
                        {
                            continue;
                        }
                        num8 = (long)Convert.ToInt32(Convert.ToString(dataRow2["StatusID"]));
                    }
                    if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                    {
                        this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(num8), "job", this.EstimateItemID, (long)0);
                    }
                    DataTable dataTable1 = new DataTable();
                    dataTable1 = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, (long)0, this.EstimateItemID, this.modulename);
                    if (dataTable1.Rows.Count > 0)
                    {
                        this.IsStockReplenishItem = Convert.ToBoolean(dataTable1.Rows[0]["IsStockReplenishItem"]);
                        this.IsStockReplenished = Convert.ToBoolean(dataTable1.Rows[0]["IsStockReplenished"]);
                    }
                    if (!this.IsStockReplenishItem)
                    {
                        BaseClass baseClass1 = new BaseClass();
                        string str10 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                        string str11 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str12 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str13 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        if (str10 == "e")
                        {
                            foreach (DataRow row3 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                if (row3["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str11, "self", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (row3["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str11, Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (row3["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row3["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str11, "multiple", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else
                                {
                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str11, "additional option", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                            }
                        }
                        else if (str10 == "j" && baseClass1.Return_StockManagementSettings("SA_JobStatusID") == num8.ToString())
                        {
                            foreach (DataRow dataRow3 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str11, "self", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str11, Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str11, "multiple", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else
                                {
                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str11, "additional option", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                            }
                        }
                        if (str13 == "e" || string.Compare(this.modulename, "invoice", true) == 0)
                        {
                            foreach (DataRow row4 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else
                                {
                                    baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                            }
                        }
                        else if (str13 != "j" && string.Compare(this.modulename, "invoice", true) != 0)
                        {
                            if ((str13 == "c" || string.Compare(this.modulename, "invoice", true) == 0) && string.Compare(this.modulename, "invoice", true) == 0)
                            {
                                foreach (DataRow dataRow4 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    base.Session["StockItemType"] = "C";
                                    if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else
                                    {
                                        baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                }
                            }
                        }
                        else if (baseClass1.Return_StockManagementSettings("SR_JobStatusID") == num8.ToString())
                        {
                            foreach (DataRow row5 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                base.Session["StockItemType"] = "C";
                                if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else
                                {
                                    baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                            }
                        }
                    }
                }
                if (this.modulename == "jobs")
                {
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    foreach (DataRow dataRow5 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                    {
                        empty4 = dataRow5["PhraseText"].ToString();
                    }
                    foreach (DataRow row6 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                    {
                        empty5 = row6["PhraseText"].ToString();
                    }
                    EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty4, empty5);
                }
            }
            if (base.Request.Params["acntype"].ToString() == "edit")
            {
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && !flag2)
                {
                    short num9 = 1;
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, num9, this.EstimateID);
                    }
                }
                if (this.hdn_Update_Item_Descriptions.Value.ToLower() == "true")
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0 || string.Compare(this.modulename, "orders", true) == 0)
                {
                    if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                    {
                        EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                    }
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, (long)0, this.EstimateItemID, this.modulename);
                    if (dataTable2.Rows.Count > 0)
                    {
                        this.IsStockReplenishItem = Convert.ToBoolean(dataTable2.Rows[0]["IsStockReplenishItem"]);
                        this.IsStockReplenished = Convert.ToBoolean(dataTable2.Rows[0]["IsStockReplenished"]);
                    }
                    if (!this.IsStockReplenishItem)
                    {
                        long num10 = (long)0;
                        foreach (DataRow dataRow6 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(dataRow6["StatusID"])))
                            {
                                continue;
                            }
                            num10 = (long)Convert.ToInt32(Convert.ToString(dataRow6["StatusID"]));
                        }
                        BaseClass baseClass2 = new BaseClass();
                        string str14 = baseClass2.Return_StockManagementSettings("SA_EprintMISJobs");
                        string str15 = baseClass2.Return_StockManagementSettings("SR_StockReductionMethod");
                        string str16 = baseClass2.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                        string str17 = baseClass2.Return_StockManagementSettings("SR_WhenStockReduced");
                        string lower = string.Empty;
                        string empty6 = string.Empty;
                        string lower1 = string.Empty;
                        string empty7 = string.Empty;
                        DataTable dataTable3 = new DataTable();
                        DataTable dataTable4 = new DataTable();
                        DataTable dataTable5 = new DataTable();
                        if (this.hid_OldPriceCatalogueID.Value == this.hidCatalogueID.Value)
                        {
                            num = Convert.ToInt64(this.hidCatalogueID.Value);
                            dataTable4 = baseClass2.ProductStockType_Select((long)this.CompanyID, num);
                            foreach (DataRow row7 in dataTable4.Rows)
                            {
                                lower = row7["DrawStockFrom"].ToString().ToLower();
                                if (row7["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                                }
                                else if (row7["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select((long)0, num, (long)this.CompanyID, "others", this.EstimateItemID);
                                }
                                else if (row7["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    if (row7["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        continue;
                                    }
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "additional option", this.EstimateItemID);
                                }
                                else
                                {
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                                }
                            }
                            foreach (DataRow dataRow7 in dataTable3.Rows)
                            {
                                if (Convert.ToInt32(dataRow7["TotalOldQty"].ToString()) == num1 * num2)
                                {
                                    continue;
                                }
                                if (str14 != "e")
                                {
                                    if (!(str14 == "j") || !(baseClass2.Return_StockManagementSettings("SA_JobStatusID") == num10.ToString()))
                                    {
                                        continue;
                                    }
                                    if (lower == "s")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                        if (empty6.ToLower() != "success")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else if (lower == "o")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                        if (empty6.ToLower() != "success")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else if (lower != "a")
                                    {
                                        if (lower != "m")
                                        {
                                            continue;
                                        }
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                        if (empty6.ToLower() != "success")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                        if (empty6.ToLower() != "success")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                }
                                else if (lower == "s")
                                {
                                    empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty6.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (lower == "o")
                                {
                                    empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty6.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass2.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (lower != "a")
                                {
                                    if (lower != "m")
                                    {
                                        continue;
                                    }
                                    empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty6.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else
                                {
                                    empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty6.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass2.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                            }
                        }
                        else
                        {
                            num = Convert.ToInt64(this.hidCatalogueID.Value);
                            long num11 = Convert.ToInt64(this.hid_OldPriceCatalogueID.Value);
                            dataTable4 = baseClass2.ProductStockType_Select((long)this.CompanyID, num);
                            foreach (DataRow row8 in dataTable4.Rows)
                            {
                                lower = row8["DrawStockFrom"].ToString().ToLower();
                                if (row8["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select(num11, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                                }
                                else if (row8["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select((long)0, num11, (long)this.CompanyID, "others", this.EstimateItemID);
                                }
                                else if (row8["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    if (row8["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        continue;
                                    }
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select(num11, (long)0, (long)this.CompanyID, "additional option", this.EstimateItemID);
                                }
                                else
                                {
                                    dataTable3 = baseClass2.StockProductRerunDetails_Select(num11, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                                }
                            }
                            dataTable5 = baseClass2.ProductStockType_Select((long)this.CompanyID, num11);
                            foreach (DataRow dataRow8 in dataTable5.Rows)
                            {
                                lower1 = dataRow8["DrawStockFrom"].ToString().ToLower();
                            }
                            foreach (DataRow row9 in dataTable3.Rows)
                            {
                                if (str14 != "e")
                                {
                                    if (!(str14 == "j") || !(baseClass2.Return_StockManagementSettings("SA_JobStatusID") == num10.ToString()))
                                    {
                                        continue;
                                    }
                                    if (lower1 == "s")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num11, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    else if (lower1 == "o")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num11, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    else if (lower1 == "a")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num11, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    else if (lower1 == "m")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num11, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    if (empty6.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    if (lower == "s")
                                    {
                                        baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else if (lower == "o")
                                    {
                                        baseClass2.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else if (lower != "a")
                                    {
                                        if (lower != "m")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else
                                    {
                                        baseClass2.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                }
                                else
                                {
                                    if (lower1 == "s")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num11, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    else if (lower1 == "o")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num11, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    else if (lower1 == "a")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num11, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    else if (lower1 == "m")
                                    {
                                        empty6 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num11, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    }
                                    if (empty6.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    if (lower == "s")
                                    {
                                        baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else if (lower == "o")
                                    {
                                        baseClass2.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else if (lower != "a")
                                    {
                                        if (lower != "m")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                    else
                                    {
                                        baseClass2.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                    }
                                }
                            }
                        }
                        if (empty6.ToLower() == "success")
                        {
                            if (str17 == "e" || string.Compare(this.modulename, "invoice", true) == 0)
                            {
                                foreach (DataRow dataRow9 in baseClass2.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    if (dataRow9["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass2.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow9["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        baseClass2.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow9["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow9["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else
                                    {
                                        baseClass2.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                }
                            }
                            else if (str17 != "j" && string.Compare(this.modulename, "invoice", true) != 0)
                            {
                                if (str17 == "c" || string.Compare(this.modulename, "invoice", true) == 0)
                                {
                                    foreach (DataRow row10 in baseClass2.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                    {
                                        base.Session["StockItemType"] = "C";
                                        if (row10["DrawStockFrom"].ToString().ToLower() == "s")
                                        {
                                            baseClass2.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                        }
                                        else if (row10["DrawStockFrom"].ToString().ToLower() == "o")
                                        {
                                            baseClass2.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                        }
                                        else if (row10["DrawStockFrom"].ToString().ToLower() != "a")
                                        {
                                            if (row10["DrawStockFrom"].ToString().ToLower() != "m")
                                            {
                                                continue;
                                            }
                                            baseClass2.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                        }
                                        else
                                        {
                                            baseClass2.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                        }
                                    }
                                }
                            }
                            else if (baseClass2.Return_StockManagementSettings("SR_JobStatusID") == num10.ToString())
                            {
                                foreach (DataRow dataRow10 in baseClass2.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    base.Session["StockItemType"] = "C";
                                    if (dataRow10["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass2.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow10["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        baseClass2.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow10["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (dataRow10["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        baseClass2.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else
                                    {
                                        baseClass2.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                }
                            }
                        }
                    }
                }
                if (this.ParentEstimateItemID == (long)0)
                {
                    EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "C");
                }
            }
            string empty8 = string.Empty;
            if (this.jobID != (long)0)
            {
                empty8 = string.Concat("&jID=", this.jobID);
            }
            string empty9 = string.Empty;
            if (this.InvoiceID != (long)0)
            {
                empty9 = string.Concat("&InvID=", this.InvoiceID);
            }
            if (this.ParentEstimateItemID == (long)0 && base.Request.Params["acntype"] != null && base.Request.Params["acntype"].ToString() == "add" && EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "C") > (long)0 && this.hdn_isAddMore.Value.ToString() == "0")
            {
                Type type = base.GetType();
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, empty8, empty9, "&parentestitemid=", this.EstimateItemID, "&parentesttype=C&maintype=edit&subitem=s';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type, " ", string.Concat(str), true);
            }
            string empty10 = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty10 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty10 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.tabtype == "job")
            {
                Type type1 = base.GetType();
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, "Jobs/job_item_form.aspx?frm=add&estid=", this.EstimateID, empty8, empty9, "';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type1, " ", string.Concat(str), true);
            }
            else if (this.tabtype == "invoice")
            {
                Type type2 = base.GetType();
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, "invoice/invoice_item_form.aspx?frm=add&estid=", this.EstimateID, empty8, empty9, "';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type2, " ", string.Concat(str), true);
            }
            else if (base.Request.Params["acntype"] != null && base.Request.Params["acntype"].ToString() == "edit" || this.frmcopyitem == "yes")
            {
                if (this.modulename == "orders")
                {
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        Type type3 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.EstimateItemID, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type3, " ", string.Concat(str), true);
                    }
                    else
                    {
                        Type type4 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.ParentEstimateItemID, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type4, " ", string.Concat(str), true);
                    }
                }
                else if (this.ParentEstimateItemID != (long)0)
                {
                    if (empty10.ToLower() != "yes")
                    {
                        Type type5 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.ParentEstimateItemID, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type5, " ", string.Concat(str), true);
                    }
                    else
                    {
                        Type type6 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.ParentEstimateItemID, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type6, " ", string.Concat(str), true);
                    }
                }
                else if (empty10.ToLower() != "yes")
                {
                    Type type7 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.EstimateItemID, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type7, " ", string.Concat(str), true);
                }
                else
                {
                    Type type8 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.EstimateItemID, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type8, " ", string.Concat(str), true);
                }
            }
            else if (this.modulename == "orders")
            {
                if (this.ParentEstimateItemID == (long)0)
                {
                    Type type9 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.EstimateItemID, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type9, " ", string.Concat(str), true);
                }
                else
                {
                    Type type10 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.ParentEstimateItemID, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type10, " ", string.Concat(str), true);
                }
            }
            else if (this.ParentEstimateItemID != (long)0)
            {
                if (empty10.ToLower() != "yes")
                {
                    Type type11 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.ParentEstimateItemID, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type11, " ", string.Concat(str), true);
                }
                else
                {
                    Type type12 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.ParentEstimateItemID, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type12, " ", string.Concat(str), true);
                }
            }
            else if (empty10.ToLower() != "yes")
            {
                string ddlvalue = string.Concat("&ddlValue=", base.Request.QueryString["ddlValue"].ToString());
                Type type13 = base.GetType();

                if (this.hdn_isAddMore.Value.ToString() == "1")
                {
                    if (base.Request.Params["fromPageType"].ToString() == "estimate")
                    {
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty8, "&InvID=0", ddlvalue, "&FromAddAnItem=Y&maintype=add&fromPageType=estimate';GetRadWindow().close();" };
                    }
                    else if (base.Request.Params["fromPageType"].ToString() == "job")
                    {
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty8, "&InvID=0", ddlvalue, "&FromAddAnItem=Y&maintype=add&fromPageType=job';GetRadWindow().close();" };
                    }
                    else if (base.Request.Params["fromPageType"].ToString() == "invoice")
                    {
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty8, "&InvID=0", ddlvalue, "&FromAddAnItem=Y&maintype=add&fromPageType=invoice';GetRadWindow().close();" };
                    }
                    else
                    {
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty8, "&InvID=0", ddlvalue, "&FromAddAnItem=Y&maintype=add&fromPageType=invoice';GetRadWindow().close();" };
                    }
                    //str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty8, empty9, "&InvID=0", "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    //str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty8, "&InvID=0", ddlvalue, "&FromAddAnItem=Y&maintype=add&fromPageType=job';GetRadWindow().close();" };
                }
                else
                {
                    //str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty8, empty9, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.EstimateItemID, "';GetRadWindow().close();" };
                }

                ScriptManager.RegisterStartupScript(this, type13, " ", string.Concat(str), true);
            }
            else
            {
                Type type14 = base.GetType();
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty8, empty9, "&EstItemID=", this.EstimateItemID, "';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type14, " ", string.Concat(str), true);
            }
            if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["AllowPrintReadyFile"]) && base.Request.Params["acntype"].ToString() == "add")
            {
                DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(num, this.CompanyID);
                if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                {
                    string empty11 = string.Empty;
                    EstimatesBasePage.PrintReadyfile_Insert(this.EstimateID, this.EstimateItemID, (long)this.UserID, this.modulename, "C");
                    str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                    empty11 = string.Concat(str);
                    str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    if (!Directory.Exists(string.Concat(str)))
                    {
                        str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                        Directory.CreateDirectory(string.Concat(str));
                    }
                    if (File.Exists(empty11))
                    {
                        str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        string str18 = string.Concat(str);
                        if (!Directory.Exists(str18))
                        {
                            Directory.CreateDirectory(str18);
                        }
                        File.Copy(empty11, string.Concat(str18, dataTable6.Rows[0]["PrintReadyFile"].ToString()), true);
                    }

                }

            }
            if (commonClass.CheckFTPEnable())
            {
                string filePath = string.Empty;
                DataTable dataTable7 = commonClass.Get_ProductFileByType(PriceCatalogueID, this.CompanyID);
                if (!string.IsNullOrEmpty(dataTable7.Rows[0]["PrintReadyFile"].ToString()))
                {
                    if (dataTable7.Rows[0]["FileType"].ToString() == "Editable")
                    {
                        object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable7.Rows[0]["PrintReadyFile"].ToString() };
                        filePath = string.Concat(editableTemplatePath);
                    }
                    else
                    {
                        string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                        filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable7.Rows[0]["PrintReadyFile"].ToString());
                    }
                    if (this.modulename == "jobs")
                    {
                        commonClass.UploadPrintReadyFileToSftp(this.CompanyID, PriceCatalogueID.ToString(), filePath, "JobCreation", "ProductEstimate", this.EstimateItemID);
                    }
                    else if (this.modulename == "estimates")
                    {
                        commonClass.UploadPrintReadyFileToSftp(this.CompanyID, PriceCatalogueID.ToString(), filePath, "EstimateCreation", "ProductEstimate", this.EstimateItemID);
                    }
                    else if (this.modulename == "invoice")
                    {
                        commonClass.UploadPrintReadyFileToSftp(this.CompanyID, PriceCatalogueID.ToString(), filePath, "InvoiceCreation", "ProductEstimate", this.EstimateItemID);
                    }
                }

            }

        }

        protected void ddlOtherMultiple_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOtherMultiple.SelectedItem.Value != "--Select--")
            {
                if (this.ddlOtherMultiple.SelectedItem.Value != "-1")
                {
                    this.hidCatalogueID.Value = this.ddlOtherMultiple.SelectedItem.Value;
                    DataTable dataTable = EstimateBasePage.OtherMultiple_product_Select(this.CompanyID, Convert.ToInt64(this.hidCatalogueID.Value));
                    if (dataTable.Rows.Count > 0)
                    {
                        if (this.ddlOtherMultiple1.SelectedIndex == -1)
                        {
                            this.BindOtherMultipleDropdownList1(Convert.ToInt64(this.hidCatalogueID.Value));
                            this.ddlOtherMultiple1.Items.Insert(0, "--Select--");
                        }
                            //this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                            //this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), 'm');
                            this.BindProductDetails(Convert.ToInt64(this.hidCatalogueID.Value), 'm');
                            this.pnlOtherMultiple1.Visible = true;
                    }
                    else
                    {
                        this.BindProductDetails(Convert.ToInt64(this.ddlOtherMultiple.SelectedItem.Value), 'm');
                    }
                        return;
                }
            }
            else if (this.ddlOtherMultiple.SelectedItem.Value == "--Select--" && this.ddlOtherMultiple.SelectedItem.Value != "-1")
            {
                if (base.Request.Params["PriceCatalogueID"] != null)
                {
                    EstimateProductcatalogueBind.PriceCatalogueID = Convert.ToInt64(base.Request.Params["PriceCatalogueID"]);
                }
                this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), 'm');
            }
        }

        protected void ddlOtherMultiple1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOtherMultiple1.SelectedItem.Value != "--Select--")
            {
                if (this.ddlOtherMultiple1.SelectedItem.Value != "-1")
                {
                    this.hidCatalogueID.Value = this.ddlOtherMultiple1.SelectedItem.Value;
                    DataTable dataTable = EstimateBasePage.OtherMultiple_product_Select(this.CompanyID, Convert.ToInt64(this.hidCatalogueID.Value));
                    if (dataTable.Rows.Count > 0)
                    {
                        if (this.ddlOtherMultiple2.SelectedIndex == -1)
                        {
                            this.BindOtherMultipleDropdownList1(Convert.ToInt64(this.hidCatalogueID.Value));
                            this.ddlOtherMultiple2.Items.Insert(0, "--Select--");
                        }
                        //this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                        this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), 'm');
                        this.pnlOtherMultiple2.Visible = true;
                    }
                    else
                    {
                        this.BindProductDetails(Convert.ToInt64(this.ddlOtherMultiple1.SelectedItem.Value), 'm');
                    }
                    return;
                }
            }
            else if (this.ddlOtherMultiple1.SelectedItem.Value == "--Select--" && this.ddlOtherMultiple1.SelectedItem.Value != "-1")
            {
                if (base.Request.Params["PriceCatalogueID"] != null)
                {
                    EstimateProductcatalogueBind.PriceCatalogueID = Convert.ToInt64(base.Request.Params["PriceCatalogueID"]);
                }
                this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), 'm');
            }
        }

        protected void ddlOtherMultiple2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOtherMultiple2.SelectedItem.Value != "--Select--")
            {
                if (this.ddlOtherMultiple2.SelectedItem.Value != "-1")
                {
                    this.hidCatalogueID.Value = this.ddlOtherMultiple2.SelectedItem.Value;
                    DataTable dataTable = EstimateBasePage.OtherMultiple_product_Select(this.CompanyID, Convert.ToInt64(this.hidCatalogueID.Value));
                    if (dataTable.Rows.Count > 0)
                    {
                        this.BindOtherMultipleDropdownList2(Convert.ToInt64(this.hidCatalogueID.Value));
                        this.ddlOtherMultiple2.Items.Insert(0, "--Select--");
                        //this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                        this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), 'm');
                        //this.pnlOtherMultiple2.Visible = true;
                    }
                    else
                    {
                        this.BindProductDetails(Convert.ToInt64(this.ddlOtherMultiple2.SelectedItem.Value), 'm');
                    }
                    return;
                }
            }
            else if (this.ddlOtherMultiple2.SelectedItem.Value == "--Select--" && this.ddlOtherMultiple2.SelectedItem.Value != "-1")
            {
                if (base.Request.Params["PriceCatalogueID"] != null)
                {
                    EstimateProductcatalogueBind.PriceCatalogueID = Convert.ToInt64(base.Request.Params["PriceCatalogueID"]);
                }
                this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), 'm');
            }
        }

        public void Insert_activity_history(int CompanyID, long ModuleID, long EstimateItemID)
        {
            if (this.modulename.Contains("job"))
            {
                ModuleID = this.jobID;
            }
            else if (!this.modulename.Contains("invoice"))
            {
                ModuleID = this.EstimateID;
            }
            else
            {
                ModuleID = this.InvoiceID;
            }
            if (string.Compare(this.MainType, "add", true) == 0)
            {
                string str = "C";
                string str1 = "Price Catalogue Item";
                string empty = string.Empty;
                foreach (DataRow row in Notes.select_item_Title_for_Activity_History(CompanyID, ModuleID, EstimateItemID, str).Rows)
                {
                    empty = row["itemtitle"].ToString();
                }
                if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
                {
                    string empty1 = string.Empty;
                    foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        empty1 = dataRow["rownumber"].ToString();
                    }
                    if (this.modulename == "estimates")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = empty1;
                        this.objnotes.Estimate_type = str1;
                    }
                    else if (this.modulename == "jobs")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                        this.objnotes.Item_number = empty1;
                        this.objnotes.Job_type = str1;
                    }
                    else if (this.modulename == "invoice")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                        this.objnotes.Item_number = empty1;
                        this.objnotes.Invoice_type = str1;
                    }
                    else if (this.modulename == "orders")
                    {
                        this.objnotes.Item_title = empty;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                        this.objnotes.Item_number = empty1;
                        this.objnotes.Estimate_type = str1;
                    }
                    this.objnotes.ModuleID = ModuleID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.objJava;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = EstimateItemID;
                    this.objN.NotesAdd(this.objnotes);
                    return;
                }
                string empty2 = string.Empty;
                if (this.modulename == "estimates")
                {
                    foreach (DataRow row1 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                    {
                        empty2 = row1["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                else if (this.modulename == "jobs")
                {
                    foreach (DataRow dataRow1 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "job", (long)0).Rows)
                    {
                        empty2 = dataRow1["jobnumber"].ToString();
                    }
                    this.objnotes.Job_type = str1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Job_number = empty2;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
                }
                else if (this.modulename == "invoice")
                {
                    foreach (DataRow row2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "invoice", (long)0).Rows)
                    {
                        empty2 = row2["invoicenumber"].ToString();
                    }
                    this.objnotes.Invoice_type = str1;
                    this.objnotes.Invoice_number = empty2;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
                }
                else if (this.modulename == "orders")
                {
                    foreach (DataRow dataRow2 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, ModuleID, "", (long)0).Rows)
                    {
                        empty2 = dataRow2["Estimatenumber"].ToString();
                    }
                    this.objnotes.Estimate_type = str1;
                    this.objnotes.Estimate_number = empty2;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit")
            {
                string str2 = "";
                string str3 = "Price Catalogue Item";
                if (this.modulename == "estimates")
                {
                    foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        str2 = (row3["IsParentItem"].ToString().ToLower() != "true" ? row3["ParentItemNumber"].ToString() : row3["rownumber"].ToString());
                    }
                    this.objnotes.Item_number = str2;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.Estimate_type = str3;
                    if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != ""))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else if (base.Request.Params["acntype"].ToLower() != "edit")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemRerun);
                    }
                }
                else if (this.modulename == "jobs")
                {
                    foreach (DataRow dataRow3 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        str2 = (dataRow3["IsParentItem"].ToString().ToLower() != "true" ? dataRow3["ParentItemNumber"].ToString() : dataRow3["rownumber"].ToString());
                    }
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.Item_number = str2;
                    if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != ""))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    }
                    else if (base.Request.Params["acntype"].ToLower() != "edit")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobSubItemRerun);
                    }
                }
                else if (this.modulename == "invoice")
                {
                    foreach (DataRow row4 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        str2 = (row4["IsParentItem"].ToString().ToLower() != "true" ? row4["ParentItemNumber"].ToString() : row4["rownumber"].ToString());
                    }
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = str2;
                    this.objnotes.ModuleName = "invoice";
                    if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != ""))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    else if (base.Request.Params["acntype"].ToLower() != "edit")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvSubItemRerun);
                    }
                }
                else if (this.modulename == "orders")
                {
                    foreach (DataRow dataRow4 in Notes.select_item_number_for_Activity_History(ModuleID, EstimateItemID, this.modulename).Rows)
                    {
                        str2 = (dataRow4["IsParentItem"].ToString().ToLower() != "true" ? dataRow4["ParentItemNumber"].ToString() : dataRow4["rownumber"].ToString());
                    }
                    this.objnotes.Estimate_type = str3;
                    this.objnotes.Item_number = str2;
                    this.objnotes.ModuleName = "webstoreorder";
                    if (this.ParentEstimateItemID == (long)0 || !(base.Request.Params["parentesttype"] != ""))
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrdItemRerun);
                    }
                    else if (base.Request.Params["acntype"].ToLower() != "edit")
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstSubItemAdded);
                    }
                    else
                    {
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.OrderSubItemRerun);
                    }
                }
                this.objnotes.ModuleID = ModuleID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass2 = this.objnotes;
                commonClass _commonClass2 = this.objJava;
                DateTime now1 = DateTime.Now;
                _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), CompanyID, this.UserID, true);
                this.objnotes.CompanyID = CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = EstimateItemID;
                this.objN.NotesAdd(this.objnotes);
            }
        }

        public string Insert_Warehouse_ItemDescription()
        {
            object wareItemDesc;
            object[] str;
            DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "C");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (string.Compare(row["DatabaseFieldName"].ToString(), "ItemTitle", true) == 0)
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind.WareItemDesc;
                    str = new object[] { wareItemDesc, "ItemTitle»", row["ScreenName"].ToString(), "»", this.hdn_title.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Description", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind1 = this;
                    object obj = usercontrolProductCatalogueEstimateProductcatalogueBind1.WareItemDesc;
                    object[] objArray = new object[] { obj, "µDescription»", row["ScreenName"].ToString(), "»", this.hdn_description.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind1.WareItemDesc = string.Concat(objArray);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Artwork", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind2 = this;
                    object wareItemDesc1 = usercontrolProductCatalogueEstimateProductcatalogueBind2.WareItemDesc;
                    object[] str1 = new object[] { wareItemDesc1, "µArtwork»", row["ScreenName"].ToString(), "»", this.hdn_artwork.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind2.WareItemDesc = string.Concat(str1);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Colour", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind3 = this;
                    object obj1 = usercontrolProductCatalogueEstimateProductcatalogueBind3.WareItemDesc;
                    object[] objArray1 = new object[] { obj1, "µColour»", row["ScreenName"].ToString(), "»", this.hdn_color.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind3.WareItemDesc = string.Concat(objArray1);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Size", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind4 = this;
                    object wareItemDesc2 = usercontrolProductCatalogueEstimateProductcatalogueBind4.WareItemDesc;
                    object[] str2 = new object[] { wareItemDesc2, "µSize»", row["ScreenName"].ToString(), "»", this.hdn_size.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind4.WareItemDesc = string.Concat(str2);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Material", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind5 = this;
                    object obj2 = usercontrolProductCatalogueEstimateProductcatalogueBind5.WareItemDesc;
                    object[] objArray2 = new object[] { obj2, "µMaterial»", row["ScreenName"].ToString(), "»", this.hdn_Material.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind5.WareItemDesc = string.Concat(objArray2);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Delivery", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind6 = this;
                    object wareItemDesc3 = usercontrolProductCatalogueEstimateProductcatalogueBind6.WareItemDesc;
                    object[] str3 = new object[] { wareItemDesc3, "µDelivery»", row["ScreenName"].ToString(), "»", this.hdn_Delivery.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind6.WareItemDesc = string.Concat(str3);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Finishing", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind7 = this;
                    object obj3 = usercontrolProductCatalogueEstimateProductcatalogueBind7.WareItemDesc;
                    object[] objArray3 = new object[] { obj3, "µFinishing»", row["ScreenName"].ToString(), "»", this.hdn_Finish.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind7.WareItemDesc = string.Concat(objArray3);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Proofs", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind8 = this;
                    object wareItemDesc4 = usercontrolProductCatalogueEstimateProductcatalogueBind8.WareItemDesc;
                    object[] str4 = new object[] { wareItemDesc4, "µProofs»", row["ScreenName"].ToString(), "»", this.hdn_Proofs.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind8.WareItemDesc = string.Concat(str4);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Packing", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind9 = this;
                    object obj4 = usercontrolProductCatalogueEstimateProductcatalogueBind9.WareItemDesc;
                    object[] objArray4 = new object[] { obj4, "µPacking»", row["ScreenName"].ToString(), "»", this.hdn_Packing.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind9.WareItemDesc = string.Concat(objArray4);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Notes", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind10 = this;
                    object wareItemDesc5 = usercontrolProductCatalogueEstimateProductcatalogueBind10.WareItemDesc;
                    object[] str5 = new object[] { wareItemDesc5, "µNotes»", row["ScreenName"].ToString(), "»", this.hdn_Notes.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind10.WareItemDesc = string.Concat(str5);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Instructions", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind11 = this;
                    object obj5 = usercontrolProductCatalogueEstimateProductcatalogueBind11.WareItemDesc;
                    object[] objArray5 = new object[] { obj5, "µInstructions»", row["ScreenName"].ToString(), "»", this.hdn_terms.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind11.WareItemDesc = string.Concat(objArray5);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 1", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind12 = this;
                    object wareItemDesc6 = usercontrolProductCatalogueEstimateProductcatalogueBind12.WareItemDesc;
                    object[] str6 = new object[] { wareItemDesc6, "µCustom Description 1»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription1.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind12.WareItemDesc = string.Concat(str6);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 2", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind13 = this;
                    object obj6 = usercontrolProductCatalogueEstimateProductcatalogueBind13.WareItemDesc;
                    object[] objArray6 = new object[] { obj6, "µCustom Description 2»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription2.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind13.WareItemDesc = string.Concat(objArray6);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 3", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind14 = this;
                    object wareItemDesc7 = usercontrolProductCatalogueEstimateProductcatalogueBind14.WareItemDesc;
                    object[] str7 = new object[] { wareItemDesc7, "µCustom Description 3»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription3.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind14.WareItemDesc = string.Concat(str7);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 4", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind15 = this;
                    object obj7 = usercontrolProductCatalogueEstimateProductcatalogueBind15.WareItemDesc;
                    object[] objArray7 = new object[] { obj7, "µCustom Description 4»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription4.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind15.WareItemDesc = string.Concat(objArray7);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 5", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind16 = this;
                    object wareItemDesc8 = usercontrolProductCatalogueEstimateProductcatalogueBind16.WareItemDesc;
                    object[] str8 = new object[] { wareItemDesc8, "µCustom Description 5»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription5.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind16.WareItemDesc = string.Concat(str8);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 6", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind17 = this;
                    object obj8 = usercontrolProductCatalogueEstimateProductcatalogueBind17.WareItemDesc;
                    object[] objArray8 = new object[] { obj8, "µCustom Description 6»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription6.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind17.WareItemDesc = string.Concat(objArray8);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 7", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind18 = this;
                    object wareItemDesc9 = usercontrolProductCatalogueEstimateProductcatalogueBind18.WareItemDesc;
                    object[] str9 = new object[] { wareItemDesc9, "µCustom Description 7»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription7.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind18.WareItemDesc = string.Concat(str9);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 8", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind19 = this;
                    object obj9 = usercontrolProductCatalogueEstimateProductcatalogueBind19.WareItemDesc;
                    object[] objArray9 = new object[] { obj9, "µCustom Description 8»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription8.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind19.WareItemDesc = string.Concat(objArray9);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 9", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind20 = this;
                    object wareItemDesc10 = usercontrolProductCatalogueEstimateProductcatalogueBind20.WareItemDesc;
                    object[] str10 = new object[] { wareItemDesc10, "µCustom Description 9»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription9.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind20.WareItemDesc = string.Concat(str10);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 10", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind21 = this;
                    object obj10 = usercontrolProductCatalogueEstimateProductcatalogueBind21.WareItemDesc;
                    object[] objArray10 = new object[] { obj10, "µCustom Description 10»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription10.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind21.WareItemDesc = string.Concat(objArray10);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 11", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind22 = this;
                    object wareItemDesc11 = usercontrolProductCatalogueEstimateProductcatalogueBind22.WareItemDesc;
                    object[] str11 = new object[] { wareItemDesc11, "µCustom Description 11»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription11.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind22.WareItemDesc = string.Concat(str11);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 12", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind23 = this;
                    object obj11 = usercontrolProductCatalogueEstimateProductcatalogueBind23.WareItemDesc;
                    object[] objArray11 = new object[] { obj11, "µCustom Description 12»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription12.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind23.WareItemDesc = string.Concat(objArray11);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 13", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind24 = this;
                    object wareItemDesc12 = usercontrolProductCatalogueEstimateProductcatalogueBind24.WareItemDesc;
                    object[] str12 = new object[] { wareItemDesc12, "µCustom Description 13»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription13.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind24.WareItemDesc = string.Concat(str12);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 14", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind25 = this;
                    object obj12 = usercontrolProductCatalogueEstimateProductcatalogueBind25.WareItemDesc;
                    object[] objArray12 = new object[] { obj12, "µCustom Description 14»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription14.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind25.WareItemDesc = string.Concat(objArray12);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 15", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind26 = this;
                    object wareItemDesc13 = usercontrolProductCatalogueEstimateProductcatalogueBind26.WareItemDesc;
                    object[] str13 = new object[] { wareItemDesc13, "µCustom Description 15»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription15.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind26.WareItemDesc = string.Concat(str13);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 16", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind27 = this;
                    object obj13 = usercontrolProductCatalogueEstimateProductcatalogueBind27.WareItemDesc;
                    object[] objArray13 = new object[] { obj13, "µCustom Description 16»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription16.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind27.WareItemDesc = string.Concat(objArray13);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 17", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind28 = this;
                    object wareItemDesc14 = usercontrolProductCatalogueEstimateProductcatalogueBind28.WareItemDesc;
                    str = new object[] { wareItemDesc14, "µCustom Description 17»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription17.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind28.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 18", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind29 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind29.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 18»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription18.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind29.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 19", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind30 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind30.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 19»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription19.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind30.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 20", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind31 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind31.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 20»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription20.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind31.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 21", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind32 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind32.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 21»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription21.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind32.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 22", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind33 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind33.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 22»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription22.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind33.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 23", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind34 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind34.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 23»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription23.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind34.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 24", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind35 = this;
                    wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind35.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 24»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription24.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolProductCatalogueEstimateProductcatalogueBind35.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 25", true) != 0 || !Convert.ToBoolean(row["IsChecked"]))
                {
                    continue;
                }
                EstimateProductcatalogueBind usercontrolProductCatalogueEstimateProductcatalogueBind36 = this;
                wareItemDesc = usercontrolProductCatalogueEstimateProductcatalogueBind36.WareItemDesc;
                str = new object[] { wareItemDesc, "µCustom Description 25»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription25.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                usercontrolProductCatalogueEstimateProductcatalogueBind36.WareItemDesc = string.Concat(str);
            }
            return this.WareItemDesc;
        }

        public void MultipleChoice_DropDownBind(DataTable dtMul, DropDownList ddlMutiple, PlaceHolder plhPriceCalculator, string Type, string ActionType, int SelectedID)
        {
            if (Type != "matrix")
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "Label";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
            }
            else
            {
                ddlMutiple.DataSource = dtMul;
                ddlMutiple.DataTextField = "ToQuantity";
                ddlMutiple.DataValueField = "FormulaNew";
                ddlMutiple.DataBind();
                plhPriceCalculator.Controls.Add(ddlMutiple);
            }
            if (ActionType == "edit")
            {
                int num = 0;
                foreach (DataRow row in dtMul.Rows)
                {
                    if (Convert.ToInt32(row["SelectedID"]) == SelectedID)
                    {
                        ddlMutiple.SelectedIndex = num;
                    }
                    num++;
                }
            }
        }

        protected void Onclick_btnSave(object sender, EventArgs e)
        {
            object[] str;
            decimal profitMargin;
            string[] strArrays;
            int taxIDByProductID;
            char[] chrArray;
            string empty = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            string empty1 = string.Empty;
            string catalogueProfitAndTax = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            long num = (long)0;
            int num1 = 0;
            int num2 = 1;
            decimal num3 = new decimal(0);
            bool flag = false;
            long num4 = (long)0;
            DataTable dataTable = new DataTable();
            bool TaxPrecedence = EstimatesBasePage.TaxPrecedence_Select(this.EstimateID);
            if (this.EstimateItemID != (long)0)
            {
                dataTable = EstimatesBasePage.OrderItemID_Select(this.EstimateID, this.EstimateItemID);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                num4 = Convert.ToInt64(row["ProductID"]);
            }
            long num5 = (long)0;
            if (base.Request.Params["PriceCatalogueID"] != null)
            {
                num5 = Convert.ToInt64(base.Request.Params["PriceCatalogueID"]);
            }
            if (base.Request.Params["acntype"].ToString() == "edit" && this.frmcopyitem != "yes")
            {
                empty1 = ",ProfitMargin,SubTotal,Tax,TaxID";
                //if (Convert.ToInt64(num4) == Convert.ToInt64(num5) || num4 == (long)0 || num5 == (long)0)
                //{
                //    catalogueProfitAndTax = this.CatalogueProfitAndTax;
                //}
                //else
                //{
                int deID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);

                str = new object[] { ",", null, null, null, null, null };
                profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                str[1] = profitMargin.ToString();
                str[2] = ",0,";
                if (deID == 0)
                {
                    profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, num5);
                }
                else
                {
                    profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                }
                str[3] = profitMargin.ToString();
                str[4] = ",";

                if (deID == 0 || TaxPrecedence == false)
                {
                    Int32 TaxId = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, num5);

                    str[5] = TaxId != 0 ? TaxId : EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                }
                else
                {
                    str[5] = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                }
                catalogueProfitAndTax = string.Concat(str);
                profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                profitMargin.ToString();
                if (deID == 0)
                {
                    profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, num5);
                }
                else
                {
                    profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                }
                profitMargin.ToString();
                //}
                if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0 || string.Compare(this.ParentEstimateType, "R", true) == 0)
                {
                    this.ParentItemID = this.EstimateBookletItemID;
                }
                else
                {
                    this.ParentItemID = this.ParentEstimateItemID;
                }
                foreach (DataRow dataRow in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                {
                    this.EstTypeFromSP = dataRow["EstimateType"].ToString();
                    this.ParentItemType = dataRow["EstimateType"].ToString();
                }
            }
            else if (base.Request.Params["acntype"].ToString() == "add" || this.frmcopyitem == "yes")
            {
                empty1 = ",ProfitMargin,SubTotal,Tax,TaxID";
                long parentEstimateItemID = (long)0;
                bool flag1 = false;
                int productIdByEstimatetItemId = 0;
                if (this.ParentEstimateItemID != (long)0)
                {
                    flag1 = false;
                    parentEstimateItemID = this.ParentEstimateItemID;
                }
                else
                {
                    flag1 = true;
                    parentEstimateItemID = (long)0;
                }
                if (flag1)
                {

                    int deID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);


                    strArrays = new string[] { ",", null, null, null, null, null };

                    profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    strArrays[1] = profitMargin.ToString();
                    strArrays[2] = ",0,";


                    if (deID == 0)
                    {
                        profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, num5);
                    }
                    else
                    {
                        profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                    }


                    strArrays[3] = profitMargin.ToString();
                    strArrays[4] = ",";
                    if (deID == 0 || TaxPrecedence == false)
                    {
                        Int32 TaxId = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, num5);
                        taxIDByProductID = TaxId != 0 ? TaxId : EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                        //taxIDByProductID = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, num5);
                    }
                    else
                    {
                        taxIDByProductID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    }
                    strArrays[5] = taxIDByProductID.ToString();
                    catalogueProfitAndTax = string.Concat(strArrays);
                }
                else if (this.ParentEstimateType != "C")
                {
                    strArrays = new string[] { ",", null, null, null, null, null };
                    profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    strArrays[1] = profitMargin.ToString();
                    strArrays[2] = ",0,";
                    profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                    strArrays[3] = profitMargin.ToString();
                    strArrays[4] = ",";
                    taxIDByProductID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    strArrays[5] = taxIDByProductID.ToString();
                    catalogueProfitAndTax = string.Concat(strArrays);
                }
                else
                {
                    int deID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);

                    productIdByEstimatetItemId = EstimatesBasePage.GetProductId_ByEstimatetItemId(this.CompanyID, Convert.ToInt32(this.ParentEstimateItemID));
                    strArrays = new string[] { ",", null, null, null, null, null };
                    profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                    strArrays[1] = profitMargin.ToString();
                    strArrays[2] = ",0,";
                    if (deID == 0)
                    {
                        profitMargin = EstimatesBasePage.GetTaxRateByProductID(this.CompanyID, (long)productIdByEstimatetItemId);
                    }
                    else
                    {
                        profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                    }
                    strArrays[3] = profitMargin.ToString();
                    strArrays[4] = ",";

                    if (deID == 0 || TaxPrecedence == false)
                    {
                        taxIDByProductID = EstimatesBasePage.GetTaxIDByProductID(this.CompanyID, (long)productIdByEstimatetItemId);
                    }
                    else
                    {
                        taxIDByProductID = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                    }
                    strArrays[5] = taxIDByProductID.ToString();
                    catalogueProfitAndTax = string.Concat(strArrays);
                }
                if (this.InvoiceID <= (long)0)
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "C", flag1, parentEstimateItemID, num5);
                }
                else
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "C", flag1, parentEstimateItemID, num5);
                }
                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                if (this.jobID > (long)0)
                {
                    long estimateItemID = this.EstimateItemID;
                    long num6 = this.jobID;
                    commonClass _commonClass = this.commclass;
                    DateTime now = DateTime.Now;
                    JobBasePage.EstimateItems_ProgressToJob(estimateItemID, num6, false, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                }
                if (this.InvoiceID > (long)0)
                {
                    InvoiceBasePage.EstimateItems_ProgressToInvoice(this.EstimateItemID, this.InvoiceID);
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0 || string.Compare(this.ParentEstimateType, "R", true) == 0)
                    {
                        this.ParentItemID = this.EstimateBookletItemID;
                    }
                    else
                    {
                        this.ParentItemID = this.ParentEstimateItemID;
                    }
                    foreach (DataRow row1 in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                    {
                        this.EstTypeFromSP = row1["EstimateType"].ToString();
                        this.ParentItemType = row1["EstimateType"].ToString();
                        row1["EstimateType"].ToString();
                    }
                }
                else
                {
                    this.EstSingleItemID = (long)0;
                    this.EstTypeFromSP = "";
                }
            }
            int num7 = 0;
            bool flag2 = false;
            if (this.EstimateItemID != (long)0)
            {
                string value = this.hidCatalogueData.Value;
                chrArray = new char[] { 'µ' };
                string[] array = value.Split(chrArray);
                List<string> strs = new List<string>(array);
                for (int i = 0; i < strs.Count; i++)
                {
                    if (strs[i].IndexOf("Cost»±") != -1)
                    {
                        strs.RemoveAt(i);
                        i = 0;
                    }
                }
                array = strs.ToArray();
                for (int j = 0; j < (int)array.Length; j++)
                {
                    string str3 = array[j];
                    chrArray = new char[] { '±' };
                    string[] strArrays1 = str3.Split(chrArray);
                    string str4 = "0";
                    string str5 = "";
                    string empty3 = string.Empty;
                    if (base.Request.Params["acntype"].ToString() == "add" || this.hid_GetItemDescription.Value != "")
                    {
                        base.Session["PricecatalogItemTitle"] = this.hid_GetItemDescription.Value;
                    }
                    if (!string.IsNullOrEmpty(array[j]))
                    {
                        this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
                        empty3 = this.Objclss.SpecialEncode(this.WareItemDesc);
                        if (base.Request.Params["acntype"].ToString() == "edit" && this.frmcopyitem != "yes" && this.hid_GetItemDescription.Value.Trim().Length == 0)
                        {
                            foreach (DataRow dataRow1 in EstimatesBasePage.Pricecatalog_selecttiemdescription_byestimateitemid(this.CompanyID, this.EstimateItemID).Rows)
                            {
                                for (int k = 0; k <= 0; k++)
                                {
                                    empty3 = dataRow1["ItemDescription"].ToString();
                                }
                            }
                        }
                        stringBuilder.Append(string.Concat(" Insert into [TABLE_EstPriceCatalogue](EstimateItemID,PriceCatalogueID,Quantity,Price,MultipleOf,Markup,QtyNumber,ItemTitle,ItemDescription,ParentItemID,ParentItemType", empty1, ", Height, Width,QtyusedforCalculation, IsSides, IsBackOrder,approvestatus)"));
                        stringBuilder.Append(string.Concat(" Values (", this.EstimateItemID, ","));
                        for (int l = 0; l < (int)strArrays1.Length; l++)
                        {
                            string str6 = strArrays1[l];
                            chrArray = new char[] { '»' };
                            string[] strArrays2 = str6.Split(chrArray);
                            if (strArrays1[l].Length > 0)
                            {
                                if (strArrays2[0].Trim() == "PriceCatalogueID")
                                {
                                    num = Convert.ToInt64(strArrays2[1].Trim().ToString());
                                    stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                }
                                else if (strArrays2[0].Trim() == "Quantity")
                                {
                                    num1 = Convert.ToInt32(strArrays2[1].Trim().ToString());
                                    stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                }
                                else if (strArrays2[0].Trim() == "Price")
                                {
                                    num3 = Convert.ToDecimal(strArrays2[1].Trim());
                                }
                                else if (strArrays2[0].Trim() == "Cost")
                                {
                                    if (strArrays2[1].Trim().Trim().Length != 0)
                                    {
                                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append("0,");
                                    }
                                }
                                else if (string.Compare(strArrays2[0], "MultipleOf", true) == 0)
                                {
                                    str4 = strArrays2[1].Trim();
                                    if (str4 != "0" && str4 != "")
                                    {
                                        num2 = Convert.ToInt32(str4);
                                    }
                                    stringBuilder.Append(string.Concat(str4, ","));
                                }
                                else if (string.Compare(strArrays2[0], "CatalogueName", true) == 0)
                                {
                                    if (base.Request.Params["acntype"].ToString() == "add")
                                    {
                                        string str7 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str5 = str7.Split(chrArray)[0];
                                    }
                                    if (base.Request.Params["acntype"].ToString() == "edit")
                                    {
                                        string str8 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        if (str8.Split(chrArray)[0] == "")
                                        {
                                            goto Label1;
                                        }
                                        string str9 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str5 = str9.Split(chrArray)[0];
                                        goto Label0;
                                    }
                                    Label1:
                                    str5 = strArrays2[1].Trim();
                                    Label0:
                                    if (this.hdnDrawStockFrom.Value.ToLower() == "m")
                                    {
                                        if (base.Request.QueryString["cataloguename"] != null)
                                        {
                                            this.ProductName = base.Request.QueryString["cataloguename"].ToString().Replace("<br/>", " - ");
                                        }
                                        str5 = string.Concat(this.ProductName, "<br/>", str5);
                                    }
                                }
                                else if (strArrays2[0].Trim() == "Markup")
                                {
                                    stringBuilder.Append(((strArrays2[1].Trim() ?? "") == "" ? "0," : string.Concat(strArrays2[1].Trim().Replace(",", ""), ",")));
                                    if (this.modulename.ToLower() != "jobs" && this.modulename.ToLower() != "invoice" && this.modulename.ToLower() != "orders" || (int)array.Length > 2)
                                    {
                                        flag2 = true;
                                        num7 = j + 1;
                                    }
                                    else if (this.ParentEstimateItemID <= (long)0)
                                    {
                                        num7 = 1;
                                    }
                                    else
                                    {
                                        foreach (DataRow row2 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                                        {
                                            num7 = Convert.ToInt16(row2["QtyNumber"].ToString());
                                        }
                                        if (num7 == 0)
                                        {
                                            num7 = 1;
                                        }
                                    }
                                    stringBuilder.Append(string.Concat(num7, ","));
                                    stringBuilder.Append(string.Concat("'", this.Objclss.SpecialEncode(str5), "',"));
                                    stringBuilder.Append(string.Concat("'", this.Objclss.SpecialEncode(empty3), "',"));
                                    str = new object[] { this.ParentItemID, ",'", this.EstTypeFromSP, "'" };
                                    stringBuilder.Append(string.Concat(str));
                                    stringBuilder.Append(string.Concat(catalogueProfitAndTax, ","));
                                }
                                else if (strArrays2[0].Trim() == "Height")
                                {
                                    if (strArrays2[1].Trim().Length == 0)
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                    else if (strArrays2[1].Trim().ToString().ToLower() != "undefined")
                                    {
                                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                }
                                else if (strArrays2[0].Trim() == "Width")
                                {
                                    if (strArrays2[1].Trim().Length == 0)
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                    else if (strArrays2[1].Trim().ToString().ToLower() != "undefined")
                                    {
                                        stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append(" 0,");
                                    }
                                }
                                else if (strArrays2[0].Trim() == "ReplenishProduct")
                                {
                                    flag = (strArrays2[1].Trim().ToString().ToLower() != "true" ? false : true);
                                }
                                else if (strArrays2[0].Trim() == "QtyusedforCalculation")
                                {
                                    Convert.ToInt32(strArrays2[1].Trim());
                                    stringBuilder.Append(string.Concat(strArrays2[1].Trim(), ","));
                                }
                            }
                        }
                        stringBuilder.Append(string.Concat(this.hid_IsSides.Value, ","));
                        bool flag3 = EstimateBasePage.EstPriceCatalogue_IsBackOrder_Check(num, num1 * num2, this.EstimateItemID);
                        if (flag)
                        {
                            flag3 = false;
                        }
                        stringBuilder.Append(string.Concat("'", flag3, "',1)"));
                    }
                }
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                empty4 = string.Concat(" Delete from [TABLE_EstPriceCatalogue] where EstimateItemID=", this.EstimateItemID, "; ");
                if (flag)
                {
                    empty5 = string.Concat("; UPDATE tb_Estimateitem  SET IsStockReplenishitem = 1 WHERE EstimateItemID=", this.EstimateItemID);
                }
                if (this.MainType.ToLower() == "edit" && num4 != num)
                {
                    empty5 = string.Concat(empty5, "; UPDATE tb_Estimateitem  SET IsStockReplenishitem = 0, IsStockReplenished = 0 WHERE EstimateItemID=", this.EstimateItemID);
                }
                EstimateBasePage.price_catalogue_insert(this.CompanyID, string.Concat(empty4, " ", stringBuilder.ToString(), empty5.ToString()), this.EstimateItemID);
                EstimatesBasePage.estimate_othercost_typeid_update(this.CompanyID, this.EstimateItemID, "C", (long)0);
            }
            if (base.Request.Params["parentestitemid"] == null || !(base.Request.Params["parentestitemid"] != "0"))
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            if (base.Request.Params["acntype"].ToString() == "add")
            {
                EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                    //EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                }
                if (this.modulename == "jobs")
                {
                    string empty6 = string.Empty;
                    string empty7 = string.Empty;
                    foreach (DataRow dataRow2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                    {
                        empty6 = dataRow2["PhraseText"].ToString();
                    }
                    foreach (DataRow row3 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                    {
                        empty7 = row3["PhraseText"].ToString();
                    }
                    EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty6, empty7);
                }
            }
            if (base.Request.Params["acntype"].ToString() == "edit")
            {
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && !flag2)
                {
                    short num8 = 1;
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, num8, this.EstimateID);
                    }
                }
                if (this.hdn_Update_Item_Descriptions.Value.ToLower() == "true")
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                }
                if (this.ParentEstimateItemID == (long)0)
                {
                    EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "C");
                }
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            int num9 = 0;
            string value1 = this.hid_SaveToAdditionalItems.Value;
            chrArray = new char[] { 'µ' };
            string[] strArrays3 = value1.Split(chrArray);
            string freeTextQuestionLong = string.Empty;
            string calculation_type = string.Empty;
            for (int m = 0; m <= (int)strArrays3.Length - 1; m++)
            {
                long num10 = (long)0;
                string empty8 = string.Empty;
                if (strArrays3[m] != "")
                {
                    num9 = (m != 0 ? 0 : 1);
                    string str10 = strArrays3[m].ToString();
                    chrArray = new char[] { '~' };
                    string[] strArrays4 = str10.Split(chrArray);
                    for (int n = 0; n < (int)strArrays4.Length; n++)
                    {
                        if (strArrays4[n] != "")
                        {
                            string str11 = strArrays4[n].ToString();
                            chrArray = new char[] { '±' };
                            string[] strArrays5 = str11.Split(chrArray);
                            int num11 = 0;
                            for (int o = 0; o <= (int)strArrays5.Length - 1; o++)
                            {
                                if (strArrays5[o] != "")
                                {
                                    string str12 = strArrays5[o];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays6 = str12.Split(chrArray);
                                    if (strArrays6[0] != "")
                                    {
                                        if (strArrays6[0] == "QtyNo")
                                        {
                                            num11 = Convert.ToInt32(strArrays6[1]);
                                        }
                                        if (strArrays6[0] == "OthercostID")
                                        {
                                            this.OthercostID = Convert.ToInt64(strArrays6[1]);
                                        }
                                        else if (strArrays6[0] == "Formula")
                                        {
                                            this.Formula = strArrays6[1];
                                        }
                                        else if (strArrays6[0] == "MarkUp")
                                        {
                                            if (strArrays6[1] != "undefined")
                                            {
                                                this.MarkUp = Convert.ToDecimal(strArrays6[1]);
                                            }
                                            else
                                            {
                                                this.MarkUp = new decimal(0);
                                            }
                                            this.MarkupPercentage1 = this.MarkUp;
                                            this.MarkupPercentage2 = this.MarkUp;
                                            this.MarkupPercentage3 = this.MarkUp;
                                            this.MarkupPercentage4 = this.MarkUp;
                                        }
                                        else if (strArrays6[0] == "TotalPrice")
                                        {
                                            this.TotalPrice = Convert.ToDecimal(strArrays6[1]);
                                        }
                                        else if (strArrays6[0] == "SelectedID")
                                        {
                                            if (strArrays6[1] != "undefined")
                                            {
                                                this.SelectedID = Convert.ToInt64(strArrays6[1]);
                                            }
                                            else
                                            {
                                                this.SelectedID = (long)0;
                                            }
                                        }
                                        else if (strArrays6[0] == "SelectedValue")
                                        {
                                            this.SelectedValue = strArrays6[1];
                                        }
                                        else if (strArrays6[0] == "MarkUpValue")
                                        {
                                            this.MarkUpValue = Convert.ToDecimal(strArrays6[1]);
                                        }
                                        else if (strArrays6[0] == "SelectedPrice")
                                        {
                                            if (strArrays6[1] != "")
                                            {
                                                this.SelectedPrice = Convert.ToDecimal(strArrays6[1]);
                                            }
                                            else
                                            {
                                                this.SelectedPrice = new decimal(0);
                                            }
                                        }
                                        else if (strArrays6[0] == "SortOrderNo")
                                        {
                                            this.SortOrderNo = Convert.ToInt32(strArrays6[1]);
                                        }
                                        else if (strArrays6[0] == "ParentWebOtherCostID")
                                        {
                                            num10 = Convert.ToInt64(strArrays6[1]);
                                        }
                                        else if (strArrays6[0] == "WebOtherCostType")
                                        {
                                            empty8 = strArrays6[1];
                                        }
                                        else if (strArrays6[0] == "CalculationType")
                                        {
                                            calculation_type = strArrays6[1];
                                        }
                                    }
                                }
                                if (num11 == 1)
                                {
                                    this.MarkupPercentage1 = this.MarkUp;
                                    this.MarkupPercentage2 = new decimal(0);
                                    this.MarkupPercentage3 = new decimal(0);
                                    this.MarkupPercentage4 = new decimal(0);
                                    this.CostPrice1 = this.TotalPrice;
                                    this.CostPrice2 = new decimal(0);
                                    this.CostPrice3 = new decimal(0);
                                    this.CostPrice4 = new decimal(0);
                                    this.MarkupValue1 = this.MarkUpValue;
                                    this.MarkupValue2 = new decimal(0);
                                    this.MarkupValue3 = new decimal(0);
                                    this.MarkupValue4 = new decimal(0);
                                    this.SelectedPrice1 = this.SelectedPrice;
                                    this.SelectedPrice2 = new decimal(0);
                                    this.SelectedPrice3 = new decimal(0);
                                    this.SelectedPrice4 = new decimal(0);
                                    if (this.CostPrice1 == new decimal(0))
                                    {
                                        this.MarkupValue1 = new decimal(0);
                                    }
                                    this.TotalPriceExMarkup1 = this.CostPrice1 - this.MarkupValue1;
                                    this.TotalPriceExMarkup2 = new decimal(0);
                                    this.TotalPriceExMarkup3 = new decimal(0);
                                    this.TotalPriceExMarkup4 = new decimal(0);
                                    this.TotalPriceIncMarkup1 = this.CostPrice1;
                                    this.TotalPriceIncMarkup2 = new decimal(0);
                                    this.TotalPriceIncMarkup3 = new decimal(0);
                                    this.TotalPriceIncMarkup4 = new decimal(0);
                                }
                                else if (num11 == 2)
                                {
                                    this.MarkupPercentage2 = this.MarkUp;
                                    this.MarkupPercentage3 = new decimal(0);
                                    this.MarkupPercentage4 = new decimal(0);
                                    this.CostPrice2 = this.TotalPrice;
                                    this.CostPrice3 = new decimal(0);
                                    this.CostPrice4 = new decimal(0);
                                    this.MarkupValue2 = this.MarkUpValue;
                                    this.MarkupValue3 = new decimal(0);
                                    this.MarkupValue4 = new decimal(0);
                                    if (this.CostPrice2 == new decimal(0))
                                    {
                                        this.MarkupValue2 = new decimal(0);
                                    }
                                    this.SelectedPrice2 = this.SelectedPrice;
                                    this.SelectedPrice3 = new decimal(0);
                                    this.SelectedPrice4 = new decimal(0);
                                    this.TotalPriceExMarkup2 = this.CostPrice2 - this.MarkupValue2;
                                    this.TotalPriceExMarkup3 = new decimal(0);
                                    this.TotalPriceExMarkup4 = new decimal(0);
                                    this.TotalPriceIncMarkup2 = this.CostPrice2;
                                    this.TotalPriceIncMarkup3 = new decimal(0);
                                    this.TotalPriceIncMarkup4 = new decimal(0);
                                }
                                else if (num11 == 3)
                                {
                                    this.MarkupPercentage3 = this.MarkUp;
                                    this.MarkupPercentage4 = new decimal(0);
                                    this.CostPrice3 = this.TotalPrice;
                                    this.CostPrice4 = new decimal(0);
                                    this.MarkupValue3 = this.MarkUpValue;
                                    this.MarkupValue4 = new decimal(0);
                                    if (this.CostPrice3 == new decimal(0))
                                    {
                                        this.MarkupValue3 = new decimal(0);
                                    }
                                    this.SelectedPrice3 = this.SelectedPrice;
                                    this.SelectedPrice4 = new decimal(0);
                                    this.TotalPriceExMarkup3 = this.CostPrice3 - this.MarkupValue3;
                                    this.TotalPriceExMarkup4 = new decimal(0);
                                    this.TotalPriceIncMarkup3 = this.CostPrice3;
                                    this.TotalPriceIncMarkup4 = new decimal(0);
                                }
                                else if (num11 == 4)
                                {
                                    this.MarkupPercentage4 = this.MarkUp;
                                    this.CostPrice4 = this.TotalPrice;
                                    this.MarkupValue4 = this.MarkUpValue;
                                    if (this.CostPrice4 == new decimal(0))
                                    {
                                        this.MarkupValue4 = new decimal(0);
                                    }
                                    this.SelectedPrice4 = this.SelectedPrice;
                                    this.TotalPriceExMarkup4 = this.CostPrice4 - this.MarkupValue4;
                                    this.TotalPriceIncMarkup4 = this.CostPrice4;
                                }
                            }
                            if (!string.IsNullOrEmpty(calculation_type))
                            {
                                if (calculation_type == "l")
                                {
                                    freeTextQuestionLong = this.SelectedValue;
                                }
                                else
                                {
                                    freeTextQuestionLong = "";
                                }
                            }
                            DataSet dataSet = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(this.OthercostID));
                            foreach (DataRow dataRow3 in dataSet.Tables[0].Rows)
                            {
                                this.MainCalculationtype = dataRow3["MainCalculationType"].ToString();
                                this.CalculationType = this.MainCalculationtype;
                                this.OtherCostName = this.objBase.SpecialDecode(dataRow3["UserFriendlyName"].ToString());
                                this.EstimateOtherCostName = Convert.ToString(this.OtherCostName);
                            }
                            string value2 = this.hdn_allselectedqty.Value;
                            chrArray = new char[] { '~' };
                            string[] strArrays7 = value2.Split(chrArray);
                            string str13 = strArrays7[0];
                            string str14 = strArrays7[1];
                            string str15 = strArrays7[2];
                            string str16 = strArrays7[3];
                        }
                    }
                    /////////for decoration////////////////
                    if (SortOrderNo > 100)
                    {
                        this.CalculationType = "D";
                        empty8 = "Decoration";
                    }
                    EstimatesBasePage.Insert_EstPriceCatAddOptionDetails(this.EstimateAdditionalItemID, this.EstimateID, this.CalculationType, this.EstimateItemID, this.SelectedValue, this.MarkupPercentage1, this.MarkupPercentage2, this.MarkupPercentage3, this.MarkupPercentage4, this.CostPrice1, this.CostPrice2, this.CostPrice3, this.CostPrice4, this.SelectedID, this.MarkupValue1, this.MarkupValue2, this.MarkupValue3, this.MarkupValue4, this.SortOrderNo, this.SelectedPrice1, this.SelectedPrice2, this.SelectedPrice3, this.SelectedPrice4, this.EstimateOtherCostName, this.TotalPriceExMarkup1, this.TotalPriceExMarkup2, this.TotalPriceExMarkup3, this.TotalPriceExMarkup4, this.TotalPriceIncMarkup1, this.TotalPriceIncMarkup2, this.TotalPriceIncMarkup3, this.TotalPriceIncMarkup4, num9, this.OthercostID, num10, empty8, freeTextQuestionLong);
                }
            }
            // additional options saved now
            EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
            if (strArrays3[0] == "" && this.MainType == "edit")
            {
                long num12 = (long)0;
                string empty9 = string.Empty;
                num9 = 2;
                EstimatesBasePage.Insert_EstPriceCatAddOptionDetails(this.EstimateAdditionalItemID, this.EstimateID, this.CalculationType, this.EstimateItemID, this.SelectedValue, this.MarkupPercentage1, this.MarkupPercentage2, this.MarkupPercentage3, this.MarkupPercentage4, this.CostPrice1, this.CostPrice2, this.CostPrice3, this.CostPrice4, this.SelectedID, this.MarkupValue1, this.MarkupValue2, this.MarkupValue3, this.MarkupValue4, this.SortOrderNo, this.SelectedPrice1, this.SelectedPrice2, this.SelectedPrice3, this.SelectedPrice4, this.EstimateOtherCostName, this.TotalPriceExMarkup1, this.TotalPriceExMarkup2, this.TotalPriceExMarkup3, this.TotalPriceExMarkup4, this.TotalPriceIncMarkup1, this.TotalPriceIncMarkup2, this.TotalPriceIncMarkup3, this.TotalPriceIncMarkup4, num9, this.OthercostID, num12, empty9);
            }
            if (base.Request.Params["acntype"].ToString() == "add" && !flag)
            {
                EstimateBasePage.EstPriceCatalogue_IsBackOrder_Check(num, num1 * num2, this.EstimateItemID);
            }
            if (base.Request.Params["parentestitemid"] == null || !(base.Request.Params["parentestitemid"] != "0"))
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            if (base.Request.Params["acntype"].ToString() == "add" && (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0))
            {
                DataTable dataTable1 = new DataTable();
                dataTable1 = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, (long)0, this.EstimateItemID, this.modulename);
                if (dataTable1.Rows.Count > 0)
                {
                    this.IsStockReplenishItem = Convert.ToBoolean(dataTable1.Rows[0]["IsStockReplenishItem"]);
                    this.IsStockReplenished = Convert.ToBoolean(dataTable1.Rows[0]["IsStockReplenished"]);
                }
                if (!this.IsStockReplenishItem)
                {
                    long num13 = (long)0;
                    foreach (DataRow row4 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(row4["StatusID"])))
                        {
                            continue;
                        }
                        num13 = (long)Convert.ToInt32(Convert.ToString(row4["StatusID"]));
                    }
                    BaseClass baseClass = new BaseClass();
                    string str17 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                    string str18 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                    string str19 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                    string str20 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                    if (str17 == "e")
                    {
                        foreach (DataRow dataRow4 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str18, "self", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str18, Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str18, "multiple", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else
                            {
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str18, "additional option", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                        }
                    }
                    else if (str17 == "j" && baseClass.Return_StockManagementSettings("SA_JobStatusID") == num13.ToString())
                    {
                        foreach (DataRow row5 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str18, "self", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str18, Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row5["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str18, "multiple", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else
                            {
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str18, "additional option", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                        }
                    }
                    if (str20 == "e" || string.Compare(this.modulename, "invoice", true) == 0)
                    {
                        foreach (DataRow dataRow5 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (dataRow5["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else if (dataRow5["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else if (dataRow5["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow5["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else
                            {
                                baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                        }
                    }
                    else if (str20 != "j" && string.Compare(this.modulename, "invoice", true) != 0)
                    {
                        if ((str20 == "c" || string.Compare(this.modulename, "invoice", true) == 0) && string.Compare(this.modulename, "invoice", true) == 0)
                        {
                            foreach (DataRow row6 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                base.Session["StockItemType"] = "C";
                                if (row6["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else
                                {
                                    baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                            }
                        }
                    }
                    else if (baseClass.Return_StockManagementSettings("SR_JobStatusID") == num13.ToString())
                    {
                        foreach (DataRow dataRow6 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            base.Session["StockItemType"] = "C";
                            if (dataRow6["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else if (dataRow6["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else if (dataRow6["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow6["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else
                            {
                                baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                        }
                    }
                }
            }
            if (base.Request.Params["acntype"].ToString() == "edit" && (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0))
            {
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                }
                DataTable dataTable2 = new DataTable();
                dataTable2 = EstimateBasePage.Select_EstimateItemDetails(this.CompanyID, (long)0, this.EstimateItemID, this.modulename);
                if (dataTable2.Rows.Count > 0)
                {
                    this.IsStockReplenishItem = Convert.ToBoolean(dataTable2.Rows[0]["IsStockReplenishItem"]);
                    this.IsStockReplenished = Convert.ToBoolean(dataTable2.Rows[0]["IsStockReplenished"]);
                }
                if (!this.IsStockReplenishItem)
                {
                    long num14 = (long)0;
                    foreach (DataRow row7 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(row7["StatusID"])))
                        {
                            continue;
                        }
                        num14 = (long)Convert.ToInt32(Convert.ToString(row7["StatusID"]));
                    }
                    BaseClass baseClass1 = new BaseClass();
                    string str21 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                    string str22 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                    string str23 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                    string str24 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                    string lower = string.Empty;
                    string empty10 = string.Empty;
                    if (this.StockCancellationType == "a" || this.StockCancellationType == "p" && this.hdn_stockBackwarehoue.Value == "yes")
                    {
                        DataTable dataTable3 = this.ObjClass.ProductStockType_Select((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value));
                        foreach (DataRow dataRow7 in dataTable3.Rows)
                        {
                            if (dataRow7["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "self", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (dataRow7["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), "other", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str22, Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (dataRow7["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow7["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "multiple", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else
                            {
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str22, "additional option", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                        }
                    }
                    else
                    {
                        DataTable dataTable4 = new DataTable();
                        foreach (DataRow row8 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            lower = row8["DrawStockFrom"].ToString().ToLower();
                            if (row8["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                dataTable4 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                            }
                            else if (row8["DrawStockFrom"].ToString().ToLower() != "o")
                            {
                                if (row8["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                dataTable4 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                            }
                            else
                            {
                                dataTable4 = baseClass1.StockProductRerunDetails_Select((long)0, num, (long)this.CompanyID, "others", this.EstimateItemID);
                            }
                        }
                        foreach (DataRow dataRow8 in dataTable4.Rows)
                        {
                            if (Convert.ToInt32(dataRow8["TotalOldQty"].ToString()) == num1 * num2)
                            {
                                continue;
                            }
                            if (str21 != "e")
                            {
                                if (!(str21 == "j") || !(baseClass1.Return_StockManagementSettings("SA_JobStatusID") == num14.ToString()))
                                {
                                    continue;
                                }
                                if (lower == "s")
                                {
                                    empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty10.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "self", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else if (lower != "o")
                                {
                                    if (lower != "m")
                                    {
                                        continue;
                                    }
                                    empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty10.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "multiple", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                                else
                                {
                                    empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty10.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str22, Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                                }
                            }
                            else if (lower == "s")
                            {
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "self", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else if (lower != "o")
                            {
                                if (lower != "m")
                                {
                                    continue;
                                }
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "multiple", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else
                            {
                                empty10 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty10.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str22, Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                        }
                    }
                    if (empty10.ToLower() == "success")
                    {
                        if (str24 == "e" || string.Compare(this.modulename, "invoice", true) == 0)
                        {
                            foreach (DataRow row9 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                if (row9["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row9["DrawStockFrom"].ToString().ToLower() != "o")
                                {
                                    if (row9["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                            }
                        }
                        else if (str24 != "j" && string.Compare(this.modulename, "invoice", true) != 0)
                        {
                            if (str24 == "c" || string.Compare(this.modulename, "invoice", true) == 0)
                            {
                                foreach (DataRow dataRow9 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    base.Session["StockItemType"] = "C";
                                    if (dataRow9["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else if (dataRow9["DrawStockFrom"].ToString().ToLower() != "o")
                                    {
                                        if (dataRow9["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                    else
                                    {
                                        baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                    }
                                }
                            }
                        }
                        else if (baseClass1.Return_StockManagementSettings("SR_JobStatusID") == num14.ToString())
                        {
                            foreach (DataRow row10 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                base.Session["StockItemType"] = "C";
                                if (row10["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else if (row10["DrawStockFrom"].ToString().ToLower() != "o")
                                {
                                    if (row10["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                                else
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                                }
                            }
                        }
                    }
                }
            }
            string empty11 = string.Empty;
            if (this.jobID != (long)0)
            {
                empty11 = string.Concat("&jID=", this.jobID);
            }
            string empty12 = string.Empty;
            if (this.InvoiceID != (long)0)
            {
                empty12 = string.Concat("&InvID=", this.InvoiceID);
            }
            if (this.ParentItemID == (long)0 && base.Request.Params["acntype"] != null)
            {
                if (base.Request.Params["acntype"].ToString() == "add")
                {
                    if (EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "C") > (long)0 && this.hdn_isAddMore.Value.ToString() == "0")
                    {
                        Type type = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, empty11, empty12, "&parentesttype=C&maintype=edit&subitem=s';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type, " ", string.Concat(str), true);
                    }
                }
                else if (this.ParentItemID == (long)0)
                {
                    EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "C");
                }
            }
            string empty13 = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty13 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty13 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.tabtype == "job")
            {
                Type type1 = base.GetType();
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, "Jobs/job_item_form.aspx?frm=add&estid=", this.EstimateID, empty11, empty12, "';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type1, " ", string.Concat(str), true);
            }
            else if (this.tabtype == "invoice")
            {
                Type type2 = base.GetType();
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, "invoice/invoice_item_form.aspx?frm=add&estid=", this.EstimateID, empty11, empty12, "';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type2, " ", string.Concat(str), true);
            }
            else if (base.Request.Params["acntype"] != null && base.Request.Params["acntype"].ToString() == "edit" || this.frmcopyitem == "yes")
            {
                if (this.modulename == "orders")
                {
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        Type type3 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type3, " ", string.Concat(str), true);
                    }
                    else
                    {
                        Type type4 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type4, " ", string.Concat(str), true);
                    }
                }
                else if (this.ParentEstimateItemID != (long)0)
                {
                    if (empty13.ToLower() != "yes")
                    {
                        Type type5 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type5, " ", string.Concat(str), true);
                    }
                    else
                    {
                        Type type6 = base.GetType();
                        str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                        ScriptManager.RegisterStartupScript(this, type6, " ", string.Concat(str), true);
                    }
                }
                else if (empty13.ToLower() != "yes")
                {
                    Type type7 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type7, " ", string.Concat(str), true);
                }
                else
                {
                    Type type8 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type8, " ", string.Concat(str), true);
                }
            }
            else if (this.modulename == "orders")
            {
                if (this.ParentEstimateItemID == (long)0)
                {
                    Type type9 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type9, " ", string.Concat(str), true);
                }
                else
                {
                    Type type10 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type10, " ", string.Concat(str), true);
                }
            }
            else if (this.ParentEstimateItemID != (long)0)
            {
                if (empty13.ToLower() != "yes")
                {
                    Type type11 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type11, " ", string.Concat(str), true);
                }
                else
                {
                    Type type12 = base.GetType();
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                    ScriptManager.RegisterStartupScript(this, type12, " ", string.Concat(str), true);
                }
            }
            else if (empty13.ToLower() != "yes")
            {
                string ddlvalue = string.Concat("&ddlValue=", base.Request.QueryString["ddlValue"].ToString());

                Type type13 = base.GetType();

                if (this.hdn_isAddMore.Value.ToString() == "1")
                {
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_pricecatalog.aspx?type=add&EstID=", this.EstimateID, empty11, "&InvID=0", ddlvalue, "&FromAddAnItem=Y&maintype=add&fromPageType=job';GetRadWindow().close();" };
                }
                else
                {
                    str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                }

                //str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };

                ScriptManager.RegisterStartupScript(this, type13, " ", string.Concat(str), true);
            }
            else
            {
                Type type14 = base.GetType();
                //str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty11, "&InvID=0", "&FromAddAnItem=Y&maintype=add&pageType=job", "';GetRadWindow().close();" };
                str = new object[] { "javascript:GetRadWindow().BrowserWindow.location.href='", this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, empty11, empty12, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, "';GetRadWindow().close();" };
                ScriptManager.RegisterStartupScript(this, type14, " ", string.Concat(str), true);
            }
            if (Convert.ToBoolean(SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows[0]["AllowPrintReadyFile"]) && base.Request.Params["acntype"].ToString() == "add")
            {
                DataTable dataTable5 = EstimatesBasePage.PrintReadyFile_Select(num, this.CompanyID);
                if (dataTable5.Rows[0]["PrintReadyFile"].ToString() != "")
                {
                    string empty14 = string.Empty;
                    EstimatesBasePage.PrintReadyfile_Insert(this.EstimateID, this.EstimateItemID, (long)this.UserID, this.modulename, "C");
                    str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataTable5.Rows[0]["PrintReadyFile"].ToString() };
                    empty14 = string.Concat(str);
                    str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    if (!Directory.Exists(string.Concat(str)))
                    {
                        str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                        Directory.CreateDirectory(string.Concat(str));
                    }
                    if (File.Exists(empty14))
                    {
                        str = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        string str25 = string.Concat(str);
                        if (!Directory.Exists(str25))
                        {
                            Directory.CreateDirectory(str25);
                        }
                        File.Copy(empty14, string.Concat(str25, dataTable5.Rows[0]["PrintReadyFile"].ToString()), true);
                    }
                }

            }
            if (commonClass.CheckFTPEnable())
            {
                string filePath = string.Empty;
                DataTable dataTable7 = commonClass.Get_ProductFileByType(PriceCatalogueID, this.CompanyID);
                if (dataTable7.Rows[0]["FileType"].ToString() == "Editable")
                {
                    object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable7.Rows[0]["PrintReadyFile"].ToString() };
                    filePath = string.Concat(editableTemplatePath);
                }
                else
                {
                    string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                    filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable7.Rows[0]["PrintReadyFile"].ToString());
                }
                if (this.modulename.ToLower() == "jobs")
                {
                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, PriceCatalogueID.ToString(), filePath, "JobCreation", "ProductEstimate", this.EstimateItemID);
                }
                else if (this.modulename.ToLower() == "invoice")
                {
                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, PriceCatalogueID.ToString(), filePath, "InvoiceCreation", "ProductEstimate", this.EstimateItemID);
                }
                else
                {
                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, PriceCatalogueID.ToString(), filePath, "EstimateCreation", "ProductEstimate", this.EstimateItemID);
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["fromPageType"] == "job" || base.Request.QueryString["fromPageType"] == "estimate" || base.Request.QueryString["fromPageType"] == "invoice")
            {
                this.divNewAdd.Style.Add("display", "block");
            }
            else
            {
                this.divNewAdd.Style.Add("display", "none");
            }



            this.Alert_Msg = this.objLanguage.GetLanguageConversion("Please_Select_At_Least_One_Catalogue_Item");
            if (!base.IsPostBack)
            {
                this.btnBack.Text = this.objLanguage.GetLanguageConversion("Back");
            }
            if (base.Request.QueryString["cataloguename"] != null)
            {
                this.Page.Title = base.Request.QueryString["cataloguename"].ToString().Replace("<br/>", " - ");
            }
            if (base.Request.QueryString["acntype"] != null)
            {
                this.QueryType = base.Request.QueryString["acntype"].ToString();
            }
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            if (base.Request.QueryString["acntype"] != null)
            {
                this.ModuleType = base.Request.QueryString["acntype"].ToString();
            }
            try
            {
                if (base.Request.Params["parentestitemid"] != null)
                {
                    this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (base.Request.Params["parentesttype"] != null)
                {
                    this.ParentEstimateType = base.Request.Params["parentesttype"].ToString();
                }
                if (base.Request.QueryString["sectionid"] != null)
                {
                    this.EstimateBookletItemID = Convert.ToInt64(base.Request.QueryString["sectionid"]);
                }
            }
            catch
            {
                this.ParentEstimateItemID = (long)0;
            }
            this.defaultvalue = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.defaultvalue), 2, "", false, false, true));
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            this.RoundOff = OrderBasePage.Company_RoundOff_Value(this.CompanyID);
            global.pgName = string.Empty;
            this.Measurementvalue = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (this.Measurementvalue != "In.")
            {
                this.Measurementvalue_Sq = this.objLanguage.GetLanguageConversion("SquareMeter");
            }
            else
            {
                this.Measurementvalue_Sq = this.objLanguage.GetLanguageConversion("SquareFeet");
            }
            if (ConnectionClass.WebStore != null)
            {
                this.Webstore = ConnectionClass.WebStore.ToString();
            }
            this.Check_SpecialPrivilege = false;
            this.Check_SpecialPrivilege = this.Objclss.Check_SpecialPrivilege_For_User((long)this.UserID, (long)this.CompanyID);
            if (base.Request.Params["modulename"] == null || base.Request.Params["submodulename"] == null)
            {
                this.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                this.modulename = base.Request.Params["modulename"].ToString();
                this.submodulename = base.Request.Params["submodulename"].ToString();
            }
            if (ConnectionClass.IsHandy)
            {
                this.SimpleMatBrowserHandy = "yes";
            }
            DataSet dataSet = new DataSet();
            if (base.Request.Params["PriceCatalogueID"] != null)
            {
                EstimateProductcatalogueBind.PriceCatalogueID = Convert.ToInt64(base.Request.Params["PriceCatalogueID"]);
            }
            if (base.Request.Params["oldPriceCatalogueID"] != null)
            {
                this.hid_OldPriceCatalogueID.Value = base.Request.Params["oldPriceCatalogueID"].ToString();
            }
            if (base.Request.QueryString["esttype"] != null && base.Request.Params["acntype"].ToString() == "edit")
            {
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                this.Select_Catalogue_Item();
            }
            this.TakeItemDesc();
            if (this.modulename != "invoice")
            {
                foreach (DataRow row in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    this.Pub_CustomerID = row["CustomerID"].ToString();
                    this.Pub_CustomerName = row["ClientName"].ToString();
                    this.hid_Price_CustomerID.Value = this.Pub_CustomerID;
                    this.hid_Customer_Name.Value = this.Pub_CustomerName;
                    this.IsDirectJob = Convert.ToInt32(row["IsDirectJob"]);
                    this.IsForInvoice = Convert.ToInt32(row["IsForInvoice"]);
                }
            }
            else
            {
                foreach (DataRow dataRow in InvoiceBasePage.InvoiceDetails_ByInvoiceID_Select(this.InvoiceID).Rows)
                {
                    this.Pub_CustomerID = dataRow["CustomerID"].ToString();
                    this.Pub_CustomerName = dataRow["ClientName"].ToString();
                    this.hid_Price_CustomerID.Value = this.Pub_CustomerID;
                    this.hid_Customer_Name.Value = this.Pub_CustomerName;
                    this.IsForInvoice = 1;
                }
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.pnlCatalogue.Style.Add("display", "none");
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = "C";
                }
                if (base.Request.QueryString["frm"] != null || base.Request.QueryString["frm"] == "yes")
                {
                    this.frm = base.Request.QueryString["frm"].ToString();
                }
            }
            catch
            {
                this.subedit = "0";
            }
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            EstimateProductcatalogueBind.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            if (EstimateProductcatalogueBind.ManageStockPermission == 1)
            {
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
            }
            if (base.Request.Params["ordid"] != null)
            {
                this.OrderID = Convert.ToInt64(base.Request.Params["ordid"].ToString());
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            foreach (DataRow row1 in EstimatesBasePage.OrderItemID_Select(this.EstimateID, this.EstimateItemID).Rows)
            {
                this.OrderItemID = Convert.ToInt64(row1["OrderItemID"]);
                if (base.IsPostBack)
                {
                    continue;
                }
                this.hid_PriceCatalogueID.Value = row1["ProductID"].ToString();
            }
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                foreach (DataRow dataRow1 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    this.hdnJobStatusID.Value = dataRow1["StatusID"].ToString();
                }
            }
            if (base.Session["ProductStockManagement"] == null)
            {
                this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                this.pnlOtherMultiple.Visible = false;
                this.pnlOtherMultiple1.Visible = false;
                this.pnlOtherMultiple2.Visible = false;
                this.BindProductDetails(EstimateProductcatalogueBind.PriceCatalogueID, 'z');
            }
            else
            {
                if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
                {
                    this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                    this.pnlOtherMultiple.Visible = false;
                    this.pnlOtherMultiple1.Visible = false;
                    this.pnlOtherMultiple2.Visible = false;
                    this.BindProductDetails(EstimateProductcatalogueBind.PriceCatalogueID, 'z');
                    return;
                }
                BaseClass baseClass = new BaseClass();
                DataTable dataTable1 = baseClass.ProductStockType_Select((long)this.CompanyID, EstimateProductcatalogueBind.PriceCatalogueID);
                if (dataTable1.Rows.Count <= 0)
                {
                    this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                    this.pnlOtherMultiple.Visible = false;
                    this.pnlOtherMultiple1.Visible = false;
                    this.pnlOtherMultiple2.Visible = false;
                    this.BindProductDetails(EstimateProductcatalogueBind.PriceCatalogueID, 'z');
                    return;
                }
                foreach (DataRow row2 in dataTable1.Rows)
                {
                    if (row2["DrawStockFrom"].ToString().ToLower() != "m")
                    {
                        this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                        this.pnlOtherMultiple.Visible = false;
                        this.pnlOtherMultiple1.Visible = false;
                        this.pnlOtherMultiple2.Visible = false;
                        this.BindProductDetails(EstimateProductcatalogueBind.PriceCatalogueID, Convert.ToChar(row2["DrawStockFrom"].ToString().ToLower()));
                    }
                    else
                    {
                        this.BindOtherMultipleDropdownList(EstimateProductcatalogueBind.PriceCatalogueID);
                        this.hdnDrawStockFrom.Value = "m";
                        DataTable dataTable2 = WebstoreBasePage.OtherMultiple_DefaultItem_Select(EstimateProductcatalogueBind.PriceCatalogueID);
                        if (dataTable2.Rows.Count > 0)
                        {
                            HiddenField str = this.hidCatalogueID;
                            long num = Convert.ToInt64(dataTable2.Rows[0]["KitItemID"]);
                            str.Value = num.ToString();
                            if (dataTable2.Rows[0]["KitItemID"] == null)
                            {
                                continue;
                            }
                            this.objBase.SetDDLValue(this.ddlOtherMultiple, dataTable2.Rows[0]["KitItemID"].ToString());
                            this.BindProductDetails(Convert.ToInt64(dataTable2.Rows[0]["KitItemID"]), Convert.ToChar(row2["DrawStockFrom"].ToString().ToLower()));
                            this.pnlOtherMultiple.Visible = true;
                            this.pnlOtherMultiple1.Visible = true;
                            this.pnlOtherMultiple2.Visible = true;
                        }
                        else if (dataTable2.Rows.Count != 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HidePanle();alert('There are no Kit items in Product');", true);
                        }
                        else
                        {
                            this.ddlOtherMultiple.Items.Insert(0, "--Select--");
                            this.hidCatalogueID.Value = EstimateProductcatalogueBind.PriceCatalogueID.ToString();
                            this.BindProductDetails(Convert.ToInt64(EstimateProductcatalogueBind.PriceCatalogueID), Convert.ToChar(row2["DrawStockFrom"].ToString().ToLower()));
                            this.pnlOtherMultiple.Visible = true;
                            this.pnlOtherMultiple1.Visible = false;
                            this.pnlOtherMultiple2.Visible = false;
                        }
                    }
                }

            }
        }

        public void Price_Area(int CompanyID, PlaceHolder plh, string QueryType, string AdditionItem, decimal OrderItemTotalPrice, decimal OrderItemTax, decimal TaxRate, long TaxID, string TaxName)
        {
            decimal orderItemTotalPrice = OrderItemTotalPrice + OrderItemTax;
            this.plhquantity.Controls.Add(new LiteralControl("<tr >"));
            this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
            if (!base.Request.Browser.Type.ToLower().Contains("firefox"))
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 251px; clear: both; font-style:bold; '><b>", this.objLanguage.GetLanguageConversion("Total"), " </b></div>")));
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold; '><b>", this.objLanguage.GetLanguageConversion("Total"), " </b></div>")));
            }
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
            {
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal1' runat='server' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal2' runat='server' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal3' runat='server' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td style='text-align: right;", this.ForthQtydis_, "'>")));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal4' runat='server' CssClass='normalText'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal1' runat='server' CssClass='normalText' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal2' runat='server' CssClass='normalText' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal3' runat='server' CssClass='normalText' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl(" <td style='text-align: right; width: 10%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lbltotal4' runat='server' CssClass='normalText' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTotalPrice, 0, "", false, false, true), "</span>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            }
            this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            this.plhquantity.Controls.Add(new LiteralControl("</table>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost' style='display:none;' >"));
            plh.Controls.Add(new LiteralControl("</div>"));
            if (QueryType == "add")
            {
                foreach (DataRow row in EstimatesBasePage.Tax_Bind(CompanyID).Rows)
                {
                    TaxID = Convert.ToInt64(row["TaxID"]);
                    TaxName = row["TaxName"].ToString();
                    TaxRate = Convert.ToDecimal(row["TaxRate"].ToString());
                }
            }
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='display:none;'>"));
            ControlCollection controls = plh.Controls;
            string[] taxName = new string[] { "<label id='lblTax'>Tax: ", TaxName, " (", this.commclass.ToRemoveDecimalPlacesIfZero(this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, Convert.ToDecimal(TaxRate), 2, "", false, false, true)), " %) </label>" };
            controls.Add(new LiteralControl(string.Concat(taxName)));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='display:none;'>"));
            plh.Controls.Add(new LiteralControl("<div class='box' style='width: 100%; float: left;' style='display:none;'>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            ControlCollection controlCollections = plh.Controls;
            object[] taxRate = new object[] { "<div class='price_table_content_right' style='display:none;'><label id='lblTaxRate' style='display:none;'>", TaxRate, "</label><label id='lblTotalTax'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, OrderItemTax, 0, "", false, false, true), "</label>" };
            controlCollections.Add(new LiteralControl(string.Concat(taxRate)));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='display:none;'>"));
            plh.Controls.Add(new LiteralControl("<label id='lblSellingPrice' class='lblSellingPrice'>Total Price (inc. Tax) </label>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_middle' style='display:none;'>"));
            plh.Controls.Add(new LiteralControl("<div class='box' style='width: 100%; float: left;'>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("<div class='price_table_content_right' style='display:none;'>"));
            plh.Controls.Add(new LiteralControl(string.Concat("<label id='lblTotalSellingPrice' class='lblTotalSellingPrice'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, this.UserID, orderItemTotalPrice, 0, "", false, false, true), "</label>")));
            plh.Controls.Add(new LiteralControl("</div>"));
            plh.Controls.Add(new LiteralControl("</div>"));
        }

        public void Product_catalogueDetails_Edit()
        {
            int num;
            object[] otherCostName;
            IEnumerator enumerator;
            long num1 = Convert.ToInt64(this.hidCatalogueID.Value);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            long num5 = (long)0;
            string empty = string.Empty;
            foreach (DataRow row in EstimatesBasePage.productsDetails_Select(num1).Rows)
            {
                this.ProductName = row["ItemTitle"].ToString();
                this.hid_matixType.Value = row["MatrixType"].ToString();
            }
            DataSet dataSet = EstimatesBasePage.settings_Product_CatalogueAdditional_Select(this.CompanyID, num1);
            DataTable item = dataSet.Tables[0];
            foreach (DataRow dataRow in item.Rows)
            {
                this.WebOtherCostID = Convert.ToInt64(dataRow["WebOtherCostID"].ToString());
            }
            this.OrderAddItemsCount = item.Rows.Count;
            this.hid_qtyFromList.Value = "0";
            this.hid_qtyToList.Value = "0";
            this.hid_CostExcMarkupList.Value = "0";
            this.hid_MarkupList.Value = "0";
            this.hid_priceList.Value = "0";
            foreach (DataRow row1 in EstimatesBasePage.Product_CatalogueQty_Select(num1).Rows)
            {
                if (row1["FromQuantity"] == "")
                    row1["FromQuantity"] = 0;

                if (row1["ToQuantity"] == "")
                    row1["ToQuantity"] = 0;

                this.hid_qtyFromList.Value = string.Concat(this.hid_qtyFromList.Value, Convert.ToDecimal(row1["FromQuantity"]).ToString("0.##"), "µ");
                this.hid_qtyToList.Value = string.Concat(this.hid_qtyToList.Value, Convert.ToDecimal(row1["ToQuantity"]).ToString("0.##"), "µ");
                this.hid_CostExcMarkupList.Value = string.Concat(this.hid_CostExcMarkupList.Value, Convert.ToDecimal(row1["Price"]).ToString("0.##"), "µ");
                this.hid_MarkupList.Value = string.Concat(this.hid_MarkupList.Value, Convert.ToDecimal(row1["Markup"]).ToString("0.##"), "µ");
                this.hid_priceList.Value = string.Concat(this.hid_priceList.Value, Convert.ToDecimal(row1["sellingPrice"]).ToString("0.##"), "µ");
            }
            this.plhquantity.Controls.Add(new LiteralControl("<div style='clear:both;'></div>"));
            this.plhquantity.Controls.Add(new LiteralControl("<table id='tblPriceCatalogueItem' width='100%' cellpadding='0' cellspacing='0' border='0'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Product_Name"), "</div>")));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td colspan='5' id='tdPriceCatAddOptCostTotal1' style='text-align: left; padding-left:5px;'>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='lblProductName' runat='server' CssClass='normalText' >", this.objBase.SpecialDecode(this.ProductName), "</span>")));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            if (this.hid_matixType.Value == "P")
            {
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right;", this.firstQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt1' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right;", this.SecQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt2' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right;", this.ThirdQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt3' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right;", this.ForthQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt4' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt1' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt2' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt3' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt4' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>Price</div>"));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right;", this.firstQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt1' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right;", this.SecQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt2' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right;", this.ThirdQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt3' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right;", this.ForthQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt4' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt1' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt2' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt3' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt4' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            }
            else if (this.hid_matixType.Value != "G")
            {
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right;", this.firstQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty1' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice1.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right;", this.SecQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty2' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice2.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right;", this.ThirdQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty3' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice3.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right;", this.ForthQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty4' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice4.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty1' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice1.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty2' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice2.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty3' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice3.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='Labelqty4' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice4.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                this.plhquantity.Controls.Add(new LiteralControl("<tr >"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Price"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice1' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice1.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice2' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice2.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice3' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice3.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td style='text-align: right;", this.ForthQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice4' runat='server' CssClass='normalText'>", this.hdnLabelqtyPrice4.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice1' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice1.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice2' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice2.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice3' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice3.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<span ID='LabelqtyPrice4' runat='server' CssClass='normalText' >", this.hdnLabelqtyPrice4.Value, "</span>")));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right;", this.firstQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt1' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right;", this.SecQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt2' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right;", this.ThirdQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt3' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right;", this.ForthQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt4' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt1' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt2' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt3' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt4' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>Price</div>"));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                {
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right;", this.firstQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt1' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right;", this.SecQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt2' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right;", this.ThirdQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt3' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right;", this.ForthQtydis_, "'>")));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt4' runat='server' CssClass='normalText'>&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                else
                {
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt1' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal2' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt2' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal3' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt3' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tdPriceCatAddOptCostTotal4' style='text-align: right; width: 10%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='LabelqtyPricetxt4' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                }
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            }
            this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div id='spn_qty' style='float:left;margin:0px 0px 0px 35px;color:red;display:none;'><span id='spnQty'>&nbsp; Please enter quantity</span></div>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='width: 250px; clear: both; font-style:bold; padding:5px 0px 10px 0px;'><b>", this.objLanguage.GetLanguageConversion("Additional_Options"), "</b></div>")));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td colspan='5' id='tdPriceCatAddOptCostTotal1' style='text-align: right;'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt1' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            string str = string.Empty;
            string empty1 = string.Empty;
            DataTable dataTable = EstimatesBasePage.EstPriceCatAddOptionDetailsSelect(this.EstimateItemID);
            int freeTextQuestionCount = 0;
            foreach (DataRow dataRow1 in EstimatesBasePage.Select_OtherCostAdditional_ItemsIDs(num1).Rows)
            {
                int num10 = 0;
                int num11 = 0;
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                string str1 = string.Empty;
                DataSet dataSet1 = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataRow1["WebOtherCostID"].ToString()));
                DataTable item1 = dataSet1.Tables[0];
                DataTable dataTable1 = dataSet1.Tables[1];
                long num16 = Convert.ToInt64(dataRow1["WebOtherCostID"].ToString());
                long num17 = Convert.ToInt64(dataRow1["AdditionalGroupID"].ToString());
                decimal num22 = new decimal(0);
                decimal num23 = new decimal(0);
                num9++;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                foreach (DataRow row2 in item1.Rows)
                {
                    this.MainCalculationtype = row2["MainCalculationType"].ToString();
                    if (this.MainCalculationtype.ToLower() == "c")
                    {
                        num = Convert.ToInt32(row2["IsCartmandatory"]);
                        str2 = num.ToString();
                    }
                    row2["Description"].ToString().Replace("\n", "<br>");
                    this.OtherCostName = this.objBase.SpecialDecode(row2["UserFriendlyName"].ToString());
                    try
                    {
                        this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                    }
                    catch
                    {
                    }
                }
                int num18 = 0;
                if (num17 == (long)0)
                {
                    empty2 = "1";
                }
                else if (str == "")
                {
                    empty2 = "1";
                }
                else
                {
                    string[] strArrays = str.Split(new char[] { '±' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        if (strArrays[i] == "")
                        {
                            empty2 = "1";
                        }
                        else
                        {
                            empty2 = (num17 == (long)0 || Convert.ToInt64(strArrays[i]) != num17 ? "1" : "0");
                        }
                    }
                }
                str = string.Concat(str, dataRow1["AdditionalGroupID"].ToString(), "±");
                foreach (DataRow dataRow2 in dataTable1.Rows)
                {
                    if (this.MainCalculationtype.ToLower() == "q")
                    {
                        string str3 = dataRow2["formula"].ToString();
                        string str4 = this.objBase.SpecialDecode(dataRow2["Question"].ToString());
                        this.plhquantity.Controls.Add(new LiteralControl("<tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px;'>"));
                        //this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px;'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div>"));
                        ControlCollection controls = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblQuestion_", num6, "' style='word-break: break-all;' > ", this.OtherCostName, "<br/>", str4, "<br/></label>" };
                        controls.Add(new LiteralControl(string.Concat(otherCostName)));
                        if (this.MainType.ToLower() == "edit" && Convert.ToInt64(this.hid_PriceCatalogueID.Value) == num1)
                        {
                            int num19 = 0;
                            if (dataTable.Rows.Count > 0)
                            {
                                foreach (DataRow row3 in dataTable.Rows)
                                {
                                    if (Convert.ToInt32(row3["WebOtherCostID"].ToString()) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()) || !(this.MainCalculationtype.ToLower() == row3["Calculationtype"].ToString().ToLower()))
                                    {
                                        continue;
                                    }
                                    ControlCollection controlCollections = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input value='", row3["SelectedValue"].ToString(), "' id='txtQuestion_", num6, "' grpvalue='", empty2, "'  onkeyup='Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                                    controlCollections.Add(new LiteralControl(string.Concat(otherCostName)));
                                    num19 = 1;
                                    break;
                                }
                                if (num19 == 0)
                                {
                                    ControlCollection controls1 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='txtQuestion_", num6, "' grpvalue='", empty2, "'  onblur='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                                    controls1.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                            }
                            else if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                ControlCollection controlCollections1 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<input id='txtQuestion_", num6, "' grpvalue='", empty2, "'  onblur='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                                controlCollections1.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            else
                            {
                                ControlCollection controls2 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<input value='", str1, "' id='txtQuestion_", num6, "' grpvalue='", empty2, "'  onkeyup='Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                                controls2.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                        }
                        else if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            ControlCollection controlCollections2 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<input id='txtQuestion_", num6, "' grpvalue='", empty2, "' onblur='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                            controlCollections2.Add(new LiteralControl(string.Concat(otherCostName)));
                        }
                        else
                        {
                            ControlCollection controls3 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<input value='", str1, "' id='txtQuestion_", num6, "' grpvalue='", empty2, "'  onkeyup='Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                            controls3.Add(new LiteralControl(string.Concat(otherCostName)));
                        }



                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                            ControlCollection controlCollections3 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice1_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label></div>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                            ControlCollection controls4 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice2_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula2_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label></div>" };
                            controls4.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                            ControlCollection controlCollections4 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice3_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula3_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label></div>" };
                            controlCollections4.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ForthQtydis_, "'>")));
                            ControlCollection controls5 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice4_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula4_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label></div>" };
                            controls5.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: left; width: 70%;'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<br/><label id='lblPrice1_dup' Width='200px'>&nbsp&nbsp&nbsp&nbsp&nbsp</label>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controlCollections5 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice1_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls6 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice2_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula2_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label>" };
                            controls6.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controlCollections6 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice3_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula3_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label>" };
                            controlCollections6.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls7 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice4_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula4_", num6, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num6, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", num6, "' style='display:none'>", num9, "</label>" };
                            controls7.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: left; width: 40%;'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<br/><label id='lblPrice1_dup' Width='200px'>&nbsp&nbsp&nbsp&nbsp&nbsp</label>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        num6++;
                    }

                    if (this.MainCalculationtype.ToLower() == "f" || this.MainCalculationtype.ToLower() == "l")
                    {
                        string str3 = dataRow2["formula"].ToString();
                        string str4 = this.objBase.SpecialDecode(dataRow2["Question"].ToString());
                        int maxCharLimit = this.MainCalculationtype.ToLower() == "f" ? 100 : 1000;

                        this.plhquantity.Controls.Add(new LiteralControl("<tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px;'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div>"));
                        ControlCollection controls = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblFreeTextQuestion_", freeTextQuestionCount, "' style='word-break: break-all;' > ", str4, "<br/></label>" };
                        controls.Add(new LiteralControl(string.Concat(otherCostName)));
                        string textareaContent = string.Empty;
                        string eventAttribute = string.Empty;

                        if ((this.MainType.Equals("edit", StringComparison.OrdinalIgnoreCase) &&
                             Convert.ToInt64(this.hid_PriceCatalogueID.Value) == num1) ||
                            num10 == Convert.ToInt32(dataRow1["WebOtherCostID"]))
                        {
                            bool found = false;

                            if (dataTable.Rows.Count > 0)
                            {
                                foreach (DataRow row3 in dataTable.Rows)
                                {
                                    if (Convert.ToInt32(row3["WebOtherCostID"]) == Convert.ToInt32(dataRow1["WebOtherCostID"]) &&
                                        this.MainCalculationtype.Equals(row3["Calculationtype"].ToString(), StringComparison.OrdinalIgnoreCase))
                                    {
                                        textareaContent = row3["SelectedValue"].ToString();
                                        eventAttribute = "onkeyup='Tocall_mainFunc();'";
                                        found = true;
                                        break;
                                    }
                                }
                            }

                            if (!found)
                            {
                                textareaContent = (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"])) ? string.Empty : str1;
                                eventAttribute = (textareaContent == string.Empty)
                                    ? $"onblur='ForAdditional_Grouping({num17},{num16});Tocall_mainFunc();'"
                                    : "onkeyup='Tocall_mainFunc();'";
                            }
                        }
                        else
                        {
                            // Else case: default textarea for all other scenarios
                            textareaContent = string.Empty; // or str1 if you want a default value
                            eventAttribute = $"onblur='ForAdditional_Grouping({num17},{num16});Tocall_mainFunc();'";
                        }

                        // Build and add the textarea
                        var textareaHtml = $@"
                        <textarea id='txtFreeTextQuestion_{freeTextQuestionCount}' grpvalue='{empty2}' {eventAttribute} class='txtStyle' rows='2' onkeyup='UpdateCount(this,{freeTextQuestionCount});' onblur='UpdateCount(this,{freeTextQuestionCount});' onfocus='UpdateCount(this,{freeTextQuestionCount});'
                                  style ='width:92%;height:48px;text-align:left;resize:vertical;'>{textareaContent}</textarea><span id='cnt_txtFreeTextQuestion_{freeTextQuestionCount}' class='charCount'></span> <input type='hidden' id='hdn_FreeTextQuestion_CalculationType_{freeTextQuestionCount}' value='{this.MainCalculationtype.ToLower()}'/> <label id='lblFreeTextQuestionID_{freeTextQuestionCount}' style='display:none'>{dataRow1["WebOtherCostID"].ToString()}</label>";

                        this.plhquantity.Controls.Add(new LiteralControl(textareaHtml));



                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                            ControlCollection controlCollections3 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice1_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label></div>" };
                            controlCollections3.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                            ControlCollection controls4 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice2_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula2_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label></div>" };
                            controls4.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                            ControlCollection controlCollections4 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice3_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula3_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label></div>" };
                            controlCollections4.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ForthQtydis_, "'>")));
                            ControlCollection controls5 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><div><label id='lblPrice4_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula4_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label></div>" };
                            controls5.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: left; width: 70%;'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<br/><label id='lblPrice1_dup' Width='200px'>&nbsp&nbsp&nbsp&nbsp&nbsp</label>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controlCollections5 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice1_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls6 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice2_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula2_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label>" };
                            controls6.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controlCollections6 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice3_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula3_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label>" };
                            controlCollections6.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls7 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<br/><label id='lblPrice4_", freeTextQuestionCount, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), " </label><label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula4_", freeTextQuestionCount, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num12, "</label><label id='lblQuestionSortOrderNo_", freeTextQuestionCount, "' style='display:none'>", num9, "</label>" };
                            controls7.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: left; width: 40%;'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<br/><label id='lblPrice1_dup' Width='200px'>&nbsp&nbsp&nbsp&nbsp&nbsp</label>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        freeTextQuestionCount++;
                    }
                    else if (this.MainCalculationtype.ToLower() == "c")
                    {
                        if (num18 == 0)
                        {
                            if (dataRow2["CalculationType"].ToString().ToLower().Trim() != "groups")
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px;'>"));
                                if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections7 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controlCollections7.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                else
                                {
                                    ControlCollection controls8 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controls8.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                //this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px; width: 85%;'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<div style='width: 85%;'>"));
                                if (str2 != "1")
                                {
                                    ControlCollection controlCollections8 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<label id='lblMatrixName_", num7, "'><span style='word-break: break-word;'> ", this.OtherCostName, "</span></label>" };
                                    controlCollections8.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                else
                                {
                                    ControlCollection controls9 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<label id='lblMatrixName_", num7, "'><span style='word-break: break-word;'> ", this.OtherCostName, "</span><span style='color:Red;'> *</span></label>" };
                                    controls9.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("<div style='margin:5px 0px 0px 0px;'>"));
                                DropDownList dropDownList = new DropDownList()
                                {
                                    ID = string.Concat("ddlMultiple_", num7),
                                    CssClass = "dropDownMultiple150",
                                    Width = 220
                                };
                                AttributeCollection attributes = dropDownList.Attributes;
                                otherCostName = new object[] { "ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();" };
                                attributes.Add("onchange", string.Concat(otherCostName));
                                dropDownList.Attributes.Add("IsMandatory", str2);
                                dropDownList.Attributes.Add("grpvalue", empty2);
                                if (this.MainType.ToLower() == "edit" && Convert.ToInt64(this.hid_PriceCatalogueID.Value) == num1 && dataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow dataRow3 in dataTable.Rows)
                                    {
                                        if (Convert.ToInt32(dataRow3["WebOtherCostID"].ToString()) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                        {
                                            continue;
                                        }
                                        num11 = Convert.ToInt32(dataRow3["SelectedID"].ToString());
                                    }
                                }
                                if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections9 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controlCollections9.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                else
                                {
                                    ControlCollection controls10 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controls10.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                this.MultipleChoice_DropDownBind(dataTable1, dropDownList, this.plhquantity, dataRow2["CalculationType"].ToString(), "edit", num11);
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                if (this.modulename.ToLower() != "jobs" && this.modulename.ToLower() != "invoice" || this.MainType.ToLower() != "edit")
                                {
                                    if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                    {
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controlCollections10 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice1_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controlCollections10.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controls11 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice2_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controls11.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controlCollections11 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice3_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controlCollections11.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controls12 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice4_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controls12.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                    }
                                    else
                                    {
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controlCollections12 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice1_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controlCollections12.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controls13 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice2_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controls13.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controlCollections13 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice3_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controlCollections13.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                        ControlCollection controls14 = this.plhquantity.Controls;
                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice4_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label>" };
                                        controls14.Add(new LiteralControl(string.Concat(otherCostName)));
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                    }
                                }
                                else if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                                    ControlCollection controlCollections14 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice1_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controlCollections14.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                                    ControlCollection controls15 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice2_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controls15.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                                    ControlCollection controlCollections15 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice3_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controlCollections15.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ForthQtydis_, "'>")));
                                    ControlCollection controls16 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label id='lblMultiplePrice4_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controls16.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 70%;'>"));
                                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                }
                                else
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                                    ControlCollection controlCollections16 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice1_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controlCollections16.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                                    ControlCollection controls17 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice2_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controls17.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                                    ControlCollection controlCollections17 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice3_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controlCollections17.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ForthQtydis_, "'>")));
                                    ControlCollection controls18 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<br/><div><label id='lblMultipleID_", num7, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice4_", num7, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "' style='display:none;'>", num9, "</label></div>" };
                                    controls18.Add(new LiteralControl(string.Concat(otherCostName)));
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 70%;'>"));
                                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                            }
                            else
                            {
                                string empty3 = string.Empty;
                                DataTable dataTable2 = new DataTable();
                                DataSet dataSet2 = new DataSet();
                                DataTable item2 = new DataTable();
                                DataTable dataTable3 = new DataTable();

                                if (this.MainType.ToLower() == "edit" && Convert.ToInt64(this.hid_PriceCatalogueID.Value) == num1 && dataTable.Rows.Count > 0)
                                {
                                    foreach (DataRow row4 in dataTable.Rows)
                                    {
                                        if (Convert.ToInt32(row4["WebOtherCostID"].ToString()) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                        {
                                            continue;
                                        }
                                        if(Convert.ToInt32(row4["SelectedID"].ToString()) > 0)
                                        {
                                            num11 = Convert.ToInt32(row4["SelectedID"].ToString());
                                            num10 = Convert.ToInt32(row4["WebOtherCostID"].ToString());
                                        }
                                    }
                                }

                                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'  style='vertical-align:top;'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px;'>"));
                                if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections18 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controlCollections18.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                else
                                {
                                    ControlCollection controls19 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controls19.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                //this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px; width: 85%;'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<div style='width: 85%;'>"));
                                if (str2 != "1")
                                {
                                    ControlCollection controlCollections19 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<label id='lblMatrixName_", num7, "'><span style='word-break: break-word;'> ", this.OtherCostName, "</span></label>" };
                                    controlCollections19.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                else
                                {
                                    ControlCollection controls20 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<label id='lblMatrixName_", num7, "'><span style='word-break: break-word;'> ", this.OtherCostName, "</span><span style='color:Red;'> *</span></label>" };
                                    controls20.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("<div style='margin:5px 0px 0px 0px;'>"));
                                DropDownList dropDownList1 = new DropDownList()
                                {
                                    ID = string.Concat("ddlMultiple_", num7),
                                    CssClass = "dropDownMultiple150",
                                    Width = 220
                                };
                                dropDownList1.Attributes.Add("onchange", string.Concat("VisibleAdditionaloption('", dataRow1["WebOtherCostID"].ToString(), "');Tocall_mainFunc();"));
                                dropDownList1.Attributes.Add("isgroup", "maingroup");
                                dropDownList1.Attributes.Add("IsMandatory", str2);
                                dropDownList1.Attributes.Add("WeotherCostID", dataRow1["WebOtherCostID"].ToString());
                            
                                if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    ControlCollection controlCollections20 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controlCollections20.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                else
                                {
                                    ControlCollection controls21 = this.plhquantity.Controls;
                                    otherCostName = new object[] { "<input id='chkMultiple_", num7, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num7, ");'/>" };
                                    controls21.Add(new LiteralControl(string.Concat(otherCostName)));
                                }
                                this.MultipleChoice_DropDownBind(dataTable1, dropDownList1, this.plhquantity, dataRow2["CalculationType"].ToString(), "edit", num11);
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                for (int j = 0; j < dataTable1.Rows.Count; j++)
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='display:none;' id='div_SubAdditionalsddl_", Convert.ToInt32(dataTable1.Rows[j]["SelectedID"].ToString()), "'>")));
                                    dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[j]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                    if (dataTable2.Rows.Count > 0 && Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) != (long)0)
                                    {
                                        int pIndex = 0;
                                        for (int k = 0; k < dataTable2.Rows.Count; k++)
                                        {
                                            dataSet2 = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataTable2.Rows[k]["WebOtherCostID"].ToString()));
                                            item2 = dataSet2.Tables[0];
                                            dataTable3 = dataSet2.Tables[1];
                                            enumerator = item2.Rows.GetEnumerator();
                                            try
                                            {
                                                if (enumerator.MoveNext())
                                                {
                                                    DataRow current = (DataRow)enumerator.Current;
                                                    num = Convert.ToInt32(current["IsCartmandatory"]);
                                                    empty3 = num.ToString();
                                                }
                                            }
                                            finally
                                            {
                                                IDisposable disposable = enumerator as IDisposable;
                                                if (disposable != null)
                                                {
                                                    disposable.Dispose();
                                                }
                                            }

                                            if (item2.Rows[0]["MainCalculationType"].ToString() == "f" || item2.Rows[0]["MainCalculationType"].ToString() == "l")
                                            {
                                                string str4 = dataTable3.Rows[0]["formula"].ToString();
                                                string str5 = dataTable3.Rows[0]["Question"].ToString();
                                                string freeTextQuestion = string.Empty;
                                                int maxCharLimit = item2.Rows[0]["MainCalculationType"].ToString() == "f" ? 100 : 1000;
                                                this.plhquantity.Controls.Add(new LiteralControl("<div></div>"));
                                                this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width:92%'>"));

                                                ControlCollection controlCollections1 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<label id='lblFreeTextQuestion_", freeTextQuestionCount, "'>", str5, "</label>" };
                                                controlCollections1.Add(new LiteralControl(string.Concat(otherCostName)));

                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                                int parentId = Convert.ToInt32(dataRow1["WebOtherCostID"]);

                                                var filteredRows = dataTable.AsEnumerable()
                                                    .Where(r => Convert.ToInt32(r["WebOtherCostID"]) == parentId &&
                                                                Convert.ToInt32(r["SelectedID"]) == 0);

                                                DataTable childTable = new DataTable();

                                                if (filteredRows.Any())
                                                {
                                                    childTable = filteredRows.CopyToDataTable();
                                                }
                                                else
                                                {
                                                    childTable = dataTable.Clone(); // create an empty table with same structure
                                                }
                                                if (pIndex < childTable.Rows.Count)
                                                {
                                                    DataRow row3 = childTable.Rows[pIndex];

                                                    // Now use row3
                                                    num12 = Convert.ToInt32(row3["WebOtherCostID"]);
                                                    num13 = Convert.ToInt32(row3["SelectedID"]);
                                                    //num14 = Convert.ToDecimal(row3["MarkupValue"]);
                                                    //num15 = Convert.ToDecimal(row3["TotalPrice"]);
                                                    if (item2.Rows[0]["MainCalculationType"].ToString() == "l")
                                                    {
                                                        freeTextQuestion = row3["FreeTextQuestionLong"].ToString();
                                                    }
                                                    else
                                                    {
                                                        freeTextQuestion = row3["SelectedValue"].ToString();
                                                    }
                                                    //num16 = Convert.ToDecimal(row3["SelectedPrice"]);
                                                    //num17 = Convert.ToDecimal(row3["Markup"]);
                                                    pIndex++;
                                                }

                                                this.plhquantity.Controls.Add(new LiteralControl("<div>"));

                                                string str3 = "1";

                                                ControlCollection controls2 = this.plhquantity.Controls;

                                                otherCostName = new object[]
                                                {
                                                        "<textarea id='txtFreeTextQuestion_", freeTextQuestionCount,
                                                        "' grpvalue='", str3,
                                                        "' onkeyup='UpdateCount(this,", freeTextQuestionCount, ");' onblur='UpdateCount(this,", freeTextQuestionCount, ");' onfocus='UpdateCount(this,", freeTextQuestionCount, ");'  class='txtStyle' rows='2' style='width:92%;height:48px;text-align:left;resize:vertical;'>",
                                                        freeTextQuestion,
                                                        "</textarea> <span id='cnt_txtFreeTextQuestion_", freeTextQuestionCount, "' class='charCount'></span> <input type='hidden' id='hdn_FreeTextQuestion_CalculationType_", freeTextQuestionCount,
                                                        "' value='", item2.Rows[0]["MainCalculationType"].ToString() , "'/> <label id='lblFreeTextQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label>"
                                                };

                                                controls2.Add(new LiteralControl(string.Concat(otherCostName)));

                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                                                // RIGHT SIDE PRICE & HIDDEN LABELS
                                                this.plhquantity.Controls.Add(new LiteralControl("<div>"));

                                                //ControlCollection controls3 = this.plhquantity.Controls;

                                                //otherCostName = new object[]
                                                //{
                                                //    "<br/><label id='lblFreeTextPrice_", freeTextQuestionCount, "'>",
                                                //    this.commclass.GetCurrencyinRequiredFormate("", true),
                                                //    this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true),
                                                //    "</label>",
                                                //    "<label id='lblQuestionID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label>",
                                                //    //"<label id='lblQuestionFormula_", freeTextQuestionCount, "' style='display:none'>", str4, "</label>",
                                                //    //"<label id='lblQuestionGroupID_", freeTextQuestionCount, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label>",
                                                //    //"<label id='lblQuestionMarkupValue_", freeTextQuestionCount, "' style='display:none'>", num14, "</label>",
                                                //    //"<label id='lblQuestionSortOrderNo_", num8, "' style='display:none'>", num11, "</label>"
                                                //};

                                                //controls3.Add(new LiteralControl(string.Concat(otherCostName)));

                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                                                freeTextQuestionCount++;
                                            }
                                            else
                                            {
                                                //this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px; width: 85%;'>"));
                                                this.plhquantity.Controls.Add(new LiteralControl("<div style='width: 85%;'>"));
                                                if (empty3 != "1")
                                                {
                                                    ControlCollection controlCollections21 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMatrixName_", num7, "_", dataTable1.Rows[j]["SelectedID"].ToString(), "_", k, "'><span style='word-break: break-word;'> ", this.objBase.SpecialDecode(item2.Rows[0]["UserFriendlyName"].ToString()), "</span></label>" };
                                                    controlCollections21.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls22 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMatrixName_", num7, "_", dataTable1.Rows[j]["SelectedID"].ToString(), "_", k, "'><span style='word-break: break-word;'> ", this.objBase.SpecialDecode(item2.Rows[0]["UserFriendlyName"].ToString()), "</span><span style='color:Red;'> *</span></label>" };
                                                    controls22.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("<div style='margin:5px 0px 0px 0px;'>"));
                                                DropDownList dropDownList2 = new DropDownList();
                                                otherCostName = new object[] { "ddlMultiple_", num7, "_", dataTable1.Rows[j]["SelectedID"].ToString(), "_", k };
                                                dropDownList2.ID = string.Concat(otherCostName);
                                                dropDownList2.CssClass = "dropDownMultiple150";
                                                dropDownList2.Width = 220;
                                                dropDownList2.Attributes.Add("onchange", "Tocall_mainFunc();");
                                                dropDownList2.Attributes.Add("grpvalue", empty2);
                                                dropDownList2.Attributes.Add("IsMandatory", empty3);
                                                dropDownList2.Attributes.Add("isgroup", "subgroup");
                                                dropDownList2.Attributes.Add("WeotherCostID", dataTable2.Rows[k]["WebOtherCostID"].ToString());
                                                if (this.MainType.ToLower() == "edit" && Convert.ToInt64(this.hid_PriceCatalogueID.Value) == num1 && dataTable.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dataRow4 in dataTable.Rows)
                                                    {
                                                        if (Convert.ToInt32(dataRow4["WebOtherCostID"].ToString()) != Convert.ToInt32(dataTable2.Rows[k]["WebOtherCostID"].ToString()))
                                                        {
                                                            continue;
                                                        }
                                                        num11 = Convert.ToInt32(dataRow4["SelectedID"].ToString());
                                                    }
                                                }
                                                this.MultipleChoice_DropDownBind(dataTable3, dropDownList2, this.plhquantity, dataTable3.Rows[0]["CalculationType"].ToString(), "edit", num11);
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                            
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                if (this.modulename.ToLower() != "jobs" && this.modulename.ToLower() != "invoice" || this.MainType.ToLower() != "edit")
                                {
                                    if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                    {
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int l = 0; l < dataTable1.Rows.Count; l++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[l]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections22 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[l]["SelectedID"]), "_1'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections22.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[l]["SelectedID"]), "_1' style='display:none;'>")));
                                                for (int m = 0; m < dataTable2.Rows.Count; m++)
                                                {
                                                    if (m == 0 && l != 0)
                                                    {
                                                        ControlCollection controls23 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", dataTable2.Rows[m]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none;'>", num9, "</label>" };
                                                        controls23.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (l == 0)
                                                    {
                                                        ControlCollection controlCollections23 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", dataTable2.Rows[m]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections23.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls24 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", dataTable2.Rows[m]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[l]["SelectedID"].ToString(), "_", m, "' style='display:none;'>", num9, "</label>" };
                                                        controls24.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int n = 0; n < dataTable1.Rows.Count; n++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[n]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections24 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[n]["SelectedID"]), "_2'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections24.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[n]["SelectedID"]), "_2' style='display:none;'>")));
                                                for (int o = 0; o < dataTable2.Rows.Count; o++)
                                                {
                                                    if (o == 0 && n != 0)
                                                    {
                                                        ControlCollection controls25 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", dataTable2.Rows[o]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none;'>", num9, "</label>" };
                                                        controls25.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (n == 0)
                                                    {
                                                        ControlCollection controlCollections25 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", dataTable2.Rows[o]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections25.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls26 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", dataTable2.Rows[o]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[n]["SelectedID"].ToString(), "_", o, "' style='display:none;'>", num9, "</label>" };
                                                        controls26.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int p = 0; p < dataTable1.Rows.Count; p++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[p]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections26 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[p]["SelectedID"]), "_3'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections26.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[p]["SelectedID"]), "_3' style='display:none;'>")));
                                                for (int q = 0; q < dataTable2.Rows.Count; q++)
                                                {
                                                    if (q == 0 && p != 0)
                                                    {
                                                        ControlCollection controls27 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", dataTable2.Rows[q]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'></label><label style='display:none;margin-top:26px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none;'>", num9, "</label>" };
                                                        controls27.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (p == 0)
                                                    {
                                                        ControlCollection controlCollections27 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", dataTable2.Rows[q]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections27.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls28 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", dataTable2.Rows[q]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'></label><label style='display:none;margin-top:13px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[p]["SelectedID"].ToString(), "_", q, "' style='display:none;'>", num9, "</label>" };
                                                        controls28.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int r = 0; r < dataTable1.Rows.Count; r++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[r]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections28 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[r]["SelectedID"]), "_4'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections28.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[r]["SelectedID"]), "_4' style='display:none;'>")));
                                                for (int s = 0; s < dataTable2.Rows.Count; s++)
                                                {
                                                    if (s == 0 && r != 0)
                                                    {
                                                        ControlCollection controls29 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", dataTable2.Rows[s]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none;'>", num9, "</label>" };
                                                        controls29.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (r == 0)
                                                    {
                                                        ControlCollection controlCollections29 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", dataTable2.Rows[s]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'></label><label style='display:none;;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections29.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls30 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", dataTable2.Rows[s]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[r]["SelectedID"].ToString(), "_", s, "' style='display:none;'>", num9, "</label>" };
                                                        controls30.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                                        for (int t = 0; t < dataTable1.Rows.Count; t++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[t]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                            }
                                            else
                                            {
                                                for (int u = 0; u < dataTable2.Rows.Count; u++)
                                                {
                                                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                                }
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                    }
                                    else
                                    {
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int v = 0; v < dataTable1.Rows.Count; v++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[v]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections30 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[v]["SelectedID"]), "_1'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections30.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[v]["SelectedID"]), "_1' style='display:none;'>")));
                                                for (int w = 0; w < dataTable2.Rows.Count; w++)
                                                {
                                                    if (w == 0 && v != 0)
                                                    {
                                                        ControlCollection controls31 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", dataTable2.Rows[w]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none;'>", num9, "</label>" };
                                                        controls31.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (v == 0)
                                                    {
                                                        ControlCollection controlCollections31 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", dataTable2.Rows[w]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections31.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls32 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", dataTable2.Rows[w]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[v]["SelectedID"].ToString(), "_", w, "' style='display:none;'>", num9, "</label>" };
                                                        controls32.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int x = 0; x < dataTable1.Rows.Count; x++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[x]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections32 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[x]["SelectedID"]), "_2'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections32.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[x]["SelectedID"]), "_2' style='display:none;'>")));
                                                for (int y = 0; y < dataTable2.Rows.Count; y++)
                                                {
                                                    if (y == 0 && x != 0)
                                                    {
                                                        ControlCollection controls33 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", dataTable2.Rows[y]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none;'>", num9, "</label>" };
                                                        controls33.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (x == 0)
                                                    {
                                                        ControlCollection controlCollections33 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", dataTable2.Rows[y]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections33.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls34 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", dataTable2.Rows[y]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[x]["SelectedID"].ToString(), "_", y, "' style='display:none;'>", num9, "</label>" };
                                                        controls34.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int a = 0; a < dataTable1.Rows.Count; a++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[a]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections34 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[a]["SelectedID"]), "_3'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections34.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[a]["SelectedID"]), "_3' style='display:none;'>")));
                                                for (int b = 0; b < dataTable2.Rows.Count; b++)
                                                {
                                                    if (b == 0 && a != 0)
                                                    {
                                                        ControlCollection controls35 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", dataTable2.Rows[b]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'></label><label style='display:none;margin-top:26px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none;'>", num9, "</label>" };
                                                        controls35.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (a == 0)
                                                    {
                                                        ControlCollection controlCollections35 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", dataTable2.Rows[b]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections35.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls36 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", dataTable2.Rows[b]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'></label><label style='display:none;margin-top:13px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[a]["SelectedID"].ToString(), "_", b, "' style='display:none;'>", num9, "</label>" };
                                                        controls36.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%; padding-top:28px;'>"));
                                        for (int c = 0; c < dataTable1.Rows.Count; c++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[c]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                ControlCollection controlCollections36 = this.plhquantity.Controls;
                                                otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[c]["SelectedID"]), "_4'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                                controlCollections36.Add(new LiteralControl(string.Concat(otherCostName)));
                                            }
                                            else
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[c]["SelectedID"]), "_4' style='display:none;'>")));
                                                for (int d = 0; d < dataTable2.Rows.Count; d++)
                                                {
                                                    if (d == 0 && c != 0)
                                                    {
                                                        ControlCollection controls37 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", dataTable2.Rows[d]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none;'>", num9, "</label>" };
                                                        controls37.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else if (c == 0)
                                                    {
                                                        ControlCollection controlCollections37 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", dataTable2.Rows[d]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'></label><label style='display:none;;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none;'>", num9, "</label>" };
                                                        controlCollections37.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                    else
                                                    {
                                                        ControlCollection controls38 = this.plhquantity.Controls;
                                                        otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", dataTable2.Rows[d]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[c]["SelectedID"].ToString(), "_", d, "' style='display:none;'>", num9, "</label>" };
                                                        controls38.Add(new LiteralControl(string.Concat(otherCostName)));
                                                    }
                                                }
                                                this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                        this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                                        for (int e = 0; e < dataTable1.Rows.Count; e++)
                                        {
                                            dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[e]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                            if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                            }
                                            else
                                            {
                                                for (int f = 0; f < dataTable2.Rows.Count; f++)
                                                {
                                                    this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                                }
                                            }
                                        }
                                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                    }
                                }
                                else if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.firstQtydis_, "'>")));
                                    for (int g = 0; g < dataTable1.Rows.Count; g++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[g]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections38 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[g]["SelectedID"]), "_1'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections38.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[g]["SelectedID"]), "_1' style='display:none;'>")));
                                            for (int h = 0; h < dataTable2.Rows.Count; h++)
                                            {
                                                if (h == 0 && g != 0)
                                                {
                                                    ControlCollection controls39 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", dataTable2.Rows[h]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none;'>", num9, "</label>" };
                                                    controls39.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (g == 0)
                                                {
                                                    ControlCollection controlCollections39 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", dataTable2.Rows[h]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections39.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls40 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", dataTable2.Rows[h]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[g]["SelectedID"].ToString(), "_", h, "' style='display:none;'>", num9, "</label>" };
                                                    controls40.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.SecQtydis_, "'>")));
                                    for (int i1 = 0; i1 < dataTable1.Rows.Count; i1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[i1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections40 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[i1]["SelectedID"]), "_2'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections40.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[i1]["SelectedID"]), "_2' style='display:none;'>")));
                                            for (int j1 = 0; j1 < dataTable2.Rows.Count; j1++)
                                            {
                                                if (j1 == 0 && i1 != 0)
                                                {
                                                    ControlCollection controls41 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", dataTable2.Rows[j1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none;'>", num9, "</label>" };
                                                    controls41.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (i1 == 0)
                                                {
                                                    ControlCollection controlCollections41 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", dataTable2.Rows[j1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections41.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls42 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", dataTable2.Rows[j1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[i1]["SelectedID"].ToString(), "_", j1, "' style='display:none;'>", num9, "</label>" };
                                                    controls42.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.ThirdQtydis_, "'>")));
                                    for (int k1 = 0; k1 < dataTable1.Rows.Count; k1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[k1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections42 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[k1]["SelectedID"]), "_3'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections42.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[k1]["SelectedID"]), "_3' style='display:none;'>")));
                                            for (int l1 = 0; l1 < dataTable2.Rows.Count; l1++)
                                            {
                                                if (l1 == 0 && k1 != 0)
                                                {
                                                    ControlCollection controls43 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", dataTable2.Rows[l1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'></label><label style='display:none;margin-top:26px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none;'>", num9, "</label>" };
                                                    controls43.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (k1 == 0)
                                                {
                                                    ControlCollection controlCollections43 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", dataTable2.Rows[l1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections43.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls44 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", dataTable2.Rows[l1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'></label><label style='display:none;margin-top:13px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[k1]["SelectedID"].ToString(), "_", l1, "' style='display:none;'>", num9, "</label>" };
                                                    controls44.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.ForthQtydis_, "'>")));
                                    for (int m1 = 0; m1 < dataTable1.Rows.Count; m1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[m1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections44 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[m1]["SelectedID"]), "_4'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections44.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[m1]["SelectedID"]), "_4' style='display:none;'>")));
                                            for (int n1 = 0; n1 < dataTable2.Rows.Count; n1++)
                                            {
                                                if (n1 == 0 && m1 != 0)
                                                {
                                                    ControlCollection controls45 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", dataTable2.Rows[n1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none;'>", num9, "</label>" };
                                                    controls45.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (m1 == 0)
                                                {
                                                    ControlCollection controlCollections45 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", dataTable2.Rows[n1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'></label><label style='display:none;;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections45.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls46 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", dataTable2.Rows[n1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[m1]["SelectedID"].ToString(), "_", n1, "' style='display:none;'>", num9, "</label>" };
                                                    controls46.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 70%;'>"));
                                    for (int o1 = 0; o1 < dataTable1.Rows.Count; o1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[o1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                        }
                                        else
                                        {
                                            for (int p1 = 0; p1 < dataTable2.Rows.Count; p1++)
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                            }
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                }
                                else
                                {
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.firstQtydis_, "'>")));
                                    for (int q1 = 0; q1 < dataTable1.Rows.Count; q1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[q1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections46 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[q1]["SelectedID"]), "_1'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections46.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[q1]["SelectedID"]), "_1' style='display:none;'>")));
                                            for (int r1 = 0; r1 < dataTable2.Rows.Count; r1++)
                                            {
                                                if (r1 == 0 && q1 != 0)
                                                {
                                                    ControlCollection controls47 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", dataTable2.Rows[r1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none;'>", num9, "</label>" };
                                                    controls47.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (q1 == 0)
                                                {
                                                    ControlCollection controlCollections47 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", dataTable2.Rows[r1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections47.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls48 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", dataTable2.Rows[r1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice1_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[q1]["SelectedID"].ToString(), "_", r1, "' style='display:none;'>", num9, "</label>" };
                                                    controls48.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.SecQtydis_, "'>")));
                                    for (int s1 = 0; s1 < dataTable1.Rows.Count; s1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[s1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections48 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[s1]["SelectedID"]), "_2'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections48.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[s1]["SelectedID"]), "_2' style='display:none;'>")));
                                            for (int t1 = 0; t1 < dataTable2.Rows.Count; t1++)
                                            {
                                                if (t1 == 0 && s1 != 0)
                                                {
                                                    ControlCollection controls49 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", dataTable2.Rows[t1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none;'>", num9, "</label>" };
                                                    controls49.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (s1 == 0)
                                                {
                                                    ControlCollection controlCollections49 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", dataTable2.Rows[t1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections49.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls50 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", dataTable2.Rows[t1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice2_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[s1]["SelectedID"].ToString(), "_", t1, "' style='display:none;'>", num9, "</label>" };
                                                    controls50.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.ThirdQtydis_, "'>")));
                                    for (int u1 = 0; u1 < dataTable1.Rows.Count; u1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[u1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections50 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[u1]["SelectedID"]), "_3'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections50.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[u1]["SelectedID"]), "_3' style='display:none;'>")));
                                            for (int v1 = 0; v1 < dataTable2.Rows.Count; v1++)
                                            {
                                                if (v1 == 0 && u1 != 0)
                                                {
                                                    ControlCollection controls51 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", dataTable2.Rows[v1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'></label><label style='display:none;margin-top:26px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none;'>", num9, "</label>" };
                                                    controls51.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (u1 == 0)
                                                {
                                                    ControlCollection controlCollections51 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", dataTable2.Rows[v1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'></label><label style='display:none;' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections51.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls52 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", dataTable2.Rows[v1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'></label><label style='display:none;margin-top:13px' id='lblMultiplePrice3_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[u1]["SelectedID"].ToString(), "_", v1, "' style='display:none;'>", num9, "</label>" };
                                                    controls52.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right; padding-top:28px;", this.ForthQtydis_, "'>")));
                                    for (int w1 = 0; w1 < dataTable1.Rows.Count; w1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[w1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            ControlCollection controlCollections52 = this.plhquantity.Controls;
                                            otherCostName = new object[] { "<div id='div_", Convert.ToInt32(dataTable1.Rows[w1]["SelectedID"]), "_4'><label id='lblMultipleID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0' style='display:none'>", dataTable2.Rows[0]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0' style='display:none'></label><label Width='200px' style='display:none' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_0' style='display:none;'>", num9, "</label></div>" };
                                            controlCollections52.Add(new LiteralControl(string.Concat(otherCostName)));
                                        }
                                        else
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div id='div_", Convert.ToInt32(dataTable1.Rows[w1]["SelectedID"]), "_4' style='display:none;'>")));
                                            for (int x1 = 0; x1 < dataTable2.Rows.Count; x1++)
                                            {
                                                if (x1 == 0 && w1 != 0)
                                                {
                                                    ControlCollection controls53 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", dataTable2.Rows[x1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'></label><label style='display:none;margin-top:26px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none;'>", num9, "</label>" };
                                                    controls53.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else if (w1 == 0)
                                                {
                                                    ControlCollection controlCollections53 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<label id='lblMultipleID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", dataTable2.Rows[x1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'></label><label style='display:none;;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none;'>", num9, "</label>" };
                                                    controlCollections53.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                                else
                                                {
                                                    ControlCollection controls54 = this.plhquantity.Controls;
                                                    otherCostName = new object[] { "<br/><label id='lblMultipleID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", dataTable2.Rows[x1]["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'></label><label id='lblMultipleMarkup_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'></label><label style='display:none;margin-top:13px;' id='lblMultiplePrice4_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none'>", num12, "</label><label id='lblMultipleSortOrderNo_", num7, "_", dataTable1.Rows[w1]["SelectedID"].ToString(), "_", x1, "' style='display:none;'>", num9, "</label>" };
                                                    controls54.Add(new LiteralControl(string.Concat(otherCostName)));
                                                }
                                            }
                                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                    this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 70%;'>"));
                                    for (int y1 = 0; y1 < dataTable1.Rows.Count; y1++)
                                    {
                                        dataTable2 = WebstoreBasePage.SubAdditionalOptions_SubValues(Convert.ToInt32(dataTable1.Rows[y1]["SelectedID"].ToString()), Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()));
                                        if (dataTable2.Rows.Count <= 0 || Convert.ToInt64(dataTable2.Rows[0]["GroupID"]) == (long)0)
                                        {
                                            this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                        }
                                        else
                                        {
                                            for (int a1 = 0; a1 < dataTable2.Rows.Count; a1++)
                                            {
                                                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                            }
                                        }
                                    }
                                    this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                }
                                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                            }
                            num7++;
                        }
                    }
                    else if (this.MainCalculationtype.ToLower() == "m" && num18 == 0)
                    {
                        dataRow2["matrixType"].ToString();
                        string empty4 = string.Empty;
                        this.plhquantity.Controls.Add(new LiteralControl("<tr >"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width:250px;'>"));
                        if (!(this.MainType.ToLower() == "edit") || Convert.ToInt64(this.hid_PriceCatalogueID.Value) != num1)
                        {
                            if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                ControlCollection controlCollections54 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num8, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();'/></div>" };
                                controlCollections54.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            else
                            {
                                otherCostName = new object[] { num14, "~", num15, "~", num11, "~", this.MainItemQuantity };
                                empty4 = string.Concat(otherCostName);
                                ControlCollection controls55 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num8, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();'/></div>" };
                                controls55.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                        }
                        else if (dataTable.Rows.Count > 0)
                        {
                            int num20 = 0;
                            foreach (DataRow row5 in dataTable.Rows)
                            {
                                if (Convert.ToInt32(row5["WebOtherCostID"].ToString()) != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()) || !(this.MainCalculationtype.ToLower() == row5["Calculationtype"].ToString().ToLower()))
                                {
                                    continue;
                                }
                                num11 = Convert.ToInt32(row5["SelectedID"].ToString());
                                otherCostName = new object[] { num14, "~", num15, "~", num11, "~", this.MainItemQuantity };
                                empty4 = string.Concat(otherCostName);
                                ControlCollection controlCollections55 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num8, "' class='DisplayBlock' type='checkbox' Checked='Checked' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();'/></div>" };
                                controlCollections55.Add(new LiteralControl(string.Concat(otherCostName)));
                                num20 = 1;
                                break;
                            }
                            if (num20 == 0)
                            {
                                ControlCollection controls56 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num8, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();'/></div>" };
                                controls56.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                        }
                        else if (num10 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            ControlCollection controlCollections56 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num8, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();'/></div>" };
                            controlCollections56.Add(new LiteralControl(string.Concat(otherCostName)));
                        }
                        else
                        {
                            otherCostName = new object[] { num14, "~", num15, "~", num11, "~", this.MainItemQuantity };
                            empty4 = string.Concat(otherCostName);
                            ControlCollection controls57 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num8, "' class='DisplayBlock' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='ForAdditional_Grouping(", num17, ",", num16, ");Tocall_mainFunc();'/></div>" };
                            controls57.Add(new LiteralControl(string.Concat(otherCostName)));
                        }
                        ControlCollection controlCollections57 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<div style='padding-top:3px;'><label id='lblMatrixName_", num8, "' > ", this.OtherCostName, "</label></div>" };
                        controlCollections57.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        if ((this.modulename.ToLower() == "jobs" || this.modulename.ToLower() == "invoice") && this.MainType.ToLower() == "edit")
                        {
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.firstQtydis_, "'>")));
                            this.plhquantity.Controls.Add(new LiteralControl("<div>"));
                            ControlCollection controls58 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup1_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls58.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections58 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice1_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections58.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.SecQtydis_, "'>")));
                            this.plhquantity.Controls.Add(new LiteralControl("<div>"));
                            ControlCollection controls59 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID2_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup2_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls59.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections59 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice2_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections59.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ThirdQtydis_, "'>")));
                            this.plhquantity.Controls.Add(new LiteralControl("<div>"));
                            ControlCollection controls60 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID3_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup3_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls60.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections60 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice3_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections60.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<td style='text-align: right;", this.ForthQtydis_, "'>")));
                            this.plhquantity.Controls.Add(new LiteralControl("<div>"));
                            ControlCollection controls61 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID4_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup4_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls61.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections61 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice4_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections61.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 70%;'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        }
                        else
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls62 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup1_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls62.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections62 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice1_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections62.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls63 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID2_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup2_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls63.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections63 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice2_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections63.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls64 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID3_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup3_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls64.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections64 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice3_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections64.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                            ControlCollection controls65 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixID4_", num8, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num8, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup4_", num8, "' style='display:none;'>", empty4, "</label><label id='lblMatrixGroupID_", num8, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num8, "' style='display:none'>", num12, "</label><label id='lblMatrixSortOrderNo_", num8, "' style='display:none;'>", num9, "</label>" };
                            controls65.Add(new LiteralControl(string.Concat(otherCostName)));
                            ControlCollection controlCollections65 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<label id='lblMatrixPrice4_", num8, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num13, 0, "", false, false, true), "</label>" };
                            controlCollections65.Add(new LiteralControl(string.Concat(otherCostName)));
                            this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        if (dataRow2["matrixType"].ToString().ToLower() != "pricebands")
                        {
                            DropDownList dropDownList3 = new DropDownList();
                            this.MultipleChoice_DropDownBind(dataTable1, dropDownList3, this.plhquantity, "matrix", "edit", num11);
                            dropDownList3.ID = string.Concat("ddlMatrix_", num8);
                            dropDownList3.CssClass = "dropDownMultiple150";
                            dropDownList3.Width = 300;
                            dropDownList3.Style.Add("display", "none");
                        }
                        num8++;
                    }
                    //if (this.MainCalculationtype.ToLower() == "f" || this.MainCalculationtype.ToLower() == "l")
                    //{
                    //    string str4 = dataRow2["formula"].ToString();
                    //    string str5 = dataRow2["Question"].ToString();

                    //    int maxCharLimit = this.MainCalculationtype.ToLower() == "f" ? 100 : 1000;

                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_leftmost'></div>"));
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_left bglabel' style='height:53px;'>"));

                    //    this.plhquantity.Controls.Add(new LiteralControl(
                    //        $"<label id='lblFreeTextQuestion_{freeTextQuestionCount}'>{str5}</label>"));

                    //    this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_middle'>"));

                    //    string grpVal = (num12 != Convert.ToInt32(dataRow1["WebOtherCostID"])) ? "0" : "1";

                    //    string textareaHtml =
                    //        $"<textarea id='txtFreeTextQuestion_{freeTextQuestionCount}' " +
                    //        $"grpvalue='{grpVal}' maxlength='{maxCharLimit}' " +
                    //        $"onkeyup='ForAdditional_Grouping({num17},{num16});Tocall_mainFunc();UpdateCount(this,{freeTextQuestionCount});' " +
                    //        $"onblur='ForAdditional_Grouping({num17},{num16});Tocall_mainFunc();UpdateCount(this,{freeTextQuestionCount});' " +
                    //        $"onfocus='UpdateCount(this,{freeTextQuestionCount});' " +
                    //        $"class='txtStyle' rows='2' " +
                    //        $"style='width:92%;height:48px;text-align:left;resize:vertical;'></textarea>" +
                    //        $"<span id='cnt_txtFreeTextQuestion_{freeTextQuestionCount}' class='charCount'></span>" +
                    //        $"<input type='hidden' id='hdn_FreeTextQuestion_CalculationType_{freeTextQuestionCount}' value='{this.MainCalculationtype.ToLower()}'/>";

                    //    this.plhquantity.Controls.Add(new LiteralControl(textareaHtml));

                    //    this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                    //    // RIGHT SIDE
                    //    this.plhquantity.Controls.Add(new LiteralControl("<div class='price_table_content_right'>"));

                    //    this.plhquantity.Controls.Add(new LiteralControl(
                    //        $"<br/><label id='lblFreeTextPrice_{freeTextQuestionCount}'>" +
                    //        $"{this.commclass.GetCurrencyinRequiredFormate("", true)}" +
                    //        $"{this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num15, 0, "", false, false, true)}</label>" +

                    //        $"<label id='lblFreeTextQuestionID_{freeTextQuestionCount}' style='display:none'>{dataRow1["WebOtherCostID"]}</label>" +
                    //        $"<label id='lblQuestionFormula_{freeTextQuestionCount}' style='display:none'>{str4}</label>" +
                    //        $"<label id='lblQuestionGroupID_{freeTextQuestionCount}' style='display:none'>{dataRow1["AdditionalGroupID"]}</label>" +
                    //        $"<label id='lblQuestionMarkupValue_{freeTextQuestionCount}' style='display:none'>{num14}</label>" +
                    //        $"<label id='lblQuestionSortOrderNo_{freeTextQuestionCount}' style='display:none'>{num11}</label>"
                    //    ));

                    //    this.plhquantity.Controls.Add(new LiteralControl("</div>"));

                    //    freeTextQuestionCount++;
                    //}

                    num18++;
                }


            }
            this.hid_QuestionLenght.Value = num6.ToString();
            this.hid_MultipleLenght.Value = num7.ToString();
            this.hid_MatrixLenght.Value = num8.ToString();
            this.hid_QuestionTextFreeLenght.Value = freeTextQuestionCount.ToString();

            //////////////////////////////////////////Decoration Work By Amin//////////////////////////
            /////
            if (ConnectionClass.IsDecoration.ToLower() == "true")
            {
                long CatalogueID = Convert.ToInt64(this.hidCatalogueID.Value);
                var dt = OrderBasePage.productsDetails_Select(CatalogueID);



                foreach (DataRow row in dt.Rows)
                {
                    string decoration1Value = "No";
                    string decoration2Value = "No";
                    string decoration3Value = "No";
                    string decoration4Value = "No";
                    string decoration5Value = "No";
                    string decoration6Value = "No";


                    foreach (DataRow dtitem in dataTable.Rows)
                    {
                        if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 101)
                        {
                            string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                            decoration1Value = strSelectedValue[1];


                        }
                        if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 102)
                        {
                            string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                            decoration2Value = strSelectedValue[1];


                        }
                        if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 103)
                        {
                            string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                            decoration3Value = strSelectedValue[1];


                        }
                        if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 104)
                        {
                            string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                            decoration4Value = strSelectedValue[1];


                        }
                        if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 105)
                        {
                            string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                            decoration5Value = strSelectedValue[1];


                        }
                        if (Convert.ToString(dtitem["WebOtherCostType"]) == "Decoration" && Convert.ToInt32(dtitem["SortOrderNo"]) == 106)
                        {
                            string[] strSelectedValue = Convert.ToString(dtitem["SelectedValue"]).Split('¶');
                            decoration6Value = strSelectedValue[1];


                        }


                    }


                    name1 = row["Decoration1_Name"].ToString();
                    name2 = row["Decoration2_Name"].ToString();
                    name3 = row["Decoration3_Name"].ToString();
                    name4 = row["Decoration4_Name"].ToString();
                    name5 = row["Decoration5_Name"].ToString();
                    name6 = row["Decoration6_Name"].ToString();

                    Decoration1_Mandadory = Convert.ToBoolean(string.IsNullOrEmpty(row["Decoration1_Mandadory"].ToString()) ? 0 : row["Decoration1_Mandadory"]); 
                    Decoration2_Mandadory = Convert.ToBoolean(string.IsNullOrEmpty(row["Decoration2_Mandadory"].ToString()) ? 0 : row["Decoration2_Mandadory"]);
                    Decoration3_Mandadory = Convert.ToBoolean(string.IsNullOrEmpty(row["Decoration3_Mandadory"].ToString()) ? 0 : row["Decoration3_Mandadory"]);
                    Decoration4_Mandadory = Convert.ToBoolean(string.IsNullOrEmpty(row["Decoration4_Mandadory"].ToString()) ? 0 : row["Decoration4_Mandadory"]);
                    Decoration5_Mandadory = Convert.ToBoolean(string.IsNullOrEmpty(row["Decoration5_Mandadory"].ToString()) ? 0 : row["Decoration5_Mandadory"]);
                    Decoration6_Mandadory = Convert.ToBoolean(string.IsNullOrEmpty(row["Decoration6_Mandadory"].ToString()) ? 0 : row["Decoration6_Mandadory"]);
                    var length = 80;
                    if (string.IsNullOrEmpty(name1) != true)
                    {
                        hdnDecoration1.Value = Convert.ToDouble(row["Decoration1_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration1_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration1_MinimiumCost"]);
                        name1 = Decoration1_Mandadory ? name1 + "*" : name1;
                        if (Decoration1_Mandadory && decoration1Value == "No")
                        {
                            decoration1Value = "--select--";
                        }
                        AddDecorations(length, name1, 1, Decoration1_Mandadory, decoration1Value);
                    }
                    if (string.IsNullOrEmpty(name2) != true)
                    {
                        if (Decoration2_Mandadory && decoration2Value == "No")
                        {
                            decoration2Value = "--select--";
                        }

                        name2 = Decoration2_Mandadory ? name2 + "*" : name2;
                        AddDecorations(length, name2, 2, Decoration2_Mandadory, decoration2Value);
                        hdnDecoration2.Value = Convert.ToDouble(row["Decoration2_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration2_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration2_MinimiumCost"]);
                    }

                    if (string.IsNullOrEmpty(name3) != true)
                    {
                        if (Decoration3_Mandadory && decoration3Value == "No")
                        {
                            decoration3Value = "--select--";
                        }

                        name3 = Decoration3_Mandadory ? name3 + "*" : name3;
                        AddDecorations(length, name3, 3, Decoration3_Mandadory, decoration3Value);
                        hdnDecoration3.Value = Convert.ToDouble(row["Decoration3_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration3_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration3_MinimiumCost"]);
                    }
                    if (string.IsNullOrEmpty(name4) != true)
                    {
                        if (Decoration4_Mandadory && decoration4Value == "No")
                        {
                            decoration4Value = "--select--";
                        }
                        name4 = Decoration4_Mandadory ? name4 + "*" : name4;
                        AddDecorations(length, name4, 4, Decoration4_Mandadory, decoration4Value);
                        hdnDecoration4.Value = Convert.ToDouble(row["Decoration4_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration4_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration4_MinimiumCost"]);
                    }

                    if (string.IsNullOrEmpty(name5) != true)
                    {
                        if (Decoration5_Mandadory && decoration5Value == "No")
                        {
                            decoration5Value = "--select--";
                        }

                        name5 = Decoration5_Mandadory ? name5 + "*" : name5;
                        AddDecorations(length, name5, 5, Decoration5_Mandadory, decoration5Value);
                        hdnDecoration5.Value = Convert.ToDouble(row["Decoration5_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration5_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration5_MinimiumCost"]);
                    }

                    if (string.IsNullOrEmpty(name6) != true)
                    {
                        if (Decoration6_Mandadory && decoration6Value == "No")
                        {
                            decoration6Value = "--select--";
                        }

                        name6 = Decoration6_Mandadory ? name6 + "*" : name6;
                        AddDecorations(length, name6, 6, Decoration6_Mandadory, decoration6Value);
                        hdnDecoration6.Value = Convert.ToDouble(row["Decoration6_SetupCost"]) + "~" + Convert.ToDouble(row["Decoration6_PerItemCost"]) + "~" + Convert.ToDouble(row["Decoration6_MinimiumCost"]);
                    }

                }
            }



            //////////////////////////////////////////End Decoration by Amin//////////////////////////

            if (num6 == 0 && num7 == 0 && num8 == 0)
            {
                this.Price_Area(this.CompanyID, this.plhquantity, "edit", "no", num2, num3, num4, num5, empty);
                return;
            }
            this.Price_Area(this.CompanyID, this.plhquantity, "edit", "yes", num2, num3, num4, num5, empty);
        }
        void AddDecorations(Int32 length, string Label, Int32 DecorationNo, Boolean IsMandatory, string Selectevalue)
        {



            object[] otherCostName;
            this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px;'>"));
            //this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px; width: 85%;'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div style='width: 85%;'>"));
            ControlCollection controls9 = this.plhquantity.Controls;
            otherCostName = new object[] { "<label id='lblDecoration_", DecorationNo, "'><span style='word-break: break-word;'> ", Label, "</span><span style='color:Red;'></span></label>" };
            controls9.Add(new LiteralControl(string.Concat(otherCostName)));

            this.plhquantity.Controls.Add(new LiteralControl("<div style='margin:5px 0px 0px 0px;'>"));
            DropDownList dropDownList = new DropDownList()
            {
                ID = string.Concat("ddldecoration", DecorationNo),
                CssClass = "dropDownMultiple150",
                Width = 220
            };
            AttributeCollection attributes = dropDownList.Attributes;
            otherCostName = new object[] { "ForAdditional_Grouping(", DecorationNo, ",", DecorationNo, ");Tocall_mainFunc();" };
            attributes.Add("onchange", string.Concat(otherCostName));

            SetDDItems(dropDownList, Selectevalue, this.plhquantity, IsMandatory);
            // this.MultipleChoice_DropDownBind(dataTable1, dropDownList, this.plhquantity, dataRow2["CalculationType"].ToString(), "edit", num11);
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            //if (this.modulename.ToLower() != "jobs" && this.modulename.ToLower() != "invoice") || this.MainType.ToLower() != "edit")
            //{

                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                ControlCollection controlCollections10 = this.plhquantity.Controls;
                otherCostName = new object[] { "<br/><label id='lblDecoration1_", DecorationNo, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label>" };
                controlCollections10.Add(new LiteralControl(string.Concat(otherCostName)));
                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                ControlCollection controls11 = this.plhquantity.Controls;
                otherCostName = new object[] { "<br/><label id='lblDecoration2_", DecorationNo, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label>" };
                controls11.Add(new LiteralControl(string.Concat(otherCostName)));
                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                ControlCollection controlCollections11 = this.plhquantity.Controls;
                otherCostName = new object[] { "<br/></label><label id='lblDecoration3_", DecorationNo, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label>" };
                controlCollections11.Add(new LiteralControl(string.Concat(otherCostName)));
                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                ControlCollection controls12 = this.plhquantity.Controls;
                otherCostName = new object[] { "<br/><label id='lblDecoration4_", DecorationNo, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label>" };
                controls12.Add(new LiteralControl(string.Concat(otherCostName)));
                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));


            //}

            this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
        }



        void SetDDItems(DropDownList ddl, string selectedText, PlaceHolder plhPriceCalculator, Boolean IsMandatory)
        {
            try
            {
                if (IsMandatory)
                {
                    ddl.Items.Add("--select--");

                }
                ddl.Items.Add("No");
                ddl.Items.Add("Yes");

                ListItem listItem = ddl.Items.FindByValue(selectedText);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
                plhPriceCalculator.Controls.Add(ddl);

            }
            catch
            {
            }
        }

        private void Select_Catalogue_Item()
        {
            string empty = string.Empty;
            string str = string.Empty;
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            int num = 0;
            foreach (DataRow row in EstimateBasePage.price_catalogue_select_by_estimateitem_id(this.CompanyID, this.EstimateItemID).Rows)
            {
                if (string.IsNullOrEmpty(this.ProductCataDesc))
                {
                    this.ProductCataDesc = this.Objclss.SpecialDecode(row["ItemDescription"].ToString());
                }
                int num1 = int.Parse(row["QtyNumber"].ToString());
                Convert.ToInt64(row["PriceCatalogueID"]);
                this.Objclss.SpecialDecode(row["ItemDescription"].ToString());
                if (this.MainType.ToLower() == "edit")
                {
                    if (num1 - 1 == 0)
                    {
                        this.Quantity1 = row["Quantity"].ToString();
                        this.QtyusedforCalculation1 = row["QtyusedforCalculation"].ToString();
                        this.Width1 = row["Width"].ToString();
                        this.Height1 = row["Height"].ToString();
                    }
                    if (num1 - 1 == 1)
                    {
                        this.Quantity2 = row["Quantity"].ToString();
                        this.QtyusedforCalculation2 = row["QtyusedforCalculation"].ToString();
                        this.Width2 = row["Width"].ToString();
                        this.Height2 = row["Height"].ToString();
                    }
                    if (num1 - 1 == 2)
                    {
                        this.Quantity3 = row["Quantity"].ToString();
                        this.QtyusedforCalculation3 = row["QtyusedforCalculation"].ToString();
                        this.Width3 = row["Width"].ToString();
                        this.Height3 = row["Height"].ToString();
                    }
                    if (num1 - 1 == 3)
                    {
                        this.Quantity4 = row["Quantity"].ToString();
                        this.QtyusedforCalculation4 = row["QtyusedforCalculation"].ToString();
                        this.Width4 = row["Width"].ToString();
                        this.Height4 = row["Height"].ToString();
                    }
                    if (string.IsNullOrEmpty(this.MultipleOf))
                    {
                        this.MultipleOf = row["MultipleOf"].ToString();
                    }
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0 || string.Compare(this.modulename, "orders", true) == 0)
                {
                    if (num == 0)
                    {
                        this.CatalogueProfit = row["ProfitMargin"].ToString();
                        str = row["TaxID"].ToString();

                        this.CatalogueTax = Convert.ToInt32(str == "" ? "0" : str) == 0 ? "0.0000000000" : SettingsBasePage.settings_taxrate_selectbyID(this.CompanyID, Convert.ToInt32(str)).Rows[0]["TaxRate"].ToString();
                    }
                    string[] strArrays = new string[] { ",", this.CatalogueProfit.ToString(), ",", row["SubTotal"].ToString(), ",", this.CatalogueTax.ToString(), ",", str.ToString() };
                    this.CatalogueProfitAndTax = string.Concat(strArrays);
                }
                else
                {
                    this.CatalogueTax = Convert.ToInt32(str == "" ? "0" : str) == 0 ? "0.0000000000" : SettingsBasePage.settings_taxrate_selectbyID(this.CompanyID, Convert.ToInt32(row["TaxID"])).Rows[0]["TaxRate"].ToString();
                    string[] str1 = new string[] { ",", row["ProfitMargin"].ToString(), ",", row["SubTotal"].ToString(), ",", this.CatalogueTax, ",", row["TaxID"].ToString() };
                    this.CatalogueProfitAndTax = string.Concat(str1);
                    this.CatalogueProfit = row["ProfitMargin"].ToString();
                }
                num++;
            }
        }

        private void TakeItemDesc()
        {
            DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
            if (dataSet.Tables[0].Rows.Count > 0 && dataSet != null)
            {
                if (dataSet.Tables[0].Rows[0]["databaseFieldName"].ToString() == "ItemTitle")
                {
                    this.txt_lblItemtitle.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[0]["ScreenName"].ToString());
                }
                if (dataSet.Tables[0].Rows[1]["databaseFieldName"].ToString() == "Description")
                {
                    if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Description = "style='display:block'";
                        this.txt_lblDescription.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblDescription.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[2]["databaseFieldName"].ToString() == "Artwork")
                {
                    if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Artwork = "style='display:block'";
                        this.txt_lblArtwork.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblArtwork.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[3]["databaseFieldName"].ToString() == "Colour")
                {
                    if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Color = "style='display:block'";
                        this.txt_lblColour.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblColour.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[4]["databaseFieldName"].ToString() == "Size")
                {
                    if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Size = "style='display:block'";
                        this.txt_lblSize.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblSize.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[5]["databaseFieldName"].ToString() == "Material")
                {
                    if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Material = "style='display:block'";
                        this.txt_lblMaterial.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblMaterial.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[6]["databaseFieldName"].ToString() == "Delivery")
                {
                    if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Delivery = "style='display:block'";
                        this.txt_lblDelivery.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblDelivery.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[7]["databaseFieldName"].ToString() == "Finishing")
                {
                    if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Finishing = "style='display:block'";
                        this.txt_lblFinishing.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblFinishing.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[8]["databaseFieldName"].ToString() == "Proofs")
                {
                    if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Proof = "style='display:block'";
                        this.txt_lblProofs.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblProofs.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[9]["databaseFieldName"].ToString() == "Packing")
                {
                    if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Pack = "style='display:block'";
                        this.txt_lblPacking.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblPacking.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[10]["databaseFieldName"].ToString() == "Notes")
                {
                    if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Note = "style='display:block'";
                        this.txt_lblNotes.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblNotes.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim());
                    }
                }
                if (dataSet.Tables[0].Rows[11]["databaseFieldName"].ToString() == "Instructions")
                {
                    if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.Instruction = "style='display:block'";
                        this.txt_lblInstructions.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblInstructions.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim());
                    }
                }
                try
                {
                    if (dataSet.Tables[0].Rows[12]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.lblCustomDiscription1.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[12]["ScreenName"].ToString().Trim());
                        this.CustomDiscription1 = "style='display:block'";
                    }
                    if (dataSet.Tables[0].Rows[13]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.lblCustomDiscription2.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[13]["ScreenName"].ToString().Trim());
                        this.CustomDiscription2 = "style='display:block'";
                    }
                    if (dataSet.Tables[0].Rows[14]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription3 = "style='display:block'";
                        this.lblCustomDiscription3.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[14]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[15]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription4 = "style='display:block'";
                        this.lblCustomDiscription4.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[15]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[16]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription5 = "style='display:block'";
                        this.lblCustomDiscription5.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[16]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[17]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription6 = "style='display:block'";
                        this.lblCustomDiscription6.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[17]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[18]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription7 = "style='display:block'";
                        this.lblCustomDiscription7.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[18]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[19]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription8 = "style='display:block'";
                        this.lblCustomDiscription8.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[19]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[20]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription9 = "style='display:block'";
                        this.lblCustomDiscription9.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[20]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[21]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription10 = "style='display:block'";
                        this.lblCustomDiscription10.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[21]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[22]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription11 = "style='display:block'";
                        this.lblCustomDiscription11.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[22]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[23]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription12 = "style='display:block'";
                        this.lblCustomDiscription12.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[23]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[24]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription13 = "style='display:block'";
                        this.lblCustomDiscription13.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[24]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[25]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription14 = "style='display:block'";
                        this.lblCustomDiscription14.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[25]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[26]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription15 = "style='display:block'";
                        this.lblCustomDiscription15.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[26]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[27]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription16 = "style='display:block'";
                        this.lblCustomDiscription16.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[27]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[28]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription17 = "style='display:block'";
                        this.lblCustomDiscription17.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[28]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[29]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription18 = "style='display:block'";
                        this.lblCustomDiscription18.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[29]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[30]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription19 = "style='display:block'";
                        this.lblCustomDiscription19.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[30]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[31]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription20 = "style='display:block'";
                        this.lblCustomDiscription20.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[31]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[32]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription21 = "style='display:block'";
                        this.lblCustomDiscription21.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[32]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[33]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription22 = "style='display:block'";
                        this.lblCustomDiscription22.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[33]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[34]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription23 = "style='display:block'";
                        this.lblCustomDiscription23.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[34]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[35]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription24 = "style='display:block'";
                        this.lblCustomDiscription24.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[35]["ScreenName"].ToString().Trim());
                    }
                    if (dataSet.Tables[0].Rows[36]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.CustomDiscription25 = "style='display:block'";
                        this.lblCustomDiscription25.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[36]["ScreenName"].ToString().Trim());
                    }
                }
                catch
                {
                }
            }
        }
    }
}