
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
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
namespace ePrint.ProductCatalogue
{
    //public partial class ProductCatalogueGroup : System.Web.UI.Page
    public partial class ProductCatalogueGroup : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private BasePage objpage = new BasePage();

        public static BaseClass objBase;

        private commonClass commclass = new commonClass();

        private Global gloobj = new Global();

        private DataTable dtsearch = new DataTable();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private WebstoreBasePage objPro = new WebstoreBasePage();

        private SettingsBasePage objSetting = new SettingsBasePage();

        public languageClass objlang = new languageClass();

        public static int CompanyID;

        public static int UserID;

        public int AccountID;

        public int count;

        public int PageSize = 10000;

        public int PageNumber;

        public int PageIndex = 1;

        public int totalrec;

        public int sortcount;

        public int publicAccountCnt;

        public string action = "add";

        public string para = "";

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public string SecureVirtualPath = string.Empty;

        public static string whereCondition;

        public static string sortdirection;

        public static string sortedBy;

        public string colorformat = string.Empty;

        public string companyType = "Customer";

        public long PriceCatalogueGroupID;

        public string PriceCatalogueGroup = string.Empty;

        public string ServerName = string.Empty;

        public string SecDocumentSitePath = string.Empty;

        public static long catID;

        public string AddStatus = string.Empty;

        public string DeleteStatus = string.Empty;

        private bool flag;

        private bool Err_flag = true;

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

        static ProductCatalogueGroup()
        {
            ProductCatalogueGroup.objBase = new BaseClass();
            ProductCatalogueGroup.CompanyID = 0;
            ProductCatalogueGroup.UserID = 0;
            ProductCatalogueGroup.whereCondition = string.Empty;
            ProductCatalogueGroup.sortdirection = string.Empty;
            ProductCatalogueGroup.sortedBy = string.Empty;
            ProductCatalogueGroup.catID = (long)0;
        }

        public ProductCatalogueGroup()
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueGroup.aspx?&mode=add"));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        WebstoreBasePage.productGroup_Delete(Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), (long)0);
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueGroup.aspx?suc=del&mode=add"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string value = this.hdn_WebOtherCostIDs.Value;
            string[] strArrays = this.hdn_WebOtherCostIDs.Value.Split(new char[] { ',' });
            this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueGroupID)] = null;
            this.PriceCatalogueGroupID = Convert.ToInt64(base.Request.Params["GroupID"]);
            if (this.PriceCatalogueGroupID == (long)0 && this.hdn_addoption_mode.Value == "edit")
            {
                this.PriceCatalogueGroupID = (long)Convert.ToInt32(this.hdn_addoption_groupid.Value);
            }
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString() == "edit" || this.hdn_addoption_mode.Value == "edit")
                {
                    WebstoreBasePage.Group_Insert_Update(this.PriceCatalogueGroupID, this.txtGroupName.Text, ProductCatalogueGroup.CompanyID);
                    if ((int)strArrays.Length > 1)
                    {
                        WebstoreBasePage.ProductGroupSubAdditionalOptions_Delete(this.PriceCatalogueGroupID);
                    }
                    for (int i = 0; i <= (int)strArrays.Length - 1; i++)
                    {
                        if (strArrays[i].ToString() != "")
                        {
                            string str = this.objSetting.Group_webothercostName_Select((long)ProductCatalogueGroup.CompanyID, Convert.ToInt64(strArrays[i]));
                            WebstoreBasePage.ProductCatalogueGroup_Insert((long)0, this.PriceCatalogueGroupID, Convert.ToInt64(strArrays[i]), true, str);
                        }
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueGroup.aspx?suc=in&mode=add"));
                    return;
                }
                if (base.Request.Params["mode"].ToString() == "add" || this.hdn_addoption_mode.Value == "")
                {
                    int num = 0;
                    num = WebstoreBasePage.Group_Insert_Update((long)0, this.txtGroupName.Text, ProductCatalogueGroup.CompanyID);
                    for (int j = 0; j <= (int)strArrays.Length - 1; j++)
                    {
                        if (strArrays[j].ToString() != "")
                        {
                            string str1 = this.objSetting.Group_webothercostName_Select((long)ProductCatalogueGroup.CompanyID, Convert.ToInt64(strArrays[j]));
                            WebstoreBasePage.ProductCatalogueGroup_Insert((long)0, (long)num, Convert.ToInt64(strArrays[j]), true, str1);
                        }
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueGroup.aspx?suc=in&mode=add"));
                }
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridView1.MasterTableView.Rebind();
        }

        public void gridBinding(int CompanyID, long PriceCatalogueGroupID)
        {
            DataTable dataTable = WebstoreBasePage.ProductCatalogueGroup_SelectViewAll(CompanyID, (long)0, "");
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!row.Table.Columns.Contains("GroupName"))
                    {
                        continue;
                    }
                    row["GroupName"] = base.SpecialEncode(row["GroupName"].ToString());
                }
            }
            this.GridView1.DataSource = dataTable;
        }

        private void GridStateLoad()
        {
            this.commclass.GridStateLoadNew("setting", "ProductCatalogueCategory", this.GridView1, "no");
        }

        private void GridStateSave()
        {
            this.commclass.GridStateSaveNew("setting", "ProductCatalogueCategory", this.GridView1);
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), (long)0);
        }

        protected void imgDelete_OnCommand(object sender, CommandEventArgs e)
        {
            WebstoreBasePage.productGroup_Delete(Convert.ToInt32(e.CommandArgument));
            base.Message_Display("Additional Options Group deleted successfully", "msg-success", this.plhMessage_Delete);
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), (long)0);
            this.GridView1.Rebind();
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), (long)0);
            this.GridView1.Rebind();
        }

        protected void lnkloadCatagory_click(object sender, EventArgs e)
        {
            this.GridView1.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Category_Copied_Successfully"), "msg-success", this.plhMessage_Delete);
        }

        protected override void OnInit(EventArgs e)
        {
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.SecureVirtualPath != null)
            {
                this.SecureVirtualPath = ConnectionClass.SecureVirtualPath;
            }
            this.SecDocumentSitePath = this.SecureSitePath;
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
            this.GridView1.Columns[1].HeaderText = "Additional Options Group Name";
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
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

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            GridTableView masterTableView = this.GridView1.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                QueryString queryString = new QueryString()
			{
				{ "catagoryName", ((DataRowView)e.Item.DataItem)[2].ToString() }
			};
                string str = string.Concat(this.strSitepath, "ProductCatalogue/ProductCatalogueGroup.aspx?&mode=edit");
                Label label = (Label)e.Item.FindControl("lblgroupname");
                label.Text = ProductCatalogueGroup.objBase.SpecialDecode(label.Text);
                try
                {
                    this.PriceCatalogueGroupID = (long)Convert.ToInt32(((DataRowView)e.Item.DataItem)[0].ToString());
                }
                catch
                {
                }
                str = string.Concat(str, "&GroupID=", this.PriceCatalogueGroupID);
                GridDataItem item = (GridDataItem)e.Item;
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            this.gloobj.setpagename("productcatalogue");
            ProductCatalogueGroup.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            ProductCatalogueGroup.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Navigation_Path(string.Concat("<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator' style=text-decoration:underline>", this.objlang.GetLanguageConversion("Products"), "</a>"), "&nbsp;>&nbsp;Additional Options Group");
            base.Title = this.objLanguage.convert(global.pageTitle("Product Catalogue Category", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.colorformat = this.objpage.GetRegionalSettings(ProductCatalogueGroup.CompanyID, "colour");
            this.GridView1.MasterTableView.Columns[2].HeaderText = "Additional Options Group Name";
            this.GridView1.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Action");
            this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            ProductCatalogueGroup.sortdirection = "asc";
            if (base.Request.Params["mode"] != null)
            {
                this.action = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit" && base.Request.Params["GroupID"] != null)
            {
                this.PriceCatalogueGroupID = Convert.ToInt64(base.Request.Params["GroupID"]);
            }
            if (this.hdn_addoption_mode.Value == "edit" && this.txtGroupName.Text != "")
            {
                this.action = "edit";
            }
            if (this.hdn_addoption_groupid.Value != "")
            {
                this.PriceCatalogueGroupID = (long)Convert.ToInt32(this.hdn_addoption_groupid.Value);
            }
            this.btnDelete.Attributes.Add("onclick", "javascript:return CallDelete();");
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
                this.txtGroupName.Focus();
                if (base.Request.Params["suc"] != null)
                {
                    if (base.Request.Params["suc"].ToString().ToLower() == "in")
                    {
                        ProductCatalogueGroup.objBase.Message_Display("Additional Options Group saved successfully", "msg-success", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "del")
                    {
                        base.Message_Display("Additional Options Group deleted successfully", "msg-success", this.plhMessage_Delete);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "up")
                    {
                        ProductCatalogueGroup.objBase.Message_Display("Additional Options Group updated successfully", "msg-success", this.plhMessage);
                    }
                }
                if (base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit")
                {
                    DataTable dataTable = WebstoreBasePage.ProductCatalogueGroup_SelectViewAll(ProductCatalogueGroup.CompanyID, (long)Convert.ToInt32(base.Request.Params["GroupID"].ToString()), "");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.txtGroupName.Text = row["GroupName"].ToString().Trim();
                        this.hdn_categoryName.Value = this.txtGroupName.Text;
                        this.PriceCatalogueGroup = row["GroupName"].ToString().Trim();
                        QueryString queryString = new QueryString()
					{
						{ "doctype", "group" },
						{ "groupid", Convert.ToString(this.PriceCatalogueGroupID) }
					};
                        Encryption.EncryptQueryString(queryString);
                    }
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.commclass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.commclass.functionCheckChange());
            }
            ImageButton imageButton = (ImageButton)base.Master.FindControl("ImageButton1");
            this.gridBinding(Convert.ToInt32(this.Session["CompanyID"].ToString()), (long)0);
            AttributeCollection attributes = this.Select.Attributes;
            object[] priceCatalogueGroupID = new object[] { "javascript:openPopUp1('", this.PriceCatalogueGroupID, "','", this.action, "','", ProductCatalogueGroup.objBase.SpecialEncode(this.PriceCatalogueGroup), "');" };
            attributes.Add("onclick", string.Concat(priceCatalogueGroupID));
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString() != "add")
                {
                    this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueGroupID)] = null;
                }
                else if (!base.IsPostBack)
                {
                    this.Session[string.Concat("AllocatedCust_", this.PriceCatalogueGroupID)] = null;
                    return;
                }
            }
        }
    }
}