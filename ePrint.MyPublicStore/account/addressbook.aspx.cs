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
    public partial class addressbook : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected usercontrols_account_leftpanel account_panel1;

        //protected Button btn_new_address;

        //protected HtmlGenericControl addressbook_Content_left_header;

        //protected Label lbl_addressDetails;

        //protected HtmlAnchor href_change_billing_address;

        //protected HtmlGenericControl shipping_Content_left_header;

        //protected Label lbl_ashippingDetails;

        //protected HtmlAnchor href_change_shipping_address;

        //protected PlaceHolder plhAddition;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long DefaultBillingID;

        public long DefaultShippingID;

        public long StoreUserID;

        public long ContactID;

        public int IsAdditionAddress;

        public static int companyID;

        public static long AccountID;

        public string RewriteModule;

        public string KeySeparator;

        public string Address;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

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

        static addressbook()
        {
        }

        public addressbook()
        {
        }

        protected void btn_new_address_Click(object sender, EventArgs e)
        {
            if (this.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbooknew.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbooknew", ConnectionClass.FileExtension));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_new_address.Text = this.objLanguage.GetLanguageConversion("Add_New_Address");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                addressbook.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                addressbook.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("Address book", Convert.ToInt32(addressbook.companyID), Convert.ToInt32(addressbook.AccountID));
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
            if (this.comm.GetDisplayValue("IsHome", addressbook.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(addressbook.companyID), Convert.ToInt32(addressbook.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.Session["StoreUserID"] == null)
            {
                if (this.RewriteModule.ToLower() == "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            else
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                foreach (DataRow row in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.DefaultBillingID = Convert.ToInt64(row["DefaultBillingID"]);
                    this.DefaultShippingID = Convert.ToInt64(row["DefaultShippingID"]);
                }
                this.Return_address(this.StoreUserID, "", this.DefaultBillingID, out this.Address);
                this.lbl_addressDetails.Text = base.SpecialDecode(this.Address);
                this.Return_address(this.StoreUserID, "", this.DefaultShippingID, out this.Address);
                this.lbl_ashippingDetails.Text = base.SpecialDecode(this.Address);
                if (!base.IsPostBack)
                {
                    int num = 0;
                    foreach (DataRow dataRow in OrderBasePage.Select_BillingShipping_Address(this.StoreUserID, "", (long)0).Rows)
                    {
                        this.DefaultBillingID = Convert.ToInt64(dataRow["InvoiceAddressID"]);
                        this.DefaultShippingID = Convert.ToInt64(dataRow["DeliveryAddressID"]);
                        if (Convert.ToInt64(dataRow["AddressID"]) == this.DefaultBillingID || Convert.ToInt64(dataRow["AddressID"]) == this.DefaultShippingID)
                        {
                            continue;
                        }
                        this.plhAddition.Controls.Add(new LiteralControl("<div id='addressbook_Content_right_contents_details'>"));
                        Label label = new Label()
                        {
                            ID = string.Concat("lbladdition_", num)
                        };
                        if (dataRow["FirstName"].ToString() != "")
                        {
                            this.IsAdditionAddress = 0;
                        }
                        else
                        {
                            this.IsAdditionAddress = 1;
                        }
                        Convert.ToInt64(dataRow["ContactID"]);
                        this.Return_address(this.StoreUserID, "", Convert.ToInt64(dataRow["ContactID"]), Convert.ToInt64(dataRow["AddressID"]), out this.Address);
                        label.Text = base.SpecialDecode(this.Address);
                        this.plhAddition.Controls.Add(label);
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                        this.plhAddition.Controls.Add(new LiteralControl("<div id='addressbook_Content_right_contents_link'>"));
                        string str = "additional";
                        ControlCollection controls = this.plhAddition.Controls;
                        object[] objArray = new object[] { "<a href='#'  class='anchorColor' onclick='javascript:onclick_address(", Convert.ToInt64(dataRow["AddressID"]), ",\"", str, "\");' id='href_editAddress_", num, "'>", this.objLanguage.GetLanguageConversion("Edit_Address"), " </a>| <a href='#'  class='anchorColor' id='href_deleteAddress_", num, "' onclick='delete_address(", Convert.ToInt64(dataRow["AddressID"]), ");'>", this.objLanguage.GetLanguageConversion("Delete_Address"), " </a>" };
                        controls.Add(new LiteralControl(string.Concat(objArray)));
                        this.plhAddition.Controls.Add(new LiteralControl("<div class='clearBoth'>&nbsp;</div>"));
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                        num++;
                    }
                    this.Return_address(this.StoreUserID, "", this.DefaultBillingID, out this.Address);
                    this.lbl_addressDetails.Text = base.SpecialDecode(this.Address);
                    this.Return_address(this.StoreUserID, "", this.DefaultShippingID, out this.Address);
                    this.lbl_ashippingDetails.Text = base.SpecialDecode(this.Address);
                    if (this.lbl_addressDetails.Text.Trim() == "")
                    {
                        this.href_change_billing_address.Attributes.Add("style", "display:none");
                        this.addressbook_Content_left_header.Attributes.Add("style", "display:none");
                    }
                    if (this.lbl_ashippingDetails.Text.Trim() == "")
                    {
                        this.href_change_shipping_address.Attributes.Add("style", "display:none");
                        this.shipping_Content_left_header.Attributes.Add("style", "display:none");
                    }
                    if (num == 0)
                    {
                        this.plhAddition.Controls.Add(new LiteralControl("<div>"));
                        Label label1 = new Label()
                        {
                            Text = this.objLanguage.GetLanguageConversion("You_have_no_additional_address_entries_in_your_address_book"),
                            ID = "lblNoaddition"
                        };
                        label1.Style.Add("font-weight", "bold");
                        this.plhAddition.Controls.Add(label1);
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                        return;
                    }
                }
            }
        }

        public void Return_address(long StoreUserID, string type, long AddressID, out string Address)
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

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShipping_Address(StoreUserID, "", ContactID).Rows)
            {
                if (Convert.ToInt64(row["AddressID"].ToString()) != AddressID)
                {
                    continue;
                }
                string[] strArrays = row["Address"].ToString().Split(new char[] { ',' });
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