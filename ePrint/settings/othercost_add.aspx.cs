using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public partial class othercost_add : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSet = new SettingsBasePage();

        public commonClass objcom = new commonClass();

        private BasePage ObjPage = new BasePage();

        public int CompanyID;

        public int UserID;

        public long OtherCostID;

        public string pg = string.Empty;

        public string item = string.Empty;

        public string CalMethod = string.Empty;

        public string Action = string.Empty;

        public string Formula = string.Empty;

        public string Type = string.Empty;

        public string RedirectTo = string.Empty;

        public int ddlSelectSupID;

        public string strTemp = string.Empty;

        public string FormulaValue = string.Empty;

        public string FormulaKey = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public languageClass objlang = new languageClass();

        private string PaperMeasure = string.Empty;

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

        public othercost_add()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_view.aspx"));
        }

        protected void btnCategorySave_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.btnCategorySave.Text, "save", true) != 0)
            {
                string.Compare(this.btnCategorySave.Text, "update", true);
            }
            else
            {
                int num = SettingsBasePage.settings_othercostcategory_insert(this.CompanyID, (long)0, base.SpecialEncode(this.txtOtherCostCategoryName.Text), 0, this.ddlJobcardCategory.SelectedValue.ToString());
                this.hdn_CategortID.Value = num.ToString();
                if (num <= 0)
                {
                    for (int i = 0; i < this.ddlCategory.Items.Count; i++)
                    {
                        if (this.ddlCategory.Items[i].Text == base.ReplaceSingleQuote(this.txtOtherCostCategoryName.Text))
                        {
                            this.ddlCategory.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("select"), "---"));
                    this.ddlCategory.SelectedValue = num.ToString();
                }
            }
            this.txtOtherCostCategoryName.Text = "";
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_othercost_delete(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()));
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_view.aspx?su=de"));
        }

        public void btnSave_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnMatrixValueID.Value.Split(new char[] { '+' });
            if (this.hdn_supplierID.Value != "")
            {
                this.ddlSelectSupID = Convert.ToInt32(this.hdn_supplierID.Value);
            }
            else if (base.Request.QueryString["suplrid"] != null)
            {
                this.ddlSelectSupID = Convert.ToInt32(base.Request.QueryString["suplrid"]);
            }
            if (base.Request.Params["type"] == null)
            {
                this.txtPerHourCost.Text = (this.txtPerHourCost.Text == "" ? "0" : this.txtPerHourCost.Text);
                this.txtProfit.Text = (this.txtProfit.Text == "" ? "0" : this.txtProfit.Text);
                long num = SettingsBasePage.settings_othercost_insert(this.OtherCostID, this.CompanyID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlCalculation.SelectedValue.ToString(), Convert.ToInt64(this.hid_CostTimeBasedID.Value), Convert.ToInt32(this.ddlSupplier.SelectedValue), Convert.ToDecimal(this.txtPerHourCost.Text), Convert.ToDecimal(this.txtProfit.Text), Convert.ToDecimal(this.txtMinimum.Text), string.Concat("'", base.SpecialEncode(this.TextBox2.Text), "'"));
                if (this.ddlCalculation.SelectedValue == "m")
                {
                    int num1 = SettingsBasePage.settings_othercost_matrix_insert(num, this.ddlCalculation.SelectedValue, this.txtCol1.Text, this.txtCol2.Text, this.txtCol3.Text, this.txtCol4.Text, this.txtCol5.Text, this.txtCol6.Text, this.txtCol7.Text, this.txtCol8.Text, this.txtCol9.Text, this.txtCol10.Text, base.SpecialEncode(this.txtprompt.Text));
                    for (int i = 1; i < 21; i++)
                    {
                        TextBox textBox = (TextBox)this.div_table.FindControl(string.Concat("txtFrm", i.ToString()));
                        int num2 = 0;
                        if (i != 20)
                        {
                            TextBox textBox1 = (TextBox)this.div_table.FindControl(string.Concat("txtTo", i.ToString()));
                            num2 = Convert.ToInt32(textBox1.Text);
                        }
                        TextBox textBox2 = (TextBox)this.div_table.FindControl(string.Concat("txtA5", i.ToString()));
                        TextBox textBox3 = (TextBox)this.div_table.FindControl(string.Concat("txtA4", i.ToString()));
                        TextBox textBox4 = (TextBox)this.div_table.FindControl(string.Concat("txtA3", i.ToString()));
                        TextBox textBox5 = (TextBox)this.div_table.FindControl(string.Concat("txtA2", i.ToString()));
                        TextBox textBox6 = (TextBox)this.div_table.FindControl(string.Concat("txtA6", i.ToString()));
                        TextBox textBox7 = (TextBox)this.div_table.FindControl(string.Concat("txtA7", i.ToString()));
                        TextBox textBox8 = (TextBox)this.div_table.FindControl(string.Concat("txtA8", i.ToString()));
                        TextBox textBox9 = (TextBox)this.div_table.FindControl(string.Concat("txtA9", i.ToString()));
                        TextBox textBox10 = (TextBox)this.div_table.FindControl(string.Concat("txtA10", i.ToString()));
                        TextBox textBox11 = (TextBox)this.div_table.FindControl(string.Concat("txtA11", i.ToString()));
                        SettingsBasePage.settings_othercost_matrix_value_insert(num1, Convert.ToInt32(textBox.Text), num2, Convert.ToDecimal(textBox2.Text), Convert.ToDecimal(textBox3.Text), Convert.ToDecimal(textBox4.Text), Convert.ToDecimal(textBox5.Text), Convert.ToDecimal(textBox6.Text), Convert.ToDecimal(textBox7.Text), Convert.ToDecimal(textBox8.Text), Convert.ToDecimal(textBox9.Text), Convert.ToDecimal(textBox10.Text), Convert.ToDecimal(textBox11.Text));
                    }
                    string str = "";
                    string str1 = this.TextBox2.Text.Trim();
                    string empty = string.Empty;
                    foreach (DataRow row in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                    {
                        this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace("<<", " "));
                        this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace(">>", " "));
                        empty = this.TextBox2.Text.Replace(row["Value"].ToString(), row["Key"].ToString());
                    }
                    SettingsBasePage.settings_costformulabased_insert(this.CompanyID, (long)0, num, base.SpecialEncode(str), base.SpecialEncode(str1), base.SpecialEncode(empty));
                }
                else if (this.ddlCalculation.SelectedValue == "t")
                {
                    string empty1 = string.Empty;
                    empty1 = (this.rdlTimeCostType.SelectedValue != "m" ? "l" : "m");
                    this.hid_DefaultHourType.Value = (this.hid_DefaultHourType.Value == "0" ? "f" : this.hid_DefaultHourType.Value);
                    SettingsBasePage.settings_costtimebased_insert(this.CompanyID, num, Convert.ToInt64(this.hid_CostTimeBasedID.Value), Convert.ToDecimal(this.txtHourlyRate.Text), Convert.ToDecimal(this.txtMakeReadyTime.Text), Convert.ToDecimal(this.txtRunSpeed.Text), this.hid_DefaultHourType.Value, Convert.ToDecimal(this.txtFixedQty.Text), this.ddlVariableQty.SelectedValue, empty1);
                }
                else if (this.ddlCalculation.SelectedValue == "q")
                {
                    this.hid_QtyDefaultValueType.Value = (this.hid_QtyDefaultValueType.Value == "0" ? "f" : this.hid_QtyDefaultValueType.Value);
                    SettingsBasePage.settings_costquantitybased_insert(this.CompanyID, num, Convert.ToInt64(this.hid_CostTimeBasedID.Value), Convert.ToDecimal(this.txtQtyHourlyRate.Text), Convert.ToDecimal(this.txtQtyMakeReadyTime.Text), Convert.ToDecimal(this.txtQtyTimePerUnit.Text), Convert.ToDecimal(this.txtQtyUnitCost.Text), this.hid_QtyDefaultValueType.Value, Convert.ToDecimal(this.txtQtyFixedValue.Text), this.ddlQtyVariableValue.SelectedValue, Convert.ToBoolean(this.hid_IsMatrix.Value));
                }
                else if (this.ddlCalculation.SelectedValue == "f")
                {
                    string str2 = "";
                    string str3 = this.TextBox2.Text.Trim();
                    string empty2 = string.Empty;
                    foreach (DataRow dataRow in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                    {
                        this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace("<<", " "));
                        this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace(">>", " "));
                        empty2 = this.TextBox2.Text.Replace(dataRow["Value"].ToString(), dataRow["Key"].ToString());
                    }
                    SettingsBasePage.settings_costformulabased_insert(this.CompanyID, (long)0, num, base.SpecialEncode(str2), base.SpecialEncode(str3), base.SpecialEncode(empty2));
                }
                if (this.AccountingCode == "d")
                {
                    SettingsBasePage.OtherCost_AccountingCode_Insert((long)this.CompanyID, num, int.Parse(this.ddlAccountCode.SelectedValue));
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_view.aspx?su=in"));
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                this.txtPerHourCost.Text = (this.txtPerHourCost.Text == "" ? "0" : this.txtPerHourCost.Text);
                this.txtProfit.Text = (this.txtProfit.Text == "" ? "0" : this.txtProfit.Text);
                long num3 = SettingsBasePage.settings_othercost_insert(Convert.ToInt64(base.Request.Params["id"].ToString()), this.CompanyID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.hid_CalculationType.Value, Convert.ToInt64(this.hid_CostTimeBasedID.Value), Convert.ToInt32(this.ddlSupplier.SelectedValue), Convert.ToDecimal(this.txtPerHourCost.Text), Convert.ToDecimal(this.txtProfit.Text), Convert.ToDecimal(this.txtMinimum.Text), string.Concat("'", base.SpecialEncode(this.TextBox2.Text), "'"));
                if (num3 != (long)-1)
                {
                    if (this.AccountingCode == "d")
                    {
                        SettingsBasePage.OtherCost_AccountingCode_Insert((long)this.CompanyID, num3, int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (this.hid_CalculationType.Value == "m")
                    {
                        SettingsBasePage.settings_othercost_matrix_update(Convert.ToInt32(this.hdnMatrixHeadingID.Value), this.ddlCalculation.SelectedValue, this.txtCol1.Text, this.txtCol2.Text, this.txtCol3.Text, this.txtCol4.Text, this.txtCol5.Text, this.txtCol6.Text, this.txtCol7.Text, this.txtCol8.Text, this.txtCol9.Text, this.txtCol10.Text, base.SpecialEncode(this.txtprompt.Text));
                        int num4 = 0;
                        for (int j = 1; j < 21; j++)
                        {
                            num4 = j - 1;
                            TextBox textBox12 = (TextBox)this.div_table.FindControl(string.Concat("txtFrm", j.ToString()));
                            int num5 = 0;
                            if (j != 20)
                            {
                                TextBox textBox13 = (TextBox)this.div_table.FindControl(string.Concat("txtTo", j.ToString()));
                                num5 = Convert.ToInt32(textBox13.Text);
                            }
                            TextBox textBox14 = (TextBox)this.div_table.FindControl(string.Concat("txtA5", j.ToString()));
                            TextBox textBox15 = (TextBox)this.div_table.FindControl(string.Concat("txtA4", j.ToString()));
                            TextBox textBox16 = (TextBox)this.div_table.FindControl(string.Concat("txtA3", j.ToString()));
                            TextBox textBox17 = (TextBox)this.div_table.FindControl(string.Concat("txtA2", j.ToString()));
                            TextBox textBox18 = (TextBox)this.div_table.FindControl(string.Concat("txtA6", j.ToString()));
                            TextBox textBox19 = (TextBox)this.div_table.FindControl(string.Concat("txtA7", j.ToString()));
                            TextBox textBox20 = (TextBox)this.div_table.FindControl(string.Concat("txtA8", j.ToString()));
                            TextBox textBox21 = (TextBox)this.div_table.FindControl(string.Concat("txtA9", j.ToString()));
                            TextBox textBox22 = (TextBox)this.div_table.FindControl(string.Concat("txtA10", j.ToString()));
                            TextBox textBox23 = (TextBox)this.div_table.FindControl(string.Concat("txtA11", j.ToString()));
                            if (Convert.ToInt32(strArrays[num4]) != 0)
                            {
                                SettingsBasePage.settings_othercost_matrix_value_update(Convert.ToInt32(strArrays[num4]), Convert.ToInt32(textBox12.Text), num5, Convert.ToDecimal(textBox14.Text), Convert.ToDecimal(textBox15.Text), Convert.ToDecimal(textBox16.Text), Convert.ToDecimal(textBox17.Text), Convert.ToDecimal(textBox18.Text), Convert.ToDecimal(textBox19.Text), Convert.ToDecimal(textBox20.Text), Convert.ToDecimal(textBox21.Text), Convert.ToDecimal(textBox22.Text), Convert.ToDecimal(textBox23.Text));
                            }
                            else
                            {
                                SettingsBasePage.settings_othercost_matrix_value_insert(Convert.ToInt32(this.hdnMatrixHeadingID.Value), Convert.ToInt32(textBox12.Text), num5, Convert.ToDecimal(textBox14.Text), Convert.ToDecimal(textBox15.Text), Convert.ToDecimal(textBox16.Text), Convert.ToDecimal(textBox17.Text), Convert.ToDecimal(textBox18.Text), Convert.ToDecimal(textBox19.Text), Convert.ToDecimal(textBox20.Text), Convert.ToDecimal(textBox21.Text), Convert.ToDecimal(textBox22.Text), Convert.ToDecimal(textBox23.Text));
                            }
                        }
                        string str4 = "";
                        string str5 = this.TextBox2.Text.Trim();
                        string empty3 = string.Empty;
                        foreach (DataRow row1 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                        {
                            this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace("<<", " "));
                            this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace(">>", " "));
                            empty3 = this.TextBox2.Text.Replace(row1["Value"].ToString(), row1["Key"].ToString());
                        }
                        SettingsBasePage.settings_costformulabased_insert(this.CompanyID, Convert.ToInt64(this.hid_CostTimeBasedID.Value), num3, base.SpecialEncode(str4), base.SpecialEncode(str5), base.SpecialEncode(empty3));
                    }
                    else if (this.hid_CalculationType.Value == "t")
                    {
                        string empty4 = string.Empty;
                        empty4 = (this.rdlTimeCostType.SelectedValue != "m" ? "l" : "m");
                        SettingsBasePage.settings_costtimebased_insert(this.CompanyID, num3, Convert.ToInt64(this.hid_CostTimeBasedID.Value), Convert.ToDecimal(this.txtHourlyRate.Text), Convert.ToDecimal(this.txtMakeReadyTime.Text), Convert.ToDecimal(this.txtRunSpeed.Text), this.hid_DefaultHourType.Value, Convert.ToDecimal(this.txtFixedQty.Text), this.ddlVariableQty.SelectedValue, empty4);
                    }
                    else if (this.hid_CalculationType.Value == "q")
                    {
                        this.hid_QtyDefaultValueType.Value = (this.hid_QtyDefaultValueType.Value == "0" ? "f" : this.hid_QtyDefaultValueType.Value);
                        SettingsBasePage.settings_costquantitybased_insert(this.CompanyID, num3, Convert.ToInt64(this.hid_CostTimeBasedID.Value), Convert.ToDecimal(this.txtQtyHourlyRate.Text), Convert.ToDecimal(this.txtQtyMakeReadyTime.Text), Convert.ToDecimal(this.txtQtyTimePerUnit.Text), Convert.ToDecimal(this.txtQtyUnitCost.Text), this.hid_QtyDefaultValueType.Value, Convert.ToDecimal(this.txtQtyFixedValue.Text), this.ddlQtyVariableValue.SelectedValue, Convert.ToBoolean(this.hid_IsMatrix.Value));
                    }
                    else if (this.hid_CalculationType.Value == "f")
                    {
                        string str6 = "";
                        string str7 = this.TextBox2.Text.Trim();
                        string empty5 = string.Empty;
                        foreach (DataRow dataRow1 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                        {
                            string str8 = dataRow1["Value"].ToString();
                            string str9 = dataRow1["Key"].ToString();
                            this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace("<<", " "));
                            this.TextBox2.Text = base.SpecialDecode(this.TextBox2.Text.Replace(">>", " "));
                            empty5 = this.TextBox2.Text.Replace(str8, str9);
                        }
                        SettingsBasePage.settings_costformulabased_insert(this.CompanyID, Convert.ToInt64(this.hid_CostTimeBasedID.Value), num3, base.SpecialEncode(str6), base.SpecialEncode(str7), base.SpecialEncode(empty5));
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "settings/othercost_view.aspx?su=up"));
                    return;
                }
            }
        }

        [WebMethod]
        public static int FindDuplicate(string parall)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = parall.Split(new char[] { '±' });
            int num = Convert.ToInt32(strArrays[0]);
            string str = baseClass.ReplaceSingleQuote(strArrays[1]);
            long num1 = Convert.ToInt64(strArrays[2]);
            return SettingsBasePage.settings_othercostduplicacy_check(num, str, num1);
        }

        [WebMethod]
        public static int FindDuplicateCategory(string parall)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = parall.Split(new char[] { '&' });
            int num = Convert.ToInt32(strArrays[0]);
            string str = baseClass.ReplaceSingleQuote(strArrays[1]);
            long num1 = Convert.ToInt64(strArrays[2]);
            return SettingsBasePage.settings_othercost_categoryduplicacy_check(num, str, num1);
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (base.Request.Params["type"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "client/client_add.aspx?type=Supplier&post=othercost"));
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                HttpResponse response = base.Response;
                string[] lower = new string[] { this.strSitepath, "client/client_add.aspx?type=Supplier&post=othercost&mode=", base.Request.Params["type"].ToString().ToLower(), "&id=", base.Request.Params["id"].ToString() };
                response.Redirect(string.Concat(lower));
                return;
            }
        }

        protected void OnClick_lnkCategoryDelete(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.hid_CategoryID.Value);
            if (num != 0)
            {
                SettingsBasePage.settings_othercostcategory_delete(this.CompanyID, (long)num);
                this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("select"), "---"));
                this.ddlCategory.SelectedIndex = 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] count;
            long num;
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimage(this.id,'div_btncancelprocess');");
            this.rdldefaultQty.Text = this.objlang.GetValueOnLang("Fixed Hours");
            if (!base.IsPostBack)
            {
                this.txtCol1.Text = this.objLanguage.GetLanguageConversion("Selection_A");
                this.txtCol2.Text = this.objLanguage.GetLanguageConversion("SelectionB");
                this.txtCol3.Text = this.objLanguage.GetLanguageConversion("SelectionC");
                this.txtCol4.Text = this.objLanguage.GetLanguageConversion("SelectionD");
                this.txtCol5.Text = this.objLanguage.GetLanguageConversion("SelectionE");
                this.txtCol6.Text = this.objLanguage.GetLanguageConversion("SelectionF");
                this.txtCol7.Text = this.objLanguage.GetLanguageConversion("SelectionG");
                this.txtCol8.Text = this.objLanguage.GetLanguageConversion("SelectionH");
                this.txtCol9.Text = this.objLanguage.GetLanguageConversion("SelectionI");
                this.txtCol10.Text = this.objLanguage.GetLanguageConversion("SelectionJ");
            }
            this.btnSave.Text = this.objlang.GetValueOnLang("SaveH");
            this.ddlJobcardCategory.Items[0].Text = this.objLanguage.GetLanguageConversion("Pre_Press");
            this.ddlJobcardCategory.Items[1].Text = this.objLanguage.GetLanguageConversion("Press");
            this.ddlJobcardCategory.Items[2].Text = this.objLanguage.GetLanguageConversion("Post_Press");
            this.ddlJobcardCategory.Items[3].Text = this.objLanguage.GetLanguageConversion("Admin");
            this.ddlCalculation.Items[0].Text = string.Concat("--- ", this.objLanguage.GetLanguageConversion("Select"), " ---");
            this.ddlCalculation.Items[1].Text = this.objLanguage.GetLanguageConversion("Formula_Base");
            this.ddlCalculation.Items[2].Text = this.objLanguage.GetLanguageConversion("Formula_Based_Matrix_Table");
            this.ddlCalculation.Items[3].Text = this.objLanguage.GetLanguageConversion("Quantity_Based");
            this.ddlCalculation.Items[4].Text = this.objLanguage.GetLanguageConversion("Time_Based");
            this.rdlTimeCostType.Items[0].Text = this.objLanguage.GetLanguageConversion("Machine_Labour");
            this.rdlTimeCostType.Items[1].Text = this.objLanguage.GetLanguageConversion("Labour_Only");
            this.ddlVariableQty.Items[0].Text = this.objLanguage.GetLanguageConversion("Select");
            this.ddlVariableQty.Items[1].Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Qty_excl_Spoilage_Hourly_Run_Speed");
            this.ddlVariableQty.Items[2].Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Qty_incl_Spoilage_Hourly_Run_Speed");
            this.ddlVariableQty.Items[3].Text = this.objLanguage.GetLanguageConversion("Finished_Item_Qty_Hourly_Run_Speed");
            this.ddlVariableQty.Items[4].Text = this.objLanguage.GetLanguageConversion("Width_of_Unfolded_Finished_Item_Size/Hourly_Run_Speed");
            this.ddlVariableQty.Items[5].Text = this.objLanguage.GetLanguageConversion("Height_of_Unfolded_Finished_Item_Size/Hourly_Run_Speed");

            this.ddlQtyVariableValue.Items[0].Text = this.objLanguage.GetLanguageConversion("Select");
            this.ddlQtyVariableValue.Items[1].Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Qty_excl_Spoilage");
            this.ddlQtyVariableValue.Items[2].Text = this.objLanguage.GetLanguageConversion("Print_Sheet_Qty_incl_Spoilage");
            this.ddlQtyVariableValue.Items[3].Text = this.objLanguage.GetLanguageConversion("Finished_Item_Qty");
            this.rdlQtyDefaultValue.Items[0].Text = this.objLanguage.GetLanguageConversion("Fixed_Value");
            this.rdlQtyDefaultValue.Items[1].Text = this.objLanguage.GetLanguageConversion("Variable_Value");
            this.btnCancelMatrix.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSaveMatrix.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnDelete.Text = this.objLanguage.GetLanguageConversion("Delete");
            this.btnCategorySave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.txtName.Focus();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>&nbsp;>&nbsp;<a href=../settings/othercost_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Other_Costs_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("OtherCost_AddHeader")));
            base.Title = this.objLanguage.convert(global.pageTitle("Other Cost Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("OtherCost_Add");
            this.txtPerHourCost.Attributes.Add("style", "text-align:right");
            this.txtMinimum.Attributes.Add("style", "text-align:right");
            this.txtHourlyRate.Attributes.Add("style", "text-align:right");
            this.txtMakeReadyTime.Attributes.Add("style", "text-align:right");
            this.txtQtyTimePerUnit.Attributes.Add("style", "text-align:right");
            this.txtQtyUnitCost.Attributes.Add("style", "text-align:right");
            this.txtQtyHourlyRate.Attributes.Add("style", "text-align:right");
            this.txtQtyMakeReadyTime.Attributes.Add("style", "text-align:right");
            this.txtRunSpeed.Attributes.Add("style", "text-align:right");
            this.txtProfit.Attributes.Add("style", "text-align:right");
            this.txtFixedQty.Attributes.Add("style", "text-align:right");
            this.txtQtyFixedValue.Attributes.Add("style", "text-align:right");
            this.txtPerHourCost.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtPerHourCost.Text.ToString()), 0, "", false, false, false, 3);
            this.txtMinimum.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMinimum.Text.ToString()), 0, "", false, false, false, 3);
            this.txtHourlyRate.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtHourlyRate.Text.ToString()), 0, "", false, false, false, 3);
            this.txtMakeReadyTime.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtMakeReadyTime.Text.ToString()), 0, "", false, false, false, 3);
            this.txtQtyTimePerUnit.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtQtyTimePerUnit.Text.ToString()), 0, "", false, false, false, 3);
            this.txtQtyUnitCost.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtQtyUnitCost.Text.ToString()), 0, "", false, false, false, 3);
            this.txtQtyHourlyRate.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtQtyHourlyRate.Text.ToString()), 0, "", false, false, false, 3);
            this.txtQtyMakeReadyTime.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtQtyMakeReadyTime.Text.ToString()), 0, "", false, false, false, 3);
            this.txtRunSpeed.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtRunSpeed.Text.ToString()), 0, "", false, false, false, 3);
            this.txtA51.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA51.Text.ToString()), 3, "", false, false, false);
            this.txtA41.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA41.Text.ToString()), 3, "", false, false, false);
            this.txtA31.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA31.Text.ToString()), 3, "", false, false, false);
            this.txtA21.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA21.Text.ToString()), 3, "", false, false, false);
            this.txtA61.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA61.Text.ToString()), 3, "", false, false, false);
            this.txtA71.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA71.Text.ToString()), 3, "", false, false, false);
            this.txtA81.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA81.Text.ToString()), 3, "", false, false, false);
            this.txtA91.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA91.Text.ToString()), 3, "", false, false, false);
            this.txtA101.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA101.Text.ToString()), 3, "", false, false, false);
            this.txtA111.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA111.Text.ToString()), 3, "", false, false, false);
            this.txtA52.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA52.Text.ToString()), 3, "", false, false, false);
            this.txtA42.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA42.Text.ToString()), 3, "", false, false, false);
            this.txtA32.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA32.Text.ToString()), 3, "", false, false, false);
            this.txtA22.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA22.Text.ToString()), 3, "", false, false, false);
            this.txtA62.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA62.Text.ToString()), 3, "", false, false, false);
            this.txtA72.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA72.Text.ToString()), 3, "", false, false, false);
            this.txtA82.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA82.Text.ToString()), 3, "", false, false, false);
            this.txtA92.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA92.Text.ToString()), 3, "", false, false, false);
            this.txtA102.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA102.Text.ToString()), 3, "", false, false, false);
            this.txtA112.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA112.Text.ToString()), 3, "", false, false, false);
            this.txtA53.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA53.Text.ToString()), 3, "", false, false, false);
            this.txtA43.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA43.Text.ToString()), 3, "", false, false, false);
            this.txtA33.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA33.Text.ToString()), 3, "", false, false, false);
            this.txtA23.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA23.Text.ToString()), 3, "", false, false, false);
            this.txtA63.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA63.Text.ToString()), 3, "", false, false, false);
            this.txtA73.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA73.Text.ToString()), 3, "", false, false, false);
            this.txtA83.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA83.Text.ToString()), 3, "", false, false, false);
            this.txtA93.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA93.Text.ToString()), 3, "", false, false, false);
            this.txtA103.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA103.Text.ToString()), 3, "", false, false, false);
            this.txtA113.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA113.Text.ToString()), 3, "", false, false, false);
            this.txtA54.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA54.Text.ToString()), 3, "", false, false, false);
            this.txtA44.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA44.Text.ToString()), 3, "", false, false, false);
            this.txtA34.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA34.Text.ToString()), 3, "", false, false, false);
            this.txtA24.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA24.Text.ToString()), 3, "", false, false, false);
            this.txtA64.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA64.Text.ToString()), 3, "", false, false, false);
            this.txtA74.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA74.Text.ToString()), 3, "", false, false, false);
            this.txtA84.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA84.Text.ToString()), 3, "", false, false, false);
            this.txtA94.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA94.Text.ToString()), 3, "", false, false, false);
            this.txtA104.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA104.Text.ToString()), 3, "", false, false, false);
            this.txtA114.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA114.Text.ToString()), 3, "", false, false, false);
            this.txtA55.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA55.Text.ToString()), 3, "", false, false, false);
            this.txtA45.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA45.Text.ToString()), 3, "", false, false, false);
            this.txtA35.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA35.Text.ToString()), 3, "", false, false, false);
            this.txtA25.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA25.Text.ToString()), 3, "", false, false, false);
            this.txtA65.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA65.Text.ToString()), 3, "", false, false, false);
            this.txtA75.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA75.Text.ToString()), 3, "", false, false, false);
            this.txtA85.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA85.Text.ToString()), 3, "", false, false, false);
            this.txtA95.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA95.Text.ToString()), 3, "", false, false, false);
            this.txtA105.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA105.Text.ToString()), 3, "", false, false, false);
            this.txtA115.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA115.Text.ToString()), 3, "", false, false, false);
            this.txtA56.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA56.Text.ToString()), 3, "", false, false, false);
            this.txtA46.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA46.Text.ToString()), 3, "", false, false, false);
            this.txtA36.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA36.Text.ToString()), 3, "", false, false, false);
            this.txtA26.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA26.Text.ToString()), 3, "", false, false, false);
            this.txtA66.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA66.Text.ToString()), 3, "", false, false, false);
            this.txtA76.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA76.Text.ToString()), 3, "", false, false, false);
            this.txtA86.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA86.Text.ToString()), 3, "", false, false, false);
            this.txtA96.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA96.Text.ToString()), 3, "", false, false, false);
            this.txtA106.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA106.Text.ToString()), 3, "", false, false, false);
            this.txtA116.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA116.Text.ToString()), 3, "", false, false, false);
            this.txtA57.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA57.Text.ToString()), 3, "", false, false, false);
            this.txtA47.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA47.Text.ToString()), 3, "", false, false, false);
            this.txtA37.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA37.Text.ToString()), 3, "", false, false, false);
            this.txtA27.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA27.Text.ToString()), 3, "", false, false, false);
            this.txtA67.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA67.Text.ToString()), 3, "", false, false, false);
            this.txtA77.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA77.Text.ToString()), 3, "", false, false, false);
            this.txtA87.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA87.Text.ToString()), 3, "", false, false, false);
            this.txtA97.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA97.Text.ToString()), 3, "", false, false, false);
            this.txtA107.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA107.Text.ToString()), 3, "", false, false, false);
            this.txtA117.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA117.Text.ToString()), 3, "", false, false, false);
            this.txtA58.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA58.Text.ToString()), 3, "", false, false, false);
            this.txtA48.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA48.Text.ToString()), 3, "", false, false, false);
            this.txtA38.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA38.Text.ToString()), 3, "", false, false, false);
            this.txtA28.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA28.Text.ToString()), 3, "", false, false, false);
            this.txtA68.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA68.Text.ToString()), 3, "", false, false, false);
            this.txtA78.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA78.Text.ToString()), 3, "", false, false, false);
            this.txtA88.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA88.Text.ToString()), 3, "", false, false, false);
            this.txtA98.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA98.Text.ToString()), 3, "", false, false, false);
            this.txtA108.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA108.Text.ToString()), 3, "", false, false, false);
            this.txtA118.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA118.Text.ToString()), 3, "", false, false, false);
            this.txtA59.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA59.Text.ToString()), 3, "", false, false, false);
            this.txtA49.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA49.Text.ToString()), 3, "", false, false, false);
            this.txtA39.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA39.Text.ToString()), 3, "", false, false, false);
            this.txtA29.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA29.Text.ToString()), 3, "", false, false, false);
            this.txtA69.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA69.Text.ToString()), 3, "", false, false, false);
            this.txtA79.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA79.Text.ToString()), 3, "", false, false, false);
            this.txtA89.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA89.Text.ToString()), 3, "", false, false, false);
            this.txtA99.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA99.Text.ToString()), 3, "", false, false, false);
            this.txtA109.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA109.Text.ToString()), 3, "", false, false, false);
            this.txtA119.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA119.Text.ToString()), 3, "", false, false, false);
            this.txtA510.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA510.Text.ToString()), 3, "", false, false, false);
            this.txtA410.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA410.Text.ToString()), 3, "", false, false, false);
            this.txtA310.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA310.Text.ToString()), 3, "", false, false, false);
            this.txtA210.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA210.Text.ToString()), 3, "", false, false, false);
            this.txtA610.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA610.Text.ToString()), 3, "", false, false, false);
            this.txtA710.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA710.Text.ToString()), 3, "", false, false, false);
            this.txtA810.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA810.Text.ToString()), 3, "", false, false, false);
            this.txtA910.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA910.Text.ToString()), 3, "", false, false, false);
            this.txtA1010.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1010.Text.ToString()), 3, "", false, false, false);
            this.txtA1110.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1110.Text.ToString()), 3, "", false, false, false);
            this.txtA511.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA511.Text.ToString()), 3, "", false, false, false);
            this.txtA411.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA411.Text.ToString()), 3, "", false, false, false);
            this.txtA311.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA311.Text.ToString()), 3, "", false, false, false);
            this.txtA211.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA211.Text.ToString()), 3, "", false, false, false);
            this.txtA611.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA611.Text.ToString()), 3, "", false, false, false);
            this.txtA711.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA711.Text.ToString()), 3, "", false, false, false);
            this.txtA811.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA811.Text.ToString()), 3, "", false, false, false);
            this.txtA911.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA911.Text.ToString()), 3, "", false, false, false);
            this.txtA1011.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1011.Text.ToString()), 3, "", false, false, false);
            this.txtA1111.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1111.Text.ToString()), 3, "", false, false, false);
            this.txtA512.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA512.Text.ToString()), 3, "", false, false, false);
            this.txtA412.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA412.Text.ToString()), 3, "", false, false, false);
            this.txtA312.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA312.Text.ToString()), 3, "", false, false, false);
            this.txtA212.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA212.Text.ToString()), 3, "", false, false, false);
            this.txtA612.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA612.Text.ToString()), 3, "", false, false, false);
            this.txtA712.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA712.Text.ToString()), 3, "", false, false, false);
            this.txtA812.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA812.Text.ToString()), 3, "", false, false, false);
            this.txtA912.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA912.Text.ToString()), 3, "", false, false, false);
            this.txtA1012.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1012.Text.ToString()), 3, "", false, false, false);
            this.txtA1112.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1112.Text.ToString()), 3, "", false, false, false);
            this.txtA513.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA513.Text.ToString()), 3, "", false, false, false);
            this.txtA413.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA413.Text.ToString()), 3, "", false, false, false);
            this.txtA313.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA313.Text.ToString()), 3, "", false, false, false);
            this.txtA213.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA213.Text.ToString()), 3, "", false, false, false);
            this.txtA613.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA613.Text.ToString()), 3, "", false, false, false);
            this.txtA713.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA713.Text.ToString()), 3, "", false, false, false);
            this.txtA813.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA813.Text.ToString()), 3, "", false, false, false);
            this.txtA913.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA913.Text.ToString()), 3, "", false, false, false);
            this.txtA1013.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1013.Text.ToString()), 3, "", false, false, false);
            this.txtA1113.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1113.Text.ToString()), 3, "", false, false, false);
            this.txtA514.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA514.Text.ToString()), 3, "", false, false, false);
            this.txtA414.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA414.Text.ToString()), 3, "", false, false, false);
            this.txtA314.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA314.Text.ToString()), 3, "", false, false, false);
            this.txtA214.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA214.Text.ToString()), 3, "", false, false, false);
            this.txtA614.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA614.Text.ToString()), 3, "", false, false, false);
            this.txtA714.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA714.Text.ToString()), 3, "", false, false, false);
            this.txtA814.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA814.Text.ToString()), 3, "", false, false, false);
            this.txtA914.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA914.Text.ToString()), 3, "", false, false, false);
            this.txtA1014.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1014.Text.ToString()), 3, "", false, false, false);
            this.txtA1114.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1114.Text.ToString()), 3, "", false, false, false);
            this.txtA515.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA515.Text.ToString()), 3, "", false, false, false);
            this.txtA415.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA415.Text.ToString()), 3, "", false, false, false);
            this.txtA315.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA315.Text.ToString()), 3, "", false, false, false);
            this.txtA215.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA215.Text.ToString()), 3, "", false, false, false);
            this.txtA615.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA615.Text.ToString()), 3, "", false, false, false);
            this.txtA715.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA715.Text.ToString()), 3, "", false, false, false);
            this.txtA815.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA815.Text.ToString()), 3, "", false, false, false);
            this.txtA915.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA915.Text.ToString()), 3, "", false, false, false);
            this.txtA1015.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1015.Text.ToString()), 3, "", false, false, false);
            this.txtA1115.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1115.Text.ToString()), 3, "", false, false, false);
            this.txtA516.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA516.Text.ToString()), 3, "", false, false, false);
            this.txtA416.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA416.Text.ToString()), 3, "", false, false, false);
            this.txtA316.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA316.Text.ToString()), 3, "", false, false, false);
            this.txtA216.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA216.Text.ToString()), 3, "", false, false, false);
            this.txtA616.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA616.Text.ToString()), 3, "", false, false, false);
            this.txtA716.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA716.Text.ToString()), 3, "", false, false, false);
            this.txtA816.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA816.Text.ToString()), 3, "", false, false, false);
            this.txtA916.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA916.Text.ToString()), 3, "", false, false, false);
            this.txtA1016.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1016.Text.ToString()), 3, "", false, false, false);
            this.txtA1116.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1116.Text.ToString()), 3, "", false, false, false);
            this.txtA517.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA517.Text.ToString()), 3, "", false, false, false);
            this.txtA417.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA417.Text.ToString()), 3, "", false, false, false);
            this.txtA317.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA317.Text.ToString()), 3, "", false, false, false);
            this.txtA217.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA217.Text.ToString()), 3, "", false, false, false);
            this.txtA617.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA617.Text.ToString()), 3, "", false, false, false);
            this.txtA717.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA717.Text.ToString()), 3, "", false, false, false);
            this.txtA817.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA817.Text.ToString()), 3, "", false, false, false);
            this.txtA917.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA917.Text.ToString()), 3, "", false, false, false);
            this.txtA1017.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1017.Text.ToString()), 3, "", false, false, false);
            this.txtA1117.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1117.Text.ToString()), 3, "", false, false, false);
            this.txtA518.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA518.Text.ToString()), 3, "", false, false, false);
            this.txtA418.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA418.Text.ToString()), 3, "", false, false, false);
            this.txtA318.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA318.Text.ToString()), 3, "", false, false, false);
            this.txtA218.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA218.Text.ToString()), 3, "", false, false, false);
            this.txtA618.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA618.Text.ToString()), 3, "", false, false, false);
            this.txtA718.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA718.Text.ToString()), 3, "", false, false, false);
            this.txtA818.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA818.Text.ToString()), 3, "", false, false, false);
            this.txtA918.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA918.Text.ToString()), 3, "", false, false, false);
            this.txtA1018.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1018.Text.ToString()), 3, "", false, false, false);
            this.txtA1118.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1118.Text.ToString()), 3, "", false, false, false);
            this.txtA519.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA519.Text.ToString()), 3, "", false, false, false);
            this.txtA419.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA419.Text.ToString()), 3, "", false, false, false);
            this.txtA319.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA319.Text.ToString()), 3, "", false, false, false);
            this.txtA219.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA219.Text.ToString()), 3, "", false, false, false);
            this.txtA619.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA619.Text.ToString()), 3, "", false, false, false);
            this.txtA719.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA719.Text.ToString()), 3, "", false, false, false);
            this.txtA819.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA819.Text.ToString()), 3, "", false, false, false);
            this.txtA919.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA919.Text.ToString()), 3, "", false, false, false);
            this.txtA1019.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1019.Text.ToString()), 3, "", false, false, false);
            this.txtA1119.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1119.Text.ToString()), 3, "", false, false, false);
            this.txtA520.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA520.Text.ToString()), 3, "", false, false, false);
            this.txtA420.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA420.Text.ToString()), 3, "", false, false, false);
            this.txtA320.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA320.Text.ToString()), 3, "", false, false, false);
            this.txtA220.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA220.Text.ToString()), 3, "", false, false, false);
            this.txtA620.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA620.Text.ToString()), 3, "", false, false, false);
            this.txtA720.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA720.Text.ToString()), 3, "", false, false, false);
            this.txtA820.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA820.Text.ToString()), 3, "", false, false, false);
            this.txtA920.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA920.Text.ToString()), 3, "", false, false, false);
            this.txtA1020.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1020.Text.ToString()), 3, "", false, false, false);
            this.txtA1120.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtA1120.Text.ToString()), 3, "", false, false, false);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:SelectPrompt();", true);
            if (!base.IsPostBack)
            {
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = false;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, "--- Select ---");
                }
            }
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["from"] != null)
            {
                this.RedirectTo = base.Request.Params["from"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString() != "")
            {
                this.item = base.Request.Params["item"].ToString();
            }
            if (!base.IsPostBack)
            {
                SettingsBasePage.add_small_format_formula_tag(this.CompanyID);
                SettingsBasePage.add_warehouse_caliper_formula_tag(this.CompanyID);
                DataSet dataSet = SettingsBasePage.settings_othercost_formulatag_select(this.CompanyID);
                this.PaperMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                bool flag = false;
                bool flag1 = false;
                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    int num1 = 0;
                    foreach (DataRow row in dataSet.Tables[i].Rows)
                    {
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>"));
                        if (i % 2 != 0)
                        {
                            num1++;
                            str = row["Label"].ToString();
                            empty1 = row["key"].ToString();
                            str1 = row["Value"].ToString();
                            if (flag)
                            {
                                if (this.PaperMeasure != "In.")
                                {
                                    str = row["Label"].ToString();
                                    empty1 = row["key"].ToString();
                                    str1 = row["Value"].ToString();
                                }
                                else if (row["Label"].ToString() != "Total Length Required (Meter)")
                                {
                                    str = this.objlang.GetLanguageConversion("Total_Area_Required_Sq_Feet");
                                    empty1 = this.objlang.GetLanguageConversion("Total_Area_Required_Sq_Feet");
                                    str1 = this.objlang.GetLanguageConversion("Total_Area_Required_Sq_Feet");
                                }
                                else
                                {
                                    str = this.objlang.GetLanguageConversion("Total_Length_Required_Feet");
                                    empty1 = this.objlang.GetLanguageConversion("Total_Length_Required_Feet");
                                    str1 = this.objlang.GetLanguageConversion("Total_Length_Required_Feet");
                                }
                            }
                            else if (!flag1)
                            {
                                str = row["Label"].ToString();
                                empty1 = row["key"].ToString();
                                str1 = row["Value"].ToString();
                            }
                            else if (this.PaperMeasure != "In.")
                            {
                                str = row["Label"].ToString();
                                empty1 = row["key"].ToString();
                                str1 = row["Value"].ToString();
                            }
                            else if (row["Label"].ToString() == "Large Format Item Area (sq. meter)")
                            {
                                str = this.objlang.GetLanguageConversion("Large_Format_Item_Area_feet");
                                empty1 = this.objlang.GetLanguageConversion("Large_Format_Item_Area_feet");
                                str1 = this.objlang.GetLanguageConversion("Large_Format_Item_Area_feet");
                            }
                            else if (row["Label"].ToString() == "Large Format Item Width (meter)")
                            {
                                str = this.objlang.GetLanguageConversion("Large_Format_Item_Width_feet");
                                empty1 = this.objlang.GetLanguageConversion("Large_Format_Item_Width_feet");
                                str1 = this.objlang.GetLanguageConversion("Large_Format_Item_Width_feet");
                            }
                            else if (row["Label"].ToString() != "Large Format Item Height (meter)")
                            {
                                str = row["Label"].ToString();
                                empty1 = row["key"].ToString();
                                str1 = row["Value"].ToString();
                            }
                            else
                            {
                                str = this.objlang.GetLanguageConversion("Large_Format_Item_Height_feet");
                                empty1 = this.objlang.GetLanguageConversion("Large_Format_Item_Height_feet");
                                str1 = this.objlang.GetLanguageConversion("Large_Format_Item_Height_feet");
                            }
                            if (row["Label"].ToString() == "Paper Caliper")
                            {
                                string paperMaterial = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMaterial");
                                str = string.Concat(row["Label"].ToString()," ","("+ paperMaterial + ")");
                                empty1 = string.Concat(row["key"].ToString(), " ", "(" + paperMaterial + ")");
                                str1 = string.Concat(row["Value"].ToString()," ","(" + paperMaterial + ")");
                            }
                            if ((row["Label"].ToString() == "Small Format Item Width") || (row["Label"].ToString() == "Small Format Item Height"))
                            {
                                if(this.PaperMeasure != "In.")
                                {
                                    str = string.Concat(str," ","(mm)");
                                    empty1 = string.Concat(empty1," ","(mm)");
                                    str1 = string.Concat(str1," ","(mm)");
                                }
                                else
                                {
                                    str = string.Concat(str," ","(inches)");
                                    empty1 = string.Concat(empty1," ","(inches)");
                                    str1 = string.Concat(str1," ","(inches)");
                                }
                            }
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<td>"));
                            int num2 = i - 1;
                            ControlCollection controls = this.plhFormulaTags.Controls;
                            count = new object[] { "<div id='divbooklet_", num2, "_", num1, "'  style='display: none'>" };
                            controls.Add(new LiteralControl(string.Concat(count)));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<table id='tableID1' width='100%' border='0' cellspacing='0' cellpadding='0' align='center'>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<tr class='VMenu'>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<td style='width: 2%'></td>"));
                            string str2 = string.Concat(this.strImagepath, "branch-e.gif");
                            if (num1 == dataSet.Tables[i].Rows.Count)
                            {
                                str2 = string.Concat(this.strImagepath, "branch-l.gif");
                            }
                            this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<td class='VMenuIcon'><img src='", str2, "' width='15' height='20' alt='' border='0'></td>")));
                            ControlCollection controlCollections = this.plhFormulaTags.Controls;
                            languageConversion = new string[] { "<td width='100%' style='cursor: pointer' id='td0' class='Caption2Out' onclick=\"javascript:generate_formula('<<", str1, ">>','ex','", row["CategoryID"].ToString(), "','", empty1, "');\">" };
                            controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                            this.plhFormulaTags.Controls.Add(new LiteralControl(str));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</table>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</div>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                        }
                        else
                        {
                            empty = row["CategoryName"].ToString();
                            flag = (empty != "Large Format Variables" ? false : true);
                            flag1 = (empty != "Job Variables" ? false : true);
                            if (dataSet.Tables[i + 1].Rows.Count <= 0)
                            {
                                continue;
                            }
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<td>"));
                            ControlCollection controls1 = this.plhFormulaTags.Controls;
                            count = new object[] { "<div id='divopen_", i, "' onclick=\"javascript:booklet('none',this.id,'", i, "','", dataSet.Tables[i + 1].Rows.Count, "');\" style='cursor: pointer; display: none'>" };
                            controls1.Add(new LiteralControl(string.Concat(count)));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%'>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<td style='width: 2%'>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<td><img src='../images/mminus.gif' width='20' height='20' alt='' border='0' style='vertical-align: middle'><b>", empty, "</b></td>")));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</table>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</div>"));
                            ControlCollection controlCollections1 = this.plhFormulaTags.Controls;
                            count = new object[] { "<div id='divclose_", i, "' onclick=\"javascript:booklet('block',this.id,'", i, "','", dataSet.Tables[i + 1].Rows.Count, "');\" style='cursor: pointer; display: block'>" };
                            controlCollections1.Add(new LiteralControl(string.Concat(count)));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%'>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("<td style='width: 2%'>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<td><img src='../images/mplus.gif' width='20' height='20' alt='' border='0' style='vertical-align: middle'><b>", empty, "</b></td>")));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</table>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</div>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                            this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                        }
                    }
                    if (dataSet.Tables.Count - 1 == i)
                    {
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<td>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<div id='divopen_", i + 1, "' onclick='AddQuestion();' style='cursor: pointer; display: block'>")));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%'>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<td style='width: 2%'>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<td>&nbsp;<b>Add Question</b><img src=", this.strImagepath, "'mminus.gif' width='18' style='display: none' height='20' alt='' border='0'></td>")));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</table>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</div>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<div id='divclose_", i + 1, "'  style='cursor: pointer; display: none'>")));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' border='0' width='100%'>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<tr>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("<td style='width: 2%'>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl(string.Concat("<td>&nbsp;<b>Add Question</b><img src=", this.strImagepath, "'mminus.gif' width='18' style='display: none' height='20' alt='' border='0'></td>")));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</table>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</div>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</td>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</tr>"));
                        this.plhFormulaTags.Controls.Add(new LiteralControl("</table>"));
                    }
                }
            }
            if (!base.IsPostBack && base.Request.Url.ToString().ToLower().Contains("cop=yes") && base.Request.Params["cop"] != null)
            {
                base.Message_Display(" Other Cost Item Successfully Copied", "msg-success", this.plhMessage);
            }
            if (!base.IsPostBack)
            {
                this.objComp.company_supplier_select(this.CompanyID, this.ddlSupplier);
                if (base.Request.QueryString["suplrid"] != null)
                {
                    DropDownList dropDownList = this.ddlSupplier;
                    num = Convert.ToInt64(base.Request.QueryString["suplrid"]);
                    dropDownList.SelectedValue = num.ToString();
                }
                for (int j = 0; j < this.ddlSupplier.Items.Count; j++)
                {
                    this.ddlSupplier.Items[j].Attributes.Add("class", "Space_dropdown");
                }
                this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, string.Concat("--- ", this.objLanguage.GetLanguageConversion("select"), " ---"));
                this.txtProfit.Text = SettingsBasePage.settings_system_markup_by_type(this.CompanyID, "OtherCost");
                this.txtProfit.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(this.txtProfit.Text.ToString()), 0, "", false, false, false, 3);
                if (base.Request.Params["type"] != null)
                {
                    this.Type = base.Request.Params["type"].ToString().ToLower();
                    if (base.Request.Params["type"].ToString().ToLower() == "edit")
                    {
                        this.Action = "edit";
                        this.OtherCostID = Convert.ToInt64(base.Request.QueryString["id"].ToString());
                        try
                        {
                            if (this.AccountingCode != "d")
                            {
                                this.div_AccountCode.Visible = false;
                            }
                            else
                            {
                                this.div_AccountCode.Visible = false;
                                DropDownList dropDownList1 = this.ddlAccountCode;
                                int num3 = SettingsBasePage.OtherCost_AccountingCode_Select((long)this.CompanyID, this.OtherCostID);
                                dropDownList1.SelectedValue = num3.ToString();
                            }
                        }
                        catch
                        {
                        }
                        this.btnDelete.Visible = true;
                        this.Divboxedit.Attributes.Add("Style", "Margin-left:3px;");
                        foreach (DataRow dataRow in SettingsBasePage.settings_othercost_select(this.CompanyID, this.OtherCostID).Rows)
                        {
                            this.txtName.Text = base.SpecialDecode(dataRow["OtherCostName"].ToString());
                            this.txtDescription.Text = base.SpecialDecode(dataRow["Description"].ToString());
                            this.ddlCategory.SelectedValue = dataRow["OtherCostCategoryID"].ToString();
                            this.ddlCalculation.SelectedValue = dataRow["CalculationType"].ToString();
                            this.hid_CalculationType.Value = dataRow["CalculationType"].ToString();
                            this.hid_CostTimeBasedID.Value = dataRow["CostTimeBasedID"].ToString();
                            if (base.Request.QueryString["suplrid"] == null)
                            {
                                this.ddlSupplier.SelectedValue = dataRow["SupplierID"].ToString();
                            }
                            this.txtPerHourCost.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["PerHourCost"].ToString()), 0, "", false, false, false, 3);
                            this.txtProfit.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Profit"].ToString()), 0, "", false, false, false, 3);
                            this.txtMinimum.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["Minimum"].ToString()), 0, "", false, false, false, 3);
                            this.Formula = base.ReplaceSingleQuote(dataRow["Formula"].ToString());
                            this.CalMethod = dataRow["CalculationType"].ToString();
                        }
                        if (this.ddlCalculation.SelectedValue != "0")
                        {
                            this.pnlShowOnCalType.Visible = true;
                            this.ddlCalculation.Enabled = false;
                        }
                        if (this.ddlCalculation.SelectedValue == "m")
                        {
                            foreach (DataRow row1 in SettingsBasePage.settings_othercost_matrix_select(this.CompanyID, this.OtherCostID).Rows)
                            {
                                this.txtCol1.Text = row1["Column1"].ToString();
                                this.txtCol2.Text = row1["Column2"].ToString();
                                this.txtCol3.Text = row1["Column3"].ToString();
                                this.txtCol4.Text = row1["Column4"].ToString();
                                this.txtCol5.Text = row1["Column5"].ToString();
                                this.txtCol6.Text = row1["Column6"].ToString();
                                this.txtCol7.Text = row1["Column7"].ToString();
                                this.txtCol8.Text = row1["Column8"].ToString();
                                this.txtCol9.Text = row1["Column9"].ToString();
                                this.txtCol10.Text = row1["Column10"].ToString();
                                this.txtprompt.Text = row1["Prompt"].ToString();
                                this.hdnMatrixHeadingID.Value = row1["MatrixHeadingID"].ToString();
                            }
                            DataTable dataTable = SettingsBasePage.settings_othercost_matrix_value_select(this.CompanyID, Convert.ToInt32(this.hdnMatrixHeadingID.Value));
                            int num4 = 1;
                            foreach (DataRow dataRow1 in dataTable.Rows)
                            {
                                TextBox textBox = (TextBox)this.div_table.FindControl(string.Concat("txtFrm", num4.ToString()));
                                textBox.Text = dataRow1["RangeFrom"].ToString();
                                if (num4 != 20)
                                {
                                    TextBox textBox1 = (TextBox)this.div_table.FindControl(string.Concat("txtTo", num4.ToString()));
                                    textBox1.Text = dataRow1["RangeTo"].ToString();
                                }
                                TextBox textBox2 = (TextBox)this.div_table.FindControl(string.Concat("txtA5", num4.ToString()));
                                textBox2.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column1"].ToString()), 3, "", false, false, false);
                                TextBox textBox3 = (TextBox)this.div_table.FindControl(string.Concat("txtA4", num4.ToString()));
                                textBox3.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column2"].ToString()), 3, "", false, false, false);
                                TextBox textBox4 = (TextBox)this.div_table.FindControl(string.Concat("txtA3", num4.ToString()));
                                textBox4.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column3"].ToString()), 3, "", false, false, false);
                                TextBox textBox5 = (TextBox)this.div_table.FindControl(string.Concat("txtA2", num4.ToString()));
                                textBox5.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column4"].ToString()), 3, "", false, false, false);
                                TextBox textBox6 = (TextBox)this.div_table.FindControl(string.Concat("txtA6", num4.ToString()));
                                textBox6.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column5"].ToString()), 3, "", false, false, false);
                                TextBox textBox7 = (TextBox)this.div_table.FindControl(string.Concat("txtA7", num4.ToString()));
                                textBox7.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column6"].ToString()), 3, "", false, false, false);
                                TextBox textBox8 = (TextBox)this.div_table.FindControl(string.Concat("txtA8", num4.ToString()));
                                textBox8.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column7"].ToString()), 3, "", false, false, false);
                                TextBox textBox9 = (TextBox)this.div_table.FindControl(string.Concat("txtA9", num4.ToString()));
                                textBox9.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column8"].ToString()), 3, "", false, false, false);
                                TextBox textBox10 = (TextBox)this.div_table.FindControl(string.Concat("txtA10", num4.ToString()));
                                textBox10.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column9"].ToString()), 3, "", false, false, false);
                                TextBox textBox11 = (TextBox)this.div_table.FindControl(string.Concat("txtA11", num4.ToString()));
                                textBox11.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Column10"].ToString()), 3, "", false, false, false);
                                this.hdnMatrixValueID.Value = string.Concat(this.hdnMatrixValueID.Value, dataRow1["MatrixValueID"].ToString(), "+");
                                num4++;
                                if (base.Request.QueryString["suplrid"] == null)
                                {
                                    continue;
                                }
                                DropDownList dropDownList2 = this.ddlSupplier;
                                num = Convert.ToInt64(base.Request.QueryString["suplrid"]);
                                dropDownList2.SelectedValue = num.ToString();
                            }
                            if (dataTable.Rows.Count == 7)
                            {
                                for (int k = 0; k < 5; k++)
                                {
                                    this.hdnMatrixValueID.Value = string.Concat(this.hdnMatrixValueID.Value, 0, "+");
                                }
                            }
                            if (dataTable.Rows.Count == 12)
                            {
                                for (int l = 0; l < 8; l++)
                                {
                                    this.hdnMatrixValueID.Value = string.Concat(this.hdnMatrixValueID.Value, 0, "+");
                                }
                            }
                            DataTable dataTable1 = SettingsBasePage.settings_costformulabased_select(this.CompanyID, Convert.ToInt64(this.hid_CostTimeBasedID.Value));
                            foreach (DataRow row2 in dataTable1.Rows)
                            {
                                this.Formula = row2["Formula"].ToString();
                                this.hid_FormulaTag.Value = row2["FormulaTag"].ToString();
                            }
                            foreach (DataRow dataRow2 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                            {
                                othercost_add settingsOthercostAdd = this;
                                settingsOthercostAdd.FormulaKey = string.Concat(settingsOthercostAdd.FormulaKey, dataRow2["Key"].ToString(), "±");
                                othercost_add settingsOthercostAdd1 = this;
                                settingsOthercostAdd1.FormulaValue = string.Concat(settingsOthercostAdd1.FormulaValue, dataRow2["Value"].ToString(), "±");
                            }
                        }
                        else if (this.ddlCalculation.SelectedValue == "t")
                        {
                            DataTable dataTable2 = SettingsBasePage.settings_costtimebased_select(this.CompanyID, Convert.ToInt64(this.hid_CostTimeBasedID.Value));
                            foreach (DataRow row3 in dataTable2.Rows)
                            {
                                this.hid_CostTimeBasedID.Value = row3["CostTimeBasedID"].ToString();
                                this.txtHourlyRate.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(row3["HourlyRate"].ToString()), 0, "", false, false, false, 3);
                                this.txtMakeReadyTime.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["MakereadyTime"].ToString()), 0, "", false, false, false);
                                this.txtRunSpeed.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(row3["HourlyRunSpeed"].ToString()), 0, "", false, false, false, 3);
                                this.hdnRunSpeed.Value = this.txtRunSpeed.Text;
                                this.rdlTimeCostType.SelectedValue = (row3["HourlyRunSpeed"].ToString() == "0.0000000000" || row3["HourlyRunSpeed"].ToString() == "0" ? "l" : "m");
                                this.txtRunSpeed.Enabled = (this.rdlTimeCostType.SelectedValue == "l" ? false : true);
                                this.hid_DefaultHourType.Value = row3["DefaultHourType"].ToString();
                                if (this.hid_DefaultHourType.Value != "f")
                                {
                                    this.rdldefaultQty.SelectedValue = "ddl";
                                }
                                else
                                {
                                    this.rdldefaultQty.SelectedValue = "txt";
                                }
                                this.txtFixedQty.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row3["FixedHours"].ToString()), 0, "", false, false, false);
                                this.ddlVariableQty.SelectedValue = row3["VariableHours"].ToString();
                                this.rdlTimeCostType.SelectedValue = row3["TimeBasedType"].ToString();
                                if (this.rdlTimeCostType.SelectedValue != row3["TimeBasedType"].ToString())
                                {
                                    continue;
                                }
                                base.ClientScript.RegisterStartupScript(base.GetType(), "Javascript", "javascript:CheckRdn(); ", true);
                            }
                        }
                        else if (this.ddlCalculation.SelectedValue == "q")
                        {
                            DataTable dataTable3 = SettingsBasePage.settings_costquantitybased_select(this.CompanyID, Convert.ToInt64(this.hid_CostTimeBasedID.Value));
                            foreach (DataRow dataRow3 in dataTable3.Rows)
                            {
                                this.hid_CostTimeBasedID.Value = dataRow3["CostQuantityBasedID"].ToString();
                                this.txtQtyHourlyRate.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["HourlyRate"].ToString()), 0, "", false, false, false, 3);
                                this.txtQtyMakeReadyTime.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["MakereadyTime"].ToString()), 0, "", false, false, false);
                                this.txtQtyTimePerUnit.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["TimePerUnit"].ToString()), 0, "", false, false, false);
                                this.txtQtyUnitCost.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount_byRoundOff(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["DefaultUnitCost"].ToString()), 0, "", false, false, false, 3);
                                this.hid_QtyDefaultValueType.Value = dataRow3["DefaultQtyType"].ToString();
                                if (this.hid_QtyDefaultValueType.Value != "f")
                                {
                                    this.rdlQtyDefaultValue.SelectedValue = "ddl";
                                }
                                else
                                {
                                    this.rdlQtyDefaultValue.SelectedValue = "txt";
                                }
                                this.txtQtyFixedValue.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow3["FixedQty"].ToString()), 0, "", true, false, false);
                                this.ddlQtyVariableValue.SelectedValue = dataRow3["VariableQty"].ToString();
                                this.hid_IsMatrix.Value = dataRow3["IsMatrix"].ToString();
                                if (this.hid_IsMatrix.Value.ToLower() != "true")
                                {
                                    continue;
                                }
                                foreach (DataRow row4 in SettingsBasePage.settings_othercost_matrix_select(this.CompanyID, this.OtherCostID).Rows)
                                {
                                    this.txtCol1.Text = row4["Column1"].ToString();
                                    this.txtCol2.Text = row4["Column2"].ToString();
                                    this.txtCol3.Text = row4["Column3"].ToString();
                                    this.txtCol4.Text = row4["Column4"].ToString();
                                    this.txtCol5.Text = row4["Column5"].ToString();
                                    this.txtCol6.Text = row4["Column6"].ToString();
                                    this.txtprompt.Text = row4["Prompt"].ToString();
                                    this.hdnMatrixHeadingID.Value = row4["MatrixHeadingID"].ToString();
                                }
                                DataTable dataTable4 = SettingsBasePage.settings_othercost_matrix_value_select(this.CompanyID, Convert.ToInt32(this.hdnMatrixHeadingID.Value));
                                int num5 = 1;
                                foreach (DataRow dataRow4 in dataTable4.Rows)
                                {
                                    TextBox str3 = (TextBox)this.div_table.FindControl(string.Concat("txtFrm", num5.ToString()));
                                    str3.Text = dataRow4["RangeFrom"].ToString();
                                    if (num5 != 12)
                                    {
                                        TextBox str4 = (TextBox)this.div_table.FindControl(string.Concat("txtTo", num5.ToString()));
                                        str4.Text = dataRow4["RangeTo"].ToString();
                                    }
                                    TextBox textBox12 = (TextBox)this.div_table.FindControl(string.Concat("txtA5", num5.ToString()));
                                    textBox12.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["Column1"].ToString()), 3, "", false, false, false);
                                    TextBox textBox13 = (TextBox)this.div_table.FindControl(string.Concat("txtA4", num5.ToString()));
                                    textBox13.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["Column2"].ToString()), 3, "", false, false, false);
                                    TextBox textBox14 = (TextBox)this.div_table.FindControl(string.Concat("txtA3", num5.ToString()));
                                    textBox14.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["Column3"].ToString()), 3, "", false, false, false);
                                    TextBox textBox15 = (TextBox)this.div_table.FindControl(string.Concat("txtA2", num5.ToString()));
                                    textBox15.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["Column4"].ToString()), 3, "", false, false, false);
                                    TextBox textBox16 = (TextBox)this.div_table.FindControl(string.Concat("txtA6", num5.ToString()));
                                    textBox16.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["Column5"].ToString()), 3, "", false, false, false);
                                    TextBox textBox17 = (TextBox)this.div_table.FindControl(string.Concat("txtA7", num5.ToString()));
                                    textBox17.Text = this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow4["Column6"].ToString()), 3, "", false, false, false);
                                    this.hdnMatrixValueID.Value = string.Concat(this.hdnMatrixValueID.Value, dataRow4["MatrixValueID"].ToString(), "+");
                                    num5++;
                                }
                            }
                        }
                        else if (this.ddlCalculation.SelectedValue == "f")
                        {
                            DataTable dataTable5 = SettingsBasePage.settings_costformulabased_select(this.CompanyID, Convert.ToInt64(this.hid_CostTimeBasedID.Value));
                            foreach (DataRow row5 in dataTable5.Rows)
                            {
                                this.Formula = row5["Formula"].ToString();
                                this.hid_FormulaTag.Value = row5["FormulaTag"].ToString();
                            }
                            foreach (DataRow dataRow5 in SettingsBasePage.settings_costformulatag_selectall(this.CompanyID).Rows)
                            {
                                othercost_add settingsOthercostAdd2 = this;
                                settingsOthercostAdd2.FormulaKey = string.Concat(settingsOthercostAdd2.FormulaKey, dataRow5["Key"].ToString(), "±");
                                othercost_add settingsOthercostAdd3 = this;
                                settingsOthercostAdd3.FormulaValue = string.Concat(settingsOthercostAdd3.FormulaValue, dataRow5["Value"].ToString(), "±");
                            }
                        }
                    }
                }
                this.ddlCalculation.SelectedIndex = 0;
            }
            this.btnDelete.Attributes.Add("onclick", string.Concat("javascript:return window.confirm('Are you sure, You want to delete ", this.txtName.Text, "?')"));
        }

        public new void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }
    }
}