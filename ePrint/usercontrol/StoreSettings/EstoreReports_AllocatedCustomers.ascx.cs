using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.StoreSettings
{
    public partial class EstoreReports_AllocatedCustomers : UserControl
    {
        //protected RadAjaxManager RAM_Attch;

        //protected Telerik.Web.UI.RadAjaxLoadingPanel RadAjaxLoadingPanel;

        //protected LinkButton btnDelete;

        //protected RadGrid RadGrid_Customer;

        //protected UpdatePanel update;

        //protected HtmlGenericControl Div_customer;

        //protected HiddenField hdn_AllocatedClietIDs;

        public int CompanyID;

        private BaseClass objBase = new BaseClass();

        public languageClass objLanguage = new languageClass();

        public string Type = string.Empty;

        public long ReportID;

        public string From = string.Empty;

        public string ReportName = string.Empty;

        public string ModuleName = string.Empty;

        public string strImagepath = global.imagePath();

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

     
        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hdn_AllocatedClietIDs.Value))
            {
                string[] strArrays = this.hdn_AllocatedClietIDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        WebstoreBasePage.EstoreReports_AllocatedCustomers_Delete(this.ReportID, (long)Convert.ToInt32(strArrays[i]), this.ReportName, this.ModuleName);
                    }
                }
            }
            this.GridBind_Customer(this.ReportID, this.ReportName, this.ModuleName);
        }

        public void GridBind_Customer(long ReportID, string ReportName, string ModuleName)
        {
            DataTable dataTable = SettingsBasePage.EstoreReport_Customer_View(this.CompanyID, ReportID, ReportName, ModuleName);
            this.RadGrid_Customer.DataSource = dataTable;
            this.RadGrid_Customer.DataBind();
        }

        protected void imgbtnDelete_Click(object sender, CommandEventArgs e)
        {
            WebstoreBasePage.EstoreReports_AllocatedCustomers_Delete(this.ReportID, (long)Convert.ToInt32(e.CommandArgument), this.ReportName, this.ModuleName);
            this.GridBind_Customer(this.ReportID, this.ReportName, this.ModuleName);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.RadGrid_Customer.FilterMenu;
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
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.RadGrid_Customer.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
            this.GridBind_Customer(this.ReportID, this.ReportName, this.ModuleName);
        }

        protected void RadGrid_Customer_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid_Customer.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid_Customer.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }
    }
}