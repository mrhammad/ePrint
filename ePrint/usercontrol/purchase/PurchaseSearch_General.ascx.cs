using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.purchase
{
    public partial class PurchaseSearch_General : System.Web.UI.UserControl
    {
        public int GetPurcaseRecordCount;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private commonClass cmnClass = new commonClass();

        private createViewClass objCreateView = new createViewClass();

        public languageClass objLangClass = new languageClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int totalrec;

        public int CompanyID;

        public int UserID;

        private string para = "";

        public string newdate = string.Empty;

        public int defaultviewid;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public DataTable dt = new DataTable();

        private string pg = string.Empty;

        private string pgsearch = string.Empty;

        public string cellvalue_createddate = string.Empty;

        public string cellvalue_podate = string.Empty;

        public string cellvalue_poprice = string.Empty;

        public string cellvalue_goodsreceived = string.Empty;

        public string cellvalue_Comments = string.Empty;

        public string cellvalue_Description = string.Empty;

        public string cellvalue_Jobtitle = string.Empty;

        public string cellvalue_PurValExcGst = string.Empty;

        public string flag_PurValExcGst = string.Empty;

        public string flag_createddate = string.Empty;

        public string flag_podate = string.Empty;

        public string flag_poprice = string.Empty;

        public string flag_goodsreceived = string.Empty;

        public string flag_Comments = string.Empty;

        public string flag_Description = string.Empty;

        public string flag_Jobtitle = string.Empty;

        public string cellvalue_suppliername = string.Empty;

        public string flag_suppliername = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public long New_PurchaseID;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public int PageSize;

        public string Mode = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public int ViewID;

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

        public PurchaseSearch_General()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridViewpurchase.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "podate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                    else if (dt.Columns[i].ColumnName.ToLower() == "goodsreceived")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Int32");
                    }
                }
                for (int j = 1; j < this.GridViewpurchase.Columns.Count; j++)
                {
                    this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewpurchase.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "pono")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("PO_No"), ".");
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "goodsreceived")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Goods_Received");
                        this.flag_goodsreceived = "true";
                        this.cellvalue_goodsreceived = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "suppliername")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Supplier_Name");
                        this.GridViewpurchase.Columns[j].ItemStyle.Width = Unit.Pixel(220);
                        this.GridViewpurchase.Columns[j].ItemStyle.Wrap = false;
                        this.flag_suppliername = "true";
                        this.cellvalue_suppliername = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "status")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Status");
                        this.GridViewpurchase.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Created_On");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "podate")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("PO_Date");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_podate = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_podate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "poprice")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("PO_Price"), " ", this.cmnClass.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_poprice = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_poprice = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "jobtitle")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title");
                        this.cellvalue_Jobtitle = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_Jobtitle = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "description")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Description");
                        this.cellvalue_Description = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_Description = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Comments");
                        this.cellvalue_Comments = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_Comments = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridViewpurchase.Columns[j].Visible = false;
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Purchase_Value_Exc_Tax"), "(", this.cmnClass.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewpurchase.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_PurValExcGst = this.GridViewpurchase.Columns[j].SortExpression;
                        this.flag_PurValExcGst = "true";
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "customername")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Customer_Name");
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewpurchase.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridViewpurchase.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Payment_Terms");
                        this.GridViewpurchase.ItemStyle.Wrap = false;
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewpurchase.Columns[j].SortExpression.ToLower();
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
                base.Response.Redirect(string.Concat(this.strSitepath, "purchase/purchase_search.aspx?para=", this.para));
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

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para, string new_para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView_ForSearch(CompanyID, UserID, PageSize, PageNumber, this.pg, ViewID, SortedBy, SortDirection, para, new_para);
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
            DataTable item = dataSet.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row.Table.Columns.Contains("CreatedDate"))
                    {
                        row["CreatedDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("PODate"))
                    {
                        row["PODate"] = this.cmnClass.Eprint_return_Date_Before_View(row["PODate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("SupplierName"))
                    {
                        row["SupplierName"] = this.objBase.SpecialDecode(row["SupplierName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Description"))
                    {
                        row["Description"] = this.objBase.SpecialDecode(row["Description"].ToString());
                    }
                    if (row.Table.Columns.Contains("Status"))
                    {
                        row["Status"] = this.objBase.SpecialDecode(row["Status"].ToString());
                    }
                    if (row.Table.Columns.Contains("JobTitle"))
                    {
                        row["JobTitle"] = this.objBase.SpecialDecode(row["JobTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("Comments"))
                    {
                        row["Comments"] = this.objBase.SpecialDecode(row["Comments"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerName"))
                    {
                        row["CustomerName"] = this.objBase.SpecialDecode(row["CustomerName"].ToString());
                    }
                    if (!row.Table.Columns.Contains("PaymentTerms"))
                    {
                        continue;
                    }
                    row["PaymentTerms"] = this.objBase.SpecialDecode(row["PaymentTerms"].ToString());
                }
            }
            _commonClass.closeConnection();
            this.GridViewpurchase.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewpurchase);
                this.div_Main.Style.Add("display", "block");
                this.GridViewpurchase.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewpurchase);
                this.div_Main.Style.Add("display", "block");
                this.GridViewpurchase.AllowCustomPaging = true;
                this.GridViewpurchase.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.GetPurcaseRecordCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.getPurchaseRecCount != null)
                {
                    this.getPurchaseRecCount(this.GetPurcaseRecordCount);
                    return;
                }
            }
        }

        private void GridStateLoad()
        {
            this.cmnClass.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewpurchase, "yes");
        }

        private void GridStateSave()
        {
            this.cmnClass.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewpurchase);
        }

        protected void GridViewpurchase_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column.UniqueName == "pono")
            {
                e.Column.AutoPostBackOnFilter = true;
                e.Column.FilterControlWidth = Unit.Pixel(100);
            }
        }

        protected void GridViewpurchase_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && commandArgument.Second.ToString().ToLower() == "poprice")
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Pls Enter only Number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text;
                    }
                }
                if (base.Session["search_pur"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_pur"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_pur"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if (item.Text != "")
                {
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
                }
                base.Session["search_pur"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.GridViewpurchase.Rebind();
            }
        }

        protected void GridViewpurchase_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewpurchase.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewpurchase.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewpurchase.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewpurchase.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.GridViewpurchase.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void GridViewpurchase_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewpurchase.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, this.GridViewpurchase.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void GridViewpurchase_OnSorting(object sender, GridSortCommandEventArgs e)
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
            this.GridViewpurchase.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, this.GridViewpurchase.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        public string Only_number(string input)
        {
            return Regex.Replace(input, "[^0-9.]", "");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridViewpurchase(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < this.GridViewpurchase.Columns.Count; i++)
                {
                    if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "podate")
                    {
                        this.flag_podate = "true";
                        this.cellvalue_podate = this.GridViewpurchase.Columns[i].SortExpression;
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "poprice")
                    {
                        this.flag_poprice = "true";
                        this.cellvalue_poprice = this.GridViewpurchase.Columns[i].SortExpression;
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "goodsreceived")
                    {
                        this.flag_goodsreceived = "true";
                        this.cellvalue_goodsreceived = this.GridViewpurchase.Columns[i].SortExpression;
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "jobtitle")
                    {
                        this.cellvalue_Jobtitle = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_Jobtitle = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "description")
                    {
                        this.cellvalue_Description = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_Description = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.cellvalue_Comments = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_Comments = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.cellvalue_PurValExcGst = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_PurValExcGst = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.cellvalue_status = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_status = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.cellvalue_customername = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_customername = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.cellvalue_paymentterms = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_paymentterms = "true";
                    }
                    else if (this.GridViewpurchase.Columns[i].SortExpression.ToLower() == "suppliername")
                    {
                        this.cellvalue_suppliername = this.GridViewpurchase.Columns[i].SortExpression;
                        this.flag_suppliername = "true";
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string str = string.Concat("purchase/purchase_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString());
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                string empty = string.Empty;
                string empty1 = string.Empty;
                empty = string.Concat(this.strImagepath, "Attachment.PNG");
                empty1 = "Item with an attachment(s)";
                if (item["EstItemCoun"].Text == "0")
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                else
                {
                    ControlCollection controls = placeHolder.Controls;
                    string[] strArrays = new string[] { "<img src='", empty, "' title='", empty1, "' style='cursor:pointer;' />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                TableCell tableCell = item["PONo"];
                string[] str1 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "purchase/purchase_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["PONo"].Text, "</a>" };
                tableCell.Text = string.Concat(str1);
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_podate == "true")
                {
                    item[this.cellvalue_podate].Attributes.Add("align", "center");
                    item[this.cellvalue_podate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_podate].Style.Add("cursor", "pointer");
                }
                if (this.flag_poprice == "true")
                {
                    item[this.cellvalue_poprice].Attributes.Add("align", "right");
                    item[this.cellvalue_poprice].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_poprice].Style.Add("cursor", "pointer");
                    item[this.cellvalue_poprice].Text = this.cmnClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_poprice].Text.ToString()), 0, "", false, false, true);
                }
                if (this.flag_PurValExcGst == "true")
                {
                    item[this.cellvalue_PurValExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_PurValExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_PurValExcGst].Style.Add("cursor", "pointer");
                    item[this.cellvalue_PurValExcGst].Text = this.cmnClass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_PurValExcGst].Text.ToString()), 0, "", false, false, true);
                }
                if (this.flag_goodsreceived == "true")
                {
                    item[this.cellvalue_goodsreceived].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_goodsreceived].Style.Add("cursor", "pointer");
                }
                if (this.flag_Comments == "true")
                {
                    item[this.cellvalue_Comments].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Comments].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Comments].Text = string.Concat("<div style='width:100px;overflow:hidden;max-height: 15px;height:15px;'>", item["comments"].Text, "</div>");
                }
                if (this.flag_Description == "true")
                {
                    item[this.cellvalue_Description].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Description].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Description].Text = string.Concat("<div style='width:100px;overflow:hidden;max-height: 15px;height:15px;'>", item["Description"].Text, "</div>");
                }
                if (this.flag_Jobtitle == "true")
                {
                    item[this.cellvalue_Jobtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Jobtitle].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Jobtitle].Text = string.Concat("<div style='width:120px;overflow:hidden;max-height: 15px;height:15px;'>", item["jobtitle"].Text, "</div>");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                }
                if (this.flag_suppliername == "true")
                {
                    item[this.cellvalue_suppliername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_suppliername].Style.Add("cursor", "pointer");
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_poprice == "true")
                {
                    gridFilteringItem[this.cellvalue_poprice].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_PurValExcGst == "true")
                {
                    gridFilteringItem[this.cellvalue_PurValExcGst].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_podate == "true")
                {
                    gridFilteringItem[this.cellvalue_podate].HorizontalAlign = HorizontalAlign.Center;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridViewpurchase.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridViewpurchase.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridViewpurchase.MasterTableView.NoMasterRecordsText = this.objLangClass.GetLanguageConversion("No_records_To_Display");
            global.pageName = "purchase";
            global.pgName = "";
            this.gloobj.setpagename("purchase");
            this.strImagepath = global.imagePath();
            this.pg = "purchase";
            this.pgsearch = "purchasesearch";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            this.Page.Title = this.objLanguage.convert(global.pageTitle("Purchase View", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            string str = this.cmnClass.UserSetting_Selete(this.CompanyID, this.UserID, "purchases_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (base.Session["PurViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["PurViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridViewpurchase.PageSize = 50;
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, this.pg);
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row in this.dt.Rows)
                {
                    this.defaultsortedby = row["SortedBy"].ToString();
                    this.defaultsortdirection = row["SortDirection"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                this.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    this.SortedBy = "PONo";
                }
                else
                {
                    this.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    this.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    this.sortdirection = this.defaultsortdirection;
                }
            }
            if (!base.IsPostBack && base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                string str1 = string.Concat(this.pgsearch, this.UserID, this.pgsearch);
                base.Session["search_pur"] = null;
                base.Session[str1] = null;
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["su"] == null)
                {
                    if (base.Request.Params["suc"] != null)
                    {
                        if (base.Request.Params["suc"].ToString().ToLower() == "d")
                        {
                            this.objBase.Message_Display("Purchase Deleted Successfully", "successfulMsg", this.plhMessage);
                        }
                        else if (base.Request.Params["suc"].ToString().ToLower() == "a")
                        {
                            this.objBase.Message_Display("Purchase Archived Successfully", "successfulMsg", this.plhMessage);
                        }
                        else if (base.Request.Params["suc"].ToString().ToLower() == "cop")
                        {
                            long num1 = Convert.ToInt64(base.Request.Params["id"]);
                            this.objBase.Message_Display(string.Concat("Purchase Copied Successfully <a href='../purchase/purchase_add.aspx?type=edit&id=", num1, "'>Please Click here to view</a>"), "successfulMsg", this.plhMessage);
                        }
                    }
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "in")
                {
                    this.objBase.Message_Display("Purchase Saved Successfully", "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "up")
                {
                    this.objBase.Message_Display("Purchase Updated Successfully", "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "de")
                {
                    this.objBase.Message_Display("Purchase Deleted Successfully", "successfulMsg", this.plhMessage);
                }
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckAll", this.cmnClass.functionCheckAll());
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckChanged", this.cmnClass.functionCheckChange());
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
                    string[] strArrays = new string[] { " AND(SupplierName LIKE '%", str4, "%' OR Contact LIKE '%", str4, "%' OR contactaddress LIKE '%", str4, "%' OR DeliveryTo LIKE '%", str4, "%' OR Comments LIKE '%", str4, "%' OR PONO LIKE '%", str4, "%' OR Status LIKE '%", str4, "%' OR RaisedBy LIKE '%", str4, "%' OR CarrierInformation LIKE '%", str4, "%' OR RefNo LIKE '%", str4, "%' OR SupplierQuoteNumber LIKE '%", str4, "%' OR SupplierInvoiceNumber LIKE '%", str4, "%' OR JobNumber LIKE '%", str4, "%' OR InvoiceReceived LIKE '%", str4, "%')" };
                    str3 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str3;
                }
                this.GridStateLoad();
                if (base.Session["search_pur"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_pur"];
                    str2 = "";
                }
                base.Session["PurViewID"] = this.defaultviewid;
                this.PageSize = this.cmnClass.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewpurchase);
                this.GridViewpurchase.PageSize = this.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewpurchase.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.GridViewpurchase.Rebind();
            }
            this.GridViewpurchase.MasterTableView.GetColumn("PurchaseID").Visible = false;
        }

        public event GetPurchaseRecCount getPurchaseRecCount;
    }
}