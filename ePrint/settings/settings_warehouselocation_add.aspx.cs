using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
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
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class settings_warehouselocation_add : BaseClass, IRequiresSessionState
    {
        public static int companyid;

        public static int UserID;

        private CompanyBasePage comnyobj = new CompanyBasePage();

        public string pg = string.Empty;

        public string PageType = "g";

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

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

        static settings_warehouselocation_add()
        {
        }

        public settings_warehouselocation_add()
        {
        }

        public void grdbind()
        {
            DataTable dataTable = SettingsBasePage.productcatalogue_warehouselocation_select(settings_warehouselocation_add.companyid);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["LocationName"] = base.SpecialDecode(row["LocationName"].ToString());
                row["Telephone"] = base.SpecialDecode(row["Telephone"].ToString());
            }
            this.grdWarehouseLocation.DataSource = dataTable;
            this.grdWarehouseLocation.DataBind();
        }

        protected void grdWarehouseLocation_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtlocationName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtaddress");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txt_city");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txt_suburb");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txt_postCode");
            TextBox textBox5 = (TextBox)e.Item.FindControl("txttelephone");
            CheckBox checkBox = e.Item.FindControl("chkDefault") as CheckBox;
            DropDownList dropDownList = e.Item.FindControl("ddlcountry") as DropDownList;
            string text = "";
            if (dropDownList.SelectedIndex != 0)
            {
                text = dropDownList.SelectedItem.Text;
            }
            int num = 0;
            num = (!checkBox.Checked ? 0 : 1);
            SettingsBasePage.productcatalogue_warehouselocation_insert(settings_warehouselocation_add.companyid, base.SpecialEncode(textBox.Text), base.SpecialEncode(textBox1.Text), base.SpecialEncode(textBox2.Text), base.SpecialEncode(textBox3.Text), textBox4.Text, text, textBox5.Text, num);
            this.grdWarehouseLocation.Rebind();
        }

        protected void grdWarehouseLocation_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.productcatalogue_warehouselocation_select(settings_warehouselocation_add.companyid);
            this.grdWarehouseLocation.DataSource = dataTable;
        }

        protected void grdWarehouseLocation_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.grdWarehouseLocation.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.grdWarehouseLocation.MasterTableView.ClearEditItems();
            }
        }

        protected void grdWarehouseLocation_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtlocationName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtaddress");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txt_city");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txt_suburb");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txt_postCode");
            TextBox textBox5 = (TextBox)e.Item.FindControl("txttelephone");
            CheckBox checkBox = e.Item.FindControl("chkDefault") as CheckBox;
            DropDownList dropDownList = e.Item.FindControl("ddlcountry") as DropDownList;
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnlocationid");
            string text = "";
            if (dropDownList.SelectedIndex != 0)
            {
                text = dropDownList.SelectedItem.Text;
            }
            int num = 0;
            num = (!checkBox.Checked ? 0 : 1);
            SettingsBasePage.productcatalogue_warehouselocation_update(settings_warehouselocation_add.companyid, Convert.ToInt32(hiddenField.Value), base.SpecialEncode(textBox.Text), base.SpecialEncode(textBox1.Text), base.SpecialEncode(textBox2.Text), base.SpecialEncode(textBox3.Text), textBox4.Text, text, textBox5.Text, num);
            this.grdWarehouseLocation.Rebind();
        }

        public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dropDownList = (DropDownList)e.Row.FindControl("ddlcountry");
                this.comnyobj.company_country_select(dropDownList);
            }
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.productcatalogue_warehouselocation_delete(Convert.ToInt32(e.CommandArgument));
            this.grdWarehouseLocation.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdWarehouseLocation.FilterMenu;
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
            this.grdWarehouseLocation.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Location_Name");
            this.grdWarehouseLocation.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Address");
            this.grdWarehouseLocation.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Telephone");
            this.grdWarehouseLocation.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("InUse");
            this.grdWarehouseLocation.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.grdWarehouseLocation.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Stock_Location"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), "&nbsp;&nbsp;");
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["page"] != null)
            {
                this.PageType = base.Request.Params["page"].ToString();
            }
            base.Title = global.pageTitle("Warehouse Location", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
            settings_warehouselocation_add.companyid = Convert.ToInt32(this.Session["CompanyID"].ToString());
            settings_warehouselocation_add.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Stock_Location");
            if (!base.IsPostBack)
            {
                this.grdbind();
            }
            string empty = string.Empty;
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = (GridEditableItem)e.Item;
                DropDownList dropDownList = (DropDownList)item.FindControl("ddlcountry");
                this.comnyobj.company_country_select(dropDownList);
                CheckBox checkBox = item.FindControl("chkDefault") as CheckBox;
                HiddenField hiddenField = item.FindControl("hdn_Default") as HiddenField;
                HiddenField hiddenField1 = item.FindControl("hdncountry") as HiddenField;
                TextBox textBox = item.FindControl("txtlocationName") as TextBox;
                TextBox textBox1 = item.FindControl("txtaddress") as TextBox;
                TextBox textBox2 = item.FindControl("txt_city") as TextBox;
                TextBox textBox3 = item.FindControl("txt_suburb") as TextBox;
                TextBox textBox4 = item.FindControl("txt_postCode") as TextBox;
                TextBox textBox5 = item.FindControl("txttelephone") as TextBox;
                textBox.Text = base.SpecialDecode(textBox.Text);
                textBox1.Text = base.SpecialDecode(textBox1.Text);
                textBox2.Text = base.SpecialDecode(textBox2.Text);
                textBox3.Text = base.SpecialDecode(textBox3.Text);
                textBox4.Text = base.SpecialDecode(textBox4.Text);
                textBox5.Text = base.SpecialDecode(textBox5.Text);
                this.setddlval(dropDownList, hiddenField1.Value.ToString());
                if (hiddenField.Value == "True")
                {
                    checkBox.Checked = true;
                }
            }
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label label = (Label)e.Item.FindControl("lbl_Address");
                Label label1 = (Label)e.Item.FindControl("lblFieldName");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_Address");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_City");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_Suburb");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_PostCode");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_Country");
                string[] value = new string[] { hiddenField2.Value, " ", hiddenField3.Value, " ", hiddenField4.Value, " ", hiddenField5.Value, " ", hiddenField6.Value };
                label.Text = base.SpecialDecode(string.Concat(value));
                label1.Text = base.SpecialDecode(label1.Text);
                HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdn_Default");
                HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hdn_InUse");
                Image image = (Image)e.Item.FindControl("img_Default");
                Image image1 = (Image)e.Item.FindControl("img_InUse");
                if (hiddenField7.Value != "True")
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                }
                if (hiddenField8.Value != "True")
                {
                    image1.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.grdWarehouseLocation.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.grdWarehouseLocation.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void setddlval(DropDownList ddl, string value)
        {
            ListItem listItem = ddl.Items.FindByText(value.ToString());
            ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
        }
    }
}