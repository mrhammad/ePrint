using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
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
    public partial class callpurpose : BaseClass, IRequiresSessionState
    {
        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadCodeBlock RadCodeBlock1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected LinkButton lnkDeleteStatus;

        //protected RadGrid RadGrid1;

        //protected UpdatePanel UpdatePanel2;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor1;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        public int CompanyID;

        public int UserID;

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        private Global objglobal = new Global();

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

        public callpurpose()
        {
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGrid1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.RadGrid1.MasterTableView.FilterExpression = string.Empty;
            this.RadGrid1.MasterTableView.Rebind();
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.CallPurpose_delete((long)Convert.ToInt32(e.CommandArgument));
            this.RadGrid1.Rebind();
            this.NoRecords();
            base.Message_Display(this.objlang.GetLanguageConversion("Call_Purpose_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkDeleteStatus_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid1.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked && !htmlInputCheckBox.Disabled)
                {
                    SettingsBasePage.CallPurpose_delete((long)Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.RadGrid1.Rebind();
            this.NoRecords();
            base.Message_Display(this.objlang.GetLanguageConversion("Call_Purpose_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void NoRecords()
        {
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            if (table.Rows.Count == 0)
            {
                this.RadGrid1.MasterTableView.GetColumn("Checkbox").Visible = false;
                this.RadGrid1.MasterTableView.PagerStyle.Visible = false;
                this.RadGrid1.MasterTableView.AllowFilteringByColumn = false;
                return;
            }
            this.RadGrid1.MasterTableView.GetColumn("Checkbox").Visible = true;
            this.RadGrid1.MasterTableView.PagerStyle.Visible = true;
            this.RadGrid1.MasterTableView.AllowFilteringByColumn = true;
            if (table.Rows.Count == 1 && table.Rows[0]["IsDefault"].ToString() == "True")
            {
                this.RadGrid1.MasterTableView.GetColumn("Checkbox").Visible = false;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.RadGrid1.FilterMenu;
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
            this.lnkDeleteStatus.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.RadGrid1.MasterTableView.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Call_Subject");
            this.RadGrid1.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Default");
            this.RadGrid1.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Action");
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("Detele_Selected");
            this.objglobal.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.convert(global.pageTitle(this.objlang.GetLanguageConversion("Call_Subject"), this.CompanyID, this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Call_Subject")));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Call_Subject");
            if (((DataView)this.SessionDataSource1.Select()).Table.Rows.Count == 0)
            {
                this.lnkDeleteStatus.Visible = false;
            }
            else
            {
                this.lnkDeleteStatus.Visible = true;
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            this.NoRecords();
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtStautsTitle");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            if (SettingsBasePage.CallPurpose_insert(this.CompanyID, base.SpecialEncode(textBox.Text), checkBox.Checked, this.UserID) == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Call_Purpose_Already_Exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Call_Purpose_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            this.RadGrid1.Rebind();
            this.NoRecords();
            item.Display = false;
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGrid1.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGrid1.MasterTableView.ClearEditItems();
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                TextBox textBox = item.FindControl("txtStautsTitle") as TextBox;
                CheckBox checkBox = (CheckBox)item.FindControl("chkDefault");
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnDefault");
                RequiredFieldValidator languageConversion = (RequiredFieldValidator)item.FindControl("requiredfieldvalidator1");
                languageConversion.ErrorMessage = this.objlang.GetLanguageConversion("Please_enter_Call_Purpose");
                textBox.Text = base.SpecialDecode(textBox.Text);
                if (hiddenField.Value.ToLower() == "false")
                {
                    checkBox.Checked = false;
                }
                else if (hiddenField.Value.ToLower() != "true")
                {
                    checkBox.Checked = false;
                }
                else
                {
                    checkBox.Checked = true;
                }
                textBox.Focus();
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem text = (GridDataItem)e.Item;
                text["CallPurpose"].ToolTip = text["CallPurpose"].Text;
                text["CallPurpose"].Text = string.Concat("<div style='width:100%;overflow:hidden;max-height: 15px;height:15px;cursor:pointer'>", base.SpecialDecode(text["CallPurpose"].Text), "</div>");
                HiddenField hiddenField1 = (HiddenField)text.FindControl("hdn_Default");
                Image image = (Image)text.FindControl("img_Default");
                ImageButton imageButton = (ImageButton)text.FindControl("imgbtnDelete");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)text.FindControl("Id");
                imageButton.ToolTip = this.objlang.GetLanguageConversion("Delete");
                if (hiddenField1.Value != "True")
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "ICON_checkbox_u.gif");
                    htmlInputCheckBox.Disabled = false;
                    imageButton.Enabled = true;
                }
                else
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "ICON_checkboxNew.gif");
                    htmlInputCheckBox.Visible = false;
                    imageButton.Visible = false;
                }
            }
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            this.NoRecords();
        }

        public void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtStautsTitle");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnStatusID");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            SettingsItem settingsItem = new SettingsItem()
            {
                CPStatusID = Convert.ToInt64(hiddenField.Value),
                CompanyID = this.CompanyID,
                StatusTitle = base.SpecialEncode(textBox.Text),
                IsDefaultStatus = checkBox.Checked
            };
            SettingsBasePage.CallPurpose_update(settingsItem);
            base.Message_Display(this.objlang.GetLanguageConversion("Call_Purpose_Updated_Successfully"), "msg-success", this.plhMessage);
            this.RadGrid1.Rebind();
            item.Display = false;
        }

        protected void setDefault_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.CallPurpose_status_update((long)this.CompanyID, (long)Convert.ToInt16(e.CommandArgument));
            base.Message_Display(this.objlang.GetLanguageConversion("Call_Purpose_Status_Set_Successfully"), "msg-success", this.plhMessage);
            this.RadGrid1.Rebind();
        }
    }
}