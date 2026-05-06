
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
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
namespace ePrint.ProductCatalogue
{
    public partial class Othercost_webstore : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass objcom = new commonClass();

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

        public bool IsSubAdditionOption;

        public string type = string.Empty;

        public long GroupID;

        private int SubadditionCount;

        public bool IsMandatoryField;

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

        public Othercost_webstore()
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
                    this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, "--- Select ---");
                    this.ddlCategory.SelectedValue = num.ToString();
                }
            }
            this.txtOtherCostCategoryName.Text = "";
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            WebstoreBasePage.Othercost_Webstore_Delete(this.CompanyID, Convert.ToInt64(base.Request.Params["id"].ToString()));
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=de"));
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
                if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "c" || this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "f" || this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "l")
                {
                    if (!this.chkSubAdditionalOption.Checked)
                    {
                        this.IsSubAdditionOption = false;
                    }
                    else
                    {
                        this.IsSubAdditionOption = true;
                    }
                }
                if (base.Request.Params["type"].ToString().ToLower() == "add")
                {
                    this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate((long)0, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "p", 0, Convert.ToInt32(this.ddlSupplier.SelectedValue), this.IsSubAdditionOption, this.chkMandatory.Checked);
                    if (this.AccountingCode == "d")
                    {
                        WebstoreBasePage.WebStore_AccountingCode_Insert(this.CompanyID, this.WebOthercostID, int.Parse(this.ddlAccountCode.SelectedValue));
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "q")
                    {
                        WebstoreBasePage.Othercost_WebstoreQuestion_Insertupdate((long)0, this.WebOthercostID, this.txtQuestion.Text, this.txtFormula.Text);
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "f" || this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "l")
                    {
                        WebstoreBasePage.Othercost_WebstoreFreeTextQuestion_Insertupdate((long)0, this.WebOthercostID, this.txtFreeText.Text, this.txtFormula.Text,this.chkHideAdditionalName.Checked,this.chkMandatory.Checked);
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
                                string empty = string.Empty;
                                string str = string.Empty;
                                string empty1 = string.Empty;
                                decimal num = new decimal(0);
                                long num1 = (long)0;
                                int num2 = 0;
                                bool flag = false;
                                string[] strArrays1 = strArrays[i].Split(new char[] { '±' });
                                for (int j = 0; j < (int)strArrays1.Length; j++)
                                {
                                    string[] strArrays2 = strArrays1[j].Split(new char[] { '»' });
                                    if (string.Compare(strArrays2[0], "CalculationType", true) == 0)
                                    {
                                        empty = strArrays2[1];
                                    }
                                    else if (string.Compare(strArrays2[0], "Label", true) == 0)
                                    {
                                        str = strArrays2[1];
                                    }
                                    else if (string.Compare(strArrays2[0], "Formula", true) == 0)
                                    {
                                        empty1 = strArrays2[1];
                                    }
                                    else if (string.Compare(strArrays2[0], "Markup", true) == 0)
                                    {
                                        num = Convert.ToDecimal(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "InvID", true) == 0)
                                    {
                                        num1 = Convert.ToInt64(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "GroupID", true) == 0)
                                    {
                                        this.GroupID = Convert.ToInt64(strArrays2[1]);
                                        this.SubadditionCount = WebstoreBasePage.Select_WebOtherCostID(Convert.ToInt32(this.GroupID));
                                    }
                                    else if (string.Compare(strArrays2[0], "RowOrderNumber", true) == 0)
                                    {
                                        num2 = Convert.ToInt32(strArrays2[1]);
                                    }
                                    else if (string.Compare(strArrays2[0], "IsMandatoryField", true) == 0)
                                    {
                                        flag = (Convert.ToString(strArrays2[1]) == "1" ? true : false);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreChoice_Insertupdate((long)0, this.WebOthercostID, str, empty, empty1, num, num1, i + 1, num2, this.GroupID, this.SubadditionCount, flag);
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
                                int num3 = 0;
                                int num4 = 0;
                                decimal num5 = new decimal(0);
                                decimal num6 = new decimal(0);
                                decimal num7 = new decimal(0);
                                int num8 = 0;
                                string[] strArrays4 = strArrays3[k].Split(new char[] { '±' });
                                for (int l = 0; l < (int)strArrays4.Length; l++)
                                {
                                    string[] strArrays5 = strArrays4[l].Split(new char[] { '»' });
                                    if (string.Compare(strArrays5[0], "FromQty", true) == 0)
                                    {
                                        num3 = Convert.ToInt32(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "ToQty", true) == 0)
                                    {
                                        num4 = Convert.ToInt32(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "Cost", true) == 0)
                                    {
                                        num5 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "Markup", true) == 0)
                                    {
                                        num6 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "SellingPrice", true) == 0)
                                    {
                                        num7 = Convert.ToDecimal(strArrays5[1]);
                                    }
                                    else if (string.Compare(strArrays5[0], "RowOrderNumber", true) == 0)
                                    {
                                        num8 = Convert.ToInt32(strArrays5[1]);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreMatrix_Insertupdate((long)0, this.WebOthercostID, this.ddlMatrixType.SelectedValue, num3, num4, num5, num6, num7, num8);
                            }
                        }
                    }
                    else if (SaveType == "Save")
                    {
                        if (base.Request.Params["id"] == null)
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=in"));
                        }
                        else
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=up"));
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
                    this.WebOthercostID = WebstoreBasePage.OtherCost_WebStore_Insertupdate(this.WebOthercostID, (long)this.CompanyID, (long)this.UserID, base.SpecialEncode(this.txtName.Text), base.SpecialEncode(this.txtDescription.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToInt64(this.ddlCategory.SelectedValue), this.ddlMainCalculation.SelectedValue.ToString(), "p", 0, Convert.ToInt32(this.ddlSupplier.SelectedValue), this.IsSubAdditionOption, this.chkMandatory.Checked);
                    if (this.hdn_deleted_row.Value != "")
                    {
                        string value1 = this.hdn_deleted_row.Value;
                        chrArray = new char[] { '\u00A7' };
                        string[] strArrays6 = value1.Split(chrArray);
                        for (int m = 1; m < (int)strArrays6.Length; m++)
                        {
                            WebstoreBasePage.Othercost_WebstoreChoice_Delete(this.WebOthercostID, Convert.ToInt64(strArrays6[m]));
                        }
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "q")
                    {
                        WebstoreBasePage.Othercost_WebstoreQuestion_Delete(this.WebOthercostID);
                        WebstoreBasePage.Othercost_WebstoreQuestion_Insertupdate((long)0, this.WebOthercostID, this.txtQuestion.Text, this.txtFormula.Text);
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "f" || this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "l") 
                    {
                        WebstoreBasePage.Othercost_WebstoreQuestion_Delete(this.WebOthercostID);
                        WebstoreBasePage.Othercost_WebstoreFreeTextQuestion_Insertupdate((long)0, this.WebOthercostID, this.txtFreeText.Text, this.txtFormula.Text, this.chkHideAdditionalName.Checked,this.chkMandatory.Checked);
                    }
                    if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "c")
                    {
                        string str1 = this.hid_MultipleChoiceValue.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays7 = str1.Split(chrArray);
                        for (int n = 0; n < (int)strArrays7.Length - 1; n++)
                        {
                            if (strArrays7[n] != "")
                            {
                                string empty2 = string.Empty;
                                string str2 = string.Empty;
                                string empty3 = string.Empty;
                                decimal num9 = new decimal(0);
                                long num10 = (long)0;
                                long num11 = (long)0;
                                int num12 = 0;
                                bool flag1 = false;
                                string str3 = strArrays7[n];
                                chrArray = new char[] { '±' };
                                string[] strArrays8 = str3.Split(chrArray);
                                for (int o = 0; o < (int)strArrays8.Length; o++)
                                {
                                    string str4 = strArrays8[o];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays9 = str4.Split(chrArray);
                                    if (string.Compare(strArrays9[0], "CalculationType", true) == 0)
                                    {
                                        empty2 = strArrays9[1];
                                    }
                                    else if (string.Compare(strArrays9[0], "Label", true) == 0)
                                    {
                                        str2 = strArrays9[1];
                                    }
                                    else if (string.Compare(strArrays9[0], "Formula", true) == 0)
                                    {
                                        empty3 = strArrays9[1];
                                    }
                                    else if (string.Compare(strArrays9[0], "Markup", true) == 0)
                                    {
                                        num9 = Convert.ToDecimal(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "ChoiceID", true) == 0)
                                    {
                                        num10 = Convert.ToInt64(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "InvID", true) == 0)
                                    {
                                        num11 = Convert.ToInt64(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "GroupID", true) == 0)
                                    {
                                        this.GroupID = Convert.ToInt64(strArrays9[1]);
                                        this.SubadditionCount = WebstoreBasePage.Select_WebOtherCostID(Convert.ToInt32(this.GroupID));
                                    }
                                    else if (string.Compare(strArrays9[0], "RowOrderNumber", true) == 0)
                                    {
                                        num12 = Convert.ToInt32(strArrays9[1]);
                                    }
                                    else if (string.Compare(strArrays9[0], "IsMandatoryField", true) == 0)
                                    {
                                        flag1 = (Convert.ToString(strArrays9[1]) == "1" ? true : false);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreChoice_Insertupdate(num10, this.WebOthercostID, str2, empty2, empty3, num9, num11, n + 1, num12, this.GroupID, this.SubadditionCount, flag1);
                            }
                        }
                        string value2 = this.hid_RemoveChoiceValue.Value;
                        chrArray = new char[] { '±' };
                        string[] strArrays10 = value2.Split(chrArray);
                        for (int p = 0; p < (int)strArrays10.Length - 1; p++)
                        {
                            if (strArrays10[p] != "")
                            {
                                long num13 = (long)0;
                                string str5 = strArrays10[p];
                                chrArray = new char[] { '»' };
                                string[] strArrays11 = str5.Split(chrArray);
                                if (strArrays11[1] != "0")
                                {
                                    for (int q = 0; q < (int)strArrays11.Length; q++)
                                    {
                                        num13 = Convert.ToInt64(strArrays11[1]);
                                        WebstoreBasePage.Othercost_WebstoreChoice_Delete(this.WebOthercostID, num13);
                                    }
                                }
                            }
                        }
                    }
                    else if (this.ddlMainCalculation.SelectedValue.ToString().ToLower() == "m")
                    {
                        string value3 = this.hidQtyPrice.Value;
                        chrArray = new char[] { 'µ' };
                        string[] strArrays12 = value3.Split(chrArray);
                        for (int r = 0; r < (int)strArrays12.Length - 1; r++)
                        {
                            if (strArrays12[r] != "")
                            {
                                int num14 = 0;
                                int num15 = 0;
                                decimal num16 = new decimal(0);
                                decimal num17 = new decimal(0);
                                decimal num18 = new decimal(0);
                                long num19 = (long)0;
                                int num20 = 0;
                                string str6 = strArrays12[r];
                                chrArray = new char[] { '±' };
                                string[] strArrays13 = str6.Split(chrArray);
                                for (int s = 0; s < (int)strArrays13.Length; s++)
                                {
                                    string str7 = strArrays13[s];
                                    chrArray = new char[] { '»' };
                                    string[] strArrays14 = str7.Split(chrArray);
                                    if (string.Compare(strArrays14[0], "FromQty", true) == 0)
                                    {
                                        num14 = Convert.ToInt32(strArrays14[1]);
                                    }
                                    else if (string.Compare(strArrays14[0], "ToQty", true) == 0)
                                    {
                                        num15 = Convert.ToInt32(strArrays14[1]);
                                    }
                                    else if (string.Compare(strArrays14[0], "Cost", true) == 0)
                                    {
                                        num16 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (string.Compare(strArrays14[0], "Markup", true) == 0)
                                    {
                                        num17 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (string.Compare(strArrays14[0], "SellingPrice", true) == 0)
                                    {
                                        num18 = Convert.ToDecimal(strArrays14[1]);
                                    }
                                    else if (string.Compare(strArrays14[0], "MatrixID", true) == 0)
                                    {
                                        num19 = Convert.ToInt64(strArrays14[1]);
                                    }
                                    else if (string.Compare(strArrays14[0], "RowOrderNumber", true) == 0)
                                    {
                                        num20 = Convert.ToInt32(strArrays14[1]);
                                    }
                                }
                                WebstoreBasePage.Othercost_WebstoreMatrix_Insertupdate(num19, this.WebOthercostID, this.ddlMatrixType.SelectedValue, num14, num15, num16, num17, num18, num20);
                            }
                        }
                    }
                    else if (SaveType == "Save")
                    {
                        if (base.Request.Params["id"] == null)
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=in"));
                        }
                        else
                        {
                            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=up"));
                        }
                    }
                }
                if (SaveType == "SaveandStay")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/Othercost_webstore.aspx?type=edit&id=", this.WebOthercostID));
                    return;
                }
                if (SaveType == "Save")
                {
                    if (base.Request.Params["id"] != null)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=up"));
                        return;
                    }
                    base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/OtherCost_webStore_View.aspx?su=in"));
                }
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
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("productcatalogue", "isview", "");
            BaseClass baseClass1 = new BaseClass();
            string str1 = baseClass1.ReturnRoles_Privileges_ForGrid("productcatalogue", "isadd", this.Page.Request.Url.ToString());
            string str2 = baseClass1.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdelete", this.Page.Request.Url.ToString());
            this.hdn_finalsavetype.Value = base.Request.Params["type"];
            this.btnCategorySave.Text = this.objlang.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objlang.GetLanguageConversion("Save");
            this.btnDelete.Text = this.objlang.GetLanguageConversion("Delete");
            this.btnsaveStay.Text = this.objlang.GetLanguageConversion("Save_Stay");
            this.ddlCalculationType.Items[0].Text = this.objlang.GetLanguageConversion("Fixed_Value");
            this.ddlCalculationType.Items[1].Text = this.objlang.GetLanguageConversion("Formula");
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString();
            }
            this.gloobj.setpagename("productcatalogue");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.txtName.Focus();
            if (this.type == "edit")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>Home</a>&nbsp;>&nbsp;<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Products"), "</a>&nbsp;>&nbsp;<a href=../ProductCatalogue/OtherCost_webStore_View.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Product_Catalogue_Additional_Option_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("ProductCatalogue_Additional_Option_Edit")));
                base.Title = this.objLanguage.convert(global.pageTitle("Additional Option Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else
            {
                string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp;<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Products"), "</a>&nbsp;>&nbsp;<a href=../ProductCatalogue/OtherCost_webStore_View.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Product_Catalogue_Additional_Option_View"), "</a>" };
                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("ProductCatalogue_Additional_Option_Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Additional Option Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            if (base.Request.Params["type"] == "add")
            {
                this.btnDelete.Visible = false;
            }
            if (!base.IsPostBack)
            {
                this.objSet.Bind_OtherCostCategory(this.ddlCategory, this.CompanyID, "--- Select ---");
                this.ddlMatrixType.Items.Insert(0, " ");
                this.ddlMatrixType.Items[0].Text = this.objlang.GetLanguageConversion("Price_Bands");
                this.ddlMatrixType.Items[0].Value = "pricebands";
                this.ddlMatrixType.Items.Insert(1, " ");
                this.ddlMatrixType.Items[1].Text = this.objlang.GetLanguageConversion("Simple_Matrix");
                this.ddlMatrixType.Items[1].Value = "simplematrix";
                this.ddlMainCalculation.Items.Insert(0, " ");
                this.ddlMainCalculation.Items[0].Text = this.objlang.GetLanguageConversion("Simple_Single_Question");
                this.ddlMainCalculation.Items[0].Value = "q";
                this.ddlMainCalculation.Items.Insert(1, " ");
                this.ddlMainCalculation.Items[1].Text = this.objlang.GetLanguageConversion("Multiple_Choice_Question");
                this.ddlMainCalculation.Items[1].Value = "c";
                this.ddlMainCalculation.Items.Insert(2, " ");
                this.ddlMainCalculation.Items[2].Text = this.objlang.GetLanguageConversion("Matrix");
                this.ddlMainCalculation.Items[2].Value = "m";

                this.ddlMainCalculation.Items.Insert(3, " ");
                this.ddlMainCalculation.Items[3].Text = this.objlang.GetLanguageConversion("Free_Text_Questions");
                this.ddlMainCalculation.Items[3].Value = "f";

                this.ddlMainCalculation.Items.Insert(4, " ");
                this.ddlMainCalculation.Items[4].Text = this.objlang.GetLanguageConversion("Free_Text_Questions_Long");
                this.ddlMainCalculation.Items[4].Value = "l";

            }
            if (!base.IsPostBack)
            {
                if (base.Request.Url.ToString().ToLower().Contains("cop=yes") && base.Request.Params["cop"] != null)
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Copy_Of_Additional_Option_Successfully_Done"), "msg-success", this.plhMessage);
                }
                this.objComp.company_supplier_select(this.CompanyID, this.ddlSupplier);
                for (int i = 0; i < this.ddlSupplier.Items.Count; i++)
                {
                    this.ddlSupplier.Items[i].Attributes.Add("class", "Space_dropdown");
                }
            }
            if (!base.IsPostBack)
            {
                if (this.AccountingCode != "d")
                {
                    this.div_AccountCode.Visible = false;
                }
                else
                {
                    this.div_AccountCode.Visible = true;
                    SettingsBasePage.Bind_AccountingCodes(this.ddlAccountCode, this.CompanyID, string.Concat("--- ", this.objlang.GetLanguageConversion("Select"), " ---"));
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
                                DropDownList dropDownList = this.ddlAccountCode;
                                int num = WebstoreBasePage.WebStore_AccountingCode_Select(this.CompanyID, this.WebOthercostID);
                                dropDownList.SelectedValue = num.ToString();
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
                            if (row["IsCartmandatory"].ToString().ToLower() == "true")
                            {
                                this.chkMandatory.Checked = true;
                            }
                            if (this.ddlMainCalculation.SelectedValue == "q")
                            {
                                this.ddlMainCalculation.SelectedIndex = 0;
                                this.divMandatory.Style.Add("display", "none");
                                this.divNote.Style.Add("display", "none");
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
                                else if (empty == "Groups")
                                {
                                    this.ddlCalculationType.SelectedIndex = 2;
                                }
                                this.ddlCalculationType.Enabled = false;
                                if (Convert.ToBoolean(row["IsSubAdditionOption"]))
                                {
                                    this.chkSubAdditionalOption.Checked = true;
                                }
                                else
                                {
                                    this.chkSubAdditionalOption.Checked = false;
                                }
                                this.chkSubAdditionalOption.Enabled = false;
                                this.DivSubAddition.Style.Add("display", "block");
                            }
                            else if (this.ddlMainCalculation.SelectedValue == "m")
                            {
                                this.divMandatory.Style.Add("display", "none");
                                this.divNote.Style.Add("display", "none");
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

                            else if (this.ddlMainCalculation.SelectedValue == "f" || this.ddlMainCalculation.SelectedValue == "l")
                            {
                                if(this.ddlMainCalculation.SelectedValue == "f")
                                {
                                    this.ddlMainCalculation.SelectedIndex = 3;
                                }
                                else
                                {
                                    this.ddlMainCalculation.SelectedIndex = 4;
                                }
                                this.divMandatory.Style.Add("display", "block");
                                this.divNote.Style.Add("display", "block");
                                this.chkSubAdditionalOption.Enabled = false;
                            }
                            baseClass.SetDDLValue(this.ddlSupplier, row["SupplierID"].ToString());
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
                            int num1 = 0;
                            string str3 = "90%;";
                            StringBuilder stringBuilder = new StringBuilder();
                            foreach (DataRow row1 in WebstoreBasePage.Othercost_WebstoreChoice_Select(this.ID).Rows)
                            {
                                string str4 = "";
                                if (num1 != 0)
                                {
                                    str4 = (num1 % 2 != 0 ? "#EFEFEF" : "");
                                }
                                stringBuilder.Append(string.Concat("<div id='td_", num1, "' >"));
                                str = new object[] { "<div id='div_row_multiple", num1, "' style='background-color:", str4, ";height:25px;vertical-align:middle'>" };
                                stringBuilder.Append(string.Concat(str));
                                stringBuilder.Append("<div class='only5px' style='width: 100%;'>");
                                stringBuilder.Append(" <table style='width:100%;' cellpadding='0px' cellspacing='0px' border='0px' >");
                                stringBuilder.Append("      <tr>");
                                stringBuilder.Append("          <td style='width: 30%;padding-left:5px' align='left'>");
                                object[] objArray = new object[] { "<div id='div_label_", num1, "' style='float: left; width: ", str3, ";' >" };
                                stringBuilder.Append(string.Concat(objArray));
                                object[] objArray1 = new object[] { "<input id='txtlabel_", num1, "'   maxlength=250 type='text' style='width:250px;text-align:left;' class='textboxnew' value='", row1["Label"].ToString().Replace("'", "&#39"), "'/>" };
                                stringBuilder.Append(string.Concat(objArray1));
                                object[] objArray2 = new object[] { "<input type='hidden' name='Rownumber' id='hdn_Multiple_Rownumber_", num1, "' value='", num1, "'>" };
                                stringBuilder.Append(string.Concat(objArray2));
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 38%;' align='left'>");
                                if (row1["CalculationType"].ToString() == "fixed")
                                {
                                    decimal num2 = Convert.ToDecimal(row1["Formula"].ToString());
                                    object[] objArray3 = new object[] { "<input id='txtfixed_or_qty_", num1, "' type='text' maxlength='200' style='width:400px;text-align:left;' onblur='todecimal_functionForThreeDecimalplace(this,this.value);CalculateMultipleSellPrice(this,", num1, ")' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num2, 3, "", false, false, false), "'/>" };
                                    stringBuilder.Append(string.Concat(objArray3));
                                }
                                else if (row1["CalculationType"].ToString() != "Groups")
                                {
                                    string str5 = row1["Formula"].ToString();
                                    object[] objArray4 = new object[] { "<input id='txtfixed_or_qty_", num1, "' type='text' maxlength='1000' style='width:400px;text-align:left;' class='textboxnew' value='", str5, "'/>" };
                                    stringBuilder.Append(string.Concat(objArray4));
                                }
                                else
                                {
                                    string str6 = row1["Formula"].ToString();
                                    object[] companyID = new object[] { "<input id='txtfixed_or_qty_", num1, "' type='text' maxlength='200' style='width:400px;text-align:left;' onclick='displayGroups(", this.CompanyID, ",", num1, ",event);'  onkeyup='displayGroups(", this.CompanyID, ",", num1, ",event);' onblur='CalculateMultipleSellPrice(this,", num1, ")' class='textboxnew' value='", str6, "'/>" };
                                    stringBuilder.Append(string.Concat(companyID));
                                }
                                object[] num3 = new object[] { "<input type='hidden' name='GroupID' id='hdn_GroupID_", num1, "' value='", Convert.ToInt64(row1["GroupID"]), "'>" };
                                stringBuilder.Append(string.Concat(num3));
                                object[] num4 = new object[] { "<input type='hidden' name='IsMandatoryField' id='hdn_IsMandatoryField_", num1, "' value='", Convert.ToInt64(row1["IsMandatoryField"]), "'>" };
                                stringBuilder.Append(string.Concat(num4));
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 13%;' align='center'>");
                                if (row1["CalculationType"].ToString() == "fixed")
                                {
                                    object[] objArray5 = new object[] { "<input id='txtMarkup_multiple_", num1, "'  type='text' maxlength='20' style='width:80px;text-align:right;' class='textboxnew' onblur='Onbur_MultipleMarkup(this,", num1, ");' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Markup"].ToString()), 0, "", false, false, false), "' />" };
                                    stringBuilder.Append(string.Concat(objArray5));
                                }
                                else if (row1["CalculationType"].ToString() != "Groups")
                                {
                                    this.div_MultipleFormulaTag.Style.Add("display", "block");
                                    object[] objArray6 = new object[] { "<input id='txtMarkup_multiple_", num1, "'  type='text' maxlength='20' style='width:80px;text-align:right;' class='textboxnew' onblur='todecimal_function(this,this.value);' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["Markup"].ToString()), 0, "", false, false, false), "' />" };
                                    stringBuilder.Append(string.Concat(objArray6));
                                }
                                else
                                {
                                    this.div_MultipleFormulaTag.Style.Add("display", "none");
                                    stringBuilder.Append(string.Concat("<input id='txtMarkup_multiple_", num1, "'  type='text' maxlength='20' style='width:80px;text-align:right;display:none;' class='textboxnew' onblur='todecimal_function(this,this.value);' value='0' />"));
                                }
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 15%;padding-left:1%;' align='left'>");
                                if (row1["CalculationType"].ToString() == "fixed")
                                {
                                    decimal num5 = Convert.ToDecimal(row1["Formula"].ToString());
                                    decimal num6 = Convert.ToDecimal(row1["Markup"].ToString());
                                    decimal num7 = num5 + ((num5 * num6) / new decimal(100));
                                    object[] objArray7 = new object[] { "<input id='txt_sellingprice_", num1, "' onblur=Calculate_MultipleMarkup(this,'", num1, "'); type='text' maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, num7, 3, "", false, false, false), "' />" };
                                    stringBuilder.Append(string.Concat(objArray7));
                                }
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("          <td style='width: 4%;' align='center'>");
                                if (!Convert.ToBoolean(row1["IsMandatoryField"]))
                                {
                                    stringBuilder.Append(string.Concat("<span id='spn_IsMandatoryField_", num1, "' align='right' style='color: Red; display:none;'>*</span>"));
                                    object[] objArray8 = new object[] { "<img id='img_deleterow_", num1, "' style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row_New(", num1, "); />" };
                                    stringBuilder.Append(string.Concat(objArray8));
                                }
                                else
                                {
                                    this.IsMandatoryField = true;
                                    stringBuilder.Append(string.Concat("<span id='spn_IsMandatoryField_", num1, "' align='right' style='color: Red;'>*</span>"));
                                }
                                stringBuilder.Append(string.Concat("<img style='cursor:pointer;height:10px;width:10px;padding-left:5px;' src='", this.strImagepath, "drag_drop.gif' border='0' title='Re-order'/>"));
                                object[] str7 = new object[] { "<span id='spn_choiceID_", num1, "' style='display:none;'>", row1["ChoiceID"].ToString(), "</span>" };
                                stringBuilder.Append(string.Concat(str7));
                                object[] str8 = new object[] { "<span id='spn_InventoryID_", num1, "' style='display:none;'>", row1["InventoryID"].ToString(), "</span>" };
                                stringBuilder.Append(string.Concat(str8));
                                stringBuilder.Append("          </td>");
                                stringBuilder.Append("     </tr>");
                                stringBuilder.Append(" </table>");
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("</div>");
                                stringBuilder.Append("</div>µ");
                                num1++;
                            }
                            this.hid_data_multiple.Value = stringBuilder.ToString();
                            this.hid_Rows_On_Edit_multiple.Value = num1.ToString();
                            this.pnlCheckRowMultiple.Visible = true;
                        }
                        else if (this.ddlMainCalculation.SelectedValue == "m")
                        {
                            int num8 = 0;
                            string empty1 = string.Empty;
                            string str9 = "50%;";
                            if (empty == "simplematrix")
                            {
                                empty1 = "style='display:none;'";
                                str9 = "90%";
                            }
                            StringBuilder stringBuilder1 = new StringBuilder();
                            foreach (DataRow dataRow1 in WebstoreBasePage.Othercost_WebstoreMatrix_Select(this.ID).Rows)
                            {
                                string str10 = "";
                                if (num8 != 0)
                                {
                                    str10 = (num8 % 2 != 0 ? "#EFEFEF" : "");
                                }
                                stringBuilder1.Append(string.Concat("<div id='td_", num8, "' >"));
                                object[] objArray9 = new object[] { "<div id='div_row_", num8, "' style='background-color:", str10, ";height:25px;vertical-align:middle;padding-top:3px;'>" };
                                stringBuilder1.Append(string.Concat(objArray9));
                                stringBuilder1.Append("<div class='only5px' style='width: 100%;'>");
                                stringBuilder1.Append(" <table style='width:100%;' cellpadding='0px' cellspacing='0px' border='0px' >");
                                stringBuilder1.Append("      <tr>");
                                stringBuilder1.Append("          <td style='width: 24%;' align='center'>");
                                stringBuilder1.Append("<div style='float: left; width: 45%;' align='center'>");
                                object[] objArray10 = new object[] { "<input id='txtQty_from_", num8, "' ", empty1, " onblur='Check_Qty_From(", num8, ",this.value)' maxlength=7 type='text' style='width:50px;text-align:right' value='", dataRow1["FromQuantity"].ToString(), "'  class='textboxnew' />" };
                                stringBuilder1.Append(string.Concat(objArray10));
                                object[] objArray11 = new object[] { "<input type='hidden' name='Rownumber' id='hdn_Matrix_Rownumber_", num8, "' value='", num8, "'>" };
                                stringBuilder1.Append(string.Concat(objArray11));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("<div style='float: left; padding-right: 5px;'>");
                                object[] objArray12 = new object[] { "<span id='spn_qty_sep_", num8, "' ", empty1, ">-</span>" };
                                stringBuilder1.Append(string.Concat(objArray12));
                                stringBuilder1.Append("</div>");
                                object[] objArray13 = new object[] { "<div id='div_txtQty_", num8, "' style='float: left; width: ", str9, ";'>" };
                                stringBuilder1.Append(string.Concat(objArray13));
                                object[] str11 = new object[] { "<input id='txtQty_", num8, "' onblur=QuantityCheck(this.value,", num8, "); maxlength=7 type='text' style='width:80px;text-align:right;' value='", dataRow1["ToQuantity"].ToString(), "'  class='textboxnew' />" };
                                stringBuilder1.Append(string.Concat(str11));
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td style='width: 20%;' align='center'>");
                                object[] objArray14 = new object[] { "<input id='txtCost_", num8, "' type='text' onblur=\"CalculateSellPrice(this,", num8, ",'cost');\" maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Price"].ToString()), 3, "", false, false, false), "' />" };
                                stringBuilder1.Append(string.Concat(objArray14));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td style='width: 20%;' align='center'>");
                                str = new object[] { "<input id='txtMarkup_", num8, "' type='text' onblur=\"CalculateSellPrice(this,", num8, ",'markup');\" maxlength='20' style='width: 80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["Markup"].ToString()), 0, "", false, false, false), "' />" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td style='width: 24%;' align='center'>");
                                str = new object[] { "<input id='txtSellingPrice_", num8, "' onblur=\"Calculate_Markup(this,", num8, ");\" type='text' maxlength='20'  style='width: 80px;text-align:right;' class='textboxnew' value='", this.objcom.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["SellingPrice"].ToString()), 3, "", false, false, false), "' />" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("          <td align='left' style='padding-left:50px;'>");
                                stringBuilder1.Append("<div align='left'>");
                                if (str2.Trim().ToLower() == "true")
                                {
                                    str = new object[] { "<img style='cursor:pointer;height:10px;width:10px' src='", this.strImagepath, "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(", num8, "); />" };
                                    stringBuilder1.Append(string.Concat(str));
                                }
                                stringBuilder1.Append("</div>");
                                str = new object[] { "<span id='spn_matrixID_", num8, "' style='display:none;'>", dataRow1["MatrixID"].ToString(), "</span>" };
                                stringBuilder1.Append(string.Concat(str));
                                stringBuilder1.Append("          </td>");
                                stringBuilder1.Append("     </tr>");
                                stringBuilder1.Append(" </table>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>");
                                stringBuilder1.Append("</div>µ");
                                num8++;
                            }
                            this.hid_data.Value = stringBuilder1.ToString();
                            this.hid_Rows_On_Edit.Value = num8.ToString();
                            this.pnlCheckRow.Visible = true;
                        }
                        else if (this.ddlMainCalculation.SelectedValue == "f" || this.ddlMainCalculation.SelectedValue == "l")
                        {
                            foreach (DataRow dataRow in WebstoreBasePage.Othercost_WebstoreQuestion_Select(this.ID).Rows)
                            {
                                this.txtFreeText.Text = dataRow["Question"].ToString();
                                this.chkHideAdditionalName.Checked = Convert.ToBoolean(dataRow["HideAdditionalOptionName"].ToString());
                                this.chkMandatory.Checked = Convert.ToBoolean(dataRow["IsMandatoryField"].ToString());
                                this.chkSubAdditionalOption.Checked = Convert.ToBoolean(dataRow["IsSubAdditionOption"].ToString());

                            }
                        }
                    }
                }
            }
            this.btnDelete.Attributes.Add("onclick", string.Concat("javascript:var a= window.confirm('Are you sure, You want to delete ", this.txtName.Text, "?');if(a)loadingimage(this.id,'div_deleteprocess');return a;"));
            if (str1.Trim().ToLower() != "false")
            {
                this.btnsaveStay.Visible = true;
                this.btnSave.Visible = true;
                this.div_AddCategory.Visible = true;
            }
            else
            {
                this.btnsaveStay.Visible = false;
                this.btnSave.Visible = false;
                this.div_AddCategory.Visible = false;
            }
            if (str2.Trim().ToLower() == "false")
            {
                this.btnDelete.Visible = false;
                return;
            }
            if (this.type != "add")
            {
                this.btnDelete.Visible = true;
                return;
            }
            this.btnDelete.Visible = false;
        }
    }
}