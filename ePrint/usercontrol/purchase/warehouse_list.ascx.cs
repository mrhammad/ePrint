
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using Printcenter.UI.Purchases;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.DynamicData;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.purchase
{
    public partial class warehouse_list : System.Web.UI.UserControl
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

        public int totalrec;

        public int CompanyID;

        public int UserID;

        public int PageSize = 25;

        public int ClientID;

        public string type = string.Empty;

        public string invtype = string.Empty;

        public string Filtervalue = string.Empty;

        public string WhereConditionValues = string.Empty;

        public string SortBy = string.Empty;

        public string SortDirection = string.Empty;

        public string chkDesIncl = string.Empty;

        public string FilterCondition = "";

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public warehouse_list()
        {
        }

        protected void btnShowAll_OnClick(object sender, EventArgs e)
        {
            this.hidInvBindType.Value = "btn";
            this.GridBindAll(this.CompanyID, this.PageSize, 1, "CreatedDate", "desc", "");
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        protected void clrFilters_Click_ink(object sender, EventArgs e)
        {
            base.Session["GridInksearchFilter"] = null;
            base.Session["GridInkFilterCondition"] = null;
            base.Session["WhereConditionPostBack"] = null;
            base.Session["supplierfilter"] = null;
            this.GridInk.MasterTableView.FilterExpression = string.Empty;
            foreach (GridColumn column in this.GridInk.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridInk.MasterTableView.Rebind();
        }

        protected void clrFilters_Click_inventry(object sender, EventArgs e)
        {
            base.Session["GridInventorysearchFilter"] = null;
            base.Session["GridInventoryFilterCondition"] = null;
            base.Session["WhereConditionPostBack"] = null;
            base.Session["supplierfilter"] = null;
            this.GridInventory.MasterTableView.FilterExpression = string.Empty;
            foreach (GridColumn column in this.GridInventory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridInventory.MasterTableView.Rebind();
        }

        protected void ddlInvCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.invtype = this.ddlInvCategory.SelectedItem.Text.ToLower();
            if (base.Session["supplierfilter"] == null)
            {
                this.Filtervalue = "";
                this.WhereConditionValues = "";
            }
            else
            {
                this.Filtervalue = base.Session["supplierfilter"].ToString();
                this.WhereConditionValues = string.Concat(" and SupplierName  like '%", this.Filtervalue, "%'");
            }
            if (this.invtype.ToLower() == "plate" || this.invtype.ToLower() == "plates" || this.invtype.ToLower() == "ink" || this.invtype.ToLower() == "inks")
            {
                this.GridInk.MasterTableView.Columns[3].CurrentFilterFunction = GridKnownFunction.Contains;
                this.GridInk.MasterTableView.Columns[3].CurrentFilterValue = this.objBase.SpecialDecode(this.Filtervalue);
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInk.PageSize, this.GridInk.CurrentPageIndex + 1, "CreatedDate", "desc", this.WhereConditionValues);
                this.GridInk.DataBind();
                return;
            }
            if (this.ddlInvCategory.SelectedValue == "0")
            {
                this.GridInventory.MasterTableView.Columns[9].CurrentFilterFunction = GridKnownFunction.Contains;
                this.GridInventory.MasterTableView.Columns[9].CurrentFilterValue = this.Filtervalue;
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, "CreatedDate", "desc", this.WhereConditionValues);
                this.GridInventory.DataBind();
                return;
            }
            this.GridInventory.MasterTableView.Columns[9].CurrentFilterFunction = GridKnownFunction.Contains;
            this.GridInventory.MasterTableView.Columns[9].CurrentFilterValue = this.Filtervalue;
            this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, "CreatedDate", "desc", this.WhereConditionValues);
            this.GridInventory.DataBind();
        }

        private void DDPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.hidInvBindType.Value == "cat")
            {
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.PageSize, 1, "CreatedDate", "desc", "");
                return;
            }
            if (this.hidInvBindType.Value == "btn")
            {
                this.GridBindAll(this.CompanyID, this.PageSize, 1, "CreatedDate", "desc", "");
            }
        }

        private void DDPageSizeCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetDDLValue(this.usrPagingCustItem.DDPageSize, this.usrPagingCustItem.DDPageSize.SelectedValue);
            this.GridBindCust(this.CompanyID, "c", this.PageSize, 1, "CreatedDate", "desc", "");
        }

        private void DDPageSizeInk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.hidInvBindType.Value == "cat")
            {
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.PageSize, 1, "CreatedDate", "desc", "");
                return;
            }
            if (this.hidInvBindType.Value == "btn")
            {
                this.GridBindAll(this.CompanyID, this.PageSize, 1, "CreatedDate", "desc", "");
            }
        }

        private void DDPageSizeStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetDDLValue(this.usrPagingstore.DDPageSize, this.usrPagingstore.DDPageSize.SelectedValue);
            this.GridBindStore(this.CompanyID, "s", this.PageSize, 1, "CreatedDate", "desc", "");
        }

        public void GridBindAll(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            this.div_ink.Visible = false;
            this.div_InvItems.Visible = false;
            this.ClientID = Convert.ToInt32(base.Request.Params["clientid"].ToString());
            if (!(this.ddlInvCategory.SelectedItem.Text.ToLower() == "inks") && !(this.ddlInvCategory.SelectedItem.Text.ToLower() == "ink") && !(this.ddlInvCategory.SelectedItem.Text.ToLower() == "plate") && !(this.ddlInvCategory.SelectedItem.Text.ToLower() == "plates"))
            {
                if (this.ddlInvCategory.SelectedValue != "0")
                {
                    this.btnShowAll.Text = string.Concat("Show All Suppliers ", this.ddlInvCategory.SelectedItem.Text);
                }
                else
                {
                    this.btnShowAll.Text = "Show All Suppliers Items";
                }
                this.div_InvItems.Visible = true;
                DataSet dataSet = InventoryBasePage.warehouse_inventory_selectall_PageText(CompanyID, this.ddlInvCategory.SelectedItem.Text, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, " ", " ");
                this.GridInventory.DataSource = dataSet;
                if (dataSet.Tables[0].Rows.Count <= 0)
                {
                    this.div_Main.Style.Add("display", "none");
                    this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                    this.hidGridCount.Value = this.totalrec.ToString();
                    return;
                }
                this.div_Main.Style.Add("display", "block");
                this.GridInventory.DataBind();
                Paging.intCurrentPage = PageNumber;
                Paging.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSet.Tables[1].Rows[0][0].ToString()) / (double)PageSize));
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.div_ink.Visible = true;
            if (this.ddlInvCategory.SelectedItem.Text.ToLower() == "inks" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "ink")
            {
                this.ItemType = "inks";
            }
            else if (this.ddlInvCategory.SelectedItem.Text.ToLower() == "plate" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "plates")
            {
                this.ItemType = "plates";
            }
            Label label = new Label()
            {
                Text = this.ddlInvCategory.SelectedItem.Text
            };
            label.Text = (label.Text.Trim().Length > 9 ? string.Concat(label.Text.Substring(0, 8), "...") : label.Text);
            this.btnShowAll.Text = string.Concat("Show All Suppliers ", label.Text);
            this.btnShowAll.ToolTip = this.ddlInvCategory.SelectedItem.Text;
            DataSet dataSet1 = InventoryBasePage.warehouse_inventory_selectall_PageText(CompanyID, this.ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, " ", " ");
            if (dataSet1.Tables[0].Rows.Count <= 0)
            {
                this.div_MainInk.Style.Add("display", "none");
                this.totalrec = Convert.ToInt32(dataSet1.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.div_MainInk.Style.Add("display", "block");
            Paging.intCurrentPage = PageNumber;
            Paging.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSet1.Tables[1].Rows[0][0].ToString()) / (double)PageSize));
            this.totalrec = Convert.ToInt32(dataSet1.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = this.totalrec.ToString();
        }

        protected void GridBindCust(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            if (this.usrPagingCustItem.DDPageSize.SelectedValue != "")
            {
                PageSize = Convert.ToInt32(this.usrPagingCustItem.DDPageSize.SelectedValue);
            }
            DataSet dataSet = InventoryBasePage.warehouse_finishedgoods_PageText(CompanyID, FinishedGoodType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
            this.GridCustomerItem.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.pnlEmptyRecordsCust.Visible = true;
                this.div_MainCust.Style.Add("display", "none");
                this.usrPagingCustItem.Visible = false;
                this.lblTotalRecordsCustomerItem.Text = dataSet.Tables[1].Rows[0][0].ToString();
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.div_MainCust.Style.Add("display", "block");
            this.pnlEmptyRecordsCust.Visible = false;
            this.GridCustomerItem.DataBind();
            this.usrPagingCustItem.Visible = true;
            Paging.intCurrentPage = PageNumber;
            Paging.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSet.Tables[1].Rows[0][0].ToString()) / (double)PageSize));
            this.usrPagingCustItem.CreatePaging();
            this.usrPagingCustItem.OnPageChange += new PagingEventHandler(this.usrPagingCust_OnPageChange);
            this.lblTotalRecordsCustomerItem.Text = dataSet.Tables[1].Rows[0][0].ToString();
            this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = this.totalrec.ToString();
            this.CallPagingBtn_ScrollGrid(this.usrPagingCustItem);
        }

        protected void GridBindInk(int CompanyID, int ClientID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            if (SortBy.Trim() == "" && this.ViewState["SortBy"] == null)
            {
                this.ViewState["SortBy"] = "CreatedDate";
            }
            if (SortDirection.Trim() == "" && this.ViewState["SortDirection"] == null)
            {
                this.ViewState["SortDirection"] = " desc ";
            }
            if (SortBy != "")
            {
                this.ViewState["SortBy"] = SortBy;
            }
            if (SortDirection != "")
            {
                this.ViewState["SortDirection"] = SortDirection;
            }
            SortBy = this.ViewState["SortBy"].ToString();
            SortDirection = this.ViewState["SortDirection"].ToString();
            if (base.Session["GridInkFilterCondition"] != null)
            {
                if (WhereCondition.Length <= 0)
                {
                    WhereCondition = string.Concat(" and ", base.Session["GridInkFilterCondition"].ToString());
                }
                else
                {
                    WhereCondition = string.Concat(WhereCondition, " and ", base.Session["GridInkFilterCondition"].ToString());
                }
            }
            if (base.Session["WhereConditionPostBack"] != null)
            {
                if (WhereCondition.Length <= 0)
                {
                    WhereCondition = base.Session["WhereConditionPostBack"].ToString();
                }
                else
                {
                    WhereCondition = string.Concat(WhereCondition, base.Session["WhereConditionPostBack"].ToString());
                }
            }
            DataSet dataSet = InventoryBasePage.warehouse_inventory_selectall_PageText(CompanyID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, "", "");
            DataTable item = dataSet.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            this.GridInk.DataSource = dataSet;
            try
            {
                if (dataSet.Tables[0].Rows.Count <= 0)
                {
                    this.GridInk.AllowCustomPaging = false;
                }
                else
                {
                    this.GridInk.AllowCustomPaging = true;
                    this.GridInk.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                }
            }
            catch
            {
                base.Session["GridInksearchFilter"] = null;
                base.Session["GridInkFilterCondition"] = null;
                base.Session["WhereConditionPostBack"] = null;
                foreach (GridColumn column in this.GridInk.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.GridInk.MasterTableView.FilterExpression = string.Empty;
            }
        }

        protected void GridBindInv(int CompanyID, int ClientID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            if (SortBy.Trim() == "" && this.ViewState["SortBy"] == null)
            {
                this.ViewState["SortBy"] = "CreatedDate";
            }
            if (SortDirection.Trim() == "" && this.ViewState["SortDirection"] == null)
            {
                this.ViewState["SortDirection"] = " desc ";
            }
            if (SortBy != "")
            {
                this.ViewState["SortBy"] = SortBy;
            }
            if (SortDirection != "")
            {
                this.ViewState["SortDirection"] = SortDirection;
            }
            SortBy = this.ViewState["SortBy"].ToString();
            SortDirection = this.ViewState["SortDirection"].ToString();
            if (base.Session["GridInventoryFilterCondition"] != null)
            {
                if (WhereCondition.Length <= 0)
                {
                    WhereCondition = string.Concat(" and ", base.Session["GridInventoryFilterCondition"].ToString());
                }
                else
                {
                    WhereCondition = string.Concat(WhereCondition, " and ", base.Session["GridInventoryFilterCondition"].ToString());
                }
            }
            if (base.Session["WhereConditionPostBack"] != null)
            {
                if (WhereCondition.Length <= 0)
                {
                    WhereCondition = base.Session["WhereConditionPostBack"].ToString();
                }
                else
                {
                    WhereCondition = string.Concat(WhereCondition, base.Session["WhereConditionPostBack"].ToString());
                }
            }
            DataSet dataSet = InventoryBasePage.warehouse_inventory_selectall_PageText(CompanyID, ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, "", "");
            DataTable item = dataSet.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            this.GridInventory.DataSource = dataSet.Tables[0];
            try
            {
                if (dataSet.Tables[0].Rows.Count <= 0)
                {
                    this.GridInventory.AllowCustomPaging = false;
                }
                else
                {
                    this.GridInventory.AllowCustomPaging = true;
                    this.GridInventory.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                }
            }
            catch
            {
                base.Session["GridInventorysearchFilter"] = null;
                base.Session["GridInventoryFilterCondition"] = null;
                base.Session["WhereConditionPostBack"] = null;
                foreach (GridColumn column in this.GridInventory.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.GridInventory.MasterTableView.FilterExpression = string.Empty;
            }
        }

        public void GridBindOnClientID(int CompanyID, int ClientID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            this.div_ink.Visible = false;
            this.div_InvItems.Visible = false;
            if (!this.IsPostBack)
            {
                ddlInvCategory.Items.Insert(0, "All");
                ddlInvCategory.SelectedIndex = 0;
                //base.Session["WhereConditionPostBack"] = null;
                this.div_InvItems.Visible = true;
                this.GridBindInv(CompanyID, ClientID, this.ddlInvCategory.SelectedItem.Text.ToLower(), PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
                return;
            }
            if (this.ddlInvCategory.SelectedItem.Text.ToLower() == "inks" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "ink" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "plate" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "plates")
            {
                this.div_ink.Visible = true;
                if (this.ddlInvCategory.SelectedItem.Text.ToLower() == "inks" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "ink")
                {
                    this.ItemType = "inks";
                }
                else if (this.ddlInvCategory.SelectedItem.Text.ToLower() == "plate" || this.ddlInvCategory.SelectedItem.Text.ToLower() == "plates")
                {
                    this.ItemType = "plates";
                }
                this.GridBindInk(CompanyID, ClientID, this.ItemType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
                return;
            }
            if (this.ddlInvCategory.SelectedValue != "0")
            {
                Label label = new Label()
                {
                    Text = this.ddlInvCategory.SelectedItem.Text
                };
                label.Text = (label.Text.Trim().Length > 9 ? string.Concat(label.Text.Substring(0, 8), "...") : label.Text);
                this.btnShowAll.Text = string.Concat("Show All Suppliers ", label.Text);
                this.btnShowAll.ToolTip = this.ddlInvCategory.SelectedItem.Text;
            }
            else
            {
                this.btnShowAll.Text = "Show All Suppliers Items";
            }
            this.div_InvItems.Visible = true;
            this.GridBindInv(CompanyID, ClientID, this.objBase.SpecialEncode(this.ddlInvCategory.SelectedItem.Text), PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        protected void GridBindStore(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            if (this.usrPagingstore.DDPageSize.SelectedValue != "")
            {
                PageSize = Convert.ToInt32(this.usrPagingstore.DDPageSize.SelectedValue);
            }
            DataSet dataSet = InventoryBasePage.warehouse_finishedgoods_PageText(CompanyID, FinishedGoodType, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
            this.GridStoreSupply.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.pnlEmptyRecordsStore.Visible = true;
                this.div_MainStore.Style.Add("display", "none");
                this.usrPagingstore.Visible = false;
                this.lblTotalRecordsStore.Text = dataSet.Tables[1].Rows[0][0].ToString();
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.div_MainStore.Style.Add("display", "block");
            this.pnlEmptyRecordsStore.Visible = false;
            this.GridStoreSupply.DataBind();
            this.usrPagingstore.Visible = true;
            Paging.intCurrentPage = PageNumber;
            Paging.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSet.Tables[1].Rows[0][0].ToString()) / (double)PageSize));
            this.usrPagingstore.CreatePaging();
            this.usrPagingstore.OnPageChange += new PagingEventHandler(this.usrPagingStore_OnPageChange);
            this.lblTotalRecordsStore.Text = dataSet.Tables[1].Rows[0][0].ToString();
            this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = this.totalrec.ToString();
            this.CallPagingBtn_ScrollGrid(this.usrPagingstore);
        }

        protected void Gridcust_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.FindControl("lblCustInStockQty");
                Label label1 = (Label)e.Row.FindControl("lblCustPaperQty");
                Label label2 = (Label)e.Row.FindControl("lblCustPackCostPrice");
                label.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", true, false, true);
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", true, false, true);
                label2.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
            }
        }

        protected void GridInk_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            TextBox textBox = new TextBox()
            {
                AutoCompleteType = AutoCompleteType.Disabled
            };
            string empty = string.Empty;
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                textBox = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                textBox.Text = this.objBase.SpecialEncode(textBox.Text);
                if (str.ToLower() == "suppliername")
                {
                    base.Session["supplierfilter"] = textBox.Text.Trim().Replace("'", "`");
                }
                this.FilterCondition = "";
                string empty1 = string.Empty;
                string str1 = string.Empty;
                if (base.Session["GridInksearchFilter"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["GridInksearchFilter"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["GridInksearchFilter"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if (textBox.Text != "")
                {
                    if ((int)dataRowArray.Length > 0)
                    {
                        this.dtsearch.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            if (textBox.Text != "")
                            {
                                empty = textBox.Text;
                            }
                            object[] second = new object[] { commandArgument.Second, commandArgument.First, empty };
                            this.dtsearch.Rows.Add(second);
                        }
                    }
                    else if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        if (textBox.Text != "")
                        {
                            empty = textBox.Text;
                        }
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, empty };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                if (commandArgument.First.ToString().ToLower() == "nofilter" && this.dtsearch.Rows.Count == 0)
                {
                    this.GridInk.MasterTableView.FilterExpression = string.Empty;
                    GridColumn[] renderColumns = this.GridInk.MasterTableView.RenderColumns;
                    for (int i = 0; i < (int)renderColumns.Length; i++)
                    {
                        GridColumn gridColumn = renderColumns[i];
                        if (gridColumn.SupportsFiltering())
                        {
                            gridColumn.CurrentFilterValue = string.Empty;
                            gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                            base.Session["WhereConditionPostBack"] = null;
                            base.Session["supplierfilter"] = null;
                        }
                    }
                }
                base.Session["GridInksearchFilter"] = this.dtsearch;
                foreach (DataRow row in this.dtsearch.Rows)
                {
                    if (row["filter"].ToString().ToLower() != "nofilter" && this.FilterCondition != "")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList = this;
                        usercontrolPurchaseWarehouseList.FilterCondition = string.Concat(usercontrolPurchaseWarehouseList.FilterCondition, " and ");
                    }
                    empty1 = row["ColumnName"].ToString();
                    str1 = row["FilterText"].ToString();
                    if (str1.Length > 200)
                    {
                        str1 = str1.Substring(0, 200);
                    }
                    string lower = row["filter"].ToString().ToLower();
                    string str2 = lower;
                    if (lower == null)
                    {
                        continue;
                    }
                    if (str2 == "startswith")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList1 = this;
                        string filterCondition = usercontrolPurchaseWarehouseList1.FilterCondition;
                        string[] strArrays = new string[] { filterCondition, " ", empty1, " like '", str1, "%'" };
                        usercontrolPurchaseWarehouseList1.FilterCondition = string.Concat(strArrays);
                    }
                    else if (str2 == "endswith")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList2 = this;
                        string filterCondition1 = usercontrolPurchaseWarehouseList2.FilterCondition;
                        string[] strArrays1 = new string[] { filterCondition1, " ", empty1, " like '%", str1, "'" };
                        usercontrolPurchaseWarehouseList2.FilterCondition = string.Concat(strArrays1);
                    }
                    else if (str2 == "contains")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList3 = this;
                        string filterCondition2 = usercontrolPurchaseWarehouseList3.FilterCondition;
                        string[] strArrays2 = new string[] { filterCondition2, " ", empty1, " like '%", str1, "%'" };
                        usercontrolPurchaseWarehouseList3.FilterCondition = string.Concat(strArrays2);
                    }
                    else if (str2 == "doesnotcontain")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList4 = this;
                        string filterCondition3 = usercontrolPurchaseWarehouseList4.FilterCondition;
                        string[] strArrays3 = new string[] { filterCondition3, " ", empty1, " not like '%", str1, "%'" };
                        usercontrolPurchaseWarehouseList4.FilterCondition = string.Concat(strArrays3);
                    }
                    else if (str2 == "equalto")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList5 = this;
                        string str3 = usercontrolPurchaseWarehouseList5.FilterCondition;
                        string[] strArrays4 = new string[] { str3, " ", empty1, " = '", str1, "'" };
                        usercontrolPurchaseWarehouseList5.FilterCondition = string.Concat(strArrays4);
                    }
                    else if (str2 == "notequalto")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList6 = this;
                        string filterCondition4 = usercontrolPurchaseWarehouseList6.FilterCondition;
                        string[] strArrays5 = new string[] { filterCondition4, " ", empty1, " != '", str1, "'" };
                        usercontrolPurchaseWarehouseList6.FilterCondition = string.Concat(strArrays5);
                    }
                }
                base.Session["GridInkFilterCondition"] = this.FilterCondition;
                if (this.FilterCondition.Trim().Length == 0)
                {
                    base.Session["GridInkFilterCondition"] = null;
                }
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInk.PageSize, this.GridInk.CurrentPageIndex + 1, "CreatedDate", "desc", "");
                this.GridInk.Rebind();
                e.Canceled = true;
            }
        }

        protected void GridInk_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInk.PageSize, this.GridInk.CurrentPageIndex + 1, "CreatedDate", "desc", this.WhereConditionValues);
        }

        protected void GridInk_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["PackedPrice"].Text = string.Concat("Pack Price(", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lblInkPackQty");
                Label label1 = (Label)e.Item.FindControl("lblInkPackPrice");
                label.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", false, false, true);
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
                Label text = (Label)e.Item.FindControl("lblSupplier");
                text.ToolTip = text.Text;
                text.Text = BaseClass.WrapString(text.Text.ToString(), 20);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLangClass.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridInk.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridInk.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLangClass.GetLanguageConversion("items_in"), " {1} ", this.objLangClass.GetLanguageConversion("pages"));
            }
        }

        protected void GridInk_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridBindOnClientID(this.CompanyID, this.ClientID, Convert.ToInt32(this.hdnGridInk.Value), e.NewPageIndex + 1, "CreatedDate", "desc", "");
        }

        protected void GridInk_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridBindOnClientID(this.CompanyID, this.ClientID, e.NewPageSize, this.GridInk.CurrentPageIndex + 1, "CreatedDate", "desc", this.WhereConditionValues);
            this.hdnGridInk.Value = Convert.ToString(e.NewPageSize);
        }

        protected void GridInk_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            GridTableView ownerTableView = e.Item.OwnerTableView;
            GridSortExpression gridSortExpression = new GridSortExpression();
            this.SortBy = e.SortExpression;
            this.SortDirection = e.NewSortOrder.ToString();
            if (this.SortDirection.ToLower() == "ascending")
            {
                this.SortDirection = "ASC";
            }
            else if (this.SortDirection.ToLower() != "descending")
            {
                this.SortDirection = "ASC";
            }
            else
            {
                this.SortDirection = "DESC";
            }
            try
            {
                this.GridBindOnClientID(this.CompanyID, this.ClientID, Convert.ToInt32(this.hdnGridInk.Value), this.GridInk.CurrentPageIndex + 1, this.SortBy, this.SortDirection, this.WhereConditionValues);
            }
            catch
            {
            }
        }

        protected void GridInventory_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["PackedPrice"].Text = string.Concat("Pack Price(", this.cmnDate.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lblPaperSize");
                Label label1 = (Label)e.Item.FindControl("lblInvWeightSize");
                Label label2 = (Label)e.Item.FindControl("lblGsm");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_PaperType");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hid_LengthType");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hid_WidthType");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hid_Length");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hid_Width");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hid_Height");
                LinkButton linkButton = (LinkButton)e.Item.Cells[1].FindControl("lnkInvName1");
                Label label3 = (Label)e.Item.FindControl("lblInvName");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hid_InventoryID");
                HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hid_InventoryCode");
                Label label4 = (Label)e.Item.FindControl("lblPackQty");
                Label labeldes = (Label)e.Item.FindControl("lblInvFriendlyName");
                Label labelFn = (Label)e.Item.FindControl("lblInvDescription");
                Label label5 = (Label)e.Item.FindControl("lblPackPrice");
                Label label6 = (Label)e.Item.FindControl("lblInvCost");
                Label label7 = (Label)e.Item.FindControl("lblInvPer");
                HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hid_PackedIn");
                HiddenField hiddenField9 = (HiddenField)e.Item.FindControl("hid_StockType");
                HiddenField hiddenField10 = (HiddenField)e.Item.FindControl("hid_PackedInType");
                HiddenField hiddenField11 = (HiddenField)e.Item.FindControl("hid_Description");
                LinkButton linkButton1 = (LinkButton)e.Item.Cells[1].FindControl("lnkInvCode");
                label4.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text), 0, "", true, false, true);
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
                hiddenField3.Value = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField3.Value), 0, "", false, false, true);
                hiddenField4.Value = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField4.Value), 0, "", false, false, true);
                hiddenField5.Value = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField5.Value), 0, "", false, false, true);
                label5.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField5.Value), 0, "", false, false, true);
                label6.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label6.Text), 0, "", false, false, true);
                label7.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label7.Text), 0, "", true, false, true);
                if (hiddenField9.Value.ToLower() == "paper")
                {
                    label4.Text = (hiddenField.Value.ToLower() == "web printing" ? "1" : label4.Text);
                }
                else if (hiddenField9.Value.ToLower() == "ink" || hiddenField9.Value.ToLower() == "inks")
                {
                    label4.Text = "1";
                    label1.Text = "";
                    label2.Text = "";
                }
                else if (hiddenField9.Value.ToLower() == "plate" || hiddenField9.Value.ToLower() == "plates")
                {
                    label1.Text = "";
                    label2.Text = "";
                }
                string[] value = new string[] { "javascript:ShowWarehouseQtyDiv('show');getvalues('", hiddenField6.Value, "','", this.objBase.SpecialEncode(hiddenField7.Value), "','", this.objBase.SpecialEncode(label3.Text), "','", hiddenField8.Value, "','", label5.Text, "','I','", label6.Text, "','", label7.Text, "','", hiddenField.Value.ToLower(), "','", hiddenField11.Value.Trim().Replace("\n", "").Replace("\r", ""), "','", hiddenField9.Value, "','", label4.Text, "');return false;" };
                linkButton1.OnClientClick = string.Concat(value);
                string[] strArrays = new string[] { "javascript:ShowWarehouseQtyDiv('show');getvalues('", hiddenField6.Value, "','", this.objBase.SpecialEncode(hiddenField7.Value), "','", this.objBase.SpecialEncode(label3.Text), "','", hiddenField8.Value, "','", label5.Text, "','I','", label6.Text, "','", label7.Text, "','", hiddenField.Value.ToLower(), "','", hiddenField11.Value.Trim().Replace("\n", "").Replace("\r", ""), "','", hiddenField9.Value, "','", label4.Text, "');return false;" };
                linkButton.OnClientClick = string.Concat(strArrays);
                linkButton.Text = this.objBase.dispstrtxtbox(this.cmnDate.replaceLineBreak(linkButton.Text.ToString().Trim()), 25);
                if (label1.Text == "0")
                {
                    label1.Text = "";
                    label2.Text = "";
                }
                if (hiddenField9.Value.ToLower() != "paper")
                {
                    label.Text = "";
                }
                Label text = (Label)e.Item.FindControl("lblSupplier");
                text.ToolTip = text.Text;
                text.Text = BaseClass.WrapString(text.Text.ToString(), 20);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLangClass.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridInventory.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridInventory.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLangClass.GetLanguageConversion("items_in"), " {1} ", this.objLangClass.GetLanguageConversion("pages"));
            }
        }

        protected void GridInventory_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridBindOnClientID(this.CompanyID, this.ClientID, Convert.ToInt32(this.hdnGridInventoryRadGrid.Value), e.NewPageIndex + 1, this.SortBy, this.SortDirection, this.WhereConditionValues);
        }

        protected void GridInventory_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridBindOnClientID(this.CompanyID, this.ClientID, e.NewPageSize, this.GridInventory.CurrentPageIndex + 1, this.SortBy, this.SortDirection, this.WhereConditionValues);
            this.hdnGridInventoryRadGrid.Value = Convert.ToString(e.NewPageSize);
        }

        protected void GridInventory_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            GridTableView ownerTableView = e.Item.OwnerTableView;
            GridSortExpression gridSortExpression = new GridSortExpression();
            this.SortBy = e.SortExpression;
            this.SortDirection = e.NewSortOrder.ToString();
            if (this.SortDirection.ToLower() == "ascending")
            {
                this.SortDirection = "ASC";
            }
            else if (this.SortDirection.ToLower() != "descending")
            {
                this.SortDirection = "ASC";
            }
            else
            {
                this.SortDirection = "DESC";
            }
            try
            {
                this.GridBindOnClientID(this.CompanyID, this.ClientID, Convert.ToInt32(this.hdnGridInventoryRadGrid.Value), this.GridInventory.CurrentPageIndex + 1, this.SortBy, this.SortDirection, this.WhereConditionValues);
            }
            catch
            {
            }
        }

        private void GridStateLoad()
        {
            this.cmnDate.GridStateLoadNew("Purchase", "InventorySelector", this.GridInventory, "no");
        }

        private void GridStateSave()
        {
            this.cmnDate.GridStateSaveNew("setting", "InventorySelector", this.GridInventory);
        }

        public void GridStoreSupply_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.FindControl("lblInStockQty");
                Label label1 = (Label)e.Row.FindControl("lblStorePackCostPrice");
                Label label2 = (Label)e.Row.FindControl("lblStorePackQty");
                label.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", true, false, true);
                label2.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", true, false, true);
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
            }
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            TextBox textBox = new TextBox()
            {
                AutoCompleteType = AutoCompleteType.Disabled
            };
            string empty = string.Empty;
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                textBox = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                textBox.Text = this.objBase.SpecialEncode(textBox.Text);
                if (str.ToLower() == "suppliername")
                {
                    base.Session["supplierfilter"] = textBox.Text.Trim().Replace("'", "`");
                }
                this.FilterCondition = "";
                string empty1 = string.Empty;
                string str1 = string.Empty;
                if (base.Session["GridInventorysearchFilter"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (dtsearch.Columns.Count==0)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["GridInventorysearchFilter"] != null && textBox.Text != "")
                {
                    this.dtsearch = (DataTable)base.Session["GridInventorysearchFilter"];
                }
               
                DataRow[] dataRowArray = new DataRow[0];
                if (this.dtsearch.Rows.Count > 0)
                {
                     dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                }

                if (textBox.Text != "")
                {
                    if ((int)dataRowArray.Length > 0)
                    {
                        this.dtsearch.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            if (textBox.Text != "")
                            {
                                empty = textBox.Text;
                            }
                            object[] second = new object[] { commandArgument.Second, commandArgument.First, empty };
                            this.dtsearch.Rows.Add(second);
                        }
                    }
                    else if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        if (textBox.Text != "")
                        {
                            empty = textBox.Text;
                        }
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, empty };
                        this.dtsearch.Rows.Add(objArray);
                    }
                }
                if (commandArgument.First.ToString().ToLower() == "nofilter" && this.dtsearch.Rows.Count == 0)
                {
                    this.GridInventory.MasterTableView.FilterExpression = string.Empty;
                    GridColumn[] renderColumns = this.GridInventory.MasterTableView.RenderColumns;
                    for (int i = 0; i < (int)renderColumns.Length; i++)
                    {
                        GridColumn gridColumn = renderColumns[i];
                        if (gridColumn.SupportsFiltering())
                        {
                            gridColumn.CurrentFilterValue = string.Empty;
                            gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                            base.Session["WhereConditionPostBack"] = null;
                            base.Session["supplierfilter"] = null;
                        }
                    }
                }
                base.Session["GridInventorysearchFilter"] = this.dtsearch;
                foreach (DataRow row in this.dtsearch.Rows)
                {
                    if (row["filter"].ToString().ToLower() != "nofilter" && this.FilterCondition != "")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList = this;
                        usercontrolPurchaseWarehouseList.FilterCondition = string.Concat(usercontrolPurchaseWarehouseList.FilterCondition, " and ");
                    }
                    empty1 = row["ColumnName"].ToString();
                    str1 = row["FilterText"].ToString();
                    if (str1.Length > 200)
                    {
                        str1 = str1.Substring(0, 200);
                    }
                    string lower = row["filter"].ToString().ToLower();
                    string str2 = lower;
                    if (lower == null)
                    {
                        continue;
                    }
                    if (str2 == "startswith")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList1 = this;
                        string filterCondition = usercontrolPurchaseWarehouseList1.FilterCondition;
                        string[] strArrays = new string[] { filterCondition, " ", empty1, " like '", str1, "%'" };
                        usercontrolPurchaseWarehouseList1.FilterCondition = string.Concat(strArrays);
                    }
                    else if (str2 == "endswith")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList2 = this;
                        string filterCondition1 = usercontrolPurchaseWarehouseList2.FilterCondition;
                        string[] strArrays1 = new string[] { filterCondition1, " ", empty1, " like '%", str1, "'" };
                        usercontrolPurchaseWarehouseList2.FilterCondition = string.Concat(strArrays1);
                    }
                    else if (str2 == "contains")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList3 = this;
                        string filterCondition2 = usercontrolPurchaseWarehouseList3.FilterCondition;
                        string[] strArrays2 = new string[] { filterCondition2, " ", empty1, " like '%", str1, "%'" };
                        usercontrolPurchaseWarehouseList3.FilterCondition = string.Concat(strArrays2);
                    }
                    else if (str2 == "doesnotcontain")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList4 = this;
                        string filterCondition3 = usercontrolPurchaseWarehouseList4.FilterCondition;
                        string[] strArrays3 = new string[] { filterCondition3, " ", empty1, " not like '%", str1, "%'" };
                        usercontrolPurchaseWarehouseList4.FilterCondition = string.Concat(strArrays3);
                    }
                    else if (str2 == "equalto")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList5 = this;
                        string str3 = usercontrolPurchaseWarehouseList5.FilterCondition;
                        string[] strArrays4 = new string[] { str3, " ", empty1, " = '", str1, "'" };
                        usercontrolPurchaseWarehouseList5.FilterCondition = string.Concat(strArrays4);
                    }
                    else if (str2 == "notequalto")
                    {
                        warehouse_list usercontrolPurchaseWarehouseList6 = this;
                        string filterCondition4 = usercontrolPurchaseWarehouseList6.FilterCondition;
                        string[] strArrays5 = new string[] { filterCondition4, " ", empty1, " != '", str1, "'" };
                        usercontrolPurchaseWarehouseList6.FilterCondition = string.Concat(strArrays5);
                    }
                }
                base.Session["GridInventoryFilterCondition"] = this.FilterCondition;
                if (this.FilterCondition.Trim().Length == 0)
                {
                    base.Session["GridInventoryFilterCondition"] = null;
                }
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, "CreatedDate", "desc", "");
                this.GridInventory.Rebind();
                e.Canceled = true;
            }
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.WhereConditionValues = string.Concat(" and SupplierName  like '%", this.Filtervalue, "%'");
                base.Session["WhereConditionPostBack"] = this.WhereConditionValues;
            }
            this.GridBindOnClientID(this.CompanyID, this.ClientID, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, "CreatedDate", "desc", this.WhereConditionValues);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridInventory.FilterMenu;
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
            GridFilterMenu languageConversion = this.GridInk.FilterMenu;
            for (int j = languageConversion.Items.Count - 1; j >= 0; j--)
            {
                if (languageConversion.Items[j].Text == "Custom")
                {
                    languageConversion.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (languageConversion.Items[j].Text.ToLower() == "isempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "isnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "between")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notbetween")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "nofilter")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("NoFilter");
                }
                if (languageConversion.Items[j].Text.ToLower() == "contains")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("Contains");
                }
                if (languageConversion.Items[j].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion.Items[j].Text.ToLower() == "startswith")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("StartsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "endswith")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("EndsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("EqualTo");
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Text = this.objLangClass.GetLanguageConversion("LessThan");
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
                this.ViewState["SortBy"] = null;
                this.ViewState["SortDirection"] = null;
                base.Session["GridInventorysearchFilter"] = null;
                base.Session["GridInventoryFilterCondition"] = null;
                base.Session["WhereConditionPostBack"] = null;
                base.Session["GridInksearchFilter"] = null;
                base.Session["GridInkFilterCondition"] = null;
                base.Session["WhereConditionPostBack"] = null;
                base.Session["supplierfilter"] = null;
            }
            if (base.Request.Params["item"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["clientid"].ToString());
                this.type = base.Request.Params["item"].ToString().ToLower();
                this.div_ink.Visible = false;
                this.div_Store.Visible = false;
                this.div_Customer.Visible = false;
                this.div_Search.Visible = true;
                if (!base.IsPostBack)
                {
                    DataSet dataSet = PurchaseBasePage.Warehouse_Inventory_Select(this.CompanyID, this.ClientID);
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {               
                        if (base.Session["supplierfilter"] != null)
                        {
                            continue;
                        }
                        base.Session["supplierfilter"] = row["SupplierName"].ToString();
                        this.Filtervalue = base.Session["supplierfilter"].ToString();
                    }
                }
                DataSet datSet = PurchaseBasePage.Warehouse_Inventory_Select(this.CompanyID, this.ClientID);
                foreach (DataRow row in datSet.Tables[0].Rows)
                {
                    this.chkDesIncl = row["DescriptionInclude"].ToString(); 
                }
                if (base.Request.Params["item"].ToString().ToLower() == "inventory" && !base.IsPostBack)
                {
                    this.objInv.Bind_Stock_Category(this.ddlInvCategory, this.CompanyID, "all");
                    this.GridInventory.MasterTableView.Columns[9].CurrentFilterFunction = GridKnownFunction.Contains;
                    if (base.Session["supplierfilter"] == null)
                    {
                        this.GridInventory.MasterTableView.Columns[9].CurrentFilterValue = "";
                    }
                    else
                    {
                        this.GridInventory.MasterTableView.Columns[9].CurrentFilterValue = this.objBase.SpecialDecode(base.Session["supplierfilter"].ToString());
                    }
                    this.GridInventory.DataBind();
                }
            }
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
            }
            this.Label28.Text = this.objLangClass.GetLanguageConversion("Category");
            this.btnShowAll.Text = this.objLangClass.GetLanguageConversion("Show_All_Suppliers_Items");
            this.link_clrfilt_Invntry.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
            this.Label135.Text = this.objLangClass.GetLanguageConversion("Required_Stock_Qty");
            this.Button6.Text = this.objLangClass.GetLanguageConversion("Add");
            this.link_clrfilt_Ink.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
            this.GridInventory.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Code").ToString();
            this.GridInventory.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Name").ToString();
            this.GridInventory.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Description").ToString();
            this.GridInventory.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Friendly_Name").ToString();
            this.GridInventory.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Weight").ToString();
            this.GridInventory.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Size").ToString();
            this.GridInventory.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Pack_Qty").ToString();
            this.GridInventory.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Pack_Price").ToString();
            this.GridInventory.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Cost_Price").ToString();
            this.GridInventory.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("Supplier").ToString();
            this.GridInventory.MasterTableView.NoMasterRecordsText = this.objLangClass.GetLanguageConversion("No_Records_To_Display");
        }

        public void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        private void usrPaging_OnPageChange(int PageNumber)
        {
            if (this.hidInvBindType.Value == "cat")
            {
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.PageSize, PageNumber, "CreatedDate", "desc", "");
                return;
            }
            if (this.hidInvBindType.Value == "btn")
            {
                this.GridBindAll(this.CompanyID, this.PageSize, PageNumber, "CreatedDate", "desc", "");
            }
        }

        private void usrPagingCust_OnPageChange(int PageNumber)
        {
            this.GridBindCust(this.CompanyID, "c", this.PageSize, PageNumber, "CreatedDate", "desc", "");
        }

        private void usrPagingInk_OnPageChange(int PageNumber)
        {
            if (this.hidInvBindType.Value == "cat")
            {
                this.GridBindOnClientID(this.CompanyID, this.ClientID, this.PageSize, PageNumber, "CreatedDate", "desc", "");
                return;
            }
            if (this.hidInvBindType.Value == "btn")
            {
                this.GridBindAll(this.CompanyID, this.PageSize, PageNumber, "CreatedDate", "desc", "");
            }
        }

        private void usrPagingStore_OnPageChange(int PageNumber)
        {
            this.GridBindStore(this.CompanyID, "s", this.PageSize, PageNumber, "CreatedDate", "desc", "");
        }
    }
}