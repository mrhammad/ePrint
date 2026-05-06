using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Invoices;
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
    public partial class JobsSubSection : System.Web.UI.UserControl
    {

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

        public static int FilteringJobs;

        public static string ShowRecords;

        public string SalesPersonCondition = string.Empty;

        public string WebStorePath = string.Empty;

        public string FileExtension = string.Empty;

        public string CompanyName = string.Empty;

        public string CompanyType = string.Empty;

        public string redirectFrom = string.Empty;

        public string isView = string.Empty;

        private DataTable dt_Jobs = new DataTable();

        private string WhereConditionJob = string.Empty;

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

        static JobsSubSection()
        {
            JobsSubSection.objBase = new BaseClass();
            JobsSubSection.FilteringJobs = 0;
            JobsSubSection.ShowRecords = string.Empty;
        }

        public JobsSubSection()
        {
        }

        protected void clrFiltersJobs_Click(object sender, EventArgs e)
        {
            base.Session["CRMDateFilterJob"] = "";
            foreach (GridColumn column in this.RadGrid_Jobs.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            base.Session["searchJobs"] = null;
            this.WhereConditionJob = "";
            this.RadGrid_Jobs.MasterTableView.FilterExpression = string.Empty;
            this.GridJobs(this.ClientID);
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
            this.GridJobs(this.ClientID);
        }

        public void GridJobs(int ClientID)
        {
            this.dt_Jobs = CompanyBasePage.ActiveHistoryJobs_SplitItems_Filter(ClientID, this.SalesPersonCondition, this.WhereConditionJob);
            this.RadGrid_Jobs.DataSource = this.dt_Jobs;
            this.RadGrid_Jobs.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:LoadingImageJob();", true);
            this.RadGrid_Jobs.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Job_Number").ToString();
            this.RadGrid_Jobs.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title").ToString();
            this.RadGrid_Jobs.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Job_Date").ToString();
            this.RadGrid_Jobs.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Job_Status").ToString();
            this.RadGrid_Jobs.Columns[4].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value"), "($)");
            BaseClass baseClass = new BaseClass();
            this.isView = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "isview", this.Page.Request.Url.ToString());
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
            JobsSubSection.ShowRecords = baseClass.ReturnRoles_Privileges_Others("showrecords");
            if (JobsSubSection.ShowRecords.ToLower() != "allocation")
            {
                this.SalesPersonCondition = " ";
            }
            else
            {
                this.SalesPersonCondition = string.Concat("e.SalesPerson=", this.UserID, " and");
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["JobsFiterState"] != null)
                {
                    base.Request.Cookies["JobsFiterState"].Value = null;
                }
                this.FilterStatus();
            }
            if (base.Session["searchJobs"] != null)
            {
                DataTable dataTable = new DataTable();
                this.RadGrid_Jobs.MasterTableView.FilterExpression = "";
                try
                {
                    dataTable = (DataTable)base.Session["searchJobs"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GridColumn columnSafe = this.RadGrid_Jobs.MasterTableView.GetColumnSafe(row["ColumnName"].ToString());
                        columnSafe.CurrentFilterValue = row["FilterText"].ToString();
                    }
                    this.WhereConditionJob = this.FilterFunction(dataTable);
                }
                catch
                {
                }
            }
            this.GridJobs(this.ClientID);
        }

        protected void RadGrid_Jobs_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                if (str.ToLower() == "converteddate")
                {
                    base.Session["CRMDateFilterJob"] = item.Text;
                    item.Text = this.objcom.Eprint_return_Date_Before_View(item.Text, this.CompanyID, this.UserID, false);
                }
                item.Text = JobsSubSection.objBase.ReplaceSingleQuote(item.Text);
                this.WhereConditionJob = "";
                if (base.Session["searchJobs"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (base.Session["searchJobs"] != null)
                {
                    dataTable = (DataTable)base.Session["searchJobs"];
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
                base.Session["searchJobs"] = dataTable;
                this.WhereConditionJob = this.FilterFunction(dataTable);
                this.GridJobs(this.ClientID);
                this.RadGrid_Jobs.Rebind();
            }
        }

        protected void RadGrid_Jobs_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.dt_Jobs = CompanyBasePage.ActiveHistoryJobs_SplitItems_Filter(this.ClientID, this.SalesPersonCondition, this.WhereConditionJob);
            this.RadGrid_Jobs.DataSource = this.dt_Jobs;
        }

        protected void RadGridJobs_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            string empty = string.Empty;
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["EstimateValue"].Text = string.Concat(this.objLangClass.GetLanguageConversion("Job_Value"), "(", this.objcom.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lbl_EstimateNumber_Jobs");
                Label label1 = (Label)e.Item.FindControl("lbl_EstimateDate_Jobs");
                Label label2 = (Label)e.Item.FindControl("lbl_EstimateTitle_Jobs");
                Label label3 = (Label)e.Item.FindControl("lbl_StatusTitle_Jobs");
                Label label4 = (Label)e.Item.FindControl("lbl_EstimateValue_Jobs");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_EstimateValue_Jobs");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_EstimateDate_Jobs");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_EstimateType");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_EstimateID_Jobs");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_OrderID_Jobs");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_JobID_Jobs");
                try
                {
                    label4.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text), 0, "", false, false, true);
                    label1.Text = this.objcom.Eprint_return_Date_Before_View(label1.Text, this.CompanyID, this.UserID, false);
                    empty = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore((long)Convert.ToInt32(hiddenField5.Value), "jobs").ToLower();
                    AttributeCollection attributes = label2.Attributes;
                    string[] value = new string[] { "javascript:DisplaySummaryPopUp('", hiddenField3.Value, "','2','", empty, "','", hiddenField4.Value, "','", this.isView, "','", hiddenField5.Value, "');" };
                    attributes.Add("onclick", string.Concat(value));
                    AttributeCollection attributeCollection = label3.Attributes;
                    string[] strArrays = new string[] { "javascript:DisplaySummaryPopUp('", hiddenField3.Value, "','2','", empty, "','", hiddenField4.Value, "','", this.isView, "','", hiddenField5.Value, "');" };
                    attributeCollection.Add("onclick", string.Concat(strArrays));
                    AttributeCollection attributes1 = label.Attributes;
                    string[] value1 = new string[] { "javascript:DisplaySummaryPopUp('", hiddenField3.Value, "','2','", empty, "','", hiddenField4.Value, "','", this.isView, "','", hiddenField5.Value, "');" };
                    attributes1.Add("onclick", string.Concat(value1));
                    AttributeCollection attributeCollection1 = label4.Attributes;
                    string[] strArrays1 = new string[] { "javascript:DisplaySummaryPopUp('", hiddenField3.Value, "','2','", empty, "','", hiddenField4.Value, "','", this.isView, "','", hiddenField5.Value, "');" };
                    attributeCollection1.Add("onclick", string.Concat(strArrays1));
                    AttributeCollection attributes2 = label1.Attributes;
                    string[] value2 = new string[] { "javascript:DisplaySummaryPopUp('", hiddenField3.Value, "','2','", empty, "','", hiddenField4.Value, "','", this.isView, "','", hiddenField5.Value, "');" };
                    attributes2.Add("onclick", string.Concat(value2));
                }catch(Exception ex)
                {

                }
            }
            if (e.Item.ItemType == GridItemType.FilteringItem)
            {
                ((GridFilteringItem)e.Item)["EstimateValue"].HorizontalAlign = HorizontalAlign.Right;
                TextBox str = (e.Item as GridFilteringItem)["ConvertedDate"].Controls[0] as TextBox;
                string regionalSettings = this.objPage.GetRegionalSettings(this.CompanyID, "Dateformat");
                if (base.Session["CRMDateFilterJob"] != null && regionalSettings == "dd/mm/yyyy")
                {
                    str.Text = base.Session["CRMDateFilterJob"].ToString();
                }
            }
        }
    }
}
