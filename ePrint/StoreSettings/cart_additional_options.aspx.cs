using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
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
namespace ePrint.StoreSettings
{
    public partial class cart_additional_options : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSet = new SettingsBasePage();

        public commonClass objcom = new commonClass();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public int CompanyID;

        public int UserID;

        public long OtherCostID;

        public string CalMethod = string.Empty;

        public string Action = string.Empty;

        public string Formula = string.Empty;

        public string Type = string.Empty;

        public string strTemp = string.Empty;

        public string FormulaValue = string.Empty;

        public string FormulaKey = string.Empty;

        public string action = string.Empty;

        public long WebOthercostID;

        public long ID;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public languageClass objlang = new languageClass();

        public long AccountID;

        public string type = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public cart_additional_options()
        {
        }

        protected void btnCategorySave_OnClick(object sender, EventArgs e)
        {
            if (string.Compare(this.btnCategorySave.Text, "save", true) != 0)
            {
                string.Compare(this.btnCategorySave.Text, "update", true);
            }
            else
            {
                int num = SettingsBasePage.settings_othercostcategory_insert(this.CompanyID, (long)0, base.ReplaceSingleQuote(this.txtOtherCostCategoryName.Text), 0, this.ddlJobcardCategory.SelectedValue.ToString());
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
                    this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, "--- Select ---");
                    this.ddlCategory.SelectedValue = num.ToString();
                }
            }
            this.txtOtherCostCategoryName.Text = "";
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            WebstoreBasePage.Othercost_Webstore_Delete_Per_Account(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()), this.AccountID, "ind");
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/cart_additional_options_view.aspx?su=de"));
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.FinalSave("Save");
        }

        protected void btnsaveStay_OnClick(object sender, EventArgs e)
        {
            this.FinalSave("SaveandStay");
        }

        public void FinalSave(string SaveType)
        {
            char[] chrArray;
            if (base.Request.Params["type"] != null)
            {
                int num = 0;
                num = (!this.chkVisibletoCart.Checked ? 0 : 1);
                string empty = string.Empty;
                empty = "s";
                if (base.Request.Params["type"].ToString().ToLower() == "add")
                {
                    if (!this.chkCost.Checked)
                    {
                        this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate_ShopCartCost((long)0, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "c", num, this.AccountID, empty, false, false);
                    }
                    else
                    {
                        this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate_ShopCartCost((long)0, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "c", num, this.AccountID, empty, true, false);
                    }
                    if (this.AccountingCode == "d")
                    {
                        WebstoreBasePage.WebStore_AccountingCode_Insert(this.CompanyID, this.WebOthercostID, int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "q")
                    {
                        WebstoreBasePage.Othercost_WebstoreQuestion_Insertupdate((long)0, this.WebOthercostID, this.txtQuestion.Text, this.txtFormula.Text);
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "c")
                    {
                        string value = this.hid_MultipleChoiceValue.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays = value.Split(chrArray);
                        for (int i = 0; i < (int)strArrays.Length - 1; i++)
                        {
                            if (strArrays[i] != "")
                            {
                                string str = string.Empty;
                                string empty1 = string.Empty;
                                string str1 = string.Empty;
                                decimal num1 = new decimal(0);
                                long num2 = (long)0;
                                int num3 = 0;
                                bool flag = false;
                                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                                for (int j = 0; j < (int)strArrays1.Length; j++)
                                {
                                    string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                                    if (string.Compare(strArrays2[0], "CalculationType", true) == 0)
                                    {
                                        str = strArrays2[1];
                                    }
                                    else if (string.Compare(strArrays2[0], "Label", true) == 0)
                                    {
                                        empty1 = base.SpecialEncode(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "Formula", true) == 0)
                                    {
                                        str1 = strArrays2[1];
                                    }
                                    else if (string.Compare(strArrays2[0], "Markup", true) == 0)
                                    {
                                        num1 = Convert.ToDecimal(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "InvID", true) == 0)
                                    {
                                        num2 = Convert.ToInt64(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "RowOrderNumber", true) == 0)
                                    {
                                        num3 = Convert.ToInt32(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "IsMandatoryField", true) == 0)
                                    {
                                        flag = (Convert.ToString(strArrays2[1]) == "1" ? true : false);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreChoice_Insertupdate((long)0, this.WebOthercostID, empty1, str, str1, num1, num2, i + 1, num3, (long)0, 0, flag);
                            }
                        }
                    }
                    else if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "m")
                    {
                        string[] strArrays3 = this.hidQtyPrice.Value.Split(new char[] { 'µ' });
                        for (int k = 0; k < (int)strArrays3.Length - 1; k++)
                        {
                            if (strArrays3[k] != "")
                            {
                                int num4 = 0;
                                int num5 = 0;
                                decimal num6 = new decimal(0);
                                decimal num7 = new decimal(0);
                                decimal num8 = new decimal(0);
                                int num9 = 0;
                                string[] strArrays4 = strArrays3[k].Split(new char[] { '±' });
                                for (int l = 0; l < (int)strArrays4.Length; l++)
                                {
                                    string[] strArrays5 = strArrays4[l].Split(new char[] { '»' });
                                    if (string.Compare(strArrays5[0], "FromQty", true) == 0)
                                    {
                                        num4 = Convert.ToInt32(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "ToQty", true) == 0)
                                    {
                                        num5 = Convert.ToInt32(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "Cost", true) == 0)
                                    {
                                        num6 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "Markup", true) == 0)
                                    {
                                        num7 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "SellingPrice", true) == 0)
                                    {
                                        num8 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "RowOrderNumber", true) == 0)
                                    {
                                        num9 = Convert.ToInt32(strArrays5[1]);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreMatrix_Insertupdate((long)0, this.WebOthercostID, this.ddlMatrixType.SelectedValue, num4, num5, num6, num7, num8, num9);
                            }
                        }
                    }
                }
                else if (base.Request.Params["type"].ToString().ToLower() == "edit")
                {
                    if (base.Request.Params["id"] != null)
                    {
                        this.WebOthercostID = Convert.ToInt64(base.Request.Params["id"].ToString());
                    }
                    if (this.AccountingCode == "d")
                    {
                        WebstoreBasePage.WebStore_AccountingCode_Insert(this.CompanyID, this.WebOthercostID, int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (!this.chkApplyToOthers.Checked)
                    {
                        this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate_ShopCartCost((long)0, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "c", num, this.AccountID, empty, this.chkCost.Checked, false);
                        WebstoreBasePage.Retaining_ShopCartCostDetails_To_OtherAccounts(Convert.ToInt64(base.Request.Params["id"].ToString()), (long)this.CompanyID, this.AccountID);
                    }
                    else
                    {
                        if (!this.chkCost.Checked)
                        {
                            this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate_ShopCartCost(this.WebOthercostID, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "c", num, this.AccountID, empty, false, false);
                        }
                        else
                        {
                            this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate_ShopCartCost(this.WebOthercostID, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "c", num, this.AccountID, empty, true, false);
                        }
                        if (this.hdn_deleted_row.Value != "")
                        {
                            string[] strArrays6 = this.hdn_deleted_row.Value.Split(new char[] { '\u00A7' });
                            for (int m = 1; m < (int)strArrays6.Length; m++)
                            {
                                WebstoreBasePage.Othercost_WebstoreChoice_Delete(this.WebOthercostID, Convert.ToInt64(strArrays6[m]));
                            }
                        }
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "q")
                    {
                        WebstoreBasePage.Othercost_WebstoreQuestion_Delete(this.WebOthercostID);
                        WebstoreBasePage.Othercost_WebstoreQuestion_Insertupdate((long)0, this.WebOthercostID, this.txtQuestion.Text, this.txtFormula.Text);
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "c")
                    {
                        string[] strArrays7 = this.hid_MultipleChoiceValue.Value.Split(new char[] { 'µ' });
                        for (int n = 0; n < (int)strArrays7.Length - 1; n++)
                        {
                            if (strArrays7[n] != "")
                            {
                                string empty2 = string.Empty;
                                string str2 = string.Empty;
                                string empty3 = string.Empty;
                                decimal num10 = new decimal(0);
                                long num11 = (long)0;
                                long num12 = (long)0;
                                int num13 = 0;
                                bool flag1 = false;
                                string[] strArrays8 = strArrays7[n].Split(new char[] { '±' });
                                for (int o = 0; o < (int)strArrays8.Length; o++)
                                {
                                    string str3 = strArrays8[o];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays9 = str3.Split(chrArray);
                                    if (string.Compare(strArrays9[0], "CalculationType", true) == 0)
                                    {
                                        empty2 = strArrays9[1];
                                    }
                                    else if (string.Compare(strArrays9[0], "Label", true) == 0)
                                    {
                                        str2 = base.SpecialEncode(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "Formula", true) == 0)
                                    {
                                        empty3 = strArrays9[1];
                                    }
                                    else if (string.Compare(strArrays9[0], "Markup", true) == 0)
                                    {
                                        num10 = Convert.ToDecimal(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "ChoiceID", true) == 0)
                                    {
                                        num11 = Convert.ToInt64(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "InvID", true) == 0)
                                    {
                                        num12 = Convert.ToInt64(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "RowOrderNumber", true) == 0)
                                    {
                                        num13 = Convert.ToInt32(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "IsMandatoryField", true) == 0)
                                    {
                                        flag1 = (Convert.ToString(strArrays9[1]) == "1" ? true : false);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreChoice_Insertupdate(num11, this.WebOthercostID, str2, empty2, empty3, num10, num12, n + 1, num13, (long)0, 0, flag1);
                            }
                        }
                    }
                    else if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "m")
                    {
                        string value1 = this.hidQtyPrice.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays10 = value1.Split(chrArray);
                        for (int p = 0; p < (int)strArrays10.Length - 1; p++)
                        {
                            if (strArrays10[p] != "")
                            {
                                int num14 = 0;
                                int num15 = 0;
                                decimal num16 = new decimal(0);
                                decimal num17 = new decimal(0);
                                decimal num18 = new decimal(0);
                                long num19 = (long)0;
                                int num20 = 0;
                                string str4 = strArrays10[p];
                                chrArray = new char[] { '±' };
                                string[] strArrays11 = str4.Split(chrArray);
                                for (int q = 0; q < (int)strArrays11.Length; q++)
                                {
                                    string str5 = strArrays11[q];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays12 = str5.Split(chrArray);
                                    if (string.Compare(strArrays12[0], "FromQty", true) == 0)
                                    {
                                        num14 = Convert.ToInt32(strArrays12[1]);
                                    }
                                    else if (string.Compare(strArrays12[0], "ToQty", true) == 0)
                                    {
                                        num15 = Convert.ToInt32(strArrays12[1]);
                                    }
                                    else if (string.Compare(strArrays12[0], "Cost", true) == 0)
                                    {
                                        num16 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (string.Compare(strArrays12[0], "Markup", true) == 0)
                                    {
                                        num17 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (string.Compare(strArrays12[0], "SellingPrice", true) == 0)
                                    {
                                        num18 = Convert.ToDecimal(strArrays12[1]);
                                    }
                                    else if (string.Compare(strArrays12[0], "MatrixID", true) == 0)
                                    {
                                        num19 = Convert.ToInt64(strArrays12[1]);
                                    }
                                    else if (string.Compare(strArrays12[0], "RowOrderNumber", true) == 0)
                                    {
                                        num20 = Convert.ToInt32(strArrays12[1]);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreMatrix_Insertupdate(num19, this.WebOthercostID, this.ddlMatrixType.SelectedValue, num14, num15, num16, num17, num18, num20);
                            }
                        }
                    }
                }
                if (SaveType == "SaveandStay")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/cart_additional_options.aspx?type=edit&id=", this.WebOthercostID));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/cart_additional_options_view.aspx?su=up"));
            }
        }

        [WebMethod]
        public static int FindDuplicate(string parall)
        {
            BaseClass baseClass = new BaseClass();
            string[] strArrays = parall.Split(new char[] { '±' });
            long num = (long)Convert.ToInt32(strArrays[0]);
            string str = baseClass.ReplaceSingleQuote(strArrays[1]);
            long num1 = Convert.ToInt64(strArrays[2]);
            return WebstoreBasePage.settingsWeb_othercostduplicacy_check(num, str, num1);
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

        [WebMethod]
        public static string LanguageConversion(string Key)
        {
            return (new languageClass()).GetLanguageConversion(Key);
        }

        protected void OnClick_lnkCategoryDelete(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.hid_CategoryID.Value);
            if (num != 0)
            {
                SettingsBasePage.settings_othercostcategory_delete(this.CompanyID, (long)num);
                this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, "--- Select ---");
                this.ddlCategory.SelectedIndex = 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] str;
            this.btnCategorySave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnDelete.Text = this.objLanguage.GetLanguageConversion("Delete");
            this.btnsaveStay.Text = this.objLanguage.GetLanguageConversion("Save_Stay");
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString();
            }
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.txtName.Focus();
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
            this.plhAccountList.Controls.Add(userControl);
            string str1 = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str1 == "")
            {
                DropDownList dropDownList = (DropDownList)userControl.FindControl("ddl_accountsList");
                dropDownList.DataSource = this.objAcc.accountsList(this.CompanyID);
                dropDownList.DataTextField = "accountName";
                dropDownList.DataValueField = "Categorylist";
                dropDownList.DataBind();
                base.SetDDLValue(dropDownList, str1.ToString());
                char[] chrArray = new char[] { '~' };
                this.AccountID = Convert.ToInt64(str1.Split(chrArray)[0]);
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Select");
            }
            else
            {
                string[] strArrays = str1.Split(new char[] { '~' });
                this.AccountID = (long)Convert.ToInt32(strArrays[0]);
                string str2 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str2, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (this.type == "edit")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Storesettings/StoreSsettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/cart_additional_options_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option_Edit")));
                base.Title = this.objLanguage.convert(global.pageTitle("Additional Option Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                long num = WebstoreBasePage.Checking_ShopCartCostDetails(Convert.ToInt64(base.Request.Params["id"].ToString()), this.AccountID);
                this.header.SettingName = this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option");
                this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
                if (num != (long)-1)
                {
                    this.div_chkApplyToOthers.Visible = false;
                }
                else
                {
                    this.div_chkApplyToOthers.Visible = true;
                }
            }
            else
            {
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Storesettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/cart_additional_options_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option_Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Additional Option Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.div_chkApplyToOthers.Visible = false;
                this.header.SettingName = this.objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option");
                this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            }
            if (!base.IsPostBack)
            {
                this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, string.Concat("--- ", this.objlang.GetLanguageConversion("Select"), " ---"));
                this.ddlMatrixType.Items.Insert(0, " ");
                this.ddlMatrixType.Items[0].Text = "Price Bands";
                this.ddlMatrixType.Items[0].Value = "pricebands";
                this.ddlMatrixType.Items.Insert(1, " ");
                this.ddlMatrixType.Items[1].Text = "Simple Matrix";
                this.ddlMatrixType.Items[1].Value = "simplematrix";
                this.ddlMainCalculation.Items.Insert(0, " ");
                this.ddlMainCalculation.Items[0].Text = this.objLanguage.GetLanguageConversion("Multiple_Choice_Question");
                this.ddlMainCalculation.Items[0].Value = "c";
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Url.ToString().ToLower().Contains("cop=yes") && base.Request.Params["cop"] != null)
                {
                    base.Message_Display(this.objLanguage.GetLanguageConversion("Copy_Of_Additional_Option_Successfully_Done"), "msg-success", this.plhMessage);
                }
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = true;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, "--- Select ---");
                }
                if (base.Request.Params["type"] != null)
                {
                    this.action = base.Request.Params["type"].ToString().ToLower();
                    string empty = string.Empty;
                    if (base.Request.Params["type"].ToString().ToLower() == "edit")
                    {
                        this.Action = "edit";
                        this.ID = Convert.ToInt64(base.Request.Params["id"].ToString());
                        try
                        {
                            if (this.AccountingCode != "d")
                            {
                                this.div_AccountCode.Visible = false;
                            }
                            else
                            {
                                this.div_AccountCode.Visible = true;
                                this.WebOthercostID = (long)Convert.ToInt32(base.Request.Params["id"].ToString());
                                DropDownList dropDownList1 = this.ddlAccountCode;
                                int num1 = WebstoreBasePage.WebStore_AccountingCode_Select(this.CompanyID, this.WebOthercostID);
                                dropDownList1.SelectedValue = num1.ToString();
                            }
                        }
                        catch
                        {
                        }
                        this.btnDelete.Visible = true;
                        DataTable dataTable = WebstoreBasePage.OtherCost_WebStore_Select(this.ID, (long)this.CompanyID, (long)this.UserID);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            this.txtName.Text = base.SpecialDecode(row["webothercostName"].ToString());
                            this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
                            this.txtUserfriendly.Text = base.SpecialDecode(row["UserFriendlyName"].ToString());
                            this.ddlCategory.SelectedValue = row["CategoryID"].ToString();
                            this.ddlMainCalculation.SelectedValue = row["MainCalculationType"].ToString();
                            empty = row["MatrixOrChoiceType"].ToString();
                            if (this.ddlMainCalculation.SelectedValue == "q")
                            {
                                this.ddlMainCalculation.SelectedIndex = 0;
                            }
                            else if (this.ddlMainCalculation.SelectedValue == "c")
                            {
                                this.ddlMainCalculation.SelectedIndex = 1;
                                if (empty == "fixed")
                                {
                                    this.ddlCalculationType.SelectedIndex = 0;
                                }
                                else if (empty == "quantity")
                                {
                                    this.ddlCalculationType.SelectedIndex = 1;
                                }
                                this.ddlCalculationType.Enabled = false;
                            }
                            else if (this.ddlMainCalculation.SelectedValue == "m")
                            {
                                this.ddlMainCalculation.SelectedIndex = 2;
                                if (empty == "pricebands")
                                {
                                    this.ddlMatrixType.SelectedIndex = 0;
                                }
                                else if (empty == "simplematrix")
                                {
                                    this.ddlMatrixType.SelectedIndex = 1;
                                }
                                this.ddlMatrixType.Enabled = false;
                            }
                            if (!Convert.ToBoolean(row["VisibletoCart"]))
                            {
                                this.chkVisibletoCart.Checked = false;
                            }
                            else
                            {
                                this.chkVisibletoCart.Checked = true;
                            }
                            this.chkCost.Checked = Convert.ToBoolean(row["IsCartmandatory"]);
                        }
                        if (this.ddlMainCalculation.SelectedValue != "")
                        {
                            this.pnl_OnLoadEdit.Visible = true;
                            this.ddlMainCalculation.Enabled = false;
                        }
                        if (this.ddlMainCalculation.SelectedValue == "q")
                        {
                            foreach (DataRow dataRow in WebstoreBasePage.Othercost_WebstoreQuestion_Select(this.ID).Rows)
                            {
                                this.txtQuestion.Text = dataRow["Question"].ToString();
                                this.txtFormula.Text = dataRow["formula"].ToString();
                            }
                        }
                        else if (this.ddlMainCalculation.SelectedValue == "c")
                        {
                            int num2 = 0;
                            string str3 = "90%;";
                            StringBuilder stringBuilder = new StringBuilder();
                            foreach (DataRow row1 in WebstoreBasePage.Othercost_WebstoreChoice_Select(this.ID).Rows)
                            {
                                string str4 = "";
                                if (num2 != 0)
                                {
                                    str4 = (num2 % 2 != 0 ? "#EFEFEF" : "");
                                }
                                stringBuilder.Append(string.Concat("<div id='td_", num2, "' >"));
                                str = new object[] { "<div id='div_row_multiple", num2, "' style='background-color:", str4, ";height:25px;vertical-align:middle'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("<div class='only5px' style='width: 100%;'>");
                                stringBuilder.Append(" <table style='width:100%;' cellpadding='0px' cellspacing='0px' border='0px' >");
                                stringBuilder.Append("      <tr>");
                                stringBuilder.Append("          <td style='width: 30%;padding-left:5px' align='left'>");
                                object[] objArray = new object[] { "<div id='div_label_", num2, "' style='float: left; width: ", str3, ";' >" };
                                stringBuilder.Append(string.Concat(objArray));
                                object[] objArray1 = new object[] { "<input id='txtlabel_", num2, "'   maxlength=250 type='text' style='width:250px;text-align:left;' class='textboxnew' value='", base.SpecialDecode(row1["Label"].ToString()).Replace("'", "&#39"), "'/>" };
                                stringBuilder.Append(string.Concat(objArray1));
                                object[] objArray2 = new object[] { "<input type='hidden' name='Rownumber' id='hdn_Multiple_Rownumber_", num2, "' value='", num2, "'>" };
                                stringBuilder.Append(string.Concat(objArray2));
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 38%;' align='left'>");
                                if (row1["CalculationType"].ToString() != "fixed")
                                {
                                    string str5 = row1["Formula"].ToString();
                                    object[] objArray3 = new object[] { "<input id='txtfixed_or_qty_", num2, "' type='text' maxlength='1000' style='width:400px;text-align:left;' class='textboxnew' value='", str5, "'/>" };
                                    stringBuilder.Append(string.Concat(objArray3));
                                }
                                else
                                {
                                    decimal num3 = Convert.ToDecimal(row1["Formula"].ToString());
                                    object[] objArray4 = new object[] { "<input id='txtfixed_or_qty_", num2, "' type='text' maxlength='20' style='width:400px;text-align:left;' onblur='todecimal_function(this,this.value);CalculateMultipleSellPrice(this,", num2, ")' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num3, 0, "", false, false, false), "'/>" };
                                    stringBuilder.Append(string.Concat(objArray4));
                                }
                                if (num2 != 0)
                                {
                                    stringBuilder.Append(string.Concat("<input type='hidden' name='IsMandatoryField' id='hdn_IsMandatoryField_", num2, "' value='0'>"));
                                }
                                else
                                {
                                    stringBuilder.Append(string.Concat("<input type='hidden' name='IsMandatoryField' id='hdn_IsMandatoryField_", num2, "' value='1'>"));
                                }
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 15%;' align='center'>");
                                if (row1["CalculationType"].ToString() != "fixed")
                                {
                                    this.div_MultipleFormulaTag.Style.Add("display", "block");
                                    object[] objArray5 = new object[] { "<input id='txtMarkup_multiple_", num2, "'  type='text' maxlength='20' style='width:80px;text-align:right;' class='textboxnew' onblur='todecimal_function(this,this.value);' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Markup"].ToString()), 0, "", false, false, false), "' />" };
                                    stringBuilder.Append(string.Concat(objArray5));
                                }
                                else
                                {
                                    object[] objArray6 = new object[] { "<input id='txtMarkup_multiple_", num2, "'  type='text' maxlength='20' style='width:80px;text-align:right;' class='textboxnew' onblur='Onbur_MultipleMarkup(this,", num2, ");' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Markup"].ToString()), 0, "", false, false, false), "' />" };
                                    stringBuilder.Append(string.Concat(objArray6));
                                }
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 15%;' align='left'>");
                                if (row1["CalculationType"].ToString() == "fixed")
                                {
                                    decimal num4 = Convert.ToDecimal(row1["Formula"].ToString());
                                    decimal num5 = Convert.ToDecimal(row1["Markup"].ToString());
                                    decimal num6 = num4 + ((num4 * num5) / new decimal(100));
                                    object[] objArray7 = new object[] { "<input id='txt_sellingprice_", num2, "' onblur=Calculate_MultipleMarkup(this,'", num2, "'); type='text' maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num6, 0, "", false, false, false), "' />" };
                                    stringBuilder.Append(string.Concat(objArray7));
                                }
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 2%;' align='center'>");
                                if (num2 != 0)
                                {
                                    object[] objArray8 = new object[] { "                  <img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row_New(", num2, "); />" };
                                    stringBuilder.Append(string.Concat(objArray8));
                                }
                                else
                                {
                                    stringBuilder.Append("<span align='right' style='color: Red;'>*</span>");
                                }
                                object[] str6 = new object[] { "<span id='spn_choiceID_", num2, "' style='display:none;'>", row1["ChoiceID"].ToString(), "</span>" };
                                stringBuilder.Append(string.Concat(str6));
                                object[] str7 = new object[] { "<span id='spn_InventoryID_", num2, "' style='display:none;'>", row1["InventoryID"].ToString(), "</span>" };
                                stringBuilder.Append(string.Concat(str7));
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("     </tr>");
                                stringBuilder.Append(" </table>");
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("</div>µ");
                                num2++;
                            }
                            this.hid_data_multiple.Value = stringBuilder.ToString();
                            this.hid_Rows_On_Edit_multiple.Value = num2.ToString();
                            this.pnlCheckRowMultiple.Visible = true;
                        }
                        else if (this.ddlMainCalculation.SelectedValue == "m")
                        {
                            int num7 = 0;
                            string empty1 = string.Empty;
                            string str8 = "50%;";
                            if (empty == "simplematrix")
                            {
                                empty1 = "style='display:none;'";
                                str8 = "90%";
                            }
                            StringBuilder stringBuilder1 = new StringBuilder();
                            foreach (DataRow dataRow1 in WebstoreBasePage.Othercost_WebstoreMatrix_Select(this.ID).Rows)
                            {
                                string str9 = "";
                                if (num7 != 0)
                                {
                                    str9 = (num7 % 2 != 0 ? "#EFEFEF" : "");
                                }
                                stringBuilder1.Append(string.Concat("<div id='td_", num7, "' >"));
                                object[] objArray9 = new object[] { "<div id='div_row_", num7, "' style='background-color:", str9, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                                stringBuilder1.Append(string.Concat(objArray9));
                                stringBuilder1.Append("<div class='only5px' style='width: 100%;'>");
                                stringBuilder1.Append(" <table style='width:100%;' cellpadding='0px' cellspacing='0px' border='0px' >");
                                stringBuilder1.Append("      <tr>");
                                stringBuilder1.Append("          <td style='width: 24%;' align='center'>");
                                stringBuilder1.Append("<div style='float: left; width: 45%;' align='center'>");
                                object[] str10 = new object[] { "<input id='txtQty_from_", num7, "' ", empty1, " onblur='Check_Qty_From(", num7, ",this.value)' maxlength=7 type='text' style='width:50px;text-align:right' value='", dataRow1["FromQuantity"].ToString(), "'  class='textboxnew' />" };
                                stringBuilder1.Append(string.Concat(str10));
                                object[] objArray10 = new object[] { "<input type='hidden' name='Rownumber' id='hdn_Matrix_Rownumber_", num7, "' value='", num7, "'>" };
                                stringBuilder1.Append(string.Concat(objArray10));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div style='float: left; padding-right: 5px;'>");
                                object[] objArray11 = new object[] { "<span id='spn_qty_sep_", num7, "' ", empty1, ">-</span>" };
                                stringBuilder1.Append(string.Concat(objArray11));
                                stringBuilder1.Append("</div>");
                                object[] objArray12 = new object[] { "<div id='div_txtQty_", num7, "' style='float: left; width: ", str8, ";'>" };
                                stringBuilder1.Append(string.Concat(objArray12));
                                object[] str11 = new object[] { "<input id='txtQty_", num7, "' onblur=QuantityCheck(this.value,", num7, "); maxlength=7 type='text' style='width:80px;text-align:right;' value='", dataRow1["ToQuantity"].ToString(), "'  class='textboxnew' />" };
                                stringBuilder1.Append(string.Concat(str11));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td style='width: 20%;' align='center'>");
                                str = new object[] { "<input id='txtCost_", num7, "' type='text' onblur=\"CalculateSellPrice(this,", num7, ",'cost');\" maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Price"].ToString()), 0, "", false, false, false), "' />" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td style='width: 20%;' align='center'>");
                                str = new object[] { "<input id='txtMarkup_", num7, "' type='text' onblur=\"CalculateSellPrice(this,", num7, ",'markup');\" maxlength='20' style='width: 80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Markup"].ToString()), 0, "", false, false, false), "' />" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td style='width: 24%;' align='center'>");
                                str = new object[] { "<input id='txtSellingPrice_", num7, "' onblur=\"Calculate_Markup(this,", num7, ");\" type='text' maxlength='20'  style='width: 80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["SellingPrice"].ToString()), 0, "", false, false, false), "' />" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td align='center'>");
                                stringBuilder1.Append("<div align='center'>");
                                str = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", num7, "); />" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("</div>");
                                str = new object[] { "<span id='spn_matrixID_", num7, "' style='display:none;'>", dataRow1["MatrixID"].ToString(), "</span>" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("     </tr>");
                                stringBuilder1.Append(" </table>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>µ");
                                num7++;
                            }
                            this.hid_data.Value = stringBuilder1.ToString();
                            this.hid_Rows_On_Edit.Value = num7.ToString();
                            this.pnlCheckRow.Visible = true;
                        }
                    }
                }
            }
            string languageConversion2 = this.objLanguage.GetLanguageConversion("Are_You_Sure_You_Want_To_Delete");
            this.btnDelete.Attributes.Add("onclick", string.Concat("javascript:var a=window.confirm('", languageConversion2, this.txtName.Text, "?');if(a)loadingimage(this.id,'div_deleteprocess');return a;"));
            this.ddlCalculationType.Items[0].Text = this.objLanguage.GetLanguageConversion("Fixed_Value");
            this.ddlCalculationType.Items[1].Text = this.objLanguage.GetLanguageConversion("Formula");
            this.ddlJobcardCategory.Items[0].Text = this.objLanguage.GetLanguageConversion("Pre_Press");
            this.ddlJobcardCategory.Items[1].Text = this.objLanguage.GetLanguageConversion("Press");
            this.ddlJobcardCategory.Items[2].Text = this.objLanguage.GetLanguageConversion("Post_Press");
            this.ddlJobcardCategory.Items[3].Text = this.objLanguage.GetLanguageConversion("Admin");
        }
    }
}