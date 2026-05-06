using MathFunctions;
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
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;


namespace ePrint.usercontrol.Item
{
    public partial class estimate_price_catalogueNew : UsercontrolBasePage
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

        public long EstimateItemID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string qtype = string.Empty;

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

        public string ItemTitle = string.Empty;

        public string Description = string.Empty;

        public string fromType = string.Empty;

        public string SortExpression = string.Empty;

        public string SortDirection = string.Empty;

        public string CustomerName = string.Empty;

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

        private Global gloobj = new Global();

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

        private int IsDirectJob;

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

        public string frm = string.Empty;

        public string FromAddAnItem = string.Empty;

        public string Measurementvalue = string.Empty;

        public string WhereConditionEstimateProdouct = string.Empty;

        private long ParentWebOtherCostID;

        private string WebOtherCostType = string.Empty;

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

        static estimate_price_catalogueNew()
        {
            estimate_price_catalogueNew.Customer_ID = -1;
            estimate_price_catalogueNew.IsBackOrder = 0;
            estimate_price_catalogueNew.ManageStockPermission = 0;
        }

        public estimate_price_catalogueNew()
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

        public void BindProductDetails(long PriceCatalogueID, char Drawstockfrom)
        {
            string[] languageConversion;
            object[] currencyinRequiredFormate;
            this.plhquantity.Controls.Clear();
            this.Product_catalogueDetails_Edit();
            this.pnlCatalogue.Style.Add("display", "block");
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='center' style='width:100%;'>"));
            DataTable dataTable = EstimateBasePage.price_catalogue_select_by_id(this.CompanyID, PriceCatalogueID, Drawstockfrom);
            if (dataTable.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Norowsalert();", true);
                return;
            }
            estimate_price_catalogueNew.IsBackOrder = Convert.ToInt32(dataTable.Rows[0]["IsBackOrder"]);
            this.hdn_isbackorder.Value = estimate_price_catalogueNew.IsBackOrder.ToString();
            this.hdn_drawstockfrom.Value = dataTable.Rows[0]["DrawStockFrom"].ToString();
            DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            HiddenField hdnStockManagement = this.hdn_StockManagement;
            int num = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
            hdnStockManagement.Value = num.ToString();
            this.hdn_IsStockItem.Value = dataTable.Rows[0]["IsStockItem"].ToString();
            HiddenField hdnKitavailibility = this.hdn_kitavailibility;
            int num1 = this.objBase.Check_MaxKit_Availability(PriceCatalogueID, 0);
            hdnKitavailibility.Value = num1.ToString();
            int num2 = 0;
            string empty = string.Empty;
            string str = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<option value='select'>select</option>");
            string str1 = "block";
            str1 = (!this.Check_SpecialPrivilege ? "block" : "none");
            string empty1 = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                this.hdnUnitOfMeasure.Value = row["UnitOfMeasure"].ToString();
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
                str = row["MatrixType"].ToString();
                string str2 = "#DADADA";
                if (num2 % 2 == 0)
                {
                    str2 = "#EFEFEF";
                }
                if (num2 == 0)
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='padding: 2px;width: 100%;' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float: left;width: 45%;overflow: hidden; overflow-y: scroll; height:450px;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblItemtitle.Text, "</div>")));
                    try
                    {
                        if (base.Request.Params["FromAddAnItem"] == null)
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><input id='txtcatalogue_item_title'  type='text' value='", this.objBase.SpecialDecode(row["ItemTitle"].ToString()), "' onblur='Copy_ItemTitle_Price(this.value);' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                        }
                        else
                        {
                            this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><input id='txtcatalogue_item_title'  type='text' value='", this.objBase.SpecialDecode(row["ItemTitle"].ToString()), "' onblur='Copy_ItemTitle_Price(this.value);' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                        }
                    }
                    catch
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;overflow: hidden;max-width: 68%;padding-right: 2px;'><input id='txtcatalogue_item_title'  type='text' value='", this.objBase.SpecialDecode(row["ItemTitle"].ToString()), "' onblur='Copy_ItemTitle_Price(this.value);' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 50px;width:27%;'>", this.txt_lblDescription.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_design' rows='3' cols='15' class='textboxnew' onblur=Copy_Description_Price(this.value);  style='width:98%'>", this.objBase.SpecialDecode(row["Description"].ToString()), "</textarea></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblArtwork.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_art' type='text' value='", this.objBase.SpecialDecode(row["Artwork"].ToString()), "' onblur=Copy_Artwork_Price(this.value); class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblColour.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_color' type='text' value='", this.objBase.SpecialDecode(row["Color"].ToString()), "' onblur=Copy_Color_Price(this.value); class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblSize.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_size' type='text' value='", this.objBase.SpecialDecode(row["Size"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblMaterial.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_material' type='text' value='", this.objBase.SpecialDecode(row["Material"].ToString()), "' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblDelivery.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_delivery' type='text' value='", this.objBase.SpecialDecode(row["Delivery"].ToString()), "' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblFinishing.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_finishing' type='text' value='", this.objBase.SpecialDecode(row["Finishing"].ToString()), "' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblProofs.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_Proofs' type='text' value='", this.objBase.SpecialDecode(row["Proofs"].ToString()), "' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' >"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.txt_lblPacking.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtcatalogue_Packing' type='text' value='", this.objBase.SpecialDecode(row["Packing"].ToString()), "' class='textboxnew' style='width:98%' maxlength='2000'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 50px;width:27%;'>", this.txt_lblNotes.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_notes' rows='3' cols='15' class='textboxnew' style='width:98%' >", this.objBase.SpecialDecode(row["Notes"].ToString()), "</textarea></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='height: 50px;width:27%;overflow:hidden;'>", this.txt_lblInstructions.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><textarea id='txtcatalogue_terms' rows='3' cols='15' class='textboxnew' style='width:98%'  >", this.objBase.SpecialDecode(row["Instructions"].ToString()), "</textarea></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription1.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription1' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription1"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription2.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription2' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription2"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription3.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription3' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription3"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription4.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription4' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription4"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription5.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription5' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription5"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription6.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription6' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription6"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription7.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription7' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription7"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription8.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription8' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription8"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription9.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription9' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription9"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription10.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription10' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription10"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription11.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription11' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription11"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription12.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription12' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription12"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription13.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription13' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription13"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription14.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription14' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription14"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription15.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription15' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription15"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription16.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription16' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription16"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription17.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription17' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription17"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription18.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription18' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription18"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription19.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription19' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription19"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription20.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription20' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription20"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription21.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription21' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription21"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription22.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription22' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription22"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription23.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription23' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription23"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription24.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription24' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription24"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:27%;'>", this.lblCustomDiscription25.Text, "</div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='box' style='width:68%;'><input id='txtCustomDiscription25' type='text' value='", this.objBase.SpecialDecode(row["CustomDescription25"].ToString()), "' class='textboxnew' style='width:98%' maxlength='50'></div>")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;width:54%;'>"));
                    if (base.Session["productstockmanagement"] != null && base.Session["ProductStockManagement"].ToString().Trim().ToLower() == "true")
                    {
                        string lower = row["DrawStockFrom"].ToString().ToLower();
                        if (lower == "s" || lower == "o" || lower == "a")
                        {
                            DataTable dataTable2 = WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, Convert.ToInt32(PriceCatalogueID));
                            if (dataTable2.Rows.Count > 0)
                            {
                                StringBuilder stringBuilder1 = new StringBuilder();
                                stringBuilder1.Append("<fieldset style='margin-left:-1px'>");
                                stringBuilder1.Append(string.Concat("<legend>", this.objLanguage.GetLanguageConversion("Current_Stock_Levels"), "</legend>"));
                                stringBuilder1.Append("<table style='width:90%;border-collapse: collapse; border: 1px solid #CCCCCC'>");
                                stringBuilder1.Append("<tr style='background-color: #DDDDDD; height: 20px;'>");
                                stringBuilder1.Append("<td>");
                                stringBuilder1.Append("Current Stock");
                                stringBuilder1.Append("</td>");
                                stringBuilder1.Append("<td>");
                                stringBuilder1.Append("Allocated Stock");
                                stringBuilder1.Append("</td>");
                                if (lower != "o")
                                {
                                    stringBuilder1.Append("<td>");
                                    stringBuilder1.Append("Production Quantity");
                                    stringBuilder1.Append("</td>");
                                }
                                stringBuilder1.Append("<td>");
                                stringBuilder1.Append("Available Stock");
                                stringBuilder1.Append("</td>");
                                string empty2 = string.Empty;
                                string empty3 = string.Empty;
                                if (lower != "o")
                                {
                                    empty2 = dataTable2.Rows[0]["TotalQuantity"].ToString();
                                    empty3 = dataTable2.Rows[0]["AvailableQuantity"].ToString();
                                }
                                else
                                {
                                    int num3 = (new BaseClass()).Check_MaxKit_Availability(PriceCatalogueID, 0);
                                    empty2 = string.Empty;
                                    empty3 = num3.ToString();
                                    if (dataTable2.Rows[0]["AllocatedQuantity"] != null && dataTable2.Rows[0]["AllocatedQuantity"] != null)
                                    {
                                        int num4 = num3 + Convert.ToInt32(dataTable2.Rows[0]["AllocatedQuantity"]);
                                        empty2 = num4.ToString();
                                    }
                                }
                                stringBuilder1.Append("</tr>");
                                stringBuilder1.Append("<tr>");
                                stringBuilder1.Append("<td>");
                                stringBuilder1.Append(string.Concat("<input id='txtcurrentstock' type='text' disabled='disable' style='width:125px' value='", empty2, "' class='textboxnew'/>"));
                                stringBuilder1.Append("</td>");
                                stringBuilder1.Append("<td>");
                                stringBuilder1.Append(string.Concat("<input id='txtallocatedstock' type='text'  disabled='disable' style='width:125px;' value='", dataTable2.Rows[0]["AllocatedQuantity"], "' class='textboxnew'/>"));
                                stringBuilder1.Append("</td>");
                                if (lower != "o")
                                {
                                    stringBuilder1.Append("<td>");
                                    int num5 = Convert.ToInt32(dataTable2.Rows[0]["ProductionQuantity"]);
                                    stringBuilder1.Append(string.Concat("<input id='txtproductionquantity' type='text'  disabled='disable' style='width:125px' value='", num5.ToString(), "' class='textboxnew />'"));
                                    stringBuilder1.Append("</td>");
                                }
                                stringBuilder1.Append("<td>");
                                stringBuilder1.Append(string.Concat("<input id='txtavailablestock' type='text'  disabled='disable' style='width:125px' value='", empty3, "' class='textboxnew' />"));
                                stringBuilder1.Append("</td>");
                                stringBuilder1.Append("</tr>");
                                stringBuilder1.Append("</table>");
                                stringBuilder1.Append("</fieldset>");
                                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                            }
                        }
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='border:solid 1px silver;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='height:20px;width:100%padding:2px;background-color:#BCBCBC;font-weight:bold;'>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:25%;float:left;text-align:center;'>Quantity</div>"));
                    if (str == "P")
                    {
                        ControlCollection controls = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Cost_For_1"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                        controls.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    else if (str == "S")
                    {
                        ControlCollection controlCollections = this.plhCatalogueList.Controls;
                        string[] strArrays = new string[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Cost"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                    ControlCollection controls1 = this.plhCatalogueList.Controls;
                    string[] languageConversion1 = new string[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objLanguage.GetLanguageConversion("Markup"), "</div>" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion1)));
                    ControlCollection controlCollections1 = this.plhCatalogueList.Controls;
                    string[] strArrays1 = new string[] { "<div style='width:29%;float:left;text-align:right;'>", this.objLanguage.GetLanguageConversion("Selling_Price"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='height:238px;overflow-y:scroll;border:0px solid'><div>"));
                }
                string str3 = row["ToQuantity"].ToString();
                currencyinRequiredFormate = new object[] { "<option value='", num2, "'>", str3, "</option>" };
                stringBuilder.Append(string.Concat(currencyinRequiredFormate));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='center' style='height:20px;width:99%padding:2px;background-color:", str2, "' class='onlyEmpty'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='width:18%;float:left;text-align:right;'>"));
                if (str == "P")
                {
                    ControlCollection controls2 = this.plhCatalogueList.Controls;
                    object[] objArray = new object[] { "<span id='spn_FromQty_", num2, "'>", row["FromQuantity"].ToString(), "</span> - " };
                    controls2.Add(new LiteralControl(string.Concat(objArray)));
                }
                ControlCollection controlCollections2 = this.plhCatalogueList.Controls;
                object[] objArray1 = new object[] { "<span id='spn_ToQty_", num2, "'>", row["ToQuantity"].ToString(), "</span></div>" };
                controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
                ControlCollection controls3 = this.plhCatalogueList.Controls;
                object[] objArray2 = new object[] { "<div style='width:27%;float:left;text-align:right;display: ", str1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Price"].ToString()), 3, "", false, false, true), "<span id='spn_price_", num2, "' style='display:none;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Price"].ToString()), 3, "", false, false, true), "</span></div>" };
                controls3.Add(new LiteralControl(string.Concat(objArray2)));
                ControlCollection controlCollections3 = this.plhCatalogueList.Controls;
                object[] objArray3 = new object[] { "<div style='width:20%;float:left;text-align:right;display: ", str1, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 3, "", false, false, true), "<span id='spn_markup_", num2, "' style='display:none;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 0, "", false, false, true), "</span></div>" };
                controlCollections3.Add(new LiteralControl(string.Concat(objArray3)));
                ControlCollection controls4 = this.plhCatalogueList.Controls;
                object[] objArray4 = new object[] { "<div style='width:29%;float:left;text-align:right;'><span id='spn_SellingPrice_", num2, "'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["sellingPrice"].ToString()), 3, "", false, false, true), "</span></div>" };
                controls4.Add(new LiteralControl(string.Concat(objArray4)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                num2++;
            }
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left' style='width:100%'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='bgLabel' style='width:23%;'>Quantity</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;border:0px solid'> "));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
            string str4 = ";";
            if (this.modulename == "jobs" || this.modulename == "jobs")
            {
                str4 = ";display:none;";
            }
            else if (this.modulename == "orders")
            {
                str4 = ";display:none;";
            }
            else if (this.modulename == "invoice" && this.IsForInvoice == 1 || this.modulename == "invoice" && this.IsDirectJob == 1)
            {
                str4 = ";display:none;";
            }
            int num6 = 0;
            if (this.ParentEstimateItemID <= (long)0 || !(this.modulename.ToLower() == "jobs") && !(this.modulename.ToLower() == "invoice") && !(this.modulename.ToLower() == "orders"))
            {
                if (str == "S")
                {
                    string str5 = "none";
                    string str6 = "block";
                    if (!ConnectionClass.IsHandy)
                    {
                        str5 = "none";
                        str6 = "block";
                    }
                    else
                    {
                        str5 = "block";
                        str6 = "none";
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections4 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str6, "'>", stringBuilder, " </select>  " };
                    controlCollections4.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    ControlCollection controls5 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_1'  type='text' style='width:70px;text-align:right;display:", str5, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controls5.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections5 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer;' title='Check Availability' ToolTip='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_1','s');  border='0' />" };
                        controlCollections5.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controls6 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str6, "'>", stringBuilder, "</select>  " };
                    controls6.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    ControlCollection controlCollections6 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:70px;text-align:right;display:", str5, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controlCollections6.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls7 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_2','s');  border='0' />" };
                        controls7.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections7 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str6, "'>", stringBuilder, "</select>  " };
                    controlCollections7.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    ControlCollection controls8 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:70px;text-align:right;display:", str5, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controls8.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controlCollections8 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_3','s');  border='0' />" };
                        controlCollections8.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controls9 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str6, "'>", stringBuilder, "</select>  " };
                    controls9.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    ControlCollection controlCollections9 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:70px;text-align:right;display:", str5, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controlCollections9.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls10 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'ddl_req_qty_4','s');  border='0' />" };
                        controls10.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (str == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections10 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'1',", num2, "); onblur=CalculateQtyPrice(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections10.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls11 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_1','p');  border='0' />" };
                        controls11.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections11 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_2' type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num2, "); onblur=CalculateQtyPrice(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections11.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls12 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_2','p');  border='0' />" };
                        controls12.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections12 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_3' type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num2, "); onblur=CalculateQtyPrice(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections12.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls13 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability' onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_3','p');  border='0' />" };
                        controls13.Add(new LiteralControl(string.Concat(languageConversion)));
                        this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<table>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                    ControlCollection controlCollections13 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_4' type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num2, "); onblur=CalculateQtyPrice(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections13.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    if (this.hdn_StockManagement.Value == 1.ToString() && Convert.ToInt32(dataTable.Rows[0]["IsStockItem"]) == 1 && dataTable.Rows[0]["DrawStockFrom"].ToString().ToLower() == "o")
                    {
                        this.plhCatalogueList.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls14 = this.plhCatalogueList.Controls;
                        languageConversion = new string[] { "<img src='", this.strImagepath, "check.png' style='height:20px;width:20px;cursor:pointer' title='Check Kit Availability'  onclick=javascript:GetMaxAvail(", this.hidCatalogueID.Value, ",'txt_req_qty_4','p');  border='0' />" };
                        controls14.Add(new LiteralControl(string.Concat(languageConversion)));
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
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                if (str == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    ControlCollection controlCollections14 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='width:70px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controlCollections14.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    ControlCollection controls15 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='width:70px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controls15.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    ControlCollection controlCollections15 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='width:70px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controlCollections15.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    ControlCollection controls16 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='width:70px;text-align:right;'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controls16.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (str == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                    ControlCollection controlCollections16 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='width:70px;text-align:right;display:block; ' onkeyup=CalculateQtyPrice(this,this.value,'1',", num2, "); onblur=CalculateQtyPrice(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections16.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    ControlCollection controls17 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'2',", num2, "); onblur=CalculateQtyPrice(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controls17.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    ControlCollection controlCollections17 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'3',", num2, "); onblur=CalculateQtyPrice(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections17.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                    ControlCollection controls18 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='width:70px;text-align:right;display:block;' onkeyup=CalculateQtyPrice(this,this.value,'4',", num2, "); onblur=CalculateQtyPrice(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controls18.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
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
                ControlCollection controlCollections18 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_1' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections18.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                ControlCollection controls19 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_2' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls19.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                ControlCollection controlCollections19 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_3' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections19.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                ControlCollection controls20 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_4' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls20.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                string str7 = "Create Multiple Of ";
                str7 = (!ConnectionClass.IsHandy ? "Create Multiple Of " : "Sides");
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", str7, "</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                StringBuilder stringBuilder2 = new StringBuilder();
                for (int i = 1; i <= 12; i++)
                {
                    if (!ConnectionClass.IsHandy)
                    {
                        currencyinRequiredFormate = new object[] { "<option value='", i, "'>", i, "</option>" };
                        stringBuilder2.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else if (i < 3)
                    {
                        currencyinRequiredFormate = new object[] { "<option value='", i, "'>", i, "</option>" };
                        stringBuilder2.Append(string.Concat(currencyinRequiredFormate));
                    }
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<select id='ddlMultiple' onchange='showTotalCostPrice();' class='textboxnew' style='width:75px;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</select>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%;display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>Total Selling Price(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<td style='width:25%;' > "));
                ControlCollection controlCollections20 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_1' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections20.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                ControlCollection controls21 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_2' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls21.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                ControlCollection controlCollections21 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_3' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections21.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%", str4, "' > ")));
                ControlCollection controls22 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_4' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls22.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            }
            else
            {
                foreach (DataRow dataRow in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                {
                    num6 = Convert.ToInt16(dataRow["QtyNumber"].ToString());
                    this.hdnQtyNumber.Value = num6.ToString();
                }
                string str8 = "none";
                string str9 = "block";
                if (!ConnectionClass.IsHandy)
                {
                    str8 = "none";
                    str9 = "block";
                }
                else
                {
                    str8 = "block";
                    str9 = "none";
                }
                string str10 = "display:none;";
                string str11 = "display:none;";
                string str12 = "display:none;";
                string str13 = "display:none;";
                if (num6 == 1)
                {
                    str10 = "display:block;";
                }
                if (num6 == 2)
                {
                    str11 = "display:block;";
                }
                if (num6 == 3)
                {
                    str12 = "display:block;";
                }
                if (num6 == 4)
                {
                    str13 = "display:block;";
                }
                if (str == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str10, "' > ")));
                    if (ConnectionClass.IsHandy)
                    {
                        ControlCollection controlCollections22 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;display:", str9, "'>", stringBuilder, " </select>  " };
                        controlCollections22.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls23 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_1'  type='text'  style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls23.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    else
                    {
                        ControlCollection controlCollections23 = this.plhCatalogueList.Controls;
                        object[] objArray5 = new object[] { "<select id='ddl_req_qty_1' class='textboxnew' onchange=TakeSellPrice(this,'1');onddlChanged(this,'1'); style='width:75px;", str10, "'>", stringBuilder, " </select>  " };
                        controlCollections23.Add(new LiteralControl(string.Concat(objArray5)));
                        ControlCollection controls24 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_1'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls24.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str11, "' > ")));
                    if (ConnectionClass.IsHandy)
                    {
                        ControlCollection controlCollections24 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;display:", str9, "'>", stringBuilder, "</select>  " };
                        controlCollections24.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls25 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num2, ");  onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls25.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    else
                    {
                        ControlCollection controlCollections25 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_2' class='textboxnew' onchange=TakeSellPrice(this,'2');onddlChanged(this,'2'); style='width:75px;", str11, "'>", stringBuilder, "</select>  " };
                        controlCollections25.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls26 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_2'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls26.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str12, "' > ")));
                    if (ConnectionClass.IsHandy)
                    {
                        ControlCollection controlCollections26 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;display:", str9, "'>", stringBuilder, "</select>  " };
                        controlCollections26.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls27 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls27.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    else
                    {
                        ControlCollection controlCollections27 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_3' class='textboxnew' onchange=TakeSellPrice(this,'3');onddlChanged(this,'3'); style='width:75px;", str12, "'>", stringBuilder, "</select>  " };
                        controlCollections27.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls28 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_3'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls28.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str13, "' > ")));
                    if (ConnectionClass.IsHandy)
                    {
                        ControlCollection controlCollections28 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;display:", str9, "'>", stringBuilder, "</select>  " };
                        controlCollections28.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls29 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls29.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    else
                    {
                        ControlCollection controlCollections29 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<select id='ddl_req_qty_4' class='textboxnew' onchange=TakeSellPrice(this,'4');onddlChanged(this,'4'); style='width:75px;", str13, "'>", stringBuilder, "</select>  " };
                        controlCollections29.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        ControlCollection controls30 = this.plhCatalogueList.Controls;
                        currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_4'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                        controls30.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    }
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (str == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str10, " ' > ")));
                    ControlCollection controlCollections30 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_1'  type='text' style='width:70px;text-align:right;", str10, "' onkeyup=CalculateQtyPrice(this,this.value,'1',", num2, "); onblur=CalculateQtyPrice(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections30.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str11, "' > ")));
                    ControlCollection controls31 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_2' type='text' style='width:70px;text-align:right;", str11, "' onkeyup=CalculateQtyPrice(this,this.value,'2',", num2, "); onblur=CalculateQtyPrice(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controls31.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str12, " ' > ")));
                    ControlCollection controlCollections31 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_3' type='text' style='width:70px;text-align:right;", str12, "' onkeyup=CalculateQtyPrice(this,this.value,'3',", num2, "); onblur=CalculateQtyPrice(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections31.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str13, "' > ")));
                    ControlCollection controls32 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_4' type='text' style='width:70px;text-align:right;", str13, "' onkeyup=CalculateQtyPrice(this,this.value,'4',", num2, "); onblur=CalculateQtyPrice(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controls32.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
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
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                if (str == "S")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str10, "' > ")));
                    ControlCollection controlCollections32 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_1'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controlCollections32.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str11, "' > ")));
                    ControlCollection controls33 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_2'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controls33.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str12, "' > ")));
                    ControlCollection controlCollections33 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_3'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controlCollections33.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str13, "' > ")));
                    ControlCollection controls34 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input  id='ddltxt_req_qty_temp_4'  type='text' style='width:70px;text-align:right;display:", str8, "'  onkeyup=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); onblur=TakeSellPrice_ForHandy(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>  " };
                    controls34.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                }
                else if (str == "P")
                {
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str10, " ' > ")));
                    ControlCollection controlCollections34 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_1'  type='text' style='width:70px;text-align:right;", str10, "' onkeyup=CalculateQtyPrice(this,this.value,'1',", num2, "); onblur=CalculateQtyPrice(this,this.value,'1',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections34.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str11, "' > ")));
                    ControlCollection controls35 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_2' type='text' style='width:70px;text-align:right;", str11, "' onkeyup=CalculateQtyPrice(this,this.value,'2',", num2, "); onblur=CalculateQtyPrice(this,this.value,'2',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controls35.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str12, " ' > ")));
                    ControlCollection controlCollections35 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_3' type='text' style='width:70px;text-align:right;", str12, "' onkeyup=CalculateQtyPrice(this,this.value,'3',", num2, "); onblur=CalculateQtyPrice(this,this.value,'3',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controlCollections35.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                    this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                    this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str13, "' > ")));
                    ControlCollection controls36 = this.plhCatalogueList.Controls;
                    currencyinRequiredFormate = new object[] { "<input id='txt_req_qty_temp_4' type='text' style='width:70px;text-align:right;", str13, "' onkeyup=CalculateQtyPrice(this,this.value,'4',", num2, "); onblur=CalculateQtyPrice(this,this.value,'4',", num2, "); autocomplete='off' class='textboxnew' maxlength=7>" };
                    controls36.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
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
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str10, "' > ")));
                ControlCollection controlCollections36 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_1' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections36.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_1' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str11, "' > ")));
                ControlCollection controls37 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_2' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls37.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_2' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str12, "' > ")));
                ControlCollection controlCollections37 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_3' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections37.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_3' style='display:none' ></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%;", str13, "' > ")));
                ControlCollection controls38 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_QtyPrice_4' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls38.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyCost_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<span id='spn_QtyMarkup_4' style='display:none'></span>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                string languageConversion2 = this.objLanguage.GetLanguageConversion("Create_Multiple_Of");
                languageConversion2 = (!ConnectionClass.IsHandy ? "Create Multiple Of " : "Sides");
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='display:", empty1, "'>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div class='bgLabel' style='width:23%;'>", languageConversion2, "</div>")));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                StringBuilder stringBuilder3 = new StringBuilder();
                for (int j = 1; j <= 12; j++)
                {
                    if (!ConnectionClass.IsHandy)
                    {
                        currencyinRequiredFormate = new object[] { "<option value='", j, "'>", j, "</option>" };
                        stringBuilder3.Append(string.Concat(currencyinRequiredFormate));
                    }
                    else if (j < 3)
                    {
                        currencyinRequiredFormate = new object[] { "<option value='", j, "'>", j, "</option>" };
                        stringBuilder3.Append(string.Concat(currencyinRequiredFormate));
                    }
                }
                this.plhCatalogueList.Controls.Add(new LiteralControl("<select id='ddlMultiple' onchange='showTotalCostPrice();' class='textboxnew' style='width:75px;'>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</select>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<div align='left' style='width:100%;display:", empty1, "'>")));
                ControlCollection controlCollections38 = this.plhCatalogueList.Controls;
                languageConversion = new string[] { "<div class='bgLabel' style='width:23%;'>", this.objLanguage.GetLanguageConversion("Total_Selling_Price"), "(", this.commclass.GetCurrencyinRequiredFormate("", true), ")</div>" };
                controlCollections38.Add(new LiteralControl(string.Concat(languageConversion)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='box' style='width:70%;'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 width='100%' Border='0px'> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str10, "' > ")));
                ControlCollection controls39 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_1' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls39.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str11, "' > ")));
                ControlCollection controlCollections39 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_2' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections39.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str12, "' > ")));
                ControlCollection controls40 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_3' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controls40.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl(string.Concat("<td style='width:25%; ", str13, "' > ")));
                ControlCollection controlCollections40 = this.plhCatalogueList.Controls;
                currencyinRequiredFormate = new object[] { "<span id='spn_Total_QtyPrice_4' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.defaultvalue, "</span>" };
                controlCollections40.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</td>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</tr> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</table> "));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
                this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='only10px'></div>"));
            }
            if (this.QueryType == "add" && this.ParentEstimateType.ToLower() == "c")
            {
                string empty4 = string.Empty;
                foreach (DataRow row1 in EstimatesBasePage.Select_ProductCatalogueQty(this.ParentEstimateItemID, this.ParentEstimateType).Rows)
                {
                    currencyinRequiredFormate = new object[] { empty4, row1["Quantity"], "~", row1["QtyNumber"], "µ" };
                    empty4 = string.Concat(currencyinRequiredFormate);
                }
                UpdatePanel updatePanel2 = this.UpdatePanel2;
                Type type = this.UpdatePanel2.GetType();
                languageConversion = new string[] { "TogetMainItemQuatity_forAdditional('", empty4, "','", str, "','", num2.ToString(), "');" };
                ScriptManager.RegisterClientScriptBlock(updatePanel2, type, "Call", string.Concat(languageConversion), true);
            }
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div align='left'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;width:22%'>&nbsp;</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;width:70%'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;display:none'>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<input type='submit' value='Cancel' onclick='javascript:HidePanle();return false;' class='button' style='width:65px' />"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;width:10px;'>&nbsp;</div>"));
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
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;width:10px;'>&nbsp;</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left;'>"));
            Button button1 = new Button()
            {
                Text = this.objLanguage.GetLanguageConversion("Save"),
                CssClass = "button"
            };
            AttributeCollection attributes = button1.Attributes;
            currencyinRequiredFormate = new object[] { "storeToArray(", PriceCatalogueID, ",'", empty, "','", str, "');" };
            attributes.Add("onclick", string.Concat(currencyinRequiredFormate));
            this.plhCatalogueList.Controls.Add(button1);
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div style='float:left; padding-left:4px;'>"));
            Button button2 = new Button()
            {
                ID = "btnidnext",
                Text = "Next",
                CssClass = "button"
            };
            button2.Style.Add("display", "block");
            if (this.OrderAddItemsCount == 0 || ConnectionClass.IsHandy)
            {
                button2.Style.Add("display", "none");
            }
            AttributeCollection attributeCollection = button2.Attributes;
            currencyinRequiredFormate = new object[] { "javascript:funcBtnNextonclick('", PriceCatalogueID, "','", empty, "','", str, "');return false;" };
            attributeCollection.Add("onclick", string.Concat(currencyinRequiredFormate));
            this.plhCatalogueList.Controls.Add(button2);
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("</div>"));
            this.plhCatalogueList.Controls.Add(new LiteralControl("<div class='onlyEmpty'></div>"));
            HiddenField hidCatalogueItems = this.hid_catalogue_items;
            num = dataTable.Rows.Count;
            hidCatalogueItems.Value = num.ToString();
        }

        protected void btnCatalogueFinish_OnClick(object sender, EventArgs e)
        {
            IEnumerator enumerator;
            object[] str;
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string catalogueProfitAndTax = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            long num = (long)0;
            int num1 = 0;
            decimal num2 = new decimal(0);
            if (base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes")
            {
                empty = ",ProfitMargin,SubTotal,Tax,TaxID";
                catalogueProfitAndTax = this.CatalogueProfitAndTax;
                if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
                {
                    this.ParentItemID = this.EstimateBookletItemID;
                }
                else
                {
                    this.ParentItemID = this.ParentEstimateItemID;
                }
                foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                {
                    this.EstTypeFromSP = row["EstimateType"].ToString();
                    this.ParentItemType = row["EstimateType"].ToString();
                }
            }
            else if (base.Request.Params["type"].ToString() == "add" || this.frmcopyitem == "yes")
            {
                empty = ",ProfitMargin,SubTotal,Tax,TaxID";
                str = new object[] { ",", null, null, null, null, null };
                decimal profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                str[1] = profitMargin.ToString();
                str[2] = ",0,";
                profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                str[3] = profitMargin.ToString();
                str[4] = ",";
                str[5] = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                catalogueProfitAndTax = string.Concat(str);
                long parentEstimateItemID = (long)0;
                bool flag = false;
                if (this.ParentEstimateItemID != (long)0)
                {
                    flag = false;
                    parentEstimateItemID = this.ParentEstimateItemID;
                }
                else
                {
                    flag = true;
                    parentEstimateItemID = (long)0;
                }
                if (this.modulename.ToLower() != "invoice")
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "C", flag, parentEstimateItemID);
                }
                else
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "C", flag, parentEstimateItemID);
                }
                EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
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
                else
                {
                    this.EstSingleItemID = (long)0;
                    this.EstTypeFromSP = "";
                }
            }
            int num3 = 0;
            bool flag1 = false;
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
                    string[] strArrays = str2.Split(chrArray);
                    string str3 = "0";
                    string str4 = "";
                    string empty2 = string.Empty;
                    if (base.Request.Params["type"].ToString() == "add" || this.hid_GetItemDescription.Value != "")
                    {
                        base.Session["PricecatalogItemTitle"] = this.hid_GetItemDescription.Value;
                    }
                    if (!string.IsNullOrEmpty(array[j]))
                    {
                        this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
                        empty2 = this.Objclss.SpecialEncode(this.WareItemDesc);
                        if (base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes" && this.hid_GetItemDescription.Value.Trim().Length == 0)
                        {
                            DataTable dataTable = EstimatesBasePage.Pricecatalog_selecttiemdescription_byestimateitemid(this.CompanyID, this.EstimateItemID);
                            enumerator = dataTable.Rows.GetEnumerator();
                            try
                            {
                                if (enumerator.MoveNext())
                                {
                                    empty2 = ((DataRow)enumerator.Current)["ItemDescription"].ToString();
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
                        }
                        stringBuilder.Append(string.Concat(" Insert into [TABLE_EstPriceCatalogue](EstimateItemID,PriceCatalogueID,Quantity,Price,MultipleOf,Markup,QtyNumber,ItemTitle,ItemDescription,ParentItemID,ParentItemType", empty, ",IsSides )"));
                        stringBuilder.Append(string.Concat(" Values (", this.EstimateItemID, ","));
                        for (int k = 0; k < (int)strArrays.Length; k++)
                        {
                            string str5 = strArrays[k];
                            chrArray = new char[] { '»' };
                            string[] strArrays1 = str5.Split(chrArray);
                            if (strArrays[k].Length > 0)
                            {
                                if (strArrays1[0].Trim() == "PriceCatalogueID")
                                {
                                    num = Convert.ToInt64(strArrays1[1].Trim());
                                    stringBuilder.Append(string.Concat(strArrays1[1].Trim(), ","));
                                }
                                else if (strArrays1[0].Trim() == "Quantity")
                                {
                                    num1 = Convert.ToInt32(strArrays1[1].Trim());
                                    stringBuilder.Append(string.Concat(strArrays1[1].Trim(), ","));
                                }
                                else if (strArrays1[0].Trim() == "Price")
                                {
                                    num2 = Convert.ToDecimal(strArrays1[1].Trim());
                                }
                                else if (strArrays1[0].Trim() == "Cost")
                                {
                                    if (strArrays1[1].Trim().Trim().Length != 0)
                                    {
                                        stringBuilder.Append(string.Concat(strArrays1[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append("0,");
                                    }
                                }
                                else if (string.Compare(strArrays1[0], "MultipleOf", true) == 0)
                                {
                                    str3 = strArrays1[1].Trim();
                                    stringBuilder.Append(string.Concat(str3, ","));
                                }
                                else if (string.Compare(strArrays1[0], "CatalogueName", true) == 0)
                                {
                                    if (base.Request.Params["type"].ToString() == "add")
                                    {
                                        string str6 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str4 = str6.Split(chrArray)[0];
                                    }
                                    if (base.Request.Params["type"].ToString() == "edit")
                                    {
                                        string str7 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        if (str7.Split(chrArray)[0] == "")
                                        {
                                            goto Label1;
                                        }
                                        string str8 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str4 = str8.Split(chrArray)[0];
                                        goto Label0;
                                    }
                                    Label1:
                                    str4 = strArrays1[1].Trim();
                                }
                                else if (strArrays1[0].Trim() == "Markup")
                                {
                                    stringBuilder.Append(((strArrays1[1].Trim() ?? "") == "" ? "0," : string.Concat(strArrays1[1].Trim().Replace(",", ""), ",")));
                                    if (!(this.MainType.ToLower() == "edit") || !(this.modulename.ToLower() == "jobs") && !(this.modulename.ToLower() == "invoice") && !(this.modulename.ToLower() == "orders") || (int)array.Length > 2)
                                    {
                                        flag1 = true;
                                        num3 = j + 1;
                                    }
                                    else if (this.ParentEstimateItemID <= (long)0)
                                    {
                                        num3 = 1;
                                    }
                                    else
                                    {
                                        foreach (DataRow row1 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                                        {
                                            num3 = Convert.ToInt16(row1["QtyNumber"].ToString());
                                        }
                                        if (num3 == 0)
                                        {
                                            num3 = 1;
                                        }
                                    }
                                    stringBuilder.Append(string.Concat(num3, ","));
                                    stringBuilder.Append(string.Concat("'", str4, "',"));
                                    stringBuilder.Append(string.Concat("'", empty2, "',"));
                                    str = new object[] { this.ParentItemID, ",'", this.EstTypeFromSP, "'" };
                                    stringBuilder.Append(string.Concat(str));
                                    stringBuilder.Append(catalogueProfitAndTax ?? "");
                                }
                            }
                            Label0:
                            var d = 0;
                        }
                        stringBuilder.Append(string.Concat(",", this.hid_IsSides.Value, ")"));
                    }
                }
                string str9 = string.Concat(" Delete from [TABLE_EstPriceCatalogue] where EstimateItemID=", this.EstimateItemID, "; ");
                stringBuilder.Append(string.Concat(" ; delete from tb_EstPriceCatAddOptionDetails where estimateitemid=", this.EstimateItemID, " "));
                EstimateBasePage.price_catalogue_insert(this.CompanyID, string.Concat(str9, " ", stringBuilder.ToString()), this.EstimateItemID);
                EstimatesBasePage.estimate_othercost_typeid_update(this.CompanyID, this.EstimateItemID, "C", (long)0);
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            this.Insert_activity_history(this.CompanyID, this.EstimateID, this.EstimateItemID);
            if (base.Request.Params["type"].ToString() == "add")
            {
                if (this.ParentItemID == (long)0)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                    string empty3 = string.Empty;
                    foreach (DataRow dataRow1 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        empty3 = dataRow1["StatusID"].ToString();
                    }
                    if (string.Compare(this.modulename, "jobs", true) == 0 && this.ParentEstimateItemID == (long)0)
                    {
                        this.objJava.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty3), "job", this.EstimateItemID, (long)0);
                    }
                    BaseClass baseClass = new BaseClass();
                    string str10 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                    string str11 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                    string str12 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                    string str13 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                    if (str10 == "e")
                    {
                        foreach (DataRow row2 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (row2["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str11, "self", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else if (row2["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockAllocation_Others((long)this.CompanyID, num, num1, str11, Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else if (row2["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row2["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str11, "multiple", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else
                            {
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str11, "additional option", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                        }
                    }
                    else if (str10 == "j" && baseClass.Return_StockManagementSettings("SA_JobStatusID") == empty3.ToString())
                    {
                        foreach (DataRow dataRow2 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (dataRow2["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str11, "self", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else if (dataRow2["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockAllocation_Others((long)this.CompanyID, num, num1, str11, Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else if (dataRow2["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow2["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str11, "multiple", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else
                            {
                                baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str11, "additional option", Convert.ToBoolean(str12), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                        }
                    }
                    if (str13 == "e")
                    {
                        foreach (DataRow row3 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (row3["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                            else if (row3["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                            else if (row3["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row3["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                            else
                            {
                                baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                        }
                    }
                    else if (str13 == "j")
                    {
                        if (baseClass.Return_StockManagementSettings("SR_JobStatusID") == empty3.ToString())
                        {
                            foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                base.Session["StockItemType"] = "C";
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else
                                {
                                    baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                            }
                        }
                    }
                    else if (str13 == "c" && string.Compare(this.modulename, "invoice", true) == 0)
                    {
                        foreach (DataRow row4 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            base.Session["StockItemType"] = "C";
                            if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                            else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                            else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (row4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                            else
                            {
                                baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                            }
                        }
                    }
                }
                if (this.modulename == "jobs")
                {
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    foreach (DataRow dataRow4 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                    {
                        empty4 = dataRow4["PhraseText"].ToString();
                    }
                    foreach (DataRow row5 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                    {
                        empty5 = row5["PhraseText"].ToString();
                    }
                    EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty4, empty5);
                }
            }
            if (base.Request.Params["type"].ToString() == "edit")
            {
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && !flag1)
                {
                    short num4 = 1;
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, num4, this.EstimateID);
                    }
                }
                if (this.Chk_ItemDescn.Checked && this.ParentEstimateItemID == (long)0)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                    string empty6 = string.Empty;
                    foreach (DataRow dataRow5 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                    {
                        empty6 = dataRow5["StatusID"].ToString();
                    }
                    BaseClass baseClass1 = new BaseClass();
                    string str14 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                    string str15 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                    string str16 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                    string str17 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                    string lower = string.Empty;
                    string empty7 = string.Empty;
                    string lower1 = string.Empty;
                    string empty8 = string.Empty;
                    DataTable dataTable1 = new DataTable();
                    DataTable dataTable2 = new DataTable();
                    DataTable dataTable3 = new DataTable();
                    if (this.hid_OldPriceCatalogueID.Value == this.hidCatalogueID.Value)
                    {
                        num = Convert.ToInt64(this.hidCatalogueID.Value);
                        dataTable2 = baseClass1.ProductStockType_Select((long)this.CompanyID, num);
                        foreach (DataRow row6 in dataTable2.Rows)
                        {
                            lower = row6["DrawStockFrom"].ToString().ToLower();
                            if (row6["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                            }
                            else if (row6["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                dataTable1 = baseClass1.StockProductRerunDetails_Select((long)0, num, (long)this.CompanyID, "others", this.EstimateItemID);
                            }
                            else if (row6["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                if (row6["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    continue;
                                }
                                dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "additional option", this.EstimateItemID);
                            }
                            else
                            {
                                dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                            }
                        }
                        foreach (DataRow dataRow6 in dataTable1.Rows)
                        {
                            if (Convert.ToInt32(dataRow6["TotalOldQty"].ToString()) == num1)
                            {
                                continue;
                            }
                            if (str14 != "e")
                            {
                                if (!(str14 == "j") || !(baseClass1.Return_StockManagementSettings("SA_JobStatusID") == empty6.ToString()))
                                {
                                    continue;
                                }
                                if (lower == "s")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty7.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else if (lower == "o")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty7.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else if (lower != "a")
                                {
                                    if (lower != "m")
                                    {
                                        continue;
                                    }
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty7.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                    if (empty7.ToLower() != "success")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                            }
                            else if (lower == "s")
                            {
                                empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty7.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else if (lower == "o")
                            {
                                empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty7.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else if (lower != "a")
                            {
                                if (lower != "m")
                                {
                                    continue;
                                }
                                empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty7.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                            else
                            {
                                empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty7.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                            }
                        }
                    }
                    else
                    {
                        num = Convert.ToInt64(this.hidCatalogueID.Value);
                        long num5 = Convert.ToInt64(this.hid_OldPriceCatalogueID.Value);
                        dataTable2 = baseClass1.ProductStockType_Select((long)this.CompanyID, num);
                        foreach (DataRow row7 in dataTable2.Rows)
                        {
                            lower = row7["DrawStockFrom"].ToString().ToLower();
                            if (row7["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                            }
                            else if (row7["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                dataTable1 = baseClass1.StockProductRerunDetails_Select((long)0, num, (long)this.CompanyID, "others", this.EstimateItemID);
                            }
                            else if (row7["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                if (row7["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    continue;
                                }
                                dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "additional option", this.EstimateItemID);
                            }
                            else
                            {
                                dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                            }
                        }
                        dataTable3 = baseClass1.ProductStockType_Select((long)this.CompanyID, num5);
                        foreach (DataRow dataRow7 in dataTable3.Rows)
                        {
                            lower1 = dataRow7["DrawStockFrom"].ToString().ToLower();
                        }
                        foreach (DataRow row8 in dataTable1.Rows)
                        {
                            if (str14 != "e")
                            {
                                if (!(str14 == "j") || !(baseClass1.Return_StockManagementSettings("SA_JobStatusID") == empty6.ToString()))
                                {
                                    continue;
                                }
                                if (lower1 == "s")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num5, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                else if (lower1 == "o")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num5, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                else if (lower1 == "a")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num5, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                else if (lower1 == "m")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num5, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                if (empty7.ToLower() != "success")
                                {
                                    continue;
                                }
                                if (lower == "s")
                                {
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else if (lower == "o")
                                {
                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else if (lower != "a")
                                {
                                    if (lower != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else
                                {
                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                            }
                            else
                            {
                                if (lower1 == "s")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num5, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                else if (lower1 == "o")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num5, "others", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                else if (lower1 == "a")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num5, (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                else if (lower1 == "m")
                                {
                                    empty7 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num5, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                }
                                if (empty7.ToLower() != "success")
                                {
                                    continue;
                                }
                                if (lower == "s")
                                {
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "self", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else if (lower == "o")
                                {
                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1, str15, Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else if (lower != "a")
                                {
                                    if (lower != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1, str15, "multiple", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                                else
                                {
                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str15, "additional option", Convert.ToBoolean(str16), this.EstimateItemID, "Job", num2, (long)this.UserID);
                                }
                            }
                        }
                    }
                    if (empty7.ToLower() == "success")
                    {
                        if (str17 == "e")
                        {
                            foreach (DataRow dataRow8 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                if (dataRow8["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else if (dataRow8["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else if (dataRow8["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow8["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else
                                {
                                    baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                            }
                        }
                        else if (str17 == "j")
                        {
                            if (baseClass1.Return_StockManagementSettings("SR_JobStatusID") == empty6.ToString())
                            {
                                foreach (DataRow row9 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    base.Session["StockItemType"] = "C";
                                    if (row9["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                    }
                                    else if (row9["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                    }
                                    else if (row9["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row9["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                    }
                                    else
                                    {
                                        baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                    }
                                }
                            }
                        }
                        else if (str17 == "c" && string.Compare(this.modulename, "invoice", true) == 0)
                        {
                            foreach (DataRow dataRow9 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                base.Session["StockItemType"] = "C";
                                if (dataRow9["DrawStockFrom"].ToString().ToLower() == "s")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else if (dataRow9["DrawStockFrom"].ToString().ToLower() == "o")
                                {
                                    baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else if (dataRow9["DrawStockFrom"].ToString().ToLower() != "a")
                                {
                                    if (dataRow9["DrawStockFrom"].ToString().ToLower() != "m")
                                    {
                                        continue;
                                    }
                                    baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "multiple", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
                                }
                                else
                                {
                                    baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num, "additional option", num1, this.EstimateItemID, "Job", (long)this.UserID, num2);
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
            if (this.ParentEstimateItemID == (long)0 && base.Request.Params["type"] != null && base.Request.Params["type"].ToString() == "add" && EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "C") > (long)0)
            {
                HttpResponse response = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, "&parentesttype=C&maintype=edit&subitem=s", this.jID, this.InvID };
                response.Redirect(string.Concat(str));
            }
            string empty9 = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty9 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty9 = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.tabtype == "job")
            {
                HttpResponse httpResponse = base.Response;
                str = new object[] { this.strSitepath, "Jobs/job_item_form.aspx?frm=add&estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(str));
                return;
            }
            if (this.tabtype == "invoice")
            {
                HttpResponse response1 = base.Response;
                str = new object[] { this.strSitepath, "invoice/invoice_item_form.aspx?frm=add&estid=", this.EstimateID, this.jID, this.InvID };
                response1.Redirect(string.Concat(str));
                return;
            }
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString() == "edit" || this.frmcopyitem == "yes")
            {
                if (this.modulename.ToLower() == "orders")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        HttpResponse httpResponse1 = base.Response;
                        str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, " " };
                        httpResponse1.Redirect(string.Concat(str));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, " ", this.jID, this.InvID };
                    response2.Redirect(string.Concat(str));
                    return;
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (empty9.ToLower() == "yes")
                    {
                        HttpResponse httpResponse2 = base.Response;
                        str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, " " };
                        httpResponse2.Redirect(string.Concat(str));
                        return;
                    }
                    HttpResponse response3 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, " " };
                    response3.Redirect(string.Concat(str));
                    return;
                }
                if (empty9.ToLower() == "yes")
                {
                    HttpResponse httpResponse3 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, " ", this.jID, this.InvID };
                    httpResponse3.Redirect(string.Concat(str));
                    return;
                }
                HttpResponse response4 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, " ", this.jID, this.InvID };
                response4.Redirect(string.Concat(str));
                return;
            }
            if (this.modulename.ToLower() == "orders")
            {
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse httpResponse4 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, " " };
                    httpResponse4.Redirect(string.Concat(str));
                    return;
                }
                HttpResponse response5 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, " " };
                response5.Redirect(string.Concat(str));
                return;
            }
            if (this.ParentEstimateItemID != (long)0)
            {
                if (empty9.ToLower() == "yes")
                {
                    HttpResponse httpResponse5 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, " " };
                    httpResponse5.Redirect(string.Concat(str));
                    return;
                }
                HttpResponse response6 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID, " " };
                response6.Redirect(string.Concat(str));
                return;
            }
            if (empty9.ToLower() == "yes")
            {
                HttpResponse httpResponse6 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, " " };
                httpResponse6.Redirect(string.Concat(str));
                return;
            }
            HttpResponse response7 = base.Response;
            str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.EstimateItemID, this.jID, this.InvID, " " };
            response7.Redirect(string.Concat(str));
        }

        protected void btnprevious_onclick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.modulename.ToLower() == "jobs")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, this.modulename);
            }
            else if (this.modulename.ToLower() == "invoice")
            {
                empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.InvoiceID, this.modulename);
            }
            if (this.QueryType == "add")
            {
                if (this.modulename.ToLower() != "orders")
                {
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (empty.ToLower() != "yes")
                        {
                            HttpResponse response = base.Response;
                            object[] estimateID = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                            response.Redirect(string.Concat(estimateID));
                        }
                        else
                        {
                            HttpResponse httpResponse = base.Response;
                            object[] objArray = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, this.jID, this.InvID };
                            httpResponse.Redirect(string.Concat(objArray));
                        }
                    }
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        if (this.submodulename.ToLower() == "estimate")
                        {
                            this.submodulename = "estimates";
                        }
                        if (this.submodulename.ToLower() == "job")
                        {
                            this.submodulename = "job";
                        }
                        if (this.submodulename.ToLower() == "invoice")
                        {
                            this.submodulename = "invoices";
                        }
                        HttpResponse response1 = base.Response;
                        object[] estimateID1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=C&From=F&maintype=", this.MainType, this.jID, this.InvID };
                        response1.Redirect(string.Concat(estimateID1));
                        return;
                    }
                    if (empty.ToLower() == "yes")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        object[] objArray1 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(objArray1));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    object[] estimateID2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response2.Redirect(string.Concat(estimateID2));
                    return;
                }
                if (base.Request.Params["FromAddAnItem"] != null)
                {
                    HttpResponse httpResponse2 = base.Response;
                    object[] objArray2 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, this.jID, this.InvID };
                    httpResponse2.Redirect(string.Concat(objArray2));
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response3 = base.Response;
                    object[] estimateID3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response3.Redirect(string.Concat(estimateID3));
                    return;
                }
            }
            else if (this.QueryType == "edit")
            {
                if (this.modulename.ToLower() != "orders")
                {
                    if (this.ParentEstimateItemID != (long)0)
                    {
                        if (empty.ToLower() == "yes")
                        {
                            HttpResponse httpResponse3 = base.Response;
                            object[] objArray3 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                            httpResponse3.Redirect(string.Concat(objArray3));
                            return;
                        }
                        HttpResponse response4 = base.Response;
                        object[] estimateID4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                        response4.Redirect(string.Concat(estimateID4));
                        return;
                    }
                    if (this.submodulename.ToLower() == "estimate")
                    {
                        this.submodulename = "estimates";
                    }
                    if (this.submodulename.ToLower() == "job")
                    {
                        this.submodulename = "job";
                    }
                    if (this.submodulename.ToLower() == "invoice")
                    {
                        this.submodulename = "invoices";
                    }
                    HttpResponse httpResponse4 = base.Response;
                    object[] objArray4 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_add.aspx?type=Edit&prev=y&estid=", this.EstimateID, "&esttype=C&From=S&EstItemID=", this.EstimateItemID, "&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse4.Redirect(string.Concat(objArray4));
                }
                else if (this.ParentEstimateItemID != (long)0)
                {
                    HttpResponse response5 = base.Response;
                    object[] estimateID5 = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&EstItemID=", this.ParentEstimateItemID, this.jID, this.InvID };
                    response5.Redirect(string.Concat(estimateID5));
                    return;
                }
            }
        }

        public string CalculateFormulaCost(string FormulaVals, int ID)
        {
            MathParser mathParser = new MathParser();
            if (FormulaVals.Substring(0, 1) == "-")
            {
                FormulaVals = string.Concat("0", FormulaVals);
            }
            string str = mathParser.Calculate(FormulaVals).ToString();
            return string.Concat(str, "~", ID);
        }

        public string CalculateFormulaCost_ForMultipleChoice(string FormulaVals, decimal Markup, long ID)
        {
            MathParser mathParser = new MathParser();
            if (FormulaVals.Substring(0, 1) == "-")
            {
                FormulaVals = string.Concat("0", FormulaVals);
            }
            string str = mathParser.Calculate(FormulaVals).ToString();
            decimal num = Convert.ToDecimal(str) + ((Convert.ToDecimal(str) * Markup) / new decimal(100));
            string str1 = string.Concat(num.ToString(), "~", ID);
            return str1;
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            if (this.ddlCategoryBind.Items[1].Selected)
            {
                this.qtype = "A";
            }
            else if (this.ddlCategoryBind.Items[2].Selected)
            {
                this.qtype = "U";
            }
            else if (this.ddlCategoryBind.Items[0].Selected)
            {
                this.qtype = "C";
            }
            base.Session["searchProdouct"] = null;
            this.WhereConditionEstimateProdouct = "";
            foreach (GridColumn column in this.GridPriceCatalogue.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridPriceCatalogue.MasterTableView.FilterExpression = string.Empty;
            this.Common_PriceCatalogue_Call_new(this.qtype, this.CustomerID, this.CustomerName, this.ItemTitle, this.Description, this.fromType, this.SortExpression, this.SortDirection, this.PageSize, 1);
            this.GridPriceCatalogue.MasterTableView.DataBind();
        }

        public void Common_PriceCatalogue_Call(string QueryType, int CustomerID, string CustomerName, string ItemTitle, string Description, string fromType, string SortExpression, string SortDirection, int PageSize, int PageNumber)
        {
            HiddenField hidQueryDetails = this.hid_query_details;
            object[] queryType = new object[] { QueryType, "±", CustomerID, "±", CustomerName, "±", ItemTitle, "±" };
            hidQueryDetails.Value = string.Concat(queryType);
            HiddenField hiddenField = this.hid_query_details;
            string[] value = new string[] { this.hid_query_details.Value, Description, "±", SortExpression, "±", SortDirection };
            hiddenField.Value = string.Concat(value);
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.price_catalogue_select_search(this.CompanyID, QueryType, CustomerID, CustomerName, ItemTitle, Description, PageSize, PageNumber, SortExpression, SortDirection, this.Webstore, this.WhereConditionEstimateProdouct);
            this.GridPriceCatalogue.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.GridPriceCatalogue.DataBind();
            }
            HiddenField str = this.hidCatalogueCount;
            int count = this.GridPriceCatalogue.MasterTableView.Items.Count;
            str.Value = count.ToString();
        }

        public void Common_PriceCatalogue_Call_new(string QueryType, int CustomerID, string CustomerName, string ItemTitle, string Description, string fromType, string SortExpression, string SortDirection, int PageSize, int PageNumber)
        {
            HiddenField hidQueryDetails = this.hid_query_details;
            object[] queryType = new object[] { QueryType, "±", CustomerID, "±", CustomerName, "±", ItemTitle, "±" };
            hidQueryDetails.Value = string.Concat(queryType);
            HiddenField hiddenField = this.hid_query_details;
            string[] value = new string[] { this.hid_query_details.Value, Description, "±", SortExpression, "±", SortDirection };
            hiddenField.Value = string.Concat(value);
            DataSet dataSet = new DataSet();
            dataSet = EstimateBasePage.price_catalogue_select_search(this.CompanyID, QueryType, CustomerID, CustomerName, ItemTitle, Description, PageSize, PageNumber, SortExpression, SortDirection, this.Webstore, this.WhereConditionEstimateProdouct);
            this.GridPriceCatalogue.DataSource = dataSet;
        }

        public void ddlCategoryBind_Onchange(object sender, EventArgs e)
        {
            string str = (this.hid_Price_CustomerID.Value == "" ? "0" : this.hid_Price_CustomerID.Value);
            string str1 = this.txtPriceCatalogueSerach.Value.ToString();
            string str2 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            if (this.ddlCategoryBind.Items[1].Selected)
            {
                HiddenField hdnParam = this.hdn_param;
                object[] pageSize = new object[] { "A±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam.Value = string.Concat(pageSize);
                this.Common_PriceCatalogue_Call("A", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                this.GridPriceCatalogue.Rebind();
                return;
            }
            if (this.ddlCategoryBind.Items[2].Selected)
            {
                HiddenField hiddenField = this.hdn_param;
                object[] objArray = new object[] { "U±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hiddenField.Value = string.Concat(objArray);
                this.Common_PriceCatalogue_Call("U", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                this.GridPriceCatalogue.Rebind();
                return;
            }
            if (this.ddlCategoryBind.Items[0].Selected)
            {
                str = (this.Pub_CustomerID == "" ? "0" : this.Pub_CustomerID);
                HiddenField hdnParam1 = this.hdn_param;
                object[] num = new object[] { "C±", Convert.ToInt32(str), "±", str2, "±", str1, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam1.Value = string.Concat(num);
                this.Common_PriceCatalogue_Call("C", Convert.ToInt32(str), str2, str1, "", "search", "CatalogueName", "asc", this.PageSize, 1);
                this.GridPriceCatalogue.Rebind();
            }
        }

        protected void ddlOtherMultiple_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "edit", "javascript:showDivPopupCenter('divPriceCatalogue', '350');", true);
            if (this.ddlOtherMultiple.SelectedItem.Value != "-1")
            {
                this.BindProductDetails(Convert.ToInt64(this.ddlOtherMultiple.SelectedItem.Value), 'm');
            }
        }

        public string FilterFunction(DataTable dtsearchfilter)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dtsearchfilter.Rows)
            {
                if (row["filter"].ToString().ToLower() != "nofilter" && empty1 != "")
                {
                    empty1 = string.Concat(empty1, " and ");
                }
                string lower = row["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                if (str1 == "startswith")
                {
                    string str2 = empty1;
                    string[] strArrays = new string[] { str2, " ", row["ColumnName"].ToString(), " like '", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays);
                }
                else if (str1 == "endswith")
                {
                    string str3 = empty1;
                    string[] strArrays1 = new string[] { str3, " ", row["ColumnName"].ToString(), " like '%", row["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays1);
                }
                else if (str1 == "equalto")
                {
                    string str4 = empty1;
                    string[] strArrays2 = new string[] { str4, " ", row["ColumnName"].ToString(), " = '", row["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays2);
                }
                else if (str1 == "contains")
                {
                    string str5 = empty1;
                    string[] strArrays3 = new string[] { str5, " ", row["ColumnName"].ToString(), " like '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays3);
                }
                else if (str1 == "doesnotcontain")
                {
                    string str6 = empty1;
                    string[] strArrays4 = new string[] { str6, " ", row["ColumnName"].ToString(), " not like '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays4);
                }
                else if (str1 == "nofilter")
                {
                    string str7 = empty1;
                    string[] strArrays5 = new string[] { str7, " ", row["ColumnName"].ToString(), " > '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays5);
                }
            }
            return empty1;
        }

        protected void GridPriceCatalogue_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            string str = (this.hid_Price_CustomerID.Value == "" ? "0" : this.hid_Price_CustomerID.Value);
            string str1 = this.txtPriceCatalogueSerach.Value.ToString();
            string str2 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            if (this.ddlCategoryBind.Items[1].Selected)
            {
                HiddenField hdnParam = this.hdn_param;
                object[] pageSize = new object[] { "A±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam.Value = string.Concat(pageSize);
                this.Common_PriceCatalogue_Call_new("A", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                return;
            }
            if (this.ddlCategoryBind.Items[2].Selected)
            {
                HiddenField hiddenField = this.hdn_param;
                object[] objArray = new object[] { "U±", 0, "± ±", str1, "±", str1, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                hiddenField.Value = string.Concat(objArray);
                this.Common_PriceCatalogue_Call_new("U", 0, "", str1, str1, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                return;
            }
            if (this.ddlCategoryBind.Items[0].Selected)
            {
                str = (this.Pub_CustomerID == "" ? "0" : this.Pub_CustomerID);
                HiddenField hdnParam1 = this.hdn_param;
                object[] num = new object[] { "C±", Convert.ToInt32(str), "±", str2, "±", str1, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                hdnParam1.Value = string.Concat(num);
                this.Common_PriceCatalogue_Call_new("C", Convert.ToInt32(str), str2, str1, "", "search", "CatalogueName", "asc", this.PageSize, 1);
            }
        }

        public void Insert_activity_history(int CompanyID, long EstimateID, long EstimateItemID)
        {
            if (string.Compare(this.MainType, "add", true) != 0)
            {
                if (base.Request.Params["maintype"] != null && base.Request.Params["maintype"].ToString() == "edit")
                {
                    string empty = string.Empty;
                    if (this.modulename == "estimates")
                    {
                        foreach (DataRow row in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    else if (this.modulename == "jobs")
                    {
                        foreach (DataRow dataRow in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = dataRow["rownumber"].ToString();
                        }
                        this.objnotes.ModuleName = "job";
                        this.objnotes.Item_number = empty;
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemRerun);
                    }
                    else if (this.modulename == "invoice")
                    {
                        foreach (DataRow row1 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = row1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemRerun);
                    }
                    else if (this.modulename == "orders")
                    {
                        foreach (DataRow dataRow1 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                        {
                            empty = dataRow1["rownumber"].ToString();
                        }
                        this.objnotes.Item_number = empty;
                        this.objnotes.ModuleName = "webstoreorder";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemRerun);
                    }
                    this.objnotes.ModuleID = EstimateID;
                    this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass = this.objJava;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objnotes.ItemID = EstimateItemID;
                    this.objN.NotesAdd(this.objnotes);
                }
                return;
            }
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            foreach (DataRow row2 in Notes.select_EstimateType_for_Activity_History(EstimateID, EstimateItemID).Rows)
            {
                str = row2["EstimateType"].ToString();
            }
            if (str == "S")
            {
                empty1 = "Sheet Fed Digital Single Item";
            }
            else if (str == "P")
            {
                empty1 = "Sheet Fed Digital Pad Item";
            }
            else if (str == "B")
            {
                empty1 = "Sheet Fed Digital Booklet Item";
            }
            else if (str == "L")
            {
                empty1 = "Large Format Item";
            }
            else if (str == "W")
            {
                empty1 = "Warehouse Item";
            }
            else if (str == "O")
            {
                empty1 = "OutWork Item";
            }
            else if (str == "C")
            {
                empty1 = "Price Catalogue Item";
            }
            else if (str == "U")
            {
                empty1 = "Other Costs Item";
            }
            else if (str == "F")
            {
                empty1 = "Sheet Fed Offset Single Item";
            }
            else if (str == "D")
            {
                empty1 = "Sheet Fed Offset Pad Item";
            }
            else if (str == "N")
            {
                empty1 = "Sheet Fed Offset Ncr Item";
            }
            else if (str == "K")
            {
                empty1 = "Sheet Fed Offset Booklet Item";
            }
            else if (str == "Q")
            {
                empty1 = "Quick Quote Item";
            }
            foreach (DataRow dataRow2 in Notes.select_item_Title_for_Activity_History(CompanyID, EstimateID, EstimateItemID, str).Rows)
            {
                str1 = dataRow2["itemtitle"].ToString();
            }
            if (base.Request.Params["FromAddAnItem"] != null || base.Request.Params["FrmAddAnItem"] == "Y")
            {
                string empty2 = string.Empty;
                foreach (DataRow row3 in Notes.select_item_number_for_Activity_History(EstimateID, EstimateItemID, this.modulename).Rows)
                {
                    empty2 = row3["rownumber"].ToString();
                }
                if (this.modulename == "estimates")
                {
                    this.objnotes.Item_title = str1;
                    this.objnotes.ModuleName = "estimate";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Estimate_type = empty1;
                }
                else if (this.modulename == "jobs")
                {
                    this.objnotes.Item_title = str1;
                    this.objnotes.ModuleName = "job";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Job_type = empty1;
                }
                else if (this.modulename == "invoice")
                {
                    this.objnotes.Item_title = str1;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Invoice_type = empty1;
                }
                else if (this.modulename == "orders")
                {
                    this.objnotes.Item_title = str1;
                    this.objnotes.ModuleName = "webstoreorder";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewItemAdd);
                    this.objnotes.Item_number = string.Concat(" ", empty2);
                    this.objnotes.Estimate_type = empty1;
                }
                this.objnotes.ModuleID = EstimateID;
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
            string str2 = string.Empty;
            if (this.modulename == "estimates")
            {
                foreach (DataRow dataRow3 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "", (long)0).Rows)
                {
                    str2 = dataRow3["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_type = empty1;
                this.objnotes.Estimate_number = str2;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
            }
            else if (this.modulename == "jobs")
            {
                foreach (DataRow row4 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "", (long)0).Rows)
                {
                    str2 = row4["jobnumber"].ToString();
                }
                this.objnotes.Job_type = empty1;
                this.objnotes.ModuleName = "job";
                this.objnotes.Job_number = str2;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobDirCreate);
            }
            else if (this.modulename == "invoice")
            {
                foreach (DataRow dataRow4 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "", (long)0).Rows)
                {
                    str2 = dataRow4["invoicenumber"].ToString();
                }
                this.objnotes.Invoice_type = empty1;
                this.objnotes.Invoice_number = str2;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvDirCreate);
            }
            else if (this.modulename == "orders")
            {
                foreach (DataRow row5 in EstimatesBasePage.select_details_for_Activity_History(CompanyID, EstimateID, "", (long)0).Rows)
                {
                    str2 = row5["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_type = empty1;
                this.objnotes.Estimate_number = str2;
                this.objnotes.ModuleName = "webstoreorder";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCreate);
            }
            this.objnotes.ModuleID = EstimateID;
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

        public string Insert_Warehouse_ItemDescription()
        {
            object wareItemDesc;
            object[] str;
            DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "C");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (string.Compare(row["DatabaseFieldName"].ToString(), "ItemTitle", true) == 0)
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew.WareItemDesc;
                    str = new object[] { wareItemDesc, "ItemTitle»", row["ScreenName"].ToString(), "»", this.hdn_title.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Description", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew1 = this;
                    object obj = usercontrolItemEstimatePriceCatalogueNew1.WareItemDesc;
                    object[] objArray = new object[] { obj, "µDescription»", row["ScreenName"].ToString(), "»", this.hdn_description.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew1.WareItemDesc = string.Concat(objArray);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Artwork", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew2 = this;
                    object wareItemDesc1 = usercontrolItemEstimatePriceCatalogueNew2.WareItemDesc;
                    object[] str1 = new object[] { wareItemDesc1, "µArtwork»", row["ScreenName"].ToString(), "»", this.hdn_artwork.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew2.WareItemDesc = string.Concat(str1);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Colour", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew3 = this;
                    object obj1 = usercontrolItemEstimatePriceCatalogueNew3.WareItemDesc;
                    object[] objArray1 = new object[] { obj1, "µColour»", row["ScreenName"].ToString(), "»", this.hdn_color.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew3.WareItemDesc = string.Concat(objArray1);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Size", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew4 = this;
                    object wareItemDesc2 = usercontrolItemEstimatePriceCatalogueNew4.WareItemDesc;
                    object[] str2 = new object[] { wareItemDesc2, "µSize»", row["ScreenName"].ToString(), "»", this.hdn_size.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew4.WareItemDesc = string.Concat(str2);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Material", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew5 = this;
                    object obj2 = usercontrolItemEstimatePriceCatalogueNew5.WareItemDesc;
                    object[] objArray2 = new object[] { obj2, "µMaterial»", row["ScreenName"].ToString(), "»", this.hdn_Material.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew5.WareItemDesc = string.Concat(objArray2);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Delivery", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew6 = this;
                    object wareItemDesc3 = usercontrolItemEstimatePriceCatalogueNew6.WareItemDesc;
                    object[] str3 = new object[] { wareItemDesc3, "µDelivery»", row["ScreenName"].ToString(), "»", this.hdn_Delivery.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew6.WareItemDesc = string.Concat(str3);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Finishing", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew7 = this;
                    object obj3 = usercontrolItemEstimatePriceCatalogueNew7.WareItemDesc;
                    object[] objArray3 = new object[] { obj3, "µFinishing»", row["ScreenName"].ToString(), "»", this.hdn_Finish.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew7.WareItemDesc = string.Concat(objArray3);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Proofs", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew8 = this;
                    object wareItemDesc4 = usercontrolItemEstimatePriceCatalogueNew8.WareItemDesc;
                    object[] str4 = new object[] { wareItemDesc4, "µProofs»", row["ScreenName"].ToString(), "»", this.hdn_Proofs.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew8.WareItemDesc = string.Concat(str4);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Packing", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew9 = this;
                    object obj4 = usercontrolItemEstimatePriceCatalogueNew9.WareItemDesc;
                    object[] objArray4 = new object[] { obj4, "µPacking»", row["ScreenName"].ToString(), "»", this.hdn_Packing.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew9.WareItemDesc = string.Concat(objArray4);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Notes", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew10 = this;
                    object wareItemDesc5 = usercontrolItemEstimatePriceCatalogueNew10.WareItemDesc;
                    object[] str5 = new object[] { wareItemDesc5, "µNotes»", row["ScreenName"].ToString(), "»", this.hdn_Notes.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew10.WareItemDesc = string.Concat(str5);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Instructions", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew11 = this;
                    object obj5 = usercontrolItemEstimatePriceCatalogueNew11.WareItemDesc;
                    object[] objArray5 = new object[] { obj5, "µInstructions»", row["ScreenName"].ToString(), "»", this.hdn_terms.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew11.WareItemDesc = string.Concat(objArray5);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 1", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew12 = this;
                    object wareItemDesc6 = usercontrolItemEstimatePriceCatalogueNew12.WareItemDesc;
                    object[] str6 = new object[] { wareItemDesc6, "µCustom Description 1»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription1.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew12.WareItemDesc = string.Concat(str6);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 2", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew13 = this;
                    object obj6 = usercontrolItemEstimatePriceCatalogueNew13.WareItemDesc;
                    object[] objArray6 = new object[] { obj6, "µCustom Description 2»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription2.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew13.WareItemDesc = string.Concat(objArray6);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 3", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew14 = this;
                    object wareItemDesc7 = usercontrolItemEstimatePriceCatalogueNew14.WareItemDesc;
                    object[] str7 = new object[] { wareItemDesc7, "µCustom Description 3»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription3.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew14.WareItemDesc = string.Concat(str7);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 4", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew15 = this;
                    object obj7 = usercontrolItemEstimatePriceCatalogueNew15.WareItemDesc;
                    object[] objArray7 = new object[] { obj7, "µCustom Description 4»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription4.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew15.WareItemDesc = string.Concat(objArray7);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 5", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew16 = this;
                    object wareItemDesc8 = usercontrolItemEstimatePriceCatalogueNew16.WareItemDesc;
                    object[] str8 = new object[] { wareItemDesc8, "µCustom Description 5»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription5.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew16.WareItemDesc = string.Concat(str8);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 6", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew17 = this;
                    object obj8 = usercontrolItemEstimatePriceCatalogueNew17.WareItemDesc;
                    object[] objArray8 = new object[] { obj8, "µCustom Description 6»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription6.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew17.WareItemDesc = string.Concat(objArray8);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 7", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew18 = this;
                    object wareItemDesc9 = usercontrolItemEstimatePriceCatalogueNew18.WareItemDesc;
                    object[] str9 = new object[] { wareItemDesc9, "µCustom Description 7»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription7.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew18.WareItemDesc = string.Concat(str9);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 8", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew19 = this;
                    object obj9 = usercontrolItemEstimatePriceCatalogueNew19.WareItemDesc;
                    object[] objArray9 = new object[] { obj9, "µCustom Description 8»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription8.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew19.WareItemDesc = string.Concat(objArray9);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 9", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew20 = this;
                    object wareItemDesc10 = usercontrolItemEstimatePriceCatalogueNew20.WareItemDesc;
                    object[] str10 = new object[] { wareItemDesc10, "µCustom Description 9»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription9.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew20.WareItemDesc = string.Concat(str10);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 10", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew21 = this;
                    object obj10 = usercontrolItemEstimatePriceCatalogueNew21.WareItemDesc;
                    object[] objArray10 = new object[] { obj10, "µCustom Description 10»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription10.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew21.WareItemDesc = string.Concat(objArray10);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 11", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew22 = this;
                    object wareItemDesc11 = usercontrolItemEstimatePriceCatalogueNew22.WareItemDesc;
                    object[] str11 = new object[] { wareItemDesc11, "µCustom Description 11»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription11.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew22.WareItemDesc = string.Concat(str11);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 12", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew23 = this;
                    object obj11 = usercontrolItemEstimatePriceCatalogueNew23.WareItemDesc;
                    object[] objArray11 = new object[] { obj11, "µCustom Description 12»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription12.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew23.WareItemDesc = string.Concat(objArray11);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 13", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew24 = this;
                    object wareItemDesc12 = usercontrolItemEstimatePriceCatalogueNew24.WareItemDesc;
                    object[] str12 = new object[] { wareItemDesc12, "µCustom Description 13»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription13.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew24.WareItemDesc = string.Concat(str12);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 14", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew25 = this;
                    object obj12 = usercontrolItemEstimatePriceCatalogueNew25.WareItemDesc;
                    object[] objArray12 = new object[] { obj12, "µCustom Description 14»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription14.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew25.WareItemDesc = string.Concat(objArray12);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 15", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew26 = this;
                    object wareItemDesc13 = usercontrolItemEstimatePriceCatalogueNew26.WareItemDesc;
                    object[] str13 = new object[] { wareItemDesc13, "µCustom Description 15»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription15.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew26.WareItemDesc = string.Concat(str13);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 16", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew27 = this;
                    object obj13 = usercontrolItemEstimatePriceCatalogueNew27.WareItemDesc;
                    object[] objArray13 = new object[] { obj13, "µCustom Description 16»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription16.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew27.WareItemDesc = string.Concat(objArray13);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 17", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew28 = this;
                    object wareItemDesc14 = usercontrolItemEstimatePriceCatalogueNew28.WareItemDesc;
                    str = new object[] { wareItemDesc14, "µCustom Description 17»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription17.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew28.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 18", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew29 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew29.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 18»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription18.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew29.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 19", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew30 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew30.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 19»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription19.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew30.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 20", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew31 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew31.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 20»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription20.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew31.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 21", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew32 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew32.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 21»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription21.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew32.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 22", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew33 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew33.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 22»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription22.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew33.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 23", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew34 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew34.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 23»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription23.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew34.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 24", true) == 0 && Convert.ToBoolean(row["IsChecked"]))
                {
                    estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew35 = this;
                    wareItemDesc = usercontrolItemEstimatePriceCatalogueNew35.WareItemDesc;
                    str = new object[] { wareItemDesc, "µCustom Description 24»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription24.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                    usercontrolItemEstimatePriceCatalogueNew35.WareItemDesc = string.Concat(str);
                }
                if (string.Compare(row["DatabaseFieldName"].ToString(), "Custom Description 25", true) != 0 || !Convert.ToBoolean(row["IsChecked"]))
                {
                    continue;
                }
                estimate_price_catalogueNew usercontrolItemEstimatePriceCatalogueNew36 = this;
                wareItemDesc = usercontrolItemEstimatePriceCatalogueNew36.WareItemDesc;
                str = new object[] { wareItemDesc, "µCustom Description 25»", row["ScreenName"].ToString(), "»", this.hdn_CustomDescription25.Value, "»", Convert.ToBoolean(row["IsChecked"]) };
                usercontrolItemEstimatePriceCatalogueNew36.WareItemDesc = string.Concat(str);
            }
            return this.WareItemDesc;
        }

        protected void lnkCatalogueList_OnClick(object sender, EventArgs e)
        {
            this.spn_Catalogue_Name.InnerHtml = this.objBase.SpecialDecode(this.hdn_cataloguename.Value);
            long num = Convert.ToInt64(this.hidCatalogueID.Value);
            if (base.Session["ProductStockManagement"] == null)
            {
                this.pnlOtherMultiple.Visible = false;
                this.BindProductDetails(num, 'z');
            }
            else
            {
                if (base.Session["ProductStockManagement"].ToString().Trim().ToLower() != "true")
                {
                    this.pnlOtherMultiple.Visible = false;
                    this.BindProductDetails(num, 'z');
                    return;
                }
                DataTable dataTable = (new BaseClass()).ProductStockType_Select((long)this.CompanyID, num);
                if (dataTable.Rows.Count <= 0)
                {
                    this.pnlOtherMultiple.Visible = false;
                    this.BindProductDetails(num, 'z');
                    return;
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DrawStockFrom"].ToString().ToLower() != "m")
                    {
                        this.pnlOtherMultiple.Visible = false;
                        this.BindProductDetails(num, Convert.ToChar(row["DrawStockFrom"].ToString().ToLower()));
                    }
                    else
                    {
                        this.BindOtherMultipleDropdownList(num);
                        this.hdnDrawStockFrom.Value = "m";
                        DataTable dataTable1 = WebstoreBasePage.OtherMultiple_DefaultItem_Select(num);
                        if (dataTable1.Rows.Count > 0)
                        {
                            if (dataTable1.Rows[0]["KitItemID"] == null)
                            {
                                continue;
                            }
                            this.objBase.SetDDLValue(this.ddlOtherMultiple, dataTable1.Rows[0]["KitItemID"].ToString());
                            this.BindProductDetails(Convert.ToInt64(dataTable1.Rows[0]["KitItemID"]), Convert.ToChar(row["DrawStockFrom"].ToString().ToLower()));
                            this.pnlOtherMultiple.Visible = true;
                        }
                        else if (this.ddlOtherMultiple.Items.Count <= 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HidePanle();alert('There are no Kit items in Product');", true);
                        }
                        else
                        {
                            this.BindProductDetails(Convert.ToInt64(this.ddlOtherMultiple.Items[0].Value), Convert.ToChar(row["DrawStockFrom"].ToString().ToLower()));
                            this.pnlOtherMultiple.Visible = true;
                        }
                    }
                }
            }
        }

        protected void lnkLoadPriceCatalogue_OnClick(object sender, EventArgs e)
        {
            string str = (this.hid_Price_CustomerID.Value == "" ? "0" : this.hid_Price_CustomerID.Value);
            string str1 = this.txtPriceCatalogueSerach.Value.ToString();
            string str2 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            HiddenField hdnParam = this.hdn_param;
            object[] num = new object[] { "C±", Convert.ToInt32(str), "±", str2, "±", str1, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
            hdnParam.Value = string.Concat(num);
            this.Common_PriceCatalogue_Call("C", Convert.ToInt32(str), str2, str1, "", "search", "CatalogueName", "asc", this.PageSize, 1);
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
            if (base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes")
            {
                empty1 = ",ProfitMargin,SubTotal,Tax,TaxID";
                catalogueProfitAndTax = this.CatalogueProfitAndTax;
                if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
                {
                    this.ParentItemID = this.EstimateBookletItemID;
                }
                else
                {
                    this.ParentItemID = this.ParentEstimateItemID;
                }
                foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.ParentEstimateItemID, this.EstimateID).Rows)
                {
                    this.EstTypeFromSP = row["EstimateType"].ToString();
                    this.ParentItemType = row["EstimateType"].ToString();
                }
            }
            else if (base.Request.Params["type"].ToString() == "add" || this.frmcopyitem == "yes")
            {
                empty1 = ",ProfitMargin,SubTotal,Tax,TaxID";
                str = new object[] { ",", null, null, null, null, null };
                decimal profitMargin = EstimatesBasePage.GetProfitMargin(this.CompanyID, this.EstimateID);
                str[1] = profitMargin.ToString();
                str[2] = ",0,";
                profitMargin = EstimatesBasePage.GetTaxRate(this.CompanyID, this.EstimateID);
                str[3] = profitMargin.ToString();
                str[4] = ",";
                str[5] = EstimatesBasePage.GetTaxID(this.CompanyID, this.EstimateID);
                catalogueProfitAndTax = string.Concat(str);
                long parentEstimateItemID = (long)0;
                bool flag = false;
                if (this.ParentEstimateItemID != (long)0)
                {
                    flag = false;
                    parentEstimateItemID = this.ParentEstimateItemID;
                }
                else
                {
                    flag = true;
                    parentEstimateItemID = (long)0;
                }
                if (this.InvoiceID <= (long)0)
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, this.EstimateID, "C", flag, parentEstimateItemID);
                }
                else
                {
                    this.EstimateItemID = EstimatesBasePage.Estimate_Item_Insert(this.CompanyID, (long)0, "C", flag, parentEstimateItemID);
                }
                if (this.ParentEstimateItemID != (long)0)
                {
                    if (string.Compare(this.ParentEstimateType, "B", true) == 0 || string.Compare(this.ParentEstimateType, "N", true) == 0 || string.Compare(this.ParentEstimateType, "K", true) == 0)
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
                        dataRow["EstimateType"].ToString();
                    }
                }
                else
                {
                    this.EstSingleItemID = (long)0;
                    this.EstTypeFromSP = "";
                }
                int num4 = 0;
                if (base.Session["AccountCodeID"] != null)
                {
                    num4 = Convert.ToInt32(base.Session["AccountCodeID"].ToString());
                }
                EstimatesBasePage.Estimate_Item_AccountCode_Insert(this.EstimateItemID, num4);
            }
            int num5 = 0;
            bool flag1 = false;
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
                    string[] strArrays = str3.Split(chrArray);
                    string str4 = "0";
                    string str5 = "";
                    string empty3 = string.Empty;
                    if (base.Request.Params["type"].ToString() == "add" || this.hid_GetItemDescription.Value != "")
                    {
                        base.Session["PricecatalogItemTitle"] = this.hid_GetItemDescription.Value;
                    }
                    if (!string.IsNullOrEmpty(array[j]))
                    {
                        this.WareItemDesc = this.Insert_Warehouse_ItemDescription();
                        empty3 = this.Objclss.SpecialEncode(this.WareItemDesc);
                        if (base.Request.Params["type"].ToString() == "edit" && this.frmcopyitem != "yes" && this.hid_GetItemDescription.Value.Trim().Length == 0)
                        {
                            foreach (DataRow row1 in EstimatesBasePage.Pricecatalog_selecttiemdescription_byestimateitemid(this.CompanyID, this.EstimateItemID).Rows)
                            {
                                for (int k = 0; k <= 0; k++)
                                {
                                    empty3 = row1["ItemDescription"].ToString();
                                }
                            }
                        }
                        stringBuilder.Append(string.Concat(" Insert into [TABLE_EstPriceCatalogue](EstimateItemID,PriceCatalogueID,Quantity,Price,MultipleOf,Markup,QtyNumber,ItemTitle,ItemDescription,ParentItemID,ParentItemType", empty1, ",IsSides )"));
                        stringBuilder.Append(string.Concat(" Values (", this.EstimateItemID, ","));
                        for (int l = 0; l < (int)strArrays.Length; l++)
                        {
                            string str6 = strArrays[l];
                            chrArray = new char[] { '»' };
                            string[] strArrays1 = str6.Split(chrArray);
                            if (strArrays[l].Length > 0)
                            {
                                if (strArrays1[0].Trim() == "PriceCatalogueID")
                                {
                                    num = Convert.ToInt64(strArrays1[1].Trim().ToString());
                                    stringBuilder.Append(string.Concat(strArrays1[1].Trim(), ","));
                                }
                                else if (strArrays1[0].Trim() == "Quantity")
                                {
                                    num1 = Convert.ToInt32(strArrays1[1].Trim().ToString());
                                    stringBuilder.Append(string.Concat(strArrays1[1].Trim(), ","));
                                }
                                else if (strArrays1[0].Trim() == "Price")
                                {
                                    num3 = Convert.ToDecimal(strArrays1[1].Trim());
                                }
                                else if (strArrays1[0].Trim() == "Cost")
                                {
                                    if (strArrays1[1].Trim().Trim().Length != 0)
                                    {
                                        stringBuilder.Append(string.Concat(strArrays1[1].Trim(), ","));
                                    }
                                    else
                                    {
                                        stringBuilder.Append("0,");
                                    }
                                }
                                else if (string.Compare(strArrays1[0], "MultipleOf", true) == 0)
                                {
                                    str4 = strArrays1[1].Trim();
                                    if (str4 != "0" && str4 != "")
                                    {
                                        num2 = Convert.ToInt32(str4);
                                    }
                                    stringBuilder.Append(string.Concat(str4, ","));
                                }
                                else if (string.Compare(strArrays1[0], "CatalogueName", true) == 0)
                                {
                                    if (base.Request.Params["type"].ToString() == "add")
                                    {
                                        string str7 = this.hid_GetItemDescription.Value.ToString();
                                        chrArray = new char[] { '~' };
                                        str5 = str7.Split(chrArray)[0];
                                    }
                                    if (base.Request.Params["type"].ToString() == "edit")
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
                                    str5 = strArrays1[1].Trim();
                                }
                                else if (strArrays1[0].Trim() == "Markup")
                                {
                                    stringBuilder.Append(((strArrays1[1].Trim() ?? "") == "" ? "0," : string.Concat(strArrays1[1].Trim().Replace(",", ""), ",")));
                                    if (this.modulename.ToLower() != "jobs" && this.modulename.ToLower() != "invoice" && this.modulename.ToLower() != "orders" || (int)array.Length > 2)
                                    {
                                        flag1 = true;
                                        num5 = j + 1;
                                    }
                                    else if (this.ParentEstimateItemID <= (long)0)
                                    {
                                        num5 = 1;
                                    }
                                    else
                                    {
                                        foreach (DataRow dataRow1 in JobBasePage.Job_Quantity_Numbert_Select(this.CompanyID, this.ParentEstimateItemID).Rows)
                                        {
                                            num5 = Convert.ToInt16(dataRow1["QtyNumber"].ToString());
                                        }
                                        if (num5 == 0)
                                        {
                                            num5 = 1;
                                        }
                                    }
                                    stringBuilder.Append(string.Concat(num5, ","));
                                    stringBuilder.Append(string.Concat("'", str5, "',"));
                                    stringBuilder.Append(string.Concat("'", empty3, "',"));
                                    str = new object[] { this.ParentItemID, ",'", this.EstTypeFromSP, "'" };
                                    stringBuilder.Append(string.Concat(str));
                                    stringBuilder.Append(catalogueProfitAndTax ?? "");
                                }
                            }
                            Label0:
                            var d = 0;
                        }
                        stringBuilder.Append(string.Concat(",", this.hid_IsSides.Value, ")"));
                    }
                }
                string empty4 = string.Empty;
                empty4 = string.Concat(" Delete from [TABLE_EstPriceCatalogue] where EstimateItemID=", this.EstimateItemID, "; ");
                EstimateBasePage.price_catalogue_insert(this.CompanyID, string.Concat(empty4, " ", stringBuilder.ToString()), this.EstimateItemID);
                EstimatesBasePage.estimate_othercost_typeid_update(this.CompanyID, this.EstimateItemID, "C", (long)0);
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            EstimatesBasePage.estimatenumberupdateandiscomplete(this.CompanyID, this.EstimateID, this.EstimateItemID, ConnectionClass.IsHandy);
            if (base.Request.Params["type"].ToString() == "add")
            {
                if (this.ParentItemID == (long)0)
                {
                    EstimateCommonMethods.UpdateDescription(this.EstimateItemID, this.EstimateID, "C", false);
                }
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
                {
                    JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, 1, this.EstimateID);
                    EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                }
                if (this.modulename == "jobs")
                {
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    foreach (DataRow row2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Header").Rows)
                    {
                        empty5 = row2["PhraseText"].ToString();
                    }
                    foreach (DataRow dataRow2 in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Job Footer").Rows)
                    {
                        empty6 = dataRow2["PhraseText"].ToString();
                    }
                    EstimateBasePage.estimate_tojob_headerfooter_update(this.CompanyID, this.EstimateID, empty5, empty6);
                }
            }
            if (base.Request.Params["type"].ToString() == "edit")
            {
                if ((string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0) && !flag1)
                {
                    short num6 = 1;
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        JobBasePage.Job_Jobcard_Insert_NewItem(this.CompanyID, this.EstimateItemID, num6, this.EstimateID);
                    }
                }
                if (this.Chk_ItemDescn.Checked && this.ParentEstimateItemID == (long)0)
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
            int num7 = 0;
            string value1 = this.hid_SaveToAdditionalItems.Value;
            chrArray = new char[] { 'µ' };
            string[] strArrays2 = value1.Split(chrArray);
            for (int m = 0; m <= (int)strArrays2.Length - 1; m++)
            {
                if (strArrays2[m] != "")
                {
                    num7 = (m != 0 ? 0 : 1);
                    string str10 = strArrays2[m].ToString();
                    chrArray = new char[] { '~' };
                    string[] strArrays3 = str10.Split(chrArray);
                    for (int n = 0; n < (int)strArrays3.Length; n++)
                    {
                        if (strArrays3[n] != "")
                        {
                            string str11 = strArrays3[n].ToString();
                            chrArray = new char[] { '±' };
                            string[] strArrays4 = str11.Split(chrArray);
                            int num8 = 0;
                            for (int o = 0; o <= (int)strArrays4.Length - 1; o++)
                            {
                                if (strArrays4[o] != "")
                                {
                                    string str12 = strArrays4[o];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays5 = str12.Split(chrArray);
                                    if (strArrays5[0] != "")
                                    {
                                        if (strArrays5[0] == "QtyNo")
                                        {
                                            num8 = Convert.ToInt32(strArrays5[1]);
                                        }
                                        if (strArrays5[0] == "OthercostID")
                                        {
                                            this.OthercostID = Convert.ToInt64(strArrays5[1]);
                                        }
                                        else if (strArrays5[0] == "Formula")
                                        {
                                            this.Formula = strArrays5[1];
                                        }
                                        else if (strArrays5[0] == "MarkUp")
                                        {
                                            if (strArrays5[1] != "undefined")
                                            {
                                                this.MarkUp = Convert.ToDecimal(strArrays5[1]);
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
                                        else if (strArrays5[0] == "TotalPrice")
                                        {
                                            this.TotalPrice = Convert.ToDecimal(strArrays5[1]);
                                        }
                                        else if (strArrays5[0] == "SelectedID")
                                        {
                                            if (strArrays5[1] != "undefined")
                                            {
                                                this.SelectedID = Convert.ToInt64(strArrays5[1]);
                                            }
                                            else
                                            {
                                                this.SelectedID = (long)0;
                                            }
                                        }
                                        else if (strArrays5[0] == "SelectedValue")
                                        {
                                            this.SelectedValue = strArrays5[1];
                                        }
                                        else if (strArrays5[0] == "MarkUpValue")
                                        {
                                            this.MarkUpValue = Convert.ToDecimal(strArrays5[1]);
                                        }
                                        else if (strArrays5[0] == "SelectedPrice")
                                        {
                                            if (strArrays5[1] != "")
                                            {
                                                this.SelectedPrice = Convert.ToDecimal(strArrays5[1]);
                                            }
                                            else
                                            {
                                                this.SelectedPrice = new decimal(0);
                                            }
                                        }
                                        else if (strArrays5[0] == "SortOrderNo")
                                        {
                                            this.SortOrderNo = Convert.ToInt32(strArrays5[1]);
                                        }
                                        else if (strArrays5[0] == "ParentWebOtherCostID")
                                        {
                                            this.ParentWebOtherCostID = Convert.ToInt64(strArrays5[1]);
                                        }
                                        else if (strArrays5[0] == "WebOtherCostType")
                                        {
                                            this.WebOtherCostType = strArrays5[1];
                                        }
                                    }
                                }
                                if (num8 == 1)
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
                                else if (num8 == 2)
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
                                else if (num8 == 3)
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
                                else if (num8 == 4)
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
                            DataSet dataSet = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(this.OthercostID));
                            foreach (DataRow row3 in dataSet.Tables[0].Rows)
                            {
                                this.MainCalculationtype = row3["MainCalculationType"].ToString();
                                this.CalculationType = this.MainCalculationtype;
                                this.OtherCostName = row3["UserFriendlyName"].ToString();
                                this.EstimateOtherCostName = Convert.ToString(this.OtherCostName);
                            }
                            string value2 = this.hdn_allselectedqty.Value;
                            chrArray = new char[] { '~' };
                            string[] strArrays6 = value2.Split(chrArray);
                            string str13 = strArrays6[0];
                            string str14 = strArrays6[1];
                            string str15 = strArrays6[2];
                            string str16 = strArrays6[3];
                        }
                    }
                    EstimatesBasePage.Insert_EstPriceCatAddOptionDetails(this.EstimateAdditionalItemID, this.EstimateID, this.CalculationType, this.EstimateItemID, this.SelectedValue, this.MarkupPercentage1, this.MarkupPercentage2, this.MarkupPercentage3, this.MarkupPercentage4, this.CostPrice1, this.CostPrice2, this.CostPrice3, this.CostPrice4, this.SelectedID, this.MarkupValue1, this.MarkupValue2, this.MarkupValue3, this.MarkupValue4, this.SortOrderNo, this.SelectedPrice1, this.SelectedPrice2, this.SelectedPrice3, this.SelectedPrice4, this.EstimateOtherCostName, this.TotalPriceExMarkup1, this.TotalPriceExMarkup2, this.TotalPriceExMarkup3, this.TotalPriceExMarkup4, this.TotalPriceIncMarkup1, this.TotalPriceIncMarkup2, this.TotalPriceIncMarkup3, this.TotalPriceIncMarkup4, num7, this.OthercostID, this.ParentWebOtherCostID, this.WebOtherCostType);
                }
            }
            if (base.Request.Params["parentestitemid"] == null)
            {
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.EstimateItemID);
            }
            else
            {
                this.ParentEstimateItemID = Convert.ToInt64(base.Request.Params["parentestitemid"]);
                EstimatesBasePage.estimate_EstTotalPriceDetails_Update(this.ParentEstimateItemID);
            }
            if (base.Request.Params["type"].ToString() == "add" && (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0))
            {
                string empty7 = string.Empty;
                foreach (DataRow dataRow3 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty7 = dataRow3["StatusID"].ToString();
                }
                BaseClass baseClass = new BaseClass();
                string str17 = baseClass.Return_StockManagementSettings("SA_EprintMISJobs");
                string str18 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                string str19 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string str20 = baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                if (str17 == "e")
                {
                    foreach (DataRow row4 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                    {
                        if (row4["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            baseClass.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str18, "self", Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                        else if (row4["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            baseClass.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str18, Convert.ToBoolean(str19), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                        else if (row4["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (row4["DrawStockFrom"].ToString().ToLower() != "m")
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
                else if (str17 == "j" && baseClass.Return_StockManagementSettings("SA_JobStatusID") == empty7.ToString())
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
                if (str20 == "e")
                {
                    foreach (DataRow row5 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                    {
                        if (row5["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            baseClass.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                        }
                        else if (row5["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num, "other", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                        }
                        else if (row5["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (row5["DrawStockFrom"].ToString().ToLower() != "m")
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
                else if (str20 == "j")
                {
                    if (baseClass.Return_StockManagementSettings("SR_JobStatusID") == empty7.ToString())
                    {
                        foreach (DataRow dataRow5 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            base.Session["StockItemType"] = "C";
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
                }
                else if (str20 == "c" && string.Compare(this.modulename, "invoice", true) == 0)
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
            if (base.Request.Params["type"].ToString() == "edit" && (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0))
            {
                EstimateCommonMethods.ShowJobCardDetails(this.CompanyID, this.EstimateID, this.EstimateItemID, "C");
                string empty8 = string.Empty;
                foreach (DataRow dataRow6 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    empty8 = dataRow6["StatusID"].ToString();
                }
                BaseClass baseClass1 = new BaseClass();
                string str21 = baseClass1.Return_StockManagementSettings("SA_EprintMISJobs");
                string str22 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                string str23 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                string str24 = baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                string lower = string.Empty;
                string empty9 = string.Empty;
                if (this.StockCancellationType == "a" || this.StockCancellationType == "p" && this.hdn_stockBackwarehoue.Value == "yes")
                {
                    DataTable dataTable = this.ObjClass.ProductStockType_Select((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value));
                    foreach (DataRow row7 in dataTable.Rows)
                    {
                        if (row7["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                            if (empty9.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "self", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                        else if (row7["DrawStockFrom"].ToString().ToLower() == "o")
                        {
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), "other", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                            if (empty9.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str22, Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                        else if (row7["DrawStockFrom"].ToString().ToLower() != "a")
                        {
                            if (row7["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                            if (empty9.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "multiple", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                        else
                        {
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, Convert.ToInt64(this.hid_OldPriceCatalogueID.Value), (long)0, "additional option", this.EstimateItemID, "Job", (long)this.UserID, this.StockCancellationType);
                            if (empty9.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1 * num2, str22, "additional option", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                    }
                }
                else
                {
                    DataTable dataTable1 = new DataTable();
                    foreach (DataRow dataRow7 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                    {
                        lower = dataRow7["DrawStockFrom"].ToString().ToLower();
                        if (dataRow7["DrawStockFrom"].ToString().ToLower() == "s")
                        {
                            dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "self", this.EstimateItemID);
                        }
                        else if (dataRow7["DrawStockFrom"].ToString().ToLower() != "o")
                        {
                            if (dataRow7["DrawStockFrom"].ToString().ToLower() != "m")
                            {
                                continue;
                            }
                            dataTable1 = baseClass1.StockProductRerunDetails_Select(num, (long)0, (long)this.CompanyID, "multiple", this.EstimateItemID);
                        }
                        else
                        {
                            dataTable1 = baseClass1.StockProductRerunDetails_Select((long)0, num, (long)this.CompanyID, "others", this.EstimateItemID);
                        }
                    }
                    foreach (DataRow row8 in dataTable1.Rows)
                    {
                        if (Convert.ToInt32(row8["TotalOldQty"].ToString()) == num1 * num2)
                        {
                            continue;
                        }
                        if (str21 != "e")
                        {
                            if (!(str21 == "j") || !(baseClass1.Return_StockManagementSettings("SA_JobStatusID") == empty8.ToString()))
                            {
                                continue;
                            }
                            if (lower == "s")
                            {
                                empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty9.ToLower() != "success")
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
                                empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty9.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "multiple", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                            else
                            {
                                empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                                if (empty9.ToLower() != "success")
                                {
                                    continue;
                                }
                                baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str22, Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                            }
                        }
                        else if (lower == "s")
                        {
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty9.ToLower() != "success")
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
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, num, (long)0, "multiple", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty9.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass1.StockAllocationProcess((long)this.CompanyID, num, (long)0, num1 * num2, str22, "multiple", Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                        else
                        {
                            empty9 = this.ObjClass.StockCancellationProcess((long)this.CompanyID, (long)0, num, "self", this.EstimateItemID, "Job", (long)this.UserID, "a");
                            if (empty9.ToLower() != "success")
                            {
                                continue;
                            }
                            baseClass1.StockAllocation_Others((long)this.CompanyID, num, num1 * num2, str22, Convert.ToBoolean(str23), this.EstimateItemID, "Job", num3, (long)this.UserID);
                        }
                    }
                }
                if (empty9.ToLower() == "success")
                {
                    if (str24 == "e")
                    {
                        foreach (DataRow dataRow8 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                        {
                            if (dataRow8["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                baseClass1.StockReductionProcess((long)this.CompanyID, num, (long)0, "self", num1 * num2, this.EstimateItemID, "Job", (long)this.UserID, num3);
                            }
                            else if (dataRow8["DrawStockFrom"].ToString().ToLower() != "o")
                            {
                                if (dataRow8["DrawStockFrom"].ToString().ToLower() != "m")
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
                    else if (str24 == "j")
                    {
                        if (baseClass1.Return_StockManagementSettings("SR_JobStatusID") == empty8.ToString())
                        {
                            foreach (DataRow row9 in baseClass1.ProductStockType_Select((long)this.CompanyID, num).Rows)
                            {
                                base.Session["StockItemType"] = "C";
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
                    }
                    else if (str24 == "c" && string.Compare(this.modulename, "invoice", true) == 0)
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
            }
            if (this.ParentItemID == (long)0 && base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString() == "add")
                {
                    if (EstimatesBasePage.OtherCostSequence_GetCountBy_EstimatType(this.CompanyID, "C") > (long)0)
                    {
                        HttpResponse response = base.Response;
                        str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_Othercost.aspx?isFromOtherCostSeq=1&isFromOtherCostSeq=1&type=add&estid=", this.EstimateID, "&parentestitemid=", this.EstimateItemID, "&parentesttype=C&maintype=edit&subitem=s", this.jID, this.InvID };
                        response.Redirect(string.Concat(str));
                    }
                }
                else if (this.ParentItemID == (long)0)
                {
                    EstimateCommonMethods.PCR_FormulaTags_Replace(this.EstimateItemID, "C");
                }
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
                HttpResponse httpResponse = base.Response;
                str = new object[] { this.strSitepath, "Jobs/job_item_form.aspx?frm=add&estid=", this.EstimateID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(str));
                return;
            }
            if (this.tabtype == "invoice")
            {
                HttpResponse response1 = base.Response;
                str = new object[] { this.strSitepath, "invoice/invoice_item_form.aspx?frm=add&estid=", this.EstimateID, this.jID, this.InvID };
                response1.Redirect(string.Concat(str));
                return;
            }
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString() == "edit" || this.frmcopyitem == "yes")
            {
                if (this.modulename == "orders")
                {
                    if (this.ParentEstimateItemID == (long)0)
                    {
                        HttpResponse httpResponse1 = base.Response;
                        str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                        httpResponse1.Redirect(string.Concat(str));
                        return;
                    }
                    HttpResponse response2 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                    response2.Redirect(string.Concat(str));
                    return;
                }
                if (this.ParentEstimateItemID == (long)0)
                {
                    if (empty10.ToLower() == "yes")
                    {
                        HttpResponse httpResponse2 = base.Response;
                        str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                        httpResponse2.Redirect(string.Concat(str));
                        return;
                    }
                    HttpResponse response3 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                    response3.Redirect(string.Concat(str));
                    return;
                }
                if (empty10.ToLower() == "yes")
                {
                    HttpResponse httpResponse3 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse3.Redirect(string.Concat(str));
                    return;
                }
                HttpResponse response4 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                response4.Redirect(string.Concat(str));
                return;
            }
            if (this.modulename == "orders")
            {
                if (this.ParentEstimateItemID == (long)0)
                {
                    HttpResponse httpResponse4 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse4.Redirect(string.Concat(str));
                    return;
                }
                HttpResponse response5 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary.aspx?ordid=", this.EstimateID, "&estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                response5.Redirect(string.Concat(str));
                return;
            }
            if (this.ParentEstimateItemID == (long)0)
            {
                if (empty10.ToLower() == "yes")
                {
                    HttpResponse httpResponse5 = base.Response;
                    str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                    httpResponse5.Redirect(string.Concat(str));
                    return;
                }
                HttpResponse response6 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&estitemid=", this.EstimateItemID, "&esttype=C&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                response6.Redirect(string.Concat(str));
                return;
            }
            if (empty10.ToLower() == "yes")
            {
                HttpResponse httpResponse6 = base.Response;
                str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_order_summary.aspx?estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, this.jID, this.InvID };
                httpResponse6.Redirect(string.Concat(str));
                return;
            }
            HttpResponse response7 = base.Response;
            str = new object[] { this.strSitepath, this.modulename, "/", this.submodulename, "_summary_reeng.aspx?estid=", this.EstimateID, "&estitemid=", this.ParentEstimateItemID, "&esttype=", this.ParentEstimateType, "&parent=y&maintype=", this.MainType, this.jID, this.InvID };
            response7.Redirect(string.Concat(str));
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridPriceCatalogue.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void OnItemCommand_GridPriceCatalogue(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                this.WhereConditionEstimateProdouct = "";
                if (base.Session["searchProdouct"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session["searchProdouct"] != null)
                {
                    dataTable = (DataTable)base.Session["searchProdouct"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                base.Session["searchProdouct"] = dataTable;
                this.WhereConditionEstimateProdouct = this.FilterFunction(dataTable);
                this.GridPriceCatalogue.Rebind();
            }
        }

        protected void OnItemDataBound_GridPriceCatalogue(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridPriceCatalogue.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridPriceCatalogue.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                ((GridDataItem)e.Item).Style.Add("cursor", "pointer");
            }
        }

        protected void OnSorting_GridPriceCatalogue(object sender, GridViewSortEventArgs e)
        {
            string str = (e.SortDirection.ToString() == "Ascending" ? "ASC" : "DESC");
            string str1 = e.SortExpression.ToString();
            string[] strArrays = this.hid_query_details.Value.Split(new char[] { '±' });
            try
            {
                if (string.Compare(str1, strArrays[5], true) == 0)
                {
                    if (string.Compare(strArrays[6], "ASC", true) == 0)
                    {
                        str = "DESC";
                    }
                    else if (string.Compare(str, "DESC", true) == 0)
                    {
                        str = "ASC";
                    }
                }
                this.Common_PriceCatalogue_Call(strArrays[0], Convert.ToInt32(strArrays[1]), strArrays[2], strArrays[3], strArrays[4], "sort", str1, str, this.PageSize, 1);
            }
            catch
            {
                str = "ASC";
            }
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            int resultId = 0;
            string connectionString = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            string query = "SELECT ViewID FROM tb_CustomizeView WHERE CompanyID = @CompanyID AND PageName = @PageName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", Convert.ToInt16(this.Session["CompanyID"]));
                    command.Parameters.AddWithValue("@PageName", "ProductSelectView");

                    connection.Open();
                    object result = command.ExecuteScalar();
                    resultId = Convert.ToInt32(result);
                }
            }
            HttpResponse response = base.Response;
            object[] value = new object[] { "../estimates/customviewproduct.aspx?type=edit&id=", resultId, "&cid=", Convert.ToInt16(this.Session["CompanyID"]) };
            response.Redirect(string.Concat(value));
        }

        private string GetColumnNamesFromDatabase()
        {
            // Placeholder for actual database retrieval logic
            string columnNames = string.Empty;

            string connectionString = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            string query = "SELECT ColumnNames FROM tb_CustomizeView WHERE CompanyID = @CompanyID AND PageName = @PageName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyID", Convert.ToInt16(this.Session["CompanyID"]));
                    command.Parameters.AddWithValue("@PageName", "ProductSelectView");

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        columnNames = result.ToString();
                    }
                }
            }

            return columnNames;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (base.Request.QueryString["pageType"] == "job")
            //{
            //    this.divNewAdd.Visible = true;
            //}
            //else
            //{
            //    this.divNewAdd.Visible = false;
            //}

            this.ddlCategoryBind.Items[1].Text = this.objLanguage.GetLanguageConversion("All_Items");
            this.ddlCategoryBind.Items[2].Text = this.objLanguage.GetLanguageConversion("Unallocated_Items");
            this.GridPriceCatalogue.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.Alert_Msg = this.objLanguage.GetLanguageConversion("Please_Select_At_Least_One_Catalogue_Item");
            if (!base.IsPostBack)
            {
                this.btnPricePrevious.Text = this.objLanguage.GetLanguageConversion("Previous");
                this.Button15.Text = this.objLanguage.GetLanguageConversion("Finish");
                this.btnBack.Text = this.objLanguage.GetLanguageConversion("Back");
                string columnNames = GetColumnNamesFromDatabase();

                // Split column names into an array
                string[] columnsToShow = columnNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Loop through each column in the grid
                foreach (GridColumn column in this.GridPriceCatalogue.MasterTableView.Columns)
                {
                    // Set column visibility based on the fetched column names
                    if (columnsToShow.Contains(column.UniqueName))
                    {
                        column.Visible = true;
                    }
                    else
                    {
                        column.Visible = false;
                    }
                }
            }
            this.gloobj.setpagename("estimate");
            if (base.Request.QueryString["type"] != null)
            {
                this.QueryType = base.Request.QueryString["type"].ToString();
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
            if (base.Request.QueryString["InvID"] != null && base.Request.QueryString["InvID"] != "0")
            {
                base.Session["InvoiceIdIfSaveAndAddAnother"] = base.Request.Params["InvID"];
            }

                if (this.InvoiceID == (long)0 && base.Session["InvoiceIdIfSaveAndAddAnother"]!=null && base.Request.QueryString["fromPageType"] == "invoice")
            {
                this.InvoiceID = Convert.ToInt64(base.Session["InvoiceIdIfSaveAndAddAnother"]);
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.QueryString["maintype"] != null)
            {
                this.MainType = base.Request.QueryString["maintype"].ToString();
            }
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                this.FromAddAnItem = base.Request.QueryString["FromAddAnItem"].ToString();
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
            this.defaultvalue = Convert.ToDecimal(this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.defaultvalue), 0, "", false, false, true));
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            global.pgName = string.Empty;
            if (ConnectionClass.WebStore != null)
            {
                this.Webstore = ConnectionClass.WebStore.ToString();
            }
            this.Check_SpecialPrivilege = false;
            this.Check_SpecialPrivilege = this.Objclss.Check_SpecialPrivilege_For_User((long)this.UserID, (long)this.CompanyID);
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                this.tabtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice_add.aspx"))
            {
                this.tabtype = "estimate";
            }
            else
            {
                this.tabtype = "invoice";
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.modulename = "jobs";
                this.submodulename = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.modulename = "invoice";
                this.submodulename = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.modulename = "estimates";
                this.submodulename = "estimate";
            }
            else
            {
                this.modulename = "orders";
                this.submodulename = "order";
            }
            if (ConnectionClass.IsHandy)
            {
                this.SimpleMatBrowserHandy = "yes";
            }
            DataSet dataSet = new DataSet();
            DataTable dataTable = SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID);
            if (string.Compare(this.QueryType, "edit", true) == 0)
            {
                if (!base.IsPostBack)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["UpdateItemDescription"].ToString().ToLower() != "true")
                        {
                            this.Chk_ItemDescn.Checked = false;
                        }
                        else
                        {
                            this.Chk_ItemDescn.Checked = true;
                        }
                    }
                }
                if (base.Request.QueryString["esttype"] != null)
                {
                    this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                }
            }
            this.TakeItemDesc();
            if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                foreach (DataRow dataRow in EstimateBasePage.Estimate_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    this.Pub_CustomerID = dataRow["CustomerID"].ToString();
                    this.Pub_CustomerName = dataRow["ClientName"].ToString();
                    this.hid_Price_CustomerID.Value = this.Pub_CustomerID;
                    this.hid_Customer_Name.Value = this.Pub_CustomerName;
                    this.IsDirectJob = Convert.ToInt32(dataRow["IsDirectJob"]);
                    this.IsForInvoice = Convert.ToInt32(dataRow["IsForInvoice"]);
                }
            }
            else
            {
                foreach (DataRow row1 in InvoiceBasePage.InvoiceDetails_ByInvoiceID_Select(this.InvoiceID).Rows)
                {
                    this.Pub_CustomerID = row1["CustomerID"].ToString();
                    this.Pub_CustomerName = row1["ClientName"].ToString();
                    this.hid_Price_CustomerID.Value = this.Pub_CustomerID;
                    this.hid_Customer_Name.Value = this.Pub_CustomerName;
                    this.IsForInvoice = 1;
                }
            }
            if (base.Request.QueryString["esttype"] != null)
            {
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
                this.Select_Catalogue_Item();
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.pnlCatalogue.Style.Add("display", "none");
            try
            {
                if (base.Request.QueryString["subedit"] != null)
                {
                    this.subedit = "C";
                    this.Div_ItemDescn.Visible = false;
                }
                if (base.Request.QueryString["frm"] != null || base.Request.QueryString["frm"] == "yes")
                {
                    this.btnPricePrevious.Visible = false;
                }
            }
            catch
            {
                this.subedit = "0";
            }
            this.ddlCategoryBind.Items[0].Text = this.objBase.SpecialDecode(this.hid_Customer_Name.Value);
            string value = this.hid_Price_CustomerID.Value;
            value = (this.Pub_CustomerID == "" ? "0" : this.Pub_CustomerID);
            string str = this.txtPriceCatalogueSerach.Value.ToString();
            string str1 = (this.ddlCategoryBind.SelectedValue == "0" ? "" : this.ddlCategoryBind.SelectedValue);
            DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            estimate_price_catalogueNew.ManageStockPermission = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
            if (estimate_price_catalogueNew.ManageStockPermission == 1)
            {
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (dataRow1["Productcatlg_ItemDisplay"].ToString().Trim().ToLower() == "s")
                    {
                        this.Common_PriceCatalogue_Call("C", Convert.ToInt32(value), str1, str, "", "search", "CatalogueName", "asc", this.PageSize, 1);
                        HiddenField hdnParam = this.hdn_param;
                        object[] num = new object[] { "C±", Convert.ToInt32(value), "±", str1, "±", str, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                        hdnParam.Value = string.Concat(num);
                        this.ddlCategoryBind.SelectedValue = "0";
                    }
                    if (dataRow1["Productcatlg_ItemDisplay"].ToString().Trim().ToLower() == "a")
                    {
                        HiddenField hiddenField = this.hdn_param;
                        object[] pageSize = new object[] { "A±", 0, "± ±", str, "±", str, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                        hiddenField.Value = string.Concat(pageSize);
                        this.Common_PriceCatalogue_Call("A", 0, "", str, str, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                        this.ddlCategoryBind.SelectedValue = "1";
                    }

                    if (base.Request.QueryString["fromPageType"] != null)
                    {
                        if (base.Request.QueryString["fromPageType"].ToString() == "job" && base.Request.QueryString["ddlValue"] != null)
                        {
                            //this.ddlCategoryBind.SelectedValue = base.Request.QueryString["ddlValue"].ToString();
                            if (base.Request.QueryString["ddlValue"].ToString() == "0")
                            {
                                this.Common_PriceCatalogue_Call("C", Convert.ToInt32(value), str1, str, "", "search", "CatalogueName", "asc", this.PageSize, 1);
                                HiddenField hdnParam = this.hdn_param;
                                object[] num = new object[] { "C±", Convert.ToInt32(value), "±", str1, "±", str, "±±search±CatalogueName±asc±", this.PageSize, "±", 1 };
                                hdnParam.Value = string.Concat(num);
                                this.ddlCategoryBind.SelectedValue = "0";
                            }
                            if (base.Request.QueryString["ddlValue"].ToString() == "1")
                            {
                                HiddenField hiddenField = this.hdn_param;
                                object[] pageSize = new object[] { "A±", 0, "± ±", str, "±", str, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                                hiddenField.Value = string.Concat(pageSize);
                                this.Common_PriceCatalogue_Call("A", 0, "", str, str, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                                this.ddlCategoryBind.SelectedValue = "1";
                            }
                            if (base.Request.QueryString["ddlValue"].ToString() == "2")
                            {
                                HiddenField hdnParam1_ = this.hdn_param;
                                object[] objArray_ = new object[] { "U±", 0, "± ±", str, "±", str, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                                hdnParam1_.Value = string.Concat(objArray_);
                                this.Common_PriceCatalogue_Call("U", 0, "", str, str, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                                this.ddlCategoryBind.SelectedValue = "2";
                            }
                        }
                    }

                    if (dataRow1["Productcatlg_ItemDisplay"].ToString().Trim().ToLower() != "u")
                    {
                        continue;
                    }
                    HiddenField hdnParam1 = this.hdn_param;
                    object[] objArray = new object[] { "U±", 0, "± ±", str, "±", str, "±unallocated±CatalogueName±asc±", this.PageSize, "±", 1 };
                    hdnParam1.Value = string.Concat(objArray);
                    this.Common_PriceCatalogue_Call("U", 0, "", str, str, "unallocated", "CatalogueName", "asc", this.PageSize, 1);
                    this.ddlCategoryBind.SelectedValue = "2";
                }
            }
            if (base.Request.QueryString["frm"] != null)
            {
                this.frm = base.Request.QueryString["frm"].ToString();
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
            DataTable dataTable2 = new DataTable();
            if (this.EstimateItemID != (long)0)
            {
                dataTable2 = EstimatesBasePage.OrderItemID_Select(this.OrderID, this.EstimateItemID);
            }
            IEnumerator enumerator = dataTable2.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.OrderItemID = Convert.ToInt64(current["OrderItemID"]);
                    if (!base.IsPostBack)
                    {
                        this.hid_PriceCatalogueID.Value = current["ProductID"].ToString();
                        this.hid_PriceCataloguename.Value = current["ItemTitle"].ToString();
                    }
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
            if (!base.IsPostBack)
            {
                this.Product_catalogueDetails_Edit();
                base.Session["searchProdouct"] = null;
            }
            if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0)
            {
                foreach (DataRow row2 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, this.EstimateID).Rows)
                {
                    this.hdnJobStatusID.Value = row2["StatusID"].ToString();
                }
            }
            if (base.Session["ProductStockManagement"] != null)
            {
                this.hdn_StockManagement.Value = base.Session["ProductStockManagement"].ToString();
            }
            this.Measurementvalue = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (base.Session["searchProdouct"] != null)
            {
                DataTable item = new DataTable();
                this.GridPriceCatalogue.MasterTableView.FilterExpression = "";
                try
                {
                    item = (DataTable)base.Session["searchProdouct"];
                    foreach (DataRow dataRow2 in item.Rows)
                    {
                        GridColumn columnSafe = this.GridPriceCatalogue.MasterTableView.GetColumnSafe(dataRow2["ColumnName"].ToString());
                        columnSafe.CurrentFilterValue = dataRow2["FilterText"].ToString();
                    }
                    this.WhereConditionEstimateProdouct = this.FilterFunction(item);
                }
                catch
                {
                }
            }
            this.GridPriceCatalogue.Rebind();
        }

        public void Price_Area(int CompanyID, PlaceHolder plh, string QueryType, string AdditionItem, decimal OrderItemTotalPrice, decimal OrderItemTax, decimal TaxRate, long TaxID, string TaxName)
        {
            decimal orderItemTotalPrice = OrderItemTotalPrice + OrderItemTax;
            this.plhquantity.Controls.Add(new LiteralControl("<tr >"));
            this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold; '><b>", this.objLanguage.GetLanguageConversion("Total"), " </b></div>")));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
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
            object[] otherCostName;
            long num = Convert.ToInt64(this.hidCatalogueID.Value);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            long num4 = (long)0;
            string empty = string.Empty;
            foreach (DataRow row in EstimatesBasePage.productsDetails_Select(num).Rows)
            {
                this.ProductName = row["ItemTitle"].ToString();
                this.hid_matixType.Value = row["MatrixType"].ToString();
            }
            DataSet dataSet = EstimatesBasePage.settings_Product_CatalogueAdditional_Select(this.CompanyID, num);
            DataTable item = dataSet.Tables[0];
            foreach (DataRow dataRow in item.Rows)
            {
                this.WebOtherCostID = Convert.ToInt64(dataRow["WebOtherCostID"].ToString());
            }
            this.OrderAddItemsCount = item.Rows.Count;
            foreach (DataRow row1 in EstimatesBasePage.Product_CatalogueQty_Select(num).Rows)
            {
                this.hid_qtyFromList.Value = string.Concat(this.hid_qtyFromList.Value, row1["FromQuantity"].ToString(), "µ");
                this.hid_qtyToList.Value = string.Concat(this.hid_qtyToList.Value, row1["ToQuantity"].ToString(), "µ");
                this.hid_CostExcMarkupList.Value = string.Concat(this.hid_CostExcMarkupList.Value, row1["Price"].ToString(), "µ");
                this.hid_priceList.Value = string.Concat(this.hid_priceList.Value, row1["sellingPrice"].ToString(), "µ");
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
            if (this.hid_matixType.Value != "P")
            {
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
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
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                this.plhquantity.Controls.Add(new LiteralControl("<tr >"));
                this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Price"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
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
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            }
            else
            {
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>", this.objLanguage.GetLanguageConversion("Quantity"), "</div>")));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
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
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
                this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 250px; clear: both; font-style:bold;'>Price</div>"));
                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
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
                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            }
            this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td id='tdlblPCAOTotal' style='width: 20%'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<div id='spn_qty' style='float:left;margin:0px 0px 0px 35px;color:red;display:none;'><span id='spnQty'>&nbsp; Please enter Quantity</span></div>"));
            this.plhquantity.Controls.Add(new LiteralControl(string.Concat("<div style='width: 250px; clear: both; font-style:bold; padding:5px 0px 10px 0px;'><b>", this.objLanguage.GetLanguageConversion("Additional_Options"), "</b></div>")));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            this.plhquantity.Controls.Add(new LiteralControl("<td colspan='5' id='tdPriceCatAddOptCostTotal1' style='text-align: right;'>"));
            this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtytxt1' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
            this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow dataRow1 in EstimatesBasePage.Select_OtherCostAdditional_ItemsIDs(num).Rows)
            {
                int num9 = 0;
                int num10 = 0;
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                decimal num14 = new decimal(0);
                string str1 = string.Empty;
                DataSet dataSet1 = EstimatesBasePage.Select_OtherCostAdditional_ItemsDetail(Convert.ToInt64(dataRow1["WebOtherCostID"].ToString()));
                DataTable dataTable = dataSet1.Tables[0];
                DataTable item1 = dataSet1.Tables[1];
                Convert.ToInt64(dataRow1["WebOtherCostID"].ToString());
                long num15 = Convert.ToInt64(dataRow1["AdditionalGroupID"].ToString());
                num8++;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                foreach (DataRow row2 in dataTable.Rows)
                {
                    this.MainCalculationtype = row2["MainCalculationType"].ToString();
                    if (this.MainCalculationtype.ToLower() == "c")
                    {
                        int num16 = Convert.ToInt32(row2["IsCartmandatory"]);
                        str2 = num16.ToString();
                    }
                    row2["Description"].ToString().Replace("\n", "<br>");
                    this.OtherCostName = row2["UserFriendlyName"].ToString();
                    try
                    {
                        this.OtherCostName = this.OtherCostName.Trim().Substring(0, 70);
                    }
                    catch
                    {
                    }
                }
                int num17 = 0;
                if (num15 == (long)0)
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
                            empty2 = (num15 == (long)0 || Convert.ToInt64(strArrays[i]) != num15 ? "1" : "0");
                        }
                    }
                }
                str = string.Concat(str, dataRow1["AdditionalGroupID"].ToString(), "±");
                foreach (DataRow dataRow2 in item1.Rows)
                {
                    if (this.MainCalculationtype.ToLower() == "q")
                    {
                        string str3 = dataRow2["formula"].ToString();
                        string str4 = dataRow2["Question"].ToString();
                        this.plhquantity.Controls.Add(new LiteralControl("<tr>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 96.2%'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px;'>"));
                        ControlCollection controls = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblQuestion_", num5, "' > ", this.OtherCostName, "<br/>", str4, "<br/></label>" };
                        controls.Add(new LiteralControl(string.Concat(otherCostName)));
                        if (num9 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            ControlCollection controlCollections = this.plhquantity.Controls;
                            object[] objArray = new object[] { "<input id='txtQuestion_", num5, "' grpvalue='", empty2, "'  onkeyup='Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' style='margin-top:4px;' />" };
                            controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                        }
                        else
                        {
                            ControlCollection controls1 = this.plhquantity.Controls;
                            object[] objArray1 = new object[] { "<input value='", str1, "' id='txtQuestion_", num5, "' grpvalue='", empty2, "'  onkeyup='Tocall_mainFunc();' class='txtStyle' type='text' maxlength='7' />" };
                            controls1.Add(new LiteralControl(string.Concat(objArray1)));
                        }
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controlCollections1 = this.plhquantity.Controls;
                        object[] currencyinRequiredFormate = new object[] { "<br/><label id='lblPrice1_", num5, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), " </label><label id='lblQuestionID_", num5, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula_", num5, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num5, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num5, "' style='display:none'>", num11, "</label><label id='lblQuestionSortOrderNo_", num5, "' style='display:none'>", num8, "</label>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(currencyinRequiredFormate)));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controls2 = this.plhquantity.Controls;
                        object[] currencyinRequiredFormate1 = new object[] { "<br/><label id='lblPrice2_", num5, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), " </label><label id='lblQuestionID_", num5, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula2_", num5, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num5, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num5, "' style='display:none'>", num11, "</label><label id='lblQuestionSortOrderNo_", num5, "' style='display:none'>", num8, "</label>" };
                        controls2.Add(new LiteralControl(string.Concat(currencyinRequiredFormate1)));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controlCollections2 = this.plhquantity.Controls;
                        object[] currencyinRequiredFormate2 = new object[] { "<br/><label id='lblPrice3_", num5, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), " </label><label id='lblQuestionID_", num5, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula3_", num5, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num5, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num5, "' style='display:none'>", num11, "</label><label id='lblQuestionSortOrderNo_", num5, "' style='display:none'>", num8, "</label>" };
                        controlCollections2.Add(new LiteralControl(string.Concat(currencyinRequiredFormate2)));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controls3 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<br/><label id='lblPrice4_", num5, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), " </label><label id='lblQuestionID_", num5, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblQuestionFormula4_", num5, "'  style='display:none;'>", str3, " </label><label id='lblQuestionGroupID_", num5, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblQuestionMarkupValue_", num5, "' style='display:none'>", num11, "</label><label id='lblQuestionSortOrderNo_", num5, "' style='display:none'>", num8, "</label>" };
                        controls3.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 40%;'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<br/><label id='lblPrice1_dup' Width='200px'>&nbsp&nbsp&nbsp&nbsp&nbsp</label>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        num5++;
                    }
                    else if (this.MainCalculationtype.ToLower() == "c")
                    {
                        if (num17 == 0)
                        {
                            this.plhquantity.Controls.Add(new LiteralControl("<tr id='trPriceCatalogAddOptionsHeader'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                            this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 96.2%'>"));
                            if (num9 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                ControlCollection controlCollections3 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<input id='chkMultiple_", num6, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num6, ");'/>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            else
                            {
                                ControlCollection controls4 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<input id='chkMultiple_", num6, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num6, ");'/>" };
                                controls4.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            this.plhquantity.Controls.Add(new LiteralControl("<div style='float:left;padding:2px 5px 0px 24px;'>"));
                            if (str2 != "1")
                            {
                                ControlCollection controlCollections4 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<label id='lblMatrixName_", num6, "'> ", this.OtherCostName, "</label>" };
                                controlCollections4.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            else
                            {
                                ControlCollection controls5 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<label id='lblMatrixName_", num6, "'> ", this.OtherCostName, "</label><span style='color:Red;'> *</span>" };
                                controls5.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            this.plhquantity.Controls.Add(new LiteralControl("<div style='margin:5px 0px 0px 0px;'>"));
                            DropDownList dropDownList = new DropDownList()
                            {
                                ID = string.Concat("ddlMultiple_", num6),
                                CssClass = "dropDownMultiple150",
                                Width = 220
                            };
                            dropDownList.Attributes.Add("onmouseout", "javascript:Tocall_mainFunc();");
                            dropDownList.Attributes.Add("onchange", "javascript:Tocall_mainFunc();");
                            dropDownList.Attributes.Add("IsMandatory", str2);
                            dropDownList.Attributes.Add("grpvalue", empty2);
                            if (num9 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                ControlCollection controlCollections5 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<input id='chkMultiple_", num6, "' style='display:none' type='checkbox' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num6, ");'/>" };
                                controlCollections5.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            else
                            {
                                ControlCollection controls6 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<input id='chkMultiple_", num6, "' style='display:none' type='checkbox' checked='checked' title='", this.OtherCostName, "' onclick='javascript:Onchange_MultipleChoice(", num6, ");'/>" };
                                controls6.Add(new LiteralControl(string.Concat(otherCostName)));
                            }
                            this.MultipleChoice_DropDownBind(item1, dropDownList, this.plhquantity, dataRow2["CalculationType"].ToString(), "edit", num10);
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                            this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                            if (num9 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controlCollections6 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label id='lblMultiplePrice1_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controlCollections6.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controls7 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label id='lblMultiplePrice2_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controls7.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controlCollections7 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label id='lblMultiplePrice3_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controlCollections7.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controls8 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label id='lblMultiplePrice4_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("0.00", true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controls8.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                            }
                            else
                            {
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controlCollections8 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice1_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controlCollections8.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controls9 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice2_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controls9.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controlCollections9 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice3_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controlCollections9.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                                ControlCollection controls10 = this.plhquantity.Controls;
                                otherCostName = new object[] { "<br/><label id='lblMultipleID_", num6, "' style='display:none'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMultipleType_", num6, "' style='display:none'></label><label id='lblMultipleMarkup_", num6, "' style='display:none'></label><label Width='200px' id='lblMultiplePrice4_", num6, "'>", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label><label id='lblMultipleGroupID_", num6, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMultipleMarkupValue_", num6, "' style='display:none'>", num11, "</label><label id='lblMultipleSortOrderNo_", num6, "' style='display:none;'>", num8, "</label>" };
                                controls10.Add(new LiteralControl(string.Concat(otherCostName)));
                                this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<td id='tdPriceCatAddOptCostTotal1' style='text-align: right; width: 40%;'>"));
                                this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labelqtydup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                                this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                                this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                            }
                            num6++;
                        }
                    }
                    else if (this.MainCalculationtype.ToLower() == "m" && num17 == 0)
                    {
                        dataRow2["matrixType"].ToString();
                        this.plhquantity.Controls.Add(new LiteralControl("<tr >"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='width: 20%'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<div class='bglabel' style='width: 96.2%'>"));
                        string empty3 = string.Empty;
                        if (num9 != Convert.ToInt32(dataRow1["WebOtherCostID"].ToString()))
                        {
                            ControlCollection controlCollections10 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num7, "' style='display:block' type='checkbox' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='Tocall_mainFunc();'/></div>" };
                            controlCollections10.Add(new LiteralControl(string.Concat(otherCostName)));
                        }
                        else
                        {
                            otherCostName = new object[] { num13, "~", num14, "~", num10, "~", this.MainItemQuantity };
                            empty3 = string.Concat(otherCostName);
                            ControlCollection controls11 = this.plhquantity.Controls;
                            otherCostName = new object[] { "<div style='float:left;padding:2px 5px 0px 0px;'><input id='chkMatrix_", num7, "' style='display:block' type='checkbox' checked='checked' title='", this.OtherCostName, "' grpvalue=", empty2, " onclick='Tocall_mainFunc();'/></div>" };
                            controls11.Add(new LiteralControl(string.Concat(otherCostName)));
                        }
                        ControlCollection controlCollections11 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<div style='padding-top:3px;'><label id='lblMatrixName_", num7, "' > ", this.OtherCostName, "</label></div>" };
                        controlCollections11.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl("</div>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controls12 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixID_", num7, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num7, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup1_", num7, "' style='display:none;'>", empty3, "</label><label id='lblMatrixGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num7, "' style='display:none'>", num11, "</label><label id='lblMatrixSortOrderNo_", num7, "' style='display:none;'>", num8, "</label>" };
                        controls12.Add(new LiteralControl(string.Concat(otherCostName)));
                        ControlCollection controlCollections12 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixPrice1_", num7, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label>" };
                        controlCollections12.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controls13 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixID2_", num7, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num7, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup2_", num7, "' style='display:none;'>", empty3, "</label><label id='lblMatrixGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num7, "' style='display:none'>", num11, "</label><label id='lblMatrixSortOrderNo_", num7, "' style='display:none;'>", num8, "</label>" };
                        controls13.Add(new LiteralControl(string.Concat(otherCostName)));
                        ControlCollection controlCollections13 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixPrice2_", num7, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label>" };
                        controlCollections13.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controls14 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixID3_", num7, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num7, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup3_", num7, "' style='display:none;'>", empty3, "</label><label id='lblMatrixGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num7, "' style='display:none'>", num11, "</label><label id='lblMatrixSortOrderNo_", num7, "' style='display:none;'>", num8, "</label>" };
                        controls14.Add(new LiteralControl(string.Concat(otherCostName)));
                        ControlCollection controlCollections14 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixPrice3_", num7, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label>" };
                        controlCollections14.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<td style='text-align: right; width: 10%;'>"));
                        ControlCollection controls15 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixID4_", num7, "' style='display:none;'>", dataRow1["WebOtherCostID"].ToString(), "</label><label id='lblMatrixType_", num7, "' style='display:none;'>", dataRow2["matrixType"].ToString(), "</label><label id='lblMatrixCostMarkup4_", num7, "' style='display:none;'>", empty3, "</label><label id='lblMatrixGroupID_", num7, "' style='display:none'>", dataRow1["AdditionalGroupID"].ToString(), "</label><label id='lblMatrixMarkupValue_", num7, "' style='display:none'>", num11, "</label><label id='lblMatrixSortOrderNo_", num7, "' style='display:none;'>", num8, "</label>" };
                        controls15.Add(new LiteralControl(string.Concat(otherCostName)));
                        ControlCollection controlCollections15 = this.plhquantity.Controls;
                        otherCostName = new object[] { "<label id='lblMatrixPrice4_", num7, "' >", this.commclass.GetCurrencyinRequiredFormate("", true), this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num12, 0, "", false, false, true), "</label>" };
                        controlCollections15.Add(new LiteralControl(string.Concat(otherCostName)));
                        this.plhquantity.Controls.Add(new LiteralControl("</td>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" <td id='tddup' style='text-align: right; width: 40%;'>"));
                        this.plhquantity.Controls.Add(new LiteralControl("<span ID='Labeldup' runat='server' CssClass='normalText' >&nbsp&nbsp&nbsp&nbsp&nbsp</span>"));
                        this.plhquantity.Controls.Add(new LiteralControl(" </td>"));
                        this.plhquantity.Controls.Add(new LiteralControl("</tr>"));
                        if (dataRow2["matrixType"].ToString().ToLower() != "pricebands")
                        {
                            DropDownList dropDownList1 = new DropDownList();
                            this.MultipleChoice_DropDownBind(item1, dropDownList1, this.plhquantity, "matrix", "edit", num10);
                            dropDownList1.ID = string.Concat("ddlMatrix_", num7);
                            dropDownList1.CssClass = "dropDownMultiple150";
                            dropDownList1.Width = 300;
                            dropDownList1.Style.Add("display", "none");
                        }
                        num7++;
                    }
                    num17++;
                }
            }
            this.hid_QuestionLenght.Value = num5.ToString();
            this.hid_MultipleLenght.Value = num6.ToString();
            this.hid_MatrixLenght.Value = num7.ToString();
            if (num5 == 0 && num6 == 0 && num7 == 0)
            {
                this.Price_Area(this.CompanyID, this.plhquantity, "edit", "no", num1, num2, num3, num4, empty);
                return;
            }
            this.Price_Area(this.CompanyID, this.plhquantity, "edit", "yes", num1, num2, num3, num4, empty);
        }

        private void Select_Catalogue_Item()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            long num = (long)0;
            this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"]);
            int num1 = 0;
            foreach (DataRow row in EstimateBasePage.price_catalogue_select_by_estimateitem_id(this.CompanyID, this.EstimateItemID).Rows)
            {
                num = Convert.ToInt64(row["PriceCatalogueID"]);
                row["ItemDescription"].ToString();
                stringBuilder.AppendFormat("PriceCatalogueID»{0}±", row["PriceCatalogueID"].ToString());
                stringBuilder.AppendFormat("CatalogueName»{0}±", row["ItemTitle"].ToString());
                stringBuilder.AppendFormat("Quantity»{0}±", row["Quantity"].ToString());
                double num2 = Convert.ToDouble(row["Price"]) + Convert.ToDouble(row["Markup"]) * Convert.ToDouble(row["Price"]) / 100;
                stringBuilder.AppendFormat("Price»{0}±", num2);
                stringBuilder.AppendFormat("Markup»{0}±", row["Markup"].ToString());
                stringBuilder.AppendFormat("Cost»{0}±", row["Price"].ToString());
                stringBuilder.AppendFormat("MultipleOf»{0}µ", row["MultipleOf"].ToString());
                if (string.Compare(this.modulename, "invoice", true) == 0 || string.Compare(this.modulename, "jobs", true) == 0 || string.Compare(this.modulename, "orders", true) == 0)
                {
                    if (num1 == 0)
                    {
                        this.CatalogueProfit = row["ProfitMargin"].ToString();
                        this.CatalogueTax = row["Tax"].ToString();
                        str = row["TaxID"].ToString();
                    }
                    string[] strArrays = new string[] { ",", this.CatalogueProfit.ToString(), ",", row["SubTotal"].ToString(), ",", this.CatalogueTax.ToString(), ",", str.ToString() };
                    this.CatalogueProfitAndTax = string.Concat(strArrays);
                }
                else
                {
                    string[] str1 = new string[] { ",", row["ProfitMargin"].ToString(), ",", row["SubTotal"].ToString(), ",", row["Tax"].ToString(), ",", row["TaxID"].ToString() };
                    this.CatalogueProfitAndTax = string.Concat(str1);
                    this.CatalogueProfit = row["ProfitMargin"].ToString();
                    decimal num3 = EstimateBasePage.Estimate_Summary_TaxRate(this.CompanyID);
                    this.CatalogueTax = num3.ToString();
                }
                num1++;
            }
            DataTable dataTable = EstimateBasePage.price_catalogue_select_by_id(this.CompanyID, num, 'z');
            IEnumerator enumerator = dataTable.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    if (!Convert.ToBoolean(((DataRow)enumerator.Current)["IsSides"]))
                    {
                        this.hid_IsSides.Value = "0";
                    }
                    else
                    {
                        this.hid_IsSides.Value = "1";
                    }
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
            this.hidCatalogueDataOnEdit.Value = stringBuilder.ToString();
            this.pnlCatalogueOnEdit.Visible = true;
        }

        public void SimpleMatrix_DropDownBind(DataTable dtMul, DropDownList ddlMatrix, PlaceHolder plhquantity, string ActionType, int MainItemQuantity)
        {
            ddlMatrix.DataSource = dtMul;
            ddlMatrix.DataTextField = "ToQuantity";
            ddlMatrix.DataValueField = "NewPrice";
            ddlMatrix.DataBind();
            plhquantity.Controls.Add(ddlMatrix);
            if (ActionType == "edit")
            {
                int num = 0;
                foreach (DataRow row in dtMul.Rows)
                {
                    if (Convert.ToInt32(row["ToQuantity"]) == MainItemQuantity)
                    {
                        ddlMatrix.SelectedIndex = num;
                    }
                    num++;
                }
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
                        this.txt_lblInstructions.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim());
                    }
                    else if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "false")
                    {
                        this.txt_lblInstructions.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim());
                    }
                }
                try
                {
                    this.lblCustomDiscription1.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[12]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription2.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[13]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription3.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[14]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription4.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[15]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription5.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[16]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription6.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[17]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription7.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[18]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription8.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[19]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription9.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[20]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription10.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[21]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription11.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[22]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription12.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[23]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription13.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[24]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription14.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[25]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription15.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[26]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription16.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[27]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription17.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[28]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription18.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[29]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription19.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[30]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription20.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[31]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription21.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[32]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription22.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[33]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription23.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[34]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription24.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[35]["ScreenName"].ToString().Trim());
                    this.lblCustomDiscription25.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[36]["ScreenName"].ToString().Trim());
                }
                catch
                {
                }
            }
        }
    }
}
