using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.usercontrol.ProductCatalogue
{
    public partial class ProductCatalogueItemStockPO : System.Web.UI.UserControl
    {
        public static languageClass objLanguage;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private BaseClass objbaseclass = new BaseClass();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public static int ProductCatalogueID;

        public static string WhereCondition;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public static commonClass comm;

        public static ArrayList fieldnames;

        public int CompanyID;

        public int UserID;

        public static string Price;

        public string DateFormat = "mm/dd/yyyy";

        public string JobNo = string.Empty;

        private DataTable dtsearch = new DataTable();

        public int totalrows = 2;

        private StringBuilder strBuildAdditional = new StringBuilder();

        public long EstItemID;

        public long EstimateID;

        public long JobID;

        public long Qty;

        public static string ActionType;

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

        static ProductCatalogueItemStockPO()
        {
            ProductCatalogueItemStockPO.objLanguage = new languageClass();
            ProductCatalogueItemStockPO.ProductCatalogueID = 0;
            ProductCatalogueItemStockPO.WhereCondition = string.Empty;
            ProductCatalogueItemStockPO.comm = new commonClass();
            ProductCatalogueItemStockPO.fieldnames = new ArrayList();
            ProductCatalogueItemStockPO.Price = 0.ToString();
            ProductCatalogueItemStockPO.ActionType = "";
        }

        public ProductCatalogueItemStockPO()
        {
        }

        protected void btnclrFilters_ProductCatalogueItemStockHistory_Click(object sender, EventArgs e)
        {
            ProductCatalogueItemStockPO.WhereCondition = "";
            base.Session["SearchJobAllocationHistory"] = null;
            foreach (GridColumn column in this.grdProductCatalogueItemStockHistory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.grdProductCatalogueItemStockHistory.MasterTableView.FilterExpression = string.Empty;
            this.GrdProductCatalogueItemStockHistoryBind(ProductCatalogueItemStockPO.ProductCatalogueID, this.grdProductCatalogueItemStockHistory.PageSize, this.grdProductCatalogueItemStockHistory.CurrentPageIndex + 1, ProductCatalogueItemStockPO.WhereCondition);
            this.grdProductCatalogueItemStockHistory.MasterTableView.Rebind();
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() == "nofilter")
            {
                base.Session["SearchJobAllocationHistory"] = "";
                return;
            }
            base.Session["SearchJobAllocationHistory"] = this.dtsearch;
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
            base.Session["SearchJobAllocationHistory"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && ProductCatalogueItemStockPO.WhereCondition != "")
                {
                    ProductCatalogueItemStockPO.WhereCondition = string.Concat(ProductCatalogueItemStockPO.WhereCondition, " and ");
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", dataRow["ColumnName"].ToString(), " like '", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string whereCondition2 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] str2 = new string[] { whereCondition2, " ", dataRow["ColumnName"].ToString(), " = '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(str2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition3 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays2 = new string[] { whereCondition3, " ", dataRow["ColumnName"].ToString(), " != '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 4:
                        {
                            string str3 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays3 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition4 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] str4 = new string[] { whereCondition4, " ", dataRow["ColumnName"].ToString(), " not like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(str4);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition5 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition5, " ", dataRow["ColumnName"].ToString(), " > '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 7:
                        {
                            string str5 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays5 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " < '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition6 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] str6 = new string[] { whereCondition6, " ", dataRow["ColumnName"].ToString(), " >= '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(str6);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition7 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition7, " ", dataRow["ColumnName"].ToString(), " <= '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 10:
                        {
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(ProductCatalogueItemStockPO.WhereCondition, " ", dataRow["ColumnName"].ToString(), " = ''");
                            continue;
                        }
                    case 11:
                        {
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(ProductCatalogueItemStockPO.WhereCondition, " ", dataRow["ColumnName"].ToString(), " != ''");
                            continue;
                        }
                    case 12:
                        {
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(ProductCatalogueItemStockPO.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is null");
                            continue;
                        }
                    case 13:
                        {
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(ProductCatalogueItemStockPO.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str7 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] strArrays7 = new string[] { str7, " ", dataRow["ColumnName"].ToString(), " between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition8 = ProductCatalogueItemStockPO.WhereCondition;
                            string[] str8 = new string[] { whereCondition8, " ", dataRow["ColumnName"].ToString(), " not between '", dataRow["FilterText"].ToString().Trim(), "' and '", dataRow["FilterText"].ToString().Trim(), "'" };
                            ProductCatalogueItemStockPO.WhereCondition = string.Concat(str8);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return ProductCatalogueItemStockPO.WhereCondition;
        }

        public void getalldetails(int ProductCatalogueID)
        {
            if (ProductCatalogueID != 0)
            {
                DataTable dataTable = WebstoreBasePage.Settings_Product_Catalogue_Select(this.CompanyID, ProductCatalogueID);
                if (dataTable.Rows.Count > 0 && Convert.ToBoolean(dataTable.Rows[0]["IsStockItem"]))
                {
                    this.imgback_ProductCatalogueItemStockHistory.Style.Add("display", "block");
                }
            }
        }

        protected void grdProductCatalogueItemStockHistory_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objbaseclass.ReplaceSingleQuote(item.Text);
                ProductCatalogueItemStockPO.WhereCondition = "";
                if (str.Trim().ToLower() == "templatecolumn1")
                {
                    str = "PODate";
                }
                if (str.Trim().ToLower() == "templatecolumn2")
                {
                    str = "PONumber";
                }
                if (base.Session["SearchJobAllocationHistory"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["SearchJobAllocationHistory"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["SearchJobAllocationHistory"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", str, "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] first = new object[] { str, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(first);
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { str, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                        this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                    }
                }
                ProductCatalogueItemStockPO.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GrdProductCatalogueItemStockHistoryBind(ProductCatalogueItemStockPO.ProductCatalogueID, this.grdProductCatalogueItemStockHistory.PageSize, 1, ProductCatalogueItemStockPO.WhereCondition);
                this.grdProductCatalogueItemStockHistory.Rebind();
            }
        }

        protected void grdProductCatalogueItemStockHistory_ItemDataBound(object sender, GridItemEventArgs e)
        {
            foreach (GridColumn column in this.grdProductCatalogueItemStockHistory.MasterTableView.Columns)
            {
                if (base.IsPostBack || !(column.UniqueName == "JobNumber") || !(this.JobNo.ToString().Trim() != ""))
                {
                    continue;
                }
                column.CurrentFilterValue = this.JobNo;
            }
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label str = (Label)e.Item.FindControl("lblDate");
                str.Text = Convert.ToString(str.Text);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdProductCatalogueItemStockHistory.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdProductCatalogueItemStockHistory.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("items_in"), " {1} ", ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void grdProductCatalogueItemStockHistory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.grdProductCatalogueItemStockHistory.AllowCustomPaging = true;
            DataSet dataSet = this.GrdProductCatalogueItemStockHistoryBind(ProductCatalogueItemStockPO.ProductCatalogueID, this.grdProductCatalogueItemStockHistory.PageSize, this.grdProductCatalogueItemStockHistory.CurrentPageIndex + 1, ProductCatalogueItemStockPO.WhereCondition);
            this.grdProductCatalogueItemStockHistory.DataSource = dataSet.Tables[0];
        }

        protected void grdProductCatalogueItemStockHistory_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.grdProductCatalogueItemStockHistory.CurrentPageIndex = e.NewPageIndex;
            this.GrdProductCatalogueItemStockHistoryBind(ProductCatalogueItemStockPO.ProductCatalogueID, this.grdProductCatalogueItemStockHistory.PageSize, this.grdProductCatalogueItemStockHistory.CurrentPageIndex + 1, ProductCatalogueItemStockPO.WhereCondition);
        }

        public DataSet GrdProductCatalogueItemStockHistoryBind(int ProductCatalogueID, int PageSize, int PageNumber, string WhereCondition)
        {
            this.grdProductCatalogueItemStockHistory.AllowCustomPaging = true;
            DataSet dataSet = new DataSet();
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_PriceCatalogItemPO_Select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PricecatalogueID", ProductCatalogueID);
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            this.grdProductCatalogueItemStockHistory.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                this.grdProductCatalogueItemStockHistory.VirtualItemCount = 0;
                this.grdProductCatalogueItemStockHistory.AllowCustomPaging = false;
            }
            return dataSet;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdProductCatalogueItemStockHistory.FilterMenu;
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
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = ProductCatalogueItemStockPO.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["PriceCatalogueID"] != null && base.Request.Params["PriceCatalogueID"].ToString() != "")
            {
                ProductCatalogueItemStockPO.ProductCatalogueID = Convert.ToInt32(base.Request.Params["PriceCatalogueID"].ToString());
            }
            if (base.Request.Params["JobNo"] != null && base.Request.Params["JobNo"].ToString() != "")
            {
                this.JobNo = base.Request.Params["JobNo"].ToString().Trim();
            }
            if (base.Request.Params["EstItemID"] != null && base.Request.Params["EstItemID"].ToString() != "")
            {
                this.EstItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString().Trim());
            }
            if (base.Request.Params["EstimateID"] != null && base.Request.Params["EstimateID"].ToString() != "")
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"].ToString().Trim());
            }
            if (base.Request.Params["JobID"] != null && base.Request.Params["JobID"].ToString() != "")
            {
                this.JobID = Convert.ToInt64(base.Request.Params["JobID"].ToString().Trim());
            }
            if (base.Request.Params["Qty"] != null && base.Request.Params["Qty"].ToString() != "")
            {
                this.Qty = Convert.ToInt64(base.Request.Params["Qty"].ToString().Trim());
            }
            if (base.Request.Params["ActionType"] != null && base.Request.Params["ActionType"].ToString() != "")
            {
                ProductCatalogueItemStockPO.ActionType = base.Request.Params["ActionType"].ToString().Trim();
            }
            if (!base.IsPostBack)
            {
                this.getalldetails(ProductCatalogueItemStockPO.ProductCatalogueID);
                string str = "";
                if (base.Session["SearchJobAllocationHistory"] != null)
                {
                    DataTable item = (DataTable)base.Session["SearchJobAllocationHistory"];
                    str = this.FilterFunction(item);
                    base.Session["SearchJobAllocationHistory"] = null;
                    str = string.Concat(" JobNumber like '%", this.JobNo, "%'");
                    ProductCatalogueItemStockPO.WhereCondition = string.Concat(" JobNumber like '%", this.JobNo, "%'");
                }
                else if (this.JobNo == "")
                {
                    str = "";
                    ProductCatalogueItemStockPO.WhereCondition = "";
                }
                else
                {
                    str = string.Concat(" JobNumber like '%", this.JobNo, "%'");
                    ProductCatalogueItemStockPO.WhereCondition = string.Concat(" JobNumber like '%", this.JobNo, "%'");
                }
                this.GrdProductCatalogueItemStockHistoryBind(ProductCatalogueItemStockPO.ProductCatalogueID, this.grdProductCatalogueItemStockHistory.PageSize, 1, str);
                this.grdProductCatalogueItemStockHistory.Rebind();
            }
        }
    }
}