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
namespace ePrint.StoreSettings
{
    public partial class cart_additional_options_view : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        private commonClass objJava = new commonClass();

        public int totalrec;

        public int PageSize = 10000;

        public long AccountID;

        public languageClass objlang = new languageClass();

        public string formatScript = "";

        public string AdditionalType = "c";

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long UserId;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

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

        public cart_additional_options_view()
        {
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_add.aspx"));
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
                        if (!this.rdoDeleteAll.Checked)
                        {
                            WebstoreBasePage.Othercost_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(strArrays[i]), this.AccountID, "ind");
                        }
                        else
                        {
                            WebstoreBasePage.Othercost_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(strArrays[i]), this.AccountID, "all");
                        }
                    }
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/cart_additional_options_view.aspx?su=de"));
            }
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridWebOtherCost.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridWebOtherCost.MasterTableView.FilterExpression = string.Empty;
            this.GridWebOtherCost.MasterTableView.Rebind();
        }

        protected void GridBind()
        {
            DataTable table = ((DataView)this.odsPriceCatalogue.Select()).Table;
            foreach (DataRow row in table.Rows)
            {
                row["OtherCostCategoryName"] = base.SpecialDecode(row["OtherCostCategoryName"].ToString());
                row["WebOtherCostName"] = base.SpecialDecode(row["WebOtherCostName"].ToString());
                row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
                row["Description"] = base.SpecialDecode(row["DEscription"].ToString());
            }
            this.GridWebOtherCost.DataSource = table;
            this.GridWebOtherCost.DataBind();
        }

        protected void GridOtherCost_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew("storesetting", "GridCartAdditionalOptions", this.GridWebOtherCost, "no");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew("storesetting", "GridCartAdditionalOptions", this.GridWebOtherCost);
        }

        protected void GridWebOtherCost_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridWebOtherCost.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridWebOtherCost.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridWebOtherCost_PazeIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridWebOtherCost.CurrentPageIndex = e.NewPageIndex;
            this.GridWebOtherCost.Rebind();
        }

        protected void GridWebOtherCost_PazeSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridWebOtherCost.Rebind();
        }

        protected void imgbtnCopy_OnCommand(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            long num = WebstoreBasePage.SettingsWebStore_OtherCost_Copy_ShopCartCost(this.CompanyID, Convert.ToInt64(imageButton.CommandArgument.ToString()));
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "storesettings/cart_additional_options.aspx?type=edit&id=", num, "&cop=yes" };
            response.Redirect(string.Concat(objArray));
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            if (!this.rdoDeleteAll.Checked)
            {
                WebstoreBasePage.Othercost_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(e.CommandArgument), this.AccountID, "ind");
            }
            else
            {
                WebstoreBasePage.Othercost_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(e.CommandArgument), this.AccountID, "all");
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/cart_additional_options_view.aspx?su=de"));
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridWebOtherCost.FilterMenu;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridWebOtherCost.MasterTableView.Columns[4].HeaderText = this.objlang.GetValueOnLang("Action");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Shopping Cart Additional Option View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.UserId = Convert.ToInt64(this.Session["UserID"].ToString());
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            this.RadWindowDeleteConfirm.Title = this.objLanguage.GetLanguageConversion("Delete_Record");
            string str = SettingsBasePage.Fetch_SelectedAccountID(this.UserId);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = (long)Convert.ToInt32(strArrays[0]);
                this.hdnAccountID.Value = this.AccountID.ToString();
            }
            if (!base.IsPostBack && base.Request.Params["su"] != null)
            {
                if (base.Request.Params["su"] == "in")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Additional_Option_Saved_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "up")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Additional_Option_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "de")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Additional_Option_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "al")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Additional_Option_Allocated_Successfully"), "msg-success", this.plhMessage);
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            int count = this.GridWebOtherCost.Items.Count;
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
            }
            this.GridBind();
        }
    }
}