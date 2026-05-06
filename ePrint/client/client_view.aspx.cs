using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.client
{
    public partial class client_view : BaseClass, IRequiresSessionState
    {
        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        private commonClass objJava = new commonClass();

        private Global gloobj = new Global();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private createViewClass objCreateView = new createViewClass();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int totalrec;

        public int defaultviewid;

        private string para = "";

        public string pg;

        public string companytype = "Customer";

        public string tabcolor = string.Empty;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string CrmHeader = string.Empty;

        public static string WhereCondition;

        public static int PageSize;

        public static string sortdirection;

        public static string SortedBy;

        public string newdate = string.Empty;

        public static string ViewName;

        public string web_key = string.Empty;

        public string strRedirect = string.Empty;

        private DataTable dtsearch = new DataTable();

        public DataTable dt = new DataTable();

        public int ViewID;

        public bool Istype;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        static client_view()
        {
            client_view.WhereCondition = string.Empty;
            client_view.PageSize = 50;
            client_view.sortdirection = string.Empty;
            client_view.SortedBy = string.Empty;
            client_view.ViewName = "crm_customer_view";
        }

        public client_view()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridView1.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                }
                for (int j = 0; j < this.GridView1.Columns.Count; j++)
                {
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridView1.Columns[j].HeaderStyle.Wrap = false;
                    this.GridView1.Columns[j].CurrentFilterFunction = GridKnownFunction.Contains;
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "name")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Name");
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "type")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Type");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Account_Status");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Account_Number");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "businesstelephone")
                    {
                        if (this.companytype.ToLower().Trim() != "customer")
                        {
                            this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Business_Telephone");
                        }
                        else
                        {
                            this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Dept_Phone");
                        }
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "fax")
                    {
                        this.GridView1.Columns[j].HeaderText = "Business Fax";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "businessemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Business_Email");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Referred_BY");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "storename")
                    {
                        if (this.web_key.ToLower().Trim() != "yes")
                        {
                            this.GridView1.Columns[j].Visible = false;
                        }
                        else if (this.companytype.ToLower().Trim() != "customer")
                        {
                            this.GridView1.Columns[j].Visible = false;
                        }
                        else
                        {
                            this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Store_Name");
                        }
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Payment_Terms");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultcontactemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_Email");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultdepartmentname")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Default_Department_Name");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultcontactname")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_Name");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultcontactphone") //modifications by bilal ticket # 7909
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_Phone");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultcontactmobile") //modifications by bilal ticket # 7909
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Default_Contact_Mobile");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address1")
                    {
                        this.GridView1.Columns[j].HeaderText = this.hdnaddress1.Value;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address2")
                    {
                        this.GridView1.Columns[j].HeaderText = this.hdnaddress2.Value;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address3")
                    {
                        this.GridView1.Columns[j].HeaderText = this.hdnaddress3.Value;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address4")
                    {
                        this.GridView1.Columns[j].HeaderText = this.hdnaddress4.Value;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address5")
                    {
                        this.GridView1.Columns[j].HeaderText = this.hdnaddress5.Value;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultcontactjobtitle1")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("DefaultConatct_JobTitle1");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaultcontactjobtitle2")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("DefaultConatct_JobTitle2");
                    }
                }
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            client_view.WhereCondition = "";
            if (this.companytype.ToLower() == "customer")
            {
                this.Session["searchCust"] = null;
            }
            else if (this.companytype.ToLower() == "supplier")
            {
                this.Session["searchSupp"] = null;
            }
            else if (this.companytype.ToLower() == "prospect")
            {
                this.Session["searchPros"] = null;
            }
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, client_view.SortedBy, client_view.sortdirection, client_view.WhereCondition);
            this.GridView1.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View_cust.SelectedValue);
            num = Convert.ToInt32(this.ddl_View_cust.SelectedIndex);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "client/client_view.aspx?type=", this.companytype, "&viewid=", num1, "&index=", num };
            response.Redirect(string.Concat(objArray));
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
            if (this.companytype.ToLower() == "customer")
            {
                this.Session["searchCust"] = dtsearch;
            }
            else if (this.companytype.ToLower() == "supplier")
            {
                this.Session["searchSupp"] = dtsearch;
            }
            else if (this.companytype.ToLower() == "prospect")
            {
                this.Session["searchPros"] = dtsearch;
            }
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && client_view.WhereCondition != "")
                {
                    client_view.WhereCondition = string.Concat(client_view.WhereCondition, " and ");
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
                            string whereCondition = client_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", dataRow["ColumnName"].ToString(), " like '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = client_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", dataRow["ColumnName"].ToString(), " like '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            client_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            string whereCondition2 = client_view.WhereCondition;
                            string[] str2 = new string[] { whereCondition2, " ", dataRow["ColumnName"].ToString(), " = '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            client_view.WhereCondition = string.Concat(str2);
                            continue;
                        }
                    case 3:
                        {
                            string whereCondition3 = client_view.WhereCondition;
                            string[] strArrays2 = new string[] { whereCondition3, " ", dataRow["ColumnName"].ToString(), " != '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            client_view.WhereCondition = string.Concat(strArrays2);
                            continue;
                        }
                    case 4:
                        {
                            string str3 = client_view.WhereCondition;
                            string[] strArrays3 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(strArrays3);
                            continue;
                        }
                    case 5:
                        {
                            string whereCondition4 = client_view.WhereCondition;
                            string[] str4 = new string[] { whereCondition4, " ", dataRow["ColumnName"].ToString(), " not like '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(str4);
                            continue;
                        }
                    case 6:
                        {
                            string whereCondition5 = client_view.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition5, " ", dataRow["ColumnName"].ToString(), " > '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 7:
                        {
                            string str5 = client_view.WhereCondition;
                            string[] strArrays5 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " < '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(strArrays5);
                            continue;
                        }
                    case 8:
                        {
                            string whereCondition6 = client_view.WhereCondition;
                            string[] str6 = new string[] { whereCondition6, " ", dataRow["ColumnName"].ToString(), " >= '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(str6);
                            continue;
                        }
                    case 9:
                        {
                            string whereCondition7 = client_view.WhereCondition;
                            string[] strArrays6 = new string[] { whereCondition7, " ", dataRow["ColumnName"].ToString(), " <= '%", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "%'" };
                            client_view.WhereCondition = string.Concat(strArrays6);
                            continue;
                        }
                    case 10:
                        {
                            client_view.WhereCondition = string.Concat(client_view.WhereCondition, " ", dataRow["ColumnName"].ToString(), " = ''");
                            continue;
                        }
                    case 11:
                        {
                            client_view.WhereCondition = string.Concat(client_view.WhereCondition, " ", dataRow["ColumnName"].ToString(), " != ''");
                            continue;
                        }
                    case 12:
                        {
                            client_view.WhereCondition = string.Concat(client_view.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is null");
                            continue;
                        }
                    case 13:
                        {
                            client_view.WhereCondition = string.Concat(client_view.WhereCondition, " ", dataRow["ColumnName"].ToString(), " is not null");
                            continue;
                        }
                    case 14:
                        {
                            string str7 = client_view.WhereCondition;
                            string[] strArrays7 = new string[] { str7, " ", dataRow["ColumnName"].ToString(), " between '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "' and '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            client_view.WhereCondition = string.Concat(strArrays7);
                            continue;
                        }
                    case 15:
                        {
                            string whereCondition8 = client_view.WhereCondition;
                            string[] str8 = new string[] { whereCondition8, " ", dataRow["ColumnName"].ToString(), " not between '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "' and '", this.objBase.SpecialEncode(dataRow["FilterText"].ToString().Trim()), "'" };
                            client_view.WhereCondition = string.Concat(str8);
                            continue;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return client_view.WhereCondition;
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

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
        {
            this.Session["crmdefaultviewid"] = ViewID;
            this.Session["crmsortby"] = SortedBy;
            this.Session["crmsortdirection"] = SortDirection;
            this.Session["crmpara"] = para;
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, this.companytype, ViewID, SortedBy, SortDirection, para);
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
            DataTable item = dataSet.Tables[0];
            this.GridView1.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridView1);
                this.div_Main.Style.Add("display", "block");
                this.GridView1.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns(dataSet.Tables[0], this.GridView1);
            this.div_Main.Style.Add("display", "block");
            this.GridView1.AllowCustomPaging = true;
            this.GridView1.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                client_view.WhereCondition = "";
                if (this.companytype.ToLower() == "customer")
                {
                    if (this.Session["searchCust"] == null)
                    {
                        this.dtsearch.Columns.Add("ColumnName");
                        this.dtsearch.Columns.Add("Filter");
                        this.dtsearch.Columns.Add("FilterText");
                    }
                    if (this.Session["searchCust"] != null)
                    {
                        this.dtsearch = (DataTable)this.Session["searchCust"];
                    }
                }
                else if (this.companytype.ToLower() == "supplier")
                {
                    if (this.Session["searchSupp"] == null)
                    {
                        this.dtsearch.Columns.Add("ColumnName");
                        this.dtsearch.Columns.Add("Filter");
                        this.dtsearch.Columns.Add("FilterText");
                    }
                    if (this.Session["searchSupp"] != null)
                    {
                        this.dtsearch = (DataTable)this.Session["searchSupp"];
                    }
                }
                else if (this.companytype.ToLower() == "prospect")
                {
                    if (this.Session["searchPros"] == null)
                    {
                        this.dtsearch.Columns.Add("ColumnName");
                        this.dtsearch.Columns.Add("Filter");
                        this.dtsearch.Columns.Add("FilterText");
                    }
                    if (this.Session["searchPros"] != null)
                    {
                        this.dtsearch = (DataTable)this.Session["searchPros"];
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
                    this.Session["searchCust"] = this.dtsearch;
                }
                else if (this.companytype.ToLower() == "supplier")
                {
                    this.Session["searchSupp"] = this.dtsearch;
                }
                else if (this.companytype.ToLower() == "prospect")
                {
                    this.Session["searchPros"] = this.dtsearch;
                }
                client_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, client_view.SortedBy, client_view.sortdirection, client_view.WhereCondition);
                this.GridView1.Rebind();
            }
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View_cust.SelectedValue), client_view.SortedBy, client_view.sortdirection, client_view.WhereCondition);
        }

        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            client_view.SortedBy = e.SortExpression;
            client_view.sortdirection = e.NewSortOrder.ToString();
            if (client_view.sortdirection.ToLower() == "ascending")
            {
                client_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (client_view.sortdirection.ToLower() != "descending")
            {
                client_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                client_view.sortdirection = "DESC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridView1.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View_cust.SelectedValue), e.SortExpression, client_view.sortdirection, client_view.WhereCondition);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
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
                        case "nofilter":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                                break;
                            }
                        case "contains":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                                break;
                            }
                        case "doesnotcontain":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                                break;
                            }
                        case "startswith":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                                break;
                            }
                        case "EndsWith":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                                break;
                            }
                        case "equalto":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                                break;
                            }
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
            }
            PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
            string empty = string.Empty;
            string languageConversion = string.Empty;
            empty = string.Concat(this.strImagepath, "AccountOnHold.png");
            languageConversion = this.objLanguage.GetLanguageConversion("Account_On_Hold");
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                this.Session["UniqueID"] = null;
                this.Session["Type"] = null;
                QueryString queryString = new QueryString()
			{
				{ "clientid", ((DataRowView)e.Item.DataItem)[0].ToString() },
				{ "isnew", "2" },
				{ "bypass", "1" },
				{ "type", this.companytype }
			};
                this.strRedirect = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                client_view clientClientView = this;
                clientClientView.strRedirect = string.Concat(clientClientView.strRedirect, queryString1.ToString());
                GridDataItem item = (GridDataItem)e.Item;
                string str = this.strRedirect;
                item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                item.Style.Add("cursor", "pointer");
                TableCell tableCell = item["name"];
                string[] text = new string[] { "<a style='color:#10357F;' href=", this.strRedirect, ">", item["name"].Text, "</a>" };
                tableCell.Text = string.Concat(text);
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
                if (this.companytype.ToLower() == "customer")
                {
                    this.AccountID = Convert.ToInt32(((DataRowView)e.Item.DataItem)[(int)((DataRowView)e.Item.DataItem).Row.ItemArray.Length - 2].ToString());
                    if (this.AccountID != 0)
                    {
                        TableCell item1 = item.Cells[4];
                        string[] imgPath = new string[] { "<a href=", this.strRedirect, "> <img alt='' src='", this.ImgPath, "e_icon.gif' border='0' title='eStore Account' style='height:13px; width:13px; margin:3px 2px -2px -19px'>&nbsp;</a>", item.Cells[4].Text };
                        item1.Text = string.Concat(imgPath);
                    }
                    if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                    {
                        ControlCollection controls = placeHolder.Controls;
                        string[] strArrays = new string[] { "<img src='", empty, "'  title='", languageConversion, "' class='viewicon_margin' style='margin:7px;'/>" };
                        controls.Add(new LiteralControl(string.Concat(strArrays)));
                    }
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label label = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objLangClass.GetLanguageConversion("No_records_to_display");
            this.objBase.ReturnRoles_Privileges_Tabs("clients", "isview", "");
            this.companyid = Convert.ToInt32(this.Session["CompanyID"]);
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            try
            {
                if(base.Request.Params["type"] != null)
                {
                    this.companytype = base.Request.Params["type"].ToString();
                }
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
            base.Title = _languageClass.convert(global.pageTitle(string.Concat(this.objBase.ReturnScreenName("CLIENTS", 2, "p").ToUpper(), " View"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            if (this.companytype.ToLower() == "customer")
            {
                this.pg = "customer";
                this.Session.Add("flage", 0);
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Customer_View")));
                this.CrmHeader = this.objLangClass.GetLanguageConversion("Customer_Details");
            }
            else if (this.companytype.ToLower() != "supplier")
            {
                this.pg = "prospect";
                this.Session.Add("flage", 1);
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Prospect_View")));
                this.CrmHeader = this.objLangClass.GetLanguageConversion("Prospect_Details");
            }
            else
            {
                this.pg = "supplier";
                this.Session.Add("flage", 0);
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Supplier_View")));
                this.CrmHeader = this.objLangClass.GetLanguageConversion("Supplier_Details");
            }
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.tabcolor = this.objpage.colorCode(Convert.ToInt32(this.Session["companyid"]), "client");
            if (this.companytype.ToLower() == "customer")
            {
                client_view.ViewName = "crm_customer_view";
            }
            else if (this.companytype.ToLower() == "supplier")
            {
                client_view.ViewName = "crm_supplier_view";
            }
            else if (this.companytype.ToLower() == "prospect")
            {
                client_view.ViewName = "crm_prospect_view";
            }
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, client_view.ViewName);
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.companytype.ToLower() == "customer")
            {
                if (this.Session["CustViewID"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(this.Session["CustViewID"]);
                }
            }
            else if (this.companytype.ToLower() == "supplier")
            {
                if (this.Session["SuppViewID"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(this.Session["SuppViewID"]);
                }
            }
            else if (this.companytype.ToLower() == "prospect" && this.Session["ProsViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["ProsViewID"]);
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row in this.objcomp.Clientaddresslabels(this.CompanyID).Rows)
                {
                    if (row["addresslkey"].ToString().ToLower() == "address1")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress1.Value = this.objLangClass.GetLanguageConversion("Address1");
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
                            this.hdnaddress2.Value = this.objLangClass.GetLanguageConversion("Address2");
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
                            this.hdnaddress3.Value = this.objLangClass.GetLanguageConversion("Address3");
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
                            this.hdnaddress4.Value = this.objLangClass.GetLanguageConversion("Address4");
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
                        this.hdnaddress5.Value = this.objLangClass.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = row["addressvalue"].ToString();
                    }
                }
            }
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["viewid"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                    string str1 = string.Concat(this.pg, this.UserID, this.pg);
                    this.Session[str1] = null;
                    if (this.companytype.ToLower() == "customer")
                    {
                        this.Session["searchCust"] = null;
                        this.Session["CustViewID"] = this.defaultviewid;
                    }
                    else if (this.companytype.ToLower() == "supplier")
                    {
                        this.Session["searchSupp"] = null;
                        this.Session["SuppViewID"] = this.defaultviewid;
                    }
                    else if (this.companytype.ToLower() == "prospect")
                    {
                        this.Session["searchPros"] = null;
                        this.Session["ProsViewID"] = this.defaultviewid;
                    }
                }
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView(this.companytype, this.CompanyID, this.ddl_View_cust, Convert.ToInt32(base.Request.Params["ViewID"]));
                    int num = 0;
                    while (num < this.ddl_View_cust.Items.Count)
                    {
                        if (this.ddl_View_cust.Items[num].Value != this.ViewID.ToString())
                        {
                            num++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View_cust, this.ddl_View_cust.Items[num].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View_cust.SelectedItem.Text;
                }
                else if (this.defaultviewid == 0)
                {
                    this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, this.companytype);
                    if (this.dt.Rows.Count != 0)
                    {
                        foreach (DataRow dataRow in this.dt.Rows)
                        {
                            this.defaultviewid = Convert.ToInt32(dataRow["ViewID"].ToString());
                        }
                    }
                    this.objCreateView.BindCustomView(this.companytype, this.CompanyID, this.ddl_View_cust);
                    int num1 = 0;
                    while (num1 < this.ddl_View_cust.Items.Count)
                    {
                        if (this.ddl_View_cust.Items[num1].Value != this.defaultviewid.ToString())
                        {
                            num1++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View_cust, this.ddl_View_cust.Items[num1].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View_cust.SelectedItem.Text;
                }
                else
                {
                    this.objCreateView.BindCustomView(this.companytype, this.CompanyID, this.ddl_View_cust, this.defaultviewid);
                    for (int i = 0; i < this.ddl_View_cust.Items.Count; i++)
                    {
                        if (this.ddl_View_cust.Items[i].Value == this.defaultviewid.ToString())
                        {
                            this.ddl_View_cust.SelectedIndex = i;
                        }
                    }
                    this.lblView.Text = this.ddl_View_cust.SelectedItem.Text;
                }
            }
            int num2 = 0;
            num2 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num2, this.CompanyID, this.companytype);
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row1 in this.dt.Rows)
                {
                    this.defaultsortedby = row1["SortedBy"].ToString();
                    this.defaultsortdirection = row1["SortDirection"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                this.GridView1.PageSize = 50;
                if (this.defaultsortedby == "")
                {
                    client_view.SortedBy = "Name";
                }
                else
                {
                    client_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    client_view.sortdirection = "ASC";
                }
                else if (this.defaultsortdirection != "")
                {
                    client_view.sortdirection = this.defaultsortdirection;
                }
                client_view.WhereCondition = "";
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            if (!base.IsPostBack)
            {
                string str2 = "";
                this.GridStateLoad();
                if (this.companytype.ToLower() == "customer")
                {
                    if (this.Session["searchCust"] != null)
                    {
                        DataTable item = (DataTable)this.Session["searchCust"];
                        str2 = this.FilterFunction(item);
                    }
                    this.Session["CustViewID"] = this.defaultviewid;
                }
                else if (this.companytype.ToLower() == "supplier")
                {
                    if (this.Session["searchSupp"] != null)
                    {
                        DataTable dataTable = (DataTable)this.Session["searchSupp"];
                        str2 = this.FilterFunction(dataTable);
                    }
                    this.Session["SuppViewID"] = this.defaultviewid;
                }
                else if (this.companytype.ToLower() == "prospect")
                {
                    if (this.Session["searchPros"] != null)
                    {
                        DataTable item1 = (DataTable)this.Session["searchPros"];
                        str2 = this.FilterFunction(item1);
                    }
                    this.Session["ProsViewID"] = this.defaultviewid;
                }
                client_view.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
                this.GridView1.PageSize = client_view.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, client_view.SortedBy, client_view.sortdirection, str2);
                this.GridStateLoad();
                this.GridView1.Rebind();
            }
            try
            {
                this.GridView1.MasterTableView.GetColumn("ClientID").Visible = false;
                this.GridView1.MasterTableView.GetColumn("AccountID").Visible = false;
                if (this.pg.ToString().ToLower().Trim() == "customer")
                {
                    this.GridView1.MasterTableView.GetColumn("IsAccountOnHold").Visible = false;
                }
            }
            catch (Exception exception)
            {
            }
            this.btnclrFilters.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
        }
    }
}