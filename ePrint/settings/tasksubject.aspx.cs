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
    public partial class tasksubject : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadCodeBlock RadCodeBlock1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected LinkButton lnkDeleteStatus;

        //protected RadGrid radgrdtasksubject;

        //protected UpdatePanel UpdatePanel1;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor1;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        public int CompanyID;

        public int UserID;

        private Global objglobal = new Global();

        public languageClass objlang = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public tasksubject()
        {
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.radgrdtasksubject.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.radgrdtasksubject.MasterTableView.FilterExpression = string.Empty;
            this.radgrdtasksubject.MasterTableView.Rebind();
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.Settings_TaskSubject_delete((long)Convert.ToInt32(e.CommandArgument));
            this.radgrdtasksubject.Rebind();
            this.NoRecords();
            base.Message_Display(this.objlang.GetLanguageConversion("Subject_Deleted_Successfully"), "msg-success", this.plhMessage);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Message();", true);
        }

        protected void lnkDeleteStatus_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.radgrdtasksubject.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.radgrdtasksubject.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked && !htmlInputCheckBox.Disabled)
                {
                    SettingsBasePage.Settings_TaskSubject_delete((long)Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.radgrdtasksubject.Rebind();
            this.NoRecords();
            base.Message_Display(this.objlang.GetLanguageConversion("Subject_Deleted_Successfully"), "msg-success", this.plhMessage);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Message();", true);
        }

        public void NoRecords()
        {
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            if (table.Rows.Count == 0)
            {
                this.radgrdtasksubject.MasterTableView.GetColumn("Checkbox").Visible = false;
                this.radgrdtasksubject.MasterTableView.PagerStyle.Visible = false;
                this.radgrdtasksubject.MasterTableView.AllowFilteringByColumn = false;
                return;
            }
            this.radgrdtasksubject.MasterTableView.GetColumn("Checkbox").Visible = true;
            this.radgrdtasksubject.MasterTableView.PagerStyle.Visible = true;
            this.radgrdtasksubject.MasterTableView.AllowFilteringByColumn = true;
            if (table.Rows.Count == 1 && table.Rows[0]["IsDefault"].ToString() == "True")
            {
                this.radgrdtasksubject.MasterTableView.GetColumn("Checkbox").Visible = false;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.radgrdtasksubject.FilterMenu;
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
            this.radgrdtasksubject.MasterTableView.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Subject");
            this.radgrdtasksubject.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Default");
            this.radgrdtasksubject.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Action");
            this.radgrdtasksubject.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("Detele_Selected");
            this.objglobal.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.convert(global.pageTitle(this.objlang.GetLanguageConversion("Task_Subject"), this.CompanyID, this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Task_Subject")));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Task_Subject");
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            this.NoRecords();
        }

        protected void radgrdtasksubject_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtSubject");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            SettingsBasePage.Settings_TaskSubject_Insert(base.SpecialEncode(textBox.Text).Trim(), (long)this.CompanyID, checkBox.Checked);
            base.Message_Display(this.objlang.GetLanguageConversion("Subject_Saved_Successfully"), "msg-success", this.plhMessage);
            this.radgrdtasksubject.Rebind();
            this.NoRecords();
            item.Display = false;
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Message();", true);
        }

        protected void radgrdtasksubject_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.radgrdtasksubject.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.radgrdtasksubject.MasterTableView.ClearEditItems();
            }
        }

        protected void radgrdtasksubject_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                TextBox textBox = item.FindControl("txtSubject") as TextBox;
                CheckBox checkBox = (CheckBox)item.FindControl("chkDefault");
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnDefault");
                RequiredFieldValidator languageConversion = (RequiredFieldValidator)item.FindControl("requiredfieldvalidator1");
                languageConversion.ErrorMessage = this.objlang.GetLanguageConversion("Enter_Subject");
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
                text["Subject"].ToolTip = text["Subject"].Text;
                text["Subject"].Text = string.Concat("<div style='width:100%;overflow:hidden;max-height: 15px;height:15px;cursor:pointer'>", base.SpecialDecode(text["Subject"].Text), "</div>");
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

        public void radgrdtasksubject_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtSubject");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnSubjectID");
            SettingsBasePage.Settings_TaskSubject_Update(Convert.ToInt64(hiddenField.Value), (long)this.CompanyID, base.SpecialEncode(textBox.Text).Trim(), checkBox.Checked);
            base.Message_Display(this.objlang.GetLanguageConversion("Subject_Updated_Successfully"), "msg-success", this.plhMessage);
            this.radgrdtasksubject.Rebind();
            item.Display = false;
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Message();", true);
        }

        protected void setDefault_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.Settings_TaskSubject_status_update((long)Convert.ToInt32(e.CommandArgument), (long)this.CompanyID);
            base.Message_Display(this.objlang.GetLanguageConversion("Subject_status_set_successfully"), "msg-success", this.plhMessage);
            this.radgrdtasksubject.Rebind();
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:Message();", true);
        }
    }
}