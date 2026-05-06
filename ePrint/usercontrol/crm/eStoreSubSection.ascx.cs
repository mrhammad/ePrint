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
    public partial class eStoreSubSection : System.Web.UI.UserControl
    {


        private CompanyBasePage objcomm = new CompanyBasePage();

        private commonClass objcom = new commonClass();

        public static BaseClass objBase;

        private BasePage objPage = new BasePage();

        public string ImgPath = global.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int cntDelete;

        public int cntDefault;

        public int SetDefaultContactID;

        public int Index;

        public static int FilteringeStore;

        public static string ShowRecords;

        public string SalesPersonCondition = string.Empty;

        public string WebStorePath = string.Empty;

        public string FileExtension = string.Empty;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string B2BURL = ConnectionClass.B2BURL;

        public string isView = string.Empty;

        private DataTable dt_eStore;

        private string WhereConditionEstore = string.Empty;

        public languageClass objLangClass = new languageClass();

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

        static eStoreSubSection()
        {
            eStoreSubSection.objBase = new BaseClass();
            eStoreSubSection.FilteringeStore = 0;
            eStoreSubSection.ShowRecords = string.Empty;
        }

        public eStoreSubSection()
        {
        }

        protected void clrFilterseStore_Click(object sender, EventArgs e)
        {
            base.Session["CRMDateFiltereStore"] = "";
            foreach (GridColumn column in this.RadGrid_eStore.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session["searchEstore"] = null;
            this.WhereConditionEstore = "";
            this.RadGrid_eStore.MasterTableView.FilterExpression = string.Empty;
            this.GrideStore(this.CompanyID, this.ClientID);
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

        public void FilterStatus()
        {
            this.GrideStore(this.CompanyID, this.ClientID);
        }

        public void GrideStore(int CompanyID, int ClientID)
        {
            this.dt_eStore = CompanyBasePage.ActiveHistoryeStore_SplitItems_Filter(CompanyID, ClientID, this.SalesPersonCondition, this.WhereConditionEstore);
            this.RadGrid_eStore.DataSource = this.dt_eStore;
            this.RadGrid_eStore.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:LoadingImageeStore();", true);
            this.RadGrid_eStore.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Order_Number").ToString();
            this.RadGrid_eStore.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Order_Title").ToString();
            this.RadGrid_eStore.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Order_Date").ToString();
            this.RadGrid_eStore.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Order_Status").ToString();
            BaseClass baseClass = new BaseClass();
            this.isView = baseClass.ReturnRoles_Privileges_ForGrid("webstoreorder", "isview", this.Page.Request.Url.ToString());
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.WebStorePath = string.Concat(this.B2BURL, "store/accounts/login.aspx");
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
            eStoreSubSection.ShowRecords = baseClass.ReturnRoles_Privileges_Others("showrecords");
            if (eStoreSubSection.ShowRecords.ToLower() != "allocation")
            {
                this.SalesPersonCondition = " ";
            }
            else
            {
                this.SalesPersonCondition = string.Concat("e.SalesPerson=", this.UserID, " and");
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["eStoreFiterState"] != null)
                {
                    base.Request.Cookies["eStoreFiterState"].Value = null;
                }
                this.FilterStatus();
            }
            if (base.Session["searchEstore"] != null)
            {
                DataTable dataTable = new DataTable();
                this.RadGrid_eStore.MasterTableView.FilterExpression = "";
                try
                {
                    dataTable = (DataTable)base.Session["searchEstore"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GridColumn columnSafe = this.RadGrid_eStore.MasterTableView.GetColumnSafe(row["ColumnName"].ToString());
                        columnSafe.CurrentFilterValue = row["FilterText"].ToString();
                    }
                    this.WhereConditionEstore = this.FilterFunction(dataTable);
                }
                catch
                {
                }
            }
            this.GrideStore(this.CompanyID, this.ClientID);
        }

        protected void RadGrid_eStore_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                if (str.ToLower() == "orderdate")
                {
                    base.Session["CRMDateFiltereStore"] = item.Text;
                    item.Text = this.objcom.Eprint_return_Date_Before_View(item.Text, this.CompanyID, this.UserID, false);
                }
                item.Text = eStoreSubSection.objBase.ReplaceSingleQuote(item.Text);
                this.WhereConditionEstore = "";
                if (base.Session["searchEstore"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session["searchEstore"] != null)
                {
                    dataTable = (DataTable)base.Session["searchEstore"];
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
                base.Session["searchEstore"] = dataTable;
                this.WhereConditionEstore = this.FilterFunction(dataTable);
                this.GrideStore(this.CompanyID, this.ClientID);
                this.RadGrid_eStore.Rebind();
            }
        }

        protected void RadGrid_eStore_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.dt_eStore = CompanyBasePage.ActiveHistoryeStore_SplitItems_Filter(this.CompanyID, this.ClientID, this.SalesPersonCondition, this.WhereConditionEstore);
            this.RadGrid_eStore.DataSource = this.dt_eStore;
        }

        protected void RadGrid_eStore_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["OrderValue"].Text = string.Concat(this.objLangClass.GetLanguageConversion("Order_Value"), "(", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_EstimateValue_eStore");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_EstimateValue_eStore");
                Label label1 = (Label)e.Item.FindControl("lbl_EstimateDate_eStore");
                label1.Text = this.objcom.Eprint_return_Date_Before_View(label1.Text, this.CompanyID, this.UserID, false);
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_EstimateDate_eStore");
                label.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField.Value), 0, "", false, false, true);
            }
            if (e.Item.ItemType == GridItemType.FilteringItem)
            {
                ((GridFilteringItem)e.Item)["OrderValue"].HorizontalAlign = HorizontalAlign.Right;
                TextBox str = (e.Item as GridFilteringItem)["OrderDate"].Controls[0] as TextBox;
                string regionalSettings = this.objPage.GetRegionalSettings(this.CompanyID, "Dateformat");
                if (base.Session["CRMDateFiltereStore"] != null && regionalSettings == "dd/mm/yyyy")
                {
                    str.Text = base.Session["CRMDateFiltereStore"].ToString();
                }
            }
        }
    }
}