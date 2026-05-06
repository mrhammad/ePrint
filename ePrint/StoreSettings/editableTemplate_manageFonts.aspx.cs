using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.StoreSettings
{
    public partial class editableTemplate_manageFonts : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public static long CompanyID;

        public static long UserID;

        public static BaseClass objbase;

        public static string strImagepath;

        public static string color;

        public static string type;

        public static languageClass objLanguage;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global objGlb = new Global();

        public BasePage objLog = new BasePage();

        public string colorformat = string.Empty;

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

        static editableTemplate_manageFonts()
        {
            editableTemplate_manageFonts.CompanyID = (long)0;
            editableTemplate_manageFonts.UserID = (long)0;
            editableTemplate_manageFonts.objbase = new BaseClass();
            editableTemplate_manageFonts.strImagepath = global.imagePath();
            editableTemplate_manageFonts.color = "";
            editableTemplate_manageFonts.type = "";
            editableTemplate_manageFonts.objLanguage = new languageClass();
        }

        public editableTemplate_manageFonts()
        {
        }

        protected void btn_Deleted_OnClick(object sender, EventArgs e)
        {
            if (editableTemplate_manageFonts.type.ToLower() == "font")
            {
                for (int i = 0; i < this.grdeditablefonts.Items.Count; i++)
                {
                    HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                    htmlInputCheckBox = (HtmlInputCheckBox)this.grdeditablefonts.Items[i].Cells[0].FindControl("Id");
                    if (htmlInputCheckBox.Checked)
                    {
                        SettingsBasePage.editabletemplate_fontstyle_delete(Convert.ToInt64(htmlInputCheckBox.Value));
                    }
                }
                this.grdeditablefonts.Rebind();
                base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Font_Style_Deleted_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            if (editableTemplate_manageFonts.type.ToLower() == "color")
            {
                for (int j = 0; j < this.grdeditablecolors.Items.Count; j++)
                {
                    HtmlInputCheckBox htmlInputCheckBox1 = new HtmlInputCheckBox();
                    htmlInputCheckBox1 = (HtmlInputCheckBox)this.grdeditablecolors.Items[j].Cells[0].FindControl("Id");
                    if (htmlInputCheckBox1.Checked)
                    {
                        SettingsBasePage.editabletemplate_colorstyle_delete(Convert.ToInt64(htmlInputCheckBox1.Value));
                    }
                }
                this.grdeditablecolors.Rebind();
                base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Color_Style_Deleted_Successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void btnapply_OnClick(object sender, EventArgs e)
        {
        }

        public void btnSavecmyk_onclick(object sender, EventArgs e)
        {
        }

        protected void grdeditablecolors_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)item.FindControl("txtcolorstyle");
            TextBox textBox1 = (TextBox)item.FindControl("txtspotcolor");
            TextBox textBox2 = (TextBox)item.FindControl("txttint");
            item.FindControl("RadColorPicker1");
            RadButton radButton = item.FindControl("btnToggle") as RadButton;
            TextBox textBox3 = (TextBox)item.FindControl("txtcyan");
            TextBox textBox4 = (TextBox)item.FindControl("txtmagenta");
            TextBox textBox5 = (TextBox)item.FindControl("txtyellow");
            TextBox textBox6 = (TextBox)item.FindControl("txtblack");
            if (this.hdnred.Value == "" && this.hdngreen.Value == "" && this.hdnblue.Value == "")
            {
                decimal num = Convert.ToDecimal(textBox3.Text);
                decimal num1 = Convert.ToDecimal(textBox4.Text);
                decimal num2 = Convert.ToDecimal(textBox5.Text);
                decimal num3 = Convert.ToDecimal(textBox6.Text);
                decimal num4 = num / new decimal(100);
                decimal num5 = num1 / new decimal(100);
                decimal num6 = num2 / new decimal(100);
                decimal num7 = num3 / new decimal(100);
                decimal num8 = new decimal(1) - Math.Min(new decimal(1), (num4 * (new decimal(1) - num7)) + num7);
                decimal num9 = new decimal(1) - Math.Min(new decimal(1), (num5 * (new decimal(1) - num7)) + num7);
                decimal num10 = new decimal(1) - Math.Min(new decimal(1), (num6 * (new decimal(1) - num7)) + num7);
                decimal num11 = Math.Round(num8 * new decimal(255));
                decimal num12 = Math.Round(num9 * new decimal(255));
                decimal num13 = Math.Round(num10 * new decimal(255));
                this.hdnred.Value = Convert.ToString(num11);
                this.hdngreen.Value = Convert.ToString(num12);
                this.hdnblue.Value = Convert.ToString(num13);
            }
            int num14 = 0;
            decimal num15 = new decimal(0);
            if (textBox2.Text != "")
            {
                num15 = Convert.ToDecimal(textBox2.Text);
            }
            if (radButton.Checked)
            {
                num14 = 1;
            }
            if (textBox.Text != "")
            {
                long num16 = (long)0;
                long userID = editableTemplate_manageFonts.UserID;
                long companyID = editableTemplate_manageFonts.CompanyID;
                string text = textBox.Text;
                string str = textBox3.Text;
                string text1 = textBox4.Text;
                string str1 = textBox5.Text;
                string text2 = textBox6.Text;
                decimal num17 = Convert.ToDecimal(this.hdnred.Value);
                decimal num18 = Convert.ToDecimal(this.hdngreen.Value);
                decimal num19 = Convert.ToDecimal(this.hdnblue.Value);
                Color selectedColor = this.RadColorPicker1.SelectedColor;
                SettingsBasePage.editabletemplate_colorstyle_insert(num16, userID, companyID, text, str, text1, str1, text2, num17, num18, num19, selectedColor.A, num15, num14, textBox1.Text);
                base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Color_style_saved_Successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void grdeditablecolors_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                HiddenField hiddenField = item.FindControl("hdn_pcval") as HiddenField;
                HiddenField hiddenField1 = item.FindControl("hdn_pmval") as HiddenField;
                HiddenField hiddenField2 = item.FindControl("hdn_pyval") as HiddenField;
                HiddenField hiddenField3 = item.FindControl("hdn_pkval") as HiddenField;
                item.FindControl("hdn_pr");
                item.FindControl("hdn_pg");
                item.FindControl("hdn_pB");
                item.FindControl("hdn_pa");
                Label label = (Label)item.FindControl("lblcmykcode");
                string[] value = new string[] { "(", hiddenField.Value, ",", hiddenField1.Value, ",", hiddenField2.Value, ",", hiddenField3.Value, ")" };
                label.Text = string.Concat(value);
                HiddenField hiddenField4 = item.FindControl("hdnspotColorRef") as HiddenField;
                Label label1 = (Label)item.FindControl("lblspotcolorname");
                if (hiddenField4.Value == "")
                {
                    label1.Text = "n/a";
                }
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem gridEditableItem = (GridEditableItem)e.Item;
                HiddenField hiddenField5 = gridEditableItem.FindControl("hdn_colorid") as HiddenField;
                TextBox textBox = (TextBox)gridEditableItem.FindControl("txtcolorstyle");
                HiddenField hiddenField6 = gridEditableItem.FindControl("hdn_r") as HiddenField;
                HiddenField hiddenField7 = gridEditableItem.FindControl("hdn_g") as HiddenField;
                HiddenField hiddenField8 = gridEditableItem.FindControl("hdn_B") as HiddenField;
                HiddenField hiddenField9 = gridEditableItem.FindControl("hdn_A") as HiddenField;
                HiddenField hiddenField10 = gridEditableItem.FindControl("hdn_cval") as HiddenField;
                HiddenField hiddenField11 = gridEditableItem.FindControl("hdn_mval") as HiddenField;
                HiddenField hiddenField12 = gridEditableItem.FindControl("hdn_yval") as HiddenField;
                HiddenField hiddenField13 = gridEditableItem.FindControl("hdn_kval") as HiddenField;
                HiddenField hiddenField14 = gridEditableItem.FindControl("hdn_chkspotcolor") as HiddenField;
                RadButton languageConversion = gridEditableItem.FindControl("btnToggle") as RadButton;
                gridEditableItem.FindControl("hdn_selectedcolor");
                TextBox black = (TextBox)gridEditableItem.FindControl("txtselectedcolor");
                TextBox value1 = (TextBox)gridEditableItem.FindControl("txtcyan");
                TextBox textBox1 = (TextBox)gridEditableItem.FindControl("txtmagenta");
                TextBox value2 = (TextBox)gridEditableItem.FindControl("txtyellow");
                TextBox textBox2 = (TextBox)gridEditableItem.FindControl("txtblack");
                TextBox textBox3 = (TextBox)gridEditableItem.FindControl("lblcyan");
                TextBox textBox4 = (TextBox)gridEditableItem.FindControl("lblmagenta");
                TextBox textBox5 = (TextBox)gridEditableItem.FindControl("lblyellow");
                TextBox textBox6 = (TextBox)gridEditableItem.FindControl("lblblack");
                LinkButton linkButton = (LinkButton)gridEditableItem.FindControl("lnkselectcolor");
                Label label2 = (Label)gridEditableItem.FindControl("lblerrormsg");
                languageConversion.Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Use_spot_color");
                languageConversion.Text = string.Concat(languageConversion.Text, this.colorformat);
                linkButton.Attributes.Add("onclick", string.Concat("javascript:showwindow('", hiddenField5.Value, "');return false;"));
                if (hiddenField5.Value == "")
                {
                    textBox.Attributes.Add("onblur", "javascript:validateduplicate(this,this.value,'add');");
                }
                else
                {
                    textBox.Attributes.Add("onblur", "javascript:validateduplicate(this,this.value,'edit');");
                }
                if (hiddenField14.Value.ToLower() == "true")
                {
                    languageConversion.Checked = true;
                }
                if (!(hiddenField9.Value != "") || !(hiddenField6.Value != "") || !(hiddenField7.Value != "") || !(hiddenField8.Value != ""))
                {
                    value1.Text = "0.00";
                    textBox1.Text = "0.00";
                    value2.Text = "0.00";
                    textBox2.Text = "100.00";
                    this.cgridid.Value = value1.ClientID;
                    this.mgridid.Value = textBox1.ClientID;
                    this.ygridid.Value = value2.ClientID;
                    this.kgridid.Value = textBox2.ClientID;
                    this.hdncolor.Value = black.ClientID;
                    black.BackColor = Color.Black;
                }
                else
                {
                    black.BackColor = Color.FromArgb(Convert.ToInt32(hiddenField9.Value), Convert.ToInt32(hiddenField6.Value), Convert.ToInt32(hiddenField7.Value), Convert.ToInt32(hiddenField8.Value));
                    this.RadColorPicker1.SelectedColor = Color.FromArgb(Convert.ToInt32(hiddenField9.Value), Convert.ToInt32(hiddenField6.Value), Convert.ToInt32(hiddenField7.Value), Convert.ToInt32(hiddenField8.Value));
                    value1.Text = hiddenField10.Value;
                    textBox1.Text = hiddenField11.Value;
                    value2.Text = hiddenField12.Value;
                    textBox2.Text = hiddenField13.Value;
                    this.cgrideditid.Value = value1.ClientID;
                    this.mgrideditid.Value = textBox1.ClientID;
                    this.ygrideditid.Value = value2.ClientID;
                    this.kgrideditid.Value = textBox2.ClientID;
                    this.hdncoloredit.Value = black.ClientID;
                }
            }
            this.colorpicker.Title = editableTemplate_manageFonts.objLanguage.convert(global.pageTitle(string.Concat(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Select"), " ", this.colorformat), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }

        protected void grdeditablecolors_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.editabletemplate_colorstyle_select(editableTemplate_manageFonts.CompanyID);
            this.grdeditablecolors.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    HiddenField hdnFontnames = this.hdn_fontnames;
                    string[] value = new string[] { this.hdn_fontnames.Value, dataTable.Rows[i]["ColorStyle"].ToString(), "~", dataTable.Rows[i]["ColorID"].ToString(), "," };
                    hdnFontnames.Value = string.Concat(value);
                }
            }
        }

        protected void grdeditablecolors_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            HiddenField hiddenField = item.FindControl("hdn_colorid") as HiddenField;
            TextBox textBox = (TextBox)item.FindControl("txtcolorstyle");
            TextBox textBox1 = (TextBox)item.FindControl("txtspotcolor");
            TextBox textBox2 = (TextBox)item.FindControl("txttint");
            item.FindControl("RadColorPicker1");
            RadButton radButton = item.FindControl("btnToggle") as RadButton;
            TextBox textBox3 = (TextBox)item.FindControl("txtcyan");
            TextBox textBox4 = (TextBox)item.FindControl("txtmagenta");
            TextBox textBox5 = (TextBox)item.FindControl("txtyellow");
            TextBox textBox6 = (TextBox)item.FindControl("txtblack");
            if (this.hdnred.Value == "" && this.hdngreen.Value == "" && this.hdnblue.Value == "")
            {
                decimal num = Convert.ToDecimal(textBox3.Text);
                decimal num1 = Convert.ToDecimal(textBox4.Text);
                decimal num2 = Convert.ToDecimal(textBox5.Text);
                decimal num3 = Convert.ToDecimal(textBox6.Text);
                decimal num4 = num / new decimal(100);
                decimal num5 = num1 / new decimal(100);
                decimal num6 = num2 / new decimal(100);
                decimal num7 = num3 / new decimal(100);
                decimal num8 = new decimal(1) - Math.Min(new decimal(1), (num4 * (new decimal(1) - num7)) + num7);
                decimal num9 = new decimal(1) - Math.Min(new decimal(1), (num5 * (new decimal(1) - num7)) + num7);
                decimal num10 = new decimal(1) - Math.Min(new decimal(1), (num6 * (new decimal(1) - num7)) + num7);
                decimal num11 = Math.Round(num8 * new decimal(255));
                decimal num12 = Math.Round(num9 * new decimal(255));
                decimal num13 = Math.Round(num10 * new decimal(255));
                this.hdnred.Value = Convert.ToString(num11);
                this.hdngreen.Value = Convert.ToString(num12);
                this.hdnblue.Value = Convert.ToString(num13);
            }
            int num14 = 0;
            decimal num15 = new decimal(0);
            if (textBox2.Text != "")
            {
                num15 = Convert.ToDecimal(textBox2.Text);
            }
            if (radButton.Checked)
            {
                num14 = 1;
            }
            if (textBox.Text != "")
            {
                long num16 = Convert.ToInt64(hiddenField.Value);
                long num17 = (long)0;
                long userID = editableTemplate_manageFonts.UserID;
                long companyID = editableTemplate_manageFonts.CompanyID;
                string text = textBox.Text;
                string str = textBox3.Text;
                string text1 = textBox4.Text;
                string str1 = textBox5.Text;
                string text2 = textBox6.Text;
                decimal num18 = Convert.ToDecimal(this.hdnred.Value);
                decimal num19 = Convert.ToDecimal(this.hdngreen.Value);
                decimal num20 = Convert.ToDecimal(this.hdnblue.Value);
                Color selectedColor = this.RadColorPicker1.SelectedColor;
                SettingsBasePage.editabletemplate_colorstyle_update(num16, num17, userID, companyID, text, str, text1, str1, text2, num18, num19, num20, selectedColor.A, num15, num14, textBox1.Text);
                base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Color_Style_updated_Successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void grdeditablefonts_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            TextBox textBox = (TextBox)item.FindControl("txtfontstyle");
            TextBox textBox1 = (TextBox)item.FindControl("txtsize");
            TextBox textBox2 = (TextBox)item.FindControl("txtindent");
            DropDownList dropDownList = (DropDownList)item.FindControl("ddlfontfamily");
            TextBox textBox3 = (TextBox)item.FindControl("txtmanualtracking");
            DropDownList dropDownList1 = (DropDownList)item.FindControl("ddlplusminus");
            DropDownList dropDownList2 = (DropDownList)item.FindControl("ddlunit");
            DropDownList dropDownList3 = (DropDownList)item.FindControl("ddldatatype");
            DropDownList dropDownList4 = (DropDownList)item.FindControl("radcomcapitalization");
            RadioButton radioButton = item.FindControl("rbdright") as RadioButton;
            RadioButton radioButton1 = item.FindControl("rdbleft") as RadioButton;
            RadioButton radioButton2 = item.FindControl("rdbcenter") as RadioButton;
            string str = "";
            string str1 = "";
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            if (textBox1.Text != "")
            {
                num = Convert.ToDecimal(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                num1 = Convert.ToDecimal(textBox2.Text);
            }
            if (textBox3.Text == "")
            {
                object[] value = new object[] { dropDownList1.SelectedItem.Value, ',', 0, ',', dropDownList2.SelectedItem.Value };
                str = string.Concat(value);
            }
            else
            {
                object[] objArray = new object[] { dropDownList1.SelectedItem.Value, ',', textBox3.Text, ',', dropDownList2.SelectedItem.Value };
                str = string.Concat(objArray);
            }
            if (radioButton.Checked)
            {
                str1 = "Right";
            }
            else if (radioButton1.Checked)
            {
                str1 = "Left";
            }
            else if (radioButton2.Checked)
            {
                str1 = "Center";
            }
            if (textBox.Text != "")
            {
                SettingsBasePage.editabletemplate_fontstyle_insert((long)0, editableTemplate_manageFonts.UserID, editableTemplate_manageFonts.CompanyID, textBox.Text, num, str, str1, num1, dropDownList4.SelectedItem.Value, dropDownList3.SelectedItem.Value, "", dropDownList.SelectedItem.Text);
                base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Font_Style_saved_successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void grdeditablefonts_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("img_default_value");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnIsUsed");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgbtnDelete");
                string value = hiddenField.Value;
                if (value == "True")
                {
                    htmlInputCheckBox.Disabled = true;
                    image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                    imageButton.Visible = false;
                }
                if (value == "False")
                {
                    imageButton.ImageUrl = string.Concat(global.imagePath(), "erase.png");
                }
            }
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem item = (GridEditableItem)e.Item;
                DropDownList dropDownList = (DropDownList)item.FindControl("ddlfontfamily");
                dropDownList.DataSource = SettingsBasePage.editabletemplate_fontfamily_select(editableTemplate_manageFonts.CompanyID);
                dropDownList.DataTextField = "FontName";
                dropDownList.DataValueField = "FontID";
                dropDownList.DataBind();
                HiddenField hiddenField1 = item.FindControl("hdn_FontID") as HiddenField;
                HiddenField hiddenField2 = item.FindControl("hdn_FontFamily") as HiddenField;
                HiddenField hiddenField3 = item.FindControl("hdn_ManualTracking") as HiddenField;
                HiddenField hiddenField4 = item.FindControl("hdn_Datatype") as HiddenField;
                HiddenField hiddenField5 = item.FindControl("hdn_Capitalization") as HiddenField;
                HiddenField hiddenField6 = item.FindControl("hdn_textalign") as HiddenField;
                RadioButton radioButton = item.FindControl("rbdright") as RadioButton;
                RadioButton radioButton1 = item.FindControl("rdbleft") as RadioButton;
                RadioButton radioButton2 = item.FindControl("rdbcenter") as RadioButton;
                DropDownList dropDownList1 = (DropDownList)item.FindControl("ddlfontfamily");
                TextBox textBox = (TextBox)item.FindControl("txtfontstyle");
                TextBox textBox1 = (TextBox)item.FindControl("txtsize");
                TextBox textBox2 = (TextBox)item.FindControl("txtindent");
                Button button = (Button)item.FindControl("btnsave");
                if (hiddenField1.Value == "")
                {
                    textBox.Attributes.Add("onblur", "javascript:validateduplicate(this,this.value,'add');");
                }
                else
                {
                    textBox.Attributes.Add("onblur", "javascript:validateduplicate(this,this.value,'edit');");
                }
                TextBox str = (TextBox)item.FindControl("txtmanualtracking");
                DropDownList dropDownList2 = (DropDownList)item.FindControl("ddlplusminus");
                DropDownList dropDownList3 = (DropDownList)item.FindControl("ddlunit");
                DropDownList dropDownList4 = (DropDownList)item.FindControl("ddldatatype");
                DropDownList dropDownList5 = (DropDownList)item.FindControl("radcomcapitalization");
                if (hiddenField6.Value == "")
                {
                    radioButton1.Checked = true;
                }
                else if (hiddenField6.Value.ToLower() == "left")
                {
                    radioButton1.Checked = true;
                }
                else if (hiddenField6.Value.ToLower() == "right")
                {
                    radioButton.Checked = true;
                }
                else if (hiddenField6.Value.ToLower() == "center")
                {
                    radioButton2.Checked = true;
                }
                if (hiddenField3.Value != "")
                {
                    string[] strArrays = hiddenField3.Value.Split(new char[] { ',' });
                    str.Text = strArrays[1].ToString();
                    base.SetDDLText(dropDownList2, strArrays[0].ToString());
                    base.SetDDLText(dropDownList3, strArrays[2].ToString());
                }
                base.SetDDLText(dropDownList1, hiddenField2.Value);
                base.SetDDLValue(dropDownList5, hiddenField5.Value);
                base.SetDDLValue(dropDownList4, hiddenField4.Value);
            }
        }

        protected void grdeditablefonts_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = SettingsBasePage.editabletemplate_fontstyles_select(editableTemplate_manageFonts.CompanyID);
            this.grdeditablefonts.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.hdn_fontnames.Value = string.Concat(this.hdn_fontnames.Value, dataTable.Rows[i]["FontStyle"].ToString(), ",");
                }
            }
        }

        protected void grdeditablefonts_OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.grdeditablefonts.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.grdeditablefonts.MasterTableView.ClearEditItems();
            }
        }

        protected void grdeditablefonts_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem item = e.Item as GridEditableItem;
            HiddenField hiddenField = item.FindControl("hdn_FontID") as HiddenField;
            TextBox textBox = (TextBox)item.FindControl("txtfontstyle");
            TextBox textBox1 = (TextBox)item.FindControl("txtsize");
            TextBox textBox2 = (TextBox)item.FindControl("txtindent");
            DropDownList dropDownList = (DropDownList)item.FindControl("ddlfontfamily");
            TextBox textBox3 = (TextBox)item.FindControl("txtmanualtracking");
            DropDownList dropDownList1 = (DropDownList)item.FindControl("ddlplusminus");
            DropDownList dropDownList2 = (DropDownList)item.FindControl("ddlunit");
            DropDownList dropDownList3 = (DropDownList)item.FindControl("ddldatatype");
            DropDownList dropDownList4 = (DropDownList)item.FindControl("radcomcapitalization");
            RadioButton radioButton = item.FindControl("rbdright") as RadioButton;
            RadioButton radioButton1 = item.FindControl("rdbleft") as RadioButton;
            RadioButton radioButton2 = item.FindControl("rdbcenter") as RadioButton;
            string str = "";
            string str1 = "";
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            if (textBox1.Text != "")
            {
                num = Convert.ToDecimal(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                num1 = Convert.ToDecimal(textBox2.Text);
            }
            if (textBox3.Text == "")
            {
                object[] value = new object[] { dropDownList1.SelectedItem.Value, ',', 0, ',', dropDownList2.SelectedItem.Value };
                str = string.Concat(value);
            }
            else
            {
                object[] objArray = new object[] { dropDownList1.SelectedItem.Value, ',', textBox3.Text, ',', dropDownList2.SelectedItem.Value };
                str = string.Concat(objArray);
            }
            if (radioButton.Checked)
            {
                str1 = "Right";
            }
            else if (radioButton1.Checked)
            {
                str1 = "Left";
            }
            else if (radioButton2.Checked)
            {
                str1 = "Center";
            }
            if (textBox.Text != "")
            {
                SettingsBasePage.editabletemplate_fontstyle_update(editableTemplate_manageFonts.CompanyID, num, str, str1, num1, dropDownList4.SelectedItem.Value, dropDownList3.SelectedItem.Value, "", dropDownList.SelectedItem.Text, textBox.Text, Convert.ToInt64(hiddenField.Value));
                base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Font_Style_updated_Successfully"), "msg-success", this.plhMessage);
            }
        }

        protected void imgbtncolorDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.editabletemplate_colorstyle_delete(Convert.ToInt64(e.CommandArgument));
            this.grdeditablecolors.Rebind();
            base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Color_Style_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            SettingsBasePage.editabletemplate_fontstyle_delete(Convert.ToInt64(e.CommandArgument));
            this.grdeditablefonts.Rebind();
            base.Message_Display(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Font_Style_Deleted_Successfully"), "msg-success", this.plhMessage);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.grdeditablefonts.FilterMenu;
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
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterMenu languageConversion = this.grdeditablecolors.FilterMenu;
            for (int j = filterMenu.Items.Count - 1; j >= 0; j--)
            {
                if (languageConversion.Items[j].Text == "Custom")
                {
                    languageConversion.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (languageConversion.Items[j].Text.ToLower() == "isempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "isnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "between")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notbetween")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "nofilter")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion.Items[j].Text.ToLower() == "contains")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion.Items[j].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion.Items[j].Text.ToLower() == "startswith")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "endswith")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.colorformat = this.objLog.GetRegionalSettings(int.Parse(this.Session["companyID"].ToString()), "colour");
            this.objGlb.setpagename("setting");
            editableTemplate_manageFonts.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"].ToString());
            editableTemplate_manageFonts.UserID = (long)Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.QueryString["type"] != null)
            {
                editableTemplate_manageFonts.type = base.Request.QueryString["type"].ToString();
            }
            if (editableTemplate_manageFonts.type.ToLower() == "font")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Manage_Font_Styles")));
                this.Page.Title = global.pageTitle("Manage Font Styles", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
                this.header_mis.SettingName = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Manage_Font_Styles");
            }
            else if (editableTemplate_manageFonts.type.ToLower() == "color")
            {
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("eStore_Settings"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Manage_Color_Styles"), this.colorformat));
                this.Page.Title = global.pageTitle("Manage Color Styles", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString());
                this.header_mis.SettingName = string.Concat(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Manage_Color_Styles"), this.colorformat);
            }
            if (editableTemplate_manageFonts.type.ToLower() == "font")
            {
                this.grdeditablecolors.Visible = false;
                this.lblheader.Text = string.Concat(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("eStore_Settings"), ": ", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Manage_Font_Styles"));
                this.lnkDeleteStatus.Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Detele_Selected");
                return;
            }
            if (editableTemplate_manageFonts.type.ToLower() == "color")
            {
                this.grdeditablefonts.Visible = false;
                this.lblheader.Text = string.Concat(editableTemplate_manageFonts.objLanguage.GetLanguageConversion("eStore_Settings"), ": ", editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Manage_Color_Styles"), this.colorformat);
                this.lnkDeleteStatus.Text = editableTemplate_manageFonts.objLanguage.GetLanguageConversion("Detele_Selected");
            }
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.grdeditablecolors.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.grdeditablecolors.MasterTableView.ClearEditItems();
            }
        }
    }
}