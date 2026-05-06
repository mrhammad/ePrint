using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore.usercontrol
{
    public partial class invoice_del_Info : UserControl
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel LoadingPanel1;

        //protected Label lblAddressInfoHeader;

        //protected HtmlTableRow tr_AddressInfoHeader;

        //protected Label lblDelivery_Address;

        //protected Label lblShippingAddress;

        //protected HtmlTableCell td_Deladdr;

        //protected Label lblInvoice_Address;

        //protected Label lblBillingAddress;

        //protected HtmlTableCell td_invaddr;

        //protected Label lblDeliveryLine;

        //protected LinkButton lnkEdit_Ship;

        //protected HtmlTableCell tdEditAddress1;

        //protected HtmlTableCell tdChooseAddress1;

        //protected HtmlTableCell tdAddAddress1;

        //protected HtmlTableCell td_Del_Choose;

        //protected Label Label1;

        //protected LinkButton lnkEdit_Bill;

        //protected HtmlTableCell tdEditAddress;

        //protected HtmlTableCell tdChooseAddress;

        //protected HtmlTableCell tdAddAddress;

        //protected HtmlTableCell td_Inv_Choose;

        //protected HtmlTableRow trChangeAddress;

        //protected Label lblNew_Address;

        //protected Label lblEdit_Address;

        //protected Label lblAddress_LAbel;

        //protected TextBox txtaddressLabelBilling;

        //protected HtmlGenericControl spnExample;

        //protected Label lblAddressBill1;

        //protected Label lblBillAdd1_UC;

        //protected TextBox txt_address_billing1;

        //protected RequiredFieldValidator Required_Address1;

        //protected Label lblAddressBill2;

        //protected Label lblBillAdd2_UC;

        //protected TextBox txt_address_billing2;

        //protected RequiredFieldValidator Required_Address2;

        //protected Label lblAddressBill3;

        //protected Label lblBillAdd3_UC;

        //protected TextBox txt_address_billing3;

        //protected RequiredFieldValidator Required_Address3;

        //protected Label lblAddressBill4;

        //protected Label lblBillAdd4_UC;

        //protected TextBox txt_address_billing4;

        //protected RequiredFieldValidator Required_Address4;

        //protected Label lblAddressBill5;

        //protected Label lblBillAdd5_UC;

        //protected TextBox txt_address_billing5;

        //protected RequiredFieldValidator Required_Address5;

        //protected Label lbl_Country;

        //protected DropDownList ddlCountry;

        //protected RequiredFieldValidator Required_Country;

        //protected HtmlGenericControl sdf;

        //protected Label lbl_Telephne;

        //protected TextBox txt_telephone_billing;

        //protected Label lblFax;

        //protected TextBox txt_fax_billing;

        //protected CheckBox chkCopytoInvoice;

        //protected Label lblcopyaddress;

        //protected HtmlTableRow CopyAddress;

        //protected CheckBox Chk_makedefaultAddres_Delivery;

        //protected Label lblMakedeafultaddres_Delivery;

        //protected HtmlTableRow MakeDefaultAddress_Delivery;

        //protected CheckBox ChkcopytoDel;

        //protected Label lblcopyInvaddress;

        //protected HtmlTableRow CopyInvtoDelAddress;

        //protected CheckBox Chk_makedefaultAddres_Invoice;

        //protected Label lblMakedeafultaddres_Invoice;

        //protected HtmlTableRow MakeDefaultAddress_Invoice;

        //protected Button btnSave_Bill;

        //protected Button btnSave_Ship;

        //protected Button btn_Update_bill;

        //protected Button btn_Update_Ship;

        //protected Label lblAddress_Book;

        //protected RadTextBox grd_Search_bill;

        //protected ImageButton imgSearch_Bill;

        //protected Label lblListofAllAddress;

        //protected RadGrid rdGrd_bill_Choose;

        //protected RadTextBox grd_Search_ship;

        //protected ImageButton imgSearch_Ship;

        //protected HtmlGenericControl spnList;

        //protected RadGrid rdgrd_ship_choose;

        //protected HiddenField hdnChkInvAddress;

        //protected HiddenField hdnChkDelAddress;

        //protected HiddenField hdnTotalAddressCount;

        private OrderBasePage objOrder = new OrderBasePage();

        private BaseClass objBase = new BaseClass();

        public languageClass objLanguage = new languageClass();

        private commonclass comm = new commonclass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long BillingAddressID;

        public long ShippingAddressID;

        public long StoreUserID;

        public long AccountID;

        public string strImagepath = BaseClass.imagePath();

        private string users_change_addresses_app;

        private string users_change_addresses_dept;

        private string users_change_addresses_user;

        private string users_select_addresses_app;

        private string users_select_addresses_dept;

        private string users_select_addresses_user;

        private string users_edit_addresses_app;

        private string users_edit_addresses_dept;

        private string users_edit_addresses_user;

        private string users_add_addresses_app;

        private string users_add_addresses_dept;

        private string users_add_addresses_user;

        private string MainApprover;

        private string DeptApprover;

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

        public invoice_del_Info()
        {
        }

        protected void btnSave_Bill_OnClick(object sender, EventArgs e)
        {
            this.ButtonSaveClick_Bill(sender, e);
        }

        protected void btnSave_Ship_OnClick(object sender, EventArgs e)
        {
            this.ButtonSaveClick_Ship(sender, e);
        }

        protected void btnUpdate_Bill_OnClick(object sender, EventArgs e)
        {
            this.ButtonUpdateClick_Bill(sender, e);
        }

        protected void btnUpdate_Ship_OnClick(object sender, EventArgs e)
        {
            this.ButtonUpdateClick_Ship(sender, e);
        }

        protected void grd_Search_bill_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(base.Session["StoreUserID"].ToString()), "bill", (long)0, this.objBase.SpecialEncode(this.grd_Search_bill.Text));
            List<string> strs = new List<string>();
            List<string> strs1 = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                string str = string.Concat(row["AddressLabel"].ToString(), ", ", row["Address"].ToString());
                string empty = string.Empty;
                string[] strArrays = str.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        empty = string.Concat(empty, strArrays[i]);
                        empty = string.Concat(empty, ",");
                    }
                }
                empty = empty.TrimEnd(new char[] { ',' });
                strs.Add(this.objBase.SpecialDecode(empty));
                strs1.Add(row["Addressid"].ToString());
            }
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("AddressID", typeof(string));
            dataTable1.Columns.Add("Address", typeof(string));
            for (int j = 0; j < strs.Count; j++)
            {
                object[] item = new object[] { strs1[j], strs[j] };
                dataTable1.Rows.Add(item);
            }
            this.rdGrd_bill_Choose.DataSource = dataTable1;
            this.rdGrd_bill_Choose.DataBind();
        }

        protected void grd_Search_ship_OnTextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address_Grid(Convert.ToInt64(base.Session["StoreUserID"].ToString()), "bill", (long)0, this.objBase.SpecialEncode(this.grd_Search_ship.Text));
            List<string> strs = new List<string>();
            List<string> strs1 = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                string str = string.Concat(row["AddressLabel"].ToString(), ", ", row["Address"].ToString());
                string empty = string.Empty;
                string[] strArrays = str.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        empty = string.Concat(empty, strArrays[i]);
                        empty = string.Concat(empty, ",");
                    }
                }
                empty = empty.TrimEnd(new char[] { ',' });
                strs.Add(this.objBase.SpecialDecode(empty));
                strs1.Add(row["Addressid"].ToString());
            }
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("AddressID", typeof(string));
            dataTable1.Columns.Add("Address", typeof(string));
            for (int j = 0; j < strs.Count; j++)
            {
                object[] item = new object[] { strs1[j], strs[j] };
                dataTable1.Rows.Add(item);
            }
            this.rdgrd_ship_choose.DataSource = dataTable1;
            this.rdgrd_ship_choose.DataBind();
        }

        protected void lnkEdit_Bill_Click(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["BillingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                }
            }
        }

        protected void lnkEdit_Ship_Click(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = OrderBasePage.Select_Individual_Address(this.StoreUserID, Convert.ToInt64(base.Session["ShippingAddressID"]), (long)0);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtaddressLabelBilling.Text = baseClass.SpecialDecode(row["AddressLabel"].ToString());
                    this.txt_address_billing1.Text = baseClass.SpecialDecode(row["AddressLine1"].ToString());
                    this.txt_address_billing2.Text = baseClass.SpecialDecode(row["AddressLine2"].ToString());
                    this.txt_address_billing3.Text = baseClass.SpecialDecode(row["Address2"].ToString());
                    this.txt_address_billing4.Text = baseClass.SpecialDecode(row["Address3"].ToString());
                    this.txt_address_billing5.Text = baseClass.SpecialDecode(row["Address4"].ToString());
                    baseClass.SetDDLText(this.ddlCountry, row["Country"].ToString());
                    this.txt_telephone_billing.Text = row["phone"].ToString();
                    this.txt_fax_billing.Text = row["Fax"].ToString();
                }
            }
        }

        protected void lnkOrderDate_bill_Click(object sender, CommandEventArgs e)
        {
            this.ButtonClick_Bill(sender, e);
            this.grd_Search_bill.Text = string.Empty;
        }

        protected void lnkOrderDate_ship_Click(object sender, CommandEventArgs e)
        {
            this.ButtonClick_Ship(sender, e);
            this.grd_Search_ship.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            this.spnExample.InnerText = this.objLanguage.GetLanguageConversion("My_Home_address");
            this.lblInvoice_Address.Text = this.objLanguage.GetLanguageConversion("Invoice_Address");
            this.lblDelivery_Address.Text = this.objLanguage.GetLanguageConversion("Delivery_Address");
            this.lblNew_Address.Text = this.objLanguage.GetLanguageConversion("New_Address");
            this.lblEdit_Address.Text = this.objLanguage.GetLanguageConversion("Edit_Address");
            this.lblAddress_LAbel.Text = this.objLanguage.GetLanguageConversion("Address_label");
            this.lbl_Country.Text = this.objLanguage.GetLanguageConversion("Country");
            this.lbl_Telephne.Text = this.objLanguage.GetLanguageConversion("Telephone");
            this.lblFax.Text = this.objLanguage.GetLanguageConversion("Fax");
            this.spnExample.InnerText = this.objLanguage.GetLanguageConversion("Address_Example_Note");
            this.Required_Address1.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.Required_Address2.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.Required_Address3.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.Required_Address4.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.Required_Address5.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.Required_Country.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.btnSave_Bill.Text = this.objLanguage.GetLanguageConversion("Save_ANd_Use_This_Address");
            this.btnSave_Ship.Text = this.objLanguage.GetLanguageConversion("Save_ANd_Use_This_Address");
            this.btn_Update_bill.Text = this.objLanguage.GetLanguageConversion("Update");
            this.btn_Update_Ship.Text = this.objLanguage.GetLanguageConversion("Update");
            this.lblListofAllAddress.Text = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            this.lblAddress_Book.Text = this.objLanguage.GetLanguageConversion("Address_Book");
            this.spnList.InnerHtml = this.objLanguage.GetLanguageConversion("List_Of_Available_Address");
            this.BillingAddressID = Convert.ToInt64(base.Session["BillingAddressID"]);
            this.ShippingAddressID = Convert.ToInt64(base.Session["ShippingAddressID"]);
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
            }
            if (!base.IsPostBack)
            {
                this.rdGrd_bill_Choose.Rebind();
                this.rdgrd_ship_choose.Rebind();
            }
            if (ConnectionClass.SystemName != null && (ConnectionClass.SystemName.ToString() == "dmc2" || ConnectionClass.SystemName.ToString() == "DMC2"))
            {
                this.tdChooseAddress.Visible = false;
                this.tdChooseAddress1.Visible = false;
            }
            if (this.comm.GetDisplayValue("is_deliveryaddress_mandatory", this.AccountID).ToLower() == "false")
            {
                this.hdnChkDelAddress.Value = "1";
            }
            if (this.comm.GetDisplayValue("is_invoiceaddress_mandatory", this.AccountID).ToLower() == "false")
            {
                this.hdnChkInvAddress.Value = "1";
            }
            if (this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "false" && this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "true")
            {
                this.td_invaddr.Style.Add("display", "none");
                this.td_Inv_Choose.Style.Add("display", "none");
                this.td_Deladdr.Attributes.Add("colspan", "2");
                this.td_Del_Choose.Attributes.Add("colspan", "2");
                this.td_Deladdr.Style.Add("padding-left", "15px");
                this.td_Del_Choose.Style.Add("padding-left", "15px");
            }
            else if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false" && this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "true")
            {
                this.td_Deladdr.Style.Add("display", "none");
                this.td_Del_Choose.Style.Add("display", "none");
                this.td_invaddr.Attributes.Add("colspan", "2");
                this.td_Inv_Choose.Attributes.Add("colspan", "2");
            }
            else if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false" && this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "false")
            {
                this.td_Deladdr.Style.Add("display", "none");
                this.td_Del_Choose.Style.Add("display", "none");
                this.td_invaddr.Style.Add("display", "none");
                this.td_Inv_Choose.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "false")
            {
                this.td_invaddr.Style.Add("display", "none");
                this.td_Inv_Choose.Style.Add("display", "none");
                this.CopyAddress.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false")
            {
                this.td_Deladdr.Style.Add("display", "none");
                this.td_Del_Choose.Style.Add("display", "none");
                this.CopyInvtoDelAddress.Style.Add("display", "none");
            }
        }

        protected void rdGrd_bill_Choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && base.Session["BillingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() == base.Session["BillingAddressID"].ToString())
                {
                    e.Item.Selected = true;
                    return;
                }
                e.Item.Selected = false;
            }
        }

        protected void rdgrd_ship_choose_OnItemDataBound(object source, GridItemEventArgs e)
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            if ((e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item) && base.Session["ShippingAddressID"] != null)
            {
                if (dataItem["AddressID"].ToString() != base.Session["ShippingAddressID"].ToString())
                {
                    e.Item.Selected = false;
                }
                else
                {
                    e.Item.Selected = true;
                }
            }
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                radComboBox.Enabled = false;
                radComboBox.Visible = false;
            }
        }

        protected void rdgrd_ship_choose_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.rdgrd_ship_choose.DataSource = base.Session["AddressGrid"];
            this.rdGrd_bill_Choose.DataSource = base.Session["AddressGrid"];
        }

        public event EventHandler ButtonClick_Bill;

        public event EventHandler ButtonClick_Ship;

        public event EventHandler ButtonSaveClick_Bill;

        public event EventHandler ButtonSaveClick_Ship;

        public event EventHandler ButtonUpdateClick_Bill;

        public event EventHandler ButtonUpdateClick_Ship;
    }
}