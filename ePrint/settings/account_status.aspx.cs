using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class account_status : BaseClass, IRequiresSessionState
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

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor2;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        public int CompanyID;

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

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

        public account_status()
        {
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_accountstatus_delete");
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.String, e.CommandArgument);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
            this.RadGrid1.Rebind();
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void lnkDeleteStatus_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid1.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.settings_accountstatus_delete(this.CompanyID, Convert.ToInt32(htmlInputCheckBox.Value.ToString()));
                }
            }
            this.RadGrid1.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lnkDeleteStatus.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.RadGrid1.MasterTableView.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Status");
            this.RadGrid1.MasterTableView.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Default");
            this.RadGrid1.MasterTableView.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Action");
            this.RadGrid1.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("Detele_Selected");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle(this.objlang.GetLanguageConversion("Account_Status"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Account_Status")));
            this.lblheader.Text = this.objlang.GetLanguageConversion("Settings_Account_Status");
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Account_Status");
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
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtStautsTitle");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            if (SettingsBasePage.settings_accountstatus_insert(this.CompanyID, base.SpecialEncode(textBox.Text), checkBox.Checked) == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_already_exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            this.RadGrid1.Rebind();
            item.Display = false;
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
                languageConversion.ErrorMessage = this.objlang.GetLanguageConversion("Please_Enter_Status");
                textBox.Text = base.SpecialDecode(textBox.Text);
                if (textBox.Text.ToLower() == "account on hold")
                {
                    textBox.Enabled = false;
                }
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
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                gridDataItem["TaxName"].ToolTip = base.SpecialDecode(gridDataItem["TaxName"].Text);
                gridDataItem["TaxName"].Text = string.Concat("<div style='width:100%;overflow:hidden;max-height: 15px;height:15px;cursor:pointer'>", base.SpecialDecode(gridDataItem["TaxName"].Text), "</div>");
                HiddenField hiddenField1 = (HiddenField)gridDataItem.FindControl("hdn_Default");
                Image image = (Image)gridDataItem.FindControl("img_Default");
                ImageButton imageButton = (ImageButton)gridDataItem.FindControl("imgbtnDelete");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)gridDataItem.FindControl("Id");
                if (hiddenField1.Value != "True")
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "ICON_checkbox_u.gif");
                    htmlInputCheckBox.Disabled = false;
                    imageButton.Enabled = true;
                }
                else
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "ICON_checkboxNew.gif");
                    htmlInputCheckBox.Disabled = true;
                    imageButton.Enabled = false;
                    imageButton.Attributes.Add("style", "display:none");
                }
                if (gridDataItem["TaxName"].ToolTip.ToLower() == "account on hold")
                {
                    htmlInputCheckBox.Disabled = true;
                    imageButton.Enabled = false;
                    imageButton.Attributes.Add("style", "display:none");
                }
            }
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
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

        public void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtStautsTitle");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnStatusID");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            if (SettingsBasePage.settings_accountstatus_update(this.CompanyID, Convert.ToInt16(hiddenField.Value), base.SpecialEncode(textBox.Text), checkBox.Checked) == -1)
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_already_exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_Updated_Sucessfully"), "msg-success", this.plhMessage);
            }
            this.RadGrid1.Rebind();
            item.Display = false;
        }

        protected void setDefault_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.settings_accountstatus_setDefalut(this.CompanyID, Convert.ToInt16(e.CommandArgument));
            base.Message_Display(this.objlang.GetLanguageConversion("Account_Status_Set_Successfully"), "msg-success", this.plhMessage);
            this.RadGrid1.Rebind();
        }
    }
}