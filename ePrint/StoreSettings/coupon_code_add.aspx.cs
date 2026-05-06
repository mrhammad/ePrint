using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.StoreSettings
{
    public partial class coupon_code_add : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private CompanyBasePage objComp = new CompanyBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public int CompanyID;

        public int UserID;

        public string action = string.Empty;

        public long ID;

        public languageClass objlang = new languageClass();

        public long AccountID;

        public string type = string.Empty;

        public string strImagepath = global.imagePath();

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

        public coupon_code_add()
        {
        }

        protected void btnCouponCode_Onclick(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            if (this.chk_CouponCode_CanbeusedMultipleTimes.Checked)
            {
                flag = true;
            }
            if (base.Request.Params["type"] != null)
            {
                long num = (long)0;
                bool flag1 = true;
                if (base.Request.Params["type"].Trim().ToLower() == "add")
                {
                    if (!this.chk_CreateMultipleCouponCode.Checked)
                    {
                        num = WebstoreBasePage.CouponCode_Insertupdate(Convert.ToInt64(this.CompanyID), (long)0, Convert.ToInt64(this.AccountID), "Add", base.SpecialEncode(this.txtCouponCode.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToDecimal(this.txtCouponCodeDiscount.Text), this.ddl_CouponCode_TypeSelect.SelectedValue.ToString(), flag);
                        flag1 = Convert.ToBoolean(num);
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(this.txt_CouponCodeFrom.Text); i <= Convert.ToInt32(this.txt_CouponCodeTo.Text); i++)
                        {
                            if (WebstoreBasePage.CouponCode_Insertupdate(Convert.ToInt64(this.CompanyID), (long)0, Convert.ToInt64(this.AccountID), "Check", base.SpecialEncode(string.Concat(this.txtCouponCode.Text, "-", i)), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToDecimal(this.txtCouponCodeDiscount.Text), this.ddl_CouponCode_TypeSelect.SelectedValue.ToString(), flag) == (long)0)
                            {
                                if (stringBuilder.ToString().Length != 0)
                                {
                                    object[] text = new object[] { ", ", this.txtCouponCode.Text, "-", i };
                                    stringBuilder.Append(string.Concat(text));
                                }
                                else
                                {
                                    object[] objArray = new object[] { " ", this.txtCouponCode.Text, "-", i };
                                    stringBuilder.Append(string.Concat(objArray));
                                }
                                flag1 = false;
                            }
                        }
                        if (flag1)
                        {
                            for (int j = Convert.ToInt32(this.txt_CouponCodeFrom.Text); j <= Convert.ToInt32(this.txt_CouponCodeTo.Text); j++)
                            {
                                num = WebstoreBasePage.CouponCode_Insertupdate(Convert.ToInt64(this.CompanyID), (long)0, Convert.ToInt64(this.AccountID), "Add", base.SpecialEncode(string.Concat(this.txtCouponCode.Text, "-", j)), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToDecimal(this.txtCouponCodeDiscount.Text), this.ddl_CouponCode_TypeSelect.SelectedValue.ToString(), flag);
                            }
                        }
                    }
                    if (flag1)
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/coupon_code_view.aspx?su=in"));
                        return;
                    }
                    if (!this.chk_CreateMultipleCouponCode.Checked)
                    {
                        base.Message_Display(string.Concat(" ", this.txtCouponCode.Text, " Coupon Code already exists"), "msg-success", this.plhMessage);
                        return;
                    }
                    base.Message_Display(string.Concat(" ", stringBuilder.ToString(), "<br />Coupon Code already exists. Please reenter your range"), "msg-success", this.plhMessage);
                    this.chk_CreateMultipleCouponCode.Checked = false;
                    return;
                }
                WebstoreBasePage.CouponCode_Insertupdate(Convert.ToInt64(this.CompanyID), Convert.ToInt64(base.Request.Params["id"].ToString()), Convert.ToInt64(this.AccountID), "Update", base.SpecialEncode(this.txtCouponCode.Text), base.SpecialEncode(this.txtUserfriendly.Text), Convert.ToDecimal(this.txtCouponCodeDiscount.Text), this.ddl_CouponCode_TypeSelect.SelectedValue.ToString(), flag);
                base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/coupon_code_view.aspx?su=up"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["type"] != null)
            {
                this.type = base.Request.Params["type"].ToString();
            }
            this.gloobj.setpagename("setting");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.btnCouponCode.Text = this.objLanguage.GetLanguageConversion("Create_Code");
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (base.IsPostBack)
            {
                UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
                this.plhAccountList.Controls.Add(userControl);
                if (str == "")
                {
                    DropDownList dropDownList = (DropDownList)userControl.FindControl("ddl_accountsList");
                    dropDownList.DataSource = this.objAcc.accountsList(this.CompanyID);
                    dropDownList.DataTextField = "accountName";
                    dropDownList.DataValueField = "Categorylist";
                    dropDownList.DataBind();
                    base.SetDDLValue(dropDownList, str.ToString());
                    char[] chrArray = new char[] { '~' };
                    this.AccountID = Convert.ToInt64(str.Split(chrArray)[0]);
                    this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Select");
                }
                else
                {
                    string[] strArrays = str.Split(new char[] { '~' });
                    this.AccountID = (long)Convert.ToInt32(strArrays[0]);
                    string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                    this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                    this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
                }
            }
            if (this.type == "edit")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Storesettings/StoreSsettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/coupon_code_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Coupon_Code_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Coupon_Code_Edit")));
                base.Title = this.objLanguage.convert(global.pageTitle("Coupon Code Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header.SettingName = this.objLanguage.GetLanguageConversion("Coupon_Code");
                this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
                this.btnCouponCode.Text = this.objLanguage.GetLanguageConversion("Update_Code");
            }
            else
            {
                string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Storesettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/coupon_code_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Coupon_Code_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Coupon_Code_Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Coupon Code Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.header.SettingName = this.objLanguage.GetLanguageConversion("Coupon_Code");
                this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            }
            this.objLanguage.GetLanguageConversion("Are_You_Sure_You_Want_To_Delete");
            if (!base.IsPostBack)
            {
                this.chk_CouponCode_CanbeusedMultipleTimes.Checked = true;
                this.ddl_CouponCode_TypeSelect.Items.Add("%");
                this.ddl_CouponCode_TypeSelect.Items.Add(ConnectionClass.CurrencySymbol);
            }
        }
    }
}