using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
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
    public partial class General_ledger_codes : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton btnDeleteAccountcode;

        //protected RadGrid gridAccountingCodes;

        //protected HtmlGenericControl div_Main;

        //protected UpdatePanel pnlgridAccountingCodes;

        //protected ObjectDataSource AccountCodeDataSource;

        //protected RadCodeBlock RadCodeBlock1;

        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public int return1;

        private commonClass objJava = new commonClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public General_ledger_codes()
        {
        }

        protected void btnDeleteAccountcode_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < this.gridAccountingCodes.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.gridAccountingCodes.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.Setting_accountingCode_Delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                    flag = true;
                }
            }
            if (flag)
            {
                this.gridAccountingCodes.Rebind();
                base.Message_Display(this.objlang.GetLanguageConversion("Accounting_codes_deleted_successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.gridAccountingCodes.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.gridAccountingCodes.MasterTableView.FilterExpression = string.Empty;
            this.gridAccountingCodes.MasterTableView.Rebind();
        }

        protected void gridAccountingCodes_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtAccountingCode");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtDescription");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnAccountCodeID");
            Label label = (Label)e.Item.FindControl("lblDuplicacyCheck");
            CheckBox checkBox = e.Item.FindControl("chkDefault") as CheckBox;
            CheckBox checkBox1 = e.Item.FindControl("chkPurchaseDefault") as CheckBox;
            CheckBox checkBox2 = e.Item.FindControl("chkRevenuCode") as CheckBox;
            CheckBox checkBox3 = e.Item.FindControl("chkPurchaseCode") as CheckBox;
            bool flag = true;
            flag = (!checkBox2.Checked ? false : true);
            bool flag1 = true;
            flag1 = (!checkBox3.Checked ? false : true);
            bool flag2 = false;
            flag2 = (!checkBox.Checked ? false : true);
            bool flag3 = false;
            flag3 = (!checkBox1.Checked ? false : true);
            if (textBox1.Text == null)
            {
                textBox1.Text = "";
            }
            this.return1 = SettingsBasePage.Setting_accountingCode_Insert(Convert.ToInt32(this.CompanyID.ToString()), textBox.Text, textBox1.Text, flag2, flag3, 0, flag, flag1);
            if (this.return1 != -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Accounting_code_inserted_successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Accounting_code_already_exists"), "msg-fail", this.plhMessage);
            }
            this.gridAccountingCodes.Rebind();
            item.Display = false;
        }

        protected void gridAccountingCodes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                e.Item.FindControl("hdn_InUse");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_InUse");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_Default");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdn_PurchaseDefault");
                Image image = (Image)e.Item.FindControl("img_InUse");
                Image image1 = (Image)e.Item.FindControl("img_Default");
                Image image2 = (Image)e.Item.FindControl("img_PurchaseDefault");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgbtnDelete");
                Image image3 = (Image)e.Item.FindControl("img_RevenueCodes");
                Image image4 = (Image)e.Item.FindControl("img_PurchaseCode");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdn_RevenueCode");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_PurchaseCode");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdnRevenueCode");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdnPurchaseCode");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                if(hiddenField3 != null)
                {
                    if (hiddenField3.Value.ToLower() != "true")
                    {
                        image3.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image3.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = false;
                    }
                }
                if(hiddenField4 != null)
                {
                    if (hiddenField4.Value.ToLower() != "true")
                    {
                        image4.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image4.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = false;
                    }
                }
                if(hiddenField != null)
                {
                    if (hiddenField.Value != "True")
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = false;
                        htmlInputCheckBox.Disabled = true;
                    }
                }
                if(hiddenField1 != null)
                {
                    if (hiddenField1.Value != "True")
                    {
                        image1.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = false;
                        htmlInputCheckBox.Disabled = true;
                    }
                }
                if(hiddenField2 != null)
                {
                    if (hiddenField2.Value != "True")
                    {
                        image2.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image2.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = false;
                    }
                }
               
            }
            catch (Exception exception)
            {
            }
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                Label label = (Label)e.Item.FindControl("lblAccountCode");
                Label label1 = (Label)e.Item.FindControl("lblDescription");
                label.Text = base.SpecialDecode(label.Text);
                label1.Text = base.SpecialDecode(label1.Text);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.gridAccountingCodes.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.gridAccountingCodes.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                GridItem gridItem = e.Item;
                TextBox textBox = item.FindControl("txtAccountingCode") as TextBox;
                TextBox textBox1 = item.FindControl("txtDescription") as TextBox;
                CheckBox checkBox = item.FindControl("chkDefault") as CheckBox;
                CheckBox checkBox1 = item.FindControl("chkPurchaseDefault") as CheckBox;
                CheckBox checkBox2 = e.Item.FindControl("chkRevenuCode") as CheckBox;
                CheckBox checkBox3 = e.Item.FindControl("chkPurchaseCode") as CheckBox;
                HiddenField hiddenField7 = item.FindControl("hdnIsDefault") as HiddenField;
                HiddenField hiddenField8 = item.FindControl("hdnIsPurchaseDefault") as HiddenField;
                HiddenField hiddenField9 = item.FindControl("hdnRevenueCode") as HiddenField;
                HiddenField hiddenField10 = item.FindControl("hdnPurchaseCode") as HiddenField;
                textBox.Focus();
                textBox.Text = base.SpecialDecode(textBox.Text);
                textBox1.Text = base.SpecialDecode(textBox1.Text);
                if (hiddenField9.Value.ToLower() != "true")
                {
                    checkBox2.Checked = false;
                }
                else
                {
                    checkBox2.Checked = true;
                }
                if (hiddenField10.Value.ToLower() != "true")
                {
                    checkBox3.Checked = false;
                }
                else
                {
                    checkBox3.Checked = true;
                }
                if (hiddenField7.Value == "True")
                {
                    checkBox.Checked = true;
                    checkBox.Enabled = false;
                }
                if (hiddenField8.Value.ToLower() == "true")
                {
                    checkBox1.Checked = true;
                }
                try
                {
                    if (e.Item is GridEditFormInsertItem)
                    {
                        e.Item.FindControl("chkRevenuCode");
                        e.Item.FindControl("chkPurchaseCode");
                        checkBox2.Checked = true;
                        checkBox3.Checked = true;
                    }
                }
                catch
                {
                }
            }
        }

        protected void gridAccountingCodes_ItemDeleted(object sender, GridDeletedEventArgs e)
        {
            base.Message_Display(this.objlang.GetLanguageConversion("Accounting_codes_deleted_successfully"), "msg-success", this.plhMessage);
        }

        protected void gridAccountingCodes_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.gridAccountingCodes.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.gridAccountingCodes.MasterTableView.ClearEditItems();
            }
        }

        protected void gridAccountingCodes_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            int pageSize = this.gridAccountingCodes.PageSize;
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txtAccountingCode");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtDescription");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnAccountCodeID");
            Label label = (Label)e.Item.FindControl("lblDuplicacyCheck");
            CheckBox checkBox = e.Item.FindControl("chkDefault") as CheckBox;
            CheckBox checkBox1 = e.Item.FindControl("chkPurchaseDefault") as CheckBox;
            CheckBox checkBox2 = e.Item.FindControl("chkRevenuCode") as CheckBox;
            CheckBox checkBox3 = e.Item.FindControl("chkPurchaseCode") as CheckBox;
            bool flag = true;
            flag = (!checkBox2.Checked ? false : true);
            bool flag1 = true;
            flag1 = (!checkBox3.Checked ? false : true);
            bool flag2 = false;
            flag2 = (!checkBox.Checked ? false : true);
            bool flag3 = false;
            flag3 = (!checkBox1.Checked ? false : true);
            if (textBox1.Text == null)
            {
                textBox1.Text = " ";
            }
            this.return1 = SettingsBasePage.Setting_accountingCode_Insert(Convert.ToInt32(this.CompanyID.ToString()), textBox.Text, textBox1.Text, flag2, flag3, Convert.ToInt32(hiddenField.Value), flag, flag1);
            if (this.return1 != -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Accounting_code_updated_successfully"), "msg-success", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Accounting_code_already_exists"), "msg-fail", this.plhMessage);
            }
            this.gridAccountingCodes.Rebind();
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.Setting_accountingCode_Delete(this.CompanyID, Convert.ToInt32(e.CommandArgument.ToString()));
            this.gridAccountingCodes.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Accounting_code_deleted_successfully"), "msg-success", this.plhMessage);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.gridAccountingCodes.FilterMenu;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gridAccountingCodes.MasterTableView.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Accounting_Codes");
            this.gridAccountingCodes.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Description");
            this.gridAccountingCodes.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("In_Use");
            this.gridAccountingCodes.MasterTableView.Columns[4].HeaderText = this.objlang.GetLanguageConversion("Revenu_Code");
            this.gridAccountingCodes.MasterTableView.Columns[5].HeaderText = this.objlang.GetLanguageConversion("Revenue_Codes");
            this.gridAccountingCodes.MasterTableView.Columns[6].HeaderText = this.objlang.GetLanguageConversion("Purchase_Code");
            this.gridAccountingCodes.MasterTableView.Columns[7].HeaderText = this.objlang.GetLanguageConversion("Purchase_Codes");
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Accounting_Code");
            this.gridAccountingCodes.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Accounting_Code")));
            base.Title = this.objLanguage.convert(global.pageTitle("Accounting Codes", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            DataTable table = ((DataView)this.AccountCodeDataSource.Select()).Table;
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
        }
    }
}