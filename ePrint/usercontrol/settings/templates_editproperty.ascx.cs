using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.usercontrol.settings
{
    public partial class templates_editproperty : System.Web.UI.UserControl
    {

        public int totalrec;

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        public string strSitepath = global.sitePath();

        private BaseClass objBase = new BaseClass();

        private Template objTemplates = new Template();

        public long id;

        public int companyId;

        public int TemplateID;

        public string pop = string.Empty;

        public static languageClass objLanguage;

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

        static templates_editproperty()
        {
            templates_editproperty.objLanguage = new languageClass();
        }

        public templates_editproperty()
        {
        }

        public void BindAssociatelabel()
        {
            if (base.Session["Associatelabel"] == null)
            {
                DataTable dataTable = SettingsBasePage.settings_templates_associatelabel_select(Convert.ToInt32(this.id));
                base.Session["Associatelabel"] = dataTable;
            }
        }

        public void BindGroup()
        {
            if (base.Session["GroupDT"] == null)
            {
                DataTable dataTable = SettingsBasePage.settings_default_template_group_select(Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt64(this.id));
                base.Session["GroupDT"] = dataTable;
            }
        }

        public void BindHGroup()
        {
            if (base.Session["HGroupDT"] == null)
            {
                DataSet dataSet = this.objTemplates.Template_HGroup_View(Convert.ToInt32(this.id));
                base.Session["HGroupDT"] = dataSet.Tables[0];
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.sitepath, "Settings/templates.aspx?page=", base.Request.Params["page"].ToString()));
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (this.GridTemplateProperties.Items.Count > 0)
            {
                for (int i = 0; i < this.GridTemplateProperties.Items.Count; i++)
                {
                    HiddenField hiddenField = (HiddenField)this.GridTemplateProperties.Items[i].FindControl("hdn_TemplatePropertiesID");
                    DropDownList dropDownList = (DropDownList)this.GridTemplateProperties.Items[i].FindControl("ddl_align");
                    TextBox textBox = (TextBox)this.GridTemplateProperties.Items[i].FindControl("txtTop");
                    TextBox textBox1 = (TextBox)this.GridTemplateProperties.Items[i].FindControl("txtLeft");
                    TextBox textBox2 = (TextBox)this.GridTemplateProperties.Items[i].FindControl("txtWidth");
                    TextBox textBox3 = (TextBox)this.GridTemplateProperties.Items[i].FindControl("txtHeight");
                    DropDownList dropDownList1 = (DropDownList)this.GridTemplateProperties.Items[i].FindControl("ddl_font");
                    TextBox textBox4 = (TextBox)this.GridTemplateProperties.Items[i].FindControl("txtFontSize");
                    textBox4.Text = string.Concat(textBox4.Text, "pt");
                    DropDownList dropDownList2 = (DropDownList)this.GridTemplateProperties.Items[i].FindControl("ddlGroup");
                    DropDownList dropDownList3 = (DropDownList)this.GridTemplateProperties.Items[i].FindControl("ddlHGroup");
                    DropDownList dropDownList4 = (DropDownList)this.GridTemplateProperties.Items[i].FindControl("ddlassociatelbl");
                    HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)this.GridTemplateProperties.Items[i].FindControl("chkIsHgroupMain");
                    HtmlInputCheckBox htmlInputCheckBox1 = (HtmlInputCheckBox)this.GridTemplateProperties.Items[i].FindControl("chkLock");
                    SettingsBasePage.settings_templates_properties_update(this.companyId, Convert.ToInt64(hiddenField.Value), dropDownList.SelectedItem.Value.Trim(), Convert.ToDecimal(textBox.Text), Convert.ToDecimal(textBox1.Text), Convert.ToDecimal(textBox2.Text), Convert.ToDecimal(textBox3.Text), dropDownList1.SelectedItem.Value, textBox4.Text, dropDownList2.SelectedItem.Value, dropDownList3.SelectedItem.Value, dropDownList4.SelectedItem.Value, htmlInputCheckBox.Checked, htmlInputCheckBox1.Checked);
                }
            }
            SettingsBasePage.Set_Horizontal_Group_TOP(this.companyId, this.id);
            this.GridTemplateProperties.Visible = false;
            this.div_rightbtns.Attributes.Add("style", "display:none");
            this.div_topbtns.Attributes.Add("style", "display:none");
            if (this.pop != "")
            {
                if (this.hdn_PropertySaveType.Value.ToLower() == "save")
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "window.opener.location.href = window.opener.location.href;self.close();", true);
                }
                return;
            }
            if (this.hdn_PropertySaveType.Value.ToLower() != "stay")
            {
                base.Response.Redirect(string.Concat(this.sitepath, "Settings/templates.aspx?page=", base.Request.Params["page"].ToString()));
                return;
            }
            HttpResponse response = base.Response;
            object[] str = new object[] { "templates_editproperty.aspx?id=", this.id, "&page=", base.Request.Params["page"].ToString(), "&stay=yes" };
            response.Redirect(string.Concat(str));
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridTemplateProperties.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridTemplateProperties.MasterTableView.FilterExpression = string.Empty;
            this.GridTemplateProperties.MasterTableView.Rebind();
        }

        protected void GridTemplateProperties_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Align");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_font");
                DropDownList dropDownList = (DropDownList)e.Item.FindControl("ddl_align");
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddl_font");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnGroup");
                DropDownList languageConversion = (DropDownList)e.Item.FindControl("ddlGroup");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hdnHGroup");
                DropDownList languageConversion1 = (DropDownList)e.Item.FindControl("ddlHGroup");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hdn_objType");
                Label value = (Label)e.Item.FindControl("lbl_title");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hdn_objValue");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hdn_objTitle");
                DropDownList languageConversion2 = (DropDownList)e.Item.FindControl("ddlassociatelbl");
                HiddenField hiddenField7 = (HiddenField)e.Item.FindControl("hdnAssociatedLabel");
                HtmlInputCheckBox flag = (HtmlInputCheckBox)e.Item.FindControl("chkIsHgroupMain");
                HiddenField hiddenField8 = (HiddenField)e.Item.FindControl("hdnIsHGroupMain");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("chkLock");
                this.objTemplates.Bind_TemplateFonts(dropDownList1, this.companyId, "--- Select ---");
                DataTable item = (DataTable)base.Session["GroupDT"];
                languageConversion.DataTextField = "GroupName";
                languageConversion.DataValueField = "ID";
                languageConversion.DataSource = item;
                languageConversion.DataBind();
                languageConversion.Items.Insert(0, templates_editproperty.objLanguage.GetLanguageConversion("None"));
                languageConversion.Items[0].Text = templates_editproperty.objLanguage.GetLanguageConversion("None");
                languageConversion.Items[0].Value = "0";
                for (int i = 0; i < languageConversion.Items.Count; i++)
                {
                    if (languageConversion.Items[i].Value.ToLower().Trim() == hiddenField2.Value.ToLower().Trim())
                    {
                        languageConversion.SelectedIndex = i;
                    }
                }
                for (int j = 0; j < dropDownList.Items.Count; j++)
                {
                    if (dropDownList.Items[j].Text.ToLower().Trim() == hiddenField.Value.ToLower().Trim())
                    {
                        dropDownList.SelectedIndex = j;
                    }
                }
                for (int k = 0; k < dropDownList1.Items.Count; k++)
                {
                    if (dropDownList1.Items[k].Value.ToLower().Trim() == hiddenField1.Value.ToLower().Trim())
                    {
                        dropDownList1.SelectedIndex = k;
                    }
                }
                DataTable dataTable = (DataTable)base.Session["HGroupDT"];
                languageConversion1.DataTextField = "GroupName";
                languageConversion1.DataValueField = "ID";
                languageConversion1.DataSource = dataTable;
                languageConversion1.DataBind();
                languageConversion1.Items.Insert(0, templates_editproperty.objLanguage.GetLanguageConversion("None"));
                languageConversion1.Items[0].Text = templates_editproperty.objLanguage.GetLanguageConversion("None");
                languageConversion1.Items[0].Value = "0";
                for (int l = 0; l < languageConversion1.Items.Count; l++)
                {
                    if (languageConversion1.Items[l].Value.ToLower().Trim() == hiddenField3.Value.ToLower().Trim())
                    {
                        languageConversion1.SelectedIndex = l;
                    }
                }
                if (Convert.ToInt32(hiddenField3.Value) != 0)
                {
                    flag.Checked = Convert.ToBoolean(hiddenField8.Value);
                }
                else
                {
                    flag.Visible = false;
                }
                if (Convert.ToBoolean(htmlInputCheckBox.Value))
                {
                    htmlInputCheckBox.Checked = true;
                }
                DataTable item1 = (DataTable)base.Session["Associatelabel"];
                languageConversion2.DataTextField = "objValue";
                languageConversion2.DataValueField = "objID";
                languageConversion2.DataSource = item1;
                languageConversion2.DataBind();
                languageConversion2.Items.Insert(0, templates_editproperty.objLanguage.GetLanguageConversion("None"));
                languageConversion2.Items[0].Text = templates_editproperty.objLanguage.GetLanguageConversion("None");
                languageConversion2.Items[0].Value = "0";
                for (int m = 0; m < languageConversion2.Items.Count; m++)
                {
                    if (languageConversion2.Items[m].Value.Replace("'", "").ToLower().Trim() == hiddenField7.Value.Replace("'", "").ToLower().Trim())
                    {
                        languageConversion2.SelectedIndex = m;
                    }
                }
                if (hiddenField4.Value == "3")
                {
                    value.Text = "Image";
                }
                if (hiddenField4.Value == "12")
                {
                    value.Text = "Header line";
                }
                if (hiddenField4.Value == "9")
                {
                    value.Text = "Item line start";
                }
                if (hiddenField4.Value == "8")
                {
                    value.Text = "Item line end";
                }
                if (hiddenField4.Value == "11")
                {
                    value.Text = "Footer line";
                }
                if (hiddenField4.Value == "2")
                {
                    value.ToolTip = hiddenField5.Value;
                    value.Text = (hiddenField5.Value.Length < 30 ? hiddenField5.Value : string.Concat(hiddenField5.Value.ToString().Substring(0, 30), "..."));
                    languageConversion2.Visible = false;
                }
            }
        }

        protected void lnkParentSave_OnClick(object sender, EventArgs e)
        {
            long num = (long)0;
            if (base.Request.Params["id"] != null)
            {
                num = Convert.ToInt64(base.Request.Params["id"].ToString());
            }
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.settings_templates_properties_select(this.companyId, num);
            this.GridTemplateProperties.DataSource = dataTable;
            this.GridTemplateProperties.DataBind();
            this.main.Attributes.Add("style", "display:block");
            if (this.GridTemplateProperties.Items.Count > 0)
            {
                this.btnUpdate.Style.Add("display", "block");
                this.btnSave.Style.Add("display", "block");
                return;
            }
            this.btnUpdate.Style.Add("display", "none");
            this.btnSave.Style.Add("display", "none");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridTemplateProperties.FilterMenu;
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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnTopCancel.Text = templates_editproperty.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = templates_editproperty.objLanguage.GetLanguageConversion("Save_Close");
            this.btnTopSave.Text = templates_editproperty.objLanguage.GetLanguageConversion("Save_Close");
            this.btnUpdate.Text = templates_editproperty.objLanguage.GetLanguageConversion("Save_Stay");
            this.btnTopUpdate.Text = templates_editproperty.objLanguage.GetLanguageConversion("Save_Stay");
            this.id = (long)Convert.ToInt32(base.Request.Params["id"]);
            this.companyId = int.Parse(base.Session["companyid"].ToString());
            IDataReader dataReader = SettingsBasePage.settings_template_select_byID(this.companyId, Convert.ToInt32(this.id));
            while (dataReader.Read())
            {
                this.spnheader.InnerText = string.Concat(templates_editproperty.objLanguage.GetLanguageConversion("Templates_Properties_Edit"), ": ", this.objBase.SpecialDecode(dataReader["Name"].ToString()));
            }
            if (base.Request.Params["pop"] != null)
            {
                this.pop = base.Request.Params["pop"].ToString();
            }
            if (!base.IsPostBack)
            {
                base.Session["GroupDT"] = null;
                base.Session["HGroupDT"] = null;
                base.Session["Associatelabel"] = null;
                this.BindGroup();
                this.BindHGroup();
                this.BindAssociatelabel();
                if (base.Request.Params["stay"] != null)
                {
                    this.objBase.Message_Display(templates_editproperty.objLanguage.GetLanguageConversion("Properties_Saved_Successfully"), "msg-success", this.plhMessage);
                }
                this.GridTemplateProperties.Visible = true;
                this.div_rightbtns.Attributes.Add("style", "display:block");
                this.div_topbtns.Attributes.Add("style", "display:block");
                this.GridTemplateProperties.DataBind();
                if (this.GridTemplateProperties.Items.Count <= 0)
                {
                    this.btnUpdate.Style.Add("display", "none");
                    this.btnSave.Style.Add("display", "none");
                }
                else
                {
                    this.btnUpdate.Style.Add("display", "block");
                    this.btnSave.Style.Add("display", "block");
                }
            }
            if (this.GridTemplateProperties.Items.Count > 0)
            {
                for (int i = 0; i < this.GridTemplateProperties.Items.Count; i++)
                {
                    TextBox textBox = (TextBox)this.GridTemplateProperties.Items[i].FindControl("txtFontSize");
                    if (textBox.Text.Contains("pt"))
                    {
                        textBox.Text = textBox.Text.Replace("pt", "");
                    }
                }
            }
            if (!base.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:ParentCall();", true);
            }
        }
    }
}