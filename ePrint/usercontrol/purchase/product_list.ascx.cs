using System;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace ePrint.usercontrol.purchase
{
    public partial class product_list : System.Web.UI.UserControl
    {

        public string ItemType = string.Empty;

        public string inkid = string.Empty;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public languageClass objLangClass = new languageClass();

        private InventoryBasePage objInv = new InventoryBasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        private DataTable dtsearch = new DataTable();

        public string cs = string.Empty;

        public int totalrec;

        public int CompanyID;

        public int UserID;

        public int PageSize = 50;

        public int ClientID;

        public string type = string.Empty;

        public string invtype = string.Empty;

        public string Filtervalue = string.Empty;

        public string WhereConditionValues = string.Empty;

        public string SortBy = string.Empty;

        public string SortDirection = string.Empty;

        public string FilterCondition = "";

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string IsCumulative = string.Empty;

        public string desv = string.Empty;

        public string desvArtwork = string.Empty;

        public string desvColour = string.Empty;

        public string desvSize = string.Empty;

        public string desvMaterial = string.Empty;

        public string desvDelivery = string.Empty;

        public string desvFinishing = string.Empty;

        public string desvProofs = string.Empty;

        public string desvPacking = string.Empty;

        public string desvNotes = string.Empty;

        public string desvInstructions = string.Empty;

        public string desvItemTitle = string.Empty;

        public static string WhereCondition;

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

        static product_list()
        {
            product_list.WhereCondition = string.Empty;
        }

        public product_list()
        {
        }

        public void Bind_AdditionalOptions(DropDownList ddl, long PriceCatalogueID)
        {
            DataTable dataTable = InventoryBasePage.Bind_StockAdditionalItems(PriceCatalogueID);
            ddl.DataSource = dataTable;
            ddl.Items.Insert(0, dataTable.Rows[0][1].ToString());
            ddl.DataTextField = "OptionValue";
            ddl.DataValueField = "Details";
            ddl.DataBind();
        }

        public void Bind_ProductPriceList(TextBox txtQuantityToOrder, HtmlInputCheckBox Checkboxrpt, HiddenField Hdn_PricelistFrom, HiddenField Hdn_PricelistTo, HiddenField Hdn_PricelistCostExcMarkup, HiddenField hid_MarkupList, HiddenField Hdn_SellingPrice, HiddenField hdn_IsCumulative, HiddenField hid_matixType, long PriceCatalogueID, HiddenField hid_SalesTaxRate , HiddenField hid_PurchaseACcodeID)
        {
            DataTable dataTable = EstimatesBasePage.Product_CatalogueQty_Select(PriceCatalogueID);
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            this.IsCumulative = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                Hdn_PricelistFrom.Value = string.Concat(Hdn_PricelistFrom.Value, row["FromQuantity"].ToString(), "µ");
                Hdn_PricelistTo.Value = string.Concat(Hdn_PricelistTo.Value, row["ToQuantity"].ToString(), "µ");
                Hdn_PricelistCostExcMarkup.Value = string.Concat(Hdn_PricelistCostExcMarkup.Value, row["Price"].ToString(), "µ");
                hid_MarkupList.Value = string.Concat(hid_MarkupList.Value, row["Markup"].ToString(), "µ");
                Hdn_SellingPrice.Value = string.Concat(Hdn_SellingPrice.Value, row["NewPrice"].ToString(), "µ");
                hid_matixType.Value = row["MatrixType"].ToString();
                hdn_IsCumulative.Value = row["IsCumulativePricing"].ToString().ToLower().Trim();
                hid_SalesTaxRate.Value = row["SalesTaxRate"].ToString().ToLower().Trim();
                hid_PurchaseACcodeID.Value = row["PurAccountingCode"].ToString().ToLower().Trim();
                if (!Convert.ToBoolean(row["IsStockItem"]))
                    Checkboxrpt.Attributes.Add("Style", "Display:None;");
            }
            txtQuantityToOrder.Attributes.Add("onkeyup", string.Concat("javascript:Tocalculate_totalPrice(this.value,", PriceCatalogueID, ");"));
        }

        public void bindProductList()
        {
            this.GridProductList.PagerStyle.AlwaysVisible = true;
            this.GridProductList.AllowCustomPaging = true;
            DataSet dataSet = InventoryBasePage.SelectProductcatalogueitems_InPurchse(this.CompanyID, this.PageSize, this.GridProductList.CurrentPageIndex + 1, product_list.WhereCondition);
            this.GridProductList.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                this.GridProductList.VirtualItemCount = 0;
                this.GridProductList.AllowCustomPaging = false;
            }
            this.GridProductList.DataSource = dataSet;
        }

        protected void clrFilters_Click_inventry(object sender, EventArgs e)
        {
            product_list.WhereCondition = "";
            foreach (GridColumn column in this.GridProductList.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridProductList.MasterTableView.FilterExpression = string.Empty;
            base.Session["SearchProductList"]=null;
            this.bindProductList();
            this.GridProductList.Rebind();

        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                Convert.ToInt32(row["Roundoff"].ToString());
            }
            base.Session["SearchProd_History"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && product_list.WhereCondition != "")
                {
                    product_list.WhereCondition = string.Concat(product_list.WhereCondition, " and ");
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }

                var dictionary = new Dictionary<string, int>(16)
                             {
                                    { "startswith", 0 },
                                    { "endswith", 1 },
                                    { "equalto", 2 },
                                    { "notequalto", 3 },
                                    { "contains", 4 },
                                    { "doesnotcontain", 5 },
                                    { "greaterthan", 6 },
                                    { "lessthan", 7 },
                                    { "greaterthanorequalto", 8 },
                                    { "lessthanorequalto", 9 },
                                    { "isempty", 10 },
                                    { "notisempty", 11 },
                                    { "isnull", 12 },
                                    { "notisnull", 13 },
                                    { "between", 14 },
                                    { "notbetween", 15 }
                             };


                dictionary.TryGetValue(str1, out num);

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = product_list.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", dataRow["ColumnName"].ToString(), " like '", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = product_list.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "'" };
                            product_list.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string whereCondition2 = product_list.WhereCondition;
                            string[] str2 = new string[] { whereCondition2, " ", dataRow["ColumnName"].ToString(), " = '", dataRow["FilterText"].ToString().Trim(), "'" };
                            product_list.WhereCondition = string.Concat(str2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition3 = product_list.WhereCondition;
                            string[] strArrays2 = new string[] { whereCondition3, " ", dataRow["ColumnName"].ToString(), " != '", dataRow["FilterText"].ToString().Trim(), "'" };
                            product_list.WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 4:
                        {
                            string str3 = product_list.WhereCondition;
                            string[] strArrays3 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition4 = product_list.WhereCondition;
                            string[] str4 = new string[] { whereCondition4, " ", dataRow["ColumnName"].ToString(), " not like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(str4);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition5 = product_list.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition5, " ", dataRow["ColumnName"].ToString(), " > '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 7:
                        {
                            string str5 = product_list.WhereCondition;
                            string[] strArrays5 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " < '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition6 = product_list.WhereCondition;
                            string[] str6 = new string[] { whereCondition6, " ", dataRow["ColumnName"].ToString(), " >= '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(str6);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition7 = product_list.WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition7, " ", dataRow["ColumnName"].ToString(), " <= '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            product_list.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 10:
                        {
                            product_list.WhereCondition = string.Concat(product_list.WhereCondition, " ", dataRow["ColumnName"].ToString(), " = ''");
                            continue;
                        }
                    case 11:
                        {
                            product_list.WhereCondition = string.Concat(product_list.WhereCondition, " ", dataRow["ColumnName"].ToString(), " != ''");
                            continue;
                        }
                    case 12:
                        {
                            product_list.WhereCondition = string.Concat(product_list.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is null");
                            continue;
                        }
                    case 13:
                        {
                            product_list.WhereCondition = string.Concat(product_list.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str7 = product_list.WhereCondition;
                            string[] strArrays7 = new string[] { str7, " ", dataRow["ColumnName"].ToString(), " between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            product_list.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition8 = product_list.WhereCondition;
                            string[] str8 = new string[] { whereCondition8, " ", dataRow["ColumnName"].ToString(), " not between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            product_list.WhereCondition = string.Concat(str8);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return product_list.WhereCondition;
        }

        protected void GridProductList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                product_list.WhereCondition = "";
                if (base.Session["SearchProductList"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["SearchProductList"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["SearchProductList"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", str, "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] first = new object[] { str, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(first);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (item.Text != "")
                    {
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { str, commandArgument.First, item.Text };
                            this.dtsearch.Rows.Add(objArray);
                        }
                    }
                }
                base.Session["SearchProductList"] = this.dtsearch;
                product_list.WhereCondition = this.FilterFunction(this.dtsearch);
                this.bindProductList();
                this.GridProductList.Rebind();
            }
        }

        protected void GridProductList_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridProductList.AllowCustomPaging = true;
            this.bindProductList();
        }

        protected void GridProductList_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    e.Item.Visible = false;
                    GridDataItem item = (GridDataItem)e.Item;
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_DrawStockFrom");
                    HiddenField hiddenField13 = (HiddenField)e.Item.FindControl("hid_PurchaseACcodeID");
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hid_PriceCatalogueID");
                    HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hid_SalesTaxRate");
                    DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlAddItems");
                    dropDownList.ID = string.Concat("ddlAddItems_", hiddenField1.Value);
                    TextBox textBox = (TextBox)e.Item.FindControl("txtQuantityToOrder");
                    HtmlInputCheckBox checkbox = (HtmlInputCheckBox)e.Item.FindControl("Checkboxrpt"); ///Modification
                    HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("Hdn_PricelistFrom");
                    HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("Hdn_PricelistTo");
                    HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("Hdn_PricelistCostExcMarkup");
                    HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hid_MarkupList");
                    HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hid_matixType");
                    HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("Hdn_SellingPrice");
                    HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hdn_IsCumulative");
                    HiddenField hiddenField10 = (HiddenField)e.Item.FindControl("hdnFinal_QuantityPrice");
                    HiddenField hiddenField11 = (HiddenField)e.Item.FindControl("hdn_ItemDescription");
                    HiddenField hiddenField12 = (HiddenField)e.Item.FindControl("hdn_FinalItemDescription");
                    hiddenField4.ID = string.Concat("Hdn_PricelistTo_", hiddenField1.Value);
                    hiddenField3.ID = string.Concat("Hdn_PricelistFrom_", hiddenField1.Value);
                    hiddenField5.ID = string.Concat("Hdn_PricelistCostExcMarkup_", hiddenField1.Value);
                    hiddenField6.ID = string.Concat("hid_MarkupList_", hiddenField1.Value);
                    hiddenField8.ID = string.Concat("Hdn_SellingPrice_", hiddenField1.Value);
                    hiddenField9.ID = string.Concat("hdn_IsCumulative_", hiddenField1.Value);
                    hiddenField7.ID = string.Concat("hid_matixType_", hiddenField1.Value);
                    hiddenField10.ID = string.Concat("hdnFinal_QuantityPrice_", hiddenField1.Value);
                    hiddenField11.ID = string.Concat("hdn_ItemDescription_", hiddenField1.Value);
                    hiddenField12.ID = string.Concat("hdn_FinalItemDescription_", hiddenField1.Value);
                    hiddenField2.ID = string.Concat("hid_SalesTaxRate_", hiddenField1.Value);
                    hiddenField13.ID = string.Concat("hid_PurchaseACcodeID_", hiddenField1.Value);
                    textBox.Attributes.Add("autocomplete", "off");
                    //if (hiddenField.Value.ToLower() == "a")
                    //{
                    //    this.Bind_AdditionalOptions(dropDownList, Convert.ToInt64(hiddenField1.Value.ToString()));
                    //    if (dropDownList.Items.Count > 0)
                    //    {
                    //        dropDownList.Visible = true;
                    //    }
                    //}
                    this.Bind_ProductPriceList(textBox, checkbox, hiddenField3, hiddenField4, hiddenField5, hiddenField6, hiddenField8, hiddenField9, hiddenField7, Convert.ToInt64(hiddenField1.Value.ToString()), hiddenField2, hiddenField13);
                    this.TakeItemDesc(hiddenField11, hiddenField12);
                }
                if (e.Item is GridPagerItem)
                {
                    Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    languageConversion.Text = this.objLangClass.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.GridProductList.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.GridProductList.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLangClass.GetLanguageConversion("items_in"), " {1} ", this.objLangClass.GetLanguageConversion("pages"));
                }
            }
            catch
            {
            }
        }

        protected void GridProductList_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridProductList.CurrentPageIndex = e.NewPageIndex;
            this.bindProductList();
        }

        protected void GridProductList_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.PageSize = e.NewPageSize;
            this.GridProductList.Rebind();
        }

        public void LoadDescription()
        {
            try
            {
                DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
                if (dataSet.Tables[0].Rows.Count > 0 && dataSet != null)
                {
                    if (dataSet.Tables[0].Rows[0]["databaseFieldName"].ToString() == "ItemTitle" && dataSet.Tables[0].Rows[0]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvItemTitle = dataSet.Tables[0].Rows[0]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[1]["databaseFieldName"].ToString() == "Description" && dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desv = dataSet.Tables[0].Rows[1]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[2]["databaseFieldName"].ToString() == "Artwork" && dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvArtwork = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[3]["databaseFieldName"].ToString() == "Colour" && dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvColour = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[4]["databaseFieldName"].ToString() == "Size" && dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvSize = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[5]["databaseFieldName"].ToString() == "Material" && dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvMaterial = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[6]["databaseFieldName"].ToString() == "Delivery" && dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvDelivery = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[7]["databaseFieldName"].ToString() == "Finishing" && dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvFinishing = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[8]["databaseFieldName"].ToString() == "Proofs" && dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvProofs = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[9]["databaseFieldName"].ToString() == "Packing" && dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvPacking = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[10]["databaseFieldName"].ToString() == "Notes" && dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvNotes = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
                    }
                    if (dataSet.Tables[0].Rows[11]["databaseFieldName"].ToString() == "Instructions" && dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() == "true")
                    {
                        this.desvInstructions = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
                    }
                }
            }
            catch
            {
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridProductList.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLangClass.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.GridProductList.MasterTableView.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Item_Code");
            this.GridProductList.MasterTableView.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Item_Title");
            this.GridProductList.MasterTableView.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Supplier");
            this.GridProductList.MasterTableView.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Current_Stock");
            this.GridProductList.MasterTableView.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Allocated_Stock");
            this.GridProductList.MasterTableView.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Available_Stock");
            //this.GridProductList.MasterTableView.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Additional_Options");
            this.GridProductList.MasterTableView.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Stock_Type");
            this.GridProductList.MasterTableView.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("Quantity_to_Order");
            this.link_clrfilt_Warehous.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
            //this.btnAdd.Text = this.objLangClass.GetLanguageConversion("Add");
            this.btnAddClose.Text = this.objLangClass.GetLanguageConversion("Add_and_Close");
            this.LoadDescription();
            if (!base.IsPostBack)
            {
                base.Session["SearchProductList"] = null;
                product_list.WhereCondition = "";
                this.GridProductList.PageSize = 50;
                this.bindProductList();
            }
            this.GridProductList.Rebind();
        }

        public void TakeItemDesc(HiddenField hdn_ItemDescription, HiddenField hdn_FinalItemDescription)
        {
            if (hdn_ItemDescription.Value != "")
            {
                string[] strArrays = hdn_ItemDescription.Value.Split(new char[] { 'µ' });
                string empty = string.Empty;
                for (int i = 0; i <= (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '»' });
                    if (strArrays1[0].ToString().Trim() == "ItemTitle")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays2 = new string[] { empty, "\n", this.desvItemTitle, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays2);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Description")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays3 = new string[] { empty, "\n", this.desv, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays3);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Artwork")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays4 = new string[] { empty, "\n", this.desvArtwork, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays4);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Colour")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays5 = new string[] { empty, "\n", this.desvColour, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays5);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Material")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays6 = new string[] { empty, "\n", this.desvMaterial, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays6);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Delivery")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays7 = new string[] { empty, "\n", this.desvDelivery, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays7);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Finishing")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays8 = new string[] { empty, "\n", this.desvFinishing, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays8);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Proofs")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays9 = new string[] { empty, "\n", this.desvProofs, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays9);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Packing")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays10 = new string[] { empty, "\n", this.desvPacking, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays10);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Notes")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays11 = new string[] { empty, "\n", this.desvNotes, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays11);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "instructions")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays12 = new string[] { empty, "\n", this.desvInstructions, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays12);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "Size")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays13 = new string[] { empty, "\n", this.desvSize, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays13);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim() == "notes")
                    {
                        if (strArrays1[1].ToString().Trim() != "")
                        {
                            string[] strArrays14 = new string[] { empty, "\n", this.desvNotes, ": ", strArrays1[1] };
                            empty = string.Concat(strArrays14);
                        }
                    }
                    else if (strArrays1[0].ToString().Trim().Contains("Custom") && strArrays1[1].ToString().Trim() != "")
                    {
                        DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
                        DataRow[] dataRowArray = dataSet.Tables[0].Select(string.Concat("databaseFieldName='", strArrays1[0].ToString().Trim().Replace("\n", "").Replace("\r", ""), "'"));
                        string[] str = new string[] { empty, "\n", dataRowArray[0]["ScreenName"].ToString(), ": ", strArrays1[1] };
                        empty = string.Concat(str);
                    }
                }
                hdn_FinalItemDescription.Value = empty.Replace("\r", "").Replace("\n\n", "").Replace("µ", "").Replace("»", "");
            }
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {

            foreach (GridDataItem item in GridProductList.MasterTableView.Items)
            {
                HtmlInputCheckBox checkbox = item.FindControl("Checkboxrpt") as HtmlInputCheckBox;
                // access your checkbox here
                if (checkbox.Checked)
                {
                    HiddenField hiddenField1 = (HiddenField)item.FindControl("hid_PriceCatalogueID");
                    string pricecatalougeid = hiddenField1.Value;
                    this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(this.cs);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(string.Concat("update tb_PriceCatalogueQty set flag = 1 where PriceCatalogueID=", pricecatalougeid), sqlConnection);
                    pricecatalougeid = (string)sqlCommand.ExecuteScalar();
                    sqlConnection.Close();
                }
            }
            //object a = this.GridProductList.MasterTableView.Columns[9];
            //HtmlInputCheckBox cb = (HtmlInputCheckBox)this.DataList1.Items[index].FindControl("Checkbox1");
            //  HtmlInputCheckBox checkbox = (HtmlInputCheckBox)e.Item.FindControl("Checkboxrpt");


        }
    }
}