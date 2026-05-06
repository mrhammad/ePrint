using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
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

namespace ePrint.usercontrol.crm
{
    public partial class ProductSubSection : System.Web.UI.UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private CompanyBasePage objcomm = new CompanyBasePage();

        public static BaseClass objBase;

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int cntDelete;

        public int cntDefault;

        public int SetDefaultContactID;

        public int Index;

        public static int FilteringProducts;

        public string WebStorePath = string.Empty;

        public string FileExtension = string.Empty;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public languageClass objLangClass = new languageClass();

        private DataTable dt_Products;

        public string WhereCondition = string.Empty;

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

        static ProductSubSection()
        {
            ProductSubSection.objBase = new BaseClass();
            ProductSubSection.FilteringProducts = 0;
        }

        public ProductSubSection()
        {
        }

        protected void btnclrFilters_Products_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGrid_Products.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchProducts", this.ClientID)] = null;
            this.WhereCondition = "";
            this.RadGrid_Products.MasterTableView.FilterExpression = string.Empty;
            this.GridProducts(this.CompanyID, this.ClientID);
        }

        public string FilterFunction(DataTable dt)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dt.Rows)
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

        public void FilterStatus()
        {
            this.GridProducts(this.CompanyID, this.ClientID);
        }

        public void GridProducts(int CompanyID, int ClientID)
        {
            this.dt_Products = CompanyBasePage.Customer_Products_Select_Filter(CompanyID, ClientID, this.WhereCondition);
            this.RadGrid_Products.DataSource = this.dt_Products;
            this.RadGrid_Products.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.RadGrid_Products.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                string lower = filterMenu.Items[i].Text.ToLower();
                string str = lower;
                if (lower != null)
                {
                    switch (str)
                    {
                        case "custom":
                            {
                                filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                                break;
                            }
                        case "isempty":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notisempty":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "isnull":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notisnull":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "between":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notbetween":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "notequalto":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "greaterthan":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "lessthan":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "greaterthanorequalto":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                        case "lessthanorequalto":
                            {
                                filterMenu.Items[i].Visible = false;
                                break;
                            }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadGrid_Products.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Category_Name").ToString();
            this.RadGrid_Products.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Item_Title").ToString();
            this.RadGrid_Products.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Description").ToString();
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            try
            {
                string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
                ArrayList arrayLists = Encryption.querystrvalue(str);
                this.ClientID = int.Parse(arrayLists[1].ToString());
                this.CompanyName = arrayLists[3].ToString();
                this.CompanyType = arrayLists[7].ToString();
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["ProductsFiterState"] != null)
                {
                    base.Request.Cookies["ProductsFiterState"].Value = null;
                }
                this.FilterStatus();
            }
            if (base.Session[string.Concat("searchProducts", this.ClientID)] != null)
            {
                DataTable dataTable = new DataTable();
                this.RadGrid_Products.MasterTableView.FilterExpression = "";
                try
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchProducts", this.ClientID)];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GridColumn columnSafe = this.RadGrid_Products.MasterTableView.GetColumnSafe(row["ColumnName"].ToString());
                        columnSafe.CurrentFilterValue = row["FilterText"].ToString();
                    }
                    this.WhereCondition = this.FilterFunction(dataTable);
                }
                catch
                {
                }
            }
            this.GridProducts(this.CompanyID, this.ClientID);
            this.RadGrid_Products.Rebind();
        }

        protected void RadGrid_Products_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = ProductSubSection.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (base.Session[string.Concat("searchProducts", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchProducts", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchProducts", this.ClientID)];
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
                base.Session[string.Concat("searchProducts", this.ClientID)] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                this.GridProducts(this.CompanyID, this.ClientID);
                this.RadGrid_Products.Rebind();
            }
        }

        protected void RadGrid_Products_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.dt_Products = CompanyBasePage.Customer_Products_Select_Filter(this.CompanyID, this.ClientID, this.WhereCondition);
            this.RadGrid_Products.DataSource = this.dt_Products;
        }

        protected void RadGridProduct_OnRowDataBound(object sender, GridItemEventArgs e)
        {
        }
    }
}