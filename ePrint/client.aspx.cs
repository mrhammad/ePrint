using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint
{
    public partial class client : System.Web.UI.Page
    {

        protected HiddenField hdnsystemname;

        protected HiddenField hdncmpnyaddressid;

        protected Label lblAddCompany;

        protected Label lblEditCompany;

        protected HtmlGenericControl ColourPanel;

        protected Label lblcomptype;

        protected Label lblCompanyType;

        protected RadioButton rdProspect;

        protected RadioButton rdCustomer;

        protected Label lbl_companyname;

        protected TextBox txt_companyname;

        protected Label lbl_companyalias;

        protected TextBox txt_companyalias;

        protected Label lbl_type;

        protected RadComboBox ddl_type;

        protected Label lblcarrier;

        protected CheckBox chkcarrier;

        protected HtmlGenericControl div_Carrier;

        protected Label lbl_status;

        protected DropDownList ddl_status;

        protected Label lbl_account;

        protected TextBox txt_accountno;

        protected Label lbl_email;

        protected TextBox txt_email;

        protected Label lbl_emailValue;

        protected Label lbl_url;

        protected TextBox txt_url;

        protected Label lbl_urlValue;

        protected Label lbl_defaultinv;

        protected CheckBox chk_defaultinvoiceaddress;

        protected Label lbl_defaultdel;

        protected CheckBox chk_defaultdeliveryaddress;

        protected HtmlGenericControl div_DeliveryAddress1;

        protected Label lbl_credit;

        protected TextBox txt_creditlimit;

        protected Label lbl_creditref;

        protected TextBox txt_creditref;

        protected Label lbl_tax1;

        protected DropDownList ddl_tax1;

        protected Label lbl_tax2;

        protected DropDownList ddl_tax2;

        protected HtmlGenericControl div_Tax2;

        protected Label lbl_DeliveryAddress;

        protected Label lbl_Deliveryaddr1Value;

        protected Label lbl_Deliveryaddr2Value;

        protected Label lbl_Deliveryaddr3Value;

        protected Label lbl_Deliveryaddr4Value;

        protected Label lbl_Deliveryaddr5Value;

        protected Label lbl_DeliverycountryValue;

        protected Label lbl_DeliveryphoneValue;

        protected Label lbl_DeliveryfaxValue;

        protected LinkButton lnk_DeliveryEdit;

        protected Label lbl_DeliverySpliter;

        protected LinkButton lnk_DeliveryChange;

        protected HtmlGenericControl div_DeliveryAddressView;

        protected Label lbl_InvoiceAddress;

        protected Label lbl_Invoiceaddr1Value;

        protected Label lbl_Invoiceaddr2Value;

        protected Label lbl_Invoiceaddr3Value;

        protected Label lbl_Invoiceaddr4Value;

        protected Label lbl_Invoiceaddr5Value;

        protected Label lbl_InvoicecountryValue;

        protected Label lbl_InvoicephoneValue;

        protected Label lbl_InvoicefaxValue;

        protected LinkButton lnk_InvoiceEdit;

        protected Label lbl_InvoiceSpliter;

        protected LinkButton lnk_InvoiceChange;

        protected HtmlGenericControl div_InvoiceAddressView;

        protected Label lbl_terms;

        protected DropDownList ddl_PaymentTerms;

        protected HiddenField hdn_PaymentTerm;

        protected HiddenField hdn_PaymenttermID;

        protected Label lbl_PaymentTerm;

        protected Label lbl_days;

        protected Label lbl_profit;

        protected TextBox txt_profitmargin;

        protected Label lbl_taxno;

        protected TextBox txt_taxregno;

        protected Label lbl_companyno;

        protected TextBox txt_companyno;

        protected Label lbl_acopened;

        protected TextBox txt_acopened;

        protected Label lbl_code;

        protected TextBox txt_bankcode;

        protected Label lbl_bankacno;

        protected TextBox txt_bankacno;

        protected Label lbl_acname;

        protected TextBox txt_accountname;

        protected Label Label15;

        protected DropDownList ddl_salesperson;

        protected Label lbl_Referencedby;

        protected ImageButton ImgRefferedByAdd;

        protected HtmlGenericControl DivImgRefferedByAdd;

        protected TextBox txt_Referencedby;

        protected DropDownList ddl_Referencedby;

        protected HiddenField hdn_Referencedby;

        protected Label Label2;

        protected TextBox txt_taxnumber;

        protected Label Label3;

        protected TextBox txt_balance;

        protected HtmlGenericControl div_Supplier;

        protected Label Label4;

        protected CheckBox Chkcreate_identical_contact;

        protected HtmlGenericControl div_create_identical_contact;

        protected Label Label5;

        protected CheckBox ChkRoyalityFree;

        protected HtmlGenericControl DivChkRoyalityFree;

        protected Label AddressHeader;

        protected Label lbl_Deliveryaddr1;

        protected TextBox txt_Deliveryaddr1;

        protected Label lbl_Deliveryaddr2;

        protected TextBox txt_Deliveryaddr2;

        protected Label lbl_Deliveryaddr3;

        protected TextBox txt_Deliveryaddr3;

        protected Label lbl_Deliveryaddr4;

        protected TextBox txt_Deliveryaddr4;

        protected Label lbl_Deliveryaddr5;

        protected TextBox txt_Deliveryaddr5;

        protected Label lbl_Deliverycountry;

        protected DropDownList ddl_Deliverycountry;

        protected HtmlGenericControl divDeliverycountry;

        protected Label lbl_Deliveryphone;

        protected TextBox txt_Deliveryphone;

        protected HtmlGenericControl divDeliveryphone;

        protected Label lbl_Deliveryfax;

        protected TextBox txt_Deliveryfax;

        protected HtmlGenericControl divDeliveryfax;

        protected Label Label1;

        protected HtmlGenericControl div_edit_changeDelivery;

        protected HtmlGenericControl div_DeliveryAddress;

        protected Label lbl_desc;

        protected TextBox txt_description;

        protected HtmlGenericControl div_Description;

        protected Button btncancel;

        //protected Button btnsave;

        protected HtmlGenericControl Divdiv_btnsave;

        protected HtmlGenericControl content;

        protected RadWindowManager RadWindowManager1;

        protected HiddenField hid_ClientID;

        protected HiddenField hdn_DeliveryaddressID;

        protected HiddenField hdn_InvoiceaddressID;

        protected HiddenField hdn_companytype;

        protected HiddenField hdn_selectedcounter;

        protected HiddenField hdn_ddlreferedbySel;

        protected HiddenField hdn_ddlRefSelIndexOnEditLoad;

        protected Panel pnlWinClose;

        protected Panel pnlWinClose1;

        protected Panel pnl_Supp_Purchase;

        protected Panel pnlWinClose2;

        protected PlaceHolder plhDiv;

        protected Panel Panel_Inventoryadd;

        private Global gloobj = new Global();

        private BaseClass basecls = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private BasePage comnbasepage = new BasePage();

        private commonClass comncls = new commonClass();

        public string strImagepath = global.strimagepath;

        public languageClass objlang = new languageClass();

        public int CompanyID;

        public int UserID;

        public int ClientID;

        public int isnew = 2;

        public long rtnDeptID;

        public int retClientID;

        public long retAddressID;

        public long DeliveryAddressID;

        public long InvoiceAddressID;

        public int retContactID;

        public string strSitepath = global.sitePath();

        public string DateFormat = string.Empty;

        public string companytype = string.Empty;

        public string CountryName = string.Empty;

        public string pg = string.Empty;

        public string newdate = string.Empty;

        public string sender1 = string.Empty;

        public string action = string.Empty;

        public string postback = string.Empty;

        public string post = string.Empty;

        public string type = string.Empty;

        public string mode = string.Empty;

        public string id = string.Empty;

        public string estid = string.Empty;

        public string Tax2 = string.Empty;

        public string RedirectTo = string.Empty;

        public static string strFinalData;

        public string RequiredAddress = string.Empty;

        public string RequiredAddress1 = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        //protected void btnsave_onclick(object sender, EventArgs e)
        //{
        //    string[] invID;
        //    object[] str;
        //    string empty = string.Empty;
        //    string empty1 = string.Empty;
        //    string str1 = string.Empty;
        //    foreach (RadComboBoxItem item in this.ddl_type.Items)
        //    {
        //        if (!((CheckBox)item.FindControl("chk1")).Checked)
        //        {
        //            continue;
        //        }
        //        empty = string.Concat(empty, item.Text, "±");
        //        empty1 = string.Concat(empty1, item.Value, ",");
        //        str1 = string.Concat(str1, item.Text, ", ");
        //    }
        //    if (empty1 == "")
        //    {
        //        empty1 = "0,";
        //        empty = "±";
        //        str1 = ", ";
        //    }
        //    string[] strArrays = empty1.ToString().Split(new char[] { ',' });
        //    string[] strArrays1 = empty.ToString().Split(new char[] { '±' });
        //    empty1 = empty1.Substring(0, empty1.Length - 1);
        //    str1 = str1.Substring(0, str1.Length - 2);
        //    bool @checked = this.chk_defaultdeliveryaddress.Checked;
        //    bool flag = this.chk_defaultinvoiceaddress.Checked;
        //    string empty2 = string.Empty;
        //    int num = 0;
        //    if (this.chkcarrier.Checked)
        //    {
        //        num = 1;
        //    }
        //    bool flag1 = false;
        //    flag1 = (!this.ChkRoyalityFree.Checked ? false : true);
        //    string str2 = "1/1/1900";
        //    if (this.txt_acopened.Text != "")
        //    {
        //        str2 = this.comncls.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txt_acopened.Text);
        //    }
        //    DateTime now = DateTime.Now;
        //    this.txt_profitmargin.Text = this.txt_profitmargin.Text.Replace("%", "");
        //    this.txt_profitmargin.Text = this.txt_profitmargin.Text.Replace(",", "");
        //    empty2 = (this.txt_profitmargin.Text == "" ? Convert.ToString(0) : this.basecls.SpecialEncode(this.txt_profitmargin.Text));
        //    if (this.postback == "estimate" || this.postback == "estimates")
        //    {
        //        this.rdProspect.Checked = true;
        //        if (this.rdCustomer.Checked)
        //        {
        //            this.lblCompanyType.Text = "Customer";
        //        }
        //        else if (this.rdProspect.Checked)
        //        {
        //            this.lblCompanyType.Text = "Prospect";
        //        }
        //    }
        //    if (base.Request.QueryString["item"] != null && base.Request.QueryString["item"] == "Outwork")
        //    {
        //        this.lblCompanyType.Text = "Supplier";
        //        this.lblCompanyType.Visible = true;
        //    }
        //    if (base.Request.Params["type"] != null)
        //    {
        //        if (this.ddl_Deliverycountry.SelectedItem.Text.ToString().Equals("--- Select ---"))
        //        {
        //            foreach (DataRow row in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
        //            {
        //                for (int i = 0; i < this.ddl_Deliverycountry.Items.Count; i++)
        //                {
        //                    if (this.ddl_Deliverycountry.Items[i].ToString() == row["Country"].ToString())
        //                    {
        //                        this.ddl_Deliverycountry.SelectedIndex = i;
        //                    }
        //                }
        //            }
        //        }
        //        if (base.Session["Flag"] != null)
        //        {
        //            if (base.Session["Flag"].ToString().ToLower() != "true")
        //            {
        //                this.retClientID = CompanyBasePage.Company_InsertUpdate(
        //                    this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value),
        //                    this.lblCompanyType.Text,
        //                    this.basecls.SpecialEncode(this.txt_companyname.Text),
        //                    this.basecls.SpecialEncode(this.txt_companyalias.Text),
        //                    this.basecls.SpecialEncode(this.ddl_type.SelectedValue),
        //                    this.basecls.SpecialEncode(this.ddl_status.SelectedValue),
        //                    this.basecls.SpecialEncode(this.txt_accountno.Text),
        //                    this.basecls.SpecialEncode(this.txt_email.Text),
        //                    this.basecls.SpecialEncode(this.txt_url.Text),
        //                    this.basecls.SpecialEncode(this.txt_creditlimit.Text),
        //                    this.basecls.SpecialEncode(this.txt_creditref.Text),
        //                    Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)),
        //                    Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)),
        //                    this.basecls.SpecialEncode(this.txt_taxregno.Text),
        //                    this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue),
        //                    this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2),
        //                    this.basecls.SpecialEncode(this.txt_bankcode.Text),
        //                    this.basecls.SpecialEncode(this.txt_bankacno.Text),
        //                    this.basecls.SpecialEncode(this.txt_accountname.Text),
        //                    Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)),
        //                    this.basecls.SpecialEncode(this.txt_taxnumber.Text),
        //                    this.basecls.SpecialEncode(this.txt_balance.Text),
        //                    this.basecls.SpecialEncode(this.txt_description.Text), now,
        //                    this.UserID, Convert.ToInt32(this.ddl_Referencedby.SelectedValue), num, flag1,
        //                    this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1));
        //            }
        //            else
        //            {
        //                this.retClientID = CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.hdn_Referencedby.Value), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1));
        //            }
        //        }
        //        this.hid_ClientID.Value = this.retClientID.ToString();
        //        for (int j = 0; j < (int)strArrays.Length - 1; j++)
        //        {
        //            CompanyBasePage.crm_clientType_add((long)this.CompanyID, (long)this.retClientID, Convert.ToInt64(this.basecls.SpecialEncode(strArrays[j])), this.basecls.SpecialEncode(strArrays1[j]));
        //        }
        //        long num1 = (long)0;
        //        long num2 = Convert.ToInt64(this.retClientID);
        //        string str3 = this.basecls.SpecialEncode(this.txt_Deliveryaddr1.Text);
        //        string str4 = this.basecls.SpecialEncode(this.txt_Deliveryaddr3.Text);
        //        string str5 = this.basecls.SpecialEncode(this.txt_Deliveryaddr4.Text);
        //        string str6 = this.basecls.SpecialEncode(this.txt_Deliveryaddr5.Text);
        //        string str7 = this.basecls.SpecialEncode(this.ddl_Deliverycountry.SelectedItem.Text);
        //        string str8 = this.basecls.SpecialEncode(this.txt_Deliveryphone.Text);
        //        string str9 = this.basecls.SpecialEncode(this.txt_Deliveryfax.Text);
        //        string str10 = this.basecls.SpecialEncode(this.txt_url.Text);
        //        int userID = this.UserID;
        //        DateTime dateTime = DateTime.Now;
        //        this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num1, num2, str3, str4, str5, str6, str7, str8, str9, str10, userID, dateTime.ToString(), "Main", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
        //        this.rtnDeptID = DepartmentBaseClass.departmentInsert((long)0, "Main", this.retClientID, this.retContactID, this.UserID, Convert.ToInt32(this.retAddressID), "A", DateTime.Now, DateTime.Now, this.CompanyID, (long)Convert.ToInt32(this.retAddressID), 0, 0, "N", Convert.ToBoolean(0), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", (long)0, "", "");
        //        if (this.Chkcreate_identical_contact.Checked)
        //        {
        //            string empty3 = string.Empty;
        //            string empty4 = string.Empty;
        //            string empty5 = string.Empty;
        //            string empty6 = string.Empty;
        //            string text = this.txt_companyname.Text;
        //            string[] strArrays2 = text.Split(new char[] { ' ' });
        //            try
        //            {
        //                if ((int)strArrays2.Length <= 0)
        //                {
        //                    empty3 = text;
        //                }
        //                else if ((int)strArrays2.Length > 2)
        //                {
        //                    empty3 = strArrays2[0];
        //                    empty4 = strArrays2[1];
        //                    for (int k = 2; k < (int)strArrays2.Length; k++)
        //                    {
        //                        empty5 = string.Concat(empty5, strArrays2[k], " ");
        //                    }
        //                }
        //                else if ((int)strArrays2.Length != 2)
        //                {
        //                    empty3 = strArrays2[0];
        //                }
        //                else
        //                {
        //                    empty3 = strArrays2[0];
        //                    empty5 = strArrays2[1];
        //                }
        //            }
        //            catch
        //            {
        //            }
        //            empty6 = string.Concat(empty3, "_", empty5);
        //            this.retContactID = CompanyBasePage.Contact_InsertUpdate(this.CompanyID, 0, Convert.ToInt32(this.retClientID), "", this.basecls.SpecialEncode(empty3.ToString()), this.basecls.SpecialEncode(empty4.ToString()), this.basecls.SpecialEncode(empty5.ToString()), this.basecls.SpecialEncode(empty6.ToString()), this.basecls.SpecialEncode(this.txt_companyname.Text), "", "", this.basecls.SpecialEncode(this.txt_Deliveryphone.Text), "", this.basecls.SpecialEncode(this.txt_email.Text), 0, this.UserID, this.rtnDeptID, this.basecls.SpecialEncode(this.txt_Deliveryfax.Text), Convert.ToInt32(this.retAddressID), true, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        //        }
        //        try
        //        {
        //            if (this.sender1.ToLower() == "popup")
        //            {
        //                if (this.postback == null || !(this.postback.ToLower() == "purchase"))
        //                {
        //                    this.pnlWinClose1.Visible = true;
        //                }
        //                else
        //                {
        //                    this.pnl_Supp_Purchase.Visible = true;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        if (this.post != "" && (this.post == "estimates" || this.type == "inventory"))
        //        {
        //            if (this.mode != "add")
        //            {
        //                base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_warehouse.aspx?page=FrmWareList", this.jID, this.InvID));
        //            }
        //            else
        //            {
        //                HttpResponse response = base.Response;
        //                invID = new string[] { this.strSitepath, "estimates/estimate_warehouse.aspx?page=FrmWareList&type=", this.mode, "&estid=", this.id, this.jID, this.InvID };
        //                response.Redirect(string.Concat(invID));
        //            }
        //        }
        //        if (this.postback == "")
        //        {
        //            QueryString queryString = new QueryString()
        //            {
        //                { "clientid", this.retClientID.ToString() },
        //                { "isnew", "2" },
        //                { "bypass", "1" },
        //                { "type", this.companytype },
        //                { "suc", "in" }
        //            };
        //            string str11 = "client/client_detail.aspx";
        //            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
        //            str11 = string.Concat(str11, queryString1.ToString());
        //            base.Response.Redirect(string.Concat(this.strSitepath, str11));
        //        }
        //        else
        //        {
        //            if (this.postback == "accounts")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_new_create.aspx?type=Customer", this.jID, this.InvID));
        //                    return;
        //                }
        //                HttpResponse httpResponse = base.Response;
        //                string[] invID1 = new string[] { this.strSitepath, "Accounts/accounts_new_create.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
        //                httpResponse.Redirect(string.Concat(invID1));
        //                return;
        //            }
        //            if (this.postback == "inv")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    HttpResponse response1 = base.Response;
        //                    string[] value = new string[] { this.strSitepath, "warehouse/inventory_add.aspx?suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                    response1.Redirect(string.Concat(value));
        //                    return;
        //                }
        //                HttpResponse httpResponse1 = base.Response;
        //                string[] value1 = new string[] { this.strSitepath, "warehouse/inventory_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                httpResponse1.Redirect(string.Concat(value1));
        //                return;
        //            }
        //            if (this.postback == "store")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=store", this.jID, this.InvID));
        //                    return;
        //                }
        //                HttpResponse response2 = base.Response;
        //                string[] invID2 = new string[] { this.strSitepath, "warehouse/item_finishedgoods_add?page=store&type=", this.mode, "&id=", this.id, this.jID, this.InvID };
        //                response2.Redirect(string.Concat(invID2));
        //                return;
        //            }
        //            if (this.postback == "item")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/item_finishedgoods_add.aspx?page=item", this.jID, this.InvID));
        //                    return;
        //                }
        //                HttpResponse httpResponse2 = base.Response;
        //                string[] invID3 = new string[] { this.strSitepath, "warehouse/item_finishedgoods_add?page=item&type=", this.mode, "&id=", this.id, this.jID, this.InvID };
        //                httpResponse2.Redirect(string.Concat(invID3));
        //                return;
        //            }
        //            if (this.postback == "estimate" || this.postback == "estimates")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
        //                    {
        //                        object[] objArray = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.txt_companyname.Text, "~", this.retContactID };
        //                        client_add.strFinalData = string.Concat(objArray);
        //                        this.pnlWinClose.Visible = true;
        //                        return;
        //                    }
        //                    if (this.retContactID == 0)
        //                    {
        //                        if (this.ddl_salesperson.SelectedValue == "0")
        //                        {
        //                            HttpResponse response3 = base.Response;
        //                            string[] value2 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                            response3.Redirect(string.Concat(value2));
        //                            return;
        //                        }
        //                        HttpResponse httpResponse3 = base.Response;
        //                        string[] value3 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                        httpResponse3.Redirect(string.Concat(value3));
        //                        return;
        //                    }
        //                    if (this.ddl_salesperson.SelectedValue == "0")
        //                    {
        //                        HttpResponse response4 = base.Response;
        //                        object[] objArray1 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                        response4.Redirect(string.Concat(objArray1));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse4 = base.Response;
        //                    object[] objArray2 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                    httpResponse4.Redirect(string.Concat(objArray2));
        //                    return;
        //                }
        //                if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
        //                {
        //                    str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.txt_companyname.Text, "~", this.retContactID };
        //                    client_add.strFinalData = string.Concat(str);
        //                    this.pnlWinClose.Visible = true;
        //                    return;
        //                }
        //                if (this.retContactID == 0)
        //                {
        //                    if (this.ddl_salesperson.SelectedValue == "0")
        //                    {
        //                        HttpResponse response5 = base.Response;
        //                        string[] strArrays3 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
        //                        response5.Redirect(string.Concat(strArrays3));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse5 = base.Response;
        //                    string[] value4 = new string[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, "&cntct=new", this.jID, this.InvID };
        //                    httpResponse5.Redirect(string.Concat(value4));
        //                    return;
        //                }
        //                if (this.ddl_salesperson.SelectedValue == "0")
        //                {
        //                    HttpResponse response6 = base.Response;
        //                    object[] objArray3 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                    response6.Redirect(string.Concat(objArray3));
        //                    return;
        //                }
        //                HttpResponse httpResponse6 = base.Response;
        //                object[] objArray4 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                httpResponse6.Redirect(string.Concat(objArray4));
        //                return;
        //            }
        //            if (this.postback == "job" || this.postback == "jobs")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
        //                    {
        //                        str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.txt_companyname.Text, "~", this.retContactID };
        //                        client_add.strFinalData = string.Concat(str);
        //                        this.pnlWinClose.Visible = true;
        //                        return;
        //                    }
        //                    if (this.retContactID == 0)
        //                    {
        //                        if (this.ddl_salesperson.SelectedValue == "0")
        //                        {
        //                            HttpResponse response7 = base.Response;
        //                            invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                            response7.Redirect(string.Concat(invID));
        //                            return;
        //                        }
        //                        HttpResponse httpResponse7 = base.Response;
        //                        invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                        httpResponse7.Redirect(string.Concat(invID));
        //                        return;
        //                    }
        //                    if (this.ddl_salesperson.SelectedValue == "0")
        //                    {
        //                        HttpResponse response8 = base.Response;
        //                        str = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                        response8.Redirect(string.Concat(str));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse8 = base.Response;
        //                    str = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                    httpResponse8.Redirect(string.Concat(str));
        //                    return;
        //                }
        //                if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
        //                {
        //                    str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.txt_companyname.Text, "~", this.retContactID };
        //                    client_add.strFinalData = string.Concat(str);
        //                    this.pnlWinClose.Visible = true;
        //                    return;
        //                }
        //                if (this.retContactID == 0)
        //                {
        //                    if (this.ddl_salesperson.SelectedValue == "0")
        //                    {
        //                        HttpResponse response9 = base.Response;
        //                        invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
        //                        response9.Redirect(string.Concat(invID));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse9 = base.Response;
        //                    invID = new string[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, "&cntct=new", this.jID, this.InvID };
        //                    httpResponse9.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                if (this.ddl_salesperson.SelectedValue == "0")
        //                {
        //                    HttpResponse response10 = base.Response;
        //                    str = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                    response10.Redirect(string.Concat(str));
        //                    return;
        //                }
        //                HttpResponse httpResponse10 = base.Response;
        //                str = new object[] { this.strSitepath, "jobs/job_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                httpResponse10.Redirect(string.Concat(str));
        //                return;
        //            }
        //            if (this.postback == "invoice")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
        //                    {
        //                        str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.txt_companyname.Text, "~", this.retContactID };
        //                        client_add.strFinalData = string.Concat(str);
        //                        this.pnlWinClose.Visible = true;
        //                        return;
        //                    }
        //                    if (this.retContactID == 0)
        //                    {
        //                        if (this.ddl_salesperson.SelectedValue == "0")
        //                        {
        //                            HttpResponse response11 = base.Response;
        //                            invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                            response11.Redirect(string.Concat(invID));
        //                            return;
        //                        }
        //                        HttpResponse httpResponse11 = base.Response;
        //                        invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                        httpResponse11.Redirect(string.Concat(invID));
        //                        return;
        //                    }
        //                    if (this.ddl_salesperson.SelectedValue == "0")
        //                    {
        //                        HttpResponse response12 = base.Response;
        //                        str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                        response12.Redirect(string.Concat(str));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse12 = base.Response;
        //                    str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                    httpResponse12.Redirect(string.Concat(str));
        //                    return;
        //                }
        //                if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
        //                {
        //                    str = new object[] { this.retClientID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.txt_companyname.Text, "~", this.retContactID };
        //                    client_add.strFinalData = string.Concat(str);
        //                    this.pnlWinClose.Visible = true;
        //                    return;
        //                }
        //                if (this.retContactID == 0)
        //                {
        //                    if (this.ddl_salesperson.SelectedValue == "0")
        //                    {
        //                        HttpResponse response13 = base.Response;
        //                        invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
        //                        response13.Redirect(string.Concat(invID));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse13 = base.Response;
        //                    invID = new string[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&salperson=", this.ddl_salesperson.SelectedValue, "&cntct=new", this.jID, this.InvID };
        //                    httpResponse13.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                if (this.ddl_salesperson.SelectedValue == "0")
        //                {
        //                    HttpResponse response14 = base.Response;
        //                    str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                    response14.Redirect(string.Concat(str));
        //                    return;
        //                }
        //                HttpResponse httpResponse14 = base.Response;
        //                str = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=", this.mode, "&estid=", this.id, "&ReRun=Y&clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, "&salperson=", this.ddl_salesperson.SelectedValue, this.jID, this.InvID };
        //                httpResponse14.Redirect(string.Concat(str));
        //                return;
        //            }
        //            if (this.postback == "purchase")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    if (this.retContactID == 0)
        //                    {
        //                        HttpResponse response15 = base.Response;
        //                        invID = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                        response15.Redirect(string.Concat(invID));
        //                        return;
        //                    }
        //                    HttpResponse httpResponse15 = base.Response;
        //                    str = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&suplrid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                    httpResponse15.Redirect(string.Concat(str));
        //                    return;
        //                }
        //                if (this.retContactID == 0)
        //                {
        //                    HttpResponse response16 = base.Response;
        //                    invID = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, "&cntct=new", this.jID, this.InvID };
        //                    response16.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                HttpResponse httpResponse16 = base.Response;
        //                str = new object[] { this.strSitepath, "purchase/purchase_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                httpResponse16.Redirect(string.Concat(str));
        //                return;
        //            }
        //            if (this.postback == "delivery")
        //            {
        //                if (this.mode == "edit")
        //                {
        //                    HttpResponse response17 = base.Response;
        //                    invID = new string[] { this.strSitepath, "delivery/delivery_add.aspx?type=", this.mode, "&id=", this.id, "&clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                    response17.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                if (this.retContactID == 0)
        //                {
        //                    HttpResponse httpResponse17 = base.Response;
        //                    invID = new string[] { this.strSitepath, "delivery/delivery_add.aspx?clientid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                    httpResponse17.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                HttpResponse response18 = base.Response;
        //                str = new object[] { this.strSitepath, "delivery/delivery_add.aspx?clientid=", this.hid_ClientID.Value, "&contactid=", this.retContactID, this.jID, this.InvID };
        //                response18.Redirect(string.Concat(str));
        //                return;
        //            }
        //            if (this.postback == "ContactAdd")
        //            {
        //                if (this.mode == "edit")
        //                {
        //                    HttpResponse httpResponse18 = base.Response;
        //                    invID = new string[] { this.strSitepath, "client/contact_add.aspx?type=", this.mode, "&id=", this.id, this.jID, this.InvID };
        //                    httpResponse18.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                HttpResponse response19 = base.Response;
        //                str = new object[] { this.strSitepath, "client/contact_add.aspx?type=", this.companytype, "&id=", this.retClientID, this.jID, this.InvID };
        //                response19.Redirect(string.Concat(str));
        //                return;
        //            }
        //            if (this.postback == "othercost")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    HttpResponse httpResponse19 = base.Response;
        //                    invID = new string[] { this.strSitepath, "settings/othercost_add.aspx?suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                    httpResponse19.Redirect(string.Concat(invID));
        //                    return;
        //                }
        //                HttpResponse response20 = base.Response;
        //                invID = new string[] { this.strSitepath, "settings/othercost_add.aspx?type=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                response20.Redirect(string.Concat(invID));
        //                return;
        //            }
        //            if (this.postback == "settings")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    HttpResponse httpResponse20 = base.Response;
        //                    str = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?suplrid=", this.hid_ClientID.Value, "&clientID=", this.ClientID, "&from=", this.RedirectTo, this.jID, this.InvID };
        //                    httpResponse20.Redirect(string.Concat(str));
        //                    return;
        //                }
        //                HttpResponse response21 = base.Response;
        //                str = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, "&clientID=", this.ClientID, "&from=", this.RedirectTo, this.jID, this.InvID };
        //                response21.Redirect(string.Concat(str));
        //                return;
        //            }
        //            if (this.postback == "estimate1")
        //            {
        //                if (this.mode != "edit")
        //                {
        //                    base.Response.Redirect(string.Concat(this.strSitepath, "common/common_popup.aspx?type=Paper&pg=estimate&item=Paper", this.jID, this.InvID));
        //                    return;
        //                }
        //                this.id = "0";
        //                HttpResponse httpResponse21 = base.Response;
        //                invID = new string[] { this.strSitepath, "common/common_popup.aspx?type=Paper&pg=estimate&item=Paper&action=", this.mode, "&id=", this.id, "&suplrid=", this.hid_ClientID.Value, this.jID, this.InvID };
        //                httpResponse21.Redirect(string.Concat(invID));
        //                return;
        //            }
        //        }
        //    }
        //    else if (this.action != "" && this.action == "edit")
        //    {
        //        if (this.ddl_Deliverycountry.SelectedItem.Text.ToString().Equals("--- Select ---"))
        //        {
        //            foreach (DataRow dataRow in SettingsBasePage.settings_companyprofile_select(this.CompanyID).Rows)
        //            {
        //                for (int l = 0; l < this.ddl_Deliverycountry.Items.Count; l++)
        //                {
        //                    if (this.ddl_Deliverycountry.Items[l].ToString() == dataRow["Country"].ToString())
        //                    {
        //                        this.ddl_Deliverycountry.SelectedIndex = l;
        //                    }
        //                }
        //            }
        //        }
        //        if (base.Session["Flag"] != null)
        //        {
        //            if (base.Session["Flag"].ToString().ToLower() != "true")
        //            {
        //                CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.ddl_Referencedby.SelectedValue), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1));
        //            }
        //            else
        //            {
        //                CompanyBasePage.Company_InsertUpdate(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.lblCompanyType.Text, this.basecls.SpecialEncode(this.txt_companyname.Text), this.basecls.SpecialEncode(this.txt_companyalias.Text), this.basecls.SpecialEncode(this.ddl_type.SelectedValue), this.basecls.SpecialEncode(this.ddl_status.SelectedValue), this.basecls.SpecialEncode(this.txt_accountno.Text), this.basecls.SpecialEncode(this.txt_email.Text), this.basecls.SpecialEncode(this.txt_url.Text), this.basecls.SpecialEncode(this.txt_creditlimit.Text), this.basecls.SpecialEncode(this.txt_creditref.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax1.SelectedValue)), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_tax2.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxregno.Text), this.basecls.SpecialEncode(this.ddl_PaymentTerms.SelectedValue), this.basecls.SpecialEncode(this.txt_companyno.Text), empty2, Convert.ToDateTime(str2), this.basecls.SpecialEncode(this.txt_bankcode.Text), this.basecls.SpecialEncode(this.txt_bankacno.Text), this.basecls.SpecialEncode(this.txt_accountname.Text), Convert.ToInt32(this.basecls.SpecialEncode(this.ddl_salesperson.SelectedValue)), this.basecls.SpecialEncode(this.txt_taxnumber.Text), this.basecls.SpecialEncode(this.txt_balance.Text), this.basecls.SpecialEncode(this.txt_description.Text), now, this.UserID, Convert.ToInt32(this.hdn_Referencedby.Value), num, flag1, this.basecls.SpecialEncode(empty1), this.basecls.SpecialEncode(str1));
        //            }
        //            for (int m = 0; m < (int)strArrays.Length - 1; m++)
        //            {
        //                CompanyBasePage.crm_clientType_add((long)this.CompanyID, Convert.ToInt64(this.hid_ClientID.Value), Convert.ToInt64(this.basecls.SpecialEncode(strArrays[m])), this.basecls.SpecialEncode(strArrays1[m]));
        //            }
        //        }
        //        if (this.hdncmpnyaddressid.Value != "0" && (this.lblCompanyType.Text.ToLower() == "customer" || this.lblCompanyType.Text.ToLower() == "prospect" || this.lblCompanyType.Text.ToLower() == "supplier"))
        //        {
        //            long num3 = Convert.ToInt64(this.hdncmpnyaddressid.Value);
        //            long num4 = Convert.ToInt64(this.retClientID);
        //            string str12 = this.basecls.SpecialEncode(this.txt_Deliveryaddr1.Text);
        //            string str13 = this.basecls.SpecialEncode(this.txt_Deliveryaddr3.Text);
        //            string str14 = this.basecls.SpecialEncode(this.txt_Deliveryaddr4.Text);
        //            string str15 = this.basecls.SpecialEncode(this.txt_Deliveryaddr5.Text);
        //            string str16 = this.basecls.SpecialEncode(this.ddl_Deliverycountry.SelectedItem.Text);
        //            string str17 = this.basecls.SpecialEncode(this.txt_Deliveryphone.Text);
        //            string str18 = this.basecls.SpecialEncode(this.txt_Deliveryfax.Text);
        //            string str19 = this.basecls.SpecialEncode(this.txt_url.Text);
        //            int userID1 = this.UserID;
        //            DateTime now1 = DateTime.Now;
        //            this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num3, num4, str12, str13, str14, str15, str16, str17, str18, str19, userID1, now1.ToString(), "Main", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
        //        }
        //        else if (this.lblCompanyType.Text.ToLower() == "customer" || this.lblCompanyType.Text.ToLower() == "prospect" || this.lblCompanyType.Text.ToLower() == "supplier")
        //        {
        //            long num5 = (long)0;
        //            long num6 = (long)Convert.ToInt32(this.hid_ClientID.Value);
        //            string str20 = this.basecls.SpecialEncode(this.txt_Deliveryaddr1.Text);
        //            string str21 = this.basecls.SpecialEncode(this.txt_Deliveryaddr3.Text);
        //            string str22 = this.basecls.SpecialEncode(this.txt_Deliveryaddr4.Text);
        //            string str23 = this.basecls.SpecialEncode(this.txt_Deliveryaddr5.Text);
        //            string str24 = this.basecls.SpecialEncode(this.ddl_Deliverycountry.SelectedItem.Text);
        //            string str25 = this.basecls.SpecialEncode(this.txt_Deliveryphone.Text);
        //            string str26 = this.basecls.SpecialEncode(this.txt_Deliveryfax.Text);
        //            string str27 = this.basecls.SpecialEncode(this.txt_url.Text);
        //            int userID2 = this.UserID;
        //            DateTime dateTime1 = DateTime.Now;
        //            this.retAddressID = CompanyBasePage.CompanyDefaultAddress_InsertUpdate(num5, num6, str20, str21, str22, str23, str24, str25, str26, str27, userID2, dateTime1.ToString(), "Main", this.basecls.SpecialEncode(this.txt_Deliveryaddr2.Text), this.basecls.SpecialEncode(this.txt_email.Text), "N");
        //        }
        //        QueryString queryString2 = new QueryString()
        //        {
        //            { "clientid", this.hid_ClientID.Value },
        //            { "isnew", "2" },
        //            { "bypass", "1" },
        //            { "type", this.companytype },
        //            { "suc", "up" }
        //        };
        //        string str28 = string.Concat("client/client_detail.aspx", this.jID, this.InvID);
        //        QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
        //        str28 = string.Concat(str28, queryString3.ToString());
        //        base.Response.Redirect(string.Concat(this.strSitepath, str28));
        //        return;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnsave_onclick(object sender, EventArgs e)
        {
            CompanyBasePage.Company_InsertUpdate(111111,
                Convert.ToInt32(0),
                "Test Company",
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                Convert.ToInt32(1),
                Convert.ToInt32(1),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                "1",
                Convert.ToDateTime(DateTime.Now),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                Convert.ToInt32(1),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"),
                DateTime.Now,
                1,
                Convert.ToInt32(1),
                1,
                false,
                this.basecls.SpecialEncode("1"),
                this.basecls.SpecialEncode("1"));
        }

    }
}