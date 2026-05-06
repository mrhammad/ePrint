using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
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

namespace ePrint.WebStore
{
    public partial class Campaign : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager ScriptManager1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lblmsg;

        //protected LinkButton lnkDeleteStatus;

        //protected RadGrid radgrdCampaign;

        //protected UpdatePanel UpdatePanel2;

        //protected GridTextBoxColumnEditor GridTextBoxColumnEditor1;

        //protected RadWindowManager RadWindowManager1;

        //protected ObjectDataSource SessionDataSource1;

        //protected HtmlGenericControl Campaign_div;

        //protected HiddenField hidGridCount;

        //protected Label lblAddressBook1;

        //protected RadTextBox grd_Search_ship;

        //protected Panel Panel1;

        //protected ImageButton imgSearch_Ship;

        //protected HtmlGenericControl spn_ListAllAdddress1;

        //protected LinkButton lnkbtnAddNewAddress;

        //protected RadGrid rdgrd_ship_choose;

        //protected Label lblNewAddress;

        //protected Label lblAddress_Label;

        //protected TextBox txtaddressLabelBilling;

        //protected Label lnlExample_Note;

        //protected Label lblAddressBill1;

        //protected Label lblBillAdd1_UC;

        //protected TextBox txt_address_billing1;

        //protected RequiredFieldValidator Required_Address1;

        //protected Label lblAddressBill2;

        //protected Label lblBillAdd2_UC;

        //protected TextBox txt_address_billing2;

        //protected RequiredFieldValidator Required_Address2;

        //protected Label lblAddressBill3;

        //protected Label lblBillAdd3_UC;

        //protected TextBox txt_address_billing3;

        //protected RequiredFieldValidator Required_Address3;

        //protected Label lblAddressBill4;

        //protected Label lblBillAdd4_UC;

        //protected TextBox txt_address_billing4;

        //protected RequiredFieldValidator Required_Address4;

        //protected Label lblAddressBill5;

        //protected Label lblBillAdd5_UC;

        //protected TextBox txt_address_billing5;

        //protected RequiredFieldValidator Required_Address5;

        //protected Label lblCountry;

        //protected DropDownList ddlCountry;

        //protected RequiredFieldValidator Required_Country;

        //protected HtmlGenericControl sdf;

        //protected HiddenField hdnCountryID;

        //protected Label lblTelephone;

        //protected Label lblBillPhone_UC;

        //protected TextBox txt_telephone_billing;

        //protected RequiredFieldValidator Required_Phone;

        //protected HtmlGenericControl Span1;

        //protected Label lblFax;

        //protected TextBox txt_fax_billing;

        //protected Button btnBack_toList;

        //protected Button btn_SaveAddress;

        //protected HiddenField hdnLabelID;

        //protected UpdatePanel UpdatePanel1;

        private BaseClass objBc = new BaseClass();

        private commonclass common = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long StoreUserID;

        public int CompanyID;

        public static long AccountID;

        private DateTime EventStartDate;

        private DateTime EventEndDate;

        public string DateFormat = string.Empty;

        private string strSitePath = string.Empty;

        private bool isarchive;

        private long deliveryAddressID;

        private DateTime DeliveryDate;

        private Label lblShippingAddress = new Label();

        public DateTime CreatedDate;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static Campaign()
        {
        }

        public Campaign()
        {
        }

        public void BindAddressGrid()
        {
            DataTable dataTable = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBc.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBc.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBc.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBc.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBc.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBc.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBc.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBc.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
            this.rdgrd_ship_choose.DataBind();
            this.grd_Search_ship.Text = string.Empty;
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
                        LoginBasePage.settings_managecampaign_delete((long)Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            this.radgrdCampaign.Rebind();
            this.NoRecords();
            string languageConversion = this.objLanguage.GetLanguageConversion("Campaign_deleted_successfully");
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:Message('", languageConversion, "');"), true);
        }

        protected void btnSave_NewAddress_Click(object source, EventArgs e)
        {
            commonclass _commonclass = this.common;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, Convert.ToInt32(this.Session["StoreUserID"]), true));
            string empty = string.Empty;
            this.deliveryAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(),"" ,this.txt_fax_billing.Text.Trim(), this.ddlCountry.SelectedItem.Text.Trim(), 0, 0, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);
            this.rdgrd_ship_choose.Rebind();
            empty = this.GetNewDeliveryAddress();
            System.Web.UI.Page page = this.Page;
            Type type = base.GetType();
            object[] objArray = new object[] { "javascript:HideDialog4();Assign_Address_To_Label('", empty, "', ", this.deliveryAddressID, ");" };
            System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "", string.Concat(objArray), true);
        }

        public string GetNewDeliveryAddress()
        {
            string empty = string.Empty;
            if (this.txtaddressLabelBilling.Text != "")
            {
                empty = string.Concat(empty, this.txtaddressLabelBilling.Text, ",&nbsp;");
            }
            if (this.txt_address_billing1.Text != "")
            {
                empty = string.Concat(empty, this.txt_address_billing1.Text, ",&nbsp;");
            }
            if (this.txt_address_billing2.Text != "")
            {
                empty = string.Concat(empty, this.txt_address_billing2.Text, ",&nbsp;");
            }
            if (this.txt_address_billing3.Text != "")
            {
                empty = string.Concat(empty, this.txt_address_billing3.Text, ",&nbsp;");
            }
            if (this.txt_address_billing4.Text != "")
            {
                empty = string.Concat(empty, this.txt_address_billing4.Text, ",&nbsp;");
            }
            if (this.txt_address_billing5.Text != "")
            {
                empty = string.Concat(empty, this.txt_address_billing5.Text, ",&nbsp;");
            }
            if (this.ddlCountry.SelectedItem.Text.Trim() != "")
            {
                empty = string.Concat(empty, this.ddlCountry.SelectedItem.Text.Trim(), ",&nbsp;");
            }
            if (this.txt_telephone_billing.Text != "")
            {
                empty = string.Concat(empty, this.txt_telephone_billing.Text, ",&nbsp;");
            }
            if (this.txt_fax_billing.Text != "")
            {
                empty = string.Concat(empty, this.txt_fax_billing.Text);
            }
            string str = this.objBc.SpecialDecode(empty);
            empty = str;
            return str;
        }

        protected void grd_Search_ship_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(this.Session["StoreUserID"].ToString()), "bill", (long)0, this.grd_Search_ship.Text);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBc.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBc.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBc.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBc.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBc.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBc.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBc.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBc.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
            this.rdgrd_ship_choose.DataBind();
        }

        protected void lnkAddress_Select_Click(object sender, CommandEventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            this.deliveryAddressID = Convert.ToInt64(linkButton.CommandArgument.ToString());
            this.grd_Search_ship.Text = string.Empty;
            this.rdgrd_ship_choose.Rebind();
            System.Web.UI.Page page = this.Page;
            Type type = base.GetType();
            object[] text = new object[] { "javascript:HideDialog4();Assign_Address_To_Label('", linkButton.Text, "', ", this.deliveryAddressID, ");" };
            System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "", string.Concat(text), true);
        }

        protected void lnkDelete_onclick(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            long num = Convert.ToInt64(imageButton.CommandArgument.ToString());
            LoginBasePage.settings_managecampaign_delete(num);
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            this.NoRecords();
            string languageConversion = this.objLanguage.GetLanguageConversion("Campaign_deleted_successfully");
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:Message('", languageConversion, "');"), true);
        }

        public void NoRecords()
        {
            if (((DataView)this.SessionDataSource1.Select()).Table.Rows.Count == 0)
            {
                this.radgrdCampaign.MasterTableView.GetColumn("Checkbox").Visible = false;
                this.radgrdCampaign.MasterTableView.PagerStyle.Visible = false;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.radgrdCampaign.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
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
            this.lblAddressBook1.Text = this.objLanguage.GetLanguageConversion("Address_Book");
            this.spn_ListAllAdddress1.InnerText = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            this.lnkbtnAddNewAddress.Text = this.objLanguage.GetLanguageConversion("Add_New_Address");
            this.lblNewAddress.Text = this.objLanguage.GetLanguageConversion("New_Address");
            this.lblAddress_Label.Text = "Address Label";
            this.lblCountry.Text = "Country";
            this.lblTelephone.Text = "Telephone";
            this.lblFax.Text = "Fax";
            this.lblAddressBill1.Text = this.common.GetAddressLabelByKey("Address1");
            this.lblAddressBill2.Text = this.common.GetAddressLabelByKey("Address2");
            this.lblAddressBill3.Text = this.common.GetAddressLabelByKey("Address3");
            this.lblAddressBill4.Text = this.common.GetAddressLabelByKey("Address4");
            this.lblAddressBill5.Text = this.common.GetAddressLabelByKey("Address5");
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                Campaign.AccountID = (long)Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitePath = ConnectionClass.SitePath;
            }
            if (this.Session["StoreUserID"] == null || this.CompanyID == 0 && Campaign.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "login.aspx?from=campaign"));
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, Campaign.AccountID).Rows)
            {
                this.DateFormat = row["DateFormat"].ToString();
            }
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            this.NoRecords();
            base.Title = commonclass.pageTitle("Campaign", Convert.ToInt32(this.CompanyID), Convert.ToInt32(Campaign.AccountID));
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "Campaign.aspx'>", this.objLanguage.GetLanguageConversion("Campaign"), "</a>" };
            label.Text = string.Concat(sitePath);
            if (!base.IsPostBack)
            {
                OrderBasePage.company_country_select(this.ddlCountry);
                foreach (DataRow dataRow in OrderBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                {
                    this.hdnCountryID.Value = dataRow["CountryID"].ToString();
                }
            }
            if (this.common.GetMandatoryByKey("address1").ToLower() != "true")
            {
                this.lblBillAdd1_UC.Visible = false;
                this.Required_Address1.Display = ValidatorDisplay.None;
                this.Required_Address1.Enabled = false;
            }
            else
            {
                this.lblBillAdd1_UC.Visible = true;
                this.Required_Address1.Display = ValidatorDisplay.Dynamic;
                this.Required_Address1.Enabled = true;
            }
            if (this.common.GetMandatoryByKey("address2").ToLower() != "true")
            {
                this.lblBillAdd2_UC.Visible = false;
                this.Required_Address2.Display = ValidatorDisplay.None;
                this.Required_Address2.Enabled = false;
            }
            else
            {
                this.lblBillAdd2_UC.Visible = true;
                this.Required_Address2.Display = ValidatorDisplay.Dynamic;
                this.Required_Address2.Enabled = true;
            }
            if (this.common.GetMandatoryByKey("address3").ToLower() != "true")
            {
                this.lblBillAdd3_UC.Visible = false;
                this.Required_Address3.Display = ValidatorDisplay.None;
                this.Required_Address3.Enabled = false;
            }
            else
            {
                this.lblBillAdd3_UC.Visible = true;
                this.Required_Address3.Display = ValidatorDisplay.Dynamic;
                this.Required_Address3.Enabled = true;
            }
            if (this.common.GetMandatoryByKey("address4").ToLower() != "true")
            {
                this.lblBillAdd4_UC.Visible = false;
                this.Required_Address4.Display = ValidatorDisplay.None;
                this.Required_Address4.Enabled = false;
            }
            else
            {
                this.lblBillAdd4_UC.Visible = true;
                this.Required_Address4.Display = ValidatorDisplay.Dynamic;
                this.Required_Address4.Enabled = true;
            }
            if (this.common.GetMandatoryByKey("address5").ToLower() != "true")
            {
                this.lblBillAdd5_UC.Visible = false;
                this.Required_Address5.Display = ValidatorDisplay.None;
                this.Required_Address5.Enabled = false;
            }
            else
            {
                this.lblBillAdd5_UC.Visible = true;
                this.Required_Address5.Display = ValidatorDisplay.Dynamic;
                this.Required_Address5.Enabled = true;
            }
            if (ConnectionClass.ServerName != null && ConnectionClass.ServerName.ToLower() == "smp" && Campaign.AccountID == (long)276)
            {
                this.lblBillPhone_UC.Visible = true;
                this.Required_Phone.Display = ValidatorDisplay.Dynamic;
                this.Required_Phone.Enabled = true;
                return;
            }
            this.lblBillPhone_UC.Visible = false;
            this.Required_Phone.Display = ValidatorDisplay.None;
            this.Required_Phone.Enabled = false;
        }

        protected void radgrdCampaign_InsertCommand(object source, GridCommandEventArgs e)
        {
            string empty = string.Empty;
            TextBox textBox = (TextBox)e.Item.FindControl("txtOrdNo");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtEventName");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtVenue");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txteventcode");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txtEventStartdate");
            TextBox textBox5 = (TextBox)e.Item.FindControl("txtEventEnddate");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkArchive");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_DeliveryAddressID");
            TextBox textBox6 = (TextBox)e.Item.FindControl("txtDeliveryDate");
            if (hiddenField.Value != "")
            {
                this.deliveryAddressID = Convert.ToInt64(hiddenField.Value);
            }
            if (checkBox.Checked)
            {
                this.isarchive = true;
            }
            this.DeliveryDate = Convert.ToDateTime(this.common.date_Check_new(this.DateFormat, textBox6.Text));
            this.EventStartDate = Convert.ToDateTime(this.common.date_Check_new(this.DateFormat, textBox4.Text));
            this.EventEndDate = Convert.ToDateTime(this.common.date_Check_new(this.DateFormat, textBox5.Text));
            LoginBasePage.ManageCampign_Insert_Update((long)this.CompanyID, this.StoreUserID, Campaign.AccountID, (long)0, textBox1.Text, textBox2.Text, textBox3.Text, this.EventStartDate, this.EventEndDate, "U", this.isarchive, textBox.Text, this.deliveryAddressID, this.DeliveryDate);
            empty = this.objLanguage.GetLanguageConversion("Campaign_saved_successfully");
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:Message('", empty, "');"), true);
        }

        protected void radgrdCampaign_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.radgrdCampaign.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.radgrdCampaign.MasterTableView.ClearEditItems();
            }
        }

        protected void radgrdCampaign_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void radgrdCampaign_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem item = (GridFilteringItem)e.Item;
                item["EventStartdate"].HorizontalAlign = HorizontalAlign.Center;
                item["EventEnddate"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                this.BindAddressGrid();
                Label label = (Label)e.Item.FindControl("lblDeliveryaddress");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnMangeID");
                TextBox textBox = (TextBox)e.Item.FindControl("txtEventStartdate");
                TextBox textBox1 = (TextBox)e.Item.FindControl("txtEventEnddate");
                TextBox textBox2 = (TextBox)e.Item.FindControl("txtEventName");
                TextBox textBox3 = (TextBox)e.Item.FindControl("txtDeliveryDate");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("chkArchive");
                if (checkBox.Text.ToLower() == "true")
                {
                    checkBox.Checked = true;
                }
                textBox2.Focus();
                checkBox.Text = "";
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                empty = this.common.Eprint_return_Date_Before_View(textBox.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
                textBox.Text = empty;
                textBox.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                str = this.common.Eprint_return_Date_Before_View(textBox1.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
                textBox1.Text = str;
                textBox1.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                empty1 = this.common.Eprint_return_Date_Before_View(textBox3.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
                textBox3.Text = empty1;
                textBox3.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (textBox3.Text.Contains("1/1/1900"))
                {
                    textBox3.Text = "";
                }
                if (textBox.Text.Contains("1/1/1900"))
                {
                    textBox.Text = "";
                }
                if (textBox1.Text.Contains("1/1/1900"))
                {
                    textBox1.Text = "";
                }
            }
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    this.BindAddressGrid();
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnMangeID");
                    Image image = (Image)e.Item.FindControl("img_InUse");
                    Image image1 = (Image)e.Item.FindControl("img_Archive");
                    Label label1 = (Label)e.Item.FindControl("lblenddate");
                    Label label2 = (Label)e.Item.FindControl("lblstartdate");
                    Label label3 = (Label)e.Item.FindControl("DeliveryDate_view");
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonErase");
                    HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("chkId");
                    DataTable dataTable = LoginBasePage.SelectInUse_IsArchiveCampaign(Convert.ToInt64(hiddenField1.Value));
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    int num = 0;
                    string str2 = string.Empty;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        str2 = row["isArchive"].ToString();
                        num = Convert.ToInt32(row["InUse"]);
                    }
                    if (num == -1)
                    {
                        image.ImageUrl = "images/StoreImages/check.gif";
                        imageButton.Visible = true;
                        htmlInputCheckBox.Disabled = false;
                    }
                    else if (num != 1)
                    {
                        image.ImageUrl = "images/StoreImages/1t.gif";
                    }
                    else
                    {
                        image.ImageUrl = "images/StoreImages/1t.gif";
                        imageButton.Visible = true;
                        htmlInputCheckBox.Disabled = false;
                    }
                    if (str2.ToLower() != "true")
                    {
                        image1.ImageUrl = "images/StoreImages/1t.gif";
                    }
                    else
                    {
                        image1.ImageUrl = "images/StoreImages/check.gif";
                    }
                    label2.Text = this.common.Eprint_return_Date_Before_View(label2.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
                    label1.Text = this.common.Eprint_return_Date_Before_View(label1.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
                    label3.Text = this.common.Eprint_return_Date_Before_View(label3.Text, Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.StoreUserID), false);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        protected void radgrdCampaign_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            TextBox textBox = (TextBox)e.Item.FindControl("txtOrdNo");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txtEventName");
            TextBox textBox2 = (TextBox)e.Item.FindControl("txtVenue");
            TextBox textBox3 = (TextBox)e.Item.FindControl("txteventcode");
            TextBox textBox4 = (TextBox)e.Item.FindControl("txtEventStartdate");
            TextBox textBox5 = (TextBox)e.Item.FindControl("txtEventEnddate");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkArchive");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_DeliveryAddressID");
            TextBox textBox6 = (TextBox)e.Item.FindControl("txtDeliveryDate");
            if (hiddenField.Value != "")
            {
                this.deliveryAddressID = Convert.ToInt64(hiddenField.Value);
            }
            if (checkBox.Checked)
            {
                this.isarchive = true;
            }
            this.DeliveryDate = Convert.ToDateTime(this.common.date_Check_new(this.DateFormat, textBox6.Text));
            this.EventStartDate = Convert.ToDateTime(this.common.date_Check_new(this.DateFormat, textBox4.Text));
            this.EventEndDate = Convert.ToDateTime(this.common.date_Check_new(this.DateFormat, textBox5.Text));
            HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_ManID");
            LoginBasePage.ManageCampign_Insert_Update((long)this.CompanyID, this.StoreUserID, Campaign.AccountID, Convert.ToInt64(hiddenField1.Value), textBox1.Text, textBox2.Text, textBox3.Text, this.EventStartDate, this.EventEndDate, "A", this.isarchive, textBox.Text, this.deliveryAddressID, this.DeliveryDate);
            string languageConversion = this.objLanguage.GetLanguageConversion("Campaign_updated_successfully");
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:Message('", languageConversion, "');"), true);
            DataTable table = ((DataView)this.SessionDataSource1.Select()).Table;
        }

        protected void rdgrd_ship_choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && this.Session["ShippingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() != this.Session["ShippingAddressID"].ToString())
                {
                    e.Item.Selected = false;
                }
                else
                {
                    e.Item.Selected = true;
                }
            }
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
        }

        protected void rdgrd_ship_choose_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["Address"] = this.objBc.SpecialDecode(row["Address"].ToString());
                row["AddressNew"] = this.objBc.SpecialDecode(row["AddressNew"].ToString());
                row["AddressLine1"] = this.objBc.SpecialDecode(row["AddressLine1"].ToString());
                row["AddressLine2"] = this.objBc.SpecialDecode(row["AddressLine2"].ToString());
                row["Address1"] = this.objBc.SpecialDecode(row["Address1"].ToString());
                row["Address2"] = this.objBc.SpecialDecode(row["Address2"].ToString());
                row["FirstName"] = this.objBc.SpecialDecode(row["FirstName"].ToString());
                row["LastNAme"] = this.objBc.SpecialDecode(row["LastNAme"].ToString());
            }
            this.rdgrd_ship_choose.DataSource = dataTable;
        }
    }
}