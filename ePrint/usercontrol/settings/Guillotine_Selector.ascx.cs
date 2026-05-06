using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.settings
{
    public partial class Guillotine_Selector : System.Web.UI.UserControl
    {
        private Global gloobj = new Global();

        public languageClass objlang = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int totalrec;

        public int CompanyID;

        public int PageSize = 50;

        public string IsForLarge = string.Empty;

        public string ParaForLarge = string.Empty;

        public string AddNewText = string.Empty;

        public bool Do_Guillotine_New_Cal;

        public BaseClass objBase = new BaseClass();

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

        public Guillotine_Selector()
        {
        }

        protected void btnclrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridGuillotine.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridGuillotine.MasterTableView.FilterExpression = string.Empty;
            this.GridGuillotine.MasterTableView.Rebind();
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        protected void GridBind(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            this.GridGuillotine.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Guillotine_Name");
            this.GridGuillotine.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Description");
            DataSet dataSet = SettingsBasePage.settings_guillotine_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition, this.IsForLarge);
            this.GridGuillotine.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.lblTotalRecords.Text = dataSet.Tables[1].Rows[0][0].ToString();
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.lblTotalRecords.Text = dataSet.Tables[1].Rows[0][0].ToString();
            this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = this.totalrec.ToString();
            this.GridGuillotine.DataBind();
        }

        protected void GridGuillotine_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (base.Request.Params["islarge"] == null)
            {
                this.IsForLarge = "";
            }
            else
            {
                this.IsForLarge = "yes";
            }
            DataTable dataTable = SettingsBasePage.Settings_Guillotine_PageText_New(this.CompanyID, this.IsForLarge);
            this.GridGuillotine.DataSource = dataTable;
        }

        protected void GridGuillotine_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objlang.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridGuillotine.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridGuillotine.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objlang.GetLanguageConversion("items_in"), " {1} ", this.objlang.GetLanguageConversion("pages"));
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridGuillotine.FilterMenu;
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
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridGuillotine.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Guillotine_Name");
            this.GridGuillotine.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Description");
            this.Do_Guillotine_New_Cal = Convert.ToBoolean(EprintConfigurationManager.AppSettings["Guillotine_New_Cal"]);
            if (this.Do_Guillotine_New_Cal && base.Request.Params["islarge"] != null)
            {
                this.ParaForLarge = "&islarge=yes";
                this.IsForLarge = "yes";
            }
            if (this.IsForLarge != "yes")
            {
                this.GridGuillotine.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Guillotine_Name");
                this.AddNewText = this.objlang.GetLanguageConversion("Add_New_Guillotine");
            }
            else
            {
                this.GridGuillotine.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Cutting_Table_Name");
                this.AddNewText = this.objlang.GetLanguageConversion("Add_New_Cutting_Table");
            }
            this.GridGuillotine.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Description");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
                this.RadGrid_GuillotineBind(this.CompanyID, this.IsForLarge);
            }
        }

        protected void RadGrid_GuillotineBind(int CompanyID, string IsLarge)
        {
            DataTable dataTable = SettingsBasePage.Settings_Guillotine_PageText_New(CompanyID, IsLarge);
            if (dataTable.Rows.Count > 0)
            {
                this.lblTotalRecords.Text = Convert.ToString(dataTable.Rows.Count);
                this.hidGridCount.Value = Convert.ToString(dataTable.Rows.Count);
                this.GridGuillotine.DataSource = dataTable;
                this.GridGuillotine.DataBind();
            }
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
    }
}