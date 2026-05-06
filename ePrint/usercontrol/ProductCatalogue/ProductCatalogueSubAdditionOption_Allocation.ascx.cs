using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.ProductCatalogue
{
    public partial class ProductCatalogueSubAdditionOption_Allocation : System.Web.UI.UserControl
    {
        public int CompanyID;

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSetting = new SettingsBasePage();

        private BaseClass objBase = new BaseClass();

        public string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

        public string Action = string.Empty;

        public long productCatalogueID;

        public string CustomerValues = string.Empty;

        protected IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> AllocatedCustomers
        {
            get
            {
                IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> customaerLists;
                try
                {
                    object item = base.Session["AllocatedCustomers"];
                    if (item == null)
                    {
                        item = this.GetAllocatedCustomers();
                        if (item == null)
                        {
                            item = new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
                        }
                        else
                        {
                            base.Session["AllocatedCustomers"] = item;
                        }
                    }
                    customaerLists = (IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>)item;
                }
                catch
                {
                    base.Session["AllocatedCustomers"] = null;
                    return new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
                }
                return customaerLists;
            }
            set
            {
                base.Session["AllocatedCustomers"] = value;
            }
        }

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> AvailableCustomers
        {
            get
            {
                IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> customaerLists;
                try
                {
                    object item = base.Session["PendingCustomers"];
                    if (item == null)
                    {
                        item = this.GetCustomers();
                        if (item == null)
                        {
                            item = new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
                        }
                        else
                        {
                            base.Session["PendingCustomers"] = item;
                        }
                    }
                    customaerLists = (IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>)item;
                }
                catch
                {
                    base.Session["PendingCustomers"] = null;
                    return new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
                }
                return customaerLists;
            }
            set
            {
                base.Session["PendingCustomers"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public ProductCatalogueSubAdditionOption_Allocation()
        {
        }

        protected void BtnMove_Onclick(object sender, EventArgs e)
        {
            IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> allocatedCustomers = this.AllocatedCustomers;
            IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> availableCustomers = this.AvailableCustomers;
            if (base.Request.Cookies["MoveCustomers"] != null)
            {
                string[] strArrays = base.Request.Cookies["MoveCustomers"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        ProductCatalogueSubAdditionOption_Allocation.CustomaerList customers = ProductCatalogueSubAdditionOption_Allocation.GetCustomers(availableCustomers, Convert.ToInt64(strArrays[i].ToString()));
                        if (customers != null)
                        {
                            allocatedCustomers.Add(customers);
                            this.AvailableCustomers.Remove(customers);
                        }
                    }
                }
            }
            base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] = null;
            this.AvailableCustomers = availableCustomers;
            this.AllocatedCustomers = allocatedCustomers;
            this.GridAvailableSubAdditionalOptions.Rebind();
            this.GridAllocatedSubAdditionalOptions.Rebind();
        }

        protected void BtnReMove_Onclick(object sender, EventArgs e)
        {
            IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> allocatedCustomers = this.AllocatedCustomers;
            IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> availableCustomers = this.AvailableCustomers;
            if (base.Request.Cookies["RemoveCustomers"] != null)
            {
                string[] strArrays = base.Request.Cookies["RemoveCustomers"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        ProductCatalogueSubAdditionOption_Allocation.CustomaerList customers = ProductCatalogueSubAdditionOption_Allocation.GetCustomers(allocatedCustomers, Convert.ToInt64(strArrays[i].ToString()));
                        if (customers != null)
                        {
                            this.AvailableCustomers.Add(customers);
                            allocatedCustomers.Remove(customers);
                        }
                    }
                }
            }
            base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] = null;
            this.AllocatedCustomers = allocatedCustomers;
            this.AvailableCustomers = availableCustomers;
            this.GridAvailableSubAdditionalOptions.Rebind();
            this.GridAllocatedSubAdditionalOptions.Rebind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.FinalSave();
            this.popUpClose.Visible = true;
            int num = 0;
            foreach (ProductCatalogueSubAdditionOption_Allocation.CustomaerList allocatedCustomer in this.AllocatedCustomers)
            {
                if (num == 0)
                {
                    base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] = null;
                }
                HttpSessionState session = base.Session;
                HttpSessionState httpSessionStates = session;
                string str = string.Concat("AllocatedCust_", this.productCatalogueID);
                object item = httpSessionStates[str];
                long webOtherCostid = allocatedCustomer.WebOtherCostid;
                session[str] = string.Concat(item, webOtherCostid.ToString(), '~');
                string value = this.hdn_WebOtherCostIDs.Value;
                num++;
            }
        }

        protected void btnselectallocate_OnClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:AllocateCategory();", true);
        }

        public void FinalSave()
        {
            this.hdn_CustomerList.Value = this.hdn_WebOtherCostIDs.Value;
            if (base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] != null)
            {
                this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
                string[] strArrays = this.CustomerValues.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    this.objSetting.Category_Customer_Select((long)this.CompanyID, Convert.ToInt64(strArrays[i]));
                    if (base.Session[string.Concat("AllocatedDeptCust_", strArrays[i])] != null)
                    {
                        string[] strArrays1 = base.Session[string.Concat("AllocatedDeptCust_", strArrays[i])].ToString().Split(new char[] { ',' });
                        for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                        {
                            HiddenField hdnDeptallocationtype = this.hdn_deptallocationtype;
                            hdnDeptallocationtype.Value = string.Concat(hdnDeptallocationtype.Value, strArrays[i], "~*S^");
                            if (strArrays1[j].ToString() != "")
                            {
                                HiddenField hdnMovecookievalue = this.hdn_movecookievalue;
                                string value = hdnMovecookievalue.Value;
                                string[] str = new string[] { value, strArrays[i], "*~", strArrays1[j].ToString(), "^" };
                                hdnMovecookievalue.Value = string.Concat(str);
                            }
                        }
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:assignOptionstval();", true);
        }

        protected IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> GetAllocatedCustomers()
        {
            IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> customaerLists = new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
            DataTable dataTable = this.objSetting.PriceCatalogue_webothercost_Select(this.CompanyID, Convert.ToInt64(this.productCatalogueID));
            if (dataTable.Rows.Count <= 0)
            {
                this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
                string[] strArrays = this.CustomerValues.Split(new char[] { '~' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string str = this.objSetting.Group_webothercostName_Select((long)this.CompanyID, Convert.ToInt64(strArrays[i]));
                    customaerLists.Add(new ProductCatalogueSubAdditionOption_Allocation.CustomaerList(Convert.ToInt64(strArrays[i]), this.objBase.SpecialDecode(str)));
                }
            }
            else
            {
                try
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        dataTable.Columns[j].ReadOnly = false;
                    }
                    if (base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] != null)
                    {
                        this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
                        string[] strArrays1 = this.CustomerValues.Split(new char[] { '~' });
                        for (int k = 0; k < (int)strArrays1.Length - 1; k++)
                        {
                            string str1 = this.objSetting.Group_webothercostName_Select((long)this.CompanyID, Convert.ToInt64(strArrays1[k]));
                            customaerLists.Add(new ProductCatalogueSubAdditionOption_Allocation.CustomaerList(Convert.ToInt64(strArrays1[k]), this.objBase.SpecialDecode(str1)));
                        }
                    }
                    else
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["webothercostName"] = this.objBase.SpecialDecode(row["webothercostName"].ToString());
                            long num = Convert.ToInt64(row["webothercostid"].ToString());
                            string str2 = row["webothercostName"].ToString();
                            customaerLists.Add(new ProductCatalogueSubAdditionOption_Allocation.CustomaerList(num, str2));
                        }
                    }
                    base.Session["AllocatedCustomers"] = dataTable;
                }
                catch
                {
                    customaerLists.Clear();
                }
            }
            return customaerLists;
        }

        protected IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> GetCustomers()
        {
            IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> customaerLists = new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
            DataTable dataTable = new DataTable();
            if (base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)] != null)
            {
                dataTable = this.objSetting.SubAdditional_Option_Select(this.CompanyID, (long)0);
                this.CustomerValues = base.Session[string.Concat("AllocatedCust_", this.productCatalogueID)].ToString();
            }
            else
            {
                dataTable = this.objSetting.SubAdditional_Option_Select(this.CompanyID, (long)0);
                this.CustomerValues = "0";
            }
            if (this.Action.ToLower() == "edit")
            {
                dataTable = this.objSetting.SubAdditional_Option_Select(this.CompanyID, this.productCatalogueID);
            }
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        dataTable.Columns[i].ReadOnly = false;
                    }
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["webothercostName"] = this.objBase.SpecialDecode(row["webothercostName"].ToString());
                        long num = Convert.ToInt64(row["webothercostid"].ToString());
                        string str = row["webothercostName"].ToString();
                        if (this.CustomerValues.ToString().Contains(num.ToString()))
                        {
                            continue;
                        }
                        customaerLists.Add(new ProductCatalogueSubAdditionOption_Allocation.CustomaerList(num, str));
                    }
                    base.Session["PendingCustomers"] = dataTable;
                }
                catch
                {
                    customaerLists.Clear();
                }
            }
            return customaerLists;
        }

        private static ProductCatalogueSubAdditionOption_Allocation.CustomaerList GetCustomers(IEnumerable<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> CustomerToSearchIn, long clientID)
        {
            ProductCatalogueSubAdditionOption_Allocation.CustomaerList customaerList;
            using (IEnumerator<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> enumerator = CustomerToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ProductCatalogueSubAdditionOption_Allocation.CustomaerList current = enumerator.Current;
                    if (current.WebOtherCostid != clientID)
                    {
                        continue;
                    }
                    customaerList = current;
                    return customaerList;
                }
                return null;
            }
            return customaerList;
        }

        protected void GridAllocatedSubAdditionalOptions_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridAllocatedSubAdditionalOptions.DataSource = this.AllocatedCustomers;
        }

        protected void GridAllocatedSubAdditionalOptions_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridAllocatedSubAdditionalOptions.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridAllocatedSubAdditionalOptions.ClientID)
            {
                IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> allocatedCustomers = this.AllocatedCustomers;
                ProductCatalogueSubAdditionOption_Allocation.CustomaerList customers = ProductCatalogueSubAdditionOption_Allocation.GetCustomers(allocatedCustomers, (long)e.DestDataItem.GetDataKeyValue("webothercostid"));
                int num = allocatedCustomers.IndexOf(customers);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                IList<ProductCatalogueSubAdditionOption_Allocation.CustomaerList> customaerLists = new List<ProductCatalogueSubAdditionOption_Allocation.CustomaerList>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    ProductCatalogueSubAdditionOption_Allocation.CustomaerList customaerList = ProductCatalogueSubAdditionOption_Allocation.GetCustomers(allocatedCustomers, (long)draggedItem.GetDataKeyValue("webothercostid"));
                    if (customaerList == null)
                    {
                        continue;
                    }
                    customaerLists.Add(customaerList);
                }
                foreach (ProductCatalogueSubAdditionOption_Allocation.CustomaerList customaerList1 in customaerLists)
                {
                    allocatedCustomers.Remove(customaerList1);
                    allocatedCustomers.Insert(num, customaerList1);
                }
                this.AllocatedCustomers = allocatedCustomers;
                this.GridAllocatedSubAdditionalOptions.Rebind();
                int pageSize = num - this.GridAllocatedSubAdditionalOptions.PageSize * this.GridAllocatedSubAdditionalOptions.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void GridAvailableCustomers_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem parentItem = e.DetailTableView.ParentItem;
            if (e.DetailTableView.Name.ToString().ToLower() == "departmentgrid")
            {
                string str = parentItem.GetDataKeyValue("clientid").ToString();
                DataTable dataTable = WebstoreBasePage.Category_ClientDepartment_select(Convert.ToInt64(str), "");
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns["DeptName"] == null)
                    {
                        continue;
                    }
                    row["DeptName"] = this.objBase.SpecialDecode(row["DeptName"].ToString());
                }
                e.DetailTableView.DataSource = dataTable;
                ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:chkselectdept();chkselectbuffervalues();deptcheckmoved();", true);
            }
        }

        protected void GridAvailableSubAdditionalOptions_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridAvailableSubAdditionalOptions.DataSource = this.AvailableCustomers;
        }

        protected void GridSelectedCustomer_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridNestedViewItem)
            {
                GridNestedViewItem item = e.Item as GridNestedViewItem;
                item.NestedViewCell.PreRender += new EventHandler(this.NestedViewCell_PreRender);
            }
        }

        protected void GridSelectedCustomer_ItemDataBound(object sender, GridItemEventArgs e)
        {
        }

        private void NestedViewCell_PreRender(object sender, EventArgs e)
        {
            ((Control)sender).Controls[0].SetRenderMethodDelegate(new RenderMethod(this.NestedViewTable_Render));
        }

        protected void NestedViewTable_Render(HtmlTextWriter writer, Control control)
        {
            control.SetRenderMethodDelegate(null);
            writer.Write("<div style='height: 150px; overflow-y: scroll; border-bottom:1px solid #828282'>");
            control.RenderControl(writer);
            writer.Write("</div>");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridAllocatedSubAdditionalOptions.FilterMenu;
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
            }
            GridFilterMenu gridFilterMenu = this.GridAvailableSubAdditionalOptions.FilterMenu;
            for (int j = filterMenu.Items.Count - 1; j >= 0; j--)
            {
                if (gridFilterMenu.Items[j].Text == "Custom")
                {
                    gridFilterMenu.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisempty")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "isnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notisnull")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "between")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "notbetween")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
                if (gridFilterMenu.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu.Items[j].Visible = false;
                }
            }
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnMove.ToolTip = this.objLanguage.GetLanguageConversion("Move");
            this.btnReMove.ToolTip = this.objLanguage.GetLanguageConversion("Remove");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Allocate");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (base.Request.Params["id"] != null)
            {
                this.productCatalogueID = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            if (base.Request.Params["action"] != null)
            {
                this.Action = base.Request.Params["action"].ToString();
            }
            this.grd_header.InnerHtml = "Allocated Sub Options";
            this.Spn_header.InnerHtml = "Available Sub Options";
            this.btnMove.Visible = true;
            this.btnReMove.Visible = true;
            if (!base.IsPostBack)
            {
                base.Session["PendingCustomers"] = null;
                base.Session["AllocatedCustomers"] = null;
                base.Session["ExcludedCustomers"] = null;
            }
            if (this.Action.ToLower() == "allocatemultiple")
            {
                this.btnSave.Visible = false;
            }
            this.btnselectallocate.Visible = true;
            this.GridAllocatedSubAdditionalOptions.Visible = true;
            if (!(this.Action.ToLower() == "allocatemultiple") && !(this.Action.ToLower() == "allocatesingle"))
            {
                this.div_Copy.Style.Add("display", "none");
                return;
            }
            this.div_Copy.Style.Add("display", "block");
        }

        protected class CustomaerList
        {
            private long _WebOtherCostid;

            private string _WebOtherCostName;

            public long WebOtherCostid
            {
                get
                {
                    return this._WebOtherCostid;
                }
            }

            public string WebOtherCostName
            {
                get
                {
                    return this._WebOtherCostName;
                }
            }

            public CustomaerList(long webothercostid, string webothercostName)
            {
                this._WebOtherCostid = webothercostid;
                this._WebOtherCostName = webothercostName;
            }
        }
    }
}