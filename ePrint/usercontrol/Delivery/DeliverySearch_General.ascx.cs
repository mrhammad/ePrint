using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
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

namespace ePrint.usercontrol.Delivery
{
    public partial class DeliverySearch_General : UsercontrolBasePage
    {
        private int getDeliveryRecordCount;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private commonClass cmnClass = new commonClass();

        private BaseClass objBase = new BaseClass();

        public languageClass objLangClass = new languageClass();

        public int CompanyID;

        public int UserID;

        private string para = "";

        public int totalrec;

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        private createViewClass objCreateView = new createViewClass();

        public int defaultviewid;

        public string cellvalue_createddate = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_deliverydate = string.Empty;

        public string flag_deliverydate = string.Empty;

        public string cellvalue_posted = string.Empty;

        public string flag_posted = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_consignmentnotenumber = string.Empty;

        public string flag_consignmentnotenumber = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_jobnumber = string.Empty;

        public string flag_jobnumber = string.Empty;

        public string cellvalue_customerordernumber = string.Empty;

        public string flag_customerordernumber = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_jobtitle = string.Empty;

        public string flag_jobtitle = string.Empty;

        public DataTable dt = new DataTable();

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string pg;

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public int PageSize;

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Mode = string.Empty;

        public string pgsearch = string.Empty;

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

        public DeliverySearch_General()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridViewDelivery.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "deliverydate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                }
                for (int j = 1; j < this.GridViewDelivery.Columns.Count; j++)
                {
                    this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewDelivery.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "deliverynumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(9);
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Customer_Name").ToString();
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "orderno")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Customer_Order_No_view").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(9);
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "posted")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Posted").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(6);
                        this.flag_posted = "true";
                        this.cellvalue_posted = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "status")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("status").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "jobnumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(9);
                        this.flag_jobnumber = "true";
                        this.cellvalue_jobnumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "consignmentnumber")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Consignment_Note_Number").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(15);
                        this.flag_consignmentnotenumber = "true";
                        this.cellvalue_consignmentnotenumber = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Delivery_Dates_view").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                        this.cellvalue_deliverydate = this.GridViewDelivery.Columns[j].SortExpression;
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Created_On").ToString();
                        this.GridViewDelivery.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridViewDelivery.Columns[j].HeaderStyle.Width = Unit.Percentage(10);
                        this.cellvalue_createddate = this.GridViewDelivery.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridViewDelivery.Columns[j].Visible = false;
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("PAyment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewDelivery.Columns[j].SortExpression.ToLower() == "jobtitle")
                    {
                        this.GridViewDelivery.Columns[j].HeaderText = this.objLangClass.GetLanguageConversion("Job_Title");
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridViewDelivery.Columns[j].SortExpression.ToLower();
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
                base.Response.Redirect(string.Concat(this.strSitepath, "delivery/delivery_search.aspx?para=", this.para));
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
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("Status"))
                    {
                        row["Status"] = this.objBase.SpecialDecode(row["Status"].ToString());
                    }
                    if (row.Table.Columns.Contains("customerid"))
                    {
                        row["customerid"] = this.objBase.SpecialDecode(row["customerid"].ToString());
                    }
                    if (row.Table.Columns.Contains("consignmentnumber"))
                    {
                        row["consignmentnumber"] = this.objBase.SpecialDecode(row["consignmentnumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("PaymentTerms"))
                    {
                        row["PaymentTerms"] = this.objBase.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("orderno"))
                    {
                        row["orderno"] = this.objBase.SpecialDecode(row["orderno"].ToString());
                    }
                    if (row.Table.Columns.Contains("jobnumber"))
                    {
                        row["jobnumber"] = this.objBase.SpecialDecode(row["jobnumber"].ToString());
                    }
                    if (!row.Table.Columns.Contains("jobtitle"))
                    {
                        continue;
                    }
                    row["jobtitle"] = this.objBase.SpecialDecode(row["jobtitle"].ToString());
                }
            }
            _commonClass.closeConnection();
            this.GridViewDelivery.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewDelivery);
                this.div_Main.Style.Add("display", "block");
                this.GridViewDelivery.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewDelivery);
                this.div_Main.Style.Add("display", "block");
                this.GridViewDelivery.AllowCustomPaging = true;
                this.GridViewDelivery.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.getDeliveryRecordCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.getDeliveryRecCount != null)
                {
                    this.getDeliveryRecCount(this.getDeliveryRecordCount);
                    return;
                }
            }
        }

        private void GridStateLoad()
        {
            this.cmnClass.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewDelivery, "yes");
        }

        private void GridStateSave()
        {
            this.cmnClass.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewDelivery);
        }

        protected void GridViewDelivery_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void GridViewDelivery_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                string empty = string.Empty;
                string empty1 = string.Empty;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (base.Session["search_del"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_del"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_del"];
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
                base.Session["search_del"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.GridViewDelivery.Rebind();
            }
        }

        protected void GridViewDelivery_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewDelivery.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewDelivery.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewDelivery.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewDelivery.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.GridViewDelivery.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void GridViewDelivery_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewDelivery.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, this.GridViewDelivery.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void GridViewDelivery_SortCommand(object sender, GridSortCommandEventArgs e)
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
            this.GridViewDelivery.CurrentPageIndex = 0;
            HttpSessionState session = base.Session;
            object[] sortExpression = new object[] { 1, "±", this.defaultviewid, "±", e.SortExpression, "±", this.sortdirection, "±false" };
            session["delivery"] = string.Concat(sortExpression);
            this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, this.GridViewDelivery.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridViewDelivery(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridViewDelivery.Columns.Count; i++)
                {
                    if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewDelivery.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_deliverydate = "true";
                        this.cellvalue_deliverydate = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "posted")
                    {
                        this.flag_posted = "true";
                        this.cellvalue_posted = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "consignmentnumber")
                    {
                        this.flag_consignmentnotenumber = "true";
                        this.cellvalue_consignmentnotenumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "jobnumber")
                    {
                        this.flag_jobnumber = "true";
                        this.cellvalue_jobnumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "orderno")
                    {
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                    else if (this.GridViewDelivery.Columns[i].SortExpression.ToLower() == "jobtitle")
                    {
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridViewDelivery.Columns[i].SortExpression;
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string str = string.Concat("delivery/delivery_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString());
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                string empty = string.Empty;
                string languageConversion = string.Empty;
                empty = string.Concat(this.strImagepath, "Attachment.PNG");
                languageConversion = this.objLangClass.GetLanguageConversion("Item_With_Attachment");
                if (item["EstItemCoun"].Text == "0")
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                else
                {
                    ControlCollection controls = placeHolder.Controls;
                    string[] strArrays = new string[] { "<img src='", empty, "' title='", languageConversion, "' style='cursor:pointer;' />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                TableCell tableCell = item["DeliveryNumber"];
                string[] str1 = new string[] { "<a style='color:#10357F;' href=", this.strSitepath, "delivery/delivery_add.aspx?type=edit&id=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["DeliveryNumber"].Text, "</a>" };
                tableCell.Text = string.Concat(str1);
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                }
                if (this.flag_posted == "true")
                {
                    item[this.cellvalue_posted].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_posted].Style.Add("cursor", "pointer");
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                }
                if (this.flag_consignmentnotenumber == "true")
                {
                    item[this.cellvalue_consignmentnotenumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_consignmentnotenumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                }
                if (this.flag_jobnumber == "true")
                {
                    item[this.cellvalue_jobnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_jobnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_customerordernumber == "true")
                {
                    item[this.cellvalue_customerordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customerordernumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_jobtitle == "true")
                {
                    item[this.cellvalue_jobtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_jobtitle].Style.Add("cursor", "pointer");
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_deliverydate == "true")
                {
                    gridFilteringItem[this.cellvalue_deliverydate].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridViewDelivery.MasterTableView.NoMasterRecordsText = this.objLangClass.GetLanguageConversion("No_records_To_display");
            global.pageName = "deliverynote";
            global.pgName = "";
            this.gloobj.setpagename("deliverynote");
            this.pg = "deliverynote";
            this.pgsearch = "deliverynotesearch";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            languageClass _languageClass = new languageClass();
            this.Page.Title = _languageClass.convert(global.pageTitle("Delivery Note Search View", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            string str = this.cmnClass.UserSetting_Selete(this.CompanyID, this.UserID, "delivery_note_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (base.Session["DelViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["DelViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridViewDelivery.PageSize = 5;
                this.PageSize = 5;
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, "deliverynote");
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
                    this.SortedBy = "DeliveryNumber";
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
                base.Session["search_del"] = null;
                base.Session[str1] = null;
            }
            if (!base.IsPostBack && base.Request.Params["su"] != null)
            {
                if (base.Request.Params["su"].ToString().ToLower() == "in")
                {
                    this.objBase.Message_Display("Delivery Note Saved Successfully", "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "up")
                {
                    this.objBase.Message_Display("Delivery Note Updated Successfully", "successfulMsg", this.plhMessage);
                }
                else if (base.Request.Params["su"].ToString().ToLower() == "de")
                {
                    this.objBase.Message_Display("Delivery Note Deleted Successfully", "successfulMsg", this.plhMessage);
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
                    BaseClass baseClass = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str4 = baseClass.SpecialEncode(item.Split(chrArray)[0].ToString());
                    string[] strArrays = new string[] { " AND(CustomerID LIKE '%", str4, "%' OR Contact LIKE '%", str4, "%' OR ShippedTo LIKE '%", str4, "%' OR DeliveryAddress LIKE '%", str4, "%' OR Comments LIKE '%", str4, "%' OR DeliveryNumber LIKE '%", str4, "%' OR Status LIKE '%", str4, "%' OR JobNumber LIKE '%", str4, "%' OR CarrierInformation LIKE '%", str4, "%' OR ConsignmentNumber LIKE '%", str4, "%' OR JobTitle LIKE '%", str4, "%' OR GoodsDelivered LIKE '%", str4, "%')" };
                    str3 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str3;
                }
                this.GridStateLoad();
                if (base.Session["search_del"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_del"];
                    str2 = "";
                }
                base.Session["DelViewID"] = this.defaultviewid;
                this.PageSize = this.cmnClass.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewDelivery);
                this.GridViewDelivery.PageSize = this.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewDelivery.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.GridViewDelivery.Rebind();
            }
            this.GridViewDelivery.MasterTableView.GetColumn("DeliveryID").Visible = false;
        }

        public event GetDeliveyRecCount getDeliveryRecCount;
    }
}