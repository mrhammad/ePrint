using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.Proofs
{
    public partial class Proof_Search : System.Web.UI.UserControl
    {
        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private commonClass objJava = new commonClass();

        private EstimateBasePage ObjEst = new EstimateBasePage();

        private commonClass comm = new commonClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        public int totalrec;

        private string para = string.Empty;

        public string newdate = string.Empty;

        public int CompanyID;

        public int defaultviewid;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string pg;

        public DataTable dt = new DataTable();

        private createViewClass objCreateView = new createViewClass();

        public string cellvalue_deliverydate = string.Empty;

        public string flag_deliverydate = string.Empty;

        public string cellvalue_createddate = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_completiondate = string.Empty;

        public string flag_completiondate = string.Empty;

        public string cellvalue_ispaid = string.Empty;

        public string flag_ispaid = string.Empty;

        public string cellvalue_Invval = string.Empty;

        public string flag_Invval = string.Empty;

        public string cellvalue_InvoiceAmountPaid = string.Empty;

        public string flag_InvoiceAmountPaid = string.Empty;

        public string cellvalue_InvoiceOutstanding = string.Empty;

        public string flag_InvoiceOutstanding = string.Empty;

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string cellvalue_InvvalExcGst = string.Empty;

        public string flag_InvvalExcGst = string.Empty;

        public string cellvalue_Quantity = string.Empty;

        public string flag_Quantity = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_invoicetitle = string.Empty;

        public string flag_invoicetitle = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_customeraccountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_customerordernumber = string.Empty;

        public string flag_customerordernumber = string.Empty;

        public string cellvalue_referredby = string.Empty;

        public string flag_referredby = string.Empty;

        public string cellvalue_contactname = string.Empty;

        public string flag_contactname = string.Empty;

        public string cellvalue_salesperson = string.Empty;

        public string flag_salesperson = string.Empty;

        public string cellvalue_costcentre = string.Empty;

        public string flag_costcentre = string.Empty;

        public string cellvalue_invoicetype = string.Empty;

        public string flag_invoicetype = string.Empty;

        public string cellvalue_EstimateNumber = string.Empty;

        public string flag_EstimateNumber = string.Empty;

        public string cellvalue_JobNumber = string.Empty;

        public string flag_JobNumber = string.Empty;

        public string cellvalue_InvoiceDueDate = string.Empty;

        public string flag_InvoiceDueDate = string.Empty;

        public int UserID;

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public int PageSize;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        private DataTable dtArtwork = new DataTable();

        public int ViewID;

        public string Mode = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string pgsearch = string.Empty;

        public string flag_ItemStatus = string.Empty;

        public string cellvalue_ItemStatus = string.Empty;

        public string flag_ItemTitle = string.Empty;

        public string cellvalue_ItemTitle = string.Empty;

        public string flag_ItemAccCode = string.Empty;

        public string cellvalue_ItemAccCode = string.Empty;

        public string flag_ItemQTY = string.Empty;

        public string cellvalue_ItemQTY = string.Empty;

        public string flag_ItemValue_ExcTax = string.Empty;

        public string cellvalue_ItemValue_ExcTax = string.Empty;

        public string flag_ItemValue_IncTax = string.Empty;

        public string cellvalue_ItemValue_IncTax = string.Empty;

        public string flag_ItemTaxValue = string.Empty;

        public string cellvalue_ItemTaxValue = string.Empty;

        public string flag_ItemCostPriceExcMarkup = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup = string.Empty;

        public string flag_ItemMarkupValue = string.Empty;

        public string cellvalue_ItemMarkupValue = string.Empty;

        public string flag_ItemCostPriceIncMarkup = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup = string.Empty;

        public string flag_ItemProfitMarginPercentage = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage = string.Empty;

        public string flag_ItemProfitMarginValue = string.Empty;

        public string cellvalue_ItemProfitMarginValue = string.Empty;

        public string flag_ItemGrossProfitPercentage = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage = string.Empty;

        public string flag_ItemGrossProfitValue = string.Empty;

        public string cellvalue_ItemGrossProfitValue = string.Empty;

        public string flag_EventName = string.Empty;

        public string cellvalue_EventName = string.Empty;

        public string flag_EventCodeNumber = string.Empty;

        public string cellvalue_EventCodeNumber = string.Empty;

        public string flag_CampaignSignNumber = string.Empty;

        public string cellvalue_CampaignSignNumber = string.Empty;

        public string flag_ItemMaterial = string.Empty;

        public string cellvalue_ItemMaterial = string.Empty;

        public string flag_EventVenue = string.Empty;

        public string cellValue_EventVenue = string.Empty;

        public string flag_Height = string.Empty;

        public string cellvalue_Height = string.Empty;

        public string flag_Width = string.Empty;

        public string cellvalue_Width = string.Empty;

        public string flag_ItemDescription = string.Empty;

        public string cellvalue_ItemDescription = string.Empty;

        public string flag_ItemColour = string.Empty;

        public string cellvalue_ItemColour = string.Empty;

        public string flag_ItemSize = string.Empty;

        public string cellvalue_ItemSize = string.Empty;

        public string flag_ItemArtwork = string.Empty;

        public string cellvalue_ItemArtwork = string.Empty;

        public string flag_ItemDelivery = string.Empty;

        public string cellvalue_ItemDelivery = string.Empty;

        public string flag_ItemFinishing = string.Empty;

        public string cellvalue_ItemFinishing = string.Empty;

        public string flag_ItemProofs = string.Empty;

        public string cellvalue_ItemProofs = string.Empty;

        public string flag_ItemPacking = string.Empty;

        public string cellvalue_ItemPacking = string.Empty;

        public string flag_ItemNotes = string.Empty;

        public string cellvalue_ItemNotes = string.Empty;

        public string flag_ItemTermsInstructions = string.Empty;

        public string cellvalue_ItemTermsInstructions = string.Empty;

        public string flag_JobName = string.Empty;

        public string cellvalue_JobName = string.Empty;

        public bool IsItemSelected;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }
        public Proof_Search()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridViewProof.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "completiondate" || dt.Columns[i].ColumnName.ToLower() == "deliverydate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                }
                for (int j = 1; j < this.GridViewProof.Columns.Count; j++)
                {
                    this.GridViewProof.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewProof.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewProof.Columns[j].SortExpression.ToLower() == "invoicenumber")
                    {
                        this.GridViewProof.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_No");
                    }
                    else if (this.GridViewProof.Columns[j].SortExpression.ToLower() == "customertype")
                    {
                        this.GridViewProof.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Type");
                    }
                   
                }
            }
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textBox = (TextBox)this.Page.Master.FindControl("keywordsearch");
            //if (textBox.Text != "")
            //{
            //    this.para = this.objBase.ReplaceSingleQuote(textBox.Text);
            //    base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_search.aspx?para=", this.para));
            //}
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
            //sqlCommand.CommandTimeout = 300;
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
                    if (row.Table.Columns.Contains("CompletionDate"))
                    {
                        row["CompletionDate"] = this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CreatedDate"))
                    {
                        row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("SalesPerson"))
                    {
                        row["SalesPerson"] = this.objBase.SpecialDecode(row["SalesPerson"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerID"))
                    {
                        row["CustomerID"] = this.objBase.SpecialDecode(row["CustomerID"].ToString());
                    }
                 
                }
            }
            _commonClass.closeConnection();
            this.GridViewProof.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewProof);
                this.div_Main.Style.Add("display", "block");
                this.GridViewProof.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewProof);
                this.div_Main.Style.Add("display", "block");
                this.GridViewProof.AllowCustomPaging = true;
                this.GridViewProof.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                //this.Proofreccount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                //if (this.getProofRecordCount != null)
                //{
                //    this.getProofRecordCount(this.proofreccount);
                //    return;
                //}
            }
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewProof, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewProof);
        }

        protected void GridViewProof_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void GridViewProof_ItemCommand(object sender, GridCommandEventArgs e)
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
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "invoicevalue" || commandArgument.Second.ToString().ToLower() == "quantity"))
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
                if (base.Session["search_Proof"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_Inv"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_Proof"];
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
                base.Session["search_Proof"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.GridViewProof.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.GridViewProof.Rebind();
            }
        }

        protected void GridViewProof_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewProof.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewProof.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewProof.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewProof.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.GridViewProof.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void GridViewProof_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewProof.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewProof.PageSize, this.GridViewProof.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void GridViewProof_SortCommand(object sender, GridSortCommandEventArgs e)
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
            this.GridViewProof.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewProof.PageSize, this.GridViewProof.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
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

        protected void OnRowDataBound_GridViewProof(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridViewProof.Columns.Count; i++)
                {
                    if (this.GridViewProof.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewProof.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewProof.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_deliverydate = "true";
                        this.cellvalue_deliverydate = this.GridViewProof.Columns[i].SortExpression;
                    }
                    else if (this.GridViewProof.Columns[i].SortExpression.ToLower() == "completiondate")
                    {
                        this.cellvalue_completiondate = this.GridViewProof.Columns[i].SortExpression;
                        this.flag_completiondate = "true";
                    }
                    else if (this.GridViewProof.Columns[i].SortExpression.ToLower() == "invoicevalue")
                    {
                        this.cellvalue_Invval = this.GridViewProof.Columns[i].SortExpression;
                        this.flag_Invval = "true";
                    }
                    else if (this.GridViewProof.Columns[i].SortExpression.ToLower() == "invoiceamountpaid")
                    {
                        this.cellvalue_InvoiceAmountPaid = this.GridViewProof.Columns[i].SortExpression;
                        this.flag_InvoiceAmountPaid = "true";
                    }
                   
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_attach");
                string str = string.Empty;
                string empty1 = string.Empty;
                str = string.Concat(this.strImagepath, "Attachment.PNG");
                empty1 = "Item with an attachment(s)";
                string str1 = string.Empty;
                string languageConversion = string.Empty;
                str1 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                string empty2 = string.Empty;
                DataRow[] dataRowArray = this.dtArtwork.Select(string.Concat("EstimateID=", ((DataRowView)e.Item.DataItem)[1].ToString()));
                if ((int)dataRowArray.Length > 0)
                {
                    empty2 = dataRowArray[0]["ArtWork"].ToString();
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls = placeHolder.Controls;
                    string[] strArrays = new string[] { "<img src='", str1, "'  title='", languageConversion, "' class='viewicon_margin'  />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                if (item["EstItemCoun"].Text != "0" || empty2 != "")
                {
                    ControlCollection controlCollections = placeHolder1.Controls;
                    string[] strArrays1 = new string[] { "<img src='", str, "' title='", empty1, "' style='cursor:pointer;'/>" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                if (item["isfromwebstore"].Text.Trim().ToLower() != "yes")
                {
                    empty = string.Concat("invoice/invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell = item["invoicenumber"];
                        string[] str2 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        tableCell.Text = string.Concat(str2);
                    }
                    else
                    {
                        empty = string.Concat(empty, "&EstItemID=", item["EstimateItemID"].Text);
                        TableCell item1 = item["invoicenumber"];
                        string[] strArrays2 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", item["EstimateItemID"].Text, ">", item["invoicenumber"].Text, "</a>" };
                        item1.Text = string.Concat(strArrays2);
                    }
                }
                else
                {
                    string[] str3 = new string[] { "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString() };
                    empty = string.Concat(str3);
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell1 = item["invoicenumber"];
                        string[] strArrays3 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        tableCell1.Text = string.Concat(strArrays3);
                    }
                    else
                    {
                        empty = string.Concat(empty, "&EstItemID=", item["EstimateItemID"].Text);
                        TableCell item2 = item["invoicenumber"];
                        string[] str4 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", item["EstimateItemID"].Text, ">", item["invoicenumber"].Text, "</a>" };
                        item2.Text = string.Concat(str4);
                    }
                }
                if (((DataRowView)e.Item.DataItem).DataView.Table.Columns.Contains("CustomerType") && item["CustomerType"].Text.Trim().Length > 30)
                {
                    item["CustomerType"].ToolTip = item["CustomerType"].Text;
                    item["CustomerType"].Text = string.Concat(item["CustomerType"].Text.Substring(0, 30), "..");
                }
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                }
                if (this.flag_completiondate == "true")
                {
                    item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                    item[this.cellvalue_completiondate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_completiondate].Style.Add("cursor", "pointer");
                }
                if (this.flag_Invval == "true")
                {
                    item[this.cellvalue_Invval].Attributes.Add("align", "right");
                    item[this.cellvalue_Invval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Invval].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Invval].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Invval].Text), 0, "", false, false, true);
                }
                if (this.flag_InvoiceAmountPaid == "true")
                {
                    item[this.cellvalue_InvoiceAmountPaid].Attributes.Add("align", "right");
                    item[this.cellvalue_InvoiceAmountPaid].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceAmountPaid].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvoiceAmountPaid].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvoiceAmountPaid].Text), 0, "", false, false, true);
                }
               
                if (this.flag_InvvalExcGst == "true")
                {
                    item[this.cellvalue_InvvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_InvvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvvalExcGst].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvvalExcGst].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvvalExcGst].Text), 0, "", false, false, true);
                }
                if (this.flag_ispaid == "true")
                {
                    item[this.cellvalue_ispaid].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ispaid].Style.Add("cursor", "pointer");
                }
                if (this.flag_Quantity == "true")
                {
                    item[this.cellvalue_Quantity].Attributes.Add("align", "right");
                    item[this.cellvalue_Quantity].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Quantity].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Quantity].Text = item[this.cellvalue_Quantity].Text;
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                }
                if (this.flag_invoicetitle == "true")
                {
                    item[this.cellvalue_invoicetitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_invoicetitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_customeraccountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customeraccountnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_salesperson == "true")
                {
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                }
                if (this.flag_customerordernumber == "true")
                {
                    item[this.cellvalue_customerordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customerordernumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                }
                
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridViewProof.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_Display");
            global.pageName = "proof";
            global.pgName = "";
            this.gloobj.setpagename("proof");
            this.pg = "proof";
            this.pgsearch = "proofsearch";
            this.strImagepath = global.imagePath();
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            this.Page.Title = this.objLanguage.convert(global.pageTitle("Proofs Search view", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_DateTime_Before_View(now.ToString().ToString(), this.CompanyID, this.UserID, true);
            //string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "proofs_view");
            //if (str != "" && str != null)
            //{
            //    this.defaultviewid = Convert.ToInt32(str);
            //}
            //if (base.Session["ProofViewID"] != null)
            //{
            //    this.defaultviewid = Convert.ToInt32(base.Session["ProofViewID"]);
            //}
            DataTable dt = EstimateBasePage.GetProofViewDefault(this.CompanyID,this.UserID);
            foreach(DataRow dr in dt.Rows)
            {
                this.defaultviewid = int.Parse(dr["ViewID"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.GridViewProof.PageSize = 5;
                this.PageSize = 5;
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, "proof");
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
                    this.SortedBy = "ProofNumber";
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
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            try
            {
                if (base.Request.QueryString["custom"] != null)
                {
                    string empty = string.Empty;
                    empty = base.Request.QueryString["custom"].ToString().Trim();
                    if (empty != "")
                    {
                        empty = this.objBase.ReplaceSingleQuote(empty);
                        this.GridBind(this.CompanyID, this.UserID, this.GridViewProof.PageSize, 1, this.defaultviewid, "CustomerID", "desc", empty, this.ViewState["WhereCondition"].ToString());
                    }
                }
            }
            catch
            {
            }
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            if (!base.IsPostBack)
            {
                string str1 = "";
                string str2 = "";
                if (base.Request.Params["srch_val"] != null)
                {
                    BaseClass baseClass = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str3 = baseClass.SpecialEncode(item.Split(chrArray)[0].ToString());
                    string[] strArrays = new string[] { " AND(CustomerID LIKE '%", str3, "%' OR Department LIKE '%", str3, "%' OR Estimator LIKE '%", str3, "%' OR Greeting LIKE '%", str3, "%' OR SalesPerson LIKE '%", str3, "%' OR EstimateTitle LIKE '%", str3, "%' OR InvoiceNumber LIKE '%", str3, "%' OR EstimateNumber LIKE '%", str3, "%' OR JobNumber LIKE '%", str3, "%' OR CustomerOrderNumber LIKE '%", str3, "%' OR CustomerType like   '%", str3, "%' OR ((ContactAddress + ' ' + DeliveryAddress + ' ' + InvoiceAddress + ' ' + Address1 + ' ' + Address2 + ' ' + Address3 + ' ' + Address4 + ' ' + Address5) like '%", str3, "%') OR Status LIKE '%", str3, "%')" };
                    str2 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str2;
                }
                this.GridStateLoad();
                if (base.Session["search_Inv"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_Inv"];
                    str1 = "";
                }
                base.Session["InvViewID"] = this.defaultviewid;
                this.PageSize = this.objJava.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewProof);
                this.GridViewProof.PageSize = this.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewProof.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str1, str2);
                this.GridStateLoad();
                this.GridViewProof.Rebind();
            }
            this.GridViewProof.MasterTableView.GetColumn("ProofID").Visible = false;
            this.GridViewProof.MasterTableView.GetColumn("estimateid").Visible = false;
            if (this.GridViewProof.MasterTableView.GetColumn("estimateitemid") != null)
            {
                this.GridViewProof.MasterTableView.GetColumn("estimateitemid").Visible = false;
            }
        }

        public event GetProofRecCount getProofRecordCount;
    }
}