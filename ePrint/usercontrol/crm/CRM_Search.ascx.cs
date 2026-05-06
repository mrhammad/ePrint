using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.crm
{
    public partial class CRM_Search : System.Web.UI.UserControl
    {
        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        private commonClass objJava = new commonClass();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private Global gloobj = new Global();

        private createViewClass objCreateView = new createViewClass();

        public languageClass objLang = new languageClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int totalrec;

        public int defaultviewid;

        private string para = "";

        public string pg;

        public string companytype = string.Empty;

        public string tabcolor = string.Empty;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string CrmHeader = string.Empty;

        public string WhereCondition = string.Empty;

        public int PageSize;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public string newdate = string.Empty;

        public string ViewName = "crm_customer_view";

        public string web_key = string.Empty;

        public string strRedirect = string.Empty;

        private DataTable dtsearch = new DataTable();

        public DataTable dt = new DataTable();

        public string crmHeaderPanel = string.Empty;

        public string crmContentPanel = string.Empty;

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int custreturnnoRec;

        public int CRMCustomercount;

        public int CRMSuppliercount;

        public int CRMprospectcount;

        public bool Istype;

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

        public CRM_Search()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.grvCRMSearch.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                }
                for (int j = 0; j < this.grvCRMSearch.Columns.Count; j++)
                {
                    this.grvCRMSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.grvCRMSearch.Columns[j].HeaderStyle.Wrap = false;
                    this.grvCRMSearch.Columns[j].CurrentFilterFunction = GridKnownFunction.Contains;
                    if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "name")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Name");
                        this.grvCRMSearch.Columns[j].ItemStyle.Wrap = false;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "type")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Type");
                        this.grvCRMSearch.Columns[j].ItemStyle.Wrap = false;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Account_Status");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "accountnumber")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Account_Number");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "businesstelephone")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Dept_Phone");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "fax")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Busniess_Fax");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "businessemail")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Business_Email");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "storename")
                    {
                        if (this.web_key.ToLower().Trim() != "yes")
                        {
                            this.grvCRMSearch.Columns[j].Visible = false;
                        }
                        else if (this.companytype.ToLower().Trim() != "customer")
                        {
                            this.grvCRMSearch.Columns[j].Visible = false;
                        }
                        else
                        {
                            this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Store_Name");
                        }
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Referred_BY");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Payment_Terms");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Sales_Person");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "defaultcontactjobtitle1")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("DefaultConatct_JobTitle1");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "defaultcontactjobtitle2")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("DefaultConatct_JobTitle2");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "defaultcontactemail")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Default_Contact_Email");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "defaultdepartmentname")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Default_Department_Name");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "defaultcontactname")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.objLang.GetLanguageConversion("Default_Contact_Name");
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "address1")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.hdnaddress1.Value;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "address2")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.hdnaddress2.Value;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "address3")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.hdnaddress3.Value;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "address4")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.hdnaddress4.Value;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "address5")
                    {
                        this.grvCRMSearch.Columns[j].HeaderText = this.hdnaddress5.Value;
                    }
                    else if (this.grvCRMSearch.Columns[j].SortExpression.ToLower() == "isaccountonhold")
                    {
                        this.grvCRMSearch.Columns[j].Visible = false;
                    }
                }
            }
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textBox = (TextBox)this.Page.Master.FindControl("keywordsearch");
            if (textBox.Text != "")
            {
                this.para = textBox.Text;
                this.GridBind(this.CompanyID, this.UserID, this.grvCRMSearch.PageSize, 1, this.defaultviewid, "name", "desc", this.para, this.ViewState["WhereCondition"].ToString());
            }
        }

        private string GetSortDirection(string column)
        {
            string str = "ASC";
            string item = this.ViewState["SortExpression"] as string;
            if (item != null && item == column)
            {
                string item1 = this.ViewState["SortDirection"] as string;
                if (item1 != null && item1 == "ASC")
                {
                    str = "DESC";
                }
            }
            this.ViewState["SortDirection"] = str;
            this.ViewState["SortExpression"] = column;
            return str;
        }

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para, string para_new)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView_ForSearch(CompanyID, UserID, PageSize, PageNumber, this.companytype, ViewID, SortedBy, SortDirection, para, para_new);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@strSQL", empty);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                dataSet.Tables[0].Columns[i].ReadOnly = false;
            }
            if (dataSet.Tables[0] != null)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row.Table.Columns.Contains("Name"))
                    {
                        row["Name"] = this.objBase.SpecialDecode(row["Name"].ToString());
                    }
                    if (row.Table.Columns.Contains("SalesPerson"))
                    {
                        row["SalesPerson"] = this.objBase.SpecialDecode(row["SalesPerson"].ToString());
                    }
                    if (row.Table.Columns.Contains("Type"))
                    {
                        row["Type"] = this.objBase.SpecialDecode(row["Type"].ToString());
                        this.Istype = true;
                    }
                    if (row.Table.Columns.Contains("AccountStatus"))
                    {
                        row["AccountStatus"] = this.objBase.SpecialDecode(row["AccountStatus"].ToString());
                    }
                    if (row.Table.Columns.Contains("BusniessTelephone"))
                    {
                        row["BusniessTelephone"] = this.objBase.SpecialDecode(row["BusniessTelephone"].ToString());
                    }
                    if (row.Table.Columns.Contains("AccountNumber"))
                    {
                        row["AccountNumber"] = this.objBase.SpecialDecode(row["AccountNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("StoreName"))
                    {
                        row["StoreName"] = this.objBase.SpecialDecode(row["StoreName"].ToString());
                    }
                    if (row.Table.Columns.Contains("BusinessEmail"))
                    {
                        row["BusinessEmail"] = this.objBase.SpecialDecode(row["BusinessEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("ReferredBy"))
                    {
                        row["ReferredBy"] = this.objBase.SpecialDecode(row["ReferredBy"].ToString());
                    }
                    if (row.Table.Columns.Contains("PaymentTerms"))
                    {
                        row["PaymentTerms"] = this.objBase.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("DefaultContactJobTitle1"))
                    {
                        row["DefaultContactJobTitle1"] = this.objBase.SpecialDecode(row["DefaultContactJobTitle1"].ToString());
                    }
                    if (row.Table.Columns.Contains("DefaultContactJobTitle2"))
                    {
                        row["DefaultContactJobTitle2"] = this.objBase.SpecialDecode(row["DefaultContactJobTitle2"].ToString());
                    }
                    if (row.Table.Columns.Contains("DefaultContactEmail"))
                    {
                        row["DefaultContactEmail"] = this.objBase.SpecialDecode(row["DefaultContactEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("DefaultDepartmentName"))
                    {
                        row["DefaultDepartmentName"] = this.objBase.SpecialDecode(row["DefaultDepartmentName"].ToString());
                    }
                    if (row.Table.Columns.Contains("DefaultContactName"))
                    {
                        row["DefaultContactName"] = this.objBase.SpecialDecode(row["DefaultContactName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address1"))
                    {
                        row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address2"))
                    {
                        row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address3"))
                    {
                        row["Address3"] = this.objBase.SpecialDecode(row["Address3"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address4"))
                    {
                        row["Address4"] = this.objBase.SpecialDecode(row["Address4"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Address5"))
                    {
                        continue;
                    }
                    row["Address5"] = this.objBase.SpecialDecode(row["Address5"].ToString());
                }
            }
            this.grvCRMSearch.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.grvCRMSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvCRMSearch.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.grvCRMSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvCRMSearch.AllowCustomPaging = true;
                this.grvCRMSearch.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.companytype.ToLower() == "customer")
                {
                    this.CRMCustomercount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                    if (this.GetPageCount != null)
                    {
                        this.GetPageCount(this.CRMCustomercount);
                    }
                }
                if (this.companytype.ToLower() == "supplier")
                {
                    this.CRMSuppliercount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                    if (this.GetPageCount != null)
                    {
                        this.GetPageCount(this.CRMSuppliercount);
                    }
                }
                if (this.companytype.ToLower() == "prospect")
                {
                    this.CRMprospectcount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                    if (this.GetPageCount != null)
                    {
                        this.GetPageCount(this.CRMprospectcount);
                        return;
                    }
                }
            }
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.grvCRMSearch, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.grvCRMSearch);
        }

        protected void grvCRMSearch_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void grvCRMSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.companytype.ToLower() == "customer")
                {
                    if (base.Session["searchCust"] == null)
                    {
                        this.dtsearch.Columns.Add("ColumnName");
                        this.dtsearch.Columns.Add("Filter");
                        this.dtsearch.Columns.Add("FilterText");
                    }
                    if (base.Session["searchCust"] != null)
                    {
                        this.dtsearch = (DataTable)base.Session["searchCust"];
                    }
                }
                else if (this.companytype.ToLower() == "supplier")
                {
                    if (base.Session["searchSupp"] == null)
                    {
                        this.dtsearch.Columns.Add("ColumnName");
                        this.dtsearch.Columns.Add("Filter");
                        this.dtsearch.Columns.Add("FilterText");
                    }
                    if (base.Session["searchSupp"] != null)
                    {
                        this.dtsearch = (DataTable)base.Session["searchSupp"];
                    }
                }
                else if (this.companytype.ToLower() == "prospect")
                {
                    if (base.Session["searchPros"] == null)
                    {
                        this.dtsearch.Columns.Add("ColumnName");
                        this.dtsearch.Columns.Add("Filter");
                        this.dtsearch.Columns.Add("FilterText");
                    }
                    if (base.Session["searchPros"] != null)
                    {
                        this.dtsearch = (DataTable)base.Session["searchPros"];
                    }
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(second);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                if (this.companytype.ToLower() == "customer")
                {
                    base.Session["searchCust"] = this.dtsearch;
                }
                else if (this.companytype.ToLower() == "supplier")
                {
                    base.Session["searchSupp"] = this.dtsearch;
                }
                else if (this.companytype.ToLower() == "prospect")
                {
                    base.Session["searchPros"] = this.dtsearch;
                }
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.grvCRMSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.grvCRMSearch.Rebind();
            }
        }

        protected void grvCRMSearch_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvCRMSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvCRMSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvCRMSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvCRMSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.grvCRMSearch.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void grvCRMSearch_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.grvCRMSearch.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.grvCRMSearch.PageSize, this.grvCRMSearch.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void grvCRMSearch_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            this.SortedBy = e.SortExpression;
            this.sortdirection = e.NewSortOrder.ToString();
            if (this.sortdirection.ToLower() == "ascending")
            {
                this.sortdirection = "ASC";
            }
            else if (this.sortdirection.ToLower() != "descending")
            {
                this.sortdirection = "ASC";
            }
            else
            {
                this.sortdirection = "DESC";
            }
            this.grvCRMSearch.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.grvCRMSearch.PageSize, this.grvCRMSearch.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_grvCRMSearch(object sender, GridItemEventArgs e)
        {
            bool flag = true;
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                QueryString queryString = new QueryString()
			{
				{ "clientid", ((DataRowView)e.Item.DataItem)[0].ToString() },
				{ "isnew", "2" },
				{ "bypass", "1" },
				{ "type", this.companytype }
			};
                this.strRedirect = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                CRM_Search usercontrolCrmCRMSearch = this;
                usercontrolCrmCRMSearch.strRedirect = string.Concat(usercontrolCrmCRMSearch.strRedirect, queryString1.ToString());
                GridDataItem item = (GridDataItem)e.Item;
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                string empty = string.Empty;
                string languageConversion = string.Empty;
                empty = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion = this.objLang.GetLanguageConversion("Account_On_Hold");
                string str = this.strRedirect;
                item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                item.Style.Add("cursor", "pointer");
                if (this.companytype.ToLower() != "customer")
                {
                    TableCell tableCell = item["name"];
                    string[] strArrays = new string[] { "<a style='color:#10357F;' href=", this.strRedirect, ">", ((DataRowView)e.Item.DataItem)[1].ToString(), "</a>" };
                    tableCell.Text = string.Concat(strArrays);
                    item["name"].Width = Unit.Pixel(180);
                    if (this.Istype)
                    {
                        if (item["type"].Text != "&nbsp;")
                        {
                            item["type"].ToolTip = item["type"].Text;
                        }
                        if (item["type"].Text.Trim().Length > 20)
                        {
                            item["type"].Text = string.Concat(item["type"].Text.Substring(0, 20), "...");
                        }
                    }
                }
                else
                {
                    DataTable dataTable = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(((DataRowView)e.Item.DataItem)[0].ToString()), this.companytype);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.AccountID = Convert.ToInt32(row["AccountID"].ToString());
                        if (this.AccountID == 0)
                        {
                            flag = false;
                        }
                        else
                        {
                            TableCell item1 = item["name"];
                            string[] strArrays1 = new string[] { "<a href=", this.strRedirect, "> <img alt='' src='", this.strImagepath, "e_icon.gif' border='0' title='eStore Account' style='height:13px; width:13px; margin:3px 2px -2px -19px'>&nbsp;</a>" };
                            item1.Text = string.Concat(strArrays1);
                        }
                    }
                    if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                    {
                        ControlCollection controls = placeHolder.Controls;
                        string[] strArrays2 = new string[] { "<img src='", empty, "'  title='", languageConversion, "' class='viewicon_margin'  style='margin:7px;'/>" };
                        controls.Add(new LiteralControl(string.Concat(strArrays2)));
                    }
                    if (flag)
                    {
                        TableCell tableCell1 = item["name"];
                        string text = tableCell1.Text;
                        string[] str1 = new string[] { text, "<a style='color:#10357F;' href=", this.strRedirect, ">", ((DataRowView)e.Item.DataItem)[1].ToString(), "</a>" };
                        tableCell1.Text = string.Concat(str1);
                        item["name"].Width = Unit.Pixel(180);
                        if (this.Istype)
                        {
                            if (item["type"].Text != "&nbsp;")
                            {
                                item["type"].ToolTip = item["type"].Text;
                            }
                            if (item["type"].Text.Trim().Length > 20)
                            {
                                item["type"].Text = string.Concat(item["type"].Text.Substring(0, 20), "...");
                                return;
                            }
                        }
                    }
                    else
                    {
                        TableCell item2 = item["name"];
                        string[] str2 = new string[] { "<a style='color:#10357F;' href=", this.strRedirect, ">", ((DataRowView)e.Item.DataItem)[1].ToString(), "</a>" };
                        item2.Text = string.Concat(str2);
                        item["name"].Width = Unit.Pixel(180);
                        if (this.Istype)
                        {
                            if (item["type"].Text != "&nbsp;")
                            {
                                item["type"].ToolTip = item["type"].Text;
                            }
                            if (item["type"].Text.Trim().Length > 20)
                            {
                                item["type"].Text = string.Concat(item["type"].Text.Substring(0, 20), "...");
                                return;
                            }
                        }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            try
            {
                this.companytype = base.Request.Params["type"].ToString();
            }
            catch
            {
            }
            if (ConnectionClass.WebStore != null)
            {
                this.web_key = ConnectionClass.WebStore;
            }
            global.pageName = "Client";
            this.gloobj.setpagename("Client");
            languageClass _languageClass = new languageClass();
            this.grvCRMSearch.MasterTableView.NoMasterRecordsText = _languageClass.GetLanguageConversion("No_records_To_Display");
            this.Page.Title = _languageClass.convert(global.pageTitle(string.Concat(this.objBase.ReturnScreenName("CLIENTS", 2, "p").ToUpper(), " View"), int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            if (this.companytype.ToLower() == "customer")
            {
                this.pg = "customer_search";
                base.Session.Add("flage", 0);
                this.CrmHeader = "Customer Details";
                this.crmHeaderPanel = "Customer";
                this.crmContentPanel = "Customer";
            }
            else if (this.companytype.ToLower() != "supplier")
            {
                this.pg = "prospect_search";
                base.Session.Add("flage", 1);
                this.CrmHeader = "Prospect Details";
                this.crmHeaderPanel = "Prospect";
                this.crmContentPanel = "Prospect";
            }
            else
            {
                this.pg = "supplier_search";
                base.Session.Add("flage", 0);
                this.CrmHeader = "Supplier Details";
                this.crmHeaderPanel = "Supplier";
                this.crmContentPanel = "Supplier";
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyid"]), "client");
            if (this.companytype.ToLower() == "customer")
            {
                this.ViewName = "crm_customer_view";
            }
            else if (this.companytype.ToLower() == "supplier")
            {
                this.ViewName = "crm_supplier_view";
            }
            else if (this.companytype.ToLower() == "prospect")
            {
                this.ViewName = "crm_prospect_view";
            }
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, this.ViewName);
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.companytype.ToLower() == "customer")
            {
                if (base.Session["CustViewID"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Session["CustViewID"]);
                }
            }
            else if (this.companytype.ToLower() == "supplier")
            {
                if (base.Session["SuppViewID"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Session["SuppViewID"]);
                }
            }
            else if (this.companytype.ToLower() == "prospect" && base.Session["ProsViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["ProsViewID"]);
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row in this.objcomp.Clientaddresslabels(this.CompanyID).Rows)
                {
                    if (row["addresslkey"].ToString().ToLower() == "address1")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress1.Value = this.objLang.GetLanguageConversion("Address1");
                        }
                        else
                        {
                            this.hdnaddress1.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address2")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress2.Value = this.objLang.GetLanguageConversion("Address2");
                        }
                        else
                        {
                            this.hdnaddress2.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address3")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress3.Value = this.objLang.GetLanguageConversion("Address3");
                        }
                        else
                        {
                            this.hdnaddress3.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address4")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress4.Value = this.objLang.GetLanguageConversion("Address4");
                        }
                        else
                        {
                            this.hdnaddress4.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() != "address5")
                    {
                        continue;
                    }
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.hdnaddress5.Value = this.objLang.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = row["addressvalue"].ToString();
                    }
                }
            }
            if (!base.IsPostBack)
            {
                this.grvCRMSearch.PageSize = 50;
                if (base.Request.QueryString["viewid"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                    string str1 = string.Concat(this.pg, this.UserID, this.pg);
                    base.Session[str1] = null;
                    if (this.companytype.ToLower() == "customer")
                    {
                        base.Session["searchCust"] = null;
                        base.Session["CustViewID"] = this.defaultviewid;
                    }
                    else if (this.companytype.ToLower() == "supplier")
                    {
                        base.Session["searchSupp"] = null;
                        base.Session["SuppViewID"] = this.defaultviewid;
                    }
                    else if (this.companytype.ToLower() == "prospect")
                    {
                        base.Session["searchPros"] = null;
                        base.Session["ProsViewID"] = this.defaultviewid;
                    }
                }
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, this.companytype);
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow dataRow in this.dt.Rows)
                {
                    this.defaultsortedby = dataRow["SortedBy"].ToString();
                    this.defaultsortdirection = dataRow["SortDirection"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                if (this.defaultsortedby == "")
                {
                    this.SortedBy = "Name";
                }
                else
                {
                    this.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    this.sortdirection = "ASC";
                }
                else if (this.defaultsortdirection != "")
                {
                    this.sortdirection = this.defaultsortdirection;
                }
                this.WhereCondition = "";
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            if (!base.IsPostBack)
            {
                string str2 = "";
                string str3 = "";
                if (base.Request.Params["srch_val"] != null)
                {
                    BaseClass baseClass1 = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str4 = baseClass1.SpecialEncode(item.Split(chrArray)[0].ToString());
                    if (this.companytype.ToLower() != "customer")
                    {
                        string[] strArrays = new string[] { " AND(Name LIKE '%", str4, "%' OR Type LIKE '%", str4, "%' OR AccountStatus LIKE '%", str4, "%' OR Description LIKE '%", str4, "%' OR PaymentTerms LIKE '%", str4, "%' OR AccountName LIKE '%", str4, "%' OR SalesPerson LIKE '%", str4, "%' OR DefaultContactJobTitle1 LIKE '%", str4, "%' OR DefaultContactJobTitle2 LIKE '%", str4, "%' OR Referredby LIKE '%", str4, "%')" };
                        str3 = string.Concat(strArrays);
                        this.ViewState["WhereCondition"] = str3;
                    }
                    else
                    {
                        string[] strArrays1 = new string[] { " AND(Name LIKE '%", str4, "%' OR Type LIKE '%", str4, "%' OR AccountStatus LIKE '%", str4, "%' OR Description LIKE '%", str4, "%' OR PaymentTerms LIKE '%", str4, "%' OR AccountName LIKE '%", str4, "%' OR SalesPerson LIKE '%", str4, "%' OR DefaultContactJobTitle1 LIKE '%", str4, "%' OR DefaultContactJobTitle2 LIKE '%", str4, "%' OR ((Address1 + ' ' + Address2 + ' ' + Address3 + ' ' + Address4 + ' ' + Address5) LIKE '%", str4, "%') OR Referredby LIKE '%", str4, "%')" };
                        str3 = string.Concat(strArrays1);
                        this.ViewState["WhereCondition"] = str3;
                    }
                }
                this.GridStateLoad();
                if (this.companytype.ToLower() == "customer")
                {
                    if (base.Session["searchCust"] != null)
                    {
                        DataTable dataTable = (DataTable)base.Session["searchCust"];
                        str2 = "";
                    }
                    base.Session["CustViewID"] = this.defaultviewid;
                }
                else if (this.companytype.ToLower() == "supplier")
                {
                    if (base.Session["searchSupp"] != null)
                    {
                        DataTable item1 = (DataTable)base.Session["searchSupp"];
                        str2 = "";
                    }
                    base.Session["SuppViewID"] = this.defaultviewid;
                }
                else if (this.companytype.ToLower() == "prospect")
                {
                    if (base.Session["searchPros"] != null)
                    {
                        DataTable dataTable1 = (DataTable)base.Session["searchPros"];
                        str2 = "";
                    }
                    base.Session["ProsViewID"] = this.defaultviewid;
                }
                this.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.grvCRMSearch);
                this.grvCRMSearch.PageSize = this.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.grvCRMSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.grvCRMSearch.Rebind();
            }
            this.grvCRMSearch.MasterTableView.GetColumn("ClientID").Visible = false;
        }

        public event GetQueryCount GetPageCount;
    }
}