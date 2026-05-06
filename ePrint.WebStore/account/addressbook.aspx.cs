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

namespace ePrint.WebStore.account
{
    public partial class addressbook : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected usercontrols_leftpanelpanel1;

        //protected Button btn_new_address;

        //protected HtmlGenericControl addressbook_Content_left_header;

        //protected Label lbl_addressDetails;

        //protected HtmlAnchor href_change_billing_address;

        //protected HtmlGenericControl shipping_Content_left_header;

        //protected Label lbl_ashippingDetails;

        //protected HtmlAnchor href_change_shipping_address;

        //protected PlaceHolder plhAddition;

        //protected HtmlGenericControl AdditionalAddress;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

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

        public string strImagepath = BaseClass.imagePath();

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

        static addressbook()
        {
        }

        public addressbook()
        {
        }

        protected void btn_new_address_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbooknew.aspx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/account.aspx' >", this.objLanguage.GetLanguageConversion("My_Account"), "<span Class='floatLeft'>&nbsp;</span></a><a Class='floatLeft' href ='", BaseClass.SitePath, "account/addressbook.aspx' ><span Class='floatLeft'>&nbsp;>>&nbsp;</span></a>", this.objLanguage.GetLanguageConversion("My_Address_book") };
            label.Text = string.Concat(sitePath);
            this.btn_new_address.Text = this.objLanguage.GetLanguageConversion("Add_a_New_address");
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
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = ConnectionClass.KeySeparator;
            }
            DataTable dataTable = LoginBasePage.AddEditAddress_select(addressbook.AccountID);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["users_add_addresses_app"].ToString() == "N")
                {
                    this.btn_new_address.Attributes.Add("style", "display:none");
                }
                if (dataTable.Rows[0]["users_edit_addresses_app"].ToString() == "N")
                {
                    this.href_change_billing_address.Attributes.Add("style", "display:none");
                    this.href_change_shipping_address.Attributes.Add("style", "display:none");
                }
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
                foreach (DataRow row in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.DefaultBillingID = Convert.ToInt64(row["DefaultBillingID"]);
                    this.DefaultShippingID = Convert.ToInt64(row["DefaultShippingID"]);
                }
                this.Return_address(this.StoreUserID, "", this.DefaultBillingID, out this.Address);
                this.lbl_addressDetails.Text = this.Address;
                this.Return_address(this.StoreUserID, "", this.DefaultShippingID, out this.Address);
                this.lbl_ashippingDetails.Text = this.Address;
                if (!base.IsPostBack)
                {
                    int num = 0;
                    foreach (DataRow dataRow in OrderBasePage.B2B_Select_All_Address_ByStoreUserID(this.StoreUserID).Rows)
                    {
                        this.DefaultBillingID = Convert.ToInt64(dataRow["InvoiceAddressID"]);
                        this.DefaultShippingID = Convert.ToInt64(dataRow["DeliveryAddressID"]);
                        if (Convert.ToInt64(dataRow["AddressID"]) == this.DefaultBillingID || Convert.ToInt64(dataRow["AddressID"]) == this.DefaultShippingID)
                        {
                            continue;
                        }
                        if (num == 0 || num % 2 == 0)
                        {
                            if (num > 0)
                            {
                                this.plhAddition.Controls.Add(new LiteralControl("</tr>"));
                            }
                            this.plhAddition.Controls.Add(new LiteralControl("<tr>"));
                        }
                        this.plhAddition.Controls.Add(new LiteralControl("<td class='td500px'>"));
                        this.plhAddition.Controls.Add(new LiteralControl("<div id='addressbook_Content_right_contents_details'>"));
                        Label label1 = new Label()
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
                        label1.Text = base.SpecialDecode(this.Address);
                        this.plhAddition.Controls.Add(label1);
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                        this.plhAddition.Controls.Add(new LiteralControl("<div id='addressbook_Content_right_contents_link'>"));
                        string str = "additional";
                        if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["users_edit_addresses_app"].ToString() != "N")
                        {
                            ControlCollection controls = this.plhAddition.Controls;
                            object[] objArray = new object[] { "<a href='#'  class='anchorColor' onclick='javascript:onclick_address(", Convert.ToInt64(dataRow["AddressID"]), ",\"", str, "\");' id='href_editAddress_", num, "'>", this.objLanguage.GetLanguageConversion("Edit"), " </a>| <a href='#'  class='anchorColor' id='href_deleteAddress_", num, "' onclick='delete_address(", Convert.ToInt64(dataRow["AddressID"]), ");'>", this.objLanguage.GetLanguageConversion("Delete"), " </a>" };
                            controls.Add(new LiteralControl(string.Concat(objArray)));
                        }
                        this.plhAddition.Controls.Add(new LiteralControl("<div class='clearBoth'>&nbsp;</div>"));
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                        this.plhAddition.Controls.Add(new LiteralControl("</td>"));
                        if (num % 2 != 0)
                        {
                            this.plhAddition.Controls.Add(new LiteralControl("</tr>"));
                        }
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
                        Label label2 = new Label()
                        {
                            Text = this.objLanguage.GetLanguageConversion("You_have_no_additional_address_entries_in_your_address_book"),
                            ID = "lblNoaddition"
                        };
                        label2.Style.Add("font-weight", "bold");
                        this.plhAddition.Controls.Add(label2);
                        this.plhAddition.Controls.Add(new LiteralControl("</div>"));
                    }
                    if (ConnectionClass.ServerName.ToLower().Trim() != "smp")
                    {
                        if (dataTable.Rows.Count <= 0)
                        {
                            this.AdditionalAddress.Attributes.Add("style", "display:none");
                            return;
                        }
                        if (!(dataTable.Rows[0]["users_select_addresses_app"].ToString() == "Y") && !(dataTable.Rows[0]["users_select_addresses_dept"].ToString() == "Y") && !(dataTable.Rows[0]["users_select_addresses_user"].ToString() == "Y"))
                        {
                            this.AdditionalAddress.Attributes.Add("style", "display:none");
                            return;
                        }
                        this.AdditionalAddress.Attributes.Add("style", "display:block");
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
                            empty = (strArrays[3].Length >= 2 || strArrays[4].Length >= 2 ? string.Concat(empty, strArrays[2], ",&nbsp;") : string.Concat(empty, strArrays[2]));
                        }
                        if (i == 3 && strArrays[3].Length >= 2)
                        {
                            empty = (strArrays[4].Length < 2 ? string.Concat(empty, strArrays[3]) : string.Concat(empty, strArrays[3], ",&nbsp;"));
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

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_BillingShipping_Address(AddressID).Rows)
            {
                string[] strArrays = row["Address"].ToString().Split(new char[] { ',' });
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
                            empty = (strArrays[3].Length >= 2 || strArrays[4].Length >= 2 ? string.Concat(empty, strArrays[2], ",") : string.Concat(empty, strArrays[2]));
                        }
                        if (i == 3 && strArrays[3].Length >= 2)
                        {
                            empty = (strArrays[4].Length < 2 ? string.Concat(empty, strArrays[3]) : string.Concat(empty, strArrays[3], ","));
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