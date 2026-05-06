using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.warehouse
{
    public partial class mass_adjustment : System.Web.UI.UserControl
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        private BaseClass obj = new BaseClass();

        private InventoryBasePage objinv = new InventoryBasePage();

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string type = string.Empty;

        public int CompanyID;

        public int UserID;

        public static int totalrec;

        public commonClass cmns = new commonClass();

        public int PageSize = 10000;

        public static string SearchText;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public static decimal finalcost;

        public languageClass objLangClass = new languageClass();

        public string DateFormat = string.Empty;

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

        static mass_adjustment()
        {
            mass_adjustment.SearchText = string.Empty;
            mass_adjustment.finalcost = new decimal(0);
        }

        public mass_adjustment()
        {
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            mass_adjustment.SearchText = this.txtSearch.Text;
            this.Grid_Inv_Search(1);
            this.ddlCategory.SelectedIndex = 0;
            this.rdlChangeInd.Checked = true;
            this.rdlChangeAll.Checked = false;
        }

        protected void btnShowAll_OnClick(object sender, EventArgs e)
        {
            this.txtSearch.Text = "";
            this.Grid_Inv_Bind(1);
        }

        protected void btnTaxRatesCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnTaxRatesSave_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.rdlChangeInd.Checked)
            {
                if (this.GridInventory.Items.Count != 0)
                {
                    for (int i = 0; i < this.GridInventory.Items.Count; i++)
                    {
                        for (int j = 0; j < this.GridInventory.Columns.Count; j++)
                        {
                            if (j == 9)
                            {
                                int num = 0;
                                Label label = (Label)this.GridInventory.Items[i].Cells[j].FindControl("lblInventoryID");
                                Label label1 = (Label)this.GridInventory.Items[i].Cells[j].FindControl("lblInventoryPropertyID");
                                Label label2 = (Label)this.GridInventory.Items[i].Cells[j].FindControl("lblInStock");
                                Label label3 = (Label)this.GridInventory.Items[i].Cells[j].FindControl("lblCost");
                                label3.Text = label3.Text.Replace(",", "");
                                label2.Text = label2.Text.Replace(",", "");
                                DropDownList dropDownList = (DropDownList)this.GridInventory.Items[i].Cells[j].FindControl("ddlMinusPlus");
                                TextBox textBox = (TextBox)this.GridInventory.Items[i].Cells[j + 1].FindControl("txtReasonadjustment");
                                TextBox str = (TextBox)this.GridInventory.Items[i].Cells[j].FindControl("txtPerQty");
                                DropDownList dropDownList1 = (DropDownList)this.GridInventory.Items[i].Cells[j].FindControl("ddlcosttype");
                                textBox.Text = textBox.Text.Replace(",", "");
                                str.Text = str.Text.Replace(",", "");
                                if (str.Text == "")
                                {
                                    str.Text = "0";
                                }
                                if (str.Text == "")
                                {
                                    str.Text = "0";
                                }
                                decimal num1 = new decimal(0);
                                if (dropDownList.SelectedItem.Value.ToLower() == "plus")
                                {
                                    num1 = Convert.ToDecimal(label2.Text) + Convert.ToDecimal(str.Text);
                                    empty = "r";
                                    if (textBox.Text == "")
                                    {
                                        textBox.Text = "Stock Replenished";
                                    }
                                }
                                if (dropDownList.SelectedItem.Value.ToLower() == "minus")
                                {
                                    num1 = Convert.ToDecimal(label2.Text) - Convert.ToDecimal(str.Text);
                                    empty = "d";
                                    if (textBox.Text == "")
                                    {
                                        textBox.Text = "Stock Reduced";
                                    }
                                }
                                str.Text = num1.ToString();
                                TextBox textBox1 = (TextBox)this.GridInventory.Items[i].Cells[j + 1].FindControl("txtCost");
                                if (!(dropDownList1.SelectedItem.Value == "%") || !(textBox1.Text != "0"))
                                {
                                    mass_adjustment.finalcost = Convert.ToDecimal(textBox1.Text);
                                }
                                else
                                {
                                    mass_adjustment.finalcost = Convert.ToDecimal(label3.Text) + ((Convert.ToDecimal(label3.Text) * Convert.ToDecimal(textBox1.Text)) / new decimal(100));
                                }
                                this.objinv.warehouse_inventory_adjustment_update(this.CompanyID, Convert.ToInt64(label.Text), Convert.ToInt64(label1.Text), Convert.ToInt32(str.Text), Convert.ToDecimal(mass_adjustment.finalcost));
                                num = 1;
                                if (this.InventoryManagement == "IM" && empty != null && str.Text != "0")
                                {
                                    this.cmns.Insert_Activity_History_For_Inventory(Convert.ToInt64(label.Text), string.Concat(textBox.Text, "µ"), this.UserID, Convert.ToInt32(str.Text), empty, Convert.ToInt32(Convert.ToDecimal(label2.Text)));
                                }
                                if (num == 1)
                                {
                                    this.obj.Message_Display(this.objLangClass.GetLanguageConversion("Inventory_Item_Saved_Successfully"), "msg-success", this.plhMessage);
                                }
                            }
                        }
                    }
                }
            }
            else if (this.rdlChangeAll.Checked)
            {
                this.GridInventory.AllowPaging = false;
                this.GridInventory.Rebind();
                decimal num2 = Convert.ToDecimal(this.txtAlterStock.Text);
                if (this.txtAlterStock.Text == "")
                {
                    this.txtAlterStock.Text = "0";
                }
                if (this.txtAlterStock.Text == "")
                {
                    this.txtAlterStock.Text = "0";
                }
                for (int k = 0; k < this.GridInventory.Items.Count; k++)
                {
                    Label label4 = (Label)this.GridInventory.Items[k].Cells[9].FindControl("lblInventoryID");
                    Label label5 = (Label)this.GridInventory.Items[k].Cells[9].FindControl("lblInventoryPropertyID");
                    Label label6 = (Label)this.GridInventory.Items[k].Cells[9].FindControl("lblInStock");
                    Label label7 = (Label)this.GridInventory.Items[k].Cells[9].FindControl("lblCost");
                    label7.Text = label7.Text.Replace(",", "");
                    label6.Text = label6.Text.Replace(",", "");
                    if (this.ddlChangeAllMinusPlus.SelectedItem.Value.ToLower() == "plus")
                    {
                        num2 = Convert.ToDecimal(label6.Text) + Convert.ToDecimal(this.txtAlterStock.Text);
                        empty = "r";
                        if (this.txtChangeAllReasonadjustment.Text == "")
                        {
                            this.txtChangeAllReasonadjustment.Text = "Stock Replenished";
                        }
                    }
                    if (this.ddlChangeAllMinusPlus.SelectedItem.Value.ToLower() == "minus")
                    {
                        num2 = Convert.ToDecimal(label6.Text) - Convert.ToDecimal(this.txtAlterStock.Text);
                        empty = "d";
                        if (this.txtChangeAllReasonadjustment.Text == "")
                        {
                            this.txtChangeAllReasonadjustment.Text = "Stock Reduced";
                        }
                    }
                    num2.ToString();
                    if (Convert.ToDecimal(this.txtAlterCost.Text) == new decimal(0))
                    {
                        mass_adjustment.finalcost = Convert.ToDecimal(label7.Text);
                    }
                    else if (!(this.ddlcostin.SelectedItem.Value == "%") || !(Convert.ToDecimal(this.txtAlterCost.Text) > new decimal(0)))
                    {
                        mass_adjustment.finalcost = Convert.ToDecimal(label7.Text) + (Convert.ToDecimal(this.txtAlterCost.Text) * Convert.ToDecimal(string.Concat(this.ddlChangeAllMinusPlusCP.SelectedItem.Text, "1")));
                    }
                    else
                    {
                        mass_adjustment.finalcost = Convert.ToDecimal(label7.Text) + (((Convert.ToDecimal(label7.Text) * Convert.ToDecimal(this.txtAlterCost.Text)) * Convert.ToDecimal(string.Concat(this.ddlChangeAllMinusPlusCP.SelectedItem.Text, "1"))) / new decimal(100));
                    }
                    this.objinv.warehouse_inventory_adjustment_update(this.CompanyID, Convert.ToInt64(label4.Text), Convert.ToInt64(label5.Text), Convert.ToInt32(num2), Convert.ToDecimal(mass_adjustment.finalcost));
                    if (this.InventoryManagement == "IM" && empty != null && this.txtAlterStock.Text != "0")
                    {
                        this.cmns.Insert_Activity_History_For_Inventory(Convert.ToInt64(label4.Text), string.Concat(this.obj.SpecialEncode(this.txtChangeAllReasonadjustment.Text), "µ"), this.UserID, Convert.ToInt32(num2), empty, Convert.ToInt32(label6.Text));
                    }
                }
                this.GridInventory.AllowPaging = true;
            }
            if (this.txtSearch.Text != "")
            {
                this.Grid_Inv_Search(1);
                return;
            }
            this.Grid_Inv_Bind(1);
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridInventory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridInventory.MasterTableView.FilterExpression = string.Empty;
            this.GridInventory.MasterTableView.Rebind();
        }

        private void DDPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtSearch.Text != "")
            {
                this.Grid_Inv_Search(1);
                return;
            }
            this.Grid_Inv_Bind(1);
        }

        public void Grid_Inv_Bind(int PageNumber)
        {
            if (this.ddlCategory.SelectedValue == "0")
            {
                DataTable dataTable = this.objinv.warehouse_inventory_selectall(this.CompanyID, "all", this.obj.SpecialEncode(this.txtSearch.Text));
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataTable.Columns[i].ReadOnly = false;
                }
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["Date"] = this.cmns.Eprint_return_Date_Before_View(row["Date"].ToString(), this.CompanyID, this.UserID, false);
                        row["InventoryName"] = this.obj.SpecialDecode(row["InventoryName"].ToString());
                        row["InventoryCode"] = this.obj.SpecialDecode(row["InventoryCode"].ToString());
                        row["Description"] = this.obj.SpecialDecode(row["Description"].ToString());
                        row["SupplierName"] = this.obj.SpecialDecode(row["SupplierName"].ToString());
                    }
                }
                this.GridInventory.DataSource = dataTable;
                this.GridInventory.DataBind();
                return;
            }
            DataTable dataTable1 = this.objinv.warehouse_inventory_selectall(this.CompanyID, this.obj.SpecialEncode(this.ddlCategory.SelectedItem.Text), this.obj.SpecialEncode(this.txtSearch.Text));
            for (int j = 0; j < dataTable1.Columns.Count; j++)
            {
                dataTable1.Columns[j].ReadOnly = false;
            }
            if (dataTable1 != null)
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    dataRow["Date"] = this.cmns.Eprint_return_Date_Before_View(dataRow["Date"].ToString(), this.CompanyID, this.UserID, false);
                    dataRow["InventoryName"] = this.obj.SpecialDecode(dataRow["InventoryName"].ToString());
                    dataRow["InventoryCode"] = this.obj.SpecialDecode(dataRow["InventoryCode"].ToString());
                    dataRow["Description"] = this.obj.SpecialDecode(dataRow["Description"].ToString());
                    dataRow["SupplierName"] = this.obj.SpecialDecode(dataRow["SupplierName"].ToString());
                }
            }
            this.GridInventory.DataSource = dataTable1;
            this.GridInventory.DataBind();
        }

        private void Grid_Inv_Search(int PageNumber)
        {
            if (this.txtSearch.Text != "")
            {
                this.odsInventory.TypeName = "Printcenter.UI.Inventories.InventoryBasePage";
                this.odsInventory.SelectMethod = "warehouse_inventory_search";
                this.odsInventory.SelectParameters.Clear();
                this.odsInventory.SelectParameters.Add("CompanyID", base.Session["CompanyID"].ToString());
                this.odsInventory.SelectParameters.Add("SearchText", this.obj.SpecialEncode(this.txtSearch.Text));
                this.odsInventory.DataBind();
            }
            else
            {
                this.odsInventory.TypeName = "Printcenter.UI.Inventories.InventoryBasePage";
                this.odsInventory.SelectMethod = "warehouse_inventory_selectall";
                this.odsInventory.SelectParameters.Clear();
                this.odsInventory.SelectParameters.Add("CompanyID", base.Session["CompanyID"].ToString());
                this.odsInventory.SelectParameters.Add("ItemType", "all");
                this.odsInventory.SelectParameters.Add("SearchText", this.obj.SpecialEncode(this.txtSearch.Text));
                this.odsInventory.DataBind();
            }
            this.GridInventory.DataBind();
            if (this.GridInventory.Items.Count > 0)
            {
                DataTable table = ((DataView)this.odsInventory.Select()).Table;
                mass_adjustment.totalrec = table.Rows.Count;
            }
        }

        protected void GridInventory_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = this.objinv.warehouse_inventory_selectall(this.CompanyID, this.obj.SpecialEncode(this.ddlCategory.SelectedItem.Text), this.obj.SpecialEncode(this.txtSearch.Text));
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    row["Date"] = this.cmns.Eprint_return_Date_Before_View(row["Date"].ToString(), this.CompanyID, this.UserID, false);
                    row["InventoryName"] = this.obj.SpecialDecode(row["InventoryName"].ToString());
                    row["InventoryCode"] = this.obj.SpecialDecode(row["InventoryCode"].ToString());
                    row["Description"] = this.obj.SpecialDecode(row["Description"].ToString());
                    row["SupplierName"] = this.obj.SpecialDecode(row["SupplierName"].ToString());
                }
            }
            this.GridInventory.DataSource = dataTable;
        }

        protected void GridInventory_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
                item["cost"].Text = string.Concat(this.objLangClass.GetLanguageConversion("Price"), " (", this.cmns.GetCurrencyinRequiredFormate("", true), ")");
                item["AlterPrice"].Text = string.Concat(this.objLangClass.GetLanguageConversion("Alter_Price"), " (", this.cmns.GetCurrencyinRequiredFormate("", true), ")");
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                TextBox textBox = (TextBox)e.Item.FindControl("txtPerQty");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtCost");
                Label label = (Label)e.Item.FindControl("lblInStock");
                Label label1 = (Label)e.Item.FindControl("lblCost");
                Label label2 = (Label)e.Item.FindControl("lblDate");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlMinusPlus");
                TextBox textBox2 = (TextBox)e.Item.FindControl("txtReasonadjustment");
                textBox1.Text = this.cmns.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox1.Text), 0, "", false, false, true);
                textBox.Text = this.cmns.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(textBox.Text), 0, "", false, false, true);
                label1.Text = this.cmns.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
                label.Text = this.cmns.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", false, false, true);
                label.Text = label.Text.Substring(0, label.Text.IndexOf("."));
                textBox.Text = textBox.Text.Substring(0, textBox.Text.IndexOf("."));
                textBox.Attributes.Add("onkeyup", "javascript:ToInteger(this,this.value);AllowNumber(this,this.value);");
                textBox.Attributes.Add("onkeychange", "javascript:ToInteger(this,this.value);AllowNumber(this,this.value);");
                textBox1.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
                textBox1.Attributes.Add("onkeychange", "javascript:AllowNumber(this,this.value);");
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlcosttype");
                dropDownList1.Items.Insert(0, this.cmns.GetCurrencyinRequiredFormate("", true));
                dropDownList1.Items[0].Selected = true;
                dropDownList1.Items.Insert(1, "%");
                if (this.InventoryManagement == "IM")
                {
                    dropDownList.Attributes.Add("onchange", string.Concat("javascript:Toggle(this.value,'", e.Item.Cells[8].ClientID, "');"));
                }
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
            this.GridInventory.CurrentPageIndex = e.NewPageIndex;
            try
            {
                this.GridInventory.Rebind();
                this.txtSearch.Text = "";
            }
            catch
            {
                this.txtSearch.Text = mass_adjustment.SearchText;
                this.Grid_Inv_Search(1);
            }
        }

        protected void GridInventory_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            try
            {
                this.GridInventory.Rebind();
                this.txtSearch.Text = "";
            }
            catch
            {
                this.txtSearch.Text = mass_adjustment.SearchText;
                this.Grid_Inv_Search(1);
            }
        }

        private void GridStateLoad()
        {
            this.cmns.GridStateLoadNew("setting", "InventoryAdjustment", this.GridInventory, "no");
        }

        private void GridStateSave()
        {
            this.cmns.GridStateSaveNew("setting", "InventoryAdjustment", this.GridInventory);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
            GridFilterMenu filterMenu = this.GridInventory.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
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
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnSelectedIndexChanged_ddlCategory(object sender, EventArgs e)
        {
            this.Grid_Inv_Bind(1);
            this.txtSearch.Text = "";
            this.rdlChangeInd.Checked = true;
            this.rdlChangeAll.Checked = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnTaxRatesCancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btnTaxRatesCancelprocess');");
            this.GridInventory.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Item_Code").ToString();
            this.GridInventory.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Date").ToString();
            this.GridInventory.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Supplier").ToString();
            this.GridInventory.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("In_Stock_Qty").ToString();
            this.GridInventory.Columns[7].HeaderText = this.objLangClass.GetLanguageConversion("Alter_Stock_Qty").ToString();
            this.GridInventory.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Notes").ToString();
            this.ddlcostin.Items.Insert(0, "%");
            this.ddlcostin.Items.Insert(1, this.cmns.GetCurrencyinRequiredFormate("", true));
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["userID"].ToString());
            this.txtSearch.Focus();
            this.txtAlterCost.Text = this.cmns.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtAlterCost.Text), 0, "", false, false, true);
            if (!base.Request.Url.ToString().ToLower().Contains("warehouse/inventory_adjustment.aspx"))
            {
                this.lblheader.Text = "Settings: Inventory Adjustment";
            }
            else
            {
                this.lblheader.Text = this.objLangClass.GetLanguageConversion("Warehouse_Inventory_Adjustment");
            }
            if (!base.IsPostBack)
            {
                base.Session["invadjust"] = string.Empty;
                this.objinv.Bind_Stock_Category(this.ddlCategory, this.CompanyID, "All");
                if (base.Request.QueryString["type"] != null)
                {
                    this.type = base.Request.QueryString["type"].ToString();
                    if (this.type == "inventory")
                    {
                        this.lblheader.Text = "Warehouse: Inventory Adjustment";
                    }
                    else if (this.type == "store")
                    {
                        this.lblheader.Text = "Warehouse: Store Supply Adjustment";
                    }
                    else if (this.type == "item")
                    {
                        this.lblheader.Text = "Warehouse: Customer Item Adjustment";
                    }
                }
                if (this.txtSearch.Text == "")
                {
                    this.Grid_Inv_Bind(1);
                }
                else
                {
                    this.Grid_Inv_Search(1);
                }
            }
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
            }
            if (this.InventoryManagement == "IM")
            {
                this.GridInventory.MasterTableView.Columns[8].Visible = true;
            }
            else
            {
                this.GridInventory.MasterTableView.Columns[8].Visible = false;
            }
            this.btnTaxRatesSave.Attributes.Add("onclick", "javascript:var a=savevalidate();if(a)return Check_zeros();return a;");
            this.txtAlterCost.Attributes.Add("onkeyup", "javascript:AllowNumber(this,this.value);");
            this.txtAlterCost.Attributes.Add("onkeychange", "javascript:AllowNumber(this,this.value);");
            this.txtAlterStock.Attributes.Add("onkeyup", "javascript:ToInteger(this,this.value);AllowNumber(this,this.value);");
            this.txtAlterStock.Attributes.Add("onkeychange", "javascript:ToInteger(this,this.value);AllowNumber(this,this.value);");
            this.rdlChangeInd.Text = this.objLangClass.GetLanguageConversion("Change_Individually");
            this.rdlChangeAll.Text = this.objLangClass.GetLanguageConversion("Change_All");
            this.txtChangeAllReasonadjustment.Text = this.objLangClass.GetLanguageConversion("Stock_Replenished");
            this.btnTaxRatesCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnTaxRatesSave.Text = this.objLangClass.GetLanguageConversion("Save");
        }

        private void usrPaging_OnPageChange(int PageNumber)
        {
            if (this.txtSearch.Text != "")
            {
                this.Grid_Inv_Search(PageNumber);
                return;
            }
            this.Grid_Inv_Bind(PageNumber);
        }
    }
}