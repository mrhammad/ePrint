using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
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
    public partial class Settings_ReferedBy : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RAM;

        //protected RadAjaxLoadingPanel RALP;

        //protected Label lblheader;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton btnDeleteReferedby;

        //protected RadGrid grdCommissiontype;

        //protected HtmlGenericControl div_Main;

        //protected UpdatePanel pnlgridAccountingCodes;

        //protected ObjectDataSource AccountCodeDataSource;

        //protected HiddenField hdn_CommissionType;

        private Global gloobj = new Global();

        private commonClass objJava = new commonClass();

        public languageClass objlang = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int CompanyID;

        public int UserID;

        public int CompanyTypeid;

        public string CommissionType = string.Empty;

        public int return1;

        public string lbl_CommissionType;

        public languageClass objlanguage = new languageClass();

        private int RoundOff = 2;

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

        public Settings_ReferedBy()
        {
        }

        protected void btnDeleteReferencedBy_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < this.grdCommissiontype.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.grdCommissiontype.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    SettingsBasePage.Settings_ReferedBy_Isdelete_Update(Convert.ToInt32(htmlInputCheckBox.Value.ToString()), this.CompanyID);
                    flag = true;
                }
            }
            if (flag)
            {
                this.grdCommissiontype.Rebind();
                base.Message_Display(this.objLanguage.GetLanguageConversion("Referrenced_Name_Deleted_Successfully"), "msg-success", this.plhMessage);
            }
        }

        public void FuncCommissionType(object sender, EventArgs e)
        {
            if (this.hdn_CommissionType.Value == "p")
            {
                this.lbl_CommissionType = "%";
                return;
            }
            this.lbl_CommissionType = "";
        }

        protected void grdCommissiontype_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.grdCommissiontype.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.grdCommissiontype.MasterTableView.ClearEditItems();
            }
        }

        protected void grdCommissiontype_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = e.Item as GridEditableItem;
                TextBox textBox = item.FindControl("txt_ReferedByName") as TextBox;
                textBox.Text = base.SpecialDecode(textBox.Text);
                textBox.Focus();
                TextBox textBox1 = item.FindControl("txt_CommValue") as TextBox;
                textBox1.Attributes.Add("onblur", string.Concat("javascript:roundUp(this.id,this.value,", this.RoundOff, ");"));
                RadButton languageConversion = item.FindControl("btnSave") as RadButton;
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Save");
                RadButton radButton = item.FindControl("btnCancel") as RadButton;
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
            if (e.Item is GridDataItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Label label = gridDataItem.FindControl("lblDescription") as Label;
                Label label1 = (Label)e.Item.FindControl("lblAccountCode");
                label1.Text = base.SpecialDecode(label1.Text);
                if (label.Text != "")
                {
                    label.Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", false, false, true);
                }
            }
            try
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_InUse");
                Image image = (Image)e.Item.FindControl("img_InUse");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgbtnDelete");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                if (hiddenField.Value == "0")
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    imageButton.Visible = false;
                    htmlInputCheckBox.Disabled = true;
                }
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_Default");
                Image image1 = (Image)e.Item.FindControl("img_Default");
                if (hiddenField1.Value != "True")
                {
                    image1.ImageUrl = string.Concat(this.strImagepath, "ICON_checkbox_u.gif");
                }
                else
                {
                    image1.ImageUrl = string.Concat(this.strImagepath, "ICON_checkboxNew.gif");
                    imageButton.Visible = false;
                    htmlInputCheckBox.Disabled = true;
                }
            }
            catch
            {
            }
        }

        protected void grdCommissiontype_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)e.Item.FindControl("txt_ReferedByName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txt_CommValue");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_ReferencedID");
            Label label = (Label)e.Item.FindControl("lblDuplicacyCheck");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            if (textBox1.Text == null)
            {
                textBox1.Text = "";
            }
            if (hiddenField.Value != "")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("ReferredBy_and_Commission_Value_Already_Exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("ReferredBy_And_Commission_Value_Inserted_Successfully"), "msg-success", this.plhMessage);
            }
            SettingsBasePage.Setting_ReferencedBy_InsertUpdate(0, Convert.ToInt32(this.CompanyID.ToString()), base.SpecialEncode(textBox.Text), textBox1.Text, Convert.ToBoolean(0), checkBox.Checked);
            this.grdCommissiontype.Rebind();
            item.Display = false;
        }

        public void grdCommissiontype_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            int pageSize = this.grdCommissiontype.PageSize;
            GridItem item = e.Item;
            TextBox textBox = (TextBox)e.Item.FindControl("txt_ReferedByName");
            TextBox textBox1 = (TextBox)e.Item.FindControl("txt_CommValue");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_ReferencedID");
            Label label = (Label)e.Item.FindControl("lblDuplicacyCheck");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("chkDefault");
            if (textBox1.Text == null)
            {
                textBox1.Text = " ";
            }
            if (hiddenField.Value == "")
            {
                base.Message_Display(this.objlang.GetLanguageConversion("ReferredBy_and_Commission_Value_Already_Exists"), "msg-fail", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("ReferredBy_And_Commission_Value_Updated_Successfully"), "msg-success", this.plhMessage);
            }
            SettingsBasePage.Setting_ReferencedBy_InsertUpdate(Convert.ToInt32(hiddenField.Value), Convert.ToInt32(this.CompanyID.ToString()), base.SpecialEncode(textBox.Text), textBox1.Text, Convert.ToBoolean(0), checkBox.Checked);
            this.grdCommissiontype.Rebind();
        }

        public void GridBind()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_ClientReferencedByName_Select", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@Name", "");
            sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    this.CommissionType = Convert.ToString(row["CommissionType"]);
                    this.hdn_CommissionType.Value = this.CommissionType;
                }
            }
        }

        public void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            int num = Convert.ToInt32(e.CommandArgument);
            SettingsBasePage.Settings_ReferedBy_Isdelete_Update(Convert.ToInt32(num), this.CompanyID);
            this.grdCommissiontype.Rebind();
            base.Message_Display(this.objlang.GetLanguageConversion("Referrenced_Name_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            if (!base.IsPostBack)
            {
                this.GridBind();
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Referred By", int.Parse(this.Session["CompanyID"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Referred_By")));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Referred_By");
            this.grdCommissiontype.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
            this.grdCommissiontype.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Commission");
            this.grdCommissiontype.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Default");
            this.grdCommissiontype.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("InUse");
            this.grdCommissiontype.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Delete");
            this.btnDeleteReferedby.Text = this.objlanguage.GetLanguageConversion("Detele_Selected");
            this.grdCommissiontype.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_Display");
        }

        protected void setDefaultRefferedBy_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.SetDefault_RefferceBy((long)this.CompanyID, Convert.ToInt16(e.CommandArgument));
            base.Message_Display(" Default contact set successfully", "msg-success", this.plhMessage);
            this.grdCommissiontype.Rebind();
        }
    }
}