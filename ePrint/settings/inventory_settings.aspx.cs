using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
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
    public partial class inventory_settings : BaseClass, IRequiresSessionState
    {

        public string VersionNumber = ConnectionClass.VersionNumber;

        private InventoryBasePage obj = new InventoryBasePage();

        public int CompanyID;

        public int UserID;

        public int ParentCategory;

        public int totalrec;

        public string ParentCategoryName = string.Empty;

        private Global gloobj = new Global();

        private commonClass objJava = new commonClass();

        public string strImagepath = global.strimagepath;

        public string sitePath = global.sitePath();

        public int CategoryID;

        public int id;

        public string type = string.Empty;

        public BasePage ObjPage = new BasePage();

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

        public inventory_settings()
        {
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridStockCategory.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridStockCategory.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    this.obj.settings_stockcategory_delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.GridStockCategory.Rebind();
            DataTable table = ((DataView)this.odsStockCategory.Select()).Table;
            base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void GridStockCategory_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                GridItem item = e.Item;
                Label label = (Label)e.Item.FindControl("lblCategoryName");
                Label text = (Label)e.Item.FindControl("lblDescription");
                text.Text = base.SpecialDecode(text.Text);
                text.ToolTip = text.Text;
                bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
                if (ConnectionClass.Is_Non_Printing_System && (label.Text.ToLower() == "ink" || label.Text.ToLower() == "inks" || label.Text.ToLower() == "paper" || label.Text.ToLower() == "plate" || label.Text.ToLower() == "plates"))
                {
                    item.Attributes.Add("style", "display:none");
                }
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridItem gridItem = e.Item;
                TextBox textBox = (TextBox)e.Item.FindControl("txtCode");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtName");
                TextBox textBox2 = (TextBox)e.Item.FindControl("txtDescription");
                CheckBoxList regionalSettings = (CheckBoxList)e.Item.FindControl("chkproperties");
                regionalSettings.Items[1].Text = this.ObjPage.GetRegionalSettings(this.CompanyID, "Colour");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_CategoryID");
                textBox.Focus();
                if (hiddenField.Value != "")
                {
                    this.CategoryID = int.Parse(hiddenField.Value);
                    foreach (DataRow row in this.obj.settings_stockcategory_select(this.CompanyID, this.CategoryID).Rows)
                    {
                        textBox.Text = base.SpecialDecode(row["CategoryCode"].ToString());
                        textBox1.Text = base.SpecialDecode(row["CategoryName"].ToString());
                        textBox2.Text = base.SpecialDecode(row["Description"].ToString());
                        regionalSettings.Items[0].Selected = Convert.ToBoolean(row["IsWeight"].ToString());
                        regionalSettings.Items[1].Selected = Convert.ToBoolean(row["IsColor"].ToString());
                        regionalSettings.Items[2].Selected = Convert.ToBoolean(row["IsItemCustomSize"].ToString());
                        regionalSettings.Items[3].Selected = Convert.ToBoolean(row["IsItemPaperSize"].ToString());
                        regionalSettings.Items[4].Selected = Convert.ToBoolean(row["IsCoatingType"].ToString());
                        regionalSettings.Items[5].Selected = Convert.ToBoolean(row["IsPrinting"].ToString());
                    }
                    if (textBox1.Text.ToLower() == "paper" || textBox1.Text.ToLower() == "inks" || textBox1.Text.ToLower() == "ink" || textBox1.Text.ToLower() == "plates")
                    {
                        textBox1.Enabled = false;
                        textBox.Enabled = false;
                        this.lnkbtnDelete.Visible = false;
                        if (textBox1.Text.ToLower() == "paper")
                        {
                            regionalSettings.Items[0].Enabled = false;
                            regionalSettings.Items[1].Enabled = false;
                            regionalSettings.Items[2].Enabled = false;
                            regionalSettings.Items[3].Enabled = false;
                            regionalSettings.Items[4].Enabled = false;
                            regionalSettings.Items[5].Enabled = false;
                        }
                        else if (textBox1.Text.ToLower() == "inks" || textBox1.Text.ToLower() == "ink")
                        {
                            regionalSettings.Items[4].Enabled = true;
                        }
                        else if (textBox1.Text.ToLower() == "plate" || textBox1.Text.ToLower() == "plates")
                        {
                            regionalSettings.Items[0].Enabled = false;
                            regionalSettings.Items[4].Enabled = false;
                            regionalSettings.Items[2].Enabled = false;
                        }
                    }
                    else
                    {
                        textBox1.Enabled = true;
                        textBox.Enabled = true;
                        this.lnkbtnDelete.Visible = true;
                        regionalSettings.Items[0].Enabled = true;
                        regionalSettings.Items[1].Enabled = true;
                        regionalSettings.Items[2].Enabled = true;
                        regionalSettings.Items[3].Enabled = true;
                        regionalSettings.Items[4].Enabled = true;
                        regionalSettings.Items[5].Enabled = true;
                    }
                }
                bool flag = ConnectionClass.Is_Non_Printing_System;
                if (ConnectionClass.Is_Non_Printing_System)
                {
                    regionalSettings.Items[3].Attributes.Add("style", "display:none");
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridStockCategory.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridStockCategory.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridStockCategory_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtCode");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtName");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtDescription");
            CheckBoxList checkBoxList = (CheckBoxList)e.Item.FindControl("chkproperties");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_CategoryID");
            Label label = (Label)e.Item.FindControl("lblDuplicacyCheck");
            if (this.obj.settings_stockcategory_insert(this.CompanyID, base.SpecialEncode(textBox.Text), base.SpecialEncode(textBox1.Text), base.SpecialEncode(textBox2.Text), checkBoxList.Items[0].Selected, checkBoxList.Items[1].Selected, checkBoxList.Items[2].Selected, checkBoxList.Items[3].Selected, checkBoxList.Items[4].Selected, checkBoxList.Items[5].Selected) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Already_Exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                textBox.Text = "";
                textBox2.Text = "";
                textBox1.Text = "";
                DataTable table = ((DataView)this.odsStockCategory.Select()).Table;
                foreach (ListItem listItem in checkBoxList.Items)
                {
                    listItem.Selected = false;
                }
                base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Added_Successfully"), "msg-success", this.plhMessage);
            }
            item.Display = false;
        }

        protected void GridStockCategory_OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.GridStockCategory.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.GridStockCategory.MasterTableView.ClearEditItems();
            }
        }

        protected void GridStockCategory_OnPageChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridStockCategory.CurrentPageIndex = e.NewPageIndex;
            this.GridStockCategory.Rebind();
        }

        public void GridStockCategory_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtCode");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtName");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtDescription");
            CheckBoxList checkBoxList = (CheckBoxList)e.Item.FindControl("chkproperties");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_CategoryID");
            this.CategoryID = Convert.ToInt32(hiddenField.Value);
            if (this.obj.settings_stockcategory_update(this.CompanyID, this.CategoryID, base.SpecialEncode(textBox.Text), base.SpecialEncode(textBox1.Text), base.SpecialEncode(textBox2.Text), checkBoxList.Items[0].Selected, checkBoxList.Items[1].Selected, checkBoxList.Items[2].Selected, checkBoxList.Items[3].Selected, checkBoxList.Items[4].Selected, checkBoxList.Items[5].Selected) == -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Already_Exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            this.GridStockCategory.Rebind();
            item.Display = false;
        }

        protected void GridStockSubCategory_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label text = (Label)e.Row.FindControl("lblSubCategoryName");
                text.ToolTip = text.Text;
                text.Style.Add("cursor", "default");
                if (text.Text.Length > 30)
                {
                    text.Text = string.Concat(text.Text.Substring(0, 30), "...");
                }
                Label label = (Label)e.Row.FindControl("lblSubDescription");
                label.ToolTip = label.Text;
                label.Style.Add("cursor", "default");
                if (label.Text.Length > 50)
                {
                    label.Text = string.Concat(label.Text.Substring(0, 50), "...");
                }
                Label label1 = (Label)e.Row.FindControl("lblSubcategoryID");
                DataTable dataTable = this.obj.settings_stocksubcategory_select(this.CompanyID, Convert.ToInt32(label1.Text));
                foreach (DataRow row in dataTable.Rows)
                {
                    this.ParentCategory = Convert.ToInt32(row["ParentCategory"].ToString());
                }
                foreach (DataRow dataRow in this.obj.settings_stockcategory_select(this.CompanyID, this.ParentCategory).Rows)
                {
                    this.ParentCategoryName = dataRow["CategoryName"].ToString();
                }
                Label str = (Label)e.Row.FindControl("lblParentCategory");
                str.Text = this.ParentCategoryName.ToString();
                str.ToolTip = str.Text;
                str.Style.Add("cursor", "default");
                if (str.Text.Length > 50)
                {
                    str.Text = string.Concat(str.Text.Substring(0, 50), "...");
                }
            }
        }

        protected void imgbtnDelete_OnCommand(object sender, CommandEventArgs e)
        {
            this.obj.settings_stockcategory_delete(this.CompanyID, Convert.ToInt32(e.CommandArgument.ToString()));
            this.GridStockCategory.Rebind();
        }

        protected void imgbtnSubDelete_OnCommand(object sender, CommandEventArgs e)
        {
            this.obj.settings_stocksubcategory_delete(this.CompanyID, Convert.ToInt32(e.CommandArgument.ToString()));
            this.GridStockSubCategory.DataBind();
        }

        protected void lnkCategoryName_OnCommand(object sender, CommandEventArgs e)
        {
            this.odsStockSubCategory.TypeName = "Printcenter.UI.Inventories.InventoryBasePage";
            this.odsStockSubCategory.SelectMethod = "settings_stocksubcategory_select_by_categoryid";
            this.odsStockSubCategory.SelectParameters.Clear();
            this.odsStockSubCategory.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.odsStockSubCategory.SelectParameters.Add("ParentCategory", e.CommandArgument.ToString());
            this.GridStockSubCategory.DataBind();
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            this.obj.settings_stockcategory_delete(this.CompanyID, Convert.ToInt32(e.CommandArgument.ToString()));
            this.GridStockCategory.Rebind();
            DataTable table = ((DataView)this.odsStockCategory.Select()).Table;
            base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkShowAll_OnCommand(object sender, CommandEventArgs e)
        {
            this.odsStockSubCategory.TypeName = "Printcenter.UI.Inventories.InventoryBasePage";
            this.odsStockSubCategory.SelectMethod = "settings_stocksubcategory_selectall";
            this.odsStockSubCategory.SelectParameters.Clear();
            this.odsStockSubCategory.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            this.GridStockSubCategory.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddInventorySubCat.Text = this.objLanguage.GetLanguageConversion("Add_New_Inventory_SubCategory");
            this.GridStockCategory.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            global.pageName = "setting";
            global.pgName = "setting";
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["userID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Inventory_Settings_View")));
            base.Title = this.objLanguage.convert(global.pageTitle("Inventory Settings View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.lblheader.Text = "Settings: Inventory Settings View";
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Inventory_Settings_View");
            this.pnlCallScroll.Visible = true;
            this.odsStockCategory.TypeName = "Printcenter.UI.Inventories.InventoryBasePage";
            this.odsStockCategory.SelectMethod = "settings_stockcategory_selectall";
            this.odsStockCategory.SelectParameters.Clear();
            this.odsStockCategory.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
                this.GridStockCategory.DataBind();
            }
            this.odsStockSubCategory.TypeName = "Printcenter.UI.Inventories.InventoryBasePage";
            this.odsStockSubCategory.SelectMethod = "settings_stocksubcategory_selectall";
            this.odsStockSubCategory.SelectParameters.Clear();
            this.odsStockSubCategory.SelectParameters.Add("CompanyID", this.Session["CompanyID"].ToString());
            if (this.GridStockCategory.Items.Count != 0)
            {
                DataTable table = ((DataView)this.odsStockCategory.Select()).Table;
                this.totalrec = table.Rows.Count;
            }
            if (this.GridStockSubCategory.Rows.Count != 0)
            {
                DataTable dataTable = ((DataView)this.odsStockSubCategory.Select()).Table;
                this.totalrec = dataTable.Rows.Count;
            }
            int count = this.GridStockCategory.Items.Count;
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            try
            {
                global.pageName = "setting";
                global.pgName = "";
                this.gloobj.setpagename("setting");
                this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
                this.UserID = Convert.ToInt32(this.Session["userID"].ToString());
                this.type = base.Request.Params["type"].ToString();
                base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>Home</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>Settings</a>&nbsp;>&nbsp;<a href=../settings/inventory_settings.aspx class='subnavigator'  style='text-decoration:underline;'>Inventory Settings View</a>", "&nbsp;>&nbsp;Inventory Settings Add");
                base.Title = this.objLanguage.convert(global.pageTitle("Inventory Settings Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            catch
            {
                try
                {
                    if (base.Request.Params["su"].ToString().ToLower() == "up")
                    {
                        base.Message_Display(this.objLanguage.GetLanguageConversion("Inventory_Category_Updated_Successfully"), "msg-success", this.plhMessage);
                        this.obj.ReturnDeleteID = 0;
                    }
                }
                catch
                {
                }
            }
        }
    }
}