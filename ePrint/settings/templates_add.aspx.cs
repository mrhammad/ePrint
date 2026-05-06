using ePrint.usercontrol.settings;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Editor.DialogControls;

namespace ePrint.settings
{
    public partial class templates_add : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string sitepath = global.sitePath();

        private Global gloobj = new Global();

        private Template objTemplates = new Template();

        public int CompanyID;

        public int UserID;

        public string report_page = string.Empty;

        public string action = string.Empty;

        public string EditorText = string.Empty;

        public string ControlList = string.Empty;

        public string copy = string.Empty;

        public string CompanyLogo = string.Empty;

        public int TemplateID;

        private string PageType = string.Empty;

        public string imgHeaderPath = string.Empty;

        public string imgFooterPath = string.Empty;

        public string imgItemPath = string.Empty;

        public string imgSubItemPath = string.Empty;

        public string imgHRPath = string.Empty;

        public string @from = string.Empty;

        private string navigateText = string.Empty;

        public StringBuilder sbCreateControl = new StringBuilder();

        public string strCreateControl = string.Empty;

        public string CheckTagsExists = "no";

        public string strTemplatePDfValues = string.Empty;

        public string PDFImageName = string.Empty;

        public string divFields_Height = string.Empty;

        public string divFields_overflowy = string.Empty;

        public string EditorWidth = "925px";

        public string EditorHeight = "1285px";

        public string chklstCopyValues = "1285px";

        public int ImageWidthOnEdit = 925;

        public int ImageHeightOnEdit = 1285;

        public languageClass objlang = new languageClass();

        public string ServerName = ConnectionClass.ServerName;

        public string SecureSitePath = global.SecureSitePath();

        public string SecureDocPath = global.SecureDocPath();

        public string SeucreDocFilePath = global.SecureDocFilepath();

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

        public templates_add()
        {
        }

        private string ArrayListToString(ArrayList value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num = 0;
            foreach (string str in value)
            {
                stringBuilder.Append(str);
                if (num < value.Count - 1)
                {
                    stringBuilder.Append(",");
                }
                num++;
            }
            return stringBuilder.ToString();
        }

        private void BindFields(int CompanyID, int CategoryID)
        {
            this.RadPanelBar_btn.Visible = false;
            this.phButtons.Controls.Clear();
            this.divFields_Height = (CategoryID == 0 ? "1500px" : "1575px");
            this.divFields_overflowy = (CategoryID == 0 ? "scroll" : "scroll");
            foreach (DataRow row in this.objTemplates.settings_template_fields_oncategory_select(CompanyID, CategoryID).Rows)
            {
                Button button = new Button()
                {
                    Text = row["fieldName"].ToString(),
                    ID = string.Concat("btn", row["ID"].ToString()),
                    CssClass = "button11",
                    Width = Unit.Pixel(280)
                };
                string[] text = new string[] { "javascript:AddField('", button.Text, "','", row["fieldValue"].ToString(), "','", row["isitem"].ToString(), "');return false;" };
                button.OnClientClick = string.Concat(text);
                this.phButtons.Controls.Add(new LiteralControl("<div align='left'>"));
                this.phButtons.Controls.Add(button);
                this.phButtons.Controls.Add(new LiteralControl("</div>"));
                RadPanelItem radPanelItem = this.RadPanelBar_btn.Items.FindItemByValue(row["CategoryID"].ToString(), true);
                if (row["CategoryID"].ToString() != radPanelItem.Value)
                {
                    continue;
                }
                RadPanelItem radPanelItem1 = new RadPanelItem()
                {
                    Text = row["fieldName"].ToString()
                };
                radPanelItem1.Style.Add("font-size", "11px");
                AttributeCollection attributes = radPanelItem1.Attributes;
                string[] str = new string[] { "javascript:AddField('", row["fieldName"].ToString(), "','", row["fieldValue"].ToString(), "','", row["isitem"].ToString(), "');return false;" };
                attributes.Add("onclick", string.Concat(str));
                radPanelItem.Items.Add(radPanelItem1);
            }
        }

        protected void BindGroup()
        {
            DataSet dataSet = new DataSet();
            dataSet = this.objTemplates.Template_Group_View(this.TemplateID);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["GroupName"] = base.SpecialDecode(row["GroupName"].ToString());
            }
            this.ddlGroup.DataSource = dataSet;
            this.ddlGroup.DataTextField = "GroupName";
            this.ddlGroup.DataValueField = "ID";
            this.ddlGroup.DataBind();
            this.ddlGroup.Items.Insert(0, "Groups");
            this.ddlGroup.Items[0].Text = this.objLanguage.GetLanguageConversion("Groups");
            this.ddlGroup.Items[0].Value = "0";
            int count = this.ddlGroup.Items.Count - 1;
            this.ddlGroup.Items.Insert(count + 1, "-----------------");
            this.ddlGroup.Items[count + 1].Text = "-----------------";
            this.ddlGroup.Items[count + 1].Value = "-1";
            this.ddlGroup.Items.Insert(count + 2, "Create New");
            this.ddlGroup.Items[count + 2].Text = this.objLanguage.GetLanguageConversion("Create_New");
            this.ddlGroup.Items[count + 2].Value = "-2";
        }

        protected void BindHGroup()
        {
            DataSet dataSet = new DataSet();
            dataSet = this.objTemplates.Template_HGroup_View(this.TemplateID);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["GroupName"] = base.SpecialDecode(row["GroupName"].ToString());
            }
            this.ddlHGroup.DataSource = dataSet;
            this.ddlHGroup.DataTextField = "GroupName";
            this.ddlHGroup.DataValueField = "ID";
            this.ddlHGroup.DataBind();
            this.ddlHGroup.Items.Insert(0, "H Groups");
            this.ddlHGroup.Items[0].Text = this.objLanguage.GetLanguageConversion("H_Groups");
            this.ddlHGroup.Items[0].Value = "0";
            int count = this.ddlHGroup.Items.Count - 1;
            this.ddlHGroup.Items.Insert(count + 1, "-----------------");
            this.ddlHGroup.Items[count + 1].Text = "-----------------";
            this.ddlHGroup.Items[count + 1].Value = "-1";
            this.ddlHGroup.Items.Insert(count + 2, "Create New");
            this.ddlHGroup.Items[count + 2].Text = this.objLanguage.GetLanguageConversion("Create_New");
            this.ddlHGroup.Items[count + 2].Value = "-2";
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat("templates.aspx?page=", this.report_page));
        }

        protected void btnSaveGroup_OnClick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.ddlGroup.SelectedValue) > 0)
            {
                int num = Convert.ToInt32(this.ddlGroup.SelectedValue);
                SettingsBasePage.Template_Group_Update(Convert.ToInt32(this.ddlGroup.SelectedValue), base.SpecialEncode(this.txtGroupName.Text), this.chkAutoExpand.Checked);
                this.BindGroup();
                base.SetDDLValue(this.ddlGroup, num.ToString());
                return;
            }
            this.objTemplates.Template_Group_Add(Convert.ToInt32(base.Request.QueryString["ID"]), base.SpecialEncode(this.txtGroupName.Text), this.chkAutoExpand.Checked);
            this.BindGroup();
            this.ddlGroup.SelectedIndex = this.ddlGroup.Items.Count - 3;
            this.Message_Display("Group added successfully!", "msg-success", this.plhMessage);
        }

        protected void btnSaveHGroup_OnClick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.ddlHGroup.SelectedValue) <= 0)
            {
                this.objTemplates.Template_HGroup_Add(Convert.ToInt32(base.Request.QueryString["ID"]), base.SpecialEncode(this.txtHGroupName.Text), this.chkIsDeleteAllIfBlank.Checked);
                this.BindHGroup();
                this.ddlHGroup.SelectedIndex = this.ddlHGroup.Items.Count - 3;
            }
            else
            {
                int num = Convert.ToInt32(this.ddlHGroup.SelectedValue);
                SettingsBasePage.Template_HGroup_Update(Convert.ToInt32(this.ddlHGroup.SelectedValue), base.SpecialEncode(this.txtHGroupName.Text), this.chkIsDeleteAllIfBlank.Checked);
                this.BindHGroup();
                base.SetDDLValue(this.ddlHGroup, num.ToString());
            }
            this.Message_Display("HGroup added successfully!", "msg-success", this.plhMessage);
        }

        public void btnUpdate_Submit(object sender, EventArgs e)
        {
            this.Session["TemplateHTML"] = null;
            this.Session["TemplateControlList"] = null;
            long templateID = (long)0;
            decimal num = (this.txtFooterSpace.Text == "" ? new decimal(0) : Convert.ToDecimal(this.txtFooterSpace.Text));
            decimal num1 = (this.txtHeaderSpace.Text == "" ? new decimal(0) : Convert.ToDecimal(this.txtHeaderSpace.Text));
            if (base.Request.Params["copy"] != null)
            {
                this.TemplateID = 0;
                if (this.chklstCopyValues != "")
                {
                    string[] strArrays = this.chklstCopyValues.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        this.EditorText = this.hid_EditorHTML.Value;
                        this.ControlList = this.hid_ctrlListHTML.Value;
                        if (!this.chkSplit.Checked)
                        {
                            templateID = (!this.chkadjusted.Checked ? SettingsBasePage.settings_templates_insert(this.CompanyID, this.txtName.Text, this.txtDescription.Text, this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, strArrays[i].ToString(), this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, ' ', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked) : SettingsBasePage.settings_templates_insert(this.CompanyID, this.txtName.Text, this.txtDescription.Text, this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, strArrays[i].ToString(), this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 'a', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked));
                        }
                        else
                        {
                            templateID = SettingsBasePage.settings_templates_insert(this.CompanyID, this.txtName.Text, this.txtDescription.Text, this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, strArrays[i].ToString(), this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 's', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked);
                        }
                        SettingsBasePage.settings_templatefield_properties_delete(this.CompanyID, templateID);
                        this.Insert_TemplateField_Properties(templateID);
                        SettingsBasePage.Set_Horizontal_Group_TOP(this.CompanyID, templateID);
                        SettingsBasePage.settings_templates_groups_copy((long)this.CompanyID, Convert.ToInt64(base.Request.Params["ID"].ToString()), templateID);
                        SettingsBasePage.settings_templates_Hgroups_copy((long)this.CompanyID, Convert.ToInt64(base.Request.Params["ID"].ToString()), templateID);
                    }
                }
                if (this.hid_SaveType.Value.ToLower() == "redirect")
                {
                    base.Response.Redirect(string.Concat("templates.aspx?page=", this.report_page, "&action=edit"));
                    return;
                }
                HttpResponse response = base.Response;
                object[] reportPage = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", templateID, "&stay=yes" };
                response.Redirect(string.Concat(reportPage));
                return;
            }
            if (this.action == "edit")
            {
                this.EditorText = this.hid_EditorHTML.Value;
                this.ControlList = this.hid_ctrlListHTML.Value;
                this.UserID = Convert.ToInt32(this.Session["UserID"]);
                if (this.chkSplit.Checked)
                {
                    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 's', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked, this.UserID);
                }
                else if (!this.chkadjusted.Checked)
                {
                    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, ' ', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked, this.UserID);
                }
                //else if (this.chkSubitemSplit.Checked)
                //{
                //    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 'c', this.chkisKeepWithPrevious.Checked);
                //}
                else
                {
                    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 'a', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked, this.UserID);
                }
                templateID = (long)this.TemplateID;
                SettingsBasePage.settings_templatefield_properties_delete(this.CompanyID, templateID);
                this.Insert_TemplateField_Properties(templateID);
                SettingsBasePage.Set_Horizontal_Group_TOP(this.CompanyID, templateID);
                if (this.hid_SaveType.Value.ToLower() == "redirect")
                {
                    base.Response.Redirect(string.Concat("templates.aspx?page=", this.report_page, "&action=edit"));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", this.TemplateID, "&stay=yes" };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (base.Request.Params["iszeroth"] == null)
            {
                this.EditorText = this.hid_EditorHTML.Value;
                this.ControlList = this.hid_ctrlListHTML.Value;
                if (!this.chkadjusted.Checked)
                {
                    templateID = (!this.chkSplit.Checked ? SettingsBasePage.settings_templates_insert(this.CompanyID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, ' ', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked) : SettingsBasePage.settings_templates_insert(this.CompanyID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 's', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked));
                }
                else
                {
                    templateID = SettingsBasePage.settings_templates_insert(this.CompanyID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 'a', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked);
                }
                SettingsBasePage.settings_templatefield_properties_delete(this.CompanyID, templateID);
                this.Insert_TemplateField_Properties(templateID);
                SettingsBasePage.Set_Horizontal_Group_TOP(this.CompanyID, templateID);
            }
            else
            {
                this.CompanyID = 0;
                foreach (DataRow row in this.objTemplates.settings_zeroth_template_select(this.CompanyID, this.report_page).Rows)
                {
                    this.TemplateID = Convert.ToInt32(row["TemplateID"]);
                    this.txtDescription.Text = row["Description"].ToString();
                    this.txtName.Text = row["Name"].ToString();
                    this.chkDefaultTemp.Checked = Convert.ToBoolean(row["IsDefault"].ToString());
                    this.hidEditorValues_Edit.Value = row["Contents"].ToString();
                    this.hid_ctrlListHTML.Value = row["ControlList"].ToString();
                    this.hid_EditorHTML.Value = row["Contents"].ToString();
                }
                this.EditorText = this.hid_EditorHTML.Value;
                this.ControlList = this.hid_ctrlListHTML.Value;
                if (this.chkSplit.Checked)
                {
                    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 's', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked, this.UserID);
                }
                else if (!this.chkadjusted.Checked)
                {
                    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, ' ', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked, this.UserID);
                }
                else
                {
                    SettingsBasePage.settings_template_update(this.CompanyID, this.TemplateID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), this.hid_EditorHTML.Value, this.hid_ctrlListHTML.Value, this.report_page, this.chkDefaultTemp.Checked, Convert.ToInt64(this.ddlTemplatePDF.SelectedValue), num, num1, 'a', this.chkisKeepWithPrevious.Checked, this.chkSplitSubitem.Checked, this.chkLocationBasedSorting.Checked, this.chkGroupingBasedOnStock.Checked, this.UserID);
                }
                templateID = (long)this.TemplateID;
                SettingsBasePage.settings_templatefield_properties_delete(this.CompanyID, templateID);
                this.Insert_TemplateField_Properties(templateID);
                SettingsBasePage.Set_Horizontal_Group_TOP(this.CompanyID, templateID);
                if (this.hid_SaveType.Value.ToLower() != "redirect")
                {
                    base.Response.Redirect(string.Concat("templates_add.aspx?page=", this.report_page, "&action=add&iszeroth=yes"));
                }
                else
                {
                    base.Response.Redirect(string.Concat("templates.aspx?page=", this.report_page, "&action=add"));
                }
            }
            if (this.hid_SaveType.Value.ToLower() == "redirect")
            {
                base.Response.Redirect(string.Concat("templates.aspx?page=", this.report_page, "&action=add"));
                return;
            }
            HttpResponse response1 = base.Response;
            object[] reportPage1 = new object[] { "templates_add.aspx?page=", this.report_page, "&action=edit&ID=", templateID, "&stay=yes" };
            response1.Redirect(string.Concat(reportPage1));
        }

        [WebMethod]
        public static int CheckDuplicate(string val)
        {
            string[] strArrays = val.Split(new char[] { '&' });
            string str = strArrays[1];
            string str1 = strArrays[0];
            string str2 = strArrays[2];
            return SettingsBasePage.settings_templates_checkDuplicate(Convert.ToInt32(str2), str1, str);
        }

        private string CreateControl(DataTable dtFields)
        {
            foreach (DataRow row in dtFields.Rows)
            {
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                string empty4 = string.Empty;
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                string str4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                string str6 = string.Empty;
                string empty7 = string.Empty;
                string str7 = string.Empty;
                string empty8 = string.Empty;
                string str8 = string.Empty;
                string empty9 = string.Empty;
                string lower = string.Empty;
                string str9 = string.Empty;
                string empty10 = string.Empty;
                string str10 = string.Empty;
                string empty11 = string.Empty;
                string str11 = string.Empty;
                string empty12 = string.Empty;
                string str12 = string.Empty;
                string empty13 = string.Empty;
                string str13 = string.Empty;
                string empty14 = string.Empty;
                string str14 = string.Empty;
                string lower1 = string.Empty;
                string lower2 = string.Empty;
                string empty15 = string.Empty;
                string str15 = string.Empty;
                string empty16 = string.Empty;
                string str16 = string.Empty;
                string empty17 = string.Empty;
                string str17 = string.Empty;
                string empty18 = string.Empty;
                string lower3 = "n";
                string lower4 = "0";
                string lower5 = "0";
                string str18 = string.Empty;
                bool flag = false;
                str = row["objType"].ToString();
                row["objID"].ToString();
                empty18 = row["objTag"].ToString().Replace("GroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupID", "");
                empty2 = row["objValue"].ToString();
                str2 = row["imgsrc"].ToString();
                lower1 = row["lock"].ToString().Trim().ToLower();
                lower2 = row["Repeat"].ToString().Trim().ToLower();
                empty2 = (str == "3" || str == "8" || str == "9" || str == "10" || str == "11" || str == "12" || str == "13" || str == "14" ? str2 : base.SpecialEncode(row["objValue"].ToString()));
                empty1 = base.SpecialEncode(row["objName"].ToString());
                empty11 = (row["maxlength"].ToString() == "null" ? "0" : row["maxlength"].ToString());
                str6 = row["fontfamily"].ToString();
                empty7 = row["fontsize"].ToString();
                str7 = row["fontweight"].ToString();
                empty8 = row["fontstyle"].ToString();
                num1 = Convert.ToDecimal(row["left"]);
                num = Convert.ToDecimal(row["top"]);
                num2 = Convert.ToDecimal(row["width"]);
                num3 = Convert.ToDecimal(row["height"]);
                str8 = row["fontcolor"].ToString();
                empty9 = (row["textdecoration"].ToString().ToLower() == "underline" ? "1" : "0");
                lower = row["textalign"].ToString().ToLower();
                lower4 = row["GroupID"].ToString().ToLower();
                lower5 = row["HGroupID"].ToString().ToLower();
                str18 = row["AssociatedLabel"].ToString();
                lower3 = row["isitem"].ToString().ToLower();
                flag = Convert.ToBoolean(row["IsHGroupMain"]);
                string str19 = "1";
                if (lower == "center")
                {
                    str19 = "2";
                }
                else if (lower == "right")
                {
                    str19 = "3";
                }
                if (str == "13")
                {
                    this.ImageWidthOnEdit = Convert.ToInt32(num2);
                    this.ImageHeightOnEdit = Convert.ToInt32(num3);
                }
                if ((this.CheckTagsExists == "no" || this.CheckTagsExists == "yes" && empty18.ToString().ToLower() == "null") && str == "1" && empty18.ToString().ToLower() == "null")
                {
                    string lower6 = empty1.ToString().ToLower();
                    if (lower6 == "estimate" || lower6 == "enter your text" || lower6 == "kind regards" || lower6 == "best regards" || lower6 == "job card" || lower6 == "invoice" || lower6 == "purchase order" || lower6 == "delivery note" || lower6 == "your's sincerely" || lower6 == "description of goods" || lower6 == "production information" || lower6 == "estimated" || lower6 == "actual job performance" || lower6.Trim() == "GroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupIDGroupID")
                    {
                        empty18 = "";
                    }
                    else
                    {
                        string str20 = empty1.Replace("GroupID", "");
                        string[] strArrays = str20.Split(new char[] { ' ' });
                        string empty19 = string.Empty;
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            empty19 = string.Concat(empty19, strArrays[i].ToString());
                        }
                        empty18 = string.Concat("[", empty19, "]");
                    }
                }
                if (str2.Contains("borders.gif"))
                {
                    empty1 = empty1.Replace("borders.gif", "borders.png");
                    empty2 = empty2.Replace("borders.gif", "borders.png");
                    str2 = str2.Replace("borders.gif", "borders.png");
                }
                if (str2.Contains("borders.png"))
                {
                    num2 = new decimal(783);
                    num3 = new decimal(842);
                }
                object[] secureSitePath = new object[] { this.SecureSitePath, this.ServerName, "/", this.CompanyID, "/", this.CompanyLogo };
                string str21 = string.Concat(secureSitePath);
                string.Concat(this.strImagepath, "items-line.gif");
                empty1 = empty1.Replace("[LogoPath]", str21);
                empty2 = empty2.Replace("[LogoPath]", str21);
                str2 = str2.Replace("[LogoPath]", str21);
                StringBuilder stringBuilder = this.sbCreateControl;
                object[] objArray = new object[] { "CreateCtrl('", str, "', '', '", empty18, "', '", empty2, "', '", empty1, "', '", empty11, "', '', '", str6, "', '", empty7, "','", str7, "', '", empty8, "', '", Convert.ToInt32(num1), "', '", Convert.ToInt32(num), "', '", Convert.ToInt32(num2), "', '", Convert.ToInt32(num3), "', '", str8, "','", empty9, "', '0pt', '", str19, "', '0', '1', '", lower1, "' ,'0', '0', '0', '1', '1', '1', '", lower3, "','", lower4, "','", lower5, "','", str18, "','", flag, "','", lower2, "');" };
                stringBuilder.Append(string.Concat(objArray));
            }
            this.sbCreateControl.ToString().Contains("borders.png");
            return this.sbCreateControl.ToString();
        }

        private string GetCheckBoxList(Control control)
        {
            ArrayList arrayLists = new ArrayList();
            foreach (ListItem item in ((CheckBoxList)control).Items)
            {
                if (!item.Selected)
                {
                    continue;
                }
                arrayLists.Add(item.Value);
            }
            return this.ArrayListToString(arrayLists);
        }

        protected void img_Groupeditbtnclick(object sender, EventArgs e)
        {
            DataSet dataSet = SettingsBasePage.Settings_Template_Group_Select(Convert.ToInt32(this.ddlGroup.SelectedValue.ToString()));
            this.chkAutoExpand.Checked = false;
            this.txtGroupName.Text = "";
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["IsAuto"].ToString().Trim().ToLower() != "true")
                {
                    this.chkAutoExpand.Checked = false;
                }
                else
                {
                    this.chkAutoExpand.Checked = true;
                }
                this.txtGroupName.Text = row["GroupName"].ToString();
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "SaveAndRedirect", ";EditGroup();", true);
        }

        protected void img_heditbtnclick(object sender, EventArgs e)
        {
            DataSet dataSet = SettingsBasePage.Settings_Template_HGroup_Select(Convert.ToInt32(this.ddlHGroup.SelectedValue.ToString()));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row["isDeleteAllIfMainisBlank"].ToString().Trim().ToLower() != "true")
                {
                    this.chkIsDeleteAllIfBlank.Checked = false;
                }
                else
                {
                    this.chkIsDeleteAllIfBlank.Checked = true;
                }
                this.txtHGroupName.Text = row["GroupName"].ToString();
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "SaveAndRedirect", ";EditHGroup();", true);
        }

        protected void imgbtnDeleteGroup_OnClick(object sender, EventArgs e)
        {
            if (this.ddlGroup.SelectedValue == "0")
            {
                this.Message_Display("Please select Group to remove", "msg-alert", this.plhMessage);
                return;
            }
            this.objTemplates.Template_Group_Delete(Convert.ToInt32(this.ddlGroup.SelectedValue), Convert.ToInt32(base.Request.QueryString["ID"]));
            this.BindGroup();
            this.Message_Display("Group removed successfully!", "msg-success", this.plhMessage);
        }

        protected void imgbtnDeleteHGroup_OnClick(object sender, EventArgs e)
        {
            if (this.ddlHGroup.SelectedValue == "0")
            {
                this.Message_Display("Please select HGroup to remove", "msg-alert", this.plhMessage);
                return;
            }
            this.objTemplates.Template_HGroup_Delete(Convert.ToInt32(this.ddlHGroup.SelectedValue), Convert.ToInt32(base.Request.QueryString["ID"]));
            this.BindHGroup();
            this.Message_Display("HGroup removed successfully!", "msg-success", this.plhMessage);
        }

        private void Insert_TemplateField_Properties(long retTemplateID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            string str11 = string.Empty;
            string empty12 = string.Empty;
            string str12 = string.Empty;
            string empty13 = string.Empty;
            string str13 = string.Empty;
            string empty14 = string.Empty;
            string str14 = string.Empty;
            string empty15 = string.Empty;
            string str15 = string.Empty;
            string empty16 = string.Empty;
            string str16 = string.Empty;
            string empty17 = string.Empty;
            string str17 = string.Empty;
            string empty18 = string.Empty;
            string str18 = string.Empty;
            string empty19 = string.Empty;
            string str19 = string.Empty;
            string str20 = "0";
            string str21 = "0";
            string empty20 = string.Empty;
            bool flag = false;
            if (this.hid_FieldProperties.Value != "")
            {
                string[] strArrays = this.hid_FieldProperties.Value.Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                        string str22 = strArrays2[0].ToString();
                        string str23 = strArrays2[1].ToString();
                        if (str22 == "objID")
                        {
                            empty = str23;
                        }
                        if (str22 == "objType")
                        {
                            str = str23;
                        }
                        if (str22 == "objName")
                        {
                            empty1 = str23;
                        }
                        if (str22 == "type")
                        {
                            str1 = str23;
                        }
                        if (str22 == "objValue")
                        {
                            empty2 = str23;
                        }
                        if (str22 == "imgsrc")
                        {
                            str2 = str23;
                        }
                        if (str22 == "title")
                        {
                            empty3 = str23;
                        }
                        if (str22 == "align")
                        {
                            str3 = (str23 == "null" ? "left" : str23);
                        }
                        if (str22 == "position")
                        {
                            empty4 = str23;
                        }
                        if (str22 == "objtop")
                        {
                            num = Convert.ToDecimal(str23);
                        }
                        if (str22 == "objleft")
                        {
                            num1 = Convert.ToDecimal(str23);
                        }
                        if (str22 == "objwidth")
                        {
                            num2 = Convert.ToDecimal(str23);
                        }
                        if (str22 == "objheight")
                        {
                            num3 = Convert.ToDecimal(str23);
                        }
                        if (str22 == "zindex")
                        {
                            str4 = str23;
                        }
                        if (str22 == "padding")
                        {
                            empty5 = str23;
                        }
                        if (str22 == "display")
                        {
                            str5 = str23;
                        }
                        if (str22 == "overflow")
                        {
                            empty6 = str23;
                        }
                        if (str22 == "fontfamily")
                        {
                            str6 = str23;
                        }
                        if (str22 == "fontsize")
                        {
                            empty7 = str23;
                        }
                        if (str22 == "fontweight")
                        {
                            str7 = str23;
                        }
                        if (str22 == "fontstyle")
                        {
                            empty8 = str23;
                        }
                        if (str22 == "fontcolor")
                        {
                            str8 = str23;
                        }
                        if (str22 == "textdecoration")
                        {
                            empty9 = str23;
                        }
                        if (str22 == "textalign")
                        {
                            str9 = str23;
                        }
                        if (str22 == "border")
                        {
                            empty10 = str23;
                        }
                        if (str22 == "backgroundcolor")
                        {
                            str10 = str23;
                        }
                        if (str22 == "backgroundcolor")
                        {
                            str10 = str23;
                        }
                        if (str22 == "visibility")
                        {
                            empty11 = str23;
                        }
                        if (str22 == "maxlength")
                        {
                            str11 = (str23 == "null" ? "0" : str23);
                        }
                        if (str22 == "offsetwidth")
                        {
                            empty12 = str23;
                        }
                        if (str22 == "offsetheight")
                        {
                            str12 = str23;
                        }
                        if (str22 == "offsettop")
                        {
                            empty13 = str23;
                        }
                        if (str22 == "offsetleft")
                        {
                            str13 = str23;
                        }
                        if (str22 == "pixelwidth")
                        {
                            empty14 = (str23 == "undefined" ? "0" : str23);
                        }
                        if (str22 == "pixelheight")
                        {
                            str14 = (str23 == "undefined" ? "0" : str23);
                        }
                        if (str22 == "pixeltop")
                        {
                            empty15 = (str23 == "undefined" ? "0" : str23);
                        }
                        if (str22 == "lock")
                        {
                            str15 = str23;
                        }
                        if (str22 == "repeat")
                        {
                            empty16 = str23;
                        }
                        if (str22 == "canmove")
                        {
                            str16 = (str23 == "null" ? "1" : str23);
                        }
                        if (str22 == "canchangefontcolor")
                        {
                            empty17 = (str23 == "null" ? "1" : str23);
                        }
                        if (str22 == "canchangefontsize")
                        {
                            str17 = (str23 == "null" ? "1" : str23);
                        }
                        if (str22 == "canchangefont")
                        {
                            empty18 = (str23 == "null" ? "1" : str23);
                        }
                        if (str22 == "objclass")
                        {
                            str18 = (str23 == "null" ? "putpointer" : str23);
                        }
                        if (str22 == "onmouseoverclass")
                        {
                            empty19 = (str23 == "null" ? "this.className='putpointer'" : str23);
                        }
                        if (str22 == "objTag")
                        {
                            str19 = str23;
                        }
                        if (str22.Trim().ToLower() == "groupid")
                        {
                            str20 = str23;
                        }
                        if (str22.Trim().ToLower() == "hgroupid")
                        {
                            str21 = str23;
                        }
                        if (str22.Trim().ToLower() == "associatedlabel")
                        {
                            empty20 = str23;
                        }
                        if (str22.Trim().ToLower() == "ihgroupmain")
                        {
                            flag = Convert.ToBoolean(str23);
                        }
                    }
                    SettingsBasePage.settings_templatefield_properties_insert(this.CompanyID, retTemplateID, empty, str, empty1, str1, empty2, str2, empty3, str3, empty4, num, num1, num2, num3, str4, empty5, str5, empty6, str6.Replace("'", ""), empty7, str7, empty8, str8, empty9, str9, empty10, str10, empty11, str11, empty12, str12, empty13, str13, empty14, str14, empty15, str15, str16, empty17, str17, empty18, str18, empty19, str19, str20, str21, empty20, flag, empty16);
                }
            }
        }

        public new void Message_Display(string strMsg, string cssclass, PlaceHolder plh)
        {
            plh.Controls.Clear();
            UserControl userControl = (UserControl)base.LoadControl("~/Usercontrol/message_display.ascx");
            plh.Controls.Add(userControl);
            Timer timer = (Timer)userControl.FindControl("TimerMessage");
            Label label = (Label)userControl.FindControl("lblMessage");
            ((Panel)userControl.FindControl("pnlMessage")).CssClass = cssclass;
            label.Text = strMsg;
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (base.Request.Params["page"] != null)
            {
                if (base.Request.Params["page"].ToString().ToLower() != "webstoreorder")
                {
                    this.MasterPageFile = "~/Templates/settingpage.master";
                }
                else
                {
                    this.MasterPageFile = "~/Templates/SettingsEstore.master";
                }
            }
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btnCancel','div_btnCancelprocess');");
            this.chklstCopyValues = this.GetCheckBoxList(this.chklstCopy);
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnUpdate.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnSaveStay.Text = this.objLanguage.GetLanguageConversion("Save_Stay");
            this.btnSaveHGroup.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnSaveGroup.Text = this.objLanguage.GetLanguageConversion("Save");
            this.chkisKeepWithPrevious.Text = string.Concat("&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("Where_Fields_In_Group_Are_Blank_Move_The_Fields_Below_Up_To_Close_The_Gap"));
            this.chkSplit.Text = string.Concat("&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("In_Multi_Item_Templates_Only_Allow_One_Item_Per_Page"));
            this.chkadjusted.Text = string.Concat("&nbsp;&nbsp;", this.objLanguage.GetLanguageConversion("In_Multi_Item_Templates_Allow_Multiple_Items_On_A_Page_But_Dont_Allow_An_Items_Details_To_Be_Split_Accross_Two_Pages"));
            FileManagerDialogParameters fileManagerDialogParameter = new FileManagerDialogParameters();
            string[] strArrays = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays[0] = string.Concat(secureVirtualPath);
            fileManagerDialogParameter.ViewPaths = strArrays;
            string[] strArrays1 = new string[1];
            string[] secureVirtualPath1 = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays1[0] = string.Concat(secureVirtualPath1);
            fileManagerDialogParameter.UploadPaths = strArrays1;
            fileManagerDialogParameter.MaxUploadFileSize = 5000000;
            DialogDefinition dialogDefinition = new DialogDefinition(typeof(ImageManagerDialog), fileManagerDialogParameter)
            {
                ClientCallbackFunction = "ImageManagerFunction",
                Width = Unit.Pixel(690),
                Height = Unit.Pixel(440),
                Title = this.objLanguage.GetLanguageConversion("Image_Manager")
            };
            dialogDefinition.Parameters["ExternalDialogsPath"] = "~/RadEditorDialogs/";
            this.DialogOpener1.DialogDefinitions.Add("ImageManager", dialogDefinition);
            FileManagerDialogParameters fileManagerDialogParameter1 = new FileManagerDialogParameters();
            string[] strArrays2 = new string[1];
            string[] secureVirtualPath2 = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays2[0] = string.Concat(secureVirtualPath2);
            fileManagerDialogParameter1.ViewPaths = strArrays2;
            string[] strArrays3 = new string[1];
            string[] secureVirtualPath3 = new string[] { this.SecureVirtualPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays3[0] = string.Concat(secureVirtualPath3);
            fileManagerDialogParameter1.UploadPaths = strArrays3;
            fileManagerDialogParameter1.MaxUploadFileSize = 5000000;
            DialogDefinition dialogDefinition1 = new DialogDefinition(typeof(ImageEditorDialog), fileManagerDialogParameter1);
            dialogDefinition1.Parameters["ExternalDialogsPath"] = "~/RadEditorDialogs/";
            dialogDefinition1.Width = Unit.Pixel(800);
            dialogDefinition1.Height = Unit.Pixel(440);
            this.DialogOpener1.DialogDefinitions.Add("ImageEditor", dialogDefinition1);
            this.gloobj.setpagename("setting");
            this.report_page = base.Request.Params["page"].ToString();
            this.action = base.Request.Params["action"].ToString();
            this.imgHeaderPath = string.Concat(this.strImagepath, "header-line.gif");
            this.imgFooterPath = string.Concat(this.strImagepath, "footer-line.gif");
            this.imgItemPath = string.Concat(this.strImagepath, "items-line.gif");
            this.imgSubItemPath = string.Concat(this.strImagepath, "sub-items.gif");
            this.imgHRPath = string.Concat(this.strImagepath, "HorizontalLine.gif");
            base.Title = "Settings: Add New Layout";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            if (!base.IsPostBack && base.Request.Params["stay"] != null)
            {
                this.Message_Display(this.objLanguage.GetLanguageConversion("Template_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            if (this.action == "add")
            {
                this.AdjustTooltd.Visible = false;
                this.ddlGroup.Visible = false;
                this.editgroupTooltd.Visible = false;
                this.deletegroupTooltd.Visible = false;
                this.ddlHGroup.Visible = false;
                this.editHgroupTooltd.Visible = false;
                this.deleteHgroupTooltd.Visible = false;
            }
            if (this.action != "edit")
            {
                this.navigateText = this.objLanguage.GetLanguageConversion("Add_New");
                this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Add_New");
            }
            else
            {
                this.TemplateID = Convert.ToInt32(base.Request.Params["ID"].ToString());
                if (base.Request.Params["copy"] == null)
                {
                    this.navigateText = this.objLanguage.GetLanguageConversion("Edit");
                }
                else
                {
                    this.copy = base.Request.Params["copy"].ToString().ToLower();
                    this.navigateText = this.objLanguage.GetLanguageConversion("Copy");
                }
                if (base.Request.Params["from"] != null)
                {
                    this.@from = base.Request.Params["from"].ToString();
                }
            }
            if (this.report_page.ToLower().Trim() == "note")
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Delivery_Note"));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.report_page, "' class='subnavigator' ><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Delivery_Note_Templates_View"), "</span></a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Delivery_Note_Template")));
                base.Title = this.objLanguage.convert(global.pageTitle("Delivery Note: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = string.Concat(this.navigateText, " ", this.objLanguage.GetLanguageConversion("Delivery_Note_Template"));
            }
            else if (this.report_page.ToLower().Trim() == "printbroker")
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Supplier_RFQs"));
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel'   style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.report_page, "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Supplier_RFQ_Templates_View"), "</span></a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Supplier_RFQ_Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle("Supplier RFQ: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                settings_mis_headerpanel headerMis = this.header_mis;
                string[] languageConversion2 = new string[] { this.navigateText, " ", this.objLanguage.GetLanguageConversion("Supplier_RFQs"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                headerMis.SettingName = string.Concat(languageConversion2);
            }
            else if (this.report_page.ToLower().Trim() == "job")
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Job"));
                string[] languageConversion3 = new string[] { "<a href=../welcome.aspx class='subnavigator' ><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.report_page, "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Templates_View"), "</span></a>" };
                base.Navigation_Path(string.Concat(languageConversion3), string.Concat("&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Job_Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle("Job Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                settings_mis_headerpanel usercontrolSettingsSettingsMisHeaderpanel = this.header_mis;
                string[] languageConversion4 = new string[] { this.navigateText, " ", this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                usercontrolSettingsSettingsMisHeaderpanel.SettingName = string.Concat(languageConversion4);
            }
            else if (this.report_page.ToLower().Trim() != "webstoreorder")
            {
                if (this.report_page.ToLower().Trim() == "invoice")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Invoice"));
                    string[] strArrays4 = new string[] { "<a href=../welcome.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.objLanguage.GetLanguageConversion("Invoice"), "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice"), " ", this.objLanguage.GetLanguageConversion("Templates_View"), "</span></a>" };
                    string str = string.Concat(strArrays4);
                    string[] languageConversion5 = new string[] { "&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Invoice"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    base.Navigation_Path(str, string.Concat(languageConversion5));
                    settings_mis_headerpanel headerMis1 = this.header_mis;
                    string[] strArrays5 = new string[] { this.navigateText, " ", this.objLanguage.GetLanguageConversion("Invoice"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    headerMis1.SettingName = string.Concat(strArrays5);
                }
                else if (this.report_page.ToLower().Trim() == "estimate")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Estimate"));
                    string[] languageConversion6 = new string[] { "<a href=../welcome.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.objLanguage.GetLanguageConversion("Estimate"), "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate"), " ", this.objLanguage.GetLanguageConversion("Templates_View"), "</span></a>" };
                    string str1 = string.Concat(languageConversion6);
                    string[] strArrays6 = new string[] { "&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Estimate"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    base.Navigation_Path(str1, string.Concat(strArrays6));
                    settings_mis_headerpanel usercontrolSettingsSettingsMisHeaderpanel1 = this.header_mis;
                    string[] languageConversion7 = new string[] { this.navigateText, " ", this.objLanguage.GetLanguageConversion("Estimate"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    usercontrolSettingsSettingsMisHeaderpanel1.SettingName = string.Concat(languageConversion7);
                }
                else if (this.report_page.ToLower().Trim() == "job")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Job"));
                    string[] strArrays7 = new string[] { "<a href=../welcome.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.objLanguage.GetLanguageConversion("Job"), "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates_View"), "</span></a>" };
                    string str2 = string.Concat(strArrays7);
                    string[] languageConversion8 = new string[] { "&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    base.Navigation_Path(str2, string.Concat(languageConversion8));
                    settings_mis_headerpanel headerMis2 = this.header_mis;
                    string[] strArrays8 = new string[] { this.navigateText, " ", this.objLanguage.GetLanguageConversion("Job"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    headerMis2.SettingName = string.Concat(strArrays8);
                }
                else if (this.report_page.ToLower().Trim() == "purchase")
                {
                    this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Purchase"));
                    string[] languageConversion9 = new string[] { "<a href=../welcome.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.objLanguage.GetLanguageConversion("Purchase"), "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Purchase"), " ", this.objLanguage.GetLanguageConversion("Templates_View"), "</span></a>" };
                    string str3 = string.Concat(languageConversion9);
                    string[] strArrays9 = new string[] { "&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("Purchase"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    base.Navigation_Path(str3, string.Concat(strArrays9));
                    settings_mis_headerpanel usercontrolSettingsSettingsMisHeaderpanel2 = this.header_mis;
                    string[] languageConversion10 = new string[] { this.navigateText, " ", this.objLanguage.GetLanguageConversion("Purchase"), " ", this.objLanguage.GetLanguageConversion("Templates") };
                    usercontrolSettingsSettingsMisHeaderpanel2.SettingName = string.Concat(languageConversion10);
                }
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(this.report_page, " Templates"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else
            {
                this.spnheader.InnerText = string.Concat(this.objLanguage.GetLanguageConversion("Templates"), " : ", this.objLanguage.GetLanguageConversion("Estore_Order"));
                string[] strArrays10 = new string[] { "<a href=../welcome.aspx class='subnavigator' ><span class='navigatorpanel' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</span></a>&nbsp;>&nbsp;<a href=../Storesettings/Storesettings.aspx class='subnavigator'><span class='navigatorpanel' style='text-decoration:underline;'>eStore Settings View</span></a>&nbsp;>&nbsp;<a href='../Settings/templates.aspx?page=", this.report_page, "' class='subnavigator'><span class='navigatorpanel'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("EStore_Order_Templates_View"), "</span></a>" };
                base.Navigation_Path(string.Concat(strArrays10), string.Concat("&nbsp;>&nbsp;", this.navigateText, " ", this.objLanguage.GetLanguageConversion("EStore_Order_Templates")));
                base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Order_Template"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header_mis.SettingName = string.Concat(this.navigateText, " ", this.objLanguage.GetLanguageConversion("EStore_Order_Templates"));
            }
            string str4 = this.report_page.ToLower().Trim();
            string str5 = str4;
            if (str4 != null)
            {
                switch (str5)
                {
                    case "estimate":
                        {
                            this.BindFields(this.CompanyID, 7);
                            break;
                        }
                    case "printbroker":
                        {
                            this.BindFields(this.CompanyID, 14);
                            break;
                        }
                    case "job":
                        {
                            this.BindFields(this.CompanyID, 8);
                            break;
                        }
                    case "jobcard":
                        {
                            this.BindFields(this.CompanyID, 9);
                            break;
                        }
                    case "invoice":
                        {
                            this.BindFields(this.CompanyID, 10);
                            break;
                        }
                    case "purchase":
                        {
                            this.BindFields(this.CompanyID, 11);
                            break;
                        }
                    case "note":
                        {
                            this.BindFields(this.CompanyID, 12);
                            break;
                        }
                    case "webstoreorder":
                        {
                            this.BindFields(this.CompanyID, 15);
                            break;
                        }
                }
            }
            if (!base.IsPostBack)
            {
                this.objTemplates.Bind_TemplatePDF(this.ddlTemplatePDF, this.CompanyID, "--- Select ---");
                this.objTemplates.Bind_TemplateFonts(this.ddlfonts, this.CompanyID, "--- Select ---");
                this.BindGroup();
                this.BindHGroup();
                foreach (DataRow row in this.objTemplates.settings_template_pdf_select(this.CompanyID).Rows)
                {
                    object[] secureSitePath = new object[] { this.SecureSitePath, this.ServerName, "/", this.CompanyID, "/TemplatePDF/", row["ImageName"].ToString() };
                    string str6 = string.Concat(secureSitePath);
                    templates_add settingsTemplatesAdd = this;
                    object obj = settingsTemplatesAdd.strTemplatePDfValues;
                    object[] objArray = new object[] { obj, row["PDFID"].ToString(), "»", str6, "»", Convert.ToInt32(row["ImageWidth"]), "»", Convert.ToInt32(row["ImageHeight"]), "µ" };
                    settingsTemplatesAdd.strTemplatePDfValues = string.Concat(objArray);
                }
                foreach (DataRow dataRow in CompanyBasePage.company_logo_select(this.CompanyID, "header").Rows)
                {
                    if (dataRow["logotype"].ToString() != "image")
                    {
                        this.CompanyLogo = "Eprint_logo1.jpg";
                    }
                    else
                    {
                        this.CompanyLogo = dataRow["logoimage"].ToString();
                    }
                }
                this.chkisKeepWithPrevious.Checked = true;
                if (this.action != "edit")
                {
                    DataTable dataTable = this.objTemplates.settings_default_template_field_properties_select(0, this.report_page.ToLower());
                    this.strCreateControl = this.CreateControl(dataTable);
                }
                else
                {
                    IDataReader dataReader = SettingsBasePage.settings_template_select_byID(this.CompanyID, this.TemplateID);
                    while (dataReader.Read())
                    {
                        this.txtDescription.Text = base.SpecialDecode(dataReader["Description"].ToString());
                        this.txtName.Text = base.SpecialDecode(dataReader["Name"].ToString());
                        this.chkDefaultTemp.Checked = Convert.ToBoolean(dataReader["IsDefault"].ToString());
                        this.ddlTemplatePDF.SelectedValue = dataReader["PDFID"].ToString();
                        this.txtFooterSpace.Text = dataReader["FooterSpace"].ToString();
                        this.txtHeaderSpace.Text = dataReader["HeaderSpace"].ToString();
                        if (Convert.ToChar(dataReader["ItemSplitStatus"].ToString()) == 's')
                        {
                            this.chkSplit.Checked = true;
                            this.chkadjusted.Checked = false;
                        }
                        else if (Convert.ToChar(dataReader["ItemSplitStatus"].ToString()) != 'a')
                        {
                            this.chkadjusted.Checked = false;
                            this.chkSplit.Checked = false;
                        }
                        else
                        {
                            this.chkadjusted.Checked = true;
                            this.chkSplit.Checked = false;
                        }
                        //if (Convert.ToBoolean(Convert.ToString(dataReader["isSplitSubitem"])))
                        //{
                        //    this.chkSplitSubitem.Checked = true;
                        //}
                        this.chkisKeepWithPrevious.Checked = Convert.ToBoolean(dataReader["isKeepWithPrevious"].ToString());
                        this.chkSplitSubitem.Checked = Convert.ToBoolean(dataReader["isSplitSubitem"].ToString());
                        this.chkLocationBasedSorting.Checked = Convert.ToBoolean(dataReader["isLocationBasedSorting"].ToString());
                        this.chkGroupingBasedOnStock.Checked = Convert.ToBoolean(dataReader["isGroupingBasedOnStockLocation"].ToString());
                        HiddenField hidPDFImageName = this.hid_PDFImageName;
                        object[] secureSitePath1 = new object[] { this.SecureSitePath, this.ServerName, "/", this.CompanyID, "/TemplatePDF/", dataReader["ImageName"].ToString() };
                        hidPDFImageName.Value = string.Concat(secureSitePath1);
                        this.hidEditorValues_Edit.Value = dataReader["Contents"].ToString();
                        this.hid_ctrlListHTML.Value = dataReader["ControlList"].ToString();
                        this.hid_EditorHTML.Value = dataReader["Contents"].ToString();
                        this.pnlInsertPDFOnEdit.Visible = true;

                        if (this.report_page.ToLower().Trim() == "job")
                        {
                            dvSplitSubitem.Visible = true;
                        }
                        else
                        {
                            dvSplitSubitem.Visible = false;
                        }
                        if (this.report_page.ToLower().Trim() == "note")
                        {
                            dvLocationBasedSorting.Visible = true;
                            dvGroupingBasedOnStock.Visible = true;
                        }
                        else
                        {
                            dvLocationBasedSorting.Visible = false;
                            dvGroupingBasedOnStock.Visible = false;
                        }
                    }
                    DataTable dataTable1 = this.objTemplates.settings_template_field_properties_select(this.CompanyID, (long)this.TemplateID, this.report_page.ToLower());
                    if (dataTable1.Rows.Count <= 0)
                    {
                        this.CheckTagsExists = "no";
                    }
                    else
                    {
                        this.CheckTagsExists = "yes";
                        this.strCreateControl = this.CreateControl(dataTable1);
                    }
                    this.pnlEdit.Visible = true;
                    if (this.copy == "yes")
                    {
                        this.div_chkCopy.Style.Add("display", "block");
                    }
                    object[] objArray1 = new object[] { this.SecureSitePath, this.ServerName, "/", this.CompanyID, "/", this.CompanyLogo };
                    string str7 = string.Concat(objArray1);
                    string str8 = string.Concat(this.strImagepath, "items-line.gif");
                    this.hidEditorValues_Edit.Value = this.hidEditorValues_Edit.Value.Replace("[LogoPath]", str7);
                    this.hidEditorValues_Edit.Value = this.hidEditorValues_Edit.Value.Replace("[HRPath]", str8);
                }
            }
            if (base.Request.Params["copy"] == null)
            {
                this.btnUpdate.Attributes.Add("onclick", "javascript:var a=ValidateName('redirect');if(a)loadingimg('div_btnupdate','div_btnupdateprocess');return a;");
                this.btnSaveStay.Attributes.Add("onclick", "javascript:var a=ValidateName('stay');if(a)loadingimg('div_btnsavestay','div_btnsavestayprocess');return a;");
            }
            else if (base.Request.Params["copy"].ToString().ToLower() == "yes")
            {
                this.btnUpdate.Attributes.Add("onclick", "javascript:var a=ValidateName('redirect')&&readCheckBoxList();if(a)loadingimg('div_btnupdate','div_btnupdateprocess');return a;");
                this.btnSaveStay.Attributes.Add("onclick", "javascript:var a=ValidateName('stay')&&readCheckBoxList();if(a)loadingimg('div_btnsavestay','div_btnsavestayprocess');return a;");
                if (this.chkDefaultTemp.Checked)
                {
                    this.chkDefaultTemp.Checked = false;
                }
            }
            if (base.Request.Params["page"] != null && base.Request.Params["copy"] != null && base.Request.Params["copy"].ToString().ToLower() == "yes")
            {
                if (base.Request.Params["page"].ToString().ToLower() == "estimate")
                {
                    this.SetCheckBoxList(this.chklstCopy, "Estimate");
                    return;
                }
                if (base.Request.Params["page"].ToString().ToLower() == "printbroker")
                {
                    this.SetCheckBoxList(this.chklstCopy, "PrintBroker");
                    return;
                }
                if (base.Request.Params["page"].ToString().ToLower() == "job")
                {
                    this.SetCheckBoxList(this.chklstCopy, "Job");
                    return;
                }
                if (base.Request.Params["page"].ToString().ToLower() == "purchase")
                {
                    this.SetCheckBoxList(this.chklstCopy, "Purchase");
                    return;
                }
                if (base.Request.Params["page"].ToString().ToLower() == "note")
                {
                    this.SetCheckBoxList(this.chklstCopy, "Note");
                    return;
                }
                if (base.Request.Params["page"].ToString().ToLower() == "invoice")
                {
                    this.SetCheckBoxList(this.chklstCopy, "Invoice");
                }
            }
        }

        private void SetCheckBoxList(Control control, string value)
        {
            CheckBoxList checkBoxList = (CheckBoxList)control;
            ArrayList arrayList = this.StringToArrayList(value);
            foreach (ListItem item in checkBoxList.Items)
            {
                if (!arrayList.Contains(item.Value))
                {
                    item.Selected = false;
                }
                else
                {
                    item.Selected = true;
                }
            }
        }

        private ArrayList StringToArrayList(string value)
        {
            ArrayList arrayLists = new ArrayList();
            string[] strArrays = value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                arrayLists.Add(strArrays[i]);
            }
            return arrayLists;
        }
    }
}