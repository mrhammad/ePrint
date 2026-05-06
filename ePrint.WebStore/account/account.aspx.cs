using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ePrint.WebStore.account
{
    public partial class account : BaseClass, IRequiresSessionState
    {
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

        public string strImagepath = BaseClass.SitePath;

        private MemoryStream stream = new MemoryStream();

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

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

        public string VersionNumber = ConnectionClass.VersionNumber;

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
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/account.aspx'>", this.objLanguage.GetLanguageConversion("My_Account"), "</a><span Class='floatLeft'>&nbsp;</span>" };
            label.Text = string.Concat(sitePath);
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
            if (this.Session["StoreUserID"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            else
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                DataTable dataTable = LoginBasePage.Select_DeptDetail_For_StoreUser(account.AccountID, this.StoreUserID);
                string empty = string.Empty;
                foreach (DataRow row in dataTable.Rows)
                {
                    empty = row["Deptname"].ToString();
                }
                foreach (DataRow dataRow in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    Label lblInformation = this.lbl_information;
                    string[] str = new string[] { dataRow["FirstName"].ToString(), " ", dataRow["LastName"].ToString(), "<br/>", dataRow["EmailID"].ToString(), "<br/>", empty };
                    lblInformation.Text = string.Concat(str);
                    this.lbl_information.Text = base.SpecialDecode(this.lbl_information.Text);
                    this.DefaultBillingID = Convert.ToInt64(dataRow["DefaultBillingID"]);
                    this.DefaultShippingID = Convert.ToInt64(dataRow["DefaultShippingID"]);
                }
                long num = (long)0;
                DataTable dataTable1 = OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID);
                IEnumerator enumerator = dataTable1.Rows.GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        num = Convert.ToInt64(current["ContactID"]);
                        this.DefaultBillingID = Convert.ToInt64(current["InvoiceAddressID"]);
                        this.DefaultShippingID = Convert.ToInt64(current["DeliveryAddressID"]);
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                this.Return_address(this.StoreUserID, "", num, this.DefaultBillingID, out this.Address);
                this.lblBillingAddress.Text = base.SpecialDecode(this.Address);
                this.Return_address(this.StoreUserID, "", num, this.DefaultShippingID, out this.Address);
                this.lblShippingAddress.Text = base.SpecialDecode(this.Address);
            }
            DataTable dataTable2 = LoginBasePage.AddEditAddress_select(account.AccountID);
            if (dataTable2.Rows.Count > 0 && dataTable2.Rows[0]["users_edit_addresses_app"].ToString() == "N")
            {
                this.billing_editAddress.Attributes.Add("style", "display:none");
                this.shipping_editAddress.Attributes.Add("style", "display:none");
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
                        if (i == 0 && strArrays[0].Length >= 2)
                        {
                            empty = string.Concat(empty, strArrays[0], "<br/>");
                        }
                        if (i == 1 && strArrays[1].Length >= 2)
                        {
                            empty = string.Concat(empty, strArrays[1], "<br/>");
                        }
                        if (i == 2 && strArrays[2].Length >= 2)
                        {
                            empty = (strArrays[3].Length >= 2 || strArrays[4].Length >= 2 ? string.Concat(empty, strArrays[2], "&nbsp;") : string.Concat(empty, strArrays[2]));
                        }
                        if (i == 3 && strArrays[3].Length >= 2)
                        {
                            empty = (strArrays[4].Length < 2 ? string.Concat(empty, strArrays[3]) : string.Concat(empty, strArrays[3], "&nbsp;"));
                        }
                        if (i == 4 && strArrays[4].Length >= 2)
                        {
                            empty = string.Concat(empty, strArrays[4]);
                        }
                        if (i == 5 && strArrays[5].Length >= 2)
                        {
                            empty = string.Concat(empty, "<br/>", strArrays[5], "<br/>");
                        }
                        if (i == 6 && strArrays[6].Length >= 2)
                        {
                            empty = string.Concat(empty, "<br/>T:&nbsp;", strArrays[6], "<br/>");
                        }
                        if (i == 7 && strArrays[7].Length >= 2)
                        {
                            empty = (strArrays[6].Length != 1 ? string.Concat(empty, "F:&nbsp;", strArrays[7], "<br/>") : string.Concat(empty, "<br/>F:&nbsp;", strArrays[7], "<br/>"));
                        }
                    }
                }
            }
            Address = empty;
        }
    }
}