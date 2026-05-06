using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class manage_campaign : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private commonClass commclass = new commonClass();

        private BaseClass objBase = new BaseClass();

        public string DateFormat = "mm/dd/yyyy";

        public string Type = string.Empty;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public long ClientID;

        public long delveryAddressID;

        private DateTime EventStartDate;

        private DateTime EventEndDate;

        private DateTime DelveryDate;

        public string AccountType = string.Empty;

        private bool isarchive;

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

        public manage_campaign()
        {
        }

        protected void btn_MangeClient_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidGridCount.Value))
            {
                string[] strArrays = this.hidGridCount.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        SettingsBasePage.settings_managecampaign_delete((long)Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Campaign_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.grdmanagecampignBind();
            this.grdmanagecampign.Rebind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.Chkenablecamp.Checked)
            {
                SettingsBasePage.SaveCampaign((long)this.AccountID, (long)this.CompanyID, 1);
                base.Message_Display(this.objLanguage.GetLanguageConversion("Campaign_Enabled_Successfully"), "msg-success", this.plhMessage);
                //this.Chkenablecamp.Enabled = false;
                //this.btn_Save.Visible = false;
                this.grdmanagecampign.Visible = true;
                this.grdmanagecampignBind();
                this.grdmanagecampign.Rebind();
            }
            else {
                SettingsBasePage.SaveCampaign((long)this.AccountID, (long)this.CompanyID, 0);
                this.grdmanagecampign.Visible = false;
            }
        }

        protected void grdmanagecampign_InsertCommand(object source, GridCommandEventArgs e)
        {
            TextBox textBox = (TextBox)e.Item.FindControl("txtEventName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtOrdNo");
            Label label = (Label)e.Item.FindControl("lblDeliveryAddressValue");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtVenue");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txteventcode");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txtEventStartdate");
            TextBox textBox5 = (TextBox)e.Item.FindControl("txtEventEnddate");
            TextBox textBox6 = (TextBox)e.Item.FindControl("txtDeliveryDate");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkArchive");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_DeliveryAddressID");
            if (hiddenField.Value != "")
            {
                this.delveryAddressID = Convert.ToInt64(hiddenField.Value);
            }
            if (checkBox.Checked)
            {
                this.isarchive = true;
            }
            this.EventStartDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox4.Text));
            this.DelveryDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox6.Text));
            this.EventEndDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox5.Text));
            SettingsBasePage.ManageCampign_Insert_Update((long)this.CompanyID, (long)this.UserID, (long)this.AccountID, (long)0, textBox.Text, textBox2.Text, textBox3.Text, this.EventStartDate, this.EventEndDate, "A", this.isarchive, textBox1.Text, this.delveryAddressID, this.DelveryDate);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Campaign_Saved_Successfully"), "msg-success", this.plhMessage);
            this.grdmanagecampignBind();
        }

        protected void grdmanagecampign_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.grdmanagecampign.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.grdmanagecampign.MasterTableView.ClearEditItems();
            }
            this.hdnrecordtype.Value = "edit";
        }

        protected void grdmanagecampign_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
        }

        protected void grdmanagecampign_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    Label label = (Label)e.Item.FindControl("lblEventEndDate_Value");
                    Label label1 = (Label)e.Item.FindControl("lblEventStartDate_Value");
                    Label label2 = (Label)e.Item.FindControl("lbldel_Date_Value");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnMangeID");
                    Image image = (Image)e.Item.FindControl("img_InUse");
                    Image image1 = (Image)e.Item.FindControl("img_isArchive");
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonErase");
                    DataTable dataTable = SettingsBasePage.SelectInUseCampaign((long)this.AccountID, Convert.ToInt64(hiddenField.Value));
                    int num = 0;
                    string empty = string.Empty;
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        empty = row["isArchive"].ToString();
                        num = Convert.ToInt32(row["InUse"]);
                    }
                    if (num != -1)
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                        imageButton.Visible = true;
                    }
                    if (empty.ToLower() != "true")
                    {
                        image1.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                    }
                    else
                    {
                        image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    }
                    label1.Text = this.commclass.Eprint_return_Date_Before_View(label1.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.UserID), false);
                    label.Text = this.commclass.Eprint_return_Date_Before_View(label.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.UserID), false);
                    label2.Text = this.commclass.Eprint_return_Date_Before_View(label2.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.UserID), false);
                }
                if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    TextBox textBox = (TextBox)e.Item.FindControl("txtEventName");
                    textBox.Text = base.SpecialDecode(textBox.Text);
                    CheckBox checkBox = (CheckBox)e.Item.FindControl("chkArchive");
                    if (checkBox.Text.ToLower() == "true")
                    {
                        checkBox.Checked = true;
                    }
                    textBox.Focus();
                    checkBox.Text = "";
                    TextBox textBox1 = (TextBox)e.Item.FindControl("txtEventStartdate");
                    if (textBox1.Text == "1/1/1900 12:00:00 AM")
                    {
                        textBox1.Text = "";
                    }
                    else if (textBox1.Text != "")
                    {
                        textBox1.Text = this.commclass.Eprint_return_Date_Before_View(textBox1.Text, this.CompanyID, this.UserID, false);
                    }
                    textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox2 = (TextBox)e.Item.FindControl("txtEventEnddate");
                    if (textBox2.Text == "1/1/1900 12:00:00 AM")
                    {
                        textBox2.Text = "";
                    }
                    else if (textBox2.Text != "")
                    {
                        textBox2.Text = this.commclass.Eprint_return_Date_Before_View(textBox2.Text, this.CompanyID, this.UserID, false);
                    }
                    textBox2.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox3 = (TextBox)e.Item.FindControl("txtDeliveryDate");
                    if (textBox3.Text == "1/1/1900 12:00:00 AM")
                    {
                        textBox3.Text = "";
                    }
                    else if (textBox3.Text != "")
                    {
                        textBox3.Text = this.commclass.Eprint_return_Date_Before_View(textBox3.Text, this.CompanyID, this.UserID, false);
                    }
                    textBox3.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        protected void grdmanagecampign_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            TextBox textBox = (TextBox)e.Item.FindControl("txtDeliveryDate");
            this.DelveryDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox.Text));
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_DeliveryAddressID");
            this.delveryAddressID = Convert.ToInt64(hiddenField.Value);
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtOrdNo");
            Label label = (Label)e.Item.FindControl("lblDeliveryAddressValue");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtEventName");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txtVenue");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txteventcode");
            TextBox textBox5 = (TextBox)e.Item.FindControl("txtEventStartdate");
            TextBox textBox6 = (TextBox)e.Item.FindControl("txtEventEnddate");
            if (((CheckBox)e.Item.FindControl("chkArchive")).Checked)
            {
                this.isarchive = true;
            }
            this.EventStartDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox5.Text));
            this.EventEndDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox6.Text));
            HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_ManID");
            this.DelveryDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, textBox.Text));
            SettingsBasePage.ManageCampign_Insert_Update((long)this.CompanyID, (long)this.UserID, (long)this.AccountID, Convert.ToInt64(hiddenField1.Value), textBox2.Text, textBox3.Text, textBox4.Text, this.EventStartDate, this.EventEndDate, "A", this.isarchive, textBox1.Text, this.delveryAddressID, this.DelveryDate);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Campaign_Updated_Successfully"), "msg-success", this.plhMessage);
            this.grdmanagecampignBind();
        }

        public void grdmanagecampignBind()
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.SelectMangeCampign((long)this.CompanyID, (long)this.UserID, (long)this.AccountID);
            this.hdnEventNames.Value = "";
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    HiddenField hiddenField = this.hdnEventNames;
                    string[] value = new string[] { this.hdnEventNames.Value, dataTable.Rows[i]["Eventname"].ToString(), "~", dataTable.Rows[i]["ManageID"].ToString(), "," };
                    hiddenField.Value = string.Concat(value);
                }
            }
            this.grdmanagecampign.DataSource = dataTable;
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            long num = (long)Convert.ToInt32(imageButton.CommandArgument.ToString());
            SettingsBasePage.settings_managecampaign_delete(num);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Campaign_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.grdmanagecampignBind();
            this.grdmanagecampign.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdmanagecampign.FilterMenu;
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Manage_Campaign")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Manage Campaign", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Campaign");
            this.header.dtAccountList = this.objAcc.AccountsListforApprovalSystem(this.CompanyID);
            this.DateFormat = this.Session["DateFormat"].ToString();
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                if (strArrays[1].ToString() != "")
                {
                    this.ClientID = (long)Convert.ToInt32(strArrays[1]);
                }
            }
            if (this.AccountID != 0)
            {
                this.AccountType = WebstoreBasePage.SelectAccountType(Convert.ToInt32(this.AccountID));
                if (this.AccountType.ToLower() == "x")
                {
                    this.AccountID = 0;
                }
            }
            this.grdmanagecampignBind();
            if (this.AccountID != 0 && SettingsBasePage.CheckIsCampaignEnabled((long)this.AccountID, (long)this.CompanyID) )
            {
                //this.Chkenablecamp.Checked = true;
                //this.Chkenablecamp.Enabled = false;
                //this.btn_Save.Visible = false;
                this.grdmanagecampign.Visible = true;
            }else
            //if (!base.IsPostBack && !this.Chkenablecamp.Checked)
            {
                this.grdmanagecampign.Visible = false;
            }
        }
    }
}