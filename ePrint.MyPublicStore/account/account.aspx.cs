using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ePrint.MyPublicStore.account
{
    public partial class account : BaseClass, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected HtmlGenericControl div_NavigationID;

        //protected usercontrols_account_leftpanel account_panel1;

        //protected Label lbl_accountInfo;

        //protected Label lbl_contactInformation;

        //protected Label lbl_information;

        //protected Label lbl_addressBook;

        //protected Label Label2;

        //protected HtmlGenericControl addressBook_Info_left_heading;

        //protected Label lblBillingAddress;

        //protected HtmlGenericControl billing_editAddress;

        //protected Label Label5;

        //protected HtmlGenericControl addressBook_Info_right_heading;

        //protected Label lblShippingAddress;

        //protected HtmlGenericControl shipping_editAddress;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long DefaultBillingID;

        public long DefaultShippingID;

        public long StoreUserID;

        public long AddressID;

        public static int companyID;

        public static long AccountID;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string RewriteModule;

        public string KeySeparator;

        public string Address = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public bool IsPrivate_SystemName;

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

        static account()
        {
        }

        public account()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                account.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                account.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("My Account", Convert.ToInt32(account.companyID), Convert.ToInt32(account.AccountID));
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.RewriteModule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = ConnectionClass.KeySeparator;
            }
            this.IsPrivate_SystemName = this.comm.IsPrivate_SystemName();
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.comm.GetDisplayValue("IsHome", account.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(account.companyID, Convert.ToInt32(account.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                foreach (DataRow row in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    Label lblInformation = this.lbl_information;
                    string[] str = new string[] { row["FirstName"].ToString(), " ", row["LastName"].ToString(), "<br/>", row["EmailID"].ToString() };
                    lblInformation.Text = base.SpecialDecode(string.Concat(str));
                    this.DefaultBillingID = Convert.ToInt64(row["DefaultBillingID"]);
                    this.DefaultShippingID = Convert.ToInt64(row["DefaultShippingID"]);
                }
                long num = (long)0;
                foreach (DataRow dataRow in OrderBasePage.Select_BillingShipping_Address(this.StoreUserID, "", (long)0).Rows)
                {
                    num = Convert.ToInt64(dataRow["ContactID"]);
                    this.DefaultBillingID = Convert.ToInt64(dataRow["InvoiceAddressID"]);
                    this.DefaultShippingID = Convert.ToInt64(dataRow["DeliveryAddressID"]);
                }
                this.Return_address(this.StoreUserID, "", num, this.DefaultBillingID, out this.Address);
                this.lblBillingAddress.Text = base.SpecialDecode(this.Address);
                this.Return_address(this.StoreUserID, "", num, this.DefaultShippingID, out this.Address);
                this.lblShippingAddress.Text = base.SpecialDecode(this.Address);
                if (this.comm.GetDisplayValue("IsHome", account.AccountID) != "true")
                {
                    this.div_NavigationID.Style.Add("display", "none");
                }
                else
                {
                    this.div_NavigationID.Style.Add("display", "block");
                }
            }
            else if (this.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            else
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
            }
            if (this.lblBillingAddress.Text.Trim() == "")
            {
                this.billing_editAddress.Attributes.Add("style", "display:none");
                this.addressBook_Info_left_heading.Attributes.Add("style", "display:none");
            }
            if (this.lblShippingAddress.Text.Trim() == "")
            {
                this.shipping_editAddress.Attributes.Add("style", "display:none");
                this.addressBook_Info_right_heading.Attributes.Add("style", "display:none");
            }
        }

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShippingAddress_OnAddressID(StoreUserID, AddressID).Rows)
            {
                string[] strArrays = row["Address"].ToString().Split(new char[] { '\u00B6' });
                if (row["AddressLabel"].ToString().Trim() != "")
                {
                    empty = string.Concat(empty, row["AddressLabel"], "<br/>");
                }
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        if (i != 6)
                        {
                            empty = (i != 7 ? string.Concat(empty, strArrays[i], "<br/>") : string.Concat(empty, "F: ", strArrays[i], "<br/>"));
                        }
                        else
                        {
                            empty = string.Concat(empty, "T: ", strArrays[i], "<br/>");
                        }
                    }
                }
            }
            Address = empty;
        }
    }
}