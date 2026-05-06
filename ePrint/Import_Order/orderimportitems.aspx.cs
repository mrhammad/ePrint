using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.Import_Order
{
    public partial class orderimportitems : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_settings_settings_headerpanel header;

        //protected Button btnCancel;

        //protected LinkButton btnclrFilters;

        //protected LinkButton btnNewExport;

        //protected CheckBox chkError;

        //protected Label Label1;

        //protected HtmlGenericControl DivOrder1;

        //protected RadGrid rad_orderimport_items;

        //protected UpdatePanel UpdatePanel2;

        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private commonClass commclass = new commonClass();

        private BaseClass objBase = new BaseClass();

        public int CompanyID;

        public int UserID;

        public long OrderImportID;

        public static string WhereCondition;

        public string DateFormat = string.Empty;

        public bool IsErrorOnly = true;

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

        static orderimportitems()
        {
            orderimportitems.WhereCondition = string.Empty;
        }

        public orderimportitems()
        {
        }

        private void Bind()
        {
            if (!this.chkError.Checked)
            {
                this.IsErrorOnly = false;
            }
            else
            {
                this.IsErrorOnly = true;
            }
            this.rad_orderimport_items.PagerStyle.AlwaysVisible = true;
            this.rad_orderimport_items.DataSource = this.orderimport_items();
            this.rad_orderimport_items.Rebind();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Import_Order/import_order.aspx"));
        }

        public void btnExportOrder_OnClick(object sender, EventArgs e)
        {
            this.rad_orderimport_items.MasterTableView.Columns[0].Visible = false;
            this.rad_orderimport_items.ExportSettings.FileName = this.objLanguage.GetLanguageConversion("Order_Import_Items");
            this.rad_orderimport_items.MasterTableView.ExportToExcel();
        }

        public void chkError_OnClick(object sender, EventArgs e)
        {
            if (!this.chkError.Checked)
            {
                this.IsErrorOnly = false;
            }
            else
            {
                this.IsErrorOnly = true;
                this.rad_orderimport_items.CurrentPageIndex = 0;
                this.rad_orderimport_items.Rebind();
            }
            this.rad_orderimport_items.DataSource = this.orderimport_items();
            this.rad_orderimport_items.Rebind();
        }

        protected void lnkOrderFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.rad_orderimport_items.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.rad_orderimport_items.MasterTableView.FilterExpression = string.Empty;
            this.rad_orderimport_items.MasterTableView.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.rad_orderimport_items.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
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
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        public DataTable orderimport_items()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ImportOrder_Items_Select");
            database.AddInParameter(storedProcCommand, "@OrderImportID", DbType.Int64, this.OrderImportID);
            database.AddInParameter(storedProcCommand, "@IsErrorOnly", DbType.Boolean, this.IsErrorOnly);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel','div_btn_cancelprocess');");
            if (base.Request.Params["id"] != null)
            {
                this.OrderImportID = Convert.ToInt64(base.Request.Params["id"]);
            }
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = global.pageTitle(this.objLanguage.GetLanguageConversion("Order_Import_Items"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Import_Order_Items");
            if (base.IsPostBack)
            {
                this.Bind();
            }
            else
            {
                this.Bind();
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "func", "checkerror();", true);
        }

        private void paging_OnPageChange(int PageNumber)
        {
            //UserControls_Paging.intPageCount = this.rad_orderimport_items.PageCount;
            //this.rad_orderimport_items.Rebind();
        }

        protected void rad_orderimport_items_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.rad_orderimport_items.AllowCustomPaging = true;
            this.rad_orderimport_items.DataSource = this.orderimport_items();
        }

        protected void rad_orderimport_items_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            this.rad_orderimport_items.CurrentPageIndex = e.NewPageIndex;
            this.Bind();
        }

        protected void rad_orderimport_items_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.Bind();
        }

        protected void rad_orderimport_items_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Label label = (Label)e.Item.FindControl("lblItemDate");
                    label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, false);
                    Label label1 = (Label)e.Item.FindControl("llblErrorMessage");
                    if (dataItem["ErrorMessage"].ToString().Length != 0)
                    {
                        Color color = ColorTranslator.FromHtml("red");
                        e.Item.BackColor = color;
                    }
                }
            }
            catch
            {
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.rad_orderimport_items.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.rad_orderimport_items.DataSource = this.orderimport_items();
                this.rad_orderimport_items.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }
    }
}