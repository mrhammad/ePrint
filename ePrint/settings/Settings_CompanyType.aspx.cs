using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class Settings_CompanyType : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RAM;

        //protected RadAjaxLoadingPanel RALP;

        //protected Label lblHeader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton dltbtn;

        //protected RadGrid RadGridCompanyType;

        //protected UpdatePanel UpdatePanel1;

        //protected RadCodeBlock RadCodeBlock1;

        public int CompanyID;

        public int UserID;

        public int CompanyTypeid;

        private Global gloobj = new Global();

        public languageClass objlang = new languageClass();

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

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

        public Settings_CompanyType()
        {
        }

        protected void btnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.settings_CompanyType_deleterow(Convert.ToInt32(e.CommandArgument), this.CompanyID);
            this.GridBind(this.CompanyID);
            base.Message_Display(this.objlang.GetLanguageConversion("Company_Type_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void dltbtn_click(object sender, EventArgs e)
        {
            foreach (GridDataItem item in this.RadGridCompanyType.MasterTableView.Items)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)item.FindControl("chkCompanytypeId1");
                this.CompanyTypeid = Convert.ToInt32(htmlInputCheckBox.Value.ToString());
                if (!htmlInputCheckBox.Checked)
                {
                    continue;
                }
                SqlCommand sqlCommand = new SqlCommand("PC_settings_CompanyType_deleterow", (new commonClass()).openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@id", this.CompanyTypeid);
                sqlCommand.Parameters.Add("@CompanyID", this.CompanyID);
                sqlCommand.ExecuteNonQuery();
            }
            this.GridBind(this.CompanyID);
            this.RadGridCompanyType.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Company_Type_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        public void GridBind(int CompanyID)
        {
            DataTable dataTable = SettingsBasePage.settings_CompanyType_select(CompanyID);
            this.RadGridCompanyType.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGridCompanyType.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objlang.convert(global.pageTitle("Company Type", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Company_Type")));
            this.header_mis.SettingName = this.objlang.GetLanguageConversion("Company_Type");
            DataTable dataTable = SettingsBasePage.settings_CompanyType_select(this.CompanyID);
            this.RadGridCompanyType.DataSource = dataTable;
            this.dltbtn.Attributes.Add("onclick", "javascript:return CallDelete();");
            this.RadGridCompanyType.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Company_Type");
            this.RadGridCompanyType.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Used_In");
            this.RadGridCompanyType.Columns[4].HeaderText = this.objlang.GetLanguageConversion("Action");
            this.dltbtn.Text = this.objlang.GetLanguageConversion("Detele_Selected");
            this.RadGridCompanyType.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_To_Display");
        }

        protected void Rad_CompanyType_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            TextBox textBox = (TextBox)e.Item.FindControl("txtcompanyType");
            string selectedValue = ((DropDownList)e.Item.FindControl("ddl_UsedIn")).SelectedValue;
            SettingsBasePage.settings_copmanyType_insert(0, this.CompanyID, base.SpecialEncode(textBox.Text), this.UserID, selectedValue, DateTime.Now);
            this.GridBind(this.CompanyID);
            base.Message_Display(this.objlang.GetLanguageConversion("Company_Type_Added_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Rad_CompanyType_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txtcompanyType");
            string selectedValue = ((DropDownList)e.Item.FindControl("ddl_UsedIn")).SelectedValue;
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnColorid1");
            SettingsBasePage.settings_copmanyType_insert(Convert.ToInt32(hiddenField.Value), this.CompanyID, base.SpecialEncode(textBox.Text), this.UserID, selectedValue, DateTime.Now);
            item.Edit = false;
            this.GridBind(this.CompanyID);
            base.Message_Display(this.objlang.GetLanguageConversion("Company_Type_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        protected void RadGridCompanyType_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("lblcompanyType");
                label.Text = base.SpecialDecode(label.Text);
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                RadButton languageConversion = item.FindControl("btnSave") as RadButton;
                languageConversion.Text = this.objlang.GetLanguageConversion("Save");
                RadButton radButton = item.FindControl("btnCancel") as RadButton;
                radButton.Text = this.objlang.GetLanguageConversion("Cancel");
                RequiredFieldValidator requiredFieldValidator = item.FindControl("RequiredFieldValidator1") as RequiredFieldValidator;
                requiredFieldValidator.ErrorMessage = this.objlang.GetLanguageConversion("Please_enter_company_type");
                TextBox textBox = item.FindControl("txtcompanyType") as TextBox;
                textBox.Text = base.SpecialDecode(textBox.Text);
                textBox.Focus();
                DropDownList str = item.FindControl("ddl_UsedIn") as DropDownList;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnCompanyTypeId");
                if (hiddenField.Value != "")
                {
                    foreach (DataRow row in SettingsBasePage.settings_CompanyType_ddlselect(Convert.ToInt32(hiddenField.Value)).Rows)
                    {
                        str.SelectedValue = row["UsedFor"].ToString();
                    }
                }
            }
        }

        protected void RadGridCompanyType_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.RadGridCompanyType.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.RadGridCompanyType.MasterTableView.ClearEditItems();
            }
        }

        protected void RadGridCompanyType_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.RadGridCompanyType.CurrentPageIndex = e.NewPageIndex;
            this.RadGridCompanyType.Rebind();
        }

        protected void RadGridCompanyType_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.RadGridCompanyType.Rebind();
        }
    }
}