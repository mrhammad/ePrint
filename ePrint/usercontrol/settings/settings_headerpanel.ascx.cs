using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
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

namespace ePrint.usercontrol.settings
{
    public partial class settings_headerpanel : UsercontrolBasePage
    {
        public string AccList = string.Empty;

        public string SettingName = string.Empty;

        public DataTable dtAccountList = new DataTable();

        protected string strSitepath = global.sitePath();

        public int UserID;

        public int AccountID;

        public languageClass objLanguage = new languageClass();

        public string lblAccountName = string.Empty;

        public string Account_Name = string.Empty;

        public string Account_Type = string.Empty;

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

        public settings_headerpanel()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.plhAccountList.Controls.Add(new LiteralControl("<table>"));
            int num = 0;
            int num1 = 0;
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            if (base.Request.Params["type"] == "edit" || base.Request.Params["type"] == "add" || base.Request.Params["mode"] == "edit")
            {
                this.spn_change.Visible = false;
            }
            foreach (DataRow row in this.dtAccountList.Rows)
            {
                string str1 = row["accountName"].ToString();
                string str2 = row["Categorylist"].ToString();
                if (this.SettingName.ToLower() != "logout settings" && num == 0 && row["accountType"].ToString().ToLower() == "p")
                {
                    this.plhAccountList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("<a style='color: Black' href =javascript:void(0); >----------Private-----------</a>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("</div>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("</td>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("</tr>"));
                    num++;
                }
                if (num1 == 0 && row["accountType"].ToString().ToLower() == "x")
                {
                    this.plhAccountList.Controls.Add(new LiteralControl("<tr>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("<a style='color: Black' href =javascript:void(0); >-----------Public-----------</a>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("</div>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("</td>"));
                    this.plhAccountList.Controls.Add(new LiteralControl("</tr>"));
                    num1++;
                }
                this.plhAccountList.Controls.Add(new LiteralControl("<tr>"));
                this.plhAccountList.Controls.Add(new LiteralControl("<td class='DepartmentHover'>"));
                this.plhAccountList.Controls.Add(new LiteralControl("<div style='margin-top: 3px; margin-bottom: 3px; cursor:default; color:Black'>"));
                ControlCollection controls = this.plhAccountList.Controls;
                string[] strArrays1 = new string[] { "<a style='color: Black' href =javascript:AccountSelect('", str2, "'); >", str1, "</a>" };
                controls.Add(new LiteralControl(string.Concat(strArrays1)));
                this.plhAccountList.Controls.Add(new LiteralControl("</div>"));
                this.plhAccountList.Controls.Add(new LiteralControl("</tr>"));
                this.plhAccountList.Controls.Add(new LiteralControl("</td>"));
                if (this.AccountID != Convert.ToInt32(row["accountID"]))
                {
                    continue;
                }
                this.Account_Name = str1;
                this.Account_Type = row["accounttype"].ToString();
            }
            this.plhAccountList.Controls.Add(new LiteralControl("</table>"));
            if (str == "")
            {
                this.lblSettingName.Text = this.SettingName;
                this.spn_change.InnerText = this.objLanguage.GetLanguageConversion("Select");
                return;
            }
            if (this.Account_Name != "")
            {
                string[] strArrays2 = this.Account_Name.Split(new char[] { '~' });
                if ((this.SettingName.ToLower() == "approval system" || this.SettingName.ToLower() == "manage campaign" || this.SettingName.ToLower() == "registration option") && this.Account_Type.ToLower() == "x")
                {
                    this.lbleStore.Text = "";
                    this.lbleStore2.Text = "";
                    this.lblAccountName = "";
                }
                else
                {
                    this.lbleStore.Text = this.objBase.SpecialDecode(strArrays2[0]);
                    this.lbleStore2.Text = this.objBase.SpecialDecode(strArrays2[0]);
                    this.lblAccountName = this.objBase.SpecialDecode(strArrays2[0]);
                }
            }
            this.lblSettingName.Text = this.SettingName;
        }

        public void Save_OnClick(object sender, EventArgs e)
        {
            if (this.hdnAccountId.Value != "")
            {
                string[] strArrays = this.hdnAccountId.Value.Split(new char[] { '~' });
                base.Session["AccountType"] = WebstoreBasePage.SelectAccountType(Convert.ToInt32(strArrays[0].ToString()));
                SettingsBasePage.UpdateSelectedAccountID((long)this.UserID, Convert.ToInt64(strArrays[0].ToString()));
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/customize_footer.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/customize_footer.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/customize_header.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/customize_header.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/edit_style_sheet.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/edit_style_sheet.aspx"));
                    return;
                }
                if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_banner.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_banner.aspx"));
                    return;
                }
                if (!base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx"))
                {
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_email.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_email_edit.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_email_edit.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_page.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_page.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_page_edit.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_page_edit.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/payment_option.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/payment_option.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/productcategory_reorder.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/productcategory_reorder.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/shipping_option.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/shipping_option.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/products_reorder.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/products_reorder.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/termsandconditions.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/TermsAndConditions.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/deliverycost.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/DeliveryCost.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/zip2tax.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/zip2tax.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/estore_email_settings.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/estore_email_settings.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/approval_system.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/approval_system.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/registration_option.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/registration_option.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/ordering_process.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/ordering_process.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("storesettings/estoredisplaysettings_new.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/eStoreDisplaySettings_new.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/cart_additional_options_view.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/cart_additional_options_view.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/cart_additional_options.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/cart_additional_options.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/manage_campaign.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/manage_campaign.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/import_order/import_order.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "Import_Order/import_order.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/LogoutSettings.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "storesettings/LogoutSettings.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/coupon_code_view.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/coupon_code_view.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/estorespendlimit.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/eStoreSpendLimit.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/estorehideprice.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/eStoreHidePrice.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/preflight_options_estore.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/PreFlight_Options_Estore.aspx"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/estorereports.aspx"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/eStoreReports.aspx"));
                    }
                }
                else
                {
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=em"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=em"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=bli"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=bli"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=lo"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=lo"));
                        return;
                    }
                    if (base.Request.Url.ToString().ToLower().Contains("/storesettings/phrase_book.aspx?type=li"))
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/Phrase_Book.aspx?type=li"));
                        return;
                    }
                }
            }
        }
    }
}