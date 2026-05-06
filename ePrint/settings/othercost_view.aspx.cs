using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
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

namespace ePrint.settings
{
    public partial class othercost_view : BaseClass, IRequiresSessionState
    {
        //protected RadCodeBlock RadCodeBlock1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lblHeader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected DropDownList ddlCategorySelect;

        //protected LinkButton btnDelete;

        //protected RadGrid GridOtherCost;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hidGridCount;

        //protected HiddenField hid_Delete_IDs;

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        private commonClass objJava = new commonClass();

        public int totalrec;

        public static int PageSize;

        public languageClass objlang = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public static string WhereCondition;

        private DataTable dtsearch = new DataTable();

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

        static othercost_view()
        {
            othercost_view.PageSize = 50;
            othercost_view.WhereCondition = string.Empty;
        }

        public othercost_view()
        {
        }

        private void Bind()
        {
            this.GridOtherCost.PagerStyle.AlwaysVisible = true;
            this.GridOtherCost.DataSource = this.GridBind(this.CompanyID, Convert.ToInt16(this.ddlCategorySelect.SelectedValue));
            this.GridOtherCost.DataBind();
        }

        public void Bind_ddlCategorySelectedcategory()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            DataSet dataSet = SettingsBasePage.Bindddl_othercostSelectedCategory(this.CompanyID);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["OtherCostCategoryName"] = base.SpecialDecode(row["OtherCostCategoryName"].ToString());
            }
            this.ddlCategorySelect.DataSource = dataSet.Tables[0];
            this.ddlCategorySelect.DataTextField = "OtherCostCategoryName";
            this.ddlCategorySelect.DataValueField = "OtherCostCategoryID";
            this.ddlCategorySelect.DataBind();
            this.ddlCategorySelect.Items.Insert(0, new ListItem("All", "0"));
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
                        SettingsBasePage.settings_othercost_delete(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
            }
            this.GridOtherCost.DataSource = this.GridBind(this.CompanyID, Convert.ToInt16(this.ddlCategorySelect.SelectedValue));
            base.Message_Display(this.objlang.GetLanguageConversion("Other_Cost_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridOtherCost.Rebind();
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
            foreach (GridColumn column in this.GridOtherCost.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridOtherCost.MasterTableView.FilterExpression = string.Empty;
            this.Bind();
            this.GridOtherCost.MasterTableView.Rebind();
        }

        protected void ddlCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session["CostCategory"] = this.ddlCategorySelect.SelectedValue;
            this.Bind();
            this.GridOtherCost.MasterTableView.Rebind();
        }

        public DataSet GridBind(int CompanyID, int OtherCostCategoryID)
        {
            DataSet dataSet = SettingsBasePage.settings_othercost_View(CompanyID, OtherCostCategoryID);
            RadGrid gridOtherCost = this.GridOtherCost;
            int count = dataSet.Tables[0].Rows.Count;
            gridOtherCost.VirtualItemCount = Convert.ToInt32(count.ToString());
            return dataSet;
        }

        protected void GridOtherCost_items_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridOtherCost.AllowCustomPaging = true;
            this.GridOtherCost.DataSource = this.GridBind(this.CompanyID, Convert.ToInt16(this.ddlCategorySelect.SelectedValue));
        }

        protected void GridOtherCost_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Label label = (Label)e.Item.FindControl("lblOtherCostCategoryName");
                    Label label1 = (Label)e.Item.FindControl("lblOtherCostName");
                    Label label2 = (Label)e.Item.FindControl("lblDescription");
                    Image image = (Image)e.Item.FindControl("ImgButtonDelete");
                    Image image1 = (Image)e.Item.FindControl("imgbtnCopy");
                }
            }
            catch
            {
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridOtherCost.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridOtherCost.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridOtherCost_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridOtherCost_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridOtherCost.CurrentPageIndex = e.NewPageIndex;
            this.Bind();
        }

        protected void GridOtherCost_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridOtherCost.Rebind();
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew("setting", "GridOthercostSttings", this.GridOtherCost, "no");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew("setting", "GridOthercostSttings", this.GridOtherCost);
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.GridOtherCost.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.GridOtherCost.MasterTableView.ClearEditItems();
            }
        }

        protected void imgbtnCopy_OnCommand(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            long num = SettingsBasePage.settings_OtherCost_Copy(this.CompanyID, Convert.ToInt64(imageButton.CommandArgument.ToString()));
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "settings/othercost_add.aspx?type=edit&id=", num, "&cop=yes" };
            response.Redirect(string.Concat(objArray));
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.settings_othercost_delete(this.CompanyID, Convert.ToInt64(e.CommandArgument));
            this.GridOtherCost.DataSource = this.GridBind(this.CompanyID, Convert.ToInt16(this.ddlCategorySelect.SelectedValue));
            base.Message_Display(this.objlang.GetLanguageConversion("Other_Cost_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridOtherCost.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridOtherCost.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Bind_ddlCategorySelectedcategory();
                this.GridOtherCost.PageSize = 50;
            }
            this.GridOtherCost.MasterTableView.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.GridOtherCost.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_display");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Other_Costs_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Other Costs View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Other_Costs_View");
            if (!base.IsPostBack)
            {
                othercost_view.PageSize = this.objJava.ReturnPageSize("setting", "GridOthercostSttings", this.GridOtherCost);
                this.GridOtherCost.PageSize = othercost_view.PageSize;
                this.Bind();
                this.GridStateLoad();
                this.GridOtherCost.Rebind();
            }
            if (!base.IsPostBack)
            {
                this.GridOtherCost.PageSize = 50;
                if (this.Session["CostCategory"] != null)
                {
                    ListItem listItem = this.ddlCategorySelect.Items.FindByValue(this.Session["CostCategory"].ToString());
                    this.ddlCategorySelect.SelectedIndex = this.ddlCategorySelect.Items.IndexOf(listItem);
                    this.ddlCategorySelect_SelectedIndexChanged(sender, e);
                }
            }
            if (!base.IsPostBack && base.Request.Params["su"] != null)
            {
                if (base.Request.Params["su"] == "in")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Saved_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "up")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Updated_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["su"] == "de")
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Deleted_Successfully"), "msg-success", this.plhMessage);
                }
            }
            if (base.IsPostBack)
            {
                this.GridOtherCost.DataSource = this.GridBind(this.CompanyID, Convert.ToInt16(this.ddlCategorySelect.SelectedValue));
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            int count = this.GridOtherCost.Items.Count;
        }
    }
}