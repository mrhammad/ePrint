using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore.usercontrol
{
    public partial class account_leftpanel : UserControl
    {
        //protected HtmlGenericControl href_account;

        //protected HtmlGenericControl href_accountedit;

        //protected HtmlGenericControl href_addressbook;

        //protected HtmlGenericControl href_myorder;

        //protected HtmlGenericControl lbl_myCart_content;

        //protected HtmlGenericControl lbl_cartPrice;

        //protected HtmlGenericControl spn_ContinueShopping;

        //protected HtmlGenericControl spn_separator;

        //protected HtmlGenericControl spn_ContinueCheckout;

        //protected PlaceHolder plhLeftBanner;

        //protected HtmlGenericControl account_leftBanner;

        //protected Panel pnlaccount;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string SesseionKey = string.Empty;

        public long StoreUserID;

        public int CompanyID;

        public static int AccountID;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static account_leftpanel()
        {
        }

        public account_leftpanel()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EprintConfigurationManager.AppSettings["SitePath"] != null)
            {
                this.strSitepath = EprintConfigurationManager.AppSettings["SitePath"];
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            base.Request.Url.ToString().ToLower().Contains("account/account");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                account_leftpanel.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            int num = 0;
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            foreach (DataRow row in CartBasePage.Select_CartItems(this.SesseionKey, "", this.StoreUserID).Rows)
            {
                num2 = num2 + Convert.ToDecimal(row["CartTax"].ToString());
                num1 = num1 + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                num3 = Convert.ToDecimal(row["TotalCartAdditionalPrice"].ToString());
                num++;
            }
            if (num == 0)
            {
                this.lbl_cartPrice.Style.Add("display", "none");
                this.spn_ContinueShopping.Style.Add("display", "none");
                this.spn_ContinueCheckout.Style.Add("display", "none");
                this.spn_separator.Style.Add("display", "none");
            }
            if (num != 0 && num == 1)
            {
                string str = "There is ";
                string str1 = string.Concat(num.ToString(), " item");
                string str2 = " in the cart.";
                HtmlGenericControl lblMyCartContent = this.lbl_myCart_content;
                string[] strArrays = new string[] { str, "<span class='lbl_ItemColor'>", str1, "</span>", str2 };
                lblMyCartContent.InnerHtml = string.Concat(strArrays);
                this.lbl_cartPrice.InnerHtml = string.Concat("Total Price: ", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal((num2 + num1) + num3), 2, "", false, false, true));
            }
            else if (num != 0 && num > 1)
            {
                string str3 = "There are ";
                string str4 = string.Concat(num.ToString(), " items");
                string str5 = " in the cart.";
                HtmlGenericControl htmlGenericControl = this.lbl_myCart_content;
                string[] strArrays1 = new string[] { str3, "<span class='lbl_ItemColor'>", str4, "</span>", str5 };
                htmlGenericControl.InnerHtml = string.Concat(strArrays1);
                this.lbl_cartPrice.InnerHtml = string.Concat("Total Price:", this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal((num2 + num1) + num3), 2, "", false, false, true));
            }
            int num4 = 0;
            int num5 = 0;
            DataTable dataTable = CMSBasePage.Select_BannerImages((long)account_leftpanel.AccountID, 0, "L", "My Accounts");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (num5 == 0)
                {
                    this.plhLeftBanner.Controls.Add(new LiteralControl("<div>"));
                }
                object[] item = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=", dataRow["bannerImage"], "&amp;type=b&aid=", account_leftpanel.AccountID, "&cid=", this.CompanyID };
                string str6 = string.Concat(item);
                if (dataRow["URL"].ToString() == "")
                {
                    ControlCollection controls = this.plhLeftBanner.Controls;
                    object[] objArray = new object[] { "<div><img src='", str6, "' class='imgWidth' alt='", dataRow["bannerTitle"], "' style='border: none; border-color: White;' /></div>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                else
                {
                    ControlCollection controlCollections = this.plhLeftBanner.Controls;
                    object[] item1 = new object[] { "<div><a href='", dataRow["URL"], "'><img src='", str6, "' alt='", dataRow["bannerTitle"], "' style='border: none; border-color: White;' /></a></div>" };
                    controlCollections.Add(new LiteralControl(string.Concat(item1)));
                }
                num5++;
                num4++;
            }
            if (num5 != 0)
            {
                this.plhLeftBanner.Controls.Add(new LiteralControl("</div>"));
            }
            if (num4 == 0)
            {
                this.account_leftBanner.Attributes.Add("class", "account_leftBanner_empty");
            }
        }
    }
}