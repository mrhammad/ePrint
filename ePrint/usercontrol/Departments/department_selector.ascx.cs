using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.Departments
{
    public partial class department_selector : System.Web.UI.UserControl
    {
        private BaseClass objBase = new BaseClass();

        private CompanyBasePage objcomm = new CompanyBasePage();

        private DepartmentBaseClass objDept = new DepartmentBaseClass();

        public languageClass objLanguage = new languageClass();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public string pg = string.Empty;

        public string CompanyType = string.Empty;

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public static int FilteringDept;

        private DataTable dt_Department;

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

        static department_selector()
        {
        }

        public department_selector()
        {
        }

        protected void clrFiltersDept_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGrid_Department.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.RadGrid_Department.MasterTableView.FilterExpression = string.Empty;
            this.GridDepartment(this.CompanyID, this.ClientID);
            GridTableView masterTableView = this.RadGrid_Department.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            ((LinkButton)items.FindControl("btnclrFilters_Dept")).Visible = true;
        }

        protected void clrFiltersHideDept_Click(object sender, EventArgs e)
        {
            this.FilterStatus();
        }

        public void FilterStatus()
        {
            this.GridDepartment(this.CompanyID, this.ClientID);
            GridTableView masterTableView = this.RadGrid_Department.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            ((LinkButton)items.FindControl("btnclrFilters_Dept")).Visible = true;
        }

        public void GridDepartment(int CompanyID, int ClientID)
        {
            this.dt_Department = DepartmentBaseClass.department_getAllDetails(CompanyID, this.UserID, ClientID, (long)0);
            this.RadGrid_Department.DataSource = this.dt_Department;
            this.RadGrid_Department.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.RadGrid_Department.FilterMenu;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.Params["clientid"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["clientid"].ToString());
            }
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["CompanyType"] != null)
            {
                this.CompanyType = base.Request.Params["CompanyType"].ToString();
            }
            this.GridDepartment(this.CompanyID, this.ClientID);
            if (!base.IsPostBack && base.Request.Cookies["DeptFiterState"] != null)
            {
                base.Request.Cookies["DeptFiterState"].Value = null;
            }
            this.RadGrid_Department.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Department_Name");
            this.RadGrid_Department.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Address");
            this.RadGrid_Department.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Address");
            this.FilterStatus();
        }

        protected void RadGrid_Department_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.dt_Department = DepartmentBaseClass.department_getAllDetails(this.CompanyID, this.UserID, this.ClientID, (long)0);
            this.RadGrid_Department.DataSource = this.dt_Department;
        }

        protected void RadGridDepartment_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                GridTableView masterTableView = this.RadGrid_Department.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                ((LinkButton)items.FindControl("btnclrFilters_Dept")).Visible = true;
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Label label = (Label)e.Item.FindControl("lbl_DeptName");
                    Label label1 = (Label)e.Item.FindControl("lbl_DeliveryAddress");
                    Label label2 = (Label)e.Item.FindControl("lbl_InvoiceAddress");
                }
            }
            catch
            {
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.RadGrid_Department.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.RadGrid_Department.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }
    }
}