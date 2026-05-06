using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsLanguage;
using Printcenter.UI.Webstores;
using System.Collections.Specialized;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using Telerik.Web.UI;

namespace ePrint.usercontrol.ProductCatalogue
{
    public partial class ProductCategory_Allocated_View : System.Web.UI.UserControl
    {
        public languageClass objLanguage = new languageClass();

        public static int CompanyID;

        public static int UserID;

        public long PriceCatalogueCategoryID;

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

        static ProductCategory_Allocated_View()
        {
        }

        public ProductCategory_Allocated_View()
        {
        }

        public void bindcustomer(long categoryid)
        {
            DataTable dataTable = WebstoreBasePage.pricecataloguecategory_allocatedcustomer_select(categoryid, (long)ProductCategory_Allocated_View.CompanyID);
            if (dataTable.Rows.Count > 0)
            {
                this.grdallocatedcustomer.DataSource = dataTable;
                this.grdallocatedcustomer.DataBind();
            }
        }

        protected void grdallocatedcustomer_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (this.PriceCatalogueCategoryID != (long)0)
            {
                DataTable dataTable = WebstoreBasePage.pricecataloguecategory_allocatedcustomer_select(this.PriceCatalogueCategoryID, (long)ProductCategory_Allocated_View.CompanyID);
                this.grdallocatedcustomer.DataSource = dataTable;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdallocatedcustomer.FilterMenu;
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
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCategory_Allocated_View.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            ProductCategory_Allocated_View.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            if (base.Request.QueryString["categoryid"] != null || base.Request.QueryString["categoryid"] != "")
            {
                this.PriceCatalogueCategoryID = Convert.ToInt64(base.Request.QueryString["categoryid"].ToString());
            }
        }
    }
}