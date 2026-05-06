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
    public partial class EstimateSubSection : System.Web.UI.UserControl
    {
        //protected LinkButton lnk_ClearFilter_Estimate;

        //protected PlaceHolder plhEstimates;

        //protected UpdatePanel UpdatePanel5;

        //protected RadGrid RadGrid_Estimates;

        //protected HtmlGenericControl div_EstimateMain;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private CompanyBasePage objcomm = new CompanyBasePage();

        private commonClass objcom = new commonClass();

        public static BaseClass objBase;

        private BasePage objPage = new BasePage();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int cntDelete;

        public int cntDefault;

        public int SetDefaultContactID;

        public int Index;

        public static int FilteringEstimates;

        public static string ShowRecords;

        public string SalesPersonCondition = string.Empty;

        public string WebStorePath = string.Empty;

        public string FileExtension = string.Empty;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string B2BURL = ConnectionClass.B2BURL;

        public string isView = string.Empty;

        private DataTable dt_Estimates;

        public string WhereConditionEstimate = string.Empty;

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

        static EstimateSubSection()
        {
            EstimateSubSection.objBase = new BaseClass();
            EstimateSubSection.FilteringEstimates = 0;
            EstimateSubSection.ShowRecords = string.Empty;
        }

        public EstimateSubSection()
        {
        }

        protected void clrFiltersEstimates_Click(object sender, EventArgs e)
        {
            base.Session["CRMDateFilterEstimate"] = "";
            foreach (GridColumn column in this.RadGrid_Estimates.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session[string.Concat("searchEstimate", this.ClientID)] = null;
            this.WhereConditionEstimate = "";
            this.RadGrid_Estimates.MasterTableView.FilterExpression = string.Empty;
            this.GridEstimate(this.ClientID);
        }

        protected void clrFiltersHideEstimates_Click(object sender, EventArgs e)
        {
            this.FilterStatus();
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
            this.GridEstimate(this.ClientID);
        }

        public void GridEstimate(int ClientID)
        {
            if (!ConnectionClass.IsSplitItem)
            {
                this.dt_Estimates = CompanyBasePage.ActiveHistoryEstimate_Filter(ClientID, this.SalesPersonCondition, this.WhereConditionEstimate);
            }
            else
            {
                this.dt_Estimates = CompanyBasePage.ActiveHistoryEstimate_SplitItems_Filter(ClientID, this.SalesPersonCondition, this.WhereConditionEstimate);
            }
            this.RadGrid_Estimates.DataSource = this.dt_Estimates;
            this.RadGrid_Estimates.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:LoadingImageEstimate();", true);
            this.RadGrid_Estimates.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Estimate_Number").ToString();
            this.RadGrid_Estimates.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Estimate_Title").ToString();
            this.RadGrid_Estimates.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Estimate_Date").ToString();
            this.RadGrid_Estimates.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Estimate_Status").ToString();
            this.RadGrid_Estimates.Columns[4].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("To"), "($)");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.WebStorePath = string.Concat(this.B2BURL, "login.aspx");
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
            BaseClass baseClass = new BaseClass();
            EstimateSubSection.ShowRecords = baseClass.ReturnRoles_Privileges_Others("showrecords");
            if (EstimateSubSection.ShowRecords.ToLower() != "allocation")
            {
                this.SalesPersonCondition = " ";
            }
            else
            {
                this.SalesPersonCondition = string.Concat("e.SalesPerson=", this.UserID, " and");
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["EstimatesFiterState"] != null)
                {
                    base.Request.Cookies["EstimatesFiterState"].Value = null;
                }
                this.FilterStatus();
                this.isView = baseClass.ReturnRoles_Privileges_ForGrid("estimates", "isview", this.Page.Request.Url.ToString());
            }
            if (base.Session[string.Concat("searchEstimate", this.ClientID)] != null)
            {
                DataTable dataTable = new DataTable();
                this.RadGrid_Estimates.MasterTableView.FilterExpression = "";
                try
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchEstimate", this.ClientID)];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GridColumn columnSafe = this.RadGrid_Estimates.MasterTableView.GetColumnSafe(row["ColumnName"].ToString());
                        columnSafe.CurrentFilterValue = row["FilterText"].ToString();
                    }
                    this.WhereConditionEstimate = this.FilterFunction(dataTable);
                }
                catch
                {
                }
            }
            this.GridEstimate(this.ClientID);
        }

        protected void RadGrid_Estimates_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                if (str.ToLower() == "estimatedate")
                {
                    base.Session["CRMDateFilterEstimate"] = item.Text;
                    item.Text = this.objcom.Eprint_return_Date_Before_View(item.Text, this.CompanyID, this.UserID, false);
                }
                DataTable dataTable = new DataTable();
                item.Text = EstimateSubSection.objBase.ReplaceSingleQuote(item.Text);
                this.WhereConditionEstimate = "";
                if (base.Session[string.Concat("searchEstimate", this.ClientID)] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session[string.Concat("searchEstimate", this.ClientID)] != null)
                {
                    dataTable = (DataTable)base.Session[string.Concat("searchEstimate", this.ClientID)];
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
                base.Session[string.Concat("searchEstimate", this.ClientID)] = dataTable;
                this.WhereConditionEstimate = this.FilterFunction(dataTable);
                this.GridEstimate(this.ClientID);
                this.RadGrid_Estimates.Rebind();
            }
        }

        protected void RadGrid_Estimates_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (!ConnectionClass.IsSplitItem)
            {
                this.dt_Estimates = CompanyBasePage.ActiveHistoryEstimate_Filter(this.ClientID, this.SalesPersonCondition, this.WhereConditionEstimate);
            }
            else
            {
                this.dt_Estimates = CompanyBasePage.ActiveHistoryEstimate_SplitItems_Filter(this.ClientID, this.SalesPersonCondition, this.WhereConditionEstimate);
            }
            this.RadGrid_Estimates.DataSource = this.dt_Estimates;
        }

        protected void RadGridEstimates_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["EstimateValue"].Text = string.Concat(this.objLangClass.GetLanguageConversion("Estimate_Value"), "(", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_EstimateValue_Estimates");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_EstimateValue_Estimates");
                Label label1 = (Label)e.Item.FindControl("lbl_EstimateDate_Estimates");
                label1.Text = this.objcom.Eprint_return_Date_Before_View(label1.Text, this.CompanyID, this.UserID, false);
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_EstimateDate_Estimates");
                label.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField.Value), 0, "", false, false, true);
            }
            if (e.Item.ItemType == GridItemType.FilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                (e.Item as GridFilteringItem)["EstimateValue"].HorizontalAlign = HorizontalAlign.Right;
                TextBox str = (e.Item as GridFilteringItem)["EstimateDate"].Controls[0] as TextBox;
                string regionalSettings = this.objPage.GetRegionalSettings(this.CompanyID, "Dateformat");
                if (base.Session["CRMDateFilterEstimate"] != null && regionalSettings == "dd/mm/yyyy")
                {
                    str.Text = base.Session["CRMDateFilterEstimate"].ToString();
                }
            }
        }
    }
}