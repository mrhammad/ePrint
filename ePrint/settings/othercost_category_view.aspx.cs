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
    public partial class othercost_category_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager ScriptManager2;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lblHeader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton btnDelete;

        //protected RadGrid GridCostCategory;

        //protected UpdatePanel UpdatePanel1;

        //protected ObjectDataSource odsCostCategory;

        //protected RadCodeBlock RadCodeBlock1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        private commonClass objJava = new commonClass();

        public int CompanyID;

        public int totalrec;

        private SettingsBasePage objSet = new SettingsBasePage();

        public string type = string.Empty;

        public languageClass objlang = new languageClass();

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

        public othercost_category_view()
        {
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_category_add.aspx"));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridCostCategory.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridCostCategory.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_othercostcategory_delete(this.CompanyID, Convert.ToInt64(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.GridCostCategory.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Other_Cost_Category_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridCostCategory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridCostCategory.MasterTableView.FilterExpression = string.Empty;
            this.GridCostCategory.MasterTableView.Rebind();
        }

        protected void GridCostCategory_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtCategoryName");
            DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddlJobcardCategory");
            if (SettingsBasePage.settings_othercostcategory_insert(this.CompanyID, (long)0, base.SpecialEncode(radTextBox.Text), 0, dropDownList.SelectedValue.ToString()) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Category_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Category_Inserted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void GridCostCategory_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.GridCostCategory.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.GridCostCategory.MasterTableView.ClearEditItems();
            }
        }

        protected void GridCostCategory_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                RadTextBox radTextBox = item.FindControl("txtCategoryName") as RadTextBox;
                DropDownList str = item.FindControl("ddlJobcardCategory") as DropDownList;
                HiddenField hiddenField = item.FindControl("hdnOtherCostCategoryID") as HiddenField;
                RequiredFieldValidator languageConversion = item.FindControl("RequiredFieldValidator2") as RequiredFieldValidator;
                languageConversion.ErrorMessage = this.objlang.GetLanguageConversion("Please_Enter_Category_Name");
                if (hiddenField.Value != "")
                {
                    DataTable dataTable = SettingsBasePage.settings_othercostcategory_select(this.CompanyID, Convert.ToInt64(hiddenField.Value));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        str.SelectedValue = row["JobcardCategory"].ToString();
                    }
                }
                radTextBox.Focus();
                radTextBox.Text = base.SpecialDecode(radTextBox.Text);
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lblCategoryName");
                label.Text = base.SpecialDecode(label.Text);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridCostCategory.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridCostCategory.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridCostCategory_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridCostCategory_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridCostCategory.CurrentPageIndex = e.NewPageIndex;
            this.GridCostCategory.Rebind();
        }

        protected void GridCostCategory_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridCostCategory.Rebind();
        }

        protected void GridCostCategory_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            RadTextBox radTextBox = (RadTextBox)item.FindControl("txtCategoryName");
            HiddenField hiddenField = (HiddenField)item.FindControl("hdnOtherCostCategoryID");
            DropDownList dropDownList = (DropDownList)item.FindControl("ddlJobcardCategory");
            if (SettingsBasePage.settings_othercostcategory_insert(this.CompanyID, Convert.ToInt64(hiddenField.Value), base.SpecialEncode(radTextBox.Text), 0, dropDownList.SelectedValue.ToString()) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Category_Name_Already_Exists"), "msg-fail", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Category_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew("setting", "GridOthercostCategory", this.GridCostCategory, "no");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew("setting", "GridOthercostCategory", this.GridCostCategory);
        }

        protected void imgbtnDelete_OnClick(object source, CommandEventArgs e)
        {
            SettingsBasePage.settings_othercostcategory_delete(this.CompanyID, Convert.ToInt64(e.CommandArgument.ToString()));
            this.GridCostCategory.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Other_Cost_Category_Deleted_Successfully"), "msg-success", this.plhMessage);
            DataTable table = ((DataView)this.odsCostCategory.Select()).Table;
            this.totalrec = table.Rows.Count;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridCostCategory.FilterMenu;
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
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Other_Costs_Category_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Other Costs Category View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Other_Costs_Category_View");
            this.GridCostCategory.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_display");
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["su"] != null)
                {
                    if (base.Request.Params["su"] == "in")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Category_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                    else if (base.Request.Params["su"] == "up")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
                    }
                    else if (base.Request.Params["su"] == "de")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Other_Cost_Category_Deleted_Successfully"), "msg-success", this.plhMessage);
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
                DataTable table = ((DataView)this.odsCostCategory.Select()).Table;
                this.totalrec = table.Rows.Count;
            }
        }
    }
}