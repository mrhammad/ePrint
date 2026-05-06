using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
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
    public partial class Cutomer_PaymentTerms : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RAM;

        //protected RadAjaxLoadingPanel RALP;

        //protected Label lblHeader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton btn_Deleted;

        //protected RadGrid Rad_PaymentTerms;

        //protected UpdatePanel UpdatePnl;

        //protected RadCodeBlock RadCodeBlock1;

        private Global gloobj = new Global();

        public long CompanyID;

        public int UserID;

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

        public languageClass objLanguage = new languageClass();

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

        public Cutomer_PaymentTerms()
        {
        }

        protected void btn_Deleted_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Rad_PaymentTerms.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.Rad_PaymentTerms.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.PaymentTerm_Details_Delete(Convert.ToInt32(htmlInputCheckBox.Value));
                }
            }
            this.Rad_PaymentTerms_Bind(this.CompanyID);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Payment_Term_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.PaymentTerm_Details_Delete(Convert.ToInt32(e.CommandArgument));
            this.Rad_PaymentTerms_Bind(this.CompanyID);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Payment_Terms_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Payment_Terms"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Customer_Payment_Terms")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Customer_Payment_Terms");
            DataTable dataTable = SettingsBasePage.PaymentTerm_Details_Select(this.CompanyID);
            this.Rad_PaymentTerms.DataSource = dataTable;
            this.btn_Deleted.Attributes.Add("onclick", "javascript:return CallDelete();");
            this.Rad_PaymentTerms.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Name");
            this.Rad_PaymentTerms.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Days");
            this.Rad_PaymentTerms.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.Rad_PaymentTerms.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.Rad_PaymentTerms.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_To_display");
            this.btn_Deleted.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
        }

        public void Rad_PaymentTerms_Bind(long CompanyID)
        {
            DataTable dataTable = SettingsBasePage.PaymentTerm_Details_Select(CompanyID);
            this.Rad_PaymentTerms.DataSource = dataTable;
            this.Rad_PaymentTerms.DataBind();
        }

        protected void Rad_PaymentTerms_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                RadButton languageConversion = item.FindControl("btn_Save") as RadButton;
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Save");
                RadButton radButton = item.FindControl("btn_Cancel") as RadButton;
                radButton.Text = this.objLanguage.GetLanguageConversion("Cancel");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
                if (((HiddenField)e.Item.FindControl("hdnDefault")).Value.ToLower() != "true")
                {
                    checkBox.Checked = false;
                }
                else
                {
                    checkBox.Checked = true;
                }
            }
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Default");
                Image image = (Image)e.Item.FindControl("img_Default");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgbtnDelete");
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("Id");
                Label label = (Label)e.Item.FindControl("lbl_Name");
                label.Text = base.SpecialDecode(label.Text);
                if (hiddenField.Value == "True")
                {
                    image.ImageUrl = string.Concat(this.strImagepath, "ICON_checkboxNew.gif");
                    htmlControl.Disabled = true;
                    imageButton.Visible = false;
                    return;
                }
                image.ImageUrl = string.Concat(this.strImagepath, "ICON_checkbox_u.gif");
            }
        }

        protected void Rad_PaymentTerms_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txt_PaymentName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txt_PaymentDays");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            SettingsBasePage.PaymentTerms_Detail_Insert(this.CompanyID, base.SpecialEncode(textBox.Text), textBox1.Text, checkBox.Checked, 0);
            this.Rad_PaymentTerms_Bind(this.CompanyID);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Payment_Term_Added_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Rad_PaymentTerms_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.Rad_PaymentTerms.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.Rad_PaymentTerms.MasterTableView.ClearEditItems();
            }
        }

        protected void Rad_PaymentTerms_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txt_PaymentName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txt_PaymentDays");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_PaymentID");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            SettingsBasePage.PaymentTerms_Detail_Insert(this.CompanyID, textBox.Text, base.SpecialEncode(textBox1.Text), checkBox.Checked, Convert.ToInt32(hiddenField.Value));
            item.Edit = false;
            this.Rad_PaymentTerms_Bind(this.CompanyID);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Payment_Term_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        protected void setDefaultPaymentTerm_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.SetDefault_PaymentTerm(this.CompanyID, Convert.ToInt16(e.CommandArgument));
            base.Message_Display(this.objLanguage.GetLanguageConversion("Default_Payment_Term_set_successfully"), "msg-success", this.plhMessage);
            this.Rad_PaymentTerms_Bind(this.CompanyID);
        }
    }
}