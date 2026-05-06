using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.DataAccessLayer.Settings;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class jobCardsettings : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private commonClass commclass = new commonClass();

        public int CompanyID;

        public int UserID;

        public languageClass objlang = new languageClass();

        public bool Is_Non_Printing_System;

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

        public jobCardsettings()
        {
        }

        protected void btnReset_Clicked(object sender, EventArgs e)
        {
            string str = this.ddlEstimateTypes.SelectedValue.ToString();
            DbSettings dbSetting = new DbSettings();
            DataTable dataTable = new DataTable();
            dataTable = dbSetting.Setting_JobCardSettings_SelectAll_levelZero(this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
            if (this.Is_Non_Printing_System && (str.ToLower() == "o" || str.ToLower() == "w" || str.ToLower() == "u" || str.ToLower() == "q" || str.ToLower() == "c"))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!(row["SectionName"].ToString().ToLower() == "pre press") && !(row["SectionName"].ToString().ToLower() == "press") && !(row["SectionName"].ToString().ToLower() == "post press") && !(row["SectionName"].ToString().ToLower() == "paper") && !(row["SectionName"].ToString().ToLower() == "ink") && !(row["SectionName"].ToString().ToLower() == "plates") && !(row["SectionName"].ToString().ToLower() == "guillotine") && !(row["SectionName"].ToString().ToLower() == "wash up") && !(row["SectionName"].ToString().ToLower() == "make ready"))
                    {
                        continue;
                    }
                    row.Delete();
                }
                dataTable.AcceptChanges();
            }
            this.gridJobCardSettings.DataSource = dataTable;
            this.gridJobCardSettings.DataBind();
            this.gridJobCardSettings.CurrentPageIndex = 0;
        }

        protected void btnSave_Clicked(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            foreach (GridDataItem item in this.gridJobCardSettings.MasterTableView.Items)
            {
                Label label = (Label)item.FindControl("lblSectionName");
                TextBox textBox = (TextBox)item.FindControl("txtDescription");
                if (!((CheckBox)item.FindControl("Chkbx1")).Checked)
                {
                    SettingsBasePage.Setting_JobCardSettings_Insert(Convert.ToInt32(this.Session["CompanyID"]), label.Text, textBox.Text, false, this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
                }
                else
                {
                    SettingsBasePage.Setting_JobCardSettings_Insert(Convert.ToInt32(this.Session["CompanyID"]), label.Text, textBox.Text, true, this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
                }
            }
            this.gridJobCardSettings.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Settings_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        protected void ddlEstimateTypes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            this.gridBind(this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
            this.Tags_GridBind(this.ddlEstimateTypes.SelectedValue.ToString());
            // && !(this.ddlEstimateTypes.SelectedValue.ToString() == "C")
            if (!(this.ddlEstimateTypes.SelectedValue.ToString() == "B") && !(this.ddlEstimateTypes.SelectedValue.ToString() == "N") && !(this.ddlEstimateTypes.SelectedValue.ToString() == "K")  && !(this.ddlEstimateTypes.SelectedValue.ToString() == "Q") && !(this.ddlEstimateTypes.SelectedValue.ToString() == "W"))
            {
                flag = false;
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "items", string.Concat("javascript:DisableDdl('", flag, "');"), true);
                return;
            }
            flag = true;
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "items", string.Concat("javascript:DisableDdl('", flag, "');"), true);
        }

        protected void ddlItemType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridBind(this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
        }

        public void EstimatesTypesfromDwebconfig()
        {
            int num = 0;
            if (ConnectionClass.SheetFedDigital != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.SheetFedDigital);
                this.ddlEstimateTypes.Items[num].Value = "sfd";
                num++;
            }
            if (ConnectionClass.DigitalSingleItem != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.DigitalSingleItem);
                this.ddlEstimateTypes.Items[num].Value = "S";
                this.ddlEstimateTypes.Items[num].Selected = true;
                num++;
            }
            if (ConnectionClass.DigitalBooklet != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.DigitalBooklet);
                this.ddlEstimateTypes.Items[num].Value = "B";
                num++;
            }
            if (ConnectionClass.DigitalPads != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.DigitalPads);
                this.ddlEstimateTypes.Items[num].Value = "P";
                num++;
            }
            if (ConnectionClass.DigitalNCR != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.DigitalNCR);
                this.ddlEstimateTypes.Items[num].Value = "R";
                num++;
            }
            if (ConnectionClass.SheetFedOffset != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.SheetFedOffset);
                this.ddlEstimateTypes.Items[num].Value = "sfo";
                num++;
            }
            if (ConnectionClass.OffsetSingleItem != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.OffsetSingleItem);
                this.ddlEstimateTypes.Items[num].Value = "F";
                num++;
            }
            if (ConnectionClass.OffsetPad != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.OffsetPad);
                this.ddlEstimateTypes.Items[num].Value = "D";
                num++;
            }
            if (ConnectionClass.OffsetNCR != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.OffsetNCR);
                this.ddlEstimateTypes.Items[num].Value = "N";
                num++;
            }
            if (ConnectionClass.OffsetBooklet != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.OffsetBooklet);
                this.ddlEstimateTypes.Items[num].Value = "K";
                num++;
            }
            if (ConnectionClass.LargeFormat != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.LargeFormat);
                this.ddlEstimateTypes.Items[num].Value = "L";
                num++;
            }
            if (ConnectionClass.PrintBroker != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.PrintBroker);
                this.ddlEstimateTypes.Items[num].Value = "O";
                num++;
            }
            if (ConnectionClass.Warehouse != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.Warehouse);
                this.ddlEstimateTypes.Items[num].Value = "W";
                num++;
            }
            if (ConnectionClass.OtherCosts != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.OtherCosts);
                this.ddlEstimateTypes.Items[num].Value = "U";
                num++;
            }
            if (ConnectionClass.PriceCatalogue != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.PriceCatalogue);
                this.ddlEstimateTypes.Items[num].Value = "C";
                num++;
            }
            if (ConnectionClass.QuickQuote != null)
            {
                this.ddlEstimateTypes.Items.Insert(num, ConnectionClass.QuickQuote);
                this.ddlEstimateTypes.Items[num].Value = "Q";
                num++;
            }
        }

        public void gridBind(string estimateType, string ItemType)
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Setting_JobCardSettings_SelectAll(Convert.ToInt32(this.Session["CompanyID"]), estimateType, ItemType);
            if (this.Is_Non_Printing_System && (estimateType.ToLower() == "o" || estimateType.ToLower() == "w" || estimateType.ToLower() == "u" || estimateType.ToLower() == "q" || estimateType.ToLower() == "c"))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!(row["SectionName"].ToString().ToLower() == "pre press") && !(row["SectionName"].ToString().ToLower() == "press") && !(row["SectionName"].ToString().ToLower() == "post press") && !(row["SectionName"].ToString().ToLower() == "paper") && !(row["SectionName"].ToString().ToLower() == "ink") && !(row["SectionName"].ToString().ToLower() == "plates") && !(row["SectionName"].ToString().ToLower() == "guillotine") && !(row["SectionName"].ToString().ToLower() == "wash up") && !(row["SectionName"].ToString().ToLower() == "make ready"))
                    {
                        continue;
                    }
                    row.Delete();
                }
                dataTable.AcceptChanges();
            }
            this.gridJobCardSettings.DataSource = dataTable;
            this.gridJobCardSettings.DataBind();
            this.gridJobCardSettings.CurrentPageIndex = 0;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.TagsGrid.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "lesshanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RadButton1.Text = this.objLanguage.GetLanguageConversion("Save");
            this.RadButton2.Text = this.objLanguage.GetLanguageConversion("Restore_Default");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnReset.Text = this.objLanguage.GetLanguageConversion("Restore_Default");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Job_Card_Settings"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job_Card_Settings")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Job_Card_Settings");
            if (!base.IsPostBack)
            {
                this.EstimatesTypesfromDwebconfig();
                this.gridBind(this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
            }
            this.Tags_GridBind(this.ddlEstimateTypes.SelectedValue.ToString());
            foreach (ListItem item in this.ddlEstimateTypes.Items)
            {
                if (item.Value == "sfd" || item.Value == "sfo")
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                else if (item.Value == "S" || item.Value == "B" || item.Value == "P" || item.Value == "F" || item.Value == "D" || item.Value == "K" || item.Value == "N")
                {
                    item.Attributes.Add("style", "padding-left:10px");
                }
                else
                {
                    item.Attributes.Add("style", "padding-left:1px");
                }
            }
            this.gridJobCardSettings.CurrentPageIndex = 0;
            this.ddlItemType.Items[0].Text = this.objLanguage.GetLanguageConversion("Main_Item");
            this.ddlItemType.Items[1].Text = this.objLanguage.GetLanguageConversion("Sub_Item");
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            this.Is_Non_Printing_System = ConnectionClass.Is_Non_Printing_System;
        }

        protected void RestoreDefault_Clicked(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.gridJobCardSettings.MasterTableView.Items)
            {
                CheckBox checkBox = (CheckBox)item.FindControl("Chkbx2");
                Label label = (Label)item.FindControl("lblSectionName");
                Label label1 = (Label)item.FindControl("lblEstimateType");
                TextBox textBox = (TextBox)item.FindControl("txtDescription");
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnItemType");
                if (!checkBox.Checked)
                {
                    continue;
                }
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_JobCardSettings_RestoreDefault");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(this.Session["CompanyID"]));
                database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, label.Text);
                database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, label1.Text.ToString());
                database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, hiddenField.Value.ToString());
                database.ExecuteNonQuery(storedProcCommand);
            }
            this.gridBind(this.ddlEstimateTypes.SelectedValue.ToString(), this.ddlItemType.SelectedValue.ToString());
        }

        public void Tags_GridBind(string estimateType)
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Setting_jobcardtags_Select(estimateType);
            this.TagsGrid.DataSource = dataTable;
            this.TagsGrid.DataBind();
        }
    }
}